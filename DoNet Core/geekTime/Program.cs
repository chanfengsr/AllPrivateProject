using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace geekTime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstFileName = new List<string>();

            DirectoryInfo dirInfo = new DirectoryInfo(System.Environment.CurrentDirectory);

            foreach(FileInfo file in dirInfo.GetFiles()) 
            {
                if (file.FullName.EndsWith(".ts"))
                    lstFileName.Add(file.FullName);
            }

            // 文件在文件夹中可能是乱序的
            lstFileName.Sort();

            List<string> cmdList = new List<string>();
            for (int i = 0; i < lstFileName.Count; i++)
            {
                if (i == 0)
                    cmdList.Add(string.Format("copy {0} r:\\all.ts", lstFileName[i]));
                else
                    cmdList.Add(string.Format("copy /b r:\\all.ts + {0} r:\\all.ts", lstFileName[i]));
            }
            cmdList.Add("del r:\\tmp\\*.ts");

            foreach (string cmdStr in cmdList)
            {
                //Console.WriteLine(cmdStr);
                RunCmd(cmdStr);
            }
        }

        #region 调用DOS执行CMD方法
 
        /// <summary>调用DOS执行CMD方法
        /// </summary>
        /// <param name="command">参数</param>
        /// <returns></returns>
        public static string RunCmd(string command = "") {
            //实例一个Process类，启动一个独立进程  
            Process p = new Process();
 
            //Process类有一个StartInfo属性，这个是ProcessStartInfo类，包括了一些属性和方法，下面我们用到了他的几个属性：  
 
            p.StartInfo.FileName = "cmd.exe"; //设定程序名  
            p.StartInfo.Arguments = "/c " + command; //设定程式执行参数  
            p.StartInfo.UseShellExecute = false; //关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true; //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true; //重定向标准输出  
            p.StartInfo.RedirectStandardError = true; //重定向错误输出  
            p.StartInfo.CreateNoWindow = true; //设置不显示窗口  
 
            p.Start(); //启动  
            p.StandardInput.WriteLine("exit"); //不过要记得加上Exit要不然下一行程式执行的时候会当机  
 
            return p.StandardOutput.ReadToEnd(); //从输出流取得命令执行结果  
 
        }
 
        #endregion 调用DOS执行CMD方法
    }
}
