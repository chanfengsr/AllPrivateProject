using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class BLLMetrics : BLL
    {
        private readonly SqlConnection _cnn;
        private readonly DBOMetrics _dbo;

        public BLLMetrics(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
            _dbo = new DBOMetrics(_cnn);

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

        /// <summary>获取个股的所有收盘价
        /// </summary>
        /// <param name="stkCode">股票代码</param>
        /// <param name="isComposite">是否指数</param>
        /// <param name="startDay">开始日期</param>
        /// <param name="endDay">结束日期</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> GetDayCloseValue(string stkCode, bool isComposite, DateTime startDay = default( DateTime ), DateTime endDay = default( DateTime ))
        {
            DataTable closePrice = _dbo.GetStockAllPrice(BLL.GetKLineDBTableName(KLineType.Day,isComposite),  stkCode, new List<ValueType> {ValueType.Close}, startDay, endDay);
            Dictionary<DateTime, decimal> ret = SysFunction.GetColDictionary<DateTime, decimal>(closePrice, 0, 1);
            
            return ret;
        }

        /// <summary> 一次计算指定日期的所有简单移动平均线值
        /// </summary>
        /// <param name="numberList">原金额（一般为收盘价）</param>
        /// <param name="avgNumber">平均日数</param>
        /// <param name="startDay">开始日期</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> CalcAllMA(Dictionary<DateTime, decimal> numberList, int avgNumber, DateTime startDay = default( DateTime ))
        {
            Dictionary<DateTime, decimal> ret = new Dictionary<DateTime, decimal>();
            Dictionary<int, decimal> calcResult = new Dictionary<int, decimal>();
            Dictionary<int, decimal> origPrice = new Dictionary<int, decimal>();
            Dictionary<int, DateTime> remarkDate = new Dictionary<int, DateTime>();
            int count = 0;
            bool havPrev = false;
            bool havStartDay = startDay != default( DateTime );

            if (avgNumber > numberList.Count)
                return ret;

            foreach (KeyValuePair<DateTime, decimal> dayPrice in numberList)
            {
                count++;
                remarkDate.Add(count, dayPrice.Key);
                origPrice.Add(count, dayPrice.Value);
            }

            decimal price;
            while (count >= avgNumber)
            {
                price = 0;

                if (!havStartDay || startDay <= remarkDate[count])
                {
                    if (havPrev)
                    {
                        price = calcResult[count + 1] - origPrice[count + 1] + origPrice[count - avgNumber + 1];
                        calcResult.Add(count, price);
                    }
                    else
                    {
                        for (int i = 0; i < avgNumber; i++)
                            price += origPrice[count - i];

                        calcResult.Add(count, price);
                        havPrev = true;
                    }
                }
                else
                {
                    break;
                }

                count--;
            }

            foreach (KeyValuePair<int, DateTime> keyDay in remarkDate)
            {
                if (calcResult.ContainsKey(keyDay.Key))
                    ret.Add(keyDay.Value, calcResult[keyDay.Key] / avgNumber);
            }

            return ret;
        }

        /// <summary> 计算个股所有日涨幅
        /// </summary>
        /// <param name="dayTableName"></param>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> CalcStockRatio_OneStock(string dayTableName, string stkCode)
        {
            return _dbo.CalcStockRatio_OneStock(dayTableName, stkCode);
        }

        /// <summary>计算单日所有个股涨幅
        /// </summary>
        /// <param name="dayTableName"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public Dictionary<string, decimal> CalcStockRatio_OneDay(string dayTableName, DateTime day)
        {
            return _dbo.CalcStockRatio_OneDay(dayTableName, day);
        }
    }
}
