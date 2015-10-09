using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class StoreProcedure
    {        
        public enum ExecuteReturnType { NonQuery, DataReader, Scalar, Dataset, DataTable }

        private List<SPField> parameters = new List<SPField>();
        private string name;
        private string createCmdText;
        private bool needReturnVal = true;
        private ExecuteReturnType procExecRetType = ExecuteReturnType.NonQuery;

        private void AddProcedureName(string storeProcedureName)
        {
            if (storeProcedureName == null || storeProcedureName.Trim().Length == 0) throw new ArgumentNullException("StoreProcedureName");

            storeProcedureName = storeProcedureName.Trim();

            this.Name = storeProcedureName;
        }

        public StoreProcedure(string storeProcedureName)
        {
            AddProcedureName(storeProcedureName);
        }

        public StoreProcedure(string storeProcedureName, bool needReturnValue)
        {
            AddProcedureName(storeProcedureName);
            needReturnVal = needReturnValue;
        }

        public StoreProcedure(string storeProcedureName, bool needReturnValue, ExecuteReturnType procExecuteReturnType)
        {
            AddProcedureName(storeProcedureName);
            needReturnVal = needReturnValue;
            procExecRetType = procExecuteReturnType;
        }

        public bool NeedReturnValue
        {
            get { return needReturnVal; }
            set { needReturnVal = value; }
        }

        public ExecuteReturnType ProcExecuteReturnType
        {
            get { return procExecRetType; }
            set { procExecRetType = value; }
        }

        public string CreateCmdText
        {
            get { return createCmdText; }
            set { createCmdText = value; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string DeleteCmdText
        {
            get
            {
                string strRet;
                strRet = string.Format("if exists (select * from dbo.sysobjects where id = object_id(N'[{0}]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)", this.name);
                strRet = strRet + Environment.NewLine + string.Format("drop procedure [{0}]", this.name);

                return strRet;
            }
        }

        public List<SPField> Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }

        public List<SPField> InParameters
        {
            get
            {
                List<SPField> LParameters = new List<SPField>();

                foreach (SPField parm in this.parameters)
                {
                    if (parm.PARAMETER_MODE.ToUpper() == "IN")
                    {
                        LParameters.Add(parm);
                    }
                }
                return LParameters;
            }
        }

        public List<SPField> OutParameters
        {
            get
            {
                List<SPField> LParameters = new List<SPField>();

                foreach (SPField parm in this.parameters)
                {
                    if (parm.PARAMETER_MODE.ToUpper() == "OUT")
                    {
                        LParameters.Add(parm);
                    }
                }
                return LParameters;
            }
        }

        public List<SPField> InOutParameters
        {
            get
            {
                List<SPField> LParameters = new List<SPField>();

                foreach (SPField parm in this.parameters)
                {
                    if (parm.PARAMETER_MODE.ToUpper() == "INOUT")
                    {
                        LParameters.Add(parm);
                    }
                }
                return LParameters;
            }
        }

        public bool AddParameter(SPField Parameter)
        {
            foreach (SPField parm in this.parameters)
            {
                if (parm.PARAMETER_NAME.ToUpper().Trim() == Parameter.PARAMETER_NAME.ToUpper().Trim())
                {
                    return false;
                }
            }

            this.parameters.Add(Parameter);
            return true;
        }

        public bool RemoveParameter(SPField Parameter)
        {
            return this.parameters.Remove(Parameter);
        }

        public bool RemoveParameter(string ParameterName)
        {
            foreach (SPField parm in this.parameters)
            {
                if (parm.PARAMETER_NAME.ToUpper().Trim() == ParameterName.ToUpper().Trim())
                {
                    this.parameters.Remove(parm);
                    return true;
                }
            }

            return false;
        }

        public SPField GetParameter(string ParameterName)
        {
            foreach (SPField var in this.parameters )
            {
                string pureParmName=(var.PARAMETER_NAME.Trim().ToLower()).Replace("@","");

                if (var.PARAMETER_NAME.Trim().ToLower() == ParameterName.Trim().ToLower() || pureParmName == ParameterName.Trim().ToLower())
                    return var;
            }

            return null;
        }
    }
}
