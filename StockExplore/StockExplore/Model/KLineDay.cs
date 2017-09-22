using System;
using System.Collections.Generic;

namespace StockExplore
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class KLineDay
    {
        #region 私有变量及默认值
        private String _MarkType;
        private String _StkCode;
        private DateTime? _TradeDay;
        private Decimal? _Open;
        private Decimal? _High;
        private Decimal? _Low;
        private Decimal? _Close;
        private Decimal? _Volume;
        private Decimal? _Amount;
        private Int32? _RecId;
        #endregion 私有变量及默认值

        #region 表字段名
        public static string ColName_MarkType = "MarkType";
        public static string ColName_StkCode = "StkCode";
        public static string ColName_TradeDay = "TradeDay";
        public static string ColName_Open = "Open";
        public static string ColName_High = "High";
        public static string ColName_Low = "Low";
        public static string ColName_Close = "Close";
        public static string ColName_Volume = "Volume";
        public static string ColName_Amount = "Amount";
        public static string ColName_RecId = "RecId";
        public List<string> AllColNames = new List<string> { "MarkType", "StkCode", "TradeDay", "Open", "High", "Low", "Close", "Volume", "Amount", "RecId" };
        #endregion 表字段名

        #region 索引组
        public List<string> UniIdxPK_KLineDay = new List<string> { "MarkType", "StkCode", "TradeDay" };
        public List<string> IdxIX_KLineDay = new List<string> { "StkCode" };
        public List<string> UniIdxIX_KLineDay_RecId = new List<string> { "RecId" };
        #endregion 索引组

        #region 公共属性

        /// <summary>
        /// </summary>
        public String MarkType
        {
            get { return _MarkType; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("MarkType");

                const int length = 2;
                _MarkType = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
            }
        }

        /// <summary>
        /// </summary>
        public String StkCode
        {
            get { return _StkCode; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("StkCode");

                const int length = 6;
                _StkCode = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
            }
        }

        /// <summary>
        /// </summary>
        public DateTime? TradeDay
        {
            get { return _TradeDay; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("TradeDay");

                _TradeDay = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? Open
        {
            get { return _Open; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Open");

                _Open = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? High
        {
            get { return _High; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("High");

                _High = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? Low
        {
            get { return _Low; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Low");

                _Low = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? Close
        {
            get { return _Close; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Close");

                _Close = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? Volume
        {
            get { return _Volume; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Volume");

                _Volume = value;
            }
        }

        /// <summary>
        /// </summary>
        public Decimal? Amount
        {
            get { return _Amount; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Amount");

                _Amount = value;
            }
        }

        /// <summary>
        /// </summary>
        public Int32? RecId
        {
            get { return _RecId; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("RecId");

                _RecId = value;
            }
        }
        #endregion 公共属性

        #region 公共方法
        /// <summary>检验不可为空项；返回是否检验通过及不能为空却为空的字段名
        /// </summary>
        public Tuple<bool, List<string>> CheckNullable()
        {
            List<string> retList = new List<string>();

            if (_MarkType == null) retList.Add("MarkType");
            if (_StkCode == null) retList.Add("StkCode");
            if (_TradeDay == null) retList.Add("TradeDay");
            if (_Open == null) retList.Add("Open");
            if (_High == null) retList.Add("High");
            if (_Low == null) retList.Add("Low");
            if (_Close == null) retList.Add("Close");
            if (_Volume == null) retList.Add("Volume");
            if (_Amount == null) retList.Add("Amount");
            if (_RecId == null) retList.Add("RecId");

            bool retBool = _MarkType != null && _StkCode != null && _TradeDay != null && _Open != null && _High != null && _Low != null && _Close != null && _Volume != null && _Amount != null && _RecId != null;

            return Tuple.Create(retBool, retList);
        }
        #endregion 公共方法
    }
}
