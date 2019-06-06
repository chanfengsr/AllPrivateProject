using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Configuration;
using System.IO;

namespace bDown
{
    /// <summary>
    /// 生成 将目录下的 flv 文件连成一个 mp4 文件的 bat
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const string cmdMod = "ffmpeg -f concat -i fileList.txt -vcodec copy -acodec copy {0}";

            string tarFileName = @"output.mp4";
            string tarPath = System.Environment.CurrentDirectory; //@"D:\Download\";
            string workDir = System.Environment.CurrentDirectory; //@"R:\"; //

            // 有参数传入路径的话就用传入的
            // args[0]  输出文件名(不含后缀)
            // args[1]  输出目录
            // args[2]  输入文件夹(默认当前目录 workDir)
            if (args != null)
            {
                if (args.Length > 0 && args[0].Length > 0)
                {
                    tarFileName = args[0].Trim() + ".mp4";
                    tarFileName = ReplaceBadFileName(tarFileName);
                }
                if (args.Length > 1 && System.IO.Directory.Exists(args[1]))
                    tarPath = args[1];
                if (args.Length > 2 && System.IO.Directory.Exists(args[2]))
                    workDir = args[2];
            }

            if (!tarPath.EndsWith("\\"))
                tarPath += "\\";
            if (!workDir.EndsWith("\\"))
                workDir += "\\";

            DirectoryInfo dirInfo = new DirectoryInfo(workDir);
            Console.WriteLine(string.Format("Work directory: {0}", dirInfo.FullName));

            List<ValueTuple<string, string>> lstFileName = new List<ValueTuple<string, string>>();
            foreach (FileInfo file in dirInfo.GetFiles().Where(f => f.Extension.ToLower() == ".flv"))
            {
                lstFileName.Add((file.Name, file.FullName));
            }

            if (lstFileName.Count == 0)
                return;

            lstFileName.Sort();
            StringBuilder sbBatFile = new StringBuilder();
            const string listLineMod = "file '{0}'";
            foreach (var fName in lstFileName)
            {
                sbBatFile.AppendLine(string.Format(listLineMod, fName.Item1));
            }

            string listFileName = (workDir + "\\" + "fileList.txt").Replace("\\\\", "\\");
            System.IO.File.WriteAllText(listFileName, sbBatFile.ToString());

            // 过长的中文名称会导致 ffmpeg 执行出错，所以让其运行后再改名字
            StringBuilder sbCmdCont = new StringBuilder();
            sbCmdCont.AppendLine(string.Format(cmdMod, tarPath + "output.mp4"));
            if (tarFileName != "output.mp4")
            {
                string cmdRename = "ren \"" + tarPath + "output.mp4\" \"" + tarFileName + "\"";
                sbCmdCont.AppendLine(cmdRename);
            }

            // 删除原始分段文件
            foreach (var fName in lstFileName)
            {
                sbCmdCont.AppendLine("del \"" + fName.Item2 + "\"");
            }

            string cmdFileName = (workDir + "\\" + "ffmpegCvtFlv.bat").Replace("\\\\", "\\");
            sbCmdCont.AppendLine("del *.ef2");
            sbCmdCont.AppendLine("del \"" + listFileName + "\"");
            sbCmdCont.AppendLine("del \"" + cmdFileName + "\"");

            // .net core 中 GB2312 需要注册
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            System.IO.File.WriteAllText(cmdFileName, sbCmdCont.ToString(), Encoding.GetEncoding("GB2312"));


            Console.WriteLine("Done.");
            Console.WriteLine(cmdFileName);
        }

        /// <summary>
        /// 替换非法文件字符为空格
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReplaceBadFileName(string fileName)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                fileName = fileName.Replace(c.ToString(), " ");
            }
            return fileName;
        }
    }
}
