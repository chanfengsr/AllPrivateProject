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
        private struct FormControlProperties {
            public bool SourceFolderEnabled;
            public bool TargetFolderEnabled;
            public bool FileTypeEnabled;
            public string FileTypeDefaultString;
            public bool SortModeEnabled;
            public bool ViewFileNameListEnabled;
            public bool SpecFileListEnabled;

        }

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
            btnCloseForm.Top = -1000;
            LoadConfig();

            int addHeight = chkSpecFileList.Height;
            grpFileSelect.Height = btnViewFileNameList.Location.Y + btnViewFileNameList.Height + addHeight;
            splitContainer1.SplitterDistance = grpFileSelect.Location.Y + grpFileSelect.Height + tabCtrlFunction.Height + addHeight;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            SaveConfig();
        }

        private void btnCloseForm_Click(object sender, EventArgs e) {
            this.Close();
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
                try {
                    UIInProcess(true);

                    FileCopyByGroup fileCopyByGroup = ConstructFileCopyByGroup();
                    fileCopyByGroup.Execute();

                    SaveConfig();
                }
                catch (Exception ex) {
                    CommFunction.WriteMessage(ex.Message);
                }
                finally {
                    UIInProcess(false);
                }

                GC.Collect();
            }).Start();
        }

        private void rdoTypeCust_CheckedChanged(object sender, EventArgs e) {
            txtFileType.Enabled = rdoTypeCust.Checked;
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

        private void btnViewFileNameList_Click(object sender, EventArgs e) {
            try {
                UIInProcess(true);

                FileProcessBaseClass fileProcBase = new FileProcessBaseClass();
                fileProcBase.SetFileSelectParm(this.GetFormFileSelParm());
                string fileList = fileProcBase.LoadFileList();

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

        private void chkSpecFileList_CheckedChanged(object sender, EventArgs e) {
            btnEditChangeFileList.Enabled = chkSpecFileList.Checked;

            grpFileType.Enabled =
                grpSortMode.Enabled =
                btnViewFileNameList.Enabled =
                !chkSpecFileList.Checked;
        }

        private void btnEditChangeFileList_Click(object sender, EventArgs e) {
            using (formTextMessage frmMessage = new formTextMessage("编辑要被更名的文件列表", _fileChangeNameSpecChgFileList)) {
                if (frmMessage.ShowDialog(this) == DialogResult.OK)
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
                if (frmMessage.ShowDialog(this) == DialogResult.OK)
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

        private void btnSpFunDeleteEmptyFolder_Click(object sender, EventArgs e) {
            try {
                UIInProcess(true);

                FileSporadicFunction sporadicFunction = new FileSporadicFunction();
                FileSelectParm fileSelParm = this.GetFormFileSelParm();
                sporadicFunction.SetFileSelectParm(fileSelParm);
                List<string> emptyFolderList = sporadicFunction.GetEmptyFolderList(fileSelParm.SourceFileFolder, fileSelParm.FileFilter);
                emptyFolderList.Reverse();
                StringBuilder sbMsg = new StringBuilder();
                foreach (string empFolder in emptyFolderList)
                    sbMsg.AppendLine(empFolder);

                if (emptyFolderList.Count > 0) {
                    using (formTextMessage frmMessage = new formTextMessage("是否删除以下空文件夹？", sbMsg.ToString().Trim().TrimEnd(Environment.NewLine.ToArray()), true)) {
                        if (frmMessage.ShowDialog(this) == DialogResult.OK) {
                            emptyFolderList.Reverse(); //重新倒置，使从子目录开始删
                            sporadicFunction.Execute_DeleteEmptyFolder(emptyFolderList);
                        }
                    }
                }
                else {
                    CommFunction.WriteMessage("没有找到空文件夹。");
                }

                UIInProcess(false);
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
            finally {
                UIInProcess(false);
            }
        }

        private void btnSpFunFindMisplacedPhoto_Click(object sender, EventArgs e) {
            try {
                UIInProcess(true);

                FileSporadicFunction sporadicFunction = new FileSporadicFunction();
                FileSelectParm fileSelParm = this.GetFormFileSelParm();
                if (fileSelParm.FileFilter == string.Empty)
                    fileSelParm.FileFilter = CommDefinition.ExtensionPicFile;
                sporadicFunction.SetFileSelectParm(fileSelParm);

                StringBuilder sbMsg = new StringBuilder();
                List<string> fileInWrongFolder = sporadicFunction.GetFileInWrongFolder();
                foreach (string fName in fileInWrongFolder)
                    sbMsg.AppendLine(fName);

                UIInProcess(false);

                if (fileInWrongFolder.Count > 0) {
                    using (formTextMessage frmMessage = new formTextMessage("找到的文件列表", sbMsg.ToString().Trim().TrimEnd(Environment.NewLine.ToArray()), true)) {
                        frmMessage.ShowDialog(this);
                    }
                }
                else {
                    CommFunction.WriteMessage("没有找到此类文件。");
                }
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
            finally {
                UIInProcess(false);
            }
        }

        private void tabCtrlFunction_SelectedIndexChanged(object sender, EventArgs e) {
            FormControlProperties formCtrlProps = new FormControlProperties();

            if (tabCtrlFunction.SelectedTab.Name == tabPageCopyByGroup.Name) {
                formCtrlProps.SourceFolderEnabled = true;
                formCtrlProps.TargetFolderEnabled = true;
                formCtrlProps.FileTypeEnabled = true;
                formCtrlProps.SortModeEnabled = true;
                formCtrlProps.ViewFileNameListEnabled = true;
                formCtrlProps.SpecFileListEnabled = true;

                formCtrlProps.FileTypeDefaultString = txtFileType.Text == "" ? "*" : txtFileType.Text;
            }
            else if (tabCtrlFunction.SelectedTab.Name == tabPageFileBatchChangeName.Name) {
                formCtrlProps.SourceFolderEnabled = true;
                formCtrlProps.TargetFolderEnabled = false;
                formCtrlProps.FileTypeEnabled = true;
                formCtrlProps.SortModeEnabled = true;
                formCtrlProps.ViewFileNameListEnabled = true;
                formCtrlProps.SpecFileListEnabled = true;

                formCtrlProps.FileTypeDefaultString = txtFileType.Text == "" ? "*" : txtFileType.Text;
            }
            else if (tabCtrlFunction.SelectedTab.Name == tabPageSporadicFunction.Name) {
                formCtrlProps.SourceFolderEnabled = true;
                formCtrlProps.TargetFolderEnabled = false;
                formCtrlProps.FileTypeEnabled = true;
                formCtrlProps.SortModeEnabled = false;
                formCtrlProps.ViewFileNameListEnabled = false;
                formCtrlProps.SpecFileListEnabled = false;

                formCtrlProps.FileTypeDefaultString = txtFileType.Text == "*" ? "" : txtFileType.Text;
            }

            this.SetFormControlProperties(formCtrlProps);
        }

        private void FolderBrowser(Control txtBox) {
            if (Directory.Exists(txtBox.Text))
                folderBrowser.SelectedPath = txtBox.Text;
            else
                folderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = folderBrowser.SelectedPath;
        }

        private void LoadConfig() {
            try {
                txtSourceFolder.Text = SysConfig.GetConfigData("AppConfig", "SourceFolder", "");
                txtTargetFolder.Text = SysConfig.GetConfigData("AppConfig", "TargetFolder", "");
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void SaveConfig() {
            try {
                SysConfig.WriteConfigData("AppConfig", "SourceFolder", txtSourceFolder.Text);
                SysConfig.WriteConfigData("AppConfig", "TargetFolder", txtTargetFolder.Text);
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void UIInProcess(bool inProcessing) {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            grpFunction.Enabled = !inProcessing;
        }

        private FileSelectParm GetFormFileSelParm() {
            FileSelectParm retVal = new FileSelectParm();

            if (rdoTypePic.Checked)
                retVal.FileFilter = CommDefinition.ExtensionPicFile;
            else if (rdoTypeAudio.Checked)
                retVal.FileFilter = CommDefinition.ExtensionAudioFile;
            else if (rdoTypeVideo.Checked)
                retVal.FileFilter = CommDefinition.ExtensionVideoFile;
            else if (rdoTypeText.Checked)
                retVal.FileFilter = CommDefinition.ExtensionTextFile;
            else if (rdoTypeCust.Checked)
                retVal.FileFilter = txtFileType.Text;

            if (rdoSortName.Checked)
                retVal.FileSortBy = FileSortMode.FileName;
            else if (rdoSortCreateDate.Checked)
                retVal.FileSortBy = FileSortMode.CreateDate;
            else if (rdoSortModifyDate.Checked)
                retVal.FileSortBy = FileSortMode.ModifyDate;
            else if (rdoSortRecordDate.Checked)
                retVal.FileSortBy = FileSortMode.RecordingDate;
            else if (rdoSortNameDate.Checked)
                retVal.FileSortBy = FileSortMode.DateInFileName;

            retVal.SourceFileFolder = txtSourceFolder.Text;
            retVal.TargetFileFolder = txtTargetFolder.Text;
            retVal.UseSpecFileList = chkSpecFileList.Checked;
            retVal.SpecFileList = _fileChangeNameSpecChgFileList;

            return retVal;
        }

        private void SetFormControlProperties(FormControlProperties formCtrlProps) {
            txtSourceFolder.Enabled =
                btnSourceFolderBrowser.Enabled = formCtrlProps.SourceFolderEnabled;

            txtTargetFolder.Enabled =
                btnTargetFolderBrowser.Enabled = formCtrlProps.TargetFolderEnabled;

            grpFileType.Enabled = formCtrlProps.FileTypeEnabled;
            txtFileType.Text = formCtrlProps.FileTypeDefaultString;

            grpSortMode.Enabled = formCtrlProps.SortModeEnabled;

            btnViewFileNameList.Enabled = formCtrlProps.ViewFileNameListEnabled;
            chkSpecFileList.Enabled =
                btnEditChangeFileList.Enabled = formCtrlProps.SpecFileListEnabled;

            if (formCtrlProps.SpecFileListEnabled)
                this.chkSpecFileList_CheckedChanged(chkSpecFileList, new EventArgs());
        }

        private FileBatchChangeName ConstructFileBatchChangeName() {
            FileBatchChangeName retVal = new FileBatchChangeName();
            retVal.SetFileSelectParm(this.GetFormFileSelParm());

            FileChangeRule fileChangeBy = FileChangeRule.FixedString;
            if (rdoChgNmRulFixedStr.Checked)
                fileChangeBy = FileChangeRule.FixedString;
            else if (rdoChgNmRulWildcard.Checked)
                fileChangeBy = FileChangeRule.Wildcard;
            else if (rdoChgNmRulSpecList.Checked)
                fileChangeBy = FileChangeRule.SpecList;

            switch (fileChangeBy) {
                case FileChangeRule.FixedString:
                    retVal.SetFunctionRule(fileChangeBy, txtChgNmFixedStr.Text, chkChgNmIsRegex.Checked);
                    break;
                case FileChangeRule.Wildcard:
                    retVal.SetFunctionRule(fileChangeBy,
                                           perfixStr: txtChgNmPerfixStr.Text,
                                           suffixStr: txtChgNmSuffixStr.Text,
                                           startNum: (int)numChgNmStartNum.Value,
                                           wildcardLen: (int)numChgNmWildcardLen.Value,
                                           onlyFixStr: chkChgNmOnlyFixStr.Checked);
                    break;
                case FileChangeRule.SpecList:
                    retVal.SetFunctionRule(fileChangeBy, specChgList: _fileChangeNameChangeList);
                    break;
            }

            return retVal;
        }

        private FileCopyByGroup ConstructFileCopyByGroup() {
            FileCopyByGroup retVal = new FileCopyByGroup();
            retVal.SetFileSelectParm(this.GetFormFileSelParm());
            retVal.SetFunctionRule(chkModMove.Checked);

            return retVal;
        }
    }
}