using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string text = this.txtChs.Text;
            if (!string.IsNullOrEmpty(text))
            {
                byte[] bytes = Encoding.Default.GetBytes(text);
                this.txtEnUC.Text = Encoding.GetEncoding(0x4e4).GetString(bytes);
                
                this.txtASCII.Text = Asc(this.txtChs.Text);
            }
        }

        public string Asc(string character)
        {
            string strResult = "";

            if (character.Length > 0)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();

                if (character.Length == 1)
                {
                    int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                    return (intAsciiCode.ToString());
                }
                else
                {
                    foreach (Char chr in this.txtEnUC.Text)
                    {
                        strResult = strResult + ((int)chr).ToString() + " ";
                    }

                    return (strResult);
                }
            }
            else
            {
                return "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "(V " + Application.ProductVersion + ")";
        }
    }

}