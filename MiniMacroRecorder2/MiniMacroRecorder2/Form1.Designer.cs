namespace MiniMacroRecorder2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Main Controls
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabRecorder;
        private System.Windows.Forms.TabPage tabAutoClicker;
        private System.Windows.Forms.TabPage tabAutoKey;
        private System.Windows.Forms.TabPage tabMouseTools;
        private System.Windows.Forms.TabPage tabSettings;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnMinimize;

        // === RECORDER TAB ===
        private System.Windows.Forms.GroupBox grpRecControls;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStopPlay;
        private System.Windows.Forms.Button btnPause;

        private System.Windows.Forms.GroupBox grpPlaySettings;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.NumericUpDown nudLoopCount;
        private System.Windows.Forms.CheckBox chkInfiniteLoop;
        private System.Windows.Forms.CheckBox chkRandomDelay;
        private System.Windows.Forms.NumericUpDown nudRandomMin;
        private System.Windows.Forms.NumericUpDown nudRandomMax;
        private System.Windows.Forms.Label lblRandomMs;

        private System.Windows.Forms.GroupBox grpRecordOptions;
        private System.Windows.Forms.CheckBox chkRecordMouse;
        private System.Windows.Forms.CheckBox chkRecordKeyboard;
        private System.Windows.Forms.CheckBox chkRecordMouseMove;
        private System.Windows.Forms.CheckBox chkRecordClicks;
        private System.Windows.Forms.CheckBox chkRecordScroll;

        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnEditAction;
        private System.Windows.Forms.Button btnAddDelay;
        private System.Windows.Forms.Label lblActionCount;
        private System.Windows.Forms.ProgressBar prgPlayback;

        // === AUTO CLICKER TAB ===
        private System.Windows.Forms.GroupBox grpClickerSettings;
        private System.Windows.Forms.Label lblClickInterval;
        private System.Windows.Forms.NumericUpDown nudClickInterval;
        private System.Windows.Forms.ComboBox cmbClickIntervalUnit;
        private System.Windows.Forms.Label lblClickButton;
        private System.Windows.Forms.ComboBox cmbMouseButton;
        private System.Windows.Forms.Label lblClickType;
        private System.Windows.Forms.ComboBox cmbClickType;

        private System.Windows.Forms.GroupBox grpClickerPosition;
        private System.Windows.Forms.RadioButton radCurrentPos;
        private System.Windows.Forms.RadioButton radFixedPos;
        private System.Windows.Forms.NumericUpDown nudClickX;
        private System.Windows.Forms.NumericUpDown nudClickY;
        private System.Windows.Forms.Button btnPickPosition;
        private System.Windows.Forms.Label lblClickPos;

        private System.Windows.Forms.GroupBox grpClickerRepeat;
        private System.Windows.Forms.RadioButton radClickInfinite;
        private System.Windows.Forms.RadioButton radClickCount;
        private System.Windows.Forms.NumericUpDown nudClickCount;

        private System.Windows.Forms.Button btnStartClicker;
        private System.Windows.Forms.Button btnStopClicker;
        private System.Windows.Forms.Label lblClickerStatus;
        private System.Windows.Forms.Label lblClickCounter;

        // === AUTO KEY TAB ===
        private System.Windows.Forms.GroupBox grpKeySettings;
        private System.Windows.Forms.Label lblKeyToPress;
        private System.Windows.Forms.ComboBox cmbKeyToPress;
        private System.Windows.Forms.Button btnCaptureKey;
        private System.Windows.Forms.Label lblKeyInterval;
        private System.Windows.Forms.NumericUpDown nudKeyInterval;
        private System.Windows.Forms.ComboBox cmbKeyIntervalUnit;
        private System.Windows.Forms.CheckBox chkHoldKey;
        private System.Windows.Forms.NumericUpDown nudHoldDuration;

        private System.Windows.Forms.GroupBox grpKeyRepeat;
        private System.Windows.Forms.RadioButton radKeyInfinite;
        private System.Windows.Forms.RadioButton radKeyCount;
        private System.Windows.Forms.NumericUpDown nudKeyCount;

        private System.Windows.Forms.GroupBox grpKeySequence;
        private System.Windows.Forms.ListBox lstKeySequence;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.Button btnRemoveKey;
        private System.Windows.Forms.Button btnClearKeys;
        private System.Windows.Forms.CheckBox chkSequenceMode;

        private System.Windows.Forms.Button btnStartAutoKey;
        private System.Windows.Forms.Button btnStopAutoKey;
        private System.Windows.Forms.Label lblAutoKeyStatus;
        private System.Windows.Forms.Label lblKeyCounter;

        // === MOUSE TOOLS TAB ===
        private System.Windows.Forms.GroupBox grpMouseInfo;
        private System.Windows.Forms.Label lblCurrentPos;
        private System.Windows.Forms.Label lblCurrentPosValue;
        private System.Windows.Forms.Label lblPixelColor;
        private System.Windows.Forms.Panel pnlColorPreview;
        private System.Windows.Forms.Label lblColorHex;
        private System.Windows.Forms.Timer tmrMouseInfo;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;

        private System.Windows.Forms.GroupBox grpQuickClick;
        private System.Windows.Forms.Button btnLeftClick;
        private System.Windows.Forms.Button btnRightClick;
        private System.Windows.Forms.Button btnMiddleClick;
        private System.Windows.Forms.Button btnDoubleClick;

        private System.Windows.Forms.GroupBox grpScrollTool;
        private System.Windows.Forms.Label lblScrollAmount;
        private System.Windows.Forms.NumericUpDown nudScrollAmount;
        private System.Windows.Forms.Button btnScrollUp;
        private System.Windows.Forms.Button btnScrollDown;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.NumericUpDown nudAutoScrollInterval;

        // === SETTINGS TAB ===
        private System.Windows.Forms.GroupBox grpHotkeys;
        private System.Windows.Forms.Label lblHkRecord;
        private System.Windows.Forms.Button btnHkRecord;
        private System.Windows.Forms.Label lblHkStopRecord;
        private System.Windows.Forms.Button btnHkStopRecord;
        private System.Windows.Forms.Label lblHkPlay;
        private System.Windows.Forms.Button btnHkPlay;
        private System.Windows.Forms.Label lblHkStopPlay;
        private System.Windows.Forms.Button btnHkStopPlay;
        private System.Windows.Forms.Label lblHkClicker;
        private System.Windows.Forms.Button btnHkClicker;
        private System.Windows.Forms.Label lblHkAutoKey;
        private System.Windows.Forms.Button btnHkAutoKey;
        private System.Windows.Forms.Label lblHkPanic;
        private System.Windows.Forms.Button btnHkPanic;
        private System.Windows.Forms.Button btnResetHotkeys;

        private System.Windows.Forms.GroupBox grpTheme;
        private System.Windows.Forms.RadioButton radDarkTheme;
        private System.Windows.Forms.RadioButton radLightTheme;
        private System.Windows.Forms.RadioButton radBlueTheme;

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.CheckBox chkPlaySound;
        private System.Windows.Forms.CheckBox chkShowNotifications;
        private System.Windows.Forms.CheckBox chkAutoSave;

        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Label lblVersion;

        // System Tray
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuShow;
        private System.Windows.Forms.ToolStripMenuItem trayMenuRecord;
        private System.Windows.Forms.ToolStripMenuItem trayMenuPlay;
        private System.Windows.Forms.ToolStripMenuItem trayMenuClicker;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialize ALL controls
            InitializeMainControls();
            InitializeRecorderTab();
            InitializeAutoClickerTab();
            InitializeAutoKeyTab();
            InitializeMouseToolsTab();
            InitializeSettingsTab();
            InitializeSystemTray();

            this.SuspendLayout();

            // =====================
            // FORM SETTINGS
            // =====================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Text = "Ultimate Macro Suite Pro";
            this.BackColor = System.Drawing.Color.FromArgb(25, 25, 35);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            SetupLayout();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeMainControls()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabRecorder = new System.Windows.Forms.TabPage();
            this.tabAutoClicker = new System.Windows.Forms.TabPage();
            this.tabAutoKey = new System.Windows.Forms.TabPage();
            this.tabMouseTools = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
        }

        private void InitializeRecorderTab()
        {
            this.grpRecControls = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStopPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();

            this.grpPlaySettings = new System.Windows.Forms.GroupBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.nudLoopCount = new System.Windows.Forms.NumericUpDown();
            this.chkInfiniteLoop = new System.Windows.Forms.CheckBox();
            this.chkRandomDelay = new System.Windows.Forms.CheckBox();
            this.nudRandomMin = new System.Windows.Forms.NumericUpDown();
            this.nudRandomMax = new System.Windows.Forms.NumericUpDown();
            this.lblRandomMs = new System.Windows.Forms.Label();

            this.grpRecordOptions = new System.Windows.Forms.GroupBox();
            this.chkRecordMouse = new System.Windows.Forms.CheckBox();
            this.chkRecordKeyboard = new System.Windows.Forms.CheckBox();
            this.chkRecordMouseMove = new System.Windows.Forms.CheckBox();
            this.chkRecordClicks = new System.Windows.Forms.CheckBox();
            this.chkRecordScroll = new System.Windows.Forms.CheckBox();

            this.grpActions = new System.Windows.Forms.GroupBox();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnEditAction = new System.Windows.Forms.Button();
            this.btnAddDelay = new System.Windows.Forms.Button();
            this.lblActionCount = new System.Windows.Forms.Label();
            this.prgPlayback = new System.Windows.Forms.ProgressBar();

            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoopCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomMax)).BeginInit();
        }

        private void InitializeAutoClickerTab()
        {
            this.grpClickerSettings = new System.Windows.Forms.GroupBox();
            this.lblClickInterval = new System.Windows.Forms.Label();
            this.nudClickInterval = new System.Windows.Forms.NumericUpDown();
            this.cmbClickIntervalUnit = new System.Windows.Forms.ComboBox();
            this.lblClickButton = new System.Windows.Forms.Label();
            this.cmbMouseButton = new System.Windows.Forms.ComboBox();
            this.lblClickType = new System.Windows.Forms.Label();
            this.cmbClickType = new System.Windows.Forms.ComboBox();

            this.grpClickerPosition = new System.Windows.Forms.GroupBox();
            this.radCurrentPos = new System.Windows.Forms.RadioButton();
            this.radFixedPos = new System.Windows.Forms.RadioButton();
            this.nudClickX = new System.Windows.Forms.NumericUpDown();
            this.nudClickY = new System.Windows.Forms.NumericUpDown();
            this.btnPickPosition = new System.Windows.Forms.Button();
            this.lblClickPos = new System.Windows.Forms.Label();

            this.grpClickerRepeat = new System.Windows.Forms.GroupBox();
            this.radClickInfinite = new System.Windows.Forms.RadioButton();
            this.radClickCount = new System.Windows.Forms.RadioButton();
            this.nudClickCount = new System.Windows.Forms.NumericUpDown();

            this.btnStartClicker = new System.Windows.Forms.Button();
            this.btnStopClicker = new System.Windows.Forms.Button();
            this.lblClickerStatus = new System.Windows.Forms.Label();
            this.lblClickCounter = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudClickInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClickX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClickY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClickCount)).BeginInit();
        }

        private void InitializeAutoKeyTab()
        {
            this.grpKeySettings = new System.Windows.Forms.GroupBox();
            this.lblKeyToPress = new System.Windows.Forms.Label();
            this.cmbKeyToPress = new System.Windows.Forms.ComboBox();
            this.btnCaptureKey = new System.Windows.Forms.Button();
            this.lblKeyInterval = new System.Windows.Forms.Label();
            this.nudKeyInterval = new System.Windows.Forms.NumericUpDown();
            this.cmbKeyIntervalUnit = new System.Windows.Forms.ComboBox();
            this.chkHoldKey = new System.Windows.Forms.CheckBox();
            this.nudHoldDuration = new System.Windows.Forms.NumericUpDown();

            this.grpKeyRepeat = new System.Windows.Forms.GroupBox();
            this.radKeyInfinite = new System.Windows.Forms.RadioButton();
            this.radKeyCount = new System.Windows.Forms.RadioButton();
            this.nudKeyCount = new System.Windows.Forms.NumericUpDown();

            this.grpKeySequence = new System.Windows.Forms.GroupBox();
            this.lstKeySequence = new System.Windows.Forms.ListBox();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.btnRemoveKey = new System.Windows.Forms.Button();
            this.btnClearKeys = new System.Windows.Forms.Button();
            this.chkSequenceMode = new System.Windows.Forms.CheckBox();

            this.btnStartAutoKey = new System.Windows.Forms.Button();
            this.btnStopAutoKey = new System.Windows.Forms.Button();
            this.lblAutoKeyStatus = new System.Windows.Forms.Label();
            this.lblKeyCounter = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudKeyInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoldDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeyCount)).BeginInit();
        }

        private void InitializeMouseToolsTab()
        {
            this.grpMouseInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentPos = new System.Windows.Forms.Label();
            this.lblCurrentPosValue = new System.Windows.Forms.Label();
            this.lblPixelColor = new System.Windows.Forms.Label();
            this.pnlColorPreview = new System.Windows.Forms.Panel();
            this.lblColorHex = new System.Windows.Forms.Label();
            this.tmrMouseInfo = new System.Windows.Forms.Timer(this.components);
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();

            this.grpQuickClick = new System.Windows.Forms.GroupBox();
            this.btnLeftClick = new System.Windows.Forms.Button();
            this.btnRightClick = new System.Windows.Forms.Button();
            this.btnMiddleClick = new System.Windows.Forms.Button();
            this.btnDoubleClick = new System.Windows.Forms.Button();

            this.grpScrollTool = new System.Windows.Forms.GroupBox();
            this.lblScrollAmount = new System.Windows.Forms.Label();
            this.nudScrollAmount = new System.Windows.Forms.NumericUpDown();
            this.btnScrollUp = new System.Windows.Forms.Button();
            this.btnScrollDown = new System.Windows.Forms.Button();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.nudAutoScrollInterval = new System.Windows.Forms.NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.nudScrollAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoScrollInterval)).BeginInit();
        }

        private void InitializeSettingsTab()
        {
            this.grpHotkeys = new System.Windows.Forms.GroupBox();
            this.lblHkRecord = new System.Windows.Forms.Label();
            this.btnHkRecord = new System.Windows.Forms.Button();
            this.lblHkStopRecord = new System.Windows.Forms.Label();
            this.btnHkStopRecord = new System.Windows.Forms.Button();
            this.lblHkPlay = new System.Windows.Forms.Label();
            this.btnHkPlay = new System.Windows.Forms.Button();
            this.lblHkStopPlay = new System.Windows.Forms.Label();
            this.btnHkStopPlay = new System.Windows.Forms.Button();
            this.lblHkClicker = new System.Windows.Forms.Label();
            this.btnHkClicker = new System.Windows.Forms.Button();
            this.lblHkAutoKey = new System.Windows.Forms.Label();
            this.btnHkAutoKey = new System.Windows.Forms.Button();
            this.lblHkPanic = new System.Windows.Forms.Label();
            this.btnHkPanic = new System.Windows.Forms.Button();
            this.btnResetHotkeys = new System.Windows.Forms.Button();

            this.grpTheme = new System.Windows.Forms.GroupBox();
            this.radDarkTheme = new System.Windows.Forms.RadioButton();
            this.radLightTheme = new System.Windows.Forms.RadioButton();
            this.radBlueTheme = new System.Windows.Forms.RadioButton();

            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.chkShowNotifications = new System.Windows.Forms.CheckBox();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();

            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
        }

        private void InitializeSystemTray()
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuClicker = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
        }

        private void SetupLayout()
        {
            // =====================
            // HEADER
            // =====================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(35, 35, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;

            this.lblTitle.Text = "⚡ ULTIMATE MACRO SUITE PRO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;

            this.lblStatus.Text = "● Ready";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 255, 150);
            this.lblStatus.Location = new System.Drawing.Point(900, 20);
            this.lblStatus.AutoSize = true;

            this.btnMinimize.Text = "─";
            this.btnMinimize.Location = new System.Drawing.Point(1050, 10);
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.btnMinimize);

            // =====================
            // TAB CONTROL
            // =====================
            this.tabMain.Location = new System.Drawing.Point(10, 70);
            this.tabMain.Size = new System.Drawing.Size(1080, 640);
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // Tab Pages
            this.tabRecorder.Text = "🎬 Recorder";
            this.tabRecorder.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.tabRecorder.Padding = new System.Windows.Forms.Padding(10);

            this.tabAutoClicker.Text = "🖱️ Auto Clicker";
            this.tabAutoClicker.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.tabAutoClicker.Padding = new System.Windows.Forms.Padding(10);

            this.tabAutoKey.Text = "⌨️ Auto Key";
            this.tabAutoKey.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.tabAutoKey.Padding = new System.Windows.Forms.Padding(10);

            this.tabMouseTools.Text = "🔧 Mouse Tools";
            this.tabMouseTools.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.tabMouseTools.Padding = new System.Windows.Forms.Padding(10);

            this.tabSettings.Text = "⚙️ Settings";
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.tabSettings.Padding = new System.Windows.Forms.Padding(10);

            SetupRecorderTab();
            SetupAutoClickerTab();
            SetupAutoKeyTab();
            SetupMouseToolsTab();
            SetupSettingsTab();
            SetupTrayIcon();

            this.tabMain.TabPages.Add(this.tabRecorder);
            this.tabMain.TabPages.Add(this.tabAutoClicker);
            this.tabMain.TabPages.Add(this.tabAutoKey);
            this.tabMain.TabPages.Add(this.tabMouseTools);
            this.tabMain.TabPages.Add(this.tabSettings);

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabMain);
        }

        private void SetupRecorderTab()
        {
            // Recording Controls Group
            this.grpRecControls.Text = "Recording Controls";
            this.grpRecControls.ForeColor = System.Drawing.Color.FromArgb(255, 180, 100);
            this.grpRecControls.Location = new System.Drawing.Point(15, 15);
            this.grpRecControls.Size = new System.Drawing.Size(350, 130);

            SetupButton(this.btnRecord, "⏺ Record", 15, 30, 100, 45, System.Drawing.Color.FromArgb(220, 70, 70));
            SetupButton(this.btnStopRecord, "⏹ Stop", 125, 30, 100, 45, System.Drawing.Color.FromArgb(80, 80, 95));
            SetupButton(this.btnPlay, "▶ Play", 15, 80, 100, 45, System.Drawing.Color.FromArgb(70, 180, 70));
            SetupButton(this.btnStopPlay, "⏹ Stop", 125, 80, 100, 45, System.Drawing.Color.FromArgb(80, 80, 95));
            SetupButton(this.btnPause, "⏸ Pause", 235, 80, 100, 45, System.Drawing.Color.FromArgb(200, 150, 50));

            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnStopPlay.Click += new System.EventHandler(this.btnStopPlay_Click);
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);

            this.grpRecControls.Controls.Add(this.btnRecord);
            this.grpRecControls.Controls.Add(this.btnStopRecord);
            this.grpRecControls.Controls.Add(this.btnPlay);
            this.grpRecControls.Controls.Add(this.btnStopPlay);
            this.grpRecControls.Controls.Add(this.btnPause);

            // Playback Settings Group
            this.grpPlaySettings.Text = "Playback Settings";
            this.grpPlaySettings.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.grpPlaySettings.Location = new System.Drawing.Point(15, 155);
            this.grpPlaySettings.Size = new System.Drawing.Size(350, 180);

            this.lblSpeed.Text = "Speed:";
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(15, 28);
            this.lblSpeed.AutoSize = true;

            this.trkSpeed.Location = new System.Drawing.Point(70, 25);
            this.trkSpeed.Size = new System.Drawing.Size(200, 30);
            this.trkSpeed.Minimum = 10;
            this.trkSpeed.Maximum = 500;
            this.trkSpeed.Value = 100;
            this.trkSpeed.TickFrequency = 50;
            this.trkSpeed.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.trkSpeed.Scroll += new System.EventHandler(this.trkSpeed_Scroll);

            this.nudSpeed.Location = new System.Drawing.Point(280, 25);
            this.nudSpeed.Size = new System.Drawing.Size(55, 25);
            this.nudSpeed.Minimum = 10;
            this.nudSpeed.Maximum = 500;
            this.nudSpeed.Value = 100;
            SetupNumericUpDown(this.nudSpeed);

            this.chkLoop.Text = "Loop playback";
            this.chkLoop.ForeColor = System.Drawing.Color.White;
            this.chkLoop.Location = new System.Drawing.Point(15, 60);
            this.chkLoop.AutoSize = true;

            this.nudLoopCount.Location = new System.Drawing.Point(140, 58);
            this.nudLoopCount.Size = new System.Drawing.Size(60, 25);
            this.nudLoopCount.Minimum = 1;
            this.nudLoopCount.Maximum = 9999;
            this.nudLoopCount.Value = 1;
            SetupNumericUpDown(this.nudLoopCount);

            this.chkInfiniteLoop.Text = "Infinite";
            this.chkInfiniteLoop.ForeColor = System.Drawing.Color.White;
            this.chkInfiniteLoop.Location = new System.Drawing.Point(210, 60);
            this.chkInfiniteLoop.AutoSize = true;

            this.chkRandomDelay.Text = "Random delay:";
            this.chkRandomDelay.ForeColor = System.Drawing.Color.White;
            this.chkRandomDelay.Location = new System.Drawing.Point(15, 95);
            this.chkRandomDelay.AutoSize = true;

            this.nudRandomMin.Location = new System.Drawing.Point(140, 93);
            this.nudRandomMin.Size = new System.Drawing.Size(60, 25);
            this.nudRandomMin.Minimum = 0;
            this.nudRandomMin.Maximum = 10000;
            this.nudRandomMin.Value = 0;
            SetupNumericUpDown(this.nudRandomMin);

            this.nudRandomMax.Location = new System.Drawing.Point(210, 93);
            this.nudRandomMax.Size = new System.Drawing.Size(60, 25);
            this.nudRandomMax.Minimum = 0;
            this.nudRandomMax.Maximum = 10000;
            this.nudRandomMax.Value = 100;
            SetupNumericUpDown(this.nudRandomMax);

            this.lblRandomMs.Text = "ms";
            this.lblRandomMs.ForeColor = System.Drawing.Color.Gray;
            this.lblRandomMs.Location = new System.Drawing.Point(275, 96);
            this.lblRandomMs.AutoSize = true;

            this.grpPlaySettings.Controls.Add(this.lblSpeed);
            this.grpPlaySettings.Controls.Add(this.trkSpeed);
            this.grpPlaySettings.Controls.Add(this.nudSpeed);
            this.grpPlaySettings.Controls.Add(this.chkLoop);
            this.grpPlaySettings.Controls.Add(this.nudLoopCount);
            this.grpPlaySettings.Controls.Add(this.chkInfiniteLoop);
            this.grpPlaySettings.Controls.Add(this.chkRandomDelay);
            this.grpPlaySettings.Controls.Add(this.nudRandomMin);
            this.grpPlaySettings.Controls.Add(this.nudRandomMax);
            this.grpPlaySettings.Controls.Add(this.lblRandomMs);

            // Record Options Group
            this.grpRecordOptions.Text = "Record Options";
            this.grpRecordOptions.ForeColor = System.Drawing.Color.FromArgb(200, 150, 255);
            this.grpRecordOptions.Location = new System.Drawing.Point(15, 345);
            this.grpRecordOptions.Size = new System.Drawing.Size(350, 120);

            this.chkRecordMouse.Text = "Record Mouse";
            this.chkRecordMouse.ForeColor = System.Drawing.Color.White;
            this.chkRecordMouse.Location = new System.Drawing.Point(15, 25);
            this.chkRecordMouse.AutoSize = true;
            this.chkRecordMouse.Checked = true;

            this.chkRecordKeyboard.Text = "Record Keyboard";
            this.chkRecordKeyboard.ForeColor = System.Drawing.Color.White;
            this.chkRecordKeyboard.Location = new System.Drawing.Point(150, 25);
            this.chkRecordKeyboard.AutoSize = true;
            this.chkRecordKeyboard.Checked = true;

            this.chkRecordMouseMove.Text = "Mouse Movement";
            this.chkRecordMouseMove.ForeColor = System.Drawing.Color.White;
            this.chkRecordMouseMove.Location = new System.Drawing.Point(15, 55);
            this.chkRecordMouseMove.AutoSize = true;
            this.chkRecordMouseMove.Checked = true;

            this.chkRecordClicks.Text = "Mouse Clicks";
            this.chkRecordClicks.ForeColor = System.Drawing.Color.White;
            this.chkRecordClicks.Location = new System.Drawing.Point(150, 55);
            this.chkRecordClicks.AutoSize = true;
            this.chkRecordClicks.Checked = true;

            this.chkRecordScroll.Text = "Mouse Scroll";
            this.chkRecordScroll.ForeColor = System.Drawing.Color.White;
            this.chkRecordScroll.Location = new System.Drawing.Point(15, 85);
            this.chkRecordScroll.AutoSize = true;
            this.chkRecordScroll.Checked = true;

            this.grpRecordOptions.Controls.Add(this.chkRecordMouse);
            this.grpRecordOptions.Controls.Add(this.chkRecordKeyboard);
            this.grpRecordOptions.Controls.Add(this.chkRecordMouseMove);
            this.grpRecordOptions.Controls.Add(this.chkRecordClicks);
            this.grpRecordOptions.Controls.Add(this.chkRecordScroll);

            // Actions Group
            this.grpActions.Text = "Recorded Actions";
            this.grpActions.ForeColor = System.Drawing.Color.FromArgb(150, 220, 150);
            this.grpActions.Location = new System.Drawing.Point(380, 15);
            this.grpActions.Size = new System.Drawing.Size(670, 450);

            this.lstActions.Location = new System.Drawing.Point(15, 30);
            this.lstActions.Size = new System.Drawing.Size(640, 340);
            this.lstActions.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.lstActions.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.lstActions.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lstActions.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.lblActionCount.Text = "Total: 0 actions | Duration: 0.0s";
            this.lblActionCount.ForeColor = System.Drawing.Color.Gray;
            this.lblActionCount.Location = new System.Drawing.Point(15, 380);
            this.lblActionCount.AutoSize = true;

            SetupButton(this.btnDeleteAction, "🗑 Delete", 15, 405, 80, 35, System.Drawing.Color.FromArgb(180, 70, 70));
            SetupButton(this.btnEditAction, "✏️ Edit", 105, 405, 80, 35, System.Drawing.Color.FromArgb(100, 140, 180));
            SetupButton(this.btnAddDelay, "⏱ +Delay", 195, 405, 85, 35, System.Drawing.Color.FromArgb(140, 140, 80));
            SetupButton(this.btnClear, "🗑 Clear All", 380, 405, 90, 35, System.Drawing.Color.FromArgb(180, 70, 70));
            SetupButton(this.btnExport, "💾 Export", 480, 405, 85, 35, System.Drawing.Color.FromArgb(80, 140, 180));
            SetupButton(this.btnImport, "📂 Import", 575, 405, 85, 35, System.Drawing.Color.FromArgb(80, 140, 180));

            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            this.btnEditAction.Click += new System.EventHandler(this.btnEditAction_Click);
            this.btnAddDelay.Click += new System.EventHandler(this.btnAddDelay_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            this.prgPlayback.Location = new System.Drawing.Point(300, 380);
            this.prgPlayback.Size = new System.Drawing.Size(355, 18);
            this.prgPlayback.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.grpActions.Controls.Add(this.lstActions);
            this.grpActions.Controls.Add(this.lblActionCount);
            this.grpActions.Controls.Add(this.btnDeleteAction);
            this.grpActions.Controls.Add(this.btnEditAction);
            this.grpActions.Controls.Add(this.btnAddDelay);
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnExport);
            this.grpActions.Controls.Add(this.btnImport);
            this.grpActions.Controls.Add(this.prgPlayback);

            this.tabRecorder.Controls.Add(this.grpRecControls);
            this.tabRecorder.Controls.Add(this.grpPlaySettings);
            this.tabRecorder.Controls.Add(this.grpRecordOptions);
            this.tabRecorder.Controls.Add(this.grpActions);
        }

        private void SetupAutoClickerTab()
        {
            // Clicker Settings
            this.grpClickerSettings.Text = "Click Settings";
            this.grpClickerSettings.ForeColor = System.Drawing.Color.FromArgb(255, 180, 100);
            this.grpClickerSettings.Location = new System.Drawing.Point(15, 15);
            this.grpClickerSettings.Size = new System.Drawing.Size(320, 180);

            this.lblClickInterval.Text = "Interval:";
            this.lblClickInterval.ForeColor = System.Drawing.Color.White;
            this.lblClickInterval.Location = new System.Drawing.Point(15, 35);
            this.lblClickInterval.AutoSize = true;

            this.nudClickInterval.Location = new System.Drawing.Point(90, 32);
            this.nudClickInterval.Size = new System.Drawing.Size(100, 25);
            this.nudClickInterval.Minimum = 1;
            this.nudClickInterval.Maximum = 999999;
            this.nudClickInterval.Value = 100;
            SetupNumericUpDown(this.nudClickInterval);

            this.cmbClickIntervalUnit.Location = new System.Drawing.Point(200, 32);
            this.cmbClickIntervalUnit.Size = new System.Drawing.Size(100, 25);
            this.cmbClickIntervalUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClickIntervalUnit.Items.AddRange(new object[] { "Milliseconds", "Seconds", "Minutes" });
            this.cmbClickIntervalUnit.SelectedIndex = 0;
            SetupComboBox(this.cmbClickIntervalUnit);

            this.lblClickButton.Text = "Button:";
            this.lblClickButton.ForeColor = System.Drawing.Color.White;
            this.lblClickButton.Location = new System.Drawing.Point(15, 75);
            this.lblClickButton.AutoSize = true;

            this.cmbMouseButton.Location = new System.Drawing.Point(90, 72);
            this.cmbMouseButton.Size = new System.Drawing.Size(120, 25);
            this.cmbMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMouseButton.Items.AddRange(new object[] { "Left", "Right", "Middle" });
            this.cmbMouseButton.SelectedIndex = 0;
            SetupComboBox(this.cmbMouseButton);

            this.lblClickType.Text = "Type:";
            this.lblClickType.ForeColor = System.Drawing.Color.White;
            this.lblClickType.Location = new System.Drawing.Point(15, 115);
            this.lblClickType.AutoSize = true;

            this.cmbClickType.Location = new System.Drawing.Point(90, 112);
            this.cmbClickType.Size = new System.Drawing.Size(120, 25);
            this.cmbClickType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClickType.Items.AddRange(new object[] { "Single", "Double", "Triple" });
            this.cmbClickType.SelectedIndex = 0;
            SetupComboBox(this.cmbClickType);

            this.grpClickerSettings.Controls.Add(this.lblClickInterval);
            this.grpClickerSettings.Controls.Add(this.nudClickInterval);
            this.grpClickerSettings.Controls.Add(this.cmbClickIntervalUnit);
            this.grpClickerSettings.Controls.Add(this.lblClickButton);
            this.grpClickerSettings.Controls.Add(this.cmbMouseButton);
            this.grpClickerSettings.Controls.Add(this.lblClickType);
            this.grpClickerSettings.Controls.Add(this.cmbClickType);

            // Position Settings
            this.grpClickerPosition.Text = "Click Position";
            this.grpClickerPosition.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.grpClickerPosition.Location = new System.Drawing.Point(15, 205);
            this.grpClickerPosition.Size = new System.Drawing.Size(320, 150);

            this.radCurrentPos.Text = "Current cursor position";
            this.radCurrentPos.ForeColor = System.Drawing.Color.White;
            this.radCurrentPos.Location = new System.Drawing.Point(15, 30);
            this.radCurrentPos.AutoSize = true;
            this.radCurrentPos.Checked = true;

            this.radFixedPos.Text = "Fixed position:";
            this.radFixedPos.ForeColor = System.Drawing.Color.White;
            this.radFixedPos.Location = new System.Drawing.Point(15, 60);
            this.radFixedPos.AutoSize = true;

            this.lblClickPos.Text = "X:";
            this.lblClickPos.ForeColor = System.Drawing.Color.White;
            this.lblClickPos.Location = new System.Drawing.Point(140, 62);
            this.lblClickPos.AutoSize = true;

            this.nudClickX.Location = new System.Drawing.Point(160, 58);
            this.nudClickX.Size = new System.Drawing.Size(65, 25);
            this.nudClickX.Minimum = 0;
            this.nudClickX.Maximum = 9999;
            this.nudClickX.Value = 0;
            SetupNumericUpDown(this.nudClickX);

            this.nudClickY.Location = new System.Drawing.Point(245, 58);
            this.nudClickY.Size = new System.Drawing.Size(65, 25);
            this.nudClickY.Minimum = 0;
            this.nudClickY.Maximum = 9999;
            this.nudClickY.Value = 0;
            SetupNumericUpDown(this.nudClickY);

            SetupButton(this.btnPickPosition, "🎯 Pick", 15, 100, 290, 35, System.Drawing.Color.FromArgb(100, 150, 200));
            this.btnPickPosition.Click += new System.EventHandler(this.btnPickPosition_Click);

            this.grpClickerPosition.Controls.Add(this.radCurrentPos);
            this.grpClickerPosition.Controls.Add(this.radFixedPos);
            this.grpClickerPosition.Controls.Add(this.lblClickPos);
            this.grpClickerPosition.Controls.Add(this.nudClickX);
            this.grpClickerPosition.Controls.Add(this.nudClickY);
            this.grpClickerPosition.Controls.Add(this.btnPickPosition);

            // Repeat Settings
            this.grpClickerRepeat.Text = "Repeat";
            this.grpClickerRepeat.ForeColor = System.Drawing.Color.FromArgb(200, 150, 255);
            this.grpClickerRepeat.Location = new System.Drawing.Point(15, 365);
            this.grpClickerRepeat.Size = new System.Drawing.Size(320, 100);

            this.radClickInfinite.Text = "Repeat until stopped";
            this.radClickInfinite.ForeColor = System.Drawing.Color.White;
            this.radClickInfinite.Location = new System.Drawing.Point(15, 30);
            this.radClickInfinite.AutoSize = true;
            this.radClickInfinite.Checked = true;

            this.radClickCount.Text = "Repeat";
            this.radClickCount.ForeColor = System.Drawing.Color.White;
            this.radClickCount.Location = new System.Drawing.Point(15, 60);
            this.radClickCount.AutoSize = true;

            this.nudClickCount.Location = new System.Drawing.Point(90, 57);
            this.nudClickCount.Size = new System.Drawing.Size(80, 25);
            this.nudClickCount.Minimum = 1;
            this.nudClickCount.Maximum = 999999;
            this.nudClickCount.Value = 10;
            SetupNumericUpDown(this.nudClickCount);

            this.grpClickerRepeat.Controls.Add(this.radClickInfinite);
            this.grpClickerRepeat.Controls.Add(this.radClickCount);
            this.grpClickerRepeat.Controls.Add(this.nudClickCount);

            // Start/Stop Buttons
            SetupButton(this.btnStartClicker, "▶ START CLICKING", 380, 100, 300, 80, System.Drawing.Color.FromArgb(70, 180, 70));
            this.btnStartClicker.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartClicker.Click += new System.EventHandler(this.btnStartClicker_Click);

            SetupButton(this.btnStopClicker, "⏹ STOP", 380, 200, 300, 80, System.Drawing.Color.FromArgb(180, 70, 70));
            this.btnStopClicker.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStopClicker.Click += new System.EventHandler(this.btnStopClicker_Click);

            this.lblClickerStatus.Text = "Status: Stopped";
            this.lblClickerStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClickerStatus.ForeColor = System.Drawing.Color.FromArgb(255, 150, 150);
            this.lblClickerStatus.Location = new System.Drawing.Point(380, 300);
            this.lblClickerStatus.AutoSize = true;

            this.lblClickCounter.Text = "Clicks: 0";
            this.lblClickCounter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblClickCounter.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.lblClickCounter.Location = new System.Drawing.Point(380, 340);
            this.lblClickCounter.AutoSize = true;

            this.tabAutoClicker.Controls.Add(this.grpClickerSettings);
            this.tabAutoClicker.Controls.Add(this.grpClickerPosition);
            this.tabAutoClicker.Controls.Add(this.grpClickerRepeat);
            this.tabAutoClicker.Controls.Add(this.btnStartClicker);
            this.tabAutoClicker.Controls.Add(this.btnStopClicker);
            this.tabAutoClicker.Controls.Add(this.lblClickerStatus);
            this.tabAutoClicker.Controls.Add(this.lblClickCounter);
        }

        private void SetupAutoKeyTab()
        {
            // Key Settings
            this.grpKeySettings.Text = "Key Settings";
            this.grpKeySettings.ForeColor = System.Drawing.Color.FromArgb(255, 180, 100);
            this.grpKeySettings.Location = new System.Drawing.Point(15, 15);
            this.grpKeySettings.Size = new System.Drawing.Size(320, 200);

            this.lblKeyToPress.Text = "Key:";
            this.lblKeyToPress.ForeColor = System.Drawing.Color.White;
            this.lblKeyToPress.Location = new System.Drawing.Point(15, 35);
            this.lblKeyToPress.AutoSize = true;

            this.cmbKeyToPress.Location = new System.Drawing.Point(70, 32);
            this.cmbKeyToPress.Size = new System.Drawing.Size(120, 25);
            this.cmbKeyToPress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            SetupComboBox(this.cmbKeyToPress);

            SetupButton(this.btnCaptureKey, "🎯 Capture", 200, 30, 100, 30, System.Drawing.Color.FromArgb(100, 150, 200));
            this.btnCaptureKey.Click += new System.EventHandler(this.btnCaptureKey_Click);

            this.lblKeyInterval.Text = "Interval:";
            this.lblKeyInterval.ForeColor = System.Drawing.Color.White;
            this.lblKeyInterval.Location = new System.Drawing.Point(15, 80);
            this.lblKeyInterval.AutoSize = true;

            this.nudKeyInterval.Location = new System.Drawing.Point(85, 77);
            this.nudKeyInterval.Size = new System.Drawing.Size(100, 25);
            this.nudKeyInterval.Minimum = 1;
            this.nudKeyInterval.Maximum = 999999;
            this.nudKeyInterval.Value = 100;
            SetupNumericUpDown(this.nudKeyInterval);

            this.cmbKeyIntervalUnit.Location = new System.Drawing.Point(195, 77);
            this.cmbKeyIntervalUnit.Size = new System.Drawing.Size(105, 25);
            this.cmbKeyIntervalUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyIntervalUnit.Items.AddRange(new object[] { "Milliseconds", "Seconds" });
            this.cmbKeyIntervalUnit.SelectedIndex = 0;
            SetupComboBox(this.cmbKeyIntervalUnit);

            this.chkHoldKey.Text = "Hold key for:";
            this.chkHoldKey.ForeColor = System.Drawing.Color.White;
            this.chkHoldKey.Location = new System.Drawing.Point(15, 120);
            this.chkHoldKey.AutoSize = true;

            this.nudHoldDuration.Location = new System.Drawing.Point(130, 118);
            this.nudHoldDuration.Size = new System.Drawing.Size(80, 25);
            this.nudHoldDuration.Minimum = 10;
            this.nudHoldDuration.Maximum = 10000;
            this.nudHoldDuration.Value = 100;
            SetupNumericUpDown(this.nudHoldDuration);

            this.grpKeySettings.Controls.Add(this.lblKeyToPress);
            this.grpKeySettings.Controls.Add(this.cmbKeyToPress);
            this.grpKeySettings.Controls.Add(this.btnCaptureKey);
            this.grpKeySettings.Controls.Add(this.lblKeyInterval);
            this.grpKeySettings.Controls.Add(this.nudKeyInterval);
            this.grpKeySettings.Controls.Add(this.cmbKeyIntervalUnit);
            this.grpKeySettings.Controls.Add(this.chkHoldKey);
            this.grpKeySettings.Controls.Add(this.nudHoldDuration);

            // Key Repeat
            this.grpKeyRepeat.Text = "Repeat";
            this.grpKeyRepeat.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.grpKeyRepeat.Location = new System.Drawing.Point(15, 225);
            this.grpKeyRepeat.Size = new System.Drawing.Size(320, 100);

            this.radKeyInfinite.Text = "Repeat until stopped";
            this.radKeyInfinite.ForeColor = System.Drawing.Color.White;
            this.radKeyInfinite.Location = new System.Drawing.Point(15, 30);
            this.radKeyInfinite.AutoSize = true;
            this.radKeyInfinite.Checked = true;

            this.radKeyCount.Text = "Repeat";
            this.radKeyCount.ForeColor = System.Drawing.Color.White;
            this.radKeyCount.Location = new System.Drawing.Point(15, 60);
            this.radKeyCount.AutoSize = true;

            this.nudKeyCount.Location = new System.Drawing.Point(90, 57);
            this.nudKeyCount.Size = new System.Drawing.Size(80, 25);
            this.nudKeyCount.Minimum = 1;
            this.nudKeyCount.Maximum = 999999;
            this.nudKeyCount.Value = 10;
            SetupNumericUpDown(this.nudKeyCount);

            this.grpKeyRepeat.Controls.Add(this.radKeyInfinite);
            this.grpKeyRepeat.Controls.Add(this.radKeyCount);
            this.grpKeyRepeat.Controls.Add(this.nudKeyCount);

            // Key Sequence
            this.grpKeySequence.Text = "Key Sequence (Optional)";
            this.grpKeySequence.ForeColor = System.Drawing.Color.FromArgb(200, 150, 255);
            this.grpKeySequence.Location = new System.Drawing.Point(15, 335);
            this.grpKeySequence.Size = new System.Drawing.Size(320, 200);

            this.chkSequenceMode.Text = "Use sequence mode";
            this.chkSequenceMode.ForeColor = System.Drawing.Color.White;
            this.chkSequenceMode.Location = new System.Drawing.Point(15, 25);
            this.chkSequenceMode.AutoSize = true;

            this.lstKeySequence.Location = new System.Drawing.Point(15, 55);
            this.lstKeySequence.Size = new System.Drawing.Size(200, 100);
            this.lstKeySequence.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.lstKeySequence.ForeColor = System.Drawing.Color.White;
            this.lstKeySequence.BorderStyle = System.Windows.Forms.BorderStyle.None;

            SetupButton(this.btnAddKey, "+", 225, 55, 40, 30, System.Drawing.Color.FromArgb(70, 150, 70));
            SetupButton(this.btnRemoveKey, "-", 270, 55, 40, 30, System.Drawing.Color.FromArgb(150, 70, 70));
            SetupButton(this.btnClearKeys, "Clear", 225, 95, 85, 30, System.Drawing.Color.FromArgb(100, 100, 120));

            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            this.btnRemoveKey.Click += new System.EventHandler(this.btnRemoveKey_Click);
            this.btnClearKeys.Click += new System.EventHandler(this.btnClearKeys_Click);

            this.grpKeySequence.Controls.Add(this.chkSequenceMode);
            this.grpKeySequence.Controls.Add(this.lstKeySequence);
            this.grpKeySequence.Controls.Add(this.btnAddKey);
            this.grpKeySequence.Controls.Add(this.btnRemoveKey);
            this.grpKeySequence.Controls.Add(this.btnClearKeys);

            // Start/Stop
            SetupButton(this.btnStartAutoKey, "▶ START AUTO KEY", 380, 100, 300, 80, System.Drawing.Color.FromArgb(70, 180, 70));
            this.btnStartAutoKey.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartAutoKey.Click += new System.EventHandler(this.btnStartAutoKey_Click);

            SetupButton(this.btnStopAutoKey, "⏹ STOP", 380, 200, 300, 80, System.Drawing.Color.FromArgb(180, 70, 70));
            this.btnStopAutoKey.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStopAutoKey.Click += new System.EventHandler(this.btnStopAutoKey_Click);

            this.lblAutoKeyStatus.Text = "Status: Stopped";
            this.lblAutoKeyStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAutoKeyStatus.ForeColor = System.Drawing.Color.FromArgb(255, 150, 150);
            this.lblAutoKeyStatus.Location = new System.Drawing.Point(380, 300);
            this.lblAutoKeyStatus.AutoSize = true;

            this.lblKeyCounter.Text = "Key Presses: 0";
            this.lblKeyCounter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKeyCounter.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.lblKeyCounter.Location = new System.Drawing.Point(380, 340);
            this.lblKeyCounter.AutoSize = true;

            this.tabAutoKey.Controls.Add(this.grpKeySettings);
            this.tabAutoKey.Controls.Add(this.grpKeyRepeat);
            this.tabAutoKey.Controls.Add(this.grpKeySequence);
            this.tabAutoKey.Controls.Add(this.btnStartAutoKey);
            this.tabAutoKey.Controls.Add(this.btnStopAutoKey);
            this.tabAutoKey.Controls.Add(this.lblAutoKeyStatus);
            this.tabAutoKey.Controls.Add(this.lblKeyCounter);
        }

        private void SetupMouseToolsTab()
        {
            // Mouse Info
            this.grpMouseInfo.Text = "Mouse Information (Live)";
            this.grpMouseInfo.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.grpMouseInfo.Location = new System.Drawing.Point(15, 15);
            this.grpMouseInfo.Size = new System.Drawing.Size(350, 160);

            this.lblCurrentPos.Text = "Cursor Position:";
            this.lblCurrentPos.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPos.Location = new System.Drawing.Point(15, 35);
            this.lblCurrentPos.AutoSize = true;

            this.lblCurrentPosValue.Text = "X: 0, Y: 0";
            this.lblCurrentPosValue.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPosValue.ForeColor = System.Drawing.Color.FromArgb(100, 255, 150);
            this.lblCurrentPosValue.Location = new System.Drawing.Point(140, 32);
            this.lblCurrentPosValue.AutoSize = true;

            this.lblPixelColor.Text = "Pixel Color:";
            this.lblPixelColor.ForeColor = System.Drawing.Color.White;
            this.lblPixelColor.Location = new System.Drawing.Point(15, 75);
            this.lblPixelColor.AutoSize = true;

            this.pnlColorPreview.Location = new System.Drawing.Point(140, 70);
            this.pnlColorPreview.Size = new System.Drawing.Size(40, 30);
            this.pnlColorPreview.BackColor = System.Drawing.Color.Black;
            this.pnlColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblColorHex.Text = "#000000";
            this.lblColorHex.Font = new System.Drawing.Font("Consolas", 11F);
            this.lblColorHex.ForeColor = System.Drawing.Color.White;
            this.lblColorHex.Location = new System.Drawing.Point(190, 77);
            this.lblColorHex.AutoSize = true;

            this.chkAlwaysOnTop.Text = "Always on Top";
            this.chkAlwaysOnTop.ForeColor = System.Drawing.Color.White;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(15, 120);
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);

            this.tmrMouseInfo.Interval = 50;
            this.tmrMouseInfo.Tick += new System.EventHandler(this.tmrMouseInfo_Tick);

            this.grpMouseInfo.Controls.Add(this.lblCurrentPos);
            this.grpMouseInfo.Controls.Add(this.lblCurrentPosValue);
            this.grpMouseInfo.Controls.Add(this.lblPixelColor);
            this.grpMouseInfo.Controls.Add(this.pnlColorPreview);
            this.grpMouseInfo.Controls.Add(this.lblColorHex);
            this.grpMouseInfo.Controls.Add(this.chkAlwaysOnTop);

            // Quick Click
            this.grpQuickClick.Text = "Quick Click";
            this.grpQuickClick.ForeColor = System.Drawing.Color.FromArgb(255, 180, 100);
            this.grpQuickClick.Location = new System.Drawing.Point(15, 190);
            this.grpQuickClick.Size = new System.Drawing.Size(350, 120);

            SetupButton(this.btnLeftClick, "🖱️ Left Click", 15, 35, 155, 40, System.Drawing.Color.FromArgb(80, 140, 180));
            SetupButton(this.btnRightClick, "🖱️ Right Click", 180, 35, 155, 40, System.Drawing.Color.FromArgb(180, 100, 80));
            SetupButton(this.btnMiddleClick, "🖱️ Middle Click", 15, 80, 155, 40, System.Drawing.Color.FromArgb(100, 150, 100));
            SetupButton(this.btnDoubleClick, "🖱️ Double Click", 180, 80, 155, 40, System.Drawing.Color.FromArgb(150, 100, 180));

            this.btnLeftClick.Click += new System.EventHandler(this.btnLeftClick_Click);
            this.btnRightClick.Click += new System.EventHandler(this.btnRightClick_Click);
            this.btnMiddleClick.Click += new System.EventHandler(this.btnMiddleClick_Click);
            this.btnDoubleClick.Click += new System.EventHandler(this.btnDoubleClick_Click);

            this.grpQuickClick.Controls.Add(this.btnLeftClick);
            this.grpQuickClick.Controls.Add(this.btnRightClick);
            this.grpQuickClick.Controls.Add(this.btnMiddleClick);
            this.grpQuickClick.Controls.Add(this.btnDoubleClick);

            // Scroll Tool
            this.grpScrollTool.Text = "Scroll Tool";
            this.grpScrollTool.ForeColor = System.Drawing.Color.FromArgb(200, 150, 255);
            this.grpScrollTool.Location = new System.Drawing.Point(15, 320);
            this.grpScrollTool.Size = new System.Drawing.Size(350, 150);

            this.lblScrollAmount.Text = "Amount:";
            this.lblScrollAmount.ForeColor = System.Drawing.Color.White;
            this.lblScrollAmount.Location = new System.Drawing.Point(15, 35);
            this.lblScrollAmount.AutoSize = true;

            this.nudScrollAmount.Location = new System.Drawing.Point(85, 32);
            this.nudScrollAmount.Size = new System.Drawing.Size(80, 25);
            this.nudScrollAmount.Minimum = 1;
            this.nudScrollAmount.Maximum = 1000;
            this.nudScrollAmount.Value = 3;
            SetupNumericUpDown(this.nudScrollAmount);

            SetupButton(this.btnScrollUp, "⬆ Scroll Up", 15, 70, 155, 40, System.Drawing.Color.FromArgb(100, 150, 180));
            SetupButton(this.btnScrollDown, "⬇ Scroll Down", 180, 70, 155, 40, System.Drawing.Color.FromArgb(100, 150, 180));

            this.btnScrollUp.Click += new System.EventHandler(this.btnScrollUp_Click);
            this.btnScrollDown.Click += new System.EventHandler(this.btnScrollDown_Click);

            this.chkAutoScroll.Text = "Auto scroll every";
            this.chkAutoScroll.ForeColor = System.Drawing.Color.White;
            this.chkAutoScroll.Location = new System.Drawing.Point(15, 120);
            this.chkAutoScroll.AutoSize = true;

            this.nudAutoScrollInterval.Location = new System.Drawing.Point(150, 118);
            this.nudAutoScrollInterval.Size = new System.Drawing.Size(70, 25);
            this.nudAutoScrollInterval.Minimum = 100;
            this.nudAutoScrollInterval.Maximum = 10000;
            this.nudAutoScrollInterval.Value = 1000;
            SetupNumericUpDown(this.nudAutoScrollInterval);

            this.grpScrollTool.Controls.Add(this.lblScrollAmount);
            this.grpScrollTool.Controls.Add(this.nudScrollAmount);
            this.grpScrollTool.Controls.Add(this.btnScrollUp);
            this.grpScrollTool.Controls.Add(this.btnScrollDown);
            this.grpScrollTool.Controls.Add(this.chkAutoScroll);
            this.grpScrollTool.Controls.Add(this.nudAutoScrollInterval);

            this.tabMouseTools.Controls.Add(this.grpMouseInfo);
            this.tabMouseTools.Controls.Add(this.grpQuickClick);
            this.tabMouseTools.Controls.Add(this.grpScrollTool);
        }

        private void SetupSettingsTab()
        {
            // Hotkeys
            this.grpHotkeys.Text = "Global Hotkeys";
            this.grpHotkeys.ForeColor = System.Drawing.Color.FromArgb(255, 180, 100);
            this.grpHotkeys.Location = new System.Drawing.Point(15, 15);
            this.grpHotkeys.Size = new System.Drawing.Size(400, 280);

            int y = 30;
            int spacing = 35;

            AddHotkeyRow(this.grpHotkeys, this.lblHkRecord, this.btnHkRecord, "Start Recording:", "F6", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkStopRecord, this.btnHkStopRecord, "Stop Recording:", "F7", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkPlay, this.btnHkPlay, "Start Playback:", "F8", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkStopPlay, this.btnHkStopPlay, "Stop Playback:", "F9", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkClicker, this.btnHkClicker, "Toggle Clicker:", "F10", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkAutoKey, this.btnHkAutoKey, "Toggle AutoKey:", "F11", y);
            y += spacing;
            AddHotkeyRow(this.grpHotkeys, this.lblHkPanic, this.btnHkPanic, "STOP ALL (Panic):", "F12", y);

            SetupButton(this.btnResetHotkeys, "Reset to Defaults", 15, 240, 150, 30, System.Drawing.Color.FromArgb(100, 100, 120));
            this.btnResetHotkeys.Click += new System.EventHandler(this.btnResetHotkeys_Click);
            this.grpHotkeys.Controls.Add(this.btnResetHotkeys);

            // Theme
            this.grpTheme.Text = "Theme";
            this.grpTheme.ForeColor = System.Drawing.Color.FromArgb(100, 200, 255);
            this.grpTheme.Location = new System.Drawing.Point(430, 15);
            this.grpTheme.Size = new System.Drawing.Size(200, 130);

            this.radDarkTheme.Text = "Dark Theme";
            this.radDarkTheme.ForeColor = System.Drawing.Color.White;
            this.radDarkTheme.Location = new System.Drawing.Point(15, 30);
            this.radDarkTheme.AutoSize = true;
            this.radDarkTheme.Checked = true;

            this.radLightTheme.Text = "Light Theme";
            this.radLightTheme.ForeColor = System.Drawing.Color.White;
            this.radLightTheme.Location = new System.Drawing.Point(15, 60);
            this.radLightTheme.AutoSize = true;

            this.radBlueTheme.Text = "Blue Theme";
            this.radBlueTheme.ForeColor = System.Drawing.Color.White;
            this.radBlueTheme.Location = new System.Drawing.Point(15, 90);
            this.radBlueTheme.AutoSize = true;

            this.grpTheme.Controls.Add(this.radDarkTheme);
            this.grpTheme.Controls.Add(this.radLightTheme);
            this.grpTheme.Controls.Add(this.radBlueTheme);

            // General Settings
            this.grpGeneral.Text = "General Settings";
            this.grpGeneral.ForeColor = System.Drawing.Color.FromArgb(200, 150, 255);
            this.grpGeneral.Location = new System.Drawing.Point(430, 155);
            this.grpGeneral.Size = new System.Drawing.Size(250, 180);

            this.chkStartMinimized.Text = "Start minimized";
            this.chkStartMinimized.ForeColor = System.Drawing.Color.White;
            this.chkStartMinimized.Location = new System.Drawing.Point(15, 30);
            this.chkStartMinimized.AutoSize = true;

            this.chkMinimizeToTray.Text = "Minimize to system tray";
            this.chkMinimizeToTray.ForeColor = System.Drawing.Color.White;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(15, 55);
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Checked = true;

            this.chkPlaySound.Text = "Play sounds";
            this.chkPlaySound.ForeColor = System.Drawing.Color.White;
            this.chkPlaySound.Location = new System.Drawing.Point(15, 80);
            this.chkPlaySound.AutoSize = true;

            this.chkShowNotifications.Text = "Show notifications";
            this.chkShowNotifications.ForeColor = System.Drawing.Color.White;
            this.chkShowNotifications.Location = new System.Drawing.Point(15, 105);
            this.chkShowNotifications.AutoSize = true;
            this.chkShowNotifications.Checked = true;

            this.chkAutoSave.Text = "Auto-save macros";
            this.chkAutoSave.ForeColor = System.Drawing.Color.White;
            this.chkAutoSave.Location = new System.Drawing.Point(15, 130);
            this.chkAutoSave.AutoSize = true;

            this.grpGeneral.Controls.Add(this.chkStartMinimized);
            this.grpGeneral.Controls.Add(this.chkMinimizeToTray);
            this.grpGeneral.Controls.Add(this.chkPlaySound);
            this.grpGeneral.Controls.Add(this.chkShowNotifications);
            this.grpGeneral.Controls.Add(this.chkAutoSave);

            // Save/Reset Buttons
            SetupButton(this.btnSaveSettings, "💾 Save Settings", 430, 350, 130, 40, System.Drawing.Color.FromArgb(80, 160, 80));
            SetupButton(this.btnResetSettings, "🔄 Reset All", 570, 350, 110, 40, System.Drawing.Color.FromArgb(160, 80, 80));

            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);

            this.lblVersion.Text = "Version 2.0 Pro | © 2024";
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(430, 450);
            this.lblVersion.AutoSize = true;

            this.tabSettings.Controls.Add(this.grpHotkeys);
            this.tabSettings.Controls.Add(this.grpTheme);
            this.tabSettings.Controls.Add(this.grpGeneral);
            this.tabSettings.Controls.Add(this.btnSaveSettings);
            this.tabSettings.Controls.Add(this.btnResetSettings);
            this.tabSettings.Controls.Add(this.lblVersion);
        }

        private void SetupTrayIcon()
        {
            this.notifyIcon.Text = "Ultimate Macro Suite";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);

            this.trayMenuShow.Text = "Show";
            this.trayMenuShow.Click += new System.EventHandler(this.trayMenuShow_Click);

            this.trayMenuRecord.Text = "Start Recording";
            this.trayMenuRecord.Click += new System.EventHandler(this.trayMenuRecord_Click);

            this.trayMenuPlay.Text = "Play Macro";
            this.trayMenuPlay.Click += new System.EventHandler(this.trayMenuPlay_Click);

            this.trayMenuClicker.Text = "Toggle Clicker";
            this.trayMenuClicker.Click += new System.EventHandler(this.trayMenuClicker_Click);

            this.trayMenuExit.Text = "Exit";
            this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);

            this.trayMenu.Items.Add(this.trayMenuShow);
            this.trayMenu.Items.Add(new System.Windows.Forms.ToolStripSeparator());
            this.trayMenu.Items.Add(this.trayMenuRecord);
            this.trayMenu.Items.Add(this.trayMenuPlay);
            this.trayMenu.Items.Add(this.trayMenuClicker);
            this.trayMenu.Items.Add(new System.Windows.Forms.ToolStripSeparator());
            this.trayMenu.Items.Add(this.trayMenuExit);

            this.notifyIcon.ContextMenuStrip = this.trayMenu;
        }

        private void AddHotkeyRow(System.Windows.Forms.GroupBox grp, System.Windows.Forms.Label lbl,
            System.Windows.Forms.Button btn, string labelText, string keyText, int y)
        {
            lbl.Text = labelText;
            lbl.ForeColor = System.Drawing.Color.White;
            lbl.Location = new System.Drawing.Point(15, y + 3);
            lbl.AutoSize = true;

            btn.Text = keyText;
            btn.Location = new System.Drawing.Point(180, y);
            btn.Size = new System.Drawing.Size(120, 28);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
            btn.ForeColor = System.Drawing.Color.FromArgb(150, 220, 255);
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 80, 100);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Click += new System.EventHandler(this.HotkeyButton_Click);

            grp.Controls.Add(lbl);
            grp.Controls.Add(btn);
        }

        private void SetupButton(System.Windows.Forms.Button btn, string text, int x, int y, int w, int h, System.Drawing.Color bgColor)
        {
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(w, h);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.BackColor = bgColor;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        }

        private void SetupNumericUpDown(System.Windows.Forms.NumericUpDown nud)
        {
            nud.BackColor = System.Drawing.Color.FromArgb(45, 45, 60);
            nud.ForeColor = System.Drawing.Color.White;
            nud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void SetupComboBox(System.Windows.Forms.ComboBox cmb)
        {
            cmb.BackColor = System.Drawing.Color.FromArgb(45, 45, 60);
            cmb.ForeColor = System.Drawing.Color.White;
            cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }
    }
}