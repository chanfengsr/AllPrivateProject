using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;

namespace FileManager
{
    internal class FileSporadicFunction : FileProcessBaseClass
    {
        public FileSporadicFunction() {}

        /// <summary>构造函数，用于需要设置、修改显示内容的方法
        /// </summary>
        /// <param name="consoleTextBox"></param>
        public FileSporadicFunction(TextBox consoleTextBox)
        {
            base.FormConsoleTextBox = consoleTextBox;
        }

        /// <summary> 获取文件Hash，返回 “文件长度|文件MD5”，出错的话返回 "-1"
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <returns></returns>
        public string GetFileHashValue(string fileName)
        {
            string fileHash = string.Empty;

            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    try
                    {
                        if (fileStream.Length > 0)
                        {
                            string md5Val = CommFunction.GetMD5HashFromFile(fileStream);
                            fileHash = fileStream.Length + "|" + md5Val;
                        }
                    }
                    finally
                    {
                        fileStream.Close();
                    }
                }
            }
            catch (Exception)
            {
                fileHash = "-1";
            }

            return fileHash;
        }

        private void GetEmptyFolderList(DirectoryInfo dirInfo, List<string> ignoreTypes, ref List<string> foundList, ref bool subFolderFound)
        {
            bool thisSubFolderFound = false;

            foreach (DirectoryInfo dirInfoSub in dirInfo.GetDirectories())
            {
                bool evySubFound = false;

                this.GetEmptyFolderList(dirInfoSub, ignoreTypes, ref foundList, ref evySubFound);
                if (evySubFound)
                    thisSubFolderFound = true;
            }

            if (thisSubFolderFound)
            {
                subFolderFound = true;
            }
            else
            {
                if (ignoreTypes.Contains("*"))
                {
                    foundList.Add(dirInfo.FullName);
                }
                else
                {
                    bool foundFile = dirInfo.GetFiles().Any(fileInfo => !ignoreTypes.Contains(fileInfo.Extension.Length > 0 ? fileInfo.Extension.Remove(0, 1).ToUpper() : ""));

                    if (foundFile)
                        subFolderFound = true;
                    else
                        foundList.Add(dirInfo.FullName);
                }
            }
        }

        /// <summary>获得空文件夹列表（没有文件的，只包含要被过滤文件类型的）
        /// </summary>
        /// <param name="rootFolderPath">源文件夹</param>
        /// <param name="ignoreFileTypes">需要忽略的文件类型</param>
        /// <returns></returns>
        public List<string> GetEmptyFolderList(string rootFolderPath, string ignoreFileTypes = "null")
        {
            List<string> retVal = new List<string>();
            List<string> ignoreTypes = new List<string>();

            if (!Directory.Exists(rootFolderPath))
            {
                throw new DirectoryNotFoundException("源文件夹不存在！");
            }

            if (ignoreFileTypes.ToLower() == "null")
                ignoreTypes.Add("");
            else
                ignoreTypes = ignoreFileTypes.ToUpper().Split('|').ToList();

            bool subFolderFound = false;
            this.GetEmptyFolderList(new DirectoryInfo(rootFolderPath), ignoreTypes, ref retVal, ref subFolderFound);

            return retVal;
        }

        /// <summary>删除空文件夹
        /// </summary>
        /// <param name="emptyFolderList">指定需要删除的文件夹列表</param>
        /// <returns></returns>
        public int Execute_DeleteEmptyFolder(List<string> emptyFolderList = null)
        {
            int delCount = 0;

            if (emptyFolderList == null)
                emptyFolderList = this.GetEmptyFolderList(this.FileSelParm.SourceFileFolder, this.FileSelParm.FileFilter);

            try
            {
                foreach (string dic in emptyFolderList.Where(Directory.Exists))
                {
                    Directory.Delete(dic, true);
                    delCount++;
                }
            }
            catch (Exception ex)
            {
                CommFunction.WriteMessage(ex.Message);
            }

            if (delCount > 0)
                CommFunction.WriteMessage(string.Format("成功删除 {0} 个空文件夹。", delCount));

            if (emptyFolderList.Count > delCount)
                CommFunction.WriteMessage(string.Format("{0} 个文件夹未能正确删除。", emptyFolderList.Count - delCount));

            return delCount;
        }

        /// <summary>按文件名查找放错文件夹的照片
        /// </summary>
        /// <returns></returns>
        public List<string> Execute_GetFileInWrongFolder()
        {
            List<string> retVal = new List<string>();

            if (!Directory.Exists(this.FileSelParm.SourceFileFolder))
            {
                throw new DirectoryNotFoundException("源文件夹不存在！");
            }

            //获取字符串中的日期
            Func<string, DateTime> getNameDate = delegate(string name)
            {
                DateTime ret = DateTime.MinValue;
                Regex reg = new Regex(@"((19|20)\d{2})-?(0[1-9]|1[0-2])-?(0[1-9]|[1-2][0-9]|3[0-1])");

                Match match = reg.Match(name);
                if (match.Success)
                    DateTime.TryParseExact(match.Value, new[] {"yyyy-MM-dd", "yyyyMMdd"}, CultureInfo.CurrentUICulture, DateTimeStyles.None, out ret);

                return ret;
            };

            base.AllFile.Clear();
            base.LoadFileListAllTree(false);

            //文件名包含日期，所在文件夹包含日期，但两者日期不一致
            foreach (FileInfo fileInfo in base.AllFile)
            {
                DateTime fileDate = getNameDate(fileInfo.Name);
                if (fileDate > DateTime.MinValue)
                {
                    DateTime folderDate = getNameDate(fileInfo.DirectoryName);

                    if (folderDate > DateTime.MinValue && folderDate != fileDate)
                        retVal.Add(fileInfo.FullName);
                }
            }

            return retVal;
        }

        /// <summary>按内容查找重复文件
        /// </summary>
        /// <returns></returns>
        public string Execute_FindDuplicateFilesByContent()
        {
            Dictionary<string, List<string>> foundList = new Dictionary<string, List<string>>();

            //加载所有文件
            CommFunction.WriteMessage("正在加载文件列表...", isWrap: false);
            List<string> lstAllFileName = base.LoadFileNameListAllTree(FileSelParm.SourceFileFolder);
            CommFunction.WriteMessage(string.Format("(完成)  总共 {0} 个文件", lstAllFileName.Count), addTime: false);

            //算出Hash，填充序列
            CommFunction.WriteMessage("正在计算文件Hash值...", isWrap: false);
            StringBuilder errText = new StringBuilder();

            //获取文件Hash，在此方法中，出错的话，Hash随机取 "-1"
            Func<string, string> getFileHashValue = delegate(string fName)
            {
                string fileHash = GetFileHashValue(fName);
                if (fileHash == "-1")
                    errText.AppendLine(string.Format("文件计算Hash出错。{0}", fName));
                
                return fileHash;
            };
            //异步获取所有文件的Hash
            ParallelQuery<Tuple<string, string>> fileHashs = lstAllFileName.AsParallel().Select(fName => Tuple.Create(fName, getFileHashValue(fName))).Where(fh => fh.Item2 != "-1");
            foreach (Tuple<string, string> fileHash in fileHashs)
            {
                //创建/更新哈希列表组
                if (foundList.ContainsKey(fileHash.Item2))
                    foundList[fileHash.Item2].Add(fileHash.Item1);
                else
                    foundList.Add(fileHash.Item2, new List<string>(new[] {fileHash.Item1}));
            }

            //此为同步版本，可显示百分比
            /*
            float fileIndex = 0;
            foreach (string fName in lstAllFileName) {
                fileIndex++;
                int percent = (int)( fileIndex / lstAllFileName.Count * 100 );
                string msgText = string.Format("({0}%) {1}", percent, fName);
                CommFunction.WriteMessage(msgText, isWrap: false, addTime: false);

                try {
                    using (FileStream fileStream = new FileStream(fName, FileMode.Open)) {
                        try {
                            if (fileStream.Length > 0) {
                                string md5Val = CommFunction.GetMD5HashFromFile(fileStream);
                                string fileHash = fileStream.Length + "|" + md5Val;

                                //创建/更新哈希列表组
                                if (foundList.ContainsKey(fileHash))
                                    foundList[fileHash].Add(fName);
                                else
                                    foundList.Add(fileHash, new List<string>(new[] {fName}));
                            }
                        }
                        finally {
                            fileStream.Close();
                        }
                    }
                }
                catch (Exception ex) {
                    errText.AppendLine(ex.Message);
                }

                CommFunction.BackspaceInConsole(msgText, base.FormConsoleTextBox);
            }
            */

            CommFunction.WriteMessage("(完成) ", addTime: false);
            if (errText.Length > 0)
            {
                //CommFunction.WriteMessage(errText.ToString(), addTime: false);
                base.FormConsoleTextBox.Text = base.FormConsoleTextBox.Text + errText;
            }

            StringBuilder retSb = new StringBuilder();
            //取数量大于1的为相同的文件
            foreach (KeyValuePair<string, List<string>> foundGroup in foundList.Where(fl => fl.Value.Count > 1))
            {
                //倒置列表以符合常规文件排序
                foundGroup.Value.Reverse();

                foreach (string fName in foundGroup.Value)
                    retSb.AppendLine(fName);

                retSb.AppendLine(); //每组加一空行
            }

            return retSb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public string Execute_FindNotInTargetPathFileByContent(bool genCopyCmd = false)
        {
            //加载所有文件
            CommFunction.WriteMessage("正在加载源文件列表...", isWrap: false);
            List<string> lstAllSourceFileName = base.LoadFileNameListAllTree(FileSelParm.SourceFileFolder);
            CommFunction.WriteMessage(string.Format("(完成)  总共 {0} 个文件", lstAllSourceFileName.Count), addTime: false);
            CommFunction.WriteMessage("正在加载目标文件列表...", isWrap: false);
            List<string> lstAllTargetFileName = base.LoadFileNameListAllTree(FileSelParm.TargetFileFolder);
            CommFunction.WriteMessage(string.Format("(完成)  总共 {0} 个文件", lstAllTargetFileName.Count), addTime: false);

            //算出Hash，填充序列
            CommFunction.WriteMessage("正在计算文件Hash值...", isWrap: false);
            StringBuilder errText = new StringBuilder();

            //获取文件Hash，在此方法中，出错的话，Hash随机取 "-1"
            Func<string, string> getFileHashValue = delegate(string fName)
            {
                string fileHash = GetFileHashValue(fName);
                if (fileHash == "-1")
                    errText.AppendLine(string.Format("文件计算Hash出错。{0}", fName));

                return fileHash;
            };

            // 异步获取目标文件夹文件的Hash
            List<string> targHashList = lstAllTargetFileName.AsParallel().Select(getFileHashValue).Where(hash => hash != "-1").ToList();
            // 异步获取源文件夹文件的Hash
            List<Tuple<string, string>> sourceHashList = lstAllSourceFileName.AsParallel().Select(fName => Tuple.Create(fName, getFileHashValue(fName))).Where(fh => fh.Item2 != "-1").ToList();

            CommFunction.WriteMessage("(完成) ", addTime: false);
            if (errText.Length > 0)
                base.FormConsoleTextBox.Text = base.FormConsoleTextBox.Text + errText;


            List<string> foundList = sourceHashList.Where(t => !targHashList.Contains(t.Item2)).Select(t => t.Item1).ToList();
            foundList.Sort();

            StringBuilder retSb = new StringBuilder();
            if (genCopyCmd)
            {
                const string copyFormat = "copy \"{0}\" \"{1}\"";
                foreach (string fName in foundList)
                    retSb.AppendLine(string.Format(copyFormat, fName, FileSelParm.TargetFileFolder));
            }
            else
                foreach (string fName in foundList)
                    retSb.AppendLine(fName);

            return retSb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
