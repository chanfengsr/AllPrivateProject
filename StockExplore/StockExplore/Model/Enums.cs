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
}
