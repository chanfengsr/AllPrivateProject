//StkType = "1"; // 0 指数，1 股票

using System;
using System.Collections.Generic;

namespace StockExplore
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class StockHead
    {
        #region 私有变量及默认值
        private String _MarkType;
        private String _StkCode;
        private String _StkName;
        private String _StkNameAbbr = ""; // 拼音缩写
        private String _StkType = "1";// 0 指数，1 股票
        private Int32? _RecId;
        #endregion 私有变量及默认值

        public List<string> AllColNames = new List<string> { "MarkType", "StkCode", "StkName", "StkNameAbbr", "StkType", "RecId" };

        #region 索引组
        public List<string> UniIdxPK_StockHead = new List<string> { "MarkType", "StkCode" };
        public List<string> UniIdxIX_StockHead = new List<string> { "MarkType", "StkCode", "StkType" };
        public List<string> UniIdxIX_StockHead_RecId = new List<string> { "RecId" };
        public List<string> IdxIX_StockHead_StkNameAbbr = new List<string> { "StkNameAbbr" };
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
        public String StkName
        {
            get { return _StkName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("StkName");

                const int length = 20;
                _StkName = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
            }
        }

        /// <summary>
        /// </summary>
        public String StkNameAbbr
        {
            get { return _StkNameAbbr; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("StkNameAbbr");

                const int length = 10;
                _StkNameAbbr = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
            }
        }

        /// <summary>
        /// </summary>
        public String StkType
        {
            get { return _StkType; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("StkType");

                const int length = 1;
                _StkType = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();
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
            if (_StkName == null) retList.Add("StkName");
            if (_StkNameAbbr == null) retList.Add("StkNameAbbr");
            if (_StkType == null) retList.Add("StkType");
            if (_RecId == null) retList.Add("RecId");

            bool retBool = _MarkType != null && _StkCode != null && _StkName != null && _StkNameAbbr != null && _StkType != null && _RecId != null;

            return Tuple.Create(retBool, retList);
        }
        #endregion 公共方法
    }
}