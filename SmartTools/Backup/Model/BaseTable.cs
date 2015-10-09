using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BaseTable
    {
        protected List<TableField> fields = new List<TableField>();
        protected string name;

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

        public List<TableField> Fields
        {
            get
            {
                return this.fields;
            }
            set
            {
                this.fields = value;
            }
        }

        public List<TableField> IdentityFields
        {
            get
            {
                List<TableField> LFields = new List<TableField>();
                foreach (TableField field in this.fields)
                {
                    if (field.IsIdentity == true)
                    {
                        LFields.Add(field);
                    }
                }

                return LFields;
            }
        }

        public List<TableField> KeyFields
        {
            get
            {
                List<TableField> LFields = new List<TableField>();
                foreach (TableField field in this.fields)
                {
                    if (field.IsKey == true)
                    {
                        LFields.Add(field);
                    }
                }

                return LFields;
            }
        }

        public List<TableField> NotKeyFields
        {
            get
            {
                List<TableField> LFields = new List<TableField>();
                foreach (TableField field in this.fields)
                {
                    if (!field.IsKey == true)
                    {
                        LFields.Add(field);
                    }
                }

                return LFields;
            }
        }

        public List<TableField> CanBeParmFields
        {
            get
            {
                List<TableField> LFields = new List<TableField>();
                foreach (TableField field in this.fields)
                {
                    if ((field.IsRowVersion == false && field.IsReadOnly == false) || field.IsKey == true)
                    {
                        LFields.Add(field);
                    }
                }

                return LFields;
            }
        }

        public List<TableField> ShouldAddLengthFields
        {
            get
            {
                List<TableField> LFields = new List<TableField>();
                foreach (TableField field in this.fields)
                {
                    if (field.NumericPrecision == 255 &&
                        field.IsRowVersion == false &&
                        field.IsLong == false &&
                        field.IsReadOnly == false)
                    {
                        LFields.Add(field);
                    }
                }

                return LFields;
            }
        }

        public bool AddField(TableField Field)
        {
            foreach (TableField field in this.fields)
            {
                if (field.ColumnName.ToUpper().Trim() == Field.ColumnName.ToUpper().Trim())
                {
                    return false;
                }
            }

            this.fields.Add(Field);
            return true;
        }

        public bool RemoveField(TableField Field)
        {
            return this.fields.Remove(Field);
        }

        public bool RemoveField(string FieldName)
        {
            foreach (TableField field in this.fields)
            {
                if (field.ColumnName.ToUpper().Trim() == FieldName.ToUpper().Trim())
                {
                    this.fields.Remove(field);
                    return true;
                }
            }

            return false;
        }

        public TableField GetField(string FieldName)
        {
            foreach (TableField var in this.fields)
            {
                if (var.ColumnName.Trim().ToLower() == FieldName.Trim().ToLower())
                    return var;
            }

            return null;
        }
    }
}