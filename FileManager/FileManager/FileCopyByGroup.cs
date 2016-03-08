using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager {
    internal class FileCopyByGroup : FileProcessBaseClass {
        private bool MoveFile { get; set; }
        
        public FileCopyByGroup() {
            this.MoveFile = false;
        }

        //public void SetFileSelect(string sourceFolder, string targetFolder, string fileFilter, FileSortMode fileSortBy, bool useSpecCopyList, string specCopyList = "") {
        //    FileSelParm.SourceFileFolder = sourceFolder;
        //    FileSelParm.TargetFileFolder = targetFolder;
        //    FileSelParm.FileFilter = fileFilter;
        //    FileSelParm.UseSpecFileList = useSpecCopyList;
        //    FileSelParm.SpecFileList = specCopyList;
        //}

        public void SetFunctionRule(bool moveFile) {
            this.MoveFile = moveFile;
        }

        public void Execute() {
            int count = 0;
            string sourceFolder = FileSelParm.SourceFileFolder;
            string origTargetFolder = FileSelParm.TargetFileFolder;
            string targetFolder;
            string dupFileFolder; //重复文件放的文件夹
            bool havDupFileFolder = false;
            DateTime fileDate;
            Dictionary<string, string> moveFileList = new Dictionary<string, string>();

            if (Directory.Exists(origTargetFolder)) {
                CommFunction.WriteMessage("目标文件夹不存在！");
                return;
            }

            if (!origTargetFolder.EndsWith("\\"))
                origTargetFolder = origTargetFolder + "\\";

            dupFileFolder = origTargetFolder + "Duplicate files\\";
            base.AllFile.Clear();
            if (base.LoadFileList().Length > 0) {
                //Load to moveFileList
                foreach (FileInfo fileInfo in base.AllFile) {
                    //隐藏文件和系统文件就不要过来凑热闹了
                    if ( /*( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden || */
                        (fileInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                        continue;
                    

                }
            }
        }
    }
}