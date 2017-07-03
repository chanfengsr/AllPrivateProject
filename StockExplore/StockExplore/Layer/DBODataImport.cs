using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace StockExplore
{
    internal class DBODataImport:DBO
    {
        public DBODataImport(SqlConnection cnn): base(cnn)
        {

        }

        public DataTable GetEmptyTable(string tableName)
        {
            const string strSql = "SELECT TOP 0 * FROM {0}";
            DataTable retVal = SQLHelper.ExecuteDataTable(string.Format(strSql, tableName), CommandType.Text, Connection);
            retVal.TableName = tableName;

            return retVal;
        }

        public void TruncateTable(string tableName)
        {
            const string strSql = "TRUNCATE TABLE {0}";
            SQLHelper.ExecuteNonQuery(string.Format(strSql, tableName), CommandType.Text, Connection);
        }

        public void DeleteTable(string tableName, StockHead stkHead)
        {
            const string strSql = "DELETE FROM {0} WHERE StkCode = '{1}'";

            SQLHelper.ExecuteNonQuery(string.Format(strSql, tableName,  stkHead.StkCode), CommandType.Text, Connection);
        }

        /// <summary>找到指定股票代码已有数据的最大交易日
        /// </summary>
        public DateTime FindMaxExistTradeDay(string tableName, StockHead stkHead)
        {
            DateTime retVal = DateTime.MinValue;

/*
            string strSql = string.Format("SELECT TradeDay = MAX(TradeDay) FROM {0}" + Environment.NewLine
                                          + "WHERE MarkType = @MarkType AND StkCode = @StkCode", tableName);
            SqlParameter[] parms = new[]
            {
                new SqlParameter("@MarkType", stkHead.MarkType),
                new SqlParameter("@StkCode", stkHead.StkCode)
            };
            
            object objMaxDay = SQLHelper.ExecuteScalar(strSql, CommandType.Text, parms, _cnn);
*/
            /**/
            const string strSql = "SELECT TradeDay = MAX(TradeDay) FROM {0}" + "\r\n"
                                  + "WHERE StkCode = '{1}'";

            object objMaxDay = SQLHelper.ExecuteScalar(string.Format(strSql, tableName,  stkHead.StkCode), CommandType.Text, Connection);


            if (objMaxDay != System.DBNull.Value)
                retVal = (DateTime)objMaxDay;

            return retVal;
        }

        /// <summary>批量插入数据
        /// </summary>
        public void BulkInsertTable(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(Connection);
                bulkCopy.DestinationTableName = dataTable.TableName;
                foreach (DataColumn col in dataTable.Columns)
                    if (!col.AutoIncrement)
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                bulkCopy.WriteToServer(dataTable, DataRowState.Added);
                bulkCopy.Close();
            }
        }

        /// <summary> 数据库中查找 StockHead
        /// </summary>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public StockHead FindStockHead( string stkCode)
        {
            const string strSql = "SELECT * FROM StockHead WHERE StkCode = '{0}'";
            DataTable dt = SQLHelper.ExecuteDataTable(string.Format(strSql,  stkCode), CommandType.Text, Connection);

            if (dt.Rows.Count > 0)
                return ModelHelp.GenerateList<StockHead>(dt)[0];
            else
                return new StockHead();
        }

        /// <summary>新增或修改 StockHead(StkName)
        /// </summary>
        public void InsertOrUpdateStockHead(StockHead stockHead)
        {
            StockHead existStkHead = this.FindStockHead(stockHead.StkCode);

            if (!string.IsNullOrEmpty(existStkHead.StkCode))
            {
                if (existStkHead.StkName.Trim() != stockHead.StkName.Trim())
                {
                    const string strSql = "UPDATE StockHead SET StkName = '{0}' WHERE StkCode = '{1}'";
                    SQLHelper.ExecuteNonQuery(string.Format(strSql, stockHead.StkName, stockHead.StkCode), CommandType.Text, Connection);
                }
            }
            else
            {
                const string strSql = "INSERT INTO StockHead(MarkType, StkCode, StkName, StkType) " + "\r\n"
                                      + "VALUES('{0}','{1}','{2}','{3}') ";

                SQLHelper.ExecuteNonQuery(string.Format(strSql, stockHead.MarkType, stockHead.StkCode, stockHead.StkName, stockHead.StkType), CommandType.Text, Connection);
            }
        }
    }
}