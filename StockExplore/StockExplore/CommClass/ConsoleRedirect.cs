using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace StockExplore
{
    public static class ConsoleRedirect
    {
        private const int ATTACH_PARENT_PROCESS = -1;

        public static void AttachConsole()
        {
            AttachConsole(-1);
        }

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        public static void AttachTextBox(TextBox txtConsole)
        {
            TextWriter newOut = new TextBoxStreamWriter(txtConsole);
            Console.SetOut(newOut);
        }
    }
}
