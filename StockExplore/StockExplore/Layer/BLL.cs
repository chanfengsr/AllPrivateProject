using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal class BLL
    {
        public static string GetDBTableName(KLineType kLineType)
        {
            const string kLineDay = "KLineDay",
                         kLineWeek = "KLineWeek",
                         kLineMonth = "KLineMonth",
                         kLineMinute = "KLineMinute";

            switch (kLineType)
            {
                case KLineType.Day:
                    return kLineDay;
                case KLineType.Week:
                    return kLineWeek;
                case KLineType.Month:
                    return kLineMonth;
                case KLineType.Minute:
                    return kLineMinute;
                default:
                    throw new ArgumentOutOfRangeException("kLineType");
            }
        }
    }
}
