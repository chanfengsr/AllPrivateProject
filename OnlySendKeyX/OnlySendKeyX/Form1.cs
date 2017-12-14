using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OnlySendKeyX
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        //定义消息常数 
        public const int CUSTOM_MESSAGE = 0X400 + 2;//自定义消息

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);
        public const int WM_CHAR = 256;
        public const int WM_KEYDOWN = 256;
        public const int WM_KEYUP = 257;

        private IntPtr _windowHandler=IntPtr.Zero;

        //向窗体发送消息的函数 
        public void SendMsgToMainForm(int msg)
        {
            int WINDOW_HANDLER = FindWindow(null, "无标题 - 记事本");
            if (WINDOW_HANDLER == 0)
            {
                throw new Exception("Could not find Main window!");
            }

            //long result = SendMessage(WINDOW_HANDLER, CUSTOM_MESSAGE, new IntPtr(14), IntPtr.Zero).ToInt64();
            SendMessage(WINDOW_HANDLER, 88, new IntPtr(14), IntPtr.Zero);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //SendKeys.Send("X");
            //keybd_event(Keys.X, 0, 0, 0);

            if (_windowHandler == IntPtr.Zero)
                SendKeys.Send("X");
            else
                PostMessage(_windowHandler, WM_CHAR, Keys.X, 1);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int intPtr;
            if (int.TryParse(txtHandle.Text, System.Globalization.NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out intPtr))
                _windowHandler = (IntPtr)intPtr;
            else
                _windowHandler = IntPtr.Zero;

            timer1.Enabled = true;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            IntPtr windowHandler = (IntPtr)FindWindow(null, "无标题 - 记事本");
            int intPtr = int.Parse("00090B18", System.Globalization.NumberStyles.AllowHexSpecifier);

            windowHandler = (IntPtr)0x00090B18;
            //txtHandle.Focus();
            //windowHandler = txtHandle.Handle;
            PostMessage(windowHandler, WM_CHAR, Keys.A, 1);
            PostMessage(windowHandler, WM_CHAR, Keys.A, 2);
        }
    }
}
