using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager {
    internal class CommFunction {
        /// <summary>出提示
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="logFileFullName">日志文件全名，如有则写日志</param>
        /// <param name="isWrap">是否换行写入</param>
        /// <param name="addTime">是否添加时间标记</param>
        public static void WriteMessage(string message, string logFileFullName = "", bool isWrap = true, bool addTime = true) {
            string strTime = addTime ? "(" + DateTime.Now.ToString("MM-dd HH:mm:ss") + ") " : "";
            string strMsg = strTime + message + ( isWrap ? Environment.NewLine : "" );

            try {
                Console.Write(strMsg);

                if (logFileFullName != string.Empty)
                    File.AppendAllText(logFileFullName, strMsg, Encoding.UTF8);
            }
            catch (Exception) {}
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

            return fileInfo.CreationTime;
        }

        /// <summary>将List弄成一个字符串，用StringBuilder，量大可能会快一点
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string StringList2String(ICollection<string> list) {
            StringBuilder sb = new StringBuilder();
            foreach (string s in list)
                sb.AppendLine(s);

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public static string GetMD5HashFromFile(FileStream fileStream) {
            try {
                if (fileStream.Length > 0) {
                    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(fileStream);
                    
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++) {
                        sb.Append(retVal[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
                else
                    return string.Empty;
            }
            catch (Exception ex) {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        public static string GetMD5HashFromFile(string fileName) {
            string retVal;

            try {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open)) {
                    try {
                        retVal = GetMD5HashFromFile(fileStream);
                    }
                    finally {
                        fileStream.Close();
                    }

                }
            }
            catch (Exception ex) {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }

            return retVal;
        }

        #region 在命令行中实行退格键
        /// <summary>在命令行中实行退格键
        /// </summary>
        /// <param name="previousObject">前一个显示的内容（用于测长度）</param>
        public static void BackspaceInConsole(dynamic previousObject) {
            try {
                int length = previousObject.ToString().Length;

                for (int i = 0; i < length; i++)
                    Console.Write("\b \b");
                //Console.Write(Keys.Back);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static void BackspaceInConsole(dynamic previousObject, TextBox textBox) {
            try {
                int length = previousObject.ToString().Length;

                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - length);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        #endregion 在命令行中实行退格键
    }
}