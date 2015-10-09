using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SPField
    {
        private String _SPECIFIC_CATALOG;
        private String _SPECIFIC_SCHEMA;
        private String _SPECIFIC_NAME;
        private Int16? _ORDINAL_POSITION;
        private String _PARAMETER_MODE;
        private String _IS_RESULT;
        private String _AS_LOCATOR;
        private String _PARAMETER_NAME;
        private String _DATA_TYPE;
        private Int32? _CHARACTER_MAXIMUM_LENGTH;
        private Int32? _CHARACTER_OCTET_LENGTH;
        private String _COLLATION_CATALOG;
        private String _COLLATION_SCHEMA;
        private String _COLLATION_NAME;
        private String _CHARACTER_SET_CATALOG;
        private String _CHARACTER_SET_SCHEMA;
        private String _CHARACTER_SET_NAME;
        private Byte? _NUMERIC_PRECISION;
        private Int16? _NUMERIC_PRECISION_RADIX;
        private Int32? _NUMERIC_SCALE;
        private Int16? _DATETIME_PRECISION;
        private String _INTERVAL_TYPE;
        private Int16? _INTERVAL_PRECISION;

        public String SPECIFIC_CATALOG
        {
            get { return this._SPECIFIC_CATALOG; }
            set { this._SPECIFIC_CATALOG = value; }
        }

        public String SPECIFIC_SCHEMA
        {
            get { return this._SPECIFIC_SCHEMA; }
            set { this._SPECIFIC_SCHEMA = value; }
        }

        public String SPECIFIC_NAME
        {
            get { return this._SPECIFIC_NAME; }
            set { this._SPECIFIC_NAME = value; }
        }

        public Int16? ORDINAL_POSITION
        {
            get { return this._ORDINAL_POSITION; }
            set { this._ORDINAL_POSITION = value; }
        }

        public String PARAMETER_MODE
        {
            get { return this._PARAMETER_MODE; }
            set { this._PARAMETER_MODE = value; }
        }

        public String IS_RESULT
        {
            get { return this._IS_RESULT; }
            set { this._IS_RESULT = value; }
        }

        public String AS_LOCATOR
        {
            get { return this._AS_LOCATOR; }
            set { this._AS_LOCATOR = value; }
        }

        public String PARAMETER_NAME
        {
            get { return this._PARAMETER_NAME; }
            set { this._PARAMETER_NAME = value; }
        }

        public String DATA_TYPE
        {
            get { return this._DATA_TYPE; }
            set { this._DATA_TYPE = value; }
        }

        public Int32? CHARACTER_MAXIMUM_LENGTH
        {
            get { return this._CHARACTER_MAXIMUM_LENGTH; }
            set { this._CHARACTER_MAXIMUM_LENGTH = value; }
        }

        public Int32? CHARACTER_OCTET_LENGTH
        {
            get { return this._CHARACTER_OCTET_LENGTH; }
            set { this._CHARACTER_OCTET_LENGTH = value; }
        }

        public String COLLATION_CATALOG
        {
            get { return this._COLLATION_CATALOG; }
            set { this._COLLATION_CATALOG = value; }
        }

        public String COLLATION_SCHEMA
        {
            get { return this._COLLATION_SCHEMA; }
            set { this._COLLATION_SCHEMA = value; }
        }

        public String COLLATION_NAME
        {
            get { return this._COLLATION_NAME; }
            set { this._COLLATION_NAME = value; }
        }

        public String CHARACTER_SET_CATALOG
        {
            get { return this._CHARACTER_SET_CATALOG; }
            set { this._CHARACTER_SET_CATALOG = value; }
        }

        public String CHARACTER_SET_SCHEMA
        {
            get { return this._CHARACTER_SET_SCHEMA; }
            set { this._CHARACTER_SET_SCHEMA = value; }
        }

        public String CHARACTER_SET_NAME
        {
            get { return this._CHARACTER_SET_NAME; }
            set { this._CHARACTER_SET_NAME = value; }
        }

        public Byte? NUMERIC_PRECISION
        {
            get { return this._NUMERIC_PRECISION; }
            set { this._NUMERIC_PRECISION = value; }
        }

        public Int16? NUMERIC_PRECISION_RADIX
        {
            get { return this._NUMERIC_PRECISION_RADIX; }
            set { this._NUMERIC_PRECISION_RADIX = value; }
        }

        public Int32? NUMERIC_SCALE
        {
            get { return this._NUMERIC_SCALE; }
            set { this._NUMERIC_SCALE = value; }
        }

        public Int16? DATETIME_PRECISION
        {
            get { return this._DATETIME_PRECISION; }
            set { this._DATETIME_PRECISION = value; }
        }

        public String INTERVAL_TYPE
        {
            get { return this._INTERVAL_TYPE; }
            set { this._INTERVAL_TYPE = value; }
        }

        public Int16? INTERVAL_PRECISION
        {
            get { return this._INTERVAL_PRECISION; }
            set { this._INTERVAL_PRECISION = value; }
        }
    }
}
