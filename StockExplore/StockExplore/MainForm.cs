using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StockExplore.Properties;

namespace StockExplore
{
    public partial class MainForm : Form
    {
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
            LoadConfig();

            new Thread(() =>
            {
                if (!SQLHelper.TestConnectString(CommProp.ConnectionString))
                    Console.WriteLine("数据库连接错误!");
            }).Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
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

        private void btnSourceFolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowser(txtSourceFolder);
        }

        private void txtFileFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void txtFileFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array ary = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (ary.Length == 0)
                    return;

                string folderName = ary.GetValue(0).ToString();

                if (Directory.Exists(folderName))
                {
                    var textBox = sender as TextBox;
                    if (textBox != null)
                        textBox.Text = folderName;
                }
            }
        }

        private void FolderBrowser(Control txtBox)
        {
            if (Directory.Exists(txtBox.Text))
                folderBrowserDialog.SelectedPath = txtBox.Text;
            else
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                txtBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void LoadConfig()
        {
            try
            {
                CommFunction.LoadAllConfig();
                txtSourceFolder.Text = CommProp.SourceFolder;
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void SaveConfig()
        {
            try
            {
                SysConfig.WriteConfigData("AppConfig", "SourceFolder", txtSourceFolder.Text);
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }
        }

        private void UIInProcess(bool inProcessing)
        {
            this.Cursor = inProcessing ? Cursors.WaitCursor : Cursors.Default;

            //grpFunction.Enabled = !inProcessing;
        }
        
    }
}