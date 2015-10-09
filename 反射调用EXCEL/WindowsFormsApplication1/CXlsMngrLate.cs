using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace OrgDept
{
    /// <summary>
    /// Note:Manage Excel Related Object,use Late Binding technology
    /// Date:2008-05-14
    /// Author: wucz
    /// </summary>
    class CXlsMngrLate
    {
        public enum XlWBATemplate
        {
            xlWBATWorksheet=-4167 //工作表
        }
        public enum XlHAlign
        {
            xlHAlignLeft=-4131,
            xlHAlignCenter=-4108
        }

        public enum XlVAlign
        {
            xlVAlignTop=-4160,
            xlVAlignCenter=-4108
        }

        public enum XlPageOrientation
        {
            xlLandscape = 2, xlPortrait=1
        }

        public class CApplication
        {
            #region private field
            
            object _objAppLate;         //raw type
            
            CWorkBooks _cWorkBooks;   //supply with complete type
            CWorkSheet _activeSheet;   

            object[] parameters;    //method or set property parameters
            
            #endregion

            #region default construtor

            public CApplication()
            {
                Type objType;
                objType = Type.GetTypeFromProgID("Excel.Application");
                _objAppLate = Activator.CreateInstance(objType);

                _cWorkBooks = new CWorkBooks(this);
                
            }

            #endregion

            #region public property

            /// <summary>
            /// 如果宏运行时 Microsoft Excel 显示特定的警告和消息，则该属性值为 True。Boolean 类型，可读写
            /// 与Application.DisplayAlters同意词
            /// </summary>
            public bool DisplayAlerts
            {
                set 
                {
                    if (IsExcelInstalled)
                    {
                        parameters = new object[1];
                        parameters[0] = value;
                        _objAppLate.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty,
                            null, _objAppLate, parameters);
                    }
                }
                get
                {
                    bool toRet = false;
                    if (IsExcelInstalled)
                    {
                        toRet = (bool)_objAppLate.GetType().InvokeMember("DisplayAlerts", BindingFlags.GetProperty,
                            null, _objAppLate, null);
                    }

                    return toRet;
                }
            }
            /// <summary>
            /// 返回或设置一个 Boolean 值，它确定对象是否可见。可读写。
            /// 与Application.Visible 同意词
            /// </summary>
            public bool Visible
            {
                set
                {
                    if (IsExcelInstalled)
                    {
                        parameters = new object[1];
                        parameters[0] = value;
                        _objAppLate.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                            null, _objAppLate, parameters);
                    }
                }
                get
                {
                    bool toRet = false;
                    if (IsExcelInstalled)
                    {
                        toRet = (bool)_objAppLate.GetType().InvokeMember("Visible", BindingFlags.GetProperty, 
                            null, _objAppLate, null);
                    }

                    return toRet;
                }
            }

            /// <summary>
            /// 获取当前Office Excel是否安装,已经安装返回true,否则返回false
            /// </summary>
            public bool IsExcelInstalled
            {
                get { return _objAppLate != null; }
            }

            /// <summary>
            /// Return Application Object From Activator.CreateInstance(...).
            /// </summary>
            public object ObjLateApp
            {
                get { return _objAppLate; }
            }

            /// <summary>
            /// 返回一个 Workbooks 集合，该集合表示所有打开的工作簿。只读。
            /// </summary>
            public CXlsMngrLate.CWorkBooks WorkBooks
            {
                get { return _cWorkBooks; }
            }

            /// <summary>
            /// 返回一个对象，它代表活动工作簿中或指定的窗口或工作簿中的活动工作表（最上面的工作表）。如果没有活动的工作表，则返回 Nothing。
            /// </summary>
            public CWorkSheet ActiveSheet
            {
                get 
                {
                    if (_activeSheet == null)
                    {
                        object shtLate;
                        shtLate = _objAppLate.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty,
                            null, _objAppLate, null);

                        _activeSheet = new CWorkSheet(shtLate);
                    }

                    return _activeSheet;
                }
            }
            #endregion

            #region method
            /// <summary>
            /// 将度量单位从英寸转换为磅 （磅：指打印的字符的高度的度量单位。1 磅等于 1/72 英寸，或大约等于 1 厘米的 1/28。）。
            /// </summary>
            /// <param name="inches"></param>
            /// <returns></returns>
            public double InchesToPoints(double inches)
            {
                double toRet;
                parameters = new object[1];
                parameters[0] = inches;
                toRet =(double) _objAppLate.GetType().InvokeMember("InchesToPoints", BindingFlags.InvokeMethod,
                    null, _objAppLate, parameters);
                return toRet;
            }
            #endregion



        }

        public class CWorkBooks
        {
            #region private field
            
            CApplication _cApp;    //supply with complete type

            object _objAppLate;         //raw type
            object _objBooksLate;       //raw type
            object[] parameters;    //method or set property parameters
            
            #endregion

            #region default constructor
            /// <summary>
            /// Initial Class WorkBooks By CXlsMngrLate.CApplication
            /// </summary>
            /// <param name="xlsApp"> CXlsMngrLate.CApplication </param>
            public CWorkBooks(CXlsMngrLate.CApplication cApplication)
            {
                _cApp = cApplication;
                
                _objAppLate=cApplication.ObjLateApp;

                _objBooksLate = _objAppLate.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, 
                    null, _objAppLate, null);
            }    

            #endregion

            #region property
            /// <summary>
            /// Get Late Excel Application
            /// It's different from the Excel Application for ms office
            /// </summary>
            public CXlsMngrLate.CApplication Application
            {
                get { return _cApp; }
            }
            

            #endregion

            #region method

            /// <summary>
            /// 打开一个 Excel 工作簿
            /// </summary>
            /// <param name="fileName">文件名,与 Workbooks.Open(fileName) 参数意义相同</param>
            public void Open(string fileName)
            {

                if (_cApp != null && _cApp.IsExcelInstalled)
                {
                    parameters = new object[1];
                    parameters[0] = fileName;

                    _objBooksLate.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, 
                        null, _objBooksLate, parameters, null);
                }
            }

            public CWorkBook Add(object optParam)
            {
                object objBookLate;
                if (optParam == null)
                {
                    objBookLate = _objBooksLate.GetType().InvokeMember("Add", BindingFlags.InvokeMethod,
                        null, _objBooksLate, null);
                }
                else
                {

                    parameters = new object[1];
                    parameters[0] = optParam;
                    objBookLate = _objBooksLate.GetType().InvokeMember("Add", BindingFlags.InvokeMethod,
                        null, _objBooksLate, parameters);
                }

                return new CWorkBook(objBookLate);
            }
            #endregion
        }
        
        public class CWorkBook
        {
            CXlsMngrLate.CApplication _cApp;

            object _objBookLate;

            public CWorkBook(CXlsMngrLate.CApplication cApplication)
            {
                _cApp = cApplication;    
            }

            public CWorkBook(object objBookLate)
            {
                _objBookLate = objBookLate;
            }


        }

        public class CWorkSheet
        {
            CXlsMngrLate.CApplication _cApp;

            object _objSheetLate;

            object[] parameters;

            public CWorkSheet(CXlsMngrLate.CApplication cApplication)
            {
                _cApp = cApplication;
            }

            public CWorkSheet(object objSheetLate)
            {
                _objSheetLate = objSheetLate;
            }
            /// <summary>
            ///
            /// </summary>
            /// <param name="arg1"></param>
            /// <param name="arg2"></param>
            /// <returns></returns>
            public CRange GetRange(object arg1, object arg2)
            {
                CRange toRet;
                object objRangeLate;
                parameters = new object[2];
                parameters[0] = arg1;
                parameters[1] = arg2;

                objRangeLate = _objSheetLate.GetType().InvokeMember("Range", BindingFlags.GetProperty, 
                    null, _objSheetLate, parameters);
                
                
                toRet = new CRange(objRangeLate);

                return toRet;
            }

            public CRange GetRangeCell(object arg1, object arg2)
            {
                CRange toRet;
                object objRangeLate;
                parameters = new object[2];
                parameters[0] = arg1;
                parameters[1] = arg2;

                objRangeLate = _objSheetLate.GetType().InvokeMember("Cells", BindingFlags.GetProperty, 
                    null, _objSheetLate, parameters);

                toRet=new CRange(objRangeLate);
                return toRet;
            }

            public CPageSetup PageSetup
            {
                get
                {
                    CPageSetup toRet;
                    object objPageSetupLate;
                    objPageSetupLate = _objSheetLate.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                        null, _objSheetLate, null);

                    toRet = new CPageSetup(objPageSetupLate);

                    return toRet;
                }
            }
        }

        public class CRange
        {
            object _objRangeLate;
            object[] parameters;

            public CRange(object objRangeLate)
            {
                _objRangeLate = objRangeLate;
            }

            public object GetItem(object arg1, object arg2)
            {
                object toRet;
                parameters = new object[2];
                parameters[0] = arg1;
                parameters[1] = arg2;


                toRet = _objRangeLate.GetType().InvokeMember("Item", BindingFlags.GetProperty, 
                    null, _objRangeLate, parameters);

                return toRet;
            }

            public object CurrentRangeLate
            {
                get { return _objRangeLate; }
            }

            public object GetValue()
            {
                object toRet;

                toRet = _objRangeLate.GetType().InvokeMember("Value", BindingFlags.GetProperty, 
                    null, _objRangeLate, null);

                return toRet;
            }


            public void Merge(object across)
            {
                parameters = new object[1];
                parameters[0] = across;
                _objRangeLate.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod, null, _objRangeLate, parameters);
            }

            public void SetFontName(object fontName)
            {
                object objFont;
                objFont = _objRangeLate.GetType().InvokeMember("Font", BindingFlags.GetProperty,
                    null, _objRangeLate, null);

                parameters = new object[1];
                parameters[0] = fontName;
                objFont.GetType().InvokeMember("Name", BindingFlags.SetProperty,
                    null, objFont, parameters);
            }
            public void SetFontSize(object fontSize)
            {
                object objFont;
                objFont = _objRangeLate.GetType().InvokeMember("Font", BindingFlags.GetProperty,
                    null, _objRangeLate, null);

                parameters = new object[1];
                parameters[0] = fontSize;
                objFont.GetType().InvokeMember("Size", BindingFlags.SetProperty,
                    null, objFont, parameters);
            }

            /// <summary>
            /// 返回或设置一个 Variant 型，它代表指定单元格的值。
            /// </summary>
            public object Value
            {
                get { return GetValue(); }
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;

                    _objRangeLate.GetType().InvokeMember("Value", BindingFlags.SetProperty,
                        null, _objRangeLate, parameters);

                }
            }
            /// <summary>
            /// 返回或设置单元格值。Variant 类型，可读写。
            /// </summary>
            public object Value2
            {
                get 
                {
                    object toRet;
                    toRet = _objRangeLate.GetType().InvokeMember("Value2", BindingFlags.GetProperty, 
                        null, _objRangeLate, null);

                    return toRet;
                }
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;

                    _objRangeLate.GetType().InvokeMember("Value2", BindingFlags.SetProperty, 
                        null, _objRangeLate, parameters);

                }
            }

            /// <summary>
            /// 以磅为单位返回或设置指定区域中所有行的行高。如果指定区域中的各行的行高不等，则返回 null。Variant 类型，可读写。
            /// </summary>
            public object RowHeight
            {
                get 
                {
                    object toRet;
                    toRet = _objRangeLate.GetType().InvokeMember("RowHeight", BindingFlags.GetProperty, 
                        null, _objRangeLate, null);

                    return toRet;
                }
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;

                    _objRangeLate.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, 
                        null, _objRangeLate, parameters);
                }
            }

            public object NumberFormatLocal
            {
                get 
                {
                    object toRet;
                    toRet = _objRangeLate.GetType().InvokeMember("NumberFormatLocal", BindingFlags.GetProperty,
                        null, _objRangeLate, null);
                    return toRet;
                }
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objRangeLate.GetType().InvokeMember("NumberFormatLocal", BindingFlags.SetProperty,
                        null, _objRangeLate, parameters);
                }
            }

            public bool WrapText
            {
                get
                {
                    bool toRet = false;
                    toRet = (bool)_objRangeLate.GetType().InvokeMember("WrapText", BindingFlags.GetProperty,
                        null, _objRangeLate, null);
                    return toRet;
                }
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objRangeLate.GetType().InvokeMember("WrapText", BindingFlags.SetProperty,
                        null, _objRangeLate, parameters);
                }
            }

            public object HorizontalAlignment
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objRangeLate.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty,
                        null, _objRangeLate, parameters);
                }
            }

            public object VerticalAlignment
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objRangeLate.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty,
                        null, _objRangeLate, parameters);
                }
            }
        }

        public class CPageSetup
        {
            object _objPageSetupLate;
            object[] parameters;
            public CPageSetup(object objPageSetupLate)
            {
                _objPageSetupLate = objPageSetupLate;
            }

            public bool PrintHeadings
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("PrintHeadings", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool PrintGridlines
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("PrintGridlines", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool CenterVertically
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("CenterVertically", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool CenterHorizontally
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("CenterHorizontally", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool Draft
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("Draft", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public double LeftMargin
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("LeftMargin", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public double RightMargin
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("RightMargin", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public double TopMargin
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("TopMargin", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public double BottomMargin
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("BottomMargin", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public object Zoom
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("Zoom", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public object Orientation
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("Orientation", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }
            public bool FitToPagesWide
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("FitToPagesWide", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool FitToPagesTall
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("FitToPagesTall", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

            public bool BlackAndWhite
            {
                set
                {
                    parameters = new object[1];
                    parameters[0] = value;
                    _objPageSetupLate.GetType().InvokeMember("BlackAndWhite", BindingFlags.SetProperty,
                        null, _objPageSetupLate, parameters);
                }
            }

        }
    }
}
