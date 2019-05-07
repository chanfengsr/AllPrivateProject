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
# if DEBUG
            btnTest.Visible = true;
# endif

            labRandNum.Text = GetRandNumText();
            Fill40Num();
        }

        private readonly Random _rand = new Random(DateTime.Now.GetHashCode());

        /// <summary>
        /// 获得随机数字符（0 - 100，01，02...09）
        /// 纯一位数：GetRandNumText(0, 10)
        /// 纯两位数：GetRandNumText(10, 110, 100)
        /// </summary>
        /// <param name="min">起始数</param>
        /// <param name="max">结尾数</param>
        /// <param name="exp">排除数</param>
        /// <returns></returns>
        private string GetRandNumText(int min = 0, int max = 110, int exp = int.MinValue)
        {
            int num = _rand.Next(min, max);
            while (num == exp)
                num = _rand.Next(min, max);

            string strNum;
            if (num > 100)
                strNum = "0" + ( num - 100 );
            else
                strNum = num.ToString();

            return strNum;
        }

        private List<Label> _lstLabel = new List<Label>();

        private void Fill40Num()
        {
            if (_lstLabel.Count == 0)
            {
                for (int i = 0; i < 40; i++)
                {
                    Label lab = new Label();
                    lab.Text = GetRandNumText(0, 10);
                    lab.TextAlign = ContentAlignment.MiddleCenter;
                    lab.Dock = DockStyle.Fill;
                    lab.Font = new Font("宋体", 30F, FontStyle.Regular, GraphicsUnit.Point, ( (byte)( 134 ) ));
                    _lstLabel.Add(lab);
                    tableLayoutPanel1.Controls.Add(lab);
                }
            }
            else
            {
                foreach (Label lab in _lstLabel)
                    lab.Text = GetRandNumText(0, 10);
            }
        }

        private void btnRandNum_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    labRandNum.Text = GetRandNumText();
                    break;
                case 1:
                    Fill40Num();
                    break;
            }
        }

        private void btnInfoPic_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\Picture\\";
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            Label lab = new Label();
            lab.Text = "0";
            lab.TextAlign = ContentAlignment.MiddleCenter;
            lab.Dock = DockStyle.Fill;
            lab.Font = new Font("宋体", 25F, FontStyle.Regular, GraphicsUnit.Point, ( (byte)( 134 ) ));
            tableLayoutPanel1.Controls.Add(lab);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            btnRandNum.Select();
            btnRandNum.Focus();
        }
    }
}