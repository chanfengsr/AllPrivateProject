using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace CommDBSpace
{
    public class DataGridViewDateTimeColumn:DataGridViewColumn
    {
        public DataGridViewDateTimeColumn()
            :base(new DataGridViewDateTimeCell())

        {

        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDateTimeCell)))
                {
                    throw new InvalidCastException("²»ÊÇDataGridViewDateTimeCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
