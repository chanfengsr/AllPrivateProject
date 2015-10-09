using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace GetWords {
    public partial class Form1 : Form {
        private static object locker = new object();
        private readonly List<int> _allNotExistsFileId = new List<int>();
        private int processCnt;

        public Form1() {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //要抓取的URL地址
            string url = "http://ci.cnpoem.net/index.asp?page=1077&cate=&key=";

            //得到指定Url的源码
            string strWebContent = textBox1.Text; // GetWebContent(url);

            //textBox1.Text = strWebContent;

            //取出和数据有关的那段源码  
            int iBodyStart = strWebContent.IndexOf("<body", 0);
            int iStart = strWebContent.IndexOf("请输入搜索关键字", iBodyStart);
            int iTableStart = strWebContent.IndexOf("<table", iStart);
            int iTableEnd = strWebContent.IndexOf("</table>", iTableStart);
            string strWeb = strWebContent.Substring(iTableStart, iTableEnd - iTableStart + 8);

            //生成HtmlDocument  
            WebBrowser webb = new WebBrowser();
            webb.Navigate("about:blank");
            HtmlDocument htmldoc = webb.Document.OpenNew(true);
            htmldoc.Write(strWeb);
            HtmlElementCollection htmlTRs = htmldoc.GetElementsByTagName("TR");

            int i = 0;
            foreach (HtmlElement htmlTR in htmlTRs) {
                foreach (HtmlElement htmlTD in htmlTR.GetElementsByTagName("td")) {
                    HtmlElementCollection htmlA = htmlTD.GetElementsByTagName("a");

                    if (htmlA.Count > 0) {
                        string title = htmlA[0].GetAttribute("title");
                        string word = htmlA[0].InnerText;
                        i++;
                    }
                }
            }

            MessageBox.Show(i.ToString());
            /*
            for (int i = 0; i < 3; i++)
            {
                HtmlElementCollection htmlTD = htmlTR[i].GetElementsByTagName("td");

                for (int j = 0; j < 3; j++)
                {
                    HtmlElementCollection htmlA = htmlTD[j].GetElementsByTagName("a");
                    string title = htmlA[0].GetAttribute("title");
                    string word = htmlA[0].InnerText;
                }
            }
            */
        }

        //根据Url地址得到网页的html源码   
        private static string GetWebContent(string url) {
            string strResult = "";
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); //声明一个HttpWebRequest请求   
                request.Timeout = 30000; //设置连接超时时间   
                request.Headers.Set("Pragma", "no-cache");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                    Stream streamReceive = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding("GB2312");
                    StreamReader streamReader = new StreamReader(streamReceive, encoding);
                    strResult = streamReader.ReadToEnd();
                }
            }
            catch {
                throw;
            }
            return strResult;
        }

        private string GetFileFullName(int fileId) {
            return txtResultFolder.Text + fileId + ".txt";
        }

        private string GetUrlById(int fileId) {
            return string.Format("http://ci.cnpoem.net/index.asp?page={0}&cate=&key=", fileId);
        }

        private void GetAllNotExistsFile() {
            _allNotExistsFileId.Clear();

            const int maxId = 1079; //1079;
            for (int i = 1; i <= maxId; i++)
                _allNotExistsFileId.Add(i);

            for (int i = 1; i <= maxId; i++)
                if (File.Exists(GetFileFullName(i)))
                    _allNotExistsFileId.Remove(i);
        }

        private void button2_Click(object sender, EventArgs e) {
            GetAllNotExistsFile();

            if (_allNotExistsFileId.Count == 0)
                return;

            labAll1.Text = _allNotExistsFileId.Count.ToString();
            labFin1.Text = "0";
            processCnt = 0;

            UIInProcess(true);
            for (int i = 0; i < 5; i++) //i 为需要开的线程数
                new System.Threading.Thread(ThreadProcess).Start();
        }

        private void ThreadProcess() {
            int processFileId;

            while (true) {
                lock (locker) {
                    processFileId = -1;
                    foreach (var item in _allNotExistsFileId) {
                        processFileId = item;
                        _allNotExistsFileId.Remove(item);
                        break;
                    }
                }

                if (processFileId == -1)
                    break;

                try {
                    GetHtml2File(processFileId);
                }
                catch (Exception) {}

                lock (locker) {
                    processCnt++;
                    labFin1.Text = processCnt.ToString();
                }
            }

            if (labFin1.Text == labAll1.Text)
                UIInProcess(false);
        }

        private void GetHtml2File(int fileId) {
            string html = GetWebContent(GetUrlById(fileId));
            File.WriteAllText(GetFileFullName(fileId), html, Encoding.UTF8);
        }

        private void UIInProcess(bool inProcessing) {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;
            tabControl1.Enabled = !inProcessing;
        }

        private void button3_Click(object sender, EventArgs e) {
            Thread t1 = new Thread(() => {
                StringBuilder sb = new StringBuilder();
                DirectoryInfo dirInfo = new DirectoryInfo(txtSourceFolder.Text);

                UIInProcess(true);
                int i = 0;
                foreach (FileInfo fi in dirInfo.GetFiles()) {
                    try {
                        //得到指定Url的源码
                        string strWebContent = File.ReadAllText(fi.FullName);

                        //取出和数据有关的那段源码  
                        int iBodyStart = strWebContent.IndexOf("<body", 0);
                        int iStart = strWebContent.IndexOf("请输入搜索关键字", iBodyStart);
                        int iTableStart = strWebContent.IndexOf("<table", iStart);
                        int iTableEnd = strWebContent.IndexOf("</table>", iTableStart);
                        string strWeb = strWebContent.Substring(iTableStart, iTableEnd - iTableStart + 8);

                        //生成HtmlDocument  
                        WebBrowser webb = new WebBrowser();
                        webb.Navigate("about:blank");
                        HtmlDocument htmldoc = webb.Document.OpenNew(true);
                        htmldoc.Write(strWeb);
                        HtmlElementCollection htmlTRs = htmldoc.GetElementsByTagName("TR");

                        foreach (HtmlElement htmlTR in htmlTRs)
                            foreach (HtmlElement htmlTD in htmlTR.GetElementsByTagName("td")) {
                                HtmlElementCollection htmlA = htmlTD.GetElementsByTagName("a");

                                if (htmlA.Count > 0) {
                                    string title = htmlA[0].GetAttribute("title").Trim().Replace("解释：", "").Replace(Environment.NewLine, " ").Trim();
                                    string word = htmlA[0].InnerText.Replace(Environment.NewLine, " ").Trim();

                                    int iKH = word.IndexOf('(');
                                    if (iKH > 0)
                                        word = word.Substring(0, iKH).Trim();

                                    if (word.Length <= 10 && word.Length > 0)
                                        sb.AppendLine(word + "\t" + title);
                                }
                            }

                        labFin1.Text = ( ++i ).ToString();
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message + "@" + fi.Name);
                    }
                }

                File.WriteAllText(txtResultFolder.Text + "allWords.txt", sb.ToString(), Encoding.UTF8);
                UIInProcess(false);

            });

            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void button4_Click(object sender, EventArgs e) {
            string[][] arr2;
            string[] arr;
            List<string[]> lstArr = new List<string[]>();

            arr = new string[3] {"a", "b", "c"};
            lstArr.Add(arr);
            arr = new string[3] {"d", "e", "f"};
            lstArr.Add(arr);

            arr2 = lstArr.ToArray();

            //return;
            //string a = "李清照( 1900 - 2100)";
            //int iKH = a.IndexOf('(');
            //if (iKH > 0)
            //    a = a.Substring(0,  iKH);
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(100);
            sw.Restart();
            Thread.Sleep(200);
            //sw.Start();
            Thread.Sleep(500);
            MessageBox.Show(sw.Elapsed.ToString() + " " + sw2.IsRunning.ToString());
        }

        private void button5_Click(object sender, EventArgs e) {
            processCnt = 0;

            for (int iThd = 0; iThd < numThreadCnt.Value; iThd++) {
                new Thread(() => {
                    SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=SemanticWeb;Integrated Security=True");
                    StringBuilder sb = new StringBuilder();

                    #region SQL

                    #region 原始SQL语句

                    /*
SELECT TOP 1000 a.Word AS s, c.Word AS p, b.Word AS o
FROM
(SELECT TOP 100 a1.Word FROM (SELECT TOP 1 PERCENT Word FROM Words WHERE [Source] = N'中华诗词网' ORDER BY NEWID()) a1 ) a
CROSS JOIN
(SELECT TOP 100 b1.Word FROM (SELECT TOP 1 PERCENT Word FROM Words WHERE [Source] = 'Excel' ORDER BY NEWID()) b1 ) b
CROSS JOIN
(SELECT TOP 100 c1.Word FROM (SELECT TOP 100 PERCENT * FROM Words WHERE [Type] = 'V' ORDER BY NEWID()) c1 ) c
ORDER BY NEWID()
             */

                    #endregion 原始SQL语句

                    string strSql = "SELECT TOP " + numRecord.Value + " a.Word AS s, c.Word AS p, b.Word AS o" + Environment.NewLine
                                    + "FROM" + Environment.NewLine
                                    + "(SELECT TOP 100 a1.Word FROM (SELECT TOP 1 PERCENT Word FROM Words WHERE [Source] = N'中华诗词网' ORDER BY NEWID()) a1 ) a" + Environment.NewLine
                                    + "CROSS JOIN" + Environment.NewLine
                                    + "(SELECT TOP 100 b1.Word FROM (SELECT TOP 1 PERCENT Word FROM Words WHERE [Source] = 'Excel' ORDER BY NEWID()) b1 ) b" + Environment.NewLine
                                    + "CROSS JOIN" + Environment.NewLine
                                    + "(SELECT TOP 100 c1.Word FROM (SELECT TOP 100 PERCENT * FROM Words WHERE [Type] = 'V' ORDER BY NEWID()) c1 ) c" + Environment.NewLine
                                    + "ORDER BY NEWID()";

                    #endregion SQL

                    try {
                        UIInProcess(true);
                        cnn.Open();

                        for (int i = 0; i < numFile.Value; i++) {
                            sb.Clear();
                            using (DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, cnn)) {
                                if (dt.Rows.Count > 0) {
                                    foreach (DataRow dr in dt.Rows)
                                        sb.AppendLine(dr[0].ToString() + '\t' + dr[1] + '\t' + dr[2]);

                                    File.WriteAllText(txtResultFolder2.Text + Guid.NewGuid().ToString().Substring(0, 8) + ".txt", sb.ToString(), Encoding.UTF8);

                                    lock (locker) {
                                        labCrtdNum.Text = ( ++processCnt ).ToString();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    finally {
                        if (cnn.State != ConnectionState.Closed)
                            cnn.Close();

                        if (numFile.Value * numThreadCnt.Value == processCnt)
                            UIInProcess(false);
                    }
                }).Start();
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            processCnt = 0;

            new Thread(() => {
                SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=SemanticWeb;Integrated Security=True");
                StringBuilder sb = new StringBuilder();

                int rcdCnt = (int)( numFile.Value * numRecord.Value );
                string strSql = "SELECT TOP " + rcdCnt + " * FROM DistinctWords ORDER BY NEWID()";

                try {
                    UIInProcess(true);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(strSql, cnn);
                    cmd.CommandTimeout = 0;

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        int fileNum = 1, recordNum = 1;

                        while (reader.Read()) {
                            sb.AppendLine(reader[0].ToString() + '\t' + reader[1] + '\t' + reader[2]);

                            if (recordNum % numRecord.Value == 0) {
                                File.WriteAllText(txtResultFolder2.Text + fileNum.ToString() + ".txt", sb.ToString(), Encoding.UTF8);
                                sb.Clear();
                                labCrtdNum.Text = ( fileNum++ ).ToString();
                            }

                            recordNum++;
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    if (cnn.State != ConnectionState.Closed)
                        cnn.Close();

                    UIInProcess(false);
                }
            }).Start();
        }

        private void button7_Click(object sender, EventArgs e) {
            StringBuilder finText = new StringBuilder();

            finText.AppendLine("诡域尸咒" + Environment.NewLine
                               + "作者：馨月丶君曦" + Environment.NewLine
                               + "发布网站：http://www.heiyan.com/book/29350/chapter" + Environment.NewLine
                               + Environment.NewLine
                               + "    揭秘国内隐秘事件调查局未公开档案！" + Environment.NewLine
                               + "    我是缝尸匠的后代，五年前，我被人算计缝错了一颗人头，致恶鬼缠身，父亲为了救我，将我送到阴婆的住所，我伴着一盏幽明的人皮灯笼浑浑噩噩的活着。" + Environment.NewLine
                               + "    五年后，当我重见天日，曾经的村子离奇消失，我弟弟和父亲也下落不明，从此邪灵魑魅如影随形。" + Environment.NewLine
                               + "    人皮血衣、冰尸追魂、阴阳沉沙墓……一切诡异的事物接踵而至……每走一步都凶险莫测。" + Environment.NewLine
                               + "    为了活下去，我被迫认了七位师傅，然而这七位师傅却是一个人……" + Environment.NewLine
                               + "    所有的秘密，都指向那个叫归墟的诡域，一切都只是一场阴谋……" + Environment.NewLine
                               + "    归墟：传说为海中无底之谷，谓众水汇聚之处。《列子·汤问》：渤海之东，不知几亿万里﹐有大壑焉﹐实惟无底之谷﹐其下无底﹐名曰归墟。" + Environment.NewLine
                               + Environment.NewLine);

            try {
                this.Cursor = Cursors.WaitCursor;

                //得到指定Url的源码
                string url = "http://www.ziyouge.com/zy/5/5965/index.html";
                string strWebContent = GetWebContent(url); // textBox1.Text;  GetWebContent(url);

                //取出和数据有关的那段源码  
                int iBodyStart = strWebContent.IndexOf("<body", 0);
                int iChapStart = strWebContent.IndexOf("<ul class=\"chapter-list\">", iBodyStart);
                int iChapEnd = strWebContent.IndexOf("</ul>", iChapStart);

                string strWeb = strWebContent.Substring(iChapStart, iChapEnd - iChapStart + 5);

                //生成HtmlDocument  
                WebBrowser webb = new WebBrowser();
                webb.Navigate("about:blank");
                HtmlDocument htmldoc = webb.Document.OpenNew(true);
                htmldoc.Write(strWeb);

                HtmlElementCollection elemLIs = htmldoc.GetElementsByTagName("li");

                //开关，便于增量
                bool getContent = false;
                foreach (HtmlElement elemLI in elemLIs) {
                    if (elemLI.GetAttribute("className") == "volume")
                        finText.AppendLine("@1" + elemLI.InnerText.Trim());
                    else {
                        //起始章节
                        if (!getContent &&  elemLI.InnerText.Trim().StartsWith(txtStartChap.Text))
                            getContent = true;

                        if (!getContent)
                            continue;

                        finText.AppendLine("@2" + procGYSZstring(elemLI.InnerText.Trim(), 0));

                        foreach (HtmlElement elemHref in elemLI.GetElementsByTagName("a")) {
                            finText.AppendLine(getGYSZcontent(elemHref.GetAttribute("pathname").Trim()));
                            finText.AppendLine();
                        }

                        //结束章节
                        if (elemLI.InnerText.Trim().StartsWith(txtEndChap.Text))
                            break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }

            File.WriteAllText(string.Format(@"r:\诡域尸咒 {0}.txt",DateTime.Now.ToString("yyyy-MM-dd")), finText.ToString(), Encoding.UTF8);
        }

        private string getGYSZcontent(string href) {
            string chapContent = string.Empty;
            string url = "http://www.ziyouge.com/zy/5/5965/" + href;
            string strWebContent = GetWebContent(url); // textBox2.Text; 

            int iContentStart = strWebContent.IndexOf("<div id=\"htmlContent\"", 0);
            int iContentEnd = strWebContent.IndexOf("</div>", iContentStart);
            string strWeb = strWebContent.Substring(iContentStart, iContentEnd - iContentStart + 6);

            WebBrowser webb = new WebBrowser();
            webb.Navigate("about:blank");
            HtmlDocument htmldoc = webb.Document.OpenNew(true);
            htmldoc.Write(strWeb);

            HtmlElementCollection elemContents = htmldoc.GetElementsByTagName("div");
            foreach (HtmlElement elemContent in elemContents) {
                chapContent = elemContent.InnerText;
            }

            return procGYSZstring(chapContent, 1)
                .Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine)
                .TrimEnd(Environment.NewLine.ToCharArray())
                .TrimEnd(' ');
        }

        //处理字符串，0:标题，1:文字内容
        private string procGYSZstring(string strValue, int type) {
            if (type == 0) {
                int idxWei = strValue.IndexOf(" 为", StringComparison.Ordinal);
                if (idxWei > 0 && strValue.EndsWith("更"))
                    return strValue.Substring(0, idxWei);
            }

            if (type == 1) {
                return strValue.Replace("本站访问地址http://www.ziyouge.com 任意搜索引擎内输入:紫幽阁 即可访问!", "")
                               .Replace("www.ziyouge.com", "")
                               .Replace("WWw.ZiyoUgE.com", "");
            }

            return strValue;
        }

        private List<string> GetExcludedList() {
            List<string> retVal = new List<string>();
            const string fileName = "GyszExcludedList.txt";

            if (System.IO.File.Exists(fileName))
                retVal.AddRange(System.IO.File.ReadAllLines(fileName).Where(extStr => extStr.Trim() != ""));

            return retVal;
        }

        private void btnGyszGetEndsLst_Click(object sender, EventArgs e) {
            Dictionary<string, int> dicHeadList = new Dictionary<string, int>();
            List<string> lstEnds = new List<string>();
            StringBuilder sb = new StringBuilder();
            List<string> lstExcluded = GetExcludedList();

            Regex r = new Regex(txtGyszReg.Text);
            MatchCollection mc = r.Matches(txtGyszContent.Text);

            foreach (Match match in mc) {
                lstEnds.Add(match.Value);

                if (dicHeadList.ContainsKey(match.Value.Substring(0, 1)))
                    dicHeadList[match.Value.Substring(0, 1)]++;
                else
                    dicHeadList.Add(match.Value.Substring(0, 1), 1);
            }

            foreach (string findEnd in lstEnds.Where(end => dicHeadList.Where(dic => dic.Value > 1)
                                                                       .Select(dic => dic.Key)
                                                                       .ToList()
                                                                       .Contains(end.Substring(0, 1))
                                                                && !lstExcluded.Any(end.StartsWith)
                                                                       )
                                              .OrderBy(end => end)) {
      
                    sb.AppendLine(findEnd);
            }

            txtGyszEndsList.Text = sb.ToString();
        }

        private void btnGyszRemovEnds_Click(object sender, EventArgs e) {
            List<string> lstEnds = ( from end in txtGyszEndsList.Lines where end.Trim().Length > 0 select end.Trim() ).ToList();

            if (lstEnds.Count == 0)
                return;

            StringBuilder sbContent = new StringBuilder(txtGyszContent.Text);
            foreach (string end in lstEnds)
                sbContent.Replace(end, "");

            txtGyszContent.Text = sbContent.ToString();
        }


    }
}