using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    class BLLMetrics:BLL
    {
        private readonly SqlConnection _cnn;
        private DBOMetrics _dbo;

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

        /// <summary> 一次计算指定日期的所有简单移动平均线值
        /// </summary>
        /// <param name="origNumber">原金额（一般为收盘价）</param>
        /// <param name="avgNumber">平均日数</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> CalcAllMA(Dictionary<DateTime, decimal> origNumber, int avgNumber)
        {
            Dictionary<DateTime, decimal> ret = new Dictionary<DateTime, decimal>();
            Dictionary<int, decimal> calcResult = new Dictionary<int, decimal>();
            Dictionary<int, decimal> origPrice = new Dictionary<int, decimal>();
            Dictionary<int, DateTime> remarkDate = new Dictionary<int, DateTime>();
            int count = 0;
            bool havPrev = false;

            if (avgNumber > origNumber.Count)
                return ret;

            foreach (KeyValuePair<DateTime, decimal> dayPrice in origNumber)
            {
                count++;
                remarkDate.Add(count, dayPrice.Key);
                origPrice.Add(count, dayPrice.Value);
            }

            decimal price;
            while (count >= avgNumber)
            {
                price = 0;

                if (havPrev)
                {
                    price = calcResult[count + 1] - origPrice[count + 1]+ origPrice[count-avgNumber+1];
                    calcResult.Add(count, price);
                }
                else
                {
                    for (int i = 0; i < avgNumber; i++)
                        price += origPrice[count - i];

                    calcResult.Add(count, price);
                    havPrev = true;
                }

                count--;
            }

            foreach (KeyValuePair<int, DateTime> keyDay in remarkDate)
            {
                ret.Add(keyDay.Value, calcResult[keyDay.Key]);
            }

            return ret;
        }
    }
}
