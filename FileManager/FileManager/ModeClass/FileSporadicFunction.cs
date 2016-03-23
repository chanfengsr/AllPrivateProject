using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

        public void Execute_DeleteEmptyFolder(List<string> emptyFolderList = null) {
            if (emptyFolderList==null) {
                emptyFolderList = this.GetEmptyFolderList(this.FileSelParm.SourceFileFolder, this.FileSelParm.FileFilter);
            }

            foreach (string dic in emptyFolderList.Where(Directory.Exists)) {
                Directory.Delete(dic, true);
            }
        }
    }
}
