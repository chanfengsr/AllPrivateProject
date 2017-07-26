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

        /// <summary> 返回板块类型名称
        /// </summary>
        /// <param name="stockBlockType"></param>
        /// <returns></returns>
        public static string StockBlockTypeName(StockBlockType stockBlockType)
        {
            switch (stockBlockType)
            {
                case StockBlockType.gn:
                    return "概念";
                case StockBlockType.fg:
                    return "风格";
                case StockBlockType.zs:
                    return "指数";
                case StockBlockType.hy:
                    return "行业";
                case StockBlockType.hyDet:
                    return "行业细分";
                case StockBlockType.dq:
                    return "地区";
                default:
                    throw new ArgumentOutOfRangeException("stockBlockType");
            }
        }

        /// <summary> 板块枚举列表转换成板块名称列表
        /// </summary>
        public static List<string> ConvertBlockTypeList2Name(List<StockBlockType> lstStockBlockType)
        {
            return lstStockBlockType.Select(StockBlockTypeName).ToList();
        }

         public static string StockBlockFileName(StockBlockType stockBlockType)
         {
             switch (stockBlockType)
             {
                 case StockBlockType.gn:
                     return @"\T0002\hq_cache\block_gn.dat";
                 case StockBlockType.fg:
                     return @"\T0002\hq_cache\block_fg.dat";
                 case StockBlockType.zs:
                     return @"\T0002\hq_cache\block_zs.dat";
                 case StockBlockType.hy:
                     return string.Format("{0},{1}", @"\incon.dat", @"\T0002\hq_cache\tdxhy.cfg");
                 default:
                     return "";
             }
         }
    }
}