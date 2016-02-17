using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace FileManager {
    internal enum FileSortMode {
        FileName,
        CreateDate,
        ModifyDate,
        RecordingDate
    }

    internal enum FileChangeRule {
        FixedString,
        Wildcard,
        SpecList
    }

    internal class FileBatchChangeName {
        public static string ExtensionPicFile = "BMP|PCX|TIFF|GIF|JPEG|JPG|TGA|EXIF|FPX|SVG|PSD|CDR|PCD|DXF|UFO|EPS|AI|PNG|HDRI|RAW";
        public static string ExtensionAudioFile = "WAV|MP3|MP3|RA|RMA|WMA|ASF|MID|MIDI|RMI|XMI|OGG|VQF|TVQ|MOD|APE|AIFF|AU|FLAC";
        public static string ExtensionVideoFile = "3GP|ASF|AVI|FLV|MKV|MOV|MP4|MPEG|AVI|RMVB|WMV|SWF";
        public static string ExtensionTextFile = "TXT|DOC|DOCX|HLP|WPS|RTF|HTML|HTM|PDF";

        private string FileFolder { get; set; }
        private string FileFilter { get; set; }
        private FileSortMode FileSortBy { get; set; }
        private bool UseSpecChangeFileList { get; set; }
        private string SpecChangeFileList { get; set; } //指定的需要被改名文件的列表
        private FileChangeRule FileChangeBy { get; set; }
        private string FixedString { get; set; }
        private bool IsRegex { get; set; }
        private string PerfixStr { get; set; }
        private string SuffixStr { get; set; }
        private int StartSeriNum { get; set; }
        private int WildcardLen { get; set; }
        private bool OnlyFixStr { get; set; }
        private string SpecChangeList { get; set; }

        private readonly List<FileInfo> _allFile = new List<FileInfo>();

        public FileBatchChangeName() {
            this.FileSortBy = FileSortMode.FileName;
            this.FileChangeBy = FileChangeRule.FixedString;
            this.UseSpecChangeFileList = false;
        }

        public void SetFileSelect(string strFileFolder, string strFileFilter, FileSortMode fileSortBy, bool useSpecChangeFileList, string specChangeFileList) {
            this.FileFolder = strFileFolder;
            this.FileFilter = strFileFilter;
            this.FileSortBy = fileSortBy;
            this.UseSpecChangeFileList = useSpecChangeFileList;
            this.SpecChangeFileList = specChangeFileList;
        }

        public void SetNameChangeRule(FileChangeRule fileChangeBy, string fixedStr = "", bool isRegex = false, string perfixStr = "", string suffixStr = "", int startNum = 1, int wildcardLen = 2, bool onlyFixStr = false, string specChgList = "") {
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

        public string LoadFileList() {
            string retVal = string.Empty;

            if (Directory.Exists(this.FileFolder)) {
                _allFile.Clear();
                List<string> filterList = this.FileFilter.Split('|').ToList();
                bool havAllFilter = filterList.Contains("*");
                DirectoryInfo dicInfo = new DirectoryInfo(this.FileFolder);
                List<string> chgFileList = this.UseSpecChangeFileList ? this.SpecChangeFileList.ToUpper().Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList() : null;

                foreach (FileInfo fileInfo in dicInfo.GetFiles()) {
                    if (this.UseSpecChangeFileList) {
                        if (chgFileList != null && chgFileList.Contains(fileInfo.Name.ToUpper()))
                            _allFile.Add(fileInfo);
                    }
                    else {
                        if (havAllFilter) {
                            _allFile.Add(fileInfo);
                        }
                        else {
                            string strExt = fileInfo.Extension.Remove(0, 1).ToUpper();
                            if (filterList.Contains(strExt)) {
                                _allFile.Add(fileInfo);
                            }
                        }
                    }
                }

                //排序
                switch (this.FileSortBy) {
                    case FileSortMode.FileName:
                        _allFile.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
                        break;
                    case FileSortMode.CreateDate:
                        _allFile.Sort((x, y) => DateTime.Compare(x.CreationTime, y.CreationTime));
                        break;
                    case FileSortMode.ModifyDate:
                        _allFile.Sort((x, y) => DateTime.Compare(x.LastWriteTime, y.LastWriteTime));
                        break;
                    case FileSortMode.RecordingDate:
                        //直接取拍摄日期，文件多了会内存溢出
                        Dictionary<string, DateTime> dicRecordDate = new Dictionary<string, DateTime>();
                        foreach (FileInfo fileInfo in _allFile) {
                            dicRecordDate.Add(fileInfo.FullName, CommFunction.GetFileDateTime(fileInfo, true));
                            GC.Collect();
                        }

                        //_allFile.Sort((x, y) => DateTime.Compare(CommFunction.GetFileDateTime(x, true), CommFunction.GetFileDateTime(y, true)));
                        _allFile.Sort((x, y) => DateTime.Compare(dicRecordDate[x.FullName], dicRecordDate[y.FullName]));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //一行一行显示文件名
                StringBuilder sbFilenames = new StringBuilder();
                foreach (FileInfo fileInfo in _allFile)
                    sbFilenames.AppendLine(fileInfo.Name);

                retVal = sbFilenames.ToString().TrimEnd(Environment.NewLine.ToCharArray());
            }
            else {
                CommFunction.WriteMessage("文件夹不存在！");
            }
            
            return retVal;
        }

        public List<string> GetTargetNameList() {
            List<string> retVal = new List<string>();
            int iFileNum = this.StartSeriNum;

            if (LoadFileList().Length > 0) {
                //已经指定更名列表
                if (this.FileChangeBy == FileChangeRule.SpecList) {
                    retVal = this.SpecChangeList.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else {
                    foreach (FileInfo fileInfo in _allFile) {
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
                string sourceFolder = ( _allFile[0].DirectoryName + "\\" ).Replace("\\\\", "\\");
                int successCnt = 0;

                for (int i = 0; i < targetNameList.Count; i++) {
                    try {
                        _allFile[i].MoveTo(sourceFolder + targetNameList[i]);
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