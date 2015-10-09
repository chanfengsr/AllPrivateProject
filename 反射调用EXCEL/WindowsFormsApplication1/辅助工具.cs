using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class 辅助工具 : Form
    {
        #region 固定Array或List
        /// <summary>所有的枚举变量名称
        /// </summary>
        string[] _astrEnumName = new string[] { "BackstageGroupStyle", "CertificateDetail", "CertificateVerificationResults", "ContentVerificationResults", "DocProperties", "EncryptionCipherMode", "EncryptionProviderDetail", "MailFormat", "MsoAlertButtonType", "MsoAlertCancelType", "MsoAlertDefaultType", "MsoAlertIconType", "MsoAlignCmd", "MsoAnimationType", "MsoAppLanguageID", "MsoArrowheadLength", "MsoArrowheadStyle", "MsoArrowheadWidth", "MsoAutomationSecurity", "MsoAutoShapeType", "MsoAutoSize", "MsoBackgroundStyleIndex", "MsoBalloonButtonType", "MsoBalloonErrorType", "MsoBalloonType", "MsoBarPosition", "MsoBarProtection", "MsoBarRow", "MsoBarType", "MsoBaselineAlignment", "MsoBevelType", "MsoBlackWhiteMode", "MsoBlogCategorySupport", "MsoBlogImageType", "MsoBulletType", "MsoButtonSetType", "MsoButtonState", "MsoButtonStyle", "MsoButtonStyleHidden", "MsoCalloutAngleType", "MsoCalloutDropType", "MsoCalloutType", "MsoCharacterSet", "MsoChartElementType", "MsoClipboardFormat", "MsoColorType", "MsoComboStyle", "MsoCommandBarButtonHyperlinkType", "MsoCondition", "MsoConnector", "MsoConnectorType", "MsoContactCardAddressType", "MsoContactCardStyle", "MsoContactCardType", "MsoControlOLEUsage", "MsoControlType", "MsoCTPDockPosition", "MsoCTPDockPositionRestrict", "MsoCustomXMLNodeType", "MsoCustomXMLValidationErrorType", "MsoDateTimeFormat", "MsoDiagramNodeType", "MsoDiagramType", "MsoDistributeCmd", "MsoDocInspectorStatus", "MsoDocProperties", "MsoEditingType", "MsoEncoding", "MsoExtraInfoMethod", "MsoExtrusionColorType", "MsoFarEastLineBreakLanguageID", "MsoFeatureInstall", "MsoFileDialogType", "MsoFileDialogView", "MsoFileFindListBy", "MsoFileFindOptions", "MsoFileFindSortBy", "MsoFileFindView", "MsoFileNewAction", "MsoFileNewSection", "MsoFileType", "MsoFileValidationMode", "MsoFillType", "MsoFilterComparison", "MsoFilterConjunction", "MsoFlipCmd", "MsoFontLanguageIndex", "MsoGradientColorType", "MsoGradientStyle", "MsoHorizontalAnchor", "MsoHTMLProjectOpen", "MsoHTMLProjectState", "MsoHyperlinkType", "MsoIconType", "MsoIodGroup", "MsoLanguageID", "MsoLanguageIDHidden", "MsoLastModified", "MsoLightRigType", "MsoLineDashStyle", "MsoLineStyle", "MsoMenuAnimation", "MsoMetaPropertyType", "MsoMixedType", "MsoModeType", "MsoMoveRow", "MsoNumberedBulletStyle", "MsoOLEMenuGroup", "MsoOrgChartLayoutType", "MsoOrgChartOrientation", "MsoOrientation", "MsoParagraphAlignment", "MsoPathFormat", "MsoPatternType", "MsoPermission", "MsoPickerField", "MsoPictureColorType", "MsoPictureEffectType", "MsoPresetCamera", "MsoPresetExtrusionDirection", "MsoPresetGradientType", "MsoPresetLightingDirection", "MsoPresetLightingSoftness", "MsoPresetMaterial", "MsoPresetTextEffect", "MsoPresetTextEffectShape", "MsoPresetTexture", "MsoPresetThreeDFormat", "MsoReflectionType", "MsoRelativeNodePosition", "MsoScaleFrom", "MsoScreenSize", "MsoScriptLanguage", "MsoScriptLocation", "MsoSearchIn", "MsoSegmentType", "MsoShadowStyle", "MsoShadowType", "MsoShapeStyleIndex", "MsoShapeType", "MsoSharedWorkspaceTaskPriority", "MsoSharedWorkspaceTaskStatus", "MsoSignatureSubset", "MsoSmartArtNodePosition", "MsoSmartArtNodeType", "MsoSoftEdgeType", "MsoSortBy", "MsoSortOrder", "MsoSyncAvailableType", "MsoSyncCompareType", "MsoSyncConflictResolutionType", "MsoSyncErrorType", "MsoSyncEventType", "MsoSyncStatusType", "MsoSyncVersionType", "MsoTabStopType", "MsoTargetBrowser", "MsoTextCaps", "MsoTextChangeCase", "MsoTextCharWrap", "MsoTextDirection", "MsoTextEffectAlignment", "MsoTextFontAlign", "MsoTextOrientation", "MsoTextStrike", "MsoTextTabAlign", "MsoTextUnderlineType", "MsoTextureAlignment", "MsoTextureType", "MsoThemeColorIndex", "MsoThemeColorSchemeIndex", "MsoTriState", "MsoVerticalAnchor", "MsoWarpFormat", "MsoWizardActType", "MsoWizardMsgType", "MsoZOrderCmd", "RibbonControlSize", "SignatureDetail", "SignatureLineImage", "SignatureProviderDetail", "SignatureType", "XlAxisCrosses", "XlAxisGroup", "XlAxisType", "XlBarShape", "XlBorderWeight", "XlCategoryType", "XlChartElementPosition", "XlChartItem", "XlChartOrientation", "XlChartPictureType", "XlChartSplitType", "XlChartType", "XlColorIndex", "XlConstants", "XlDataLabelPosition", "XlDataLabelsType", "XlDisplayBlanksAs", "XlDisplayUnit", "XlEndStyleCap", "XlErrorBarDirection", "XlErrorBarInclude", "XlErrorBarType", "XlHAlign", "XlLegendPosition", "XlMarkerStyle", "XlPieSliceIndex", "XlPieSliceLocation", "XlPivotFieldOrientation", "XlReadingOrder", "XlRowCol", "XlScaleType", "XlSizeRepresents", "XlTickLabelOrientation", "XlTickLabelPosition", "XlTickMark", "XlTimeUnit", "XlTrendlineType", "XlUnderlineStyle", "XlVAlign", "Constants", "XlAboveBelow", "XlActionType", "XlApplicationInternational", "XlApplyNamesOrder", "XlArabicModes", "XlArrangeStyle", "XlArrowHeadLength", "XlArrowHeadStyle", "XlArrowHeadWidth", "XlAutoFillType", "XlAutoFilterOperator", "XlAxisCrosses", "XlAxisGroup", "XlAxisType", "XlBackground", "XlBarShape", "XlBordersIndex", "XlBorderWeight", "XlBuiltInDialog", "XlCalcFor", "XlCalculatedMemberType", "XlCalculation", "XlCalculationInterruptKey", "XlCalculationState", "XlCategoryType", "XlCellInsertionMode", "XlCellType", "XlChartElementPosition", "XlChartGallery", "XlChartItem", "XlChartLocation", "XlChartPicturePlacement", "XlChartPictureType", "XlChartSplitType", "XlChartType", "XlCheckInVersionType", "XlClipboardFormat", "XlCmdType", "XlColorIndex", "XlColumnDataType", "XlCommandUnderlines", "XlCommentDisplayMode", "XlConditionValueTypes", "XlConnectionType", "XlConsolidationFunction", "XlContainsOperator", "XlCopyPictureFormat", "XlCorruptLoad", "XlCreator", "XlCredentialsMethod", "XlCubeFieldSubType", "XlCubeFieldType", "XlCutCopyMode", "XlCVError", "XlDataLabelPosition", "XlDataLabelSeparator", "XlDataLabelsType", "XlDataSeriesDate", "XlDataSeriesType", "XlDeleteShiftDirection", "XlDirection", "XlDisplayBlanksAs", "XlDisplayDrawingObjects", "XlDisplayUnit", "XlDupeUnique", "XlDVAlertStyle", "XlDVType", "XlDynamicFilterCriteria", "XlEditionFormat", "XlEditionOptionsOption", "XlEditionType", "XlEnableCancelKey", "XlEnableSelection", "XlEndStyleCap", "XlErrorBarDirection", "XlErrorBarInclude", "XlErrorBarType", "XlErrorChecks", "XlFileAccess", "XlFileFormat", "XlFillWith", "XlFilterAction", "XlFilterAllDatesInPeriod", "XlFindLookIn", "XlFixedFormatQuality", "XlFixedFormatType", "XlFormatConditionOperator", "XlFormatConditionType", "XlFormatFilterTypes", "XlFormControl", "XlFormulaLabel", "XlGenerateTableRefs", "XlGradientFillType", "XlHAlign", "XlHebrewModes", "XlHighlightChangesTime", "XlHtmlType", "XlIconSet", "XlIMEMode", "XlImportDataAs", "XlInsertFormatOrigin", "XlInsertShiftDirection", "XlLayoutFormType", "XlLayoutRowType", "XlLegendPosition", "XlLineStyle", "XlLink", "XlLinkInfo", "XlLinkInfoType", "XlLinkStatus", "XlLinkType", "XlListConflict", "XlListDataType", "XlListObjectSourceType", "XlLocationInTable", "XlLookAt", "XlLookFor", "XlMailSystem", "XlMarkerStyle", "XlMeasurementUnits", "XlMouseButton", "XlMousePointer", "XlMSApplication", "XlObjectSize", "XlOLEType", "XlOLEVerb", "XlOrder", "XlOrientation", "XlPageBreak", "XlPageBreakExtent", "XlPageOrientation", "XlPaperSize", "XlParameterDataType", "XlParameterType", "XlPasteSpecialOperation", "XlPasteType", "XlPattern", "XlPhoneticAlignment", "XlPhoneticCharacterType", "XlPictureAppearance", "XlPictureConvertorType", "XlPivotCellType", "XlPivotConditionScope", "XlPivotFieldCalculation", "XlPivotFieldDataType", "XlPivotFieldOrientation", "XlPivotFilterType", "XlPivotFormatType", "XlPivotLineType", "XlPivotTableMissingItems", "XlPivotTableSourceType", "XlPivotTableVersionList", "XlPlacement", "XlPlatform", "XlPrintErrors", "XlPrintLocation", "XlPriority", "XlPropertyDisplayedIn", "XlPTSelectionMode", "XlQueryType", "XlRangeAutoFormat", "XlRangeValueDataType", "XlReferenceStyle", "XlReferenceType", "XlRemoveDocInfoType", "XlRgbColor", "XlRobustConnect", "XlRoutingSlipDelivery", "XlRoutingSlipStatus", "XlRowCol", "XlRunAutoMacro", "XlSaveAction", "XlSaveAsAccessMode", "XlSaveConflictResolution", "XlScaleType", "XlSearchDirection", "XlSearchOrder", "XlSearchWithin", "XlSheetType", "XlSheetVisibility", "XlSizeRepresents", "XlSmartTagControlType", "XlSmartTagDisplayMode", "XlSortDataOption", "XlSortMethod", "XlSortMethodOld", "XlSortOn", "XlSortOrder", "XlSortOrientation", "XlSortType", "XlSourceType", "XlSpeakDirection", "XlSpecialCellsValue", "XlStdColorScale", "XlSubscribeToFormat", "XlSubtototalLocationType", "XlSummaryColumn", "XlSummaryReportType", "XlSummaryRow", "XlTableStyleElementType", "XlTabPosition", "XlTextParsingType", "XlTextQualifier", "XlTextVisualLayoutType", "XlThemeColor", "XlThemeFont", "XlThreadMode", "XlTickLabelOrientation", "XlTickLabelPosition", "XlTickMark", "XlTimePeriods", "XlTimeUnit", "XlToolbarProtection", "XlTopBottom", "XlTotalsCalculation", "XlTrendlineType", "XlUnderlineStyle", "XlUpdateLinks", "XlVAlign", "XlWBATemplate", "XlWebFormatting", "XlWebSelectionType", "XlWindowState", "XlWindowType", "XlWindowView", "XlXLMMacroType", "XlXmlExportResult", "XlXmlImportResult", "XlXmlLoadOption", "XlYesNoGuess" };

        /// <summary>说明键值对
        /// </summary>
        string[][] _astrSummary = new string[][] {  
                  #region 集合
new string[] { "Add","定义新名称。"},
new string[] { "Item","从 Names 集合返回一个 Name 对象。"},
new string[] { "Application","如果不使用对象识别符，则该属性返回一个 Application 对象，该对象表示 Microsoft Excel 应用程序。如果使用对象识别符，则该属性返回一个表示指定对象（可对一个 OLE 自动操作对象使用本属性来返回该对象的应用程序）创建者的 Application 对象。只读。"},
new string[] { "Count","返回一个 Long 值，它代表集合中对象的数量。"},
new string[] { "Parent","返回指定对象的父对象。只读。"}
        };
                  #endregion

        /// <summary>Excel 对象名称集合
        /// </summary>
        List<string> _lstExcelObjectName = new List<string>(new string[] { "AboveAverage", "Actions", "AddIns", "AllowEditRange", "Application", "AutoCorrect", "AutoRecover", "Axis", "Border", "CalculatedFields", "CalculatedMember", "CalloutFormat", "Characters", "ChartArea", "ChartFillFormat", "ChartGroup", "ChartObject", "Charts", "ChartView", "ColorScale", "ColorScaleCriterion", "ColorStops", "Comments", "Connections", "ControlFormat", "CubeFields", "CustomProperty", "CustomViews", "DataLabel", "DataTable", "Dialog", "DialogSheetView", "DownBars", "Error", "ErrorCheckingOptions", "FillFormat", "Filters", "Font", "FormatCondition", "FreeformBuilder", "Gridlines", "HeaderFooter", "HPageBreak", "Hyperlink", "Icon", "IconCriterion", "IconSetCondition", "Interior", "IRtdServer", "IRTDUpdateEvent", "Legend", "LegendEntry", "LinearGradient", "LinkFormat", "ListColumns", "ListObject", "ListRow", "Mailer", "MultiThreadedCalculation", "Names", "ODBCError", "OLEDBConnection", "OLEDBErrors", "OLEObject", "Outline", "Pages", "Pane", "Parameter", "Phonetic", "PictureFormat", "PivotCache", "PivotCell", "PivotFields", "PivotFilters", "PivotFormulas", "PivotItemList", "PivotLayout", "PivotLineCells", "PivotTable", "PlotArea", "Points", "PublishObject", "PublishObjects", "QueryTables", "Ranges", "RecentFiles", "Research", "RTD", "Scenarios", "SeriesCollection", "ServerViewableItems", "Shape", "ShapeNodes", "Shapes", "SheetViews", "SmartTagAction", "SmartTagOptions", "SmartTagRecognizers", "Sort", "SortFields", "Speech", "Style", "Tab", "TableStyleElement", "TableStyles", "TextFrame", "ThreeDFormat", "Top10", "Trendline", "UniqueValues", "UsedObjects", "UserAccessList", "ValueCollection", "VPageBreaks", "Watch", "WebOptions", "Windows", "WorkbookConnection", "Worksheet", "Worksheets", "XmlDataBinding", "XmlMaps", "XmlNamespaces", "XmlSchemas", "Action", "AddIn", "Adjustments", "AllowEditRanges", "Areas", "AutoFilter", "Axes", "AxisTitle", "Borders", "CalculatedItems", "CalculatedMembers", "CellFormat", "Chart", "ChartColorFormat", "ChartFormat", "ChartGroups", "ChartObjects", "ChartTitle", "ColorFormat", "ColorScaleCriteria", "ColorStop", "Comment", "ConditionValue", "ConnectorFormat", "CubeField", "CustomProperties", "CustomView", "Databar", "DataLabels", "DefaultWebOptions", "Dialogs", "DisplayUnitLabel", "DropLines", "ErrorBars", "Errors", "Filter", "Floor", "FormatColor", "FormatConditions", "Graphic", "GroupShapes", "HiLoLines", "HPageBreaks", "Hyperlinks", "IconCriteria", "IconSet", "IconSets", "InteriorGradientStop", "InteriorGradientStops", "LeaderLines", "LegendEntries", "LegendKey", "LineFormat", "ListColumn", "ListDataFormat", "ListObjects", "ListRows", "ModuleView", "Name", "ODBCConnection", "ODBCErrors", "OLEDBError", "OLEFormat", "OLEObjects", "Page", "PageSetup", "Panes", "Parameters", "Phonetics", "PivotAxis", "PivotCaches", "PivotField", "PivotFilter", "PivotFormula", "PivotItem", "PivotItems", "PivotLine", "PivotLines", "PivotTables", "Point", "Protection", "PublishedServerItems", "QueryTable", "Range", "RecentFile", "RectangularGradient", "RoutingSlip", "Scenario", "Series", "SeriesLines", "ShadowFormat", "ShapeNode", "ShapeRange", "Sheets", "SmartTag", "SmartTagActions", "SmartTagRecognizer", "SmartTags", "SortField", "SoundNote", "SpellingOptions", "Styles", "TableStyle", "TableStyleElements", "TextEffectFormat", "TextFrame2", "TickLabels", "TreeviewControl", "Trendlines", "UpBars", "UserAccess", "Validation", "VPageBreak", "Walls", "Watches", "Window", "Workbook", "Workbooks", "WorksheetFunction", "WorksheetView", "XmlMap", "XmlNamespace", "XmlSchema", "XPath" });
        #endregion 固定Array或List

        public 辅助工具()
        {
            InitializeComponent();
        }

        #region 函数
        /// <summary>判断首字母大写
        /// </summary>
        public bool IsCaseWord(string value)
        {
            if (value.Trim() == "") return false;

            if (((int)value.ToCharArray()[0]) >= 65 && ((int)value.ToCharArray()[0]) <= 90)
                return true;
            else
                return false;
        }

        /// <summary>判断是否是个枚举
        /// </summary>
        public bool IsEnum(string value)
        {
            List<string> lstEnumName = new List<string>(_astrEnumName);

            if (lstEnumName.Contains(value))
                return true;
            else
                return false;
        }

        /// <summary>得到函数参数数组的代码
        /// </summary>
        /// <param name="FunAbb">函数签名缩写</param>
        /// <returns></returns>
        public string GiveTheParmArrayCode(string FunAbb)
        {
            StringBuilder sbRetVal = new StringBuilder();
            StringBuilder sbParmUT = new StringBuilder();

            //找出括号中的那一段
            string strVal = FunAbb.Substring(FunAbb.IndexOf('(') + 1, FunAbb.Length - FunAbb.IndexOf('(') - (FunAbb.Length - FunAbb.IndexOf(')')) - 1);
            if (strVal.Trim() == "") return "";

            string[] astrParmNC = strVal.Trim().Split(',');

            //分拆以逗号分隔
            foreach (string strParmNC in astrParmNC)
            {
                //分拆以空格分隔  astrParms[1]  为参数名称
                string[] astrParms = strParmNC.Trim().Split(' ');

                if (strParmNC.Contains("Type.Missing"))
                    sbParmUT.AppendLine("                " + astrParms[1] + " == null ? System.Type.Missing : " + astrParms[1] + ",");
                else
                    sbParmUT.AppendLine("                " + astrParms[1] + ",");
            }

            if (astrParmNC.Length > 0)
            {
                sbRetVal.AppendLine("            _objaParameters = new object[" + astrParmNC.Length + "] {");
                sbRetVal.AppendLine(sbParmUT.ToString().Substring(0, sbParmUT.ToString().Length - (sbParmUT.ToString().Length - sbParmUT.ToString().LastIndexOf(','))));
                sbRetVal.AppendLine("            };");
            }

            if (sbRetVal.ToString().Contains("System.Type.Missing") && astrParmNC.Length > 1)
                return sbRetVal.ToString();
            else
                return sbRetVal.ToString().Replace(Environment.NewLine, "").Replace("                ", " ").Replace("            }", " }");
        }
        #endregion 函数

        private void 找出所有的枚举_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sbAll = new StringBuilder();
                DirectoryInfo folder = new DirectoryInfo(textBox1.Text);
                FileInfo[] fileInfos = folder.GetFiles();
                progressBar1.Maximum = fileInfos.Length;
                progressBar1.Value = progressBar1.Minimum = 0;

                foreach (FileInfo fileInfo in fileInfos)
                {
                    StringBuilder sbSub = new StringBuilder();
                    int maxSearchLine = 10;
                    StreamReader sReader = new StreamReader(fileInfo.FullName);
                    bool appandLine = false;
                    bool endAppand = false;
                    string newLine = "";

                    while ((newLine = sReader.ReadLine()) != null)
                    {
                        if (maxSearchLine <= 0 && appandLine == false) break;
                        if (appandLine == false && newLine.Contains("    public enum ")) appandLine = true;

                        if (appandLine && endAppand == false)
                            sbSub.AppendLine(newLine);

                        if (appandLine == true && newLine.Contains("}")) endAppand = true;

                        maxSearchLine--;
                    }

                    if (appandLine)
                        sbAll.AppendLine(sbSub.ToString());

                    progressBar1.Value++;
                }

                textBox2.Text = sbAll.ToString();
                progressBar1.Value = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void 找出枚举名称_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string strLine in textBox2.Lines)
            {
                if (strLine.StartsWith("@@@@@@@@"))
                    sb.Append(strLine.Replace("@@@@@@@@", "") + ",");
            }

            textBox3.Text = sb.ToString();
        }

        private void 找出属性_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string strLine in textBox2.Lines)
            {
                if (!(strLine.Trim().StartsWith("[") || strLine.Trim().StartsWith("//")))
                {
                    sb.AppendLine(strLine.Trim().Replace("dynamic", "object"));

                }
            }

            textBox3.Text = sb.ToString();
        }

        private void 属性代码生成_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicSummary = new Dictionary<string, string>();
            foreach (string[] astrSum in _astrSummary)
                dicSummary.Add(astrSum[0], astrSum[1]);

            string strOBJName = textBox1.Text.Trim();
            StringBuilder sbAll = new StringBuilder();

            foreach (string strLine in textBox2.Lines)
            {
                if (strLine.Trim().EndsWith("get; }") || strLine.Trim().EndsWith("set; }"))
                {
                    string strNewLine = strLine.Trim();// strLine.Trim().Replace("dynamic", "object");
                    string[] parms = strNewLine.Split(' ');//第一个为类型名称，第二个为属性名称
                    StringBuilder sbProp = new StringBuilder();

                    bool isObject = (parms[0] == "dynamic");// (parms[0] == "object");
                    bool isString = (parms[0] == "string");
                    bool isEnum = IsEnum(parms[0]);
                    bool isClass = IsCaseWord(parms[0]);
                    bool hasGet = strNewLine.Contains("get");
                    bool hasSet = strNewLine.Contains("set");
                    string getCode = string.Format("{0}.GetType().InvokeMember(\"{1}\", BindingFlags.GetProperty, null, {0}, null)", strOBJName, parms[1]);
                    string setCode = "    set { " + strOBJName + ".GetType().InvokeMember(\"" + parms[1] + "\", BindingFlags.SetProperty, null, " + strOBJName + ", new object[1] { value }); }";
                    string strSummary = dicSummary.ContainsKey(parms[1]) ? dicSummary[parms[1]] : "";
                    string strAddText = "";

                    sbProp.AppendLine("/// <summary>" + strSummary);
                    sbProp.AppendLine("/// </summary>");
                    sbProp.AppendLine("public " + parms[0] + " " + parms[1]);
                    sbProp.AppendLine("{");

                    if (strSummary.Contains("Nothing")) sbProp.AppendLine("// 有 Nothing");

                    if (hasGet)
                    {
                        if (isObject)
                        {
                            strAddText = "    get { return " + getCode + ";}";
                        }
                        else
                        {
                            strAddText = getCode;

                            if (isString)//string 类型
                            { strAddText = strAddText + ".ToString()"; }
                            else if (isEnum)//枚举
                            { strAddText = "(" + parms[0] + ")" + strAddText; }
                            else if (isClass)//EXCEL对象
                            { strAddText = "new " + parms[0] + "(" + strAddText + ")"; }
                            else//普通的变量
                            { strAddText = "(" + parms[0] + ")" + strAddText; }

                            strAddText = "    get { return " + strAddText + ";}";
                        }

                        sbProp.AppendLine(strAddText);
                    }
                    if (hasSet)
                        sbProp.AppendLine(setCode);
                    sbProp.AppendLine("}");

                    sbAll.AppendLine(sbProp.ToString());
                }
            }

            textBox3.Text = sbAll.ToString();
        }

        private void 方法代码生成_Click(object sender, EventArgs e)
        {
            StringBuilder sbResult = new StringBuilder();
            Dictionary<string, string> dicSummary = new Dictionary<string, string>();
            foreach (string[] astrSum in _astrSummary)
                dicSummary.Add(astrSum[0], astrSum[1]);

            string strOBJName = textBox1.Text.Trim();
            sbResult.AppendLine("        #region 生成代码");

            foreach (string strLine in textBox2.Lines)
            {
                if (strLine.Trim().EndsWith(");") && !strLine.Trim().StartsWith("//"))
                {
                    string strFunHead = strLine.Trim();// strLine.Trim().Replace("dynamic", "object");

                    if (!(strFunHead.StartsWith("[") || strFunHead.StartsWith("//")))
                    {
                        //得到返回类型及方法名
                        string[] astrTypeAndFunName = strFunHead.Replace("(", " ").Split(' ');
                        string typeName = astrTypeAndFunName[0];
                        string funName = astrTypeAndFunName[1];

                        //函数参数数组的代码
                        string parmArrayCode = GiveTheParmArrayCode(strFunHead);
                        //注释
                        string strSummary = dicSummary.ContainsKey(funName) ? dicSummary[funName] : "";

                        strFunHead = "public " + strFunHead.Replace("= Type.Missing", "= null").Replace(";", "");

                        //返回函数代码
                        string retCode = string.Format("{0}.GetType().InvokeMember(\"{1}\", BindingFlags.InvokeMethod, null, {0}, {2})", strOBJName, funName, parmArrayCode.Trim() == "" ? "null" : "_objaParameters");
                        if (typeName == "void")
                            retCode = retCode + ";";
                        else if (typeName == "dynamic")// (typeName == "object")
                            retCode = "return " + retCode + ";";
                        else if (typeName == "string")
                            retCode = "return " + retCode + ".ToString();";
                        else if (_lstExcelObjectName.Contains(typeName))
                            retCode = "return new " + typeName + "(" + retCode + ");";
                        else
                            retCode = "return (" + typeName + ")" + retCode + ";";

                        //只要首字母大写的函数
                        if (IsCaseWord(funName))
                        {
                            sbResult.AppendLine("        /// <summary>" + strSummary);
                            sbResult.AppendLine("        /// </summary>");
                            sbResult.AppendLine("        " + strFunHead);
                            sbResult.AppendLine("        {");
                            if (parmArrayCode.Trim() != "") sbResult.AppendLine(parmArrayCode);
                            sbResult.AppendLine("            " + retCode);
                            sbResult.AppendLine("        }");
                            sbResult.AppendLine();
                        }
                    }
                }
            }

            sbResult.AppendLine("        #endregion 生成代码");
            textBox3.Text = sbResult.ToString();
        }

        private void 修正注释标签_Click(object sender, EventArgs e)
        {
            StringBuilder sbResult = new StringBuilder();
            bool blnHasHead = false;

            foreach (string strLine in textBox2.Lines)
            {
                if (strLine.Contains("/// <summary>"))
                {
                    if (blnHasHead)
                    {
                        sbResult.AppendLine(strLine.Replace("/// <summary>", "/// </summary>"));
                        blnHasHead = false;
                    }
                    else
                    {
                        sbResult.AppendLine(strLine);
                        blnHasHead = true;
                    }
                }
                else
                {
                    if (strLine.Contains("/// </summary>"))
                        blnHasHead = false;

                    sbResult.AppendLine(strLine);
                }
            }

            textBox3.Text = sbResult.ToString();
        }

        private void 复制到网格_Click(object sender, EventArgs e)
        {
            try
            {
                string pasteText = Clipboard.GetText();
                if (string.IsNullOrEmpty(pasteText))
                {
                    return;
                }

                string[] lines = pasteText.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] strs = line.Split(new char[] { '\t' });
                    dataGridView1.Rows.Add(strs);
                }
            }
            catch (Exception) { }
        }
    }
}
