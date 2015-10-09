using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
     
namespace 获取硬件信息示例
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ConvertObjectArray(object obj)
        {
            StringBuilder retVal = new StringBuilder();

            try
            {
                Array ar = (Array)obj;
                
                for (int i = 0; i < ar.Length; i++)
                    retVal.Append(ar.GetValue(0).ToString() + " ; ");
            }
            catch (Exception){}

            return retVal.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int iBreak = 0;
            StringBuilder sb=new StringBuilder();

            txtMsg.Text = "";

            ManagementObjectSearcher moSearcher =
                new ManagementObjectSearcher("select * from " + txtWin32Classes.Text.Trim());

            try
            {
                foreach (ManagementObject mo in moSearcher.Get())
                {
                    iBreak++;

                    sb.AppendLine(mo.ToString());

                    foreach (PropertyData moProp in mo.Properties)
                    {
                        string strName = moProp.Name;
                        string strValue = "";
                            //ConvertObjectArray(PC.Value); //PC.Value == null ? "null" : PC.Value.ToString();

                        if (moProp.Value == null)
                            strValue = "null";
                        else
                        {
                            if (moProp.Value.ToString().StartsWith("System."))
                                strValue = ConvertObjectArray(moProp.Value);
                            else
                                strValue = moProp.Value.ToString();
                        }

                        sb.AppendLine("  " + strName + "：" + strValue);
                    }

                    if (iBreak >= nudCycleNumber.Value) break;
                }

                txtMsg.Text = sb.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnCPUInfo_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject share in searcher.Get())
            {
                txtMsg.AppendText(share.ToString() + Environment.NewLine);

                foreach (PropertyData PC in share.Properties)
                {
                    string strName = PC.Name;
                    string strValue = PC.Value == null ? "null" : PC.Value.ToString();

                    txtMsg.AppendText("  " + strName + "：" + strValue + Environment.NewLine);
                }
            }
        }

        private void btnComputer_Click(object sender, EventArgs e)
        {
            Computer myPC = new Computer();

            txtMsg.AppendText(myPC.ComputerName + Environment.NewLine);
            txtMsg.AppendText(myPC.CpuID + Environment.NewLine);
            txtMsg.AppendText(myPC.DiskID + Environment.NewLine);
            txtMsg.AppendText(myPC.IpAddress + Environment.NewLine);
            txtMsg.AppendText(myPC.LoginUserName + Environment.NewLine);
            txtMsg.AppendText(myPC.MacAddress + Environment.NewLine);
            txtMsg.AppendText(myPC.SystemType + Environment.NewLine);
            txtMsg.AppendText(myPC.TotalPhysicalMemory + Environment.NewLine);
        }

        private void lstWin32Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWin32Classes.Text = lstWin32Classes.SelectedItem.ToString();
        }
    }
}
