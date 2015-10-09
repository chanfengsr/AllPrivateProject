using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectOffice.Core
{

    /// <summary>代表 Office 图形周围的发光效果。
    /// </summary>
    public class GlowFormat
    {
        public object _objGlowFormat;

        public GlowFormat(object objGlowFormat)
        { _objGlowFormat = objGlowFormat; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public object Application
        {
            get { return _objGlowFormat.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objGlowFormat, null); }
        }

        /// <summary>获取一个 ColorFormat 对象，该对象代表格式设置为发光的文本的颜色。只读。
        /// </summary>
        public ColorFormat Color
        {
            get { return new ColorFormat(_objGlowFormat.GetType().InvokeMember("Color", BindingFlags.GetProperty, null, _objGlowFormat, null)); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// </summary>
        public int Creator
        {
            get { return (int)_objGlowFormat.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objGlowFormat, null); }
        }

        /// <summary>获取或设置 GlowFormat 对象发光效果的半径值。可读写。
        /// </summary>
        public float Radius
        {
            get { return (float)_objGlowFormat.GetType().InvokeMember("Radius", BindingFlags.GetProperty, null, _objGlowFormat, null); }
            set { _objGlowFormat.GetType().InvokeMember("Radius", BindingFlags.SetProperty, null, _objGlowFormat, new object[1] { value }); }
        }
        #endregion 属性
    }

    /// <summary>代表单色对象的颜色、带有渐变或图案填充的对象的前景或背景色，或者指针的颜色。
    /// </summary>
    public class ColorFormat
    {
        public object _objColorFormat;

        public ColorFormat(object objColorFormat)
        { _objColorFormat = objColorFormat; }

        #region 属性
        /// <summary>如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。
        /// </summary>
        public object Application
        {
            get { return _objColorFormat.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, _objColorFormat, null); }
        }

        /// <summary>返回一个 32 位整数，该整数指示在其中创建此对象的应用程序。只读 Long 类型。
        /// </summary>
        public int Creator
        {
            get { return (int)_objColorFormat.GetType().InvokeMember("Creator", BindingFlags.GetProperty, null, _objColorFormat, null); }
        }

        /// <summary>返回或设置一种映射到主题配色方案的颜色。可读/写 MsoThemeColorIndex。
        /// </summary>
        public MsoThemeColorIndex ObjectThemeColor
        {
            get { return (MsoThemeColorIndex)_objColorFormat.GetType().InvokeMember("ObjectThemeColor", BindingFlags.GetProperty, null, _objColorFormat, null); }
            set { _objColorFormat.GetType().InvokeMember("ObjectThemeColor", BindingFlags.SetProperty, null, _objColorFormat, new object[1] { value }); }
        }

        /// <summary>返回指定对象的父对象。只读。
        /// </summary>
        public object Parent
        {
            get { return (object)_objColorFormat.GetType().InvokeMember("Parent", BindingFlags.GetProperty, null, _objColorFormat, null); }
        }

        /// <summary>返回或设置一个 Long 值，它代表指定颜色的红绿蓝 (RGB) 值。
        /// </summary>
        public int RGB
        {
            get { return (int)_objColorFormat.GetType().InvokeMember("RGB", BindingFlags.GetProperty, null, _objColorFormat, null); }
            set { _objColorFormat.GetType().InvokeMember("RGB", BindingFlags.SetProperty, null, _objColorFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Integer 值，它代表 Color 对象的颜色，作为当前配色方案中的索引。
        /// </summary>
        public int SchemeColor
        {
            get { return (int)_objColorFormat.GetType().InvokeMember("SchemeColor", BindingFlags.GetProperty, null, _objColorFormat, null); }
            set { _objColorFormat.GetType().InvokeMember("SchemeColor", BindingFlags.SetProperty, null, _objColorFormat, new object[1] { value }); }
        }

        /// <summary>返回或设置一个 Single，使颜色变深或变浅。
        /// </summary>
        public float TintAndShade
        {
            get { return (float)_objColorFormat.GetType().InvokeMember("TintAndShade", BindingFlags.GetProperty, null, _objColorFormat, null); }
            set { _objColorFormat.GetType().InvokeMember("TintAndShade", BindingFlags.SetProperty, null, _objColorFormat, new object[1] { value }); }
        }

        /// <summary>返回一个代表颜色格式类型的 MsoColorType 值。
        /// </summary>
        public MsoColorType Type
        {
            get { return (MsoColorType)_objColorFormat.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, _objColorFormat, null); }
            set { _objColorFormat.GetType().InvokeMember("Type", BindingFlags.SetProperty, null, _objColorFormat, new object[1] { value }); }
        }
        #endregion 属性
    }

    /**************以下为未完成类******************/
    /// <summary>代表 Office 图形中的反射效果。
    /// </summary>
    public class ReflectionFormat
    {
        public object _objReflectionFormat;

        public ReflectionFormat(object objReflectionFormat)
        { _objReflectionFormat = objReflectionFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 Office 图形中的柔化边缘效果。
    /// </summary>
    public class SoftEdgeFormat
    {
        public object _objSoftEdgeFormat;

        public SoftEdgeFormat(object objSoftEdgeFormat)
        { _objSoftEdgeFormat = objSoftEdgeFormat; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>COMAddIn 对象的集合，这些对象提供有关在 Windows 注册表中注册的 COM 加载项的信息。
    /// </summary>
    public class COMAddIns
    {
        public object _objCOMAddIns;
        internal object[] _objaParameters;

        public COMAddIns(object objCOMAddIns)
        { _objCOMAddIns = objCOMAddIns; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 Microsoft Office 宿主应用程序中的一个 COM 加载项。COMAddIn 对象是 COMAddIns 集合的成员。
    /// </summary>
    public class COMAddIn
    {
        public object _objCOMAddIn;
        internal object[] _objaParameters;

        public COMAddIn(object objCOMAddIn)
        { _objCOMAddIn = objCOMAddIn; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表容器应用程序中命令栏的 CommandBar 对象的集合。
    /// </summary>
    public class CommandBars
    {
        public object _objCommandBars;
        internal object[] _objaParameters;

        public CommandBars(object objCommandBars)
        { _objCommandBars = objCommandBars; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表容器应用程序中的一个命令栏。CommandBar 对象是 CommandBars 集合的成员。
    /// </summary>
    public class CommandBar
    {
        public object _objCommandBar;
        internal object[] _objaParameters;

        public CommandBar(object objCommandBar)
        { _objCommandBar = objCommandBar; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>返回 Microsoft Office 应用程序中有关语言设置的信息。
    /// 说明
    /// 使用 Application.LanguageSettings.LanguageID(MsoAppLanguageID )，其中 MsoAppLanguageID 是一个用于将区域设置标识符 (LCID) 信息返回到指定应用程序的常量。
    /// </summary>
    public class LanguageSettings
    {
        public object _objLanguageSettings;
        internal object[] _objaParameters;

        public LanguageSettings(object objLanguageSettings)
        { _objLanguageSettings = objLanguageSettings; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表某些 Microsoft Office 应用程序中“新建 Item”任务窗格上列出的项。
    /// 说明
    /// 下表列出了在每个应用程序中用于访问 NewFile 对象的属性。
    /// 应用程序	属性 
    /// Microsoft Access	NewFileTaskPane  
    /// Microsoft Excel 文件	NewWorkbook  
    /// Microsoft FrontPage	NewPageOrWeb  
    /// Microsoft PowerPoint	NewPresentation  
    /// Microsoft Word	NewDocument  
    /// </summary>
    public class NewFile
    {
        public object _objNewFile;
        internal object[] _objaParameters;

        public NewFile(object objNewFile)
        { _objNewFile = objNewFile; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表描述文档中所存储元数据的属性的集合。
    /// </summary>
    public class MetaProperties
    {
        public object _objMetaProperties;
        internal object[] _objaParameters;

        internal MetaProperties(object objMetaProperties)
        { _objMetaProperties = objMetaProperties; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 CustomXMLPart 对象的集合。
    /// </summary>
    public class CustomXMLParts
    {
        public object _objCustomXMLParts;
        internal object[] _objaParameters;

        internal CustomXMLParts(object objCustomXMLParts)
        { _objCustomXMLParts = objCustomXMLParts; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 CustomXMLParts 集合中的单个 CustomXMLPart。
    /// </summary>
    public class CustomXMLPart
    {
        public object _objCustomXMLPart;
        internal object[] _objaParameters;

        internal CustomXMLPart(object objCustomXMLPart)
        { _objCustomXMLPart = objCustomXMLPart; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 DocumentInspector 对象的集合。
    /// </summary>
    public class DocumentInspectors
    {
        public object _objDocumentInspectors;
        internal object[] _objaParameters;

        internal DocumentInspectors(object objDocumentInspectors)
        { _objDocumentInspectors = objDocumentInspectors; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 DocumentInspectors 集合中的文档检查器模块。
    /// </summary>
    public class DocumentInspector
    {
        public object _objDocumentInspector;
        internal object[] _objaParameters;

        internal DocumentInspector(object objDocumentInspector)
        { _objDocumentInspector = objDocumentInspector; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Office Word 2003 或 Microsoft Office Word 2007 中的 Document 对象、Microsoft Office Excel 2003 或 Microsoft Office Excel 2007 中的 Workbook 对象以及 Microsoft Office PowerPoint 2003 或 Microsoft Office Excel 2007 中的 Presentation 对象的 DocumentLibraryVersions 属性均可返回一个 DocumentLibraryVersions 对象。该 DocumentLibraryVersions 对象代表 DocumentLibraryVersion 对象的集合。
    /// </summary>
    public class DocumentLibraryVersions
    {
        public object _objDocumentLibraryVersions;
        internal object[] _objaParameters;

        internal DocumentLibraryVersions(object objDocumentLibraryVersions)
        { _objDocumentLibraryVersions = objDocumentLibraryVersions; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Office Word 2003 或 Microsoft Office Word 2007 中的 Document 对象、Microsoft Office Excel 2003 或 Microsoft Office Excel 2007 中的 Workbook 对象以及 Microsoft Office PowerPoint 2003 或 Microsoft Office PowerPoint 2007 中的 Presentation 对象的 Permission 属性均可返回一个 Permission 对象。
    /// </summary>
    public class Permission
    {
        public object _objPermission;
        internal object[] _objaParameters;

        internal Permission(object objPermission)
        { _objPermission = objPermission; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表为运行 Office SharePoint Server 2007 的服务器上存储的文档类型指定的策略。
    /// </summary>
    public class ServerPolicy
    {
        public object _objServerPolicy;
        internal object[] _objaParameters;

        internal ServerPolicy(object objServerPolicy)
        { _objServerPolicy = objServerPolicy; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Office Word 2003 或 Microsoft Office Word 2007 中的 Document 对象、Microsoft Office Excel 2003 或 Microsoft Office Excel 2007 中的 Workbook 对象和 Microsoft Office PowerPoint 2003 或 Microsoft Office PowerPoint 2007 中的 Presentation 对象的 SharedWorkspace 属性返回一个 SharedWorkspace 对象，该对象允许开发人员向 SharePoint 网站添加活动文档并管理共享工作区网站中的其他对象。
    /// </summary>
    public class SharedWorkspace
    {
        public object _objSharedWorkspace;
        internal object[] _objaParameters;

        internal SharedWorkspace(object objSharedWorkspace)
        { _objSharedWorkspace = objSharedWorkspace; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>对应于附加到文档的数字签名的 Signature 对象的集合。
    /// </summary>
    public class SignatureSet
    {
        public object _objSignatureSet;
        internal object[] _objaParameters;

        internal SignatureSet(object objSignatureSet)
        { _objSignatureSet = objSignatureSet; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Office Word 2003 或 Microsoft Office Word 2007 中的 Document 对象或者 Microsoft Office Excel 2003 中的 Workbook 对象的 SmartDocument 属性均可返回一个 SmartDocument 对象。
    /// </summary>
    public class SmartDocument
    {
        public object _objSmartDocument;
        internal object[] _objaParameters;

        internal SmartDocument(object objSmartDocument)
        { _objSmartDocument = objSmartDocument; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>Microsoft Office Word 2003 或 Microsoft Office Word 2007 中的 Document 对象、Microsoft Office Excel 2003 或 Microsoft Office Excel 2007 中的 Workbook 对象以及 Microsoft PowerPoint 2003 或 Microsoft Office PowerPoint 2007 中的 Presentation 对象的 Sync 属性均可返回一个 Sync 对象。
    /// </summary>
    public class Sync
    {
        public object _objSync;
        internal object[] _objaParameters;

        internal Sync(object objSync)
        { _objSync = objSync; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表一个 Microsoft Office 主题。
    /// </summary>
    public class OfficeTheme
    {
        public object _objOfficeTheme;
        internal object[] _objaParameters;

        internal OfficeTheme(object objOfficeTheme)
        { _objOfficeTheme = objOfficeTheme; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 WorkflowTemplate 对象的集合。
    /// </summary>
    public class WorkflowTemplates
    {
        public object _objWorkflowTemplates;
        internal object[] _objaParameters;

        internal WorkflowTemplates(object objWorkflowTemplates)
        { _objWorkflowTemplates = objWorkflowTemplates; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表可用于当前文档的工作流之一。
    /// </summary>
    public class WorkflowTemplate
    {
        public object _objWorkflowTemplate;
        internal object[] _objaParameters;

        internal WorkflowTemplate(object objWorkflowTemplate)
        { _objWorkflowTemplate = objWorkflowTemplate; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 WorkflowTask 对象的集合。
    /// </summary>
    public class WorkflowTasks
    {
        public object _objWorkflowTasks;
        internal object[] _objaParameters;

        internal WorkflowTasks(object objWorkflowTasks)
        { _objWorkflowTasks = objWorkflowTasks; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary>代表 WorkflowTasks 集合中的单个工作流任务。
    /// </summary>
    public class WorkflowTask
    {
        public object _objWorkflowTask;
        internal object[] _objaParameters;

        internal WorkflowTask(object objWorkflowTask)
        { _objWorkflowTask = objWorkflowTask; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }

    /// <summary> 提供对以下功能的访问：直接从 Microsoft Office 应用程序以电子邮件形式发送文档。
    /// </summary>
    public class MsoEnvelope
    {
        public object _objMsoEnvelope;
        internal object[] _objaParameters;

        internal MsoEnvelope(object objMsoEnvelope)
        { _objMsoEnvelope = objMsoEnvelope; }

        #region 属性

        #endregion 属性

        #region 函数

        #endregion 函数
    }
}
