using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager {
    internal class FileCopyByGroup : FileProcessBaseClass {
        private bool MoveFile { get; set; }

        private List<FileSortMode> DatePriority {
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

        public FileCopyByGroup() {
            this.MoveFile = false;
        }

        public void SetFunctionRule(bool moveFile) {
            this.MoveFile = moveFile;
        }

        public void Execute() {
            int count = 0;
            string sourceFolder = FileSelParm.SourceFileFolder;
            string origTargetFolder = FileSelParm.TargetFileFolder;
            string targetFolder, targetFileFullName;
            string dupFileFolder; //重复文件放的文件夹
            bool havDupFileFolder = false;
            DateTime fileDate;
            Dictionary<string, string> moveFileList = new Dictionary<string, string>();

            try {
                if (!Directory.Exists(sourceFolder)) {
                    CommFunction.WriteMessage("源文件夹不存在！");
                    return;
                }

                if (!Directory.Exists(origTargetFolder)) {
                    CommFunction.WriteMessage("目标文件夹不存在！");
                    return;
                }

                if (!origTargetFolder.EndsWith("\\"))
                    origTargetFolder = origTargetFolder + "\\";
                
                dupFileFolder = origTargetFolder + "Duplicate files\\";
                base.AllFile.Clear();
                if (base.LoadFileList(false).Length > 0) {
                    //create and record file target
                    foreach (FileInfo origFile in base.AllFile) {
                        fileDate = base.GetFileDate(origFile, this.DatePriority);
                        targetFolder = origTargetFolder + fileDate.ToString("yyyy-MM-dd") + "\\";
                        if (!Directory.Exists(targetFolder))
                            Directory.CreateDirectory(targetFolder);

                        if (File.Exists(targetFolder + origFile.Name)) {
                            if (!havDupFileFolder || !Directory.Exists(dupFileFolder)) {
                                Directory.CreateDirectory(dupFileFolder);
                                havDupFileFolder = true;
                            }

                            targetFileFullName = dupFileFolder + origFile.Name;
                        }
                        else {
                            targetFileFullName = targetFolder + origFile.Name;
                        }

                        moveFileList.Add(origFile.FullName, targetFileFullName);
                    }

                    base.AllFile.Clear();
                    GC.Collect();

                    foreach (KeyValuePair<string, string> fileNamePare in moveFileList) {
                        if (this.MoveFile)
                            File.Move(fileNamePare.Key, fileNamePare.Value);
                        else
                            File.Copy(fileNamePare.Key, fileNamePare.Value, true);

                        count++;
                    }

                    if (this.MoveFile)
                        CommFunction.WriteMessage("移动完成！ 共 " + count + " 个文件。");
                    else
                        CommFunction.WriteMessage("复制完成！ 共 " + count + " 个文件。");
                }
            }
            catch (Exception ex) {
                CommFunction.WriteMessage(ex.Message);
                CommFunction.WriteMessage("已处理完成文件共 " + count + " 个。");
            }
        }
    }
}