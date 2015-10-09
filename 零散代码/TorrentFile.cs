using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Collections;

namespace Zgke.OtherFile {
    ///<summary> 
    ///Torrent file 
    ///Zgke.OtherFile.TorrentFile File = new Zgke.OtherFile.TorrentFile( "r:\\a.torrent");
    ///2008-08-28 
    ///</Summary> 
    public class TorrentFile {
        #region private fields 

        private string _OpenError = "";
        private bool _OpenFile = false;
        private String _TorrentAnnounce = "";
        private IList<string> _TorrentAnnounceList = new List<string>();
        private DateTime _TorrentCreateTime = new DateTime(1970, 1, 1, 0, 0, 0);
        private long _TorrentCodePage = 0;
        private String _TorrentComment = "";
        private string _TorrentCreatedBy = "";
        private String _TorrentEncoding = "";
        private string _TorrentCommentUTF8 = "";
        private IList<TorrentFileInfoClass> _TorrentFileInfo = new List<TorrentFileInfoClass>();
        private String _TorrentName = "";
        private string _TorrentNameUTF8 = "";
        private long _TorrentPieceLength = 0;
        private byte[] _TorrentPieces;
        private string _TorrentPublisher = "";
        private string _TorrentPublisherUTF8 = "";
        private String _TorrentPublisherUrl = "";
        private string _TorrentPublisherUrlUTF8 = "";
        private IList<string> _TorrentNotes = new List<string>();

        #endregion

        #region Properties 

        ///<summary> 
        ///Error message 
        ///</ Summary> 
        public string OpenError {
            set {
                _OpenError = value;
            }
            get {
                return _OpenError;
            }
        }

        ///<summary> 
        ///Open the file normally 
        ///</ Summary> 
        public bool OpenFile {
            set {
                _OpenFile = value;
            }
            get {
                return _OpenFile;
            }
        }

        ///<summary> 
        ///URL of the server (string) 
        ///</ Summary> 
        public string TorrentAnnounce {
            set {
                _TorrentAnnounce = value;
            }
            get {
                return _TorrentAnnounce;
            }
        }

        ///<summary> 
        ///Standby tracker server list (list) 
        ///</ Summary> 
        public IList<string> TorrentAnnounceList {
            set {
                _TorrentAnnounceList = value;
            }
            get {
                return _TorrentAnnounceList;
            }
        }

        ///<summary> 
        ///Seed created the Unix Standard Time format, from 1970 January 1 00:00:00 to create the number of seconds (integer) 
        ///</ Summary> 
        public DateTime TorrentCreateTime {
            set {
                _TorrentCreateTime = value;
            }
            get {
                return _TorrentCreateTime;
            }
        }

        ///<summary> 
        ///Unknown digital CodePage 
        ///</ Summary> 
        public long TorrentCodePage {
            set {
                _TorrentCodePage = value;
            }
            get {
                return _TorrentCodePage;
            }
        }

        ///<summary> 
        ///Seed Description 
        ///</ Summary> 
        public string TorrentComment {
            set {
                _TorrentComment = value;
            }
            get {
                return _TorrentComment;
            }
        }

        ///<summary> 
        ///Encoding 
        ///</ Summary> 
        public string TorrentCommentUTF8 {
            set {
                _TorrentCommentUTF8 = value;
            }
            get {
                return _TorrentCommentUTF8;
            }
        }

        ///<summary> 
        ///Create 
        ///</ Summary> 
        public string TorrentCreatedBy {
            set {
                _TorrentCreatedBy = value;
            }
            get {
                return _TorrentCreatedBy;
            }
        }

        ///<summary> 
        ///Encoding 
        ///</ Summary> 
        public string TorrentEncoding {
            set {
                _TorrentEncoding = value;
            }
            get {
                return _TorrentEncoding;
            }
        }

        ///<summary> 
        ///File Information 
        ///</ Summary> 
        public IList<TorrentFileInfoClass> TorrentFileInfo {
            set {
                _TorrentFileInfo = value;
            }
            get {
                return _TorrentFileInfo;
            }
        }

        ///<summary> 
        ///Seed name 
        ///</ Summary> 
        public string TorrentName {
            set {
                _TorrentName = value;
            }
            get {
                return _TorrentName;
            }
        }

        ///<summary> 
        ///Seed name UTF8 
        ///</ Summary> 
        public string TorrentNameUTF8 {
            set {
                _TorrentNameUTF8 = value;
            }
            get {
                return _TorrentNameUTF8;
            }
        }

        ///<summary> 
        ///For each block size, in bytes (integer) 
        ///</ Summary> 
        public long TorrentPieceLength {
            set {
                _TorrentPieceLength = value;
            }
            get {
                return _TorrentPieceLength;
            }
        }

        ///<summary> 
        ///20 bytes of each block SHA1 hash value (binary format) 
        ///</ Summary> 
        private byte[] TorrentPieces {
            set {
                _TorrentPieces = value;
            }
            get {
                return _TorrentPieces;
            }
        }

        ///<summary> 
        ///Publishing 
        ///</ Summary> 
        public string TorrentPublisher {
            set {
                _TorrentPublisher = value;
            }
            get {
                return _TorrentPublisher;
            }
        }

        ///<summary> 
        ///Publishing UTF8 
        ///</ Summary> 
        public string TorrentPublisherUTF8 {
            set {
                _TorrentPublisherUTF8 = value;
            }
            get {
                return _TorrentPublisherUTF8;
            }
        }

        ///<summary> 
        ///Publishing address 
        ///</ Summary> 
        public string TorrentPublisherUrl {
            set {
                _TorrentPublisherUrl = value;
            }
            get {
                return _TorrentPublisherUrl;
            }
        }

        ///<summary> 
        ///Publishing address 
        ///</ Summary> 
        public string TorrentPublisherUrlUTF8 {
            set {
                _TorrentPublisherUrlUTF8 = value;
            }
            get {
                return _TorrentPublisherUrlUTF8;
            }
        }

        ///<summary> 
        ///NODES 
        ///</ Summary> 
        public IList<string> TorrentNotes {
            set {
                _TorrentNotes = value;
            }
            get {
                return _TorrentNotes;
            }
        }

        #endregion

        public TorrentFile(string filename) {
            System.IO.FileStream TorrentFile = new System.IO.FileStream(filename, System.IO.FileMode.Open);
            byte[] TorrentBytes = new byte[TorrentFile.Length];
            TorrentFile.Read(TorrentBytes, 0, TorrentBytes.Length);
            TorrentFile.Close();

            if ((char)TorrentBytes[0] != 'd') {
                if (OpenError.Length == 0) OpenError = "Error Torrent files, beginning with the first byte is not 100";
                return;
            }
            GetTorrentData(TorrentBytes);
        }

        #region began to read data 

        ///<summary> 
        ///Start reading 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        private void GetTorrentData(byte[] TorrentBytes) {
            int StarIndex = 0;
            while (true) {


                object Keys = GetKeyText(TorrentBytes, ref StarIndex);
                if (Keys == null) {
                    if (StarIndex >= TorrentBytes.Length) OpenFile = true;
                    break;
                }
                if (GetValueText(TorrentBytes, ref StarIndex, Keys.ToString().ToUpper()) == false) break;
            }
        }

        #endregion

        ///<summary> 
        ///Read structure 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        ///<param Name="Keys"> </ param> 
        ///<returns> </ Returns> 
        private bool GetValueText(byte[] TorrentBytes, ref int StarIndex, string Keys) {
            switch (Keys) {
                case "announce":
                    TorrentAnnounce = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "ANNOUNCE-LIST":
                    int ListCount = 0;
                    ArrayList _TempList = GetKeyData(TorrentBytes, ref StarIndex, ref ListCount);
                    for (int i = 0; i != _TempList.Count; i++) {
                        TorrentAnnounceList.Add(_TempList[i].ToString());
                    }
                    break;
                case "CREATION DATE":
                    object Date = GetKeyNumb(TorrentBytes, ref StarIndex).ToString();
                    if (Date == null) {
                        if (OpenError.Length == 0) OpenError = "CREATION DATE return is not a number type";
                        return false;
                    }
                    TorrentCreateTime = TorrentCreateTime.AddTicks(long.Parse(Date.ToString()));
                    break;
                case "CODEPAGE":
                    object CodePageNumb = GetKeyNumb(TorrentBytes, ref StarIndex);
                    if (CodePageNumb == null) {
                        if (OpenError.Length == 0) OpenError = "CODEPAGE return is not a number type";
                        return false;
                    }
                    TorrentCodePage = long.Parse(CodePageNumb.ToString());
                    break;
                case "encoding":
                    TorrentEncoding = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "Created by":
                    TorrentCreatedBy = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "comment":
                    TorrentComment = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "COMMENT.UTF-8":
                    TorrentCommentUTF8 = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "INFO":
                    int FileListCount = 0;
                    GetFileInfo(TorrentBytes, ref StarIndex, ref FileListCount);
                    break;
                case "NAME":
                    TorrentName = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "NAME.UTF-8":
                    TorrentNameUTF8 = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "PIECE LENGTH":
                    object PieceLengthNumb = GetKeyNumb(TorrentBytes, ref StarIndex);
                    if (PieceLengthNumb == null) {
                        if (OpenError.Length == 0) OpenError = "PIECE LENGTH return is not a number type";
                        return false;
                    }
                    TorrentPieceLength = long.Parse(PieceLengthNumb.ToString());
                    break;
                case "pieces":
                    TorrentPieces = GetKeyByte(TorrentBytes, ref StarIndex);
                    break;
                case "publisher":
                    TorrentPublisher = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "PUBLISHER.UTF-8":
                    TorrentPublisherUTF8 = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "PUBLISHER-URL":
                    TorrentPublisherUrl = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "PUBLISHER-URL.UTF-8":
                    TorrentPublisherUrlUTF8 = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                    break;
                case "nodes":
                    int NodesCount = 0;
                    ArrayList _NodesList = GetKeyData(TorrentBytes, ref StarIndex, ref NodesCount);
                    int IPCount = _NodesList.Count / 2;
                    for (int i = 0; i != IPCount; i++) {
                        TorrentNotes.Add(_NodesList[i * 2] + ":" + _NodesList[( i * 2 ) + 1]);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        #region to obtain data 

        ///<summary> 
        ///Get the list "I1: Xe =" X "will be called GetKeyText 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        ///<param Name="ListCount"> </ param> 
        private ArrayList GetKeyData(byte[] TorrentBytes, ref int StarIndex, ref int ListCount) {
            ArrayList _TempList = new ArrayList();
            while (true) {
                string TextStar = Encoding.UTF8.GetString(TorrentBytes, StarIndex, 1);
                switch (TextStar) {
                    case "l":
                        StarIndex ++;
                        ListCount ++;
                        break;
                    case "e":
                        ListCount --;
                        StarIndex ++;
                        if (ListCount == 0) return _TempList;
                        break;
                    case "i":
                        _TempList.Add(GetKeyNumb(TorrentBytes, ref StarIndex).ToString());
                        break;
                    default:
                        object ListText = GetKeyText(TorrentBytes, ref StarIndex);
                        if (ListText != null) {
                            _TempList.Add(ListText.ToString());
                        }
                        else {
                            if (OpenError.Length == 0) {
                                OpenError = "error Torrent file ANNOUNCE-LIST error";
                                return _TempList;
                            }
                        }
                        break;
                }
            }
        }

        ///<summary> 
        ///Get the string 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        ///<returns> </ Returns> 
        private object GetKeyText(byte[] TorrentBytes, ref int StarIndex) {
            int Numb = 0;
            int LeftNumb = 0;
            for (int i = StarIndex; i != TorrentBytes.Length; i++) {

                if ((char)TorrentBytes[i] == ':') break;
                if ((char)TorrentBytes[i] == 'e') {
                    LeftNumb ++;
                    continue;
                }
                Numb ++;
            }
            StarIndex += LeftNumb;
            string TextNumb = Encoding.UTF8.GetString(TorrentBytes, StarIndex, Numb);
            try {
                int ReadNumb = Int32.Parse(TextNumb);
                StarIndex = StarIndex + Numb + 1;
                object KeyText = Encoding.UTF8.GetString(TorrentBytes, StarIndex, ReadNumb);
                StarIndex += ReadNumb;
                return KeyText;
            }
            catch {
                return null;
            }
        }

        ///<summary> 
        ///Get the number 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        private object GetKeyNumb(byte[] TorrentBytes, ref int StarIndex) {
            if (Encoding.UTF8.GetString(TorrentBytes, StarIndex, 1) == "i") {

                int Numb = 0;
                for (int i = StarIndex; i != TorrentBytes.Length; i++) {
                    if ((char)TorrentBytes[i] == 'e') break;
                    Numb ++;
                }
                StarIndex ++;
                long RetNumb = 0;
                try {
                    RetNumb = long.Parse(Encoding.UTF8.GetString(TorrentBytes, StarIndex, Numb - 1));
                    StarIndex += Numb;
                    return RetNumb;
                }
                catch {
                    return null;
                }

            }
            else {
                return null;
            }

        }

        ///<summary> 
        ///Get BYTE data 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        ///<returns> </ Returns> 
        private byte[] GetKeyByte(byte[] TorrentBytes, ref int StarIndex) {
            int Numb = 0;
            for (int i = StarIndex; i != TorrentBytes.Length; i++) {
                if ((char)TorrentBytes[i] == ':') break;
                Numb ++;
            }
            string TextNumb = Encoding.UTF8.GetString(TorrentBytes, StarIndex, Numb);
            try {
                int ReadNumb = Int32.Parse(TextNumb);
                StarIndex = StarIndex + Numb + 1;
                System.IO.MemoryStream KeyMemory = new System.IO.MemoryStream(TorrentBytes, StarIndex, ReadNumb);
                byte[] KeyBytes = new byte[ReadNumb];
                KeyMemory.Read(KeyBytes, 0, ReadNumb);
                KeyMemory.Close();
                StarIndex += ReadNumb;
                return KeyBytes;
            }
            catch {
                return null;
            }

        }

        ///<summary> 
        ///To deal with the structure of the INFO 
        ///</ Summary> 
        ///<param Name="TorrentBytes"> </ param> 
        ///<param Name="StarIndex"> </ param> 
        ///<param Name="ListCount"> </ param> 
        private void GetFileInfo(byte[] TorrentBytes, ref int StarIndex, ref int ListCount) {
            if ((char)TorrentBytes[StarIndex] != 'd') return;
            StarIndex ++;
            if (GetKeyText(TorrentBytes, ref StarIndex).ToString().ToUpper() == "FILES") {
                TorrentFileInfoClass Info = new TorrentFileInfoClass();
                while (true) {

                    string TextStar = Encoding.UTF8.GetString(TorrentBytes, StarIndex, 1);

                    switch (TextStar) {
                        case "l":
                            StarIndex ++;
                            ListCount ++;
                            break;
                        case "e":
                            ListCount --;
                            StarIndex ++;
                            if (ListCount == 1) TorrentFileInfo.Add(Info);
                            if (ListCount == 0) return;
                            break;
                        case "d":
                            Info = new TorrentFileInfoClass();
                            ListCount  ++;
                            StarIndex ++;
                            break;
                        default:
                            object ListText = GetKeyText(TorrentBytes, ref StarIndex);
                            if (ListText == null) return;
                            switch (ListText.ToString().ToUpper()) // convert to uppercase 
                            {
                                case "ED2K":
                                    Info.De2K = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                                    break;
                                case "THE FILEHASH":
                                    Info.FileHash = GetKeyText(TorrentBytes, ref StarIndex).ToString();
                                    break;
                                case "LENGTH":
                                    Info.Length = Convert.ToInt64(GetKeyNumb(TorrentBytes, ref StarIndex));
                                    break;
                                case "PATH":
                                    int pathcount = 0;
                                    ArrayList PathList = GetKeyData(TorrentBytes, ref StarIndex, ref pathcount);
                                    string Temp = "";
                                    for (int i = 0; i != PathList.Count; i ++) {
                                        Temp += PathList[i].ToString();
                                    }
                                    Info.Path = Temp;
                                    break;
                                case "PATH.UTF-8":
                                    int PathUtf8Count = 0;
                                    ArrayList Pathutf8List = GetKeyData(TorrentBytes, ref StarIndex, ref PathUtf8Count);
                                    string UtfTemp = "";
                                    for (int i = 0; i != Pathutf8List.Count; i ++) {
                                        UtfTemp += Pathutf8List[i].ToString();
                                    }
                                    Info.PathUTF8 = UtfTemp;
                                    break;
                            }

                            break;
                    }
                }

            }
        }

        #endregion

        ///<summary> 
        ///When corresponding structures INFO multiple files 
        ///</ Summary> 
        public class TorrentFileInfoClass {
            private string path = "";
            private string pathutf8 = "";
            private long length = 0;
            private string md5sum = "";
            private String de2k = "";
            private string filehash = "";

            ///<summary> 
            ///File path 
            ///</ Summary> 
            public string Path {
                get {
                    return path;
                }
                set {
                    path = value;
                }
            }

            ///<summary> 
            ///UTF8 name 
            ///</ Summary> 
            public string PathUTF8 {
                get {
                    return pathutf8;
                }
                set {
                    pathutf8 = value;
                }
            }

            ///<summary> 
            ///File Size 
            ///</ Summary> 
            public long Length {
                get {
                    return length;
                }
                set {
                    length = value;
                }
            }

            ///<summary> 
            ///MD5 inspection efficiency (optional) 
            ///</ Summary> 
            public string MD5Sum {
                get {
                    return md5sum;
                }
                set {
                    md5sum = value;
                }
            }

            ///<summary> 
            ///ED2K unknown to 
            ///</ Summary> 
            public string De2K {
                get {
                    return de2k;
                }
                set {
                    de2k = value;
                }
            }

            ///<summary> 
            ///  The FileHash unknown 
            ///</ Summary> 
            public string FileHash {
                get {
                    return filehash;
                }
                set {
                    filehash = value;
                }
            }
        }
    }
}