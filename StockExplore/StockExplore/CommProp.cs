using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal class CommProp
    {
        /// <summary>系统连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>源文件夹路径
        /// </summary>
        public static string SourceFolder { get; set; }

        /// <summary>通达信安装目录
        /// </summary>
        public static string TDXFolder { get; set; }
    }
}