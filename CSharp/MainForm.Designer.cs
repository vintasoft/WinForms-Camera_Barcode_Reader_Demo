namespace CameraBarcodeReaderDemo
{
    partial class MainForm
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings2 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.camerasComboBox = new System.Windows.Forms.ComboBox();
            this.startImageCapturingButton = new System.Windows.Forms.Button();
            this.stopImageCapturingButton = new System.Windows.Forms.Button();
            this.configureCameraButton = new System.Windows.Forms.Button();
            this.scanBarcodeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.readerResultsTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cameraPreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.captureDeviceMonitorTextBox = new System.Windows.Forms.TextBox();
            this.supportedFormatsComboBox = new System.Windows.Forms.ComboBox();
            this.imageViewerForCameraPreview = new Vintasoft.Imaging.UI.ImageViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.barcodeReaderGroupBox = new System.Windows.Forms.GroupBox();
            this.recognitionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.saveImageAsButton = new System.Windows.Forms.Button();
            this.imageViewerForCapturedImageWithBarcodes = new Vintasoft.Imaging.UI.ImageViewer();
            this.stopBarcodeReadingButton = new System.Windows.Forms.Button();
            this.startBarcodeReadingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startImageCapturingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopImageCapturingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startBarcoderReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBarcodeReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRecognizedImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cameraPreviewGroupBox.SuspendLayout();
            this.barcodeReaderGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // camerasComboBox
            // 
            this.camerasComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.camerasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camerasComboBox.FormattingEnabled = true;
            this.camerasComboBox.Location = new System.Drawing.Point(6, 412);
            this.camerasComboBox.Name = "camerasComboBox";
            this.camerasComboBox.Size = new System.Drawing.Size(273, 21);
            this.camerasComboBox.TabIndex = 1;
            this.camerasComboBox.SelectedIndexChanged += new System.EventHandler(this.camerasComboBox_SelectedIndexChanged);
            // 
            // startImageCapturingButton
            // 
            this.startImageCapturingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startImageCapturingButton.Location = new System.Drawing.Point(5, 439);
            this.startImageCapturingButton.Name = "startImageCapturingButton";
            this.startImageCapturingButton.Size = new System.Drawing.Size(135, 33);
            this.startImageCapturingButton.TabIndex = 2;
            this.startImageCapturingButton.Text = "Start Image Capturing";
            this.startImageCapturingButton.UseVisualStyleBackColor = true;
            this.startImageCapturingButton.Click += new System.EventHandler(this.startImageCapturingButton_Click);
            // 
            // stopImageCapturingButton
            // 
            this.stopImageCapturingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopImageCapturingButton.Enabled = false;
            this.stopImageCapturingButton.Location = new System.Drawing.Point(145, 439);
            this.stopImageCapturingButton.Name = "stopImageCapturingButton";
            this.stopImageCapturingButton.Size = new System.Drawing.Size(135, 33);
            this.stopImageCapturingButton.TabIndex = 3;
            this.stopImageCapturingButton.Text = "Stop Image Capturing";
            this.stopImageCapturingButton.UseVisualStyleBackColor = true;
            this.stopImageCapturingButton.Click += new System.EventHandler(this.stopImageCapturingButton_Click);
            // 
            // configureCameraButton
            // 
            this.configureCameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.configureCameraButton.Location = new System.Drawing.Point(284, 439);
            this.configureCameraButton.Name = "configureCameraButton";
            this.configureCameraButton.Size = new System.Drawing.Size(135, 33);
            this.configureCameraButton.TabIndex = 4;
            this.configureCameraButton.Text = "Configure Camera";
            this.configureCameraButton.UseVisualStyleBackColor = true;
            this.configureCameraButton.Click += new System.EventHandler(this.configureCameraButton_Click);
            // 
            // scanBarcodeTypeComboBox
            // 
            this.scanBarcodeTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanBarcodeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scanBarcodeTypeComboBox.FormattingEnabled = true;
            this.scanBarcodeTypeComboBox.Location = new System.Drawing.Point(6, 412);
            this.scanBarcodeTypeComboBox.Name = "scanBarcodeTypeComboBox";
            this.scanBarcodeTypeComboBox.Size = new System.Drawing.Size(274, 21);
            this.scanBarcodeTypeComboBox.TabIndex = 6;
            this.scanBarcodeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.scanBarcodeTypeComboBox_SelectedIndexChanged);
            // 
            // readerResultsTextBox
            // 
            this.readerResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readerResultsTextBox.Location = new System.Drawing.Point(6, 478);
            this.readerResultsTextBox.Multiline = true;
            this.readerResultsTextBox.Name = "readerResultsTextBox";
            this.readerResultsTextBox.ReadOnly = true;
            this.readerResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.readerResultsTextBox.Size = new System.Drawing.Size(410, 155);
            this.readerResultsTextBox.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cameraPreviewGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.barcodeReaderGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(853, 639);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 8;
            // 
            // cameraPreviewGroupBox
            // 
            this.cameraPreviewGroupBox.Controls.Add(this.captureDeviceMonitorTextBox);
            this.cameraPreviewGroupBox.Controls.Add(this.supportedFormatsComboBox);
            this.cameraPreviewGroupBox.Controls.Add(this.imageViewerForCameraPreview);
            this.cameraPreviewGroupBox.Controls.Add(this.label2);
            this.cameraPreviewGroupBox.Controls.Add(this.camerasComboBox);
            this.cameraPreviewGroupBox.Controls.Add(this.configureCameraButton);
            this.cameraPreviewGroupBox.Controls.Add(this.stopImageCapturingButton);
            this.cameraPreviewGroupBox.Controls.Add(this.startImageCapturingButton);
            this.cameraPreviewGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraPreviewGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cameraPreviewGroupBox.Name = "cameraPreviewGroupBox";
            this.cameraPreviewGroupBox.Size = new System.Drawing.Size(425, 639);
            this.cameraPreviewGroupBox.TabIndex = 13;
            this.cameraPreviewGroupBox.TabStop = false;
            this.cameraPreviewGroupBox.Text = "Camera Preview";
            // 
            // captureDeviceMonitorTextBox
            // 
            this.captureDeviceMonitorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.captureDeviceMonitorTextBox.Location = new System.Drawing.Point(6, 478);
            this.captureDeviceMonitorTextBox.Multiline = true;
            this.captureDeviceMonitorTextBox.Name = "captureDeviceMonitorTextBox";
            this.captureDeviceMonitorTextBox.ReadOnly = true;
            this.captureDeviceMonitorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.captureDeviceMonitorTextBox.Size = new System.Drawing.Size(413, 155);
            this.captureDeviceMonitorTextBox.TabIndex = 13;
            // 
            // supportedFormatsComboBox
            // 
            this.supportedFormatsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.supportedFormatsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supportedFormatsComboBox.FormattingEnabled = true;
            this.supportedFormatsComboBox.Location = new System.Drawing.Point(285, 412);
            this.supportedFormatsComboBox.Name = "supportedFormatsComboBox";
            this.supportedFormatsComboBox.Size = new System.Drawing.Size(133, 21);
            this.supportedFormatsComboBox.TabIndex = 11;
            // 
            // imageViewerForCameraPreview
            // 
            this.imageViewerForCameraPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewerForCameraPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerForCameraPreview.Clipboard = winFormsSystemClipboard1;
            this.imageViewerForCameraPreview.ImageRenderingSettings = renderingSettings1;
            this.imageViewerForCameraPreview.ImageRotationAngle = 0;
            this.imageViewerForCameraPreview.Location = new System.Drawing.Point(6, 19);
            this.imageViewerForCameraPreview.Name = "imageViewerForCameraPreview";
            this.imageViewerForCameraPreview.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCameraPreview.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCameraPreview.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCameraPreview.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCameraPreview.Size = new System.Drawing.Size(410, 368);
            this.imageViewerForCameraPreview.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.imageViewerForCameraPreview.TabIndex = 0;
            this.imageViewerForCameraPreview.Text = "imageViewer1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Camera:";
            // 
            // barcodeReaderGroupBox
            // 
            this.barcodeReaderGroupBox.Controls.Add(this.recognitionTypeComboBox);
            this.barcodeReaderGroupBox.Controls.Add(this.saveImageAsButton);
            this.barcodeReaderGroupBox.Controls.Add(this.imageViewerForCapturedImageWithBarcodes);
            this.barcodeReaderGroupBox.Controls.Add(this.stopBarcodeReadingButton);
            this.barcodeReaderGroupBox.Controls.Add(this.scanBarcodeTypeComboBox);
            this.barcodeReaderGroupBox.Controls.Add(this.startBarcodeReadingButton);
            this.barcodeReaderGroupBox.Controls.Add(this.readerResultsTextBox);
            this.barcodeReaderGroupBox.Controls.Add(this.label1);
            this.barcodeReaderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeReaderGroupBox.Location = new System.Drawing.Point(0, 0);
            this.barcodeReaderGroupBox.Name = "barcodeReaderGroupBox";
            this.barcodeReaderGroupBox.Size = new System.Drawing.Size(424, 639);
            this.barcodeReaderGroupBox.TabIndex = 13;
            this.barcodeReaderGroupBox.TabStop = false;
            this.barcodeReaderGroupBox.Text = "Captured Image with Barcodes";
            // 
            // recognitionTypeComboBox
            // 
            this.recognitionTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.recognitionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recognitionTypeComboBox.FormattingEnabled = true;
            this.recognitionTypeComboBox.Items.AddRange(new object[] {
            "Automatic Recognition",
            "Threshold (Auto)",
            "Threshold (50)",
            "Threshold (100)",
            "Threshold (150)",
            "Threshold (200)",
            "Threshold (250)",
            "Threshold (300)",
            "Threshold (350)",
            "Threshold (400)",
            "Threshold (450)",
            "Threshold (500)",
            "Threshold (550)",
            "Threshold (600)",
            "Threshold (650)",
            "Threshold (700)",
            "Threshold (750)"});
            this.recognitionTypeComboBox.Location = new System.Drawing.Point(286, 412);
            this.recognitionTypeComboBox.Name = "recognitionTypeComboBox";
            this.recognitionTypeComboBox.Size = new System.Drawing.Size(130, 21);
            this.recognitionTypeComboBox.TabIndex = 14;
            this.recognitionTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.recognitionTypeComboBox_SelectedIndexChanged);
            // 
            // saveImageAsButton
            // 
            this.saveImageAsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveImageAsButton.Enabled = false;
            this.saveImageAsButton.Location = new System.Drawing.Point(285, 439);
            this.saveImageAsButton.Name = "saveImageAsButton";
            this.saveImageAsButton.Size = new System.Drawing.Size(132, 33);
            this.saveImageAsButton.TabIndex = 13;
            this.saveImageAsButton.Text = "Save Image As...";
            this.saveImageAsButton.UseVisualStyleBackColor = true;
            this.saveImageAsButton.Click += new System.EventHandler(this.saveImageAsButton_Click);
            // 
            // imageViewerForCapturedImageWithBarcodes
            // 
            this.imageViewerForCapturedImageWithBarcodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewerForCapturedImageWithBarcodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerForCapturedImageWithBarcodes.Clipboard = winFormsSystemClipboard1;
            this.imageViewerForCapturedImageWithBarcodes.ImageRenderingSettings = renderingSettings2;
            this.imageViewerForCapturedImageWithBarcodes.ImageRotationAngle = 0;
            this.imageViewerForCapturedImageWithBarcodes.Location = new System.Drawing.Point(6, 19);
            this.imageViewerForCapturedImageWithBarcodes.Name = "imageViewerForCapturedImageWithBarcodes";
            this.imageViewerForCapturedImageWithBarcodes.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCapturedImageWithBarcodes.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCapturedImageWithBarcodes.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCapturedImageWithBarcodes.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewerForCapturedImageWithBarcodes.Size = new System.Drawing.Size(410, 368);
            this.imageViewerForCapturedImageWithBarcodes.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.imageViewerForCapturedImageWithBarcodes.TabIndex = 5;
            this.imageViewerForCapturedImageWithBarcodes.Text = "imageViewer2";
            // 
            // stopBarcodeReadingButton
            // 
            this.stopBarcodeReadingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopBarcodeReadingButton.Enabled = false;
            this.stopBarcodeReadingButton.Location = new System.Drawing.Point(145, 439);
            this.stopBarcodeReadingButton.Name = "stopBarcodeReadingButton";
            this.stopBarcodeReadingButton.Size = new System.Drawing.Size(135, 33);
            this.stopBarcodeReadingButton.TabIndex = 12;
            this.stopBarcodeReadingButton.Text = "Stop Barcode Reading";
            this.stopBarcodeReadingButton.UseVisualStyleBackColor = true;
            this.stopBarcodeReadingButton.Click += new System.EventHandler(this.stopBarcodeReadingButton_Click);
            // 
            // startBarcodeReadingButton
            // 
            this.startBarcodeReadingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startBarcodeReadingButton.Enabled = false;
            this.startBarcodeReadingButton.Location = new System.Drawing.Point(5, 439);
            this.startBarcodeReadingButton.Name = "startBarcodeReadingButton";
            this.startBarcodeReadingButton.Size = new System.Drawing.Size(135, 33);
            this.startBarcodeReadingButton.TabIndex = 11;
            this.startBarcodeReadingButton.Text = "Start Barcode Reading";
            this.startBarcodeReadingButton.UseVisualStyleBackColor = true;
            this.startBarcodeReadingButton.Click += new System.EventHandler(this.startBarcodeReadingButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Barcode type:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.barcodeReaderToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(878, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startImageCapturingToolStripMenuItem,
            this.stopImageCapturingToolStripMenuItem,
            this.configureCameraToolStripMenuItem});
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.cameraToolStripMenuItem.Text = "Camera";
            // 
            // startImageCapturingToolStripMenuItem
            // 
            this.startImageCapturingToolStripMenuItem.Name = "startImageCapturingToolStripMenuItem";
            this.startImageCapturingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.startImageCapturingToolStripMenuItem.Text = "Start";
            this.startImageCapturingToolStripMenuItem.Click += new System.EventHandler(this.startImageCapturingButton_Click);
            // 
            // stopImageCapturingToolStripMenuItem
            // 
            this.stopImageCapturingToolStripMenuItem.Name = "stopImageCapturingToolStripMenuItem";
            this.stopImageCapturingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.stopImageCapturingToolStripMenuItem.Text = "Stop";
            this.stopImageCapturingToolStripMenuItem.Click += new System.EventHandler(this.stopImageCapturingButton_Click);
            // 
            // configureCameraToolStripMenuItem
            // 
            this.configureCameraToolStripMenuItem.Name = "configureCameraToolStripMenuItem";
            this.configureCameraToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.configureCameraToolStripMenuItem.Text = "Configure...";
            this.configureCameraToolStripMenuItem.Click += new System.EventHandler(this.configureCameraButton_Click);
            // 
            // barcodeReaderToolStripMenuItem
            // 
            this.barcodeReaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBarcoderReadingToolStripMenuItem,
            this.stopBarcodeReadingToolStripMenuItem});
            this.barcodeReaderToolStripMenuItem.Name = "barcodeReaderToolStripMenuItem";
            this.barcodeReaderToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.barcodeReaderToolStripMenuItem.Text = "Barcode Reader";
            // 
            // startBarcoderReadingToolStripMenuItem
            // 
            this.startBarcoderReadingToolStripMenuItem.Name = "startBarcoderReadingToolStripMenuItem";
            this.startBarcoderReadingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startBarcoderReadingToolStripMenuItem.Text = "Start";
            this.startBarcoderReadingToolStripMenuItem.Click += new System.EventHandler(this.startBarcodeReadingButton_Click);
            // 
            // stopBarcodeReadingToolStripMenuItem
            // 
            this.stopBarcodeReadingToolStripMenuItem.Name = "stopBarcodeReadingToolStripMenuItem";
            this.stopBarcodeReadingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopBarcodeReadingToolStripMenuItem.Text = "Stop";
            this.stopBarcodeReadingToolStripMenuItem.Click += new System.EventHandler(this.stopBarcodeReadingButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 678);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft WebCam Barcode Reader Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.cameraPreviewGroupBox.ResumeLayout(false);
            this.cameraPreviewGroupBox.PerformLayout();
            this.barcodeReaderGroupBox.ResumeLayout(false);
            this.barcodeReaderGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vintasoft.Imaging.UI.ImageViewer imageViewerForCameraPreview;
        private System.Windows.Forms.ComboBox camerasComboBox;
        private System.Windows.Forms.Button startImageCapturingButton;
        private System.Windows.Forms.Button stopImageCapturingButton;
        private System.Windows.Forms.Button configureCameraButton;
        private Vintasoft.Imaging.UI.ImageViewer imageViewerForCapturedImageWithBarcodes;
        private System.Windows.Forms.ComboBox scanBarcodeTypeComboBox;
        private System.Windows.Forms.TextBox readerResultsTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stopBarcodeReadingButton;
        private System.Windows.Forms.Button startBarcodeReadingButton;
        private System.Windows.Forms.GroupBox cameraPreviewGroupBox;
        private System.Windows.Forms.GroupBox barcodeReaderGroupBox;
        private System.Windows.Forms.ComboBox supportedFormatsComboBox;
        private System.Windows.Forms.TextBox captureDeviceMonitorTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startImageCapturingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopImageCapturingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startBarcoderReadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBarcodeReadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button saveImageAsButton;
        private System.Windows.Forms.SaveFileDialog saveRecognizedImageDialog;
        private System.Windows.Forms.ComboBox recognitionTypeComboBox;
    }
}