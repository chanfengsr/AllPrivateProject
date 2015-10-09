using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;
using ReflectOffice.Excel;
using MSOffice = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int id);

        public Form1()
        {
            InitializeComponent();
        }

        private System.Data.DataTable CreateDataSource()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("学生姓名", typeof(System.String)));
            dt.Columns.Add(new System.Data.DataColumn("语文", typeof(System.Decimal)));
            dt.Columns.Add(new System.Data.DataColumn("数学", typeof(System.Decimal)));
            dt.Columns.Add(new System.Data.DataColumn("英语", typeof(System.Decimal)));
            for (int i = 0; i < 8; i++)
            {
                System.Random rd = new System.Random(Environment.TickCount * i); ;
                dr = dt.NewRow();
                dr[0] = "学生" + i.ToString();
                dr[1] = System.Math.Round(rd.NextDouble() * 100, 2);
                dr[2] = System.Math.Round(rd.NextDouble() * 100, 2);
                dr[3] = System.Math.Round(rd.NextDouble() * 100, 2);
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 把DataTable的数据导出到Excel文件中
        /// </summary>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="dataTable">要导出的数据表</param>
        /// <param name="errorInfo">操作出错信息</param>
        /// <returns>是否导出成功</returns>
        public static bool GenerateExcel(string fileName, System.Data.DataTable dataTable, out string errorInfo)
        {
            errorInfo = null;

            object _objApp;
            object _objBook;
            object _objBooks;
            object _objSheets;
            object _objSheet;
            object _objCells;
            object[] _objaParameters;

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return true;
            }

            try
            {
                // 获取Excel类型并建立其实例
                Type objExcelType = Type.GetTypeFromProgID("Excel.Application");
                if (objExcelType == null)
                {
                    return false;
                }
                _objApp = Activator.CreateInstance(objExcelType);
                if (_objApp == null)
                {
                    return false;
                }
                int _hwnd = (int)_objApp.GetType().InvokeMember("Hwnd", BindingFlags.GetProperty, null, _objApp, null);

                //获取Workbook集
                _objBooks = _objApp.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, _objApp, null);

                //添加一个新的Workbook
                _objBook = _objBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objBooks, null);

                //获取Sheet集
                _objSheets = _objBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, _objBook, null);

                //获取第一个Sheet对象
                _objaParameters = new Object[1] { 1 };
                _objSheet = _objSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objSheets, _objaParameters);

                try
                {
                    //写入表头信息
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        _objaParameters = new Object[2] { 1, i + 1 };
                        _objCells = _objSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objSheet, _objaParameters);
                        //向指定单元格填写内容值
                        _objaParameters = new Object[1] { dataTable.Columns[i].Caption };
                        _objCells.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, _objCells, _objaParameters);
                    }
                    //写入表中数据内容
                    for (int i = 0; i < dataTable.DefaultView.Count; i++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            _objaParameters = new Object[2] { i + 2, col + 1 };
                            _objCells = _objSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objSheet, _objaParameters);
                            //向指定单元格填写内容值
                            _objaParameters = new Object[1] { dataTable.DefaultView[i][col].ToString() };
                            _objCells.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, _objCells, _objaParameters);
                        }
                    }
                }
                catch (Exception operExce)
                {
                    errorInfo = operExce.Message;
                    return false;
                }
                finally
                {
                    //不提示保存
                    _objaParameters = new Object[1] { false };
                    _objApp.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, _objApp, _objaParameters);

                    //保存文件并退出
                    _objaParameters = new Object[1] { fileName };
                    _objBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, _objBook, _objaParameters);
                    _objApp.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, _objApp, null);

                    GC.Collect();

                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(objCells);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_objSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_objSheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_objBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_objBooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_objApp);

                    IntPtr ptr = new IntPtr(_hwnd);
                    int pid = 0;
                    GetWindowThreadProcessId(ptr, out pid);
                    System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(pid);
                    proc.Kill();
                }
                return true;
            }
            catch (Exception appExce)
            {
                errorInfo = appExce.Message;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MSOffice.Application App = new MSOffice.Application();
            //MSOffice.Workbook Book = App.Workbooks.Add(MSOffice.XlWBATemplate.xlWBATWorksheet);
            ReflectOffice.Excel.Application App = new ReflectOffice.Excel.Application();
            ReflectOffice.Excel.Workbook book = App.Workbooks.Add();

            App.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string outMsg="";

            GenerateExcel(@"r:\abc", CreateDataSource(), out outMsg);

            MessageBox.Show(outMsg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReflectOffice.Excel.Application app = new ReflectOffice.Excel.Application();
            //app.DisplayAlerts = false;
            Workbook book = app.Workbooks.Add();
            Worksheets sheets = book.Worksheets.get_Worksheets();
            Worksheet sheet = sheets.AddWorksheet();


            sheet = sheets[2];
            sheet.Cells[1, 1].Value2 = app.InchesToPoints2(1.3).ToString();
            sheet.PageSetup.LeftMargin = app.InchesToPoints2(1.3);

            sheet.Cells[2, 2].FormulaR1C1 = "4,1";
            sheet.get_Range("A1", "D3").Font.Size = 20;
            sheet.get_Range("A1", "D3").Font.Name = "宋体";
            sheet.get_Range("A1", "D3").Font.Underline = ReflectOffice.Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
            sheet.get_Range("A1", "D3").Font.FontStyle = "加粗 倾斜";
            sheet.get_Range("A1", "D3").ColumnWidth = 19;
            sheet.get_Range("A1", "D3").RowHeight = 15;
            sheet.get_Range("A1", "D3").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            sheet.get_Range("A1", "D3").Borders[XlBordersIndex.xlEdgeBottom].Weight = ReflectOffice.Excel.XlBorderWeight.xlThick;
            sheet.get_Range("A1", "D3").HorizontalAlignment = ReflectOffice.Excel.XlHAlign.xlHAlignCenter;
            sheet.get_Range("A1", "D3").VerticalAlignment = ReflectOffice.Excel.XlVAlign.xlVAlignCenter;
            sheet.get_Range("A1", "D3").Rows.AutoFit();
            sheet.get_Range("A1", "D3").Columns.AutoFit();
            
            book.SaveAs(@"r:\abc.xls", XlFileFormat.xlExcel8);
            book.Close();
            app.Release();

            //Microsoft.Office.Interop.Excel.XlUnderlineStyle;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _strFileName = @"r:\abcd.xls";

            MSOffice.Application App = new MSOffice.Application();
            MSOffice.Workbook Book = App.Workbooks.Add(MSOffice.XlWBATemplate.xlWBATWorksheet);
            MSOffice.Worksheet Sheet = (MSOffice.Worksheet)Book.ActiveSheet;
            MSOffice.Worksheets sheets = (MSOffice.Worksheets)Book.Sheets;

            App.Visible = false;
            App.DisplayAlerts = false;

            object obj = App.Caller[1];
            obj = App.Charts;
            obj = App.ClipboardFormats;
            obj = App.CutCopyMode;
            obj = App.StatusBar;
            obj = App.Workbooks[1];
            obj = Book.ActiveChart;
            obj = Sheet.PageSetup.FirstPage.CenterFooter.Picture.Application;
            obj = Sheet.Range["", ""].Font.Application;
            obj = Sheet.Range["", ""].Borders[MSOffice.XlBordersIndex.xlDiagonalUp].Application;
            obj = App.Windows[""].SheetViews[""];
            obj = App.Charts;
            obj = Sheet.Names;
            obj = Sheet.Names.Item(1);
            
            Sheet.Copy();

            MSOffice.Areas a = null;
            obj = a.Application;
           // MSOffice.Hyperlink

            App.Workbooks.Open("");
            //     _xlsApp.Selection 
            App.Windows[1].Zoom = 150;
            //xlsSheet.Rows[1, 1];
            MSOffice.Range rng = Sheet.Range[1, 2];
            

            MSOffice.Shape shape = Sheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, 0, 48, 72, 60);
            shape.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            shape.Shadow.Obscured = Microsoft.Office.Core.MsoTriState.msoCTrue;
            shape.Shadow.Type = Microsoft.Office.Core.MsoShadowType.msoShadow18;
            shape.Fill.UserPicture(@"r:\test.jpg");
            
            //xlsSheet.Shapes.AddOLEObject
            //shape.GroupItems.Item
            //shape.Glow.Color

            Sheet.get_Range("");

            App.Windows[1].Height = 100;

            textBox1.Text = App.Version;

            App.Quit();
        }

        //My excel
        private void button5_Click(object sender, EventArgs e)
        {
            string _strFileName = @"r:\abcd.xlsx";

            ReflectOffice.Excel.Application app = new ReflectOffice.Excel.Application();
            //app.Visible = true;

            textBox1.Text = app.InchesToPoints(5).ToString();
            app.DisplayAlerts = false;
            app.Visible = false;
            Workbook book = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //Worksheet sheet = new Worksheet(book.Worksheets.Add());
            Worksheet sheet = app.ActiveSheet;
            sheet.Cells[1, 1].Value2 = app.InchesToPoints2(1.3).ToString();
            sheet.PageSetup.LeftMargin = app.InchesToPoints2(1.3);

            sheet.Cells[2, 3].FormulaR1C1 = "4,1";
            sheet.get_Range("A1", "D3").Font.Size = 20;
            sheet.get_Range("A1", "D3").Font.Name = "宋体";
            sheet.get_Range("A1", "D3").Font.Underline = ReflectOffice.Excel.XlUnderlineStyle.xlUnderlineStyleSingle;
            sheet.get_Range("A1", "D3").Font.FontStyle = "加粗 倾斜";
            sheet.get_Range("A1", "D3").ColumnWidth = 19;
            sheet.get_Range("A1", "D3").RowHeight = 15;
            sheet.get_Range("A1", "D3").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            sheet.get_Range("A1", "D3").Borders[XlBordersIndex.xlEdgeBottom].Weight = ReflectOffice.Excel.XlBorderWeight.xlThick;
            sheet.get_Range("A1", "D3").HorizontalAlignment = ReflectOffice.Excel.XlHAlign.xlHAlignCenter;
            sheet.get_Range("A1", "D3").VerticalAlignment = ReflectOffice.Excel.XlVAlign.xlVAlignCenter;
            sheet.get_Range("A1", "D3").Rows.AutoFit();
            sheet.get_Range("A1", "D3").Columns.AutoFit();
            sheet.get_Range("A1", "D3").Merge();
            sheet.Select();

            sheet.get_Range(sheet.Cells[5, 5], sheet.Cells[6, 6]).ColumnWidth = 50;

            sheet.get_Range("A1:E5").CopyPicture();
            sheet.get_Range("A1").CopyPicture();


            Range rng = sheet.get_Range("A11", "D13");
            rng.Merge();

            app.Windows[1].Zoom = 110;


            app.Visible = true;


            //book.SaveAs(_strFileName);
            //app.Release();

        }

        private void 辅助工具_Click(object sender, EventArgs e)
        {
            辅助工具 fzgj = new 辅助工具();
            fzgj.Show();
        }

        private void 新功能测试_Click(object sender, EventArgs e)
        {
            string strTemplatesFile = @"E:\Project\SunlikeERP\ERP实施\ERP相关开发\ERP外挂小工具\ERP外挂小工具\bin\Release\ExcelTemplates\tmpltsRequisition.xls";
            ReflectOffice.Excel.Application app = new ReflectOffice.Excel.Application();

            Workbook tmpBook = app.Workbooks.Open(Filename: strTemplatesFile, ReadOnly: true);
            Workbook book = app.Workbooks.Add();
            

            tmpBook.Sheets.get_Worksheets()[1].Copy(book.Sheets.get_Worksheets()[1]);
            tmpBook.Close();

            app.Visible = true;
        }
    }
}
