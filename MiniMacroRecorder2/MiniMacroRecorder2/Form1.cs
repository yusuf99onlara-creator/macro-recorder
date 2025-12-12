using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMacroRecorder2
{
    public partial class Form1 : Form
    {
        #region Constants & Enums

        private enum ActionType
        {
            MouseMove, LeftDown, LeftUp, RightDown, RightUp,
            MiddleDown, MiddleUp, ScrollUp, ScrollDown,
            KeyDown, KeyUp, Delay
        }

        private class MacroAction
        {
            public ActionType Type;
            public int X, Y, Vk, DelayMs, ScrollAmount;

            public override string ToString()
            {
                string icon = GetIcon();
                string keyName = Vk > 0 ? ((Keys)Vk).ToString() : "";
                return string.Format("{0} {1,5}ms | {2,-12} | X:{3,4} Y:{4,4} | {5}",
                    icon, DelayMs, Type, X, Y, keyName);
            }

            private string GetIcon()
            {
                switch (Type)
                {
                    case ActionType.MouseMove: return "→";
                    case ActionType.LeftDown: return "▼L";
                    case ActionType.LeftUp: return "▲L";
                    case ActionType.RightDown: return "▼R";
                    case ActionType.RightUp: return "▲R";
                    case ActionType.MiddleDown: return "▼M";
                    case ActionType.MiddleUp: return "▲M";
                    case ActionType.ScrollUp: return "↑S";
                    case ActionType.ScrollDown: return "↓S";
                    case ActionType.KeyDown: return "↓K";
                    case ActionType.KeyUp: return "↑K";
                    case ActionType.Delay: return "⏱";
                    default: return "•";
                }
            }

            public string Serialize()
            {
                return string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                    (int)Type, X, Y, Vk, DelayMs, ScrollAmount);
            }

            public static MacroAction Deserialize(string line)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    MacroAction a = new MacroAction();
                    a.Type = (ActionType)int.Parse(parts[0]);
                    a.X = int.Parse(parts[1]);
                    a.Y = int.Parse(parts[2]);
                    a.Vk = int.Parse(parts[3]);
                    a.DelayMs = int.Parse(parts[4]);
                    if (parts.Length >= 6) a.ScrollAmount = int.Parse(parts[5]);
                    return a;
                }
                return null;
            }
        }

        #endregion

        #region Fields

        private readonly List<MacroAction> _actions = new List<MacroAction>();
        private readonly Stopwatch _sw = new Stopwatch();
        private long _lastTick;
        private bool _isRecording = false;
        private bool _isPlaying = false;
        private bool _isPaused = false;

        private CancellationTokenSource _playCts;
        private Random _random = new Random();

        private System.Windows.Forms.Timer _clickerTimer;
        private bool _clickerRunning = false;
        private int _clickCount = 0;

        private System.Windows.Forms.Timer _autoKeyTimer;
        private bool _autoKeyRunning = false;
        private int _keyPressCount = 0;
        private int _sequenceIndex = 0;

        private System.Windows.Forms.Timer _autoScrollTimer;
        private bool _autoScrollRunning = false;

        private int _lastMoveX, _lastMoveY;
        private long _lastMoveTick;

        private bool _pickingPosition = false;
        private bool _capturingKey = false;

        private HotkeyManager _hotkeyManager;
        private Dictionary<string, Keys> _hotkeyBindings = new Dictionary<string, Keys>();

        private IntPtr _mouseHook = IntPtr.Zero;
        private IntPtr _keyboardHook = IntPtr.Zero;
        private LowLevelMouseProc _mouseProc;
        private LowLevelKeyboardProc _keyboardProc;

        #endregion

        #region Constructor & Load

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _clickerTimer = new System.Windows.Forms.Timer();
            _clickerTimer.Tick += ClickerTimer_Tick;

            _autoKeyTimer = new System.Windows.Forms.Timer();
            _autoKeyTimer.Tick += AutoKeyTimer_Tick;

            _autoScrollTimer = new System.Windows.Forms.Timer();
            _autoScrollTimer.Tick += AutoScrollTimer_Tick;

            PopulateKeyComboBox(cmbKeyToPress);

            tmrMouseInfo.Interval = 50;
            tmrMouseInfo.Start();

            InitializeHotkeys();

            UpdateStatus("Ready", Color.FromArgb(100, 255, 150));

            try
            {
                notifyIcon.Icon = SystemIcons.Application;
            }
            catch { }

            LoadSettingsIfExists();
        }

        private void LoadSettingsIfExists()
        {
            try
            {
                if (File.Exists("settings.ini"))
                    LoadSettings();
            }
            catch { }
        }

        private void PopulateKeyComboBox(ComboBox cmb)
        {
            cmb.Items.Clear();
            for (char c = 'A'; c <= 'Z'; c++)
                cmb.Items.Add(c.ToString());
            for (int i = 0; i <= 9; i++)
                cmb.Items.Add("D" + i);
            for (int i = 1; i <= 12; i++)
                cmb.Items.Add("F" + i);

            string[] specialKeys = { "Space", "Enter", "Tab", "Escape", "Back", "Delete",
                "Insert", "Home", "End", "PageUp", "PageDown", "Up", "Down", "Left", "Right",
                "LControlKey", "LShiftKey", "LMenu" };
            foreach (string key in specialKeys)
                cmb.Items.Add(key);

            if (cmb.Items.Count > 0)
                cmb.SelectedIndex = 0;
        }

        private void InitializeHotkeys()
        {
            _hotkeyBindings["Record"] = Keys.F6;
            _hotkeyBindings["StopRecord"] = Keys.F7;
            _hotkeyBindings["Play"] = Keys.F8;
            _hotkeyBindings["StopPlay"] = Keys.F9;
            _hotkeyBindings["Clicker"] = Keys.F10;
            _hotkeyBindings["AutoKey"] = Keys.F11;
            _hotkeyBindings["Panic"] = Keys.F12;

            RegisterAllHotkeys();
            UpdateHotkeyLabels();
        }

        private void RegisterAllHotkeys()
        {
            if (_hotkeyManager != null)
                _hotkeyManager.Dispose();

            _hotkeyManager = new HotkeyManager(this.Handle);

            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["Record"], () =>
            {
                if (!_isRecording) Invoke(new Action(() => btnRecord_Click(null, null)));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["StopRecord"], () =>
            {
                if (_isRecording) Invoke(new Action(() => btnStopRecord_Click(null, null)));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["Play"], () =>
            {
                if (!_isPlaying) Invoke(new Action(() => btnPlay_Click(null, null)));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["StopPlay"], () =>
            {
                Invoke(new Action(() => btnStopPlay_Click(null, null)));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["Clicker"], () =>
            {
                Invoke(new Action(() => ToggleClicker()));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["AutoKey"], () =>
            {
                Invoke(new Action(() => ToggleAutoKey()));
            });
            _hotkeyManager.RegisterHotkey(0, _hotkeyBindings["Panic"], () =>
            {
                Invoke(new Action(() => PanicStopAll()));
            });
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if (_hotkeyManager != null)
                    _hotkeyManager.ProcessHotkey(id);
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRecordingHooks();
            StopPlayback();
            StopClicker();
            StopAutoKey();
            StopAutoScroll();

            if (_hotkeyManager != null)
                _hotkeyManager.Dispose();

            tmrMouseInfo.Stop();
            notifyIcon.Visible = false;
        }

        #endregion

        #region Status & UI Helpers

        private void UpdateStatus(string text, Color color)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => UpdateStatus(text, color)));
                return;
            }
            lblStatus.Text = "● " + text;
            lblStatus.ForeColor = color;
        }

        private void UpdateActionCount()
        {
            if (lblActionCount.InvokeRequired)
            {
                lblActionCount.Invoke(new Action(UpdateActionCount));
                return;
            }

            int totalMs = 0;
            foreach (var a in _actions)
                totalMs += a.DelayMs;

            lblActionCount.Text = string.Format("Total: {0} actions | Duration: {1:0.0}s",
                _actions.Count, totalMs / 1000.0);
        }

        private void AddLogMessage(string message)
        {
            if (lstActions.InvokeRequired)
            {
                lstActions.Invoke(new Action(() => AddLogMessage(message)));
                return;
            }
            lstActions.Items.Add(message);
            lstActions.TopIndex = lstActions.Items.Count - 1;
        }

        private void ShowNotification(string title, string message)
        {
            if (chkShowNotifications.Checked && notifyIcon.Visible)
            {
                notifyIcon.ShowBalloonTip(2000, title, message, ToolTipIcon.Info);
            }
        }

        private string ShowInputBox(string prompt, string title, string defaultValue)
        {
            Form inputForm = new Form();
            inputForm.Text = title;
            inputForm.Size = new Size(350, 150);
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;
            inputForm.BackColor = Color.FromArgb(45, 45, 60);

            Label lblPrompt = new Label();
            lblPrompt.Text = prompt;
            lblPrompt.ForeColor = Color.White;
            lblPrompt.Location = new Point(15, 15);
            lblPrompt.AutoSize = true;

            TextBox txtInput = new TextBox();
            txtInput.Text = defaultValue;
            txtInput.Location = new Point(15, 45);
            txtInput.Size = new Size(300, 25);
            txtInput.BackColor = Color.FromArgb(60, 60, 80);
            txtInput.ForeColor = Color.White;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(155, 80);
            btnOK.Size = new Size(75, 28);
            btnOK.BackColor = Color.FromArgb(70, 130, 70);
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(240, 80);
            btnCancel.Size = new Size(75, 28);
            btnCancel.BackColor = Color.FromArgb(130, 70, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;

            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOK);
            inputForm.Controls.Add(btnCancel);
            inputForm.AcceptButton = btnOK;
            inputForm.CancelButton = btnCancel;

            if (inputForm.ShowDialog() == DialogResult.OK)
                return txtInput.Text;
            return "";
        }

        #endregion

        #region Recording

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (_isRecording) return;
            if (_isPlaying) StopPlayback();

            _actions.Clear();
            lstActions.Items.Clear();

            _sw.Reset();
            _sw.Start();
            _lastTick = 0;

            Point p = Cursor.Position;
            _lastMoveX = p.X;
            _lastMoveY = p.Y;
            _lastMoveTick = 0;

            _isRecording = true;
            StartRecordingHooks();

            AddLogMessage("======= RECORDING STARTED =======");
            UpdateStatus("Recording...", Color.FromArgb(255, 100, 100));
            ShowNotification("Recording", "Macro recording started");

            btnRecord.BackColor = Color.FromArgb(255, 60, 60);
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            if (!_isRecording) return;

            _isRecording = false;
            StopRecordingHooks();

            AddLogMessage("======= RECORDING STOPPED =======");
            UpdateStatus("Ready", Color.FromArgb(100, 255, 150));
            UpdateActionCount();
            ShowNotification("Recording", "Macro recording stopped");

            btnRecord.BackColor = Color.FromArgb(220, 70, 70);
        }

        private void AddAction(MacroAction a)
        {
            long now = _sw.ElapsedMilliseconds;
            a.DelayMs = (int)Math.Max(0, now - _lastTick);
            _lastTick = now;

            _actions.Add(a);

            if (lstActions.IsHandleCreated)
            {
                lstActions.BeginInvoke(new Action(() =>
                {
                    lstActions.Items.Add(a.ToString());
                    lstActions.TopIndex = lstActions.Items.Count - 1;
                    UpdateActionCount();
                }));
            }
        }

        #endregion

        #region Playback

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            if (_actions.Count == 0)
            {
                MessageBox.Show("No actions recorded!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_playCts != null) return;
            if (_isRecording) btnStopRecord_Click(sender, e);

            double speed = (double)nudSpeed.Value / 100.0;
            if (speed <= 0.01) speed = 1.0;

            int loopCount = chkInfiniteLoop.Checked ? int.MaxValue :
                           (chkLoop.Checked ? (int)nudLoopCount.Value : 1);

            _playCts = new CancellationTokenSource();
            CancellationToken token = _playCts.Token;
            _isPlaying = true;
            _isPaused = false;

            AddLogMessage(string.Format("======= PLAYING (Speed: {0:0.0}x) =======", speed));
            UpdateStatus("Playing...", Color.FromArgb(100, 200, 255));
            ShowNotification("Playback", "Macro playback started");
            btnPlay.BackColor = Color.FromArgb(60, 200, 60);

            try
            {
                for (int loop = 0; loop < loopCount && !token.IsCancellationRequested; loop++)
                {
                    if (loopCount > 1 && loopCount < int.MaxValue)
                        AddLogMessage(string.Format("---- Loop {0}/{1} ----", loop + 1, loopCount));

                    prgPlayback.Maximum = _actions.Count;
                    prgPlayback.Value = 0;

                    for (int i = 0; i < _actions.Count; i++)
                    {
                        while (_isPaused && !token.IsCancellationRequested)
                            await Task.Delay(50);

                        token.ThrowIfCancellationRequested();

                        MacroAction a = _actions[i];
                        int wait = (int)Math.Max(0, a.DelayMs / speed);

                        if (chkRandomDelay.Checked)
                        {
                            int minDelay = (int)nudRandomMin.Value;
                            int maxDelay = (int)nudRandomMax.Value;
                            wait += _random.Next(minDelay, maxDelay + 1);
                        }

                        if (wait > 0)
                            await Task.Delay(wait, token);

                        PerformAction(a);

                        if (prgPlayback.InvokeRequired)
                            prgPlayback.Invoke(new Action(() => prgPlayback.Value = i + 1));
                        else
                            prgPlayback.Value = i + 1;
                    }
                }

                AddLogMessage("======= PLAYBACK FINISHED =======");
            }
            catch (OperationCanceledException)
            {
                AddLogMessage("======= PLAYBACK STOPPED =======");
            }
            finally
            {
                _isPlaying = false;
                _playCts.Dispose();
                _playCts = null;
                UpdateStatus("Ready", Color.FromArgb(100, 255, 150));
                prgPlayback.Value = 0;
                btnPlay.BackColor = Color.FromArgb(70, 180, 70);
            }
        }

        private void btnStopPlay_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_isPlaying)
            {
                _isPaused = !_isPaused;
                btnPause.Text = _isPaused ? "▶ Resume" : "⏸ Pause";
                UpdateStatus(_isPaused ? "Paused" : "Playing...",
                    _isPaused ? Color.FromArgb(255, 200, 100) : Color.FromArgb(100, 200, 255));
            }
        }

        private void StopPlayback()
        {
            if (_playCts != null)
                _playCts.Cancel();
        }

        private void trkSpeed_Scroll(object sender, EventArgs e)
        {
            nudSpeed.Value = trkSpeed.Value;
        }

        #endregion

        #region Action Management

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            if (lstActions.SelectedIndex >= 0 && lstActions.SelectedIndex < _actions.Count)
            {
                _actions.RemoveAt(lstActions.SelectedIndex);
                lstActions.Items.RemoveAt(lstActions.SelectedIndex);
                UpdateActionCount();
            }
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            if (lstActions.SelectedIndex >= 0 && lstActions.SelectedIndex < _actions.Count)
            {
                MacroAction a = _actions[lstActions.SelectedIndex];
                string input = ShowInputBox("Edit delay (ms):", "Edit Action", a.DelayMs.ToString());

                int newDelay;
                if (int.TryParse(input, out newDelay) && newDelay >= 0)
                {
                    a.DelayMs = newDelay;
                    lstActions.Items[lstActions.SelectedIndex] = a.ToString();
                }
            }
        }

        private void btnAddDelay_Click(object sender, EventArgs e)
        {
            string input = ShowInputBox("Enter delay in milliseconds:", "Add Delay", "1000");

            int delay;
            if (int.TryParse(input, out delay) && delay > 0)
            {
                MacroAction a = new MacroAction { Type = ActionType.Delay, DelayMs = delay };

                int insertIndex = lstActions.SelectedIndex >= 0 ?
                    lstActions.SelectedIndex + 1 : _actions.Count;

                _actions.Insert(insertIndex, a);
                lstActions.Items.Insert(insertIndex, a.ToString());
                UpdateActionCount();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_actions.Count > 0)
            {
                DialogResult result = MessageBox.Show("Clear all recorded actions?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            _actions.Clear();
            lstActions.Items.Clear();
            UpdateActionCount();
            AddLogMessage("======= CLEARED =======");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_actions.Count == 0)
            {
                MessageBox.Show("No actions to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Macro Files|*.macro|Text Files|*.txt";
                sfd.Title = "Export Macro";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<string> lines = new List<string>();
                        foreach (var action in _actions)
                            lines.Add(action.Serialize());

                        File.WriteAllLines(sfd.FileName, lines.ToArray());
                        AddLogMessage("Exported: " + Path.GetFileName(sfd.FileName));
                        ShowNotification("Export", "Macro exported successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export failed: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Macro Files|*.macro|Text Files|*.txt|All Files|*.*";
                ofd.Title = "Import Macro";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        List<MacroAction> imported = new List<MacroAction>();

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrEmpty(line)) continue;
                            MacroAction action = MacroAction.Deserialize(line);
                            if (action != null)
                                imported.Add(action);
                        }

                        if (imported.Count > 0)
                        {
                            _actions.Clear();
                            _actions.AddRange(imported);

                            lstActions.Items.Clear();
                            foreach (var a in _actions)
                                lstActions.Items.Add(a.ToString());

                            UpdateActionCount();
                            AddLogMessage(string.Format("Imported {0} actions", imported.Count));
                            ShowNotification("Import", "Macro imported successfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Import failed: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Auto Clicker

        private void btnStartClicker_Click(object sender, EventArgs e)
        {
            StartClicker();
        }

        private void btnStopClicker_Click(object sender, EventArgs e)
        {
            StopClicker();
        }

        private void ToggleClicker()
        {
            if (_clickerRunning)
                StopClicker();
            else
                StartClicker();
        }

        private void StartClicker()
        {
            if (_clickerRunning) return;

            int interval = (int)nudClickInterval.Value;

            if (cmbClickIntervalUnit.SelectedIndex == 1)
                interval *= 1000;
            else if (cmbClickIntervalUnit.SelectedIndex == 2)
                interval *= 60000;

            if (interval < 1) interval = 1;

            _clickerTimer.Interval = interval;
            _clickCount = 0;
            _clickerRunning = true;
            _clickerTimer.Start();

            UpdateStatus("Auto Clicker Running", Color.FromArgb(255, 180, 100));
            lblClickerStatus.Text = "Status: Running";
            lblClickerStatus.ForeColor = Color.FromArgb(100, 255, 150);
            btnStartClicker.BackColor = Color.FromArgb(255, 140, 60);
            AddLogMessage(string.Format("======= CLICKER START ({0}ms) =======", interval));
            ShowNotification("Auto Clicker", "Started");
        }

        private void StopClicker()
        {
            if (!_clickerRunning) return;

            _clickerTimer.Stop();
            _clickerRunning = false;

            UpdateStatus("Ready", Color.FromArgb(100, 255, 150));
            lblClickerStatus.Text = "Status: Stopped";
            lblClickerStatus.ForeColor = Color.FromArgb(255, 150, 150);
            btnStartClicker.BackColor = Color.FromArgb(70, 180, 70);
            AddLogMessage(string.Format("======= CLICKER STOP (Clicks: {0}) =======", _clickCount));
            ShowNotification("Auto Clicker", "Stopped - " + _clickCount + " clicks");
        }

        private void ClickerTimer_Tick(object sender, EventArgs e)
        {
            if (radClickCount.Checked && _clickCount >= (int)nudClickCount.Value)
            {
                StopClicker();
                return;
            }

            if (radFixedPos.Checked)
            {
                int x = (int)nudClickX.Value;
                int y = (int)nudClickY.Value;
                SetCursorPos(x, y);
            }

            string clickButton = cmbMouseButton.Text;
            string clickType = cmbClickType.Text;

            int clickTimes = 1;
            if (clickType == "Double") clickTimes = 2;
            else if (clickType == "Triple") clickTimes = 3;

            for (int i = 0; i < clickTimes; i++)
            {
                if (clickButton == "Left")
                {
                    SendMouseClick(MOUSEEVENTF_LEFTDOWN);
                    SendMouseClick(MOUSEEVENTF_LEFTUP);
                }
                else if (clickButton == "Right")
                {
                    SendMouseClick(MOUSEEVENTF_RIGHTDOWN);
                    SendMouseClick(MOUSEEVENTF_RIGHTUP);
                }
                else if (clickButton == "Middle")
                {
                    SendMouseClick(MOUSEEVENTF_MIDDLEDOWN);
                    SendMouseClick(MOUSEEVENTF_MIDDLEUP);
                }

                if (i < clickTimes - 1)
                    Thread.Sleep(50);
            }

            _clickCount++;
            lblClickCounter.Text = "Clicks: " + _clickCount;
        }

        private void btnPickPosition_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Move mouse to desired position and press OK", "Pick Position",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Point p = Cursor.Position;
            nudClickX.Value = p.X;
            nudClickY.Value = p.Y;
            radFixedPos.Checked = true;
        }

        #endregion

        #region Auto Key Presser

        private void btnStartAutoKey_Click(object sender, EventArgs e)
        {
            StartAutoKey();
        }

        private void btnStopAutoKey_Click(object sender, EventArgs e)
        {
            StopAutoKey();
        }

        private void ToggleAutoKey()
        {
            if (_autoKeyRunning)
                StopAutoKey();
            else
                StartAutoKey();
        }

        private void StartAutoKey()
        {
            if (_autoKeyRunning) return;

            int interval = (int)nudKeyInterval.Value;

            if (cmbKeyIntervalUnit.SelectedIndex == 1)
                interval *= 1000;

            if (interval < 1) interval = 1;

            _autoKeyTimer.Interval = interval;
            _keyPressCount = 0;
            _sequenceIndex = 0;
            _autoKeyRunning = true;
            _autoKeyTimer.Start();

            UpdateStatus("Auto Key Running", Color.FromArgb(200, 150, 255));
            lblAutoKeyStatus.Text = "Status: Running";
            lblAutoKeyStatus.ForeColor = Color.FromArgb(100, 255, 150);
            btnStartAutoKey.BackColor = Color.FromArgb(180, 120, 230);
            AddLogMessage(string.Format("======= AUTO KEY START ({0}ms) =======", interval));
            ShowNotification("Auto Key", "Started");
        }

        private void StopAutoKey()
        {
            if (!_autoKeyRunning) return;

            _autoKeyTimer.Stop();
            _autoKeyRunning = false;

            UpdateStatus("Ready", Color.FromArgb(100, 255, 150));
            lblAutoKeyStatus.Text = "Status: Stopped";
            lblAutoKeyStatus.ForeColor = Color.FromArgb(255, 150, 150);
            btnStartAutoKey.BackColor = Color.FromArgb(70, 180, 70);
            AddLogMessage(string.Format("======= AUTO KEY STOP (Presses: {0}) =======", _keyPressCount));
            ShowNotification("Auto Key", "Stopped - " + _keyPressCount + " presses");
        }

        private void AutoKeyTimer_Tick(object sender, EventArgs e)
        {
            if (radKeyCount.Checked && _keyPressCount >= (int)nudKeyCount.Value)
            {
                StopAutoKey();
                return;
            }

            if (chkSequenceMode.Checked && lstKeySequence.Items.Count > 0)
            {
                string keyStr = lstKeySequence.Items[_sequenceIndex % lstKeySequence.Items.Count].ToString();
                try
                {
                    Keys key = (Keys)Enum.Parse(typeof(Keys), keyStr, true);
                    SendKeyPress((int)key);
                    _keyPressCount++;
                    _sequenceIndex++;
                }
                catch { }
            }
            else
            {
                string keyStr = cmbKeyToPress.Text.Trim();
                if (!string.IsNullOrEmpty(keyStr))
                {
                    try
                    {
                        Keys key = (Keys)Enum.Parse(typeof(Keys), keyStr, true);

                        if (chkHoldKey.Checked)
                        {
                            SendKeyDown((int)key);
                            Thread.Sleep((int)nudHoldDuration.Value);
                            SendKeyUp((int)key);
                        }
                        else
                        {
                            SendKeyPress((int)key);
                        }
                        _keyPressCount++;
                    }
                    catch { }
                }
            }

            lblKeyCounter.Text = "Key Presses: " + _keyPressCount;
        }

        private void btnCaptureKey_Click(object sender, EventArgs e)
        {
            _capturingKey = true;
            MessageBox.Show("Press any key after closing this dialog", "Capture Key",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            if (cmbKeyToPress.SelectedItem != null)
            {
                lstKeySequence.Items.Add(cmbKeyToPress.SelectedItem.ToString());
            }
        }

        private void btnRemoveKey_Click(object sender, EventArgs e)
        {
            if (lstKeySequence.SelectedIndex >= 0)
            {
                lstKeySequence.Items.RemoveAt(lstKeySequence.SelectedIndex);
            }
        }

        private void btnClearKeys_Click(object sender, EventArgs e)
        {
            lstKeySequence.Items.Clear();
        }

        #endregion

        #region Auto Scroll

        private void StartAutoScroll()
        {
            int interval = (int)nudAutoScrollInterval.Value;
            if (interval < 10) interval = 100;

            _autoScrollTimer.Interval = interval;
            _autoScrollRunning = true;
            _autoScrollTimer.Start();

            AddLogMessage("======= AUTO SCROLL START =======");
            UpdateStatus("Auto Scroll Running", Color.FromArgb(150, 200, 255));
        }

        private void StopAutoScroll()
        {
            _autoScrollTimer.Stop();
            _autoScrollRunning = false;
            AddLogMessage("======= AUTO SCROLL STOP =======");
            UpdateStatus("Ready", Color.FromArgb(100, 255, 150));
        }

        private void AutoScrollTimer_Tick(object sender, EventArgs e)
        {
            int amount = (int)nudScrollAmount.Value;
            SendMouseScroll(-amount * 120);
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            int amount = (int)nudScrollAmount.Value;
            SendMouseScroll(amount * 120);
            AddLogMessage("Scrolled up");
        }

        private void btnScrollDown_Click(object sender, EventArgs e)
        {
            int amount = (int)nudScrollAmount.Value;
            SendMouseScroll(-amount * 120);
            AddLogMessage("Scrolled down");
        }

        #endregion

        #region Quick Mouse Actions

        private void btnLeftClick_Click(object sender, EventArgs e)
        {
            SendMouseClick(MOUSEEVENTF_LEFTDOWN);
            SendMouseClick(MOUSEEVENTF_LEFTUP);
            AddLogMessage("Sent left click");
        }

        private void btnRightClick_Click(object sender, EventArgs e)
        {
            SendMouseClick(MOUSEEVENTF_RIGHTDOWN);
            SendMouseClick(MOUSEEVENTF_RIGHTUP);
            AddLogMessage("Sent right click");
        }

        private void btnMiddleClick_Click(object sender, EventArgs e)
        {
            SendMouseClick(MOUSEEVENTF_MIDDLEDOWN);
            SendMouseClick(MOUSEEVENTF_MIDDLEUP);
            AddLogMessage("Sent middle click");
        }

        private void btnDoubleClick_Click(object sender, EventArgs e)
        {
            SendMouseClick(MOUSEEVENTF_LEFTDOWN);
            SendMouseClick(MOUSEEVENTF_LEFTUP);
            Thread.Sleep(50);
            SendMouseClick(MOUSEEVENTF_LEFTDOWN);
            SendMouseClick(MOUSEEVENTF_LEFTUP);
            AddLogMessage("Sent double click");
        }

        #endregion

        #region Settings & Hotkeys

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var kvp in _hotkeyBindings)
                    lines.Add(kvp.Key + "=" + (int)kvp.Value);

                lines.Add("MinimizeToTray=" + chkMinimizeToTray.Checked);
                lines.Add("ShowNotifications=" + chkShowNotifications.Checked);
                lines.Add("StartMinimized=" + chkStartMinimized.Checked);

                File.WriteAllLines("settings.ini", lines.ToArray());
                MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save: " + ex.Message);
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (!File.Exists("settings.ini")) return;

                string[] lines = File.ReadAllLines("settings.ini");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string val = parts[1].Trim();

                        if (_hotkeyBindings.ContainsKey(key))
                        {
                            _hotkeyBindings[key] = (Keys)int.Parse(val);
                        }
                        else if (key == "MinimizeToTray")
                        {
                            chkMinimizeToTray.Checked = bool.Parse(val);
                        }
                        else if (key == "ShowNotifications")
                        {
                            chkShowNotifications.Checked = bool.Parse(val);
                        }
                        else if (key == "StartMinimized")
                        {
                            chkStartMinimized.Checked = bool.Parse(val);
                        }
                    }
                }

                RegisterAllHotkeys();
                UpdateHotkeyLabels();
            }
            catch { }
        }

        private void UpdateHotkeyLabels()
        {
            btnHkRecord.Text = _hotkeyBindings["Record"].ToString();
            btnHkStopRecord.Text = _hotkeyBindings["StopRecord"].ToString();
            btnHkPlay.Text = _hotkeyBindings["Play"].ToString();
            btnHkStopPlay.Text = _hotkeyBindings["StopPlay"].ToString();
            btnHkClicker.Text = _hotkeyBindings["Clicker"].ToString();
            btnHkAutoKey.Text = _hotkeyBindings["AutoKey"].ToString();
            btnHkPanic.Text = _hotkeyBindings["Panic"].ToString();
        }

        private void HotkeyButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string hotkeyName = GetHotkeyNameFromButton(btn);
            if (string.IsNullOrEmpty(hotkeyName)) return;

            using (HotkeyInputForm form = new HotkeyInputForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _hotkeyBindings[hotkeyName] = form.SelectedKey;
                    UpdateHotkeyLabels();
                    RegisterAllHotkeys();
                }
            }
        }

        private string GetHotkeyNameFromButton(Button btn)
        {
            if (btn == btnHkRecord) return "Record";
            if (btn == btnHkStopRecord) return "StopRecord";
            if (btn == btnHkPlay) return "Play";
            if (btn == btnHkStopPlay) return "StopPlay";
            if (btn == btnHkClicker) return "Clicker";
            if (btn == btnHkAutoKey) return "AutoKey";
            if (btn == btnHkPanic) return "Panic";
            return null;
        }

        private void btnResetHotkeys_Click(object sender, EventArgs e)
        {
            InitializeHotkeys();
            MessageBox.Show("Hotkeys reset to defaults!", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            chkMinimizeToTray.Checked = true;
            chkShowNotifications.Checked = true;
            chkStartMinimized.Checked = false;
            InitializeHotkeys();
            MessageBox.Show("Settings reset to defaults!", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanicStopAll()
        {
            StopPlayback();
            StopClicker();
            StopAutoKey();
            StopAutoScroll();

            if (_isRecording)
                btnStopRecord_Click(null, null);

            AddLogMessage("!!! PANIC STOP - ALL STOPPED !!!");
            UpdateStatus("STOPPED", Color.FromArgb(255, 100, 100));
            ShowNotification("Panic Stop", "All operations stopped!");
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkAlwaysOnTop.Checked;
        }

        #endregion

        #region Tray & Misc

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (chkMinimizeToTray.Checked)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void trayMenuShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void trayMenuRecord_Click(object sender, EventArgs e)
        {
            if (!_isRecording)
                btnRecord_Click(null, null);
            else
                btnStopRecord_Click(null, null);
        }

        private void trayMenuPlay_Click(object sender, EventArgs e)
        {
            if (!_isPlaying)
                btnPlay_Click(null, null);
            else
                btnStopPlay_Click(null, null);
        }

        private void trayMenuClicker_Click(object sender, EventArgs e)
        {
            ToggleClicker();
        }

        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmrMouseInfo_Tick(object sender, EventArgs e)
        {
            Point p = Cursor.Position;

            lblCurrentPosValue.Text = string.Format("X: {0}  Y: {1}", p.X, p.Y);

            try
            {
                Color pixelColor = GetPixelColor(p.X, p.Y);
                pnlColorPreview.BackColor = pixelColor;
                lblColorHex.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                    pixelColor.R, pixelColor.G, pixelColor.B);
            }
            catch { }

            if (_capturingKey)
            {
                foreach (Keys key in Enum.GetValues(typeof(Keys)))
                {
                    if (GetAsyncKeyState((int)key) < 0)
                    {
                        if (key != Keys.LButton && key != Keys.RButton && key != Keys.MButton)
                        {
                            cmbKeyToPress.Text = key.ToString();
                            _capturingKey = false;
                            break;
                        }
                    }
                }
            }

            // Auto scroll check
            if (chkAutoScroll.Checked && !_autoScrollRunning)
            {
                StartAutoScroll();
            }
            else if (!chkAutoScroll.Checked && _autoScrollRunning)
            {
                StopAutoScroll();
            }
        }

        private Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            return Color.FromArgb((int)(pixel & 0xFF), (int)((pixel >> 8) & 0xFF), (int)((pixel >> 16) & 0xFF));
        }

        #endregion

        #region Recording Hooks

        private void StartRecordingHooks()
        {
            _mouseProc = MouseHookCallback;
            _keyboardProc = KeyboardHookCallback;

            _mouseHook = SetHook(_mouseProc);
            _keyboardHook = SetKeyboardHook(_keyboardProc);
        }

        private void StopRecordingHooks()
        {
            if (_mouseHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_mouseHook);
                _mouseHook = IntPtr.Zero;
            }
            if (_keyboardHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_keyboardHook);
                _keyboardHook = IntPtr.Zero;
            }

            _mouseProc = null;
            _keyboardProc = null;
        }

        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && _isRecording)
            {
                int msg = wParam.ToInt32();
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                bool recordMoves = chkRecordMouseMove.Checked && chkRecordMouse.Checked;
                bool recordClicks = chkRecordClicks.Checked && chkRecordMouse.Checked;
                bool recordScroll = chkRecordScroll.Checked && chkRecordMouse.Checked;

                switch (msg)
                {
                    case WM_MOUSEMOVE:
                        if (recordMoves)
                        {
                            long now = _sw.ElapsedMilliseconds;
                            int x = hookStruct.pt.x;
                            int y = hookStruct.pt.y;

                            bool movedEnough = (Math.Abs(x - _lastMoveX) + Math.Abs(y - _lastMoveY)) >= 5;
                            bool timeEnough = (now - _lastMoveTick) >= 15;

                            if (movedEnough && timeEnough)
                            {
                                _lastMoveX = x;
                                _lastMoveY = y;
                                _lastMoveTick = now;

                                AddAction(new MacroAction { Type = ActionType.MouseMove, X = x, Y = y });
                            }
                        }
                        break;

                    case WM_LBUTTONDOWN:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.LeftDown, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_LBUTTONUP:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.LeftUp, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_RBUTTONDOWN:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.RightDown, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_RBUTTONUP:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.RightUp, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_MBUTTONDOWN:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.MiddleDown, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_MBUTTONUP:
                        if (recordClicks)
                            AddAction(new MacroAction { Type = ActionType.MiddleUp, X = hookStruct.pt.x, Y = hookStruct.pt.y });
                        break;

                    case WM_MOUSEWHEEL:
                        if (recordScroll)
                        {
                            int delta = (short)(hookStruct.mouseData >> 16);
                            ActionType scrollType = delta > 0 ? ActionType.ScrollUp : ActionType.ScrollDown;
                            AddAction(new MacroAction { Type = scrollType, ScrollAmount = Math.Abs(delta) });
                        }
                        break;
                }
            }

            return CallNextHookEx(_mouseHook, nCode, wParam, lParam);
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int msg = wParam.ToInt32();
                KBDLLHOOKSTRUCT kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                if (_capturingKey && (msg == WM_KEYDOWN || msg == WM_SYSKEYDOWN))
                {
                    _capturingKey = false;
                    if (cmbKeyToPress.InvokeRequired)
                        cmbKeyToPress.Invoke(new Action(() => cmbKeyToPress.Text = ((Keys)kb.vkCode).ToString()));
                    else
                        cmbKeyToPress.Text = ((Keys)kb.vkCode).ToString();
                }

                if (_isRecording && chkRecordKeyboard.Checked)
                {
                    if (msg == WM_KEYDOWN || msg == WM_SYSKEYDOWN)
                    {
                        AddAction(new MacroAction { Type = ActionType.KeyDown, Vk = (int)kb.vkCode });
                    }
                    else if (msg == WM_KEYUP || msg == WM_SYSKEYUP)
                    {
                        AddAction(new MacroAction { Type = ActionType.KeyUp, Vk = (int)kb.vkCode });
                    }
                }
            }

            return CallNextHookEx(_keyboardHook, nCode, wParam, lParam);
        }

        #endregion

        #region Perform Action

        private void PerformAction(MacroAction a)
        {
            switch (a.Type)
            {
                case ActionType.MouseMove:
                    SetCursorPos(a.X, a.Y);
                    break;

                case ActionType.LeftDown:
                    SetCursorPos(a.X, a.Y);
                    SendMouseClick(MOUSEEVENTF_LEFTDOWN);
                    break;

                case ActionType.LeftUp:
                    SendMouseClick(MOUSEEVENTF_LEFTUP);
                    break;

                case ActionType.RightDown:
                    SetCursorPos(a.X, a.Y);
                    SendMouseClick(MOUSEEVENTF_RIGHTDOWN);
                    break;

                case ActionType.RightUp:
                    SendMouseClick(MOUSEEVENTF_RIGHTUP);
                    break;

                case ActionType.MiddleDown:
                    SetCursorPos(a.X, a.Y);
                    SendMouseClick(MOUSEEVENTF_MIDDLEDOWN);
                    break;

                case ActionType.MiddleUp:
                    SendMouseClick(MOUSEEVENTF_MIDDLEUP);
                    break;

                case ActionType.ScrollUp:
                    SendMouseScroll(a.ScrollAmount > 0 ? a.ScrollAmount : 120);
                    break;

                case ActionType.ScrollDown:
                    SendMouseScroll(a.ScrollAmount > 0 ? -a.ScrollAmount : -120);
                    break;

                case ActionType.KeyDown:
                    SendKeyDown(a.Vk);
                    break;

                case ActionType.KeyUp:
                    SendKeyUp(a.Vk);
                    break;

                case ActionType.Delay:
                    Thread.Sleep(a.DelayMs);
                    break;
            }
        }

        #endregion

        #region WinAPI Helpers

        private void SendMouseClick(uint flags)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0] = new INPUT();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].U.mi.dwFlags = flags;
            inputs[0].U.mi.dwExtraInfo = IntPtr.Zero;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendMouseScroll(int amount)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0] = new INPUT();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].U.mi.dwFlags = MOUSEEVENTF_WHEEL;
            inputs[0].U.mi.mouseData = (uint)amount;
            inputs[0].U.mi.dwExtraInfo = IntPtr.Zero;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendKeyPress(int vk)
        {
            SendKeyDown(vk);
            Thread.Sleep(10);
            SendKeyUp(vk);
        }

        private void SendKeyDown(int vk)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0] = new INPUT();
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)vk;
            inputs[0].U.ki.dwFlags = 0;
            inputs[0].U.ki.dwExtraInfo = IntPtr.Zero;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendKeyUp(int vk)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0] = new INPUT();
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = (ushort)vk;
            inputs[0].U.ki.dwFlags = KEYEVENTF_KEYUP;
            inputs[0].U.ki.dwExtraInfo = IntPtr.Zero;
            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        #endregion

        #region WinAPI Declarations

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_MOUSE_LL = 14;
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MBUTTONUP = 0x0208;
        private const int WM_MOUSEWHEEL = 0x020A;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private const int INPUT_MOUSE = 0;
        private const int INPUT_KEYBOARD = 1;

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;

        private const uint KEYEVENTF_KEYUP = 0x0002;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT { public int x, y; }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData, flags, time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode, scanCode, flags, time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public int type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx, dy;
            public uint mouseData, dwFlags, time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk, wScan;
            public uint dwFlags, time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern uint GetPixel(IntPtr hdc, int x, int y);

        #endregion
    }

    #region Helper Classes

    public class HotkeyManager : IDisposable
    {
        private IntPtr _hwnd;
        private Dictionary<int, Action> _callbacks = new Dictionary<int, Action>();
        private int _nextId = 1;

        public HotkeyManager(IntPtr hwnd)
        {
            _hwnd = hwnd;
        }

        public void RegisterHotkey(uint modifiers, Keys key, Action callback)
        {
            int id = _nextId++;
            if (RegisterHotKey(_hwnd, id, modifiers, (uint)key))
            {
                _callbacks[id] = callback;
            }
        }

        public void ProcessHotkey(int id)
        {
            if (_callbacks.ContainsKey(id))
                _callbacks[id]();
        }

        public void Dispose()
        {
            foreach (int id in _callbacks.Keys)
                UnregisterHotKey(_hwnd, id);
            _callbacks.Clear();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    public class HotkeyInputForm : Form
    {
        public Keys SelectedKey { get; private set; }

        public HotkeyInputForm()
        {
            this.Text = "Press a key";
            this.Size = new Size(300, 120);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 60);

            Label lblInstruction = new Label();
            lblInstruction.Text = "Press any key for hotkey...";
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Font = new Font("Segoe UI", 12);
            lblInstruction.AutoSize = true;
            lblInstruction.Location = new Point(50, 35);
            this.Controls.Add(lblInstruction);

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                SelectedKey = e.KeyCode;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }
    }

    #endregion
}