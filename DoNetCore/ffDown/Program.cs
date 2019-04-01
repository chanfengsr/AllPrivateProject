using System;

namespace ffDown
{
    class Program
    {
        static void Main(string[] args)
        {
            const string cmdMod = "ffmpeg -i {0} -vcodec copy -acodec copy \"D:\\Download\\Test.mp4\"";
            string m3u8Addr = @"index.m3u8";

            // 有参数传入路径的话就用传入的
            if (args != null && args.Length > 0)
                m3u8Addr = args[0];

            Console.WriteLine(string.Format(cmdMod, m3u8Addr));

        }
    }
}