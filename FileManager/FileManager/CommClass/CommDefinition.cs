using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager {
    internal enum FileSortMode {
        FileName,
        CreateDate,
        ModifyDate,
        RecordingDate,
        DateInFileName
    }

    internal enum FileChangeRule {
        FixedString,
        Wildcard,
        SpecList
    }

    internal struct FileSelectParm {
        public string SourceFileFolder { get; set; }
        public string TargetFileFolder { get; set; }
        public string FileFilter { get; set; }
        public FileSortMode FileSortBy { get; set; }
        public bool UseSpecFileList { get; set; }
        public string SpecFileList { get; set; } //指定的需要复制、移动的文件列表
    }

    internal class CommDefinition {
        public static string ExtensionPicFile = "BMP|PCX|TIFF|GIF|JPEG|JPG|TGA|EXIF|FPX|SVG|PSD|CDR|PCD|DXF|UFO|EPS|AI|PNG|HDRI|RAW";
        public static string ExtensionAudioFile = "WAV|MP3|RA|RMA|WMA|ASF|MID|MIDI|RMI|XMI|OGG|VQF|TVQ|MOD|APE|AIFF|AU|FLAC";
        public static string ExtensionVideoFile = "3GP|ASF|AVI|FLV|MKV|MOV|MP4|MPEG|AVI|RMVB|WMV|SWF";
        public static string ExtensionTextFile = "TXT|DOC|DOCX|HLP|WPS|RTF|HTML|HTM|PDF";
    }
}