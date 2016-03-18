using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace FileManager {
    internal class FileBatchChangeName : FileProcessBaseClass {
        private FileChangeRule FileChangeBy { get; set; }
        private string FixedString { get; set; }
        private bool IsRegex { get; set; }
        private string PerfixStr { get; set; }
        private string SuffixStr { get; set; }
        private int StartSeriNum { get; set; }
        private int WildcardLen { get; set; }
        private bool OnlyFixStr { get; set; }
        private string SpecChangeList { get; set; }

        public FileBatchChangeName() {
            this.FileChangeBy = FileChangeRule.FixedString;
        }

        //public void SetFileSelect(string strFileFolder, string strFileFilter, FileSortMode fileSortBy, bool useSpecChangeFileList, string specChangeFileList) {
        //    FileSelParm.SourceFileFolder = strFileFolder;
        //    FileSelParm.FileFilter = strFileFilter;
        //    FileSelParm.FileSortBy = fileSortBy;
        //    FileSelParm.UseSpecFileList = useSpecChangeFileList;
        //    FileSelParm.SpecFileList = specChangeFileList;
        //}

        public void SetFunctionRule(FileChangeRule fileChangeBy, string fixedStr = "", bool isRegex = false, string perfixStr = "", string suffixStr = "", int startNum = 1, int wildcardLen = 2, bool onlyFixStr = false, string specChgList = "") {
            this.FileChangeBy = fileChangeBy;
            this.FixedString = fixedStr;
            this.IsRegex = isRegex;
            this.PerfixStr = perfixStr;
            this.SuffixStr = suffixStr;
            this.StartSeriNum = startNum;
            this.WildcardLen = wildcardLen;
            this.OnlyFixStr = onlyFixStr;
            this.SpecChangeList = specChgList;
        }

        public List<string> GetTargetNameList() {
            List<string> retVal = new List<string>();
            int iFileNum = this.StartSeriNum;

            if (base.LoadFileList().Length > 0) {
                //已经指定更名列表
                if (this.FileChangeBy == FileChangeRule.SpecList) {
                    retVal = this.SpecChangeList.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else {
                    foreach (FileInfo fileInfo in AllFile) {
                        switch (FileChangeBy) {
                                //去掉固定字符串或正则表达式
                            case FileChangeRule.FixedString:
                                if (this.IsRegex) {
                                    string fileName = fileInfo.Name;
                                    Regex reg = new Regex(this.FixedString);
                                    MatchCollection matchCollect = reg.Matches(fileInfo.Name);
                                    foreach (Match match in matchCollect)
                                        fileName = fileName.Replace(match.Value, "");

                                    retVal.Add(fileName);
                                }
                                else {
                                    retVal.Add(fileInfo.Name.Replace(this.FixedString, ""));
                                }
                                break;

                                //前后缀(或数字通配符)
                            case FileChangeRule.Wildcard:
                                if (this.OnlyFixStr) {
                                    //仅前后缀
                                    retVal.Add(this.PerfixStr + fileInfo.Name.Replace(fileInfo.Extension, "") + this.SuffixStr + fileInfo.Extension);
                                }
                                else {
                                    //数字通配符
                                    string formatFileNum = iFileNum.ToString().PadLeft(this.WildcardLen, '0');
                                    retVal.Add(this.PerfixStr + formatFileNum + this.SuffixStr + fileInfo.Extension);
                                    iFileNum++;
                                }
                                break;
                        }
                    }
                }
            }

            return retVal;
        }

        public void ExecuteChangeName() {
            List<string> targetNameList = GetTargetNameList();

            if (targetNameList.Count > 0) {
                string sourceFolder = ( AllFile[0].DirectoryName + "\\" ).Replace("\\\\", "\\");
                int successCnt = 0;

                for (int i = 0; i < targetNameList.Count; i++) {
                    try {
                        AllFile[i].MoveTo(sourceFolder + targetNameList[i]);
                        successCnt++;
                    }
                    catch (Exception ex) {
                        CommFunction.WriteMessage(ex.Message);
                    }
                }

                if (successCnt > 0)
                    CommFunction.WriteMessage(string.Format("成功更改{0}个文件名.", successCnt));
            }
            else {
                CommFunction.WriteMessage("没有可更名的文件！");
            }
        }
    }
}