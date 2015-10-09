using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StatisticsCPUUsage {
    public class GlobalDef {
        public const int USER = 0x0400;
        public const int WM_AutoRun = USER + 101;
    }

    internal static class Program {
        private const int WS_SHOWNORMAL = 1;

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 窗体焦点
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32.dll ", SetLastError = true)]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        /// 显示窗体,同  ShowWindowAsync 差不多
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_RESTORE = 9;

        /// <summary>
        /// 枚举窗体
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern int EnumWindows(CallBack x, int y);
        private delegate bool CallBack(IntPtr hwnd, int lParam);

        /// <summary>
        /// 根据窗体句柄获得其进程ID
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);




        /// <summary>
        /// 根据窗体句柄获得窗体标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpText"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpText, int nCount);

        /// <summary>
        ///     Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        static uint SWP_NOSIZE = 0x0001;
        static int HWND_TOP = 0;
        public struct Rect {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);


        private static Process pro = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args) {
            //Get the running instance.  
            Process instance = RunningInstance();
            pro = instance;
            bool isAutoRun = args.Length > 0 && args[0].ToLower() == "/auto";

            if (instance == null) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(isAutoRun));
            }
            else {
                //There is another instance of this process.  
                HandleRunningInstance(instance, isAutoRun);
            }
        }


        public static Process RunningInstance() {

            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop through the running processes in with the same name  
            foreach (Process process in processes) {
                //Ignore the current process  
                if (process.Id != current.Id) {
                    //Make sure that the process is running from the exe file.  

                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName) {
                        //Return the other process instance.  
                        return process;
                    }
                }
            }
            //No other instance was found, return null.
            return null;
        }

        public static void HandleRunningInstance(Process instance, bool isAutoRun) {
            IntPtr findHandle = FindWindow(null, instance.ProcessName);
            MessageBox.Show(
                findHandle.ToString() + "  " + instance.MainWindowHandle+ "  " +instance.ProcessName
                );
            
            if (instance.MainWindowHandle != IntPtr.Zero) {
                //Make sure the window is not minimized or maximized  
                ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
                //Set the real intance to foreground window
                SetForegroundWindow(instance.MainWindowHandle);
            }
            else if (!isAutoRun) {
                CallBack myCallBack = Report;
                EnumWindows(myCallBack, 0);
                //SendMessage(instance.MainWindowHandle, GlobalDef.USER, IntPtr.Zero, IntPtr.Zero);
            }
        }

        private static bool Report(IntPtr hwnd, int lParam) {
            string[] formName = new[] { "StatisticsCPUUsage" };

            //获得窗体标题
            StringBuilder sb = new StringBuilder(100);
            GetWindowText(hwnd, sb, sb.Capacity);

            int calcID;
            //获取进程ID   
            GetWindowThreadProcessId(hwnd, out calcID);
            MessageBox.Show(calcID.ToString());
            for (int i = 0; i < formName.Length; i++) {
                if ((sb.ToString() == formName[i]) && (pro != null) && (calcID == pro.Id)) //标题栏、进程id符合
                {
                    ShowWindow(hwnd, SW_RESTORE);
                    SwitchToThisWindow(hwnd, true);

                    Rect windowRec;
                    GetWindowRect(hwnd, out windowRec);
                    MessageBox.Show(windowRec.ToString());

                    return true;
                }
            }
            //else
            return true;


            MessageBox.Show(
                string.Format("{0}:{1}", hwnd, lParam)
                );

            return true;
        }
    }
}