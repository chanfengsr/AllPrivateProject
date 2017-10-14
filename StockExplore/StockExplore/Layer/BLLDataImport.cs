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

        /// <summary> 
        /// 从通达信导出的文件 / 自有文件 名获取市场类型及股票代码
        /// 返回值：List<TupleValue<完整文件名, StockHead>>
        /// </summary>
        public List<TupleValue<string, StockHead>> LoadMrkTypeAndCodeFromDataFile(List<FileInfo> allFile, bool isComposite, bool useTDXFile)
        {
            List<TupleValue<string, StockHead>> ret = new List<TupleValue<string, StockHead>>();
            List<string> codeList;

            if (isComposite)
                codeList =_dbo.GetZSCodeList(); 
            else
                codeList = _dbo.GetStockACodeList();
            
            foreach (FileInfo file in allFile)
            {
                string[] nameSplit;

                if (useTDXFile)
                    nameSplit = new[] {file.Name.Substring(0, 2), file.Name.Substring(2, 6)};
                else
                    nameSplit = file.Name.Replace(file.Extension, "").Split('#');

                StockHead stkHead = new StockHead
                {
                    MarkType = nameSplit[0].ToLower(),
                    StkCode = nameSplit[1],
                    StkType = isComposite ? "0" : "1"
                };

                if (codeList.Contains(stkHead.StkCode))
                    ret.Add(new TupleValue<string, StockHead>(file.FullName, stkHead));
            }

            return ret;
        }

        /// <summary> 返回数据库中存在的，通达信 日线数据文件完整文件名列表
        /// </summary>
        /// <param name="isComposite"></param>
        /// <returns></returns>
        public List<string> GetMatchedTDXDayFileFullNameList(bool isComposite)
        {
            // 例：["sh600001"]
            List<string> lstStockFullName = _dbo.GetStockFullName(isComposite: isComposite);

            // 例：["sh600001", fileFullName ]
            Dictionary<string, string> tdxDayLineFile = this.GetAllTDXDayLineFile();

            return tdxDayLineFile.Where(pair => lstStockFullName.Contains(pair.Key.ToLower())).Select(pair => pair.Value).ToList();
        }

        /// <summary> 获取表记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableRecordCount(string tableName)
        {
            return _dbo.GetTableRecordCount(tableName);
        }

        public int InsertStkKLine(TupleValue<string, StockHead> stkInfo, bool isConvert, bool isComposite, bool useTDXFile, KLineType kLineType, bool haveRecord = true)
        {
            string fileFullName = stkInfo.Value1;
            StockHead stkHead = stkInfo.Value2;
            string tableName = BLL.GetKLineDBTableName(kLineType, isComposite);
            DateTime existMaxDay = DateTime.MinValue;
            DataTable insTable = _dbo.GetEmptyTable(tableName);

            if (haveRecord)
            {
                if (isConvert)
                    _dbo.DeleteTable(tableName, stkHead);
                else
                    existMaxDay = _dbo.FindMaxExistTradeDay(tableName, stkHead);
            }

            if (useTDXFile)
                this.LoadDayLineFileData_TDXDayFile(fileFullName, stkHead, existMaxDay, ref insTable);
            else
                this.LoadDayLineFileData_exportFile(fileFullName, stkHead, existMaxDay, ref insTable);

            _dbo.BulkWriteTable(insTable, DataRowState.Added);

            return insTable.Rows.Count;
        }

        /// <summary>
        /// 从文本文件加载数据，小于最大日期的数据直接过滤掉
        /// </summary>
        private void LoadDayLineFileData_exportFile(string fileFullName, StockHead stkHead, DateTime existMaxDay, ref DataTable insTable)
        {
            bool isConvert = existMaxDay == DateTime.MinValue;
            StreamReader sr = new StreamReader(fileFullName, Encoding.Default);
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
                    if (DateTime.TryParse(split[idxTradeDay], out tradeDate))
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
        
        /// <summary>
        /// 从文本文件加载数据，小于最大日期的数据直接过滤掉
        /// </summary>
        private void LoadDayLineFileData_TDXDayFile(string fileFullName, StockHead stkHead, DateTime existMaxDay, ref DataTable insTable)
        {
            bool isConvert = existMaxDay == DateTime.MinValue;
            const string idxTabMarkType = "MarkType",
                         idxTabStkCode = "StkCode",
                         idxTabTradeDay = "TradeDay",
                         idxTabOpen = "Open",
                         idxTabHigh = "High",
                         idxTabLow = "Low",
                         idxTabClose = "Close",
                         idxTabVolume = "Volume",
                         idxTabAmount = "Amount";

            const int lineLength = 32;
            using (var reader = new BinaryReader(File.OpenRead(fileFullName))) //  C:\new_tdx\vipdoc\sz\lday\sz399001.day
            {
                long len = reader.BaseStream.Length / lineLength;
                for (int i = 0; i < len; i++)
                {
                    string dateOrg = reader.ReadUInt32().ToString();
                    double open = reader.ReadInt32() / 100.00;
                    double high = reader.ReadInt32() / 100.00;
                    double low = reader.ReadInt32() / 100.00;
                    double close = reader.ReadInt32() / 100.00;
                    float amount = reader.ReadSingle();
                    int vol = reader.ReadInt32();
                    reader.ReadInt32(); //reservation
                    
                    string dateStr = dateOrg.Substring(0, 4) + "/" + dateOrg.Substring(4, 2) + "/" + dateOrg.Substring(6, 2);
                    DateTime tradeDate;
                    if (DateTime.TryParse(dateStr, out tradeDate) &&
                        ( isConvert || tradeDate > existMaxDay ) &&
                        vol > 0)
                    {
                        DataRow newRow = insTable.NewRow();
                        newRow[idxTabMarkType] = stkHead.MarkType;
                        newRow[idxTabStkCode] = stkHead.StkCode;
                        newRow[idxTabTradeDay] = tradeDate;
                        newRow[idxTabOpen] = open;
                        newRow[idxTabHigh] = high;
                        newRow[idxTabLow] = low;
                        newRow[idxTabClose] = close;
                        newRow[idxTabVolume] = vol;
                        newRow[idxTabAmount] = amount;

                        insTable.Rows.Add(newRow);
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
            const string formatMod = "{0},{1},{2}";

            foreach (DataRow dr in dtBlock.Rows)
            {
                string key = string.Format(formatMod, dr["StkCode"], dr["BKType"], dr["BKName"]);
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
            const string formatMod = "{0},{1},{2}";

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

                            string key = string.Format(formatMod, stockCode, blockTypeName, bkName);
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
            const string formatMod = "{0},{1},{2}";

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
                        string key = string.Format(formatMod, stockCode, blockTypeName, bkName);
                        retDic.Add(key, 0);
                    }
                }
            }

            return retDic;
        }

        /// <summary> 获取 行业、行业明细 代码对应名称
        /// </summary>
        private TupleValue<Dictionary<string, string>, Dictionary<string, string>> GetHyHydetDictionary(string fileName)
        {
            Dictionary<string, string> dicHy = new Dictionary<string, string>();
            Dictionary<string, string> dicHyDet = new Dictionary<string, string>();
            bool begHy = false, begHyDet = false;

            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            foreach (string line in lines)
            {
                if (!begHy && !begHyDet)
                {
                    if (line.Trim() == "#SWHY")
                    {
                        begHy = true;
                        continue;
                    }

                    if (line.Trim() == "#TDXNHY")
                    {
                        begHyDet = true;
                        continue;
                    }
                }
                else
                {
                    if (line.Trim() == "######")
                    {
                        begHy = begHyDet = false;
                        continue;
                    }
                }

                if (begHy || begHyDet)
                {
                    string[] splitHy = line.Split('|');
                    if (splitHy.Length != 2) continue;

                    if (begHy)
                        dicHy.Add(splitHy[0], splitHy[1]);
                    else
                        dicHyDet.Add(splitHy[0], splitHy[1]);
                }
            }

            return new TupleValue<Dictionary<string, string>, Dictionary<string, string>>(dicHy, dicHyDet);
        }

        /// <summary> 从通达信文件中加载 行业、行业明细 板块数据
        /// </summary>
        private Dictionary<string, int> LoadHyHyDetBlockDataFile(List<StockBlockType> lstStockBlockType)
        {
            Dictionary<string, int> retDic = new Dictionary<string, int>();
            const string formatMod = "{0},{1},{2}";

            if (lstStockBlockType.Contains(StockBlockType.hy))
            {
                string[] fileNameSplit = BLL.StockBlockFileName(StockBlockType.hy).Split(',');
                string fileNamIncon = (CommProp.TDXFolder + fileNameSplit[0]).Replace(@"\\", @"\");
                string fileNameHy = (CommProp.TDXFolder + fileNameSplit[1]).Replace(@"\\", @"\");
                string blockTypeNameHy = BLL.StockBlockTypeName(StockBlockType.hy),
                       blockTypeNameHyDet = BLL.StockBlockTypeName(StockBlockType.hyDet);

                // 获取 行业、行业明细 代码对应名称
                TupleValue<Dictionary<string, string>, Dictionary<string, string>> tupleDic = this.GetHyHydetDictionary(fileNamIncon);
                Dictionary<string, string> dicHy = tupleDic.Value1;
                Dictionary<string, string> dicHyDet = tupleDic.Value2;

                // 股票代码与其 行业、行业明细 代码对应
                string[] lines = File.ReadAllLines(fileNameHy, Encoding.Default);
                foreach (string line in lines)
                {
                    string[] split = line.Split('|');
                    if (split.Length != 4) break;

                    string stockCode = split[1];
                    string hyDetCode = split[2];
                    string hyCode = split[3];

                    if (dicHy.ContainsKey(hyCode))
                    {
                        string key = string.Format(formatMod, stockCode, blockTypeNameHy, dicHy[hyCode]);
                        retDic.Add(key, 0);
                    }

                    if (dicHyDet.ContainsKey(hyDetCode))
                    {
                        string key = string.Format(formatMod, stockCode, blockTypeNameHyDet, dicHyDet[hyDetCode]);
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
            string tableName = typeof (StockBlock).Name;
            const string idxStkCode = "StkCode",
                         idxBKType = "BKType",
                         idxBKName = "BKName";
            
            if (operState == DataRowState.Deleted)
            {
                int[] aRecId = dicData.Select(kv => kv.Value).ToArray();
                _dbo.DeleteTableByRecId(tableName, aRecId);
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
            Dictionary<string, int> dbDqBlock = this.GetStockBlock(lstDq);

            // 需要删掉的：数据库中有，新文件中没有
            List<KeyValuePair<string, int>> dicNeedDelete = dbDqBlock.Where(dbBlock => !fileDqBlock.ContainsKey(dbBlock.Key)).ToList();

            // 需要新增的：新文件中有，数据库中没有
            List<KeyValuePair<string, int>> dicNeedAdd = fileDqBlock.Where(fBlock => !dbDqBlock.ContainsKey(fBlock.Key)).ToList();

            if (dicNeedDelete.Any())
                cntDel = this.BulkUpdateBlockData(dicNeedDelete, DataRowState.Deleted);

            if (dicNeedAdd.Any())
                cntAdd = this.BulkUpdateBlockData(dicNeedAdd, DataRowState.Added);

            return new TupleValue<int, int>(cntDel, cntAdd);
        }

        /// <summary> 板块导入：行业、行业明细
        /// </summary>
        private TupleValue<int, int> BlockImportHyHyDet()
        {
            int cntDel = 0, cntAdd = 0;
            List<StockBlockType> lstHyHyDet = new List<StockBlockType> { StockBlockType.hy, StockBlockType.hyDet };
            Dictionary<string, int> fileHyHyDetBlock = this.LoadHyHyDetBlockDataFile(lstHyHyDet);
            Dictionary<string, int> dbHyHyDetBlock = this.GetStockBlock(lstHyHyDet);

            // 需要删掉的：数据库中有，新文件中没有
            List<KeyValuePair<string, int>> dicNeedDelete = dbHyHyDetBlock.Where(dbBlock => !fileHyHyDetBlock.ContainsKey(dbBlock.Key)).ToList();

            // 需要新增的：新文件中有，数据库中没有
            List<KeyValuePair<string, int>> dicNeedAdd = fileHyHyDetBlock.Where(fBlock => !dbHyHyDetBlock.ContainsKey(fBlock.Key)).ToList();

            if (dicNeedDelete.Any())
                cntDel = this.BulkUpdateBlockData(dicNeedDelete, DataRowState.Deleted);

            if (dicNeedAdd.Any())
                cntAdd = this.BulkUpdateBlockData(dicNeedAdd, DataRowState.Added);

            return new TupleValue<int, int>(cntDel, cntAdd);
        }

        /// <summary> 板块导入/更新
        /// </summary>
        public TupleValue<int, int> BlockImport()
        {
            int cntDel = 0, cntAdd = 0;

            // 概念、风格、指数
            TupleValue<int, int> cntGnFgZs = BlockImportGnFgZs();
            cntDel += cntGnFgZs.Value1;
            cntAdd += cntGnFgZs.Value2;

            // 地区
            TupleValue<int, int> cntDq = this.BlockImportDq();
            cntDel += cntDq.Value1;
            cntAdd += cntDq.Value2;

            // 行业、行业明细
            TupleValue<int, int> cntHyHyDet = this.BlockImportHyHyDet(); 
            cntDel += cntHyHyDet.Value1;
            cntAdd += cntHyHyDet.Value2;

            return new TupleValue<int, int>(cntDel, cntAdd);
        }

        /// <summary>
        /// 保存例：["sh600001", fileFullName ]
        /// </summary>
        readonly Dictionary<string, string> _allTDXDayLineFile = new Dictionary<string, string>();
        /// <summary> 获取所有通达信日线文件列表（包括 SH、SZ 及指数文件）
        /// </summary>
        public Dictionary<string, string> GetAllTDXDayLineFile()
        {
            // 不太会变动，不需要每次都重新加载
            if (_allTDXDayLineFile.Count > 0)
                return _allTDXDayLineFile;

            string[] aMrkType = new [] {"sh","sz"};
            foreach (string markType in aMrkType)
            {
                string folder = ( CommProp.TDXFolder + BLL.GetDayLineFileFolder(markType) ).Replace(@"\\", @"\");
                DirectoryInfo dir = new DirectoryInfo(folder);
                foreach (FileInfo fileInfo in dir.GetFiles())
                    _allTDXDayLineFile.Add(fileInfo.Name.Substring(0, 8), fileInfo.FullName);
            }
            
            return _allTDXDayLineFile;
        }

        /// <summary> 读取通达信 tnf 文件，获取 代码、名称、缩写 信息
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="zsPrefix">指数类型前缀集合</param>
        /// <param name="markType">sh or sz</param>
        /// <returns></returns>
        private List<StockHead> LoadTDXStockHeadFile(string fileName, string[] zsPrefix, string markType)
        {
            List<StockHead> ret = new List<StockHead>();
            Dictionary<string, string> allDayLineFile = GetAllTDXDayLineFile();

            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                /* 
                 * 头部无用区域 共 50 字节
                 * IP:Encoding.Default.GetString(reader.ReadBytes(40)).TrimEnd('\0')
                 * 可能是某个数量：reader.ReadInt16()
                 * 日期：reader.ReadInt32()
                 * 时间：reader.ReadInt32()
                 */
                reader.ReadBytes(50);

                int count = (int)( ( reader.BaseStream.Length - 50 ) / 314 );
                for (int i = 0; i < count; i++)
                {
                    string stkCode = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0').Trim();
                    reader.ReadBytes(12); // 未知区域
                    string stkName = Encoding.Default.GetString(reader.ReadBytes(18)).Trim('\0').Trim();
                    reader.ReadBytes(246); // 未知区域
                    // 拼音缩写
                    string stkNameAbbr = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0').Trim();
                    reader.ReadBytes(20); // 未知区域

                    string fullCode = markType.ToLower() + stkCode;
                    if (allDayLineFile.ContainsKey(fullCode))
                    {
                        StockHead stkHead = new StockHead();
                        stkHead.MarkType = markType;
                        stkHead.StkCode = stkCode;
                        stkHead.StkName = stkName.Replace(" ",""); // 有些三个字的名字中间会有空格
                        stkHead.StkNameAbbr = stkNameAbbr;
                        stkHead.StkType = zsPrefix.Any(stkCode.StartsWith) ? "0" : "1";

                        ret.Add(stkHead);
                    }
                }
            }

            return ret;
        }

        public void ImportStockHead()
        {
            DataTable dtStockHead = _dbo.GetStockHeadAll();
            TupleValue<string, string> headFileName = StockHeadFileName();

            string fileSH = ( CommProp.TDXFolder + headFileName.Value1 ).Replace(@"\\", @"\");
            string fileSZ = ( CommProp.TDXFolder + headFileName.Value2 ).Replace(@"\\", @"\");

            List<StockHead> lstStockHeadSH = LoadTDXStockHeadFile(fileSH, new[] {"999", "000", "880"}, "sh");
            List<StockHead> lstStockHeadSZ = LoadTDXStockHeadFile(fileSZ, new[] {"399"}, "sz");

            string tableName = typeof (StockHead).Name;

            Action<List<StockHead>, string> updateStockHeadTable =
                (
                    (lstStockHeadFile, markType) =>
                    {
                        dtStockHead.DefaultView.RowFilter = string.Format("MarkType = '{0}'", markType);

                        // 现有已存在的代码
                        List<string> lstAllExistsCode = dtStockHead.DefaultView.ToTable().Rows.Cast<DataRow>().Select(row => row["StkCode"].ToString().Trim()).ToList();
                        // 与 TDX文件 共有，需要检验更新的
                        List<StockHead> lstNeedUpdate = lstStockHeadFile.Where(stkHead => lstAllExistsCode.Contains(stkHead.StkCode)).ToList();
                        // TDX文件 中有，当前没有的，需要增加
                        List<StockHead> lstNeedAdd = lstStockHeadFile.Where(stkHead => !lstAllExistsCode.Contains(stkHead.StkCode)).ToList();
                        // TDX文件 中没有，需要删除
                        List<string> lstNeedDelCode = lstAllExistsCode.Where(stkCode => !lstStockHeadFile.Select(stkHead => stkHead.StkCode).ToList().Contains(stkCode)).ToList();

                        // 处理需要删除或修改的行
                        foreach (DataRow dr in dtStockHead.Rows.Cast<DataRow>().Where(row => row["MarkType"].ToString() == markType))
                        {
                            string stkCode = dr["StkCode"].ToString();
                            if (lstNeedDelCode.Contains(stkCode))
                            {
                                dr.Delete();
                            }
                            else
                            {
                                StockHead updHead = lstNeedUpdate.FirstOrDefault(head => head.StkCode == stkCode);
                                if (updHead != null)
                                {
                                    if (dr["StkName"].ToString() != updHead.StkName)
                                        dr["StkName"] = updHead.StkName;
                                    if (dr["StkNameAbbr"].ToString() != updHead.StkNameAbbr)
                                        dr["StkNameAbbr"] = updHead.StkNameAbbr;
                                    if (dr["StkType"].ToString() != updHead.StkType)
                                        dr["StkType"] = updHead.StkType;
                                }
                            }
                        }

                        // 这样更新大批量有点慢，但是通常没有什么需要删除或修改的
                        if (SysFunction.TableChanged(dtStockHead))
                        {
                            const string strSql = "SELECT * FROM StockHead";
                            SysFunction.SaveChanges(_cnn, strSql, dtStockHead);
                            dtStockHead.AcceptChanges();
                        }

                        // 新增行
                        DataTable insTable = _dbo.GetEmptyTable(tableName);
                        foreach (StockHead stkHead in lstNeedAdd)
                        {
                            DataRow newRow = insTable.NewRow();
                            newRow["MarkType"] = stkHead.MarkType;
                            newRow["StkCode"] = stkHead.StkCode;
                            newRow["StkName"] = stkHead.StkName;
                            newRow["StkNameAbbr"] = stkHead.StkNameAbbr;
                            newRow["StkType"] = stkHead.StkType;
                            insTable.Rows.Add(newRow);
                        }
                        _dbo.BulkWriteTable(insTable, DataRowState.Added);
                    }
                );


            //_dbo.TruncateTable(tableName);
            updateStockHeadTable(lstStockHeadSH, "sh");
            updateStockHeadTable(lstStockHeadSZ, "sz");
        }


    }
}