using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using ReflectOffice.Core;

namespace ReflectOffice.Excel
{
    /// <summary>代表整个 Microsoft Excel 应用程序。
    /// 说明：
    /// Application 对象包括：
    /// 应用程序范围的设置和选项。 
    /// 返回顶级对象的方法，如 ActiveCell 和 ActiveSheet 等。 
    /// </summary>
    public class Application
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int id);

        public object _objApplication;
        internal object[] _objaParameters;
        internal int _hwnd;//进程句柄，用于销毁进程

        internal bool _blnHaveAppInstance = false;

        /// <summary>创建一个新的 Excel 应用程序
        /// </summary>
        public Application()
        {
            try
            {
                // 获取Excel类型并建立其实例
                Type objExcelType = Type.GetTypeFromProgID("Excel.Application");
                if (objExcelType == null)
                    throw new Exception("Can't find Excel on your machine");

                _objApplication = Activator.CreateInstance(objExcelType);
                if (_objApplication == null)
                    throw new Exception("Can't create an Excel instance");

                //得到进程句柄
                _hwnd = (int)_objApplication.GetType().InvokeMember("Hwnd", BindingFlags.GetProperty, null, _objApplication, null);

                _blnHaveAppInstance = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>创建一个新的 Excel 应用程序
        /// </summary>
        /// <param name="objApplication"> Excel 应用程序对象</param>
        public Application(object objApplication)
        {
            try
            {
                if (objApplication == null)
                    throw new Exception("Can't create an Excel instance");

                _objApplication = objApplication;

                //得到进程句柄
                _hwnd = (int)_objApplication.GetType().InvokeMember("Hwnd", BindingFlags.GetProperty, null, _objApplication, null);

                _blnHaveAppInstance = true;
            }
            catch (Exception ex) { throw ex; }
        }

        #region 属性
        /// <summary>静态属性，标识是否有安装过Excel
        /// </summary>
        public static bool ExcelIsInstall
        {
            get
            {
                try
                {
                    Type objExcelType = Type.GetTypeFromProgID("Excel.Application");
                    return objExcelType != null;
                }
                catch (Exception) { return false; }
            }
        }

        /// <summary>返回一个 Range 对象，它代表活动窗口（最上方的窗口）或指定窗口中的活动单元格。如果窗口中没有显示工作表，此属性无效。只读。
        /// </summary>
        public Range ActiveCell
        {
            get
            {
                object objRange = _objApplication.GetType().InvokeMember("ActiveCell", BindingFlags.GetProperty, null, _objApplication, null);

                if (objRange == null)
                    return null;
                else
                    return new Range(objRange);
            }
        }

        /// <summary>返回一个 Chart 对象，它代表活动图表（嵌入式图表或图表工作表）。嵌入式图表在被选中或激活时被认为是活动的。当没有图表处于活动状态时，此属性返回 Nothing。
        /// </summary>
        public Chart ActiveChart
        {
            get
            {
                object objChart = _objApplication.GetType().InvokeMember("ActiveChart", BindingFlags.GetProperty, null, _objApplication, null);

                if (objChart == null)
                    return null;
                else
                    return new Chart(objChart);
            }
        }

        /// <summary>Returns a Integer that represents the encryption session associated with the active document. Read-only.
        /// </summary>
        public int ActiveEncryptionSession
        {
            get { return (int)_objApplication.GetType().InvokeMember("ActiveEncryptionSession", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置活动打印机的名称。String 类型，可读写。
        /// </summary>
        public string ActivePrinter
        {
            get { return _objApplication.GetType().InvokeMember("ActivePrinter", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("ActivePrinter", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个对象，它代表活动工作簿中或指定的窗口或工作簿中的活动工作表（最上面的工作表）。如果没有活动的工作表，则返回 Nothing。
        /// </summary>
        public Worksheet ActiveSheet
        {
            get
            {
                object objWorksheet = _objApplication.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, _objApplication, null);

                if (objWorksheet == null)
                    return null;
                else
                    return new Worksheet(objWorksheet);
            }
        }

        /// <summary>返回一个 Window 对象，该对象表示活动窗口（顶部窗口）。只读。如果没有打开的窗口，则返回 Nothing。
        /// </summary>
        public Window ActiveWindow
        {
            get
            {
                object objWindow = _objApplication.GetType().InvokeMember("ActiveWindow", BindingFlags.GetProperty, null, _objApplication, null);

                if (objWindow == null)
                    return null;
                else
                    return new Window(objWindow);
            }
        }

        /// <summary>返回一个 Workbook 对象，该对象表示活动窗口（顶部窗口）中的工作簿。只读。如果没有打开的窗口，或者“信息”窗口或“剪贴板”窗口为活动窗口，则返回 Nothing。
        /// </summary>
        public Workbook ActiveWorkbook
        {
            get
            {
                object objWorkbook = _objApplication.GetType().InvokeMember("ActiveWorkbook", BindingFlags.GetProperty, null, _objApplication, null);

                if (objWorkbook == null)
                    return null;
                else
                    return new Workbook(objWorkbook);
            }
        }

        /// <summary>返回一个 AddIns 集合，该集合表示“工具”菜单的“加载宏”对话框中列出的所有加载宏。只读。
        /// </summary>
        public AddIns AddIns
        {
            get { return new AddIns(_objApplication.GetType().InvokeMember("AddIns", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果 Microsoft Excel 在执行拖放编辑操作过程中，在覆盖非空单元格之前显示一条消息，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool AlertBeforeOverwriting
        {
            get { return (bool)_objApplication.GetType().InvokeMember("AlertBeforeOverwriting", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AlertBeforeOverwriting", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置替换启动文件夹的名称。String 类型，可读写。
        /// </summary>
        public string AltStartupPath
        {
            get { return _objApplication.GetType().InvokeMember("AltStartupPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("AltStartupPath", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，该值表示是否使用 ClearType 显示菜单、功能区和对话框文本中的字体。可读/写 Boolean 类型。
        /// </summary>
        public bool AlwaysUseClearType
        {
            get { return (bool)_objApplication.GetType().InvokeMember("AlwaysUseClearType", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AlwaysUseClearType", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回 Microsoft Excel 的 AnswerWizard 对象。只读。
        /// </summary>
        public AnswerWizard AnswerWizard
        {
            get { return new AnswerWizard(_objApplication.GetType().InvokeMember("AnswerWizard", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application1
        {
            get { return new Application(_objApplication.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Boolean 类型的值，该值表示 Microsoft Excel 中的 XML 功能是否可用。只读。
        /// </summary>
        public bool ArbitraryXMLSupportAvailable
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ArbitraryXMLSupportAvailable", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果 Microsoft Excel 打开带有链接的文件时询问用户是否更新链接，则该值为 True。如果 Microsoft Excel 自动更新链接并且不显示对话框，则该值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool AskToUpdateLinks
        {
            get { return (bool)_objApplication.GetType().InvokeMember("AskToUpdateLinks", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AskToUpdateLinks", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回 Excel 2007 的一个代表 Microsoft Office 帮助查看器的 IAssistance 对象。只读。
        /// </summary>
        public IAssistance Assistance
        {
            get { return new IAssistance(_objApplication.GetType().InvokeMember("Assistance", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回 Microsoft Excel 的 Assistant 对象。
        /// </summary>
        public Assistant Assistant
        {
            get { return new Assistant(_objApplication.GetType().InvokeMember("Assistant", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回 AutoCorrect 对象，该对象表示 Microsoft Excel 自动更正属性。只读。
        /// </summary>
        public AutoCorrect AutoCorrect
        {
            get { return new AutoCorrect(_objApplication.GetType().InvokeMember("AutoCorrect", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果 Microsoft Excel 按照键入的内容自动设置超链接的格式，则该值为 True（默认）。如果 Excel 不按照键入的内容自动设置超链接的格式，则该值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool AutoFormatAsYouTypeReplaceHyperlinks
        {
            get { return (bool)_objApplication.GetType().InvokeMember("AutoFormatAsYouTypeReplaceHyperlinks", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AutoFormatAsYouTypeReplaceHyperlinks", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 MsoAutomationSecurity 常量，该常量表示在用编程方式打开文件时，Microsoft Excel 所使用的安全模式。可读写。
        /// </summary>
        public MsoAutomationSecurity AutomationSecurity
        {
            get { return (MsoAutomationSecurity)_objApplication.GetType().InvokeMember("AutomationSecurity", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AutomationSecurity", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果在向格式设置为百分比的单元格中输入数据时，并不自动将该数据乘以 100，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool AutoPercentEntry
        {
            get { return (bool)_objApplication.GetType().InvokeMember("AutoPercentEntry", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("AutoPercentEntry", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 AutoRecover 对象，该对象在规定的时间间隔内对所有的文件格式进行备份。
        /// </summary>
        public AutoRecover AutoRecover
        {
            get { return new AutoRecover(_objApplication.GetType().InvokeMember("AutoRecover", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回 Microsoft Excel 内部版本号。Long 类型，只读。
        /// </summary>
        public int Build
        {
            get { return (int)_objApplication.GetType().InvokeMember("Build", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果在将工作簿保存到磁盘之前计算工作簿（如果 Calculation 属性设置为 xlManual），则该属性值为 True。如果更改 Calculation 属性则保留该属性。Boolean 类型，可读写。
        /// </summary>
        public bool CalculateBeforeSave
        {
            get { return (bool)_objApplication.GetType().InvokeMember("CalculateBeforeSave", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CalculateBeforeSave", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlCalculation 值，它代表计算模式。
        /// </summary>
        public XlCalculation Calculation
        {
            get { return (XlCalculation)_objApplication.GetType().InvokeMember("Calculation", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Calculation", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置或返回一个 XlCalculationInterruptKey 常量，该常量指定在执行计算时可中断 Microsoft Excel 的键。可读写。
        /// </summary>
        public XlCalculationInterruptKey CalculationInterruptKey
        {
            get { return (XlCalculationInterruptKey)_objApplication.GetType().InvokeMember("CalculationInterruptKey", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CalculationInterruptKey", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 XlCalculationState 常量，该常量针对 Microsoft Excel 中正在执行的任意计算指示应用程序的计算状态。只读。
        /// </summary>
        public XlCalculationState CalculationState
        {
            get { return (XlCalculationState)_objApplication.GetType().InvokeMember("CalculationState", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回一个数字，其最右侧两位表示计算引擎的次要版本号，而左侧的其他位表示 Microsoft Office Spreadsheet 组件的主要版本号。Long 型，只读。
        /// </summary>
        public int CalculationVersion
        {
            get { return (int)_objApplication.GetType().InvokeMember("CalculationVersion", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回关于调用 Visual Basic 的信息（有关详细信息，请参阅“注解”部分）。
        /// </summary>
        public dynamic Caller
        {
            get { return _objApplication.GetType().InvokeMember("Caller", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        public bool CanPlaySounds
        {
            get { return (bool)_objApplication.GetType().InvokeMember("CanPlaySounds", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CanPlaySounds", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        public bool CanRecordSounds
        {
            get { return (bool)_objApplication.GetType().InvokeMember("CanRecordSounds", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CanRecordSounds", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 String 值，它代表出现在 Microsoft Excel 主窗口标题栏中显示的名称。
        /// </summary>
        public string Caption
        {
            get { return _objApplication.GetType().InvokeMember("Caption", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("Caption", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果启用单元格拖放功能，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool CellDragAndDrop
        {
            get { return (bool)_objApplication.GetType().InvokeMember("CellDragAndDrop", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CellDragAndDrop", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表活动工作表中的所有列。如果活动文档不是工作表，则此属性无效。
        /// </summary>
        public Range Cells
        {
            get { return new Range(_objApplication.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个代表活动工作簿中所有工作表的 Sheets 集合。
        /// </summary>
        public Sheets Charts
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("Charts", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Range 对象，它代表活动工作表中的所有列。如果活动文档不是工作表，则 Columns 属性失效。
        /// </summary>
        public Range Columns
        {
            get { return new Range(_objApplication.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回 Microsoft Excel 的 COMAddIns 集合，该集合表示当前所安装的 COM 加载宏。只读。
        /// </summary>
        public COMAddIns COMAddIns
        {
            get { return new COMAddIns(_objApplication.GetType().InvokeMember("COMAddIns", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 CommandBars 对象，它代表 Microsoft Excel 命令栏。只读。
        /// 说明
        /// 在与 Application 对象一起使用时，此属性返回对该应用程序有效的内置及自定义命令栏。
        /// 当一个工作簿嵌入在另一个应用程序中并且用户通过双击它将其激活时，此属性与 Workbook 对象一起使用会返回可在其他应用程序中使用的 Microsoft Excel 命令栏集。在所有其他情况下，此属性与 Workbook 对象一起使用会返回 Nothing。
        /// 没有编程的方法可用来返回附属于工作簿的命令栏集。
        /// </summary>
        public CommandBars CommandBars
        {
            get { return new CommandBars(_objApplication.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回或设置 Microsoft Excel for the Macintosh 中命令加下划线的状态。可以是 XlCommandUnderlines 常量之一。Long 类型，可读写。
        /// 说明
        /// 在 Microsoft Excel for Windows 中，该属性总是返回 xlCommandUnderlinesOn，该属性只能设置为 xlCommandUnderlinesOn，不允许设置为其他任何值。
        /// </summary>
        public XlCommandUnderlines CommandUnderlines
        {
            get { return (XlCommandUnderlines)_objApplication.GetType().InvokeMember("CommandUnderlines", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CommandUnderlines", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果手写识别只能识别数字和标点符号，则该属性值为 True。Boolean 类型，可读写。
        /// 说明
        /// 该属性仅在使用 Microsoft Windows for Pen Computing 时可用。如果试图在其他操作系统中对该属性进行设置将产生错误。
        /// </summary>
        public bool ConstrainNumeric
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ConstrainNumeric", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ConstrainNumeric", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 显示从右到左语言的控制字符，则该属性值为 True。Boolean 类型，可读写。
        /// 说明
        /// 只有在安装和选择了从右到左语言支持时，才可以设置该属性。
        /// </summary>
        public bool ControlCharacters
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ControlCharacters", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ControlCharacters", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果对象与单元格一同剪切、复制、提取和排序，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool CopyObjectsWithCells
        {
            get { return (bool)_objApplication.GetType().InvokeMember("CopyObjectsWithCells", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CopyObjectsWithCells", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// 说明
        /// 如果该对象是在 Microsoft Excel 中创建的，则此属性返回字符串 XCEL，它等同于十六进制的数字 5843454C。Creator 属性是为 Macintosh 上的 Microsoft Excel 设计的，在 Macintosh 上，每个应用程序都具有一个四字符的创建者代码。例如，Microsoft Excel 的创建者代码为 XCEL。 
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objApplication.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置 Microsoft Excel 中鼠标指针的外观。XlMousePointer 类型，可读写。
        /// 说明
        /// 当宏停止运行时，Cursor 属性不会自动重设。在宏停止运行前，应将指针重设为 xlDefault。
        /// </summary>
        public XlMousePointer Cursor
        {
            get { return (XlMousePointer)_objApplication.GetType().InvokeMember("Cursor", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Cursor", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个值，此值用于表明使用的是可见光标还是逻辑光标。可为以下常量之一：xlVisualCursor 或 xlLogicalCursor。Long 类型，可读写。
        /// </summary>
        public int CursorMovement
        {
            get { return (int)_objApplication.GetType().InvokeMember("CursorMovement", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CursorMovement", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回已定义的自定义序列的数目（包括内置序列）。Long 类型，只读。
        /// </summary>
        public int CustomListCount
        {
            get { return (int)_objApplication.GetType().InvokeMember("CustomListCount", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置剪切或复制模式的状态。可为 True、False 或如下表所示的一个 XLCutCopyMode 常量。Long 类型，可读写。
        /// </summary>
        public XlCutCopyMode CutCopyMode
        {
            get { return (XlCutCopyMode)_objApplication.GetType().InvokeMember("CutCopyMode", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("CutCopyMode", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置“数据输入”模式，如下表所示。处于“数据输入”模式时，仅可在当前选定区域的未锁定单元格中输入数据。Long 类型，可读写。
        /// </summary>
        public int DataEntryMode
        {
            get { return (int)_objApplication.GetType().InvokeMember("DataEntryMode", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DataEntryMode", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回带应用程序说明符的 DDE 返回代码，该代码包含在 Microsoft Excel 接收到的最后一个 DDE 确认消息中。Long 类型，只读。
        /// </summary>
        public int DDEAppReturnCode
        {
            get { return (int)_objApplication.GetType().InvokeMember("DDEAppReturnCode", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>设置或返回用作小数分隔符的字符。String 类型，可读写。
        /// </summary>
        public string DecimalSeparator
        {
            get { return _objApplication.GetType().InvokeMember("DecimalSeparator", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("DecimalSeparator", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置 Microsoft Excel 打开文件时使用的默认路径。String 类型，可读写。
        /// </summary>
        public string DefaultFilePath
        {
            get { return _objApplication.GetType().InvokeMember("DefaultFilePath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("DefaultFilePath", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置保存文件的默认格式。要获取有效常量的列表，请参阅 FileFormat 属性。Long 类型，可读写。
        /// </summary>
        public XlFileFormat DefaultSaveFormat
        {
            get { return (XlFileFormat)_objApplication.GetType().InvokeMember("DefaultSaveFormat", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DefaultSaveFormat", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置 Microsoft Excel 显示新窗口和工作表时的默认方向。可为以下常量之一：xlRTL（从右到左）或 xlLTR（从左到右）。Long 类型，可读写。
        /// </summary>
        public int DefaultSheetDirection
        {
            get { return (int)_objApplication.GetType().InvokeMember("DefaultSheetDirection", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DefaultSheetDirection", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回 DefaultWebOptions 对象，该对象包含应用程序级的全局属性，当以网页保存文档或打开网页时，Microsoft Excel 会使用这些属性。只读。
        /// </summary>
        public DefaultWebOptions DefaultWebOptions
        {
            get { return new DefaultWebOptions(_objApplication.GetType().InvokeMember("DefaultWebOptions", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>
        /// </summary>
        public bool DeferAsyncQueries
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DeferAsyncQueries", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DeferAsyncQueries", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Dialogs 集合，该集合表示所有内置对话框的。只读。
        /// </summary>
        public Dialogs Dialogs
        {
            get { return new Dialogs(_objApplication.GetType().InvokeMember("Dialogs", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>
        /// </summary>
        public Sheets DialogSheets
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("DialogSheets", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果宏运行时 Microsoft Excel 显示特定的警告和消息，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayAlerts
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayAlerts", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果能显示 Microsoft Office 剪贴板，则返回 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayClipboardWindow
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayClipboardWindow", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayClipboardWindow", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置单元格显示批注和标识符的方式。可以是 XlCommentDisplayMode 常量之一。
        /// </summary>
        public XlCommentDisplayMode DisplayCommentIndicator
        {
            get { return (XlCommentDisplayMode)_objApplication.GetType().InvokeMember("DisplayCommentIndicator", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayCommentIndicator", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置为 True 可显示“文档操作”任务窗格；设置为 False 可隐藏“文档操作”任务窗格。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayDocumentActionTaskPane
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayDocumentActionTaskPane", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayDocumentActionTaskPane", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，该值表示是否显示文档属性面板。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayDocumentInformationPanel
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayDocumentInformationPanel", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayDocumentInformationPanel", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 显示 4.0 版的菜单栏，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayExcel4Menus
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayExcel4Menus", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayExcel4Menus", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>获取或设置一个值，该值表示在生成单元格公式时是否显示相关函数和已定义名称的列表。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayFormulaAutoComplete
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayFormulaAutoComplete", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayFormulaAutoComplete", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果显示编辑栏，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayFormulaBar
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayFormulaBar", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayFormulaBar", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 处于全屏显示模式，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayFullScreen
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayFullScreen", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayFullScreen", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果可以显示函数的“工具提示”，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayFunctionToolTips
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayFunctionToolTips", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayFunctionToolTips", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool DisplayInfoWindow
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayInfoWindow", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayInfoWindow", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果应显示“插入选项”按钮，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayInsertOptions
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayInsertOptions", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayInsertOptions", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果包含注释的单元格显示单元格提示并包含注释标识符（单元格右上角的小圆点），则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayNoteIndicator
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayNoteIndicator", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayNoteIndicator", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果可以显示“粘贴选项”按钮，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayPasteOptions
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayPasteOptions", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayPasteOptions", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果最近使用的文件列表显示在用户界面中，则该属性值为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayRecentFiles
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayRecentFiles", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayRecentFiles", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果滚动条在所有工作簿中显示，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayScrollBars
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayScrollBars", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayScrollBars", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果显示状态栏，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayStatusBar
        {
            get { return (bool)_objApplication.GetType().InvokeMember("DisplayStatusBar", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("DisplayStatusBar", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 允许在单元格中直接进行编辑，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EditDirectlyInCell
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EditDirectlyInCell", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EditDirectlyInCell", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果动态插入和删除功能有效，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableAnimations
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableAnimations", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableAnimations", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果启用记忆式键入功能，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableAutoComplete
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableAutoComplete", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableAutoComplete", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>控制 Microsoft Excel 如何处理 Ctrl+Break（或 Esc、Command+Period）用户中断以用于运行过程。XlEnableCancelKey 类型，可读写。
        /// </summary>
        public XlEnableCancelKey EnableCancelKey
        {
            get { return (XlEnableCancelKey)_objApplication.GetType().InvokeMember("EnableCancelKey", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableCancelKey", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果对指定对象启用事件，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableEvents
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableEvents", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableEvents", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置或返回一个 Boolean 值，该值表示当用户尝试执行的操作所影响的单元格数目比 Office 中心 UI 中指定的数目大时，是否显示警告消息。可读/写 Boolean 类型。
        /// </summary>
        public bool EnableLargeOperationAlert
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableLargeOperationAlert", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableLargeOperationAlert", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置或返回一个 Boolean 值，该值表示是显示还是隐藏在使用支持预览的库时所出现的库预览。如果将此属性设置为 True，则会在应用命令之前显示工作簿预览。可读/写 Boolean 类型。
        /// </summary>
        public bool EnableLivePreview
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableLivePreview", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableLivePreview", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果对 Microsoft Office 启用声音，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableSound
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableSound", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableSound", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool EnableTipWizard
        {
            get { return (bool)_objApplication.GetType().InvokeMember("EnableTipWizard", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("EnableTipWizard", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 ErrorCheckingOptions 对象，该对象表示应用程序的错误检查选项。
        /// </summary>
        public ErrorCheckingOptions ErrorCheckingOptions
        {
            get { return new ErrorCheckingOptions(_objApplication.GetType().InvokeMember("ErrorCheckingOptions", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有的 Microsoft Excel 4.0 国际宏表。只读。
        /// </summary>
        public Sheets Excel4IntlMacroSheets
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("Excel4IntlMacroSheets", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有的 Microsoft Excel 4.0 宏表。只读。
        /// </summary>
        public Sheets Excel4MacroSheets
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("Excel4MacroSheets", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果 Microsoft Excel 自动将格式和公式扩展到清单中新增的数据上，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ExtendList
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ExtendList", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ExtendList", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个值（常量），该值指定 Microsoft Excel 如何处理对所需功能尚未安装的方法和属性的调用。可为下表列出的 MsoFeatureInstall 常量之一。 类型，可读写。
        /// </summary>
        public MsoFeatureInstall FeatureInstall
        {
            get { return (MsoFeatureInstall)_objApplication.GetType().InvokeMember("FeatureInstall", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("FeatureInstall", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置或返回要查找的单元格格式类型的搜索条件。
        /// </summary>
        public CellFormat FindFormat
        {
            get { return new CellFormat(_objApplication.GetType().InvokeMember("FindFormat", BindingFlags.GetProperty, null, _objApplication, null)); }
            set { _objApplication.GetType().InvokeMember("FindFormat", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果该属性被设置为 True，则以后输入的所有数据都根据 FixedDecimalPlaces 属性所设置的固定小数位数设置格式。Boolean 类型，可读写。
        /// </summary>
        public bool FixedDecimal
        {
            get { return (bool)_objApplication.GetType().InvokeMember("FixedDecimal", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("FixedDecimal", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置当 FixedDecimal 属性设置为 True 时使用的固定小数位数。Long 类型，可读写。
        /// </summary>
        public int FixedDecimalPlaces
        {
            get { return (int)_objApplication.GetType().InvokeMember("FixedDecimalPlaces", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("FixedDecimalPlaces", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>允许用户指定行中编辑栏的高度。可读/写 Long 类型。
        /// </summary>
        public int FormulaBarHeight
        {
            get { return (int)_objApplication.GetType().InvokeMember("FormulaBarHeight", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("FormulaBarHeight", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>当 Microsoft Excel 能够获取数据透视表数据时，返回 True。Boolean 类型，可读写。
        /// </summary>
        public bool GenerateGetPivotData
        {
            get { return (bool)_objApplication.GetType().InvokeMember("GenerateGetPivotData", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("GenerateGetPivotData", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>GenerateTableRefs 属性确定是使用传统的记号方法还是使用新的结构化引用记号方法在公式中引用表格。可读/写。
        /// </summary>
        public XlGenerateTableRefs GenerateTableRefs
        {
            get { return (XlGenerateTableRefs)_objApplication.GetType().InvokeMember("GenerateTableRefs", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("GenerateTableRefs", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Double 值，它代表主应用程序窗口的高度（以磅为单位）。
        /// </summary>
        public double Height
        {
            get { return (double)_objApplication.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Height", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool HighQualityModeForGraphics
        {
            get { return (bool)_objApplication.GetType().InvokeMember("HighQualityModeForGraphics", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("HighQualityModeForGraphics", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回正调用 Microsoft Excel 的实例的实例句柄。Long 类型，只读。
        /// </summary>
        public int Hinstance
        {
            get { return (int)_objApplication.GetType().InvokeMember("Hinstance", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回一个 Long 类型的值，该值表示 Microsoft Excel 窗口的最高级别的窗口句柄。只读。
        /// </summary>
        public int Hwnd
        {
            get { return (int)_objApplication.GetType().InvokeMember("Hwnd", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果远程 DDE 请求被忽略，则该值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool IgnoreRemoteRequests
        {
            get { return (bool)_objApplication.GetType().InvokeMember("IgnoreRemoteRequests", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("IgnoreRemoteRequests", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 处于交互模式，则该属性值为 True；该属性值通常为 True。如果设置该属性为 False，则 Microsoft Excel 将禁止所有的键盘输入和鼠标输入（由代码显示的对话框的输入除外）。Boolean 类型，可读写。
        /// </summary>
        public bool Interactive
        {
            get { return (bool)_objApplication.GetType().InvokeMember("Interactive", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Interactive", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 使用迭代来处理循环引用，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Iteration
        {
            get { return (bool)_objApplication.GetType().InvokeMember("Iteration", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Iteration", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 LanguageSettings 对象，该对象包含 Microsoft Excel 中有关语言设置的信息。只读。
        /// </summary>
        public LanguageSettings LanguageSettings
        {
            get { return new LanguageSettings(_objApplication.GetType().InvokeMember("LanguageSettings", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>
        /// </summary>
        public bool LargeButtons
        {
            get { return (bool)_objApplication.GetType().InvokeMember("LargeButtons", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("LargeButtons", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置操作中所需的单元格的最大数目，如果超过此数目，将触发警告。可读/写 Long 类型。
        /// </summary>
        public int LargeOperationCellThousandCount
        {
            get { return (int)_objApplication.GetType().InvokeMember("LargeOperationCellThousandCount", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("LargeOperationCellThousandCount", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Double 值，它代表从屏幕左边缘到 Microsoft Excel 主窗口左边缘的距离（以磅为单位）。
        /// </summary>
        public double Left
        {
            get { return (double)_objApplication.GetType().InvokeMember("Left", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Left", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回 Library 文件夹的路径，不带末尾分隔符。String 类型，只读。
        /// </summary>
        public string LibraryPath
        {
            get { return _objApplication.GetType().InvokeMember("LibraryPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回安装在主机上的邮件系统。XlMailSystem 类型，只读。
        /// </summary>
        public XlMailSystem MailSystem
        {
            get { return (XlMailSystem)_objApplication.GetType().InvokeMember("MailSystem", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果自动调整以其他国家/地区的标准纸张大小（例如，A4）来设置格式的文档，以便以用户所在的国家/地区的标准纸张大小（例如，信件）来正确地打印文档，则该值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool MapPaperSize
        {
            get { return (bool)_objApplication.GetType().InvokeMember("MapPaperSize", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MapPaperSize", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果数学协处理器可用，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool MathCoprocessorAvailable
        {
            get { return (bool)_objApplication.GetType().InvokeMember("MathCoprocessorAvailable", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置 Microsoft Excel 处理循环引用时迭代之间的最大变化值。Double 类型，可读写。
        /// </summary>
        public double MaxChange
        {
            get { return (double)_objApplication.GetType().InvokeMember("MaxChange", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MaxChange", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置 Microsoft Excel 处理循环引用的最大迭代次数。Long 类型，可读写。
        /// </summary>
        public int MaxIterations
        {
            get { return (int)_objApplication.GetType().InvokeMember("MaxIterations", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MaxIterations", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>指定应用程序中使用的度量单位。可读/写 xlMeasurementUnit 类型。
        /// </summary>
        public int MeasurementUnit
        {
            get { return (int)_objApplication.GetType().InvokeMember("MeasurementUnit", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MeasurementUnit", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public int MemoryFree
        {
            get { return (int)_objApplication.GetType().InvokeMember("MemoryFree", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>
        /// </summary>
        public int MemoryTotal
        {
            get { return (int)_objApplication.GetType().InvokeMember("MemoryTotal", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>
        /// </summary>
        public int MemoryUsed
        {
            get { return (int)_objApplication.GetType().InvokeMember("MemoryUsed", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果鼠标可用，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool MouseAvailable
        {
            get { return (bool)_objApplication.GetType().InvokeMember("MouseAvailable", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>如果按 Enter (Return) 键后活动单元格的位置改变，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool MoveAfterReturn
        {
            get { return (bool)_objApplication.GetType().InvokeMember("MoveAfterReturn", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MoveAfterReturn", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置当用户按 Enter 时，活动单元格的移动方向。XlDirection 类型，可读写。
        /// </summary>
        public XlDirection MoveAfterReturnDirection
        {
            get { return (XlDirection)_objApplication.GetType().InvokeMember("MoveAfterReturnDirection", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("MoveAfterReturnDirection", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public MultiThreadedCalculation MultiThreadedCalculation
        {
            get { return new MultiThreadedCalculation(_objApplication.GetType().InvokeMember("MultiThreadedCalculation", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objApplication.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回一个代表活动工作簿中所有名称的 Names 集合。Names 对象，只读。
        /// </summary>
        public Names Names
        {
            get { return new Names(_objApplication.GetType().InvokeMember("Names", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回保存模板的网络路径。网络路径不存在时，该属性返回一个空的字符串。String 类型，只读。
        /// </summary>
        public string NetworkTemplatesPath
        {
            get { return _objApplication.GetType().InvokeMember("NetworkTemplatesPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回一个 NewFile 对象。
        /// </summary>
        public NewFile NewWorkbook
        {
            get { return new NewFile(_objApplication.GetType().InvokeMember("NewWorkbook", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 ODBCErrors 集合，该集合包含由最近的查询表或数据透视表操作生成的所有 ODBC 错误。只读。
        /// </summary>
        public ODBCErrors ODBCErrors
        {
            get { return new ODBCErrors(_objApplication.GetType().InvokeMember("ODBCErrors", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>以秒为单位返回或设置 ODBC 查询的时间限制。默认值为 45 秒。Long 类型，可读写。
        /// </summary>
        public int ODBCTimeout
        {
            get { return (int)_objApplication.GetType().InvokeMember("ODBCTimeout", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ODBCTimeout", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 OLEDBErrors 集合，该集合表示最近一次 OLE DB 查询返回的错误信息。只读。
        /// </summary>
        public OLEDBErrors OLEDBErrors
        {
            get { return new OLEDBErrors(_objApplication.GetType().InvokeMember("OLEDBErrors", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>
        /// </summary>
        public string OnCalculate
        {
            get { return _objApplication.GetType().InvokeMember("OnCalculate", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnCalculate", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnData
        {
            get { return _objApplication.GetType().InvokeMember("OnData", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnData", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnDoubleClick
        {
            get { return _objApplication.GetType().InvokeMember("OnDoubleClick", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnDoubleClick", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnEntry
        {
            get { return _objApplication.GetType().InvokeMember("OnEntry", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnEntry", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetActivate
        {
            get { return _objApplication.GetType().InvokeMember("OnSheetActivate", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnSheetActivate", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetDeactivate
        {
            get { return _objApplication.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置每当激活一个窗口时要运行的过程的名称。String 型，可读写。
        /// </summary>
        public string OnWindow
        {
            get { return _objApplication.GetType().InvokeMember("OnWindow", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("OnWindow", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回当前操作系统的名称和版本号。例如，“Windows (32-bit) 4.00”或“Macintosh 7.00”。String 类型，只读。
        /// </summary>
        public string OperatingSystem
        {
            get { return _objApplication.GetType().InvokeMember("OperatingSystem", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回注册组织名称。String 类型，只读。
        /// </summary>
        public string OrganizationName
        {
            get { return _objApplication.GetType().InvokeMember("OrganizationName", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public Application Parent
        {
            get { return new Application(_objApplication.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 String 值，它代表应用程序的完整路径，不包括末尾的分隔符和应用程序名称。
        /// </summary>
        public string Path
        {
            get { return _objApplication.GetType().InvokeMember("Path", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回路径分隔符 (“\”)。String 类型，只读。
        /// </summary>
        public string PathSeparator
        {
            get { return _objApplication.GetType().InvokeMember("PathSeparator", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>如果数据透视表使用结构化选择，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool PivotTableSelection
        {
            get { return (bool)_objApplication.GetType().InvokeMember("PivotTableSelection", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("PivotTableSelection", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回 Microsoft Excel 的全球唯一标识符 (GUID)。String 类型，只读。
        /// </summary>
        public string ProductCode
        {
            get { return _objApplication.GetType().InvokeMember("ProductCode", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>如果在保存文件时 Microsoft Excel 要求用户输入汇总信息，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool PromptForSummaryInfo
        {
            get { return (bool)_objApplication.GetType().InvokeMember("PromptForSummaryInfo", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("PromptForSummaryInfo", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>当 Microsoft Excel 应用程序就绪时，返回 True，当 Microsoft Excel 未就绪时，返回 False。Boolean 类型，只读。
        /// </summary>
        public bool Ready
        {
            get { return (bool)_objApplication.GetType().InvokeMember("Ready", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回一个 RecentFiles 集合，该集合表示最近使用的文件的列表。
        /// </summary>
        public RecentFiles RecentFiles
        {
            get { return new RecentFiles(_objApplication.GetType().InvokeMember("RecentFiles", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果以相对引用录制宏，则该属性值为 True；如果以绝对引用录制宏，则该属性值为 False。Boolean 类型，只读。
        /// </summary>
        public bool RecordRelative
        {
            get { return (bool)_objApplication.GetType().InvokeMember("RecordRelative", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置 Microsoft Excel 是以 A1 引用样式还是以 R1C1 引用样式显示单元格引用和行、列标题。XlReferenceStyle 类型，可读写。
        /// </summary>
        public XlReferenceStyle ReferenceStyle
        {
            get { return (XlReferenceStyle)_objApplication.GetType().InvokeMember("ReferenceStyle", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ReferenceStyle", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>设置替换条件以用于替换单元格格式。该替换条件将在后续调用中被用于 Range 对象的 Replace 方法。
        /// </summary>
        public CellFormat ReplaceFormat
        {
            get { return new CellFormat(_objApplication.GetType().InvokeMember("ReplaceFormat", BindingFlags.GetProperty, null, _objApplication, null)); }
            set { _objApplication.GetType().InvokeMember("ReplaceFormat", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果使用智能鼠标进行缩放而不是滚动，则该属性值为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool RollZoom
        {
            get { return (bool)_objApplication.GetType().InvokeMember("RollZoom", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("RollZoom", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表活动工作表中的所有行。如果活动文档不是工作表，则 Rows 属性失效。Range 对象，只读。
        /// </summary>
        public Range Rows
        {
            get { return new Range(_objApplication.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 RTD 对象。
        /// </summary>
        public RTD RTD
        {
            get { return new RTD(_objApplication.GetType().InvokeMember("RTD", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果启用屏幕更新，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ScreenUpdating
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ScreenUpdating", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ScreenUpdating", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>为 Application 对象返回在活动窗口中选定的对象。
        /// </summary>
        public dynamic Selection
        {
            get { return _objApplication.GetType().InvokeMember("Selection", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回一个 Sheets 集合，它代表活动工作簿中所有的工作表。Sheets 对象，只读。
        /// </summary>
        public Sheets Sheets
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回或设置 Microsoft Excel 自动插入到新工作簿中的工作表数目。可读/写 Long 类型。
        /// </summary>
        public int SheetsInNewWorkbook
        {
            get { return (int)_objApplication.GetType().InvokeMember("SheetsInNewWorkbook", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("SheetsInNewWorkbook", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果图表显示图表提示名称，则该值为 True。默认值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ShowChartTipNames
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowChartTipNames", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowChartTipNames", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果图表显示图表提示值，则该值为 True。默认值是 True。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowChartTipValues
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowChartTipValues", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowChartTipValues", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，该值表示是否在功能区中显示“开发人员”选项卡。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowDevTools
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowDevTools", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowDevTools", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，该值表示当用户在工作簿窗口中右键单击时是否显示浮动工具栏。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowMenuFloaties
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowMenuFloaties", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowMenuFloaties", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，该值表示当用户选择文本时是否显示浮动工具栏。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowSelectionFloaties
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowSelectionFloaties", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowSelectionFloaties", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果显示 Microsoft Excel 应用程序的“新建工作簿”任务窗格，则返回 True（默认）。Boolean 类型，可读写。
        /// </summary>
        public bool ShowStartupDialog
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowStartupDialog", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowStartupDialog", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果打开工具提示，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ShowToolTips
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowToolTips", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowToolTips", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果每个打开的工作簿都有一个单独的 Windows 任务栏按钮，则该值为 True。默认值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ShowWindowsInTaskbar
        {
            get { return (bool)_objApplication.GetType().InvokeMember("ShowWindowsInTaskbar", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("ShowWindowsInTaskbar", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回应用程序的一个 SmartTagRecognizers 集合。
        /// </summary>
        public SmartTagRecognizers SmartTagRecognizers
        {
            get { return new SmartTagRecognizers(_objApplication.GetType().InvokeMember("SmartTagRecognizers", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Speech 对象。
        /// </summary>
        public Speech Speech
        {
            get { return new Speech(_objApplication.GetType().InvokeMember("Speech", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 SpellingOptions 对象，该对象表示应用程序的拼写检查选项。
        /// </summary>
        public SpellingOptions SpellingOptions
        {
            get { return new SpellingOptions(_objApplication.GetType().InvokeMember("SpellingOptions", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回或设置标准字体的名称。String 类型，可读写。
        /// </summary>
        public string StandardFont
        {
            get { return _objApplication.GetType().InvokeMember("StandardFont", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("StandardFont", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置标准字体大小。Long 类型，可读写。
        /// </summary>
        public double StandardFontSize
        {
            get { return (double)_objApplication.GetType().InvokeMember("StandardFontSize", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("StandardFontSize", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回启动文件夹的完整路径，不包括尾部分隔符。String 类型，只读。
        /// </summary>
        public string StartupPath
        {
            get { return _objApplication.GetType().InvokeMember("StartupPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回或设置状态栏中的文字。String 类型，可读写。
        /// </summary>
        public dynamic StatusBar
        {
            get { return _objApplication.GetType().InvokeMember("StatusBar", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("StatusBar", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回模板所存储的本地路径。String 类型，只读。
        /// </summary>
        public string TemplatesPath
        {
            get { return _objApplication.GetType().InvokeMember("TemplatesPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回一个单元格，用户定义的函数将作为 Range 对象从这里调用。
        /// </summary>
        public Range ThisCell
        {
            get { return new Range(_objApplication.GetType().InvokeMember("ThisCell", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回一个 Workbook 对象，该对象表示其中正在运行当前宏代码的工作簿。只读。
        /// </summary>
        public Workbook ThisWorkbook
        {
            get { return new Workbook(_objApplication.GetType().InvokeMember("ThisWorkbook", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>设置或返回用于千位分隔符的字符。String 类型，可读写。
        /// </summary>
        public string ThousandsSeparator
        {
            get { return _objApplication.GetType().InvokeMember("ThousandsSeparator", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("ThousandsSeparator", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Double 值，它代表从屏幕上边缘到 Microsoft Excel 主窗口上边缘的距离（以磅为单位）。
        /// </summary>
        public double Top
        {
            get { return (double)_objApplication.GetType().InvokeMember("Top", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Top", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置 Microsoft Excel 菜单或帮助键，通常为“/”。String 类型，可读写。
        /// </summary>
        public string TransitionMenuKey
        {
            get { return _objApplication.GetType().InvokeMember("TransitionMenuKey", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("TransitionMenuKey", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回或设置按下 Microsoft Excel 菜单键后将执行的操作。可为 xlExcelMenus 或 xlLotusHelp。Long 类型，可读写。
        /// </summary>
        public int TransitionMenuKeyAction
        {
            get { return (int)_objApplication.GetType().InvokeMember("TransitionMenuKeyAction", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("TransitionMenuKeyAction", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Lotus 1-2-3 常用键是活动的，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool TransitionNavigKeys
        {
            get { return (bool)_objApplication.GetType().InvokeMember("TransitionNavigKeys", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("TransitionNavigKeys", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public int UILanguage
        {
            get { return (int)_objApplication.GetType().InvokeMember("UILanguage", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("UILanguage", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回在应用程序窗口区域中一个窗口能占有的最大高度（以磅为单位）。Double 型，只读。
        /// </summary>
        public double UsableHeight
        {
            get { return (double)_objApplication.GetType().InvokeMember("UsableHeight", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回在应用程序窗口区域中一个窗口能占有的最大宽度（以磅为单位）。Double 型，只读。
        /// </summary>
        public double UsableWidth
        {
            get { return (double)_objApplication.GetType().InvokeMember("UsableWidth", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回一个 UsedObjects 对象，该对象表示在工作簿中分配的对象。只读
        /// </summary>
        public UsedObjects UsedObjects
        {
            get { return new UsedObjects(_objApplication.GetType().InvokeMember("UsedObjects", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果应用程序可见，或者用户已创建或启动应用程序，则该值为 True。如果以编程方式通过 CreateObject 函数或 GetObject 函数启动应用程序，且应用程序为隐藏状态，则该值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool UserControl
        {
            get { return (bool)_objApplication.GetType().InvokeMember("UserControl", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回用户计算机上 COM 加载宏安装位置的路径。String 类型，只读。
        /// </summary>
        public string UserLibraryPath
        {
            get { return _objApplication.GetType().InvokeMember("UserLibraryPath", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回或设置当前用户的名称。String 类型，可读写。
        /// </summary>
        public string UserName
        {
            get { return _objApplication.GetType().InvokeMember("UserName", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
            set { _objApplication.GetType().InvokeMember("UserName", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 的系统分隔符已启用，则该属性的值为 True（默认值）。Boolean 类型，可读写。
        /// </summary>
        public bool UseSystemSeparators
        {
            get { return (bool)_objApplication.GetType().InvokeMember("UseSystemSeparators", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("UseSystemSeparators", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个代表应用程序名称的 String 值。
        /// </summary>
        public string Value
        {
            get { return _objApplication.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回一个 String 值，它代表 Microsoft Excel 版本号。
        /// </summary>
        public string Version
        {
            get { return _objApplication.GetType().InvokeMember("Version", BindingFlags.GetProperty, null, _objApplication, null).ToString(); }
        }

        /// <summary>返回或设置一个 Boolean 值，它确定对象是否可见。可读写。
        /// </summary>
        public bool Visible
        {
            get { return (bool)_objApplication.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>在将 WarnOnFunctionNameConflict 属性设置为 True 时，如果开发人员尝试使用现有函数名称创建一个新函数，则会发出警告。可读/写 Boolean 类型。
        /// </summary>
        public bool WarnOnFunctionNameConflict
        {
            get { return (bool)_objApplication.GetType().InvokeMember("WarnOnFunctionNameConflict", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("WarnOnFunctionNameConflict", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Watches 对象，该对象表示在重新计算工作表时跟踪的区域。
        /// </summary>
        public Watches Watches
        {
            get { return new Watches(_objApplication.GetType().InvokeMember("Watches", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回或设置一个 Double 值，它代表从应用程序窗口左边缘到其右边缘的距离（以磅为单位）。
        /// </summary>
        public double Width
        {
            get { return (double)_objApplication.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("Width", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Windows 集合，它代表所有工作簿中的所有窗口。Windows 对象，只读。
        /// </summary>
        public Windows Windows
        {
            get { return new Windows(_objApplication.GetType().InvokeMember("Windows", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>如果此计算机正在运行的是 Microsoft Windows for Pen Computing，则该属性的值为 True。Boolean 类型，只读。
        /// </summary>
        public bool WindowsForPens
        {
            get { return (bool)_objApplication.GetType().InvokeMember("WindowsForPens", BindingFlags.GetProperty, null, _objApplication, null); }
        }

        /// <summary>返回或设置窗口的状态。XlWindowState 类型，可读写。
        /// </summary>
        public XlWindowState WindowState
        {
            get { return (XlWindowState)_objApplication.GetType().InvokeMember("WindowState", BindingFlags.GetProperty, null, _objApplication, null); }
            set { _objApplication.GetType().InvokeMember("WindowState", BindingFlags.SetProperty, null, _objApplication, new object[1] { value }); }
        }

        /// <summary>返回一个 Workbooks 集合，该集合表示所有打开的工作簿。只读。
        /// </summary>
        public Workbooks Workbooks
        {
            get { return new Workbooks(_objApplication.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>返回 WorksheetFunction 对象。只读。
        /// </summary>
        public WorksheetFunction WorksheetFunction
        {
            get { return new WorksheetFunction(_objApplication.GetType().InvokeMember("WorksheetFunction", BindingFlags.GetProperty, null, _objApplication, null)); }
        }

        /// <summary>对于 Application 对象，返回一个 Sheets 集合，它代表活动工作簿中的所有工作表。对于 Workbook 对象，返回一个 Sheets 集合，它代表指定工作簿中的所有工作表。Sheets 对象，只读。
        /// </summary>
        public Sheets Worksheets
        {
            get { return new Sheets(_objApplication.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, _objApplication, null)); }
        }
        #endregion

        #region 方法
        /// <summary>激活一个 Microsoft 应用程序。如果该应用程序已经处于运行状态，则本方法激活的是正在运行的应用程序。如果该应用程序不处于运行状态，则本方法将启动该应用程序的新实例。
        /// </summary>
        /// <param name="Index">指定要激活的 Microsoft 应用程序。</param>
        public void ActivateMicrosoftApp(XlMSApplication Index)
        {
            _objaParameters = new object[1] { Index };
            _objApplication.GetType().InvokeMember("ActivateMicrosoftApp", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>为自定义自动填充和/或自定义排序添加自定义列表。
        /// </summary>
        /// <param name="ListArray">将源数据指定为字符串数组或 Range 对象。</param>
        /// <param name="ByRow">仅当 ListArray 为 Range 对象时使用。如果为 True，则使用区域中的每一行创建自定义列表；如果为 False，则使用区域中的每一列创建自定义列表。如果省略该参数，并且区域中的行数比列数多（或者行数与列数相等），则 Microsoft Excel 使用区域中的每一列创建自定义列表。如果省略该参数，并且区域中的列数比行数多，则 Microsoft Excel 使用区域中的每一行创建自定义列表。</param>
        public void AddCustomList(object ListArray, bool? ByRow = null)
        {
            _objaParameters = new object[2] { 
                ListArray,
                ByRow == null ? System.Type.Missing : ByRow
            };
            _objApplication.GetType().InvokeMember("ActivateMicrosoftApp", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>计算所有打开的工作簿、工作簿中的某张特定工作表或工作表指定区域中的单元格，如下表所示。
        /// </summary>
        public void Calculate()
        {
            _objApplication.GetType().InvokeMember("Calculate", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>强制对所有打开工作簿中的数据进行完整计算。
        /// </summary>
        public void CalculateFull()
        {
            _objApplication.GetType().InvokeMember("CalculateFull", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>对于所有打开的工作簿，强制数据的完整计算并重建从属关系。
        /// 说明：
        /// 从属关系是取决于其他单元格的公式。例如，公式“=A1”取决于单元格 A1。CalculateFullRebuild 方法类似于重新输入所有公式。
        /// </summary>
        public void CalculateFullRebuild()
        {
            _objApplication.GetType().InvokeMember("CalculateFullRebuild", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>运行对 OLEDB 和 OLAP 数据源的所有待定查询。
        /// </summary>
        public void CalculateUntilAsyncQueriesDone()
        {
            _objApplication.GetType().InvokeMember("CalculateUntilAsyncQueriesDone", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>将计量单位从厘米转换为磅（一磅等于 0.035 厘米）。
        /// </summary>
        /// <param name="Centimeters">指定要转换为磅的厘米值。</param>
        /// <returns></returns>
        public double CentimetersToPoints(double Centimeters)
        {
            _objaParameters = new object[1] { Centimeters };

            return (double)_objApplication.GetType().InvokeMember("CentimetersToPoints", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>停止 Microsoft Excel 应用程序中的重新计算。
        /// </summary>
        /// <param name="KeepAbort">允许对区域执行重新计算。</param>
        public void CheckAbort(Range KeepAbort = null)
        {
            _objaParameters = new object[1] { KeepAbort == null ? System.Type.Missing : KeepAbort._objRange };

            _objApplication.GetType().InvokeMember("CheckAbort", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>对单个单词进行拼写检查。
        /// </summary>
        /// <param name="Word">（仅应用于 Application 对象）要检查的单词。</param>
        /// <param name="CustomDictionary">一个字符串，它表示自定义词典的文件名，如果在主词典中找不到单词，则会到此词典中查找。如果省略此参数，则使用当前指定的词典。</param>
        /// <param name="IgnoreUppercase">如果为 True，则 Microsoft Excel 忽略所有字母都是大写的单词。如果为 False，则 Microsoft Excel 检查所有字母都是大写的单词。如果省略此参数，将使用当前的设置。</param>
        /// <returns>如果在任一词典中找到单词，则为 True；否则为 False。</returns>
        public bool CheckSpelling(string Word, string CustomDictionary = null, bool? IgnoreUppercase = null)
        {
            _objaParameters = new object[3] { 
                Word,
                CustomDictionary == null ? System.Type.Missing : CustomDictionary,
                IgnoreUppercase == null ? System.Type.Missing : IgnoreUppercase
            };
            return (bool)_objApplication.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>在 A1 和 R1C1 引用样式之间转换、在相对和绝对引用之间转换公式中的单元格引用，或者同时进行这两种转换。Variant 类型。
        /// </summary>
        /// <param name="Formula">包含要转换的公式的字符串。必须为有效的公式，并且必须以等号开头。</param>
        /// <param name="FromReferenceStyle">公式的引用样式。</param>
        /// <param name="ToReferenceStyle">指定要返回的引用样式的 XlReferenceStyle 常量。如果省略此参数，则引用样式不变；公式样式保持 FromReferenceStyle 参数指定的样式。</param>
        /// <param name="ToAbsolute">指定转换引用类型的 XlReferenceStyle 常量。如果省略该参数，则引用类型不变。</param>
        /// <param name="RelativeTo">包含一个单元格的 Range 对象。相对引用与此单元格相对。</param>
        /// <returns></returns>
        public dynamic ConvertFormula(string Formula, XlReferenceStyle FromReferenceStyle, XlReferenceStyle? ToReferenceStyle = null, XlReferenceStyle? ToAbsolute = null, Range RelativeTo = null)
        {
            _objaParameters = new object[5] { 
                Formula ,
                FromReferenceStyle ,
                ToReferenceStyle == null ? System.Type.Missing : ToReferenceStyle,
                ToAbsolute == null ? System.Type.Missing : ToAbsolute,
                RelativeTo == null ? System.Type.Missing : RelativeTo._objRange
            };
            return _objApplication.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>通过指定的 DDE 通道在另一个应用程序中运行一条命令或执行其他操作。
        /// </summary>
        /// <param name="Channel">DDEInitiate 方法返回的通道号。</param>
        /// <param name="String">接收应用程序中定义的消息。</param>
        public void DDEExecute(int Channel, string String)
        {
            _objaParameters = new object[2] {
                Channel,
                String
            };

            _objApplication.GetType().InvokeMember("DDEExecute", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>打开到一个应用程序的 DDE 通道。
        /// </summary>
        /// <param name="App">应用程序名称。</param>
        /// <param name="Topic">描述通道所指向的应用程序的有关信息，通常为该应用程序的一个文档。</param>
        public int DDEInitiate(string App, string Topic)
        {
            _objaParameters = new object[2] {
                App,
                Topic
            };

            return (int)_objApplication.GetType().InvokeMember("DDEInitiate", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>向应用程序发送数据。
        /// 说明：
        /// 如果本方法调用失效将产生错误。
        /// </summary>
        /// <param name="Channel">DDEInitiate 方法返回的通道号。</param>
        /// <param name="Item">数据被发送到的项。</param>
        /// <param name="Data">发送到应用程序的数据。</param>
        public void DDEPoke(int Channel, object Item, object Data)
        {
            _objaParameters = new object[3] {
                Channel,
                Item,
                Data
            };

            _objApplication.GetType().InvokeMember("DDEPoke", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>请求指定应用程序中的信息。该方法始终返回数组。
        /// </summary>
        /// <param name="Channel">DDEInitiate 方法返回的通道号。</param>
        /// <param name="Item">要请求的项。</param>
        public dynamic DDERequest(int Channel, string Item)
        {
            _objaParameters = new object[2] {
                Channel,
                Item
            };

            return _objApplication.GetType().InvokeMember("DDERequest", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>关闭到另一个应用程序的通道。
        /// </summary>
        /// <param name="Channel">DDEInitiate 方法返回的通道号。</param>
        public void DDETerminate(int Channel)
        {
            _objaParameters = new object[1] {
                Channel
            };

            _objApplication.GetType().InvokeMember("DDETerminate", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void DeleteChartAutoFormat(string Name)
        {
            _objaParameters = new object[1] {
                Name
            };

            _objApplication.GetType().InvokeMember("DeleteChartAutoFormat", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>删除一个自定义序列。
        /// </summary>
        /// <param name="ListNum">自定义序列数字。此数字必须大于或等于 5（Microsoft Excel 有四个不可删除的内置自定义序列）。</param>
        public void DeleteCustomList(int ListNum)
        {
            _objaParameters = new object[1] {
                ListNum
            };

            _objApplication.GetType().InvokeMember("DeleteCustomList", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>打开“XML 源”任务窗格，并显示 XmlMap 参数指定的 XML 映射。
        /// </summary>
        public void DisplayXMLSourcePane(XmlMap XmlMap = null)
        {
            _objaParameters = new object[1] {
                XmlMap == null ? System.Type.Missing : XmlMap._objXmlMap
            };

            _objApplication.GetType().InvokeMember("DisplayXMLSourcePane", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>等价于双击活动单元格。
        /// </summary>
        public void DoubleClick()
        {
            _objApplication.GetType().InvokeMember("DoubleClick", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>将一个 Microsoft Excel 名称转换为一个对象或者一个值。
        ///  说明：
        /// 该方法可使用下列 Microsoft Excel 名称类型：
        /// A1 格式引用。可以通过 A1 格式表示法引用单个单元格。所有引用均视为绝对引用。
        /// 区域。在引用中可以使用区域、交集和联合运算符（分别为冒号、空格和逗号）。
        /// 定义的名称。可用宏语言指定任何名称。
        /// 外部引用。可以使用 ! 运算符引用另一工作簿中的单元格或已定义的名称，例如，Evaluate("[BOOK1.XLS]Sheet1!A1")。
        /// 图表对象。可以指定任何图表对象名称（如“Legend”、“Plot Area”或“Series 1”），以访问该对象的属性和方法。例如，Charts("Chart1").Evaluate("Legend").Font.Name 返回图例中所用字体的名称。
        /// </summary>
        /// <param name="Name">使用 Microsoft Excel 命名约定的对象名称。</param>
        public dynamic Evaluate(string Name)
        {
            _objaParameters = new object[1] {
                Name
            };

            return _objApplication.GetType().InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>执行一个 Microsoft Excel 4.0 宏函数，然后返回此函数的结果。返回结果的类型取决于函数的类型。
        /// </summary>
        /// <param name="String">一个不带等号的 Microsoft Excel 4.0 宏语言函数。所有引用必须是像 R1C1 这样的字符串。如果 String 内包含嵌套的双引号，则必须写两个。例如，要运行宏函数 =MID("sometext",1,4)，String 必须为 “MID(""sometext"",1,4)”。</param>
        public dynamic ExecuteExcel4Macro(string String)
        {
            _objaParameters = new object[1] {
                String
            };

            return _objApplication.GetType().InvokeMember("ExecuteExcel4Macro", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>显示“打开”对话框。
        /// </summary>
        public bool FindFile()
        {
            return (bool)_objApplication.GetType().InvokeMember("FindFile", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>返回一个自定义序列（一个字符串数组）。
        /// </summary>
        /// <param name="ListNum">列表数字。</param>
        public string[] GetCustomListContents(int ListNum)
        {
            _objaParameters = new object[1] { ListNum };

            return (string[])_objApplication.GetType().InvokeMember("GetCustomListContents", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>返回字符串数组的自定义序列号。使用本方法既可对内置序列进行匹配，也可对自定义序列进行匹配。
        /// </summary>
        /// <param name="ListArray">字符串数组。</param>
        public int GetCustomListNum(string[] ListArray)
        {
            _objaParameters = new object[1] {
                ListArray
            };

            return (int)_objApplication.GetType().InvokeMember("GetCustomListNum", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>显示标准的“打开”对话框，并获取用户文件名，而不必真正打开任何文件。
        /// 说明：
        /// 在 FileFilter 参数中传递的该字符串由文件筛选字符串对以及后跟的 MS-DOS 通配符文件筛选规范组成，中间以逗号分隔。每个字符串都在“文件类型”下拉列表框中列出。例如，下列字符串指定两个文件筛选 - 文本和加载宏：“文本文件 (*.txt)、*.txt、加载宏文件 (*.xla)、*.xla”。
        /// 要为单个文件筛选类型使用多个 MS-DOS 通配符表达式，需用分号将通配符表达式分开。例如：“Visual Basic 文件 (*.bas; *.txt)、*.bas; *.txt”。
        /// 如果省略 FileFilter，则此参数默认为“所有文件 (*.*),*.*”。
        /// 本方法返回选定的文件名或用户输入的名称。返回的名称可能包含路径说明。如果 MultiSelect 为 True，则返回值将是一个包含所有选定文件名的数组（即使仅选定了一个文件名）。如果用户取消了对话框，则该值为 False。
        /// 本方法可能更改当前驱动器或文件夹。
        /// </summary>
        /// <param name="FileFilter">一个指定文件筛选条件的字符串。</param>
        /// <param name="FilterIndex">指定默认文件筛选条件的索引号，取值范围为 1 到由 FileFilter 所指定的筛选条件数目。如果省略该参数，或者该参数的值大于可用筛选条件数，则使用第一个文件筛选条件。</param>
        /// <param name="Title">指定对话框的标题。如果省略该参数，则标题为“打开”。</param>
        /// <param name="ButtonText">仅限 Macintosh。</param>
        /// <param name="MultiSelect">如果为 True，则允许选择多个文件名。如果为 False，则只允许选择一个文件名。默认值为 False。</param>
        public dynamic GetOpenFilename(string FileFilter = null, int? FilterIndex = null, string Title = null, object ButtonText = null, bool? MultiSelect = null)
        {
            _objaParameters = new object[5] {
                FileFilter == null ? System.Type.Missing : FileFilter,
                FilterIndex == null ? System.Type.Missing : FilterIndex,
                Title == null ? System.Type.Missing : Title,
                ButtonText == null ? System.Type.Missing : ButtonText,
                MultiSelect == null ? System.Type.Missing : MultiSelect
            };

            return _objApplication.GetType().InvokeMember("GetOpenFilename", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>返回指定文本串的日语拼音文本。本方法只有在选择或安装了 Microsoft Office 的日语语言支持时才有效。
        /// </summary>
        /// <param name="Text">指定要转化为拼音文本的文本。如果忽略此参数，则返回以前指定的 Text 的下一个可能的拼音文本（如果存在）。如果没有其他可能的拼音文本串，则返回一个空字符串。</param>
        public string GetPhonetic(string Text = null)
        {
            _objaParameters = new object[1] {
                Text == null ? System.Type.Missing : Text
            };

            return _objApplication.GetType().InvokeMember("GetPhonetic", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters).ToString();
        }

        /// <summary>显示标准的“另存为”对话框，获取用户文件名，而无须真正保存任何文件。
        /// 说明：
        /// 在 FileFilter 参数中传递的该字符串由文件筛选字符串对以及后跟的 MS-DOS 通配符文件筛选规范组成，中间以逗号分隔。每个字符串都在“文件类型”下拉列表框中列出。例如，下列字符串指定两个文件筛选 - 文本和加载宏：“文本文件 (*.txt)、*.txt、加载宏文件 (*.xla)、*.xla”。
        /// 要为单个文件筛选类型使用多个 MS-DOS 通配符表达式，需用分号将通配符表达式分开。例如：“Visual Basic 文件 (*.bas; *.txt)、*.bas; *.txt”。
        /// 本方法返回选定的文件名或用户输入的名称。返回的名称可能包含路径说明。如果用户取消了对话框，则该值为 False。
        /// 本方法可能更改当前驱动器或文件夹。
        /// </summary>
        /// <param name="InitialFilename">指定建议的文件名。如果省略该参数，Microsoft Excel 使用活动工作簿的名称。</param>
        /// <param name="FileFilter">一个指定文件筛选条件的字符串。</param>
        /// <param name="FilterIndex">指定默认文件筛选条件的索引号，范围为 1 到 FileFilter 指定的筛选条件数。如果省略该参数，或者该参数的值大于可用筛选条件数，则使用第一个文件筛选条件。</param>
        /// <param name="Title">指定对话框的标题。如果省略该参数，则使用默认标题。</param>
        /// <param name="ButtonText">仅限 Macintosh。</param>
        public dynamic GetSaveAsFilename(string InitialFilename = null, string FileFilter = null, int? FilterIndex = null, string Title = null, object ButtonText = null)
        {
            _objaParameters = new object[5] {
                InitialFilename == null ? System.Type.Missing : InitialFilename,
                FileFilter == null ? System.Type.Missing : FileFilter,
                FilterIndex == null ? System.Type.Missing : FilterIndex,
                Title == null ? System.Type.Missing : Title,
                ButtonText == null ? System.Type.Missing : ButtonText
            };

            return _objApplication.GetType().InvokeMember("GetSaveAsFilename", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>选定任意工作簿中的任意区域或任意 Visual Basic 过程，并且如果该工作簿未处于活动状态，就激活该工作簿。
        /// 说明：
        /// 该方法与 Select 方法的区别：
        /// 如果指定的区域不在位于最前面屏幕的工作表中，Microsoft Excel 将在选定该区域之前切换至该工作表。（如果对不在屏幕的最前面的工作表中的区域使用 Select 方法，则选定该区域时并不激活该工作表）。 
        /// 该方法具有让用户滚动目标窗口的 Scroll 参数。 
        /// 当使用 Goto 方法时，前一次选定区域（Goto 方法运行前）被增加到以前选定区域的数组中（有关详细信息，请参阅 PreviousSelections 属性）。可以使用该功能快速跳过选定区域，选定区域最多为四个。 
        /// Select 方法具有 Replace 参数，而 Goto 方法没有该参数。 
        /// </summary>
        /// <param name="Reference">目标。可以是 Range 对象、包含 R1C1-样式批注的单元格引用的字符串或包含 Visual Basic 过程名的字符串。如果省略该参数，目标将为最近一次用 Goto 方法选定的区域。</param>
        /// <param name="Scroll">如果为 True，则滚动窗口直至区域的左上角出现在窗口的左上角中。如果为 False，则不滚动窗口。默认值为 False。</param>
        public void Goto(Range Reference = null, bool? Scroll = null)
        {
            _objaParameters = new object[2] {
                Reference == null ? System.Type.Missing : Reference,
                Scroll == null ? System.Type.Missing : Scroll
            };

            _objApplication.GetType().InvokeMember("Goto", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>显示一个帮助主题。
        /// </summary>
        /// <param name="HelpFile">要显示的联机帮助文件名。如果不指定该参数，则使用“Microsoft Excel 帮助”。</param>
        /// <param name="HelpContextID">指定帮助主题上下文 ID 号。如果不指定该参数，将显示“帮助主题”对话框。</param>
        public void Help(string HelpFile = null, string HelpContextID = null)
        {
            _objaParameters = new object[2] {
                HelpFile == null ? System.Type.Missing : HelpFile,
                HelpContextID == null ? System.Type.Missing : HelpContextID
            };

            _objApplication.GetType().InvokeMember("Help", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>将度量单位从英寸转换为磅。
        /// </summary>
        public double InchesToPoints(double Inches)
        {
            _objaParameters = new object[1] { Inches };
            return (double)_objApplication.GetType().InvokeMember("InchesToPoints", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }
        /// <summary>将度量单位从英寸转换为磅。（先除以了2.54）
        /// </summary>
        /// <param name="Inches">指定要转换为磅值的英寸值。</param>
        /// <returns></returns>
        public double InchesToPoints2(double Inches)
        {
            return InchesToPoints(Inches / 2.54);
        }

        /// <summary>显示一个接收用户输入的对话框。返回此对话框中输入的信息。
        /// 什么：
        /// 下表列出了可以在 Type 参数中传递的值。可以为下列值之一或其中几个值的和。例如，对于一个可接受文本和数字的输入框，将 Type 设置为 1 + 2。
        /// </summary>
        /// <param name="Prompt">要在对话框中显示的消息。可为字符串、数字、日期、或布尔值（在显示之前，Microsoft Excel 自动将其值强制转换为 String）。</param>
        /// <param name="Title">输入框的标题。如果省略该参数，默认标题将为“Input”。</param>
        /// <param name="Default">指定一个初始值，该值在对话框最初显示时出现在文本框中。如果省略该参数，文本框将为空。该值可以是 Range 对象。</param>
        /// <param name="Left">指定对话框相对于屏幕左上角的 X 坐标（以磅 （磅：指打印的字符的高度的度量单位。1 磅等于 1/72 英寸，或大约等于 1 厘米的 1/28。）为单位）。</param>
        /// <param name="Top">指定对话框相对于屏幕左上角的 Y 坐标（以磅为单位）。</param>
        /// <param name="HelpFile">此输入框使用的帮助文件名。如果存在 HelpFile 和 HelpContextID 参数，对话框中将出现一个帮助按钮。</param>
        /// <param name="HelpContextID">HelpFile 中帮助主题的上下文 ID 号。</param>
        /// <param name="Type">指定返回的数据类型。如果省略该参数，对话框将返回文本。</param>
        public dynamic InputBox(string Prompt, string Title = null, object Default = null, int? Left = null, int? Top = null, string HelpFile = null, string HelpContextID = null, object Type = null)
        {
            _objaParameters = new object[8] {
                Prompt,
                Title == null ? System.Type.Missing : Title,
                Default == null ? System.Type.Missing : Default,
                Left == null ? System.Type.Missing : Left,
                Top == null ? System.Type.Missing : Top,
                HelpFile == null ? System.Type.Missing : HelpFile,
                HelpContextID == null ? System.Type.Missing : HelpContextID,
                Type == null ? System.Type.Missing : Type
            };

            return _objApplication.GetType().InvokeMember("InputBox", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>返回一个 Range 对象，该对象表示两个或多个区域重叠的矩形区域。
        /// </summary>
        /// <param name="Arg1">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg2">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg3">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg4">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg5">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg6">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg7">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg8">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg9">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg10">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg11">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg12">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg13">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg14">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg15">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg16">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg17">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg18">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg19">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg20">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg21">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg22">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg23">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg24">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg25">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg26">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg27">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg28">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg29">重叠的区域。必须指定至少两个 Range 对象。</param>
        /// <param name="Arg30">重叠的区域。必须指定至少两个 Range 对象。</param>
        public Range Intersect(Range Arg1, Range Arg2, object Arg3 = null, object Arg4 = null, object Arg5 = null, object Arg6 = null, object Arg7 = null, object Arg8 = null, object Arg9 = null, object Arg10 = null, object Arg11 = null, object Arg12 = null, object Arg13 = null, object Arg14 = null, object Arg15 = null, object Arg16 = null, object Arg17 = null, object Arg18 = null, object Arg19 = null, object Arg20 = null, object Arg21 = null, object Arg22 = null, object Arg23 = null, object Arg24 = null, object Arg25 = null, object Arg26 = null, object Arg27 = null, object Arg28 = null, object Arg29 = null, object Arg30 = null)
        {
            _objaParameters = new object[30] {
                Arg1,
                Arg2,
                Arg3 == null ? System.Type.Missing : Arg3,
                Arg4 == null ? System.Type.Missing : Arg4,
                Arg5 == null ? System.Type.Missing : Arg5,
                Arg6 == null ? System.Type.Missing : Arg6,
                Arg7 == null ? System.Type.Missing : Arg7,
                Arg8 == null ? System.Type.Missing : Arg8,
                Arg9 == null ? System.Type.Missing : Arg9,
                Arg10 == null ? System.Type.Missing : Arg10,
                Arg11 == null ? System.Type.Missing : Arg11,
                Arg12 == null ? System.Type.Missing : Arg12,
                Arg13 == null ? System.Type.Missing : Arg13,
                Arg14 == null ? System.Type.Missing : Arg14,
                Arg15 == null ? System.Type.Missing : Arg15,
                Arg16 == null ? System.Type.Missing : Arg16,
                Arg17 == null ? System.Type.Missing : Arg17,
                Arg18 == null ? System.Type.Missing : Arg18,
                Arg19 == null ? System.Type.Missing : Arg19,
                Arg20 == null ? System.Type.Missing : Arg20,
                Arg21 == null ? System.Type.Missing : Arg21,
                Arg22 == null ? System.Type.Missing : Arg22,
                Arg23 == null ? System.Type.Missing : Arg23,
                Arg24 == null ? System.Type.Missing : Arg24,
                Arg25 == null ? System.Type.Missing : Arg25,
                Arg26 == null ? System.Type.Missing : Arg26,
                Arg27 == null ? System.Type.Missing : Arg27,
                Arg28 == null ? System.Type.Missing : Arg28,
                Arg29 == null ? System.Type.Missing : Arg29,
                Arg30 == null ? System.Type.Missing : Arg30
            };

            return new Range(_objApplication.GetType().InvokeMember("Intersect", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters));
        }

        /// <summary>对应于“宏选项”对话框中的选项。还可使用此方法将用户定义函数 (UDF) 显示在“插入函数”对话框的内置类别或新类别中。
        /// </summary>
        /// <param name="Macro">宏的名称或用户定义函数 (UDF) 的名称。</param>
        /// <param name="Description">宏的描述。</param>
        /// <param name="HasMenu">忽略该参数。</param>
        /// <param name="MenuText">忽略该参数。</param>
        /// <param name="HasShortcutKey">如果为 True，则为宏指定一个快捷键（还必须指定 ShortcutKey）。如果该参数为 False，则不为宏指定快捷键。如果宏已经有快捷键，则将该参数设置为 False 可删除快捷键。默认值为 False。</param>
        /// <param name="ShortcutKey">如果 HasShortcutKey 为 True，则该参数为必选参数；否则忽略该参数。快捷键。</param>
        /// <param name="Category">一个指定现有的宏函数类别的整数（例如，财务、日期与时间或用户定义）。请参阅备注部分，以确定映射为内置类别的整数。还可指定自定义类别的字符串。如果提供了一个字符串，它将作为类别名称显示在“插入函数”对话框中。如果此类别名称从未使用过，则将用该名称定义一个新的类别。如果使用的类别名称与某个内置名称相同，则 Excel 会将用户定义的函数映射为此内置类别。</param>
        /// <param name="StatusBar">宏的状态栏文本。</param>
        /// <param name="HelpContextID">一个指定分配给宏的帮助主题上下文 ID 的整数。</param>
        /// <param name="HelpFile">包含 HelpContextId 定义的帮助主题的帮助文件名。</param>
        public void MacroOptions(string Macro = null, string Description = null, object HasMenu = null, object MenuText = null, bool? HasShortcutKey = null, object ShortcutKey = null, object Category = null, string StatusBar = null, int? HelpContextID = null, string HelpFile = null)
        {
            _objaParameters = new object[10] {
                Macro == null ? System.Type.Missing : Macro,
                Description == null ? System.Type.Missing : Description,
                HasMenu == null ? System.Type.Missing : HasMenu,
                MenuText == null ? System.Type.Missing : MenuText,
                HasShortcutKey == null ? System.Type.Missing : HasShortcutKey,
                ShortcutKey == null ? System.Type.Missing : ShortcutKey,
                Category == null ? System.Type.Missing : Category,
                StatusBar == null ? System.Type.Missing : StatusBar,
                HelpContextID == null ? System.Type.Missing : HelpContextID,
                HelpFile == null ? System.Type.Missing : HelpFile
            };

            _objApplication.GetType().InvokeMember("MacroOptions", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>关闭 Microsoft Excel 建立的 MAPI 邮件会话。
        /// </summary>
        public void MailLogoff()
        {
            _objApplication.GetType().InvokeMember("MailLogoff", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>登录进入 MAPI Mail 或 Microsoft Exchange 并建立一个邮件会话。如果 Microsoft Mail 不处于运行状态，必须在使用邮件或文档传送功能之前先使用本方法建立邮件会话。
        /// 说明
        /// Microsoft Excel 在尝试建立新的邮件会话之前将先退出所有已建立的邮件会话。
        /// 要直接返回到系统默认的邮件会话，请省略名称和密码这两个参数。
        /// </summary>
        /// <param name="Name">邮件帐户名或 Microsoft Exchange 配置文件名。如果省略该参数，将使用默认的邮件帐户名。</param>
        /// <param name="Password">邮件帐户密码。在 Microsoft Exchange 中忽略该参数。</param>
        /// <param name="DownloadNewMail">如果为 True，则立即下载新邮件。</param>
        public void MailLogon(string Name = null, string Password = null, bool? DownloadNewMail = null)
        {
            _objaParameters = new object[3] {
                Name == null ? System.Type.Missing : Name,
                Password == null ? System.Type.Missing : Password,
                DownloadNewMail == null ? System.Type.Missing : DownloadNewMail
            };

            _objApplication.GetType().InvokeMember("MailLogon", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        public Workbook NextLetter()
        {
            return new Workbook(_objApplication.GetType().InvokeMember("NextLetter", BindingFlags.InvokeMethod, null, _objApplication, null));
        }

        /// <summary>当按特定键或特定的组合键时运行指定的过程。
        /// </summary>
        /// <param name="Key">表示要按的键的字符串。</param>
        /// <param name="Procedure">表示要运行的过程名称的字符串。如果 Procedure 为空文本 ("")，则按 Key 时不发生任何操作。该格式的 OnKey 将更改键击在 Microsoft Excel 中产生的正常结果。如果省略 Procedure 参数，则 Key 恢复为 Microsoft Excel 中的正常结果，同时清除先前使用 OnKey 方法所做的特殊键击设置。</param>
        public void OnKey(string Key, string Procedure = null)
        {
            _objaParameters = new object[2] {
                Key,
                Procedure == null ? System.Type.Missing : Procedure
            };

            _objApplication.GetType().InvokeMember("OnKey", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>设置“重复”菜单项和过程的名称；如果在运行设置此属性的过程之后选择“编辑”菜单的“重复”命令，将运行此处命名的过程。
        /// </summary>
        /// <param name="Text">与“编辑”菜单的“重复”命令一起显示的文本。</param>
        /// <param name="Procedure">选择“编辑”菜单的“重复”命令时将运行的过程的名称。</param>
        public void OnRepeat(string Text, string Procedure)
        {
            _objaParameters = new object[2] {
                Text,
                Procedure
            };

            _objApplication.GetType().InvokeMember("OnRepeat", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>安排一个过程在将来的特定时间运行（既可以是具体指定的某个时间，也可以是指定的一段时间之后）。
        /// </summary>
        /// <param name="EarliestTime">希望此过程运行的时间。</param>
        /// <param name="Procedure">要运行的过程名。</param>
        /// <param name="LatestTime">过程开始运行的最晚时间。例如，如果 LatestTime 参数设置为 EarliestTime + 30，且当到达 EarliestTime 时间时，由于其他过程处于运行状态而导致 Microsoft Excel 不能处于“就绪”、“复制”、“剪切”或“查找”模式，则 Microsoft Excel 将等待 30 秒让第一个过程先完成。如果 Microsoft Excel 不能在 30 秒内回到“就绪”模式，则不运行此过程。如果省略该参数，Microsoft Excel 将一直等待到可以运行该过程为止。</param>
        /// <param name="Schedule">如果为 True，则预定一个新的 OnTime 过程。如果为 False，则清除先前设置的过程。默认值为 True。</param>
        public void OnTime(float EarliestTime, string Procedure, float? LatestTime = null, bool? Schedule = null)
        {
            _objaParameters = new object[4] {
                EarliestTime,
                Procedure,
                LatestTime == null ? System.Type.Missing : LatestTime,
                Schedule == null ? System.Type.Missing : Schedule
            };

            _objApplication.GetType().InvokeMember("OnTime", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>设置“撤消”的文本和过程的名称；如果在运行设置该属性的过程之后选择“编辑”菜单上的“撤消”命令，将运行此处命名的过程。
        /// </summary>
        /// <param name="Text">与“撤消”命令（“编辑”菜单）一起显示的文本。</param>
        /// <param name="Procedure">选择“编辑”菜单的“撤消”命令时运行的过程的名称。</param>
        public void OnUndo(string Text, string Procedure)
        {
            _objaParameters = new object[2] {
                Text,
                Procedure
            };

            _objApplication.GetType().InvokeMember("OnUndo", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>退出 Microsoft Excel。
        /// </summary>
        public void Quit()
        {
            _objApplication.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>如果宏录制程序正在运行，则记录相应代码。
        /// </summary>
        /// <param name="BasicCode">一个字符串，指定向 Visual Basic 模块录入宏录制程序时将录制的 Visual Basic 代码。该字符串录制在一行中。如果字符串中包含回车（即 ASCII 字符为 10，或代码中含有 Chr$(10)），将分多行录制该字符串。</param>
        /// <param name="XlmCode">忽略该参数。</param>
        public void RecordMacro(string BasicCode = null, object XlmCode = null)
        {
            _objaParameters = new object[2] {
                BasicCode == null ? System.Type.Missing : BasicCode,
                XlmCode == null ? System.Type.Missing : XlmCode
            };

            _objApplication.GetType().InvokeMember("RecordMacro", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>加载 XLL 代码源，并自动注册该代码源中包含的函数和命令。
        /// </summary>
        /// <param name="Filename">指定要加载的 XLL 的名称。</param>
        public bool RegisterXLL(string Filename)
        {
            _objaParameters = new object[1] {
                Filename
            };

            return (bool)_objApplication.GetType().InvokeMember("RegisterXLL", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>重复最后一次用户界面操作。
        /// </summary>
        public void Repeat()
        {

            _objApplication.GetType().InvokeMember("Repeat", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>
        /// </summary>
        public void ResetTipWizard()
        {

            _objApplication.GetType().InvokeMember("ResetTipWizard", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>运行一个宏或者调用一个函数。该方法可用于运行用 Visual Basic 或 Microsoft Excel 宏语言编写的宏，或者运行 DLL 或 XLL 中的函数。
        /// 说明：
        /// 此方法不可使用命名参数，参数必须通过位置进行传递。
        /// </summary>
        /// <param name="Macro">要运行的宏。它可以是具有宏名称的字符串、表示函数所在位置的 Range 对象，或者是一个已注册的 DLL (XLL) 函数的注册号。如果使用字符串，将在当前工作表的上下文中对该字符串求值。</param>
        /// <param name="Arg1">应传递给函数的参数。</param>
        /// <param name="Arg2">应传递给函数的参数。</param>
        /// <param name="Arg3">应传递给函数的参数。</param>
        /// <param name="Arg4">应传递给函数的参数。</param>
        /// <param name="Arg5">应传递给函数的参数。</param>
        /// <param name="Arg6">应传递给函数的参数。</param>
        /// <param name="Arg7">应传递给函数的参数。</param>
        /// <param name="Arg8">应传递给函数的参数。</param>
        /// <param name="Arg9">应传递给函数的参数。</param>
        /// <param name="Arg10">应传递给函数的参数。</param>
        /// <param name="Arg11">应传递给函数的参数。</param>
        /// <param name="Arg12">应传递给函数的参数。</param>
        /// <param name="Arg13">应传递给函数的参数。</param>
        /// <param name="Arg14">应传递给函数的参数。</param>
        /// <param name="Arg15">应传递给函数的参数。</param>
        /// <param name="Arg16">应传递给函数的参数。</param>
        /// <param name="Arg17">应传递给函数的参数。</param>
        /// <param name="Arg18">应传递给函数的参数。</param>
        /// <param name="Arg19">应传递给函数的参数。</param>
        /// <param name="Arg20">应传递给函数的参数。</param>
        /// <param name="Arg21">应传递给函数的参数。</param>
        /// <param name="Arg22">应传递给函数的参数。</param>
        /// <param name="Arg23">应传递给函数的参数。</param>
        /// <param name="Arg24">应传递给函数的参数。</param>
        /// <param name="Arg25">应传递给函数的参数。</param>
        /// <param name="Arg26">应传递给函数的参数。</param>
        /// <param name="Arg27">应传递给函数的参数。</param>
        /// <param name="Arg28">应传递给函数的参数。</param>
        /// <param name="Arg29">应传递给函数的参数。</param>
        /// <param name="Arg30">应传递给函数的参数。</param>
        /// <returns></returns>
        public dynamic Run(object Macro = null, object Arg1 = null, object Arg2 = null, object Arg3 = null, object Arg4 = null, object Arg5 = null, object Arg6 = null, object Arg7 = null, object Arg8 = null, object Arg9 = null, object Arg10 = null, object Arg11 = null, object Arg12 = null, object Arg13 = null, object Arg14 = null, object Arg15 = null, object Arg16 = null, object Arg17 = null, object Arg18 = null, object Arg19 = null, object Arg20 = null, object Arg21 = null, object Arg22 = null, object Arg23 = null, object Arg24 = null, object Arg25 = null, object Arg26 = null, object Arg27 = null, object Arg28 = null, object Arg29 = null, object Arg30 = null)
        {
            _objaParameters = new object[31] {
                Macro == null ? System.Type.Missing : Macro,
                Arg1 == null ? System.Type.Missing : Arg1,
                Arg2 == null ? System.Type.Missing : Arg2,
                Arg3 == null ? System.Type.Missing : Arg3,
                Arg4 == null ? System.Type.Missing : Arg4,
                Arg5 == null ? System.Type.Missing : Arg5,
                Arg6 == null ? System.Type.Missing : Arg6,
                Arg7 == null ? System.Type.Missing : Arg7,
                Arg8 == null ? System.Type.Missing : Arg8,
                Arg9 == null ? System.Type.Missing : Arg9,
                Arg10 == null ? System.Type.Missing : Arg10,
                Arg11 == null ? System.Type.Missing : Arg11,
                Arg12 == null ? System.Type.Missing : Arg12,
                Arg13 == null ? System.Type.Missing : Arg13,
                Arg14 == null ? System.Type.Missing : Arg14,
                Arg15 == null ? System.Type.Missing : Arg15,
                Arg16 == null ? System.Type.Missing : Arg16,
                Arg17 == null ? System.Type.Missing : Arg17,
                Arg18 == null ? System.Type.Missing : Arg18,
                Arg19 == null ? System.Type.Missing : Arg19,
                Arg20 == null ? System.Type.Missing : Arg20,
                Arg21 == null ? System.Type.Missing : Arg21,
                Arg22 == null ? System.Type.Missing : Arg22,
                Arg23 == null ? System.Type.Missing : Arg23,
                Arg24 == null ? System.Type.Missing : Arg24,
                Arg25 == null ? System.Type.Missing : Arg25,
                Arg26 == null ? System.Type.Missing : Arg26,
                Arg27 == null ? System.Type.Missing : Arg27,
                Arg28 == null ? System.Type.Missing : Arg28,
                Arg29 == null ? System.Type.Missing : Arg29,
                Arg30 == null ? System.Type.Missing : Arg30
            };

            return _objApplication.GetType().InvokeMember("Run", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void Save(string Filename = null)
        {
            _objaParameters = new object[1] {
                Filename == null ? System.Type.Missing : Filename
            };

            _objApplication.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>保存当前工作区。
        /// </summary>
        /// <param name="Filename">已保存的文件名。</param>
        public void SaveWorkspace(object Filename = null)
        {
            _objaParameters = new object[1] {
                Filename == null ? System.Type.Missing : Filename
            };

            _objApplication.GetType().InvokeMember("SaveWorkspace", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>将击键发送给活动应用程序。
        /// </summary>
        /// <param name="Keys">要以文本形式发送给应用程序的键或组合键。</param>
        /// <param name="Wait">如果为 True，则 Microsoft Excel 会等到处理完按键后将控件返回给宏；如果为 False（或者省略该参数），则继续运行宏而不等至处理完按键。</param>
        public void SendKeys(string Keys, bool? Wait = null)
        {
            _objaParameters = new object[2] {
                Keys,
                Wait == null ? System.Type.Missing : Wait
            };

            _objApplication.GetType().InvokeMember("SendKeys", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void SetDefaultChart(object FormatName = null, object Gallery = null)
        {
            _objaParameters = new object[2] {
                FormatName == null ? System.Type.Missing : FormatName,
                Gallery == null ? System.Type.Missing : Gallery
            };

            _objApplication.GetType().InvokeMember("SetDefaultChart", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public int SharePointVersion(string bstrUrl)
        {
            _objaParameters = new object[1] {
                bstrUrl
            };

            return (int)_objApplication.GetType().InvokeMember("SharePointVersion", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Support(object Object, int ID, object arg = null)
        {
            _objaParameters = new object[3] {
                Object,
                ID,
                arg == null ? System.Type.Missing : arg
            };

            return _objApplication.GetType().InvokeMember("Support", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>撤消最后一次用户界面操作。
        /// </summary>
        public void Undo()
        {

            _objApplication.GetType().InvokeMember("Undo", BindingFlags.InvokeMethod, null, _objApplication, null);
        }

        /// <summary>返回两个或多个区域的合并区域。必须指定至少两个 Range 对象。
        /// </summary>
        public Range Union(Range Arg1, Range Arg2, Range Arg3 = null, Range Arg4 = null, Range Arg5 = null, Range Arg6 = null, Range Arg7 = null, Range Arg8 = null, Range Arg9 = null, Range Arg10 = null, Range Arg11 = null, Range Arg12 = null, Range Arg13 = null, Range Arg14 = null, Range Arg15 = null, Range Arg16 = null, Range Arg17 = null, Range Arg18 = null, Range Arg19 = null, Range Arg20 = null, Range Arg21 = null, Range Arg22 = null, Range Arg23 = null, Range Arg24 = null, Range Arg25 = null, Range Arg26 = null, Range Arg27 = null, Range Arg28 = null, Range Arg29 = null, Range Arg30 = null)
        {
            _objaParameters = new object[30] {
                Arg1,
                Arg2,
                Arg3 == null ? System.Type.Missing : Arg3,
                Arg4 == null ? System.Type.Missing : Arg4,
                Arg5 == null ? System.Type.Missing : Arg5,
                Arg6 == null ? System.Type.Missing : Arg6,
                Arg7 == null ? System.Type.Missing : Arg7,
                Arg8 == null ? System.Type.Missing : Arg8,
                Arg9 == null ? System.Type.Missing : Arg9,
                Arg10 == null ? System.Type.Missing : Arg10,
                Arg11 == null ? System.Type.Missing : Arg11,
                Arg12 == null ? System.Type.Missing : Arg12,
                Arg13 == null ? System.Type.Missing : Arg13,
                Arg14 == null ? System.Type.Missing : Arg14,
                Arg15 == null ? System.Type.Missing : Arg15,
                Arg16 == null ? System.Type.Missing : Arg16,
                Arg17 == null ? System.Type.Missing : Arg17,
                Arg18 == null ? System.Type.Missing : Arg18,
                Arg19 == null ? System.Type.Missing : Arg19,
                Arg20 == null ? System.Type.Missing : Arg20,
                Arg21 == null ? System.Type.Missing : Arg21,
                Arg22 == null ? System.Type.Missing : Arg22,
                Arg23 == null ? System.Type.Missing : Arg23,
                Arg24 == null ? System.Type.Missing : Arg24,
                Arg25 == null ? System.Type.Missing : Arg25,
                Arg26 == null ? System.Type.Missing : Arg26,
                Arg27 == null ? System.Type.Missing : Arg27,
                Arg28 == null ? System.Type.Missing : Arg28,
                Arg29 == null ? System.Type.Missing : Arg29,
                Arg30 == null ? System.Type.Missing : Arg30
            };

            return new Range(_objApplication.GetType().InvokeMember("Union", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters));
        }

        /// <summary>用于将用户自定义函数标记为易失性函数，无论何时在工作表的任意单元格中进行计算时，易失性函数都必须重新进行计算。非易失性函数只在输入变量改变时才重新计算，若不用于计算工作表单元格的用户自定义函数中，则此方法无效。
        /// </summary>
        /// <param name="Volatile">如果为 True，则将函数标记为易失性函数。如果为 False，则将函数标记为非易失性函数。默认值为 True</param>
        public void Volatile(bool? Volatile = null)
        {
            _objaParameters = new object[1] {
                Volatile == null ? System.Type.Missing : Volatile
            };

            _objApplication.GetType().InvokeMember("Volatile", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>暂停运行宏，直到一特定时间才可继续执行。如果到达指定时间，则该值为 True。
        /// </summary>
        /// <param name="Time">希望宏继续执行的时间（以 Microsoft Excel 日期格式表示）。</param>
        public bool Wait(object Time)
        {
            _objaParameters = new object[1] {
                Time
            };

            return (bool)_objApplication.GetType().InvokeMember("Wait", BindingFlags.InvokeMethod, null, _objApplication, _objaParameters);
        }

        /// <summary>释放所有Excel相关，并终止进程。
        /// </summary>
        public void Release()
        {
            this.Quit();

            GC.Collect();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_objApplication);

            IntPtr ptr = new IntPtr(_hwnd);
            int pid = 0;
            GetWindowThreadProcessId(ptr, out pid);
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(pid);
            proc.Kill();
        }

        #region 属性方法
        /// <summary>以数字数组的形式返回剪贴板中当前的格式。可用数组中每个元素与“备注”部分所述的适当常量相比较，以判断剪贴板中是否包含特定的格式。Variant 类型，只读。
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public int[] ClipboardFormats(int? Index = null)
        {
            return (int[])_objApplication.GetType().InvokeMember("ClipboardFormats", BindingFlags.GetProperty, null, _objApplication, null);
        }
        #endregion 属性方法
        #endregion 方法
    }

    /// <summary>Microsoft Excel 应用程序中当前打开的所有 Workbook 对象的集合。
    /// 说明：
    /// 有关使用一个 Workbook 对象的详细信息，请参阅 Workbook 对象。
    /// </summary>
    public class Workbooks
    {
        public object _objWorkbooks;
        internal object[] _objaParameters;

        public Workbook this[object Index]
        {
            get
            {
                _objaParameters = new object[1] { Index };
                object objWorkbook = _objWorkbooks.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objWorkbooks, _objaParameters);

                if (objWorkbook == null)
                    return null;
                else
                    return new Workbook(objWorkbook);
            }
        }

        public Workbooks(object objWorkbooks)
        { _objWorkbooks = objWorkbooks; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWorkbooks.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWorkbooks, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objWorkbooks.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objWorkbooks, null); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// 说明
        /// 如果该对象是在 Microsoft Excel 中创建的，则此属性返回字符串 XCEL，它等同于十六进制的数字 5843454C。Creator 属性是为 Macintosh 上的 Microsoft Excel 设计的，在 Macintosh 上，每个应用程序都具有一个四字符的创建者代码。例如，Microsoft Excel 的创建者代码为 XCEL。 
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWorkbooks.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWorkbooks, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWorkbooks.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWorkbooks, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>新建一个工作表。新工作表将成为活动工作表。
        /// 返回值：
        /// 一个代表新工作簿的 Workbook 对象。
        /// </summary>
        /// <param name="Template">确定如何创建新工作簿。如果此参数为指定现有 Microsoft Excel 文件名的字符串，那么创建新工作簿将以该指定的文件作为模板。如果此参数为常量，新工作簿将包含一个指定类型的工作表。可为以下 XlWBATemplate 常量之一：xlWBATChart、xlWBATExcel4IntlMacroSheet、xlWBATExcel4MacroSheet 或 xlWBATWorksheet。如果省略此参数，Microsoft Excel 将创建包含一定数目空白工作表的新工作簿（该数目由 SheetsInNewWorkbook 属性设置）。</param>
        /// <returns>一个代表新工作簿的 Workbook 对象。</returns>
        public Workbook Add(XlWBATemplate? Template = null)
        {
            _objaParameters = new object[1] { Template == null ? System.Type.Missing : Template };
            return new Workbook(_objWorkbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objWorkbooks, _objaParameters));
        }

        /// <summary>如果 Microsoft Excel 可以将指定的工作簿从服务器签出，则该值为 True。Boolean 类型，可读写。
        /// </summary>
        /// <param name="Filename">要签出的文件名。</param>
        /// <returns></returns>
        public bool CanCheckOut(string Filename)
        {
            return (bool)_objWorkbooks.GetType().InvokeMember("CanCheckOut", BindingFlags.InvokeMethod, null, _objWorkbooks, new object[1] { Filename });
        }

        /// <summary>返回一个 String 对象，该对象表示一个将从服务器签出到本机进行编辑的指定工作簿。
        /// </summary>
        /// <param name="Filename">要签出的文件名。</param>
        /// <returns></returns>
        public string CheckOut(string Filename)
        {
            return _objWorkbooks.GetType().InvokeMember("CheckOut", BindingFlags.InvokeMethod, null, _objWorkbooks, new object[1] { Filename }).ToString();
        }

        /// <summary>关闭对象。
        /// 说明：
        /// 从 Visual Basic 关闭工作簿并不运行该工作簿中的任何 Auto_Close 宏。使用 RunAutoMacros 方法可运行自动关闭宏。
        /// </summary>
        public void Close()
        {
            _objWorkbooks.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, _objWorkbooks, null);
        }

        /// <summary>打开一个工作簿，返回 Workbook
        /// </summary>
        /// <param name="Filename">要打开的工作簿的文件名</param>
        /// <param name="UpdateLinks">指定文件中链接的更新方式。如果省略本参数，则提示用户选择链接的更新方式。否则，该参数的取值应为下表中的某个值。
        /// 您可在 UpdateLinks 参数中指定下面的一个值，以确定文件的分隔字符：
        /// 0 不更新任何引用。 
        /// 1 更新外部引用，但不更新远程引用。
        /// 2 更新远程引用，但不更新外部引用。 
        /// 3 同时更新远程引用和外部引用。 </param>
        /// <param name="ReadOnly">如果为 True，则以只读模式打开工作簿。</param>
        /// <param name="Format">如果 Microsoft Excel 正在打开文本文件，则由此参数指定分隔符。如果省略此参数，则使用当前的分隔符。有关此参数值的详细信息，请参阅“备注”部分。
        /// 您可在 Format 参数中指定下面的一个值，以确定文件的分隔字符：
        /// 1 标签 
        /// 2 逗号 
        /// 3 空格 
        /// 4 分号 
        /// 5 无 
        /// 6 自定义字符（请参阅 Delimiter 参数）</param>
        /// <param name="Password">一个字符串，包含打开受保护工作簿所需的密码。如果省略此参数并且工作簿已设置密码，则提示用户输入密码。</param>
        /// <param name="WriteResPassword">一个字符串，包含写入受保护工作簿所需的密码。如果省略此参数并且工作簿已设置密码，则提示用户输入密码。</param>
        /// <param name="IgnoreReadOnlyRecommended">如果为 True，则不让 Microsoft Excel 显示只读的建议消息（如果该工作簿以“建议只读”选项保存）。</param>
        /// <param name="Origin">如果该文件为文本文件，则此参数用于指示该文件来源于何种操作系统（以便正确映射代码页和回车/换行符 (CR/LF)）。可为以下 XlPlatform 常量之一：xlMacintosh、xlWindows 或 xlMSDOS。如果省略此参数，则使用当前操作系统。</param>
        /// <param name="Delimiter">如果该文件为文本文件并且 Format 参数为 6，则此参数是一个字符串，指定用作分隔符的字符。例如，可使用 Chr(9) 代表制表符，使用“,”代表逗号，使用“;”代表分号，或者使用自定义字符。只使用字符串的第一个字符。</param>
        /// <param name="Editable">如果文件为 Microsoft Excel 4.0 加载宏，则此参数为 True 时可打开该加载宏以使其在窗口中可见。如果此参数为 False 或被省略，则以隐藏方式打开加载宏，并且无法设为可见。本选项不能应用于由 Microsoft Excel 5.0 或更高版本的 Microsoft Excel 创建的加载宏。如果文件是 Excel 模板，则参数值为 True 时，会打开指定模板进行编辑。参数值为 False 时，可根据指定模板打开新的工作簿。默认值为 False。</param>
        /// <param name="Notify">当文件不能以可读写模式打开时，如果此参数为 True，则可将该文件添加到文件通知列表。Microsoft Excel 将以只读模式打开该文件并轮询文件通知列表，并在文件可用时向用户发出通知。如果此参数为 False 或被省略，则不请求任何通知，并且不能打开任何不可用的文件。</param>
        /// <param name="Converter">打开文件时试用的第一个文件转换器的索引。首先试用的是指定的文件转换器；如果该转换器不能识别此文件，则试用所有其他转换器。转换器索引由 FileConverters 属性返回的转换器行号组成。</param>
        /// <param name="AddToMru">如果为 True，则将该工作簿添加到最近使用的文件列表中。默认值为 False。</param>
        /// <param name="Local">如果为 True，则以 Microsoft Excel（包括控制面板设置）的语言保存文件。如果为 False（默认值），则以 Visual Basic for Applications (VBA) （Visual Basic for Applications (VBA)：Microsoft Visual Basic 的宏语言版本，用于编写基于 Microsoft Windows 的应用程序，内置于多个 Microsoft 程序中。） 的语言保存文件，其中 Visual Basic for Applications (VBA) 通常为美国英语版本，除非从中运行 Workbooks.Open 的 VBA 项目是旧的已国际化的 XL5/95 VBA 项目。</param>
        /// <param name="CorruptLoad">可为以下常量之一：xlNormalLoad、xlRepairFile 和 xlExtractData。如果未指定任何值，则默认行为通常为普通加载，但如果 Excel 已尝试打开该文件，则可以是安全加载或数据恢复状态。首先尝试普通加载。如果 Excel 在打开文件时停止操作，则尝试安全加载状态。如果 Excel 再次停止操作，则尝试数据恢复状态。</param>
        /// <returns></returns>
        public Workbook Open(string Filename, object UpdateLinks = null, bool? ReadOnly = null, object Format = null, string Password = null, string WriteResPassword = null, bool? IgnoreReadOnlyRecommended = null, XlPlatform? Origin = null, char? Delimiter = null, bool? Editable = null, bool? Notify = null, object Converter = null, bool? AddToMru = null, bool? Local = null, XlCorruptLoad? CorruptLoad = null)
        {
            _objaParameters = new object[15] { 
                                                                Filename,
                                                                UpdateLinks == null ? System.Type.Missing:UpdateLinks,
                                                                ReadOnly == null ? System.Type.Missing:ReadOnly,
                                                                Format == null ? System.Type.Missing:Format,
                                                                Password == null ? System.Type.Missing:Password,
                                                                WriteResPassword == null ? System.Type.Missing:WriteResPassword,
                                                                IgnoreReadOnlyRecommended == null ? System.Type.Missing:IgnoreReadOnlyRecommended,
                                                                Origin == null ? System.Type.Missing:Origin,
                                                                Delimiter == null ? System.Type.Missing:Delimiter,
                                                                Editable == null ? System.Type.Missing:Editable,
                                                                Notify == null ? System.Type.Missing:Notify,
                                                                Converter == null ? System.Type.Missing:Converter,
                                                                AddToMru == null ? System.Type.Missing:AddToMru,
                                                                Local == null ? System.Type.Missing:Local,
                                                                CorruptLoad == null ? System.Type.Missing:CorruptLoad
            };

            return new Workbook(_objWorkbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, _objWorkbooks, _objaParameters));
        }

        /// <summary>返回一个 Workbook 对象，该对象代表一个数据库。
        /// </summary>
        /// <param name="Filename">包含数据库位置和文件名的连接字符串。</param>
        /// <param name="CommandText">查询的命令文本。</param>
        /// <param name="CommandType">查询的命令类型。指定 XlCmdType 枚举的常量之一：xlCmdCube、xlCmdList、xlCmdSql、xlCmdTable 和 xlCmdDefault。</param>
        /// <param name="BackgroundQuery">此参数是一个 Variant 数据类型，但您只能传递布尔值。如果传递 True，将在后台（异步）执行查询。默认值为 False。</param>
        /// <param name="ImportDataAs">此参数使用 XlImportDataAs 枚举值之一。此枚举的两个值为 xlPivotTableReport 和 xlQueryTable。传递这两个值之一以便以数据透视表或查询表的形式返回数据。默认值为 xlQueryTable。</param>
        /// <returns></returns>
        public Workbook OpenDatabase(string Filename, string CommandText = null, XlCmdType? CommandType = null, bool? BackgroundQuery = null, XlImportDataAs? ImportDataAs = null)
        {
            _objaParameters = new object[5] { 
                Filename == null ? System.Type.Missing : Filename,
                CommandText == null ? System.Type.Missing : CommandText,
                CommandType == null ? System.Type.Missing : CommandType,
                BackgroundQuery == null ? System.Type.Missing : BackgroundQuery,
                ImportDataAs == null ? System.Type.Missing : ImportDataAs
            };
            return new Workbook(_objWorkbooks.GetType().InvokeMember("OpenDatabase", BindingFlags.InvokeMethod, null, _objWorkbooks, _objaParameters));
        }

        /// <summary>载入一个文本文件，并将其作为包含单个工作表的新工作簿进行分列处理，然后在此工作表中放入经过分列处理的文本文件数据。
        /// 说明：
        /// FieldInfo 参数信息
        /// 只有在安装并选定了中国台湾地区语言支持时才可使用 xlEMDFormat。xlEMDFormat 常量指定使用中国台湾地区纪元日期。
        /// 列说明符可为任意顺序。输入数据中如果某列没有列说明符，则用常规设置对该列进行分列处理。
        /// </summary>
        /// <param name="Filename">指定要打开和分列的文本文件的名称。</param>
        /// <param name="Origin">指定文本文件来源。可为以下 XlPlatform 常量之一：xlMacintosh、xlWindows 或 xlMSDOS。此外，它还可以是一个整数，表示所需代码页的代码页编号。例如，“1256”指定源文本文件的编码是阿拉伯语 (Windows)。如果省略该参数，则此方法将使用“文本导入向导”中“文件原始格式”选项的当前设置。</param>
        /// <param name="StartRow">文本分列处理的起始行号。默认值为 1。</param>
        /// <param name="DataType">指定文件中数据的列格式。可为以下 XlTextParsingType 常量之一：xlDelimited 或 xlFixedWidth。如果未指定该参数，则 Microsoft Excel 将尝试在打开文件时确定列格式。</param>
        /// <param name="TextQualifier">指定文本识别符号。</param>
        /// <param name="ConsecutiveDelimiter">如果为 True，则将连续分隔符视为一个分隔符。默认值为 False。</param>
        /// <param name="Tab">如果为 True，则将制表符用作分隔符（DataType 必须为 xlDelimited）。默认值为 False。</param>
        /// <param name="Semicolon">如果为 True，则将分号用作分隔符（DataType 必须为 xlDelimited）。默认值为 False。</param>
        /// <param name="Comma">如果为 True，则将逗号用作分隔符（DataType 必须为 xlDelimited）。默认值为 False。</param>
        /// <param name="Space">如果为 True，则将空格用作分隔符（DataType 必须为 xlDelimited）。默认值为 False。</param>
        /// <param name="Other">如果为 True，则将 OtherChar 参数指定的字符用作分隔符（DataType 必须为 xlDelimited）。默认值为 False。</param>
        /// <param name="OtherChar">（如果 Other 为 True，则为必选项）。当 Other 为 True 时，指定分隔符。如果指定了多个字符，则仅使用字符串中的第一个字符而忽略剩余字符。</param>
        /// <param name="FieldInfo">包含单列数据相关分列信息的数组。对该参数的解释取决于 DataType 的值。如果此数据由分隔符分隔，则该参数为由两元素数组组成的数组，其中每个两元素数组指定一个特定列的转换选项。第一个元素为列标（从 1 开始），第二个元素是 XlColumnDataType 的常量之一，用于指定分列方式。</param>
        /// <param name="TextVisualLayout">文本的可视布局。</param>
        /// <param name="DecimalSeparator">识别数字时，Microsoft Excel 使用的小数分隔符。默认设置为系统设置。</param>
        /// <param name="ThousandsSeparator">识别数字时，Excel 使用的千位分隔符。默认设置为系统设置。</param>
        /// <param name="TrailingMinusNumbers">如果应将结尾为减号字符的数字视为负数处理，则指定为 True。如果为 False 或省略该参数，则将结尾为减号字符的数字视为文本处理。</param>
        /// <param name="Local">如果分隔符、数字和数据格式应使用计算机的区域设置，则指定为 True。</param>
        /// <returns></returns>
        public Workbook OpenText(string Filename, XlPlatform? Origin = null, int? StartRow = null, XlTextParsingType? DataType = null, XlTextQualifier? TextQualifier = null, bool? ConsecutiveDelimiter = null, bool? Tab = null, bool? Semicolon = null, bool? Comma = null, bool? Space = null, bool? Other = null, string OtherChar = null, int?[] FieldInfo = null, string TextVisualLayout = null, char? DecimalSeparator = null, char? ThousandsSeparator = null, bool? TrailingMinusNumbers = null, bool? Local = null)
        {
            _objaParameters = new object[18] { 
                Filename == null ? System.Type.Missing : Filename,
                Origin == null ? System.Type.Missing : Origin,
                StartRow == null ? System.Type.Missing : StartRow,
                DataType == null ? System.Type.Missing : DataType,
                TextQualifier == null ? System.Type.Missing : TextQualifier,
                ConsecutiveDelimiter == null ? System.Type.Missing : ConsecutiveDelimiter,
                Tab == null ? System.Type.Missing : Tab,
                Semicolon == null ? System.Type.Missing : Semicolon,
                Comma == null ? System.Type.Missing : Comma,
                Space == null ? System.Type.Missing : Space,
                Other == null ? System.Type.Missing : Other,
                OtherChar == null ? System.Type.Missing : OtherChar,
                FieldInfo == null ? System.Type.Missing : FieldInfo,
                TextVisualLayout == null ? System.Type.Missing : TextVisualLayout,
                DecimalSeparator == null ? System.Type.Missing : DecimalSeparator,
                ThousandsSeparator == null ? System.Type.Missing : ThousandsSeparator,
                TrailingMinusNumbers == null ? System.Type.Missing : TrailingMinusNumbers,
                Local == null ? System.Type.Missing : Local
            };
            return new Workbook(_objWorkbooks.GetType().InvokeMember("OpenText", BindingFlags.InvokeMethod, null, _objWorkbooks, _objaParameters));
        }

        /// <summary>打开一个 XML 数据文件。返回一个 Workbook 对象。
        /// </summary>
        /// <param name="Filename">要打开的文件的名称。</param>
        /// <param name="Stylesheets">单个值或值的数组，用于指定要应用的 XSL 转换 (XSLT) （XSL 转换 (XSLT)：用来将 XML 文档转换为其他类型的文档的语言，例如，HTML 或 XML。其用途为执行部分 XSL 功能。） 样式表处理指令。</param>
        /// <param name="LoadOption">指定 Excel 打开 XML 数据文件的方式。可以是下列 XlXmlLoadOption 常量之一。</param>
        /// <returns></returns>
        public Workbook OpenXML(string Filename, object Stylesheets = null, XlXmlLoadOption? LoadOption = null)
        {
            _objaParameters = new object[3] { 
                Filename == null ? System.Type.Missing : Filename,
                Stylesheets == null ? System.Type.Missing : Stylesheets,
                LoadOption == null ? System.Type.Missing : LoadOption
            };
            return new Workbook(_objWorkbooks.GetType().InvokeMember("OpenText", BindingFlags.InvokeMethod, null, _objWorkbooks, _objaParameters));
        }
        #endregion 函数
    }

    /// <summary>代表一个 Microsoft Excel 工作簿。
    /// 说明：
    /// Workbook 对象是 Workbooks 集合的成员。Workbooks 集合包含 Microsoft Excel 中当前打开的所有 Workbook 对象。
    /// </summary>
    public class Workbook
    {
        public object _objWorkbook;
        internal object[] _objaParameters;

        public Workbook(object objWorkbook, bool blnIsBooks = true)
        {
            _objWorkbook = objWorkbook;
        }

        #region 属性
        /// <summary>
        /// </summary>
        public bool AcceptLabelsInFormulas
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("AcceptLabelsInFormulas", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("AcceptLabelsInFormulas", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Chart 对象，它代表活动图表（嵌入式图表或图表工作表）。嵌入式图表在被选中或激活时被认为是活动的。当没有图表处于活动状态时，此属性返回 Nothing。
        /// </summary>
        public Chart ActiveChart
        {
            get
            {
                object objChart = _objWorkbook.GetType().InvokeMember("ActiveChart", BindingFlags.GetProperty, null, _objWorkbook, null);

                if (objChart == null)
                    return null;
                else
                    return new Chart(objChart);
            }
        }

        /// <summary>返回一个对象，它代表活动工作簿中或指定的窗口或工作簿中的活动工作表（最上面的工作表）。如果没有活动的工作表，则返回 Nothing。
        /// </summary>
        public dynamic ActiveSheet
        {
            get { return _objWorkbook.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWorkbook.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public string Author
        {
            get { return _objWorkbook.GetType().InvokeMember("Author", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Author", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>以分钟为单位返回或设置对共享工作簿进行自动更新的时间间隔。Long 类型，可读写。
        /// </summary>
        public int AutoUpdateFrequency
        {
            get { return (int)_objWorkbook.GetType().InvokeMember("AutoUpdateFrequency", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("AutoUpdateFrequency", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果共享工作簿自动更新时，对其所做的更改将传送到其他用户，则该值为 True。如果不传送所做的更改（该工作簿还须与其他用户所做的更改保持同步），则该值为 False。默认值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool AutoUpdateSaveChanges
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("AutoUpdateSaveChanges", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("AutoUpdateSaveChanges", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 DocumentProperties 集合，该集合表示指定工作簿的所有内置文档属性。只读。
        /// </summary>
        public dynamic BuiltinDocumentProperties
        {
            get { return _objWorkbook.GetType().InvokeMember("BuiltinDocumentProperties", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回有关工作簿最近一次完全重新计算所使用的 Excel 的版本信息。Long 型，只读。
        /// </summary>
        public int CalculationVersion
        {
            get { return (int)_objWorkbook.GetType().InvokeMember("CalculationVersion", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回或者设置共享工作簿的修订记录中所要显示修订信息的天数。Long 类型，可读写。
        /// </summary>
        public int ChangeHistoryDuration
        {
            get { return (int)_objWorkbook.GetType().InvokeMember("ChangeHistoryDuration", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ChangeHistoryDuration", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中的所有图表工作簿。
        /// </summary>
        public Sheets Charts
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Charts", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>控制在保存工作簿时是否自动运行兼容性检查器。可读/写 Boolean 类型。
        /// </summary>
        public bool CheckCompatibility
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("CheckCompatibility", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("CheckCompatibility", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回对象的代码名。String 型，只读。
        /// </summary>
        public string CodeName
        {
            get { return _objWorkbook.GetType().InvokeMember("CodeName", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 CommandBars 对象，它代表 Microsoft Excel 命令栏。只读。
        /// </summary>
        public CommandBars CommandBars
        {
            get { return new CommandBars(_objWorkbook.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public string Comments
        {
            get { return _objWorkbook.GetType().InvokeMember("Comments", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Comments", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回或设置更新共享工作簿时解决冲突的方式。XlSaveConflictResolution 类型，可读写。
        /// </summary>
        public XlSaveConflictResolution ConflictResolution
        {
            get { return (XlSaveConflictResolution)_objWorkbook.GetType().InvokeMember("ConflictResolution", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ConflictResolution", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>Connections 属性在工作簿和 ODBC 或 OLEDB 数据源之间建立连接，并在不提示用户的情况下刷新数据。只读。
        /// </summary>
        public Connections Connections
        {
            get { return new Connections(_objWorkbook.GetType().InvokeMember("Connections", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public bool ConnectionsDisabled
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ConnectionsDisabled", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回包含指定 OLE 对象的容器应用程序的对象。Object 类型，只读。
        /// </summary>
        public dynamic Container
        {
            get { return _objWorkbook.GetType().InvokeMember("Container", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 MetaProperties 集合，该集合描述工作簿中存储的元数据。只读。
        /// </summary>
        public MetaProperties ContentTypeProperties
        {
            get { return new MetaProperties(_objWorkbook.GetType().InvokeMember("ContentTypeProperties", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果保存文件时创建备份文件，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool CreateBackup
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("CreateBackup", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWorkbook.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回或设置一个 DocumentProperties 集合，该集合表示指定工作簿的所有自定义文档属性。
        /// </summary>
        public dynamic CustomDocumentProperties
        {
            get { return _objWorkbook.GetType().InvokeMember("CustomDocumentProperties", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 CustomViews 集合，该集合表示工作簿的所有自定义视图。
        /// </summary>
        public CustomViews CustomViews
        {
            get { return new CustomViews(_objWorkbook.GetType().InvokeMember("CustomViews", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 CustomXMLParts 集合，该集合代表 XML 数据存储区中的自定义 XML。只读。
        /// </summary>
        public CustomXMLParts CustomXMLParts
        {
            get { return new CustomXMLParts(_objWorkbook.GetType().InvokeMember("CustomXMLParts", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果工作簿使用 1904 日期系统，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Date1904
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("Date1904", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("Date1904", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>从 TableStyles 集合中指定表样式，该表样式将用作数据透视表的默认样式。可读/写。
        /// </summary>
        public dynamic DefaultPivotTableStyle
        {
            get { return _objWorkbook.GetType().InvokeMember("DefaultPivotTableStyle", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("DefaultPivotTableStyle", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>指定 TableStyles 集合中用作默认 TableStyle 的表样式。可读/写 Variant 类型。
        /// </summary>
        public dynamic DefaultTableStyle
        {
            get { return _objWorkbook.GetType().InvokeMember("DefaultTableStyle", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("DefaultTableStyle", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public Sheets DialogSheets
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("DialogSheets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回或设置形状的显示方式。Long 类型，可读写。
        /// </summary>
        public XlDisplayDrawingObjects DisplayDrawingObjects
        {
            get { return (XlDisplayDrawingObjects)_objWorkbook.GetType().InvokeMember("DisplayDrawingObjects", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("DisplayDrawingObjects", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>确定墨迹批注是否显示在工作簿中的 Boolean 值。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayInkComments
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("DisplayInkComments", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("DisplayInkComments", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 DocumentInspectors 集合，该集合代表指定工作簿的文档检查器模块。只读。
        /// </summary>
        public DocumentInspectors DocumentInspectors
        {
            get { return new DocumentInspectors(_objWorkbook.GetType().InvokeMember("DocumentInspectors", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 DocumentLibraryVersions 集合，代表启用版本控制的、存储在服务器上文档库中的共享工作簿的版本集合。
        /// </summary>
        public DocumentLibraryVersions DocumentLibraryVersions
        {
            get { return new DocumentLibraryVersions(_objWorkbook.GetType().InvokeMember("DocumentLibraryVersions", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public bool DoNotPromptForConvert
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("DoNotPromptForConvert", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("DoNotPromptForConvert", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>根据规定的时间间隔保存全部格式的已更改文件。Boolean 类型，可读写。
        /// </summary>
        public bool EnableAutoRecover
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("EnableAutoRecover", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("EnableAutoRecover", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 String 类型的值，该值指定在对文档加密时 1st_Excel12 使用的算法加密提供程序的名称。可读/写。
        /// </summary>
        public string EncryptionProvider
        {
            get { return _objWorkbook.GetType().InvokeMember("EncryptionProvider", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("EncryptionProvider", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果显示电子邮件标题和信封工具栏，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnvelopeVisible
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("EnvelopeVisible", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("EnvelopeVisible", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有的 Microsoft Excel 4.0 国际宏表。只读。
        /// </summary>
        public Sheets Excel4IntlMacroSheets
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Excel4IntlMacroSheets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有的 Microsoft Excel 4.0 宏表。只读。
        /// </summary>
        public Sheets Excel4MacroSheets
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Excel4MacroSheets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>Excel8CompatibilityMode 属性向开发人员提供了一种查看工作簿是否在兼容模式下的方法。只读 Boolean 类型。
        /// </summary>
        public bool Excel8CompatibilityMode
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("Excel8CompatibilityMode", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回工作簿的文件格式和/或类型。XlFileFormat 类型，只读。
        /// </summary>
        public XlFileFormat FileFormat
        {
            get { return (XlFileFormat)_objWorkbook.GetType().InvokeMember("FileFormat", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回或设置一个 Boolean 类型的值，该值指示工作簿是否是最终的。可读/写 Boolean 类型。
        /// </summary>
        public bool Final
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("Final", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("Final", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool ForceFullCalculation
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ForceFullCalculation", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ForceFullCalculation", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回对象的名称（以字符串表示），包括其磁盘路径。String 型，只读。
        /// </summary>
        public string FullName
        {
            get { return _objWorkbook.GetType().InvokeMember("FullName", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 String 值，该值表示对象名称（包括其磁盘路径）。只读。
        /// </summary>
        public string FullNameURLEncoded
        {
            get { return _objWorkbook.GetType().InvokeMember("FullNameURLEncoded", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>
        /// </summary>
        public bool HasMailer
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("HasMailer", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("HasMailer", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果指定工作簿有密码保护，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool HasPassword
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("HasPassword", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果指定工作簿含有传送名单，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool HasRoutingSlip
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("HasRoutingSlip", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("HasRoutingSlip", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Boolean 类型的值，该值代表工作簿是否具有附加的 Microsoft Visual Basic for Applications 项目。只读 Boolean 类型。
        /// </summary>
        public bool HasVBProject
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("HasVBProject", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果将指定共享工作簿的更改在屏幕上突出显示，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool HighlightChangesOnScreen
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("HighlightChangesOnScreen", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("HighlightChangesOnScreen", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>此属性用于基于 IconSet 集合中的单元格图标对工作簿中的数据进行筛选。只读。
        /// </summary>
        public IconSets IconSets
        {
            get { return new IconSets(_objWorkbook.GetType().InvokeMember("IconSets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>一个 Boolean 值，指定当列表不处于活动状态时，此列表的边框是否可见。如果边框可见，则返回 True。Boolean 类型，可读写。
        /// </summary>
        public bool InactiveListBorderVisible
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("InactiveListBorderVisible", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("InactiveListBorderVisible", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果指定工作簿作为加载宏运行，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool IsAddin
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("IsAddin", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("IsAddin", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果指定工作簿正在适当位置上进行编辑，则该值为 True。如果该工作簿已在 Microsoft Excel 中打开，并准备进行编辑，则该值为 False。Boolean 类型，只读。
        /// </summary>
        public bool IsInplace
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("IsInplace", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果对共享工作簿启用了修订记录功能，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool KeepChangeHistory
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("KeepChangeHistory", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("KeepChangeHistory", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string Keywords
        {
            get { return _objWorkbook.GetType().InvokeMember("Keywords", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Keywords", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果在单个工作表中显示共享工作簿的更改，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ListChangesOnNewSheet
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ListChangesOnNewSheet", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ListChangesOnNewSheet", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        public Mailer Mailer
        {
            get { return new Mailer(_objWorkbook.GetType().InvokeMember("Mailer", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public Sheets Modules
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Modules", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果工作簿以共享列表方式打开，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool MultiUserEditing
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("MultiUserEditing", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objWorkbook.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 Names 集合，它代表指定工作簿的所有名称（包括所有指定工作表的名称）。Names 对象，只读。
        /// </summary>
        public Names Names
        {
            get { return new Names(_objWorkbook.GetType().InvokeMember("Names", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public string OnSave
        {
            get { return _objWorkbook.GetType().InvokeMember("OnSave", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("OnSave", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetActivate
        {
            get { return _objWorkbook.GetType().InvokeMember("OnSheetActivate", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("OnSheetActivate", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetDeactivate
        {
            get { return _objWorkbook.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWorkbook.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回或设置在打开指定工作簿时必须提供的密码。String 类型，可读写。
        /// </summary>
        public string Password
        {
            get { return _objWorkbook.GetType().InvokeMember("Password", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Password", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 String 类型的数值，该数值表示 Microsoft Excel 对指定的工作簿编写密码时使用的算法。只读。
        /// </summary>
        public string PasswordEncryptionAlgorithm
        {
            get { return _objWorkbook.GetType().InvokeMember("PasswordEncryptionAlgorithm", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>如果 Microsoft Excel 对受密码保护的指定工作簿的文件属性进行加密，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool PasswordEncryptionFileProperties
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("PasswordEncryptionFileProperties", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 Long 类型的数值，该数值表示在对指定工作簿加密时 Microsoft Excel 使用的算法的密钥长度。只读。
        /// </summary>
        public int PasswordEncryptionKeyLength
        {
            get { return (int)_objWorkbook.GetType().InvokeMember("PasswordEncryptionKeyLength", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 String 类型的数值，该数值指定在对指定工作簿加密时 Microsoft Excel 使用的算法加密提供程序的名称。只读。
        /// </summary>
        public string PasswordEncryptionProvider
        {
            get { return _objWorkbook.GetType().InvokeMember("PasswordEncryptionProvider", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 String 值，它代表应用程序的完整路径，不包括末尾的分隔符和应用程序名称。
        /// </summary>
        public string Path
        {
            get { return _objWorkbook.GetType().InvokeMember("Path", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 Permission 对象，该对象表示指定工作簿中的权限设置。
        /// </summary>
        public Permission Permission
        {
            get { return new Permission(_objWorkbook.GetType().InvokeMember("Permission", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果在共享工作簿的用户个人视图中包括列表的筛选和排序设置，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool PersonalViewListSettings
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("PersonalViewListSettings", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("PersonalViewListSettings", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果在共享工作簿的用户个人视图中包括打印设置，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool PersonalViewPrintSettings
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("PersonalViewPrintSettings", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("PersonalViewPrintSettings", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果工作簿中的计算将按照屏幕显示的数字精度完成，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool PrecisionAsDisplayed
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("PrecisionAsDisplayed", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("PrecisionAsDisplayed", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果工作簿中的工作表次序处于保护状态，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectStructure
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ProtectStructure", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果工作簿窗口受保护，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectWindows
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ProtectWindows", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回 PublishObjects 集合。只读。
        /// </summary>
        public PublishObjects PublishObjects
        {
            get { return new PublishObjects(_objWorkbook.GetType().InvokeMember("PublishObjects", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果对象以只读方式打开，则返回 True。Boolean 类型，只读。
        /// </summary>
        public bool ReadOnly
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ReadOnly", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果工作簿以建议只读方式保存，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool ReadOnlyRecommended
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ReadOnlyRecommended", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ReadOnlyRecommended", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果能从指定的工作簿中删除个人信息，则该值为 True。默认值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool RemovePersonalInformation
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("RemovePersonalInformation", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("RemovePersonalInformation", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Research 对象，该对象代表工作簿的信息检索服务。只读。
        /// </summary>
        public Research Research
        {
            get { return new Research(_objWorkbook.GetType().InvokeMember("Research", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回指定工作簿以共享清单方式打开后已保存的次数。如果该工作簿以独占模式打开，则该值为 0（零）。Long 类型，只读。
        /// </summary>
        public int RevisionNumber
        {
            get { return (int)_objWorkbook.GetType().InvokeMember("RevisionNumber", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果指定工作簿已经传送给下一个收件人，则该值为 True；如果该工作簿需要进行传送，则该值为 False。Boolean 类型，只读。
        /// </summary>
        public bool Routed
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("Routed", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 RoutingSlip 对象，该对象表示工作簿的传送名单。无传送名单而读取该属性会导致错误（首先检查 HasRoutingSlip 属性）。只读。
        /// </summary>
        public RoutingSlip RoutingSlip
        {
            get { return new RoutingSlip(_objWorkbook.GetType().InvokeMember("RoutingSlip", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果指定工作簿从上次保存至今未发生过更改，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Saved
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("Saved", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("Saved", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 保存指定工作簿的外部链接值，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool SaveLinkValues
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("SaveLinkValues", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("SaveLinkValues", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 ServerPolicy 对象，该对象代表为存储在运行 2nd_OSS_NoVersion 2007 的服务器上的工作簿指定的策略。只读。
        /// </summary>
        public ServerPolicy ServerPolicy
        {
            get { return new ServerPolicy(_objWorkbook.GetType().InvokeMember("ServerPolicy", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>允许开发人员与服务器上显示的工作簿中已发布对象的列表进行交互。只读。
        /// </summary>
        public ServerViewableItems ServerViewableItems
        {
            get { return new ServerViewableItems(_objWorkbook.GetType().InvokeMember("ServerViewableItems", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 SharedWorkspace 对象，该对象表示指定文档所在的“文档工作区”。只读。
        /// </summary>
        public SharedWorkspace SharedWorkspace
        {
            get { return new SharedWorkspace(_objWorkbook.GetType().InvokeMember("SharedWorkspace", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有工作表。Sheets 对象，只读。
        /// </summary>
        public Sheets Sheets
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果“冲突的历史记录”工作表在作为共享列表打开的工作簿中可见，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ShowConflictHistory
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ShowConflictHistory", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ShowConflictHistory", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>此属性控制数据透视图筛选窗格的可见性。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowPivotChartActiveFields
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ShowPivotChartActiveFields", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ShowPivotChartActiveFields", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果该属性值为 True（默认），则能显示数据透视表字段列表。Boolean 类型，可读写。
        /// </summary>
        public bool ShowPivotTableFieldList
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("ShowPivotTableFieldList", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("ShowPivotTableFieldList", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回工作簿的数字签名。只读。
        /// </summary>
        public SignatureSet Signatures
        {
            get { return new SignatureSet(_objWorkbook.GetType().InvokeMember("Signatures", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 SmartDocument 对象，该对象表示智能文档解决方案设置。只读。
        /// </summary>
        public SmartDocument SmartDocument
        {
            get { return new SmartDocument(_objWorkbook.GetType().InvokeMember("SmartDocument", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 SmartTagOptions 对象，该对象表示能与智能标记一起进行操作的选项。
        /// </summary>
        public SmartTagOptions SmartTagOptions
        {
            get { return new SmartTagOptions(_objWorkbook.GetType().InvokeMember("SmartTagOptions", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 Styles 集合，该集合表示指定工作簿中的所有样式。只读。
        /// </summary>
        public Styles Styles
        {
            get { return new Styles(_objWorkbook.GetType().InvokeMember("Styles", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public string Subject
        {
            get { return _objWorkbook.GetType().InvokeMember("Subject", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Subject", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个 Sync 对象，该对象提供对构成“文档工作区”的文档的方法和属性的访问。
        /// </summary>
        public Sync Sync
        {
            get { return new Sync(_objWorkbook.GetType().InvokeMember("Sync", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回当前工作簿的一个 TableStyles 集合对象，该对象引用当前工作簿中所使用的样式。只读。
        /// </summary>
        public TableStyles TableStyles
        {
            get { return new TableStyles(_objWorkbook.GetType().InvokeMember("TableStyles", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>如果工作簿保存为模板时删除外部数据引用，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool TemplateRemoveExtData
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("TemplateRemoveExtData", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("TemplateRemoveExtData", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回应用于当前工作簿的主题。只读。
        /// </summary>
        public OfficeTheme Theme
        {
            get { return new OfficeTheme(_objWorkbook.GetType().InvokeMember("Theme", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>
        /// </summary>
        public string Title
        {
            get { return _objWorkbook.GetType().InvokeMember("Title", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("Title", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlUpdateLink 常量，该常量指示更新嵌入 OLE 链接的工作簿设置。可读写。
        /// </summary>
        public XlUpdateLinks UpdateLinks
        {
            get { return (XlUpdateLinks)_objWorkbook.GetType().InvokeMember("UpdateLinks", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("UpdateLinks", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 对指定工作簿中的远程引用进行更新，则该属性的值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool UpdateRemoteReferences
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("UpdateRemoteReferences", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("UpdateRemoteReferences", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool UserControl
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("UserControl", BindingFlags.GetProperty, null, _objWorkbook, null); }
            set { _objWorkbook.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>返回一个基为 1 的二维数组，该数组提供有关每一个以共享列表模式打开工作簿的用户的信息。Variant 类型，只读。
        /// </summary>
        public dynamic UserStatus
        {
            get { return _objWorkbook.GetType().InvokeMember("UserStatus", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>如果指定工作簿的 Visual Basic for Applications 项目已经过数字签名，则该属性的值为 True。Boolean 类型，只读。
        /// </summary>
        public bool VBASigned
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("VBASigned", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回一个 WebOptions 集合，该集合中包含以网页格式保存文档或打开网页时 Microsoft Excel 所使用的工作簿级别属性。只读。
        /// </summary>
        public WebOptions WebOptions
        {
            get { return new WebOptions(_objWorkbook.GetType().InvokeMember("WebOptions", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 Windows 集合，它代表指定工作簿中所有窗口。Windows 对象，只读。
        /// </summary>
        public Windows Windows
        {
            get { return new Windows(_objWorkbook.GetType().InvokeMember("Windows", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 Sheets 集合，它代表指定工作簿中所有工作表。Sheets 对象，只读。
        /// </summary>
        public Sheets Worksheets
        {
            get { return new Sheets(_objWorkbook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>为工作簿的写密码返回或设置一个 String 类型的数值。可读写。
        /// </summary>
        public string WritePassword
        {
            get { return _objWorkbook.GetType().InvokeMember("WritePassword", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
            set { _objWorkbook.GetType().InvokeMember("WritePassword", BindingFlags.SetProperty, null, _objWorkbook, new object[1] { value }); }
        }

        /// <summary>如果指定工作簿是写保护的，则该属性的值为 True。Boolean 类型，只读。
        /// </summary>
        public bool WriteReserved
        {
            get { return (bool)_objWorkbook.GetType().InvokeMember("WriteReserved", BindingFlags.GetProperty, null, _objWorkbook, null); }
        }

        /// <summary>返回当前对指定工作簿有写权限的用户的名称。String 类型，只读。
        /// </summary>
        public string WriteReservedBy
        {
            get { return _objWorkbook.GetType().InvokeMember("WriteReservedBy", BindingFlags.GetProperty, null, _objWorkbook, null).ToString(); }
        }

        /// <summary>返回一个 XmlMaps 集合，该集合表示已被添加到指定工作簿的架构映射。只读。
        /// </summary>
        public XmlMaps XmlMaps
        {
            get { return new XmlMaps(_objWorkbook.GetType().InvokeMember("XmlMaps", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }

        /// <summary>返回一个 XmlNamespaces 集合，该集合表示包含在指定工作簿中的 XML 命名空间。只读。
        /// </summary>
        public XmlNamespaces XmlNamespaces
        {
            get { return new XmlNamespaces(_objWorkbook.GetType().InvokeMember("XmlNamespaces", BindingFlags.GetProperty, null, _objWorkbook, null)); }
        }
        #endregion 属性

        #region 方法
        /// <summary>接受指定共享工作簿中的所有更改。
        /// </summary>
        /// <param name="When">指定何时接受所有更改。</param>
        /// <param name="Who">指定由何人接受所有更改。</param>
        /// <param name="Where">指定在何处接受所有更改。</param>
        public void AcceptAllChanges(object When = null, object Who = null, object Where = null)
        {
            _objaParameters = new object[3] {
                When == null ? System.Type.Missing : When,
                Who == null ? System.Type.Missing : Who,
                Where == null ? System.Type.Missing : Where
            };

            _objWorkbook.GetType().InvokeMember("AcceptAllChanges", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>激活与工作簿相关的第一个窗口。
        /// </summary>
        public void Activate()
        {
            _objWorkbook.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>将工作簿或超链接的快捷方式添加到“收藏夹”文件夹。
        /// </summary>
        public void AddToFavorites()
        {
            _objWorkbook.GetType().InvokeMember("AddToFavorites", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>将指定的主题应用于当前工作簿。
        /// </summary>
        /// <param name="Filename">主题的名称。</param>
        public void ApplyTheme(string Filename)
        {
            _objaParameters = new object[1] { Filename };

            _objWorkbook.GetType().InvokeMember("ApplyTheme", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将链接到其他 Microsoft Excel 源或 OLE 源的公式转换为值。
        /// </summary>
        /// <param name="Name">链接的名称。</param>
        /// <param name="Type">链接类型。</param>
        public void BreakLink(string Name, XlLinkType Type)
        {
            _objaParameters = new object[2] {
                Name,
                Type
            };

            _objWorkbook.GetType().InvokeMember("BreakLink", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>如果 Microsoft Excel 可以将指定的工作簿签入到服务器上，则该值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool CanCheckIn()
        {
            return (bool)_objWorkbook.GetType().InvokeMember("CanCheckIn", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>更改工作簿的访问权限。本方法需要从磁盘加载工作簿的更新版本。
        /// </summary>
        /// <param name="Mode">指定新的访问模式。</param>
        /// <param name="WritePassword">如果文件设置了写保护并且 Mode 为 xlReadWrite，则指定写保护密码。如果文件没有密码或 Mode 为 xlReadOnly，则忽略此参数。</param>
        /// <param name="Notify">如果该值为 True（或省略该参数），则当无法立即访问文件时通知用户。</param>
        public void ChangeFileAccess(XlFileAccess Mode, string WritePassword = null, bool? Notify = null)
        {
            _objaParameters = new object[3] {
                Mode,
                WritePassword == null ? System.Type.Missing : WritePassword,
                Notify == null ? System.Type.Missing : Notify
            };

            _objWorkbook.GetType().InvokeMember("ChangeFileAccess", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将链接从某一文档更改到另一文档。
        /// </summary>
        /// <param name="Name">要更改的 Microsoft Excel 链接或 DDE/OLE 链接的名称，与 LinkSources 方法所返回的名称相同。</param>
        /// <param name="NewName">链接的新名称。</param>
        /// <param name="Type">链接类型。</param>
        public void ChangeLink(string Name, string NewName, XlLinkType Type = XlLinkType.xlLinkTypeExcelLinks)
        {
            _objaParameters = new object[3] { Name, NewName, Type };

            _objWorkbook.GetType().InvokeMember("ChangeLink", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将工作簿从本地计算机返回给服务器，同时将本地工作簿设为只读使之无法在本地进行编辑。调用此方法还会关闭此工作簿。
        /// </summary>
        /// <param name="SaveChanges">如果该值为 True，则保存更改并签入文档。如果该值为 False，则不保存修订，并将文档恢复到签入状态。</param>
        /// <param name="Comments">用户可以为要签入的文档的修订输入签入批注（仅在 SaveChanges 等于 True 时才可应用）。</param>
        /// <param name="MakePublic">True 允许用户在工作簿签入后发布工作簿。这将把工作簿提交至审批过程，并最终生成发布给用户的工作簿版本，用户对该版本的工作簿拥有只读权限（仅在 SaveChanges 等于 True 时才可应用）。</param>
        public void CheckIn(bool? SaveChanges = null, string Comments = null, bool? MakePublic = null)
        {
            _objaParameters = new object[3] {
                SaveChanges == null ? System.Type.Missing : SaveChanges,
                Comments == null ? System.Type.Missing : Comments,
                MakePublic == null ? System.Type.Missing : MakePublic
            };

            _objWorkbook.GetType().InvokeMember("CheckIn", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>
        /// </summary>
        /// <param name="SaveChanges">如果该值为 True，则保存更改并签入文档。如果该值为 False，则不保存修订，并将文档恢复到签入状态。</param>
        /// <param name="Comments">用户可以为要签入的文档的修订输入签入批注（仅在 SaveChanges 等于 True 时才可应用）。</param>
        /// <param name="MakePublic">True 允许用户在工作簿签入后发布工作簿。这将把工作簿提交至审批过程，并最终生成发布给用户的工作簿版本，用户对该版本的工作簿拥有只读权限（仅在 SaveChanges 等于 True 时才可应用）。</param>
        public void CheckInWithVersion(bool? SaveChanges = null, string Comments = null, bool? MakePublic = null, object VersionType = null)
        {
            _objaParameters = new object[4] {
                SaveChanges == null ? System.Type.Missing : SaveChanges,
                Comments == null ? System.Type.Missing : Comments,
                MakePublic == null ? System.Type.Missing : MakePublic,
                VersionType == null ? System.Type.Missing : VersionType
            };

            _objWorkbook.GetType().InvokeMember("CheckInWithVersion", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>关闭对象。
        /// </summary>
        /// <param name="SaveChanges">如果工作簿中没有改动，则忽略此参数。如果工作簿中有改动但工作簿显示在其他打开的窗口中，则忽略此参数。如果工作簿中有改动且工作簿未显示在任何其他打开的窗口中，则由此参数指定是否应保存更改。如果设为 True，则保存对工作簿所做的更改。如果工作簿尚未命名，则使用 FileName。如果省略 Filename，则要求用户提供文件名。</param>
        /// <param name="Filename">以此文件名保存所做的更改。</param>
        /// <param name="RouteWorkbook">如果工作簿不需要传送给下一个收件人（没有传送名单或已经传送），则忽略此参数。否则，Microsoft Excel 根据此参数的值传送工作簿。如果设为 True，则将工作簿传送给下一个收件人。如果设为 False，则不发送工作簿。如果忽略，则要求用户确认是否发送工作簿。</param>
        public void Close(bool? SaveChanges = null, string Filename = null, bool? RouteWorkbook = null)
        {
            _objaParameters = new object[3] {
                SaveChanges == null ? System.Type.Missing : SaveChanges,
                Filename == null ? System.Type.Missing : Filename,
                RouteWorkbook == null ? System.Type.Missing : RouteWorkbook
            };

            _objWorkbook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>从工作簿中删除一个自定义数字格式。
        /// </summary>
        /// <param name="NumberFormat">命名要删除的数字格式。</param>
        public void DeleteNumberFormat(string NumberFormat)
        {
            _objaParameters = new object[1] { NumberFormat };

            _objWorkbook.GetType().InvokeMember("DeleteNumberFormat", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>使用 EnableConnections 方法，开发人员可以为用户在工作簿内以编程方式启用数据连接。
        /// </summary>
        public void EnableConnections()
        {
            _objWorkbook.GetType().InvokeMember("EnableConnections", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>终止对文件的审阅，该文件已用 SendForReview 方法发送候审。
        /// </summary>
        public void EndReview()
        {
            _objWorkbook.GetType().InvokeMember("EndReview", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>指定当前用户对共享清单中的工作簿进行独占访问。
        /// </summary>
        public bool ExclusiveAccess()
        {
            return (bool)_objWorkbook.GetType().InvokeMember("ExclusiveAccess", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>ExportAsFixedFormat 方法用于将工作簿发布为 PDF 或 XPS 格式。
        /// </summary>
        /// <param name="Type">可以是 xlTypePDF，也可以是 xlTypeXPS。</param>
        /// <param name="Filename">一个指明要保存的文件的名称的字符串。可以包括完整路径，否则 Excel 2007 会将文件保存在当前文件夹中。</param>
        /// <param name="Quality">可设置为 xlQualityStandard 或 xlQualityMinimum。</param>
        /// <param name="IncludeDocProperties">设置为 True 以指明应包含文档属性，或设置为 False 以指明应省略文档属性。</param>
        /// <param name="IgnorePrintAreas">如果设置为 True，则忽略在发布时设置的任何打印区域。如果设置为 False，则使用在发布时设置的打印区域。</param>
        /// <param name="From">发布的起始页码。如果省略此参数，则从起始位置开始发布。</param>
        /// <param name="To">发布的终止页码。如果省略此参数，则发布至最后一页。</param>
        /// <param name="OpenAfterPublish">如果设置为 True，则在发布文件后在查看器中显示文件。如果设置为 False，则发布文件，但不显示文件。</param>
        /// <param name="FixedFormatExtClassPtr">指向 FixedFormatExt 类的指针。</param>
        public void ExportAsFixedFormat(XlFixedFormatType Type, string Filename = null, object Quality = null, bool? IncludeDocProperties = null, bool? IgnorePrintAreas = null, int? From = null, int? To = null, bool? OpenAfterPublish = null, object FixedFormatExtClassPtr = null)
        {
            _objaParameters = new object[9] {
                Type,
                Filename == null ? System.Type.Missing : Filename,
                Quality == null ? System.Type.Missing : Quality,
                IncludeDocProperties == null ? System.Type.Missing : IncludeDocProperties,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas,
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                OpenAfterPublish == null ? System.Type.Missing : OpenAfterPublish,
                FixedFormatExtClassPtr == null ? System.Type.Missing : FixedFormatExtClassPtr
            };

            _objWorkbook.GetType().InvokeMember("ExportAsFixedFormat", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>如果已经下载指定文档，则显示缓冲区中的该文档。否则，本方法对指定超链接进行处理以下载目标文档，然后将该文档在适当的应用程序中显示出来。
        /// </summary>
        /// <param name="Address">目标文档的地址。</param>
        /// <param name="SubAddress">目标文档中的位置。默认值为空字符串。</param>
        /// <param name="NewWindow">如果为 True，则在新窗口中显示目标应用程序。默认值为 False。</param>
        /// <param name="AddHistory">未使用。保留供将来使用。</param>
        /// <param name="ExtraInfo">指定解析超链接时要使用的 HTTP 附加信息的 String 或字节数组。例如，可以使用 ExtraInfo 指定图像的坐标、窗体的内容或 FAT 文件名。</param>
        /// <param name="Method">指定附加 ExtraInfo 的方法。可以是 MsoExtraInfoMethod 常量之一。</param>
        /// <param name="HeaderInfo">指定 HTTP 请求的标题信息的 String。默认值为空字符串。</param>
        public void FollowHyperlink(string Address, string SubAddress = null, bool? NewWindow = null, object AddHistory = null, object ExtraInfo = null, MsoExtraInfoMethod? Method = null, string HeaderInfo = null)
        {
            _objaParameters = new object[7] {
                Address,
                SubAddress == null ? System.Type.Missing : SubAddress,
                NewWindow == null ? System.Type.Missing : NewWindow,
                AddHistory == null ? System.Type.Missing : AddHistory,
                ExtraInfo == null ? System.Type.Missing : ExtraInfo,
                Method == null ? System.Type.Missing : Method,
                HeaderInfo == null ? System.Type.Missing : HeaderInfo
            };

            _objWorkbook.GetType().InvokeMember("FollowHyperlink", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        public void ForwardMailer()
        {

            _objWorkbook.GetType().InvokeMember("ForwardMailer", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>返回指定工作簿的 WorkflowTask 对象集合。
        /// </summary>
        public WorkflowTasks GetWorkflowTasks()
        {

            return (WorkflowTasks)_objWorkbook.GetType().InvokeMember("GetWorkflowTasks", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>返回指定工作簿的 WorkflowTemplate 对象集合。
        /// </summary>
        public WorkflowTemplates GetWorkflowTemplates()
        {

            return (WorkflowTemplates)_objWorkbook.GetType().InvokeMember("GetWorkflowTemplates", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>控制共享工作簿更改的显示方式。
        /// </summary>
        /// <param name="When">显示的更改。可为以下 XlHighlightChangesTime 常量之一：xlSinceMyLastSave、xlAllChanges 或 xlNotYetReviewed。</param>
        /// <param name="Who">显示其所做更改的一个或多个用户。可以是“每个人”、“除我之外的每个人”或共享工作簿的某个用户名。</param>
        /// <param name="Where">一个 A1-样式区域引用，该引用指定要检查更改的区域。</param>
        public void HighlightChangesOptions(XlHighlightChangesTime? When = null, string Who = null, object Where = null)
        {
            _objaParameters = new object[3] {
                When == null ? System.Type.Missing : When,
                Who == null ? System.Type.Missing : Who,
                Where == null ? System.Type.Missing : Where
            };

            _objWorkbook.GetType().InvokeMember("HighlightChangesOptions", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>返回工作簿中某个链接的日期及其更新状态。
        /// </summary>
        /// <param name="Name">链接的名称。</param>
        /// <param name="LinkInfo">要返回的信息的类型。</param>
        /// <param name="Type">指定要返回的链接类型的 XlLinkInfoType 常量之一。</param>
        /// <param name="EditionRef">如果链接为一个版本，则该参数以 R1C1 样式的字符串形式指定版本引用。如果工作簿中存在多个同名的发布者和订阅者，则该参数为必选参数。</param>
        public dynamic LinkInfo(string Name, XlLinkInfo LinkInfo, XlLinkInfoType? Type = null, string EditionRef = null)
        {
            _objaParameters = new object[4] {
                Name,
                LinkInfo,
                Type == null ? System.Type.Missing : Type,
                EditionRef == null ? System.Type.Missing : EditionRef
            };

            return _objWorkbook.GetType().InvokeMember("LinkInfo", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>返回工作簿中链接的数组。数组中的名称为链接的文档名、版本名、DDE 或 OLE 服务器名。如果工作簿中无链接，则返回 Empty。
        /// </summary>
        /// <param name="Type">指定要返回的链接类型的 XlLink 常量之一。</param>
        public dynamic LinkSources(XlLink? Type = null)
        {
            _objaParameters = new object[1] {
                Type == null ? System.Type.Missing : Type
            };

            return _objWorkbook.GetType().InvokeMember("LinkSources", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>在服务器上锁定工作簿以防止修改。
        /// </summary>
        public void LockServerFile()
        {

            _objWorkbook.GetType().InvokeMember("LockServerFile", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>将某工作簿中的改动合并到已打开的工作簿中。
        /// </summary>
        /// <param name="Filename">工作簿名称，该工作簿包含将合并到打开的工作簿中的更改。</param>
        public void MergeWorkbook(string Filename)
        {
            _objaParameters = new object[1] {
                Filename
            };

            _objWorkbook.GetType().InvokeMember("MergeWorkbook", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>新建一个窗口或者创建指定窗口的副本。
        /// </summary>
        public Window NewWindow()
        {
            return new Window(_objWorkbook.GetType().InvokeMember("NewWindow", BindingFlags.InvokeMethod, null, _objWorkbook, null));
        }

        /// <summary>打开链接的支持文档。
        /// </summary>
        /// <param name="Name">Microsoft Excel 链接或 DDE/OLE 链接的名称（从 LinkSources 方法返回）。</param>
        /// <param name="ReadOnly">如果为 True，则以只读形式打开文档。默认值为 False。</param>
        /// <param name="Type">指定链接类型的 XlLink 常量之一。</param>
        public void OpenLinks(string Name, bool? ReadOnly = null, XlLink? Type = null)
        {
            _objaParameters = new object[3] {
                Name,
                ReadOnly == null ? System.Type.Missing : ReadOnly,
                Type == null ? System.Type.Missing : Type
            };

            _objWorkbook.GetType().InvokeMember("OpenLinks", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>返回一个 PivotCaches 集合，该集合表示指定工作簿中的所有数据透视表缓存。只读。
        /// </summary>
        public PivotCaches PivotCaches()
        {

            return new PivotCaches(_objWorkbook.GetType().InvokeMember("PivotCaches", BindingFlags.InvokeMethod, null, _objWorkbook, null));
        }

        /// <summary>
        /// </summary>
        public void PivotTableWizard(object SourceType = null, object SourceData = null, object TableDestination = null, object TableName = null, object RowGrand = null, object ColumnGrand = null, object SaveData = null, object HasAutoFormat = null, object AutoPage = null, object Reserved = null, object BackgroundQuery = null, object OptimizeCache = null, object PageFieldOrder = null, object PageFieldWrapCount = null, object ReadData = null, object Connection = null)
        {
            _objaParameters = new object[16] {
                SourceType == null ? System.Type.Missing : SourceType,
                SourceData == null ? System.Type.Missing : SourceData,
                TableDestination == null ? System.Type.Missing : TableDestination,
                TableName == null ? System.Type.Missing : TableName,
                RowGrand == null ? System.Type.Missing : RowGrand,
                ColumnGrand == null ? System.Type.Missing : ColumnGrand,
                SaveData == null ? System.Type.Missing : SaveData,
                HasAutoFormat == null ? System.Type.Missing : HasAutoFormat,
                AutoPage == null ? System.Type.Missing : AutoPage,
                Reserved == null ? System.Type.Missing : Reserved,
                BackgroundQuery == null ? System.Type.Missing : BackgroundQuery,
                OptimizeCache == null ? System.Type.Missing : OptimizeCache,
                PageFieldOrder == null ? System.Type.Missing : PageFieldOrder,
                PageFieldWrapCount == null ? System.Type.Missing : PageFieldWrapCount,
                ReadData == null ? System.Type.Missing : ReadData,
                Connection == null ? System.Type.Missing : Connection
            };

            _objWorkbook.GetType().InvokeMember("PivotTableWizard", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将指定工作簿发送到一个公共文件夹。本方法仅应用于与 Microsoft Exchange 服务器连接的 Microsoft Exchange 客户端。
        /// </summary>
        /// <param name="DestName">忽略该参数。Post 方法提示用户指定工作簿的目标。</param>
        public void Post(string DestName = null)
        {
            _objaParameters = new object[1] {
                DestName == null ? System.Type.Missing : DestName
            };

            _objWorkbook.GetType().InvokeMember("Post", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        /// <param name="IgnorePrintAreas">如果为 True，则忽略打印区域并打印整个对象。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, string PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorkbook.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, string PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorkbook.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] { EnableChanges == null ? System.Type.Missing : EnableChanges };
            _objWorkbook.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>保护工作簿使其不被修改。
        /// </summary>
        /// <param name="Password">一个字符串，该字符串为工作表或工作簿指定区分大小写的密码。如果省略此参数，不用密码就可以取消对工作表或工作簿的保护。否则，必须指定密码才能取消对工作表或工作簿的保护。如果忘记了密码，就无法取消对工作表或工作簿的保护。使用由大写字母、小写字母、数字和符号组合而成的强密码。弱密码不混合使用这些元素。例如，Y6dh!et5 是强密码；House27 是弱密码。密码长度应大于或等于 8 个字符。最好使用包括 14 个或更多个字符的密码。有关详细信息，请参阅使用强密码有助于保护个人信息。记住密码很重要。如果忘记了密码，Microsoft 将无法找回。最好将密码记录下来，保存在一个安全的地方，这个地方应该尽量远离密码所要保护的信息。</param>
        /// <param name="Structure">如果为 True，则保护工作簿结构（工作表的相对位置）。默认值是 False。</param>
        /// <param name="Windows">如果为 True，则保护工作簿窗口。如果省略此参数，则窗口不受保护。</param>
        public void Protect(string Password = null, bool? Structure = null, bool? Windows = null)
        {
            _objaParameters = new object[3] { 
                Password == null ? System.Type.Missing : Password,
                Structure == null ? System.Type.Missing : Structure,
                Windows == null ? System.Type.Missing : Windows
            };

            _objWorkbook.GetType().InvokeMember("Protect", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>保存工作簿并设置共享保护。
        /// </summary>
        /// <param name="Filename">一个表示保存文件的名称的字符串。可以包含一个完整路径；否则 Microsoft Excel 将该文件保存到当前文件夹中。</param>
        /// <param name="Password">一个区分大小写的字符串，表示保护此文件所用的密码。长度不应超过 15 个字符。</param>
        /// <param name="WriteResPassword">一个字符串，表示此文件的写保护密码。如果保存文件时使用了密码，但在打开文件时未提供密码，则该文件以只读方式打开。</param>
        /// <param name="ReadOnlyRecommended">如果为 True，则在打开文件时显示一条建议文件以只读方式打开的消息。</param>
        /// <param name="CreateBackup">如果为 True，则创建备份文件。</param>
        /// <param name="SharingPassword">一个字符串，表示文件共享保护密码。</param>
        public void ProtectSharing(string Filename = null, string Password = null, string WriteResPassword = null, bool? ReadOnlyRecommended = null, bool? CreateBackup = null, string SharingPassword = null)
        {
            _objaParameters = new object[6] { 
                Filename == null ? System.Type.Missing : Filename,
                Password == null ? System.Type.Missing : Password,
                WriteResPassword == null ? System.Type.Missing : WriteResPassword,
                ReadOnlyRecommended == null ? System.Type.Missing : ReadOnlyRecommended,
                CreateBackup == null ? System.Type.Missing : CreateBackup,
                SharingPassword == null ? System.Type.Missing : SharingPassword
            };

            _objWorkbook.GetType().InvokeMember("ProtectSharing", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void ProtectSharingEx(string Filename = null, string Password = null, string WriteResPassword = null, bool? ReadOnlyRecommended = null, bool? CreateBackup = null, string SharingPassword = null, object FileFormat = null)
        {
            _objaParameters = new object[7] {
                Filename == null ? System.Type.Missing : Filename,
                Password == null ? System.Type.Missing : Password,
                WriteResPassword == null ? System.Type.Missing : WriteResPassword,
                ReadOnlyRecommended == null ? System.Type.Missing : ReadOnlyRecommended,
                CreateBackup == null ? System.Type.Missing : CreateBackup,
                SharingPassword == null ? System.Type.Missing : SharingPassword,
                FileFormat == null ? System.Type.Missing : FileFormat
            };

            _objWorkbook.GetType().InvokeMember("ProtectSharingEx", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>从更改日志中删除指定工作簿的条目。
        /// </summary>
        /// <param name="Days">要在更改日志中保留更改的天数。</param>
        /// <param name="SharingPassword">工作簿的取消共享保护密码。如果工作簿有共享保护密码，同时省略了该参数，将提示用户输入密码。</param>
        public void PurgeChangeHistoryNow(int Days, string SharingPassword = null)
        {
            _objaParameters = new object[2] {
                Days,
                SharingPassword == null ? System.Type.Missing : SharingPassword
            };

            _objWorkbook.GetType().InvokeMember("PurgeChangeHistoryNow", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>使得前景智能标记检查自动出现，对以前没有注释过的数据进行注释。
        /// </summary>
        public void RecheckSmartTags()
        {
            _objWorkbook.GetType().InvokeMember("RecheckSmartTags", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>刷新指定工作簿中的所有外部数据区域和数据透视表。
        /// </summary>
        public void RefreshAll()
        {
            _objWorkbook.GetType().InvokeMember("RefreshAll", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>取消指定共享工作簿中的所有更改。
        /// </summary>
        /// <param name="When">指定何时拒绝所有更改。</param>
        /// <param name="Who">指定由何人拒绝所有更改。</param>
        /// <param name="Where">指定在何处拒绝所有更改。</param>
        public void RejectAllChanges(object When = null, object Who = null, object Where = null)
        {
            _objaParameters = new object[3] {
                When == null ? System.Type.Missing : When,
                Who == null ? System.Type.Missing : Who,
                Where == null ? System.Type.Missing : Where
            };

            _objWorkbook.GetType().InvokeMember("RejectAllChanges", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>使用指定的文档编码方式，重新加载基于 HTML 文档的工作簿。
        /// </summary>
        /// <param name="Encoding">要应用于工作簿的编码。</param>
        public void ReloadAs(MsoEncoding Encoding)
        {
            _objaParameters = new object[1] { Encoding };

            _objWorkbook.GetType().InvokeMember("ReloadAs", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>从工作簿中删除指定类型的所有信息。
        /// </summary>
        /// <param name="RemoveDocInfoType">要删除的信息的类型。</param>
        public void RemoveDocumentInformation(XlRemoveDocInfoType RemoveDocInfoType)
        {
            _objaParameters = new object[1] { RemoveDocInfoType };

            _objWorkbook.GetType().InvokeMember("RemoveDocumentInformation", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>断开指定用户与共享工作簿的连接。
        /// </summary>
        /// <param name="Index">用户索引。</param>
        public void RemoveUser(int Index)
        {
            _objaParameters = new object[1] { Index };

            _objWorkbook.GetType().InvokeMember("RemoveUser", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        public void Reply()
        {
            _objWorkbook.GetType().InvokeMember("Reply", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        public void ReplyAll()
        {
            _objWorkbook.GetType().InvokeMember("ReplyAll", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>向已发送候审的工作簿的作者发送电子邮件消息，通知审阅者已经完成工作簿的审阅。
        /// </summary>
        /// <param name="ShowMessage">如果为 False，则不显示消息。如果为 True，则显示消息。</param>
        public void ReplyWithChanges(bool? ShowMessage = null)
        {
            _objaParameters = new object[1] {
                ShowMessage == null ? System.Type.Missing : ShowMessage
            };

            _objWorkbook.GetType().InvokeMember("ReplyWithChanges", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将调色板重新设为默认颜色。
        /// </summary>
        public void ResetColors()
        {
            _objWorkbook.GetType().InvokeMember("ResetColors", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>使用工作簿的当前传送名单传送工作簿。
        /// </summary>
        public void Route()
        {
            _objWorkbook.GetType().InvokeMember("Route", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>运行附属于指定工作簿的 Auto_Open、Auto_Close、Auto_Activate 或 Auto_Deactivate 宏。保留本方法是为了保持向后兼容性。在新的 Visual Basic 代码中，应使用 Open、Close、Activate 和 Deactivate 事件取代上述宏。
        /// </summary>
        /// <param name="Which">指定要运行的自动宏。</param>
        public void RunAutoMacros(XlRunAutoMacro Which)
        {
            _objaParameters = new object[1] { Which };

            _objWorkbook.GetType().InvokeMember("RunAutoMacros", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>保存对指定工作簿所做的更改。
        /// </summary>
        public void Save()
        {
            _objWorkbook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>在另一不同文件中保存对工作簿所做的更改。
        /// </summary>
        /// <param name="FileName">一个表示要保存文件的文件名的字符串。可包含完整路径，如果不指定路径，Microsoft Excel 将文件保存到当前文件夹中。</param>
        /// <param name="FileFormat">保存文件时使用的文件格式。要查看有效的选项列表，请参阅 FileFormat 属性。对于现有文件，默认采用上一次指定的文件格式；对于新文件，默认采用当前所用 Excel 版本的格式。</param>
        /// <param name="Password">它是一个区分大小写的字符串（最长不超过 15 个字符），用于指定文件的保护密码。</param>
        /// <param name="WriteResPassword">一个表示文件写保护密码的字符串。如果文件保存时带有密码，但打开文件时不输入密码，则该文件以只读方式打开。</param>
        /// <param name="ReadOnlyRecommended">如果为 True，则在打开文件时显示一条消息，提示该文件以只读方式打开。</param>
        /// <param name="CreateBackup">如果为 True，则创建备份文件。</param>
        /// <param name="AccessMode">工作簿的访问模式。</param>
        /// <param name="ConflictResolution">一个 XlSaveConflictResolution 值，它确定该方法在保存工作簿时如何解决冲突。如果设为 xlUserResolution，则显示冲突解决对话框。如果设为 xlLocalSessionChanges，则自动接受本地用户的更改。如果设为 xlOtherSessionChanges，则自动接受来自其他会话的更改（而不是本地用户的更改）。如果省略此参数，则显示冲突处理对话框。</param>
        /// <param name="AddToMru">如果为 True，则将该工作簿添加到最近使用的文件列表中。默认值为 False。</param>
        /// <param name="TextCodepage">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="TextVisualLayout">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="Local">如果为 True，则以 Microsoft Excel（包括控制面板设置）的语言保存文件。如果为 False（默认值），则以 Visual Basic for Applications (VBA) （Visual Basic for Applications (VBA)：Microsoft Visual Basic 的宏语言版本，用于编写基于 Microsoft Windows 的应用程序，内置于多个 Microsoft 程序中。） 的语言保存文件，其中 Visual Basic for Applications (VBA) 通常为美国英语版本，除非从中运行 Workbooks.Open 的 VBA 项目是旧的已国际化的 XL5/95 VBA 项目。</param>
        public void SaveAs(string FileName,
                                     XlFileFormat? FileFormat = null,
                                     string Password = null,
                                     string WriteResPassword = null,
                                     bool? ReadOnlyRecommended = null,
                                     bool? CreateBackup = null,
                                     XlSaveAsAccessMode? AccessMode = null,
                                     XlSaveConflictResolution? ConflictResolution = null,
                                     bool? AddToMru = null,
                                     object TextCodepage = null,
                                     object TextVisualLayout = null,
                                     bool? Local = null)
        {
            if (FileName == null || FileName == string.Empty)
                throw new ArgumentNullException("The param \"FileName\" can't be a null value");

            _objaParameters = new Object[12] { 
                                                                FileName,
                                                                FileFormat == null ? System.Type.Missing : FileFormat,
                                                                Password == null ? System.Type.Missing : Password,
                                                                WriteResPassword == null ? System.Type.Missing : WriteResPassword,
                                                                ReadOnlyRecommended == null ? System.Type.Missing : ReadOnlyRecommended,
                                                                CreateBackup == null ? System.Type.Missing : CreateBackup,
                                                                AccessMode == null ? System.Type.Missing : AccessMode,
                                                                ConflictResolution == null ? System.Type.Missing : ConflictResolution,
                                                                AddToMru == null ? System.Type.Missing : AddToMru,
                                                                TextCodepage == null ? System.Type.Missing : TextCodepage,
                                                                TextVisualLayout == null ? System.Type.Missing : TextVisualLayout,
                                                                Local == null ? System.Type.Missing : Local
                };
            _objWorkbook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);

        }

        /// <summary>将已映射到指定 XML 架构映射的数据导出到 XML 数据文件中。
        /// </summary>
        /// <param name="Filename">一个表示要保存文件的文件名的字符串。可包含完整路径，如果不指定路径，Microsoft Excel 将文件保存到当前文件夹中。</param>
        /// <param name="Map">应用于数据的架构映射。</param>
        public void SaveAsXMLData(string Filename, XmlMap Map)
        {
            _objaParameters = new object[2] { Filename, Map };

            _objWorkbook.GetType().InvokeMember("SaveAsXMLData", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将指定工作簿的副本保存到文件，但不修改内存中的打开工作簿。
        /// </summary>
        /// <param name="Filename">指定副本的文件名。</param>
        public void SaveCopyAs(string Filename = null)
        {
            _objaParameters = new object[1] {
                Filename == null ? System.Type.Missing : Filename
            };

            _objWorkbook.GetType().InvokeMember("SaveCopyAs", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>将工作表作为传真发送给指定的收件人。
        /// </summary>
        /// <param name="Recipients">一个 String 类型的值，该值表示传真收件人的传真号和电子邮件地址。用分号分隔多个收件人。</param>
        /// <param name="Subject">一个 String 类型的值，该值表示传真文档的主题行。</param>
        /// <param name="ShowMessage">如果为 True，则在发送传真前显示传真消息。如果为 False，则在不显示传真消息的情况下发送传真。</param>
        public void SendFaxOverInternet(string Recipients = null, string Subject = null, bool? ShowMessage = null)
        {
            _objaParameters = new object[3] {
                Recipients == null ? System.Type.Missing : Recipients,
                Subject == null ? System.Type.Missing : Subject,
                ShowMessage == null ? System.Type.Missing : ShowMessage
            };

            _objWorkbook.GetType().InvokeMember("SendFaxOverInternet", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>在电子邮件中将供审阅的工作簿发送到指定的收件人。
        /// </summary>
        /// <param name="Recipients">一个列出邮件收件人的字符串。这些字符串可以是在电子邮件电话簿或完整电子邮件地址中未定的名称和别名。用分号 (;) 分隔开多个收件人。如果留有空格并且 ShowMessage 为 False，您将收到错误消息，并且不会发送邮件。</param>
        /// <param name="Subject">邮件主题字符串。如果为空，主题将为请审阅“filename”。</param>
        /// <param name="ShowMessage">一个 Boolean 类型的值，指示执行方法时是否显示邮件。默认值为 True。如果设置为 False，会将邮件自动发送给收件人，而不是先向发件人显示邮件。</param>
        /// <param name="IncludeAttachment">一个 Boolean 类型的值，该值表示邮件是否应包含附件或指向服务器位置的链接。默认值为 True。如果设置为 False，则文档必须存储在共享位置。</param>
        public void SendForReview(string Recipients = null, string Subject = null, bool? ShowMessage = null, bool? IncludeAttachment = null)
        {
            _objaParameters = new object[4] {
                Recipients == null ? System.Type.Missing : Recipients,
                Subject == null ? System.Type.Missing : Subject,
                ShowMessage == null ? System.Type.Missing : ShowMessage,
                IncludeAttachment == null ? System.Type.Missing : IncludeAttachment
            };

            _objWorkbook.GetType().InvokeMember("SendForReview", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>使用已安装的邮件系统发送工作簿。
        /// </summary>
        /// <param name="Recipients">以文本形式指定收件人名称，如果有多个收件人，则以文本字符串数组的形式指定它。必须至少指定一个收件人，并将所有收件人都添加到“收件人”中。</param>
        /// <param name="Subject">指定邮件主题。如果省略该参数，则使用文档名称。</param>
        /// <param name="ReturnReceipt">如果为 True，则请求返回收件人。如果为 False，则不请求返回收件人。默认值为 False。</param>
        public void SendMail(object Recipients, string Subject = null, bool? ReturnReceipt = null)
        {
            _objaParameters = new object[3] {
                Recipients,
                Subject == null ? System.Type.Missing : Subject,
                ReturnReceipt == null ? System.Type.Missing : ReturnReceipt
            };

            _objWorkbook.GetType().InvokeMember("SendMail", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        /// <param name="FileFormat">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Priority">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        public void SendMailer(object FileFormat = null, XlPriority Priority = XlPriority.xlPriorityNormal)
        {
            _objaParameters = new object[2] {
                FileFormat == null ? System.Type.Missing : FileFormat,
                Priority
            };

            _objWorkbook.GetType().InvokeMember("SendMailer", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>设置每当更新 DDE 链接时所运行过程的名称。
        /// </summary>
        /// <param name="Name">DDE/OLE 链接的名称（从 LinkSources 方法返回）。</param>
        /// <param name="Procedure">当更新链接时所运行过程的名称。可以是一个 Microsoft Excel 4.0 宏或一个 Visual Basic 过程。将该参数设置为空字符串 ("") 表示更新链接时不运行任何过程。</param>
        public void SetLinkOnData(string Name, string Procedure = null)
        {
            _objaParameters = new object[2] {
                Name,
                Procedure == null ? System.Type.Missing : Procedure
            };

            _objWorkbook.GetType().InvokeMember("SetLinkOnData", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>使用密码来设置对工作簿进行加密的选项。
        /// </summary>
        /// <param name="PasswordEncryptionProvider">区分大小写的加密服务提供商的字符串。</param>
        /// <param name="PasswordEncryptionAlgorithm">区分大小写的算法简称的字符串（例如“RC4”）。</param>
        /// <param name="PasswordEncryptionKeyLength">加密密钥的长度，为 8 的倍数（40 或更大）。</param>
        /// <param name="PasswordEncryptionFileProperties">如果为 True（默认值），则加密文件属性。</param>
        public void SetPasswordEncryptionOptions(string PasswordEncryptionProvider = null, string PasswordEncryptionAlgorithm = null, int? PasswordEncryptionKeyLength = null, bool? PasswordEncryptionFileProperties = null)
        {
            _objaParameters = new object[4] {
                PasswordEncryptionProvider == null ? System.Type.Missing : PasswordEncryptionProvider,
                PasswordEncryptionAlgorithm == null ? System.Type.Missing : PasswordEncryptionAlgorithm,
                PasswordEncryptionKeyLength == null ? System.Type.Missing : PasswordEncryptionKeyLength,
                PasswordEncryptionFileProperties == null ? System.Type.Missing : PasswordEncryptionFileProperties
            };

            _objWorkbook.GetType().InvokeMember("SetPasswordEncryptionOptions", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>ToggleFormsDesign 方法用于在使用表单控件时将 short_Excel2007 切换到设计模式。
        /// </summary>
        public void ToggleFormsDesign()
        {
            _objWorkbook.GetType().InvokeMember("ToggleFormsDesign", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>取消工作表或工作簿的保护。如果工作表或工作簿不是受保护的，则此方法不起作用。
        /// </summary>
        /// <param name="Password">一个字符串，指定用于解除工作表或工作簿保护的密码，此密码是区分大小写的。如果工作表或工作簿不设密码保护，则省略此参数。如果对工作表省略此参数，而该工作表又设有密码保护，Microsoft Excel 将提示您输入密码。如果对工作簿省略此参数，而该工作簿又设有密码保护，则该方法将失效。</param>
        public void Unprotect(string Password = null)
        {
            _objaParameters = new object[1] {
                Password == null ? System.Type.Missing : Password
            };

            _objWorkbook.GetType().InvokeMember("Unprotect", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>关闭共享保护功能并保存工作簿。
        /// </summary>
        /// <param name="SharingPassword">工作簿密码。</param>
        public void UnprotectSharing(string SharingPassword = null)
        {
            _objaParameters = new object[1] {
                SharingPassword == null ? System.Type.Missing : SharingPassword
            };

            _objWorkbook.GetType().InvokeMember("UnprotectSharing", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>如果磁盘上的工作簿版本比内存中的当前工作簿副本新，则用磁盘上保存的工作簿文件更新只读工作簿。如果载入工作簿之后，磁盘上的副本无改变，则不必重新载入内存中的副本。
        /// </summary>
        public void UpdateFromFile()
        {
            _objWorkbook.GetType().InvokeMember("UpdateFromFile", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>更新 Microsoft Excel 链接、DDE 链接或 OLE 链接。
        /// </summary>
        /// <param name="Name">要更新的 Microsoft Excel 或 DDE/OLE 链接的名称（从 LinkSources 方法返回）。</param>
        /// <param name="Type">指定链接类型的 XlLinkType 常量之一。</param>
        public void UpdateLink(string Name = null, XlLinkType? Type = null)
        {
            _objaParameters = new object[2] {
                Name == null ? System.Type.Missing : Name,
                Type == null ? System.Type.Missing : Type
            };

            _objWorkbook.GetType().InvokeMember("UpdateLink", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>以网页的形式显示对指定工作簿的预览。
        /// </summary>
        public void WebPagePreview()
        {
            _objWorkbook.GetType().InvokeMember("WebPagePreview", BindingFlags.InvokeMethod, null, _objWorkbook, null);
        }

        /// <summary>将 XML 数据文件导入当前工作簿。
        /// </summary>
        /// <param name="Url">XML 数据文件的统一资源定位符 (URL) 或通用命名约定 (UNC) 路径。</param>
        /// <param name="ImportMap">导入文件时要应用的架构映射。如果以前导入过该数据，则包含对 XmlMap 对象（包含该数据）的引用。</param>
        /// <param name="Overwrite">如果未指定 Destination 参数的值，则该参数将指定是否覆盖已映射到在 ImportMap 参数中指定的架构映射的数据。设置为 True 将覆盖数据，设置为 False 将把新数据追加到现有数据中。默认值为 True。如果指定了 Destination 参数的值，则该参数将指定是否覆盖现有数据。设置为 True 将覆盖现有数据，设置为 False 将在数据要被覆盖时取消导入。默认值为 True。</param>
        /// <param name="Destination">指定将在其中创建列表的区域。只能使用区域的左上角。</param>
        public XlXmlImportResult XmlImport(string Url, XmlMap ImportMap, bool? Overwrite = null, object Destination = null)
        {
            _objaParameters = new object[4] {
                Url,
                ImportMap,
                Overwrite == null ? System.Type.Missing : Overwrite,
                Destination == null ? System.Type.Missing : Destination
            };

            return (XlXmlImportResult)_objWorkbook.GetType().InvokeMember("XmlImport", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        /// <summary>导入先前已被加载到内存的 XML 数据流。Excel 使用找到的第一个符合需要的映射；如果未指定目标区域，则 Excel 将自动列出该数据。
        /// </summary>
        /// <param name="Data">要导入的数据。</param>
        /// <param name="ImportMap">导入文件时要应用的架构映射。</param>
        /// <param name="Overwrite">如果未指定 Destination 参数的值，则该参数将指定是否覆盖已映射到在 ImportMap 参数中指定的架构映射的数据。设置为 True 将覆盖数据，设置为 False 将把新数据追加到现有数据中。默认值为 True。如果指定了 Destination 参数的值，则该参数将指定是否覆盖现有数据。设置为 True 将覆盖现有数据，设置为 False 将在数据要被覆盖时取消导入。默认值为 True。</param>
        /// <param name="Destination">指定将在其中创建列表的区域。Excel 只使用该区域的左上角。</param>
        public XlXmlImportResult XmlImportXml(string Data, XmlMap ImportMap, bool? Overwrite = null, object Destination = null)
        {
            _objaParameters = new object[4] {
                Data,
                ImportMap,
                Overwrite == null ? System.Type.Missing : Overwrite,
                Destination == null ? System.Type.Missing : Destination
            };

            return (XlXmlImportResult)_objWorkbook.GetType().InvokeMember("XmlImportXml", BindingFlags.InvokeMethod, null, _objWorkbook, _objaParameters);
        }

        #endregion 方法
    }

    /// <summary>指定的或活动工作簿中所有 Worksheet 对象的集合。每个 Worksheet 对象都代表一个工作表。
    /// 说明：
    /// Worksheet 对象也是 Sheets 集合的成员。Sheets 集合包含工作簿中所有的工作表（图表工作表和工作表）。
    /// </summary>
    public class Worksheets
    {
        public object _objWorksheets;
        internal object[] _objaParameters;

        public Worksheet this[object Index]
        {
            get
            {
                object objWorksheet = _objWorksheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objWorksheets, new object[1] { Index });

                if (objWorksheet == null)
                    return null;
                else
                    return new Worksheet(objWorksheet);
            }
        }

        public Worksheets(object objWorksheets)
        {
            _objWorksheets = objWorksheets;
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWorksheets.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWorksheets, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objWorksheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objWorksheets, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWorksheets.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWorksheets, null); }
        }

        /// <summary>返回一个 HPageBreaks 集合，它代表工作表上的水平分页符。只读。
        /// </summary>
        public HPageBreaks HPageBreaks
        {
            get { return new HPageBreaks(_objWorksheets.GetType().InvokeMember("HPageBreaks", BindingFlags.GetProperty, null, _objWorksheets, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWorksheets.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWorksheets, null); }
        }

        /// <summary>返回或设置一个 Variant 值，它确定对象是否可见。
        /// </summary>
        public bool Visible
        {
            get { return (bool)_objWorksheets.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objWorksheets, null); }
            set { _objWorksheets.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objWorksheets, new object[1] { value }); }
        }

        /// <summary>返回一个 VPageBreaks 集合，它代表工作表上的垂直分页符。只读。
        /// </summary>
        public VPageBreaks VPageBreaks
        {
            get { return new VPageBreaks(_objWorksheets.GetType().InvokeMember("VPageBreaks", BindingFlags.GetProperty, null, _objWorksheets, null)); }
        }
        #endregion 属性

        #region 函数
        /// <summary>新建工作表。新建的工作表将成为活动工作表。
        /// </summary>
        /// <param name="Before">指定工作表的对象，新建的工作表将置于此工作表之前。</param>
        /// <param name="After">指定工作表的对象，新建的工作表将置于此工作表之后。</param>
        /// <param name="Count">要添加的工作表数。默认值为 1。</param>
        /// <returns>一个 Worksheet 值，它代表新的工作表、图表或宏表。</returns>
        public Worksheet AddWorksheet(Worksheet Before = null, Worksheet After = null, int? Count = null)
        {
            _objaParameters = new object[4] { 
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet,
                Count == null ? System.Type.Missing : Count,
                System.Type.Missing
            };
            object objWorksheet = _objWorksheets.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
            Worksheet retVal = new Worksheet(objWorksheet);

            return retVal;
        }

        /// <summary>新建工作表、图表或宏表。新建的工作表将成为活动工作表。
        /// </summary>
        /// <param name="Before">指定工作表的对象，新建的工作表将置于此工作表之前。</param>
        /// <param name="After">指定工作表的对象，新建的工作表将置于此工作表之后。</param>
        /// <param name="Count">要添加的工作表数。默认值为 1。</param>
        /// <param name="Type">指定工作表类型。可以为下列 XlSheetType 常量之一：xlWorksheet、xlChart、xlExcel4MacroSheet 或 xlExcel4IntlMacroSheet。如果基于现有模板插入工作表，则指定该模板的路径。默认值为 xlWorksheet。</param>
        /// <returns>一个 Worksheet 值，它代表新的工作表、图表或宏表。</returns>
        public dynamic Add(object Before = null, object After = null, int? Count = null, object Type = null)
        {
            _objaParameters = new object[4] {
                Before == null ? System.Type.Missing : Before,
                After == null ? System.Type.Missing : After,
                Count == null ? System.Type.Missing : Count,
                Type == null ? System.Type.Missing : Type
            };

            return _objWorksheets.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>将工作表复制到工作簿的另一位置。
        /// 说明：
        /// 如果既不指定 Before 也不指定 After，则 Microsoft Excel 将新建一个工作簿，其中包含复制的工作表。
        /// </summary>
        /// <param name="Before">将要在其之前放置所复制工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所复制工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Copy(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objWorksheets.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objWorksheets.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objWorksheets, null);
        }

        /// <summary>将单元格区域复制到集合中所有其他工作表的同一位置。
        /// </summary>
        /// <param name="Range">要填充到集合中所有工作表上的单元格区域。该区域必须来自集合中的某个工作表。</param>
        /// <param name="Type">指定如何复制区域。</param>
        public void FillAcrossSheets(Range Range, XlFillWith Type = XlFillWith.xlFillWithAll)
        {
            _objaParameters = new object[2] { Range._objRange, Type };

            _objWorksheets.GetType().InvokeMember("FillAcrossSheets", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>将工作表移到工作簿中的其他位置。
        /// </summary>
        /// <param name="Before">在其之前放置移动工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">在其之后放置移动工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Move(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objWorksheets.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        /// <param name="IgnorePrintAreas">如果为 True，则忽略打印区域并打印整个对象。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorksheets.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorksheets.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] {
                EnableChanges == null ? System.Type.Missing : EnableChanges
            };

            _objWorksheets.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] {
                Replace == null ? System.Type.Missing : Replace
            };

            _objWorksheets.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objWorksheets, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>代表一个工作表。
    /// 说明：
    /// Worksheet 对象是 Worksheets 集合的成员。Worksheets 集合包含某个工作簿中所有的 Worksheet 对象。
    /// Worksheet 对象也是 Sheets 集合的成员。Sheets 集合包含工作簿中所有的工作表（图表工作表和工作表）。
    /// </summary>
    public class Worksheet
    {
        public object _objWorksheet;
        internal object[] _objaParameters;

        public Worksheet(object objWorksheet)
        {
            _objWorksheet = objWorksheet;
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWorksheet.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>如果筛选已打开，则返回一个 AutoFilter 对象。只读。
        /// </summary>
        public AutoFilter AutoFilter
        {
            get { return new AutoFilter(_objWorksheet.GetType().InvokeMember("AutoFilter", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>如果当前在工作表上显示有“自动筛选”下拉箭头，则该值为 True。本属性与 FilterMode 属性互相独立。Boolean 类型，可读写。
        /// </summary>
        public bool AutoFilterMode
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("AutoFilterMode", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("AutoFilterMode", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表工作表中的所有单元格（不仅仅是当前使用的单元格）。
        /// </summary>
        public Range Cells
        {
            get { return new Range(_objWorksheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示工作表上包含第一个循环引用的区域，或返回 Nothing（如果工作表上没有循环引用）。在继续执行计算之前，必须删除循环引用。
        /// </summary>
        public Range CircularReference
        {
            // 有 Nothing
            get { return new Range(_objWorksheet.GetType().InvokeMember("CircularReference", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回对象的代码名。String 型，只读。
        /// </summary>
        public string CodeName
        {
            get { return _objWorksheet.GetType().InvokeMember("CodeName", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
        }

        /// <summary>返回一个 Range 对象，它代表活动工作表中的所有列。如果活动文档不是工作表，则 Columns 属性失效。
        /// </summary>
        public Range Columns
        {
            get { return new Range(_objWorksheet.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回一个 Comments 集合，该集合表示指定工作表的所有注释。只读。
        /// </summary>
        public Comments Comments
        {
            get { return new Comments(_objWorksheet.GetType().InvokeMember("Comments", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回当前合并计算所使用的函数代码。可以是 XlConsolidationFunction 常量之一。Long 类型，只读。
        /// </summary>
        public XlConsolidationFunction ConsolidationFunction
        {
            get { return (XlConsolidationFunction)_objWorksheet.GetType().InvokeMember("ConsolidationFunction", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回表示合并计算选项的三元素数组，如下表所示。某元素为 True 就表示设置了该选项。Variant 类型，只读。
        /// </summary>
        public dynamic ConsolidationOptions
        {
            get { return _objWorksheet.GetType().InvokeMember("ConsolidationOptions", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回一个字符串数组，这些字符串是工作表中当前合并计算的数据源的名称。如果工作表中没有合并计算，将返回 Empty。Variant 类型，只读。
        /// </summary>
        public string[] ConsolidationSources
        {
            get { return (string[])_objWorksheet.GetType().InvokeMember("ConsolidationSources", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWorksheet.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回一个 CustomProperties 对象，该对象表示与工作表相关的标识符信息。
        /// </summary>
        public CustomProperties CustomProperties
        {
            get { return new CustomProperties(_objWorksheet.GetType().InvokeMember("CustomProperties", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>
        /// </summary>
        public bool DisplayAutomaticPageBreaks
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("DisplayAutomaticPageBreaks", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("DisplayAutomaticPageBreaks", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果显示指定工作表中的分页符（包括自动和手动分页符），则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayPageBreaks
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("DisplayPageBreaks", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("DisplayPageBreaks", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果指定工作表是从右到左显示（而非从左到右），则为 True。如果对象从左到右显示，则为 False。Boolean 类型，只读。
        /// </summary>
        public bool DisplayRightToLeft
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("DisplayRightToLeft", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("DisplayRightToLeft", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果当仅限于用户界面保护处于打开状态时，启用自动筛选箭头，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableAutoFilter
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("EnableAutoFilter", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnableAutoFilter", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果在必要的情况下 Microsoft Excel 自动重新计算工作表，则该值为 True。如果 Excel 不重新计算工作表，则该值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool EnableCalculation
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("EnableCalculation", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnableCalculation", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回或设置是否在需要时自动计算条件格式。可读/写 Boolean 类型。
        /// </summary>
        public bool EnableFormatConditionsCalculation
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("EnableFormatConditionsCalculation", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnableFormatConditionsCalculation", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果当仅限于用户界面保护处于打开状态时，启用分级显示符号，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableOutlining
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("EnableOutlining", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnableOutlining", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果当仅限于用户界面保护处于打开状态时，启用数据透视表控件和操作，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnablePivotTable
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("EnablePivotTable", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnablePivotTable", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回或设置工作表中可被选择的内容。XlEnableSelection 类型，可读写。
        /// </summary>
        public XlEnableSelection EnableSelection
        {
            get { return (XlEnableSelection)_objWorksheet.GetType().InvokeMember("EnableSelection", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("EnableSelection", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果工作表处于筛选模式，则为 True。只读 Boolean 类型。
        /// </summary>
        public bool FilterMode
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("FilterMode", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回一个 HPageBreaks 集合，它代表工作表上的水平分页符。只读。
        /// </summary>
        public HPageBreaks HPageBreaks
        {
            get { return new HPageBreaks(_objWorksheet.GetType().InvokeMember("HPageBreaks", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回 Hyperlinks 集合，它代表区域的超链接。
        /// </summary>
        public Hyperlinks Hyperlinks
        {
            get { return new Hyperlinks(_objWorksheet.GetType().InvokeMember("Hyperlinks", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回 Long 值，它代表对象在其同类对象所组成的集合内的索引号。
        /// </summary>
        public int Index
        {
            get { return (int)_objWorksheet.GetType().InvokeMember("Index", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回工作表中 ListObject 对象的集合。ListObjects 集合，只读。
        /// </summary>
        public ListObjects ListObjects
        {
            get { return new ListObjects(_objWorksheet.GetType().InvokeMember("ListObjects", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>代表文档的电子邮件标题。
        /// </summary>
        public MsoEnvelope MailEnvelope
        {
            get { return new MsoEnvelope(_objWorksheet.GetType().InvokeMember("MailEnvelope", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回或设置一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objWorksheet.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个 Names 集合，它代表所有特定于工作表的名称（使用“WorksheetName!”前缀定义的名称）。Names 对象，只读。
        /// </summary>
        public Names Names
        {
            get { return new Names(_objWorksheet.GetType().InvokeMember("Names", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回代表下一个工作表的 Worksheet 对象。
        /// </summary>
        public Worksheet Next
        {
            get { return new Worksheet(_objWorksheet.GetType().InvokeMember("Next", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>
        /// </summary>
        public string OnCalculate
        {
            get { return _objWorksheet.GetType().InvokeMember("OnCalculate", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnCalculate", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnData
        {
            get { return _objWorksheet.GetType().InvokeMember("OnData", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnData", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnDoubleClick
        {
            get { return _objWorksheet.GetType().InvokeMember("OnDoubleClick", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnDoubleClick", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnEntry
        {
            get { return _objWorksheet.GetType().InvokeMember("OnEntry", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnEntry", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetActivate
        {
            get { return _objWorksheet.GetType().InvokeMember("OnSheetActivate", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnSheetActivate", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetDeactivate
        {
            get { return _objWorksheet.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个 Outline 对象，该对象表示指定工作表的分级显示。只读。
        /// </summary>
        public Outline Outline
        {
            get { return new Outline(_objWorksheet.GetType().InvokeMember("Outline", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回一个 PageSetup 对象，它包含用于指定对象的所有页面设置。只读。
        /// </summary>
        public PageSetup PageSetup
        {
            get { return new PageSetup(_objWorksheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWorksheet.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回代表下一个工作表的 Worksheet 对象。
        /// </summary>
        public Worksheet Previous
        {
            get { return new Worksheet(_objWorksheet.GetType().InvokeMember("Previous", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>如果工作表内容是受保护的，则为 True。此属性保护单独的单元格。要打开内容保护，请使用 Protect 方法，并将 Contents 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectContents
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("ProtectContents", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>如果形状是受保护的，则为 True。要打开形状保护，请使用 Protect 方法，并将 DrawingObjects 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectDrawingObjects
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("ProtectDrawingObjects", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回一个 Protection 对象，该对象表示工作表的保护选项。
        /// </summary>
        public Protection Protection
        {
            get { return new Protection(_objWorksheet.GetType().InvokeMember("Protection", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>如果启用了用户界面专用保护，则为 True。要打开用户界面保护，请使用 Protect 方法，并将 UserInterfaceOnly 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectionMode
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("ProtectionMode", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>如果工作表的方案处于保护状态，则该属性值为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectScenarios
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("ProtectScenarios", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回 QueryTables 集合，该集合表示指定工作表上的所有查询表。只读。
        /// </summary>
        public QueryTables QueryTables
        {
            get { return new QueryTables(_objWorksheet.GetType().InvokeMember("QueryTables", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回一个 Range 对象，它代表指定工作表中的所有行。Range 对象，只读。
        /// </summary>
        public Range Rows
        {
            get { return new Range(_objWorksheet.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>以 A1 样式的区域引用形式返回或设置允许滚动的区域。用户不能选定滚动区域之外的单元格。String 类型，可读写。
        /// </summary>
        public string ScrollArea
        {
            get { return _objWorksheet.GetType().InvokeMember("ScrollArea", BindingFlags.GetProperty, null, _objWorksheet, null).ToString(); }
            set { _objWorksheet.GetType().InvokeMember("ScrollArea", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个 Shapes 集合，它代表工作表上的所有形状。只读。
        /// </summary>
        public Shapes Shapes
        {
            get { return new Shapes(_objWorksheet.GetType().InvokeMember("Shapes", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回一个 SmartTags 对象，它代表指定单元格的标识符。
        /// </summary>
        public SmartTags SmartTags
        {
            get { return new SmartTags(_objWorksheet.GetType().InvokeMember("SmartTags", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>在当前工作表中返回经过排序的值。只读。
        /// </summary>
        public Sort Sort
        {
            get { return new Sort(_objWorksheet.GetType().InvokeMember("Sort", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>以磅为单位返回工作表中所有行的标准高度（默认值）。Double 类型，只读。
        /// </summary>
        public double StandardHeight
        {
            get { return (double)_objWorksheet.GetType().InvokeMember("StandardHeight", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回或设置工作表中所有列的标准列宽（默认值）。Double 类型，可读写。
        /// </summary>
        public double StandardWidth
        {
            get { return (double)_objWorksheet.GetType().InvokeMember("StandardWidth", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("StandardWidth", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 对工作表使用 Lotus 1-2-3 的表达式求值规则，则该属性的值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool TransitionExpEval
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("TransitionExpEval", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("TransitionExpEval", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>如果 Microsoft Excel 对工作表使用 Lotus 1-2-3 的公式输入规则，则该属性的值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool TransitionFormEntry
        {
            get { return (bool)_objWorksheet.GetType().InvokeMember("TransitionFormEntry", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("TransitionFormEntry", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个代表工作表类型的 XlSheetType 值。
        /// </summary>
        public XlSheetType Type
        {
            get { return (XlSheetType)_objWorksheet.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objWorksheet, null); }
        }

        /// <summary>返回一个 Range 对象，该对象表示指定工作表上所使用的区域。只读。
        /// </summary>
        public Range UsedRange
        {
            get { return new Range(_objWorksheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }

        /// <summary>返回或设置一个 XlSheetVisibility 值，它确定对象是否可见。
        /// </summary>
        public XlSheetVisibility Visible
        {
            get { return (XlSheetVisibility)_objWorksheet.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objWorksheet, null); }
            set { _objWorksheet.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objWorksheet, new object[1] { value }); }
        }

        /// <summary>返回一个 VPageBreaks 集合，它代表工作表上的垂直分页符。只读。
        /// </summary>
        public VPageBreaks VPageBreaks
        {
            get { return new VPageBreaks(_objWorksheet.GetType().InvokeMember("VPageBreaks", BindingFlags.GetProperty, null, _objWorksheet, null)); }
        }
        #endregion 属性

        #region 函数
        /// <summary>返回一个 Range 对象，它代表一个单元格或单元格区域。
        /// 用法：get_Range("A1")  get_Range("A1:D10")
        /// </summary>
        /// <param name="Cell1">区域名称。必须为采用宏语言的 A1 样式引用。可包括区域操作符（冒号）、相交区域操作符（空格）或合并区域操作符（逗号）。也可包括货币符号，但它们会被忽略掉。您可以在区域中任一部分使用局部定义名称。如果使用名称，则假定该名称使用的是宏语言。</param>
        /// <param name="Cell2">区域左上角和右下角的单元格。可以是一个包含单个单元格、整列或整行的 Range 对象，或者也可以是一个用宏语言为单个单元格命名的字符串。</param>
        /// <returns></returns>
        public Range get_Range(string Cell1, string Cell2 = null)
        {
            _objaParameters = new object[2] { 
                Cell1, 
                Cell2 == null ? System.Type.Missing : Cell2
            };
            object objRange = _objWorksheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, _objWorksheet, _objaParameters);
            return new Range(objRange);
        }
        /// <summary>返回一个 Range 对象，它代表一个单元格或单元格区域。
        /// </summary>
        /// <param name="Cell1">ExcelCell1</param>
        /// <param name="Cell2">ExcelCell2</param>
        /// <returns></returns>
        public Range get_Range(Range Cell1, Range Cell2)
        {
            _objaParameters = new object[2] { 
                Cell1._objRange, 
                Cell2._objRange 
            };
            object objRange = _objWorksheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, _objWorksheet, _objaParameters);
            return new Range(objRange);
        }
        /// <summary>返回一个 Range 对象，它代表一个单元格或单元格区域。
        /// </summary>
        /// <param name="Arg1">区域名称。必须为采用宏语言的 A1 样式引用。可包括区域操作符（冒号）、相交区域操作符（空格）或合并区域操作符（逗号）。也可包括货币符号，但它们会被忽略掉。您可以在区域中任一部分使用局部定义名称。如果使用名称，则假定该名称使用的是宏语言。</param>
        /// <param name="Arg2">区域左上角和右下角的单元格。可以是一个包含单个单元格、整列或整行的 Range 对象，或者也可以是一个用宏语言为单个单元格命名的字符串。</param>
        /// <returns></returns>
        public Range get_RangeCell(string Arg1, string Arg2)
        {
            _objaParameters = new object[2] { Arg1, Arg2 };
            object objRange = _objWorksheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objWorksheet, _objaParameters);
            return new Range(objRange);
        }

        /// <summary>使当前工作表成为活动工作表。
        /// </summary>
        public void Activate()
        {
            _objWorksheet.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>计算所有打开的工作簿、工作簿中的某张特定工作表或工作表指定区域中的单元格，如下表所示。
        /// </summary>
        public void Calculate()
        {
            _objWorksheet.GetType().InvokeMember("Calculate", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>返回一个对象，它代表工作表上的一个嵌入式图表（ChartObject 对象）或所有嵌入式图表的集合（ChartObjects 对象）。
        /// </summary>
        /// <param name="Index">图表的名称或号码。该参数可以是数组，用于指定多个图表。</param>
        public dynamic ChartObjects(object Index = null)
        {
            _objaParameters = new object[1] {
                Index == null ? System.Type.Missing : Index
            };

            return _objWorksheet.GetType().InvokeMember("ChartObjects", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>检查对象的拼写。
        /// </summary>
        /// <param name="CustomDictionary">一个字符串，它表示自定义词典的文件名，如果在主词典中找不到单词，则会到此词典中查找。如果省略此参数，则使用当前指定的词典。</param>
        /// <param name="IgnoreUppercase">如果为 True，则 Microsoft Excel 忽略所有字母都是大写的单词。如果为 False，则 Microsoft Excel 检查所有字母都是大写的单词。如果省略此参数，将使用当前的设置。</param>
        /// <param name="AlwaysSuggest">如果为 True，则 Microsoft Excel 在找到不正确拼写时显示建议的替换拼写列表。如果为 False，Microsoft Excel 将等待输入正确的拼写。如果省略此参数，将使用当前的设置。</param>
        /// <param name="SpellLang">当前所用词典的语言。它可以是由 LanguageID 属性使用的 MsoLanguageID 值之一。</param>
        public void CheckSpelling(string CustomDictionary = null, bool? IgnoreUppercase = null, bool? AlwaysSuggest = null, MsoLanguageID? SpellLang = null)
        {
            _objaParameters = new object[4] {
                CustomDictionary == null ? System.Type.Missing : CustomDictionary,
                IgnoreUppercase == null ? System.Type.Missing : IgnoreUppercase,
                AlwaysSuggest == null ? System.Type.Missing : AlwaysSuggest,
                SpellLang == null ? System.Type.Missing : SpellLang
            };

            _objWorksheet.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>对工作表中的无效数据项进行圈释。
        /// </summary>
        public void CircleInvalid()
        {
            _objWorksheet.GetType().InvokeMember("CircleInvalid", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>清除指定工作表的追踪箭头。使用审核功能可添加追踪箭头。
        /// </summary>
        public void ClearArrows()
        {
            _objWorksheet.GetType().InvokeMember("ClearArrows", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>清除指定工作表的无效数据项的圈释。
        /// </summary>
        public void ClearCircles()
        {
            _objWorksheet.GetType().InvokeMember("ClearCircles", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>将工作表复制到工作簿的另一位置。
        /// 说明：
        /// 如果既不指定 Before 也不指定 After，则 Microsoft Excel 将新建一个工作簿，其中包含复制的工作表。
        /// </summary>
        /// <param name="Before">将要在其之前放置所复制工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所复制工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Copy(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objWorksheet.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objWorksheet.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>将一个 Microsoft Excel 名称转换为一个对象或者一个值。
        /// </summary>
        /// <param name="Name">使用 Microsoft Excel 命名约定的对象名称。</param>
        public dynamic Evaluate(string Name)
        {
            _objaParameters = new object[1] { Name };

            return _objWorksheet.GetType().InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>导出为指定格式的文件。
        /// </summary>
        /// <param name="Type">要导出为的文件格式类型。</param>
        /// <param name="Filename">要保存的文件的文件名。可以包括完整路径，否则 Excel 2007 会将文件保存在当前文件夹中。</param>
        /// <param name="Quality">可选 XlFixedFormatQuality。指定已发布文件的质量。</param>
        /// <param name="IncludeDocProperties">若要包括文档属性，则为 True；否则为 False。</param>
        /// <param name="IgnorePrintAreas">若要忽略发布时设置的任何打印区域，则为 True；否则为 False。</param>
        /// <param name="From">发布的起始页码。如果省略此参数，则从起始位置开始发布。</param>
        /// <param name="To">发布的终止页码。如果省略此参数，则发布至最后一页。</param>
        /// <param name="OpenAfterPublish">若要在发布文件后在查看器中显示文件，则为 True；否则为 False。</param>
        /// <param name="FixedFormatExtClassPtr">Pointer to the FixedFormatExt class.</param>
        public void ExportAsFixedFormat(XlFixedFormatType Type, string Filename = null, XlFixedFormatQuality? Quality = null, bool? IncludeDocProperties = null, bool? IgnorePrintAreas = null, int? From = null, int? To = null, bool? OpenAfterPublish = null, object FixedFormatExtClassPtr = null)
        {
            _objaParameters = new object[9] {
                Type,
                Filename == null ? System.Type.Missing : Filename,
                Quality == null ? System.Type.Missing : Quality,
                IncludeDocProperties == null ? System.Type.Missing : IncludeDocProperties,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas,
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                OpenAfterPublish == null ? System.Type.Missing : OpenAfterPublish,
                FixedFormatExtClassPtr == null ? System.Type.Missing : FixedFormatExtClassPtr
            };

            _objWorksheet.GetType().InvokeMember("ExportAsFixedFormat", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>将工作表移到工作簿中的其他位置。
        /// </summary>
        /// <param name="Before">在其之前放置移动工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">在其之后放置移动工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Move(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objWorksheet.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>返回一个对象，它代表图表或工作表上的单个 OLE 对象 (OLEObject) 或所有 OLE 对象的集合（OLEObjects 集合）。只读。
        /// </summary>
        /// <param name="Index">OLE 对象的名称或编号。</param>
        public dynamic OLEObjects(object Index = null)
        {
            _objaParameters = new object[1] {
                Index == null ? System.Type.Missing : Index
            };

            return _objWorksheet.GetType().InvokeMember("OLEObjects", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>将“剪贴板”中的内容粘贴到工作表上。
        /// </summary>
        /// <param name="Destination">一个 Range 对象，指定用于粘贴剪贴板中内容的目标区域。如果省略此参数，就使用当前的选定区域。仅当剪贴板中的内容能被粘贴到某区域时，才能指定此参数。如果指定了此参数，则不能使用 Link 参数。</param>
        /// <param name="Link">如果为 True，则链接到被粘贴数据的源。如果指定此参数，则不能使用 Destination 参数。默认值是 False。</param>
        public void Paste(Range Destination = null, bool? Link = null)
        {
            _objaParameters = new object[2] {
                Destination == null ? System.Type.Missing : Destination._objRange,
                Link == null ? System.Type.Missing : Link
            };

            _objWorksheet.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>以指定格式将剪贴板中的内容粘贴到工作表上。可用本方法从其他应用程序中粘贴数据，或以特定格式粘贴数据。
        /// </summary>
        /// <param name="Format">指定数据的剪贴板格式的字符串。</param>
        /// <param name="Link">如果为 True，则链接到被粘贴数据的源。如果源数据不适于链接，或源应用程序不支持链接，将忽略此参数。默认值是 False。</param>
        /// <param name="DisplayAsIcon">如果为 True，则将粘贴内容显示为图标。默认值是 False。</param>
        /// <param name="IconFileName">如果 DisplayAsIcon 为 True，则指定包含所用图标的文件名。</param>
        /// <param name="IconIndex">图标文件内的图标索引号。</param>
        /// <param name="IconLabel">图标的文本标签。</param>
        /// <param name="NoHTMLFormatting">如果为 True，则从 HTML 中删除所有的格式设置、超链接和图像。如果为 False，则完整粘贴 HTML。默认值是 False。</param>
        public void PasteSpecial(string Format = null, bool? Link = null, bool? DisplayAsIcon = null, string IconFileName = null, int? IconIndex = null, string IconLabel = null, bool? NoHTMLFormatting = null)
        {
            _objaParameters = new object[7] {
                Format == null ? System.Type.Missing : Format,
                Link == null ? System.Type.Missing : Link,
                DisplayAsIcon == null ? System.Type.Missing : DisplayAsIcon,
                IconFileName == null ? System.Type.Missing : IconFileName,
                IconIndex == null ? System.Type.Missing : IconIndex,
                IconLabel == null ? System.Type.Missing : IconLabel,
                NoHTMLFormatting == null ? System.Type.Missing : NoHTMLFormatting
            };

            _objWorksheet.GetType().InvokeMember("PasteSpecial", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Pictures(object Index = null)
        {
            _objaParameters = new object[1] {
                Index == null ? System.Type.Missing : Index
            };

            return _objWorksheet.GetType().InvokeMember("Pictures", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>返回一个对象，该对象表示工作表上的单个数据透视表（PivotTable 对象）或所有数据透视表的集合（PivotTables 对象）。只读。
        /// </summary>
        /// <param name="Index">报表的名称或编号。</param>
        public dynamic PivotTables(object Index = null)
        {
            _objaParameters = new object[1] {
                Index == null ? System.Type.Missing : Index
            };

            return _objWorksheet.GetType().InvokeMember("PivotTables", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>创建一个新的数据透视表。此方法不显示“数据透视表向导”，它不适用于 OLE DB 数据源。请使用 Add 方法添加数据透视表缓存，然后创建基于该缓存的数据透视表。
        /// </summary>
        /// <param name="SourceType">一个代表报表数据源的 XlPivotTableSourceType 值。如果指定了此参数，那么必须同时指定 SourceData。如果忽略 SourceType 和 SourceData，Microsoft Excel 将假定源类型为 xlDatabase，并假定源数据来自命名区域“Database”。如果该命名区域不存在，那么当选定区域所在的当前区域中包含数据的单元格超过 10 个时，Microsoft Excel 就使用当前区域。否则，此方法将失败。</param>
        /// <param name="SourceData">新报表的数据。它可以是一个 Range 对象、一个区域数组或是代表其他报表名称的一个文本常量。对于外部数据库而言，SourceData 是一个包含 SQL 查询字符串的字符串数组，其中的每个元素最长为 255 个字符。您应该使用 Connection 参数指定 ODBC 连接字符串。为了能与旧版本的 Excel 兼容，SourceData 可以是一个二元数组。第一个元素是用于指定数据的 ODBC 源的连接字符串，第二个元素是用于获取数据的 SQL 查询字符串。如果指定 SourceData，则必须同时指定 SourceType。如果活动单元格位于 SourceData 区域内，则必须同时指定 TableDestination。</param>
        /// <param name="TableDestination">一个 Range 对象，它指定报表在工作表中的位置。如果省略此参数，则将报表置于活动单元格中。</param>
        /// <param name="TableName">用于指定新报表名称的字符串。</param>
        /// <param name="RowGrand">如果为 True，则显示报表中的行总计。</param>
        /// <param name="ColumnGrand">如果为 True，则显示报表中的列总计。</param>
        /// <param name="SaveData">如果为 True，则保存报表中的数据。如果为 False，则仅保存报表的定义。</param>
        /// <param name="HasAutoFormat">如果为 True，当刷新报表或移动字段时，Microsoft Excel 将自动设置其格式。</param>
        /// <param name="AutoPage">仅当 SourceType 为 xlConsolidation 时有效。如果值为 True，Microsoft Excel 将为合并创建页字段。如果 AutoPage 为 False，则必须创建一个或多个页字段。</param>
        /// <param name="Reserved">不在 Microsoft Excel 中使用。</param>
        /// <param name="BackgroundQuery">如果为 True，则 Excel 将异步执行（后台执行）报表查询。默认值为 False。</param>
        /// <param name="OptimizeCache">如果为 True，则在构造数据透视表的缓存时对其进行优化。默认值为 False。</param>
        /// <param name="PageFieldOrder">在数据透视表布局中添加页字段的顺序。可为以下 XlOrder 常量之一：xlDownThenOver 或 xlOverThenDown。默认值为 xlDownThenOver。</param>
        /// <param name="PageFieldWrapCount">数据透视表中每列或每行的页字段数。默认值为 0（零）。</param>
        /// <param name="ReadData">如果为 True，则创建数据透视表缓存以包含外部数据库中的所有记录；此时缓存可能会很大。如果 ReadData 为 False，则可在实际读取数据之前，将某些字段设为基于服务器的页字段。</param>
        /// <param name="Connection">包含 ODBC 设置的字符串，这些设置使得 Excel 可以连接 ODBC 数据源。连接字符串的格式为“ODBC;<连接字符串>”。该参数取代以前为 PivotCache 对象的 Connection 属性所做的任何设置。</param>
        public PivotTable PivotTableWizard(XlPivotTableSourceType? SourceType = null, object SourceData = null, Range TableDestination = null, string TableName = null, bool? RowGrand = null, bool? ColumnGrand = null, bool? SaveData = null, bool? HasAutoFormat = null, bool? AutoPage = null, object Reserved = null, bool? BackgroundQuery = null, bool? OptimizeCache = null, XlOrder? PageFieldOrder = null, int? PageFieldWrapCount = null, bool? ReadData = null, string Connection = null)
        {
            _objaParameters = new object[16] {
                SourceType == null ? System.Type.Missing : SourceType,
                SourceData == null ? System.Type.Missing : SourceData,
                TableDestination == null ? System.Type.Missing : TableDestination._objRange,
                TableName == null ? System.Type.Missing : TableName,
                RowGrand == null ? System.Type.Missing : RowGrand,
                ColumnGrand == null ? System.Type.Missing : ColumnGrand,
                SaveData == null ? System.Type.Missing : SaveData,
                HasAutoFormat == null ? System.Type.Missing : HasAutoFormat,
                AutoPage == null ? System.Type.Missing : AutoPage,
                Reserved == null ? System.Type.Missing : Reserved,
                BackgroundQuery == null ? System.Type.Missing : BackgroundQuery,
                OptimizeCache == null ? System.Type.Missing : OptimizeCache,
                PageFieldOrder == null ? System.Type.Missing : PageFieldOrder,
                PageFieldWrapCount == null ? System.Type.Missing : PageFieldWrapCount,
                ReadData == null ? System.Type.Missing : ReadData,
                Connection == null ? System.Type.Missing : Connection
            };

            return new PivotTable(_objWorksheet.GetType().InvokeMember("PivotTableWizard", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters));
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        /// <param name="IgnorePrintAreas">如果为 True，则忽略打印区域并打印整个对象。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, string PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorksheet.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(object From = null, object To = null, object Copies = null, object Preview = null, object ActivePrinter = null, object PrintToFile = null, object Collate = null, object PrToFileName = null, object IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objWorksheet.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] {
                EnableChanges == null ? System.Type.Missing : EnableChanges
            };

            _objWorksheet.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>保护工作表使其不能被修改。
        /// </summary>
        /// <param name="Password">一个字符串，该字符串为工作表或工作簿指定区分大小写的密码。如果省略此参数，不用密码就可以取消对工作表或工作簿的保护。否则，必须指定密码才能取消对工作表或工作簿的保护。如果忘记了密码，就无法取消对工作表或工作簿的保护。</param>
        /// <param name="DrawingObjects">如果为 True，则保护形状。默认值是 True。</param>
        /// <param name="Contents">如果为 True，则保护内容。对于图表，这样会保护整个图表。对于工作表，这样会保护锁定的单元格。默认值是 True。</param>
        /// <param name="Scenarios">如果为 True，则保护方案。此参数仅对工作表有效。默认值是 True。</param>
        /// <param name="UserInterfaceOnly">如果为 True，则保护用户界面，但不保护宏。如果省略此参数，则既保护宏也保护用户界面。</param>
        /// <param name="AllowFormattingCells">如果为 True，则允许用户为受保护的工作表上的任意单元格设置格式。默认值是 False。</param>
        /// <param name="AllowFormattingColumns">如果为 True，则允许用户为受保护的工作表上的任意列设置格式。默认值是 False。</param>
        /// <param name="AllowFormattingRows">如果为 True，则允许用户为受保护的工作表上的任意行设置格式。默认值是 False。</param>
        /// <param name="AllowInsertingColumns">如果为 True，则允许用户在受保护的工作表上插入列。默认值是 False。</param>
        /// <param name="AllowInsertingRows">如果为 True，则允许用户在受保护的工作表上插入行。默认值是 False。</param>
        /// <param name="AllowInsertingHyperlinks">如果为 True，则允许用户在受保护的工作表中插入超链接。默认值是 False。</param>
        /// <param name="AllowDeletingColumns">如果为 True，则允许用户在受保护的工作表上删除列，要删除的列中的每个单元格都被解除锁定。默认值是 False。</param>
        /// <param name="AllowDeletingRows">如果为 True，则允许用户在受保护的工作表上删除行，要删除的行中的每个单元格都被解除锁定。默认值是 False。</param>
        /// <param name="AllowSorting">如果为 True，则允许用户在受保护的工作表上进行排序。排序区域中的每个单元格必须是解除锁定的或取消保护的。默认值是 False。</param>
        /// <param name="AllowFiltering">如果为 True，则允许用户在受保护的工作表上设置筛选。用户可以更改筛选条件，但是不能启用或禁用自动筛选功能。用户也可以在已有的自动筛选功能上设置筛选。默认值是 False。</param>
        /// <param name="AllowUsingPivotTables">如果为 True，则允许用户在受保护的工作表上使用数据透视表。默认值是 False。</param>
        public void Protect(string Password = null, bool? DrawingObjects = null, object Contents = null, bool? Scenarios = null, bool? UserInterfaceOnly = null, bool? AllowFormattingCells = null, bool? AllowFormattingColumns = null, bool? AllowFormattingRows = null, bool? AllowInsertingColumns = null, bool? AllowInsertingRows = null, bool? AllowInsertingHyperlinks = null, bool? AllowDeletingColumns = null, bool? AllowDeletingRows = null, bool? AllowSorting = null, bool? AllowFiltering = null, bool? AllowUsingPivotTables = null)
        {
            _objaParameters = new object[16] {
                Password == null ? System.Type.Missing : Password,
                DrawingObjects == null ? System.Type.Missing : DrawingObjects,
                Contents == null ? System.Type.Missing : Contents,
                Scenarios == null ? System.Type.Missing : Scenarios,
                UserInterfaceOnly == null ? System.Type.Missing : UserInterfaceOnly,
                AllowFormattingCells == null ? System.Type.Missing : AllowFormattingCells,
                AllowFormattingColumns == null ? System.Type.Missing : AllowFormattingColumns,
                AllowFormattingRows == null ? System.Type.Missing : AllowFormattingRows,
                AllowInsertingColumns == null ? System.Type.Missing : AllowInsertingColumns,
                AllowInsertingRows == null ? System.Type.Missing : AllowInsertingRows,
                AllowInsertingHyperlinks == null ? System.Type.Missing : AllowInsertingHyperlinks,
                AllowDeletingColumns == null ? System.Type.Missing : AllowDeletingColumns,
                AllowDeletingRows == null ? System.Type.Missing : AllowDeletingRows,
                AllowSorting == null ? System.Type.Missing : AllowSorting,
                AllowFiltering == null ? System.Type.Missing : AllowFiltering,
                AllowUsingPivotTables == null ? System.Type.Missing : AllowUsingPivotTables
            };

            _objWorksheet.GetType().InvokeMember("Protect", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>重新设置指定工作表上的所有分页符。
        /// </summary>
        public void ResetAllPageBreaks()
        {
            _objWorksheet.GetType().InvokeMember("ResetAllPageBreaks", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>将对图表或工作表的更改保存到另一不同文件中。
        /// </summary>
        /// <param name="Filename">Variant。一个字符串，表示要保存的文件名。可包含完整路径。如果不指定路径，Microsoft Excel 将文件保存到当前文件夹中。</param>
        /// <param name="FileFormat">保存文件时使用的文件格式。要查看有效的选项列表，请参阅 FileFormat 属性。对于现有文件，默认采用上一次指定的文件格式；对于新文件，默认采用当前所用 Excel 版本的格式。</param>
        /// <param name="Password">它是一个区分大小写的字符串（最长不超过 15 个字符），用于指定文件的保护密码。</param>
        /// <param name="WriteResPassword">一个表示文件写保护密码的字符串。如果文件保存时带有密码，但打开文件时不输入密码，则该文件以只读方式打开。</param>
        /// <param name="ReadOnlyRecommended">如果为 True，则在打开文件时显示一条消息，提示该文件以只读方式打开。</param>
        /// <param name="CreateBackup">如果为 True，则创建备份文件。</param>
        /// <param name="AddToMru">如果为 True，则将该工作簿添加到最近使用的文件列表中。默认值是 False。</param>
        /// <param name="TextCodepage">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="TextVisualLayout">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="Local">如果为 True，则以 Microsoft Excel（包括控制面板设置）的语言保存文件。如果为 False（默认值），则以 Visual Basic for Applications (VBA) 的语言保存文件，其中 Visual Basic for Applications (VBA) （Visual Basic for Applications (VBA)：Microsoft Visual Basic 的宏语言版本，用于编写基于 Microsoft Windows 的应用程序，内置于多个 Microsoft 程序中。） 通常为美国英语版本，除非从中运行 Workbooks.Open 的 VBA 项目是旧的已国际化的 XL5/95 VBA 项目。</param>
        public void SaveAs(string Filename, XlFileFormat? FileFormat = null, string Password = null, string WriteResPassword = null, bool? ReadOnlyRecommended = null, bool? CreateBackup = null, bool? AddToMru = null, object TextCodepage = null, object TextVisualLayout = null, bool? Local = null)
        {
            _objaParameters = new object[10] {
                Filename,
                FileFormat == null ? System.Type.Missing : FileFormat,
                Password == null ? System.Type.Missing : Password,
                WriteResPassword == null ? System.Type.Missing : WriteResPassword,
                ReadOnlyRecommended == null ? System.Type.Missing : ReadOnlyRecommended,
                CreateBackup == null ? System.Type.Missing : CreateBackup,
                AddToMru == null ? System.Type.Missing : AddToMru,
                TextCodepage == null ? System.Type.Missing : TextCodepage,
                TextVisualLayout == null ? System.Type.Missing : TextVisualLayout,
                Local == null ? System.Type.Missing : Local
            };

            _objWorksheet.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>返回一个对象，该对象表示工作簿中的单个方案（Scenario 对象）或方案集合（Scenarios 对象）。
        /// </summary>
        /// <param name="Index">方案名称或方案号。使用数组指定多个方案。</param>
        public dynamic Scenarios(object Index = null)
        {
            _objaParameters = new object[1] {
                Index == null ? System.Type.Missing : Index
            };

            return _objWorksheet.GetType().InvokeMember("Scenarios", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>选择对象。
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        /// </summary>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] {
                Replace == null ? System.Type.Missing : Replace
            };

            _objWorksheet.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>为工作表设置背景图形。
        /// </summary>
        /// <param name="Filename">图形文件名。</param>
        public void SetBackgroundPicture(string Filename)
        {
            _objaParameters = new object[1] { Filename };

            _objWorksheet.GetType().InvokeMember("SetBackgroundPicture", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>使当前筛选列表的所有行均可见。如果正在使用自动筛选，则本方法将下拉列表框内容改为“（全部）”。
        /// </summary>
        public void ShowAllData()
        {
            _objWorksheet.GetType().InvokeMember("ShowAllData", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>显示与指定工作表相关联的数据表单。
        /// </summary>
        public void ShowDataForm()
        {
            _objWorksheet.GetType().InvokeMember("ShowDataForm", BindingFlags.InvokeMethod, null, _objWorksheet, null);
        }

        /// <summary>取消工作表或工作簿的保护。如果工作表或工作簿不是受保护的，则此方法不起作用。
        /// </summary>
        /// <param name="Password">一个字符串，指定用于解除工作表或工作簿保护的密码，此密码是区分大小写的。如果工作表或工作簿不设密码保护，则省略此参数。如果对工作表省略此参数，而该工作表又设有密码保护，Microsoft Excel 将提示您输入密码。如果对工作簿省略此参数，而该工作簿又设有密码保护，则该方法将失效。</param>
        public void Unprotect(string Password = null)
        {
            _objaParameters = new object[1] {
                Password == null ? System.Type.Missing : Password
            };

            _objWorksheet.GetType().InvokeMember("Unprotect", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters);
        }

        /// <summary>返回一个代表映射到特定 XPath 的 Range 对象。如果指定的 XPath 路径尚未映射到工作表，或者映射的区域为空，则返回 Nothing。
        /// </summary>
        /// <param name="XPath">要查询的 XPath。</param>
        /// <param name="SelectionNamespaces">以空格分隔的 String 类型，包含在 XPath 参数中引用的命名空间。如果无法解析某个指定的命名空间，将产生运行时错误。</param>
        /// <param name="Map">如果希望在特定的映射中查询 XPath，请指定一个 XmlMap。</param>
        public Range XmlDataQuery(string XPath, string SelectionNamespaces = null, XmlMap Map = null)
        {
            _objaParameters = new object[3] {
                XPath,
                SelectionNamespaces == null ? System.Type.Missing : SelectionNamespaces,
                Map == null ? System.Type.Missing : Map._objXmlMap
            };

            return new Range(_objWorksheet.GetType().InvokeMember("XmlDataQuery", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters));
        }

        /// <summary>返回一个代表映射到特定 XPath 的 Range 对象。如果指定的 XPath 路径尚未映射到工作表，则返回 Nothing。
        /// </summary>
        /// <param name="XPath">要查询的 XPath。</param>
        /// <param name="SelectionNamespaces">以空格分隔的 String 类型，包含在 XPath 参数中引用的命名空间。如果无法解析某个指定的命名空间，将产生运行时错误。</param>
        /// <param name="Map">如果希望在特定的映射中查询 XPath，请指定 XML 映射。</param>
        public Range XmlMapQuery(string XPath, string SelectionNamespaces = null, XmlMap Map = null)
        {
            _objaParameters = new object[3] {
                XPath,
                SelectionNamespaces == null ? System.Type.Missing : SelectionNamespaces,
                Map == null ? System.Type.Missing : Map._objXmlMap
            };

            return new Range(_objWorksheet.GetType().InvokeMember("XmlMapQuery", BindingFlags.InvokeMethod, null, _objWorksheet, _objaParameters));
        }
        #endregion 函数
    }

    /// <summary>代表某一单元格、某一行、某一列、某一选定区域（该区域可包含一个或若干连续单元格区域），或者某一三维区域。
    /// 说明：
    /// 示例部分中说明了以下用于返回 Range 对象的属性和方法：
    /// Range 属性 
    /// Cells 属性 
    /// Range 和 Cells 
    /// Offset 属性 
    /// Union 方法 
    /// </summary>
    public class Range
    {
        public object _objRange;
        internal object[] _objaParameters;

        public Range this[object RowIndex = null, object ColumnIndex = null]
        {
            get
            {
                if (RowIndex == null && ColumnIndex != null)
                    throw new ArgumentNullException();

                if (RowIndex != null && ColumnIndex != null)
                    if (!RowIndex.GetType().Equals(ColumnIndex.GetType()))
                        throw new Exception("The Type of the 2 argument is not equal.");

                return new Range(this.GetItem(RowIndex, ColumnIndex));
            }
        }

        public Range(object objRange)
        {
            _objRange = objRange;
        }

        #region 属性
        /// <summary>返回或设置一个 Variant 值，它指明当单元格中文本的对齐方式为水平或垂直等距分布时，文本是否为自动缩进。
        /// </summary>
        public dynamic AddIndent
        {
            get { return _objRange.GetType().InvokeMember("AddIndent", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("AddIndent", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Boolean 值，它指明是否可以在受保护的工作表上编辑区。域。
        /// </summary>
        public bool AllowEdit
        {
            get { return (bool)_objRange.GetType().InvokeMember("AllowEdit", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objRange.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Areas 集合，该集合表示多重区域选择中的所有区域。只读。
        /// </summary>
        public Areas Areas
        {
            get { return new Areas(_objRange.GetType().InvokeMember("Areas", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Borders 集合，它代表样式或单元格区域（包括定义为条件格式一部分的区域）的边框。
        /// </summary>
        public Borders Borders
        {
            get { return new Borders(_objRange.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，它代表指定单元格区域中的单元格。
        /// </summary>
        public Range Cells
        {
            get { return new Range(_objRange.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回指定区域中第一块中的第一列的列号。Long 类型，只读。
        /// </summary>
        public int Column
        {
            get { return (int)_objRange.GetType().InvokeMember("Column", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回一个 Range 对象，它代表指定区域中的列。
        /// </summary>
        public Range Columns
        {
            get { return new Range(_objRange.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置指定区域中所有列的列宽。Variant 类型，可读写。
        /// </summary>
        public float ColumnWidth
        {
            get { return (float)_objRange.GetType().InvokeMember("ColumnWidth", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Comment 对象，它代表与区域左上角单元格相关联的批注。
        /// </summary>
        public Comment Comment
        {
            get { return new Comment(_objRange.GetType().InvokeMember("Comment", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objRange.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>在指定区域的值中计算最大值。只读 Variant 类型。
        /// </summary>
        public dynamic CountLarge
        {
            get { return _objRange.GetType().InvokeMember("CountLarge", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objRange.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>如果指定单元格属于数组，则返回一个 Range 对象，该对象表示整个数组。只读。
        /// </summary>
        public Range CurrentArray
        {
            get { return new Range(_objRange.GetType().InvokeMember("CurrentArray", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示当前区域。当前区域是以空行与空列的组合为边界的区域。只读。
        /// </summary>
        public Range CurrentRegion
        {
            get { return new Range(_objRange.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示包含一个单元格所有从属单元格的区域。如果有多个从属单元格，这可能有多个选择（多个 Range 对象）。Range 类型，只读。
        /// </summary>
        public Range Dependents
        {
            get { return new Range(_objRange.GetType().InvokeMember("Dependents", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示包含一个单元格的所有直接从属单元格的区域。如果有多个从属单元格，这可能有多个选择（多个 Range 对象）。Range 类型，只读。
        /// </summary>
        public Range DirectDependents
        {
            get { return new Range(_objRange.GetType().InvokeMember("DirectDependents", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示包含一个单元格的所有直接引用单元格的区域。如果有多个引用单元格，这可能有多个选择（多个 Range 对象）。Range 对象，只读。
        /// </summary>
        public Range DirectPrecedents
        {
            get { return new Range(_objRange.GetType().InvokeMember("DirectPrecedents", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示包含指定区域的整列（或多列）。只读。
        /// </summary>
        public Range EntireColumn
        {
            get { return new Range(_objRange.GetType().InvokeMember("EntireColumn", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示包含指定区域的整行（或多行）。只读。
        /// </summary>
        public Range EntireRow
        {
            get { return new Range(_objRange.GetType().InvokeMember("EntireRow", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>允许用户访问错误检查选项。
        /// </summary>
        public Errors Errors
        {
            get { return new Errors(_objRange.GetType().InvokeMember("Errors", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Font 对象，它代表指定对象的字体。
        /// </summary>
        public Font Font
        {
            get { return new Font(_objRange.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 FormatConditions 集合，该集合表示指定区域的所有条件格式。只读。
        /// </summary>
        public FormatConditions FormatConditions
        {
            get { return new FormatConditions(_objRange.GetType().InvokeMember("FormatConditions", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表 A1 样式表示法和宏语言中的对象的公式。
        /// </summary>
        public string Formula
        {
            get { return _objRange.GetType().InvokeMember("Formula", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("Formula", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置区域的数组公式。返回（或可设置为）单个公式或 Visual Basic 数组。如果指定区域不包含数组公式，则该属性返回 null。Variant 类型，可读写。
        /// </summary>
        public dynamic FormulaArray
        {
            get { return _objRange.GetType().InvokeMember("FormulaArray", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("FormulaArray", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它指明在工作表处于保护状态时是否隐藏公式。
        /// </summary>
        public bool FormulaHidden
        {
            get { return (bool)_objRange.GetType().InvokeMember("FormulaHidden", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("FormulaHidden", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlFormulaLabel FormulaLabel
        {
            get { return (XlFormulaLabel)_objRange.GetType().InvokeMember("FormulaLabel", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("FormulaLabel", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置指定对象的公式，使用用户语言 A1 格式引用。Variant 型，可读写。
        /// </summary>
        public string FormulaLocal
        {
            get { return _objRange.GetType().InvokeMember("FormulaLocal", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("FormulaLocal", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置指定对象的公式，使用宏语言 R1C1 格式符号表示。Variant 型，可读写。
        /// </summary>
        public string FormulaR1C1
        {
            get { return _objRange.GetType().InvokeMember("FormulaR1C1", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("FormulaR1C1", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置指定对象的公式，使用用户语言 R1C1 格式符号表示。Variant 型，可读写。
        /// </summary>
        public string FormulaR1C1Local
        {
            get { return _objRange.GetType().InvokeMember("FormulaR1C1Local", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("FormulaR1C1Local", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>如果指定单元格属于数组公式，则该属性值为 True。Variant 类型，只读。
        /// </summary>
        public bool HasArray
        {
            get { return (bool)_objRange.GetType().InvokeMember("HasArray", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>如果区域中所有单元格均包含公式，则该属性值为 True；如果所有单元格均不包含公式，则该属性值为 False；其他情况下为 null。Variant 类型，只读。
        /// </summary>
        public bool HasFormula
        {
            get { return (bool)_objRange.GetType().InvokeMember("HasFormula", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回或设置一个 Variant 值，该值代表区域的高度（以磅为单位）。
        /// </summary>
        public float Height
        {
            get { return (float)_objRange.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回或设置一个 Variant 值，它指明是否隐藏行或列。
        /// </summary>
        public bool Hidden
        {
            get { return (bool)_objRange.GetType().InvokeMember("Hidden", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("Hidden", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表指定对象的水平对齐方式。
        /// </summary>
        public XlHAlign HorizontalAlignment
        {
            get { return (XlHAlign)_objRange.GetType().InvokeMember("HorizontalAlignment", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回 Hyperlinks 集合，它代表区域的超链接。
        /// </summary>
        public Hyperlinks Hyperlinks
        {
            get { return new Hyperlinks(_objRange.GetType().InvokeMember("Hyperlinks", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置一个 String 值，它代表将页面另存为网页时指定单元格的识别标志。
        /// </summary>
        public string ID
        {
            get { return _objRange.GetType().InvokeMember("ID", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("ID", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表单元格或单元格区域的缩进量。可为 0 到 15 之间的整数。
        /// </summary>
        public int IndentLevel
        {
            get { return (int)_objRange.GetType().InvokeMember("IndentLevel", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("IndentLevel", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Interior 对象，它代表指定对象的内部。
        /// </summary>
        public Interior Interior
        {
            get { return new Interior(_objRange.GetType().InvokeMember("Interior", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Variant 值，它代表从列 A 的左边缘到区域的左边缘的距离（以磅为单位）。
        /// </summary>
        public float Left
        {
            get { return (float)_objRange.GetType().InvokeMember("Left", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回指定区域中标题行的数目。Long 类型，只读。
        /// </summary>
        public int ListHeaderRows
        {
            get { return (int)_objRange.GetType().InvokeMember("ListHeaderRows", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>为 Range 对象返回一个 ListObject 对象。ListObject 对象，只读。
        /// </summary>
        public ListObject ListObject
        {
            get { return new ListObject(_objRange.GetType().InvokeMember("ListObject", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个常量，该常量描述包含指定区域左上角部分的 PivotTable 部分。可为以下 XlLocationInTable 常量之一。Long 类型，只读。
        /// </summary>
        public XlLocationInTable LocationInTable
        {
            get { return (XlLocationInTable)_objRange.GetType().InvokeMember("LocationInTable", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回或设置一个 Variant 值，它指明对象是否已被锁定。
        /// </summary>
        public bool Locked
        {
            get { return (bool)_objRange.GetType().InvokeMember("Locked", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("Locked", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回指定的 Range 对象的 MDX 名称。只读 String 类型。
        /// </summary>
        public string MDX
        {
            get { return _objRange.GetType().InvokeMember("MDX", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
        }

        /// <summary>返回一个 Range 对象，该对象代表包含指定单元格的合并区域。如果指定的单元格不在合并区域内，则该属性返回指定的单元格。只读。Variant 类型。
        /// </summary>
        public Range MergeArea
        {
            get { return new Range(_objRange.GetType().InvokeMember("MergeArea", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>如果区域包含合并单元格，则为 True。Variant 型，可读写。
        /// </summary>
        public bool MergeCells
        {
            get { return (bool)_objRange.GetType().InvokeMember("MergeCells", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objRange.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个代表下一个单元格的 Range 对象。
        /// </summary>
        public Range Next
        {
            get { return new Range(_objRange.GetType().InvokeMember("Next", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表对象的格式代码。
        /// </summary>
        public string NumberFormat
        {
            get { return _objRange.GetType().InvokeMember("NumberFormat", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("NumberFormat", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>以采用用户语言字符串的形式返回或设置一个 Variant 值，它代表对象的格式代码。
        /// </summary>
        public string NumberFormatLocal
        {
            get { return _objRange.GetType().InvokeMember("NumberFormatLocal", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
            set { _objRange.GetType().InvokeMember("NumberFormatLocal", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表文本方向。
        /// </summary>
        public XlChartOrientation Orientation
        {
            get { return (XlChartOrientation)_objRange.GetType().InvokeMember("Orientation", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置指定行或列的当前分级显示级别。Variant 类型，可读写。
        /// </summary>
        public int OutlineLevel
        {
            get { return (int)_objRange.GetType().InvokeMember("OutlineLevel", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("OutlineLevel", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置分页符的位置。可为以下 XlPageBreak 常量之一：xlPageBreakAutomatic、xlPageBreakManual 或 xlPageBreakNone。Long 类型，可读写。
        /// </summary>
        public int PageBreak
        {
            get { return (int)_objRange.GetType().InvokeMember("PageBreak", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("PageBreak", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objRange.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回 Phonetic 对象，该对象包含有关某个单元格中指定拼音文本字符串的信息。
        /// </summary>
        public Phonetic Phonetic
        {
            get { return new Phonetic(_objRange.GetType().InvokeMember("Phonetic", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回区域的 Phonetics 集合。只读。
        /// </summary>
        public Phonetics Phonetics
        {
            get { return new Phonetics(_objRange.GetType().InvokeMember("Phonetics", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 PivotCell 对象，该对象表示数据透视表中的一个单元格。
        /// </summary>
        public PivotCell PivotCell
        {
            get { return new PivotCell(_objRange.GetType().InvokeMember("PivotCell", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 PivotField 对象，它代表指定区域左上角所在的数据透视表字段。
        /// </summary>
        public PivotField PivotField
        {
            get { return new PivotField(_objRange.GetType().InvokeMember("PivotField", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 PivotItem 对象，它代表指定区域左上角所在的数据透视表项。
        /// </summary>
        public PivotItem PivotItem
        {
            get { return new PivotItem(_objRange.GetType().InvokeMember("PivotItem", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 PivotTable 对象，它代表指定区域左上角所在的数据透视表。
        /// </summary>
        public PivotTable PivotTable
        {
            get { return new PivotTable(_objRange.GetType().InvokeMember("PivotTable", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 Range 对象，该对象表示单元格的所有引用单元格。如果有多个引用单元格，则可以是一个多重选择（Range 对象的并集）。只读。
        /// </summary>
        public Range Precedents
        {
            get { return new Range(_objRange.GetType().InvokeMember("Precedents", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回单元格的前缀字符。Variant 类型，只读。
        /// </summary>
        public string PrefixCharacter
        {
            get { return _objRange.GetType().InvokeMember("PrefixCharacter", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
        }

        /// <summary>返回一个代表下一个单元格的 Range 对象。
        /// </summary>
        public Range Previous
        {
            get { return new Range(_objRange.GetType().InvokeMember("Previous", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回一个 QueryTable 对象，它代表与指定 Range 对象相交的查询表。
        /// </summary>
        public QueryTable QueryTable
        {
            get { return new QueryTable(_objRange.GetType().InvokeMember("QueryTable", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置指定对象的阅读次序。可为以下常量之一：xlRTL（从右到左）、xlLTR（从左到右）或 xlContext。Long 类型，可读写。
        /// </summary>
        public int ReadingOrder
        {
            get { return (int)_objRange.GetType().InvokeMember("ReadingOrder", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("ReadingOrder", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回区域中第一个子区域的第一行的行号。Long 类型，只读。
        /// </summary>
        public int Row
        {
            get { return (int)_objRange.GetType().InvokeMember("Row", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>以磅为单位返回或设置指定区域中所有行的行高。如果指定区域中的各行的行高不等，则返回 null。Variant 类型，可读写。
        /// </summary>
        public float RowHeight
        {
            get { return (float)_objRange.GetType().InvokeMember("RowHeight", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表指定单元格区域中的行。Range 对象，只读。
        /// </summary>
        public Range Rows
        {
            get { return new Range(_objRange.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>指定可在 SharePoint 服务器上对 Range 对象执行的操作。
        /// </summary>
        public Actions ServerActions
        {
            get { return new Actions(_objRange.GetType().InvokeMember("ServerActions", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>如果扩展了指定区域的分级显示（从而行或列的明细数据可见），则为 True。指定区域必须为分级显示中的单个汇总列或汇总行。Variant 型，可读写。对于 PivotItem 对象（如果该区域在数据透视表中，则为 Range 对象），当数据项显示明细数据时，此属性设为 True。
        /// </summary>
        public bool ShowDetail
        {
            get { return (bool)_objRange.GetType().InvokeMember("ShowDetail", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("ShowDetail", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值。
        /// 说明：
        /// 如果文本自动收缩以适应可用列宽，此属性将返回 True；如果没有将指定区域中所有单元格的这一属性设为相同的值，则返回 Null。 
        /// </summary>
        public bool ShrinkToFit
        {
            get { return (bool)_objRange.GetType().InvokeMember("ShrinkToFit", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("ShrinkToFit", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 SmartTags 对象，它代表指定单元格的标识符。
        /// </summary>
        public SmartTags SmartTags
        {
            get { return new SmartTags(_objRange.GetType().InvokeMember("SmartTags", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置一个包含 Style 对象的 Variant 值，它代表指定区域的样式。
        /// </summary>
        public Style Style
        {
            get { return new Style(_objRange.GetType().InvokeMember("Style", BindingFlags.GetProperty, null, _objRange, null)); }
            set { _objRange.GetType().InvokeMember("Style", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>如果指定区域为分级显示的汇总行或汇总列，则该值为 True。该区域应为一行或一列。Variant 类型，只读。
        /// </summary>
        public bool Summary
        {
            get { return (bool)_objRange.GetType().InvokeMember("Summary", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回或设置指定对象中的文本。String 型，只读。
        /// </summary>
        public string Text
        {
            get { return _objRange.GetType().InvokeMember("Text", BindingFlags.GetProperty, null, _objRange, null).ToString(); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表行 1 上边缘到区域上边缘的距离（以磅为单位）。
        /// </summary>
        public float Top
        {
            get { return (float)_objRange.GetType().InvokeMember("Top", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>如果 Range 对象的行高等于工作表的标准行高，则该值为 True。如果区域包含不止一行并且不是所有的行都等高，则返回 Null。Variant 类型，可读写。
        /// </summary>
        public bool UseStandardHeight
        {
            get { return (bool)_objRange.GetType().InvokeMember("UseStandardHeight", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("UseStandardHeight", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>如果 Range 对象的列宽等于工作表的标准列宽，则该属性的值为 True。如果区域包含不止一列并且不是所有的列都等宽，则返回 null。Variant 类型，可读写。
        /// </summary>
        public bool UseStandardWidth
        {
            get { return (bool)_objRange.GetType().InvokeMember("UseStandardWidth", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("UseStandardWidth", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Validation 对象，该对象表示指定区域的数据有效性检验。只读。
        /// </summary>
        public Validation Validation
        {
            get { return new Validation(_objRange.GetType().InvokeMember("Validation", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置单元格值。Variant 类型，可读写。
        /// </summary>
        public dynamic Value2
        {
            get { return _objRange.GetType().InvokeMember("Value2", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("Value2", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表指定对象的垂直对齐方式。
        /// </summary>
        public XlVAlign VerticalAlignment
        {
            get { return (XlVAlign)_objRange.GetType().InvokeMember("VerticalAlignment", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 Variant 值，它代表区域的宽度（以磅为单位）。
        /// </summary>
        public float Width
        {
            get { return (float)_objRange.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objRange, null); }
        }

        /// <summary>返回一个 Worksheet 对象，该对象表示包含指定区域的工作表。只读。
        /// </summary>
        public Worksheet Worksheet
        {
            get { return new Worksheet(_objRange.GetType().InvokeMember("Worksheet", BindingFlags.GetProperty, null, _objRange, null)); }
        }

        /// <summary>返回或设置一个 Variant 值，它指明 Microsoft Excel 是否为对象中的文本自动换行。
        /// </summary>
        public bool WrapText
        {
            get { return (bool)_objRange.GetType().InvokeMember("WrapText", BindingFlags.GetProperty, null, _objRange, null); }
            set { _objRange.GetType().InvokeMember("WrapText", BindingFlags.SetProperty, null, _objRange, new object[1] { value }); }
        }

        /// <summary>返回一个 XPath 对象，它代表映射到指定 Range 对象的元素的 XPath。该区域的上下文确定操作是否成功，或返回空对象。只读。
        /// </summary>
        public XPath XPath
        {
            get { return new XPath(_objRange.GetType().InvokeMember("XPath", BindingFlags.GetProperty, null, _objRange, null)); }
        }
        #endregion 属性

        #region 函数
        internal object GetItem(object RowIndex = null, object ColumnIndex = null)
        {
            _objaParameters = new object[2] { 
                RowIndex == null ? System.Type.Missing : RowIndex, 
                ColumnIndex == null ? System.Type.Missing : ColumnIndex 
            };
            return _objRange.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objRange, _objaParameters);
        }

        /// <summary>激活单个单元格，该单元格必须处于当前选定区域内。要选择单元格区域，请使用 Select 方法。
        /// </summary>
        public dynamic Activate()
        {
            return _objRange.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>为区域添加批注。
        /// </summary>
        /// <param name="Text">批注文字。</param>
        public Comment AddComment(string Text = null)
        {
            _objaParameters = new object[1] {
                Text == null ? System.Type.Missing : Text
            };

            return new Comment(_objRange.GetType().InvokeMember("AddComment", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>基于条件区域从列表中筛选或复制数据。如果初始选定区域为单个单元格，则使用单元格的当前区域。
        /// </summary>
        /// <param name="Action">XlFilterAction 的常量之一，用于指定是否就地复制或筛选列表。</param>
        /// <param name="CriteriaRange">条件区域。如果省略该参数，则没有条件限制。</param>
        /// <param name="CopyToRange">如果 Action 为 xlFilterCopy，则为复制行的目标区域。否则，忽略该参数。</param>
        /// <param name="Unique">如果为 True，则只筛选唯一记录。如果为 False，则筛选符合条件的所有记录。默认值为 False。</param>
        public dynamic AdvancedFilter(XlFilterAction Action, Range CriteriaRange = null, Range CopyToRange = null, bool? Unique = null)
        {
            _objaParameters = new object[4] {
                Action,
                CriteriaRange == null ? System.Type.Missing : CriteriaRange._objRange,
                CopyToRange == null ? System.Type.Missing : CopyToRange._objRange,
                Unique == null ? System.Type.Missing : Unique
            };

            return _objRange.GetType().InvokeMember("AdvancedFilter", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将名称应用于指定区域中的单元格。
        /// </summary>
        /// <param name="Names">要应用的名称数组。如果省略该参数，则工作表中所有的名称都将应用到该区域上。</param>
        /// <param name="IgnoreRelativeAbsolute">如果为 True，则用名称取代引用，而不管名称或引用的类型如何。如果为 False，则只用绝对名称替换绝对引用，用相对名称替换相对引用，并只用混合名称替换混合引用。默认值为 True。</param>
        /// <param name="UseRowColumnNames">如果为 True，则当无法找到指定区域的名称时，使用该区域所在行或列区域的名称。如果为 False，则忽略 OmitColumn 和 OmitRow 参数。默认值为 True。</param>
        /// <param name="OmitColumn">如果为 True，则用行方向的名称替换整个引用。仅当引用的单元格与公式位于同一列中，且处于行方向命名的区域中时，才能省略列方向名称。默认值为 True。</param>
        /// <param name="OmitRow">如果为 True，则用列方向的名称替换整个引用。仅当引用的单元格与公式位于同一行中，且处于列方向命名的区域中时，才能省略行方向名称。默认值为 True。</param>
        /// <param name="Order">确定用行方向区域名称和列方向区域名称替换单元格引用时，首先列出哪个区域名称。</param>
        /// <param name="AppendLast">如果为 True，则替换 Names 中的名称定义以及所定义的姓氏的定义。如果为 False，则只替换 Names 中的名称定义。默认值为 False。</param>
        public dynamic ApplyNames(string[] Names = null, bool? IgnoreRelativeAbsolute = null, bool? UseRowColumnNames = null, bool? OmitColumn = null, bool? OmitRow = null, XlApplyNamesOrder Order = XlApplyNamesOrder.xlRowThenColumn, bool? AppendLast = null)
        {
            _objaParameters = new object[7] {
                Names == null ? System.Type.Missing : Names,
                IgnoreRelativeAbsolute == null ? System.Type.Missing : IgnoreRelativeAbsolute,
                UseRowColumnNames == null ? System.Type.Missing : UseRowColumnNames,
                OmitColumn == null ? System.Type.Missing : OmitColumn,
                OmitRow == null ? System.Type.Missing : OmitRow,
                Order,
                AppendLast == null ? System.Type.Missing : AppendLast
            };

            return _objRange.GetType().InvokeMember("ApplyNames", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>对指定区域应用分级显示样式。
        /// </summary>
        public dynamic ApplyOutlineStyles()
        {
            return _objRange.GetType().InvokeMember("ApplyOutlineStyles", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>从列表中返回一个记忆式键入匹配项。如果没有相应的记忆式键入匹配项，或者在列表中有不止一个与已键入字符串相匹配的项，此方法将返回一空字符串。
        /// </summary>
        /// <param name="String">要完成的字符串。</param>
        public string AutoComplete(string String)
        {
            _objaParameters = new object[1] { String };

            return _objRange.GetType().InvokeMember("AutoComplete", BindingFlags.InvokeMethod, null, _objRange, _objaParameters).ToString();
        }

        /// <summary>对指定区域中的单元格执行自动填充。
        /// </summary>
        /// <param name="Destination">要填充的单元格。目标区域必须包括源区域。</param>
        /// <param name="Type">指定填充类型。</param>
        public dynamic AutoFill(Range Destination, XlAutoFillType Type = XlAutoFillType.xlFillDefault)
        {
            _objaParameters = new object[2] {
                Destination._objRange,
                Type
            };

            return _objRange.GetType().InvokeMember("AutoFill", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>使用“自动筛选”筛选一个列表。
        /// </summary>
        /// <param name="Field">相对于作为筛选基准字段（从列表左侧开始，最左侧的字段为第一个字段）的字段的整型偏移量。</param>
        /// <param name="Criteria1">筛选条件（一个字符串；例如，“101”）。使用“=”可查找空字段，或者使用“<>”查找非空字段。如果省略该参数，则搜索条件为 All。如果将 Operator 设置为 xlTop10Items，则 Criteria1 指定数据项个数（例如，“10”）。</param>
        /// <param name="Operator">指定筛选类型的 XlAutoFilterOperator 常量之一。</param>
        /// <param name="Criteria2">第二个筛选条件（一个字符串）。与 Criteria1 和 Operator 一起组合成复合筛选条件。</param>
        /// <param name="VisibleDropDown">如果为 True，则显示筛选字段的自动筛选下拉箭头。如果为 False，则隐藏筛选字段的自动筛选下拉箭头。默认值为 True。</param>
        public dynamic AutoFilter(int? Field = null, string Criteria1 = null, XlAutoFilterOperator Operator = XlAutoFilterOperator.xlAnd, string Criteria2 = null, bool? VisibleDropDown = null)
        {
            _objaParameters = new object[5] {
                Field == null ? System.Type.Missing : Field,
                Criteria1 == null ? System.Type.Missing : Criteria1,
                Operator,
                Criteria2 == null ? System.Type.Missing : Criteria2,
                VisibleDropDown == null ? System.Type.Missing : VisibleDropDown
            };

            return _objRange.GetType().InvokeMember("AutoFilter", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>更改区域中的列宽或行高以达到最佳匹配。
        /// </summary>
        public dynamic AutoFit()
        {
            return _objRange.GetType().InvokeMember("AutoFit", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>
        /// </summary>
        public dynamic AutoFormat(XlRangeAutoFormat Format = XlRangeAutoFormat.xlRangeAutoFormatClassic1, object Number = null, object Font = null, object Alignment = null, object Border = null, object Pattern = null, object Width = null)
        {
            _objaParameters = new object[7] {
                Format,
                Number == null ? System.Type.Missing : Number,
                Font == null ? System.Type.Missing : Font,
                Alignment == null ? System.Type.Missing : Alignment,
                Border == null ? System.Type.Missing : Border,
                Pattern == null ? System.Type.Missing : Pattern,
                Width == null ? System.Type.Missing : Width
            };

            return _objRange.GetType().InvokeMember("AutoFormat", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>自动为指定区域创建分级显示。如果区域为单个单元格，Microsoft Excel 将创建整个工作表的分级显示。新分级显示将取代所有的分级显示。
        /// </summary>
        public dynamic AutoOutline()
        {
            return _objRange.GetType().InvokeMember("AutoOutline", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>向单元格区域添加边框，并设置该新边框的 Color、LineStyle 和 Weight 属性。Variant 类型。
        /// </summary>
        /// <param name="LineStyle">用于指定边框线样式的 XlLineStyle 常量之一。</param>
        /// <param name="Weight">边框粗细。</param>
        /// <param name="ColorIndex">边框颜色，作为当前调色板的索引或作为 XlColorIndex 常量。</param>
        /// <param name="Color">边框颜色，以 RGB 值表示。</param>
        public dynamic BorderAround(XlLineStyle? LineStyle = null, XlBorderWeight Weight = XlBorderWeight.xlThin, XlColorIndex ColorIndex = XlColorIndex.xlColorIndexAutomatic, int? Color = null)
        {
            _objaParameters = new object[4] {
                LineStyle == null ? System.Type.Missing : LineStyle,
                Weight,
                ColorIndex,
                Color == null ? System.Type.Missing : Color
            };

            return _objRange.GetType().InvokeMember("BorderAround", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>计算所有打开的工作簿、工作簿中的某张特定工作表或工作表指定区域中的单元格，如下表所示。
        /// </summary>
        public dynamic Calculate()
        {
            return _objRange.GetType().InvokeMember("Calculate", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>计算指定的单元格区域。
        /// </summary>
        public dynamic CalculateRowMajorOrder()
        {
            return _objRange.GetType().InvokeMember("CalculateRowMajorOrder", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>检查对象的拼写。
        /// </summary>
        /// <param name="CustomDictionary">一个字符串，它表示自定义词典的文件名，如果在主词典中找不到单词，则会到此词典中查找。如果省略此参数，则使用当前指定的词典。</param>
        /// <param name="IgnoreUppercase">如果为 True，则 Microsoft Excel 忽略所有字母都是大写的单词。如果为 False，则 Microsoft Excel 检查所有字母都是大写的单词。如果省略此参数，将使用当前的设置。</param>
        /// <param name="AlwaysSuggest">如果为 True，则 Microsoft Excel 在找到不正确拼写时显示建议的替换拼写列表。如果为 False，Microsoft Excel 将等待输入正确的拼写。如果省略此参数，将使用当前的设置。</param>
        /// <param name="SpellLang">当前所用词典的语言。它可以是由 LanguageID 属性使用的 MsoLanguageID 值之一。</param>
        public dynamic CheckSpelling(string CustomDictionary = null, bool? IgnoreUppercase = null, bool? AlwaysSuggest = null, MsoLanguageID? SpellLang = null)
        {
            _objaParameters = new object[4] {
                CustomDictionary == null ? System.Type.Missing : CustomDictionary,
                IgnoreUppercase == null ? System.Type.Missing : IgnoreUppercase,
                AlwaysSuggest == null ? System.Type.Missing : AlwaysSuggest,
                SpellLang == null ? System.Type.Missing : SpellLang
            };

            return _objRange.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>清除整个对象。
        /// </summary>
        public dynamic Clear()
        {
            return _objRange.GetType().InvokeMember("Clear", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>清除指定区域的所有单元格批注。
        /// </summary>
        public void ClearComments()
        {
            _objRange.GetType().InvokeMember("ClearComments", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>清除区域中的公式。
        /// </summary>
        public dynamic ClearContents()
        {
            return _objRange.GetType().InvokeMember("ClearContents", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>清除对象的格式设置。
        /// </summary>
        public dynamic ClearFormats()
        {
            return _objRange.GetType().InvokeMember("ClearFormats", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>清除指定区域中所有单元格的批注和语音批注。
        /// </summary>
        public dynamic ClearNotes()
        {
            return _objRange.GetType().InvokeMember("ClearNotes", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>清除指定区域的分级显示。
        /// </summary>
        public dynamic ClearOutline()
        {
            return _objRange.GetType().InvokeMember("ClearOutline", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>返回一个 Range 对象，该对象表示每列中所有与比较单元格内容不同的单元格。
        /// </summary>
        /// <param name="Comparison">用于对指定区域进行比较的单个单元格。</param>
        public Range ColumnDifferences(Range Comparison)
        {
            _objaParameters = new object[1] { Comparison._objRange };

            return new Range(_objRange.GetType().InvokeMember("ColumnDifferences", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>将多个工作表中多个区域的数据合并计算至单个工作表上的单个区域。Variant 类型。
        /// </summary>
        /// <param name="Sources">以文本引用字符串数组的形式给出合并计算的源，该数组采用 R1C1-样式表示法。这些引用必须包含将要合并计算的工作表的完整路径。</param>
        /// <param name="Function">XlConsolidationFunction 常量之一，用于指定合并计算的类型。</param>
        /// <param name="TopRow">如果为 True，则基于合并计算区域中首行内的列标题对数据进行合并。如果为 False，则按位置进行合并计算。默认值为 False。</param>
        /// <param name="LeftColumn">如果为 True 则基于合并计算区域中左列内的行标题对数据进行合并计算。如果为 False，则按位置进行合并计算。默认值为 False。</param>
        /// <param name="CreateLinks">如果为 True，则让合并计算使用工作表链接。如果为 False，则让合并计算复制数据。默认值为 False。</param>
        public dynamic Consolidate(string Sources = null, XlConsolidationFunction? Function = null, bool? TopRow = null, bool? LeftColumn = null, bool? CreateLinks = null)
        {
            _objaParameters = new object[5] {
                Sources == null ? System.Type.Missing : Sources,
                Function == null ? System.Type.Missing : Function,
                TopRow == null ? System.Type.Missing : TopRow,
                LeftColumn == null ? System.Type.Missing : LeftColumn,
                CreateLinks == null ? System.Type.Missing : CreateLinks
            };

            return _objRange.GetType().InvokeMember("Consolidate", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将单元格区域复制到指定的区域或剪贴板中。
        /// </summary>
        /// <param name="Destination">指定区域要复制到的新域。如果省略此参数，Microsoft Excel 会将区域复制到剪贴板。</param>
        public dynamic Copy(Range Destination = null)
        {
            _objaParameters = new object[1] {
                Destination == null ? System.Type.Missing : Destination._objRange
            };

            return _objRange.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将 ADO 或 DAO Recordset 对象中的内容复制到工作表，从指定区域的左上角开始。如果 Recordset 对象包含具有 OLE 对象的字段，则该方法无效。
        /// </summary>
        /// <param name="Data">复制到区域的 Recordset 对象。</param>
        /// <param name="MaxRows">复制到工作表上的最大记录数。如果省略该参数，将复制 Recordset 对象中的所有记录。</param>
        /// <param name="MaxColumns">复制到工作表上的最大字段数。如果省略该参数，将复制 Recordset 对象中的所有字段。</param>
        public int CopyFromRecordset(object Data, int? MaxRows = null, int? MaxColumns = null)
        {
            _objaParameters = new object[3] {
                Data,
                MaxRows == null ? System.Type.Missing : MaxRows,
                MaxColumns == null ? System.Type.Missing : MaxColumns
            };

            return (int)_objRange.GetType().InvokeMember("CopyFromRecordset", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将所选对象作为图片复制到剪贴板。Variant。
        /// </summary>
        /// <param name="Appearance">指定图片的复制方式。</param>
        /// <param name="Format">图片的格式。</param>
        public dynamic CopyPicture(XlPictureAppearance Appearance = XlPictureAppearance.xlScreen, XlCopyPictureFormat Format = XlCopyPictureFormat.xlPicture)
        {
            _objaParameters = new object[2] { Appearance, Format };

            return _objRange.GetType().InvokeMember("CopyPicture", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>在指定区域中依据工作表中的文本标签创建名称。
        /// </summary>
        /// <param name="Top">如果该值为 True，则使用顶部行中的标签创建名称。默认值为 False。</param>
        /// <param name="Left">如果该值为 True，则使用左侧列中的标签创建名称。默认值为 False。</param>
        /// <param name="Bottom">如果该值为 True，则使用底部行中的标签创建名称。默认值为 False。</param>
        /// <param name="Right">如果该值为 True，则使用右侧列中的标签创建名称。默认值为 False。</param>
        public dynamic CreateNames(bool? Top = null, bool? Left = null, bool? Bottom = null, bool? Right = null)
        {
            _objaParameters = new object[4] {
                Top == null ? System.Type.Missing : Top,
                Left == null ? System.Type.Missing : Left,
                Bottom == null ? System.Type.Missing : Bottom,
                Right == null ? System.Type.Missing : Right
            };

            return _objRange.GetType().InvokeMember("CreateNames", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic CreatePublisher(object Edition = null, XlPictureAppearance Appearance = XlPictureAppearance.xlScreen, object ContainsPICT = null, object ContainsBIFF = null, object ContainsRTF = null, object ContainsVALU = null)
        {
            _objaParameters = new object[6] {
                Edition == null ? System.Type.Missing : Edition,
                Appearance,
                ContainsPICT == null ? System.Type.Missing : ContainsPICT,
                ContainsBIFF == null ? System.Type.Missing : ContainsBIFF,
                ContainsRTF == null ? System.Type.Missing : ContainsRTF,
                ContainsVALU == null ? System.Type.Missing : ContainsVALU
            };

            return _objRange.GetType().InvokeMember("CreatePublisher", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将对象剪切到剪贴板，或者将其粘贴到指定的目的地。
        /// </summary>
        /// <param name="Destination">应在其中粘贴对象的目标区域。如果省略此参数，区域对象会被剪切到剪贴板。</param>
        public dynamic Cut(Range Destination = null)
        {
            _objaParameters = new object[1] {
                Destination == null ? System.Type.Missing : Destination._objRange
            };

            return _objRange.GetType().InvokeMember("Cut", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>在指定区域内创建数据系列。Variant 类型。
        /// </summary>
        /// <param name="Rowcol">可以是 xlRows 或 xlColumns 常量，分别表示按行或列输入数据系列。如果省略本参数，则使用区域的大小和形状。</param>
        /// <param name="Type">数据序列的类型。</param>
        /// <param name="Date">如果 Type 参数为 xlChronological，则 Date 参数指示单步执行日期单位。</param>
        /// <param name="Step">系列的步长值。默认值为 1。</param>
        /// <param name="Stop">系列的终止值。如果省略本参数，Microsoft Excel 将填满整个区域。</param>
        /// <param name="Trend">如果为 True，则创建一个线性趋势或增长趋势。如果为 False，则创建一个标准数据序列。默认值为 False。</param>
        public dynamic DataSeries(object Rowcol = null, XlDataSeriesType Type = XlDataSeriesType.xlDataSeriesLinear, XlDataSeriesDate Date = XlDataSeriesDate.xlDay, int? Step = null, int? Stop = null, bool? Trend = null)
        {
            _objaParameters = new object[6] {
                Rowcol == null ? System.Type.Missing : Rowcol,
                Type,
                Date,
                Step == null ? System.Type.Missing : Step,
                Stop == null ? System.Type.Missing : Stop,
                Trend == null ? System.Type.Missing : Trend
            };

            return _objRange.GetType().InvokeMember("DataSeries", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        /// <param name="Shift">仅用于 Range 对象。指定如何调整单元格以替换删除的单元格。可以为以下 XlDeleteShiftDirection 常量之一：xlShiftToLeft 或 xlShiftUp。如果省略此参数，Microsoft Excel 将根据区域的形状确定调整方式。</param>
        public void Delete(XlDeleteShiftDirection? Shift = null)
        {
            _objaParameters = new object[1] { Shift == null ? System.Type.Missing : Shift };
            _objRange.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>显示由 Microsoft Excel 4.0 宏工作表上的对话框定义表所定义的对话框。返回选定控件的编号，或者当用户单击“取消”按钮时返回 False。
        /// </summary>
        public dynamic DialogBox()
        {
            return _objRange.GetType().InvokeMember("DialogBox", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>下一次重新计算发生时指定要重新计算的区域。
        /// </summary>
        public void Dirty()
        {
            _objRange.GetType().InvokeMember("Dirty", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        /// <param name="Type">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Option">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Name">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Reference">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Appearance">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="ChartSize">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Format">请参阅 Microsoft</param>
        public dynamic EditionOptions(XlEditionType Type, XlEditionOptionsOption Option, object Name = null, object Reference = null, XlPictureAppearance Appearance = XlPictureAppearance.xlScreen, XlPictureAppearance ChartSize = XlPictureAppearance.xlScreen, object Format = null)
        {
            _objaParameters = new object[7] {
                Type,
                Option,
                Name == null ? System.Type.Missing : Name,
                Reference == null ? System.Type.Missing : Reference,
                Appearance,
                ChartSize,
                Format == null ? System.Type.Missing : Format
            };

            return _objRange.GetType().InvokeMember("EditionOptions", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>导出为指定格式的文件。
        /// </summary>
        /// <param name="Type">要导出为的文件格式类型。</param>
        /// <param name="Filename">要保存的文件的文件名。可以包括完整路径，否则 Excel 2007 会将文件保存在当前文件夹中。</param>
        /// <param name="Quality">可选 XlFixedFormatQuality。指定已发布文件的质量。</param>
        /// <param name="IncludeDocProperties">若要包括文档属性，则为 True；否则为 False。</param>
        /// <param name="IgnorePrintAreas">若要忽略发布时设置的任何打印区域，则为 True；否则为 False。</param>
        /// <param name="From">发布的起始页码。如果省略此参数，则从起始位置开始发布。</param>
        /// <param name="To">发布的终止页码。如果省略此参数，则发布至最后一页。</param>
        /// <param name="OpenAfterPublish">若要在发布文件后在查看器中显示文件，则为 True；否则为 False。</param>
        /// <param name="FixedFormatExtClassPtr">Pointer to the FixedFormatExt class</param>
        public void ExportAsFixedFormat(XlFixedFormatType Type, string Filename = null, XlFixedFormatQuality? Quality = null, bool? IncludeDocProperties = null, bool? IgnorePrintAreas = null, int? From = null, int? To = null, bool? OpenAfterPublish = null, object FixedFormatExtClassPtr = null)
        {
            _objaParameters = new object[9] {
                Type,
                Filename == null ? System.Type.Missing : Filename,
                Quality == null ? System.Type.Missing : Quality,
                IncludeDocProperties == null ? System.Type.Missing : IncludeDocProperties,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas,
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                OpenAfterPublish == null ? System.Type.Missing : OpenAfterPublish,
                FixedFormatExtClassPtr == null ? System.Type.Missing : FixedFormatExtClassPtr
            };

            _objRange.GetType().InvokeMember("ExportAsFixedFormat", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>从指定区域的顶部单元格开始向下填充，直至该区域的底部。区域中首行单元格的内容和格式将复制到区域中其他行内。
        /// </summary>
        public dynamic FillDown()
        {
            return _objRange.GetType().InvokeMember("FillDown", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>从指定区域的最右边单元格开始向左填充。区域中最右列单元格的内容和格式将复制到区域中其他列内。
        /// </summary>
        public dynamic FillLeft()
        {
            return _objRange.GetType().InvokeMember("FillLeft", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>从指定区域的最左边单元格开始向右填充。区域中最左列单元格的内容和格式将复制到区域中其他列内。
        /// </summary>
        public dynamic FillRight()
        {
            return _objRange.GetType().InvokeMember("FillRight", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>从指定区域的底部单元格开始向上填充，直至该区域的顶部。区域中尾行单元格的内容和格式将复制到区域中其他行内。
        /// </summary>
        public dynamic FillUp()
        {
            return _objRange.GetType().InvokeMember("FillUp", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>在区域中查找特定信息。
        /// </summary>
        /// <param name="What">要搜索的数据。可为字符串或任意 Microsoft Excel 数据类型。</param>
        /// <param name="After">表示搜索过程将从其之后开始进行的单元格。此单元格对应于从用户界面搜索时的活动单元格的位置。请注意：After 必须是区域中的单个单元格。要记住搜索是从该单元格之后开始的；直到此方法绕回到此单元格时，才对其进行搜索。如果不指定该参数，搜索将从区域的左上角的单元格之后开始。</param>
        /// <param name="LookIn">信息类型。</param>
        /// <param name="LookAt">可为以下 XlLookAt 常量之一：xlWhole 或 xlPart。</param>
        /// <param name="SearchOrder">可为以下 XlSearchOrder 常量之一：xlByRows 或 xlByColumns。</param>
        /// <param name="SearchDirection">搜索的方向。</param>
        /// <param name="MatchCase">如果为 True，则搜索区分大小写。默认值为 False。</param>
        /// <param name="MatchByte">只在已经选择或安装了双字节语言支持时适用。如果为 True，则双字节字符只与双字节字符匹配。如果为 False，则双字节字符可与其对等的单字节字符匹配。</param>
        /// <param name="SearchFormat">搜索的格式。</param>
        public Range Find(object What, Range After = null, object LookIn = null, XlLookAt? LookAt = null, XlSearchOrder? SearchOrder = null, XlSearchDirection SearchDirection = XlSearchDirection.xlNext, bool? MatchCase = null, bool? MatchByte = null, string SearchFormat = null)
        {
            _objaParameters = new object[9] {
                What,
                After == null ? System.Type.Missing : After._objRange,
                LookIn == null ? System.Type.Missing : LookIn,
                LookAt == null ? System.Type.Missing : LookAt,
                SearchOrder == null ? System.Type.Missing : SearchOrder,
                SearchDirection,
                MatchCase == null ? System.Type.Missing : MatchCase,
                MatchByte == null ? System.Type.Missing : MatchByte,
                SearchFormat == null ? System.Type.Missing : SearchFormat
            };

            return new Range(_objRange.GetType().InvokeMember("Find", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>继续由 Find 方法开始的搜索。查找匹配相同条件的下一个单元格，并返回表示该单元格的 Range 对象。该操作不影响选定内容和活动单元格。
        /// </summary>
        /// <param name="After">指定一个单元格，查找将从该单元格之后开始。此单元格对应于从用户界面搜索时的活动单元格位置。注意，After 必须是查找区域中的单个单元格。注意，搜索是从该单元格之后开始的；直到本方法环绕到此单元格时，才检测其内容。如果未指定本参数，查找将从区域的左上角单元格之后开始。</param>
        public Range FindNext(Range After = null)
        {
            _objaParameters = new object[1] {
                After == null ? System.Type.Missing : After._objRange
            };

            return new Range(_objRange.GetType().InvokeMember("FindNext", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>继续由 Find 方法开始的搜索。查找匹配相同条件的上一个单元格，并返回代表该单元格的 Range 对象。该操作不影响选定内容和活动单元格。
        /// </summary>
        /// <param name="After">指定一个单元格，查找将从该单元格之前开始。此单元格对应于从用户界面搜索时的活动单元格的位置。请注意：After 必须是区域中的单个单元格。注意，搜索是从该单元格之前开始的；直到本方法环绕到此单元格时，才检测其内容。如果未指定本参数，查找将从区域的左上角单元格之前开始。</param>
        public Range FindPrevious(Range After = null)
        {
            _objaParameters = new object[1] {
                After == null ? System.Type.Missing : After._objRange
            };

            return new Range(_objRange.GetType().InvokeMember("FindPrevious", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>对指定区域左上角单元格启动“函数向导”。
        /// </summary>
        public dynamic FunctionWizard()
        {
            return _objRange.GetType().InvokeMember("FunctionWizard", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>为得出特定结果而进行单变量求解。如果此特定结果是由某公式返回的量，本方法将求出该公式中未知数的值，当用该值代换公式中的未知数时，该公式将得出所需的特定结果。如果单变量求解成功，则该值为 True。
        /// </summary>
        /// <param name="Goal">希望在该单元格中返回的结果。</param>
        /// <param name="ChangingCell">指定为获得目标值而应更改的单元格。</param>
        public bool GoalSeek(object Goal, Range ChangingCell)
        {
            _objaParameters = new object[2] {
                Goal,
                ChangingCell._objRange
            };

            return (bool)_objRange.GetType().InvokeMember("GoalSeek", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>当 Range 对象代表某个数据透视表字段的数据区域中的单个单元格时，Group 方法在该字段中执行基于数字或日期的分组。
        /// </summary>
        /// <param name="Start">要分组的第一个值。如果该参数被省略或为 True，则使用字段中的第一个值。</param>
        /// <param name="End">要分组的最后一个值。如果该参数被省略或为 True，则使用字段中的最后一个值。</param>
        /// <param name="By">如果字段为数字，则该参数指定每个组的大小。如果字段是日期，当 Periods 数组中的元素 4 为 True，而其他所有元素为 False 时，该参数指定每个组中的天数。否则，忽略该参数。如果省略此参数，Microsoft Excel 将自动选择一个默认的组大小。</param>
        /// <param name="Periods">一个 Boolean 值的数组，用于指定组的期限，如“备注”部分所示。如果数组中的元素为 True，则为相应的时间创建组；如果元素为 False，则不创建组。当字段不是日期字段时，该参数被忽略。</param>
        public dynamic Group(bool? Start = null, bool? End = null, bool? By = null, bool? Periods = null)
        {
            _objaParameters = new object[4] {
                Start == null ? System.Type.Missing : Start,
                End == null ? System.Type.Missing : End,
                By == null ? System.Type.Missing : By,
                Periods == null ? System.Type.Missing : Periods
            };

            return _objRange.GetType().InvokeMember("Group", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>在工作表或宏表中插入一个单元格或单元格区域，其他单元格相应移位以腾出空间。
        /// </summary>
        /// <param name="Shift">指定单元格的调整方式。可为以下 XlInsertShiftDirection 常量之一：xlShiftToRight 或 xlShiftDown。如果省略此参数，Microsoft Excel 将根据区域的形状确定调整方式。</param>
        /// <param name="CopyOrigin">复制的起点。</param>
        public dynamic Insert(XlInsertShiftDirection? Shift = null, object CopyOrigin = null)
        {
            _objaParameters = new object[2] {
                Shift == null ? System.Type.Missing : Shift,
                CopyOrigin == null ? System.Type.Missing : CopyOrigin
            };

            return _objRange.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>向指定的区域添加缩进量。
        /// </summary>
        /// <param name="InsertAmount">要添加到当前缩进量的缩进量。</param>
        public void InsertIndent(int InsertAmount)
        {
            _objaParameters = new object[1] { InsertAmount };

            _objRange.GetType().InvokeMember("InsertIndent", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>调整区域内的文字，使之均衡地填充该区域。
        /// </summary>
        public dynamic Justify()
        {
            return _objRange.GetType().InvokeMember("Justify", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>从指定区域的第一个单元格位置开始，将所有未隐藏的名称的列表粘贴到工作表上。
        /// </summary>
        public dynamic ListNames()
        {
            return _objRange.GetType().InvokeMember("ListNames", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>由指定的 Range 对象创建合并单元格。
        /// </summary>
        /// <param name="Across">如果为 True，则将指定区域中每一行的单元格合并为一个单独的合并单元格。默认值是 False。</param>
        public void Merge(bool? Across = null)
        {
            _objaParameters = new object[1] { Across };
            _objRange.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>定位追踪箭头，此箭头指定引用单元格、从属单元格或错误源单元格。选定引用单元格、从属单元格或错误源单元格并返回一个 Range 对象，该对象代表新选定区域。本方法应用于没有可见追踪箭头的单元格时将出错。
        /// </summary>
        /// <param name="TowardPrecedent">指定定位的方向：如果该值为 True，则定位到引用单元格；如果该值为 False，则定位到从属单元格。</param>
        /// <param name="ArrowNumber">指定要定位的箭头编号；对应于单元格公式中编号的引用。</param>
        /// <param name="LinkNumber">如果箭头是外部引用箭头，则该参数表示要跟踪的外部引用。如果省略该参数，则跟踪第一个外部引用。</param>
        public dynamic NavigateArrow(bool? TowardPrecedent = null, int? ArrowNumber = null, int? LinkNumber = null)
        {
            _objaParameters = new object[3] {
                TowardPrecedent == null ? System.Type.Missing : TowardPrecedent,
                ArrowNumber == null ? System.Type.Missing : ArrowNumber,
                LinkNumber == null ? System.Type.Missing : LinkNumber
            };

            return _objRange.GetType().InvokeMember("NavigateArrow", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>返回或设置与区域左上角单元格相关联的单元格注释。String 类型，可读写。单元格注释已经替换为区域注释。有关详细信息，请参阅 Comment 对象。
        /// </summary>
        /// <param name="Text">要添加到注释中的文本（不超过 255 个字符）。注释文本插入的起始位置由 Start 参数指定，并替换现有注释的 Length 字符。如果省略该参数，此方法将返回注释的当前文本，该注释起始于 Start 位置，长度为 Length 个字符。</param>
        /// <param name="Start">设置或返回的文本的起始位置。如果省略该参数，此方法将第一个字符作为起始位置。要将文本追加到注释，请指定一个大于现有注释中的字符数的数字。</param>
        /// <param name="Length">要设置或返回的字符数。如果省略该参数，则 Microsoft Excel 将以从现有注释起始位置到注释末尾的长度设置或返回字符（不超过 255 个字符）。如果从 Start 位置到注释的末尾的字符数超过 255，则此方法只返回 255 个字符。</param>
        public string NoteText(string Text = null, int? Start = null, int? Length = null)
        {
            _objaParameters = new object[3] {
                Text == null ? System.Type.Missing : Text,
                Start == null ? System.Type.Missing : Start,
                Length == null ? System.Type.Missing : Length
            };

            return _objRange.GetType().InvokeMember("NoteText", BindingFlags.InvokeMethod, null, _objRange, _objaParameters).ToString();
        }

        /// <summary>分列区域内的数据并将这些数据分散放置于若干单元格中。将区域内容分配于多个相邻接的列中；该区域只能包含一列。
        /// </summary>
        /// <param name="ParseLine">包含方括号的字符串，用以指明在何处拆分单元格。</param>
        /// <param name="Destination">一个代表用于放置分列数据的目标区域的左上角的 Range 对象。如果省略该参数，Microsoft Excel 将在原处进行分列。</param>
        public dynamic Parse(string ParseLine = null, Range Destination = null)
        {
            _objaParameters = new object[2] {
                ParseLine == null ? System.Type.Missing : ParseLine,
                Destination == null ? System.Type.Missing : Destination._objRange
            };

            return _objRange.GetType().InvokeMember("Parse", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将 Range 从剪贴板粘贴到指定的区域中。
        /// </summary>
        /// <param name="Paste">要粘贴的区域部分。</param>
        /// <param name="Operation">粘贴操作。</param>
        /// <param name="SkipBlanks">如果为 True，则不将剪贴板上区域中的空白单元格粘贴到目标区域中。默认值为 False。</param>
        /// <param name="Transpose">如果为 True，则在粘贴区域时转置行和列。默认值为 False。</param>
        public dynamic PasteSpecial(XlPasteType Paste = XlPasteType.xlPasteAll, XlPasteSpecialOperation Operation = XlPasteSpecialOperation.xlPasteSpecialOperationNone, bool? SkipBlanks = null, bool? Transpose = null)
        {
            _objaParameters = new object[4] {
                Paste,
                Operation,
                SkipBlanks == null ? System.Type.Missing : SkipBlanks,
                Transpose == null ? System.Type.Missing : Transpose
            };

            return _objRange.GetType().InvokeMember("PasteSpecial", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        public dynamic PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            return _objRange.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic PrintOutEx(object From = null, object To = null, object Copies = null, object Preview = null, object ActivePrinter = null, object PrintToFile = null, object Collate = null, object PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            return _objRange.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public dynamic PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] {
                EnableChanges == null ? System.Type.Missing : EnableChanges
            };

            return _objRange.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>从值区域中删除重复的值。
        /// </summary>
        /// <param name="Columns">包含重复信息的列的索引数组。如果没有传递任何内容，则假定所有列都包含重复信息。</param>
        /// <param name="Header">指定第一行是否包含标题信息。xlNo 是默认值；如果希望 Excel 确定标题，则指定 xlGuess。</param>
        public void RemoveDuplicates(int?[] Columns = null, XlYesNoGuess Header = XlYesNoGuess.xlNo)
        {
            _objaParameters = new object[2] {
                Columns == null ? System.Type.Missing : Columns,
                Header
            };

            _objRange.GetType().InvokeMember("RemoveDuplicates", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>删除列表中的分类汇总。
        /// </summary>
        public dynamic RemoveSubtotal()
        {
            return _objRange.GetType().InvokeMember("RemoveSubtotal", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>返回 Boolean，它表示指定区域内单元格中的字符。使用此方法并不会更改选定区域或活动单元格。
        /// </summary>
        /// <param name="What">Microsoft Excel 要搜索的字符串。</param>
        /// <param name="Replacement">替换字符串。</param>
        /// <param name="LookAt">可为以下 XlLookAt 常量之一：xlWhole 或 xlPart。</param>
        /// <param name="SearchOrder">可为以下 XlSearchOrder 常量之一：xlByRows 或 xlByColumns。</param>
        /// <param name="MatchCase">如果为 True，则搜索区分大小写。</param>
        /// <param name="MatchByte">只有在 Microsoft Excel 中选择或安装了双字节语言时，才能使用此参数。如果为 True，则双字节字符只与双字节字符匹配。如果为 False，则双字节字符可与其对等的单字节字符匹配。</param>
        /// <param name="SearchFormat">该方法的搜索格式。</param>
        /// <param name="ReplaceFormat">该方法的替换格式。</param>
        public bool Replace(string What, string Replacement, XlLookAt? LookAt = null, XlSearchOrder? SearchOrder = null, bool? MatchCase = null, bool? MatchByte = null, string SearchFormat = null, string ReplaceFormat = null)
        {
            _objaParameters = new object[8] {
                What,
                Replacement,
                LookAt == null ? System.Type.Missing : LookAt,
                SearchOrder == null ? System.Type.Missing : SearchOrder,
                MatchCase == null ? System.Type.Missing : MatchCase,
                MatchByte == null ? System.Type.Missing : MatchByte,
                SearchFormat == null ? System.Type.Missing : SearchFormat,
                ReplaceFormat == null ? System.Type.Missing : ReplaceFormat
            };

            return (bool)_objRange.GetType().InvokeMember("Replace", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>返回一个 Range 对象，该对象表示每行中与比较单元格内容不同的所有单元格。
        /// </summary>
        /// <param name="Comparison">用于与指定区域进行比较的单个单元格。</param>
        public Range RowDifferences(Range Comparison)
        {
            _objaParameters = new object[1] { Comparison._objRange };

            return new Range(_objRange.GetType().InvokeMember("RowDifferences", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>在该处运行 Microsoft Excel 宏。区域必须位于宏表上。
        /// </summary>
        /// <para>传递给函数的参数。</para>
        public dynamic Run(object Arg1 = null, object Arg2 = null, object Arg3 = null, object Arg4 = null, object Arg5 = null, object Arg6 = null, object Arg7 = null, object Arg8 = null, object Arg9 = null, object Arg10 = null, object Arg11 = null, object Arg12 = null, object Arg13 = null, object Arg14 = null, object Arg15 = null, object Arg16 = null, object Arg17 = null, object Arg18 = null, object Arg19 = null, object Arg20 = null, object Arg21 = null, object Arg22 = null, object Arg23 = null, object Arg24 = null, object Arg25 = null, object Arg26 = null, object Arg27 = null, object Arg28 = null, object Arg29 = null, object Arg30 = null)
        {
            _objaParameters = new object[30] {
                Arg1 == null ? System.Type.Missing : Arg1,
                Arg2 == null ? System.Type.Missing : Arg2,
                Arg3 == null ? System.Type.Missing : Arg3,
                Arg4 == null ? System.Type.Missing : Arg4,
                Arg5 == null ? System.Type.Missing : Arg5,
                Arg6 == null ? System.Type.Missing : Arg6,
                Arg7 == null ? System.Type.Missing : Arg7,
                Arg8 == null ? System.Type.Missing : Arg8,
                Arg9 == null ? System.Type.Missing : Arg9,
                Arg10 == null ? System.Type.Missing : Arg10,
                Arg11 == null ? System.Type.Missing : Arg11,
                Arg12 == null ? System.Type.Missing : Arg12,
                Arg13 == null ? System.Type.Missing : Arg13,
                Arg14 == null ? System.Type.Missing : Arg14,
                Arg15 == null ? System.Type.Missing : Arg15,
                Arg16 == null ? System.Type.Missing : Arg16,
                Arg17 == null ? System.Type.Missing : Arg17,
                Arg18 == null ? System.Type.Missing : Arg18,
                Arg19 == null ? System.Type.Missing : Arg19,
                Arg20 == null ? System.Type.Missing : Arg20,
                Arg21 == null ? System.Type.Missing : Arg21,
                Arg22 == null ? System.Type.Missing : Arg22,
                Arg23 == null ? System.Type.Missing : Arg23,
                Arg24 == null ? System.Type.Missing : Arg24,
                Arg25 == null ? System.Type.Missing : Arg25,
                Arg26 == null ? System.Type.Missing : Arg26,
                Arg27 == null ? System.Type.Missing : Arg27,
                Arg28 == null ? System.Type.Missing : Arg28,
                Arg29 == null ? System.Type.Missing : Arg29,
                Arg30 == null ? System.Type.Missing : Arg30
            };

            return _objRange.GetType().InvokeMember("Run", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        public dynamic Select()
        {
            return _objRange.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>为指定区域中的所有单元格创建 Phonetic 对象。
        /// </summary>
        public void SetPhonetic()
        {
            _objRange.GetType().InvokeMember("SetPhonetic", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>滚动当前活动窗口中的内容以将指定区域移到视图中。此区域必须由活动文档中的单个单元格组成。
        /// </summary>
        public dynamic Show()
        {
            return _objRange.GetType().InvokeMember("Show", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>绘制从指定区域指向直接从属单元格的追踪箭头。
        /// </summary>
        /// <param name="Remove">如果为 True，则去掉指向直接从属单元格的一个级别的追踪箭头。如果为 False，则扩充一个级别的追踪箭头。默认值为 False。</param>
        public dynamic ShowDependents(bool? Remove = null)
        {
            _objaParameters = new object[1] {
                Remove == null ? System.Type.Missing : Remove
            };

            return _objRange.GetType().InvokeMember("ShowDependents", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>绘制通过从属单元格树而指向错误源单元格的追踪箭头，并返回包含该单元格的区域。
        /// </summary>
        public dynamic ShowErrors()
        {
            return _objRange.GetType().InvokeMember("ShowErrors", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>绘制从指定区域指向直接引用单元格的追踪箭头。
        /// </summary>
        /// <param name="Remove">如果为 True，则去掉指向直接引用单元格的一个级别的追踪箭头。如果为 False，则扩充一个级别的追踪箭头。默认值为 False。</param>
        public dynamic ShowPrecedents(bool? Remove = null)
        {
            _objaParameters = new object[1] {
                Remove == null ? System.Type.Missing : Remove
            };

            return _objRange.GetType().InvokeMember("ShowPrecedents", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>对值区域进行排序。
        /// </summary>
        /// <param name="Key1">指定第一排序字段，作为区域名称（字符串）或 Range 对象；确定要排序的值。</param>
        /// <param name="Order1">确定 Key1 中指定的值的排序次序。</param>
        /// <param name="Key2">第二排序字段；对数据透视表进行排序时不能使用。</param>
        /// <param name="Type">指定要排序的元素。</param>
        /// <param name="Order2">确定 Key2 中指定的值的排序次序。</param>
        /// <param name="Key3">第三排序字段；对数据透视表进行排序时不能使用。</param>
        /// <param name="Order3">确定 Key3 中指定的值的排序次序。</param>
        /// <param name="Header">指定第一行是否包含标题信息。xlNo 是默认值；如果希望 Excel 确定标题，则指定 xlGuess。</param>
        /// <param name="OrderCustom">指定在自定义排序次序列表中的基于一的整数偏移。</param>
        /// <param name="MatchCase">设置为 True，则执行区分大小写的排序，设置为 False，则执行不区分大小写的排序；不能用于数据透视表。</param>
        /// <param name="Orientation">指定以升序还是降序排序。</param>
        /// <param name="SortMethod">指定排序方法。</param>
        /// <param name="DataOption1">指定 Key1 中所指定区域中的文本的排序方式；不应用于数据透视表排序。</param>
        /// <param name="DataOption2">指定 Key2 中所指定区域中的文本的排序方式；不应用于数据透视表排序。</param>
        /// <param name="DataOption3">指定 Key3 中所指定区域中的文本的排序方式；不应用于数据透视表排序。</param>
        public dynamic Sort(object Key1 = null, XlSortOrder Order1 = XlSortOrder.xlAscending, object Key2 = null, object Type = null, XlSortOrder Order2 = XlSortOrder.xlAscending, object Key3 = null, XlSortOrder Order3 = XlSortOrder.xlAscending, XlYesNoGuess Header = XlYesNoGuess.xlNo, object OrderCustom = null, object MatchCase = null, XlSortOrientation Orientation = XlSortOrientation.xlSortRows, XlSortMethod SortMethod = XlSortMethod.xlPinYin, XlSortDataOption DataOption1 = XlSortDataOption.xlSortNormal, XlSortDataOption DataOption2 = XlSortDataOption.xlSortNormal, XlSortDataOption DataOption3 = XlSortDataOption.xlSortNormal)
        {
            _objaParameters = new object[15] {
                Key1 == null ? System.Type.Missing : Key1,
                Order1,
                Key2 == null ? System.Type.Missing : Key2,
                Type == null ? System.Type.Missing : Type,
                Order2,
                Key3 == null ? System.Type.Missing : Key3,
                Order3,
                Header,
                OrderCustom == null ? System.Type.Missing : OrderCustom,
                MatchCase == null ? System.Type.Missing : MatchCase,
                Orientation,
                SortMethod,
                DataOption1,
                DataOption2,
                DataOption3
            };

            return _objRange.GetType().InvokeMember("Sort", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>使用东亚排序方法对区域或数据透视表进行排序；或者如果区域中只包含一个单元格，则对活动区域使用本方法。例如，日文排序方法是按照假名音节表进行排序的。
        /// </summary>
        /// <param name="SortMethod">排序类型。这些常量中的某些可能不可用，这取决于选择或安装的语言支持（例如，美国英语）。</param>
        /// <param name="Key1">第一个排序字段，可以是文本（数据透视表字段或区域名）也可以是 Range 对象（例如，“Dept”或 Cells(1, 1)）。</param>
        /// <param name="Order1">在 Key1 参数中指定的字段或区域的排序顺序。</param>
        /// <param name="Type">指定要排序的元素。仅在对数据透视表排序时才使用该参数。</param>
        /// <param name="Key2">第二个排序字段，可以是文本（数据透视表字段或区域名）也可以是 Range 对象。如果省略该参数，则没有第二个排序字段。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="Order2">在 Key2 参数中指定的字段或区域的排序顺序。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="Key3">第三个排序字段，可以是文本（区域名）也可以是 Range 对象。如果省略该参数，则没有第三个排序字段。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="Order3">在参数 Key3 中指定的字段或区域的排序顺序。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="Header">指定第一行是否包含标题。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="OrderCustom">该参数是从 1 开始的整数，指定了在自定义排序次序列表中的偏移量。如果省略 OrderCustom，则使用常规排序顺序。</param>
        /// <param name="MatchCase">如果为 True，则进行区分大小写的排序；如果为 False，则排序时不区分大小写。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="Orientation">排序方向。</param>
        /// <param name="DataOption1">指定如何对 Key1 中的文本进行排序。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="DataOption2">指定如何对 Key2 中的文本进行排序。对数据透视表进行排序时，不能使用该参数。</param>
        /// <param name="DataOption3">指定如何对 Key3 中的文本进行排序。对数据透视表进行排序时，不能使用该参数。</param>
        public dynamic SortSpecial(XlSortMethod SortMethod = XlSortMethod.xlPinYin, object Key1 = null, XlSortOrder Order1 = XlSortOrder.xlAscending, object Type = null, object Key2 = null, XlSortOrder Order2 = XlSortOrder.xlAscending, object Key3 = null, XlSortOrder Order3 = XlSortOrder.xlAscending, XlYesNoGuess Header = XlYesNoGuess.xlNo, object OrderCustom = null, object MatchCase = null, XlSortOrientation Orientation = XlSortOrientation.xlSortRows, XlSortDataOption DataOption1 = XlSortDataOption.xlSortNormal, XlSortDataOption DataOption2 = XlSortDataOption.xlSortNormal, XlSortDataOption DataOption3 = XlSortDataOption.xlSortNormal)
        {
            _objaParameters = new object[15] {
                SortMethod,
                Key1 == null ? System.Type.Missing : Key1,
                Order1,
                Type == null ? System.Type.Missing : Type,
                Key2 == null ? System.Type.Missing : Key2,
                Order2,
                Key3 == null ? System.Type.Missing : Key3,
                Order3,
                Header,
                OrderCustom == null ? System.Type.Missing : OrderCustom,
                MatchCase == null ? System.Type.Missing : MatchCase,
                Orientation,
                DataOption1,
                DataOption2,
                DataOption3
            };

            return _objRange.GetType().InvokeMember("SortSpecial", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>按行或列的顺序朗读单元格区域。
        /// </summary>
        /// <param name="SpeakDirection">朗读的方向，按行或按列。</param>
        /// <param name="SpeakFormulas">如果为 True，对那些有公式的单元格来说，公式将被发送到“文本到语音”(TTS) 引擎。如果单元格没有公式，则发送值。如果为 False（默认值），则始终将值发送到 TTS 引擎。</param>
        public void Speak(object SpeakDirection = null, bool? SpeakFormulas = null)
        {
            _objaParameters = new object[2] {
                SpeakDirection == null ? System.Type.Missing : SpeakDirection,
                SpeakFormulas == null ? System.Type.Missing : SpeakFormulas
            };

            _objRange.GetType().InvokeMember("Speak", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>返回一个 Range 对象，该对象代表与指定类型和值匹配的所有单元格。
        /// </summary>
        /// <param name="Type">要包含的单元格。</param>
        /// <param name="Value">如果 Type 为 xlCellTypeConstants 或 xlCellTypeFormulas，则该参数可用于确定结果中应包含哪几类单元格。将这些值相加可使此方法返回多种类型的单元格。默认情况下，将选择所有常量或公式，无论类型如何。</param>
        public Range SpecialCells(XlCellType Type, object Value = null)
        {
            _objaParameters = new object[2] {
                Type,
                Value == null ? System.Type.Missing : Value
            };

            return new Range(_objRange.GetType().InvokeMember("SpecialCells", BindingFlags.InvokeMethod, null, _objRange, _objaParameters));
        }

        /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
        /// </summary>
        /// <param name="Edition">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        /// <param name="Format">请参阅 Microsoft Office Macintosh 版本附带的帮助。</param>
        public dynamic SubscribeTo(string Edition, XlSubscribeToFormat Format = XlSubscribeToFormat.xlSubscribeToText)
        {
            _objaParameters = new object[2] { Edition, Format };

            return _objRange.GetType().InvokeMember("SubscribeTo", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>创建指定区域或当前区域（如果该区域为单个单元格时）的分类汇总。
        /// </summary>
        /// <param name="GroupBy">要作为分组依据的字段，为基于 1 的整数偏移量。有关详细信息，请参阅示例。</param>
        /// <param name="Function">分类汇总函数。</param>
        /// <param name="TotalList">基于 1 的字段偏移量数组，它指明将被分类汇总的字段。有关详细信息，请参阅示例。</param>
        /// <param name="Replace">如果为 True，则替换现有分类汇总。默认值为 True。</param>
        /// <param name="PageBreaks">如果为 True，则在每一组之后添加分页符。默认值为 False。</param>
        /// <param name="SummaryBelowData">放置相对于分类汇总的汇总数据。</param>
        public dynamic Subtotal(int GroupBy, XlConsolidationFunction Function, int TotalList, bool? Replace = null, bool? PageBreaks = null, XlSummaryRow SummaryBelowData = XlSummaryRow.xlSummaryBelow)
        {
            _objaParameters = new object[6] {
                GroupBy,
                Function,
                TotalList,
                Replace == null ? System.Type.Missing : Replace,
                PageBreaks == null ? System.Type.Missing : PageBreaks,
                SummaryBelowData
            };

            return _objRange.GetType().InvokeMember("Subtotal", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>依据输入值和工作表上定义的公式创建数据表。
        /// </summary>
        /// <param name="RowInput">用作数据表行输入的单个单元格。</param>
        /// <param name="ColumnInput">用作数据表列输入的单个单元格。</param>
        public dynamic Table(Range RowInput = null, Range ColumnInput = null)
        {
            _objaParameters = new object[2] {
                RowInput == null ? System.Type.Missing : RowInput._objRange,
                ColumnInput == null ? System.Type.Missing : ColumnInput._objRange
            };

            return _objRange.GetType().InvokeMember("Table", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>将包含文本的一列单元格分解为若干列。
        /// </summary>
        /// <param name="Destination">一个 Range 对象，指定 Microsoft Excel 放置结果的位置。如果该区域大于一个单元格，则使用左上角的单元格。</param>
        /// <param name="DataType">将被拆分到多列中的文本的格式。</param>
        /// <param name="TextQualifier">指定是将单引号、双引号用作文本分隔符还是不使用引号。</param>
        /// <param name="ConsecutiveDelimiter">如果为 True，则 Microsoft Excel 将连续分隔符视为一个分隔符。默认值为 False。</param>
        /// <param name="Tab">如果为 True，则 DataType 为 xlDelimited 并将制表符作为分隔符。默认值为 False。</param>
        /// <param name="Semicolon">如果为 True，则 DataType 为 xlDelimited 并将分号作为分隔符。默认值为 False。</param>
        /// <param name="Comma">如果为 True，则 DataType 为 xlDelimited 并将逗号作为分隔符。默认值为 False。</param>
        /// <param name="Space">如果为 True，则 DataType 为 xlDelimited 并将空格字符作为分隔符。默认值为 False。</param>
        /// <param name="Other">如果为 True，则 DataType 为 xlDelimited 并将 OtherChar 参数指定的字符作为分隔符。默认值为 False。</param>
        /// <param name="OtherChar">（如果 Other 为 True，则为必选项）。当 Other 为 True 时的分隔符。如果指定了多个字符，则仅使用字符串中的第一个字符而忽略剩余字符。</param>
        /// <param name="FieldInfo">包含单列数据相关分列信息的数组。对该参数的解释取决于 DataType 的值。如果此数据由分隔符分隔，则该参数为由两元素数组组成的数组，其中每个两元素数组指定一个特定列的转换选项。第一个元素为列标（从 1 开始），第二个元素是 xlColumnDataType 的常量之一，用于指定分列方式。</param>
        /// <param name="DecimalSeparator">识别数字时，Microsoft Excel 使用的小数分隔符。默认设置为系统设置。</param>
        /// <param name="ThousandsSeparator">识别数字时，Excel 使用的千位分隔符。默认设置为系统设置。</param>
        /// <param name="TrailingMinusNumbers">以减号字符开始的数字。</param>
        public dynamic TextToColumns(Range Destination = null, XlTextParsingType DataType = XlTextParsingType.xlDelimited, XlTextQualifier TextQualifier = XlTextQualifier.xlTextQualifierDoubleQuote, bool? ConsecutiveDelimiter = null, bool? Tab = null, bool? Semicolon = null, bool? Comma = null, bool? Space = null, bool? Other = null, string OtherChar = null, object FieldInfo = null, string DecimalSeparator = null, string ThousandsSeparator = null, int? TrailingMinusNumbers = null)
        {
            _objaParameters = new object[14] {
                Destination == null ? System.Type.Missing : Destination._objRange,
                DataType,
                TextQualifier,
                ConsecutiveDelimiter == null ? System.Type.Missing : ConsecutiveDelimiter,
                Tab == null ? System.Type.Missing : Tab,
                Semicolon == null ? System.Type.Missing : Semicolon,
                Comma == null ? System.Type.Missing : Comma,
                Space == null ? System.Type.Missing : Space,
                Other == null ? System.Type.Missing : Other,
                OtherChar == null ? System.Type.Missing : OtherChar,
                FieldInfo == null ? System.Type.Missing : FieldInfo,
                DecimalSeparator == null ? System.Type.Missing : DecimalSeparator,
                ThousandsSeparator == null ? System.Type.Missing : ThousandsSeparator,
                TrailingMinusNumbers == null ? System.Type.Missing : TrailingMinusNumbers
            };

            return _objRange.GetType().InvokeMember("TextToColumns", BindingFlags.InvokeMethod, null, _objRange, _objaParameters);
        }

        /// <summary>在分级显示中对一个区域进行升级（即降低其分级显示的级别）。指定区域必须是行或列，或者行区域或列区域。如果指定区域在数据透视表中，本方法将对该区域内的项取消分组。
        /// </summary>
        public dynamic Ungroup()
        {
            return _objRange.GetType().InvokeMember("Ungroup", BindingFlags.InvokeMethod, null, _objRange, null);
        }

        /// <summary>将合并区域分解为独立的单元格。
        /// </summary>
        public void UnMerge()
        {
            _objRange.GetType().InvokeMember("UnMerge", BindingFlags.InvokeMethod, null, _objRange, null);
        }
        #endregion 函数

    }

    /// <summary>代表页面设置说明。
    /// 说明：
    /// PageSetup 对象包含所有页面设置的属性（左边距、底部边距、纸张大小等）。
    /// </summary>
    public class PageSetup
    {
        public object _objPageSetup;

        public PageSetup(object objPageSetup)
        {
            _objPageSetup = objPageSetup;
        }

        #region 属性
        /// <summary>如果 Excel 以页面设置选项中设置的边距对齐页眉和页脚，则返回 True。可读/写 Boolean 类型。
        /// </summary>
        public bool AlignMarginsHeaderFooter
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("AlignMarginsHeaderFooter", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("AlignMarginsHeaderFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objPageSetup.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>如果指定文档中的元素以黑白方式打印，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool BlackAndWhite
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("BlackAndWhite", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("BlackAndWhite", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置底端边距的大小。Double 类型，可读写。
        /// </summary>
        public double BottomMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("BottomMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("BottomMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>居中对齐 PageSetup 对象中的页脚信息。可读/写 String 类型。
        /// </summary>
        public string CenterFooter
        {
            get { return _objPageSetup.GetType().InvokeMember("CenterFooter", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("CenterFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回一个 Graphic 对象，该对象表示页脚中间部分的图片。用于设置图片的属性。
        /// </summary>
        public Graphic CenterFooterPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("CenterFooterPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>居中对齐 PageSetup 对象中的页眉信息。可读/写 String 类型。
        /// </summary>
        public string CenterHeader
        {
            get { return _objPageSetup.GetType().InvokeMember("CenterHeader", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("CenterHeader", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回一个 Graphic 对象，该对象表示页眉中间部分的图片。用于设置图片的属性。
        /// </summary>
        public Graphic CenterHeaderPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("CenterHeaderPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>如果在页面的水平居中位置打印指定工作表，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool CenterHorizontally
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("CenterHorizontally", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("CenterHorizontally", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果在页面的垂直居中位置打印指定工作表，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool CenterVertically
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("CenterVertically", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("CenterVertically", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlObjectSize ChartSize
        {
            get { return (XlObjectSize)_objPageSetup.GetType().InvokeMember("ChartSize", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("ChartSize", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objPageSetup.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objPageSetup, null); }
        }

        /// <summary>如果在第一页使用不同的页眉或页脚，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DifferentFirstPageHeaderFooter
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("DifferentFirstPageHeaderFooter", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("DifferentFirstPageHeaderFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果打印工作表时不打印其中的图形，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Draft
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("Draft", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("Draft", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置工作簿或节的偶数页上的文本对齐方式。
        /// </summary>
        public Page EvenPage
        {
            get { return new Page(_objPageSetup.GetType().InvokeMember("EvenPage", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>返回或设置工作簿或节的第一页上的文本对齐方式。
        /// </summary>
        public Page FirstPage
        {
            get { return new Page(_objPageSetup.GetType().InvokeMember("FirstPage", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>返回或设置打印指定工作表时第一页的页号。如果设为 xlAutomatic，则 Microsoft Excel 采用第一页的页号。默认值为 xlAutomatic。Long 类型，可读写。
        /// </summary>
        public int FirstPageNumber
        {
            get { return (int)_objPageSetup.GetType().InvokeMember("FirstPageNumber", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("FirstPageNumber", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置打印工作表时，对工作表进行缩放使用的页高。仅应用于工作表。Variant 类型，可读写。
        /// </summary>
        public dynamic FitToPagesTall
        {
            get { return _objPageSetup.GetType().InvokeMember("FitToPagesTall", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("FitToPagesTall", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置打印工作表时，对工作表进行缩放使用的页宽。仅应用于工作表。Variant 类型，可读写。
        /// </summary>
        public dynamic FitToPagesWide
        {
            get { return _objPageSetup.GetType().InvokeMember("FitToPagesWide", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("FitToPagesWide", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置页脚到页面底端的距离。Double 类型，可读写。
        /// </summary>
        public double FooterMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("FooterMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("FooterMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置页面顶端到页眉的距离。Double 类型，可读写。
        /// </summary>
        public double HeaderMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("HeaderMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("HeaderMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置工作簿或节的左页脚上的文本对齐方式。
        /// </summary>
        public string LeftFooter
        {
            get { return _objPageSetup.GetType().InvokeMember("LeftFooter", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("LeftFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回一个 Graphic 对象，该对象表示页脚左边的图片。用于设置图片的属性。
        /// </summary>
        public Graphic LeftFooterPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("LeftFooterPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>返回或设置工作簿或节的左页眉上的文本对齐方式。
        /// </summary>
        public string LeftHeader
        {
            get { return _objPageSetup.GetType().InvokeMember("LeftHeader", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("LeftHeader", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回一个 Graphic 对象，该对象表示页眉左边的图片。用于设置图片的属性。
        /// </summary>
        public Graphic LeftHeaderPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("LeftHeaderPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>以磅为单位返回或设置左边距的大小。Double 类型，可读写。
        /// </summary>
        public double LeftMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("LeftMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("LeftMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果指定的 PageSetup 对象的奇数页和偶数页具有不同的页眉和页脚，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool OddAndEvenPagesHeaderFooter
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("OddAndEvenPagesHeaderFooter", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("OddAndEvenPagesHeaderFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlOrder 值，它代表 Microsoft Excel 打印一张大工作表时所使用的页编号的次序。
        /// </summary>
        public XlOrder Order
        {
            get { return (XlOrder)_objPageSetup.GetType().InvokeMember("Order", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("Order", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlPageOrientation 值，它代表纵向或横向打印模式。
        /// </summary>
        public XlPageOrientation Orientation
        {
            get { return (XlPageOrientation)_objPageSetup.GetType().InvokeMember("Orientation", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置 Pages 集合中的页数。
        /// </summary>
        public Pages Pages
        {
            get { return new Pages(_objPageSetup.GetType().InvokeMember("Pages", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>返回或设置纸张的大小。XlPaperSize 类型，可读写。
        /// </summary>
        public XlPaperSize PaperSize
        {
            get { return (XlPaperSize)_objPageSetup.GetType().InvokeMember("PaperSize", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PaperSize", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objPageSetup.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objPageSetup, null); }
        }

        /// <summary>以字符串返回或设置要打印的区域，该字符串使用宏语言的 A1 样式的引用。String 类型，可读写。
        /// </summary>
        public string PrintArea
        {
            get { return _objPageSetup.GetType().InvokeMember("PrintArea", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("PrintArea", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置批注随工作表打印的方式。XlPrintLocation 类型，可读写。
        /// </summary>
        public XlPrintLocation PrintComments
        {
            get { return (XlPrintLocation)_objPageSetup.GetType().InvokeMember("PrintComments", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PrintComments", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>设置或返回一个 XlPrintErrors 常量，该常量指定显示的打印错误类型。该功能允许用户在打印工作表时取消错误显示。可读写。
        /// </summary>
        public XlPrintErrors PrintErrors
        {
            get { return (XlPrintErrors)_objPageSetup.GetType().InvokeMember("PrintErrors", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PrintErrors", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果在页面上打印单元格网格线，则该值为 True。仅应用于工作表。Boolean 类型，可读写。
        /// </summary>
        public bool PrintGridlines
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("PrintGridlines", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PrintGridlines", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果打印本页时同时打印行标题和列标题，则该值为 True。仅应用于工作表。Boolean 类型，可读写。
        /// </summary>
        public bool PrintHeadings
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("PrintHeadings", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PrintHeadings", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>如果打印工作表时单元格批注作为尾注一起打印，则该值为 True。仅应用于工作表。Boolean 类型，可读写。
        /// </summary>
        public bool PrintNotes
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("PrintNotes", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("PrintNotes", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置包含在每一页的左边重复出现的单元格的列，用宏语言 A1-样式中的字符串表示。String 类型，可读写。
        /// </summary>
        public string PrintTitleColumns
        {
            get { return _objPageSetup.GetType().InvokeMember("PrintTitleColumns", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("PrintTitleColumns", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置那些包含在每一页顶部重复出现的单元格的行，用宏语言字符串以 A1 样式表示法表示。String 类型，可读写。
        /// </summary>
        public string PrintTitleRows
        {
            get { return _objPageSetup.GetType().InvokeMember("PrintTitleRows", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("PrintTitleRows", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置页面右边缘与页脚右边界之间的距离（以磅为单位）。可读/写 String 类型。
        /// </summary>
        public string RightFooter
        {
            get { return _objPageSetup.GetType().InvokeMember("RightFooter", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("RightFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回一个 Graphic 对象，该对象代表页脚右边的图片，用于设置图片的属性。
        /// </summary>
        public Graphic RightFooterPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("RightFooterPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>返回或设置页眉的右边部分内容。可读/写 String 类型。
        /// </summary>
        public string RightHeader
        {
            get { return _objPageSetup.GetType().InvokeMember("RightHeader", BindingFlags.GetProperty, null, _objPageSetup, null).ToString(); }
            set { _objPageSetup.GetType().InvokeMember("RightHeader", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>指定右页眉中应显示的图形图像。只读。
        /// </summary>
        public Graphic RightHeaderPicture
        {
            get { return new Graphic(_objPageSetup.GetType().InvokeMember("RightHeaderPicture", BindingFlags.GetProperty, null, _objPageSetup, null)); }
        }

        /// <summary>以磅为单位返回或设置右边距的大小。Double 类型，可读写。
        /// </summary>
        public double RightMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("RightMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("RightMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置页眉和页脚是否在文档大小更改时随文档缩放。可读/写 Boolean 类型。
        /// </summary>
        public bool ScaleWithDocHeaderFooter
        {
            get { return (bool)_objPageSetup.GetType().InvokeMember("ScaleWithDocHeaderFooter", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("ScaleWithDocHeaderFooter", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置上边距的大小。Double 类型，可读写。
        /// </summary>
        public double TopMargin
        {
            get { return (double)_objPageSetup.GetType().InvokeMember("TopMargin", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("TopMargin", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表一个数值在 10% 到 400% 之间的百分比，该百分比为 Microsoft Excel 打印工作表时的缩放比例。
        /// </summary>
        public dynamic Zoom
        {
            get { return _objPageSetup.GetType().InvokeMember("Zoom", BindingFlags.GetProperty, null, _objPageSetup, null); }
            set { _objPageSetup.GetType().InvokeMember("Zoom", BindingFlags.SetProperty, null, _objPageSetup, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>文档页面的集合。使用 Pages 集合及相关对象和属性可通过编程方式定义工作簿的页面布局。
    /// 说明：
    /// 使用 Pages 属性可返回 Pages 集合。下面的示例访问活动工作表的所有页面。
    /// </summary>
    public class Pages
    {
        public object _objPages;

        internal Pages(object objPages)
        { _objPages = objPages; }

        public Page this[object Index]
        {
            get
            {
                object objPage = _objPages.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPages, new object[1] { Index });

                if (objPage == null)
                    return null;
                else
                    return new Page(objPage);
            }
        }

        /// <summary>返回集合中对象的数目。只读 Long 类型。
        /// </summary>
        public int Count
        {
            get { return (int)_objPages.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objPages, null); }
        }
    }

    /// <summary>代表工作表的页面。使用 PageSetup 对象及相关方法和属性可通过编程方式定义工作簿的页面布局。
    /// 说明：
    /// 使用 Item 方法可访问工作簿的特定页面。下面的示例访问活动工作簿的第一页。
    /// </summary>
    public class Page
    {
        public object _objPage;

        internal Page(object objPage)
        { _objPage = objPage; }

        #region 属性
        /// <summary>指定要在页脚中居中对齐的图片或文本。
        /// </summary>
        public HeaderFooter CenterFooter
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("CenterFooter", BindingFlags.GetProperty, null, _objPage, null)); }
        }

        /// <summary>指定要在页眉中居中对齐的图片或文本。
        /// </summary>
        public HeaderFooter CenterHeader
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("CenterHeader", BindingFlags.GetProperty, null, _objPage, null)); }
        }

        /// <summary>指定要在页脚中左对齐的图片或文本。
        /// </summary>
        public HeaderFooter LeftFooter
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("LeftFooter", BindingFlags.GetProperty, null, _objPage, null)); }
        }

        /// <summary>指定要在页眉中左对齐的图片或文本。
        /// </summary>
        public HeaderFooter LeftHeader
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("LeftHeader", BindingFlags.GetProperty, null, _objPage, null)); }
        }

        /// <summary>指定要在页脚中右对齐的图片或文本。
        /// </summary>
        public HeaderFooter RightFooter
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("RightFooter", BindingFlags.GetProperty, null, _objPage, null)); }
        }

        /// <summary>指定要在页眉中右对齐的图片或文本。
        /// </summary>
        public HeaderFooter RightHeader
        {
            get { return new HeaderFooter(_objPage.GetType().InvokeMember("RightHeader", BindingFlags.GetProperty, null, _objPage, null)); }
        }
        #endregion 属性
    }

    /// <summary>包括应用于页眉和页脚的图片对象的属性。
    /// 说明
    /// PageSetup 对象有若干个属性返回 Graphic 对象。
    /// 使用 CenterFooterPicture、CenterHeaderPicture、LeftFooterPicture、LeftHeaderPicture、RightFooterPicture 或 RightHeaderPicture 属性可返回一个 Graphic 对象。
    /// </summary>
    public class Graphic
    {
        public object _objGraphic;

        internal Graphic(object objGraphic)
        { _objGraphic = objGraphic; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objGraphic.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objGraphic, null)); }
        }

        /// <summary>返回或设置指定图片或 OLE 对象的亮度。该属性的值必须是 0.0（最暗）到 1.0（最亮）之间的数。Single 型，可读写。
        /// </summary>
        public float Brightness
        {
            get { return (float)_objGraphic.GetType().InvokeMember("Brightness", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("Brightness", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置应用于指定图片或 OLE 对象的颜色转换类型。MsoPictureColorType 类型，可读写。
        /// </summary>
        public MsoPictureColorType ColorType
        {
            get { return (MsoPictureColorType)_objGraphic.GetType().InvokeMember("ColorType", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("ColorType", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置指定图片或 OLE 对象的对比度。该属性的值必须是 0.0（最低对比度）到 1.0（最高对比度）的数。Single 型，可读写。
        /// </summary>
        public float Contrast
        {
            get { return (float)_objGraphic.GetType().InvokeMember("Contrast", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("Contrast", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objGraphic.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objGraphic, null); }
        }

        /// <summary>返回或设置从指定图片或 OLE 对象的底部所裁剪下的磅数。Single 型，可读写。
        /// </summary>
        public float CropBottom
        {
            get { return (float)_objGraphic.GetType().InvokeMember("CropBottom", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("CropBottom", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置从指定图片或 OLE 对象的左边所裁剪下的磅数。Single 型，可读写。
        /// </summary>
        public float CropLeft
        {
            get { return (float)_objGraphic.GetType().InvokeMember("CropLeft", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("CropLeft", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置从指定图片或 OLE 对象的右边所裁剪下的磅数。Single 型，可读写。
        /// </summary>
        public float CropRight
        {
            get { return (float)_objGraphic.GetType().InvokeMember("CropRight", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("CropRight", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置从指定图片或 OLE 对象的顶部所裁剪下的磅数。Single 型，可读写。
        /// </summary>
        public float CropTop
        {
            get { return (float)_objGraphic.GetType().InvokeMember("CropTop", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("CropTop", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置保存指定源对象位置的 URL（Intranet 或网站上）或路径（本地或网络）。String 型，可读写。
        /// </summary>
        public string Filename
        {
            get { return _objGraphic.GetType().InvokeMember("Filename", BindingFlags.GetProperty, null, _objGraphic, null).ToString(); }
            set { _objGraphic.GetType().InvokeMember("Filename", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的高度（以磅为单位）。
        /// </summary>
        public float Height
        {
            get { return (float)_objGraphic.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("Height", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>如果指定的形状在调整大小时其原始比例保持不变，则此属性为 True。如果调整大小时可以分别更改形状的高度和宽度，则此属性为 False。MsoTriState 类型，可读写。
        /// </summary>
        public MsoTriState LockAspectRatio
        {
            get { return (MsoTriState)_objGraphic.GetType().InvokeMember("LockAspectRatio", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("LockAspectRatio", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objGraphic.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objGraphic, null); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的宽度（以磅为单位）。
        /// </summary>
        public float Width
        {
            get { return (float)_objGraphic.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objGraphic, null); }
            set { _objGraphic.GetType().InvokeMember("Width", BindingFlags.SetProperty, null, _objGraphic, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>文档页面的集合。使用 Pages 集合及相关对象和属性可通过编程方式定义工作簿的页面布局。
    /// 说明：
    /// 您也可以使用 HeaderFooter 属性和 Selection 对象来返回单个 HeaderFooter 对象。
    /// </summary>
    public class HeaderFooter
    {
        public object _objHeaderFooter;

        internal HeaderFooter(object objHeaderFooter)
        { _objHeaderFooter = objHeaderFooter; }

        /// <summary>返回一个 Picture 对象，该对象代表指定页眉或页脚中包含的图片字段。只读。
        /// </summary>
        public Graphic Picture
        {
            get { return new Graphic(_objHeaderFooter.GetType().InvokeMember("Picture", BindingFlags.GetProperty, null, _objHeaderFooter, null)); }
        }

        /// <summary>返回或设置一个 Text 对象，该对象代表指定页眉或页脚中包含的文本。可读/写。
        /// </summary>
        public string Text
        {
            get { return _objHeaderFooter.GetType().InvokeMember("Text", BindingFlags.GetProperty, null, _objHeaderFooter, null).ToString(); }
            set { _objHeaderFooter.GetType().InvokeMember("Text", BindingFlags.SetProperty, null, _objHeaderFooter, new object[1] { value }); }
        }
    }

    /// <summary>包含对象的字体属性（字体名称、字号、颜色等等）。
    /// 说明：
    /// 如果不想将单元格中的文本或图形设为相同的格式，则使用 Characters 属性返回文本的子集。
    /// </summary>
    public class Font
    {
        public object _objFont;

        public Font(object objFont)
        {
            _objFont = objFont;
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objFont.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objFont, null)); }
        }

        /// <summary>返回或设置图表中使用的文本的背景类型。XlBackground 类型，可读写。可将其设置为 XlBackground 常量之一。
        /// </summary>
        public XlBackground Background
        {
            get { return (XlBackground)_objFont.GetType().InvokeMember("Background", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Background", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>如果字体格式为加粗，则该属性值为 True。bool 类型，可读写。
        /// </summary>
        public bool Bold
        {
            get { return (bool)_objFont.GetType().InvokeMember("Bold", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Bold", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置对象的主要颜色，如注释部分中的表格所示。使用 RGB 函数可创建颜色值。int 型，可读写。
        /// </summary>
        public int Color
        {
            get { return (int)_objFont.GetType().InvokeMember("Color", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Color", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 int 值，它代表字体的颜色。
        /// </summary>
        public int ColorIndex
        {
            get { return (int)_objFont.GetType().InvokeMember("ColorIndex", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objFont.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objFont, null); }
        }

        /// <summary>返回或设置字体样式。String 类型，可读写。
        /// </summary>
        public string FontStyle
        {
            get { return _objFont.GetType().InvokeMember("FontStyle", BindingFlags.GetProperty, null, _objFont, null).ToString(); }
            set { _objFont.GetType().InvokeMember("FontStyle", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>如果字体样式为倾斜，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Italic
        {
            get { return (bool)_objFont.GetType().InvokeMember("Italic", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Italic", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objFont.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objFont, null).ToString(); }
            set { _objFont.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public dynamic OutlineFont
        {
            get { return _objFont.GetType().InvokeMember("OutlineFont", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("OutlineFont", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objFont.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objFont, null); }
        }

        /// <summary>
        /// </summary>
        public dynamic Shadow
        {
            get { return _objFont.GetType().InvokeMember("Shadow", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Shadow", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置字号。可读/写 Variant 类型。
        /// </summary>
        public dynamic Size
        {
            get { return _objFont.GetType().InvokeMember("Size", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>如果文字中间有一条水平删除线，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Strikethrough
        {
            get { return (bool)_objFont.GetType().InvokeMember("Strikethrough", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Strikethrough", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>如果字体格式设置为下标，则该属性值为 True。默认值为 False。bool 类型，可读写。
        /// </summary>
        public bool Subscript
        {
            get { return (bool)_objFont.GetType().InvokeMember("Subscript", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Subscript", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>如果字体格式设置为上标字符，则该属性值为 True；默认值为 False。bool 类型，可读写。
        /// </summary>
        public bool Superscript
        {
            get { return (bool)_objFont.GetType().InvokeMember("Superscript", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Superscript", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置已应用的配色方案中的主题颜色，该配色方案与指定对象相关联。可读/写 int 类型。
        /// </summary>
        public int ThemeColor
        {
            get { return (int)_objFont.GetType().InvokeMember("ThemeColor", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("ThemeColor", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置与指定对象关联的应用字体方案中的主题字体。可读/写 XlThemeFont 类型。
        /// </summary>
        public XlThemeFont ThemeFont
        {
            get { return (XlThemeFont)_objFont.GetType().InvokeMember("ThemeFont", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("ThemeFont", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single，使颜色变深或变浅。
        /// </summary>
        public float TintAndShade
        {
            get { return (float)_objFont.GetType().InvokeMember("TintAndShade", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("TintAndShade", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }

        /// <summary>返回或设置应用于字体的下划线类型。可为以下 XlUnderlineStyle 常量之一。Variant 类型，可读写。    /// xlUnderlineStyleNone 
        /// xlUnderlineStyleSingle  
        /// xlUnderlineStyleDouble 
        /// xlUnderlineStyleSingleAccounting 
        /// xlUnderlineStyleDoubleAccounting 
        /// </summary>
        public XlUnderlineStyle Underline
        {
            get { return (XlUnderlineStyle)_objFont.GetType().InvokeMember("Underline", BindingFlags.GetProperty, null, _objFont, null); }
            set { _objFont.GetType().InvokeMember("Underline", BindingFlags.SetProperty, null, _objFont, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>由四个 Border 对象组成的集合，它们分别代表 Range 或 Style 对象的四个边框。
    /// 说明
    /// 使用 Borders 属性可返回包含所有四个边框的 Borders 集合。
    /// 只能对 Range 和 Style 对象的各个边框分别设置边框属性。其他带边框的对象（如误差线和系列线）不论边框有几个边，都将边框视为一个实体。对于这些对象，在返回边框和设置边框属性时必须将其作为一个整体处理。有关详细信息，请参阅 Border 对象。
    /// </summary>
    public class Borders
    {
        public object _objBorders;
        internal object[] _objaParameters;

        public Borders(object objBorders)
        { _objBorders = objBorders; }

        public Border this[XlBordersIndex Index]
        {
            get
            {
                _objaParameters = new object[1] { Index };
                object objBorder = _objBorders.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objBorders, _objaParameters);

                if (objBorder == null)
                    return null;
                else
                    return new Border(objBorder);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个代表指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objBorders.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objBorders, null)); }
        }

        /// <summary>返回或设置对象的主要颜色，如注释部分中的表格所示。使用 RGB 函数可创建颜色值。int 型，可读写。
        /// </summary>
        public int Color
        {
            get { return (int)_objBorders.GetType().InvokeMember("Color", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("Color", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 int 值，它代表全部四条边框的颜色。
        /// </summary>
        public int ColorIndex
        {
            get { return (int)_objBorders.GetType().InvokeMember("ColorIndex", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objBorders.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objBorders, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objBorders.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objBorders, null); }
        }

        /// <summary>返回或设置边框的线型。XlLineStyle、xlGray25、xlGray50、xlGray75 或 xlAutomatic 类型，可读写。
        /// </summary>
        public XlLineStyle LineStyle
        {
            get { return (XlLineStyle)_objBorders.GetType().InvokeMember("LineStyle", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objBorders.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objBorders, null); }
        }

        /// <summary>返回或设置已应用的配色方案中的主题颜色，该配色方案与指定对象相关联。可读/写 int 类型。
        /// </summary>
        public int ThemeColor
        {
            get { return (int)_objBorders.GetType().InvokeMember("ThemeColor", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("ThemeColor", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single，使颜色变深或变浅。
        /// </summary>
        public float TintAndShade
        {
            get { return (float)_objBorders.GetType().InvokeMember("TintAndShade", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("TintAndShade", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>Borders.LineStyle 的同义词。
        /// </summary>
        public dynamic Value
        {
            get { return _objBorders.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlBorderWeight 值，它代表边框的粗细。
        /// </summary>
        public XlBorderWeight Weight
        {
            get { return (XlBorderWeight)_objBorders.GetType().InvokeMember("Weight", BindingFlags.GetProperty, null, _objBorders, null); }
            set { _objBorders.GetType().InvokeMember("Weight", BindingFlags.SetProperty, null, _objBorders, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>代表对象的边框。
    /// 说明
    /// 大多数具有边框的对象（除 Range 和 Style 对象外）都将边框作为单一实体处理，而不管边框有几个边。整个边框必须作为一个整体单位返回。例如，使用 TrendLine 对象的 Border 属性可返回此类对象的 Border 对象。
    /// </summary>
    public class Border
    {
        public object _objBorder;

        public Border(object objBorder)
        { _objBorder = objBorder; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个代表指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objBorder.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objBorder, null)); }
        }

        /// <summary>返回或设置对象的主要颜色，如注释部分中的表格所示。使用 RGB 函数可创建颜色值。int 型，可读写。
        /// </summary>
        public int Color
        {
            get { return (int)_objBorder.GetType().InvokeMember("Color", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("Color", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 int 值，它代表边框的颜色。
        /// </summary>
        public int ColorIndex
        {
            get { return (int)_objBorder.GetType().InvokeMember("ColorIndex", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objBorder.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objBorder, null); }
        }

        /// <summary>返回或设置边框的线型。XlLineStyle、xlGray25、xlGray50、xlGray75 或 xlAutomatic 类型，可读写。
        /// </summary>
        public XlLineStyle LineStyle
        {
            get { return (XlLineStyle)_objBorder.GetType().InvokeMember("LineStyle", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objBorder.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objBorder, null); }
        }

        /// <summary>返回或设置已应用的配色方案中的主题颜色，该配色方案与指定对象相关联。可读/写 int 类型。
        /// </summary>
        public int ThemeColor
        {
            get { return (int)_objBorder.GetType().InvokeMember("ThemeColor", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("ThemeColor", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single，使颜色变深或变浅。
        /// </summary>
        public float TintAndShade
        {
            get { return (float)_objBorder.GetType().InvokeMember("TintAndShade", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("TintAndShade", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlBorderWeight 值，它代表边框的粗细。
        /// </summary>
        public XlBorderWeight Weight
        {
            get { return (XlBorderWeight)_objBorder.GetType().InvokeMember("Weight", BindingFlags.GetProperty, null, _objBorder, null); }
            set { _objBorder.GetType().InvokeMember("Weight", BindingFlags.SetProperty, null, _objBorder, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>Microsoft Excel 中所有 Window 对象的集合。
    /// 说明
    /// Application 对象的 Windows 集合包含应用程序中的所有窗口，而 Workbook 对象的 Windows 集合只包含指定工作簿中的窗口。
    /// </summary>
    public class Windows
    {
        public object _objWindows;
        internal object[] _objaParameters;

        public Windows(object objWindows)
        {
            _objWindows = objWindows;
        }

        public Window this[object Index]
        {
            get
            {
                _objaParameters = new object[1] { Index };
                object objWindow = _objWindows.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objWindows, _objaParameters);

                if (objWindow == null)
                    return null;
                else
                    return new Window(objWindow);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWindows.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWindows, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objWindows.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objWindows, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWindows.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWindows, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWindows.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWindows, null); }
        }

        /// <summary>如果为 True，在对文档进行并排比较的同时启用窗口内容的滚动功能。若为 False，则在对文档进行并排比较的同时禁用窗口内容的滚动功能。
        /// </summary>
        public bool SyncScrollingSideBySide
        {
            get { return (bool)_objWindows.GetType().InvokeMember("SyncScrollingSideBySide", BindingFlags.GetProperty, null, _objWindows, null); }
            set { _objWindows.GetType().InvokeMember("SyncScrollingSideBySide", BindingFlags.SetProperty, null, _objWindows, new object[1] { value }); }
        }
        #endregion 属性

        #region 方法
        /// <summary>对屏幕上的窗口进行排列。
        /// </summary>
        /// <param name="ArrangeStyle">XlArrangeStyle 常量之一，指定窗口排列方式。</param>
        /// <param name="ActiveWorkbook">如果为 True，则只排列活动工作簿的可见窗口。如果为 False，则排列所有窗口。默认值为 False。</param>
        /// <param name="SyncHorizontal">如果 ActiveWorkbook 为 False 或省略，则忽略此参数。如果为 True，则在水平滚动时同步活动工作簿的窗口。如果为 False，则不同步窗口。默认值为 False。</param>
        /// <param name="SyncVertical">如果 ActiveWorkbook 为 False 或省略，则忽略此参数。如果为 True，则在垂直滚动时同步活动工作簿的窗口。如果为 False，则不同步窗口。默认值为 False。</param>
        public dynamic Arrange(XlArrangeStyle ArrangeStyle = XlArrangeStyle.xlArrangeStyleTiled, bool? ActiveWorkbook = null, bool? SyncHorizontal = null, bool? SyncVertical = null)
        {
            _objaParameters = new object[4] {
                ArrangeStyle,
                ActiveWorkbook == null ? System.Type.Missing : ActiveWorkbook,
                SyncHorizontal == null ? System.Type.Missing : SyncHorizontal,
                SyncVertical == null ? System.Type.Missing : SyncVertical
            };

            return _objWindows.GetType().InvokeMember("Arrange", BindingFlags.InvokeMethod, null, _objWindows, _objaParameters);
        }

        /// <summary>使用此方法可结束两个窗口的并排模式。返回一个表明此方法是否成功的 Boolean 值。
        /// </summary>
        public bool BreakSideBySide()
        {
            return (bool)_objWindows.GetType().InvokeMember("BreakSideBySide", BindingFlags.InvokeMethod, null, _objWindows, null);
        }

        /// <summary>以并排模式打开两个窗口。返回一个 Boolean 值。
        /// </summary>
        /// <param name="WindowName">窗口的名称。</param>
        public bool CompareSideBySideWith(string WindowName)
        {
            _objaParameters = new object[1] { WindowName };

            return (bool)_objWindows.GetType().InvokeMember("CompareSideBySideWith", BindingFlags.InvokeMethod, null, _objWindows, _objaParameters);
        }

        /// <summary>重置正在进行并排比较的两个工作表窗口的位置。
        /// </summary>
        public void ResetPositionsSideBySide()
        {
            _objWindows.GetType().InvokeMember("ResetPositionsSideBySide", BindingFlags.InvokeMethod, null, _objWindows, null);
        }
        #endregion 方法
    }

    /// <summary>代表窗口。
    /// 说明：
    /// 许多工作表特征（如滚动条和标尺）实际上是窗口的属性。Window 对象是 Windows 集合的成员。Application 对象的 Windows 集合包含应用程序中的所有窗口，而 Workbook 对象的 Windows 集合只包含指定工作簿中的窗口。
    /// </summary>
    public class Window
    {
        public object _objWindow;
        internal object[] _objaParameters;

        public Window(object objWindow)
        {
            _objWindow = objWindow;
        }

        #region 属性
        /// <summary>返回一个 Range 对象，它代表活动窗口（最上方的窗口）或指定窗口中的活动单元格。如果窗口中没有显示工作表，此属性无效。只读。
        /// </summary>
        public Range ActiveCell
        {
            get { return new Range(_objWindow.GetType().InvokeMember("ActiveCell", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>返回一个 Chart 对象，它代表活动图表（嵌入式图表或图表工作表）。嵌入式图表在被选中或激活时被认为是活动的。当没有图表处于活动状态时，此属性返回 Nothing。
        /// </summary>
        public Chart ActiveChart
        {
            get
            {
                object objActiveChart = _objWindow.GetType().InvokeMember("ActiveChart", BindingFlags.GetProperty, null, _objWindow, null);

                if (objActiveChart == null)
                    return null;
                else
                    return new Chart(objActiveChart);
            }
        }

        /// <summary>返回一个 Pane 对象，该对象表示窗口中的活动窗格。只读。
        /// </summary>
        public Pane ActivePane
        {
            get { return new Pane(_objWindow.GetType().InvokeMember("ActivePane", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>返回一个对象，它代表活动工作簿中或指定的窗口或工作簿中的活动工作表（最上面的工作表）。如果没有活动的工作表，则返回 Nothing。
        /// </summary>
        public dynamic ActiveSheet
        {
            // 有 Nothing
            get { return _objWindow.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回一个对象，该对象代表指定窗口中活动工作表的视图。只读。
        /// </summary>
        public dynamic ActiveSheetView
        {
            get { return _objWindow.GetType().InvokeMember("ActiveSheetView", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objWindow.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>如果用于日期分组的自动筛选器当前显示在指定的窗口中，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool AutoFilterDateGrouping
        {
            get { return (bool)_objWindow.GetType().InvokeMember("AutoFilterDateGrouping", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("AutoFilterDateGrouping", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Variant 值，它代表文档窗口标题栏中显示的名称。
        /// </summary>
        public string Caption
        {
            get { return _objWindow.GetType().InvokeMember("Caption", BindingFlags.GetProperty, null, _objWindow, null).ToString(); }
            set { _objWindow.GetType().InvokeMember("Caption", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objWindow.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>如果窗口正显示公式，则为 True；如果窗口正显示值，则为 False。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayFormulas
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayFormulas", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayFormulas", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示网格线，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayGridlines
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayGridlines", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayGridlines", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果同时显示行标题和列标题，则为 True；如果未显示标题，则为 False。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayHeadings
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayHeadings", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayHeadings", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示水平滚动条，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayHorizontalScrollBar
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayHorizontalScrollBar", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayHorizontalScrollBar", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示分级显示符号，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayOutline
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayOutline", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayOutline", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果指定的窗口或工作表是从右到左显示（而非从左到右），则为 True。如果对象从左到右显示，则为 False。Boolean 类型，只读。
        /// </summary>
        public bool DisplayRightToLeft
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayRightToLeft", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayRightToLeft", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果在指定窗口中显示标尺，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayRuler
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayRuler", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayRuler", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示垂直滚动条，则该属性值为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayVerticalScrollBar
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayVerticalScrollBar", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayVerticalScrollBar", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示空白，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayWhitespace
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayWhitespace", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayWhitespace", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示工作簿标签，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool DisplayWorkbookTabs
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayWorkbookTabs", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayWorkbookTabs", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果显示零值，则为 True。可读/写 Boolean 类型。
        /// </summary>
        public bool DisplayZeros
        {
            get { return (bool)_objWindow.GetType().InvokeMember("DisplayZeros", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("DisplayZeros", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果能够调整窗口大小，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool EnableResize
        {
            get { return (bool)_objWindow.GetType().InvokeMember("EnableResize", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("EnableResize", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>如果拆分窗格被冻结，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool FreezePanes
        {
            get { return (bool)_objWindow.GetType().InvokeMember("FreezePanes", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("FreezePanes", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>以 RGB 值返回或设置网格线颜色。Long 类型，可读写。
        /// </summary>
        public int GridlineColor
        {
            get { return (int)_objWindow.GetType().InvokeMember("GridlineColor", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("GridlineColor", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置网格线颜色，其值为当前调色板中的索引，或为下列 XlColorIndex 常量。
        /// </summary>
        public XlColorIndex GridlineColorIndex
        {
            get { return (XlColorIndex)_objWindow.GetType().InvokeMember("GridlineColorIndex", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("GridlineColorIndex", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Double 值，它代表窗口的高度（以磅为单位）。
        /// </summary>
        public double Height
        {
            get { return (double)_objWindow.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Height", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回 Long 值，它代表对象在其同类对象所组成的集合内的索引号。
        /// </summary>
        public int Index
        {
            get { return (int)_objWindow.GetType().InvokeMember("Index", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回一个 Double 值，它代表从客户区左边缘到窗口左边缘的距离（以磅为单位）。
        /// </summary>
        public double Left
        {
            get { return (double)_objWindow.GetType().InvokeMember("Left", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Left", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置每当激活一个窗口时要运行的过程的名称。String 型，可读写。
        /// </summary>
        public string OnWindow
        {
            get { return _objWindow.GetType().InvokeMember("OnWindow", BindingFlags.GetProperty, null, _objWindow, null).ToString(); }
            set { _objWindow.GetType().InvokeMember("OnWindow", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回一个 Panes 集合，该集合表示指定窗口中的所有窗格。只读。
        /// </summary>
        public Panes Panes
        {
            get { return new Panes(_objWindow.GetType().InvokeMember("Panes", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objWindow.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回一个 Range 对象，该对象表示指定窗口中工作表上的选定单元格，即使工作表上一个图形对象是活动或选定的。只读。
        /// </summary>
        public Range RangeSelection
        {
            get { return new Range(_objWindow.GetType().InvokeMember("RangeSelection", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>返回或设置指定窗格或窗口最左边的列号。Long 型，可读写。
        /// </summary>
        public int ScrollColumn
        {
            get { return (int)_objWindow.GetType().InvokeMember("ScrollColumn", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("ScrollColumn", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置指定窗格或窗口最上面显示的行号。Long 型，可读写。
        /// </summary>
        public int ScrollRow
        {
            get { return (int)_objWindow.GetType().InvokeMember("ScrollRow", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("ScrollRow", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回一个 Sheets 集合，该集合表示指定窗口中所有选定工作表。只读。
        /// </summary>
        public Sheets SelectedSheets
        {
            get { return new Sheets(_objWindow.GetType().InvokeMember("SelectedSheets", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>对于 Windows 对象，返回一个指定的窗口。
        /// </summary>
        public dynamic Selection
        {
            get { return _objWindow.GetType().InvokeMember("Selection", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回指定窗口的 SheetViews 对象。只读。
        /// </summary>
        public SheetViews SheetViews
        {
            get { return new SheetViews(_objWindow.GetType().InvokeMember("SheetViews", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>如果指定窗口被拆分，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool Split
        {
            get { return (bool)_objWindow.GetType().InvokeMember("Split", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Split", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置将指定窗口拆分成窗格处的列号（拆分线左侧的列数）。Long 类型，可读写。
        /// </summary>
        public int SplitColumn
        {
            get { return (int)_objWindow.GetType().InvokeMember("SplitColumn", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("SplitColumn", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置窗口水平拆分线的位置。Double 类型，可读写。
        /// </summary>
        public double SplitHorizontal
        {
            get { return (double)_objWindow.GetType().InvokeMember("SplitHorizontal", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("SplitHorizontal", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置将指定窗口拆分成窗格处的行号（拆分线以上的行数）。Long 类型，可读写。
        /// </summary>
        public int SplitRow
        {
            get { return (int)_objWindow.GetType().InvokeMember("SplitRow", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("SplitRow", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>以磅为单位返回或设置窗口垂直拆分线的位置。Double 类型，可读写。
        /// </summary>
        public double SplitVertical
        {
            get { return (double)_objWindow.GetType().InvokeMember("SplitVertical", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("SplitVertical", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置工作簿中工作表标签区域的宽度与窗口水平滚动条的宽度比例（可为 0 到 1 之间的数字；默认值为 0.6）。Double 类型，可读写。
        /// </summary>
        public double TabRatio
        {
            get { return (double)_objWindow.GetType().InvokeMember("TabRatio", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("TabRatio", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Double 值，它代表从窗口上边缘到使用区域（在菜单、任何停放在顶端的工具栏和编辑栏下方）上边缘的距离（以磅为单位）。
        /// </summary>
        public double Top
        {
            get { return (double)_objWindow.GetType().InvokeMember("Top", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Top", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个代表窗口类型的 XlWindowType 值。
        /// </summary>
        public XlWindowType Type
        {
            get { return (XlWindowType)_objWindow.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回在应用程序窗口区域中一个窗口能占有的最大高度（以磅为单位）。Double 型，只读。
        /// </summary>
        public double UsableHeight
        {
            get { return (double)_objWindow.GetType().InvokeMember("UsableHeight", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回在应用程序窗口区域中一个窗口能占有的最大宽度（以磅为单位）。Double 型，只读。
        /// </summary>
        public double UsableWidth
        {
            get { return (double)_objWindow.GetType().InvokeMember("UsableWidth", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回或设置在窗口中显示的视图。XlWindowView 类型，可读写。
        /// </summary>
        public XlWindowView View
        {
            get { return (XlWindowView)_objWindow.GetType().InvokeMember("View", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("View", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，它确定对象是否可见。可读写。
        /// </summary>
        public bool Visible
        {
            get { return (bool)_objWindow.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表显示在窗口或窗格中的单元格区域。如果列或行只显示了一部分，则说明它是包括在区域之内的。只读。
        /// </summary>
        public Range VisibleRange
        {
            get { return new Range(_objWindow.GetType().InvokeMember("VisibleRange", BindingFlags.GetProperty, null, _objWindow, null)); }
        }

        /// <summary>返回或设置一个 Double 值，它代表窗口的宽度（以磅为单位）。
        /// </summary>
        public double Width
        {
            get { return (double)_objWindow.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Width", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回窗口号。例如，名称为“Book1.xls:2”的窗口，其窗口号为 2。大多数窗口的窗口号为 1。Long 类型，只读。
        /// </summary>
        public int WindowNumber
        {
            get { return (int)_objWindow.GetType().InvokeMember("WindowNumber", BindingFlags.GetProperty, null, _objWindow, null); }
        }

        /// <summary>返回或设置窗口的状态。XlWindowState 类型，可读写。
        /// </summary>
        public XlWindowState WindowState
        {
            get { return (XlWindowState)_objWindow.GetType().InvokeMember("WindowState", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("WindowState", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 int 值，它代表窗口的显示大小，以百分数表示（100 表示正常大小，200 表示双倍大小，以此类推）。
        /// </summary>
        public int Zoom
        {
            get { return (int)_objWindow.GetType().InvokeMember("Zoom", BindingFlags.GetProperty, null, _objWindow, null); }
            set { _objWindow.GetType().InvokeMember("Zoom", BindingFlags.SetProperty, null, _objWindow, new object[1] { value }); }
        }
        #endregion 属性

        #region 方法
        /// <summary>将窗口提到 z-次序的最前面。
        /// </summary>
        public dynamic Activate()
        {
            return _objWindow.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, _objWindow, null);
        }

        /// <summary>激活指定窗口，并将其移到窗口 z-次序的末尾。
        /// </summary>
        public dynamic ActivateNext()
        {
            return _objWindow.GetType().InvokeMember("ActivateNext", BindingFlags.InvokeMethod, null, _objWindow, null);
        }

        /// <summary>激活指定窗口，然后激活窗口 z-次序末尾的窗口。
        /// </summary>
        public dynamic ActivatePrevious()
        {
            return _objWindow.GetType().InvokeMember("ActivatePrevious", BindingFlags.InvokeMethod, null, _objWindow, null);
        }

        /// <summary>关闭对象。
        /// </summary>
        /// <param name="SaveChanges">如果工作簿中没有改动，则忽略此参数。如果工作簿中有改动但工作簿显示在其他打开的窗口中，则忽略此参数。如果工作簿中有改动且工作簿未显示在任何其他打开的窗口中，则由此参数指定是否应保存更改。如果设为 True，则保存对工作簿所做的更改。如果工作簿尚未命名，则使用 Filename。如果省略 Filename，则要求用户提供文件名。</param>
        /// <param name="Filename">以此文件名保存所做的更改。</param>
        /// <param name="RouteWorkbook">如果工作簿不需要传送给下一个收件人（没有传送名单或已经传送），则忽略此参数。否则，Microsoft Excel 根据此参数的值传送工作簿。如果设为 True，则将工作簿传送给下一个收件人。如果设为 False，则不发送工作簿。如果忽略，则要求用户确认是否发送工作簿。</param>
        public bool Close(bool? SaveChanges = null, string Filename = null, bool? RouteWorkbook = null)
        {
            _objaParameters = new object[3] {
                SaveChanges == null ? System.Type.Missing : SaveChanges,
                Filename == null ? System.Type.Missing : Filename,
                RouteWorkbook == null ? System.Type.Missing : RouteWorkbook
            };

            return (bool)_objWindow.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>按页滚动窗口内容。
        /// </summary>
        /// <param name="Down">向下滚动内容的页数。</param>
        /// <param name="Up">向上滚动内容的页数。</param>
        /// <param name="ToRight">向右滚动内容的页数。</param>
        /// <param name="ToLeft">向左滚动内容的页数。</param>
        public dynamic LargeScroll(int? Down = null, int? Up = null, int? ToRight = null, int? ToLeft = null)
        {
            _objaParameters = new object[4] {
                Down == null ? System.Type.Missing : Down,
                Up == null ? System.Type.Missing : Up,
                ToRight == null ? System.Type.Missing : ToRight,
                ToLeft == null ? System.Type.Missing : ToLeft
            };

            return _objWindow.GetType().InvokeMember("LargeScroll", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>新建一个窗口或者创建指定窗口的副本。
        /// </summary>
        public Window NewWindow()
        {
            return new Window(_objWindow.GetType().InvokeMember("NewWindow", BindingFlags.InvokeMethod, null, _objWindow, null));
        }

        /// <summary>将横向度量值由以点（文档坐标）为单位转换为以屏幕像素（屏幕坐标）为单位。返回转变后的度量值（Long 类型）。
        /// </summary>
        /// <param name="Points">从文档窗口的左侧开始沿其顶部水平排列的点数。</param>
        public int PointsToScreenPixelsX(int Points)
        {
            _objaParameters = new object[1] { Points };

            return (int)_objWindow.GetType().InvokeMember("PointsToScreenPixelsX", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>将纵向度量值由以点（文档坐标）为单位转换为以屏幕像素（屏幕坐标）为单位。返回转变后的度量值（Long 类型）。
        /// </summary>
        /// <param name="Points">从文档窗口的顶部开始沿其左边缘垂直排列的点数。</param>
        public int PointsToScreenPixelsY(int Points)
        {
            _objaParameters = new object[1] { Points };

            return (int)_objWindow.GetType().InvokeMember("PointsToScreenPixelsY", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        public dynamic PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            return _objWindow.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public dynamic PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] {
                EnableChanges == null ? System.Type.Missing : EnableChanges
            };

            return _objWindow.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>返回位于屏幕上指定坐标位置的 Shape 或 Range 对象。如果指定坐标位置上没有任何形状，则此方法将返回 Nothing。
        /// </summary>
        /// <param name="x">表示从顶部开始到屏幕左边缘的水平距离的值（以像素为单位）。</param>
        /// <param name="y">表示从左侧开始到屏幕顶部的垂直距离的值（以像素为单位）。</param>
        public dynamic RangeFromPoint(int x, int y)
        {
            _objaParameters = new object[2] { x, y };

            return _objWindow.GetType().InvokeMember("RangeFromPoint", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>滚动文档窗口，使指定矩形区域中的内容显示在文档窗口或窗格的左上角或右下角（取决于 Start 参数值）。
        /// </summary>
        /// <param name="Left">矩形距离文档窗口或窗格左边的水平位置（以磅为单位）。</param>
        /// <param name="Top">矩形距离文档窗口或窗格上边的垂直位置（以磅为单位）。</param>
        /// <param name="Width">矩形的宽度（以磅为单位）。</param>
        /// <param name="Height">矩形的高度（以磅为单位）。</param>
        /// <param name="Start">如果为 True，则使矩形的左上角位于文档窗口或窗格的左上角。如果为 False，则使矩形的右下角位于文档窗口或窗格的右下角。默认值是 True。</param>
        public void ScrollIntoView(int Left, int Top, int Width, int Height, bool? Start = null)
        {
            _objaParameters = new object[5] {
                Left,
                Top,
                Width,
                Height,
                Start == null ? System.Type.Missing : Start
            };

            _objWindow.GetType().InvokeMember("ScrollIntoView", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>滚动工作簿窗口下方的工作表标签。本方法不改变该工作簿中的活动工作表。
        /// </summary>
        /// <param name="Sheets">要滚动的工作表的数目。如果为正数则向前滚动，为负数则向后滚动，为 0（零）则不滚动。如果未指定 Position 参数，则必须指定 Sheets。</param>
        /// <param name="Position">使用 xlFirst 可滚动到第一张工作表，使用 xlLast 可滚动到最后一张工作表。如果未指定 Sheets，则必须指定 Position。</param>
        public dynamic ScrollWorkbookTabs(int? Sheets = null, Constants? Position = null)
        {
            _objaParameters = new object[2] {
                Sheets == null ? System.Type.Missing : Sheets,
                Position == null ? System.Type.Missing : Position
            };

            return _objWindow.GetType().InvokeMember("ScrollWorkbookTabs", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }

        /// <summary>按行或按列滚动窗口内容。
        /// </summary>
        /// <param name="Down">将内容向下滚动的行数。</param>
        /// <param name="Up">将内容向上滚动的行数。</param>
        /// <param name="ToRight">将内容向右滚动的列数。</param>
        /// <param name="ToLeft">将内容向左滚动的列数。</param>
        public dynamic SmallScroll(int? Down = null, int? Up = null, int? ToRight = null, int? ToLeft = null)
        {
            _objaParameters = new object[4] {
                Down == null ? System.Type.Missing : Down,
                Up == null ? System.Type.Missing : Up,
                ToRight == null ? System.Type.Missing : ToRight,
                ToLeft == null ? System.Type.Missing : ToLeft
            };

            return _objWindow.GetType().InvokeMember("SmallScroll", BindingFlags.InvokeMethod, null, _objWindow, _objaParameters);
        }
        #endregion 方法
    }

    /// <summary>指定的工作表上的所有 Shape 对象的集合。
    /// 说明：
    /// 每个 Shape 对象都代表绘图层中的一个对象，如自选图形、任意多边形、OLE 对象或图片。
    /// </summary>
    public class Shapes
    {
        public object _objShapes;
        internal object[] _objaParameters;

        public Shapes(object objShapes)
        {
            _objShapes = objShapes;
        }

        /// <summary>从集合中返回一个对象
        /// </summary>
        /// <param name="Index">对象的名称或索引号。</param>
        /// <returns></returns>
        public Shape this[object Index]
        {
            get
            {
                _objaParameters = new object[1] { Index };
                object objShape = _objShapes.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objShapes, _objaParameters);

                if (objShape == null)
                    return null;
                else
                    return new Shape(objShape);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objShapes.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objShapes, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objShapes.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objShapes, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objShapes.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objShapes, null); }
        }

        /// <summary>返回一个 ShapeRange 对象，它代表 Shapes 集合中形状的子集。
        /// </summary>
        private ShapeRange Range
        {
            get { return new ShapeRange(_objShapes.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, _objShapes, null)); }
        }
        #endregion 属性

        #region 函数
        /// <summary>创建一个无边框的线形标注。返回一个代表新标注的 Shape 对象。
        /// </summary>
        /// <param name="Type">标注线的类型。</param>
        /// <param name="Left">标注边框的左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">标注边框的左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Width">标注边框的宽度（以磅为单位）。</param>
        /// <param name="Height">标注边框的高度（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddCallout(MsoCalloutType Type, float Left, float Top, float Width, float Height)
        {
            _objaParameters = new object[5] { Type, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddCallout", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>在活动工作表上的指定位置创建图表。
        /// 说明：
        /// 如果省略图表类型，则使用应用程序的默认图表类型。如果省略位置，则使用应用程序的默认大小。
        /// </summary>
        /// <param name="Type">图表类型。</param>
        /// <param name="Left">从对象左边界至 A 列左边界（在工作表上）或图表区左边界（在图表上）的距离，以磅为单位。 </param>
        /// <param name="Top">从图形区域中最上端的图形的顶端到工作表顶端的距离，以磅为单位。</param>
        /// <param name="Width">对象的宽度，以磅为单位。 </param>
        /// <param name="Height">对象的高度，以磅为单位。 </param>
        /// <returns></returns>
        public Shape AddChart(XlChartType? Type = null, float? Left = null, float? Top = null, float? Width = null, float? Height = null)
        {
            _objaParameters = new object[5] { 
                Type == null ? System.Type.Missing : Type,
                Left == null ? System.Type.Missing : Left,
                Top == null ? System.Type.Missing : Top,
                Width == null ? System.Type.Missing : Width,
                Height == null ? System.Type.Missing : Height
            };

            object objShape = _objShapes.GetType().InvokeMember("AddChart", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建一个连接符。返回一个代表新连接符的 Shape 对象。添加一个连接符时，它没有连接到任何对象。使用 BeginConnect 和 EndConnect 方法可将连接符的头和尾连接到文档中的其他形状上。
        /// </summary>
        /// <param name="Type">要添加的连接符类型。</param>
        /// <param name="BeginX">连接符的起点相对于文档左上角的水平位置（以磅为单位）。</param>
        /// <param name="BeginY">连接符的起点相对于文档左上角的垂直位置（以磅为单位）。</param>
        /// <param name="EndX">连接符的终点相对于文档左上角的水平位置（以磅为单位）。</param>
        /// <param name="EndY">连接符的终点相对于文档左上角的垂直位置（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddConnector(MsoConnectorType Type, float BeginX, float BeginY, float EndX, float EndY)
        {
            _objaParameters = new object[5] { Type, BeginX, BeginY, EndX, EndY };
            object objShape = _objShapes.GetType().InvokeMember("AddConnector", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>返回一个 Shape 对象，该对象表示工作表中的贝赛尔曲线。 
        /// </summary>
        /// <param name="SafeArrayOfPoints">由指定曲线的顶点和控制点的坐标对 （坐标对：一对值，表示两维数组中存储的点的 x 和 y 坐标，该数组中包含许多点的坐标。）组成的数组。首先指定起点，然后指定两个第一段贝塞尔曲线的控制点。该曲线每增加一条线段，就要为其指定一个顶点和两个控制点。最后指定该曲线的终点。请注意，必须指定的点数始终为 3n + 1，其中 n 为曲线的线段个数。</param>
        /// <returns></returns>
        public Shape AddCurve(object SafeArrayOfPoints)
        {
            object objShape = _objShapes.GetType().InvokeMember("AddCurve", BindingFlags.InvokeMethod, null, _objShapes, new object[1] { SafeArrayOfPoints });

            return new Shape(objShape);
        }

        /// <summary>创建一个 Microsoft Excel 控件 （Microsoft Excel 控件：Excel 本身具有的控件，而不是 ActiveX 控件。）。将返回一个 Shape 对象，该对象代表新建的控件。
        /// </summary>
        /// <param name="Type">Microsoft Excel 控件 （Microsoft Excel 控件：Excel 本身具有的控件，而不是 ActiveX 控件。）类型。无法在工作表上创建编辑框。</param>
        /// <param name="Left">新对象相对于工作表 A1 单元格左上角或图表左上角的初始坐标（以磅 （磅：指打印的字符的高度的度量单位。1 磅等于 1/72 英寸，或大约等于 1 厘米的 1/28。）为单位）。</param>
        /// <param name="Top">新对象相对于工作表 A1 单元格左上角或图表左上角的初始坐标（以磅 （磅：指打印的字符的高度的度量单位。1 磅等于 1/72 英寸，或大约等于 1 厘米的 1/28。）为单位）。</param>
        /// <param name="Width">新对象的初始大小（以磅为单位）。</param>
        /// <param name="Height">新对象的初始大小（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddFormControl(XlFormControl Type, int Left, int Top, int Width, int Height)
        {
            _objaParameters = new object[5] { Type, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddFormControl", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建一个连接符。返回一个代表新连接符的 Shape 对象。
        /// </summary>
        /// <param name="Orientation">标签中文本的方向。</param>
        /// <param name="Left">标签左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">标签左上角相对于文档顶部的位置（以磅为单位）。</param>
        /// <param name="Width">标签的宽度（以磅为单位）。</param>
        /// <param name="Height">标签的高度（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddLabel(MsoTextOrientation Orientation, float Left, float Top, float Width, float Height)
        {
            _objaParameters = new object[5] { Orientation, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddLabel", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>当本方法应用于 Shapes 对象时，返回一个 Shape 对象，该对象表示工作表中的新线条。
        /// </summary>
        /// <param name="BeginX">线条的起点相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="BeginY">线条的起点相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="EndX">线条的终点相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="EndY">线条的终点相对于文档左上角的位置（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddLine(float BeginX, float BeginY, float EndX, float EndY)
        {
            _objaParameters = new object[4] { BeginX, BeginY, EndX, EndY };
            object objShape = _objShapes.GetType().InvokeMember("AddLine", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建 OLE 对象。返回一个代表新 OLE 对象的 Shape 对象。
        /// </summary>
        /// <param name="ClassType">（必须指定 ClassType 或 FileName）。该字符串包含要创建的对象的程序标识符。如果指定了 ClassType 参数，则忽略 FileName 和 Link。</param>
        /// <param name="Filename">创建对象所用的文件名称。如果未指定路径，则使用当前的工作文件夹。必须为对象指定 ClassType 或 FileName 参数，但不能同时指定。</param>
        /// <param name="Link">如果为 True，则将 OLE 对象链接到创建该对象所使用的文件；如果为 False，则 OLE 对象成为该文件的独立副本。如果为 ClassType 指定值，则该参数必须为 False。默认值为 False。</param>
        /// <param name="DisplayAsIcon">如果为 True，则将 OLE 对象显示为图标。默认值为 False。</param>
        /// <param name="IconFileName">包含将要显示的图标的文件。</param>
        /// <param name="IconIndex">IconFileName 内的图标索引。指定文件中图标的顺序与图标在“更改图标”对话框中出现的顺序相对应（选中“显示为图标”复选框后，可从“对象”对话框访问该对话框）。文件中的第一个图标的索引号为 0（零）。如果 IconFileName 中不存在给定索引号的图标，则使用索引号为 1 的图标（即文件中的第二个图标）。默认值为 0（零）。</param>
        /// <param name="IconLabel">显示在图标下面的标签（题注）。</param>
        /// <param name="Left">新对象的左上角相对于文档左上角的位置（以磅为单位）。默认值为 0（零）。</param>
        /// <param name="Top">新对象的左上角相对于文档左上角的位置（以磅为单位）。默认值为 0（零）。</param>
        /// <param name="Width">以磅为单位给出 OLE 对象的初始尺寸。</param>
        /// <param name="Height">以磅为单位给出 OLE 对象的初始尺寸。</param>
        /// <returns></returns>
        public Shape AddOLEObject(string ClassType = null, string Filename = null, bool? Link = null, bool? DisplayAsIcon = null, string IconFileName = null, int? IconIndex = null, string IconLabel = null, float? Left = null, float? Top = null, float? Width = null, float? Height = null)
        {
            _objaParameters = new object[11] { 
                ClassType == null ? System.Type.Missing : ClassType,
                Filename == null ? System.Type.Missing : Filename,
                Link == null ? System.Type.Missing : Link,
                DisplayAsIcon == null ? System.Type.Missing : DisplayAsIcon,
                IconFileName == null ? System.Type.Missing : IconFileName,
                IconIndex == null ? System.Type.Missing : IconIndex,
                IconLabel == null ? System.Type.Missing : IconLabel,
                Left == null ? System.Type.Missing : Left,
                Top == null ? System.Type.Missing : Top,
                Width == null ? System.Type.Missing : Width,
                Height == null ? System.Type.Missing : Height
            };
            object objShape = _objShapes.GetType().InvokeMember("AddOLEObject", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>现有文件创建图片。返回一个代表新图片的 Shape 对象。
        /// </summary>
        /// <param name="Filename">要在其中创建 OLE 对象的文件。</param>
        /// <param name="LinkToFile">要链接至的文件。</param>
        /// <param name="SaveWithDocument">将图片与文档一起保存。</param>
        /// <param name="Left">图片左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">图片左上角相对于文档顶部的位置（以磅为单位）。</param>
        /// <param name="Width">图片的宽度（以磅为单位）。</param>
        /// <param name="Height">图片的高度（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddPicture(string Filename, MsoTriState LinkToFile, MsoTriState SaveWithDocument, double Left, double Top, double Width, double Height)
        {
            _objaParameters = new object[7] { Filename, LinkToFile, SaveWithDocument, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddPicture", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建一个不封闭的连续线段或一个封闭的多边形。返回一个代表新的连续线段或多边形的 Shape 对象。
        /// 说明：
        /// 要形成一个闭合的多边形，请为多边形的起点和终点指定相同的坐标。
        /// </summary>
        /// <param name="SafeArrayOfPoints">由指定多边形顶点的坐标对 （坐标对：一对值，表示两维数组中存储的点的 x 和 y 坐标，该数组中包含许多点的坐标。）组成的数组。</param>
        /// <returns></returns>
        public Shape AddPolyline(object[][] SafeArrayOfPoints)
        {
            object objShape = _objShapes.GetType().InvokeMember("AddPolyline", BindingFlags.InvokeMethod, null, _objShapes, new object[1] { SafeArrayOfPoints });

            return new Shape(objShape);
        }

        /// <summary>返回一个 Shape 对象，该对象表示工作表中的新自选形状。
        /// 说明：
        /// 要更改已添加的自选形状的类型，请设置 AutoShapeType 属性。
        /// </summary>
        /// <param name="Type">指定要创建的自选形状的类型。</param>
        /// <param name="Left">自选形状边框的左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">自选形状边框的左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Width">自选形状边框的宽度（以磅为单位）。</param>
        /// <param name="Height">自选形状边框的高度（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddShape(MsoAutoShapeType Type, double Left, double Top, double Width, double Height)
        {
            _objaParameters = new object[5] { Type, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddShape", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建一个文本框。返回一个代表新文本框的 Shape 对象。
        /// </summary>
        /// <param name="Orientation">文本框的方向。</param>
        /// <param name="Left">文本框左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">文本框左上角相对于文档顶部的位置（以磅为单位）。</param>
        /// <param name="Width">文本框的宽度（以磅为单位）。</param>
        /// <param name="Height">文本框的高度（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddTextbox(MsoTextOrientation Orientation, double Left, double Top, double Width, double Height)
        {
            _objaParameters = new object[5] { Orientation, Left, Top, Width, Height };
            object objShape = _objShapes.GetType().InvokeMember("AddTextbox", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>创建艺术字对象。返回一个代表新艺术字对象的 Shape 对象。
        /// 说明：
        /// 向文档添加艺术字对象时，该对象的高度和宽度将自动根据所指定的文字的大小和数量来设置。
        /// </summary>
        /// <param name="PresetTextEffect">预置文字效果。</param>
        /// <param name="Text">艺术字中的文字。</param>
        /// <param name="FontName">艺术字中所用字体的名称。</param>
        /// <param name="FontSize">艺术字中所用字体的大小（以磅为单位）。</param>
        /// <param name="FontBold">在艺术字中要加粗的字体。</param>
        /// <param name="FontItalic">在艺术字中要倾斜的字体。</param>
        /// <param name="Left">艺术字边框左上角相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Top">艺术字边框左上角相对于文档顶部的位置（以磅为单位）。</param>
        /// <returns></returns>
        public Shape AddTextEffect(MsoPresetTextEffect PresetTextEffect, string Text, string FontName, double FontSize, MsoTriState FontBold, MsoTriState FontItalic, double Left, double Top)
        {
            _objaParameters = new object[8] { PresetTextEffect, Text, FontName, FontSize, FontBold, FontItalic, Left, Top };
            object objShape = _objShapes.GetType().InvokeMember("AddTextEffect", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters);

            return new Shape(objShape);
        }

        /// <summary>建立一个任意多边形对象。返回一个 FreeformBuilder 对象，该对象代表正在创建的任意多边形。用 AddNodes 方法向任意多边形添加线段。如果任意多边形中已包含了一个以上的线段，则可用 ConvertToShape 方法将 FreeformBuilder 对象转换为 Shape 对象，该对象将具有在 FreeformBuilder 对象中定义的几何属性。
        /// </summary>
        /// <param name="EditingType">第一个节点的编辑属性。</param>
        /// <param name="X1">任意图形中第一个节点相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Y1">任意图形中第一个节点相对于文档左上角的位置（以磅为单位）。</param>
        /// <returns></returns>
        public FreeformBuilder BuildFreeform(MsoEditingType EditingType, float X1, float Y1)
        {
            _objaParameters = new object[3] { EditingType, X1, Y1 };

            return new FreeformBuilder(_objShapes.GetType().InvokeMember("BuildFreeform", BindingFlags.InvokeMethod, null, _objShapes, _objaParameters));
        }

        /// <summary>选择指定的 Shapes 集合中的所有形状。
        /// </summary>
        public void SelectAll()
        {
            _objShapes.GetType().InvokeMember("SelectAll", BindingFlags.InvokeMethod, null, _objShapes, null);
        }
        #endregion 函数
    }

    /// <summary>代表绘图层中的对象，例如自选图形、任意多边形、OLE 对象或图片。
    /// 说明：
    /// Shape 对象是 Shapes 集合的成员。Shapes 集合包含某个工作簿中的所有形状。 
    /// </summary>
    public class Shape
    {
        public object _objShape;
        internal object[] _objaParameters;

        public Shape(object objShape)
        {
            _objShape = objShape;
        }

        #region 属性
        /// <summary>返回一个 Adjustments 对象，它包括指定形状的所有调整操作的调整值。应用于任何代表自选图形、艺术字或连接符的 Shape 对象。
        /// </summary>
        public Adjustments Adjustments
        {
            get { return new Adjustments(_objShape.GetType().InvokeMember("Adjustments", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置一个当 Shape 对象保存为网页时，该对象的描述性（可选）文本字符串。String 型，可读写。
        /// </summary>
        public string AlternativeText
        {
            get { return _objShape.GetType().InvokeMember("AlternativeText", BindingFlags.GetProperty, null, _objShape, null).ToString(); }
            set { _objShape.GetType().InvokeMember("AlternativeText", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objShape.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置指定的 Shape 或 ShapeRange 对象的形状类型，该对象必须代表自选图形，而不能代表直线、任意多边形图形或连接符。MsoAutoShapeType 类型，可读写。
        /// </summary>
        public MsoAutoShapeType AutoShapeType
        {
            get { return (MsoAutoShapeType)_objShape.GetType().InvokeMember("AutoShapeType", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("AutoShapeType", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回或设置背景样式。可读/写 MsoBackgroundStyleIndex 类型。
        /// </summary>
        public MsoBackgroundStyleIndex BackgroundStyle
        {
            get { return (MsoBackgroundStyleIndex)_objShape.GetType().InvokeMember("BackgroundStyle", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("BackgroundStyle", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回或设置一个值，该值指明以黑白模式查看演示文稿时指定形状出现的方式。MsoBlackWhiteMode，可读写。
        /// </summary>
        public MsoBlackWhiteMode BlackWhiteMode
        {
            get { return (MsoBlackWhiteMode)_objShape.GetType().InvokeMember("BlackWhiteMode", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("BlackWhiteMode", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表位于该对象右下角下方的单元格。只读。
        /// </summary>
        public Range BottomRightCell
        {
            get { return new Range(_objShape.GetType().InvokeMember("BottomRightCell", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 CalloutFormat 对象，它包含指定形状的标注格式属性。应用于代表线形标注的 Shape 对象。只读。
        /// </summary>
        private CalloutFormat Callout
        {
            get { return new CalloutFormat(_objShape.GetType().InvokeMember("Callout", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回 Chart 对象，该对象代表形状中包含的图表。只读。
        /// </summary>
        private Chart Chart
        {
            get { return new Chart(_objShape.GetType().InvokeMember("Chart", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>如果指定的形状是子形状，或者如果形状区域中的所有形状都是同一个父形状的子形状，则返回 msoTrue。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState Child
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("Child", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回指定形状中的连接部位的数量。Long 型，只读。
        /// </summary>
        public int ConnectionSiteCount
        {
            get { return (int)_objShape.GetType().InvokeMember("ConnectionSiteCount", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>如果指定的形状是连接符，则此属性为 True。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState Connector
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("Connector", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回一个包含连接符格式属性的 ConnectorFormat 对象。应用于代表连接符的 Shape 对象。只读。
        /// </summary>
        private ConnectorFormat ConnectorFormat
        {
            get { return new ConnectorFormat(_objShape.GetType().InvokeMember("ConnectorFormat", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 ControlFormat 对象，该对象包含 Microsoft Excel 控件 （Microsoft Excel 控件：Excel 本身具有的控件，而不是 ActiveX 控件。）属性。只读。
        /// </summary>
        private ControlFormat ControlFormat
        {
            get { return new ControlFormat(_objShape.GetType().InvokeMember("ControlFormat", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// 说明
        /// 如果该对象是在 Microsoft Excel 中创建的，则此属性返回字符串 XCEL，它等同于十六进制的数字 5843454C。Creator 属性是为 Macintosh 上的 Microsoft Excel 设计的，在 Macintosh 上，每个应用程序都具有一个四字符的创建者代码。例如，Microsoft Excel 的创建者代码为 XCEL。 
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objShape.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回指定形状的 FillFormat 对象或指定图表的 ChartFillFormat 对象，这些对象包含形状或图表的填充格式属性。只读。
        /// </summary>
        public dynamic Fill
        {
            get { return _objShape.GetType().InvokeMember("Fill", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回 Microsoft Excel 控件 （Microsoft Excel 控件：Excel 本身具有的控件，而不是 ActiveX 控件。）类型。XlFormControl 类型，只读。
        /// </summary>
        public XlFormControl FormControlType
        {
            get { return (XlFormControl)_objShape.GetType().InvokeMember("FormControlType", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回一个包含形状发光格式属性的指定形状的 GlowFormat 对象。只读。
        /// </summary>
        public GlowFormat Glow
        {
            get { return new GlowFormat(_objShape.GetType().InvokeMember("Glow", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 GroupShapes 对象，它代表指定形状组中的单个形状。使用 GroupShapes 对象的 Item 方法可从形状组中返回单个形状。应用于代表成组形状的 Shape 对象。只读。
        /// </summary>
        public GroupShapes GroupItems
        {
            get { return new GroupShapes(_objShape.GetType().InvokeMember("GroupItems", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回形状是否包含图表。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState HasChart
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("HasChart", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的高度（以磅为单位）。
        /// </summary>
        public float Height
        {
            get { return (float)_objShape.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Height", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>如果指定的形状绕水平对称轴翻转，则为 True。MsoTriState，只读。
        /// </summary>
        public MsoTriState HorizontalFlip
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("HorizontalFlip", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回一个 Hyperlink 对象，该对象表示该形状的超链接。
        /// </summary>
        public Hyperlink Hyperlink
        {
            get { return new Hyperlink(_objShape.GetType().InvokeMember("Hyperlink", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 Long 值，它代表指定对象的类型。
        /// </summary>
        public int ID
        {
            get { return (int)_objShape.GetType().InvokeMember("ID", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回或设置 Single 值，它代表从对象左边缘到工作表的 A 列左边缘或到图表上的图表区左边缘的距离（以磅为单位）。
        /// </summary>
        public float Left
        {
            get { return (float)_objShape.GetType().InvokeMember("Left", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Left", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回一个 LineFormat 对象，它包含指定形状的线条格式属性。对于线条，LineFormat 对象代表线条本身；而对于带有边框的形状，LineFormat 对象代表边框。只读。
        /// </summary>
        public LineFormat Line
        {
            get { return new LineFormat(_objShape.GetType().InvokeMember("Line", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 LinkFormat 对象，该对象包含链接的 OLE 对象属性。只读。
        /// </summary>
        public LinkFormat LinkFormat
        {
            get { return new LinkFormat(_objShape.GetType().InvokeMember("LinkFormat", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>如果指定的形状在调整大小时其原始比例保持不变，则此属性为 True。如果调整大小时可以分别更改形状的高度和宽度，则此属性为 False。MsoTriState 类型，可读写。
        /// </summary>
        public MsoTriState LockAspectRatio
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("LockAspectRatio", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("LockAspectRatio", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，它指明对象是否已被锁定。
        /// </summary>
        public bool Locked
        {
            get { return (bool)_objShape.GetType().InvokeMember("Locked", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Locked", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objShape.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objShape, null).ToString(); }
            set { _objShape.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回一个 ShapeNodes 集合，它代表指定形状的几何描述。
        /// </summary>
        public ShapeNodes Nodes
        {
            get { return new ShapeNodes(_objShape.GetType().InvokeMember("Nodes", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 OLEFormat 对象，该对象包含 OLE 对象属性。只读。
        /// </summary>
        public OLEFormat OLEFormat
        {
            get { return new OLEFormat(_objShape.GetType().InvokeMember("OLEFormat", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置单击指定对象时运行的宏的名称。String 类型，可读写。
        /// </summary>
        public string OnAction
        {
            get { return _objShape.GetType().InvokeMember("OnAction", BindingFlags.GetProperty, null, _objShape, null).ToString(); }
            set { _objShape.GetType().InvokeMember("OnAction", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objShape.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回 Shape 对象，它代表子形状或子形状区域的共同父形状。
        /// </summary>
        public Shape ParentGroup
        {
            get { return new Shape(_objShape.GetType().InvokeMember("ParentGroup", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 PictureFormat 对象，它包含指定形状的图片格式属性。应用于代表图片或 OLE 对象的 Shape 对象。只读。
        /// </summary>
        public PictureFormat PictureFormat
        {
            get { return new PictureFormat(_objShape.GetType().InvokeMember("PictureFormat", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置一个 XlPlacement 值，它代表对象附加到对象下面的单元格的方式。
        /// </summary>
        public XlPlacement Placement
        {
            get { return (XlPlacement)_objShape.GetType().InvokeMember("Placement", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Placement", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回指定形状的 ReflectionFormat 对象，该对象包含形状的映像格式属性。只读。
        /// </summary>
        public ReflectionFormat Reflection
        {
            get { return new ReflectionFormat(_objShape.GetType().InvokeMember("Reflection", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设形状的旋转角度（以度为单位）。Single 型，可读写。
        /// </summary>
        public float Rotation
        {
            get { return (float)_objShape.GetType().InvokeMember("Rotation", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Rotation", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回一个只读的 ShadowFormat 对象，它包含指定形状的阴影格式属性。
        /// </summary>
        public ShadowFormat Shadow
        {
            get { return new ShadowFormat(_objShape.GetType().InvokeMember("Shadow", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置 MsoShapeStyleIndex 类型的值，该值代表形状区域的形状样式。可读/写。
        /// </summary>
        public MsoShapeStyleIndex ShapeStyle
        {
            get { return (MsoShapeStyleIndex)_objShape.GetType().InvokeMember("ShapeStyle", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("ShapeStyle", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回指定形状的 SoftEdgeFormat 对象，该对象包含形状的柔化边缘格式属性。只读。
        /// </summary>
        public SoftEdgeFormat SoftEdge
        {
            get { return new SoftEdgeFormat(_objShape.GetType().InvokeMember("SoftEdge", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>该属性返回一个 TextEffectFormat 对象，它包含指定形状的文本效果格式属性。
        /// </summary>
        public TextEffectFormat TextEffect
        {
            get { return new TextEffectFormat(_objShape.GetType().InvokeMember("TextEffect", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 TextFrame 对象，它包含指定形状的对齐方式和定位属性。
        /// </summary>
        public TextFrame TextFrame
        {
            get { return new TextFrame(_objShape.GetType().InvokeMember("TextFrame", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 TextFrame2 对象，该对象包含指定形状的文本格式。只读。
        /// </summary>
        public TextFrame2 TextFrame2
        {
            get { return new TextFrame2(_objShape.GetType().InvokeMember("TextFrame2", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回一个 ThreeDFormat 对象，它包含指定形状的三维效果格式属性。只读。
        /// </summary>
        public ThreeDFormat ThreeD
        {
            get { return new ThreeDFormat(_objShape.GetType().InvokeMember("ThreeD", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置一个 Single 值，它代表形状范围内最上面的形状的上边缘到工作表上边缘的距离（以磅为单位）。
        /// </summary>
        public float Top
        {
            get { return (float)_objShape.GetType().InvokeMember("Top", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Top", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回一个 Range 对象，它代表位于指定对象左上角下方的单元格。只读。
        /// </summary>
        public Range TopLeftCell
        {
            get { return new Range(_objShape.GetType().InvokeMember("TopLeftCell", BindingFlags.GetProperty, null, _objShape, null)); }
        }

        /// <summary>返回或设置一个代表形状类型的 MsoShapeType 值。
        /// </summary>
        public MsoShapeType Type
        {
            get { return (MsoShapeType)_objShape.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Type", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>如果指定的形状绕垂直坐标轴翻转，则此属性为 True。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState VerticalFlip
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("VerticalFlip", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>将指定任意多边形形状的顶点（及贝塞尔曲线的控制点）坐标作为一系列坐标对 （坐标对：一对值，表示两维数组中存储的点的 x 和 y 坐标，该数组中包含许多点的坐标。）返回。可将此属性返回的数组用作 AddCurve 方法或 AddPolyLine 方法的参数。Variant 型，只读。
        /// </summary>
        public object[][] Vertices
        {
            get { return (object[][])_objShape.GetType().InvokeMember("Vertices", BindingFlags.GetProperty, null, _objShape, null); }
        }

        /// <summary>返回或设置一个 MsoTriState 值，它确定对象是否可见。可读写。
        /// </summary>
        public MsoTriState Visible
        {
            get { return (MsoTriState)_objShape.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的宽度（以磅为单位）。
        /// </summary>
        public float Width
        {
            get { return (float)_objShape.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objShape, null); }
            set { _objShape.GetType().InvokeMember("Width", BindingFlags.SetProperty, null, _objShape, new object[1] { value }); }
        }

        /// <summary>返回指定形状在 z-顺序中的位置。Long 型，只读。
        /// </summary>
        public int ZOrderPosition
        {
            get { return (int)_objShape.GetType().InvokeMember("ZOrderPosition", BindingFlags.GetProperty, null, _objShape, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>应用通过 PickUp 方法复制的指定形状格式。
        /// </summary>
        public void Apply()
        {
            _objShape.GetType().InvokeMember("Apply", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>将对象复制到剪贴板。
        /// </summary>
        public void Copy()
        {
            _objShape.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>将所选对象作为图片复制到剪贴板。
        /// </summary>
        /// <param name="Appearance">用于指定图片复制方式的 XlPictureAppearance 常量。默认值为 xlScreen。</param>
        /// <param name="Format">用于指定图片格式的 XlCopyPictureFormat 常量。默认值为 xlPicture。</param>
        public void CopyPicture(XlPictureAppearance? Appearance = null, XlCopyPictureFormat? Format = null)
        {
            _objaParameters = new object[2] { 
                Appearance == null ? System.Type.Missing : Appearance,
                Format == null ? System.Type.Missing : Format
            };
            _objShape.GetType().InvokeMember("CopyPicture", BindingFlags.InvokeMethod, null, _objShape, _objaParameters);
        }

        /// <summary>将对象剪切到剪贴板。
        /// </summary>
        public void Cut()
        {
            _objShape.GetType().InvokeMember("Cut", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objShape.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>复制对象，并返回对新复制对象的引用。
        /// </summary>
        /// <returns></returns>
        public Shape Duplicate()
        {
            return new Shape(_objShape.GetType().InvokeMember("Duplicate", BindingFlags.InvokeMethod, null, _objShape, null));
        }

        /// <summary>绕指定形状的水平或垂直对称轴翻转该形状。
        /// </summary>
        /// <param name="FlipCmd">指定形状是水平翻转还是垂直翻转。</param>
        public void Flip(MsoFlipCmd FlipCmd)
        {
            _objShape.GetType().InvokeMember("Flip", BindingFlags.InvokeMethod, null, _objShape, new object[1] { FlipCmd });
        }

        /// <summary>以指定磅数水平移动指定形状。
        /// </summary>
        /// <param name="Increment">以磅为单位指定形状水平移动的距离。正值使形状向右移动，负值使形状向左移动。</param>
        public void IncrementLeft(double Increment)
        {
            _objShape.GetType().InvokeMember("IncrementLeft", BindingFlags.InvokeMethod, null, _objShape, new object[1] { Increment });
        }

        /// <summary>使指定的形状按指定度数值绕 Z 轴旋转。使用 Rotation 属性可设置形状的绝对转角。
        /// </summary>
        /// <param name="Increment">指定形状的水平旋转量，以度为单位。正值为顺时针旋转形状，负值逆时针旋转形状。</param>
        public void IncrementRotation(double Increment)
        {
            _objShape.GetType().InvokeMember("IncrementRotation", BindingFlags.InvokeMethod, null, _objShape, new object[1] { Increment });
        }

        /// <summary>以指定磅数垂直移动指定形状。
        /// </summary>
        /// <param name="Increment">指定形状对象垂直移动的距离，以磅为单位。正值将形状下移，负值将形状上移。</param>
        public void IncrementTop(double Increment)
        {
            _objShape.GetType().InvokeMember("IncrementTop", BindingFlags.InvokeMethod, null, _objShape, new object[1] { Increment });
        }

        /// <summary>复制指定形状的格式。使用 Apply 方法可将复制的格式应用到其他形状。
        /// </summary>
        public void PickUp()
        {
            _objShape.GetType().InvokeMember("PickUp", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>此方法将重排连接在指定形状上的所有连接符；如果指定的形状是连接符，就重排该连接符。
        /// 说明：
        /// 重排连接符使其以最短的路径连接形状。重排时，RerouteConnections 方法可能会断开连接符的两端并将其重新连接到形状的其他位置。
        /// 如果该方法应用于一个连接符，则只重排该连接符；如果该方法应用于一个已连接的形状，则重排该形状上所有的连接符。
        /// </summary>
        public void RerouteConnections()
        {
            _objShape.GetType().InvokeMember("RerouteConnections", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>按指定的比例调整形状的高度。对于图片和 OLE 对象，可以指定是相对于原有尺寸还是相对于当前尺寸来调整该形状。对于不是图片和 OLE 对象的形状，总是相对于其当前大小来调整高度。
        /// </summary>
        /// <param name="Factor">指定形状调整后的高度与当前或原始高度的比例。例如，若要将一个矩形放大百分之五十，请将此参数设为 1.5。</param>
        /// <param name="RelativeToOriginalSize">如果为 msoTrue，则相对于形状的原有尺寸来调整高度。如果该值为 msoFalse，则相对于形状的当前尺寸来调整高度。仅当指定的形状是图片或 OLE 对象时，才能将此参数指定为 msoTrue。</param>
        /// <param name="Scale">MsoScaleFrom 的常量之一，它指定调整形状大小时，该形状哪一部分的位置将保持不变。</param>
        public void ScaleHeight(double Factor, MsoTriState RelativeToOriginalSize, MsoScaleFrom? Scale = null)
        {
            _objaParameters = new object[3] { 
                Factor,
                RelativeToOriginalSize ,
                Scale == null ? System.Type.Missing : Scale
            };
            _objShape.GetType().InvokeMember("ScaleHeight", BindingFlags.InvokeMethod, null, _objShape, _objaParameters);
        }

        /// <summary>按指定的比例调整形状的宽度。对于图片和 OLE 对象，可以指定是相对于原有尺寸还是相对于当前尺寸来调整该形状。对于不是图片和 OLE 对象的形状，总是相对于其当前大小来调整宽度。
        /// </summary>
        /// <param name="Factor">指定形状调整后的宽度与当前或原始宽度的比例。例如，若要将一个矩形放大百分之五十，请将此参数设为 1.5。</param>
        /// <param name="RelativeToOriginalSize">如果为 False，则相对于形状的原有尺寸来调整宽度。仅当指定的形状是图片或 OLE 对象时，才能将此参数指定为 True。</param>
        /// <param name="Scale">MsoScaleFrom 的常量之一，它指定调整形状大小时，该形状哪一部分的位置将保持不变。</param>
        public void ScaleWidth(double Factor, MsoTriState RelativeToOriginalSize, MsoScaleFrom? Scale = null)
        {
            _objaParameters = new object[3] { 
                Factor,
                RelativeToOriginalSize ,
                Scale == null ? System.Type.Missing : Scale
            };
            _objShape.GetType().InvokeMember("ScaleWidth", BindingFlags.InvokeMethod, null, _objShape, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace)
        {
            _objShape.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objShape, new object[1] { Replace });
        }

        /// <summary>将指定形状的格式设置为形状的默认格式。
        /// </summary>
        public void SetShapesDefaultProperties()
        {
            _objShape.GetType().InvokeMember("SetShapesDefaultProperties", BindingFlags.InvokeMethod, null, _objShape, null);
        }

        /// <summary>取消指定形状或者形状区域中组合形状的组合。取消指定形状或形状区域中图片和 OLE 对象的组合。
        /// </summary>
        /// <returns></returns>
        private ShapeRange Ungroup()
        {
            return new ShapeRange(_objShape.GetType().InvokeMember("Ungroup", BindingFlags.InvokeMethod, null, _objShape, null));
        }

        /// <summary>将指定的形状移到集合中其他形状的前面或后面（即更改该形状在 z-次序中的位置）。
        /// </summary>
        /// <param name="ZOrderCmd">指定根据其他形状将指定的形状移到什么位置。</param>
        public void ZOrder(MsoZOrderCmd ZOrderCmd)
        {
            _objShape.GetType().InvokeMember("ZOrder", BindingFlags.InvokeMethod, null, _objShape, new object[1] { ZOrderCmd });
        }
        #endregion 函数
    }

    /// <summary>代表一组形状中的单个形状。
    /// 说明：
    /// 每个形状都由一个 Shape 对象代表。将 Item 方法与此对象一起使用，您可以在不取消分组的情况下处理组合的各个形状。
    /// </summary>
    public class GroupShapes
    {
        public object _objGroupShapes;

        public GroupShapes(object objGroupShapes)
        { _objGroupShapes = objGroupShapes; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objGroupShapes.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objGroupShapes, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objGroupShapes.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objGroupShapes, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objGroupShapes.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objGroupShapes, null); }
        }

        #endregion 属性

        #region 方法
        /// <summary>从集合中返回一个对象。
        /// </summary>
        /// <param name="Index">对象的名称或索引号。</param>
        /// <returns></returns>
        public Shape Item(object Index)
        {
            return new Shape(_objGroupShapes.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, _objGroupShapes, new object[1] { Index }));
        }

        /// <summary>返回一个 ShapeRange 对象，它代表 Shapes 集合中形状的子集。
        /// </summary>
        /// <param name="Index">包含在该区域中的各单个形状。可以是指定形状索引号的整数、指定形状名称的字符串，也可以是包含整数或字符串的数组。</param>
        /// <returns></returns>
        private ShapeRange Range(object Index)
        {
            return new ShapeRange(_objGroupShapes.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, _objGroupShapes, new object[1] { Index }));
        }
        #endregion 方法
    }

    /// <summary>它包含指定的自选图形、艺术字对象或连接符的调整值的集合。
    /// 说明：
    /// 每个调整值代表一种调整控点的调整方法。由于某些调整控点可以按两种方法调整（例如，某些控点既可以水平调整也可以垂直调整），所以形状的调整值数量可以大于调整控点数量。一个形状最多可以有八个调整值。
    /// 使用 Adjustments 属性可返回 Adjustments 对象。使用 Adjustments(index)（其中 index 是调整值的索引号）可返回单个调整值。
    /// 不同的形状具有不同数目的调整值，不同类型的调整值在不同的方向上调整形状的几何性质，不同类型的调整值有不同的取值范围。例如，下面的图示显示了右箭头标注的四个调整值各对该标注的几何形状起什么作用。 
    /// </summary>
    public class Adjustments
    {
        public object _objAdjustments;

        public Adjustments(object objAdjustments)
        { _objAdjustments = objAdjustments; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objAdjustments.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objAdjustments, null)); }
        }

        /// <summary>返回一个 Integer 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objAdjustments.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objAdjustments, null); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// 说明
        /// 如果该对象是在 Microsoft Excel 中创建的，则此属性返回字符串 XCEL，它等同于十六进制的数字 5843454C。Creator 属性是为 Macintosh 上的 Microsoft Excel 设计的，在 Macintosh 上，每个应用程序都具有一个四字符的创建者代码。例如，Microsoft Excel 的创建者代码为 XCEL。 
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objAdjustments.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objAdjustments, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objAdjustments.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objAdjustments, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>返回或设置由 Index 参数指定的调整值。Single 型，可读写。
        /// 说明：
        /// 自选图形、连接符和艺术字对象最多可有八个调整。
        /// 对于线性调整，调整值 0.0 通常对应于形状的左边缘或上边缘，值 1.0 通常对应于形状的右边缘或下边缘。不过，对于某些形状，调整可以超越边界。对于放射状调整，调整值 1.0 对应于形状的宽度。对于角度的调整，调整值为指定的角度。Item 属性只应用于 具有调整的形状。
        /// </summary>
        /// <param name="Index">Long 型。调整的索引号。</param>
        /// <returns></returns>
        public double Item(int Index)
        {
            return (double)_objAdjustments.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objAdjustments, new object[1] { Index });
        }
        #endregion 函数
    }

    /// <summary>代表任意多边形创建时的几何属性。
    /// 说明：
    /// 使用 BuildFreeform 方法可返回 FreeformBuilder 对象。使用 AddNodes 方法可在任意多边形中添加节点。使用 ConvertToShape 方法可创建 FreeformBuilder 对象中定义的形状，并将它添加到 Shapes 集合中。
    /// </summary>
    public class FreeformBuilder
    {
        public object _objFreeformBuilder;
        internal object[] _objaParameters;

        public FreeformBuilder(object objFreeformBuilder)
        { _objFreeformBuilder = objFreeformBuilder; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objFreeformBuilder.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objFreeformBuilder, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objFreeformBuilder.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objFreeformBuilder, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>在当前形状中添加一点，然后绘制一个从当前节点到添加的最后一个节点的线条。
        /// </summary>
        /// <param name="SegmentType">要添加的线段的类型。</param>
        /// <param name="EditingType">顶点的编辑属性。</param>
        /// <param name="X1">如果新线段的 EditingType 为 msoEditingAuto，则此参数指定从文档左上角到新线段终点的水平距离（以磅为单位）。如果新节点的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第一个控制点的水平距离（以磅为单位）。</param>
        /// <param name="Y1">如果新线段的 EditingType 为 msoEditingAuto，则此参数指定从文档左上角到新线段终点的水平距离（以磅为单位）。如果新节点的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第一个控制点的水平距离（以磅为单位）。</param>
        /// <param name="X2">如果新线段的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第二个控制点的水平距离（以磅为单位）。如果新线段的 EditingType 为 msoEditingAuto，则不为该参数指定值。</param>
        /// <param name="Y2">如果新线段的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第二个控制点的水平距离（以磅为单位）。如果新线段的 EditingType 为 msoEditingAuto，则不为该参数指定值。</param>
        /// <param name="X3">如果新线段的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第二个控制点的水平距离（以磅为单位）。如果新线段的 EditingType 为 msoEditingAuto，则不为该参数指定值。</param>
        /// <param name="Y3">如果新线段的 EditingType 为 msoEditingCorner，则此参数指定从文档左上角到新线段的第二个控制点的水平距离（以磅为单位）。如果新线段的 EditingType 为 msoEditingAuto，则不为该参数指定值。</param>
        public void AddNodes(MsoSegmentType SegmentType, MsoEditingType EditingType, float X1, float Y1, float? X2 = null, float? Y2 = null, float? X3 = null, float? Y3 = null)
        {
            _objaParameters = new object[8] { 
                SegmentType,
                EditingType,
                X1,
                Y1,
                X2 == null ? System.Type.Missing : X2,
                Y2 == null ? System.Type.Missing : Y2,
                X3 == null ? System.Type.Missing : X3,
                Y3 == null ? System.Type.Missing : Y3
            };

            _objFreeformBuilder.GetType().InvokeMember("AddNodes", BindingFlags.InvokeMethod, null, _objFreeformBuilder, _objaParameters);
        }

        /// <summary>创建一个具有指定 FreeformBuilder 对象的几何特性的形状。返回一个代表新形状的 Shape 对象。
        /// </summary>
        /// <returns></returns>
        public Shape ConvertToShape()
        {
            return new Shape(_objFreeformBuilder.GetType().InvokeMember("ConvertToShape", BindingFlags.InvokeMethod, null, _objFreeformBuilder, null));
        }
        #endregion 函数
    }

    /// <summary>代表形状区域，它是文档中的一组形状。
    /// 说明：
    /// 形状区域可以只包含文档中的一个形状，或者也可包含所有形状。您可以在形状区域中包含所需的任意形状（在文档中的所有形状中选取，或从选定内容中的所有形状中选取）。例如，您可以构造一个 ShapeRange 集合，它包含文档中前三个形状、文档中所有选定的形状，或文档中所有的任意多边形的。
    /// </summary>
    public class ShapeRange
    {
        public object _objShapeRange;
        internal object[] _objaParameters;

        public ShapeRange(object objShapeRange)
        { _objShapeRange = objShapeRange; }

        #region 属性
        /// <summary>返回一个 Adjustments 对象，它包括指定形状的所有调整操作的调整值。应用于任何代表自选图形、艺术字或连接符的 ShapeRange 对象。
        /// </summary>
        public Adjustments Adjustments
        {
            get { return new Adjustments(_objShapeRange.GetType().InvokeMember("Adjustments", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回或设置一个当 ShapeRange 对象保存为网页时，该对象的描述性（可选）文本字符串。String 型，可读写。
        /// </summary>
        public string AlternativeText
        {
            get { return _objShapeRange.GetType().InvokeMember("AlternativeText", BindingFlags.GetProperty, null, _objShapeRange, null).ToString(); }
            set { _objShapeRange.GetType().InvokeMember("AlternativeText", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objShapeRange.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回或设置指定的 Shape 或 ShapeRange 对象的形状类型，该对象必须代表自选图形，而不能代表直线、任意多边形图形或连接符。MsoAutoShapeType 类型，可读写。
        /// </summary>
        public MsoAutoShapeType AutoShapeType
        {
            get { return (MsoAutoShapeType)_objShapeRange.GetType().InvokeMember("AutoShapeType", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("AutoShapeType", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回或设置背景样式。可读/写 MsoBackgroundStyleIndex 类型。
        /// </summary>
        public MsoBackgroundStyleIndex BackgroundStyle
        {
            get { return (MsoBackgroundStyleIndex)_objShapeRange.GetType().InvokeMember("BackgroundStyle", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("BackgroundStyle", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个值，该值指明以黑白模式查看演示文稿时指定形状出现的方式。MsoBlackWhiteMode，可读写。
        /// </summary>
        public MsoBlackWhiteMode BlackWhiteMode
        {
            get { return (MsoBlackWhiteMode)_objShapeRange.GetType().InvokeMember("BlackWhiteMode", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("BlackWhiteMode", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回一个 CalloutFormat 对象，它包含指定形状的标注格式属性。应用于代表线形标注的 ShapeRange 对象。只读。
        /// </summary>
        public CalloutFormat Callout
        {
            get { return new CalloutFormat(_objShapeRange.GetType().InvokeMember("Callout", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回 Chart 对象，该对象代表形状区域中包含的图表。只读。
        /// </summary>
        public Chart Chart
        {
            get { return new Chart(_objShapeRange.GetType().InvokeMember("Chart", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>如果指定的形状是子形状，或者如果形状区域中的所有形状都是同一个父形状的子形状，则返回 msoTrue。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState Child
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("Child", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回指定形状中的连接部位的数量。Long 型，只读。
        /// </summary>
        public int ConnectionSiteCount
        {
            get { return (int)_objShapeRange.GetType().InvokeMember("ConnectionSiteCount", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>如果指定的形状是连接符，则此属性为 True。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState Connector
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("Connector", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回一个包含连接符格式属性的 ConnectorFormat 对象。应用于代表连接符的 ShapeRange 对象。只读。
        /// </summary>
        public ConnectorFormat ConnectorFormat
        {
            get { return new ConnectorFormat(_objShapeRange.GetType().InvokeMember("ConnectorFormat", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objShapeRange.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objShapeRange.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回指定形状的 FillFormat 对象或指定图表的 ChartFillFormat 对象，这些对象包含形状或图表的填充格式属性。只读。
        /// </summary>
        public FillFormat Fill
        {
            get { return new FillFormat(_objShapeRange.GetType().InvokeMember("Fill", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个包含形状区域发光格式属性的指定形状区域的 GlowFormat 对象。只读。
        /// </summary>
        public GlowFormat Glow
        {
            get { return new GlowFormat(_objShapeRange.GetType().InvokeMember("Glow", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 GroupShapes 对象，它代表指定形状组中的单个形状。使用 GroupShapes 对象的 Item 方法可从形状组中返回单个形状。应用于代表成组形状的 ShapeRange 对象。只读。
        /// </summary>
        public GroupShapes GroupItems
        {
            get { return new GroupShapes(_objShapeRange.GetType().InvokeMember("GroupItems", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回形状区域是否包含图表。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState HasChart
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("HasChart", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>
        /// </summary>
        public MsoTriState HasDiagram
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("HasDiagram", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>
        /// </summary>
        public MsoTriState HasDiagramNode
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("HasDiagramNode", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的高度（以磅为单位）。
        /// </summary>
        public float Height
        {
            get { return (float)_objShapeRange.GetType().InvokeMember("Height", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Height", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>如果指定的形状绕水平对称轴翻转，则为 True。MsoTriState，只读。
        /// </summary>
        public MsoTriState HorizontalFlip
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("HorizontalFlip", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回一个 Long 值，它代表指定对象的类型。
        /// </summary>
        public int ID
        {
            get { return (int)_objShapeRange.GetType().InvokeMember("ID", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回或设置 Single 值，它代表从对象左边缘到工作表的 A 列左边缘或到图表上的图表区左边缘的距离（以磅为单位）。
        /// </summary>
        public float Left
        {
            get { return (float)_objShapeRange.GetType().InvokeMember("Left", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Left", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回一个 LineFormat 对象，它包含指定形状的线条格式属性。对于线条，LineFormat 对象代表线条本身；而对于带有边框的形状，LineFormat 对象代表边框。只读。
        /// </summary>
        public LineFormat Line
        {
            get { return new LineFormat(_objShapeRange.GetType().InvokeMember("Line", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>如果指定的形状在调整大小时其原始比例保持不变，则此属性为 True。如果调整大小时可以分别更改形状的高度和宽度，则此属性为 False。MsoTriState 类型，可读写。
        /// </summary>
        public MsoTriState LockAspectRatio
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("LockAspectRatio", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("LockAspectRatio", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objShapeRange.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objShapeRange, null).ToString(); }
            set { _objShapeRange.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回一个 ShapeNodes 集合，它代表指定形状的几何描述。
        /// </summary>
        public ShapeNodes Nodes
        {
            get { return new ShapeNodes(_objShapeRange.GetType().InvokeMember("Nodes", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objShapeRange.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回 Shape 对象，它代表子形状或子形状区域的共同父形状。
        /// </summary>
        public Shape ParentGroup
        {
            get { return new Shape(_objShapeRange.GetType().InvokeMember("ParentGroup", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 PictureFormat 对象，它包含指定形状的图片格式属性。应用于代表图片或 OLE 对象的 ShapeRange 对象。只读。
        /// </summary>
        public PictureFormat PictureFormat
        {
            get { return new PictureFormat(_objShapeRange.GetType().InvokeMember("PictureFormat", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回指定形状区域的 ReflectionFormat 对象，该对象包含形状区域的映像格式属性。只读。
        /// </summary>
        public ReflectionFormat Reflection
        {
            get { return new ReflectionFormat(_objShapeRange.GetType().InvokeMember("Reflection", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回或设形状的旋转角度（以度为单位）。Single 型，可读写。
        /// </summary>
        public float Rotation
        {
            get { return (float)_objShapeRange.GetType().InvokeMember("Rotation", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Rotation", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回一个只读的 ShadowFormat 对象，它包含指定形状的阴影格式属性。
        /// </summary>
        public ShadowFormat Shadow
        {
            get { return new ShadowFormat(_objShapeRange.GetType().InvokeMember("Shadow", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回或设置 MsoShapeStyleIndex 类型的值，该值代表形状区域的形状样式。可读/写。
        /// </summary>
        public MsoShapeStyleIndex ShapeStyle
        {
            get { return (MsoShapeStyleIndex)_objShapeRange.GetType().InvokeMember("ShapeStyle", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("ShapeStyle", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回指定形状区域的 SoftEdgeFormat 对象，该对象包含形状区域的柔化边缘格式属性。只读。
        /// </summary>
        public SoftEdgeFormat SoftEdge
        {
            get { return new SoftEdgeFormat(_objShapeRange.GetType().InvokeMember("SoftEdge", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>该属性返回一个 TextEffectFormat 对象，它包含指定形状的文本效果格式属性。
        /// </summary>
        public TextEffectFormat TextEffect
        {
            get { return new TextEffectFormat(_objShapeRange.GetType().InvokeMember("TextEffect", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 TextFrame 对象，它包含指定形状的对齐方式和定位属性。
        /// </summary>
        public TextFrame TextFrame
        {
            get { return new TextFrame(_objShapeRange.GetType().InvokeMember("TextFrame", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 TextFrame2 对象，该对象包含指定形状区域的文本格式。只读。
        /// </summary>
        public TextFrame2 TextFrame2
        {
            get { return new TextFrame2(_objShapeRange.GetType().InvokeMember("TextFrame2", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回一个 ThreeDFormat 对象，它包含指定形状的三维效果格式属性。只读。
        /// </summary>
        public ThreeDFormat ThreeD
        {
            get { return new ThreeDFormat(_objShapeRange.GetType().InvokeMember("ThreeD", BindingFlags.GetProperty, null, _objShapeRange, null)); }
        }

        /// <summary>返回或设置一个 Single 值，它代表形状范围内最上面的形状的上边缘到工作表上边缘的距离（以磅为单位）。
        /// </summary>
        public float Top
        {
            get { return (float)_objShapeRange.GetType().InvokeMember("Top", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Top", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回一个代表形状类型的 MsoShapeType 值。
        /// </summary>
        public MsoShapeType Type
        {
            get { return (MsoShapeType)_objShapeRange.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>如果指定的形状绕垂直坐标轴翻转，则此属性为 True。MsoTriState 类型，只读。
        /// </summary>
        public MsoTriState VerticalFlip
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("VerticalFlip", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>将指定任意多边形形状的顶点（及贝塞尔曲线的控制点）坐标作为一系列坐标对返回。可将此属性返回的数组用作 AddCurve 方法或 AddPolyLine 方法的参数。Variant 型，只读。
        /// </summary>
        public dynamic Vertices
        {
            get { return _objShapeRange.GetType().InvokeMember("Vertices", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }

        /// <summary>返回或设置一个 MsoTriState 值，它确定对象是否可见。可读写。
        /// </summary>
        public MsoTriState Visible
        {
            get { return (MsoTriState)_objShapeRange.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single 值，它代表对象的宽度（以磅为单位）。
        /// </summary>
        public float Width
        {
            get { return (float)_objShapeRange.GetType().InvokeMember("Width", BindingFlags.GetProperty, null, _objShapeRange, null); }
            set { _objShapeRange.GetType().InvokeMember("Width", BindingFlags.SetProperty, null, _objShapeRange, new object[1] { value }); }
        }

        /// <summary>返回指定形状在 z-顺序中的位置。Long 型，只读。
        /// </summary>
        public int ZOrderPosition
        {
            get { return (int)_objShapeRange.GetType().InvokeMember("ZOrderPosition", BindingFlags.GetProperty, null, _objShapeRange, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>对齐指定形状区域中的形状。
        /// </summary>
        /// <param name="AlignCmd">指定某个指定形状范围中形状的对齐方式。</param>
        /// <param name="RelativeTo">不在 Microsoft Excel 中使用。必须为 False。</param>
        public void Align(MsoAlignCmd AlignCmd, MsoTriState RelativeTo)
        {
            _objaParameters = new object[2] { AlignCmd, RelativeTo };
            _objShapeRange.GetType().InvokeMember("Align", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>应用通过 PickUp 方法复制的指定形状格式。
        /// </summary>
        public void Apply()
        {
            _objShapeRange.GetType().InvokeMember("Apply", BindingFlags.InvokeMethod, null, _objShapeRange, null);
        }

        /// <summary>
        /// </summary>
        public void CanvasCropBottom(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("CanvasCropBottom", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void CanvasCropLeft(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("CanvasCropLeft", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void CanvasCropRight(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("CanvasCropRight", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void CanvasCropTop(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("CanvasCropTop", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objShapeRange.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objShapeRange, null);
        }

        /// <summary>水平或垂直地分布指定的形状区域中的各形状。
        /// </summary>
        /// <param name="DistributeCmd">指定该范围内的形状是水平分布还是垂直分布。</param>
        /// <param name="RelativeTo">不在 Microsoft Excel 中使用。必须为 False。</param>
        public void Distribute(MsoDistributeCmd DistributeCmd, MsoTriState RelativeTo)
        {
            _objaParameters = new object[2] { DistributeCmd, RelativeTo };
            _objShapeRange.GetType().InvokeMember("Distribute", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>复制对象，并返回对新复制对象的引用。
        /// </summary>
        public ShapeRange Duplicate()
        {
            return new ShapeRange(_objShapeRange.GetType().InvokeMember("Duplicate", BindingFlags.InvokeMethod, null, _objShapeRange, null));
        }

        /// <summary>绕指定形状的水平或垂直对称轴翻转该形状。
        /// </summary>
        /// <param name="FlipCmd">指定形状是水平翻转还是垂直翻转。</param>
        public void Flip(MsoFlipCmd FlipCmd)
        {
            _objaParameters = new object[1] { FlipCmd };
            _objShapeRange.GetType().InvokeMember("Flip", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>将指定区域中的形状形成一组。
        /// </summary>
        public Shape Group()
        {
            return new Shape(_objShapeRange.GetType().InvokeMember("Group", BindingFlags.InvokeMethod, null, _objShapeRange, null));
        }

        /// <summary>以指定磅数水平移动指定形状。
        /// </summary>
        /// <param name="Increment">以磅为单位指定形状水平移动的距离。正值使形状向右移动，负值使形状向左移动。</param>
        public void IncrementLeft(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("IncrementLeft", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>使指定的形状按指定度数值绕 Z 轴旋转。使用 Rotation 属性可设置形状的绝对转角。
        /// </summary>
        /// <param name="Increment">指定形状的水平旋转量，以度为单位。正值为顺时针旋转形状，负值逆时针旋转形状。</param>
        public void IncrementRotation(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("IncrementRotation", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>以指定磅数垂直移动指定形状。
        /// </summary>
        /// <param name="Increment">指定形状对象垂直移动的距离，以磅为单位。正值将形状下移，负值将形状上移。</param>
        public void IncrementTop(float Increment)
        {
            _objaParameters = new object[1] { Increment };
            _objShapeRange.GetType().InvokeMember("IncrementTop", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>从集合中返回一个对象。
        /// </summary>
        /// <param name="Index">对象的名称或索引号。</param>
        public Shape Item(object Index)
        {
            _objaParameters = new object[1] { Index };
            return new Shape(_objShapeRange.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters));
        }

        /// <summary>复制指定形状的格式。使用 Apply 方法可将复制的格式应用到其他形状。
        /// </summary>
        public void PickUp()
        {
            _objShapeRange.GetType().InvokeMember("PickUp", BindingFlags.InvokeMethod, null, _objShapeRange, null);
        }

        /// <summary>将指定形状原先所属的形状区域重新组合。以单一的 Shape 对象返回重新组合的形状。
        /// </summary>
        public Shape Regroup()
        {
            return new Shape(_objShapeRange.GetType().InvokeMember("Regroup", BindingFlags.InvokeMethod, null, _objShapeRange, null));
        }

        /// <summary>此方法将重排连接在指定形状上的所有连接符；如果指定的形状是连接符，就重排该连接符。
        /// </summary>
        public void RerouteConnections()
        {
            _objShapeRange.GetType().InvokeMember("RerouteConnections", BindingFlags.InvokeMethod, null, _objShapeRange, null);
        }

        /// <summary>按指定的比例调整形状的高度。对于图片和 OLE 对象，可以指定是相对于原有尺寸还是相对于当前尺寸来调整该形状。对于不是图片和 OLE 对象的形状，总是相对于其当前大小来调整高度。
        /// </summary>
        /// <param name="Factor">指定形状调整后的高度与当前或原始高度的比例。例如，若要将一个矩形放大百分之五十，请将此参数设为 1.5。</param>
        /// <param name="RelativeToOriginalSize">如果为 msoTrue，则相对于形状的原有尺寸来调整高度。如果该值为 msoFalse，则相对于形状的当前尺寸来调整高度。仅当指定的形状是图片或 OLE 对象时，才能将此参数指定为 msoTrue。</param>
        /// <param name="Scale">MsoScaleFrom 的常量之一，它指定调整形状大小时，该形状哪一部分的位置将保持不变。</param>
        public void ScaleHeight(float Factor, MsoTriState RelativeToOriginalSize, MsoScaleFrom? Scale = null)
        {
            _objaParameters = new object[3] {
                Factor,
                RelativeToOriginalSize,
                Scale == null ? System.Type.Missing : Scale
            };

            _objShapeRange.GetType().InvokeMember("ScaleHeight", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>按指定的比例调整形状的宽度。对于图片和 OLE 对象，可以指定是相对于原有尺寸还是相对于当前尺寸来调整该形状。对于不是图片和 OLE 对象的形状，总是相对于其当前大小来调整宽度。
        /// </summary>
        /// <param name="Factor">指定形状调整后的宽度与当前或原始宽度的比例。例如，若要将一个矩形放大百分之五十，请将此参数设为 1.5。</param>
        /// <param name="RelativeToOriginalSize">如果为 False，则相对于形状的原有尺寸来调整宽度。仅当指定的形状是图片或 OLE 对象时，才能将此参数指定为 True。</param>
        /// <param name="Scale">MsoScaleFrom 的常量之一，它指定调整形状大小时，该形状哪一部分的位置将保持不变。</param>
        public void ScaleWidth(float Factor, MsoTriState RelativeToOriginalSize, MsoScaleFrom? Scale = null)
        {
            _objaParameters = new object[3] {
                Factor,
                RelativeToOriginalSize,
                Scale == null ? System.Type.Missing : Scale
            };

            _objShapeRange.GetType().InvokeMember("ScaleWidth", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] { Replace == null ? System.Type.Missing : Replace };
            _objShapeRange.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }

        /// <summary>将指定形状的格式设置为形状的默认格式。
        /// </summary>
        public void SetShapesDefaultProperties()
        {
            _objShapeRange.GetType().InvokeMember("SetShapesDefaultProperties", BindingFlags.InvokeMethod, null, _objShapeRange, null);
        }

        /// <summary>取消指定形状或者形状区域中组合形状的组合。取消指定形状或形状区域中图片和 OLE 对象的组合。
        /// </summary>
        public ShapeRange Ungroup()
        {
            return new ShapeRange(_objShapeRange.GetType().InvokeMember("Ungroup", BindingFlags.InvokeMethod, null, _objShapeRange, null));
        }

        /// <summary>将指定的形状移到集合中其他形状的前面或后面（即更改该形状在 z-次序中的位置）。
        /// </summary>
        /// <param name="ZOrderCmd">指定根据其他形状将指定的形状移到什么位置。</param>
        public void ZOrder(MsoZOrderCmd ZOrderCmd)
        {
            _objaParameters = new object[1] { ZOrderCmd };
            _objShapeRange.GetType().InvokeMember("ZOrder", BindingFlags.InvokeMethod, null, _objShapeRange, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>指定的或活动工作簿中所有图表工作表的集合。
    /// 说明：
    /// 每个图表工作表都由一个 Chart 对象来表示。这不包括嵌入在工作表或对话框编辑表上的图表。有关嵌入图表的信息，请参阅 Chart 或 ChartObject 主题。
    /// </summary>
    public class Charts
    {
        public object _objCharts;
        internal object[] _objaParameters;

        internal Charts(object objCharts)
        { _objCharts = objCharts; }

        public Chart this[object Index]
        {
            get
            {
                object objChart = _objCharts.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objCharts, new object[1] { Index });

                if (objChart == null)
                    return null;
                else
                    return new Chart(objChart);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objCharts.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objCharts, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objCharts.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objCharts, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objCharts.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objCharts, null); }
        }

        /// <summary>返回一个 HPageBreaks 集合，它代表图表上的水平分页符。只读。
        /// </summary>
        public HPageBreaks HPageBreaks
        {
            get { return new HPageBreaks(_objCharts.GetType().InvokeMember("HPageBreaks", BindingFlags.GetProperty, null, _objCharts, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objCharts.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objCharts, null); }
        }

        /// <summary>返回或设置一个 Variant 值，它确定对象是否可见。
        /// </summary>
        public bool Visible
        {
            get { return (bool)_objCharts.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objCharts, null); }
            set { _objCharts.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objCharts, new object[1] { value }); }
        }

        /// <summary>返回一个 VPageBreaks 集合，它代表工作表上的垂直分页符。只读。
        /// </summary>
        public VPageBreaks VPageBreaks
        {
            get { return new VPageBreaks(_objCharts.GetType().InvokeMember("VPageBreaks", BindingFlags.GetProperty, null, _objCharts, null)); }
        }
        #endregion 属性

        #region 函数
        /// <summary>新建图表工作表，并返回 Chart 对象。
        /// </summary>
        /// <param name="Before">指定工作表的对象，新建的工作表将置于此工作表之前。</param>
        /// <param name="After">指定工作表的对象，新建的工作表将置于此工作表之后。</param>
        /// <param name="Count">要添加的工作表数。默认值为 1。</param>
        /// <param name="Count">一个 XlChartType 常量，它代表要添加的图表类型。</param>
        public dynamic Add(Worksheet Before = null, Worksheet After = null, int? Count = null, XlChartType? Type = null)
        {
            _objaParameters = new object[4] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet,
                Count == null ? System.Type.Missing : Count,
                Type == null ? System.Type.Missing : Type
            };

            return _objCharts.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>将工作表复制到工作簿的另一位置。
        /// </summary>
        /// <param name="Before">将要在其之前放置所复制工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所复制工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Copy(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objCharts.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objCharts.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objCharts, null);
        }

        /// <summary>
        /// </summary>
        public void FillAcrossSheets(Range Range, XlFillWith Type = XlFillWith.xlFillWithAll)
        {
            _objaParameters = new object[2] { Range._objRange, Type };
            _objCharts.GetType().InvokeMember("FillAcrossSheets", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>将图表移到工作簿的另一位置。
        /// </summary>
        /// <param name="Before">将要在其之前放置所移动图表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所移动图表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Move(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objCharts.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>打印对象。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        /// <param name="IgnorePrintAreas">如果为 True，则忽略打印区域并打印整个对象。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null, bool? IgnorePrintAreas = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            _objCharts.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(object From = null, object To = null, object Copies = null, object Preview = null, object ActivePrinter = null, object PrintToFile = null, object Collate = null, object PrToFileName = null, object IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objCharts.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] { EnableChanges == null ? System.Type.Missing : EnableChanges };
            _objCharts.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] { Replace == null ? System.Type.Missing : Replace };
            _objCharts.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objCharts, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>代表工作簿中的图表。
    /// 说明：
    /// 此图表既可以是嵌入的图表（包含在 ChartObject 对象中），也可以是单独的图表工作表。
    /// 示例部分中描述了以下用于返回 Chart 对象的属性和方法：
    /// Charts 方法 
    /// ActiveChart 属性 
    /// ActiveSheet 属性
    /// </summary>
    public class Chart
    {
        public object _objChart;
        internal object[] _objaParameters;

        public Chart(object objChart)
        { _objChart = objChart; }

        #region 属性

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个代表指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objChart.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup Area3DGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("Area3DGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>如果 Microsoft Excel 对三维图表进行缩放，使之与等效的二维图表的大小相近，则该属性值为 True。RightAngleAxes 属性必须为 True。Boolean 类型，可读写。
        /// </summary>
        public bool AutoScaling
        {
            get { return (bool)_objChart.GetType().InvokeMember("AutoScaling", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("AutoScaling", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回 Walls 对象，该对象允许用户单独对三维图表的背景墙进行格式设置。只读。
        /// </summary>
        public Walls BackWall
        {
            get { return new Walls(_objChart.GetType().InvokeMember("BackWall", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup Bar3DGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("Bar3DGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置用于三维条形图或柱形图的形状。XlBarShape 类型，可读写。
        /// </summary>
        public XlBarShape BarShape
        {
            get { return (XlBarShape)_objChart.GetType().InvokeMember("BarShape", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("BarShape", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 ChartArea 对象，该对象表示图表的整个图表区。只读。
        /// </summary>
        public ChartArea ChartArea
        {
            get { return new ChartArea(_objChart.GetType().InvokeMember("ChartArea", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置图表的图表样式。可读/写 Variant 类型。
        /// </summary>
        public dynamic ChartStyle
        {
            get { return _objChart.GetType().InvokeMember("ChartStyle", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ChartStyle", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 ChartTitle 对象，该对象表示指定图表的标题。只读。
        /// </summary>
        public ChartTitle ChartTitle
        {
            get { return new ChartTitle(_objChart.GetType().InvokeMember("ChartTitle", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置图表类型。XlChartType 类型，可读写。
        /// </summary>
        public XlChartType ChartType
        {
            get { return (XlChartType)_objChart.GetType().InvokeMember("ChartType", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回对象的代码名。String 型，只读。
        /// </summary>
        public string CodeName
        {
            get { return _objChart.GetType().InvokeMember("CodeName", BindingFlags.GetProperty, null, _objChart, null).ToString(); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup Column3DGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("Column3DGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objChart.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>返回一个 DataTable 对象，该对象表示图表的数据表。只读。
        /// </summary>
        public DataTable DataTable
        {
            get { return new DataTable(_objChart.GetType().InvokeMember("DataTable", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置三维图表的深度，以图表宽度的百分比表示（有效范围从 20% 到 2000%）。Long 类型，可读写。
        /// </summary>
        public int DepthPercent
        {
            get { return (int)_objChart.GetType().InvokeMember("DepthPercent", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("DepthPercent", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回或设置在图表中绘制空白单元格的方式。可以是 XlDisplayBlanksAs 常量之一。Long 类型，可读写。
        /// </summary>
        public XlDisplayBlanksAs DisplayBlanksAs
        {
            get { return (XlDisplayBlanksAs)_objChart.GetType().InvokeMember("DisplayBlanksAs", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("DisplayBlanksAs", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回或设置三维图表视图的仰角（以角度为单位）。Long 类型，可读写。
        /// </summary>
        public int Elevation
        {
            get { return (int)_objChart.GetType().InvokeMember("Elevation", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("Elevation", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 Floor 对象，该对象表示三维图表的基底。只读。
        /// </summary>
        public Floor Floor
        {
            get { return new Floor(_objChart.GetType().InvokeMember("Floor", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>以数据标志宽度的形式返回或设置三维图表中数据系列之间的距离，本属性的值必须在 0 和 500 之间。Long 类型，可读写。
        /// </summary>
        public int GapDepth
        {
            get { return (int)_objChart.GetType().InvokeMember("GapDepth", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("GapDepth", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果图表有数据表，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool HasDataTable
        {
            get { return (bool)_objChart.GetType().InvokeMember("HasDataTable", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("HasDataTable", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果图表有图例，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool HasLegend
        {
            get { return (bool)_objChart.GetType().InvokeMember("HasLegend", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("HasLegend", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool HasPivotFields
        {
            get { return (bool)_objChart.GetType().InvokeMember("HasPivotFields", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("HasPivotFields", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果坐标轴或图表有可见标题，则为 True。Boolean 类型，可读写。
        /// </summary>
        public bool HasTitle
        {
            get { return (bool)_objChart.GetType().InvokeMember("HasTitle", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("HasTitle", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回或设置三维图表的高度，以图表宽度的百分比表示，有效取值范围为 1% 到 10000%。可读/写 Long 类型。
        /// </summary>
        public int HeightPercent
        {
            get { return (int)_objChart.GetType().InvokeMember("HeightPercent", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("HeightPercent", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 Hyperlinks 集合，它代表图表的超链接。
        /// </summary>
        public Hyperlinks Hyperlinks
        {
            get { return new Hyperlinks(_objChart.GetType().InvokeMember("Hyperlinks", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回 Long 值，它代表对象在其同类对象所组成的集合内的索引号。
        /// </summary>
        public int Index
        {
            get { return (int)_objChart.GetType().InvokeMember("Index", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>返回一个 Legend 对象，该对象表示指定图表的图例。只读。
        /// </summary>
        public Legend Legend
        {
            get { return new Legend(_objChart.GetType().InvokeMember("Legend", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup Line3DGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("Line3DGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>代表文档的电子邮件标题。
        /// </summary>
        public MsoEnvelope MailEnvelope
        {
            get { return new MsoEnvelope(_objChart.GetType().InvokeMember("MailEnvelope", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objChart.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objChart, null).ToString(); }
            set { _objChart.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回代表下一个工作表的 Worksheet 对象。
        /// </summary>
        public Worksheet Next
        {
            get { return new Worksheet(_objChart.GetType().InvokeMember("Next", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public string OnDoubleClick
        {
            get { return _objChart.GetType().InvokeMember("OnDoubleClick", BindingFlags.GetProperty, null, _objChart, null).ToString(); }
            set { _objChart.GetType().InvokeMember("OnDoubleClick", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetActivate
        {
            get { return _objChart.GetType().InvokeMember("OnSheetActivate", BindingFlags.GetProperty, null, _objChart, null).ToString(); }
            set { _objChart.GetType().InvokeMember("OnSheetActivate", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public string OnSheetDeactivate
        {
            get { return _objChart.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.GetProperty, null, _objChart, null).ToString(); }
            set { _objChart.GetType().InvokeMember("OnSheetDeactivate", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 PageSetup 对象，它包含用于指定对象的所有页面设置。只读。
        /// </summary>
        public PageSetup PageSetup
        {
            get { return new PageSetup(_objChart.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objChart.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>返回或设置一个 Long 值，它代表三维图表视图的透视系数。
        /// </summary>
        public int Perspective
        {
            get { return (int)_objChart.GetType().InvokeMember("Perspective", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("Perspective", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup Pie3DGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("Pie3DGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回一个 PivotLayout 对象，该对象表示数据透视表中字段的位置以及数据透视图中坐标轴的位置。只读。
        /// </summary>
        public PivotLayout PivotLayout
        {
            get { return new PivotLayout(_objChart.GetType().InvokeMember("PivotLayout", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回一个 PlotArea 对象，该对象表示图表的绘图区。只读。
        /// </summary>
        public PlotArea PlotArea
        {
            get { return new PlotArea(_objChart.GetType().InvokeMember("PlotArea", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置行或列在图表中作为数据系列使用的方式。可为以下 XlRowCol 常量之一：xlColumns 或 xlRows。Long 类型，可读写。
        /// </summary>
        public XlRowCol PlotBy
        {
            get { return (XlRowCol)_objChart.GetType().InvokeMember("PlotBy", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("PlotBy", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果仅绘制可见单元格，则该值为 True。如果可见单元格和隐藏单元格都绘制，则该值为 False。Boolean 类型，可读写。
        /// </summary>
        public bool PlotVisibleOnly
        {
            get { return (bool)_objChart.GetType().InvokeMember("PlotVisibleOnly", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("PlotVisibleOnly", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回代表下一个工作表的 Worksheet 对象。
        /// </summary>
        public dynamic Previous
        {
            get { return _objChart.GetType().InvokeMember("Previous", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>如果工作表内容是受保护的，则为 True。对于图表，这样会保护整个图表。要打开内容保护，请使用 Protect 方法，并将 Contents 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectContents
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectContents", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>如果用户不能更改系列公式，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ProtectData
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectData", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ProtectData", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果形状是受保护的，则为 True。要打开形状保护，请使用 Protect 方法，并将 DrawingObjects 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectDrawingObjects
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectDrawingObjects", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>如果用户不能更改格式，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ProtectFormatting
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectFormatting", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ProtectFormatting", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果用户不能用鼠标操作修改图表数据点，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ProtectGoalSeek
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectGoalSeek", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ProtectGoalSeek", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果启用了用户界面专用保护，则为 True。要打开用户界面保护，请使用 Protect 方法，并将 UserInterfaceOnly 参数设置为 True。Boolean 类型，只读。
        /// </summary>
        public bool ProtectionMode
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectionMode", BindingFlags.GetProperty, null, _objChart, null); }
        }

        /// <summary>如果不能选定图表元素，则该属性值为 True。Boolean 类型，可读写。
        /// </summary>
        public bool ProtectSelection
        {
            get { return (bool)_objChart.GetType().InvokeMember("ProtectSelection", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ProtectSelection", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>如果图表的坐标轴为直角，并与图表的转角或仰角无关，则该值为 True。仅应用于三维折线图、柱形图和条形图。Boolean 类型，可读写。
        /// </summary>
        public bool RightAngleAxes
        {
            get { return (bool)_objChart.GetType().InvokeMember("RightAngleAxes", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("RightAngleAxes", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>以度为单位返回或设置三维图表视图的转角（绘图区绕 Z 轴的转角）。此属性的取值必须介于 0 到 360 之间，三维条形图除外（从 0 到 44 之间）。默认值是 20。仅适用于三维图表。Variant 型，可读写。
        /// </summary>
        public float Rotation
        {
            get { return (float)_objChart.GetType().InvokeMember("Rotation", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("Rotation", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 Shapes 集合，它代表图表工作表上所有的形状。只读。
        /// </summary>
        public Shapes Shapes
        {
            get { return new Shapes(_objChart.GetType().InvokeMember("Shapes", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>返回或设置一个布尔值，该值表示在数值大于数值轴上的最大值时是否显示数据标签。可读/写 Boolean 类型。
        /// </summary>
        public bool ShowDataLabelsOverMaximum
        {
            get { return (bool)_objChart.GetType().InvokeMember("ShowDataLabelsOverMaximum", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ShowDataLabelsOverMaximum", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool ShowWindow
        {
            get { return (bool)_objChart.GetType().InvokeMember("ShowWindow", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("ShowWindow", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回 Walls 对象，该对象允许用户单独对三维图表的侧面墙进行格式设置。只读。
        /// </summary>
        public Walls SideWall
        {
            get { return new Walls(_objChart.GetType().InvokeMember("SideWall", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public bool SizeWithWindow
        {
            get { return (bool)_objChart.GetType().InvokeMember("SizeWithWindow", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("SizeWithWindow", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public int SubType
        {
            get { return (int)_objChart.GetType().InvokeMember("SubType", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("SubType", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public ChartGroup SurfaceGroup
        {
            get { return new ChartGroup(_objChart.GetType().InvokeMember("SurfaceGroup", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>为图表返回一个 Tab 对象。
        /// </summary>
        public Tab Tab
        {
            get { return new Tab(_objChart.GetType().InvokeMember("Tab", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public int Type
        {
            get { return (int)_objChart.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("Type", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 XlSheetVisibility 值，它确定对象是否可见。
        /// </summary>
        public XlSheetVisibility Visible
        {
            get { return (XlSheetVisibility)_objChart.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }

        /// <summary>返回一个 Walls 对象，该对象表示三维图表的背景墙。只读。
        /// </summary>
        public Walls Walls
        {
            get { return new Walls(_objChart.GetType().InvokeMember("Walls", BindingFlags.GetProperty, null, _objChart, null)); }
        }

        /// <summary>
        /// </summary>
        public bool WallsAndGridlines2D
        {
            get { return (bool)_objChart.GetType().InvokeMember("WallsAndGridlines2D", BindingFlags.GetProperty, null, _objChart, null); }
            set { _objChart.GetType().InvokeMember("WallsAndGridlines2D", BindingFlags.SetProperty, null, _objChart, new object[1] { value }); }
        }
        #endregion 属性

        #region 函数
        /// <summary>使当前图表成为活动图表。
        /// </summary>
        public void Activate()
        {
            _objChart.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>将标准图表类型或自定义图表类型应用于图表。
        /// </summary>
        /// <param name="Filename">图表模板的文件名。</param>
        public void ApplyChartTemplate(string Filename)
        {
            _objaParameters = new object[1] { Filename };
            _objChart.GetType().InvokeMember("ApplyChartTemplate", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void ApplyCustomType(XlChartType ChartType, object TypeName = null)
        {
            _objaParameters = new object[2] {
                ChartType,
                TypeName == null ? System.Type.Missing : TypeName
            };

            _objChart.GetType().InvokeMember("ApplyCustomType", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>将数据标签应用到图表中的所有系列。
        /// </summary>
        /// <param name="Type">要应用的数据标签的类型。</param>
        /// <param name="LegendKey">如果为 True，则在数据点旁边显示图例项标示。默认值为 False。</param>
        /// <param name="AutoText">如果对象根据内容自动生成相应的文字，则为 True。</param>
        /// <param name="HasLeaderLines">对于 Chart 和 Series 对象，如果数据系列有引导线，则为 True。</param>
        /// <param name="ShowSeriesName">传递布尔值以启用或禁用数据标签的系列名称。</param>
        /// <param name="ShowCategoryName">传递布尔值以启用或禁用数据标签的分类名称。</param>
        /// <param name="ShowValue">传递布尔值以启用或禁用数据标签的值。</param>
        /// <param name="ShowPercentage">传递布尔值以启用或禁用数据标签的百分比。</param>
        /// <param name="ShowBubbleSize">传递布尔值以启用或禁用数据标签的气泡大小。</param>
        /// <param name="Separator">数据标签的分隔符。</param>
        public void ApplyDataLabels(XlDataLabelsType Type = XlDataLabelsType.xlDataLabelsShowValue, bool? LegendKey = null, bool? AutoText = null, bool? HasLeaderLines = null, bool? ShowSeriesName = null, bool? ShowCategoryName = null, bool? ShowValue = null, bool? ShowPercentage = null, bool? ShowBubbleSize = null, string Separator = null)
        {
            _objaParameters = new object[10] {
                Type,
                LegendKey == null ? System.Type.Missing : LegendKey,
                AutoText == null ? System.Type.Missing : AutoText,
                HasLeaderLines == null ? System.Type.Missing : HasLeaderLines,
                ShowSeriesName == null ? System.Type.Missing : ShowSeriesName,
                ShowCategoryName == null ? System.Type.Missing : ShowCategoryName,
                ShowValue == null ? System.Type.Missing : ShowValue,
                ShowPercentage == null ? System.Type.Missing : ShowPercentage,
                ShowBubbleSize == null ? System.Type.Missing : ShowBubbleSize,
                Separator == null ? System.Type.Missing : Separator
            };

            _objChart.GetType().InvokeMember("ApplyDataLabels", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>应用功能区中显示的版式。
        /// </summary>
        /// <param name="Layout">指定版式类型。版式类型由 1 到 10 的数字表示。</param>
        public void ApplyLayout(int Layout, object ChartType = null)
        {
            _objaParameters = new object[2] {
                Layout,
                ChartType == null ? System.Type.Missing : ChartType
            };

            _objChart.GetType().InvokeMember("ApplyLayout", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Arcs(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Arcs", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic AreaGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("AreaGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void AutoFormat(int Gallery, object Format = null)
        {
            _objaParameters = new object[2] {
                Gallery,
                Format == null ? System.Type.Missing : Format
            };

            _objChart.GetType().InvokeMember("AutoFormat", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回一个代表图表上单个坐标轴或坐标轴集合的某个对象。
        /// </summary>
        /// <param name="Type">指定要返回的坐标轴。可为以下 XlAxisType 常量之一：xlValue、xlCategory 或 xlSeriesAxis（xlSeriesAxis 仅对三维图表有效）。</param>
        /// <param name="AxisGroup">指定坐标轴组。如果省略该参数，则使用主坐标轴组。三维图表仅有一个坐标轴组。</param>
        public dynamic Axes(XlAxisType? Type = null, XlAxisGroup AxisGroup = XlAxisGroup.xlPrimary)
        {
            _objaParameters = new object[2] {
                Type == null ? System.Type.Missing : Type,
                AxisGroup
            };

            return _objChart.GetType().InvokeMember("Axes", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic BarGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("BarGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Buttons(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Buttons", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回一个对象，该对象表示图表中单个图表组（ChartGroup 对象）或所有图表组的集合（ChartGroups 对象）。返回的集合中包括每种类型的图表组。
        /// </summary>
        /// <param name="Index">图表组编号。</param>
        public dynamic ChartGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("ChartGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回一个对象，它代表工作表上的一个嵌入式图表（ChartObject 对象）或所有嵌入式图表的集合（ChartObjects 对象）。
        /// </summary>
        /// <param name="Index">图表的名称或号码。该参数可以是数组，用于指定多个图表。</param>
        public dynamic ChartObjects(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("ChartObjects", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>修改给定图表的属性。可使用本方法快速设置图表的格式，而不必逐个设置所有属性。本方法是非交互式的，并且仅更改指定的属性。
        /// </summary>
        /// <param name="Source">包含新图表源数据的区域。如果省略本参数，Microsoft Excel 将编辑活动图表工作表或活动工作表上处于选定状态的图表。</param>
        /// <param name="Gallery">用于指定图表类型的 XlChartType 的常量之一。</param>
        /// <param name="Format">内置自动套用格式的选项编号。可为从 1 到 10 的数字，其取值取决于库的类型。如果省略此参数，Microsoft Excel 将根据库的类型和数据源选择默认值。</param>
        /// <param name="PlotBy">指定每个系列的数据是来自行还是来自列。可以是以下 XlRowCol 常量之一：xlRows 或 xlColumns。</param>
        /// <param name="CategoryLabels">指定包含分类标签的源范围内的行数或列数的整数。合法值为从 0（零）至小于相应分类或系列的最大个数间的某一数字。</param>
        /// <param name="SeriesLabels">指定包含系列标志的源范围内的行数或列数的整数。合法值为从 0（零）至小于相应分类或系列的最大个数间的某一数字。</param>
        /// <param name="HasLegend">若要包括图例，则为 True。</param>
        /// <param name="Title">图表标题文字。</param>
        /// <param name="CategoryTitle">分类轴标题文字。</param>
        /// <param name="ValueTitle">数值轴标题文字。</param>
        /// <param name="ExtraTitle">三维图表的系列轴标题，或二维图表的次数值轴标题。</param>
        public void ChartWizard(object Source = null, XlChartType? Gallery = null, int? Format = null, XlRowCol? PlotBy = null, int? CategoryLabels = null, int? SeriesLabels = null, bool? HasLegend = null, string Title = null, string CategoryTitle = null, string ValueTitle = null, string ExtraTitle = null)
        {
            _objaParameters = new object[11] {
                Source == null ? System.Type.Missing : Source,
                Gallery == null ? System.Type.Missing : Gallery,
                Format == null ? System.Type.Missing : Format,
                PlotBy == null ? System.Type.Missing : PlotBy,
                CategoryLabels == null ? System.Type.Missing : CategoryLabels,
                SeriesLabels == null ? System.Type.Missing : SeriesLabels,
                HasLegend == null ? System.Type.Missing : HasLegend,
                Title == null ? System.Type.Missing : Title,
                CategoryTitle == null ? System.Type.Missing : CategoryTitle,
                ValueTitle == null ? System.Type.Missing : ValueTitle,
                ExtraTitle == null ? System.Type.Missing : ExtraTitle
            };

            _objChart.GetType().InvokeMember("ChartWizard", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic CheckBoxes(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("CheckBoxes", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>检查对象的拼写。
        /// </summary>
        /// <param name="CustomDictionary">一个字符串，它表示自定义词典的文件名，如果在主词典中找不到单词，则会到此词典中查找。如果省略此参数，则使用当前指定的词典。</param>
        /// <param name="IgnoreUppercase">如果为 True，则 Microsoft Excel 忽略所有字母都是大写的单词。如果为 False，则 Microsoft Excel 检查所有字母都是大写的单词。如果省略此参数，将使用当前的设置。</param>
        /// <param name="AlwaysSuggest">如果为 True，则 Microsoft Excel 在找到不正确拼写时显示建议的替换拼写列表。如果为 False，Microsoft Excel 将等待输入正确的拼写。如果省略此参数，将使用当前的设置。</param>
        /// <param name="SpellLang">当前所用词典的语言。它可以是由 LanguageID 属性使用的 MsoLanguageID 值之一。</param>
        public void CheckSpelling(string CustomDictionary = null, bool? IgnoreUppercase = null, bool? AlwaysSuggest = null, MsoLanguageID? SpellLang = null)
        {
            _objaParameters = new object[4] {
                CustomDictionary == null ? System.Type.Missing : CustomDictionary,
                IgnoreUppercase == null ? System.Type.Missing : IgnoreUppercase,
                AlwaysSuggest == null ? System.Type.Missing : AlwaysSuggest,
                SpellLang == null ? System.Type.Missing : SpellLang
            };

            _objChart.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void ClearToMatchStyle()
        {
            _objChart.GetType().InvokeMember("ClearToMatchStyle", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>
        /// </summary>
        public dynamic ColumnGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("ColumnGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>将工作表复制到工作簿的另一位置。
        /// </summary>
        /// <param name="Before">将要在其之前放置所复制工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所复制工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Copy(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objChart.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void CopyChartBuild()
        {
            _objChart.GetType().InvokeMember("CopyChartBuild", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>将所选对象作为图片复制到剪贴板。
        /// </summary>
        /// <param name="Appearance">指定图片的复制方式。默认值为 xlScreen。</param>
        /// <param name="Format">图片的格式。默认值为 xlPicture。</param>
        /// <param name="Size">当对象是图表工作表中的图表（不是工作表中的嵌入式图表）时，此参数代表复制图片的大小。默认值为 xlPrinter。</param>
        public void CopyPicture(XlPictureAppearance Appearance = XlPictureAppearance.xlScreen, XlCopyPictureFormat Format = XlCopyPictureFormat.xlPicture, XlPictureAppearance Size = XlPictureAppearance.xlPrinter)
        {
            _objaParameters = new object[3] { Appearance, Format, Size };
            _objChart.GetType().InvokeMember("CopyPicture", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void CreatePublisher(object Edition = null, XlPictureAppearance Appearance = XlPictureAppearance.xlScreen, XlPictureAppearance Size = XlPictureAppearance.xlScreen, object ContainsPICT = null, object ContainsBIFF = null, object ContainsRTF = null, object ContainsVALU = null)
        {
            _objaParameters = new object[7] {
                Edition == null ? System.Type.Missing : Edition,
                Appearance,
                Size,
                ContainsPICT == null ? System.Type.Missing : ContainsPICT,
                ContainsBIFF == null ? System.Type.Missing : ContainsBIFF,
                ContainsRTF == null ? System.Type.Missing : ContainsRTF,
                ContainsVALU == null ? System.Type.Missing : ContainsVALU
            };

            _objChart.GetType().InvokeMember("CreatePublisher", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objChart.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>取消对指定图表的选定。
        /// </summary>
        public void Deselect()
        {
            _objChart.GetType().InvokeMember("Deselect", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>
        /// </summary>
        public dynamic DoughnutGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("DoughnutGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic DrawingObjects(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("DrawingObjects", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Drawings(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Drawings", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic DropDowns(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("DropDowns", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>将一个 Microsoft Excel 名称转换为一个对象或者一个值。
        /// </summary>
        /// <param name="Name">使用 Microsoft Excel 命名约定的对象名称。</param>
        public dynamic Evaluate(string Name)
        {
            _objaParameters = new object[1] { Name };
            return _objChart.GetType().InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>以图形格式导出图表。
        /// </summary>
        /// <param name="Filename">被导出的文件的名称。</param>
        /// <param name="FilterName">图形过滤器出现在注册表中时独立于语言的名称。</param>
        /// <param name="Interactive">如果为 True，则显示包含筛选器特定选项的对话框。如果为 False，则 Microsoft Excel 使用筛选器的默认值。默认值是 False。</param>
        public bool Export(string Filename, string FilterName = null, bool? Interactive = null)
        {
            _objaParameters = new object[3] {
                Filename,
                FilterName == null ? System.Type.Missing : FilterName,
                Interactive == null ? System.Type.Missing : Interactive
            };

            return (bool)_objChart.GetType().InvokeMember("Export", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>导出为指定格式的文件。
        /// </summary>
        /// <param name="Type">要导出为的文件格式类型。</param>
        /// <param name="Filename">要保存的文件的文件名。可以包括完整路径，否则 Excel 2007 会将文件保存在当前文件夹中。</param>
        /// <param name="Quality">可选 XlFixedFormatQuality。指定已发布文件的质量。</param>
        /// <param name="IncludeDocProperties">若要包括文档属性，则为 True；否则为 False。</param>
        /// <param name="IgnorePrintAreas">若要忽略发布时设置的任何打印区域，则为 True；否则为 False。</param>
        /// <param name="From">发布的起始页码。如果省略此参数，则从起始位置开始发布。</param>
        /// <param name="To">发布的终止页码。如果省略此参数，则发布至最后一页。</param>
        /// <param name="OpenAfterPublish">若要在发布文件后在查看器中显示文件，则为 True；否则为 False。</param>
        public void ExportAsFixedFormat(XlFixedFormatType Type, string Filename = null, XlFixedFormatQuality? Quality = null, bool? IncludeDocProperties = null, bool? IgnorePrintAreas = null, int? From = null, int? To = null, bool? OpenAfterPublish = null, object FixedFormatExtClassPtr = null)
        {
            _objaParameters = new object[9] {
                Type,
                Filename == null ? System.Type.Missing : Filename,
                Quality == null ? System.Type.Missing : Quality,
                IncludeDocProperties == null ? System.Type.Missing : IncludeDocProperties,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas,
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                OpenAfterPublish == null ? System.Type.Missing : OpenAfterPublish,
                FixedFormatExtClassPtr == null ? System.Type.Missing : FixedFormatExtClassPtr
            };

            _objChart.GetType().InvokeMember("ExportAsFixedFormat", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回指定的 X 坐标和 Y 坐标上图表元素的信息。本方法稍有与众不同之处：调用时只须指定前两个参数，在本方法执行期间，Microsoft Excel 为其余参数赋值，本方法返回后应检验这些参数的值。
        /// </summary>
        /// <param name="x">图表元素的 X 坐标。</param>
        /// <param name="y">图表元素的 Y 坐标。</param>
        /// <param name="ElementID">该方法返回时，此参数包含指定坐标的图表元素的 XLChartItem 值。有关详细信息，请参阅“备注”部分。</param>
        /// <param name="Arg1">该方法返回时，该参数包含与图表元素相关的信息。有关详细信息，请参阅“备注”部分。</param>
        /// <param name="Arg2">该方法返回时，该参数包含与图表元素相关的信息。有关详细信息，请参阅“备注”部分。</param>
        public void GetChartElement(int x, int y, ref int ElementID, ref int Arg1, ref int Arg2)
        {
            _objaParameters = new object[5] { x, y, ElementID, Arg1, Arg2 };
            _objChart.GetType().InvokeMember("GetChartElement", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic GroupBoxes(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("GroupBoxes", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic GroupObjects(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("GroupObjects", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Labels(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Labels", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic LineGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("LineGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Lines(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Lines", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic ListBoxes(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("ListBoxes", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>将图表移动到新位置。
        /// </summary>
        /// <param name="Where">图表移动的目标位置。</param>
        /// <param name="Name">如果 Where 为 xlLocationAsObject，则该参数为必选参数。如果 Where 为 xlLocationAsObject，则该参数为嵌入该图表的工作表的名称。如果 Where 为 xlLocationAsNewSheet，则该参数为新工作表的名称。</param>
        public Chart Location(XlChartLocation Where, string Name = null)
        {
            _objaParameters = new object[2] {
                Where,
                Name == null ? System.Type.Missing : Name
            };

            return new Chart(_objChart.GetType().InvokeMember("Location", BindingFlags.InvokeMethod, null, _objChart, _objaParameters));
        }

        /// <summary>将图表移到工作簿的另一位置。
        /// </summary>
        /// <param name="Before">将要在其之前放置所移动图表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所移动图表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Move(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objChart.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回一个对象，它代表图表或工作表上的单个 OLE 对象 (OLEObject ) 或所有 OLE 对象的集合（OLEObjects 集合）。只读。
        /// </summary>
        /// <param name="Index">OLE 对象的名称或编号。</param>
        public dynamic OLEObjects(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("OLEObjects", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic OptionButtons(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("OptionButtons", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Ovals(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Ovals", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>将剪贴板中的图表数据粘贴到指定的图表中。
        /// </summary>
        /// <param name="Type">指定要粘贴的图表信息（如果剪贴板中有一个图表）。可以为以下 XlPasteType 常量之一：xlPasteFormats、xlPasteFormulas 或 xlPasteAll。默认值为 xlPasteAll。如果剪贴板上的数据不是图表数据，则不能使用该参数。</param>
        public void Paste(XlPasteType? Type = null)
        {
            _objaParameters = new object[1] { Type == null ? System.Type.Missing : Type };
            _objChart.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Pictures(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Pictures", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic PieGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("PieGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>打印对象。
        /// 说明：
        /// From 和 To 所描述的“页”指的是要打印的页，并非指定工作表或工作簿中的全部页。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            _objChart.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(object From = null, object To = null, object Copies = null, object Preview = null, object ActivePrinter = null, object PrintToFile = null, object Collate = null, object PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            _objChart.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] { EnableChanges == null ? System.Type.Missing : EnableChanges };
            _objChart.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>保护图表使其不被修改。
        /// </summary>
        /// <param name="Password">一个字符串，该字符串为工作表或工作簿指定区分大小写的密码。如果省略此参数，不用密码就可以取消对工作表或工作簿的保护。否则，必须指定密码才能取消对工作表或工作簿的保护。如果忘记了密码，就无法取消对工作表或工作簿的保护。</param>
        /// <param name="DrawingObjects">如果为 True，则保护形状。默认值是 True。</param>
        /// <param name="Contents">如果为 True，则保护内容。对于图表，这样会保护整个图表。对于工作表，这样会保护锁定的单元格。默认值是 True。</param>
        /// <param name="Scenarios">如果为 True，则保护方案。此参数仅对工作表有效。默认值是 True。</param>
        /// <param name="UserInterfaceOnly">如果为 True，则保护用户界面，但不保护宏。如果省略此参数，则既保护宏也保护用户界面。</param>
        public void Protect(string Password = null, bool? DrawingObjects = null, bool? Contents = null, bool? Scenarios = null, bool? UserInterfaceOnly = null)
        {
            _objaParameters = new object[5] {
                Password == null ? System.Type.Missing : Password,
                DrawingObjects == null ? System.Type.Missing : DrawingObjects,
                Contents == null ? System.Type.Missing : Contents,
                Scenarios == null ? System.Type.Missing : Scenarios,
                UserInterfaceOnly == null ? System.Type.Missing : UserInterfaceOnly
            };

            _objChart.GetType().InvokeMember("Protect", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic RadarGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("RadarGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Rectangles(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Rectangles", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>立即重新绘制指定的图表。
        /// </summary>
        public void Refresh()
        {
            _objChart.GetType().InvokeMember("Refresh", BindingFlags.InvokeMethod, null, _objChart, null);
        }

        /// <summary>将对图表或工作表的更改保存到另一不同文件中。
        /// </summary>
        /// <param name="Filename">Variant。一个字符串，表示要保存的文件名。可包含完整路径。如果不指定路径，Microsoft Excel 将文件保存到当前文件夹中。</param>
        /// <param name="FileFormat">保存文件时使用的文件格式。要查看有效的选项列表，请参阅 FileFormat 属性。对于现有文件，默认采用上一次指定的文件格式；对于新文件，默认采用当前所用 Excel 版本的格式。</param>
        /// <param name="Password">它是一个区分大小写的字符串（最长不超过 15 个字符），用于指定文件的保护密码。</param>
        /// <param name="WriteResPassword">一个表示文件写保护密码的字符串。如果文件保存时带有密码，但打开文件时不输入密码，则该文件以只读方式打开。</param>
        /// <param name="ReadOnlyRecommended">如果为 True，则在打开文件时显示一条消息，提示该文件以只读方式打开。</param>
        /// <param name="CreateBackup">如果为 True，则创建备份文件。</param>
        /// <param name="AddToMru">如果为 True，则将该工作簿添加到最近使用的文件列表中。默认值是 False。</param>
        /// <param name="TextCodepage">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="TextVisualLayout">不在美国英语版的 Microsoft Excel 中使用。</param>
        /// <param name="Local">如果为 True，则以 Microsoft Excel（包括控制面板设置）的语言保存文件。如果为 False（默认值），则以 Visual Basic for Applications (VBA) （Visual Basic for Applications (VBA)：Microsoft Visual Basic 的宏语言版本，用于编写基于 Microsoft Windows 的应用程序，内置于多个 Microsoft 程序中。） 的语言保存文件，其中 Visual Basic for Applications (VBA) 通常为美国英语版本，除非从中运行 Workbooks.Open 的 VBA 项目是旧的已国际化的 XL5/95 VBA 项目。</param>
        public void SaveAs(string Filename, XlFileFormat? FileFormat = null, string Password = null, string WriteResPassword = null, bool? ReadOnlyRecommended = null, bool? CreateBackup = null, bool? AddToMru = null, object TextCodepage = null, object TextVisualLayout = null, bool? Local = null)
        {
            _objaParameters = new object[10] {
                Filename,
                FileFormat == null ? System.Type.Missing : FileFormat,
                Password == null ? System.Type.Missing : Password,
                WriteResPassword == null ? System.Type.Missing : WriteResPassword,
                ReadOnlyRecommended == null ? System.Type.Missing : ReadOnlyRecommended,
                CreateBackup == null ? System.Type.Missing : CreateBackup,
                AddToMru == null ? System.Type.Missing : AddToMru,
                TextCodepage == null ? System.Type.Missing : TextCodepage,
                TextVisualLayout == null ? System.Type.Missing : TextVisualLayout,
                Local == null ? System.Type.Missing : Local
            };

            _objChart.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>向可用图表模板的列表添加自定义图表模板。
        /// </summary>
        /// <param name="Filename">图表模板的名称。</param>
        public void SaveChartTemplate(string Filename)
        {
            _objaParameters = new object[1] { Filename };
            _objChart.GetType().InvokeMember("SaveChartTemplate", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic ScrollBars(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("ScrollBars", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] { Replace == null ? System.Type.Missing : Replace };
            _objChart.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>返回一个对象，它代表图表或图表组中的一个系列（Series 对象）或所有系列的集合（SeriesCollection 集合）。
        /// </summary>
        /// <param name="Index">数据系列的名称或编号。</param>
        public dynamic SeriesCollection(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("SeriesCollection", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>为图表设置背景图形。
        /// </summary>
        /// <param name="Filename">图形文件名。</param>
        public void SetBackgroundPicture(string Filename)
        {
            _objaParameters = new object[1] { Filename };
            _objChart.GetType().InvokeMember("SetBackgroundPicture", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>指定 Microsoft Excel 新建图表时使用的图表模板的名称。
        /// </summary>
        /// <param name="Name">指定新建图表时将使用的默认图表模板的名称。此名称可以是字符串，指定库中图表，进而指定用户定义的模板，也可以是一个特殊常量 xlBuiltIn，用于指定内置图表模板。</param>
        public void SetDefaultChart(object Name)
        {
            _objaParameters = new object[1] { Name };
            _objChart.GetType().InvokeMember("SetDefaultChart", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>设置图表上的图表元素。可读/写 MsoChartElementType 类型。
        /// </summary>
        /// <param name="Element">指定图表元素类型。</param>
        public void SetElement(MsoChartElementType Element)
        {
            _objaParameters = new object[1] { Element };
            _objChart.GetType().InvokeMember("SetElement", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>为指定图表设置源数据区域。
        /// </summary>
        /// <param name="Source">包含源数据的区域。</param>
        /// <param name="PlotBy">指定数据绘制方式。可为以下 XlRowCol 常量之一：xlColumns 或 xlRows。</param>
        public void SetSourceData(Range Source, XlRowCol? PlotBy = null)
        {
            _objaParameters = new object[2] {
                Source._objRange,
                PlotBy == null ? System.Type.Missing : PlotBy
            };

            _objChart.GetType().InvokeMember("SetSourceData", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic Spinners(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("Spinners", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic TextBoxes(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("TextBoxes", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>取消工作表或工作簿的保护。如果工作表或工作簿不是受保护的，则此方法不起作用。
        /// </summary>
        /// <param name="Password">指定用于解除图表保护的密码，此密码是区分大小写的。如果图表不设密码保护，则忽略该参数。</param>
        public void Unprotect(string Password = null)
        {
            _objaParameters = new object[1] { Password == null ? System.Type.Missing : Password };
            _objChart.GetType().InvokeMember("Unprotect", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public dynamic XYGroups(object Index = null)
        {
            _objaParameters = new object[1] { Index == null ? System.Type.Missing : Index };
            return _objChart.GetType().InvokeMember("XYGroups", BindingFlags.InvokeMethod, null, _objChart, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary> 代表工作表或区域的超链接的集合。
    /// 说明：
    /// 每个超链接都由一个 Hyperlink 对象代表。
    /// </summary>
    public class Hyperlinks
    {
        public object _objHyperlinks;
        internal object[] _objaParameters;

        internal Hyperlinks(object objHyperlinks)
        { _objHyperlinks = objHyperlinks; }

        public Hyperlink this[object Index]
        {
            get
            {
                object objHyperlink = _objHyperlinks.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objHyperlinks, new object[1] { Index });

                if (objHyperlink == null)
                    return null;
                else
                    return new Hyperlink(objHyperlink);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objHyperlinks.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objHyperlinks, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objHyperlinks.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objHyperlinks, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objHyperlinks.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objHyperlinks, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objHyperlinks.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objHyperlinks, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>向指定的区域或形状添加超链接。
        /// </summary>
        /// <param name="Anchor">超链接的位置。可为 Range 或 Shape 对象。</param>
        /// <param name="Address">超链接的地址。</param>
        /// <param name="SubAddress">超链接的子地址。</param>
        /// <param name="ScreenTip">当鼠标指针停留在超链接上时所显示的屏幕提示。</param>
        /// <param name="TextToDisplay">要显示的超链接的文本。</param>
        public dynamic Add(object Anchor, string Address, string SubAddress = null, string ScreenTip = null, string TextToDisplay = null)
        {
            _objaParameters = new object[5] {
                Anchor,
                Address,
                SubAddress == null ? System.Type.Missing : SubAddress,
                ScreenTip == null ? System.Type.Missing : ScreenTip,
                TextToDisplay == null ? System.Type.Missing : TextToDisplay
            };

            return _objHyperlinks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objHyperlinks, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objHyperlinks.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objHyperlinks, null);
        }
        #endregion 函数
    }

    /// <summary>代表一个超链接。
    /// 说明：
    /// Hyperlink 对象是 Hyperlinks 集合的成员。
    /// </summary>
    public class Hyperlink
    {
        public object _objHyperlink;
        internal object[] _objaParameters;

        public Hyperlink(object objHyperlink)
        { _objHyperlink = objHyperlink; }

        #region 属性
        /// <summary>返回或设置一个 String 型，它代表目标文档的地址。
        /// </summary>
        public string Address
        {
            get { return _objHyperlink.GetType().InvokeMember("Address", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
            set { _objHyperlink.GetType().InvokeMember("Address", BindingFlags.SetProperty, null, _objHyperlink, new object[1] { value }); }
        }

        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objHyperlink.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objHyperlink, null)); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objHyperlink.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objHyperlink, null); }
        }

        /// <summary>返回或设置指定超链接的电子邮件主题行的文本字符串。主题行是添加到超链接地址上的。String 类型，可读写。
        /// </summary>
        public string EmailSubject
        {
            get { return _objHyperlink.GetType().InvokeMember("EmailSubject", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
            set { _objHyperlink.GetType().InvokeMember("EmailSubject", BindingFlags.SetProperty, null, _objHyperlink, new object[1] { value }); }
        }

        /// <summary>返回一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name
        {
            get { return _objHyperlink.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objHyperlink.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objHyperlink, null); }
        }

        /// <summary>返回一个 Range 对象，它代表附加的指定超链接的区域。
        /// </summary>
        public Range Range
        {
            get { return new Range(_objHyperlink.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, _objHyperlink, null)); }
        }

        /// <summary>返回或设置指定超链接的屏幕提示文字。String 类型，可读写。
        /// </summary>
        public string ScreenTip
        {
            get { return _objHyperlink.GetType().InvokeMember("ScreenTip", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
            set { _objHyperlink.GetType().InvokeMember("ScreenTip", BindingFlags.SetProperty, null, _objHyperlink, new object[1] { value }); }
        }

        /// <summary>返回一个 Shape 对象，它代表附加到指定超链接的形状。
        /// </summary>
        public Shape Shape
        {
            get { return new Shape(_objHyperlink.GetType().InvokeMember("Shape", BindingFlags.GetProperty, null, _objHyperlink, null)); }
        }

        /// <summary>返回或设置文档中与指定超链接相关联的位置。String 类型，可读写。
        /// </summary>
        public string SubAddress
        {
            get { return _objHyperlink.GetType().InvokeMember("SubAddress", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
            set { _objHyperlink.GetType().InvokeMember("SubAddress", BindingFlags.SetProperty, null, _objHyperlink, new object[1] { value }); }
        }

        /// <summary>返回或设置要为指定超链接显示的文本。默认值为超链接的地址。String 类型，可读写。
        /// </summary>
        public string TextToDisplay
        {
            get { return _objHyperlink.GetType().InvokeMember("TextToDisplay", BindingFlags.GetProperty, null, _objHyperlink, null).ToString(); }
            set { _objHyperlink.GetType().InvokeMember("TextToDisplay", BindingFlags.SetProperty, null, _objHyperlink, new object[1] { value }); }
        }

        /// <summary>返回一个包含 MsoHyperlinkType 常量的 Long 值，它代表 HTML 框架的位置。
        /// </summary>
        public int Type
        {
            get { return (int)_objHyperlink.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objHyperlink, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>将工作簿或超链接的快捷方式添加到“收藏夹”文件夹。
        /// </summary>
        public void AddToFavorites()
        {
            _objHyperlink.GetType().InvokeMember("AddToFavorites", BindingFlags.InvokeMethod, null, _objHyperlink, null);
        }

        /// <summary>新建一篇链接到指定超链接的文档。
        /// </summary>
        /// <param name="Filename">指定文档的文件名。</param>
        /// <param name="EditNow">如果该值为 True，则立即在关联的编辑环境中打开指定文档。默认值为 True。</param>
        /// <param name="Overwrite">如果该值为 True，则覆盖相同文件夹中任何现有的同名文件。如果该值为 False，则保留任何现有的同名文件，并且参数 Filename 将指定一个新的文件名。默认值为 False。</param>
        public void CreateNewDocument(string Filename, bool EditNow, bool Overwrite)
        {
            _objaParameters = new object[3] { Filename, EditNow, Overwrite };
            _objHyperlink.GetType().InvokeMember("CreateNewDocument", BindingFlags.InvokeMethod, null, _objHyperlink, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objHyperlink.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objHyperlink, null);
        }

        /// <summary>如果已经下载指定文档，则显示缓冲区中的该文档。否则，本方法对指定超链接进行处理以下载目标文档，然后将该文档在适当的应用程序中显示出来。
        /// </summary>
        /// <param name="NewWindow">如果为 True，则在新窗口中显示目标应用程序。默认值为 False。</param>
        /// <param name="AddHistory">未使用。保留供将来使用。</param>
        /// <param name="ExtraInfo">指定解析超链接时要使用的 HTTP 附加信息的 String 或字节数组。例如，可以使用 ExtraInfo 指定图像的坐标、窗体的内容或 FAT 文件名。</param>
        /// <param name="Method">指定附加 ExtraInfo 的方法。可以是下列 MsoExtraInfoMethod 常量之一。</param>
        /// <param name="HeaderInfo">指定 HTTP 请求的标题信息的 String。默认值为空字符串。</param>
        public void Follow(bool? NewWindow = null, object AddHistory = null, string ExtraInfo = null, MsoExtraInfoMethod? Method = null, string HeaderInfo = null)
        {
            _objaParameters = new object[5] {
                NewWindow == null ? System.Type.Missing : NewWindow,
                AddHistory == null ? System.Type.Missing : AddHistory,
                ExtraInfo == null ? System.Type.Missing : ExtraInfo,
                Method == null ? System.Type.Missing : Method,
                HeaderInfo == null ? System.Type.Missing : HeaderInfo
            };

            _objHyperlink.GetType().InvokeMember("Follow", BindingFlags.InvokeMethod, null, _objHyperlink, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>代表线条和箭头格式。
    /// 说明：
    /// 对于线条，LineFormat 对象包含该线条自身的格式信息；对于有边界的形状，该对象包含形状的边界的格式信息。
    /// </summary>
    public class LineFormat
    {
        public object _objLineFormat;

        public LineFormat(object objLineFormat)
        { _objLineFormat = objLineFormat; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objLineFormat.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objLineFormat, null)); }
        }

        /// <summary>返回或设置一个 ColorFormat 对象，它代表指定的填充背景色。
        /// </summary>
        public ColorFormat BackColor
        {
            get { return new ColorFormat(_objLineFormat.GetType().InvokeMember("BackColor", BindingFlags.GetProperty, null, _objLineFormat, null)); }
            set { _objLineFormat.GetType().InvokeMember("BackColor", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条起点的箭头的长度。MsoArrowheadLength 类型，可读写。
        /// </summary>
        public MsoArrowheadLength BeginArrowheadLength
        {
            get { return (MsoArrowheadLength)_objLineFormat.GetType().InvokeMember("BeginArrowheadLength", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("BeginArrowheadLength", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条起点的箭头样式。MsoArrowheadStyle 类型，可读写。
        /// </summary>
        public MsoArrowheadStyle BeginArrowheadStyle
        {
            get { return (MsoArrowheadStyle)_objLineFormat.GetType().InvokeMember("BeginArrowheadStyle", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("BeginArrowheadStyle", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条起点的箭头宽度。MsoArrowheadWidth 类型，可读写。
        /// </summary>
        public MsoArrowheadWidth BeginArrowheadWidth
        {
            get { return (MsoArrowheadWidth)_objLineFormat.GetType().InvokeMember("BeginArrowheadWidth", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("BeginArrowheadWidth", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// </summary>
        public int Creator
        {
            get { return (int)_objLineFormat.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objLineFormat, null); }
        }

        /// <summary>返回或设置指定直线的虚线样式。可以是 MsoLineDashStyle 常量之一。可读/写 Long 类型。
        /// </summary>
        public MsoLineDashStyle DashStyle
        {
            get { return (MsoLineDashStyle)_objLineFormat.GetType().InvokeMember("DashStyle", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("DashStyle", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条末尾的箭头的长度。MsoArrowheadLength 类型，可读写。
        /// </summary>
        public MsoArrowheadLength EndArrowheadLength
        {
            get { return (MsoArrowheadLength)_objLineFormat.GetType().InvokeMember("EndArrowheadLength", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("EndArrowheadLength", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条端点的箭头样式。MsoArrowheadStyle 类型，可读写。
        /// </summary>
        public MsoArrowheadStyle EndArrowheadStyle
        {
            get { return (MsoArrowheadStyle)_objLineFormat.GetType().InvokeMember("EndArrowheadStyle", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("EndArrowheadStyle", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定线条端点的箭头的宽度。MsoArrowheadWidth 类型，可读写。
        /// </summary>
        public MsoArrowheadWidth EndArrowheadWidth
        {
            get { return (MsoArrowheadWidth)_objLineFormat.GetType().InvokeMember("EndArrowheadWidth", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("EndArrowheadWidth", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 ColorFormat 对象，它代表指定的前景填充色或纯色。
        /// </summary>
        public ColorFormat ForeColor
        {
            get { return new ColorFormat(_objLineFormat.GetType().InvokeMember("ForeColor", BindingFlags.GetProperty, null, _objLineFormat, null)); }
            set { _objLineFormat.GetType().InvokeMember("ForeColor", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objLineFormat.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objLineFormat, null); }
        }

        /// <summary>返回或设置一个代表填充图案的 MsoPatternType 值。
        /// </summary>
        public MsoPatternType Pattern
        {
            get { return (MsoPatternType)_objLineFormat.GetType().InvokeMember("Pattern", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("Pattern", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 MsoLineStyle 值，它代表线条的样式。
        /// </summary>
        public MsoLineStyle Style
        {
            get { return (MsoLineStyle)_objLineFormat.GetType().InvokeMember("Style", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("Style", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置指定填充的透明度，取值范围为 0.0（不透明）到 1.0（清晰）之间。Double 型，可读写。
        /// </summary>
        public float Transparency
        {
            get { return (float)_objLineFormat.GetType().InvokeMember("Transparency", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("Transparency", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 MsoTriState 值，它确定对象是否可见。可读写。
        /// </summary>
        public MsoTriState Visible
        {
            get { return (MsoTriState)_objLineFormat.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single 值，它代表线条的粗细。
        /// </summary>
        public float Weight
        {
            get { return (float)_objLineFormat.GetType().InvokeMember("Weight", BindingFlags.GetProperty, null, _objLineFormat, null); }
            set { _objLineFormat.GetType().InvokeMember("Weight", BindingFlags.SetProperty, null, _objLineFormat, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>包含链接 OLE 对象的属性。
    /// 说明：
    /// 如果指定 Shape 对象不代表一个链接对象，则 LinkFormat 属性会失败。
    /// </summary>
    public class LinkFormat
    {
        public object _objLinkFormat;

        public LinkFormat(object objLinkFormat)
        { _objLinkFormat = objLinkFormat; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objLinkFormat.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objLinkFormat, null)); }
        }

        /// <summary>如果源更改时 LinkFormat 对象自动进行更新，则此属性为 True。Boolean 类型，只读。
        /// </summary>
        public bool AutoUpdate
        {
            get { return (bool)_objLinkFormat.GetType().InvokeMember("AutoUpdate", BindingFlags.GetProperty, null, _objLinkFormat, null); }
            set { _objLinkFormat.GetType().InvokeMember("AutoUpdate", BindingFlags.SetProperty, null, _objLinkFormat, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objLinkFormat.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objLinkFormat, null); }
        }

        /// <summary>返回或设置一个 Boolean 值，它指明对象是否已被锁定。
        /// </summary>
        public bool Locked
        {
            get { return (bool)_objLinkFormat.GetType().InvokeMember("Locked", BindingFlags.GetProperty, null, _objLinkFormat, null); }
            set { _objLinkFormat.GetType().InvokeMember("Locked", BindingFlags.SetProperty, null, _objLinkFormat, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objLinkFormat.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objLinkFormat, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>更新链接。
        /// </summary>
        public void Update()
        {
            _objLinkFormat.GetType().InvokeMember("Update", BindingFlags.InvokeMethod, null, _objLinkFormat, null);
        }
        #endregion 函数
    }

    /// <summary>指定的任意多边形中所有 ShapeNode 对象的集合。
    /// 说明：
    /// 每一个 ShapeNode 对象都代表任意多边形中线段间的结点或任意多边形曲线段的控点。您可以手动创建或通过使用 BuildFreeform 和 ConvertToShape 方法来创建任意多边形。
    /// </summary>
    public class ShapeNodes
    {
        public object _objShapeNodes;
        internal object[] _objaParameters;

        public ShapeNodes(object objShapeNodes)
        { _objShapeNodes = objShapeNodes; }

        public ShapeNode this[object Index]
        {
            get
            {
                object objShapeNode = _objShapeNodes.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objShapeNodes, new object[1] { Index });

                if (objShapeNode == null)
                    return null;
                else
                    return new ShapeNode(objShapeNode);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objShapeNodes.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objShapeNodes, null)); }
        }

        /// <summary>返回一个 Integer 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objShapeNodes.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objShapeNodes, null); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// </summary>
        public int Creator
        {
            get { return (int)_objShapeNodes.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objShapeNodes, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objShapeNodes.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objShapeNodes, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>删除对象。
        /// </summary>
        public void Delete(int Index)
        {
            _objaParameters = new object[1] { Index };
            _objShapeNodes.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters);
        }

        /// <summary>在任意多边形形状中插入节点。
        /// </summary>
        /// <param name="Index">Long 型。形状节点的编号，将在该节点后插入新节点。</param>
        /// <param name="SegmentType">线段类型。</param>
        /// <param name="EditingType">编辑的类型。</param>
        /// <param name="X1">如果新线段的 EditingType 为 msoEditingAuto，那么此参数就以磅为单位指定文档的左上角与新线段的终点之间的水平距离。如果新节点的 EditingType 为 msoEditingCorner，那么此参数就以磅为单位指定文档的左上角与新线段的第一个控制点之间的水平距离。</param>
        /// <param name="Y1">如果新线段的 EditingType 为 msoEditingAuto，则此参数就以磅为单位指定从文档左上角到新线段终点的垂直距离。如果新节点的 EditingType 属性为 msoEditingCorner，则此参数就以磅为单位指定从文档左上角到新线段第一个控制点的垂直距离。</param>
        /// <param name="X2">如果新线段的 EditingType 属性为 msoEditingCorner，则此参数就以磅为单位指定从文档左上角到新线段第二个控制点的水平距离。如果新线段的 EditingType 为 msoEditingAuto，则不用为此参数指定值。</param>
        /// <param name="Y2">如果新线段的 EditingType 为 msoEditingCorner，则此参数就以磅为单位指定从文档左上角到新线段第二个控制点的垂直距离。如果新线段的 EditingType 为 msoEditingAuto，则不用为此参数指定值。</param>
        /// <param name="X3">如果新线段的 EditingType 为 msoEditingCorner，则此参数就以磅为单位指定从文档的左上角到新线段终点之间的水平距离。如果新线段的 EditingType 为 msoEditingAuto，则不用为此参数指定值。</param>
        /// <param name="Y3">如果新线段的 EditingType 为 msoEditingCorner，则此参数就以磅为单位指定从文档左上角到新线段终点的垂直距离。如果新线段的 EditingType 为 msoEditingAuto，则不用为此参数指定值。</param>
        public void Insert(int Index, MsoSegmentType SegmentType, MsoEditingType EditingType, float X1, float Y1, float X2 = 0f, float Y2 = 0f, float X3 = 0f, float Y3 = 0f)
        {
            _objaParameters = new object[9] { Index, SegmentType, EditingType, X1, Y1, X2, Y2, X3, Y3 };
            _objShapeNodes.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters);
        }

        /// <summary>从集合中返回一个对象。
        /// </summary>
        /// <param name="Index">对象的名称或索引号。</param>
        public ShapeNode Get_Item(object Index)
        {
            _objaParameters = new object[1] { Index };
            return new ShapeNode(_objShapeNodes.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters));
        }

        /// <summary>设置由 Index 指定的结点的编辑类型。如果该结点是一个曲线的控制点，本方法将对其设置相邻结点的编辑属性，该属性连接两个段。请注意，由于编辑类型的不同，本方法可能影响相邻结点的位置。
        /// </summary>
        /// <param name="Index">需要设置编辑类型的顶点。</param>
        /// <param name="EditingType">顶点的编辑属性。</param>
        public void SetEditingType(int Index, MsoEditingType EditingType)
        {
            _objaParameters = new object[2] { Index, EditingType };
            _objShapeNodes.GetType().InvokeMember("SetEditingType", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters);
        }

        /// <summary>设置由 Index 指定的顶点位置。注意：由于顶点的编辑类型不同，此方法可能影响相邻顶点的位置。
        /// </summary>
        /// <param name="Index">要设置位置的顶点。</param>
        /// <param name="X1">新顶点相对于文档左上角的位置（以磅为单位）。</param>
        /// <param name="Y1">新顶点相对于文档左上角的位置（以磅为单位）。</param>
        public void SetPosition(int Index, float X1, float Y1)
        {
            _objaParameters = new object[3] { Index, X1, Y1 };
            _objShapeNodes.GetType().InvokeMember("SetPosition", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters);
        }

        /// <summary>设置 Index 指定的结点后面的段的段类型。如果该结点为一条曲线段的控制点，则该方法设置该曲线的段类型。请注意，该方法可能由于插入或删除相邻的结点而影响结点总数。
        /// </summary>
        /// <param name="Index">要设置段类型的顶点。</param>
        /// <param name="SegmentType">指定是直线段还是曲线段。</param>
        public void SetSegmentType(int Index, MsoSegmentType SegmentType)
        {
            _objaParameters = new object[2] { Index, SegmentType };
            _objShapeNodes.GetType().InvokeMember("SetSegmentType", BindingFlags.InvokeMethod, null, _objShapeNodes, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>该对象代表一个用户自定义任意多边形顶点的几何特征及其编辑属性。
    /// 说明：
    /// 结点包括任意多边形线段间的顶点以及曲线段的控点。ShapeNode 对象是 ShapeNodes 集合的成员。ShapeNodes 集合包括某个任意多边形中所有的结点。
    /// </summary>
    public class ShapeNode
    {
        public object _objShapeNode;

        public ShapeNode(object objShapeNode)
        { _objShapeNode = objShapeNode; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objShapeNode.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objShapeNode, null)); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// </summary>
        public int Creator
        {
            get { return (int)_objShapeNode.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objShapeNode, null); }
        }

        /// <summary>如果指定的节点为顶点，则该属性返回一个值，该值表示对节点所做的更改将如何影响与该节点相连的两个线段。MsoEditingType 类型，只读。
        /// </summary>
        public MsoEditingType EditingType
        {
            get { return (MsoEditingType)_objShapeNode.GetType().InvokeMember("EditingType", BindingFlags.GetProperty, null, _objShapeNode, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objShapeNode.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objShapeNode, null); }
        }

        /// <summary>以坐标对形式返回指定节点的位置。每个坐标都以磅为单位。只读 Variant 类型。
        /// </summary>
        public dynamic Points
        {
            get { return _objShapeNode.GetType().InvokeMember("Points", BindingFlags.GetProperty, null, _objShapeNode, null); }
        }

        /// <summary>返回一个值，该值表示与指定的节点相关联的线段是直线还是曲线。如果指定的节点是曲线段上的控制点，则该属性返回 msoSegmentCurve。MsoSegmentType 类型，只读。
        /// </summary>
        public MsoSegmentType SegmentType
        {
            get { return (MsoSegmentType)_objShapeNode.GetType().InvokeMember("SegmentType", BindingFlags.GetProperty, null, _objShapeNode, null); }
        }
        #endregion 属性
    }

    /// <summary>指定的或活动工作簿中所有工作表的集合。
    /// 说明：
    /// Sheets 集合可以包含 Chart 或 Worksheet 对象。
    /// 如果希望返回所有类型的工作表，Sheets 集合就非常有用。如果仅需使用某一类型的工作表，请参阅该工作表类型的对象主题。
    /// </summary>
    public class Sheets
    {
        public object _objSheets;
        internal object[] _objaParameters;

        public Sheets(object objSheets)
        { _objSheets = objSheets; }

        public dynamic this[object Index]
        {
            get { return _objSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objSheets, new object[1] { Index }); }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objSheets.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objSheets, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objSheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objSheets, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objSheets.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objSheets, null); }
        }

        /// <summary>返回一个 HPageBreaks 集合，它代表工作表上的水平分页符。只读。
        /// </summary>
        public HPageBreaks HPageBreaks
        {
            get { return new HPageBreaks(_objSheets.GetType().InvokeMember("HPageBreaks", BindingFlags.GetProperty, null, _objSheets, null)); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objSheets.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objSheets, null); }
        }

        /// <summary>返回或设置一个 Variant 值，它确定对象是否可见。
        /// </summary>
        public bool? Visible
        {
            get { return (bool)_objSheets.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objSheets, null); }
            set { _objSheets.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objSheets, new object[1] { value }); }
        }

        /// <summary>返回一个 VPageBreaks 集合，它代表工作表上的垂直分页符。只读。
        /// </summary>
        public VPageBreaks VPageBreaks
        {
            get { return new VPageBreaks(_objSheets.GetType().InvokeMember("VPageBreaks", BindingFlags.GetProperty, null, _objSheets, null)); }
        }
        #endregion 属性

        #region 函数
        /// <summary>把当前对象作为 Worksheets 来处理
        /// </summary>
        /// <returns></returns>
        public Worksheets get_Worksheets()
        {
            return new Worksheets(_objSheets);
        }

        /// <summary>把当前对象作为 Charts 来处理
        /// </summary>
        /// <returns></returns>
        public Charts get_Charts()
        {
            return new Charts(_objSheets);
        }

        /// <summary>新建工作表、图表或宏表。新建的工作表将成为活动工作表。
        /// </summary>
        /// <param name="Before">指定工作表的对象，新建的工作表将置于此工作表之前。</param>
        /// <param name="After">指定工作表的对象，新建的工作表将置于此工作表之后。</param>
        /// <param name="Count">要添加的工作表数。默认值为 1。</param>
        /// <param name="Type">指定工作表类型。可以为下列 XlSheetType 常量之一：xlWorksheet、xlChart、xlExcel4MacroSheet 或 xlExcel4IntlMacroSheet。如果基于现有模板插入工作表，则指定该模板的路径。默认值为 xlWorksheet。</param>
        public dynamic Add(Worksheet Before = null, Worksheet After = null, int? Count = null, XlSheetType? Type = null)
        {
            _objaParameters = new object[4] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet,
                Count == null ? System.Type.Missing : Count,
                Type == null ? System.Type.Missing : Type
            };

            return _objSheets.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>将工作表复制到工作簿的另一位置。
        /// </summary>
        /// <param name="Before">将要在其之前放置所复制工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">将要在其之后放置所复制工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Copy(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objSheets.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objSheets.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objSheets, null);
        }

        /// <summary>将单元格区域复制到集合中所有其他工作表的同一位置。
        /// </summary>
        /// <param name="Range">要填充到集合中所有工作表上的单元格区域。该区域必须来自集合中的某个工作表。</param>
        /// <param name="Type">指定如何复制区域。</param>
        public void FillAcrossSheets(Range Range, XlFillWith Type = XlFillWith.xlFillWithAll)
        {
            _objaParameters = new object[2] { Range, Type };
            _objSheets.GetType().InvokeMember("FillAcrossSheets", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>将工作表移到工作簿中的其他位置。
        /// </summary>
        /// <param name="Before">在其之前放置移动工作表的工作表。如果指定了 After，则不能指定 Before。</param>
        /// <param name="After">在其之后放置移动工作表的工作表。如果指定了 Before，则不能指定 After。</param>
        public void Move(Worksheet Before = null, Worksheet After = null)
        {
            _objaParameters = new object[2] {
                Before == null ? System.Type.Missing : Before._objWorksheet,
                After == null ? System.Type.Missing : After._objWorksheet
            };

            _objSheets.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>打印对象。
        /// 说明：
        /// From 和 To 所描述的“页”指的是要打印的页，并非指定工作表或工作簿中的全部页。
        /// </summary>
        /// <param name="From">打印的开始页号。如果省略此参数，则从起始位置开始打印。</param>
        /// <param name="To">打印的终止页号。如果省略此参数，则打印至最后一页。</param>
        /// <param name="Copies">打印份数。如果省略此参数，则只打印一份。</param>
        /// <param name="Preview">如果为 True，Microsoft Excel 将在打印对象之前调用打印预览。如果为 False（或省略该参数），则立即打印对象。</param>
        /// <param name="ActivePrinter">设置活动打印机的名称。</param>
        /// <param name="PrintToFile">如果为 True，则打印到文件。如果没有指定 PrToFileName，Microsoft Excel 将提示用户输入要使用的输出文件的文件名。</param>
        /// <param name="Collate">如果为 True，则逐份打印多个副本。</param>
        /// <param name="PrToFileName">如果 PrintToFile 设为 True，则该参数指定要打印到的文件名。</param>
        /// <param name="IgnorePrintAreas">如果为 True，则忽略打印区域并打印整个对象。</param>
        public void PrintOut(int? From = null, int? To = null, int? Copies = null, bool? Preview = null, string ActivePrinter = null, bool? PrintToFile = null, bool? Collate = null, bool? PrToFileName = null)
        {
            _objaParameters = new object[8] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName
            };

            _objSheets.GetType().InvokeMember("PrintOut", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>
        /// </summary>
        public void PrintOutEx(object From = null, object To = null, object Copies = null, object Preview = null, object ActivePrinter = null, object PrintToFile = null, object Collate = null, object PrToFileName = null, object IgnorePrintAreas = null)
        {
            _objaParameters = new object[9] {
                From == null ? System.Type.Missing : From,
                To == null ? System.Type.Missing : To,
                Copies == null ? System.Type.Missing : Copies,
                Preview == null ? System.Type.Missing : Preview,
                ActivePrinter == null ? System.Type.Missing : ActivePrinter,
                PrintToFile == null ? System.Type.Missing : PrintToFile,
                Collate == null ? System.Type.Missing : Collate,
                PrToFileName == null ? System.Type.Missing : PrToFileName,
                IgnorePrintAreas == null ? System.Type.Missing : IgnorePrintAreas
            };

            _objSheets.GetType().InvokeMember("PrintOutEx", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>按对象打印后的外观效果显示对象的预览。
        /// </summary>
        /// <param name="EnableChanges">传递 Boolean 值，以指定用户是否可更改边距和打印预览中可用的其他页面设置选项。</param>
        public void PrintPreview(bool? EnableChanges = null)
        {
            _objaParameters = new object[1] { EnableChanges == null ? System.Type.Missing : EnableChanges };
            _objSheets.GetType().InvokeMember("PrintPreview", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }

        /// <summary>选择对象。
        /// </summary>
        /// <param name="Replace">（仅用于工作表）。如果为 True，则用指定的对象替换当前所选内容。如果为 False，则扩展当前所选内容以包括以前选择的对象和指定的对象。</param>
        public void Select(bool? Replace = null)
        {
            _objaParameters = new object[1] { Replace == null ? System.Type.Missing : Replace };
            _objSheets.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, _objSheets, _objaParameters);
        }
        #endregion 函数
    }

    /// <summary>由选定区域内的多个子区域或连续单元格块组成的集合。 
    /// 说明：
    /// 没有单独的 Area 对象；Areas 集合内的各个成员是 Range 对象。在 Areas 集合中，选定区域内每个离散的连续单元格区域都有一个 Range 对象。如果选定区域内只有一个子区域，则 Areas 集合包含一个与该选定区域对应的 Range 对象。
    /// </summary>
    public class Areas
    {
        public object _objAreas;

        internal Areas(object objAreas)
        { _objAreas = objAreas; }

        public Range this[int Index]
        {
            get
            {
                return new Range(_objAreas.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objAreas, new object[1] { Index }));
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objAreas.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objAreas, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objAreas.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objAreas, null); }
        }

        /// <summary>
        /// </summary>
        public XlCreator Creator
        {
            get { return (XlCreator)_objAreas.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objAreas, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objAreas.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objAreas, null); }
        }
        #endregion 属性
    }

    /// <summary>代表单元格区域的定义名。名称可以是内置名称（如“Database”、“Print_Area”和“Auto_Open”）或自定义名称。
    /// 说明
    /// 应用程序、工作簿和 Worksheet 对象
    /// Name 对象是 Application、Workbook 和 Worksheet 对象的 Names 集合的成员。使用 Names(index)（其中 index 是名称索引号或定义名称）可返回一个 Name 对象。
    /// 索引号表明名称在集合中的位置。名称按字母顺序从 a 到 z 放置，不区分大小写。
    /// Range 对象 
    /// 虽然 Range 对象可以有多个名称，但 Range 对象没有 Names 集合。将 Name 与一个 Range 对象一起使用可从名称列表（按字母顺序排序）中返回第一个名称。下例为指定给工作表一上单元格 A1:B1 的第一个名称设置 Visible 属性。
    /// </summary>
    public class Name
    {
        public object _objName;

        public Name(object objName)
        { _objName = objName; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objName.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objName, null)); }
        }

        /// <summary>返回或设置指定名称在宏语言中的分类。该名称必须针对一个自定义函数或命令。String 类型，可读写。
        /// </summary>
        public string Category
        {
            get { return _objName.GetType().InvokeMember("Category", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("Category", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>如果指定名称为自定义函数或命令，返回或设置以用户语言表示名称的类别。String 类型，可读写。
        /// </summary>
        public string CategoryLocal
        {
            get { return _objName.GetType().InvokeMember("CategoryLocal", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("CategoryLocal", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置与名称关联的批注。可读/写 String 类型。
        /// </summary>
        public string Comment
        {
            get { return _objName.GetType().InvokeMember("Comment", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("Comment", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回 Long 值，它代表对象在其同类对象所组成的集合内的索引号。
        /// </summary>
        public int Index
        {
            get { return (int)_objName.GetType().InvokeMember("Index", BindingFlags.GetProperty, null, _objName, null); }
        }

        /// <summary>返回或设置名称所引用的对象。XlXLMMacroType 类型，可读写。
        /// </summary>
        public XlXLMMacroType MacroType
        {
            get { return (XlXLMMacroType)_objName.GetType().InvokeMember("MacroType", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("MacroType", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 String 值，它代表对象的名称。
        /// </summary>
        public string Name1
        {
            get { return _objName.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>以用户语言返回或设置对象的名称。String 型，可读写。
        /// </summary>
        public string NameLocal
        {
            get { return _objName.GetType().InvokeMember("NameLocal", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("NameLocal", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objName.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objName, null); }
        }

        /// <summary>用宏语言以 A1 样式表示法返回或设置名称所引用的公式（以等号开头）。String 类型，可读写。
        /// </summary>
        public dynamic RefersTo
        {
            get { return _objName.GetType().InvokeMember("RefersTo", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("RefersTo", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置指定名称所引用的公式。公式以等号开头，由用户语言和 A1-样式引用组成。String 类型，可读写。
        /// </summary>
        public dynamic RefersToLocal
        {
            get { return _objName.GetType().InvokeMember("RefersToLocal", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("RefersToLocal", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置指定名称所引用的公式。公式以等号开头，由宏语言和 R1C1-样式引用组成。String 类型，可读写。
        /// </summary>
        public dynamic RefersToR1C1
        {
            get { return _objName.GetType().InvokeMember("RefersToR1C1", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("RefersToR1C1", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置指定名称所引用的公式。公式以等号开头，由用户语言和 R1C1-样式引用组成。可读/写 String 类型。
        /// </summary>
        public dynamic RefersToR1C1Local
        {
            get { return _objName.GetType().InvokeMember("RefersToR1C1Local", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("RefersToR1C1Local", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回由 Name 对象引用的 Range 对象。只读。
        /// </summary>
        public Range RefersToRange
        {
            get { return new Range(_objName.GetType().InvokeMember("RefersToRange", BindingFlags.GetProperty, null, _objName, null)); }
        }

        /// <summary>返回或设置定义为自定义 Microsoft Excel 4.0 宏命令的名称的快捷键。String 类型，可读写。
        /// </summary>
        public string ShortcutKey
        {
            get { return _objName.GetType().InvokeMember("ShortcutKey", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("ShortcutKey", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>如果指定的 Name 对象是有效的工作簿参数，则返回 True。只读 Boolen 类型。
        /// </summary>
        public bool ValidWorkbookParameter
        {
            get { return (bool)_objName.GetType().InvokeMember("ValidWorkbookParameter", BindingFlags.GetProperty, null, _objName, null); }
        }

        /// <summary>返回或设置一个 String 值，它代表规定名称去引用的公式。
        /// </summary>
        public string Value
        {
            get { return _objName.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, _objName, null).ToString(); }
            set { _objName.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Boolean 值，它确定对象是否可见。可读写。
        /// </summary>
        public bool Visible
        {
            get { return (bool)_objName.GetType().InvokeMember("Visible", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }

        /// <summary>
        /// </summary>
        public bool WorkbookParameter
        {
            get { return (bool)_objName.GetType().InvokeMember("WorkbookParameter", BindingFlags.GetProperty, null, _objName, null); }
            set { _objName.GetType().InvokeMember("WorkbookParameter", BindingFlags.SetProperty, null, _objName, new object[1] { value }); }
        }
        #endregion 属性

        #region 函数
        /// <summary>删除对象。
        /// </summary>
        public void Delete()
        {
            _objName.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, _objName, null);
        }
        #endregion 函数
    }

    /// <summary>应用程序或工作簿中所有 Name 对象的集合。
    /// 说明
    /// 每一个 Name 对象都代表一个单元格区域的定义名称。名称可以是内置名称（如“Database”、“Print_Area”和“Auto_Open”）或自定义名称。
    /// RefersTo 参数必须以 A1 样式表示法指定，包括必要时使用的美元符 ($)。例如，如果在 Sheet1 上选定了单元格 A10，并且通过将 RefersTo 参数“=Sheet1!A1:B1”而定义了一个名称，那么该新名称实际上指向单元格区域 A10:B10（因为指定的是相对引用）。若要指定绝对引用，请使用“=Sheet1!$A$1:$B$1”。
    /// </summary>
    public class Names
    {
        internal object _objNames;
        internal object[] _objaParameters;

        internal Names(object objNames)
        { _objNames = objNames; }

        /// <summary>从 Names 集合返回一个 Name 对象。
        /// </summary>
        /// <param name="Index">要返回的定义名称的名称或编号。</param>
        /// <param name="IndexLocal">以用户语言表示的定义名称的名称。如果使用该参数，将不转换名称。</param>
        /// <param name="RefersTo">名称引用的内容。使用该参数以引用的内容标识名称。</param>
        /// <returns></returns>
        public Name this[object Index = null, object IndexLocal = null, object RefersTo = null]
        {
            get
            {
                _objaParameters = new object[3] {
                        Index == null ? System.Type.Missing : Index,
                        IndexLocal == null ? System.Type.Missing : IndexLocal,
                        RefersTo == null ? System.Type.Missing : RefersTo
                    };

                object objName = _objNames.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, _objNames, _objaParameters);

                if (objName == null)
                    return null;
                else
                    return new Name(objName);
            }
        }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public Application Application
        {
            get { return new Application(_objNames.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objNames, null)); }
        }

        /// <summary>返回一个 Long 值，它代表集合中对象的数量。
        /// </summary>
        public int Count
        {
            get { return (int)_objNames.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, _objNames, null); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public dynamic Parent
        {
            get { return _objNames.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objNames, null); }
        }
        #endregion 属性

        #region 函数
        /// <summary>定义新名称。
        /// </summary>
        /// <param name="Name">如果没有指定 NameLocal，则为用作名称的文本（以宏语言表示）。名称不能包括空格，不能与单元格引用相似。</param>
        /// <param name="RefersTo">除非指定了其他 RefersTo 参数，否则该参数说明名称引用的内容（使用 A1 格式表示法以宏语言表示）。注释：如果引用不存在，则返回 Nothing。</param>
        /// <param name="Visible">如果为 True，则用常规方式定义名称。如果为 False，则将名称定义为隐藏名称（即该名称在“定义名称”、“粘贴名称”或“定位”对话框中都不出现）。默认值是 True。</param>
        /// <param name="MacroType">由以下值之一确定的宏类型：
        /// 1 — 用户定义函数（Function 过程）
        /// 2 — 宏（也称为子过程）
        /// 3 — 无（忽略该参数，即该名称不引用用户定义函数或宏）
        /// </param>
        /// <param name="ShortcutKey">宏的快捷键。必须是单个字母，例如“z”或“Z”。只用于命令宏。</param>
        /// <param name="Category">如果 MacroType 为 1 或 2，则该参数为宏或函数的分类。该分类在“函数向导”中使用。可以用数字（从 1 开始）或名称（以宏语言指定）引用现有的分类。如果指定的分类不存在，Microsoft Excel 将创建新分类。</param>
        /// <param name="NameLocal">如果没有指定 Name，则为用作名称的文本（以用户语言表示）。名称不能包括空格，不能与单元格引用相似。</param>
        /// <param name="RefersToLocal">除非指定了其他 RefersTo 参数，否则该参数说明名称引用的内容（使用 A1 格式表示法以用户语言表示）。</param>
        /// <param name="CategoryLocal">如果未指定 Category，则为以用户语言标识自定义函数分类的文本。</param>
        /// <param name="RefersToR1C1">除非指定了其他 RefersTo 参数，否则该参数说明名称引用的内容（使用 R1C1 格式表示法以宏语言表示）。</param>
        /// <param name="RefersToR1C1Local">除非指定了其他 RefersTo 参数，否则该参数说明名称引用的内容（使用 R1C1 格式表示法以用户语言表示）。</param>
        /// <returns></returns>
        public Name Add(object Name = null, object RefersTo = null, object Visible = null, object MacroType = null, object ShortcutKey = null, object Category = null, object NameLocal = null, object RefersToLocal = null, object CategoryLocal = null, object RefersToR1C1 = null, object RefersToR1C1Local = null)
        {
            _objaParameters = new object[11] {
                Name == null ? System.Type.Missing : Name,
                RefersTo == null ? System.Type.Missing : RefersTo,
                Visible == null ? System.Type.Missing : Visible,
                MacroType == null ? System.Type.Missing : MacroType,
                ShortcutKey == null ? System.Type.Missing : ShortcutKey,
                Category == null ? System.Type.Missing : Category,
                NameLocal == null ? System.Type.Missing : NameLocal,
                RefersToLocal == null ? System.Type.Missing : RefersToLocal,
                CategoryLocal == null ? System.Type.Missing : CategoryLocal,
                RefersToR1C1 == null ? System.Type.Missing : RefersToR1C1,
                RefersToR1C1Local == null ? System.Type.Missing : RefersToR1C1Local
            };

            return new Name(_objNames.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, _objNames, _objaParameters));
        }
        #endregion 函数
    }    

    /**************以下为空类******************/

    /// <summary>包含 OLE 对象的属性。
    /// </summary>
    public class OLEFormat
    {
        public object _objOLEFormat;

        public OLEFormat(object objOLEFormat)
        { _objOLEFormat = objOLEFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含应用于图片和 OLE 对象的属性和方法。
    /// </summary>
    public class PictureFormat
    {
        public object _objPictureFormat;

        public PictureFormat(object objPictureFormat)
        { _objPictureFormat = objPictureFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表形状的阴影格式。
    /// </summary>
    public class ShadowFormat
    {
        public object _objShadowFormat;

        public ShadowFormat(object objShadowFormat)
        { _objShadowFormat = objShadowFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含应用于艺术字对象的属性和方法。
    /// </summary>
    public class TextEffectFormat
    {
        public object _objTextEffectFormat;

        public TextEffectFormat(object objTextEffectFormat)
        { _objTextEffectFormat = objTextEffectFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 Shape 对象中的文本框架。包含文本框架中的文本以及控制文本框架的对齐和定位的属性和方法。
    /// </summary>
    public class TextFrame
    {
        public object _objTextFrame;

        public TextFrame(object objTextFrame)
        { _objTextFrame = objTextFrame; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 Shape、ShapeRange 或 ChartFormat 对象的文本框。 
    /// </summary>
    public class TextFrame2
    {
        public object _objTextFrame2;

        public TextFrame2(object objTextFrame2)
        { _objTextFrame2 = objTextFrame2; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>该对象代表一个形状的三维格式。
    /// </summary>
    public class ThreeDFormat
    {
        public object _objThreeDFormat;

        public ThreeDFormat(object objThreeDFormat)
        { _objThreeDFormat = objThreeDFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含应用于行标注的属性和方法。
    /// </summary>
    public class CalloutFormat
    {
        public object _objCalloutFormat;

        public CalloutFormat(object objCalloutFormat)
        { _objCalloutFormat = objCalloutFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含应用于连接符的属性和方法。
    /// </summary>
    public class ConnectorFormat
    {
        public object _objConnectorFormat;

        public ConnectorFormat(object objConnectorFormat)
        { _objConnectorFormat = objConnectorFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含 Microsoft Excel 控件属性。
    /// </summary>
    public class ControlFormat
    {
        public object _objControlFormat;
        internal object[] _objaParameters;

        public ControlFormat(object objControlFormat)
        { _objControlFormat = objControlFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>一个 AddIn 对象的集合，这些对象代表 Microsoft Excel 可用的所有加载宏，不论它们是否已安装。
    /// </summary>
    public class AddIns
    {
        public object _objAddIns;
        internal object[] _objaParameters;

        public AddIns(object objAddIns)
        { _objAddIns = objAddIns; }

        public AddIn this[object Index]
        {
            get
            {
                object objAddIn = _objAddIns.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objAddIns, new object[1] { Index });

                if (objAddIn == null)
                    return null;
                else
                    return new AddIn(objAddIn);
            }
        }


        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表单个加载宏，不论该加载宏是否已加载。 
    /// </summary>
    public class AddIn
    {
        public object _objAddIn;
        internal object[] _objaParameters;

        public AddIn(object objAddIn)
        { _objAddIn = objAddIn; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 Microsoft Office 应用程序中的“应答向导”。每个应用程序只有一个“应答向导”，并且对 AnswerWizard 或 AnswerWizardFiles 集合所做的所有更改都将立刻影响活动的 Office 应用程序。
    /// </summary>
    public class AnswerWizard
    {
        public object _objAnswerWizard;
        internal object[] _objaParameters;

        public AnswerWizard(object objAnswerWizard)
        { _objAnswerWizard = objAnswerWizard; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>使开发人员能够在 Microsoft Office 内为用户创建自定义的帮助体验。
    /// </summary>
    public class IAssistance
    {
        public object _objIAssistance;
        internal object[] _objaParameters;

        public IAssistance(object objIAssistance)
        { _objIAssistance = objIAssistance; }

        #region 函数

        #endregion 函数
    }

    /// <summary>代表“Microsoft Office 助手”。
    /// </summary>
    public class Assistant
    {
        public object _objAssistant;
        internal object[] _objaParameters;

        public Assistant(object objAssistant)
        { _objAssistant = objAssistant; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含 Microsoft Excel 的 AutoCorrect 属性（自动将日期名改为大写、自动更正连续两个大写字母、自动更正词条列表等等）。
    /// </summary>
    public class AutoCorrect
    {
        public object _objAutoCorrect;
        internal object[] _objaParameters;

        public AutoCorrect(object objAutoCorrect)
        { _objAutoCorrect = objAutoCorrect; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作簿的自动恢复功能。 
    /// </summary>
    public class AutoRecover
    {
        public object _objAutoRecover;
        internal object[] _objaParameters;

        public AutoRecover(object objAutoRecover)
        { _objAutoRecover = objAutoRecover; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含应用程序级的全局属性，当将文档另存为网页或打开网页时，Microsoft Excel 将使用这些属性。您可以在应用程序（全局）级或在工作簿级返回或设置属性。
    /// 说明
    /// 工作簿级的属性设置会重写应用程序级的属性设置。工作簿级的属性设置包含在 WebOptions 对象中。
    /// </summary>
    public class DefaultWebOptions
    {
        public object _objDefaultWebOptions;
        internal object[] _objaParameters;

        public DefaultWebOptions(object objDefaultWebOptions)
        { _objDefaultWebOptions = objDefaultWebOptions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Excel 中所有 Dialog 对象的集合。
    /// 说明
    /// 每个 Dialog 对象代表一个内置对话框。不能在集合中新建或添加内置对话框。Dialog 对象只能在 Show 方法中用来显示相应的对话框。
    /// Microsoft Excel Visual Basic 对象库包含许多内置对话框的内置常量。每个常量的前缀均为“xlDialog”，随后即为对话框的名称。例如，“应用名称”对话框常量为 xlDialogApplyNames，“查找文件”对话框常量为 xlDialogFindFile。这些常量是 XlBuiltinDialog 枚举类型的成员。
    /// </summary>
    public class Dialogs
    {
        public object _objDialogs;
        internal object[] _objaParameters;

        public Dialogs(object objDialogs)
        { _objDialogs = objDialogs; }

        public Dialog this[object Index]
        {
            get
            {
                object objDialog = _objDialogs.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objDialogs, new object[1] { Index });

                if (objDialog == null)
                    return null;
                else
                    return new Dialog(objDialog);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表内置的 Microsoft Excel 对话框。
    /// 说明
    /// Dialog 对象是 Dialogs 集合的成员。Dialogs 集合包含 Microsoft Excel 中的所有内置对话框。不能在集合中新建或添加内置对话框。Dialog 对象只能在 Show 方法中用来显示相应的对话框。
    /// Microsoft Excel Visual Basic 对象库包含许多内置对话框的内置常量。每个常量的前缀均为“xlDialog”，随后即为对话框的名称。例如，“应用名称”对话框常量为 xlDialogApplyNames，“查找文件”对话框常量为 xlDialogFindFile。这些常量是 XlBuiltinDialog 枚举类型的成员。
    /// </summary>
    public class Dialog
    {
        public object _objDialog;
        internal object[] _objaParameters;

        public Dialog(object objDialog)
        { _objDialog = objDialog; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表应用程序的错误检查选项。
    /// 说明
    /// 使用 Application 对象的 ErrorCheckingOptions 属性可返回 ErrorCheckingOptions 对象。
    /// 引用 Errors 对象的 Item 属性可查看与错误检查选项关联的索引值列表。
    /// 返回 ErrorCheckingOptions 对象后，可使用以下属性设置或返回错误检查选项。这些属性都是 ErrorCheckingOptions 对象的成员。
    /// BackgroundChecking 
    /// EmptyCellReferences 
    /// EvaluateToError 
    /// InconsistentFormula 
    /// IndicatorColorIndex 
    /// NumberAsText 
    /// OmittedCells 
    /// TextDate 
    /// UnlockedFormulaCells 
    /// </summary>
    public class ErrorCheckingOptions
    {
        public object _objErrorCheckingOptions;
        internal object[] _objaParameters;

        public ErrorCheckingOptions(object objErrorCheckingOptions)
        { _objErrorCheckingOptions = objErrorCheckingOptions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表单元格格式的搜索条件。
    /// 说明
    /// 使用 Application 对象的 FindFormat 或 ReplaceFormat 属性可返回 CellFormat 对象。
    /// 使用 CellFormat 对象的 Borders 、Font 属性或 CellFormat 对象的 Interior 属性可定义单元格格式的搜索条件。 
    /// </summary>
    public class CellFormat
    {
        public object _objCellFormat;
        internal object[] _objaParameters;

        public CellFormat(object objCellFormat)
        { _objCellFormat = objCellFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>返回或设置并发计算模式。
    /// </summary>
    public class MultiThreadedCalculation
    {
        public object _objMultiThreadedCalculation;
        internal object[] _objaParameters;

        public MultiThreadedCalculation(object objMultiThreadedCalculation)
        { _objMultiThreadedCalculation = objMultiThreadedCalculation; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>ODBCError 对象的集合。
    /// 说明
    /// 每一个 ODBCError 对象都代表一个由最近的 ODBC 查询返回的错误。如果指定的 ODBC 查询运行时没有出现错误，则 ODBCErrors 集合为空。集合中错误的索引次序与 ODBC 数据源生成它们时的次序相同。您不能给该集合添加成员。
    /// </summary>
    public class ODBCErrors
    {
        public object _objODBCErrors;
        internal object[] _objaParameters;

        public ODBCErrors(object objODBCErrors)
        { _objODBCErrors = objODBCErrors; }

        public ODBCError this[object Index]
        {
            get
            {
                object objODBCError = _objODBCErrors.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objODBCErrors, new object[1] { Index });

                if (objODBCError == null)
                    return null;
                else
                    return new ODBCError(objODBCError);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一个由最近的 ODBC 查询生成的 ODBC 错误。
    /// 说明：
    /// ODBCError 对象是 ODBCErrors 集合的成员。如果指定的 ODBC 查询运行时没有出现错误，则 ODBCErrors 集合为空。集合中错误的索引次序与 ODBC 数据源生成它们时的次序相同。
    /// </summary>
    public class ODBCError
    {
        public object _objODBCError;
        internal object[] _objaParameters;

        internal ODBCError(object objODBCError)
        { _objODBCError = objODBCError; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>OLEDBError 对象的集合。
    /// 说明
    /// 每一个 OLEDBError 对象都代表最近的 OLE DB 查询返回的一个错误。如果指定的 OLE DB 查询运行时没有出现错误，则 OLEDBErrors 集合为空。集合中错误的索引次序与 OLE DB 提供程序生成它们时的次序相同。您不能给该集合添加成员。
    /// </summary>
    public class OLEDBErrors
    {
        public object _objOLEDBErrors;
        internal object[] _objaParameters;

        public OLEDBErrors(object objOLEDBErrors)
        { _objOLEDBErrors = objOLEDBErrors; }

        public OLEDBError this[object Index]
        {
            get
            {
                object objOLEDBError = _objOLEDBErrors.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objOLEDBErrors, new object[1] { Index });

                if (objOLEDBError == null)
                    return null;
                else
                    return new OLEDBError(objOLEDBError);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表由上一次 OLE DB 查询所返回的 OLE DB 错误。
    /// 说明：
    /// OLEDBError 对象是 OLEDBErrors 集合的成员。如果指定的 OLE DB 查询运行时没有出现错误，则 OLEDBErrors 集合为空。集合中错误的索引次序与 OLE DB 提供程序生成它们时的次序相同。
    /// </summary>
    public class OLEDBError
    {
        public object _objOLEDBError;
        internal object[] _objaParameters;

        internal OLEDBError(object objOLEDBError)
        { _objOLEDBError = objOLEDBError; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表最近使用过的文件的列表。
    /// 说明
    /// 每个文件都由一个 RecentFile 对象代表。
    /// </summary>
    public class RecentFiles
    {
        public object _objRecentFiles;
        internal object[] _objaParameters;

        public RecentFiles(object objRecentFiles)
        { _objRecentFiles = objRecentFiles; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一个实时数据对象。
    /// 说明
    /// 使用 Application 对象的 RTD 属性可返回一个 RTD 对象。
    /// </summary>
    public class RTD
    {
        public object _objRTD;
        internal object[] _objaParameters;

        public RTD(object objRTD)
        { _objRTD = objRTD; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>SmartTagRecognizer 对象的集合，这些对象代表着在您使用 Microsoft Excel 时给数据设置信息类型标签的识别引擎。
    /// 说明
    /// 使用 Application 对象的 SmartTagRecognizers 属性可返回一个 SmartTagRecognizers 集合。
    /// </summary>
    public class SmartTagRecognizers
    {
        public object _objSmartTagRecognizers;
        internal object[] _objaParameters;

        public SmartTagRecognizers(object objSmartTagRecognizers)
        { _objSmartTagRecognizers = objSmartTagRecognizers; }

        public SmartTagRecognizer this[object Index]
        {
            get
            {
                object objSmartTagRecognizer = _objSmartTagRecognizers.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objSmartTagRecognizers, new object[1] { Index });

                if (objSmartTagRecognizer == null)
                    return null;
                else
                    return new SmartTagRecognizer(objSmartTagRecognizer);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表在 Microsoft Excel 中进行操作时，用信息类型标记数据的识别引擎。
    /// 说明
    /// 使用 SmartTagRecognizers 集合的 Item(index) 属性可返回一个 SmartTagRecognizer 对象。
    /// </summary>
    public class SmartTagRecognizer
    {
        public object _objSmartTagRecognizer;
        internal object[] _objaParameters;

        public SmartTagRecognizer(object objSmartTagRecognizer)
        { _objSmartTagRecognizer = objSmartTagRecognizer; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包括与语音相关的方法和属性。
    /// 说明
    /// 使用 Application 对象的 Speech 属性可返回一个 Speech 对象。
    /// </summary>
    public class Speech
    {
        public object _objSpeech;
        internal object[] _objaParameters;

        public Speech(object objSpeech)
        { _objSpeech = objSpeech; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作表的各种拼写检查选项。
    /// 说明
    /// 使用 Application 对象的 SpellingOptions 属性可返回一个 SpellingOptions 对象。
    /// 一旦返回了 SpellingOptions 对象，您就可以使用下列属性来设置或返回各种拼写检查选项。
    /// 	ArabicModes 
    /// 	DictLang 
    /// 	GermanPostReform 
    /// 	HebrewModes 
    /// 	IgnoreCaps 
    /// 	IgnoreFileNames 
    /// 	IgnoreMixedDigits 
    /// 	KoreanCombineAux 
    /// 	KoreanProcessCompound 
    /// 	KoreanUseAutoChangeList 
    /// 	SuggestMainOnly 
    /// 	UserDict 
    /// </summary>
    public class SpellingOptions
    {
        public object _objSpellingOptions;
        internal object[] _objaParameters;

        public SpellingOptions(object objSpellingOptions)
        { _objSpellingOptions = objSpellingOptions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作簿中已分配的对象。
    /// </summary>
    public class UsedObjects
    {
        public object _objUsedObjects;
        internal object[] _objaParameters;

        public UsedObjects(object objUsedObjects)
        { _objUsedObjects = objUsedObjects; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的应用程序中所有 Watch 对象的集合。
    /// </summary>
    public class Watches
    {
        public object _objWatches;
        internal object[] _objaParameters;

        public Watches(object objWatches)
        { _objWatches = objWatches; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>用作可从 Visual Basic 中调用的 Microsoft Excel 工作表函数的容器。
    /// </summary>
    public class WorksheetFunction
    {
        public object _objWorksheetFunction;
        internal object[] _objaParameters;

        public WorksheetFunction(object objWorksheetFunction)
        { _objWorksheetFunction = objWorksheetFunction; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表已添加到工作簿的 XmlMap 对象的集合。
    /// </summary>
    public class XmlMaps
    {
        public object _objXmlMaps;
        internal object[] _objaParameters;

        internal XmlMaps(object objXmlMaps)
        { _objXmlMaps = objXmlMaps; }

        public XmlMap this[object Index]
        {
            get
            {
                object objXmlMap = _objXmlMaps.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objXmlMaps, new object[1] { Index });

                if (objXmlMap == null)
                    return null;
                else
                    return new XmlMap(objXmlMap);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表已添加到工作簿的 XML 映射。
    /// </summary>
    public class XmlMap
    {
        public object _objXmlMap;
        internal object[] _objaParameters;

        internal XmlMap(object objXmlMap)
        { _objXmlMap = objXmlMap; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定工作簿的 Connection 对象的集合。
    /// </summary>
    public class Connections
    {
        public object _objConnections;
        internal object[] _objaParameters;

        internal Connections(object objConnections)
        { _objConnections = objConnections; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>由自定义工作簿视图组成的集合。
    /// </summary>
    public class CustomViews
    {
        public object _objCustomViews;
        internal object[] _objaParameters;

        internal CustomViews(object objCustomViews)
        { _objCustomViews = objCustomViews; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表用于图标集条件格式规则的图标集的集合。
    /// </summary>
    public class IconSets
    {
        public object _objIconSets;
        internal object[] _objaParameters;

        internal IconSets(object objIconSets)
        { _objIconSets = objIconSets; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>您查询的是 Macintosh 专用的 Visual Basic 关键词。有关该关键词的帮助信息，请查阅 Microsoft Office Macintosh 版的语言参考帮助。
    /// </summary>
    public class Mailer
    {
        public object _objMailer;
        internal object[] _objaParameters;

        internal Mailer(object objMailer)
        { _objMailer = objMailer; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>工作簿中所有 PublishObject 对象的集合。
    /// </summary>
    public class PublishObjects
    {
        public object _objPublishObjects;
        internal object[] _objaParameters;

        internal PublishObjects(object objPublishObjects)
        { _objPublishObjects = objPublishObjects; }

        public PublishObject this[object Index]
        {
            get
            {
                object objPublishObject = _objPublishObjects.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPublishObjects, new object[1] { Index });

                if (objPublishObject == null)
                    return null;
                else
                    return new PublishObject(objPublishObject);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表保存为网页的工作簿中的项，并可以根据 PublishObject 对象中属性和方法所指定的值进行刷新。
    /// </summary>
    public class PublishObject
    {
        public object _objPublishObject;
        internal object[] _objaParameters;

        internal PublishObject(object objPublishObject)
        { _objPublishObject = objPublishObject; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>本主题供将来增添内容使用。初步文档中包括此主题是为了说明最终内容的结构提议。
    /// </summary>
    public class Research
    {
        public object _objResearch;
        internal object[] _objaParameters;

        internal Research(object objResearch)
        { _objResearch = objResearch; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作簿的传送名单。传送名单用于在电子邮件系统中发送工作簿。
    /// </summary>
    public class RoutingSlip
    {
        public object _objRoutingSlip;
        internal object[] _objaParameters;

        internal RoutingSlip(object objRoutingSlip)
        { _objRoutingSlip = objRoutingSlip; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>已标记为在服务器上可查看的对象的集合。
    /// </summary>
    public class ServerViewableItems
    {
        public object _objServerViewableItems;
        internal object[] _objaParameters;

        internal ServerViewableItems(object objServerViewableItems)
        { _objServerViewableItems = objServerViewableItems; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表用智能标记可执行的选项。
    /// </summary>
    public class SmartTagOptions
    {
        public object _objSmartTagOptions;
        internal object[] _objaParameters;

        internal SmartTagOptions(object objSmartTagOptions)
        { _objSmartTagOptions = objSmartTagOptions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的数据透视表中所有 Style
    /// </summary>
    public class Styles
    {
        public object _objStyles;
        internal object[] _objaParameters;

        internal Styles(object objStyles)
        { _objStyles = objStyles; }

        public Style this[object Index]
        {
            get
            {
                object objStyle = _objStyles.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objStyles, new object[1] { Index });

                if (objStyle == null)
                    return null;
                else
                    return new Style(objStyle);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表区域的样式说明。
    /// </summary>
    public class Style
    {
        public object _objStyle;
        internal object[] _objaParameters;

        internal Style(object objStyle)
        { _objStyle = objStyle; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表可应用于表格的样式。
    /// </summary>
    public class TableStyles
    {
        public object _objTableStyles;
        internal object[] _objaParameters;

        internal TableStyles(object objTableStyles)
        { _objTableStyles = objTableStyles; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含工作簿级的属性，当以网页保存文档或打开网页时，Microsoft Excel 将使用这些属性。
    /// </summary>
    public class WebOptions
    {
        public object _objWebOptions;
        internal object[] _objaParameters;

        internal WebOptions(object objWebOptions)
        { _objWebOptions = objWebOptions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作簿中 XmlNamespace 对象的集合
    /// </summary>
    public class XmlNamespaces
    {
        public object _objXmlNamespaces;
        internal object[] _objaParameters;

        internal XmlNamespaces(object objXmlNamespaces)
        { _objXmlNamespaces = objXmlNamespaces; }

        public XmlNamespace this[object Index]
        {
            get
            {
                object objXmlNamespace = _objXmlNamespaces.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objXmlNamespaces, new object[1] { Index });

                if (objXmlNamespace == null)
                    return null;
                else
                    return new XmlNamespace(objXmlNamespace);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表已添加到工作簿的命名空间。
    /// </summary>
    public class XmlNamespace
    {
        public object _objXmlNamespace;
        internal object[] _objaParameters;

        internal XmlNamespace(object objXmlNamespace)
        { _objXmlNamespace = objXmlNamespace; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作簿中数据透视表的内存缓存的集合。
    /// </summary>
    public class PivotCaches
    {
        public object _objPivotCaches;
        internal object[] _objaParameters;

        internal PivotCaches(object objPivotCaches)
        { _objPivotCaches = objPivotCaches; }

        public PivotCache this[object Index]
        {
            get
            {
                object objPivotCache = _objPivotCaches.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPivotCaches, new object[1] { Index });

                if (objPivotCache == null)
                    return null;
                else
                    return new PivotCache(objPivotCache);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表数据透视表的缓存。
    /// </summary>
    public class PivotCache
    {
        public object _objPivotCache;
        internal object[] _objaParameters;

        internal PivotCache(object objPivotCache)
        { _objPivotCache = objPivotCache; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 打印区域内水平分页符的集合。
    /// </summary>
    public class HPageBreaks
    {
        public object _objHPageBreaks;
        internal object[] _objaParameters;

        internal HPageBreaks(object objHPageBreaks)
        { _objHPageBreaks = objHPageBreaks; }

        public HPageBreak this[object Index]
        {
            get
            {
                object objHPageBreak = _objHPageBreaks.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objHPageBreaks, new object[1] { Index });

                if (objHPageBreak == null)
                    return null;
                else
                    return new HPageBreak(objHPageBreak);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表水平分页符。
    /// </summary>
    public class HPageBreak
    {
        public object _objHPageBreak;
        internal object[] _objaParameters;

        internal HPageBreak(object objHPageBreak)
        { _objHPageBreak = objHPageBreak; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 打印区域中垂直分页符的集合。
    /// </summary>
    public class VPageBreaks
    {
        public object _objVPageBreaks;
        internal object[] _objaParameters;

        internal VPageBreaks(object objVPageBreaks)
        { _objVPageBreaks = objVPageBreaks; }

        public VPageBreak this[object Index]
        {
            get
            {
                object objVPageBreak = _objVPageBreaks.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objVPageBreaks, new object[1] { Index });

                if (objVPageBreak == null)
                    return null;
                else
                    return new VPageBreak(objVPageBreak);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表一个垂直分页符。
    /// </summary>
    public class VPageBreak
    {
        public object _objVPageBreak;
        internal object[] _objaParameters;

        internal VPageBreak(object objVPageBreak)
        { _objVPageBreak = objVPageBreak; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表对指定工作表的自动筛选。
    /// </summary>
    public class AutoFilter
    {
        public object _objAutoFilter;
        internal object[] _objaParameters;

        internal AutoFilter(object objAutoFilter)
        { _objAutoFilter = objAutoFilter; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 由单元格批注组成的集合。
    /// </summary>
    public class Comments
    {
        public object _objComments;
        internal object[] _objaParameters;

        internal Comments(object objComments)
        { _objComments = objComments; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表单元格批注。
    /// </summary>
    public class Comment
    {
        public object _objComment;
        internal object[] _objaParameters;

        internal Comment(object objComment)
        { _objComment = objComment; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 由代表附加信息的 CustomProperty 对象组成的集合，这些信息可用作 XML 的元数据。
    /// </summary>
    public class CustomProperties
    {
        public object _objCustomProperties;
        internal object[] _objaParameters;

        internal CustomProperties(object objCustomProperties)
        { _objCustomProperties = objCustomProperties; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 工作表上所有 ListObject 对象的集合。每个 ListObject 对象都代表工作表中的一个表格。
    /// </summary>
    public class ListObjects
    {
        public object _objListObjects;
        internal object[] _objaParameters;

        internal ListObjects(object objListObjects)
        { _objListObjects = objListObjects; }

        public ListObject this[object Index]
        {
            get
            {
                object objListObject = _objListObjects.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objListObjects, new object[1] { Index });

                if (objListObject == null)
                    return null;
                else
                    return new ListObject(objListObject);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表工作表中的表格。
    /// </summary>
    public class ListObject
    {
        public object _objListObject;
        internal object[] _objaParameters;

        internal ListObject(object objListObject)
        { _objListObject = objListObject; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表工作表上的分级显示。
    /// </summary>
    public class Outline
    {
        public object _objOutline;
        internal object[] _objaParameters;

        internal Outline(object objOutline)
        { _objOutline = objOutline; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表工作表可使用的各种保护选项类型。
    /// </summary>
    public class Protection
    {
        public object _objProtection;
        internal object[] _objaParameters;

        internal Protection(object objProtection)
        { _objProtection = objProtection; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> QueryTable 对象的集合。
    /// </summary>
    public class QueryTables
    {
        public object _objQueryTables;
        internal object[] _objaParameters;

        internal QueryTables(object objQueryTables)
        { _objQueryTables = objQueryTables; }

        public QueryTable this[object Index]
        {
            get
            {
                object objQueryTable = _objQueryTables.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objQueryTables, new object[1] { Index });

                if (objQueryTable == null)
                    return null;
                else
                    return new QueryTable(objQueryTable);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表一个利用从外部数据源（如 SQL Server 或 Microsoft Access 数据库）返回的数据生成的工作表表格。
    /// </summary>
    public class QueryTable
    {
        public object _objQueryTable;
        internal object[] _objaParameters;

        internal QueryTable(object objQueryTable)
        { _objQueryTable = objQueryTable; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> SmartTag 对象的集合，这些对象代表指定给各个单元格的标识符。
    /// </summary>
    public class SmartTags
    {
        public object _objSmartTags;
        internal object[] _objaParameters;

        internal SmartTags(object objSmartTags)
        { _objSmartTags = objSmartTags; }

        public SmartTag this[object Index]
        {
            get
            {
                object objSmartTag = _objSmartTags.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objSmartTags, new object[1] { Index });

                if (objSmartTag == null)
                    return null;
                else
                    return new SmartTag(objSmartTag);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表分配给单元格的标识符。
    /// </summary>
    public class SmartTag
    {
        public object _objSmartTag;
        internal object[] _objaParameters;

        internal SmartTag(object objSmartTag)
        { _objSmartTag = objSmartTag; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表数据区域的排序方式。
    /// </summary>
    public class Sort
    {
        public object _objSort;
        internal object[] _objaParameters;

        internal Sort(object objSort)
        { _objSort = objSort; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 指定的图表工作表、对话框编辑表或工作表上的所有 ChartObject 对象的集合。
    /// 说明：
    /// 每个 ChartObject 对象都代表一个嵌入图表。ChartObject 对象充当 Chart 对象的容器。ChartObject 对象的属性和方法控制工作表上嵌入图表的外观和大小。ChartObjects 集合
    /// </summary>
    public class ChartObjects
    {
        public object _objChartObjects;
        internal object[] _objaParameters;

        internal ChartObjects(object objChartObjects)
        { _objChartObjects = objChartObjects; }

        public ChartObject this[object Index]
        {
            get
            {
                object objChartObject = _objChartObjects.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objChartObjects, new object[1] { Index });

                if (objChartObject == null)
                    return null;
                else
                    return new ChartObject(objChartObject);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 代表工作表上的嵌入图表。
    /// 说明：
    /// ChartObject 对象充当 Chart 对象的容器。ChartObject 对象的属性和方法控制工作表上嵌入图表的外观和大小。ChartObject 对象是 ChartObjects 集合的成员。ChartObjects 集合包含单一工作表上的所有嵌入图表。
    /// 使用 ChartObjects(index)（其中 index 是嵌入图表的索引号或名称）可以返回单个 ChartObject 对象。
    /// </summary>
    public class ChartObject
    {
        public object _objChartObject;
        internal object[] _objaParameters;

        internal ChartObject(object objChartObject)
        { _objChartObject = objChartObject; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的工作表中所有 PivotTable 对象的集合。
    /// 说明
    /// 因为对数据透视表进行编程可能会很复杂，所以，最方便的做法是将数据透视表操作录制到宏中，然后再修订所录制的宏代码。
    /// </summary>
    public class PivotTables
    {
        public object _objPivotTables;
        internal object[] _objaParameters;

        internal PivotTables(object objPivotTables)
        { _objPivotTables = objPivotTables; }

        public PivotTable this[object Index]
        {
            get
            {
                object objPivotTable = _objPivotTables.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPivotTables, new object[1] { Index });

                if (objPivotTable == null)
                    return null;
                else
                    return new PivotTable(objPivotTable);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作表上的数据透视表。
    /// 说明
    /// PivotTable 对象是 PivotTables 集合的成员。PivotTables 集合包含某一张工作表上的所有 PivotTable 对象。
    /// 因为对数据透视表进行编程可能会很复杂，所以，最方便的做法是将数据透视表操作录制到宏中，然后再修订所录制的宏代码。
    /// </summary>
    public class PivotTable
    {
        public object _objPivotTable;
        internal object[] _objaParameters;

        internal PivotTable(object objPivotTable)
        { _objPivotTable = objPivotTable; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定工作表上所有 Scenario 对象的集合。
    /// 说明：
    /// 方案是一组经过命名和保存的输入值（被称为“可变单元格”）。
    /// </summary>
    public class Scenarios
    {
        public object _objScenarios;
        internal object[] _objaParameters;

        internal Scenarios(object objScenarios)
        { _objScenarios = objScenarios; }

        public Scenario this[object Index]
        {
            get
            {
                object objScenario = _objScenarios.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objScenarios, new object[1] { Index });

                if (objScenario == null)
                    return null;
                else
                    return new Scenario(objScenario);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作表上的一个方案。
    /// 说明：
    /// 方案是一组经过命名和保存的输入值（被称为 changing cells）。Scenario 对象是 Scenarios 集合的成员。Scenarios 集合包含某个工作表的所有定义方案。
    /// </summary>
    public class Scenario
    {
        public object _objScenario;
        internal object[] _objaParameters;

        internal Scenario(object objScenario)
        { _objScenario = objScenario; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表区域内的各种电子表格错误。
    /// 说明：
    /// 使用 Range 对象的 Errors 属性可返回 Errors 对象。
    /// </summary>
    public class Errors
    {
        public object _objErrors;
        internal object[] _objaParameters;

        internal Errors(object objErrors)
        { _objErrors = objErrors; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一个区域内所有条件格式的集合。
    /// 说明
    /// FormatConditions 集合可以包含多个条件格式。每个格式由一个 FormatCondition 对象代表。
    /// 有关条件格式的详细信息，请参阅 FormatCondition 对象。
    /// 使用 FormatConditions 属性可返回 FormatConditions 对象。使用 Add 方法可新建条件格式，使用 Modify 方法可更改现有的条件格式。
    /// </summary>
    public class FormatConditions
    {
        public object _objFormatConditions;
        internal object[] _objaParameters;

        internal FormatConditions(object objFormatConditions)
        { _objFormatConditions = objFormatConditions; }

        public FormatCondition this[object Index]
        {
            get
            {
                object objFormatCondition = _objFormatConditions.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objFormatConditions, new object[1] { Index });

                if (objFormatCondition == null)
                    return null;
                else
                    return new FormatCondition(objFormatCondition);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表条件格式。
    /// 说明
    /// FormatCondition 对象是 FormatConditions 集合的成员。对于给定区域，FormatConditions 集合中包含的条件格式不能超过三个。
    /// 使用 Add 方法可新建条件格式。如果区域内存在多种格式，则可使用 Modify 方法更改其中一种格式，或使用 Delete 方法删除一种格式，然后使用 Add 方法创建一种新格式。
    /// 使用 FormatCondition 对象的 Font、Borders 和 Interior 属性可控制已设置格式的单元格的外观。条件格式对象模型不支持这些对象的某些属性。下表列出所有可与条件格式一起使用的属性。
    /// </summary>
    public class FormatCondition
    {
        public object _objFormatCondition;
        internal object[] _objaParameters;

        internal FormatCondition(object objFormatCondition)
        { _objFormatCondition = objFormatCondition; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一个对象的内部。
    /// </summary>
    public class Interior
    {
        public object _objInterior;
        internal object[] _objaParameters;

        internal Interior(object objInterior)
        { _objInterior = objInterior; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的区域中所有 Phonetic 对象的集合。
    /// 说明：
    /// 每一个 Phonetic 对象都包含有关某个特定拼音文本字符串的信息。
    /// </summary>
    public class Phonetics
    {
        public object _objPhonetics;
        internal object[] _objaParameters;

        internal Phonetics(object objPhonetics)
        { _objPhonetics = objPhonetics; }

        public Phonetic this[object Index]
        {
            get
            {
                object objPhonetic = _objPhonetics.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPhonetics, new object[1] { Index });

                if (objPhonetic == null)
                    return null;
                else
                    return new Phonetic(objPhonetic);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>包含单元格中特定拼音文本串的有关信息。
    /// 说明：
    /// 在 Microsoft Excel 97 中，此对象包含指定区域中任意拼音文本的格式属性。
    /// </summary>
    public class Phonetic
    {
        public object _objPhonetic;
        internal object[] _objaParameters;

        internal Phonetic(object objPhonetic)
        { _objPhonetic = objPhonetic; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表数据透视表中的一个单元格。
    /// 说明
    /// 使用 Range 集合的 PivotCell 属性可返回一个 PivotCell 对象。
    /// 返回 PivotCell 对象后，可以使用 ColumnItems 或 RowItems 属性来确定 PivotItems 集合，对应于代表所选编号的列轴或行轴上的项目。下例使用 PivotCell 对象的 ColumnItems 属性来返回一个 PivotItemList 集合。
    /// </summary>
    public class PivotCell
    {
        public object _objPivotCell;
        internal object[] _objaParameters;

        internal PivotCell(object objPivotCell)
        { _objPivotCell = objPivotCell; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的数据透视表中所有 PivotField 对象的集合。
    /// 说明：
    /// 下列存取器方法返回数据透视表字段的子集，在某些情况下，使用这些属性会更为方便：
    /// </summary>
    public class PivotFields
    {
        public object _objPivotFields;
        internal object[] _objaParameters;

        internal PivotFields(object objPivotFields)
        { _objPivotFields = objPivotFields; }

        public PivotField this[object Index]
        {
            get
            {
                object objPivotField = _objPivotFields.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPivotFields, new object[1] { Index });

                if (objPivotField == null)
                    return null;
                else
                    return new PivotField(objPivotField);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表数据透视表中的一个字段。
    /// 说明：
    /// PivotField 对象是 PivotFields 集合的成员。PivotFields 集合包含数据透视表中的所有字段，包括隐藏字段。
    /// </summary>
    public class PivotField
    {
        public object _objPivotField;
        internal object[] _objaParameters;

        internal PivotField(object objPivotField)
        { _objPivotField = objPivotField; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>数据透视表字段中所有 PivotItem 对象的集合。
    /// 说明：
    /// 这些项目是某个字段类型中的各个数据项。
    /// </summary>
    public class PivotItems
    {
        public object _objPivotItems;
        internal object[] _objaParameters;

        internal PivotItems(object objPivotItems)
        { _objPivotItems = objPivotItems; }

        public PivotItem this[object Index]
        {
            get
            {
                object objPivotItem = _objPivotItems.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPivotItems, new object[1] { Index });

                if (objPivotItem == null)
                    return null;
                else
                    return new PivotItem(objPivotItem);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表数据透视表字段中的项目。
    /// 说明：
    /// 这些项目是某个字段类型中的各个数据项。PivotItem 对象是 PivotItems 集合的成员。PivotItems 集合包含某个 PivotField 对象中所有的项目。
    /// </summary>
    public class PivotItem
    {
        public object _objPivotItem;
        internal object[] _objaParameters;

        internal PivotItem(object objPivotItem)
        { _objPivotItem = objPivotItem; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的数据系列中所有 Action 对象的集合。
    /// </summary>
    public class Actions
    {
        public object _objActions;
        internal object[] _objaParameters;

        internal Actions(object objActions)
        { _objActions = objActions; }

        public Action this[object Index]
        {
            get
            {
                object objAction = _objActions.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objActions, new object[1] { Index });

                if (objAction == null)
                    return null;
                else
                    return new Action(objAction);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表要在数据透视表或数据表中执行的操作。
    /// </summary>
    public class Action
    {
        public object _objAction;
        internal object[] _objaParameters;

        internal Action(object objAction)
        { _objAction = objAction; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表工作表区域的数据有效性规则。
    /// </summary>
    public class Validation
    {
        public object _objValidation;
        internal object[] _objaParameters;

        internal Validation(object objValidation)
        { _objValidation = objValidation; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表已被映射到 Range 或 ListColumn 对象的 XPath。
    /// 说明：
    /// 除了将文件保存为 XML 电子表格格式，其他的 XML 功能只能在 Microsoft Office Professional Edition 2003 和 Microsoft Office Excel 2003中使用。
    /// </summary>
    public class XPath
    {
        public object _objXPath;
        internal object[] _objaParameters;

        internal XPath(object objXPath)
        { _objXPath = objXPath; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的窗口中所有 Pane 对象的集合。
    /// 说明：
    /// Pane 对象只对于工作表和 Microsoft Excel 4.0 宏表存在。
    /// </summary>
    public class Panes
    {
        public object _objPanes;
        internal object[] _objaParameters;

        internal Panes(object objPanes)
        { _objPanes = objPanes; }

        public Pane this[object Index]
        {
            get
            {
                object objPane = _objPanes.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, _objPanes, new object[1] { Index });

                if (objPane == null)
                    return null;
                else
                    return new Pane(objPane);
            }
        }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表窗口中的窗格。
    /// 说明：
    /// Pane 对象只对于工作表和 Microsoft Excel 4.0 宏表存在。Pane 对象是 Panes 集合的成员。Panes 集合包含在一个窗口中显示的所有窗格。
    /// </summary>
    public class Pane
    {
        public object _objPane;
        internal object[] _objaParameters;

        internal Pane(object objPane)
        { _objPane = objPane; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>指定的或活动工作簿窗口中所有工作表视图的集合。 
    /// </summary>
    public class SheetViews
    {
        public object _objSheetViews;
        internal object[] _objaParameters;

        internal SheetViews(object objSheetViews)
        { _objSheetViews = objSheetViews; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表形状的填充格式。
    /// 说明：
    /// 形状可以有纯色、渐变、纹理、图案、图片或半透明填充。
    /// FillFormat 对象的很多属性是只读的。要设置这些属性中每一个，必须使用相应的方法。
    /// </summary>
    public class FillFormat
    {
        public object _objFillFormat;
        internal object[] _objaParameters;

        internal FillFormat(object objFillFormat)
        { _objFillFormat = objFillFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图表中用同一格式绘制的一个或多个数据系列。
    /// 说明：
    /// 一张图表包含一个或多个图表组，每个图表组包含一个或多个 Series 对象，每个数据系列包含一个或多个 Points 对象。例如，单张图表可能既包含折线图图表组（其中包含所有用折线图格式绘制的数据系列），也包含条形图图表组（其中包含所有用条形图格式绘制的数据系列）。ChartGroup 对象是 ChartGroups 集合的成员。
    /// 使用 ChartGroups(index)（其中 index 是图表组的索引号）可以返回单个 ChartGroup 对象。
    /// 因为当特定图表组所用的图表格式更改时，该图表组的索引号可能会更改，所以使用命名图表组快捷方法之一来返回特定的图表组会更加容易。PieGroups 方法返回图表中饼图图表组的集合，LineGroups 方法返回图表中折线图图表组的集合，依此类推。这些方法中的每一个都可以与索引号配合使用以返回单个 ChartGroup 对象，或不指定索引号而返回 ChartGroups 集合。
    /// </summary>
    public class ChartGroup
    {
        public object _objChartGroup;
        internal object[] _objaParameters;

        internal ChartGroup(object objChartGroup)
        { _objChartGroup = objChartGroup; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表三维图表的背景墙。此对象不是集合。没有代表单个背景墙的对象；只能将所有的背景墙作为一个单位同时返回。
    /// </summary>
    public class Walls
    {
        public object _objWalls;
        internal object[] _objaParameters;

        internal Walls(object objWalls)
        { _objWalls = objWalls; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图表的图表区。
    /// 说明：
    /// 图表区包含绘图区在内的一切内容。但是，绘图区具有它自己的填充方式，因此填充绘图区并不会填充图表区。
    /// 有关设置绘图区格式的信息，请参阅 PlotArea Object。
    /// 使用 ChartArea 属性可返回 ChartArea 对象。 
    /// </summary>
    public class ChartArea
    {
        public object _objChartArea;
        internal object[] _objaParameters;

        internal ChartArea(object objChartArea)
        { _objChartArea = objChartArea; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图表标题。
    /// 说明：
    /// 使用 ChartTitle 属性可返回 ChartTitle 对象。
    /// 只有图表的 HasTitle 属性为 True 时，ChartTitle 对象才存在，从而才能使用该对象。
    /// </summary>
    public class ChartTitle
    {
        public object _objChartTitle;
        internal object[] _objaParameters;

        internal ChartTitle(object objChartTitle)
        { _objChartTitle = objChartTitle; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一张图表数据表。
    /// </summary>
    public class DataTable
    {
        public object _objDataTable;
        internal object[] _objaParameters;

        internal DataTable(object objDataTable)
        { _objDataTable = objDataTable; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表三维图表的基底。
    /// </summary>
    public class Floor
    {
        public object _objFloor;
        internal object[] _objaParameters;

        internal Floor(object objFloor)
        { _objFloor = objFloor; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图标中的图例。每个图表只能有一个图例。
    /// 说明：
    /// Legend 对象包含一个或多个 LegendEntry 对象；每个 LegendEntry 对象都包含一个 LegendKey 对象。
    /// 除非 HasLegend 属性是 True，否则无法看到图表的图例。如果该属性为 False，Legend 对象的属性和方法将会失败。
    /// </summary>
    public class Legend
    {
        public object _objLegend;
        internal object[] _objaParameters;

        internal Legend(object objLegend)
        { _objLegend = objLegend; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表数据透视图报表中字段的位置。
    /// </summary>
    public class PivotLayout
    {
        public object _objPivotLayout;
        internal object[] _objaParameters;

        internal PivotLayout(object objPivotLayout)
        { _objPivotLayout = objPivotLayout; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图表的绘图区。
    /// 说明：
    /// 该区域为绘制图表数据的区域。二维图表中的绘图区包含数据标志、网格线、数据标签、趋势线和可选的置于图表区内的图表项。三维图表的绘图区中除包含上述各项外，还在图表中包含背景墙、基底、坐标轴、坐标轴标题和刻度线标签。
    /// 绘图区被图表区所包围。二维图表的图表区包含坐标轴、图表标题、坐标轴标题和图例。三维图表的图表区包含图表标题和图例。有关设置图表区格式的详细信息，请参阅 ChartArea 对象。
    /// </summary>
    public class PlotArea
    {
        public object _objPlotArea;
        internal object[] _objaParameters;

        internal PlotArea(object objPlotArea)
        { _objPlotArea = objPlotArea; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表图表或工作表中的标签。
    /// 说明：
    /// 使用 Chart 对象或 Worksheet 对象的 Tab 属性可返回一个 Tab 对象。
    /// 一旦返回了 Tab 对象，您就可以使用 ColorIndex 属性来确定图表或工作表标签的设置。
    /// </summary>
    public class Tab
    {
        public object _objTab;
        internal object[] _objaParameters;

        internal Tab(object objTab)
        { _objTab = objTab; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

}

