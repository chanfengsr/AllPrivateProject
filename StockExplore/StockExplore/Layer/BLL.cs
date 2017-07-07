using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal class BLL
    {
        public static string GetDBTableName(KLineType kLineType, bool isComposite)
        {
            const string kLineDay = "KLineDay",
                         kLineDayZS = "KLineDayZS",
                         kLineWeek = "KLineWeek",
                         kLineMonth = "KLineMonth",
                         kLineMinute = "KLineMinute";

            switch (kLineType)
            {
                case KLineType.Day:
                    return isComposite ? kLineDayZS : kLineDay;
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