using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace JQB
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir = @"D:\Download"; // System.Environment.CurrentDirectory;

            // 有参数传入路径的话就用传入的
            if (args != null && args.Length > 0)
                if (System.IO.Directory.Exists(args[0]))
                    workDir = args[0];

            DirectoryInfo dirInfo = new DirectoryInfo(workDir);
            Console.WriteLine(string.Format("Work directory: {0}", dirInfo.FullName));

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                // 去掉文件名中的这些关键字
                string newName = file.Directory + "\\" +
                    file.Name.Replace(file.Extension, "")
                    .Replace(" (金錢爆官方YouTube)", "")
                    .Replace(" (金錢爆官方YouTube)_2", "")
                    .Replace(" (金錢爆官方YouTube)_3", "")
                    .Replace("（完整版）", " ")
                    .Trim() +
                    file.Extension;
                newName = newName.Replace("\\\\", "\\");

                if (newName != file.FullName)
                {
                    Console.WriteLine("Old name: {0}", file.FullName);
                    file.MoveTo(newName);
                    Console.WriteLine("New name: {0}\n", newName);
                }
            }

            Console.WriteLine("Done.");            
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