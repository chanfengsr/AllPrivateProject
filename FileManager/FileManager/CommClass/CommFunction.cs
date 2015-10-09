using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManager
{
    internal class CommFunction
    {
        /// <summary>出提示
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="logFileFullName">日志文件全名，如有则写日志</param>
        /// <param name="isWrap">是否换行写入</param>
        /// <param name="addTime">是否添加时间标记</param>
        public static void WriteMessage(string message, string logFileFullName = "", bool isWrap = true, bool addTime = true)
        {
            string strTime = addTime ? "(" + DateTime.Now.ToString("MM-dd HH:mm:ss") + ") " : "";
            string strMsg = strTime + message + (isWrap ? Environment.NewLine : "");

            try
            {
                Console.Write(strMsg);

                if (logFileFullName != string.Empty)
                    File.AppendAllText(logFileFullName, strMsg, Encoding.UTF8);
            }
            catch (Exception)
            {
            }
        }
    }
}
