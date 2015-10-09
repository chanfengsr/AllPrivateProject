using System;
using System.Windows.Forms;

namespace 汉字机内码高低字节表示
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 汉字机内码高低字节表示());
        }
    }
}
