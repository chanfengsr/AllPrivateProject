using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    class BLLDataImport:BLL
    {
        private readonly SqlConnection _cnn;
        private readonly DBODataImport _dbo;
        
        public BLLDataImport(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
            _dbo = new DBODataImport(_cnn);
        }

        public void OpenConnection()
        {
            if (_cnn.State == ConnectionState.Closed)
                _cnn.Open();
        }

        public void CloseConnection()
        {
            if (_cnn.State != ConnectionState.Closed)
                _cnn.Close();
        }

        /// <summary>从文件名获取市场类型及股票代码
        /// </summary>
        public List<TupleValue<FileInfo, StockHead>> LoadMrkTypeAndCode(List<FileInfo> allFile)
        {
            List<TupleValue<FileInfo, StockHead>> ret = new List<TupleValue<FileInfo, StockHead>>();

            foreach (FileInfo file in allFile)
            {
                string[] nameSplit = file.Name.Replace(file.Extension, "").Split('#');

                StockHead stkHead = new StockHead
                {
                    MarkType = nameSplit[0],
                    StkCode = nameSplit[1]
                };

                ret.Add(new TupleValue<FileInfo, StockHead>(file, stkHead));
            }

            return ret;
        }

        /// <summary> 获取表记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableRecordCount(string tableName)
        {
            return _dbo.GetTableRecordCount(tableName);
        }

        public int InsertStkKLine(TupleValue<FileInfo, StockHead> stkInfo, bool isConvert, bool isComposite, KLineType kLineType, bool haveRecord = true)
        {
            FileInfo fileInfo = stkInfo.Value1;
            StockHead stkHead = stkInfo.Value2;
            stkHead.StkType = isComposite ? "0" : "1";
            string tableName = BLL.GetDBTableName(kLineType, isComposite);
            DateTime existMaxDay = DateTime.MinValue;
            DataTable insTable = _dbo.GetEmptyTable(tableName);

            if (haveRecord)
            {
                if (isConvert)
                    _dbo.DeleteTable(tableName, stkHead);
                else
                    existMaxDay = _dbo.FindMaxExistTradeDay(tableName, stkHead);
            }
            
            this.LoadFileData(fileInfo, stkHead, existMaxDay, ref insTable);

            // 新增或修改 StockHead
            _dbo.InsertOrUpdateStockHead(stkHead);

            _dbo.BulkWriteTable(insTable, DataRowState.Added);

            return insTable.Rows.Count;
        }
        
        /// <summary>
        /// 从文本文件加载数据，小于最大日期的数据直接过滤掉
        /// </summary>
        private void LoadFileData(FileInfo fileInfo, StockHead stkHead, DateTime existMaxDay, ref DataTable insTable)
        {
            bool isConvert = existMaxDay == DateTime.MinValue;
            StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.Default);
            string line;
            decimal vol;
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
                    {
                        stkHead.StkName = split[1];
                        for (int i = 2; i < split.Length; i++)
                        {
                            if (split[i].IndexOf("日线") < 0 && split[i].IndexOf("分钟线") < 0)
                                stkHead.StkName += split[i];
                            else
                                break;
                        }
                    }

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
                            vol = decimal.Parse(split[idxVolume]);

                            if (vol > 0 )
                            {
                                DataRow newRow = insTable.NewRow();
                                newRow[idxTabMarkType] = stkHead.MarkType;
                                newRow[idxTabStkCode] = stkHead.StkCode;
                                newRow[idxTabTradeDay] = split[idxTradeDay];
                                newRow[idxTabOpen] = split[idxOpen];
                                newRow[idxTabHigh] = split[idxHigh];
                                newRow[idxTabLow] = split[idxLow];
                                newRow[idxTabClose] = split[idxClose];
                                newRow[idxTabVolume] = vol;
                                newRow[idxTabAmount] = split[idxAmount];

                                insTable.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }
        }

        /// <summary> 从数据库中加载指定板块的板块信息 key: 代码,板块类型,板块名称  value:RecId
        /// </summary>
        /// <param name="lstStockBlockType"></param>
        /// <returns></returns>
        private Dictionary<string, int> GetStockBlock(List<StockBlockType> lstStockBlockType)
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            DataTable dtBlock = _dbo.GetStockBlock(lstStockBlockType);

            foreach (DataRow dr in dtBlock.Rows)
            {
                string key = string.Format("{0},{1},{2}", dr["StkCode"], dr["BKType"], dr["BKName"]);
                int recId = (int)dr["RecId"];
                ret.Add(key, recId);
            }
            
            return ret;
        }

        /// <summary> 从通达信文件中加载 概念、风格、指数 板块数据
        /// </summary>
        private Dictionary<string, int> LoadGnFgZsBlockDataFile(List<StockBlockType> lstStockBlockType)
        {
            /*
             * 通达信V6.1概念板块分类文件格式分析
             http://blog.csdn.net/starsky2006/article/details/5863444
             */

            Dictionary<string, int> retDic= new Dictionary<string, int>();

            foreach (StockBlockType blockType in lstStockBlockType)
            {
                // 必须是 概念、风格、指数 之中的
                if (blockType != StockBlockType.gn && blockType != StockBlockType.fg && blockType != StockBlockType.zs) 
                    continue;

                string blockTypeName = BLL.StockBlockTypeName(blockType); // 概念、风格、指数
                string fileName = ( CommProp.TDXFolder + BLL.StockBlockFileName(blockType) ).Replace(@"\\", @"\");

                using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
                {
                    // 文件信息
                    string fileInfoStr = Encoding.Default.GetString(reader.ReadBytes(64)).TrimEnd('\0');

                    int indexStart = reader.ReadInt32(); // 板块索引信息起始位置
                    int bkInfoStart = reader.ReadInt32(); // 板块记录信息起始位置

                    reader.BaseStream.Seek(indexStart, SeekOrigin.Begin);
                    // 索引名称
                    string indexName = Encoding.Default.GetString(reader.ReadBytes(64)).TrimEnd('\0');

                    reader.BaseStream.Seek(bkInfoStart, SeekOrigin.Begin);
                    // 板块数量
                    int bkCount = reader.ReadInt16();

                    // 第一个版块的起始位置为0x182h。
                    int offect = bkInfoStart + 2;
                    for (int i = 0; i < bkCount; i++)
                    {
                        reader.BaseStream.Seek(offect, SeekOrigin.Begin);
                        // 板块名称
                        string bkName = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0');
                        // 证券数量
                        int stockCount = reader.ReadInt16();
                        // 板块级别 
                        int bkLevel = reader.ReadInt16();

                        // 每个板块最多包括400只股票。(2813 -9 - 2 - 2) / 7 =  400
                        for (int j = 0; j < 400; j++)
                        {
                            string stockCode = Encoding.Default.GetString(reader.ReadBytes(7)).TrimEnd('\0');
                            if (stockCode.Length == 0)
                                break;

                            string key = string.Format("{0},{1},{2}", stockCode, blockTypeName, bkName);
                            retDic.Add(key, 0);
                        }

                        offect += 2813; // 每个板块占的长度为2813个字节。
                    }
                }
            }

            return retDic;
        }

        /// <summary> 从通达信文件中加载 地区 板块数据
        /// </summary>
        private Dictionary<string, int> LoadDqBlockDataFile(StockBlockType blockType= StockBlockType.dq)
        {
            Dictionary<string, int> retDic = new Dictionary<string, int>();
            string[] fileNameSplit = BLL.StockBlockFileName(StockBlockType.dq).Split(',');
            string fileNameZs = ( CommProp.TDXFolder + fileNameSplit[0] ).Replace(@"\\", @"\");
            string fileNameDb = (CommProp.TDXFolder + fileNameSplit[1]).Replace(@"\\", @"\");
            string blockTypeName = BLL.StockBlockTypeName(blockType);

            string[] lines = File.ReadAllLines(fileNameZs, Encoding.Default);
            Dictionary<string, string> dicDqName = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                if (line.Length <= 0) break;
                string[] split = line.Split('|');
                if (split.Length == 6 && split[2] == "3")
                    dicDqName.Add(split[5], split[0]);
            }

            DataTable baseDbf = BLL.LoadBaseDbf(fileNameDb);
            if (baseDbf != null && baseDbf.Rows.Count > 0)
            {
                foreach (DataRow dr in baseDbf.Rows)
                {
                    string dqCode = dr["DY"].ToString().Trim();
                    if (dicDqName.ContainsKey(dqCode))
                    {
                        string stockCode = dr["GPDM"].ToString().Trim();
                        string bkName = dicDqName[dqCode];
                        string key = string.Format("{0},{1},{2}", stockCode, blockTypeName, bkName);
                        retDic.Add(key, 0);
                    }
                }
            }

            return retDic;
        }

        /// <summary> 批量更新板块数据
        /// </summary>
        /// <param name="dicData">[(代码,板块类型,板块名称), RecId]</param>
        /// <param name="operState"></param>
        private int BulkUpdateBlockData(List<KeyValuePair<string, int>> dicData, DataRowState operState)
        {
            const string tableName = "StockBlock";
            const string idxStkCode = "StkCode",
                         idxBKType = "BKType",
                         idxBKName = "BKName";


            if (operState == DataRowState.Deleted)
            {
                int[] aRecId = dicData.Select(kv => kv.Value).ToArray();
                _dbo.DeleteTableByRecId(aRecId);
            }
            else
            {
                DataTable dt = _dbo.GetEmptyTable(tableName);
                foreach (KeyValuePair<string, int> keyValue in dicData)
                {
                    string[] aBlock = keyValue.Key.Split(',');

                    DataRow newRow = dt.NewRow();
                    newRow[idxStkCode] = aBlock[0];
                    newRow[idxBKType] = aBlock[1];
                    newRow[idxBKName] = aBlock[2];

                    dt.Rows.Add(newRow);
                }

                if (dt.Rows.Count > 0)
                    _dbo.BulkWriteTable(dt, operState);
            }

            return dicData.Count;
        }

        /// <summary> 板块导入：概念、风格、指数
        /// </summary>
        private TupleValue<int, int> BlockImportGnFgZs()
        {
            int cntDel = 0, cntAdd = 0;
            List<StockBlockType> lstGnFgZs = new List<StockBlockType> {StockBlockType.gn, StockBlockType.fg, StockBlockType.zs};
            Dictionary<string, int> fileGnFgZsBlock = this.LoadGnFgZsBlockDataFile(lstGnFgZs);
            Dictionary<string, int> dbGnFgZsBlock = this.GetStockBlock(lstGnFgZs);

            // 需要删掉的：数据库中有，新文件中没有
            List<KeyValuePair<string, int>> dicNeedDelete = dbGnFgZsBlock.Where(dbBlock => !fileGnFgZsBlock.ContainsKey(dbBlock.Key)).ToList();

            // 需要新增的：新文件中有，数据库中没有
            List<KeyValuePair<string, int>> dicNeedAdd = fileGnFgZsBlock.Where(fBlock => !dbGnFgZsBlock.ContainsKey(fBlock.Key)).ToList();

            if (dicNeedDelete.Any())
                cntDel = this.BulkUpdateBlockData(dicNeedDelete, DataRowState.Deleted);

            if (dicNeedAdd.Any())
                cntAdd = this.BulkUpdateBlockData(dicNeedAdd, DataRowState.Added);

            return new TupleValue<int, int>(cntDel, cntAdd);
        }

        /// <summary> 板块导入：地区
        /// </summary>
        private TupleValue<int, int> BlockImportDq()
        {
            int cntDel = 0, cntAdd = 0;
            List<StockBlockType> lstDq = new List<StockBlockType> {StockBlockType.dq};
            Dictionary<string, int> fileDqBlock = this.LoadDqBlockDataFile();

            return new TupleValue<int, int>(cntDel, cntAdd);
        }

        /// <summary> 板块导入/更新
        /// </summary>
        public void BlockImport()
        {
            // todo Modify 
            this.BlockImportDq();
            return;

            int cntDel = 0, cntAdd = 0;
            TupleValue<int, int> cntGnFgZs = BlockImportGnFgZs();
            cntDel += cntGnFgZs.Value1;
            cntAdd += cntGnFgZs.Value2;
        }
    }
}