using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockExplore
{
    public partial class MainForm : Form
    {
        private bool sqlConnect;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CommFunction.LoadAllConfig();

            sqlConnect = SQLHelper.TestConnectString(CommProp.ConnectionString);
            if (!sqlConnect)
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
    }
}