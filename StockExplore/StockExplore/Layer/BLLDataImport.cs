using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    class BLLDataImport
    {
        private SqlConnection _cnn;

        public BLLDataImport(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_cnn.State == System.Data.ConnectionState.Closed)
                _cnn.Open();
        }

        public void CloseConnection()
        {
            if (_cnn.State != System.Data.ConnectionState.Closed)
                _cnn.Close();
        }

        public List<TupleValue<FileInfo, StockHead>> LoadMrkTypeAndCode(List<FileInfo> allFile)
        {
            List<TupleValue<FileInfo, StockHead>> ret = new List<TupleValue<FileInfo, StockHead>>();

            foreach (FileInfo file in allFile)
            {
                string[] nameSplit = file.Name.Replace(file.Extension, "").Split('#');

                StockHead stkHead = new StockHead()
                {
                    MarkType = nameSplit[0],
                    StkCode = nameSplit[1]
                };

                ret.Add(new TupleValue<FileInfo, StockHead>(file, stkHead));
            }

            return ret;
        }

        public void InsertStkKLine(TupleValue<FileInfo, StockHead> stkInfo, bool isConvert, bool isComposite, KLineType kLineType)
        {
            FileInfo fileInfo = stkInfo.Value1;
            StockHead stkHead = stkInfo.Value2;
            stkHead.StkType = isComposite ? "0" : "1";

            if (isConvert)
                this.InsertStkKLine_Convert(fileInfo, stkHead, kLineType);
            else
                this.InsertStkKLine_AddNew(fileInfo, stkHead, kLineType);
        }

        private void InsertStkKLine_Convert(FileInfo fileInfo, StockHead stkHead, KLineType kLineType)
        { 
            // todo
            switch (kLineType)
            {
                case KLineType.Day:
                    break;
                case KLineType.Week:
                    break;
                case KLineType.Month:
                    break;
                case KLineType.Minute:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("kLineType");
            }
        }

        private void InsertStkKLine_AddNew(FileInfo fileInfo, StockHead stkHead, KLineType kLineType)
        {
            // todo
            switch (kLineType)
            {
                case KLineType.Day:
                    break;
                case KLineType.Week:
                    break;
                case KLineType.Month:
                    break;
                case KLineType.Minute:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("kLineType");
            }
        }
    }
}