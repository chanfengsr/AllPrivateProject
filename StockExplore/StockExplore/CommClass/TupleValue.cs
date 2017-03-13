using System;

namespace StockExplore
{
    public struct TupleValue<TValue1> : IEquatable<TupleValue<TValue1>>
    {
        private TValue1 _value1;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }

        public TupleValue(TValue1 value1)
        {
            _value1 = value1;
        }

        public bool Equals(TupleValue<TValue1> other)
        {
            return Value1.Equals(other.Value1);
        }
    }

    public struct TupleValue<TValue1, TValue2> : IEquatable<TupleValue<TValue1, TValue2>>
    {
        private TValue1 _value1;
        private TValue2 _value2;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public bool Equals(TupleValue<TValue1, TValue2> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3> : IEquatable<TupleValue<TValue1, TValue2, TValue3>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;
        private TValue16 _value16;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }
        public TValue16 Value16
        {
            get { return _value16; }
            set { _value16 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15, TValue16 value16)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
            _value16 = value16;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15)
            && Value16.Equals(other.Value16);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;
        private TValue16 _value16;
        private TValue17 _value17;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }
        public TValue16 Value16
        {
            get { return _value16; }
            set { _value16 = value; }
        }
        public TValue17 Value17
        {
            get { return _value17; }
            set { _value17 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15, TValue16 value16, TValue17 value17)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
            _value16 = value16;
            _value17 = value17;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15)
            && Value16.Equals(other.Value16)
            && Value17.Equals(other.Value17);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;
        private TValue16 _value16;
        private TValue17 _value17;
        private TValue18 _value18;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }
        public TValue16 Value16
        {
            get { return _value16; }
            set { _value16 = value; }
        }
        public TValue17 Value17
        {
            get { return _value17; }
            set { _value17 = value; }
        }
        public TValue18 Value18
        {
            get { return _value18; }
            set { _value18 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15, TValue16 value16, TValue17 value17, TValue18 value18)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
            _value16 = value16;
            _value17 = value17;
            _value18 = value18;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15)
            && Value16.Equals(other.Value16)
            && Value17.Equals(other.Value17)
            && Value18.Equals(other.Value18);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;
        private TValue16 _value16;
        private TValue17 _value17;
        private TValue18 _value18;
        private TValue19 _value19;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }
        public TValue16 Value16
        {
            get { return _value16; }
            set { _value16 = value; }
        }
        public TValue17 Value17
        {
            get { return _value17; }
            set { _value17 = value; }
        }
        public TValue18 Value18
        {
            get { return _value18; }
            set { _value18 = value; }
        }
        public TValue19 Value19
        {
            get { return _value19; }
            set { _value19 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15, TValue16 value16, TValue17 value17, TValue18 value18, TValue19 value19)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
            _value16 = value16;
            _value17 = value17;
            _value18 = value18;
            _value19 = value19;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15)
            && Value16.Equals(other.Value16)
            && Value17.Equals(other.Value17)
            && Value18.Equals(other.Value18)
            && Value19.Equals(other.Value19);
        }
    }

    public struct TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19, TValue20> : IEquatable<TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19, TValue20>>
    {
        private TValue1 _value1;
        private TValue2 _value2;
        private TValue3 _value3;
        private TValue4 _value4;
        private TValue5 _value5;
        private TValue6 _value6;
        private TValue7 _value7;
        private TValue8 _value8;
        private TValue9 _value9;
        private TValue10 _value10;
        private TValue11 _value11;
        private TValue12 _value12;
        private TValue13 _value13;
        private TValue14 _value14;
        private TValue15 _value15;
        private TValue16 _value16;
        private TValue17 _value17;
        private TValue18 _value18;
        private TValue19 _value19;
        private TValue20 _value20;

        public TValue1 Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        public TValue2 Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        public TValue3 Value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }
        public TValue4 Value4
        {
            get { return _value4; }
            set { _value4 = value; }
        }
        public TValue5 Value5
        {
            get { return _value5; }
            set { _value5 = value; }
        }
        public TValue6 Value6
        {
            get { return _value6; }
            set { _value6 = value; }
        }
        public TValue7 Value7
        {
            get { return _value7; }
            set { _value7 = value; }
        }
        public TValue8 Value8
        {
            get { return _value8; }
            set { _value8 = value; }
        }
        public TValue9 Value9
        {
            get { return _value9; }
            set { _value9 = value; }
        }
        public TValue10 Value10
        {
            get { return _value10; }
            set { _value10 = value; }
        }
        public TValue11 Value11
        {
            get { return _value11; }
            set { _value11 = value; }
        }
        public TValue12 Value12
        {
            get { return _value12; }
            set { _value12 = value; }
        }
        public TValue13 Value13
        {
            get { return _value13; }
            set { _value13 = value; }
        }
        public TValue14 Value14
        {
            get { return _value14; }
            set { _value14 = value; }
        }
        public TValue15 Value15
        {
            get { return _value15; }
            set { _value15 = value; }
        }
        public TValue16 Value16
        {
            get { return _value16; }
            set { _value16 = value; }
        }
        public TValue17 Value17
        {
            get { return _value17; }
            set { _value17 = value; }
        }
        public TValue18 Value18
        {
            get { return _value18; }
            set { _value18 = value; }
        }
        public TValue19 Value19
        {
            get { return _value19; }
            set { _value19 = value; }
        }
        public TValue20 Value20
        {
            get { return _value20; }
            set { _value20 = value; }
        }

        public TupleValue(TValue1 value1, TValue2 value2, TValue3 value3, TValue4 value4, TValue5 value5, TValue6 value6, TValue7 value7, TValue8 value8, TValue9 value9, TValue10 value10, TValue11 value11, TValue12 value12, TValue13 value13, TValue14 value14, TValue15 value15, TValue16 value16, TValue17 value17, TValue18 value18, TValue19 value19, TValue20 value20)
        {
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
            _value6 = value6;
            _value7 = value7;
            _value8 = value8;
            _value9 = value9;
            _value10 = value10;
            _value11 = value11;
            _value12 = value12;
            _value13 = value13;
            _value14 = value14;
            _value15 = value15;
            _value16 = value16;
            _value17 = value17;
            _value18 = value18;
            _value19 = value19;
            _value20 = value20;
        }

        public bool Equals(TupleValue<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17, TValue18, TValue19, TValue20> other)
        {
            return Value1.Equals(other.Value1)
            && Value2.Equals(other.Value2)
            && Value3.Equals(other.Value3)
            && Value4.Equals(other.Value4)
            && Value5.Equals(other.Value5)
            && Value6.Equals(other.Value6)
            && Value7.Equals(other.Value7)
            && Value8.Equals(other.Value8)
            && Value9.Equals(other.Value9)
            && Value10.Equals(other.Value10)
            && Value11.Equals(other.Value11)
            && Value12.Equals(other.Value12)
            && Value13.Equals(other.Value13)
            && Value14.Equals(other.Value14)
            && Value15.Equals(other.Value15)
            && Value16.Equals(other.Value16)
            && Value17.Equals(other.Value17)
            && Value18.Equals(other.Value18)
            && Value19.Equals(other.Value19)
            && Value20.Equals(other.Value20);
        }
    }
}