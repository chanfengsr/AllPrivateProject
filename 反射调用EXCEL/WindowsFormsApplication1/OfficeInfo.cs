using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MSOffice = Microsoft.Office.Interop.Excel;
using System.Data;

namespace WindowsFormsApplication1
{
    class OfficeInfo
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int id);
        
        protected void ReleaseExcel(ref MSOffice.Application excelApp, ref MSOffice.Workbook excelBook, ref MSOffice.Worksheet excelSheet)
        {
            try
            {
                excelBook.Close(false, null, null);
                excelApp.Quit();
                GC.Collect();

                IntPtr ptr = new IntPtr(excelApp.Hwnd);
                int pid = 0;
                GetWindowThreadProcessId(ptr, out pid);
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(pid);

                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)excelApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)excelBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)excelSheet);
                excelApp = null;
                excelBook = null;
                excelSheet = null;

                //最后尝试结束进程，出错表示已销毁
                try
                { proc.Kill(); }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <param name="strStartDate">起始日期</param>
        /// <param name="strEndDate">结束日期</param>
        /// <param name="dtDet">明细数据</param>
        /// <returns></returns>
        private bool ExportExcel(string strStartDate, string strEndDate, DataTable dtDet)
        {
            #region 定义Excel对象实例
            string _strFileName = @"r:\abcd.xls";
           
            MSOffice.Application _xlsApp = new MSOffice.Application();
            _xlsApp.Visible = false;
            _xlsApp.DisplayAlerts = false;
  
            

            if (_xlsApp == null) { return false; }
            
            MSOffice.Workbook _xlsBook = _xlsApp.Workbooks.Add(MSOffice.XlWBATemplate.xlWBATWorksheet);
            _xlsBook.Worksheets.Add();
            
            MSOffice.Worksheet _xlsSheet = (MSOffice.Worksheet)_xlsBook.ActiveSheet;
            
            #endregion

            try
            {
                try
                {
                    //填充Excel对象
                    FillExcel(strStartDate, strEndDate, dtDet, ref _xlsSheet);

                    //格式数据
                    FormatExcel(ref _xlsApp, ref _xlsSheet, dtDet.Rows.Count);

                    System.IO.File.Delete(_strFileName);
                    _xlsBook.Saved = true;
                    _xlsBook.SaveAs(_strFileName, MSOffice.XlFileFormat.xlExcel9795, "", "",false, false, MSOffice.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    //释放Excel及其进程
                    ReleaseExcel(ref _xlsApp, ref _xlsBook, ref _xlsSheet);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 填充Excel对象
        /// </summary>
        /// <param name="strStartDate">起始日期</param>
        /// <param name="strEndDate">结束日期</param>
        /// <param name="dtDet">明细数据</param>
        /// <param name="excelSheet">excelSheet</param>
        private void FillExcel(string strStartDate, string strEndDate, DataTable dtDet, ref MSOffice.Worksheet excelSheet)
        {
            decimal fltTotPrice = 0;
            int intSheetDataRow = (int)System.Math.Ceiling(dtDet.Rows.Count / (double)2);

            foreach (DataRow dr in dtDet.Rows)
            {
                fltTotPrice += decimal.Parse(dr["PRICE"].ToString());
            }

            string strHeadMod = "统计时间：{0} 至 {1}";

            excelSheet.Cells[1, 1] = "东方肝胆外科医院";
            excelSheet.Cells[2, 1] = "部 门 耗 材 领 取 统 计 表";
            excelSheet.Cells[3, 1] = string.Format(strHeadMod, strStartDate, strEndDate);

            excelSheet.Cells[4, 1] = "部门名称";
            excelSheet.Cells[4, 2] = "领取金额";
            excelSheet.Cells[4, 4] = "部门名称";
            excelSheet.Cells[4, 5] = "领取金额";

            int iCurRow, iCurCol;
            for (int iRow = 0; iRow < dtDet.Rows.Count; iRow++)
            {
                if (iRow < intSheetDataRow) { iCurRow = 5 + iRow; iCurCol = 1; }
                else { iCurRow = 5 + iRow - intSheetDataRow; iCurCol = 4; }

                excelSheet.Cells[iCurRow, iCurCol] = dtDet.Rows[iRow]["DEPTNAME"].ToString();
                excelSheet.Cells[iCurRow, iCurCol + 1] = decimal.Parse(dtDet.Rows[iRow]["PRICE"].ToString()).ToString("n");
            }

            excelSheet.Cells[4 + intSheetDataRow + 2, 4] = "总计金额：";
            excelSheet.Cells[4 + intSheetDataRow + 2, 5] = fltTotPrice.ToString("n");
        }

        /// <summary>
        /// 格式化EXCEL
        /// </summary>
        /// <param name="excelApp">excelApp</param>
        /// <param name="excelSheet">excelSheet</param>
        /// <param name="DetRowCnt">行数</param>
        private void FormatExcel(ref MSOffice.Application excelApp, ref MSOffice.Worksheet excelSheet, int DetRowCnt)
        {
            MSOffice.Range rng;
            int intDtEnd = 4 + (int)System.Math.Ceiling(DetRowCnt / (double)2);

            #region 设置全局
            //全局字体及大小
            excelSheet.get_Range("A1", "G" + Convert.ToString(intDtEnd + 3)).Font.Size = 10;
            excelSheet.get_Range("A1", "G" + Convert.ToString(intDtEnd + 3)).Font.Name = "宋体";
            #endregion
            
            #region 调整列宽
            excelSheet.get_Range("A1", "A1").ColumnWidth = 18;
            excelSheet.get_Range("B1", "B1").ColumnWidth = 18;
            excelSheet.get_Range("C1", "C1").ColumnWidth = 0.3;
            excelSheet.get_Range("D1", "D1").ColumnWidth = 18;
            excelSheet.get_Range("E1", "E1").ColumnWidth = 18;
            #endregion
            
            #region 调整行高
            excelSheet.get_Range("A1", "A1").RowHeight = 22.5;
            excelSheet.get_Range("A2", "A2").RowHeight = 22.5;
            excelSheet.get_Range("A3", "A3").RowHeight = 23.25;
            excelSheet.get_Range("A4", "A4").RowHeight = 21;

            excelSheet.get_Range("A" + Convert.ToString(5), "A" + Convert.ToString(intDtEnd + 2)).RowHeight = 14.25;

            #endregion

            #region 设置线条
            rng = excelSheet.get_Range("A4", "E" + Convert.ToString(intDtEnd));
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeTop].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeTop].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeBottom].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeBottom].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeLeft].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeLeft].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeRight].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeRight].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlInsideHorizontal].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlInsideVertical].LineStyle = MSOffice.XlLineStyle.xlContinuous;

            rng = excelSheet.get_Range("C4", "C" + Convert.ToString(intDtEnd));
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeLeft].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeRight].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.Borders[MSOffice.XlBordersIndex.xlInsideHorizontal].LineStyle = MSOffice.XlLineStyle.xlLineStyleNone;

            rng = excelSheet.get_Range("A4", "E4");
            rng.Borders[MSOffice.XlBordersIndex.xlEdgeBottom].Weight = MSOffice.XlBorderWeight.xlMedium;
            #endregion

            #region 设置字体格式与排列
            //名称居左，金额居右
            excelSheet.get_Range("A5", "A" + Convert.ToString(intDtEnd)).HorizontalAlignment = MSOffice.XlHAlign.xlHAlignLeft;
            excelSheet.get_Range("B5", "B" + Convert.ToString(intDtEnd)).HorizontalAlignment = MSOffice.XlHAlign.xlHAlignRight;
            excelSheet.get_Range("D5", "D" + Convert.ToString(intDtEnd)).HorizontalAlignment = MSOffice.XlHAlign.xlHAlignLeft;
            excelSheet.get_Range("E5", "E" + Convert.ToString(intDtEnd)).HorizontalAlignment = MSOffice.XlHAlign.xlHAlignRight;
            #endregion

            //几个特殊单元格
            excelSheet.get_Range("A1", "E1").Merge(true);
            excelSheet.get_Range("A2", "E2").Merge(true);
            
            rng = excelSheet.get_Range("A1", "E2");
            rng.Font.Bold = true;
            rng.Font.Size = 18;
            rng.Font.Name = "楷体_GB2312";
            rng.HorizontalAlignment = MSOffice.XlHAlign.xlHAlignCenter;
            rng.VerticalAlignment = MSOffice.XlVAlign.xlVAlignBottom;

            ////////////////////测试/////////////////////////////
            rng.Font.Background = 1;
            rng.Font.Bold = true;
            rng.Font.Size = 18;
            rng.Font.Name = "";
            rng.Font.Underline = true;
            rng.Font.Underline = MSOffice.XlUnderlineStyle.xlUnderlineStyleSingle;
            rng.Font.ThemeFont = MSOffice.XlThemeFont.xlThemeFontNone;
            excelApp.ActiveCell.FormulaR1C1 = "";
            rng.Borders[MSOffice.XlBordersIndex.xlInsideVertical].LineStyle = MSOffice.XlLineStyle.xlContinuous;
            rng.Borders[MSOffice.XlBordersIndex.xlInsideVertical].Weight = MSOffice.XlBorderWeight.xlMedium;
            rng.AutoFit();
            rng.Rows.AutoFit();
            rng.Columns.AutoFit();


            rng = excelSheet.get_Range("A3", "A3");
            rng.Font.Bold = false;
            rng.Font.Size = 11;
            rng.Font.Name = "楷体_GB2312";
            rng.HorizontalAlignment = MSOffice.XlHAlign.xlHAlignLeft;
            
            rng = excelSheet.get_Range("A4", "E4");
            rng.Font.Bold = true;
            rng.Font.Size = 12;
            rng.HorizontalAlignment = MSOffice.XlHAlign.xlHAlignCenter;

            

            #region 设置打印格式
            excelSheet.PageSetup.PaperSize = MSOffice.XlPaperSize.xlPaperA4;
            //excelSheet.PageSetup.FitToPagesWide = 1;
            //excelSheet.PageSetup.FitToPagesTall = 100;
            //excelSheet.PageSetup.Zoom = false;
            excelSheet.PageSetup.LeftMargin = excelApp.InchesToPoints(1 / 2.54 * 1.3);
            excelSheet.PageSetup.RightMargin = excelApp.InchesToPoints(1 / 2.54 * 1.3);
            excelSheet.PageSetup.TopMargin = excelApp.InchesToPoints(1 / 2.54 * 1.9);
            excelSheet.PageSetup.BottomMargin = excelApp.InchesToPoints(1 / 2.54 * 1.9);
            excelSheet.PageSetup.FooterMargin = excelApp.InchesToPoints(1 / 2.54 * 0.5);
            excelSheet.PageSetup.Orientation = MSOffice.XlPageOrientation.xlLandscape;
            #endregion
        }
 
    }
}
