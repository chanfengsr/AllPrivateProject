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
    }
}