using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ModifyFileTime
{
    public partial class Form1 : Form
    {
        DateTime dtCreationTime = new DateTime();
        DateTime dtLastWriteTime = new DateTime();
        DateTime dtLastAccessTime = new DateTime();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(textFile.Text))
                {
                    System.IO.File.SetLastWriteTimeUtc(textFile.Text, DateTime.Now);

                    try
                    {
                        if (chkSetCreationTime.Checked)
                        {
                            System.IO.File.SetCreationTime(textFile.Text, dtpDateTime.Value);
                        }
                        else
                        {
                            System.IO.File.SetCreationTime(textFile.Text, dtCreationTime);
                        }

                        if (chkSetLastWriteTime.Checked)
                        {
                            System.IO.File.SetLastWriteTime(textFile.Text, dtpDateTime.Value);
                        }
                        else
                        {
                            System.IO.File.SetLastWriteTime(textFile.Text, dtLastWriteTime);
                        }

                        if (chkSetLastAccessTime.Checked)
                        {
                            System.IO.File.SetLastAccessTime(textFile.Text, dtpDateTime.Value);
                        }
                        else
                        {
                            System.IO.File.SetLastAccessTime(textFile.Text, dtLastAccessTime);
                        }

                        RefreshFileInfo();

                        MessageBox.Show("设置完成！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("文件不存在！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog FileDlg = new OpenFileDialog();

                FileDlg.Filter = "All Files|*.*";

                if (FileDlg.ShowDialog() == DialogResult.OK)
                {
                    textFile.Text = FileDlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " (V " + Application.ProductVersion + ")";

            dtpDateTime.Value = DateTime.Now;
        }

        private void textFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(textFile.Text))
                {
                    RefreshFileInfo();
                }
                else
                {
                    lblCreationTime.Text = "";
                    lblLastWriteTime.Text = "";
                    lblLastAccessTime.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 刷新文件的原始信息
        /// </summary>
        private void RefreshFileInfo()
        {
            try
            {
                if (System.IO.File.Exists(textFile.Text))
                {
                    System.IO.FileInfo filoInfo = new System.IO.FileInfo(textFile.Text);
                    lblCreationTime.Text = filoInfo.CreationTime.ToString();
                    lblLastWriteTime.Text = filoInfo.LastWriteTime.ToString();
                    lblLastAccessTime.Text = filoInfo.LastAccessTime.ToString();

                    dtCreationTime = filoInfo.CreationTime;
                    dtLastWriteTime = filoInfo.LastWriteTime;
                    dtLastAccessTime = filoInfo.LastAccessTime;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}