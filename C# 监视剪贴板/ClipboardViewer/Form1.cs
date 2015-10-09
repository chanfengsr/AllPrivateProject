using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClipboardViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern IntPtr SetClipboardViewer(IntPtr hwnd);
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern IntPtr ChangeClipboardChain(IntPtr hwnd, IntPtr hWndNext);
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        const int WM_DRAWCLIPBOARD = 0x308;
        const int WM_CHANGECBCHAIN = 0x30D;
        IntPtr NextClipHwnd;//观察链中下一个窗口句柄	

        string strPrev = "";
        bool blnHave = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //获得观察链中下一个窗口句柄
            NextClipHwnd = SetClipboardViewer(this.Handle);

            textBox2.Text = "";
            strPrev = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //从观察链中删除本观察窗口
            ChangeClipboardChain(this.Handle, NextClipHwnd);

            //将WM_DRAWCLIPBOARD消息传递到下一个观察链中的窗口	
            SendMessage(NextClipHwnd, WM_CHANGECBCHAIN, this.Handle, NextClipHwnd);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    string strClipboardString = "";

                    //将WM_DRAWCLIPBOARD消息传递到下一个观察链中的窗口
                    //SendMessage(NextClipHwnd, m.Msg, m.WParam, m.LParam);

                    IDataObject iData = Clipboard.GetDataObject();
                    if (iData.GetDataPresent(DataFormats.Text) | iData.GetDataPresent(DataFormats.OemText))
                    {
                        strClipboardString = (String)iData.GetData(DataFormats.Text);

                        blnHave = textBox2.Text.Contains(strClipboardString) ? true : false;
                        labHave.Text = blnHave ? "有" : "无";

                        if (chkActive.Checked)
                            textBox1.Text = strClipboardString;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != strPrev)
            {
                strPrev = textBox1.Text;

                if (chkActive.Checked)
                {
                    if (chkRegex.Checked)
                    {
                        StringBuilder sb = new StringBuilder();

                        MatchCollection mc;
                        Regex r = new Regex(txtRegex.Text);
                        mc = r.Matches(textBox1.Text);

                        for (int i = 0; i < mc.Count; i++)
                            if (!chkNoneAdd.Checked || (chkNoneAdd.Checked && !textBox2.Text.Contains(mc[i].Value)))
                                sb.AppendLine(mc[i].Value);

                        textBox2.AppendText(sb.ToString());
                    }
                    else
                    {
                        if (!chkNoneAdd.Checked || (chkNoneAdd.Checked && !blnHave))
                            textBox2.AppendText(strPrev + Environment.NewLine);
                    }
                }
            }
        }

        private void llabClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            //txtRegex.Text = "";
        }

        private void llabAddNoneLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StringBuilder sb = new StringBuilder(textBox2.Text);

            foreach (string strLine in textBox1.Lines)
                if (!sb.ToString().Contains(strLine.Trim()))
                    sb.AppendLine(strLine.Trim());

            textBox2.Text = sb.ToString();
        }

        private void llabClearRegex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtRegex.Text = "";
        }

    }
}