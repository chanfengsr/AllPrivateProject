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

namespace FileManager {
    public partial class Form1 : Form {
        private readonly List<FileInfo> _allFile = new List<FileInfo>();
        private string _fileChangeNameChangeList = string.Empty;
        private string _fileChangeNameSpecChgFileList = string.Empty;

        public Form1() {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConsoleRedirect.AttachTextBox(this.txtConsole);

            this.Text = this.Text + "  V" + Application.ProductVersion;
            this.Icon = Resources.MainIco;
        }

        private void Form1_Load(object sender, EventArgs e) {
            LoadConfig();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //SaveConfig();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            txtConsole.Clear();
        }

        private void btnSourceFolderBrowser_Click(object sender, EventArgs e) {
            FolderBrowser(txtSourceFolder);
        }

        private void btnTargetFolderBrowser_Click(object sender, EventArgs e) {
            FolderBrowser(txtTargetFolder);
        }

        private void txtFileFolder_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void txtFileFolder_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (ary.Length == 0)
                    return;

                string folderName = ary.GetValue(0).ToString();

                if (Directory.Exists(folderName)) {
                    var textBox = sender as TextBox;
                    if (textBox != null)
                        textBox.Text = folderName;
                }
            }
        }

        private void btnCopyByDate_Click(object sender, EventArgs e) {
            new System.Threading.Thread(() => {
                int count = 0;
                string sourceFolder = txtSourceFolder.Text;
                string origTargetFolder = txtTargetFolder.Text;
                string targetFolder;
                string dupFileFolder; //重复文件放的文件夹
                bool havDupFileFolder = false;
                DateTime fileDate;

                try {
                    UIInProcess(true);

                    if (Directory.Exists(sourceFolder)
                        && Directory.Exists(origTargetFolder)) {
                        if (!origTargetFolder.EndsWith("\\"))
                            origTargetFolder = origTargetFolder + "\\";

                        dupFileFolder = origTargetFolder + "Duplicate files\\";

                        _allFile.Clear();
                        GetAllFile(new DirectoryInfo(sourceFolder));

                        foreach (FileInfo fileInfo in _allFile) {
                            try {
                                //隐藏文件和系统文件就不要过来凑热闹了
                                if ( /*( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden || */
                                    ( fileInfo.Attributes & FileAttributes.System ) == FileAttributes.System)
                                    continue;

                                fileDate = CommFunction.GetFileDateTime(fileInfo, chkUseCameraDate.Checked);
                                targetFolder = origTargetFolder + fileDate.ToString("yyyy-MM-dd") + "\\";
                                if (!Directory.Exists(targetFolder))
                                    Directory.CreateDirectory(targetFolder);

                                if (File.Exists(targetFolder + fileInfo.Name)) {
                                    if (!havDupFileFolder || !Directory.Exists(dupFileFolder)) {
                                        Directory.CreateDirectory(dupFileFolder);
                                        havDupFileFolder = true;
                                    }

                                    fileInfo.CopyTo(dupFileFolder + fileInfo.Name, true);
                                }
                                else
                                    fileInfo.CopyTo(targetFolder + fileInfo.Name);

                                count++;
                            }
                            catch (Exception ex) {
                                CommFunction.WriteMessage(ex.Message);
                            }
                        }

                        SaveConfig();
                        CommFunction.WriteMessage("复制完成！ 共 " + count + " 个文件。");
                    }
                    else
                        CommFunction.WriteMessage("文件夹不存在！");
                }
                catch (Exception ex) {
                    CommFunction.WriteMessage(ex.Message);
                }
                finally {
                    UIInProcess(false);
                }

                GC.Collect();
            }
                ).Start();
        }

        private void btnChgNmFolderBrowser_Click(object sender, EventArgs e) {
            FolderBrowser(txtChgNmFileFolder);
        }

        private void rdoChgNmTypeCust_CheckedChanged(object sender, EventArgs e) {
            txtChgNmFileType.Enabled = rdoChgNmTypeCust.Checked;
        }

        private void rdoChgNmRulFixedStr_CheckedChanged(object sender, EventArgs e) {
            txtChgNmFixedStr.Enabled =
                chkChgNmIsRegex.Enabled =
                rdoChgNmRulFixedStr.Checked;

            if (rdoChgNmRulFixedStr.Checked)
                btnChgNmViewChgFileNameList.Enabled = true;
        }

        private void rdoChgNmRulWildcard_CheckedChanged(object sender, EventArgs e) {
            txtChgNmPerfixStr.Enabled =
                numChgNmStartNum.Enabled =
                numChgNmWildcardLen.Enabled =
                txtChgNmSuffixStr.Enabled =
                chkChgNmOnlyFixStr.Enabled = rdoChgNmRulWildcard.Checked;

            if (rdoChgNmRulWildcard.Checked)
                btnChgNmViewChgFileNameList.Enabled = true;
        }

        private void rdoChgNmRulSpecList_CheckedChanged(object sender, EventArgs e) {
            btnChgNmEditChangeList.Enabled = rdoChgNmRulSpecList.Checked;

            if (rdoChgNmRulSpecList.Checked)
                btnChgNmViewChgFileNameList.Enabled = false;
        }

        private void btnChgNmViewFileNameList_Click(object sender, EventArgs e) {
            try {
                UIInProcess(true);
                FileBatchChangeName fileBatchChangeName = ConstructFileBatchChangeName();
                string fileList = fileBatchChangeName.LoadFileList();
                UIInProcess(false);

                if (fileList.Length > 0) {
                    using (formTextMessage frmMessage = new formTextMessage("文件列表预览", fileList, true)) {
                        frmMessage.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
            finally {
                UIInProcess(false);
            }
        }

        private void chkChgNmSpecChangeFile_CheckedChanged(object sender, EventArgs e) {
            btnChgNmEditChangeFileList.Enabled = chkChgNmSpecChangeFile.Checked;

            grpChgNmFileType.Enabled =
                grpChgNmSortMode.Enabled =
                btnChgNmViewFileNameList.Enabled =
                !chkChgNmSpecChangeFile.Checked;
        }

        private void btnChgNmEditChangeFileList_Click(object sender, EventArgs e) {
            using (formTextMessage frmMessage = new formTextMessage("编辑要被更名的文件列表", _fileChangeNameSpecChgFileList)) {
                frmMessage.ShowDialog(this);
                
                if (frmMessage.CloseResult == DialogResult.OK)
                    _fileChangeNameSpecChgFileList = frmMessage.FormMessage;
            }
        }

        private void chkChgNmOnlyFixStr_CheckedChanged(object sender, EventArgs e) {
            numChgNmStartNum.Enabled =
                numChgNmWildcardLen.Enabled = !chkChgNmOnlyFixStr.Checked;
        }

        private void btnChgNmViewChgFileNameList_Click(object sender, EventArgs e) {
            try {
                UIInProcess(true);
                FileBatchChangeName fileBatchChangeName = ConstructFileBatchChangeName();
                List<string> targetNameList = fileBatchChangeName.GetTargetNameList();
                UIInProcess(false);

                if (targetNameList.Count > 0) {
                    string nameAll = targetNameList.Aggregate("", (current, name) => current + name + Environment.NewLine).TrimEnd(Environment.NewLine.ToCharArray());

                    using (formTextMessage frmMessage = new formTextMessage("更名列表预览", nameAll, true)) {
                        frmMessage.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
            finally {
                UIInProcess(false);
            }
        }

        private void btnChgNmEditChangeList_Click(object sender, EventArgs e) {
            using (formTextMessage frmMessage = new formTextMessage("编辑文件更名列表", _fileChangeNameChangeList)) {
                frmMessage.ShowDialog(this);

                if (frmMessage.CloseResult == DialogResult.OK)
                    _fileChangeNameChangeList = frmMessage.FormMessage;
            }
        }

        private void btnChgNmExecute_Click(object sender, EventArgs e) {
            new System.Threading.Thread(() => {
                try {
                    UIInProcess(true);

                    FileBatchChangeName fileBatchChangeName = ConstructFileBatchChangeName();
                    fileBatchChangeName.ExecuteChangeName();

                    SaveConfig();
                }
                catch (Exception ex) {
                    CommFunction.WriteMessage(ex.Message);
                }
                finally {
                    UIInProcess(false);
                }

                GC.Collect();
            }
                ).Start();
        }

        private void FolderBrowser(Control txtBox) {
            if (Directory.Exists(txtTargetFolder.Text))
                folderBrowser.SelectedPath = txtTargetFolder.Text;
            else
                folderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = folderBrowser.SelectedPath;
        }

        private void LoadConfig() {
            try {
                txtSourceFolder.Text = SysConfig.GetConfigData("AppConfig", "SourceFolder", "");
                txtTargetFolder.Text = SysConfig.GetConfigData("AppConfig", "TargetFolder", "");
                chkUseCameraDate.Checked = SysConfig.GetConfigData("AppConfig", "UseCameraDate", false);

                txtChgNmFileFolder.Text = SysConfig.GetConfigData("AppConfig", "ChangeNameFileFolder", "");
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void SaveConfig() {
            try {
                SysConfig.WriteConfigData("AppConfig", "SourceFolder", txtSourceFolder.Text);
                SysConfig.WriteConfigData("AppConfig", "TargetFolder", txtTargetFolder.Text);
                SysConfig.WriteConfigData("AppConfig", "UseCameraDate", chkUseCameraDate.Checked.ToString());

                SysConfig.WriteConfigData("AppConfig", "ChangeNameFileFolder", txtChgNmFileFolder.Text);
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void GetAllFile(DirectoryInfo dirInfo) {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                GetAllFile(di);

            foreach (FileInfo fi in dirInfo.GetFiles())
                _allFile.Add(fi);
        }
        
        private void UIInProcess(bool inProcessing) {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            grpFunction.Enabled = !inProcessing;
        }

        private FileBatchChangeName ConstructFileBatchChangeName() {
            FileBatchChangeName ret = new FileBatchChangeName();
            string strFileFilter;
            FileSortMode fileSortBy;
            FileChangeRule fileChangeBy;

            if (rdoChgNmTypePic.Checked)
                strFileFilter = FileBatchChangeName.ExtensionPicFile;
            else if (rdoChgNmTypeAudio.Checked)
                strFileFilter = FileBatchChangeName.ExtensionAudioFile;
            else if (rdoChgNmTypeVideo.Checked)
                strFileFilter = FileBatchChangeName.ExtensionVideoFile;
            else if (rdoChgNmTypeText.Checked)
                strFileFilter = FileBatchChangeName.ExtensionTextFile;
            else //if (rdoChgNmTypeCust.Checked)
                strFileFilter = txtChgNmFileType.Text;

            if (rdoChgNmSortName.Checked)
                fileSortBy = FileSortMode.FileName;
            else if (rdoChgNmSortCreateDate.Checked)
                fileSortBy = FileSortMode.CreateDate;
            else if (rdoChgNmSortModifyDate.Checked)
                fileSortBy = FileSortMode.ModifyDate;
            else //if (rdoChgNmSortRecordDate.Checked)
                fileSortBy = FileSortMode.RecordingDate;

            if (rdoChgNmRulFixedStr.Checked)
                fileChangeBy = FileChangeRule.FixedString;
            else if (rdoChgNmRulWildcard.Checked)
                fileChangeBy = FileChangeRule.Wildcard;
            else
                fileChangeBy = FileChangeRule.SpecList;

            ret.SetFileSelect(txtChgNmFileFolder.Text, strFileFilter, fileSortBy, chkChgNmSpecChangeFile.Checked, _fileChangeNameSpecChgFileList);
            switch (fileChangeBy) {
                case FileChangeRule.FixedString:
                    ret.SetNameChangeRule(fileChangeBy, txtChgNmFixedStr.Text, chkChgNmIsRegex.Checked);
                    break;
                case FileChangeRule.Wildcard:
                    ret.SetNameChangeRule(fileChangeBy,
                                          perfixStr: txtChgNmPerfixStr.Text,
                                          suffixStr: txtChgNmSuffixStr.Text,
                                          startNum: (int)numChgNmStartNum.Value,
                                          wildcardLen: (int)numChgNmWildcardLen.Value,
                                          onlyFixStr: chkChgNmOnlyFixStr.Checked);
                    break;
                case FileChangeRule.SpecList:
                    ret.SetNameChangeRule(fileChangeBy, specChgList: _fileChangeNameChangeList);
                    break;
            }

            return ret;
        }
    }
}