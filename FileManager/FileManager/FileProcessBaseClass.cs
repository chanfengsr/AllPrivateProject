using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager {
    class FileProcessBaseClass {
        protected readonly List<FileInfo> AllFile = new List<FileInfo>();
        protected FileSelectParm FileSelParm = new FileSelectParm();
        Dictionary<string, DateTime> DicRecordDate = new Dictionary<string, DateTime>();

        public void SetFileSelectParm(FileSelectParm fileSelectParm) {
            this.FileSelParm = fileSelectParm;
        }

        public virtual string LoadFileList() {
            string retVal = string.Empty;

            if (Directory.Exists(FileSelParm.SourceFileFolder)) {
                AllFile.Clear();
                DicRecordDate.Clear();
                List<string> filterList = FileSelParm.FileFilter.ToUpper().Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                DirectoryInfo dicInfo = new DirectoryInfo(FileSelParm.SourceFileFolder);
                List<string> chgFileList = FileSelParm.UseSpecFileList ? FileSelParm.SpecFileList.ToUpper().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList() : null;

                foreach (FileInfo fileInfo in dicInfo.GetFiles()) {
                    if (FileSelParm.UseSpecFileList) {
                        if (chgFileList != null && chgFileList.Contains(fileInfo.Name.ToUpper()))
                            AllFile.Add(fileInfo);
                    }
                    else {
                        if (havAllFilter) {
                            AllFile.Add(fileInfo);
                        }
                        else {
                            string strExt = fileInfo.Extension.Remove(0, 1).ToUpper();
                            if (filterList.Contains(strExt)) {
                                AllFile.Add(fileInfo);
                            }
                        }
                    }
                }

                //排序
                switch (FileSelParm.FileSortBy) {
                    case FileSortMode.FileName:
                        AllFile.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
                        break;
                    case FileSortMode.CreateDate:
                        AllFile.Sort((x, y) => DateTime.Compare(x.CreationTime, y.CreationTime));
                        break;
                    case FileSortMode.ModifyDate:
                        AllFile.Sort((x, y) => DateTime.Compare(x.LastWriteTime, y.LastWriteTime));
                        break;
                    case FileSortMode.RecordingDate:
                        //直接取拍摄日期，文件多了会内存溢出
                        foreach (FileInfo fileInfo in AllFile) {
                            DicRecordDate.Add(fileInfo.FullName, CommFunction.GetFileDateTime(fileInfo, true));
                            GC.Collect();
                        }

                        //_allFile.Sort((x, y) => DateTime.Compare(CommFunction.GetFileDateTime(x, true), CommFunction.GetFileDateTime(y, true)));
                        AllFile.Sort((x, y) => DateTime.Compare(DicRecordDate[x.FullName], DicRecordDate[y.FullName]));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //一行一行显示文件名
                StringBuilder sbFilenames = new StringBuilder();
                foreach (FileInfo fileInfo in AllFile)
                    sbFilenames.AppendLine(fileInfo.Name);

                retVal = sbFilenames.ToString().TrimEnd(Environment.NewLine.ToCharArray());
            }
            else {
                CommFunction.WriteMessage("文件夹不存在！");
            }

            return retVal;
        }
    }
}
