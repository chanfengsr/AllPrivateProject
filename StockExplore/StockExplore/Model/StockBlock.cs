using System;
using System.Collections.Generic;

namespace StockExplore
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class StockBlock
    {
        #region 私有变量及默认值
        private String _StkCode;
        private String _BKType;
        private String _BKName;
        private Int32? _RecId;
        #endregion 私有变量及默认值

        #region 字段名
        public static string ColName_MarkType = "MarkType";
        public static string ColName_StkCode = "StkCode";
        public static string ColName_StkName = "StkName";
        public static string ColName_StkNameAbbr = "StkNameAbbr";
        public static string ColName_StkType = "StkType";
        public static string ColName_RecId = "RecId";
        public List<string> AllColNames = new List<string> { "StkCode", "BKType", "BKName", "RecId" };
        #endregion 字段名

        #region 索引组
        public List<string> UniIdxPK_StockBlock = new List<string> { "StkCode", "BKType", "BKName" };
        public List<string> IdxIX_StockBlock_StkCode = new List<string> { "StkCode" };
        public List<string> IdxIX_StockBlock_BKType = new List<string> { "BKType" };
        public List<string> IdxIX_StockBlock_BKName = new List<string> { "BKName" };
        public List<string> UniIdxIX_StockBlock_RecId = new List<string> { "RecId" };
        #endregion 索引组

        #region 公共属性

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
        public String BKType
        {
            get { return _BKType; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("BKType");

                const int length = 20;
                _BKType = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
            }
        }

        /// <summary>
        /// </summary>
        public String BKName
        {
            get { return _BKName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("BKName");

                const int length = 20;
                _BKName = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
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

            if (_StkCode == null) retList.Add("StkCode");
            if (_BKType == null) retList.Add("BKType");
            if (_BKName == null) retList.Add("BKName");
            if (_RecId == null) retList.Add("RecId");

            bool retBool = _StkCode != null && _BKType != null && _BKName != null && _RecId != null;

            return Tuple.Create(retBool, retList);
        }
        #endregion 公共方法
    }
}
