using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace megerVA
{
    class Program
    {
        const string cmdMod = "ffmpeg -i \"{0}\" -i \"{1}\" \"{2}\"";
        static void Main(string[] args)
        {
            string workDir = @"R:\"; // System.Environment.CurrentDirectory;

            // 有参数传入路径的话就用传入的
            if (args != null && args.Length > 0)
                if (System.IO.Directory.Exists(args[0]))
                    workDir = args[0];

            DirectoryInfo dirInfo = new DirectoryInfo(workDir);
            Console.WriteLine(string.Format("Work directory: {0}", dirInfo.FullName));

            List<string> lstFileFullName = new List<string>();
            foreach (FileInfo file in dirInfo.GetFiles().Where(f => f.Extension.ToLower() == ".mp4"))
                lstFileFullName.Add(file.FullName);

            foreach (string fName in lstFileFullName)
            {
                if (fName.EndsWith("1.mp4"))
                {
                    string actName = fName.TrimEnd("1.mp4 ".ToCharArray());
                    string audioName = actName + "2.mp4";
                    if (lstFileFullName.Contains(audioName))
                    {
                        if (actName == workDir)
                            actName += "out";
                        string tarName = actName + ".mp4";

                        Console.WriteLine(string.Format(cmdMod, fName, audioName, tarName));
                    }
                }
            }
        }

        #region 调用DOS执行CMD方法

        /// <summary>调用DOS执行CMD方法
        /// </summary>
        /// <param name="command">参数</param>
        /// <returns></returns>
        public static string RunCmd(string command = "")
        {
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