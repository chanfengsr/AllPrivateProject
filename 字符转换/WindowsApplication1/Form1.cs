using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string text = this.txtChs.Text;
            if (!string.IsNullOrEmpty(text))
            {
                byte[] bytes = Encoding.Default.GetBytes(text);
                this.txtEnUC.Text = Encoding.GetEncoding("Windows-1252").GetString(bytes);

                this.txtASCII.Text = Asc(this.txtChs.Text);
            }
        }

        private void btnReverseConvert_Click(object sender, EventArgs e)
        {
            string text = this.txtEnUC.Text;
            if (!string.IsNullOrEmpty(text))
            {
                byte[] bytes = Encoding.GetEncoding("Windows-1252").GetBytes(text);// Encoding.Default.GetBytes(text);
                this.txtChs.Text = Encoding.Default.GetString(bytes);//Encoding.GetEncoding("").GetString(bytes);

                this.txtASCII.Text = Asc(this.txtChs.Text);
            }
        }

        public string Asc(string character)
        {
            string strResult = "";

            if (character.Length > 0)
            {
                foreach (Char chr in this.txtEnUC.Text)
                    strResult = strResult + ((int)chr).ToString() + " ";

                return (strResult);
            }

            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "(V " + Application.ProductVersion + ")";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //int ii = 0x4e4;
            //MessageBox.Show(ii.ToString());
            //return;

            byte[] bytesLM = Encoding.Default.GetBytes("中文ABCabc");
            string strLM = Encoding.GetEncoding("Windows-1252").GetString(bytesLM);
            byte[] bytes = Encoding.Default.GetBytes(strLM);

  
            Dictionary<int, string> dic = new Dictionary<int, string>();

            //foreach (string str in new string[] { "IBM037", "IBM437", "IBM500", "ASMO-708", "DOS-720", "ibm737", "ibm775", "ibm850", "ibm852", "IBM855", "ibm857", "IBM00858", "IBM860", "ibm861", "DOS-862", "IBM863", "IBM864", "IBM865", "cp866", "ibm869", "IBM870", "windows-874", "cp875", "shift_jis", "gb2312", "ks_c_5601-1987", "big5", "IBM1026", "IBM01047", "IBM01140", "IBM01141", "IBM01142", "IBM01143", "IBM01144", "IBM01145", "IBM01146", "IBM01147", "IBM01148", "IBM01149", "utf-16", "unicodeFFFE", "windows-1250", "windows-1251", "Windows-1252", "windows-1253", "windows-1254", "windows-1255", "windows-1256", "windows-1257", "windows-1258", "Johab", "macintosh", "x-mac-japanese", "x-mac-chinesetrad", "x-mac-korean", "x-mac-arabic", "x-mac-hebrew", "x-mac-greek", "x-mac-cyrillic", "x-mac-chinesesimp", "x-mac-romanian", "x-mac-ukrainian", "x-mac-thai", "x-mac-ce", "x-mac-icelandic", "x-mac-turkish", "x-mac-croatian", "x-Chinese-CNS", "x-cp20001", "x-Chinese-Eten", "x-cp20003", "x-cp20004", "x-cp20005", "x-IA5", "x-IA5-German", "x-IA5-Swedish", "x-IA5-Norwegian", "us-ascii", "x-cp20261", "x-cp20269", "IBM273", "IBM277", "IBM278", "IBM280", "IBM284", "IBM285", "IBM290", "IBM297", "IBM420", "IBM423", "IBM424", "x-EBCDIC-KoreanExtended", "IBM-Thai", "koi8-r", "IBM871", "IBM880", "IBM905", "IBM00924", "EUC-JP", "x-cp20936", "x-cp20949", "cp1025", "koi8-u", "iso-8859-1", "iso-8859-2", "iso-8859-3", "iso-8859-4", "iso-8859-5", "iso-8859-6", "iso-8859-7", "iso-8859-8", "iso-8859-9", "iso-8859-13", "iso-8859-15", "x-Europa", "iso-8859-8-i", "iso-2022-jp", "csISO2022JP", "iso-2022-jp", "iso-2022-kr", "x-cp50227", "euc-jp", "EUC-CN", "euc-kr", "hz-gb-2312", "GB18030", "x-iscii-de", "x-iscii-be", "x-iscii-ta", "x-iscii-te", "x-iscii-as", "x-iscii-or", "x-iscii-ka", "x-iscii-ma", "x-iscii-gu", "x-iscii-pa", "utf-7", "utf-8", "utf-32", "utf-32BE" })
            //{
            //    dic.Add(str, Encoding.GetEncoding(str).GetString(bytes));
            //}
            string txt = Encoding.GetEncoding("UTF-8").GetString(bytes);

            foreach (int i in new int[] { 37, 437, 500, 708, 720, 737, 775, 850, 852, 855, 857, 858, 860, 861, 862, 863, 864, 865, 866, 869, 870, 874, 875, 932, 936, 949, 950, 1026, 1047, 1140, 1141, 1142, 1143, 1144, 1145, 1146, 1147, 1148, 1149, 1200, 1201, 1250, 1251, 1252, 1253, 1254, 1255, 1256, 1257, 1258, 1361, 10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 10010, 10017, 10021, 10029, 10079, 10081, 10082, 20000, 20001, 20002, 20003, 20004, 20005, 20105, 20106, 20107, 20108, 20127, 20261, 20269, 20273, 20277, 20278, 20280, 20284, 20285, 20290, 20297, 20420, 20423, 20424, 20833, 20838, 20866, 20871, 20880, 20905, 20924, 20932, 20936, 20949, 21025, 21866, 28591, 28592, 28593, 28594, 28595, 28596, 28597, 28598, 28599, 28603, 28605, 29001, 38598, 50220, 50221, 50222, 50225, 50227, 51932, 51936, 51949, 52936, 54936, 57002, 57003, 57004, 57005, 57006, 57007, 57008, 57009, 57010, 57011, 65000, 65001, 65005, 65006 })
            {
                try
                {
                    dic.Add(i, Encoding.GetEncoding(i).GetString(bytes));
                }
                catch (Exception) { }
            }

            dic.Clear();
        }
    }
}