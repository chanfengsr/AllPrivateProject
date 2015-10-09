using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TableField
    {
        private String _ColumnName;
        private Int32? _ColumnOrdinal;
        private Int32? _ColumnSize;
        private Int16? _NumericPrecision;
        private Int16? _NumericScale;
        private Boolean? _IsUnique;
        private Boolean? _IsKey;
        private String _BaseServerName;
        private String _BaseCatalogName;
        private String _BaseColumnName;
        private String _BaseSchemaName;
        private String _BaseTableName;
        private Type _DataType;
        private Boolean? _AllowDBNull;
        private Int32? _ProviderType;
        private Boolean? _IsAliased;
        private Boolean? _IsExpression;
        private Boolean? _IsIdentity;
        private Boolean? _IsAutoIncrement;
        private Boolean? _IsRowVersion;
        private Boolean? _IsHidden;
        private Boolean? _IsLong;
        private Boolean? _IsReadOnly;
        private Type _ProviderSpecificDataType;
        private String _DataTypeName;
        private String _XmlSchemaCollectionDatabase;
        private String _XmlSchemaCollectionOwningSchema;
        private String _XmlSchemaCollectionName;
        private String _UdtAssemblyQualifiedName;
        private Int32? _NonVersionedProviderType;

        public String ColumnName
        {
            get { return this._ColumnName; }
            set { this._ColumnName = value; }
        }

        public Int32? ColumnOrdinal
        {
            get { return this._ColumnOrdinal; }
            set { this._ColumnOrdinal = value; }
        }

        public Int32? ColumnSize
        {
            get { return this._ColumnSize; }
            set { this._ColumnSize = value; }
        }

        public Int16? NumericPrecision
        {
            get { return this._NumericPrecision; }
            set { this._NumericPrecision = value; }
        }

        public Int16? NumericScale
        {
            get { return this._NumericScale; }
            set { this._NumericScale = value; }
        }

        public Boolean? IsUnique
        {
            get { return this._IsUnique; }
            set { this._IsUnique = value; }
        }

        public Boolean? IsKey
        {
            get { return this._IsKey; }
            set { this._IsKey = value; }
        }

        public String BaseServerName
        {
            get { return this._BaseServerName; }
            set { this._BaseServerName = value; }
        }

        public String BaseCatalogName
        {
            get { return this._BaseCatalogName; }
            set { this._BaseCatalogName = value; }
        }

        public String BaseColumnName
        {
            get { return this._BaseColumnName; }
            set { this._BaseColumnName = value; }
        }

        public String BaseSchemaName
        {
            get { return this._BaseSchemaName; }
            set { this._BaseSchemaName = value; }
        }

        public String BaseTableName
        {
            get { return this._BaseTableName; }
            set { this._BaseTableName = value; }
        }

        public Type DataType
        {
            get { return this._DataType; }
            set { this._DataType = value; }
        }

        public Boolean? AllowDBNull
        {
            get { return this._AllowDBNull; }
            set { this._AllowDBNull = value; }
        }

        public Int32? ProviderType
        {
            get { return this._ProviderType; }
            set { this._ProviderType = value; }
        }

        public Boolean? IsAliased
        {
            get { return this._IsAliased; }
            set { this._IsAliased = value; }
        }

        public Boolean? IsExpression
        {
            get { return this._IsExpression; }
            set { this._IsExpression = value; }
        }

        public Boolean? IsIdentity
        {
            get { return this._IsIdentity; }
            set { this._IsIdentity = value; }
        }

        public Boolean? IsAutoIncrement
        {
            get { return this._IsAutoIncrement; }
            set { this._IsAutoIncrement = value; }
        }

        public Boolean? IsRowVersion
        {
            get { return this._IsRowVersion; }
            set { this._IsRowVersion = value; }
        }

        public Boolean? IsHidden
        {
            get { return this._IsHidden; }
            set { this._IsHidden = value; }
        }

        public Boolean? IsLong
        {
            get { return this._IsLong; }
            set { this._IsLong = value; }
        }

        public Boolean? IsReadOnly
        {
            get { return this._IsReadOnly; }
            set { this._IsReadOnly = value; }
        }

        public Type ProviderSpecificDataType
        {
            get { return this._ProviderSpecificDataType; }
            set { this._ProviderSpecificDataType = value; }
        }

        public String DataTypeName
        {
            get { return this._DataTypeName; }
            set { this._DataTypeName = value; }
        }

        public String XmlSchemaCollectionDatabase
        {
            get { return this._XmlSchemaCollectionDatabase; }
            set { this._XmlSchemaCollectionDatabase = value; }
        }

        public String XmlSchemaCollectionOwningSchema
        {
            get { return this._XmlSchemaCollectionOwningSchema; }
            set { this._XmlSchemaCollectionOwningSchema = value; }
        }

        public String XmlSchemaCollectionName
        {
            get { return this._XmlSchemaCollectionName; }
            set { this._XmlSchemaCollectionName = value; }
        }

        public String UdtAssemblyQualifiedName
        {
            get { return this._UdtAssemblyQualifiedName; }
            set { this._UdtAssemblyQualifiedName = value; }
        }

        public Int32? NonVersionedProviderType
        {
            get { return this._NonVersionedProviderType; }
            set { this._NonVersionedProviderType = value; }
        }
    }
}
