using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using CreateED2K.Properties;
using RHash;

namespace CreateED2K {
    public enum ExecModel {
        RHashDll,
        RHashExe
    }

    public partial class frmCreateEd2k : Form {
        private const string Ed2kFormat = "ed2k://|file|{0}|{1}|{2}|h={3}|/";

        private const string TimeAll = "总耗时：";
        private const string TimeHashAll = "总Hash耗时：";
        private const string TimeEd2kHash = "ED2K耗时：";
        private const string TimeAichHash = "AICH耗时：";

        private readonly Stopwatch _swAll = new Stopwatch();
        private readonly Stopwatch _swEd2k = new Stopwatch();
        private readonly Stopwatch _swAich = new Stopwatch();

        private int _fileCount;

        public frmCreateEd2k() {
            InitializeComponent();
            this.Text = this.Text + "  V" + Application.ProductVersion + "  ——by 巉沨散人";
            this.Icon = Resources.emule;
        }

        private void frmCreateEd2k_Load(object sender, EventArgs e) {
            labProcCount.Text = "";

            new System.Threading.Thread(
                () => {
                    Hasher.GetHashForMsg(new byte[] {}, HashType.ED2K);
                    Hasher.GetHashForMsg(new byte[] {}, HashType.AICH);
                }).Start();
        }

        private void button1_Click(object sender, EventArgs e) {
            string strUrl = "C#高级编程(中文第七版).pdf";
            txtSource.Text = UrlEncode(strUrl);

            string str = UpCaseEmuleLinkResult(@"ed2k://|file|Software.rar|450386406|65597926E25F9EE6515FCBB3F816BC42|h=I4U63MWXWYUUAVEB3TKHE6JVN5MTE3BY|/");
            return;

            txtSource.Text = CreateEd2kLinkByRHash(@"r:\C#高级编程(中文第七版).pdf");

            return;
            string file = @"r:\a b[含全部4DVD内容].docx";

            StringBuilder sb0 = new StringBuilder();
            //sb0.AppendLine(System.Web.HttpUtility.HtmlAttributeEncode(file));
            //sb0.AppendLine(System.Web.HttpUtility.HtmlEncode(file));
            //sb0.AppendLine(System.Web.HttpUtility.UrlEncodeUnicode(file));
            //sb0.AppendLine(System.Web.HttpUtility.UrlPathEncode(file));

            txtSource.Text = sb0.ToString();
            return;

            //RHash.Hasher hasher = new RHash.Hasher(RHash.HashType.ED2K);
            txtSource.Text = RHash.Hasher.GetHashForFile(file, RHash.HashType.ED2K);

            txtSource.AppendText(Environment.NewLine);

            List<string> fileList = new List<string> {file};

            StringBuilder sb = new StringBuilder();
            foreach (string fileName in fileList)
                sb.AppendLine(CreateEd2kLinkByRHashExe(fileName));

            txtSource.Text += sb.ToString();

            //txtSource.Text += System.Web.HttpUtility.UrlEncode(file, Encoding.Default);

        }

        private void btnCalculate_Click(object sender, EventArgs e) {
            DoCalculate(ExecModel.RHashDll);
        }

        private void btnCalcRHashExe_Click(object sender, EventArgs e) {
            DoCalculate(ExecModel.RHashExe);
        }

        private void btnClear_Click(object sender, EventArgs e) {
            _fileCount = 0;
            labProcCount.Text = "";
            txtSource.Clear();
            txtTarget.Clear();

            labTimeAll.Text = TimeAll;
            labTimeHashAll.Text = TimeHashAll;
            labTimeEd2kHash.Text = TimeEd2kHash;
            labTimeAichHash.Text = TimeAichHash;
        }

        private void btnClearSource_Click(object sender, EventArgs e) {
            _fileCount = 0;
            labProcCount.Text = "";
            txtSource.Clear();
        }

        private void btnClearTarget_Click(object sender, EventArgs e) {
            txtTarget.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            bkDoProcess.CancelAsync();
        }

        private void bkDoProcess_DoWork(object sender, DoWorkEventArgs e) {
            StringBuilder sb = new StringBuilder();
            ExecModel execModel = (ExecModel)e.Argument;

            _swAll.Start();
            int procFileCnt = 0;
            foreach (string line in txtSource.Lines) {
                string file = line.Trim();
                string space = new string(' ', line.Length - file.Length);

                if (file == "" || !File.Exists(file))
                    sb.AppendLine(line);
                else {
                    string hashResult;
                    switch (execModel) {
                        case ExecModel.RHashDll:
                            hashResult = CreateEd2kLinkByRHash(file);
                            break;
                        case ExecModel.RHashExe:
                            hashResult = CreateEd2kLinkByRHashExe(file);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    sb.AppendLine(space + hashResult);
                    bkDoProcess.ReportProgress(++procFileCnt);
                }

                if (bkDoProcess.CancellationPending)
                    break;
            }

            e.Result = sb.ToString().Trim();
            _swAll.Stop();
        }

        private void bkDoProcess_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            labProcCount.Text = e.ProgressPercentage + "/" + _fileCount;
        }

        private void bkDoProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            txtTarget.Text = e.Result.ToString();
            labTimeAll.Text = TimeAll + _swAll.Elapsed;
            labTimeHashAll.Text = TimeHashAll + _swEd2k.Elapsed.Add(_swAich.Elapsed);

            if (_swEd2k.Elapsed.Ticks > 0 && _swAich.Elapsed.Ticks > 0) {
                labTimeEd2kHash.Text = TimeEd2kHash + _swEd2k.Elapsed;
                labTimeAichHash.Text = TimeAichHash + _swAich.Elapsed;
            }

            _swAll.Reset();
            _swEd2k.Reset();
            _swAich.Reset();

            UIInProcess(false);
            txtTarget.Focus();
            txtTarget.SelectAll();

        }

        private void txtSource_DragDrop(object sender, DragEventArgs e) {
            StringBuilder sb = new StringBuilder();

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                for (int i = 0; i < ary.Length; i++)
                    sb.AppendLine(GetTopFileTree(ary.GetValue(i).ToString()));
            }

            txtSource.AppendText(sb.ToString());
            labProcCount.Text = "0/" + _fileCount;
        }

        private void txtSource_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DoCalculate(ExecModel execModel) {
            UIInProcess(true);
            txtTarget.Clear();
            bkDoProcess.RunWorkerAsync(execModel);
        }

        /// <summary>RHash Dll 调用，超快
        /// </summary>
        /// <param name="fileFullName">FileFullName</param>
        /// <returns></returns>
        private string CreateEd2kLinkByRHash(string fileFullName) {
            try {
                _swEd2k.Start();
                string ed2k = Hasher.GetHashForFile(fileFullName, HashType.ED2K).ToUpper();
                _swEd2k.Stop();

                _swAich.Start();
                string aich = Hasher.GetHashForFile(fileFullName, HashType.AICH).ToUpper();
                _swAich.Stop();

                FileInfo file = new FileInfo(fileFullName);
                string fileName = UrlEncode(file.Name);

                return string.Format(Ed2kFormat, fileName, file.Length, ed2k, aich);
            }
            catch (Exception) {
                if (_swEd2k.IsRunning)
                    _swEd2k.Stop();

                if (_swAich.IsRunning)
                    _swAich.Stop();

                return "";
            }
        }

        /// <summary>RHash Exe 调用，慢
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        private string CreateEd2kLinkByRHashExe(string fileFullName) {
            try {
                Process newProc = new Process {
                    StartInfo = {
                        FileName = @"RHash\rhash.exe",
                        Arguments = @"-L """ + fileFullName + @"""",
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
                _swEd2k.Start();
                newProc.Start();
                string emuleLink = newProc.StandardOutput.ReadToEnd();
                _swEd2k.Stop();

                return UpCaseEmuleLinkResult(emuleLink);
            }
            catch (Exception) {
                return "";
            }
        }

        /* unsafe characters are "<>{}[]%#/|\^~`@:;?=&+ */

        public string UrlEncode(string name) {
            char[] goodUrlChar = new[] {'$', '-', '_', '.', '!', '\'', '(', ')', ',', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            StringBuilder sb = new StringBuilder();

            foreach (char c in name.ToArray()) {
                if (goodUrlChar.Any(gc => gc == c)) {
                    sb.Append(c);
                    continue;
                }

                /* 数字及英文字符
                if (c >= 97 && c <= 122 || c >= 65 && c <= 90 || c >= 48 && c <= 57) {
                    sb.Append(c);
                    continue;
                }
                */

                byte[] bytOfChr = System.Text.Encoding.UTF8.GetBytes(new[] {c});
                foreach (byte b in bytOfChr)
                    sb.Append(@"%" + Convert.ToString(b, 16).ToUpper());
            }

            return sb.ToString();
        }

        private void UIInProcess(bool inProcessing) {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            btnCancel.Enabled = inProcessing;
            btnCalculate.Enabled =
                btnCalcRHashExe.Enabled =
                btnClear.Enabled =
                btnClearSource.Enabled =
                btnClearTarget.Enabled =
                txtSource.Enabled =
                txtTarget.Enabled = !inProcessing;
        }

        private string GetTopFileTree(string fileOrPath) {
            if (File.Exists(fileOrPath)) {
                _fileCount++;
                return fileOrPath;
            }

            if (!Directory.Exists(fileOrPath))
                return "";

            //文件夹
            StringBuilder sbFolder = new StringBuilder();
            GetFolderFileTree(ref sbFolder, fileOrPath, 0);
            return sbFolder.ToString();
        }

        private void GetFolderFileTree(ref StringBuilder pInfo, string folder, int spaceCnt) {
            string subSpaceStr = new string(' ', spaceCnt + 1);

            pInfo.AppendLine(new string(' ', spaceCnt) + folder);

            DirectoryInfo di = new DirectoryInfo(folder);

            //递归所有子文件夹
            foreach (DirectoryInfo subFolderInfo in di.GetDirectories())
                GetFolderFileTree(ref pInfo, subFolderInfo.FullName, spaceCnt + 1);

            //文件夹下的所有文件
            foreach (FileInfo fileInfo in di.GetFiles()) {
                _fileCount++;
                pInfo.AppendLine(subSpaceStr + fileInfo.FullName);
            }
        }

        /// <summary>将eMule Link后面的哈希部分值转为大写
        /// </summary>
        /// <param name="rhashResult">RHash Exe Result</param>
        /// <returns></returns>
        private string UpCaseEmuleLinkResult(string rhashResult) {
            if (string.IsNullOrEmpty(rhashResult))
                return "";

            //Hash 及 AICH 部分总长度为 69
            int startIndex = rhashResult.Length - 69;
            return rhashResult.Substring(0, startIndex)
                   + rhashResult.Substring(startIndex).ToUpper().Replace("H=", "h=");
        }
    }
}
