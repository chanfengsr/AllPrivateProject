using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

/*
内网
Index：7  本地连接     实体
Index：17 本地连接 5

外网
Index：10 本地连接 2   实体
Index：15 本地连接 4
 */

namespace SetNetworkAdapter
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
                Array ar = (Array) obj;

                for (int i = 0; i < ar.Length; i++)
                    retVal.Append(ar.GetValue(0).ToString() + " ; ");
            }
            catch (Exception)
            {
            }

            return retVal.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ManagementObjectSearcher moSearcher =
                new ManagementObjectSearcher("select * from Win32_NetworkAdapter where DeviceID = 17");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                MessageBox.Show(mo.Properties["NetConnectionID"].Value.ToString() + @":" +
                                mo.Properties["DeviceID"].Value.ToString());

                MessageBox.Show(mo.Path.ToString());
                //mo.SetPropertyValue("NetEnabled",false);
                //mo.InvokeMethod("Enable", null);
            }



            /*
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (mo.Properties["NetConnectionID"].Value != null)
                    if (mo.Properties["NetConnectionID"].Value.ToString() == "本地连接 5")
                        MessageBox.Show("Find");
            }
            */

            this.Cursor = Cursors.Default;
        }

        private void btnShowWMIInfo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            StringBuilder sb = new StringBuilder();
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where PhysicalAdapter = True");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                sb.AppendLine(mo.ToString());

                foreach (PropertyData moProp in mo.Properties)
                {
                    string strName = moProp.Name;
                    string strValue = "";

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

                sb.AppendLine();
            }

            txtMsg.Text = sb.ToString();

            this.Cursor = Cursors.Default;
        }

        private void btnOutInner_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //开内网
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 7");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 17");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            //开外网
            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 10");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 15");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            this.Cursor = Cursors.Default;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //关内网
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 17");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Disable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 7");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Disable", null);

            //开外网
            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 10");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 15");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            this.Cursor = Cursors.Default;
        }

        private void btnInner_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //开内网
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 7");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 17");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Enable", null);

            //关外网
            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 15");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Disable", null);

            moSearcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Index = 10");
            foreach (ManagementObject mo in moSearcher.Get())
                mo.InvokeMethod("Disable", null);

            this.Cursor = Cursors.Default;
        }
    }
}
