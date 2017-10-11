using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool _processCancel;

        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConsoleRedirect.AttachTextBox(this.txtConsole);

            this.Text += "  V" + Application.ProductVersion;
            this.Icon = Resources.Stocks;
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

        private void FileBrowser(Control txtBox)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();

            if (File.Exists(txtBox.Text))
            {
                FileInfo fInfo = new FileInfo(txtBox.Text);
                fileBrowser.InitialDirectory = fInfo.DirectoryName;
                fileBrowser.FileName = fInfo.Name;
            }
            else
            {
                fileBrowser.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }

            if (fileBrowser.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = fileBrowser.FileName;
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
            btnProcCancel.Visible = inProcessing;
            btnClear.Enabled = !inProcessing;
        }

        /// <summary> 加载从通达信导出的数据文件
        /// </summary>
        private string LoadFileList_exportFile()
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


        private string LoadFileList_TDXDayFile(bool isComposite)
        {
            StringBuilder sb = new StringBuilder();
            BLLDataImport bllDaImpt = new BLLDataImport(CommProp.ConnectionString);

            try
            {
                bllDaImpt.OpenConnection();

                AllFile.Clear();
                List<string> lstFullName = bllDaImpt.GetMatchedTDXDayFileFullNameList(isComposite);
                foreach (string fullName in lstFullName)
                {
                    AllFile.Add(new FileInfo(fullName));
                    sb.AppendLine(fullName);
                }
            }
            finally
            {
                bllDaImpt.CloseConnection();
            }

            //一行一行显示文件名
            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray()); ;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnCloseForm.Top = -1000;
            btnProcCancel.Visible = false;

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
        
        private void btnSourceFileBrowser_Click(object sender, EventArgs e)
        {
            FileBrowser(txtSourceFolder);
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

                if (Directory.Exists(folderName) || File.Exists(folderName))
                {
                    var textBox = sender as TextBox;
                    if (textBox != null)
                        textBox.Text = folderName;
                }
            }
        }

        private void dataImptBtnDayKLineImport_Click(object sender, EventArgs e)
        {
            // < 覆盖，指数，TDX文件，K线级别 >
            TupleValue<bool, bool, bool, KLineType> arg = new TupleValue<bool, bool, bool, KLineType>(
                dataImptDayKLineChkConvert.Checked,
                dataImptDayKLineChkIsComposite.Checked,
                dataImptDayKLineChkTDXFile.Checked,
                KLineType.Day);

            bkgDataImport.RunWorkerAsync(arg);
        }

        private void btnProcCancel_Click(object sender, EventArgs e)
        {
            _processCancel = true;
        }
        
        private void bkgDataImport_DoWork(object sender, DoWorkEventArgs e)
        {
            // < 覆盖，指数，TDX文件，K线级别 >
            TupleValue<bool, bool, bool, KLineType> arg = (TupleValue<bool, bool, bool, KLineType>)e.Argument;
            BLLDataImport bllDaImpt = new BLLDataImport(CommProp.ConnectionString);
            bool isConvert = arg.Value1;
            bool isComposite = arg.Value2;
            bool useTDXFile = arg.Value3;
            KLineType kLineType = arg.Value4;

            UIInProcess(true);
            _processCancel = false;

            if (useTDXFile)
                this.LoadFileList_TDXDayFile(isComposite);
            else
                this.LoadFileList_exportFile();

            // List<TupleValue<完整文件名, StockHead>>
            List<TupleValue<string, StockHead>> lstStockData = bllDaImpt.LoadMrkTypeAndCodeFromDataFile(AllFile, isComposite, useTDXFile);

            if (lstStockData.Count > 0)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                
                try
                {
                    bllDaImpt.OpenConnection();
                    int count = lstStockData.Count;
                    int insLineCount=0;
                    string msgString = string.Empty;

                    // 显示百分比提示信息
                    Action<int, int, int> showMsg = ( (per, all, lineCnt) =>
                    {
                        SysFunction.BackspaceInConsole(msgString, txtConsole);
                        msgString = string.Format("{0} / {1}，已导入：{2} 行)", per, all, lineCnt.ToString("N0"));
                        Console.Write(msgString);
                    } );

                    Console.Write("正在导入...（");
                    // 是否需要删表动作，如果表中无记录，则省去 Delete 动作
                    bool haveRecord = bllDaImpt.GetTableRecordCount(BLL.GetKLineDBTableName(kLineType, isComposite)) > 0;
                    for (int i = 0; i < count; i++)
                    {
                        showMsg(i + 1, count, insLineCount);

                        // TupleValue<完整文件名, StockHead>
                        TupleValue<string, StockHead> stkData = lstStockData[i];

                        insLineCount += bllDaImpt.InsertStkKLine(stkData, isConvert, isComposite, useTDXFile, kLineType, haveRecord);
                        
                        // 最后一批完成后，再刷一下
                        if (i == count - 1)
                            showMsg(i + 1, count, insLineCount);

                        if (_processCancel)
                            break;
                    }

                    if (_processCancel)
                        Console.WriteLine("  导入终止！");
                    else
                        Console.WriteLine("  导入完成！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    bllDaImpt.CloseConnection();
                    _processCancel = false;
                    Console.WriteLine("总耗时：{0}", stopWatch.Elapsed);
                }
            }

            UIInProcess(false);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            BLLMetrics bll = new BLLMetrics(CommProp.ConnectionString);
            bll.OpenConnection();
            StringBuilder sb = new StringBuilder();
            const string msgMod = "{0} : {1}";
            Dictionary<DateTime, decimal> mas = bll.CalcAllMA(bll.GetDayCloseValue("600362", false), 453);
            foreach (KeyValuePair<DateTime, decimal> ma in mas)
            {
                sb.AppendLine(string.Format(msgMod, ma.Key.ToShortDateString(), ma.Value.ToString("N3")));
            }
            bll.CloseConnection();
            
            txtConsole.Text = sb.ToString();

        }

        private void dataClearDayBtnKLineTruncate_Click(object sender, EventArgs e)
        {
            BLLClear bllDataClear = new BLLClear(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                if (SysMessageBox.ShowMessage("清空日线数据表，确认？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bllDataClear.OpenConnection();
                    bllDataClear.TruncateStkKLine(KLineType.Day, false);

                    Console.WriteLine("日K线数据清空完成！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDataClear.CloseConnection();
            }
            
            UIInProcess(false);
        }

        private void dataClearBtnDayKLineZSTruncate_Click(object sender, EventArgs e)
        {
            BLLClear bllDataClear = new BLLClear(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                if (SysMessageBox.ShowMessage("清空指数日线数据表，确认？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bllDataClear.OpenConnection();
                    bllDataClear.TruncateStkKLine(KLineType.Day, true);

                    Console.WriteLine("指数日K线数据清空完成！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDataClear.CloseConnection();
            }
            
            UIInProcess(false);
        }

        private void dataClearBtnWeekKLineTruncate_Click(object sender, EventArgs e)
        {
            BLLClear bllDataClear = new BLLClear(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                if (SysMessageBox.ShowMessage("清空周线数据表，确认？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bllDataClear.OpenConnection();
                    bllDataClear.TruncateStkKLine(KLineType.Week);

                    Console.WriteLine("周线数据清空完成！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDataClear.CloseConnection();
            }

            UIInProcess(false);
        }

        private void dataImptBtnBlockImport1_Click(object sender, EventArgs e)
        {
            BLLDataImport bllDaImpt = new BLLDataImport(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                bllDaImpt.OpenConnection();

                bllDaImpt.BlockImport();
                
                Console.WriteLine("导入完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDaImpt.CloseConnection();
            }

            UIInProcess(false);
        }

        private void dataImptBtnStkHeadImport_Click(object sender, EventArgs e)
        {
            BLLDataImport bllDaImpt = new BLLDataImport(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                bllDaImpt.OpenConnection();

                bllDaImpt.ImportStockHead();
                
                Console.WriteLine("执行完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDaImpt.CloseConnection();
            }

            UIInProcess(false);
        }

        private void dataClearBtnStockHeadTruncate_Click(object sender, EventArgs e)
        {
            BLLClear bllDataClear = new BLLClear(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                if (SysMessageBox.ShowMessage("清空代码表头，确认？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bllDataClear.OpenConnection();
                    bllDataClear.TruncateStockHead();

                    Console.WriteLine("代码表头清空完成！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDataClear.CloseConnection();
            }

            UIInProcess(false);
        }

        private void dataImptDayKLineChkIsComposite_CheckedChanged(object sender, EventArgs e)
        {
            if (dataImptDayKLineChkIsComposite.Checked)
            {
                dataImptDayKLineChkConvert.Checked = false;
                dataImptDayKLineChkTDXFile.Checked = true;
            }
        }

        private void dataClearBtnTruncateAllTable_Click(object sender, EventArgs e)
        {
            BLLClear bllDataClear = new BLLClear(CommProp.ConnectionString);
            UIInProcess(true);

            try
            {
                if (SysMessageBox.ShowMessage("将会删除所有表，并收缩数据库。谨慎确认！！！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bllDataClear.OpenConnection();

                    // 删除所有表，并收缩数据库
                    bllDataClear.TruncateAllTable();

                    Console.WriteLine("任务完成！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bllDataClear.CloseConnection();
            }

            UIInProcess(false);
        }
    }
}


/*      计算 简单移动平均线
 
            BLLMetrics bll = new BLLMetrics(CommProp.ConnectionString);
            bll.OpenConnection();
            StringBuilder sb = new StringBuilder();
            const string msgMod = "{0} : {1}";
            Dictionary<DateTime, decimal> mas = bll.CalcAllMA(bll.GetDayCloseValue("SH", "600362"), 5);
            foreach (KeyValuePair<DateTime, decimal> ma in mas)
            {
                sb.AppendLine(string.Format(msgMod, ma.Key.ToShortDateString(), ma.Value));
            }
            bll.CloseConnection();

            txtConsole.Text = sb.ToString();
 */