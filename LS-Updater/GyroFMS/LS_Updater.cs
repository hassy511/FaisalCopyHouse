using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_Updater
{
    public partial class LS_Updater : Form
    {
        WebClient webClient = new WebClient();
        Process newProcess = new Process();
        static Assembly basePath = Assembly.GetExecutingAssembly();
        static string sourcePath = ConfigurationManager.AppSettings["sourcePath"];
        static string fileName = ConfigurationManager.AppSettings["fileName"];
        static string destinationPath = System.IO.Path.GetDirectoryName(basePath.Location);
        System.Uri url = new System.Uri(sourcePath);
        string currentVersion, updatedVersion;

        public LS_Updater()
        {
            InitializeComponent();
        }
        //Get webClient Application Version
        private string GetwebClientVersion()
        {
            try
            {
                if (File.Exists(@"version.txt"))
                {
                    var cfileStream = new FileStream(@"version.txt", FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(cfileStream, Encoding.UTF8))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("Error", "Version File Not Found on webClient System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        //Get Server Application Version
        private string GetServerVersion()
        {
            try
            {
                Stream stream = webClient.OpenRead("http://92.205.25.83/LSVersionCheckerAPI/api/Version/getLatestVersion?clientCode=Mams");
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return "";
            }
        }

       

        //Run Gyro Application Exe File
        private void RunGyroApplication()
        {
            try
            {
                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.FileName = @"Gyro\ERP_Maaz_Oil.exe";
                newProcess.Start();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Download Zip File From Server
        private void DownloadZipFile()
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(url, destinationPath + "\\"+fileName);
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                //Thread.Sleep(5);
                progressBar.Text = Math.Round(percentage).ToString() + "%";
                progressBar.Value = int.Parse(Math.Round(percentage).ToString());
                //progressBar.Update();
            });
        }
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                lblStatus.Text = "Download Completed.";
                lblStatus.Refresh();
                progressBar.InnerColor = Color.FromArgb(69, 139, 0);
                progressBar.Refresh();
                if (DeleteOldFiles() == true)
                {
                    if (UnzipFiles() == true)
                    {
                        UpdateClientVersion();
                        RunGyroApplication();
                    }
                }
            });
        }

        //Delete Older Files
        private bool DeleteOldFiles()
        {
            try
            {

                if (Directory.Exists(destinationPath + "\\Gyro"))
                {
                    var dir = new DirectoryInfo(destinationPath + "\\Gyro");
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                    dir.Delete(true);
                    return true;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return false;
            }
            return false;
        }

        //Unzip Files
        private bool UnzipFiles()
        {
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(destinationPath + "\\"+fileName, destinationPath + "\\Gyro");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return false;
            }
        }

        //Update Client Version
        private void UpdateClientVersion()
        {
            try
            {
                if (File.Exists(destinationPath + "\\" + fileName))
                {
                    File.WriteAllText(@"version.txt", string.Empty);
                    File.WriteAllText(@"version.txt", updatedVersion);
                }

                if (File.Exists(destinationPath + "\\" + fileName))
                {
                    File.Delete(destinationPath + "\\" + fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public void Init()
        {
            //Checking for Updated Version
            currentVersion = GetwebClientVersion();
            updatedVersion = GetServerVersion();

            if (currentVersion.Equals(updatedVersion))
            {
                //Run Already Exist Exe File
                RunGyroApplication();
            }
            else
            {
                lblStatus.Text = "Downloading Updates..";
                DownloadZipFile();

            }
        }

        private void frmGyroFMS_Load(object sender, EventArgs e)
        {
            CheckGyroFMSRunning();
            Init();
        }

        //Check if GyroFms Already Running
        private void CheckGyroFMSRunning()
        {
            try
            {
                Process[] processName = Process.GetProcessesByName(Path.GetFileName(destinationPath + "\\Gyro\\ERP_Maaz_Oil.exe").Substring(0, Path.GetFileName(destinationPath + "\\Gyro\\ERP_Maaz_Oil.exe").LastIndexOf('.')));
                if (processName.Length > 0)
                {
                    processName[0].Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
