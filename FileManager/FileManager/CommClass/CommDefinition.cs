using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager {
    /// <summary>文件排序模式
    /// </summary>
    internal enum FileSortMode {
        /// <summary>按文件名</summary>
        FileName,
        /// <summary>按文件创建日期</summary>
        CreateDate,
        /// <summary>按文件修改日期</summary>
        ModifyDate,
        /// <summary>按优先级：拍摄日期，修改日期</summary>
        RecordingDate,
        /// <summary>按优先级：文件名日期，拍摄日期，修改日期</summary>
        DateInFileName
    }

    /// <summary>文件改名规则
    /// </summary>
    internal enum FileChangeRule {
        /// <summary>去掉固定字符串（正则表达式）</summary>
        FixedString,
        /// <summary>前后缀 + 通配符</summary>
        Wildcard,
        /// <summary>指定列表</summary>
        SpecList
    }

    /// <summary>界面输入参数
    /// </summary>
    internal struct FileSelectParm {
        /// <summary>源文件夹</summary>
        public string SourceFileFolder { get; set; }

        /// <summary>目标文件夹</summary>
        public string TargetFileFolder { get; set; }

        /// <summary>文件类型过滤</summary>
        public string FileFilter { get; set; }

        /// <summary>文件类型为忽略类型</summary>
        public bool FileTypeIsIgnore { get; set; }

        /// <summary>排序方式</summary>
        public FileSortMode FileSortBy { get; set; }

        /// <summary>是否指定文件列表</summary>
        public bool UseSpecFileList { get; set; }

        /// <summary>指定的需要复制、移动的文件列表</summary>
        public string SpecFileList { get; set; }
    }

    internal class CommDefinition {
        /// <summary>图片类型文件后缀</summary>
        public static string ExtensionPicFile = "BMP|PCX|TIFF|GIF|JPEG|JPG|TGA|EXIF|FPX|SVG|PSD|CDR|PCD|DXF|UFO|EPS|AI|PNG|HDRI|RAW";

        /// <summary>声音类型文件后缀</summary>
        public static string ExtensionAudioFile = "WAV|MP3|RA|RMA|WMA|ASF|MID|MIDI|RMI|XMI|OGG|VQF|TVQ|MOD|APE|AIFF|AU|FLAC";

        /// <summary>视频文件后缀</summary>
        public static string ExtensionVideoFile = "3GP|ASF|AVI|FLV|MKV|MOV|MP4|MPEG|AVI|RMVB|WMV|SWF";

        /// <summary>文本类型文件后缀</summary>
        public static string ExtensionTextFile = "TXT|DOC|DOCX|HLP|WPS|RTF|HTML|HTM|PDF";
    }
}