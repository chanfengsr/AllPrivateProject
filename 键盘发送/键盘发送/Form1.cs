using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 键盘发送
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendKeys_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            for (int i = 0; i < nudCycles.Value; i++)
            {
                SendKeys.Send(txtSendValue.Text);
                System.Threading.Thread.Sleep((int)(nudDelay.Value * 1000));
            }
        }
    }
}
