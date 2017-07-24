using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal enum KLineType
    {
        Day,
        Week,
        Month,
        Minute
    }

    internal enum ValueType
    {
        Open,
        High,
        Low,
        Close,
        Volume,
        Amount
    }

    /// <summary>
    /// 板块分类
    /// </summary>
    internal enum StockBlockType
    {
        /// <summary> 概念
        /// </summary>
        gn,
        /// <summary> 风格
        /// </summary>
        fg,
        /// <summary> 指数
        /// </summary>
        zs,
        /// <summary> 行业
        /// </summary>
        hy,
        /// <summary> 行业细分
        /// </summary>
        hyDet,
        /// <summary> 地区
        /// </summary>
        dq
    }
}
