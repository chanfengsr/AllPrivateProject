using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace FileManager {
    internal class FileProcessBaseClass {
        protected readonly List<FileInfo> AllFile = new List<FileInfo>();
        protected FileSelectParm FileSelParm = new FileSelectParm();
        private readonly Dictionary<string, DateTime> _dicRecordDate = new Dictionary<string, DateTime>();

        protected Dictionary<string, DateTime> DicRecordDate {
            get {
                if (_dicRecordDate.Count == 0 && AllFile.Count > 0) {
                    ParallelQuery<Tuple<string, DateTime>> pqRecordDate = AllFile.Select(f => f.FullName).AsParallel().Select(fName => Tuple.Create(fName, PictureHelper.GetTakePicDateTime(PictureHelper.GetExifProperties(fName))));
                    foreach (Tuple<string, DateTime> nameDate in pqRecordDate) {
                        _dicRecordDate.Add(nameDate.Item1, nameDate.Item2);
                    }
                }

                return _dicRecordDate;
            }
        }

        public void SetFileSelectParm(FileSelectParm fileSelectParm) {
            this.FileSelParm = fileSelectParm;
        }

        protected DateTime GetFileDate(FileInfo fileInfo, FileSortMode fileSortMode) {
            DateTime retVal = DateTime.MinValue;

            switch (fileSortMode) {
                case FileSortMode.CreateDate:
                    retVal = fileInfo.CreationTime;
                    break;
                case FileSortMode.ModifyDate:
                case FileSortMode.FileName:
                    retVal = fileInfo.LastWriteTime;
                    break;
                case FileSortMode.RecordingDate:
                    if (fileInfo.Extension.ToUpper() == ".JPG")
                        //retVal = PictureHelper.GetTakePicDateTime(PictureHelper.GetExifProperties(fileInfo.FullName));
                        retVal = this.DicRecordDate[fileInfo.FullName];
                    break;
                case FileSortMode.DateInFileName:
                    Regex reg = new Regex(@"((19|20)\d{2})-?(0[1-9]|1[0-2])-?(0[1-9]|[1-2][0-9]|3[0-1])");
                    Match match = reg.Match(fileInfo.Name);

                    if (match.Success)
                        DateTime.TryParseExact(match.Value, new[] {"yyyy-MM-dd", "yyyyMMdd"}, CultureInfo.CurrentUICulture, DateTimeStyles.None, out retVal);

                    break;
            }

            return retVal;
        }

        protected DateTime GetFileDate(FileInfo fileInfo, List<FileSortMode> listOfPriority) {
            DateTime retVal = DateTime.MinValue;

            foreach (FileSortMode mode in listOfPriority) {
                retVal = GetFileDate(fileInfo, mode);

                if (retVal > DateTime.MinValue)
                    break;
            }

            return retVal;
        }

        protected void BeforeExecute() {
            this.AllFile.Clear();
            this._dicRecordDate.Clear();
        }

        public virtual string LoadFileList(bool sortFileList = true) {
            string retVal = string.Empty;

            if (Directory.Exists(FileSelParm.SourceFileFolder)) {
                AllFile.Clear();
                _dicRecordDate.Clear();
                List<string> filterList = FileSelParm.FileFilter.ToUpper().Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                DirectoryInfo dicInfo = new DirectoryInfo(FileSelParm.SourceFileFolder);
                List<string> chgFileList = FileSelParm.UseSpecFileList ? FileSelParm.SpecFileList.ToUpper().Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList() : null;

                foreach (FileInfo fileInfo in dicInfo.GetFiles()) {
                    //隐藏文件和系统文件就不要过来凑热闹了
                    if ( /*( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden || */
                        ( fileInfo.Attributes & FileAttributes.System ) == FileAttributes.System)
                        continue;

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
                if (sortFileList) {
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
                            //foreach (FileInfo fileInfo in AllFile) {
                            //    DicRecordDate.Add(fileInfo.FullName, this.GetFileDate(fileInfo, FileSortMode.RecordingDate));
                            //}
                            //DicRecordDate = AllFile.AsParallel().ToDictionary(f => f.FullName, f => this.GetFileDate(f, FileSortMode.RecordingDate));

                            //_allFile.Sort((x, y) => DateTime.Compare(CommFunction.GetFileDateTime(x, true), CommFunction.GetFileDateTime(y, true)));
                            AllFile.Sort((x, y) => DateTime.Compare(this.DicRecordDate[x.FullName], this.DicRecordDate[y.FullName]));
                            break;
                        case FileSortMode.DateInFileName:
                            AllFile.Sort((x, y) => DateTime.Compare(this.GetFileDate(x, FileSortMode.DateInFileName), this.GetFileDate(y, FileSortMode.DateInFileName)));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
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