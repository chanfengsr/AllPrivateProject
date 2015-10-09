using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileManager.Properties;

namespace FileManager
{
    public partial class Form1 : Form
    {
        readonly List<FileInfo> _allFile = new List<FileInfo>();

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConsoleRedirect.AttachTextBox(this.txtConsole);

            this.Text = this.Text + "  V" + Application.ProductVersion;
            this.Icon = Resources.MainIco;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SaveConfig();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

        private void btnSourceFolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowser(txtSourceFolder);
        }

        private void btnTargetFolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowser(txtTargetFolder);
        }

        private void txtSourceFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void txtSourceFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (ary.Length == 0)
                    return;

                string folderName = ary.GetValue(0).ToString();

                if (Directory.Exists(folderName))
                    txtSourceFolder.Text = folderName;
            }
        }

        private void txtTargetFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void txtTargetFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (ary.Length == 0)
                    return;

                string folderName = ary.GetValue(0).ToString();

                if (Directory.Exists(folderName))
                    txtTargetFolder.Text = folderName;
            }
        }

        private void btnCopyByDate_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(() =>
                {
                    int count = 0;
                    string sourceFolder = txtSourceFolder.Text;
                    string origTargetFolder = txtTargetFolder.Text;
                    string targetFolder;
                    string dupFileFolder; //重复文件放的文件夹
                    bool havDupFileFolder = false;
                    DateTime fileDate;

                    try
                    {
                        UIInProcess(true);

                        if (Directory.Exists(sourceFolder)
                            && Directory.Exists(origTargetFolder))
                        {
                            if (!origTargetFolder.EndsWith("\\"))
                                origTargetFolder = origTargetFolder + "\\";

                            dupFileFolder = origTargetFolder + "Duplicate files\\";

                            _allFile.Clear();
                            GetAllFile(new DirectoryInfo(sourceFolder));

                            foreach (FileInfo fileInfo in _allFile)
                            {
                                try
                                {
                                    //隐藏文件和系统文件就不要过来凑热闹了
                                    if ( /*( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden || */
                                        ( fileInfo.Attributes & FileAttributes.System ) == FileAttributes.System)
                                        continue;
                                    
                                    fileDate = GetFileDateTime(fileInfo, chkUseCameraDate.Checked);
                                    targetFolder = origTargetFolder + fileDate.ToString("yyyy-MM-dd") + "\\";
                                    if (!Directory.Exists(targetFolder))
                                        Directory.CreateDirectory(targetFolder);

                                    if (File.Exists(targetFolder + fileInfo.Name))
                                    {
                                        if (!havDupFileFolder || !Directory.Exists(dupFileFolder))
                                        {
                                            Directory.CreateDirectory(dupFileFolder);
                                            havDupFileFolder = true;
                                        }

                                        fileInfo.CopyTo(dupFileFolder + fileInfo.Name, true);
                                    }
                                    else
                                        fileInfo.CopyTo(targetFolder + fileInfo.Name);

                                    count++;
                                }
                                catch (Exception ex)
                                {
                                    CommFunction.WriteMessage(ex.Message);
                                }
                            }

                            SaveConfig();
                            CommFunction.WriteMessage("复制完成！ 共 " + count + " 个文件。");
                        }
                        else
                            CommFunction.WriteMessage("文件夹不存在！");
                    }
                    catch (Exception ex)
                    {
                        CommFunction.WriteMessage(ex.Message);
                    }
                    finally
                    {
                        UIInProcess(false);
                    }

                    GC.Collect();
                }
                ).Start();
        }

        private void FolderBrowser(Control txtBox)
        {
            if (Directory.Exists(txtTargetFolder.Text))
                folderBrowser.SelectedPath = txtTargetFolder.Text;
            else
                folderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = folderBrowser.SelectedPath;
        }

        private void LoadConfig()
        {
            try
            {
                txtSourceFolder.Text = SysConfig.GetConfigData("AppConfig", "SourceFolder", "");
                txtTargetFolder.Text = SysConfig.GetConfigData("AppConfig", "TargetFolder", "");
                chkUseCameraDate.Checked = SysConfig.GetConfigData("AppConfig", "UseCameraDate", false);
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void SaveConfig()
        {
            try
            {
                SysConfig.WriteConfigData("AppConfig", "SourceFolder", txtSourceFolder.Text);
                SysConfig.WriteConfigData("AppConfig", "TargetFolder", txtTargetFolder.Text);
                SysConfig.WriteConfigData("AppConfig", "UseCameraDate", chkUseCameraDate.Checked.ToString());
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void GetAllFile(DirectoryInfo dirInfo)
        {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                GetAllFile(di);

            foreach (FileInfo fi in dirInfo.GetFiles())
                _allFile.Add(fi);
        }

        /// <summary>获取文件日期，图片的话优先取拍摄日期
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="useCameraDate">是否取照片拍摄日期</param>
        /// <returns></returns>
        private DateTime GetFileDateTime(FileInfo fileInfo, bool useCameraDate=false)
        {
            if (useCameraDate && fileInfo.Extension.ToLower() == ".jpg")
            {
                DateTime picDate = PictureHelper.GetTakePicDateTime(PictureHelper.GetExifProperties(fileInfo.FullName));

                if (picDate > DateTime.MinValue)
                    return picDate;
            }

            return fileInfo.LastWriteTime;
        }

        private void UIInProcess(bool inProcessing)
        {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            grpFunction.Enabled = !inProcessing;
        }
    }
}