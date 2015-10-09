using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public  class View : BaseTable 
    {
        private string createCmdText;

        public View(string viewName)
        {
            if (viewName == null || viewName.Trim().Length == 0) throw new ArgumentNullException("ViewName");

            viewName = viewName.Trim();

            this.name = viewName;
        }

        public string CreateCmdText
        {
            get { return createCmdText; }
            set { createCmdText = value; }
        }

        public string DeleteCmdText
        {
            get
            {
                string strRet;
                strRet = string.Format("if exists (select * from dbo.sysobjects where id = object_id(N'[{0}]') and OBJECTPROPERTY(id, N'IsView') = 1)", this.name);
                strRet = strRet + Environment.NewLine + string.Format("drop view [{0}]", this.name);

                return strRet;
            }
        }
    }
}
