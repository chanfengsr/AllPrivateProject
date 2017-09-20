using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace StockExplore
{
    internal class DBODataImport : DBO
    {
        public DBODataImport(SqlConnection cnn) : base(cnn) {}

        public DataTable GetEmptyTable(string tableName)
        {
            const string strSql = "SELECT TOP 0 * FROM {0}";
            DataTable retVal = SQLHelper.ExecuteDataTable(string.Format(strSql, tableName), CommandType.Text, _cnn);
            retVal.TableName = tableName;

            return retVal;
        }
        
        public void DeleteTable(string tableName, StockHead stkHead)
        {
            const string strSql = "DELETE FROM {0} WHERE MarkType = '{1}' AND StkCode = '{2}'";

            SQLHelper.ExecuteNonQuery(string.Format(strSql, tableName, stkHead.MarkType, stkHead.StkCode), CommandType.Text, _cnn);
        }

        /// <summary>找到指定股票代码已有数据的最大交易日
        /// </summary>
        public DateTime FindMaxExistTradeDay(string tableName, StockHead stkHead)
        {
            DateTime retVal = DateTime.MinValue;

            const string strSql = "SELECT TradeDay = MAX(TradeDay) FROM {0}" + "\r\n"
                                  + "WHERE MarkType = '{1}' AND StkCode = '{2}'";

            object objMaxDay = SQLHelper.ExecuteScalar(string.Format(strSql, tableName, stkHead.MarkType, stkHead.StkCode), CommandType.Text, _cnn);


            if (objMaxDay != System.DBNull.Value)
                retVal = (DateTime)objMaxDay;

            return retVal;
        }

        /// <summary>批量插入数据
        /// </summary>
        public void BulkWriteTable(DataTable dataTable, DataRowState dataRowState)
        {
            if (dataTable.Rows.Count > 0)
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(_cnn);
                bulkCopy.DestinationTableName = dataTable.TableName;
                foreach (DataColumn col in dataTable.Columns)
                    if (!col.AutoIncrement)
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                bulkCopy.WriteToServer(dataTable, dataRowState);
                bulkCopy.Close();
            }
        }

        /// <summary> 数据库中查找 StockHead
        /// </summary>
        /// <param name="markType"></param>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public StockHead FindStockHead(string markType, string stkCode)
        {
            const string strSql = "SELECT * FROM StockHead WHERE MarkType = '{0}' AND StkCode = '{1}'";
            DataTable dt = SQLHelper.ExecuteDataTable(string.Format(strSql, markType, stkCode), CommandType.Text, _cnn);

            if (dt.Rows.Count > 0)
                return ModelHelp.GenerateList<StockHead>(dt)[0];
            else
                return new StockHead();
        }

        /// <summary> 返回 StockHead 全表
        /// </summary>
        public DataTable GetStockHeadAll()
        {
            const string strSql = "SELECT * FROM StockHead";
            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn, relatePhysicalTable: true, tableName: "StockHead");
        }

        /// <summary> 返回 StockHead 类型为指数的
        /// </summary>
        public DataTable GetStockHeadComposite()
        {
            const string strSql = "SELECT * FROM StockHead WHERE StkType = 0";
            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
        }

        /// <summary>新增或修改 StockHead(StkName)
        /// </summary>
        public void InsertOrUpdateStockHead(StockHead stockHead)
        {
            StockHead existStkHead = this.FindStockHead(stockHead.MarkType, stockHead.StkCode);

            if (string.IsNullOrEmpty(existStkHead.StkCode))
            {
                const string strSql = "INSERT INTO StockHead(MarkType, StkCode, StkName, StkNameAbbr, StkType) " + "\r\n"
                                      + "VALUES('{0}','{1}','{2}','{3}','{4}') ";

                SQLHelper.ExecuteNonQuery(string.Format(strSql, stockHead.MarkType, stockHead.StkCode, stockHead.StkName, stockHead.StkNameAbbr, stockHead.StkType), CommandType.Text, _cnn);
            }
            else
            {
                if (existStkHead.StkName.Trim() != stockHead.StkName.Trim())
                {
                    const string strSql = "UPDATE StockHead SET StkName = '{0}', stockHead = '{1}' WHERE MarkType = '{2}' AND StkCode = '{3}'";
                    SQLHelper.ExecuteNonQuery(string.Format(strSql, stockHead.StkName, stockHead.StkNameAbbr, stockHead.MarkType, stockHead.StkCode), CommandType.Text, _cnn);
                }
            }
        }

        /// <summary>获取指定类型的板块
        /// </summary>
        /// <param name="lstStockBlockType"></param>
        /// <returns></returns>
        public DataTable GetStockBlock(List<StockBlockType> lstStockBlockType)
        {
            const string sqlMod = "SELECT * FROM StockBlock WHERE BKType IN ({0})";
            List<string> lstName = BLL.ConvertBlockTypeList2Name(lstStockBlockType);
            string sParm = SysFunction.SParm(lstName.ToArray(), true);

            return SQLHelper.ExecuteDataTable(string.Format(sqlMod, sParm), CommandType.Text, _cnn);
        }

        /// <summary>
        /// </summary>
        /// <param name="markType">sh sz null 代表所有</param>
        /// <param name="isComposite">是否指数，null 代表所有</param>
        /// <returns></returns>
        public List<string> GetStockFullName(string markType = null, bool? isComposite = null)
        {
            List<string> ret = new List<string>();

            string strSql = "SELECT FullCode = MarkType + StkCode FROM StockHead WHERE 1 = 1";

            if (markType != null)
                strSql += string.Format(" AND MarkType = '{0}' ", markType);
            if (isComposite != null)
                strSql += string.Format(" AND StkType = '{0}' ", isComposite == true ? 0 : 1);

            DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
            ret = dt.Rows.Cast<DataRow>().Select(dr => dr["FullCode"].ToString().ToLower()).ToList();

            return ret;
        }
    }
}