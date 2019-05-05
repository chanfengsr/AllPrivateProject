using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 记忆训练
{
    public partial class frmShowPicture : Form
    {
        private string _picFileName;
        public frmShowPicture()
        {
            InitializeComponent();
        }

        public frmShowPicture(string picFileName)
        {
            InitializeComponent();
            _picFileName = picFileName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPicture_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_picFileName))
                return;

            //FileStream fs = new FileStream(_picFileName, FileMode.Open);
            Image img = Image.FromFile(_picFileName);
            this.Width = img.Width + 20;
            this.Height = img.Height + 40;
            pictureBox1.Image = img;
        }
    }
}
