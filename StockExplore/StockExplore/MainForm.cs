using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockExplore.Properties;

namespace StockExplore
{
    public partial class MainForm : Form
    {
        private bool _sqlConnect;

        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ConsoleRedirect.AttachTextBox(this.txtConsole);

            this.Text += "  V" + Application.ProductVersion;
            this.Icon = Resources.Stocks;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnCloseForm.Top = -1000;

            CommFunction.LoadAllConfig();

            _sqlConnect = SQLHelper.TestConnectString(CommProp.ConnectionString);
            if (!_sqlConnect)
                SysMessageBox.ErrorMessage("数据库连接错误!", "");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string str = @"r:\SZ#002321.txt";
            StreamReader streamReader = new StreamReader(File.OpenRead(str), Encoding.Default);

            string line;
            while (( line = streamReader.ReadLine() ) != null)
            {
                MessageBox.Show(line);
            }

            streamReader.Close();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
    }
}