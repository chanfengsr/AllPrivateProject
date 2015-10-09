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
    public class DataGridViewDateTimeCell:DataGridViewTextBoxCell
    {
        public DataGridViewDateTimeCell()
        {
            this.Style.Format = "d";
        }
        public override void InitializeEditingControl(int rowIndex, object
       initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataGridViewDateTimeEditingControl ctl =
                DataGridView.EditingControl as DataGridViewDateTimeEditingControl;
            ctl.Value = (DateTime)this.Value;
        }

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDateTimeEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
