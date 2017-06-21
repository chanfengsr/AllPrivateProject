using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    class BLLDataImport
    {
        private SqlConnection _cnn;
        private DBODataImport _dbo;

        public BLLDataImport(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
            _dbo = new DBODataImport(_cnn);
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
            string tableName = BLL.GetDBTableName(kLineType);
            DateTime existMaxDay = DateTime.MinValue;
            DataTable insTable = _dbo.GetEmptyTable(tableName);

            insTable.TableName = tableName;

            if (isConvert)
                _dbo.DeleteTable(tableName, stkHead);
            else
                existMaxDay = _dbo.FindMaxExistTradeDay(tableName, stkHead);

            this.LoadFileData(fileInfo, stkHead, existMaxDay, ref insTable);

            // 新增或修改 StockHead
            _dbo.InsertOrUpdateStockHead(stkHead);

            // 插入实体数据
            _dbo.BulkInsertTable(insTable);
        }

        public void TruncateStkKLine(KLineType kLineType)
        {
            string tableName = BLL.GetDBTableName(kLineType);
            _dbo.TruncateTable(tableName);
        }

        /// <summary>
        /// 从文本文件加载数据，小于最大日期的数据直接过滤掉
        /// </summary>
        private void LoadFileData(FileInfo fileInfo, StockHead stkHead, DateTime existMaxDay, ref DataTable insTable)
        {
            bool isConvert = existMaxDay == DateTime.MinValue;
            StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.Default);
            string line;
            const string idxTabMarkType = "MarkType",
                         idxTabStkCode = "StkCode",
                         idxTabTradeDay = "TradeDay",
                         idxTabOpen = "Open",
                         idxTabHigh = "High",
                         idxTabLow = "Low",
                         idxTabClose = "Close",
                         idxTabVolume = "Volume",
                         idxTabAmount = "Amount";
            const int idxTradeDay = 0,
                      idxOpen = 1,
                      idxHigh = 2,
                      idxLow = 3,
                      idxClose = 4,
                      idxVolume = 5,
                      idxAmount = 6;

            bool firstLine = true;
            while (( line = sr.ReadLine() ) != null)
            {
                // 第一行中有股票名称
                if (firstLine)
                {
                    string[] split = line.Split(' ');
                    if (split.Length > 1)
                        stkHead.StkName = split[1];

                    firstLine = false;
                }
                // 第三行开始为数据
                else
                {
                    string[] split = line.Split('\t');
                    DateTime tradeDate;
                    if (DateTime.TryParse(split[0], out tradeDate))
                    {
                        if (isConvert || tradeDate > existMaxDay)
                        {
                            DataRow newRow = insTable.NewRow();
                            newRow[idxTabMarkType] = stkHead.MarkType;
                            newRow[idxTabStkCode] = stkHead.StkCode;
                            newRow[idxTabTradeDay] = split[idxTradeDay];
                            newRow[idxTabOpen] = split[idxOpen];
                            newRow[idxTabHigh] = split[idxHigh];
                            newRow[idxTabLow] = split[idxLow];
                            newRow[idxTabClose] = split[idxClose];
                            newRow[idxTabVolume] = split[idxVolume];
                            newRow[idxTabAmount] = split[idxAmount];

                            insTable.Rows.Add(newRow);
                        }
                    }
                }
            }
        }
    }
}