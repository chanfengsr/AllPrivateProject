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

        /// <summary>获取文件日期，图片的话优先取拍摄日期
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="useCameraDate">是否取照片拍摄日期</param>
        /// <returns></returns>
        public static DateTime GetFileDateTime(FileInfo fileInfo, bool useCameraDate = false) {
            if (useCameraDate && fileInfo.Extension.ToLower() == ".jpg") {
                DateTime picDate = PictureHelper.GetTakePicDateTime(PictureHelper.GetExifProperties(fileInfo.FullName));

                if (picDate > DateTime.MinValue)
                    return picDate;
            }

            return fileInfo.LastWriteTime;
        }
    }
}
