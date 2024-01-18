﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Barcode;
using Vintasoft.Barcode.BarcodeInfo;
using Vintasoft.Barcode.SymbologySubsets;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Drawing;
using Vintasoft.Imaging.Media;

using DemosCommonCode;
using DemosCommonCode.Imaging.Codecs;
using System.Threading;

namespace CameraBarcodeReaderDemo
{
    /// <summary>
    /// Main form of Camera Barcode Reader Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// The imaging camera barcode scanner.
        /// </summary>
        ImagingCameraBarcodeScanner _imagingCameraBarcodeScanner;

        /// <summary>
        /// ImageCaptureSource for video preview.
        /// </summary>
        ImageCaptureSource _previewImageCaptureSource;

        /// <summary>
        /// The source recognized image.
        /// </summary>
        VintasoftImage _recognizedSourceImage;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            this.Text = string.Format("VintaSoft Camera Barcode Reader Demo v{0}", ImagingGlobalSettings.ProductVersion);

            _previewImageCaptureSource = new ImageCaptureSource();
            _previewImageCaptureSource.CaptureCompleted +=
                new EventHandler<ImageCaptureCompletedEventArgs>(PreviewImageCaptureSource_CaptureCompleted);

            _imagingCameraBarcodeScanner = new ImagingCameraBarcodeScanner();
            _imagingCameraBarcodeScanner.CaptureDevicesChanged += ImagingCameraBarcodeScanner_CaptureDevicesChanged;
            _imagingCameraBarcodeScanner.ScanningStart += ImagingCameraBarcodeScanner_ScanningStart;
            _imagingCameraBarcodeScanner.ScanningStop += ImagingCameraBarcodeScanner_ScanningStop;
            _imagingCameraBarcodeScanner.ScanningException += ImagingCameraBarcodeScanner_ScanningException;
            _imagingCameraBarcodeScanner.BarcodeScanner.FrameScanFinished += BarcodeScanner_FrameScanFinished;


            CodecsFileFilters.SetSaveFileDialogFilter(saveRecognizedImageDialog, false, false);

            if (!DesignMode)
            {
                InitCamerasComboBox();
                InitBarcodeScannerUI();

                UpdateUI();
            }

            recognitionTypeComboBox.Items.Add(CameraBarcodeScannerMode.Adaptive);
            recognitionTypeComboBox.Items.Add(CameraBarcodeScannerMode.Balanced);
            recognitionTypeComboBox.Items.Add(CameraBarcodeScannerMode.BestQuality);
            recognitionTypeComboBox.SelectedIndex = 0;            
        }

      
        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the preview image.
        /// </summary>
        public VintasoftImage PreviewImage
        {
            get
            {
                return imageViewerForCameraPreview.Image;
            }
            set
            {
                VintasoftImage oldImage = imageViewerForCameraPreview.Image;
                imageViewerForCameraPreview.Image = value;
                if (oldImage != null)
                    oldImage.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the image with recognized barcodes.
        /// </summary>
        public VintasoftImage RecognizedImage
        {
            get
            {
                return imageViewerForCapturedImageWithBarcodes.Image;
            }
            set
            {
                VintasoftImage oldImage = imageViewerForCapturedImageWithBarcodes.Image;
                imageViewerForCapturedImageWithBarcodes.Image = value;
                if (oldImage != null)
                    oldImage.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the capture device.
        /// </summary>
        public ImageCaptureDevice CaptureDevice
        {
            get
            {
                return _imagingCameraBarcodeScanner.CaptureDevice;
            }
            set
            {
                _imagingCameraBarcodeScanner.CaptureDevice = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        #region Main Form

        /// <summary>
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _imagingCameraBarcodeScanner.StopScanning();
            StopCapturing();
            if (_recognizedSourceImage != null)
                _recognizedSourceImage.Dispose();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the Click event of ExitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of AboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Camera panel

        /// <summary>
        /// Handles the SelectedIndexChanged event of CamerasComboBox object.
        /// </summary>
        private void camerasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_previewImageCaptureSource.State == ImageCaptureState.Stopped)
                PreviewImage = null;
            UpdateSupportedImageCaptureFormats();
        }

        /// <summary>
        /// Handles the Click event of StartImageCapturingButton object.
        /// </summary>
        private void startImageCapturingButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartCapturing();

                UpdateUI();
            }
            catch (Exception ex)
            {
                StopCapturing();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of StopImageCapturingButton object.
        /// </summary>
        private void stopImageCapturingButton_Click(object sender, EventArgs e)
        {
            _imagingCameraBarcodeScanner.StopScanning();
            StopCapturing();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ConfigureCameraButton object.
        /// </summary>
        private void configureCameraButton_Click(object sender, EventArgs e)
        {
            try
            {
                _imagingCameraBarcodeScanner.CaptureDevice = (ImageCaptureDevice)camerasComboBox.SelectedItem;
                _imagingCameraBarcodeScanner.CaptureDevice.ShowPropertiesDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Barcode Reader panel

        /// <summary>
        /// Handles the SelectedIndexChanged event of RecognitionTypeComboBox object.
        /// </summary>
        private void recognitionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _imagingCameraBarcodeScanner.BarcodeScanner.RecognitionMode = (CameraBarcodeScannerMode)recognitionTypeComboBox.SelectedItem;

            if (_imagingCameraBarcodeScanner.BarcodeScanner.RecognitionMode == CameraBarcodeScannerMode.BestQuality)
            {
                _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.AdaptiveBinarizationType = AdaptiveBinarizationType.HighQuality;                    
            }
            else
            {
                _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.AdaptiveBinarizationType = AdaptiveBinarizationType.Fast;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ScanBarcodeTypeComboBox object.
        /// </summary>
        private void scanBarcodeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scanBarcodeTypeComboBox.SelectedItem == null)
                return;

            _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.ScanBarcodeTypes = BarcodeType.None;

            if (scanBarcodeTypeComboBox.SelectedItem is BarcodeSymbologySubset)
            {
                _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.ScanBarcodeSubsets.Clear();
                _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.ScanBarcodeSubsets.Add((BarcodeSymbologySubset)scanBarcodeTypeComboBox.SelectedItem);
            }
            else
            {
                _imagingCameraBarcodeScanner.BarcodeScanner.ScannerSettings.ScanBarcodeTypes = (BarcodeType)scanBarcodeTypeComboBox.SelectedItem;
            }
        }

        /// <summary>
        /// Handles the Click event of StartBarcodeReadingButton object.
        /// </summary>
        private void startBarcodeReadingButton_Click(object sender, EventArgs e)
        {
            _imagingCameraBarcodeScanner.StartScanning();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of StopBarcodeReadingButton object.
        /// </summary>
        private void stopBarcodeReadingButton_Click(object sender, EventArgs e)
        {
            _imagingCameraBarcodeScanner.StopScanning();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of SaveImageAsButton object.
        /// </summary>
        private void saveImageAsButton_Click(object sender, EventArgs e)
        {
            if (saveRecognizedImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    _recognizedSourceImage.Save(saveRecognizedImageDialog.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates UI.
        /// </summary>
        private void UpdateUI()
        {
            bool isCapturingStarted = _previewImageCaptureSource.State != ImageCaptureState.Stopped;
            startImageCapturingButton.Enabled = CaptureDevice != null && !isCapturingStarted;
            startImageCapturingToolStripMenuItem.Enabled = CaptureDevice != null && !isCapturingStarted;
            stopImageCapturingButton.Enabled = CaptureDevice != null && isCapturingStarted;
            stopImageCapturingToolStripMenuItem.Enabled = CaptureDevice != null && isCapturingStarted;
            configureCameraButton.Enabled = CaptureDevice != null;
            configureCameraToolStripMenuItem.Enabled = CaptureDevice != null;

            bool isBarcodeReadingStarted = _imagingCameraBarcodeScanner.IsStarted;
            startBarcodeReadingButton.Enabled = isCapturingStarted && !isBarcodeReadingStarted;
            if (!isBarcodeReadingStarted)
                startBarcodeReadingButton.Text = "Start Barcode Reading";
            startBarcoderReadingToolStripMenuItem.Enabled = isCapturingStarted && !isBarcodeReadingStarted;
            stopBarcodeReadingButton.Enabled = isCapturingStarted && isBarcodeReadingStarted;
            stopBarcodeReadingToolStripMenuItem.Enabled = isCapturingStarted && isBarcodeReadingStarted;

            camerasComboBox.Enabled = !isCapturingStarted;
            supportedFormatsComboBox.Enabled = CaptureDevice != null && !isCapturingStarted;
        }

        #endregion


        #region Init

        /// <summary>
        /// Inits the combo box with camera names.
        /// </summary>
        private void InitCamerasComboBox()
        {
            camerasComboBox.Items.Clear();

            ReadOnlyCollection<ImageCaptureDevice> captureDevices = ImageCaptureDeviceConfiguration.GetCaptureDevices();

            foreach (ImageCaptureDevice device in captureDevices)
            {
                camerasComboBox.Items.Add(device);
            }

            if (captureDevices.Contains(CaptureDevice))
            {
                camerasComboBox.SelectedItem = CaptureDevice;
            }
            else
            {
                CaptureDevice = null;

                if (camerasComboBox.Items.Count > 0)
                {
                    CaptureDevice = captureDevices[0];
                    camerasComboBox.SelectedItem = CaptureDevice;
                }
            }

            UpdateSupportedImageCaptureFormats();
        }

        /// <summary>
        /// Inits the barcode reader.
        /// </summary>
        private void InitBarcodeScannerUI()
        {
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Aztec | BarcodeType.DataMatrix | BarcodeType.QR | BarcodeType.PDF417 | BarcodeType.Code39 | BarcodeType.Code128 | BarcodeType.EAN13 | BarcodeType.UPCA | BarcodeType.UPCE);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Aztec | BarcodeType.DataMatrix | BarcodeType.QR | BarcodeType.PDF417);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code39 | BarcodeType.Code128 | BarcodeType.EAN13 | BarcodeType.UPCA | BarcodeType.UPCE);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Aztec);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.DataMatrix);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.DotCode);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.QR);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.MicroQR);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.HanXinCode);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.PDF417 | BarcodeType.PDF417Compact);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.MicroPDF417);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.MaxiCode);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code16K);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.IATA2of5);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Matrix2of5);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code11);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Codabar);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code128);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code39);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Code93);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Interleaved2of5);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Standard2of5);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.MSI);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Pharmacode);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.RSS14);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.RSSExpanded);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.RSSLimited);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Telepen);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.AustralianPost);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.IntelligentMail);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.RoyalMail);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Planet);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Postnet);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Mailmark4StateC);
            scanBarcodeTypeComboBox.Items.Add(BarcodeType.Mailmark4StateL);


            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.Code32);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.Code39Extended);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.EANVelocity);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarLimited);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.NumlyNumber);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1QR);
            scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedQRCode);

            if (!BarcodeGlobalSettings.IsDemoVersion)
            {
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.OPC);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VIN);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.SSCC18);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.SwissPostParcel);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VicsBol);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VicsScacPro);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ITF14);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.FedExGround96);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DhlAwb);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DeutschePostIdentcode);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DeutschePostLeitcode);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType7);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType9);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType29);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1Aztec);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataMatrix);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1_128);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBar);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarStacked);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarExpanded);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarExpandedStacked);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarLimited);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.PPN);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.PZN);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedAztec);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedDataMatrix);
                scanBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedPDF417);
            }

            // sort supported barcode list
            object[] barcodes = new object[scanBarcodeTypeComboBox.Items.Count];
            scanBarcodeTypeComboBox.Items.CopyTo(barcodes, 0);
            string[] names = new string[barcodes.Length];
            for (int i = 0; i < barcodes.Length; i++)
                names[i] = barcodes[i].ToString();
            Array.Sort(names, barcodes);
            scanBarcodeTypeComboBox.Items.Clear();
            scanBarcodeTypeComboBox.Items.AddRange(barcodes);

            scanBarcodeTypeComboBox.SelectedItem = BarcodeType.Aztec | BarcodeType.DataMatrix | BarcodeType.QR | BarcodeType.PDF417 | BarcodeType.Code39 | BarcodeType.Code128 | BarcodeType.EAN13 | BarcodeType.UPCA | BarcodeType.UPCE;
        }

        #endregion


        #region Camera

        /// <summary>
        /// Updates the supported image capture formats.
        /// </summary>
        private void UpdateSupportedImageCaptureFormats()
        {
            supportedFormatsComboBox.Items.Clear();
            ImageCaptureDevice device = (ImageCaptureDevice)camerasComboBox.SelectedItem;
            ReadOnlyCollection<ImageCaptureFormat> formats = _imagingCameraBarcodeScanner.CaptureFormats;
            if (device != null && formats != null)
            {
                foreach (ImageCaptureFormat format in formats)
                    supportedFormatsComboBox.Items.Add(format);

                if (device.DesiredFormat != null)
                    supportedFormatsComboBox.SelectedItem = device.DesiredFormat;
                else
                    supportedFormatsComboBox.SelectedItem = null;
            }
        }

        /// <summary>
        /// Shows captured preview image and initializes new image capture request.
        /// </summary>
        private void PreviewImageCaptureSource_CaptureCompleted(object sender, ImageCaptureCompletedEventArgs e)
        {
            VintasoftImage image = e.GetCapturedImage();

            PreviewImage = image;

            if (_previewImageCaptureSource.State == ImageCaptureState.Started)
                _previewImageCaptureSource.CaptureAsync();
        }

        /// <summary>
        /// Starts image capturing from camera.
        /// </summary>
        private void StartCapturing()
        {
            CaptureDevice = (ImageCaptureDevice)camerasComboBox.SelectedItem;
            CaptureDevice.DesiredFormat = (ImageCaptureFormat)supportedFormatsComboBox.SelectedItem;
            _previewImageCaptureSource.CaptureDevice = CaptureDevice;
            _previewImageCaptureSource.Start();
            _previewImageCaptureSource.CaptureAsync();

            captureDeviceMonitorTextBox.AppendText(string.Format("Image capturing started ({0}).", CaptureDevice.FriendlyName));
            captureDeviceMonitorTextBox.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Stops image capturing from camera.
        /// </summary>
        private void StopCapturing()
        {
            if (_previewImageCaptureSource.State != ImageCaptureState.Stopped)
            {
                _previewImageCaptureSource.Stop();

                captureDeviceMonitorTextBox.AppendText(string.Format("Image capturing stopped ({0}).", CaptureDevice.FriendlyName));
                captureDeviceMonitorTextBox.AppendText(Environment.NewLine);
            }
        }

        #endregion


        #region Barcode scanner

        private void ImagingCameraBarcodeScanner_ScanningException(object sender, ExceptionEventArgs e)
        {
            ShowErrorMessageAsync(e.Exception.ToString());
        }

        private void ImagingCameraBarcodeScanner_ScanningStart(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(OnBarcodeRecognitionStarted));
            }
            else
            {
                OnBarcodeRecognitionStarted();
            }
        }
        private void OnBarcodeRecognitionStarted()
        {
            readerResultsTextBox.AppendText("Barcode recognition started.");
            readerResultsTextBox.AppendText(Environment.NewLine);
        }

        private void ImagingCameraBarcodeScanner_ScanningStop(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(OnBarcodeRecognitionStopped));
            }
            else
            {
                OnBarcodeRecognitionStopped();
            }
        }

        private void OnBarcodeRecognitionStopped()
        {
            readerResultsTextBox.AppendText("Barcode recognition stopped.");
            readerResultsTextBox.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Handles the CaptureDevicesChanged event of ImagingCameraBarcodeScanner object.
        /// </summary>
        private void ImagingCameraBarcodeScanner_CaptureDevicesChanged(object sender, ImageCaptureDevicesChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CaptureDevicesMonitor_CaptureDevicesChangedDelegate(ImagingCameraBarcodeScanner_CaptureDevicesChanged), sender, e);
            }
            else
            {
                List<ImageCaptureDevice> removedCameras = new List<ImageCaptureDevice>(e.RemovedDevices);

                if (removedCameras.Contains(CaptureDevice))
                {
                    StopCapturing();
                }

                // add messages about changes
                foreach (ImageCaptureDevice removedDevice in e.RemovedDevices)
                    captureDeviceMonitorTextBox.AppendText(string.Format("Device '{0}' is disconnected.{1}", removedDevice.FriendlyName, Environment.NewLine));
                foreach (ImageCaptureDevice addedDevice in e.AddedDevices)
                    captureDeviceMonitorTextBox.AppendText(string.Format("Device '{0}' is connected.{1}", addedDevice.FriendlyName, Environment.NewLine));

                InitCamerasComboBox();

                UpdateUI();
            }
        }

        private void BarcodeScanner_FrameScanFinished(object sender, FrameScanFinishedEventArgs e)
        {
            // if barcode recognized then
            if (e.FoundBarcodes.Length > 0)
            {
                VintasoftImage image = new VintasoftImage((VintasoftBitmap)e.Frame.Clone(), true);

                // show reader results
                Invoke(new ShowRecognitionResultsDelegate(ShowRecognitionResults), new object[] { e.FoundBarcodes, image });

                // show captured image in image viewer
                RecognizedImage = image;
            }
        }

        /// <summary>
        /// Returns information about recognized barcodes.
        /// </summary>
        /// <param name="barcodes">Recognized barcodes.</param>
        /// <returns>Information about recognized barcodes.</returns>
        private string GetBarcodesInfo(IBarcodeInfo[] barcodes)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < barcodes.Length; i++)
                result.AppendLine(GetBarcodeInfo(i, barcodes[i]));

            return result.ToString();
        }

        /// <summary>
        /// Returns barcode information as a text.
        /// </summary>
        private string GetBarcodeInfo(int index, IBarcodeInfo info)
        {
            info.ShowNonDataFlagsInValue = true;

            string value = info.Value;
            if (info.BarcodeType == BarcodeType.UPCE)
                value += string.Format(" ({0})", (info as UPCEANInfo).UPCEValue);

            string confidence;
            if (info.Confidence == ReaderSettings.ConfidenceNotAvailable)
                confidence = "N/A";
            else
                confidence = Math.Round(info.Confidence).ToString() + "%";

            if (info is BarcodeSubsetInfo)
            {
                value = string.Format("{0}{1}Base value: {2}",
                    RemoveSpecialCharacters(value), Environment.NewLine,
                    RemoveSpecialCharacters(((BarcodeSubsetInfo)info).BaseBarcodeInfo.Value));
            }
            else
            {
                value = RemoveSpecialCharacters(value);
            }

            string barcodeTypeValue;
            if (info is BarcodeSubsetInfo)
                barcodeTypeValue = ((BarcodeSubsetInfo)info).BarcodeSubset.ToString();
            else
                barcodeTypeValue = info.BarcodeType.ToString();


            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("[{0}:{1}]", index + 1, barcodeTypeValue));
            result.AppendLine(string.Format("Value: {0}", value));
            result.AppendLine(string.Format("Confidence: {0}", confidence));
            result.AppendLine(string.Format("Reading quality: {0}", info.ReadingQuality));
            result.AppendLine(string.Format("Threshold: {0}", info.Threshold));
            result.AppendLine(string.Format("Region: {0}", info.Region));
            return result.ToString();
        }

        /// <summary>
        /// Removes special characters from string.
        /// </summary>
        private string RemoveSpecialCharacters(string text)
        {
            StringBuilder sb = new StringBuilder();
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >= ' ' || text[i] == '\n' || text[i] == '\r' || text[i] == '\t')
                        sb.Append(text[i]);
                    else
                        sb.Append('?');
                }
            }
            return sb.ToString();
        }

        #endregion


        #region Show barcode recognition results

        /// <summary>
        /// Shows barcode recognition results.
        /// </summary>
        private void ShowRecognitionResults(IBarcodeInfo[] barcodeInfo, VintasoftImage image)
        {
            // show barcode recognition in text box
            readerResultsTextBox.Text = GetBarcodesInfo(barcodeInfo);

            // set source recognized image
            if (_recognizedSourceImage != null)
                _recognizedSourceImage.Dispose();
            _recognizedSourceImage = (VintasoftImage)image.Clone();

            // draw rectangles of searched barcodes on captured image
            DrawBarcodeRectangles(barcodeInfo, image);

            // enable save image button
            saveImageAsButton.Enabled = true;
        }

        /// <summary>
        /// Draws rectangles of searched barcodes on captured image.
        /// </summary>
        private void DrawBarcodeRectangles(IBarcodeInfo[] barcodes, VintasoftImage image)
        {
            Color fillColor = Color.FromArgb(64, Color.Green);
            Color stokeColor = Color.Green;

            // open Graphics
            using (DrawingEngine graphics = image.CreateDrawingEngine())
            {
                // for each recognized barcode
                foreach (IBarcodeInfo barcode in barcodes)
                {
                    // draw barcode rectangle
                    float x = barcode.Region.LeftTop.X;
                    float y = barcode.Region.LeftTop.Y;
                    PointF leftTop = new PointF(x, y);
                    PointF rightTop = new PointF(barcode.Region.RightTop.X, barcode.Region.RightTop.Y);
                    PointF rightBottom = new PointF(barcode.Region.RightBottom.X, barcode.Region.RightBottom.Y);
                    PointF leftBottom = new PointF(barcode.Region.LeftBottom.X, barcode.Region.LeftBottom.Y);
                    using (IDrawingPen pen = graphics.DrawingFactory.CreatePen(Color.FromArgb(128, Color.Blue), 1))
                        graphics.DrawPolygon(pen, new PointF[] { leftTop, rightTop, rightBottom, leftBottom });

                    // draw bounding rectangle                
                    Rectangle boundRect = GdiConverter.Convert(barcode.Region.Rectangle);
                    PointF[] boundRectPoints = new PointF[] {
                        new PointF(boundRect.X, boundRect.Y),
                        new PointF(boundRect.X + boundRect.Width, boundRect.Y),
                        new PointF(boundRect.X + boundRect.Width, boundRect.Y + boundRect.Height),
                        new PointF(boundRect.X, boundRect.Y + boundRect.Height)
                    };
                    using (IDrawingBrush fillBrush = graphics.DrawingFactory.CreateSolidBrush(fillColor))
                        graphics.FillPolygon(fillBrush, boundRectPoints);
                    using (IDrawingPen skrokePen = graphics.DrawingFactory.CreatePen(stokeColor, 2))
                        graphics.DrawPolygon(skrokePen, boundRectPoints);
                }
            }
        }

        #endregion


        #region Utils

        private void ShowErrorMessageAsync(string message)
        {
            this.Invoke(new ShowErrorMessageDelegate(ShowErrorMessage), message);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        #endregion

        #endregion



        #region Delegates

        delegate void SetButtonTextDelegate(Button button, string text);

        delegate void ShowRecognitionResultsDelegate(IBarcodeInfo[] barcodeInfo, VintasoftImage image);

        delegate void ShowErrorMessageDelegate(string message);

        delegate void CaptureDevicesMonitor_CaptureDevicesChangedDelegate(object sender, ImageCaptureDevicesChangedEventArgs e);

        #endregion

    }
}
