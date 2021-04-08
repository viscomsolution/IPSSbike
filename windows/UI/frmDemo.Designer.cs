namespace IPSS
{
    partial class frmDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
            this.grCamera = new System.Windows.Forms.GroupBox();
            this.chkAutodetect = new System.Windows.Forms.CheckBox();
            this.btnConnectCameraIP = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.rdNetworkCamera = new System.Windows.Forms.RadioButton();
            this.rdLocalCamera = new System.Windows.Forms.RadioButton();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.groupSrc = new System.Windows.Forms.GroupBox();
            this.chkSaveInputImage = new System.Windows.Forms.CheckBox();
            this.btnSelectFolderOutput = new System.Windows.Forms.Button();
            this.chkCrop = new System.Windows.Forms.CheckBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.chkEnableLog = new System.Windows.Forms.CheckBox();
            this.rdFolder = new System.Windows.Forms.RadioButton();
            this.txtFolderOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.Label();
            this.rdImage = new System.Windows.Forms.RadioButton();
            this.rdCamera = new System.Windows.Forms.RadioButton();
            this.grImage = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstImage = new System.Windows.Forms.ListView();
            this.clFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSnapshot = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.streamPlayer = new WebEye.StreamPlayerControl();
            this.grFolder = new System.Windows.Forms.GroupBox();
            this.txtInvalidDir = new System.Windows.Forms.TextBox();
            this.chkMoveInvalid = new System.Windows.Forms.CheckBox();
            this.txtValidDir = new System.Windows.Forms.TextBox();
            this.chkMoveValid = new System.Windows.Forms.CheckBox();
            this.txtFailedDir = new System.Windows.Forms.TextBox();
            this.chkMoveFail = new System.Windows.Forms.CheckBox();
            this.btnSelectFolderInput = new System.Windows.Forms.Button();
            this.txtFolderInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timerStream = new System.Windows.Forms.Timer(this.components);
            this.timerAutoDetect = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.chk_enableDeepScan = new System.Windows.Forms.CheckBox();
            this.grCamera.SuspendLayout();
            this.groupSrc.SuspendLayout();
            this.grImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSnapshot)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.grFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grCamera
            // 
            this.grCamera.Controls.Add(this.chkAutodetect);
            this.grCamera.Controls.Add(this.btnConnectCameraIP);
            this.grCamera.Controls.Add(this.txtIpAddress);
            this.grCamera.Controls.Add(this.rdNetworkCamera);
            this.grCamera.Controls.Add(this.rdLocalCamera);
            this.grCamera.Controls.Add(this.cbCamera);
            this.grCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.grCamera.Location = new System.Drawing.Point(0, 195);
            this.grCamera.Name = "grCamera";
            this.grCamera.Size = new System.Drawing.Size(999, 85);
            this.grCamera.TabIndex = 0;
            this.grCamera.TabStop = false;
            this.grCamera.Text = "Camera";
            this.grCamera.Visible = false;
            // 
            // chkAutodetect
            // 
            this.chkAutodetect.AutoSize = true;
            this.chkAutodetect.Location = new System.Drawing.Point(496, 37);
            this.chkAutodetect.Name = "chkAutodetect";
            this.chkAutodetect.Size = new System.Drawing.Size(81, 17);
            this.chkAutodetect.TabIndex = 10;
            this.chkAutodetect.Text = "Auto detect";
            this.chkAutodetect.UseVisualStyleBackColor = true;
            this.chkAutodetect.CheckedChanged += new System.EventHandler(this.chkAutodetect_CheckedChanged);
            // 
            // btnConnectCameraIP
            // 
            this.btnConnectCameraIP.Enabled = false;
            this.btnConnectCameraIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectCameraIP.Location = new System.Drawing.Point(394, 47);
            this.btnConnectCameraIP.Name = "btnConnectCameraIP";
            this.btnConnectCameraIP.Size = new System.Drawing.Size(61, 23);
            this.btnConnectCameraIP.TabIndex = 9;
            this.btnConnectCameraIP.Text = "Start";
            this.btnConnectCameraIP.UseVisualStyleBackColor = true;
            this.btnConnectCameraIP.Click += new System.EventHandler(this.btnConnectCameraIP_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Enabled = false;
            this.txtIpAddress.Location = new System.Drawing.Point(134, 48);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(256, 20);
            this.txtIpAddress.TabIndex = 7;
            this.txtIpAddress.TextChanged += new System.EventHandler(this.txtIpAddress_TextChanged);
            // 
            // rdNetworkCamera
            // 
            this.rdNetworkCamera.AutoSize = true;
            this.rdNetworkCamera.Location = new System.Drawing.Point(21, 48);
            this.rdNetworkCamera.Name = "rdNetworkCamera";
            this.rdNetworkCamera.Size = new System.Drawing.Size(103, 17);
            this.rdNetworkCamera.TabIndex = 6;
            this.rdNetworkCamera.Text = "Network camera";
            this.toolTip1.SetToolTip(this.rdNetworkCamera, "Using IP camera");
            this.rdNetworkCamera.UseVisualStyleBackColor = true;
            this.rdNetworkCamera.CheckedChanged += new System.EventHandler(this.rdNetworkCamera_CheckedChanged);
            // 
            // rdLocalCamera
            // 
            this.rdLocalCamera.Location = new System.Drawing.Point(21, 22);
            this.rdLocalCamera.Name = "rdLocalCamera";
            this.rdLocalCamera.Size = new System.Drawing.Size(90, 17);
            this.rdLocalCamera.TabIndex = 5;
            this.rdLocalCamera.Text = "Local camera";
            this.toolTip1.SetToolTip(this.rdLocalCamera, "Using webcam");
            this.rdLocalCamera.UseVisualStyleBackColor = true;
            this.rdLocalCamera.CheckedChanged += new System.EventHandler(this.rdLocalCamera_CheckedChanged);
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Enabled = false;
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(134, 18);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(256, 21);
            this.cbCamera.TabIndex = 1;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // groupSrc
            // 
            this.groupSrc.Controls.Add(this.chk_enableDeepScan);
            this.groupSrc.Controls.Add(this.chkSaveInputImage);
            this.groupSrc.Controls.Add(this.btnSelectFolderOutput);
            this.groupSrc.Controls.Add(this.chkCrop);
            this.groupSrc.Controls.Add(this.btnDetect);
            this.groupSrc.Controls.Add(this.chkEnableLog);
            this.groupSrc.Controls.Add(this.rdFolder);
            this.groupSrc.Controls.Add(this.txtFolderOutput);
            this.groupSrc.Controls.Add(this.label6);
            this.groupSrc.Controls.Add(this.txtResult);
            this.groupSrc.Controls.Add(this.rdImage);
            this.groupSrc.Controls.Add(this.rdCamera);
            this.groupSrc.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSrc.Location = new System.Drawing.Point(0, 24);
            this.groupSrc.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.groupSrc.Name = "groupSrc";
            this.groupSrc.Size = new System.Drawing.Size(999, 86);
            this.groupSrc.TabIndex = 4;
            this.groupSrc.TabStop = false;
            this.groupSrc.Text = "Image source";
            // 
            // chkSaveInputImage
            // 
            this.chkSaveInputImage.AutoSize = true;
            this.chkSaveInputImage.Location = new System.Drawing.Point(728, 19);
            this.chkSaveInputImage.Name = "chkSaveInputImage";
            this.chkSaveInputImage.Size = new System.Drawing.Size(108, 17);
            this.chkSaveInputImage.TabIndex = 2;
            this.chkSaveInputImage.Text = "Save input image";
            this.chkSaveInputImage.UseVisualStyleBackColor = true;
            this.chkSaveInputImage.CheckedChanged += new System.EventHandler(this.chkSaveInputImage_CheckedChanged);
            // 
            // btnSelectFolderOutput
            // 
            this.btnSelectFolderOutput.Location = new System.Drawing.Point(394, 49);
            this.btnSelectFolderOutput.Name = "btnSelectFolderOutput";
            this.btnSelectFolderOutput.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFolderOutput.TabIndex = 9;
            this.btnSelectFolderOutput.Text = "...";
            this.btnSelectFolderOutput.UseVisualStyleBackColor = true;
            this.btnSelectFolderOutput.Click += new System.EventHandler(this.btnSelectFolderOutput_Click);
            // 
            // chkCrop
            // 
            this.chkCrop.AutoSize = true;
            this.chkCrop.Location = new System.Drawing.Point(853, 50);
            this.chkCrop.Name = "chkCrop";
            this.chkCrop.Size = new System.Drawing.Size(107, 17);
            this.chkCrop.TabIndex = 1;
            this.chkCrop.Text = "Crop result image";
            this.chkCrop.UseVisualStyleBackColor = true;
            this.chkCrop.CheckedChanged += new System.EventHandler(this.chkCrop_CheckedChanged);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(268, 12);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(100, 33);
            this.btnDetect.TabIndex = 4;
            this.btnDetect.Text = "Start detect (F5)";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.EnabledChanged += new System.EventHandler(this.btnDetect_EnabledChanged);
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // chkEnableLog
            // 
            this.chkEnableLog.AutoSize = true;
            this.chkEnableLog.Location = new System.Drawing.Point(728, 50);
            this.chkEnableLog.Name = "chkEnableLog";
            this.chkEnableLog.Size = new System.Drawing.Size(68, 17);
            this.chkEnableLog.TabIndex = 0;
            this.chkEnableLog.Text = "Write log";
            this.chkEnableLog.UseVisualStyleBackColor = true;
            this.chkEnableLog.CheckedChanged += new System.EventHandler(this.chkEnableLog_CheckedChanged);
            // 
            // rdFolder
            // 
            this.rdFolder.AutoSize = true;
            this.rdFolder.Location = new System.Drawing.Point(180, 20);
            this.rdFolder.Name = "rdFolder";
            this.rdFolder.Size = new System.Drawing.Size(54, 17);
            this.rdFolder.TabIndex = 3;
            this.rdFolder.Text = "Folder";
            this.toolTip1.SetToolTip(this.rdFolder, "Detect batch image in folder");
            this.rdFolder.UseVisualStyleBackColor = true;
            this.rdFolder.CheckedChanged += new System.EventHandler(this.rdFolder_CheckedChanged);
            // 
            // txtFolderOutput
            // 
            this.txtFolderOutput.Location = new System.Drawing.Point(117, 50);
            this.txtFolderOutput.Name = "txtFolderOutput";
            this.txtFolderOutput.Size = new System.Drawing.Size(273, 20);
            this.txtFolderOutput.TabIndex = 7;
            this.txtFolderOutput.TextChanged += new System.EventHandler(this.txtFolderOutput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output folder";
            // 
            // txtResult
            // 
            this.txtResult.AutoSize = true;
            this.txtResult.BackColor = System.Drawing.SystemColors.Control;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(386, 14);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(0, 26);
            this.txtResult.TabIndex = 2;
            // 
            // rdImage
            // 
            this.rdImage.AutoSize = true;
            this.rdImage.Location = new System.Drawing.Point(102, 20);
            this.rdImage.Name = "rdImage";
            this.rdImage.Size = new System.Drawing.Size(54, 17);
            this.rdImage.TabIndex = 1;
            this.rdImage.Text = "Image";
            this.toolTip1.SetToolTip(this.rdImage, "Detect license plate from 1 static image");
            this.rdImage.UseVisualStyleBackColor = true;
            this.rdImage.CheckedChanged += new System.EventHandler(this.rdImage_CheckedChanged);
            // 
            // rdCamera
            // 
            this.rdCamera.Location = new System.Drawing.Point(21, 20);
            this.rdCamera.Name = "rdCamera";
            this.rdCamera.Size = new System.Drawing.Size(61, 17);
            this.rdCamera.TabIndex = 0;
            this.rdCamera.Text = "Camera";
            this.toolTip1.SetToolTip(this.rdCamera, "Detect license plate realtime");
            this.rdCamera.UseVisualStyleBackColor = true;
            this.rdCamera.CheckedChanged += new System.EventHandler(this.rdCamera_CheckedChanged);
            // 
            // grImage
            // 
            this.grImage.Controls.Add(this.btnBrowse);
            this.grImage.Controls.Add(this.txtFilePath);
            this.grImage.Controls.Add(this.label5);
            this.grImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grImage.Location = new System.Drawing.Point(0, 110);
            this.grImage.Name = "grImage";
            this.grImage.Size = new System.Drawing.Size(999, 85);
            this.grImage.TabIndex = 5;
            this.grImage.TabStop = false;
            this.grImage.Text = "Static image";
            this.grImage.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(396, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(117, 39);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(273, 20);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "File path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstImage);
            this.groupBox1.Controls.Add(this.btnSnapshot);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.picCamera);
            this.groupBox1.Controls.Add(this.picResult);
            this.groupBox1.Controls.Add(this.streamPlayer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 231);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lstImage
            // 
            this.lstImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clFile,
            this.clResult});
            this.lstImage.ContextMenuStrip = this.contextMenuStrip1;
            this.lstImage.FullRowSelect = true;
            this.lstImage.GridLines = true;
            this.lstImage.Location = new System.Drawing.Point(21, 17);
            this.lstImage.MultiSelect = false;
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(481, 360);
            this.lstImage.TabIndex = 13;
            this.lstImage.UseCompatibleStateImageBehavior = false;
            this.lstImage.View = System.Windows.Forms.View.Details;
            this.lstImage.Visible = false;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            this.lstImage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstImage_KeyDown);
            this.lstImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstImage_MouseClick);
            // 
            // clFile
            // 
            this.clFile.Text = "File name";
            this.clFile.Width = 300;
            // 
            // clResult
            // 
            this.clResult.Text = "Result";
            this.clResult.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStrip1.Text = "Copy path";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Image = global::IPSS.Properties.Resources.save;
            this.btnSnapshot.Location = new System.Drawing.Point(483, 25);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(20, 18);
            this.btnSnapshot.TabIndex = 12;
            this.btnSnapshot.TabStop = false;
            this.btnSnapshot.Visible = false;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(3, 206);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(23, 17);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(480, 360);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera.TabIndex = 4;
            this.picCamera.TabStop = false;
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(509, 17);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 360);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 9;
            this.picResult.TabStop = false;
            // 
            // streamPlayer
            // 
            this.streamPlayer.Location = new System.Drawing.Point(23, 43);
            this.streamPlayer.Name = "streamPlayer";
            this.streamPlayer.Size = new System.Drawing.Size(480, 360);
            this.streamPlayer.TabIndex = 11;
            this.streamPlayer.StreamStarted += new System.EventHandler(this.streamPlayer_StreamStarted);
            this.streamPlayer.StreamStopped += new System.EventHandler(this.streamPlayer_StreamStopped);
            this.streamPlayer.StreamFailed += new System.EventHandler<WebEye.StreamFailedEventArgs>(this.HandleStreamFailedEvent);
            // 
            // grFolder
            // 
            this.grFolder.Controls.Add(this.txtInvalidDir);
            this.grFolder.Controls.Add(this.chkMoveInvalid);
            this.grFolder.Controls.Add(this.txtValidDir);
            this.grFolder.Controls.Add(this.chkMoveValid);
            this.grFolder.Controls.Add(this.txtFailedDir);
            this.grFolder.Controls.Add(this.chkMoveFail);
            this.grFolder.Controls.Add(this.btnSelectFolderInput);
            this.grFolder.Controls.Add(this.txtFolderInput);
            this.grFolder.Controls.Add(this.label2);
            this.grFolder.Controls.Add(this.label4);
            this.grFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grFolder.Location = new System.Drawing.Point(0, 280);
            this.grFolder.Name = "grFolder";
            this.grFolder.Size = new System.Drawing.Size(999, 85);
            this.grFolder.TabIndex = 7;
            this.grFolder.TabStop = false;
            this.grFolder.Text = "Folder";
            this.grFolder.Visible = false;
            // 
            // txtInvalidDir
            // 
            this.txtInvalidDir.Location = new System.Drawing.Point(586, 62);
            this.txtInvalidDir.Name = "txtInvalidDir";
            this.txtInvalidDir.Size = new System.Drawing.Size(273, 20);
            this.txtInvalidDir.TabIndex = 17;
            // 
            // chkMoveInvalid
            // 
            this.chkMoveInvalid.AutoSize = true;
            this.chkMoveInvalid.Location = new System.Drawing.Point(446, 62);
            this.chkMoveInvalid.Name = "chkMoveInvalid";
            this.chkMoveInvalid.Size = new System.Drawing.Size(114, 17);
            this.chkMoveInvalid.TabIndex = 16;
            this.chkMoveInvalid.Text = "Move invalid file to";
            this.chkMoveInvalid.UseVisualStyleBackColor = true;
            this.chkMoveInvalid.CheckedChanged += new System.EventHandler(this.chkMoveInvalid_CheckedChanged);
            // 
            // txtValidDir
            // 
            this.txtValidDir.Location = new System.Drawing.Point(586, 39);
            this.txtValidDir.Name = "txtValidDir";
            this.txtValidDir.Size = new System.Drawing.Size(273, 20);
            this.txtValidDir.TabIndex = 15;
            this.txtValidDir.TextChanged += new System.EventHandler(this.txtValidDir_TextChanged);
            // 
            // chkMoveValid
            // 
            this.chkMoveValid.AutoSize = true;
            this.chkMoveValid.Location = new System.Drawing.Point(446, 39);
            this.chkMoveValid.Name = "chkMoveValid";
            this.chkMoveValid.Size = new System.Drawing.Size(106, 17);
            this.chkMoveValid.TabIndex = 14;
            this.chkMoveValid.Text = "Move valid file to";
            this.chkMoveValid.UseVisualStyleBackColor = true;
            this.chkMoveValid.CheckedChanged += new System.EventHandler(this.chkMoveValid_CheckedChanged);
            // 
            // txtFailedDir
            // 
            this.txtFailedDir.Location = new System.Drawing.Point(586, 15);
            this.txtFailedDir.Name = "txtFailedDir";
            this.txtFailedDir.Size = new System.Drawing.Size(273, 20);
            this.txtFailedDir.TabIndex = 13;
            this.txtFailedDir.TextChanged += new System.EventHandler(this.txtFailedDir_TextChanged);
            // 
            // chkMoveFail
            // 
            this.chkMoveFail.AutoSize = true;
            this.chkMoveFail.Location = new System.Drawing.Point(446, 15);
            this.chkMoveFail.Name = "chkMoveFail";
            this.chkMoveFail.Size = new System.Drawing.Size(140, 17);
            this.chkMoveFail.TabIndex = 12;
            this.chkMoveFail.Text = "Move file can\'t detect to";
            this.chkMoveFail.UseVisualStyleBackColor = true;
            this.chkMoveFail.CheckedChanged += new System.EventHandler(this.chkMoveFail_CheckedChanged);
            // 
            // btnSelectFolderInput
            // 
            this.btnSelectFolderInput.Location = new System.Drawing.Point(394, 34);
            this.btnSelectFolderInput.Name = "btnSelectFolderInput";
            this.btnSelectFolderInput.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFolderInput.TabIndex = 8;
            this.btnSelectFolderInput.Text = "...";
            this.btnSelectFolderInput.UseVisualStyleBackColor = true;
            this.btnSelectFolderInput.Click += new System.EventHandler(this.btnSelectFolderInput_Click);
            // 
            // txtFolderInput
            // 
            this.txtFolderInput.Location = new System.Drawing.Point(117, 35);
            this.txtFolderInput.Name = "txtFolderInput";
            this.txtFolderInput.Size = new System.Drawing.Size(273, 20);
            this.txtFolderInput.TabIndex = 5;
            this.txtFolderInput.TextChanged += new System.EventHandler(this.txtFolderInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.WorkerSupportsCancellation = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // timerStream
            // 
            this.timerStream.Interval = 50;
            this.timerStream.Tick += new System.EventHandler(this.timerStream_Tick);
            // 
            // timerAutoDetect
            // 
            this.timerAutoDetect.Interval = 500;
            this.timerAutoDetect.Tick += new System.EventHandler(this.timerAutoDetect_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timerDraw
            // 
            this.timerDraw.Interval = 30;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 3000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // chk_enableDeepScan
            // 
            this.chk_enableDeepScan.AutoSize = true;
            this.chk_enableDeepScan.Location = new System.Drawing.Point(852, 19);
            this.chk_enableDeepScan.Name = "chk_enableDeepScan";
            this.chk_enableDeepScan.Size = new System.Drawing.Size(112, 17);
            this.chk_enableDeepScan.TabIndex = 10;
            this.chk_enableDeepScan.Text = "Enable deep scan";
            this.chk_enableDeepScan.UseVisualStyleBackColor = true;
            this.chk_enableDeepScan.CheckedChanged += new System.EventHandler(this.chk_enableDeepScan_CheckedChanged);
            // 
            // frmDemo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(999, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grFolder);
            this.Controls.Add(this.grCamera);
            this.Controls.Add(this.grImage);
            this.Controls.Add(this.groupSrc);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDemo";
            this.Text = "Phần mềm đọc biển số xe máy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDemo_FormClosed);
            this.Shown += new System.EventHandler(this.frmDemo_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmDemo_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmDemo_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDemo_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDemo_KeyUp);
            this.grCamera.ResumeLayout(false);
            this.grCamera.PerformLayout();
            this.groupSrc.ResumeLayout(false);
            this.groupSrc.PerformLayout();
            this.grImage.ResumeLayout(false);
            this.grImage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSnapshot)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.grFolder.ResumeLayout(false);
            this.grFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grCamera;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.GroupBox groupSrc;
        private System.Windows.Forms.GroupBox grImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rdImage;
        private System.Windows.Forms.RadioButton rdCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label txtResult;
        private System.Windows.Forms.RadioButton rdFolder;
        private System.Windows.Forms.GroupBox grFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolderOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFolderInput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSelectFolderInput;
        private System.Windows.Forms.Button btnSelectFolderOutput;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.RadioButton rdNetworkCamera;
        private System.Windows.Forms.RadioButton rdLocalCamera;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Button btnConnectCameraIP;
        private WebEye.StreamPlayerControl streamPlayer;
        private System.Windows.Forms.PictureBox btnSnapshot;
        private System.Windows.Forms.Timer timerStream;
        private System.Windows.Forms.Timer timerAutoDetect;
        private System.Windows.Forms.CheckBox chkAutodetect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.ListView lstImage;
        private System.Windows.Forms.ColumnHeader clFile;
        private System.Windows.Forms.ColumnHeader clResult;
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.Windows.Forms.CheckBox chkSaveInputImage;
        private System.Windows.Forms.CheckBox chkCrop;
        private System.Windows.Forms.CheckBox chkEnableLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMoveFail;
        private System.Windows.Forms.TextBox txtFailedDir;
        private System.Windows.Forms.TextBox txtValidDir;
        private System.Windows.Forms.CheckBox chkMoveValid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.TextBox txtInvalidDir;
        private System.Windows.Forms.CheckBox chkMoveInvalid;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.CheckBox chk_enableDeepScan;
    }
}