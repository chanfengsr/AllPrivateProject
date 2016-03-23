using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FileManager {
    internal class FileSporadicFunction : FileProcessBaseClass {
        private void GetEmptyFolderList(DirectoryInfo dirInfo, List<string> ignoreTypes, ref List<string> foundList, ref bool subFolderFound) {
            bool thisSubFolderFound = false;

            foreach (DirectoryInfo dirInfoSub in dirInfo.GetDirectories()) {
                bool evySubFound = false;

                this.GetEmptyFolderList(dirInfoSub, ignoreTypes, ref foundList, ref evySubFound);
                if (evySubFound)
                    thisSubFolderFound = true;
            }

            if (thisSubFolderFound) {
                subFolderFound = true;
            }
            else {
                if (ignoreTypes.Contains("*")) {
                    foundList.Add(dirInfo.FullName);
                }
                else {
                    bool foundFile = dirInfo.GetFiles().Any(fileInfo => !ignoreTypes.Contains(fileInfo.Extension.Remove(0, 1).ToUpper()));

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
        public List<string> GetEmptyFolderList(string rootFolderPath, string ignoreFileTypes = "null") {
            List<string> retVal = new List<string>();
            List<string> ignoreTypes = new List<string>();

            if (!Directory.Exists(rootFolderPath)) {
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

        public int Execute_DeleteEmptyFolder(List<string> emptyFolderList = null) {
            int delCount = 0;

            if (emptyFolderList == null)
                emptyFolderList = this.GetEmptyFolderList(this.FileSelParm.SourceFileFolder, this.FileSelParm.FileFilter);
          
            try {
                foreach (string dic in emptyFolderList.Where(Directory.Exists)) {
                    Directory.Delete(dic, true);
                    delCount++;
                }
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
            }

            if (delCount > 0)
                CommFunction.WriteMessage(string.Format("成功删除 {0} 个空文件夹。", delCount));

            if (emptyFolderList.Count > delCount)
                CommFunction.WriteMessage(string.Format("{0} 个文件夹未能正确删除。", emptyFolderList.Count - delCount));

            return delCount;
        }

        private void LoadAllFileList(DirectoryInfo dirInfo, ICollection<string> filterList) {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                LoadAllFileList(di,filterList);

            foreach (FileInfo fi in dirInfo.GetFiles()) {
                if (( fi.Attributes & FileAttributes.System ) == FileAttributes.System)
                    continue;

                if (filterList.Contains(fi.Extension.Remove(0, 1).ToUpper()))
                    base.AllFile.Add(fi);
            }
        }

        public List<string> GetFileInWrongFolder() {
            List<string> retVal = new List<string>();

            if (!Directory.Exists(this.FileSelParm.SourceFileFolder)) {
                throw new DirectoryNotFoundException("源文件夹不存在！");
            }

            //获取字符串中的日期
            Func<string, DateTime> getNameDate = delegate(string name) {
                DateTime ret = DateTime.MinValue;
                Regex reg = new Regex(@"((19|20)\d{2})-?(0[1-9]|1[0-2])-?(0[1-9]|[1-2][0-9]|3[0-1])");

                Match match = reg.Match(name);
                if (match.Success)
                    DateTime.TryParseExact(match.Value, new[] {"yyyy-MM-dd", "yyyyMMdd"}, CultureInfo.CurrentUICulture, DateTimeStyles.None, out ret);

                return ret;
            };

            base.AllFile.Clear();
            this.LoadAllFileList(new DirectoryInfo(this.FileSelParm.SourceFileFolder), this.FileSelParm.FileFilter.ToUpper().Split('|').ToList());
            
            //文件名包含日期，所在文件夹包含日期，但两者日期不一致
            foreach (FileInfo fileInfo in base.AllFile) {
                DateTime fileDate = getNameDate(fileInfo.Name);
                if (fileDate > DateTime.MinValue) {
                    DateTime folderDate = getNameDate(fileInfo.DirectoryName);

                    if (folderDate > DateTime.MinValue && folderDate != fileDate)
                        retVal.Add(fileInfo.FullName);
                }
            }

            return retVal;
        }
    }
}
