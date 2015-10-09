using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace 设置自动关机 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        /// <summary>返回两时间之差
        /// </summary>
        /// <param name="startDateTime">起始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <returns></returns>
        private double GetTimeDiff(DateTime startDateTime, DateTime endDateTime) {
            if (startDateTime > endDateTime)
                return 0;

            TimeSpan ts = endDateTime - startDateTime;
            return ts.TotalSeconds;
        }

        /// <summary>执行DOS命令，返回DOS命令的输出
        /// </summary>
        /// <param name="dosCommand">dosCommand Dos命令语句</param>
        /// <returns></returns>  
        private string Execute(string dosCommand) {
            return Execute(dosCommand, 10);
        }

        /// <summary>执行DOS命令，返回DOS命令的输出
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），  
        /// 如果设定为0，则无限等待</param>  
        /// <returns>返回DOS命令的输出</returns>  
        private string Execute(string command, int seconds) {
            string output = ""; //输出字符串  
            if (command != null && !command.Equals("")) {
                Process process = new Process(); //创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe"; //设定需要执行的命令  
                startInfo.Arguments = "/C " + command; //“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false; //不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false; //不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true; //不创建窗口  
                process.StartInfo = startInfo;
                try {
                    if (process.Start()) //开始进程  
                    {
                        if (seconds == 0) {
                            process.WaitForExit(); //这里无限等待进程结束  
                        }
                        else {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd(); //读取进程的输出  
                    }
                }
                catch {}
                finally {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }

        /// <summary>执行命令关机或重启命令
        /// </summary>
        /// <param name="switchDirection">关机还是重启的开关符</param>
        /// <param name="timeOut">设置关闭前的超时为 timeOut 秒。有效范围是 0-315360000 (10 年)，默认值为 30</param>
        /// <returns></returns>
        private void ExecuteShutdownCommand(string switchDirection, long timeOut = 30) {
            timeOut = timeOut < 0 ? 0 : timeOut;
            timeOut = timeOut > 315360000 ? 315360000 : timeOut;

            CancelShutdown();
            Execute(string.Format("shutdown -{0} -t {1}", switchDirection, timeOut));
        }

        private void CancelShutdown() {
            Execute("shutdown -a");
        }

        /// <summary>得到时间范围
        /// </summary>
        /// <returns></returns>
        private double GetTimeOut() {
            if (rdoLong.Checked)
                return (double)( nHour.Value * 3600 + nMinute.Value * 60 );

            if (rdoTime.Checked)
                return GetTimeDiff(DateTime.Now, dtpDatetime.Value) + 1; //运行时会差一秒

            return 0;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //dtpDatetime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0, 0);
            dtpDatetime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0, 0);
        }

        private void rdoLong_CheckedChanged(object sender, EventArgs e) {
            nHour.Enabled = nMinute.Enabled = true;
            dtpDatetime.Enabled = false;

            btnReboot.Enabled = btnShutdown.Enabled = true;
        }

        private void rdoTime_CheckedChanged(object sender, EventArgs e) {
            dtpDatetime.Enabled = true;
            nHour.Enabled = nMinute.Enabled = false;

            btnReboot.Enabled = btnShutdown.Enabled = true;
        }

        private void btnReboot_Click(object sender, EventArgs e) {
            if (!rdoLong.Checked && !rdoTime.Checked)
                return;

            ExecuteShutdownCommand("r", (long)GetTimeOut());
        }

        private void btnShutdown_Click(object sender, EventArgs e) {
            if (!rdoLong.Checked && !rdoTime.Checked)
                return;

            ExecuteShutdownCommand("s", (long)GetTimeOut());
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            CancelShutdown();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN) {
                if (keyData == Keys.Escape) {
                    this.Close();
                    return false;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}