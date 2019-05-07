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
            foreach (FileInfo file in dirInfo.GetFiles().Where(f => f.Extension.ToLower() == ".mp4") )
                lstFileFullName.Add(file.FullName);

            foreach (string fName in lstFileFullName)
            {
                if (fName.EndsWith("1.mp4"))
                {                    
                    string audioName = fName.TrimEnd("1.mp4 ".ToCharArray()) + "2.mp4";
                    if (lstFileFullName.Contains(audioName))
                    {
                        string tarName = fName.TrimEnd("1.mp4 ".ToCharArray()) + ".mp4";
                        Console.WriteLine(string.Format(cmdMod,fName,audioName,tarName));                        
                    }
                }
            }
        }
    }
}