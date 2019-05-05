using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 记忆训练
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRandNum_Click(null, null);
        }

        private void btnRandNum_Click(object sender, EventArgs e)
        {
            Random rand = new Random(DateTime.Now.GetHashCode());
            int num = rand.Next(0, 110);
            string strNum;
            if (num > 100)
                strNum = "0" + (num - 100).ToString();
            else
                strNum = num.ToString();

            labRandNum.Text = strNum;
        }

        private void btnInfoPic_Click(object sender, EventArgs e)
        {
            string filePath= Environment.CurrentDirectory + "\\Picture\\";
            string strFileName;
            int num;

            if (int.TryParse(labRandNum.Text, out num))
            {
                if (num <= 45)
                    strFileName = filePath + "数字编码0-45.jpg";
                else
                    strFileName = filePath + "数字编码46-99.jpg";
            }
            else
            {
                strFileName = filePath + "26个英语字母编码.jpg";
            }

            frmShowPicture frmPic = new frmShowPicture(strFileName);
            frmPic.ShowDialog(this);
            btnRandNum.Focus();
        }
    }
}
