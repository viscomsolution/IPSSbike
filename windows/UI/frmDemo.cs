using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Drawing2D;
using System.Net;
using System.Resources;
using TGMT;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.VisualBasic.FileIO;

namespace IPSS
{
    public partial class frmDemo : Form
    {
        #region global_variable
        VideoCaptureDevice m_videoSource;

        Point[] m_points;
        int OFFSET;
        float g_scaleX = 1;
        float g_scaleY = 1;
        bool m_isDrag;

        IPSSbike bikeDetector;

        enum Colision
        {
            TopLeft,
            TopRight,
            BotLeft,
            BotRight,
            None,
        }
        Colision g_colisionState = Colision.None;
        bool g_isMouseDown = false;
        Bitmap g_bmp;

        int selectPointIdx = -1;


        bool m_isFirstLoading = true;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region common_function

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SetScaleRatio()
        {
            g_scaleX = (float)g_bmp.Width / picCamera.Width;
            g_scaleY = (float)g_bmp.Height / picCamera.Height;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintPoint()
        {
            string output = "";
            for (int i = 0; i < m_points.Length; i++)
            {
                output += "(" + m_points[i].X + " ; " + m_points[i].Y + ") ";
            }
            PrintMessage(output);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Point[] GetScaledPoint()
        {
            Point[] scaledPoints = new Point[4];
            scaledPoints[0] = new Point((int)(m_points[0].X * g_scaleX), (int)(m_points[0].Y * g_scaleY));
            scaledPoints[1] = new Point((int)(m_points[1].X * g_scaleX), (int)(m_points[1].Y * g_scaleY));
            scaledPoints[2] = new Point((int)(m_points[2].X * g_scaleX), (int)(m_points[2].Y * g_scaleY));
            scaledPoints[3] = new Point((int)(m_points[3].X * g_scaleX), (int)(m_points[3].Y * g_scaleY));
            return scaledPoints;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopLoading()
        {
            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;
            progressBar1.Visible = false;
            lblMessage.Text = "";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                PrintError("Can not find camera");
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitDetector()
        {
            lblMessage.Text = "Loading data, please wait...";
            btnDetect.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ReadPlate()
        {
            if (!rdCamera.Checked && !rdImage.Checked && !rdFolder.Checked)
            {
                PrintError("Source image not selected");
                return;
            }

            if (bikeDetector == null)
            {
                MessageBox.Show("Please contact to author to fix problem");
                return;
            }

            bikeDetector.OutputFoler = txtFolderOutput.Text;

            if (rdCamera.Checked) //camera
            {
                if (rdNetworkCamera.Checked)
                {
                    if (streamPlayer.IsPlaying)
                        g_bmp = streamPlayer.GetCurrentFrame();
                }
                if (g_bmp == null)
                {
                    PrintError("Image is null");
                    return;
                }

                Bitmap bmp = (Bitmap)g_bmp.Clone();
                if (bmp == null)
                    return;


                BikePlate result = bikeDetector.ReadPlate(bmp);
                if (result.bitmap != null)
                    picResult.Image = result.bitmap;

                txtResult.Text = result.text;
                PrintMessage(result.error + " (" + result.elapsedMilisecond.ToString() + " ms)");
            }
            else if (rdImage.Checked) //static image
            {
                if (g_bmp == null)
                {
                    PrintError("Image is null");
                    return;
                }
                BikePlate result = bikeDetector.ReadPlate((Bitmap)g_bmp.Clone());
                txtResult.Text = result.text;

                if (result.bitmap != null)
                    picResult.Image = result.bitmap;
                PrintMessage(result.error + " (" + result.elapsedMilisecond + " ms)");
            }
            else if (rdFolder.Checked) //folder
            {
                if (btnDetect.Text == "Start detect (F5)")
                {
                    if (txtFolderOutput.Text == "")
                    {
                        errorProvider1.SetError(txtFolderOutput, "Folder output is empty");
                        return;
                    }

                    if (txtFolderInput.Text == txtFolderOutput.Text && txtFolderOutput.Text != "")
                    {
                        errorProvider1.SetError(txtFolderOutput, "Folder output must different folder input");
                        return;
                    }
                    if (lstImage.Items.Count == 0)
                    {
                        PrintError("No input image");
                        return;
                    }

                    g_scaleX = 1;
                    g_scaleY = 1;
                    progressBar1.Visible = true;
                    timerProgressbar.Start();
                    bgWorker1.RunWorkerAsync();

                    btnDetect.Text = "Stop detect (F5)";
                }
                else
                {
                    bgWorker1.CancelAsync();
                    btnDetect.Text = "Start detect (F5)";
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopAllCamera()
        {
            if (streamPlayer != null && streamPlayer.IsPlaying)
                streamPlayer.Stop();

            if (m_videoSource != null)
                m_videoSource.Stop();

            picCamera.Image = null;
            btnSnapshot.Visible = false;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region form

        public frmDemo()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_Shown(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("IPSS");
            bikeDetector = new IPSSbike();
            if (bikeDetector == null)
            {
                return;
            }

            CheckForIllegalCrossThreadCalls = false;
            this.KeyPreview = true;

            txtIpAddress.Text = TGMTregistry.GetInstance().ReadRegValueString("cameraAddress");

            chkEnableLog.Checked = TGMTregistry.GetInstance().ReadRegValueBool("EnableLog");            
            bikeDetector.EnableLog = chkEnableLog.Checked;
            chkCrop.Checked = TGMTregistry.GetInstance().ReadRegValueBool("CropResultImage");
            chkSaveInputImage.Checked = TGMTregistry.GetInstance().ReadRegValueBool("SaveInputImage");
            chk_enableDeepScan.Checked = bikeDetector.EnableDeepScan;

            txtFolderOutput.Text = TGMTregistry.GetInstance().ReadRegValueString("folderOutput");
            txtFailedDir.Text = TGMTregistry.GetInstance().ReadRegValueString("txtFailedDir");
            txtValidDir.Text = TGMTregistry.GetInstance().ReadRegValueString("txtValidDir");
            txtInvalidDir.Text = TGMTregistry.GetInstance().ReadRegValueString("txtInvalidDir");

            this.Text += " " + bikeDetector.Version;
            this.Text += bikeDetector.IsLicense ? " (Licensed)" : " (Vui lòng liên hệ: 0939.825.125)";            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control)
                return;
            if ((int)e.KeyCode >= 97 && (int)e.KeyCode <= 101)
            {
                selectPointIdx = (int)e.KeyCode - 97;
                picCamera.Refresh();
            }
            else if ((int)e.KeyCode >= 49 && (int)e.KeyCode <= 52)
            {
                selectPointIdx = (int)e.KeyCode - 49;
                picCamera.Refresh();
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        m_points[selectPointIdx].Y -= 10;
                        break;
                    case Keys.Down:
                        m_points[selectPointIdx].Y += 10;
                        break;
                    case Keys.Left:
                        m_points[selectPointIdx].X -= 10;
                        break;
                    case Keys.Right:
                        m_points[selectPointIdx].X += 10;
                        break;
                }

                PrintPoint();
                picCamera.Refresh();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ReadPlate();
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerAutoDetect_Tick(object sender, EventArgs e)
        {
            ReadPlate();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            picCamera.Refresh();
        }

        #endregion //form

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region select_source

        private void rdCamera_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = txtFilePath.Text = "";


            if (rdCamera.Checked)
            {
                InitCamera();

                grCamera.Visible = true;
                grImage.Visible = false;
                grFolder.Visible = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdImage.Checked)
            {
                StopAllCamera();
                grCamera.Visible = false;
                grImage.Visible = true;
                grFolder.Visible = false;

                txtFilePath.Text = TGMTregistry.GetInstance().ReadRegValueString("txtFilePath");
            }
            else
            {
                if (picCamera.Image != null)
                {
                    picCamera.Image.Dispose();
                    picCamera.Image = null;
                }

                if (picResult.Image != null)
                {
                    picResult.Image.Dispose();
                    picResult.Image = null;
                }

                if (g_bmp != null)
                {
                    g_bmp.Dispose();
                    g_bmp = null;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdFolder_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = "";
            if (picCamera.Image != null)
                picCamera.Image.Dispose();
            if (picResult.Image != null)
                picResult.Image = null;

            if (rdFolder.Checked)
            {
                if (m_isFirstLoading)
                {
                    txtFolderInput.Text = TGMTregistry.GetInstance().ReadRegValueString("folderInput");

                    m_isFirstLoading = false;
                }


                StopAllCamera();
                grFolder.Visible = true;
                grCamera.Visible = false;
                grImage.Visible = false;

                g_scaleX = 1;
                g_scaleY = 1;

                picCamera.Visible = false;
                lstImage.Visible = true;
            }
            else
            {
                picCamera.Visible = true;
                lstImage.Visible = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            ReadPlate();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_EnabledChanged(object sender, EventArgs e)
        {
            if (btnDetect.Enabled)
            {
                StopLoading();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                rdImage.Checked = true;
                txtFilePath.Text = files[0];
            }
            else
            {
                m_isDrag = true;
                rdFolder.Checked = true;
                lstImage.Items.Clear();
                foreach (string file in files)
                {
                    lstImage.Items.Add(Path.GetFileName(file));
                }
                txtFolderInput.Text = Path.GetDirectoryName(files[0]);
            }
            ReadPlate();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        #endregion //select_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_image_source

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txtFilePath.Text))
                return;

            TGMTregistry.GetInstance().SaveRegValue("txtFilePath", txtFilePath.Text);

            if (g_bmp != null)
                g_bmp.Dispose();
            try
            {
                g_bmp = new Bitmap(txtFilePath.Text);
                picCamera.Image = g_bmp;

                SetScaleRatio();

                ReadPlate();
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txtFilePath.Text = ofd.FileName;
            }

        }

        #endregion //group_image_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_camera_source

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveRegValue("cameraAddress", txtIpAddress.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp != null)
                g_bmp.Dispose();

            g_scaleX = (float)eventArgs.Frame.Width / picCamera.Width;
            g_scaleY = (float)eventArgs.Frame.Height / picCamera.Height;

            g_bmp = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = g_bmp;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdLocalCamera_CheckedChanged(object sender, EventArgs e)
        {
            PrintMessage("");
            picCamera.Image = null;
            btnSnapshot.Visible = false;
            cbCamera.Enabled = rdLocalCamera.Checked;

            if (rdLocalCamera.Checked)
            {
                if (streamPlayer != null && streamPlayer.IsPlaying)
                    streamPlayer.Stop();

                timerStream.Stop();
                ConnectLocalCamera();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdNetworkCamera_CheckedChanged(object sender, EventArgs e)
        {
            txtIpAddress.Enabled = btnConnectCameraIP.Enabled = rdNetworkCamera.Checked;

            if (rdNetworkCamera.Checked)
            {
                if (m_videoSource != null)
                    m_videoSource.Stop();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnConnectCameraIP_Click(object sender, EventArgs e)
        {
            if (btnConnectCameraIP.Text == "Start")
            {
                string text = txtIpAddress.Text;
                if (text == "")
                {
                    PrintError("URL is null");
                    return;
                }

                string url;
                string username;
                string password;

                if (text.Length - text.Replace(";", "").Length == 2)
                {
                    string[] split = txtIpAddress.Text.Split(';');
                    url = split[0];
                    username = split[1];
                    password = split[2];
                    //if(username != "")
                    //    stream.Password = username;
                    //if(password != "")
                    //    stream.Login = password;
                }
                else
                {
                    url = text;
                }

                var uri = new Uri(url);
                streamPlayer.StartPlay(uri, TimeSpan.FromSeconds(1.0));
                PrintMessage("Connecting...");
            }
            else
            {
                streamPlayer.Stop();
                btnSnapshot.Visible = false;
                picCamera.Image = null;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera()
        {
            if (cbCamera.Items.Count == 0 || cbCamera.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbCamera.SelectedIndex].MonikerString);
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();
            btnSnapshot.Visible = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HandleStreamFailedEvent(object sender, WebEye.StreamFailedEventArgs e)
        {
            PrintError("Can not connect to camera IP");
        }

        private void streamPlayer_StreamStarted(object sender, EventArgs e)
        {
            timerStream.Start();
            btnConnectCameraIP.Text = "Stop";
            btnSnapshot.Visible = true;
            PrintMessage("Playing");
        }

        private void streamPlayer_StreamStopped(object sender, EventArgs e)
        {
            timerStream.Stop();
            btnConnectCameraIP.Text = "Start";
            btnSnapshot.Visible = false;
            PrintMessage("Stopped");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerStream_Tick(object sender, EventArgs e)
        {
            g_bmp = streamPlayer.GetCurrentFrame();
            g_scaleX = (float)g_bmp.Width / picCamera.Width;
            g_scaleY = (float)g_bmp.Height / picCamera.Height;

            picCamera.Image = g_bmp;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            if (g_bmp == null && !streamPlayer.IsPlaying)
            {
                return;
            }


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Image|*.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (rdLocalCamera.Checked)
                {
                    g_bmp.Save(saveFileDialog1.FileName);
                }
                else if (rdNetworkCamera.Checked)
                {
                    Bitmap bmp = streamPlayer.GetCurrentFrame();
                    if (bmp != null)
                        bmp.Save(saveFileDialog1.FileName);
                }

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkAutodetect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutodetect.Checked)
                timerAutoDetect.Start();
            else
                timerAutoDetect.Stop();
        }

        #endregion //group_camera_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_folder_source

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                txtFolderInput.Text = fbd.SelectedPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                string dirPath = fbd.SelectedPath;
                txtFolderOutput.Text = dirPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderInput_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderInput.Text))
                return;

            TGMTregistry.GetInstance().SaveRegValue("folderInput", txtFolderInput.Text);

            if (!m_isDrag)
            {
                PrintMessage("Loading files...");
                lstImage.Items.Clear();
                bgLoadFile.RunWorkerAsync();
            }
            m_isDrag = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderOutput_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveRegValue("folderOutput", txtFolderOutput.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveFail.Checked)
            {
                errorProvider1.Clear();

                if (txtFailedDir.Text == "")
                {
                    chkMoveFail.Checked = false;
                    PrintError("Target directory is empty");
                }
                else if (!Directory.Exists(txtFailedDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtFailedDir, "Dir does not exist");

                    chkMoveFail.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveRegValue("txtFailedDir", txtFailedDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_enableDeepScan_CheckedChanged(object sender, EventArgs e)
        {
            bikeDetector.EnableDeepScan = chk_enableDeepScan.Checked;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFailedDir_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtValidDir_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveValid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveValid.Checked)
            {
                errorProvider1.Clear();

                if (txtValidDir.Text == "")
                {
                    PrintError("Valid directory is empty");
                    chkMoveValid.Checked = false;
                }
                else if (!Directory.Exists(txtValidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtValidDir, "Dir does not exist");
                    chkMoveValid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveRegValue("txtValidDir", txtValidDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveInvalid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveInvalid.Checked)
            {
                errorProvider1.Clear();

                if (txtInvalidDir.Text == "")
                {
                    PrintError("Invalid directory is empty");
                    chkMoveInvalid.Checked = false;
                }
                else if (!Directory.Exists(txtInvalidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtInvalidDir, "Dir does not exist");
                    chkMoveInvalid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveRegValue("txtInvalidDir", txtInvalidDir.Text);
                }
            }
        }

        #endregion //group_folder_source


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region BackgroundWorker

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string inputPath = "";
            if (txtFolderInput.Text != "")
                inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = "";
            if (txtFailedDir.Text != "")
                failedDir = TGMTutil.CorrectPath(txtFailedDir.Text);

            string validDir = "";
            if (txtValidDir.Text != "")
                validDir = TGMTutil.CorrectPath(txtValidDir.Text);

            string invalidDir = "";
            if (txtInvalidDir.Text != "")
                invalidDir = TGMTutil.CorrectPath(txtInvalidDir.Text);

            int exactlyCount = 0;
            string content = "";

            for (int i = 0; i < lstImage.Items.Count; i++)
            {
                if (bgWorker1.CancellationPending)
                    return;
                bgWorker1.ReportProgress(i + 1);

                bikeDetector.OutputFileName = lstImage.Items[i].Text;

                string filePath = inputPath + lstImage.Items[i].Text;
                string ext = filePath.Substring(filePath.Length - 4).ToLower();
                content += Path.GetFileName(filePath) + ",";

                if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                    continue;
                PrintMessage(i + " / " + lstImage.Items.Count + " " + filePath);

                Bitmap bmp;
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(filePath);
                }
                catch (Exception ex)
                {
                    continue;
                }

                BikePlate result = bikeDetector.ReadPlate(bmp);
                bmp.Dispose();

                if (result.hasPlate)
                {
                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.text);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.text;
                    }
                    lstImage.Items[i].ForeColor = result.isValid ? Color.Blue : Color.Black;
                    content += "x,";

                    if (result.isValid)
                    {
                        exactlyCount++;
                        if (chkMoveValid.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, validDir + lstImage.Items[i].Text));
                        }
                    }
                    else
                    {
                        if (chkMoveInvalid.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, invalidDir + lstImage.Items[i].Text));
                        }
                    }
                }
                else
                {
                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.error);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.error;
                    }
                    if (chkMoveFail.Checked)
                    {
                        Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, failedDir + lstImage.Items[i].Text));
                    }
                    
                    lstImage.Items[i].ForeColor = Color.Red;
                    content += ",";
                }

                content += result.text;
                content += "\r\n";


                result.Dispose();


                lstImage.EnsureVisible(i);
            }

            if (inputPath != "")
            {
                content += "Exactly " + exactlyCount + " / " + lstImage.Items.Count + " plates\r\n";
                File.WriteAllText(Path.GetDirectoryName(inputPath) + "\\_report.csv", content);
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PrintMessage(e.ProgressPercentage + "/" + lstImage.Items.Count + "(" + (100 * e.ProgressPercentage / lstImage.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            timerProgressbar.Stop();
            btnDetect.Text = "Start detect (F5)";
            if (txtFolderOutput.Text != "")
                PrintMessage("Save report to " + TGMTutil.CorrectPath(txtFolderInput.Text) + "_report.csv");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            lstImage.Items.Clear();

            string[] fileList = Directory.GetFiles(txtFolderInput.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> files = (List<string>)e.Result;
            for (int i = 0; i < files.Count; i++)
            {
                lstImage.Items.Add(files[i]);
            }
            PrintMessage("Loaded " + lstImage.Items.Count + " images");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkEnableLog_CheckedChanged(object sender, EventArgs e)
        {
            bikeDetector.EnableLog = chkEnableLog.Checked;
            TGMTregistry.GetInstance().SaveRegValue("EnableLog", bikeDetector.EnableLog);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkSaveInputImage_CheckedChanged(object sender, EventArgs e)
        {
            bikeDetector.SaveInputImage = chkSaveInputImage.Checked;
            TGMTregistry.GetInstance().SaveRegValue("SaveInputImage", bikeDetector.SaveInputImage);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkCrop_CheckedChanged(object sender, EventArgs e)
        {
            bikeDetector.CropResultImage = chkCrop.Checked;
            TGMTregistry.GetInstance().SaveRegValue("CropResultImage", bikeDetector.CropResultImage);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstImage.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                DisplayResultImage();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (!File.Exists(filePath))
            {
                PrintMessage("File does not exist");
                
            }


            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(filePath);
                PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(filePath);
                Clipboard.SetFileDropList(paths);
                PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if(e.ClickedItem.Name == "btnDelete")
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerClear_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            timerClear.Stop();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if(e.KeyCode == Keys.Delete)
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResultImage();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (lstImage.Items.Count == 0 || lstImage.SelectedItems.Count == 0)
            {
                return;
            }

            string fileName = lstImage.SelectedItems[0].Text;


            string inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = txtFailedDir.Text != "" ? TGMTutil.CorrectPath(txtFailedDir.Text) : "";
            string outputDir = txtFolderOutput.Text != "" ? TGMTutil.CorrectPath(txtFolderOutput.Text) : "";

            if (txtFolderOutput.Text != "" && File.Exists(outputDir + fileName))
            {
                picResult.ImageLocation = outputDir + fileName;
                PrintMessage(outputDir + fileName);
            }
            else if (File.Exists(inputPath + fileName))
            {
                picResult.ImageLocation = inputPath + fileName;
                PrintMessage(inputPath + fileName);
            }
            else if (txtFailedDir.Text != "" && File.Exists(failedDir + fileName))
            {
                picResult.ImageLocation = failedDir + fileName;
                PrintMessage(failedDir + fileName);
            }
            else
            {
                PrintError("File " + inputPath + fileName + " does not exist");
            }
        }

        
    }
}
