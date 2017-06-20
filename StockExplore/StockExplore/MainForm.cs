using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StockExplore.Properties;

namespace StockExplore
{
    public partial class MainForm : Form
    {
        protected readonly List<FileInfo> AllFile = new List<FileInfo>();

        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConsoleRedirect.AttachTextBox(this.txtConsole);

            this.Text += "  V" + Application.ProductVersion;
            this.Icon = Resources.Stocks;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnCloseForm.Top = -1000;
            LoadConfig();

            new Thread(() =>
            {
                if (!SQLHelper.TestConnectString(CommProp.ConnectionString))
                    Console.WriteLine("数据库连接错误!");
            }).Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            /*
            string str = @"r:\SZ#002321.txt";
            StreamReader streamReader = new StreamReader(File.OpenRead(str), Encoding.Default);

            string line;
            while (( line = streamReader.ReadLine() ) != null)
            {
                MessageBox.Show(line);
            }

            streamReader.Close();
             */

            string str = this.LoadFileList();
            Console.WriteLine(str);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

        private void btnSourceFolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowser(txtSourceFolder);
        }

        private void txtFileFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void txtFileFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (ary.Length == 0)
                    return;

                string folderName = ary.GetValue(0).ToString();

                if (Directory.Exists(folderName))
                {
                    var textBox = sender as TextBox;
                    if (textBox != null)
                        textBox.Text = folderName;
                }
            }
        }

        private void dataImptDayKLineBtnImport_Click(object sender, EventArgs e)
        {
            TupleValue<bool, bool, KLineType> arg = new TupleValue<bool, bool, KLineType>(dataImptDayKLineChkConvert.Checked, dataImptDayKLineChkIsComposite.Checked, KLineType.Day);
            bkgDataImport.RunWorkerAsync(arg);
        }

        private void bkgDataImport_DoWork(object sender, DoWorkEventArgs e)
        {
            TupleValue<bool, bool, KLineType> arg = (TupleValue<bool, bool, KLineType>)e.Argument;
            BLLDataImport bll = new BLLDataImport(CommProp.ConnectionString);
            bool isConvert = arg.Value1;
            bool isComposite = arg.Value2;

            UIInProcess(true);

            this.LoadFileList();

            List<TupleValue<FileInfo, StockHead>> lstStockData = bll.LoadMrkTypeAndCode(AllFile);

            if (lstStockData.Count > 0)
            {
                try
                {
                    bll.OpenConnection();
                    int count = lstStockData.Count;
                    string msgString = string.Empty;

                    Console.Write("正在导入...（");
                    for (int i = 0; i < count; i++)
                    {
                        TupleValue<FileInfo, StockHead> stkData = lstStockData[i];

                        SysFunction.BackspaceInConsole(msgString, txtConsole);
                        msgString = string.Format("{0} / {1})", i + 1, count);
                        Console.Write(msgString);
                        bll.InsertStkKLine(stkData, isConvert, isComposite, arg.Value3);
                        
                        // todo delete this
                        Thread.Sleep(100);
                    }

                    Console.WriteLine("  导入完成！");
                }
                finally
                {
                    bll.CloseConnection();
                }
            }

            UIInProcess(false);
        }

        private void FolderBrowser(Control txtBox)
        {
            if (Directory.Exists(txtBox.Text))
                folderBrowserDialog.SelectedPath = txtBox.Text;
            else
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void LoadConfig()
        {
            try
            {
                CommFunction.LoadAllConfig();
                txtSourceFolder.Text = CommProp.SourceFolder;
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
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void UIInProcess(bool inProcessing)
        {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            tabControl1.Enabled = !inProcessing;
        }

        private string LoadFileList()
        {
            string retVal = string.Empty;
            string sourceFolder = txtSourceFolder.Text;

            if (Directory.Exists(sourceFolder))
            {
                AllFile.Clear();
                DirectoryInfo dicInfo = new DirectoryInfo(sourceFolder);

                foreach (FileInfo fileInfo in dicInfo.GetFiles())
                {
                    //隐藏文件和系统文件就不要过来凑热闹了
                    if ( /*( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden || */
                        ( fileInfo.Attributes & FileAttributes.System ) == FileAttributes.System)
                        continue;

                    AllFile.Add(fileInfo);
                }

                //一行一行显示文件名
                retVal = CommFunction.StringList2String(AllFile.Select(f => f.FullName).ToList());
            }
            else
            {
                CommFunction.WriteMessage("文件夹不存在！");
            }

            return retVal;
        }

    }
}