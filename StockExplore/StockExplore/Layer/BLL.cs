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
            switch (kLineType)
            {
                case KLineType.Day:
                    return "KLineDay";
                case KLineType.Week:
                    return "KLineWeek";
                case KLineType.Month:
                    return "KLineMonth";
                case KLineType.Minute:
                    return "KLineMinute";
                default:
                    throw new ArgumentOutOfRangeException("kLineType");
            }
        }
    }
}
