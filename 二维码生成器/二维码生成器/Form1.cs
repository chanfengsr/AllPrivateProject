/*
 http://www.qrstuff.com/
 http://www.qrstuff.com/generate.generate?type=TEXT&text={0}&foreground_color=000000
 http://qrcode.kaywa.com/
 http://www.liuhuadong.com/labs/2weima/index.php
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using com.google.zxing;
using com.google.zxing.qrcode;
using com.google.zxing.common;

namespace 显示二维码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = this.Text + "  V" + Application.ProductVersion + "  ——by 巉沨散人（chanfengsr@yahoo.com.cn）";
        }

        private void CreateQRCodeByGoogleAPI()
        {
            string _strGoogleAPIURL1 = @"http://chart.apis.google.com/chart?cht=qr&chs=";
            string _strGoogleAPIURL2 = @"&chl=";
            string _strGoogleAPIURL3 = @"&choe=UTF-8";
            string _strSpaceCode = @"%20";

            string strCodePicLocation = _strGoogleAPIURL1;

            //尺寸
            if (rdbManualSize.Checked)
                strCodePicLocation += nudManualSize.Value.ToString() + "x" + nudManualSize.Value.ToString(); //txtManualSize.Text.Trim();
            else
                foreach (Control ctrl in grpSize.Controls)
                    if (ctrl is RadioButton)
                        if ((ctrl as RadioButton).Checked)
                        {
                            strCodePicLocation += (ctrl as RadioButton).Text.Trim();
                            break;
                        }

            //文本
            strCodePicLocation += _strGoogleAPIURL2 + txtText.Text.Trim();
            strCodePicLocation += _strGoogleAPIURL3;

            picCode.ImageLocation = "";
            picCode.ImageLocation = strCodePicLocation;
            picCode.Refresh();
        }

        private void CreateQRCodeByZXingAPI()
        {
            int intWidth=300;
            ByteMatrix byteMatrix;

            if (rdbManualSize.Checked)
                intWidth = (int)nudManualSize.Value;
            else if (rdb80.Checked)
                intWidth = 80;
            else if (rdb100.Checked)
                intWidth = 100;
            else if (rdb125.Checked)
                intWidth = 125;
            else if (rdb200.Checked)
                intWidth = 200;
            else if (rdb250.Checked)
                intWidth = 250;
            else if (rdb300.Checked)
                intWidth = 300;
            else if (rdb400.Checked)
                intWidth = 400;
            else if (rdb500.Checked)
                intWidth = 500;

            try
            {
                byteMatrix = new MultiFormatWriter().encode(txtText.Text, BarcodeFormat.QR_CODE, intWidth, intWidth);
                picCode.Image = byteMatrix.ToBitmap();
            }
            catch (Exception)
            {
                picCode.Image = picCode.ErrorImage;
            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(picCode.Image, 0, 0);
        }

        private void chkWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            txtText.WordWrap = chkWordWrap.Checked;
        }

        private void btnCreateQRCode_Click(object sender, EventArgs e)
        {
            if (rdbZXingAPI.Checked)
                CreateQRCodeByZXingAPI();
            else if (rdbGoogleAPI.Checked)
                CreateQRCodeByGoogleAPI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picCode.Image != null)
            {
                saveFileDialog1.Filter = "PNG文件|*.png";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    picCode.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (picCode.Image != null)
            {
                printDialog1.Document = new System.Drawing.Printing.PrintDocument();
                printDialog1.Document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

                if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    printDialog1.Document.Print();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Text = "";

            picCode.Image = null;
            picCode.Refresh();

            txtText.Focus();
        }

        private void rdbtnManualSize_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManualSize.Checked)
                nudManualSize.Visible = true;
            else
                nudManualSize.Visible = false;
        }
    }
}
