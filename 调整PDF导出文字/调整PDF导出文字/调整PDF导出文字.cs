using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 调整PDF导出文字
{
    public partial class 调整PDF导出文字 : Form
    {
        public 调整PDF导出文字()
        {
            InitializeComponent();
        }

        /// <summary>预处理字符串
        /// </summary>
        /// <param name="strBeProcess">被处理字符串</param>
        /// <returns></returns>
        private string PretreatmentString(string strBeProcess)
        {
            string retVal = strBeProcess.Replace("@NewLine", Environment.NewLine).Replace("^p", Environment.NewLine);

            return retVal;
        }

        /// <summary>找对应的其实及结束位置
        /// </summary>
        /// <param name="value">被找的字符串</param>
        /// <param name="strFront">开头部分</param>
        /// <param name="strAfter">结束部分</param>
        /// <param name="intStart">起始位置（返回值）</param>
        /// <param name="intLength">长度（返回值）</param>
        /// <returns>是否找到</returns>
        private bool FindStartEndPosition(string value, string strFront, string strAfter, out int intStart, out int intLength)
        {
            if (value.Contains(strFront) && value.Contains(strAfter))
                if (value.IndexOf(strFront) + strFront.Length < value.IndexOf(strAfter))
                {
                    intStart = value.IndexOf(strFront) + strFront.Length;
                    intLength = value.IndexOf(strAfter) - intStart;

                    return true;
                }

            intStart = 0;
            intLength = 0;
            return false;
        }

        /// <summary>
        /// 将结果输出到TextBox2.Text
        /// </summary>
        /// <param name="strNewString"></param>
        private void ToTextBox2(string strNewString)
        {
            if (chkAddRowMod.Checked)
                textBox2.Text = textBox2.Text + Environment.NewLine + strNewString;
            else
                textBox2.Text = strNewString;

            textBox2.SelectAll();
            textBox2.Focus();
        }

        private void ToTextBox2(StringBuilder strBld)
        {
            string str = strBld.ToString();

            if (strBld.Length > 0)
                ToTextBox2(str.Substring(0, str.Length - 1));
            else
                ToTextBox2("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text;
            textBox2.Text = "";

            textBox1.SelectAll();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strRepeat = ("").PadLeft(int.Parse(nudLineNbr.Value.ToString()), '@').Replace("@", Environment.NewLine);
            ToTextBox2(textBox1.Text.Replace(strRepeat, nudLineNbr.Value == 1 ? "" : Environment.NewLine));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string strLine in textBox1.Lines)
                sb.AppendLine(strLine.Trim());

            ToTextBox2(sb);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string strLine in textBox1.Lines)
            {
                if (strLine.Trim().Length > 15)
                {
                    if (strLine.Trim().EndsWith(".")
                        || strLine.Trim().EndsWith("\"")
                        || strLine.Trim().EndsWith("?")
                        || strLine.Trim().EndsWith("。")
                        || strLine.Trim().EndsWith("”")
                        || strLine.Trim().EndsWith("……")
                        || strLine.Trim().EndsWith("？"))
                    {
                        sb.AppendLine(strLine);
                    }
                    else
                    {
                        sb.Append(strLine);
                    }
                }
                else
                {
                    sb.AppendLine(strLine);
                }
            }

            ToTextBox2(sb);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToTextBox2(textBox1.Text.Replace(PretreatmentString(txtOld.Text), PretreatmentString(txtNew.Text)));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox2.Text = "";
            textBox2.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string strHead = chkTrim2.Checked ? txtHead.Text.Trim() : txtHead.Text;

            foreach (string line in textBox1.Lines)
            {
                string strLine = chkTrim2.Checked ? line.Trim() : line;
                if (strLine.StartsWith(strHead))
                    sb.AppendLine(strLine);
            }

            ToTextBox2(sb);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            MatchCollection mc;
            Regex r = new Regex(txtRegex.Text);
            mc = r.Matches(textBox1.Text);

            for (int i = 0; i < mc.Count; i++)
                sb.AppendLine(mc[i].Value);

            ToTextBox2(sb);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtRegex.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string strLine in textBox1.Lines)
                sb.AppendLine(PretreatmentString(txtAddHead.Text) + strLine + PretreatmentString(txtAddEnd.Text));

            ToTextBox2(sb);
        }

        private void Copy2ClipboardRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (rbSplit.Checked)
            {
                txtSplitString.Enabled = true;

                if (txtSplitString.Text == "")
                    txtSplitString.Text = "-";
            }
            else
            {
                txtSplitString.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (rbAll.Checked)
            {
                Clipboard.SetText(textBox2.Text);
                return;
            }

            if (rbRow.Checked)
            {
                if (textBox2.Lines.Length > 0)
                {
                    Clipboard.SetText(textBox2.Lines[0]);

                    if (textBox2.Lines.Length > 1)
                        textBox2.Text = textBox2.Text.Substring(textBox2.Text.IndexOf(Environment.NewLine) + Environment.NewLine.Length, textBox2.Text.Length - textBox2.Text.IndexOf(Environment.NewLine) - Environment.NewLine.Length);
                    else
                        textBox2.Text = "";
                }
                return;
            }

            if (rbSplit.Checked && txtSplitString.Text.Length > 0)
            {
                try
                {
                    char chrSpliter = txtSplitString.Text.ToCharArray()[0];
                    string[] astrSplitStrs = textBox2.Text.Split(chrSpliter);

                    if (astrSplitStrs.Length > 0)
                        Clipboard.SetText(astrSplitStrs[0]);

                    for (int i = 1; i < astrSplitStrs.Length; i++)
                        sb.Append(astrSplitStrs[i] + chrSpliter.ToString());

                    textBox2.Text = sb.ToString().Length > 0 ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();
                }
                catch (Exception) { }

                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string strContain = chkTrim2.Checked ? txtHead.Text.Trim() : txtHead.Text;

            foreach (string line in textBox1.Lines)
            {
                string strLine = chkTrim2.Checked ? line.Trim() : line;

                if (strLine.Contains(strContain))
                    sb.AppendLine(strLine);
            }

            ToTextBox2(sb);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lstTextBox2 = new List<string>();
            foreach (string line in textBox2.Lines)
            {
                string strLine = chkTrim1.Checked ? line.Trim() : line;
                if (!lstTextBox2.Contains(strLine))
                    lstTextBox2.Add(strLine);
            }

            foreach (string line in textBox1.Lines)
            {
                string strLine = chkTrim1.Checked ? line.Trim() : line;
                if (!(lstTextBox2.Contains(strLine) ^ chkHave.Checked))
                    sb.AppendLine(strLine);
            }

            ToTextBox2(sb);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string strLine in textBox1.Lines)
                if (strLine.Trim() != "")
                    sb.AppendLine(strLine);

            ToTextBox2(sb);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            int intStart, intLength;

            foreach (string strLine in textBox1.Lines)
                if (FindStartEndPosition(strLine, txtFront.Text, txtAfter.Text, out intStart, out intLength))
                    if (chkExc.Checked)
                        sb.AppendLine(strLine.Substring(0, intStart) + strLine.Substring(intStart + intLength));
                    else
                        sb.AppendLine(strLine.Substring(intStart, intLength));
                else
                    sb.AppendLine(strLine);

            ToTextBox2(sb);
        }

        private void button14_Click(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();

            foreach (string strLine in textBox1.Lines)
                sb.Append("'" + strLine.Trim() + "',");

            ToTextBox2(sb.ToString().TrimEnd(','));
        }

        private void button15_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") return;

            string strLineHead = "              + \"";
            string strLineEnd = " \" + Environment.NewLine";
            StringBuilder sb = new StringBuilder("string strSql = \"");
            bool isHead = true;

            for (int i = 0; i < textBox1.Lines.Length; i++) {
                string strLine = textBox1.Lines[i].Replace("\\", "\\\\");
                strLine = strLine.Replace("\"", "\\\"");

                if (isHead) {
                    sb.AppendLine(strLine + strLineEnd + (i == textBox1.Lines.Length - 1 ? ";" : ""));
                    isHead = false;
                }
                else {
                    if (i == textBox1.Lines.Length - 1) {
                        sb.Append(strLineHead + strLine + " \";");
                    }
                    else {
                        sb.AppendLine(strLineHead + strLine + strLineEnd);
                    }
                }
            }

            ToTextBox2(sb);
        }


        private void button16_Click(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder("SELECT ");
            int parmId = 1;
            const string parmHd = "@P";

            if (textBox1.Text.Trim() == "") {
                textBox1.Text = "Example:" + Environment.NewLine + "5637144576,N'usmf',N'A0001',0,0,0,5637144576,N'usmf',N'',N'',N'',N'',N'2',N'24',N'',N'',N'',N'',N'Available',N'',N'',N'',N''";
                return;
            }

            foreach (string parm in textBox1.Lines[0].Split(','))
                sb.Append(string.Format("{0}{1} = {2},", parmHd, parmId++, parm));

            textBox2.Text = sb.ToString().TrimEnd(( "," + Environment.NewLine ).ToCharArray());
        }

        private void button17_Click(object sender, EventArgs e) {
            const string parmHd = "@P";

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "") {
                textBox1.Text = "Example:" + Environment.NewLine + "5637144576,N'usmf',N'A0001',0,0,0,5637144576,N'usmf',N'',N'',N'',N'',N'2',N'24',N'',N'',N'',N'',N'Available',N'',N'',N'',N''";
                textBox2.Text = "Example:" + Environment.NewLine + "SELECT SUM(T1.AVAILPHYSICAL),SUM(T1.AVAILORDERED),SUM(T1.RESERVPHYSICAL),SUM(T1.RESERVORDERED),T1.ITEMID,T2.INVENTSITEID,T2.INVENTLOCATIONID,T2.INVENTSTATUSID FROM WHSINVENTRESERVE T1 CROSS JOIN INVENTDIM T2 WHERE (((T1.PARTITION=@P1) AND (T1.DATAAREAID=@P2)) AND ((T1.ITEMID=@P3) AND (((T1.AVAILORDERED>@P4) OR (T1.RESERVPHYSICAL>@P5)) OR (T1.RESERVORDERED>@P6)))) AND (((T2.PARTITION=@P7) AND (T2.DATAAREAID=@P8)) AND ((((((((((((((((T2.CONFIGID=@P9) AND (T2.INVENTSIZEID=@P10)) AND (T2.INVENTCOLORID=@P11)) AND (T2.INVENTSTYLEID=@P12)) AND (T2.INVENTSITEID=@P13)) AND (T2.INVENTLOCATIONID=@P14)) AND (T2.INVENTBATCHID=@P15)) AND (T2.WMSLOCATIONID=@P16)) AND (T2.WMSPALLETID=@P17)) AND (T2.INVENTSERIALID=@P18)) AND (T2.INVENTSTATUSID=@P19)) AND (T2.LICENSEPLATEID=@P20)) AND (T2.INVENTOWNERID_RU=@P21)) AND (T2.INVENTPROFILEID_RU=@P22)) AND (T2.INVENTGTDID_RU=@P23)) AND (T1.INVENTDIMID=T2.INVENTDIMID))) GROUP BY T1.ITEMID,T2.INVENTSITEID,T2.INVENTLOCATIONID,T2.INVENTSTATUSID ORDER BY T1.ITEMID,T2.INVENTSITEID,T2.INVENTLOCATIONID,T2.INVENTSTATUSID";
                return;
            }

            StringBuilder sb = new StringBuilder(textBox2.Text);

            string[] parms = textBox1.Lines[0].Split(',');
            for (int parmId = parms.Length; parmId > 0; parmId--) {
                sb.Replace(parmHd + parmId, parms[parmId-1]);
            }

            textBox2.Text = sb.ToString();
        }

        private void button18_Click(object sender, EventArgs e) {
            textBox2.Text = ChineseConverter.ToSimplified(textBox1.Text);
        }

        private void button19_Click(object sender, EventArgs e) {
            textBox2.Text = ChineseConverter.ToTraditional(textBox1.Text);
        }
    }
}