using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StockExplore
{
    class BLLDataImport
    {
        DBO _dbo;

        public BLLDataImport(string sqlCnnString)
        {
            _dbo = new DBO(sqlCnnString);
        }

        public List<TupleValue<FileInfo, StockHead>> LoadMrkTypeAndCode(List<FileInfo> allFile)
        {
            List<TupleValue<FileInfo, StockHead>> ret = new List<TupleValue<FileInfo, StockHead>>();

            foreach (FileInfo file in allFile)
            {
                string[] nameSplit = file.Name.Replace(file.Extension, "").Split('#');

                StockHead stkHead = new StockHead()
                {
                    MarkType = nameSplit[0],
                    StkCode = nameSplit[1]
                };

                ret.Add(new TupleValue<FileInfo, StockHead>(file, stkHead));
            }

            return ret;
        }

        public void InsertStkKLine(TupleValue<FileInfo, StockHead> stkInfo, bool overwrite, bool isComposite)
        {
            FileInfo fileInfo = stkInfo.Value1;
            StockHead stkHead = stkInfo.Value2;
            stkHead.StkType = isComposite ? "0" : "1";

            if (overwrite)
                this.InsertStkKLine_Overwrite(fileInfo, stkHead);
            else
                this.InsertStkKLine_AddNew(fileInfo, stkHead);
        }

        private void InsertStkKLine_Overwrite(FileInfo fileInfo, StockHead stkHead)
        { 
            // todo
        }

        private void InsertStkKLine_AddNew(FileInfo fileInfo, StockHead stkHead)
        {
            // todo
        }
    }
}