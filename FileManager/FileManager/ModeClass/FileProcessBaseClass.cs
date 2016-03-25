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

        /// <summary>获取文件日期的优先级
        /// </summary>
        protected List<FileSortMode> DatePriority {
            get {
                List<FileSortMode> listOfPriority = new List<FileSortMode>();

                switch (FileSelParm.FileSortBy) {
                    case FileSortMode.FileName:
                    case FileSortMode.CreateDate:
                    case FileSortMode.ModifyDate:
                        listOfPriority.Add(FileSelParm.FileSortBy);
                        break;
                    case FileSortMode.RecordingDate:
                        listOfPriority.Add(FileSortMode.RecordingDate);
                        listOfPriority.Add(FileSortMode.ModifyDate);
                        break;
                    case FileSortMode.DateInFileName:
                        listOfPriority.Add(FileSortMode.DateInFileName);
                        listOfPriority.Add(FileSortMode.RecordingDate);
                        listOfPriority.Add(FileSortMode.ModifyDate);
                        break;
                }

                return listOfPriority;
            }
        }

        /// <summary>获取所有照片文件拍摄日期
        /// </summary>
        protected Dictionary<string, DateTime> DicRecordDate {
            get {
                if (_dicRecordDate.Count == 0 && AllFile.Count > 0) {
                    //并行获取照片文件的日期
                    ParallelQuery<Tuple<string, DateTime>> pqRecordDate = AllFile.Where(f => f.Extension.ToUpper() == ".JPG").Select(f => f.FullName).AsParallel().Select(fName => Tuple.Create(fName, PictureHelper.GetTakePicDateTime(PictureHelper.GetExifProperties(fName))));
                    foreach (Tuple<string, DateTime> nameDate in pqRecordDate) {
                        _dicRecordDate.Add(nameDate.Item1, nameDate.Item2);
                    }
                    
                    //非照片文件直接取最小日期
                    foreach (FileInfo fileInfo in AllFile.Where(f => f.Extension.ToUpper() != ".JPG")) {
                        _dicRecordDate.Add(fileInfo.FullName, DateTime.MinValue);
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
                        if (this.DicRecordDate.ContainsKey(fileInfo.FullName))
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

        /// <summary>排序已获得的文件
        /// </summary>
        protected void SortFileList() {
            if (AllFile.Count > 0) {
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
                    case FileSortMode.DateInFileName:
                        AllFile.Sort((x, y) => DateTime.Compare(this.GetFileDate(x, this.DatePriority), this.GetFileDate(y, this.DatePriority)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public virtual string LoadFileList(bool sortFileList = true) {
            string retVal = string.Empty;

            if (Directory.Exists(FileSelParm.SourceFileFolder)) {
                AllFile.Clear();
                _dicRecordDate.Clear();
                List<string> filterList = FileSelParm.FileFilter.ToUpper().Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                bool typeIgnore = FileSelParm.FileTypeIsIgnore;
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
                        if (havAllFilter && !typeIgnore) {
                            AllFile.Add(fileInfo);
                        }
                        else {
                            string strExt = fileInfo.Extension.Remove(0, 1).ToUpper();
                            //符合异或条件
                            if (typeIgnore ^ filterList.Contains(strExt))
                                AllFile.Add(fileInfo);
                        }
                    }
                }

                //排序
                if (sortFileList)
                    this.SortFileList();

                //一行一行显示文件名
                retVal = CommFunction.StringList2String(AllFile.Select(f => f.FullName).ToList());
            }
            else {
                CommFunction.WriteMessage("文件夹不存在！");
            }

            return retVal;
        }

        protected virtual void LoadFileListAllTree(DirectoryInfo dirInfo, List<string> filterList, bool havAllFilter, bool typeIgnore) {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                LoadFileListAllTree(di, filterList, havAllFilter, typeIgnore);

            foreach (FileInfo fi in dirInfo.GetFiles().Where(fi => ( fi.Attributes & FileAttributes.System ) != FileAttributes.System)) {
                if (havAllFilter && !typeIgnore) {
                    AllFile.Add(fi);
                }
                else {
                    string strExt = fi.Extension.Remove(0, 1).ToUpper();
                    //符合异或条件
                    if (typeIgnore ^ filterList.Contains(strExt))
                        AllFile.Add(fi);
                }
            }
        }

        public virtual string LoadFileListAllTree(bool sortFileList = true) {
            string retVal = string.Empty;

            if (Directory.Exists(FileSelParm.SourceFileFolder)) {
                AllFile.Clear();
                _dicRecordDate.Clear();
                List<string> filterList = FileSelParm.FileFilter.ToUpper().Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                bool typeIgnore = FileSelParm.FileTypeIsIgnore;
                DirectoryInfo dicInfo = new DirectoryInfo(FileSelParm.SourceFileFolder);

                this.LoadFileListAllTree(dicInfo, filterList, havAllFilter, typeIgnore);

                //排序
                if (sortFileList)
                    this.SortFileList();

                //一行一行显示文件名
                retVal = CommFunction.StringList2String(AllFile.Select(f => f.FullName).ToList());
            }
            else {
                CommFunction.WriteMessage("文件夹不存在！");
            }

            return retVal;
        }

        protected virtual void LoadFileNameListAllTree(DirectoryInfo dirInfo, List<string> filterList, bool havAllFilter, bool typeIgnore,List<string> foundList) {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                LoadFileNameListAllTree(di, filterList, havAllFilter, typeIgnore,foundList);

            foreach (FileInfo fi in dirInfo.GetFiles().Where(fi => (fi.Attributes & FileAttributes.System) != FileAttributes.System)) {
                if (havAllFilter && !typeIgnore) {
                    foundList.Add(fi.FullName);
                }
                else {
                    string strExt = fi.Extension.Remove(0, 1).ToUpper();
                    //符合异或条件
                    if (typeIgnore ^ filterList.Contains(strExt))
                        foundList.Add(fi.FullName);
                }
            }
        }

        public virtual List<string> LoadFileNameListAllTree() {
            List<string> foundList = new List<string>();

            if (Directory.Exists(FileSelParm.SourceFileFolder)) {
                AllFile.Clear();
                _dicRecordDate.Clear();
                List<string> filterList = FileSelParm.FileFilter.ToUpper().Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                bool typeIgnore = FileSelParm.FileTypeIsIgnore;
                DirectoryInfo dicInfo = new DirectoryInfo(FileSelParm.SourceFileFolder);

                this.LoadFileNameListAllTree(dicInfo, filterList, havAllFilter, typeIgnore, foundList);
            }
            else {
                CommFunction.WriteMessage("文件夹不存在！");
            }

            foundList.Reverse();
            return foundList;
        }
    }
}