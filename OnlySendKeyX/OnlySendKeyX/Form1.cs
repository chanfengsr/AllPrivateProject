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

        private IntPtr _windowHandler = IntPtr.Zero;

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

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
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void btnStartMouseKey_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            btnStartMouseKey.Enabled = false;
            btnStopMouseKey.Enabled = true;
        }

        private void btnStopMouseKey_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            btnStartMouseKey.Enabled = true;
            btnStopMouseKey.Enabled = false;
        }
    }
}
