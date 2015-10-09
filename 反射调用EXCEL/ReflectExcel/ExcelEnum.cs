namespace ReflectOffice.Excel
{
    public enum Constants
    {
        xl3DBar = -4099,
        xl3DEffects1 = 13,
        xl3DEffects2 = 14,
        xl3DSurface = -4103,
        xlAbove = 0,
        xlAccounting1 = 4,
        xlAccounting2 = 5,
        xlAccounting3 = 6,
        xlAccounting4 = 0x11,
        xlAdd = 2,
        xlAll = -4104,
        xlAllExceptBorders = 7,
        xlAutomatic = -4105,
        xlBar = 2,
        xlBelow = 1,
        xlBidi = -5000,
        xlBidiCalendar = 3,
        xlBoth = 1,
        xlBottom = -4107,
        xlCascade = 7,
        xlCenter = -4108,
        xlCenterAcrossSelection = 7,
        xlChart4 = 2,
        xlChartSeries = 0x11,
        xlChartShort = 6,
        xlChartTitles = 0x12,
        xlChecker = 9,
        xlCircle = 8,
        xlClassic1 = 1,
        xlClassic2 = 2,
        xlClassic3 = 3,
        xlClosed = 3,
        xlColor1 = 7,
        xlColor2 = 8,
        xlColor3 = 9,
        xlColumn = 3,
        xlCombination = -4111,
        xlComplete = 4,
        xlConstants = 2,
        xlContents = 2,
        xlContext = -5002,
        xlCorner = 2,
        xlCrissCross = 0x10,
        xlCross = 4,
        xlCustom = -4114,
        xlDebugCodePane = 13,
        xlDefaultAutoFormat = -1,
        xlDesktop = 9,
        xlDiamond = 2,
        xlDirect = 1,
        xlDistributed = -4117,
        xlDivide = 5,
        xlDoubleAccounting = 5,
        xlDoubleClosed = 5,
        xlDoubleOpen = 4,
        xlDoubleQuote = 1,
        xlDrawingObject = 14,
        xlEntireChart = 20,
        xlExcelMenus = 1,
        xlExtended = 3,
        xlFill = 5,
        xlFirst = 0,
        xlFixedValue = 1,
        xlFloating = 5,
        xlFormats = -4122,
        xlFormula = 5,
        xlFullScript = 1,
        xlGeneral = 1,
        xlGray16 = 0x11,
        xlGray25 = -4124,
        xlGray50 = -4125,
        xlGray75 = -4126,
        xlGray8 = 0x12,
        xlGregorian = 2,
        xlGrid = 15,
        xlGridline = 0x16,
        xlHigh = -4127,
        xlHindiNumerals = 3,
        xlIcons = 1,
        xlImmediatePane = 12,
        xlInside = 2,
        xlInteger = 2,
        xlJustify = -4130,
        xlLast = 1,
        xlLastCell = 11,
        xlLatin = -5001,
        xlLeft = -4131,
        xlLeftToRight = 2,
        xlLightDown = 13,
        xlLightHorizontal = 11,
        xlLightUp = 14,
        xlLightVertical = 12,
        xlList1 = 10,
        xlList2 = 11,
        xlList3 = 12,
        xlLocalFormat1 = 15,
        xlLocalFormat2 = 0x10,
        xlLogicalCursor = 1,
        xlLong = 3,
        xlLotusHelp = 2,
        xlLow = -4134,
        xlLTR = -5003,
        xlMacrosheetCell = 7,
        xlManual = -4135,
        xlMaximum = 2,
        xlMinimum = 4,
        xlMinusValues = 3,
        xlMixed = 2,
        xlMixedAuthorizedScript = 4,
        xlMixedScript = 3,
        xlModule = -4141,
        xlMultiply = 4,
        xlNarrow = 1,
        xlNextToAxis = 4,
        xlNoDocuments = 3,
        xlNone = -4142,
        xlNotes = -4144,
        xlOff = -4146,
        xlOn = 1,
        xlOpaque = 3,
        xlOpen = 2,
        xlOutside = 3,
        xlPartial = 3,
        xlPartialScript = 2,
        xlPercent = 2,
        xlPlus = 9,
        xlPlusValues = 2,
        xlReference = 4,
        xlRight = -4152,
        xlRTL = -5004,
        xlScale = 3,
        xlSemiautomatic = 2,
        xlSemiGray75 = 10,
        xlShort = 1,
        xlShowLabel = 4,
        xlShowLabelAndPercent = 5,
        xlShowPercent = 3,
        xlShowValue = 2,
        xlSimple = -4154,
        xlSingle = 2,
        xlSingleAccounting = 4,
        xlSingleQuote = 2,
        xlSolid = 1,
        xlSquare = 1,
        xlStar = 5,
        xlStError = 4,
        xlStrict = 2,
        xlSubtract = 3,
        xlSystem = 1,
        xlTextBox = 0x10,
        xlTiled = 1,
        xlTitleBar = 8,
        xlToolbar = 1,
        xlToolbarButton = 2,
        xlTop = -4160,
        xlTopToBottom = 1,
        xlTransparent = 2,
        xlTriangle = 3,
        xlVeryHidden = 2,
        xlVisible = 12,
        xlVisualCursor = 2,
        xlWatchPane = 11,
        xlWide = 3,
        xlWorkbookTab = 6,
        xlWorksheet4 = 1,
        xlWorksheetCell = 3,
        xlWorksheetShort = 5
    }

    public enum XlAboveBelow
    {
        xlAboveAverage,
        xlBelowAverage,
        xlEqualAboveAverage,
        xlEqualBelowAverage,
        xlAboveStdDev,
        xlBelowStdDev
    }

    public enum XlActionType
    {
        xlActionTypeDrillthrough = 0x100,
        xlActionTypeReport = 0x80,
        xlActionTypeRowset = 0x10,
        xlActionTypeUrl = 1
    }

    public enum XlApplicationInternational
    {
        xl24HourClock = 0x21,
        xl4DigitYears = 0x2b,
        xlAlternateArraySeparator = 0x10,
        xlColumnSeparator = 14,
        xlCountryCode = 1,
        xlCountrySetting = 2,
        xlCurrencyBefore = 0x25,
        xlCurrencyCode = 0x19,
        xlCurrencyDigits = 0x1b,
        xlCurrencyLeadingZeros = 40,
        xlCurrencyMinusSign = 0x26,
        xlCurrencyNegative = 0x1c,
        xlCurrencySpaceBefore = 0x24,
        xlCurrencyTrailingZeros = 0x27,
        xlDateOrder = 0x20,
        xlDateSeparator = 0x11,
        xlDayCode = 0x15,
        xlDayLeadingZero = 0x2a,
        xlDecimalSeparator = 3,
        xlGeneralFormatName = 0x1a,
        xlHourCode = 0x16,
        xlLeftBrace = 12,
        xlLeftBracket = 10,
        xlListSeparator = 5,
        xlLowerCaseColumnLetter = 9,
        xlLowerCaseRowLetter = 8,
        xlMDY = 0x2c,
        xlMetric = 0x23,
        xlMinuteCode = 0x17,
        xlMonthCode = 20,
        xlMonthLeadingZero = 0x29,
        xlMonthNameChars = 30,
        xlNoncurrencyDigits = 0x1d,
        xlNonEnglishFunctions = 0x22,
        xlRightBrace = 13,
        xlRightBracket = 11,
        xlRowSeparator = 15,
        xlSecondCode = 0x18,
        xlThousandsSeparator = 4,
        xlTimeLeadingZero = 0x2d,
        xlTimeSeparator = 0x12,
        xlUpperCaseColumnLetter = 7,
        xlUpperCaseRowLetter = 6,
        xlWeekdayNameChars = 0x1f,
        xlYearCode = 0x13
    }

    public enum XlApplyNamesOrder
    {
        xlColumnThenRow = 2,
        xlRowThenColumn = 1
    }

    public enum XlArabicModes
    {
        xlArabicNone,
        xlArabicStrictAlefHamza,
        xlArabicStrictFinalYaa,
        xlArabicBothStrict
    }

    public enum XlArrangeStyle
    {
        xlArrangeStyleCascade = 7,
        xlArrangeStyleHorizontal = -4128,
        xlArrangeStyleTiled = 1,
        xlArrangeStyleVertical = -4166
    }

    public enum XlArrowHeadLength
    {
        xlArrowHeadLengthLong = 3,
        xlArrowHeadLengthMedium = -4138,
        xlArrowHeadLengthShort = 1
    }

    public enum XlArrowHeadStyle
    {
        xlArrowHeadStyleClosed = 3,
        xlArrowHeadStyleDoubleClosed = 5,
        xlArrowHeadStyleDoubleOpen = 4,
        xlArrowHeadStyleNone = -4142,
        xlArrowHeadStyleOpen = 2
    }

    public enum XlArrowHeadWidth
    {
        xlArrowHeadWidthMedium = -4138,
        xlArrowHeadWidthNarrow = 1,
        xlArrowHeadWidthWide = 3
    }

    public enum XlAutoFillType
    {
        xlFillDefault,
        xlFillCopy,
        xlFillSeries,
        xlFillFormats,
        xlFillValues,
        xlFillDays,
        xlFillWeekdays,
        xlFillMonths,
        xlFillYears,
        xlLinearTrend,
        xlGrowthTrend
    }

    public enum XlAutoFilterOperator
    {
        xlAnd = 1,
        xlBottom10Items = 4,
        xlBottom10Percent = 6,
        xlFilterAutomaticFontColor = 13,
        xlFilterCellColor = 8,
        xlFilterDynamic = 11,
        xlFilterFontColor = 9,
        xlFilterIcon = 10,
        xlFilterNoFill = 12,
        xlFilterNoIcon = 14,
        xlFilterValues = 7,
        xlOr = 2,
        xlTop10Items = 3,
        xlTop10Percent = 5
    }

    public enum XlAxisCrosses
    {
        xlAxisCrossesAutomatic = -4105,
        xlAxisCrossesCustom = -4114,
        xlAxisCrossesMaximum = 2,
        xlAxisCrossesMinimum = 4
    }

    public enum XlAxisGroup
    {
        xlPrimary = 1,
        xlSecondary = 2
    }

    public enum XlAxisType
    {
        xlCategory = 1,
        xlSeriesAxis = 3,
        xlValue = 2
    }

    public enum XlBackground
    {
        xlBackgroundAutomatic = -4105,
        xlBackgroundOpaque = 3,
        xlBackgroundTransparent = 2
    }

    public enum XlBarShape
    {
        xlBox,
        xlPyramidToPoint,
        xlPyramidToMax,
        xlCylinder,
        xlConeToPoint,
        xlConeToMax
    }

    public enum XlBordersIndex
    {
        xlDiagonalDown = 5,
        xlDiagonalUp = 6,
        xlEdgeBottom = 9,
        xlEdgeLeft = 7,
        xlEdgeRight = 10,
        xlEdgeTop = 8,
        xlInsideHorizontal = 12,
        xlInsideVertical = 11
    }

    public enum XlBorderWeight
    {
        xlHairline = 1,
        xlMedium = -4138,
        xlThick = 4,
        xlThin = 2
    }

    public enum XlBuiltInDialog
    {
        _xlDialogChartSourceData = 0x21d,
        _xlDialogPhonetic = 0x21a,
        xlDialogActivate = 0x67,
        xlDialogActiveCellFont = 0x1dc,
        xlDialogAddChartAutoformat = 390,
        xlDialogAddinManager = 0x141,
        xlDialogAlignment = 0x2b,
        xlDialogApplyNames = 0x85,
        xlDialogApplyStyle = 0xd4,
        xlDialogAppMove = 170,
        xlDialogAppSize = 0xab,
        xlDialogArrangeAll = 12,
        xlDialogAssignToObject = 0xd5,
        xlDialogAssignToTool = 0x125,
        xlDialogAttachText = 80,
        xlDialogAttachToolbars = 0x143,
        xlDialogAutoCorrect = 0x1e5,
        xlDialogAxes = 0x4e,
        xlDialogBorder = 0x2d,
        xlDialogCalculation = 0x20,
        xlDialogCellProtection = 0x2e,
        xlDialogChangeLink = 0xa6,
        xlDialogChartAddData = 0x188,
        xlDialogChartLocation = 0x20f,
        xlDialogChartOptionsDataLabelMultiple = 0x2d4,
        xlDialogChartOptionsDataLabels = 0x1f9,
        xlDialogChartOptionsDataTable = 0x1fa,
        xlDialogChartSourceData = 540,
        xlDialogChartTrend = 350,
        xlDialogChartType = 0x20e,
        xlDialogChartWizard = 0x120,
        xlDialogCheckboxProperties = 0x1b3,
        xlDialogClear = 0x34,
        xlDialogColorPalette = 0xa1,
        xlDialogColumnWidth = 0x2f,
        xlDialogCombination = 0x49,
        xlDialogConditionalFormatting = 0x247,
        xlDialogConsolidate = 0xbf,
        xlDialogCopyChart = 0x93,
        xlDialogCopyPicture = 0x6c,
        xlDialogCreateList = 0x31c,
        xlDialogCreateNames = 0x3e,
        xlDialogCreatePublisher = 0xd9,
        xlDialogCustomizeToolbar = 0x114,
        xlDialogCustomViews = 0x1ed,
        xlDialogDataDelete = 0x24,
        xlDialogDataLabel = 0x17b,
        xlDialogDataLabelMultiple = 0x2d3,
        xlDialogDataSeries = 40,
        xlDialogDataValidation = 0x20d,
        xlDialogDefineName = 0x3d,
        xlDialogDefineStyle = 0xe5,
        xlDialogDeleteFormat = 0x6f,
        xlDialogDeleteName = 110,
        xlDialogDemote = 0xcb,
        xlDialogDisplay = 0x1b,
        xlDialogDocumentInspector = 0x35e,
        xlDialogEditboxProperties = 0x1b6,
        xlDialogEditColor = 0xdf,
        xlDialogEditDelete = 0x36,
        xlDialogEditionOptions = 0xfb,
        xlDialogEditSeries = 0xe4,
        xlDialogErrorbarX = 0x1cf,
        xlDialogErrorbarY = 0x1d0,
        xlDialogErrorChecking = 0x2dc,
        xlDialogEvaluateFormula = 0x2c5,
        xlDialogExternalDataProperties = 530,
        xlDialogExtract = 0x23,
        xlDialogFileDelete = 6,
        xlDialogFileSharing = 0x1e1,
        xlDialogFillGroup = 200,
        xlDialogFillWorkgroup = 0x12d,
        xlDialogFilter = 0x1bf,
        xlDialogFilterAdvanced = 370,
        xlDialogFindFile = 0x1db,
        xlDialogFont = 0x1a,
        xlDialogFontProperties = 0x17d,
        xlDialogFormatAuto = 0x10d,
        xlDialogFormatChart = 0x1d1,
        xlDialogFormatCharttype = 0x1a7,
        xlDialogFormatFont = 150,
        xlDialogFormatLegend = 0x58,
        xlDialogFormatMain = 0xe1,
        xlDialogFormatMove = 0x80,
        xlDialogFormatNumber = 0x2a,
        xlDialogFormatOverlay = 0xe2,
        xlDialogFormatSize = 0x81,
        xlDialogFormatText = 0x59,
        xlDialogFormulaFind = 0x40,
        xlDialogFormulaGoto = 0x3f,
        xlDialogFormulaReplace = 130,
        xlDialogFunctionWizard = 450,
        xlDialogGallery3dArea = 0xc1,
        xlDialogGallery3dBar = 0x110,
        xlDialogGallery3dColumn = 0xc2,
        xlDialogGallery3dLine = 0xc3,
        xlDialogGallery3dPie = 0xc4,
        xlDialogGallery3dSurface = 0x111,
        xlDialogGalleryArea = 0x43,
        xlDialogGalleryBar = 0x44,
        xlDialogGalleryColumn = 0x45,
        xlDialogGalleryCustom = 0x184,
        xlDialogGalleryDoughnut = 0x158,
        xlDialogGalleryLine = 70,
        xlDialogGalleryPie = 0x47,
        xlDialogGalleryRadar = 0xf9,
        xlDialogGalleryScatter = 0x48,
        xlDialogGoalSeek = 0xc6,
        xlDialogGridlines = 0x4c,
        xlDialogImportTextFile = 0x29a,
        xlDialogInsert = 0x37,
        xlDialogInsertHyperlink = 0x254,
        xlDialogInsertNameLabel = 0x1f0,
        xlDialogInsertObject = 0x103,
        xlDialogInsertPicture = 0x156,
        xlDialogInsertTitle = 380,
        xlDialogLabelProperties = 0x1b4,
        xlDialogListboxProperties = 0x1b5,
        xlDialogMacroOptions = 0x17e,
        xlDialogMailEditMailer = 470,
        xlDialogMailLogon = 0x153,
        xlDialogMailNextLetter = 0x17a,
        xlDialogMainChart = 0x55,
        xlDialogMainChartType = 0xb9,
        xlDialogMenuEditor = 0x142,
        xlDialogMove = 0x106,
        xlDialogMyPermission = 0x342,
        xlDialogNameManager = 0x3d1,
        xlDialogNew = 0x77,
        xlDialogNewName = 0x3d2,
        xlDialogNewWebQuery = 0x29b,
        xlDialogNote = 0x9a,
        xlDialogObjectProperties = 0xcf,
        xlDialogObjectProtection = 0xd6,
        xlDialogOpen = 1,
        xlDialogOpenLinks = 2,
        xlDialogOpenMail = 0xbc,
        xlDialogOpenText = 0x1b9,
        xlDialogOptionsCalculation = 0x13e,
        xlDialogOptionsChart = 0x145,
        xlDialogOptionsEdit = 0x13f,
        xlDialogOptionsGeneral = 0x164,
        xlDialogOptionsListsAdd = 0x1ca,
        xlDialogOptionsME = 0x287,
        xlDialogOptionsTransition = 0x163,
        xlDialogOptionsView = 320,
        xlDialogOutline = 0x8e,
        xlDialogOverlay = 0x56,
        xlDialogOverlayChartType = 0xba,
        xlDialogPageSetup = 7,
        xlDialogParse = 0x5b,
        xlDialogPasteNames = 0x3a,
        xlDialogPasteSpecial = 0x35,
        xlDialogPatterns = 0x54,
        xlDialogPermission = 0x340,
        xlDialogPhonetic = 0x290,
        xlDialogPivotCalculatedField = 570,
        xlDialogPivotCalculatedItem = 0x23c,
        xlDialogPivotClientServerSet = 0x2b1,
        xlDialogPivotFieldGroup = 0x1b1,
        xlDialogPivotFieldProperties = 0x139,
        xlDialogPivotFieldUngroup = 0x1b2,
        xlDialogPivotShowPages = 0x1a5,
        xlDialogPivotSolveOrder = 0x238,
        xlDialogPivotTableOptions = 0x237,
        xlDialogPivotTableWizard = 0x138,
        xlDialogPlacement = 300,
        xlDialogPrint = 8,
        xlDialogPrinterSetup = 9,
        xlDialogPrintPreview = 0xde,
        xlDialogPromote = 0xca,
        xlDialogProperties = 0x1da,
        xlDialogPropertyFields = 0x2f2,
        xlDialogProtectDocument = 0x1c,
        xlDialogProtectSharing = 620,
        xlDialogPublishAsWebPage = 0x28d,
        xlDialogPushbuttonProperties = 0x1bd,
        xlDialogReplaceFont = 0x86,
        xlDialogRoutingSlip = 0x150,
        xlDialogRowHeight = 0x7f,
        xlDialogRun = 0x11,
        xlDialogSaveAs = 5,
        xlDialogSaveCopyAs = 0x1c8,
        xlDialogSaveNewObject = 0xd0,
        xlDialogSaveWorkbook = 0x91,
        xlDialogSaveWorkspace = 0x11d,
        xlDialogScale = 0x57,
        xlDialogScenarioAdd = 0x133,
        xlDialogScenarioCells = 0x131,
        xlDialogScenarioEdit = 0x134,
        xlDialogScenarioMerge = 0x1d9,
        xlDialogScenarioSummary = 0x137,
        xlDialogScrollbarProperties = 420,
        xlDialogSearch = 0x2db,
        xlDialogSelectSpecial = 0x84,
        xlDialogSendMail = 0xbd,
        xlDialogSeriesAxes = 460,
        xlDialogSeriesOptions = 0x22d,
        xlDialogSeriesOrder = 0x1d2,
        xlDialogSeriesShape = 0x1f8,
        xlDialogSeriesX = 0x1cd,
        xlDialogSeriesY = 0x1ce,
        xlDialogSetBackgroundPicture = 0x1fd,
        xlDialogSetPrintTitles = 0x17,
        xlDialogSetUpdateStatus = 0x9f,
        xlDialogShowDetail = 0xcc,
        xlDialogShowToolbar = 220,
        xlDialogSize = 0x105,
        xlDialogSort = 0x27,
        xlDialogSortSpecial = 0xc0,
        xlDialogSplit = 0x89,
        xlDialogStandardFont = 190,
        xlDialogStandardWidth = 0x1d8,
        xlDialogStyle = 0x2c,
        xlDialogSubscribeTo = 0xda,
        xlDialogSubtotalCreate = 0x18e,
        xlDialogSummaryInfo = 0x1da,
        xlDialogTable = 0x29,
        xlDialogTabOrder = 0x18a,
        xlDialogTextToColumns = 0x1a6,
        xlDialogUnhide = 0x5e,
        xlDialogUpdateLink = 0xc9,
        xlDialogVbaInsertFile = 0x148,
        xlDialogVbaMakeAddin = 0x1de,
        xlDialogVbaProcedureDefinition = 330,
        xlDialogView3d = 0xc5,
        xlDialogWebOptionsBrowsers = 0x305,
        xlDialogWebOptionsEncoding = 0x2ae,
        xlDialogWebOptionsFiles = 0x2ac,
        xlDialogWebOptionsFonts = 0x2af,
        xlDialogWebOptionsGeneral = 0x2ab,
        xlDialogWebOptionsPictures = 0x2ad,
        xlDialogWindowMove = 14,
        xlDialogWindowSize = 13,
        xlDialogWorkbookAdd = 0x119,
        xlDialogWorkbookCopy = 0x11b,
        xlDialogWorkbookInsert = 0x162,
        xlDialogWorkbookMove = 0x11a,
        xlDialogWorkbookName = 0x182,
        xlDialogWorkbookNew = 0x12e,
        xlDialogWorkbookOptions = 0x11c,
        xlDialogWorkbookProtect = 0x1a1,
        xlDialogWorkbookTabSplit = 0x19f,
        xlDialogWorkbookUnhide = 0x180,
        xlDialogWorkgroup = 0xc7,
        xlDialogWorkspace = 0x5f,
        xlDialogZoom = 0x100
    }

    public enum XlCalcFor
    {
        xlAllValues,
        xlRowGroups,
        xlColGroups
    }

    public enum XlCalculatedMemberType
    {
        xlCalculatedMember,
        xlCalculatedSet
    }

    public enum XlCalculation
    {
        xlCalculationAutomatic = -4105,
        xlCalculationManual = -4135,
        xlCalculationSemiautomatic = 2
    }

    public enum XlCalculationInterruptKey
    {
        xlNoKey,
        xlEscKey,
        xlAnyKey
    }

    public enum XlCalculationState
    {
        xlDone,
        xlCalculating,
        xlPending
    }

    public enum XlCategoryType
    {
        xlAutomaticScale = -4105,
        xlCategoryScale = 2,
        xlTimeScale = 3
    }

    public enum XlCellInsertionMode
    {
        xlOverwriteCells,
        xlInsertDeleteCells,
        xlInsertEntireRows
    }

    public enum XlCellType
    {
        xlCellTypeAllFormatConditions = -4172,
        xlCellTypeAllValidation = -4174,
        xlCellTypeBlanks = 4,
        xlCellTypeComments = -4144,
        xlCellTypeConstants = 2,
        xlCellTypeFormulas = -4123,
        xlCellTypeLastCell = 11,
        xlCellTypeSameFormatConditions = -4173,
        xlCellTypeSameValidation = -4175,
        xlCellTypeVisible = 12
    }

    public enum XlChartElementPosition
    {
        xlChartElementPositionAutomatic = -4105,
        xlChartElementPositionCustom = -4114
    }

    public enum XlChartGallery
    {
        xlAnyGallery = 0x17,
        xlBuiltIn = 0x15,
        xlUserDefined = 0x16
    }

    public enum XlChartItem
    {
        xlAxis = 0x15,
        xlAxisTitle = 0x11,
        xlChartArea = 2,
        xlChartTitle = 4,
        xlCorners = 6,
        xlDataLabel = 0,
        xlDataTable = 7,
        xlDisplayUnitLabel = 30,
        xlDownBars = 20,
        xlDropLines = 0x1a,
        xlErrorBars = 9,
        xlFloor = 0x17,
        xlHiLoLines = 0x19,
        xlLeaderLines = 0x1d,
        xlLegend = 0x18,
        xlLegendEntry = 12,
        xlLegendKey = 13,
        xlMajorGridlines = 15,
        xlMinorGridlines = 0x10,
        xlNothing = 0x1c,
        xlPivotChartDropZone = 0x20,
        xlPivotChartFieldButton = 0x1f,
        xlPlotArea = 0x13,
        xlRadarAxisLabels = 0x1b,
        xlSeries = 3,
        xlSeriesLines = 0x16,
        xlShape = 14,
        xlTrendline = 8,
        xlUpBars = 0x12,
        xlWalls = 5,
        xlXErrorBars = 10,
        xlYErrorBars = 11
    }

    public enum XlChartLocation
    {
        xlLocationAsNewSheet = 1,
        xlLocationAsObject = 2,
        xlLocationAutomatic = 3
    }

    public enum XlChartPicturePlacement
    {
        xlAllFaces = 7,
        xlEnd = 2,
        xlEndSides = 3,
        xlFront = 4,
        xlFrontEnd = 6,
        xlFrontSides = 5,
        xlSides = 1
    }

    public enum XlChartPictureType
    {
        xlStack = 2,
        xlStackScale = 3,
        xlStretch = 1
    }

    public enum XlChartSplitType
    {
        xlSplitByCustomSplit = 4,
        xlSplitByPercentValue = 3,
        xlSplitByPosition = 1,
        xlSplitByValue = 2
    }

    public enum XlChartType
    {
        xl3DArea = -4098,
        xl3DAreaStacked = 0x4e,
        xl3DAreaStacked100 = 0x4f,
        xl3DBarClustered = 60,
        xl3DBarStacked = 0x3d,
        xl3DBarStacked100 = 0x3e,
        xl3DColumn = -4100,
        xl3DColumnClustered = 0x36,
        xl3DColumnStacked = 0x37,
        xl3DColumnStacked100 = 0x38,
        xl3DLine = -4101,
        xl3DPie = -4102,
        xl3DPieExploded = 70,
        xlArea = 1,
        xlAreaStacked = 0x4c,
        xlAreaStacked100 = 0x4d,
        xlBarClustered = 0x39,
        xlBarOfPie = 0x47,
        xlBarStacked = 0x3a,
        xlBarStacked100 = 0x3b,
        xlBubble = 15,
        xlBubble3DEffect = 0x57,
        xlColumnClustered = 0x33,
        xlColumnStacked = 0x34,
        xlColumnStacked100 = 0x35,
        xlConeBarClustered = 0x66,
        xlConeBarStacked = 0x67,
        xlConeBarStacked100 = 0x68,
        xlConeCol = 0x69,
        xlConeColClustered = 0x63,
        xlConeColStacked = 100,
        xlConeColStacked100 = 0x65,
        xlCylinderBarClustered = 0x5f,
        xlCylinderBarStacked = 0x60,
        xlCylinderBarStacked100 = 0x61,
        xlCylinderCol = 0x62,
        xlCylinderColClustered = 0x5c,
        xlCylinderColStacked = 0x5d,
        xlCylinderColStacked100 = 0x5e,
        xlDoughnut = -4120,
        xlDoughnutExploded = 80,
        xlLine = 4,
        xlLineMarkers = 0x41,
        xlLineMarkersStacked = 0x42,
        xlLineMarkersStacked100 = 0x43,
        xlLineStacked = 0x3f,
        xlLineStacked100 = 0x40,
        xlPie = 5,
        xlPieExploded = 0x45,
        xlPieOfPie = 0x44,
        xlPyramidBarClustered = 0x6d,
        xlPyramidBarStacked = 110,
        xlPyramidBarStacked100 = 0x6f,
        xlPyramidCol = 0x70,
        xlPyramidColClustered = 0x6a,
        xlPyramidColStacked = 0x6b,
        xlPyramidColStacked100 = 0x6c,
        xlRadar = -4151,
        xlRadarFilled = 0x52,
        xlRadarMarkers = 0x51,
        xlStockHLC = 0x58,
        xlStockOHLC = 0x59,
        xlStockVHLC = 90,
        xlStockVOHLC = 0x5b,
        xlSurface = 0x53,
        xlSurfaceTopView = 0x55,
        xlSurfaceTopViewWireframe = 0x56,
        xlSurfaceWireframe = 0x54,
        xlXYScatter = -4169,
        xlXYScatterLines = 0x4a,
        xlXYScatterLinesNoMarkers = 0x4b,
        xlXYScatterSmooth = 0x48,
        xlXYScatterSmoothNoMarkers = 0x49
    }

    public enum XlCheckInVersionType
    {
        xlCheckInMinorVersion,
        xlCheckInMajorVersion,
        xlCheckInOverwriteVersion
    }

    public enum XlClipboardFormat
    {
        xlClipboardFormatBIFF = 8,
        xlClipboardFormatBIFF12 = 0x3f,
        xlClipboardFormatBIFF2 = 0x12,
        xlClipboardFormatBIFF3 = 20,
        xlClipboardFormatBIFF4 = 30,
        xlClipboardFormatBinary = 15,
        xlClipboardFormatBitmap = 9,
        xlClipboardFormatCGM = 13,
        xlClipboardFormatCSV = 5,
        xlClipboardFormatDIF = 4,
        xlClipboardFormatDspText = 12,
        xlClipboardFormatEmbeddedObject = 0x15,
        xlClipboardFormatEmbedSource = 0x16,
        xlClipboardFormatLink = 11,
        xlClipboardFormatLinkSource = 0x17,
        xlClipboardFormatLinkSourceDesc = 0x20,
        xlClipboardFormatMovie = 0x18,
        xlClipboardFormatNative = 14,
        xlClipboardFormatObjectDesc = 0x1f,
        xlClipboardFormatObjectLink = 0x13,
        xlClipboardFormatOwnerLink = 0x11,
        xlClipboardFormatPICT = 2,
        xlClipboardFormatPrintPICT = 3,
        xlClipboardFormatRTF = 7,
        xlClipboardFormatScreenPICT = 0x1d,
        xlClipboardFormatStandardFont = 0x1c,
        xlClipboardFormatStandardScale = 0x1b,
        xlClipboardFormatSYLK = 6,
        xlClipboardFormatTable = 0x10,
        xlClipboardFormatText = 0,
        xlClipboardFormatToolFace = 0x19,
        xlClipboardFormatToolFacePICT = 0x1a,
        xlClipboardFormatVALU = 1,
        xlClipboardFormatWK1 = 10
    }

    public enum XlCmdType
    {
        xlCmdCube = 1,
        xlCmdDefault = 4,
        xlCmdList = 5,
        xlCmdSql = 2,
        xlCmdTable = 3
    }

    public enum XlColorIndex
    {
        xlColorIndexAutomatic = -4105,
        xlColorIndexNone = -4142
    }

    public enum XlColumnDataType
    {
        xlDMYFormat = 4,
        xlDYMFormat = 7,
        xlEMDFormat = 10,
        xlGeneralFormat = 1,
        xlMDYFormat = 3,
        xlMYDFormat = 6,
        xlSkipColumn = 9,
        xlTextFormat = 2,
        xlYDMFormat = 8,
        xlYMDFormat = 5
    }

    public enum XlCommandUnderlines
    {
        xlCommandUnderlinesAutomatic = -4105,
        xlCommandUnderlinesOff = -4146,
        xlCommandUnderlinesOn = 1
    }

    public enum XlCommentDisplayMode
    {
        xlCommentAndIndicator = 1,
        xlCommentIndicatorOnly = -1,
        xlNoIndicator = 0
    }

    public enum XlConditionValueTypes
    {
        xlConditionValueFormula = 4,
        xlConditionValueHighestValue = 2,
        xlConditionValueLowestValue = 1,
        xlConditionValueNone = -1,
        xlConditionValueNumber = 0,
        xlConditionValuePercent = 3,
        xlConditionValuePercentile = 5
    }

    public enum XlConnectionType
    {
        xlConnectionTypeODBC = 2,
        xlConnectionTypeOLEDB = 1,
        xlConnectionTypeTEXT = 4,
        xlConnectionTypeWEB = 5,
        xlConnectionTypeXMLMAP = 3
    }

    public enum XlConsolidationFunction
    {
        xlAverage = -4106,
        xlCount = -4112,
        xlCountNums = -4113,
        xlMax = -4136,
        xlMin = -4139,
        xlProduct = -4149,
        xlStDev = -4155,
        xlStDevP = -4156,
        xlSum = -4157,
        xlUnknown = 0x3e8,
        xlVar = -4164,
        xlVarP = -4165
    }

    public enum XlContainsOperator
    {
        xlContains,
        xlDoesNotContain,
        xlBeginsWith,
        xlEndsWith
    }

    public enum XlCopyPictureFormat
    {
        xlBitmap = 2,
        xlPicture = -4147
    }

    public enum XlCorruptLoad
    {
        xlNormalLoad,
        xlRepairFile,
        xlExtractData
    }

    public enum XlCreator
    {
        xlCreatorCode = 0x5843454c
    }

    public enum XlCredentialsMethod
    {
        xlCredentialsMethodIntegrated,
        xlCredentialsMethodNone,
        xlCredentialsMethodStored
    }

    public enum XlCubeFieldSubType
    {
        xlCubeAttribute = 4,
        xlCubeCalculatedMeasure = 5,
        xlCubeHierarchy = 1,
        xlCubeKPIGoal = 7,
        xlCubeKPIStatus = 8,
        xlCubeKPITrend = 9,
        xlCubeKPIValue = 6,
        xlCubeKPIWeight = 10,
        xlCubeMeasure = 2,
        xlCubeSet = 3
    }

    public enum XlCubeFieldType
    {
        xlHierarchy = 1,
        xlMeasure = 2,
        xlSet = 3
    }

    public enum XlCutCopyMode
    {
        xlCopy = 1,
        xlCut = 2
    }

    public enum XlCVError
    {
        xlErrDiv0 = 0x7d7,
        xlErrNA = 0x7fa,
        xlErrName = 0x7ed,
        xlErrNull = 0x7d0,
        xlErrNum = 0x7f4,
        xlErrRef = 0x7e7,
        xlErrValue = 0x7df
    }

    public enum XlDataLabelPosition
    {
        xlLabelPositionAbove = 0,
        xlLabelPositionBelow = 1,
        xlLabelPositionBestFit = 5,
        xlLabelPositionCenter = -4108,
        xlLabelPositionCustom = 7,
        xlLabelPositionInsideBase = 4,
        xlLabelPositionInsideEnd = 3,
        xlLabelPositionLeft = -4131,
        xlLabelPositionMixed = 6,
        xlLabelPositionOutsideEnd = 2,
        xlLabelPositionRight = -4152
    }

    public enum XlDataLabelSeparator
    {
        xlDataLabelSeparatorDefault = 1
    }

    public enum XlDataLabelsType
    {
        xlDataLabelsShowBubbleSizes = 6,
        xlDataLabelsShowLabel = 4,
        xlDataLabelsShowLabelAndPercent = 5,
        xlDataLabelsShowNone = -4142,
        xlDataLabelsShowPercent = 3,
        xlDataLabelsShowValue = 2
    }

    public enum XlDataSeriesDate
    {
        xlDay = 1,
        xlMonth = 3,
        xlWeekday = 2,
        xlYear = 4
    }

    public enum XlDataSeriesType
    {
        xlAutoFill = 4,
        xlChronological = 3,
        xlDataSeriesLinear = -4132,
        xlGrowth = 2
    }

    public enum XlDeleteShiftDirection
    {
        xlShiftToLeft = -4159,
        xlShiftUp = -4162
    }

    public enum XlDirection
    {
        xlDown = -4121,
        xlToLeft = -4159,
        xlToRight = -4161,
        xlUp = -4162
    }

    public enum XlDisplayBlanksAs
    {
        xlInterpolated = 3,
        xlNotPlotted = 1,
        xlZero = 2
    }

    public enum XlDisplayDrawingObjects
    {
        xlDisplayShapes = -4104,
        xlHide = 3,
        xlPlaceholders = 2
    }

    public enum XlDisplayUnit
    {
        xlHundredMillions = -8,
        xlHundreds = -2,
        xlHundredThousands = -5,
        xlMillionMillions = -10,
        xlMillions = -6,
        xlTenMillions = -7,
        xlTenThousands = -4,
        xlThousandMillions = -9,
        xlThousands = -3
    }

    public enum XlDupeUnique
    {
        xlUnique,
        xlDuplicate
    }

    public enum XlDVAlertStyle
    {
        xlValidAlertInformation = 3,
        xlValidAlertStop = 1,
        xlValidAlertWarning = 2
    }

    public enum XlDVType
    {
        xlValidateInputOnly,
        xlValidateWholeNumber,
        xlValidateDecimal,
        xlValidateList,
        xlValidateDate,
        xlValidateTime,
        xlValidateTextLength,
        xlValidateCustom
    }

    public enum XlDynamicFilterCriteria
    {
        xlFilterAboveAverage = 0x21,
        xlFilterAllDatesInPeriodApril = 0x18,
        xlFilterAllDatesInPeriodAugust = 0x1c,
        xlFilterAllDatesInPeriodDecember = 0x20,
        xlFilterAllDatesInPeriodFebruray = 0x16,
        xlFilterAllDatesInPeriodJanuary = 0x15,
        xlFilterAllDatesInPeriodJuly = 0x1b,
        xlFilterAllDatesInPeriodJune = 0x1a,
        xlFilterAllDatesInPeriodMarch = 0x17,
        xlFilterAllDatesInPeriodMay = 0x19,
        xlFilterAllDatesInPeriodNovember = 0x1f,
        xlFilterAllDatesInPeriodOctober = 30,
        xlFilterAllDatesInPeriodQuarter1 = 0x11,
        xlFilterAllDatesInPeriodQuarter2 = 0x12,
        xlFilterAllDatesInPeriodQuarter3 = 0x13,
        xlFilterAllDatesInPeriodQuarter4 = 20,
        xlFilterAllDatesInPeriodSeptember = 0x1d,
        xlFilterBelowAverage = 0x22,
        xlFilterLastMonth = 8,
        xlFilterLastQuarter = 11,
        xlFilterLastWeek = 5,
        xlFilterLastYear = 14,
        xlFilterNextMonth = 9,
        xlFilterNextQuarter = 12,
        xlFilterNextWeek = 6,
        xlFilterNextYear = 15,
        xlFilterThisMonth = 7,
        xlFilterThisQuarter = 10,
        xlFilterThisWeek = 4,
        xlFilterThisYear = 13,
        xlFilterToday = 1,
        xlFilterTomorrow = 3,
        xlFilterYearToDate = 0x10,
        xlFilterYesterday = 2
    }

    public enum XlEditionFormat
    {
        xlBIFF = 2,
        xlPICT = 1,
        xlRTF = 4,
        xlVALU = 8
    }

    public enum XlEditionOptionsOption
    {
        xlAutomaticUpdate = 4,
        xlCancel = 1,
        xlChangeAttributes = 6,
        xlManualUpdate = 5,
        xlOpenSource = 3,
        xlSelect = 3,
        xlSendPublisher = 2,
        xlUpdateSubscriber = 2
    }

    public enum XlEditionType
    {
        xlPublisher = 1,
        xlSubscriber = 2
    }

    public enum XlEnableCancelKey
    {
        xlDisabled,
        xlInterrupt,
        xlErrorHandler
    }

    public enum XlEnableSelection
    {
        xlNoRestrictions = 0,
        xlNoSelection = -4142,
        xlUnlockedCells = 1
    }

    public enum XlEndStyleCap
    {
        xlCap = 1,
        xlNoCap = 2
    }

    public enum XlErrorBarDirection
    {
        xlX = -4168,
        xlY = 1
    }

    public enum XlErrorBarInclude
    {
        xlErrorBarIncludeBoth = 1,
        xlErrorBarIncludeMinusValues = 3,
        xlErrorBarIncludeNone = -4142,
        xlErrorBarIncludePlusValues = 2
    }

    public enum XlErrorBarType
    {
        xlErrorBarTypeCustom = -4114,
        xlErrorBarTypeFixedValue = 1,
        xlErrorBarTypePercent = 2,
        xlErrorBarTypeStDev = -4155,
        xlErrorBarTypeStError = 4
    }

    public enum XlErrorChecks
    {
        xlEmptyCellReferences = 7,
        xlEvaluateToError = 1,
        xlInconsistentFormula = 4,
        xlInconsistentListFormula = 9,
        xlListDataValidation = 8,
        xlNumberAsText = 3,
        xlOmittedCells = 5,
        xlTextDate = 2,
        xlUnlockedFormulaCells = 6
    }

    public enum XlFileAccess
    {
        xlReadOnly = 3,
        xlReadWrite = 2
    }

    public enum XlFileFormat
    {
        xlAddIn = 0x12,
        xlAddIn8 = 0x12,
        xlCSV = 6,
        xlCSVMac = 0x16,
        xlCSVMSDOS = 0x18,
        xlCSVWindows = 0x17,
        xlCurrentPlatformText = -4158,
        xlDBF2 = 7,
        xlDBF3 = 8,
        xlDBF4 = 11,
        xlDIF = 9,
        xlExcel12 = 50,
        xlExcel2 = 0x10,
        xlExcel2FarEast = 0x1b,
        xlExcel3 = 0x1d,
        xlExcel4 = 0x21,
        xlExcel4Workbook = 0x23,
        xlExcel5 = 0x27,
        xlExcel7 = 0x27,
        xlExcel8 = 0x38,
        xlExcel9795 = 0x2b,
        xlHtml = 0x2c,
        xlIntlAddIn = 0x1a,
        xlIntlMacro = 0x19,
        xlOpenXMLAddIn = 0x37,
        xlOpenXMLTemplate = 0x36,
        xlOpenXMLTemplateMacroEnabled = 0x35,
        xlOpenXMLWorkbook = 0x33,
        xlOpenXMLWorkbookMacroEnabled = 0x34,
        xlSYLK = 2,
        xlTemplate = 0x11,
        xlTemplate8 = 0x11,
        xlTextMac = 0x13,
        xlTextMSDOS = 0x15,
        xlTextPrinter = 0x24,
        xlTextWindows = 20,
        xlUnicodeText = 0x2a,
        xlWebArchive = 0x2d,
        xlWJ2WD1 = 14,
        xlWJ3 = 40,
        xlWJ3FJ3 = 0x29,
        xlWK1 = 5,
        xlWK1ALL = 0x1f,
        xlWK1FMT = 30,
        xlWK3 = 15,
        xlWK3FM3 = 0x20,
        xlWK4 = 0x26,
        xlWKS = 4,
        xlWorkbookDefault = 0x33,
        xlWorkbookNormal = -4143,
        xlWorks2FarEast = 0x1c,
        xlWQ1 = 0x22,
        xlXMLSpreadsheet = 0x2e
    }

    public enum XlFillWith
    {
        xlFillWithAll = -4104,
        xlFillWithContents = 2,
        xlFillWithFormats = -4122
    }

    public enum XlFilterAction
    {
        xlFilterCopy = 2,
        xlFilterInPlace = 1
    }

    public enum XlFilterAllDatesInPeriod
    {
        xlFilterAllDatesInPeriodYear,
        xlFilterAllDatesInPeriodMonth,
        xlFilterAllDatesInPeriodDay,
        xlFilterAllDatesInPeriodHour,
        xlFilterAllDatesInPeriodMinute,
        xlFilterAllDatesInPeriodSecond
    }

    public enum XlFindLookIn
    {
        xlComments = -4144,
        xlFormulas = -4123,
        xlValues = -4163
    }

    public enum XlFixedFormatQuality
    {
        xlQualityStandard,
        xlQualityMinimum
    }

    public enum XlFixedFormatType
    {
        xlTypePDF,
        xlTypeXPS
    }

    public enum XlFormatConditionOperator
    {
        xlBetween = 1,
        xlEqual = 3,
        xlGreater = 5,
        xlGreaterEqual = 7,
        xlLess = 6,
        xlLessEqual = 8,
        xlNotBetween = 2,
        xlNotEqual = 4
    }

    public enum XlFormatConditionType
    {
        xlAboveAverageCondition = 12,
        xlBlanksCondition = 10,
        xlCellValue = 1,
        xlColorScale = 3,
        xlDatabar = 4,
        xlErrorsCondition = 0x10,
        xlExpression = 2,
        xlIconSets = 6,
        xlNoBlanksCondition = 13,
        xlNoErrorsCondition = 0x11,
        xlTextString = 9,
        xlTimePeriod = 11,
        xlTop10 = 5,
        xlUniqueValues = 8
    }

    public enum XlFormatFilterTypes
    {
        xlFilterBottom,
        xlFilterTop,
        xlFilterBottomPercent,
        xlFilterTopPercent
    }

    public enum XlFormControl
    {
        xlButtonControl,
        xlCheckBox,
        xlDropDown,
        xlEditBox,
        xlGroupBox,
        xlLabel,
        xlListBox,
        xlOptionButton,
        xlScrollBar,
        xlSpinner
    }

    public enum XlFormulaLabel
    {
        xlColumnLabels = 2,
        xlMixedLabels = 3,
        xlNoLabels = -4142,
        xlRowLabels = 1
    }

    public enum XlGenerateTableRefs
    {
        xlGenerateTableRefA1,
        xlGenerateTableRefStruct
    }

    public enum XlGradientFillType
    {
        xlGradientFillLinear,
        xlGradientFillPath
    }

    public enum XlHAlign
    {
        xlHAlignCenter = -4108,
        xlHAlignCenterAcrossSelection = 7,
        xlHAlignDistributed = -4117,
        xlHAlignFill = 5,
        xlHAlignGeneral = 1,
        xlHAlignJustify = -4130,
        xlHAlignLeft = -4131,
        xlHAlignRight = -4152
    }

    public enum XlHebrewModes
    {
        xlHebrewFullScript,
        xlHebrewPartialScript,
        xlHebrewMixedScript,
        xlHebrewMixedAuthorizedScript
    }

    public enum XlHighlightChangesTime
    {
        xlAllChanges = 2,
        xlNotYetReviewed = 3,
        xlSinceMyLastSave = 1
    }

    public enum XlHtmlType
    {
        xlHtmlStatic,
        xlHtmlCalc,
        xlHtmlList,
        xlHtmlChart
    }

    public enum XlIconSet
    {
        xl3Arrows = 1,
        xl3ArrowsGray = 2,
        xl3Flags = 3,
        xl3Signs = 6,
        xl3Symbols = 7,
        xl3Symbols2 = 8,
        xl3TrafficLights1 = 4,
        xl3TrafficLights2 = 5,
        xl4Arrows = 9,
        xl4ArrowsGray = 10,
        xl4CRV = 12,
        xl4RedToBlack = 11,
        xl4TrafficLights = 13,
        xl5Arrows = 14,
        xl5ArrowsGray = 15,
        xl5CRV = 0x10,
        xl5Quarters = 0x11
    }

    public enum XlIMEMode
    {
        xlIMEModeNoControl,
        xlIMEModeOn,
        xlIMEModeOff,
        xlIMEModeDisable,
        xlIMEModeHiragana,
        xlIMEModeKatakana,
        xlIMEModeKatakanaHalf,
        xlIMEModeAlphaFull,
        xlIMEModeAlpha,
        xlIMEModeHangulFull,
        xlIMEModeHangul
    }

    public enum XlImportDataAs
    {
        xlQueryTable,
        xlPivotTableReport,
        xlTable
    }

    public enum XlInsertFormatOrigin
    {
        xlFormatFromLeftOrAbove,
        xlFormatFromRightOrBelow
    }

    public enum XlInsertShiftDirection
    {
        xlShiftDown = -4121,
        xlShiftToRight = -4161
    }

    public enum XlLayoutFormType
    {
        xlTabular,
        xlOutline
    }

    public enum XlLayoutRowType
    {
        xlCompactRow,
        xlTabularRow,
        xlOutlineRow
    }

    public enum XlLegendPosition
    {
        xlLegendPositionBottom = -4107,
        xlLegendPositionCorner = 2,
        xlLegendPositionCustom = -4161,
        xlLegendPositionLeft = -4131,
        xlLegendPositionRight = -4152,
        xlLegendPositionTop = -4160
    }

    public enum XlLineStyle
    {
        xlContinuous = 1,
        xlDash = -4115,
        xlDashDot = 4,
        xlDashDotDot = 5,
        xlDot = -4118,
        xlDouble = -4119,
        xlLineStyleNone = -4142,
        xlSlantDashDot = 13
    }

    public enum XlLink
    {
        xlExcelLinks = 1,
        xlOLELinks = 2,
        xlPublishers = 5,
        xlSubscribers = 6
    }

    public enum XlLinkInfo
    {
        xlEditionDate = 2,
        xlLinkInfoStatus = 3,
        xlUpdateState = 1
    }

    public enum XlLinkInfoType
    {
        xlLinkInfoOLELinks = 2,
        xlLinkInfoPublishers = 5,
        xlLinkInfoSubscribers = 6
    }

    public enum XlLinkStatus
    {
        xlLinkStatusOK,
        xlLinkStatusMissingFile,
        xlLinkStatusMissingSheet,
        xlLinkStatusOld,
        xlLinkStatusSourceNotCalculated,
        xlLinkStatusIndeterminate,
        xlLinkStatusNotStarted,
        xlLinkStatusInvalidName,
        xlLinkStatusSourceNotOpen,
        xlLinkStatusSourceOpen,
        xlLinkStatusCopiedValues
    }

    public enum XlLinkType
    {
        xlLinkTypeExcelLinks = 1,
        xlLinkTypeOLELinks = 2
    }

    public enum XlListConflict
    {
        xlListConflictDialog,
        xlListConflictRetryAllConflicts,
        xlListConflictDiscardAllConflicts,
        xlListConflictError
    }

    public enum XlListDataType
    {
        xlListDataTypeNone,
        xlListDataTypeText,
        xlListDataTypeMultiLineText,
        xlListDataTypeNumber,
        xlListDataTypeCurrency,
        xlListDataTypeDateTime,
        xlListDataTypeChoice,
        xlListDataTypeChoiceMulti,
        xlListDataTypeListLookup,
        xlListDataTypeCheckbox,
        xlListDataTypeHyperLink,
        xlListDataTypeCounter,
        xlListDataTypeMultiLineRichText
    }

    public enum XlListObjectSourceType
    {
        xlSrcExternal,
        xlSrcRange,
        xlSrcXml,
        xlSrcQuery
    }

    public enum XlLocationInTable
    {
        xlColumnHeader = -4110,
        xlColumnItem = 5,
        xlDataHeader = 3,
        xlDataItem = 7,
        xlPageHeader = 2,
        xlPageItem = 6,
        xlRowHeader = -4153,
        xlRowItem = 4,
        xlTableBody = 8
    }

    public enum XlLookAt
    {
        xlPart = 2,
        xlWhole = 1
    }

    public enum XlLookFor
    {
        xlLookForBlanks,
        xlLookForErrors,
        xlLookForFormulas
    }

    public enum XlMailSystem
    {
        xlNoMailSystem,
        xlMAPI,
        xlPowerTalk
    }

    public enum XlMarkerStyle
    {
        xlMarkerStyleAutomatic = -4105,
        xlMarkerStyleCircle = 8,
        xlMarkerStyleDash = -4115,
        xlMarkerStyleDiamond = 2,
        xlMarkerStyleDot = -4118,
        xlMarkerStyleNone = -4142,
        xlMarkerStylePicture = -4147,
        xlMarkerStylePlus = 9,
        xlMarkerStyleSquare = 1,
        xlMarkerStyleStar = 5,
        xlMarkerStyleTriangle = 3,
        xlMarkerStyleX = -4168
    }

    public enum XlMeasurementUnits
    {
        xlInches,
        xlCentimeters,
        xlMillimeters
    }

    public enum XlMouseButton
    {
        xlNoButton,
        xlPrimaryButton,
        xlSecondaryButton
    }

    public enum XlMousePointer
    {
        xlDefault = -4143,
        xlIBeam = 3,
        xlNorthwestArrow = 1,
        xlWait = 2
    }

    public enum XlMSApplication
    {
        xlMicrosoftAccess = 4,
        xlMicrosoftFoxPro = 5,
        xlMicrosoftMail = 3,
        xlMicrosoftPowerPoint = 2,
        xlMicrosoftProject = 6,
        xlMicrosoftSchedulePlus = 7,
        xlMicrosoftWord = 1
    }

    public enum XlObjectSize
    {
        xlFitToPage = 2,
        xlFullPage = 3,
        xlScreenSize = 1
    }

    public enum XlOLEType
    {
        xlOLELink,
        xlOLEEmbed,
        xlOLEControl
    }

    public enum XlOLEVerb
    {
        xlVerbOpen = 2,
        xlVerbPrimary = 1
    }

    public enum XlOrder
    {
        xlDownThenOver = 1,
        xlOverThenDown = 2
    }

    public enum XlOrientation
    {
        xlDownward = -4170,
        xlHorizontal = -4128,
        xlUpward = -4171,
        xlVertical = -4166
    }

    public enum XlPageBreak
    {
        xlPageBreakAutomatic = -4105,
        xlPageBreakManual = -4135,
        xlPageBreakNone = -4142
    }

    public enum XlPageBreakExtent
    {
        xlPageBreakFull = 1,
        xlPageBreakPartial = 2
    }

    public enum XlPageOrientation
    {
        xlLandscape = 2,
        xlPortrait = 1
    }

    public enum XlPaperSize
    {
        xlPaper10x14 = 0x10,
        xlPaper11x17 = 0x11,
        xlPaperA3 = 8,
        xlPaperA4 = 9,
        xlPaperA4Small = 10,
        xlPaperA5 = 11,
        xlPaperB4 = 12,
        xlPaperB5 = 13,
        xlPaperCsheet = 0x18,
        xlPaperDsheet = 0x19,
        xlPaperEnvelope10 = 20,
        xlPaperEnvelope11 = 0x15,
        xlPaperEnvelope12 = 0x16,
        xlPaperEnvelope14 = 0x17,
        xlPaperEnvelope9 = 0x13,
        xlPaperEnvelopeB4 = 0x21,
        xlPaperEnvelopeB5 = 0x22,
        xlPaperEnvelopeB6 = 0x23,
        xlPaperEnvelopeC3 = 0x1d,
        xlPaperEnvelopeC4 = 30,
        xlPaperEnvelopeC5 = 0x1c,
        xlPaperEnvelopeC6 = 0x1f,
        xlPaperEnvelopeC65 = 0x20,
        xlPaperEnvelopeDL = 0x1b,
        xlPaperEnvelopeItaly = 0x24,
        xlPaperEnvelopeMonarch = 0x25,
        xlPaperEnvelopePersonal = 0x26,
        xlPaperEsheet = 0x1a,
        xlPaperExecutive = 7,
        xlPaperFanfoldLegalGerman = 0x29,
        xlPaperFanfoldStdGerman = 40,
        xlPaperFanfoldUS = 0x27,
        xlPaperFolio = 14,
        xlPaperLedger = 4,
        xlPaperLegal = 5,
        xlPaperLetter = 1,
        xlPaperLetterSmall = 2,
        xlPaperNote = 0x12,
        xlPaperQuarto = 15,
        xlPaperStatement = 6,
        xlPaperTabloid = 3,
        xlPaperUser = 0x100
    }

    public enum XlParameterDataType
    {
        xlParamTypeBigInt = -5,
        xlParamTypeBinary = -2,
        xlParamTypeBit = -7,
        xlParamTypeChar = 1,
        xlParamTypeDate = 9,
        xlParamTypeDecimal = 3,
        xlParamTypeDouble = 8,
        xlParamTypeFloat = 6,
        xlParamTypeInteger = 4,
        xlParamTypeLongVarBinary = -4,
        xlParamTypeLongVarChar = -1,
        xlParamTypeNumeric = 2,
        xlParamTypeReal = 7,
        xlParamTypeSmallInt = 5,
        xlParamTypeTime = 10,
        xlParamTypeTimestamp = 11,
        xlParamTypeTinyInt = -6,
        xlParamTypeUnknown = 0,
        xlParamTypeVarBinary = -3,
        xlParamTypeVarChar = 12,
        xlParamTypeWChar = -8
    }

    public enum XlParameterType
    {
        xlPrompt,
        xlConstant,
        xlRange
    }

    public enum XlPasteSpecialOperation
    {
        xlPasteSpecialOperationAdd = 2,
        xlPasteSpecialOperationDivide = 5,
        xlPasteSpecialOperationMultiply = 4,
        xlPasteSpecialOperationNone = -4142,
        xlPasteSpecialOperationSubtract = 3
    }

    public enum XlPasteType
    {
        xlPasteAll = -4104,
        xlPasteAllExceptBorders = 7,
        xlPasteAllUsingSourceTheme = 13,
        xlPasteColumnWidths = 8,
        xlPasteComments = -4144,
        xlPasteFormats = -4122,
        xlPasteFormulas = -4123,
        xlPasteFormulasAndNumberFormats = 11,
        xlPasteValidation = 6,
        xlPasteValues = -4163,
        xlPasteValuesAndNumberFormats = 12
    }

    public enum XlPattern
    {
        xlPatternAutomatic = -4105,
        xlPatternChecker = 9,
        xlPatternCrissCross = 0x10,
        xlPatternDown = -4121,
        xlPatternGray16 = 0x11,
        xlPatternGray25 = -4124,
        xlPatternGray50 = -4125,
        xlPatternGray75 = -4126,
        xlPatternGray8 = 0x12,
        xlPatternGrid = 15,
        xlPatternHorizontal = -4128,
        xlPatternLightDown = 13,
        xlPatternLightHorizontal = 11,
        xlPatternLightUp = 14,
        xlPatternLightVertical = 12,
        xlPatternLinearGradient = 0xfa0,
        xlPatternNone = -4142,
        xlPatternRectangularGradient = 0xfa1,
        xlPatternSemiGray75 = 10,
        xlPatternSolid = 1,
        xlPatternUp = -4162,
        xlPatternVertical = -4166
    }

    public enum XlPhoneticAlignment
    {
        xlPhoneticAlignNoControl,
        xlPhoneticAlignLeft,
        xlPhoneticAlignCenter,
        xlPhoneticAlignDistributed
    }

    public enum XlPhoneticCharacterType
    {
        xlKatakanaHalf,
        xlKatakana,
        xlHiragana,
        xlNoConversion
    }

    public enum XlPictureAppearance
    {
        xlPrinter = 2,
        xlScreen = 1
    }

    public enum XlPictureConvertorType
    {
        xlBMP = 1,
        xlCGM = 7,
        xlDRW = 4,
        xlDXF = 5,
        xlEPS = 8,
        xlHGL = 6,
        xlPCT = 13,
        xlPCX = 10,
        xlPIC = 11,
        xlPLT = 12,
        xlTIF = 9,
        xlWMF = 2,
        xlWPG = 3
    }

    public enum XlPivotCellType
    {
        xlPivotCellValue,
        xlPivotCellPivotItem,
        xlPivotCellSubtotal,
        xlPivotCellGrandTotal,
        xlPivotCellDataField,
        xlPivotCellPivotField,
        xlPivotCellPageFieldItem,
        xlPivotCellCustomSubtotal,
        xlPivotCellDataPivotField,
        xlPivotCellBlankCell
    }

    public enum XlPivotConditionScope
    {
        xlSelectionScope,
        xlFieldsScope,
        xlDataFieldScope
    }

    public enum XlPivotFieldCalculation
    {
        xlDifferenceFrom = 2,
        xlIndex = 9,
        xlNoAdditionalCalculation = -4143,
        xlPercentDifferenceFrom = 4,
        xlPercentOf = 3,
        xlPercentOfColumn = 7,
        xlPercentOfRow = 6,
        xlPercentOfTotal = 8,
        xlRunningTotal = 5
    }

    public enum XlPivotFieldDataType
    {
        xlDate = 2,
        xlNumber = -4145,
        xlText = -4158
    }

    public enum XlPivotFieldOrientation
    {
        xlHidden,
        xlRowField,
        xlColumnField,
        xlPageField,
        xlDataField
    }

    public enum XlPivotFilterType
    {
        xlAfter = 0x21,
        xlAfterOrEqualTo = 0x22,
        xlAllDatesInPeriodApril = 60,
        xlAllDatesInPeriodAugust = 0x40,
        xlAllDatesInPeriodDecember = 0x44,
        xlAllDatesInPeriodFebruary = 0x3a,
        xlAllDatesInPeriodJanuary = 0x39,
        xlAllDatesInPeriodJuly = 0x3f,
        xlAllDatesInPeriodJune = 0x3e,
        xlAllDatesInPeriodMarch = 0x3b,
        xlAllDatesInPeriodMay = 0x3d,
        xlAllDatesInPeriodNovember = 0x43,
        xlAllDatesInPeriodOctober = 0x42,
        xlAllDatesInPeriodQuarter1 = 0x35,
        xlAllDatesInPeriodQuarter2 = 0x36,
        xlAllDatesInPeriodQuarter3 = 0x37,
        xlAllDatesInPeriodQuarter4 = 0x38,
        xlAllDatesInPeriodSeptember = 0x41,
        xlBefore = 0x1f,
        xlBeforeOrEqualTo = 0x20,
        xlBottomCount = 2,
        xlBottomPercent = 4,
        xlBottomSum = 6,
        xlCaptionBeginsWith = 0x11,
        xlCaptionContains = 0x15,
        xlCaptionDoesNotBeginWith = 0x12,
        xlCaptionDoesNotContain = 0x16,
        xlCaptionDoesNotEndWith = 20,
        xlCaptionDoesNotEqual = 0x10,
        xlCaptionEndsWith = 0x13,
        xlCaptionEquals = 15,
        xlCaptionIsBetween = 0x1b,
        xlCaptionIsGreaterThan = 0x17,
        xlCaptionIsGreaterThanOrEqualTo = 0x18,
        xlCaptionIsLessThan = 0x19,
        xlCaptionIsLessThanOrEqualTo = 0x1a,
        xlCaptionIsNotBetween = 0x1c,
        xlDateBetween = 0x23,
        xlDateLastMonth = 0x2d,
        xlDateLastQuarter = 0x30,
        xlDateLastWeek = 0x2a,
        xlDateLastYear = 0x33,
        xlDateNextMonth = 0x2b,
        xlDateNextQuarter = 0x2e,
        xlDateNextWeek = 40,
        xlDateNextYear = 0x31,
        xlDateNotBetween = 0x24,
        xlDateThisMonth = 0x2c,
        xlDateThisQuarter = 0x2f,
        xlDateThisWeek = 0x29,
        xlDateThisYear = 50,
        xlDateToday = 0x26,
        xlDateTomorrow = 0x25,
        xlDateYesterday = 0x27,
        xlNotSpecificDate = 30,
        xlSpecificDate = 0x1d,
        xlTopCount = 1,
        xlTopPercent = 3,
        xlTopSum = 5,
        xlValueDoesNotEqual = 8,
        xlValueEquals = 7,
        xlValueIsBetween = 13,
        xlValueIsGreaterThan = 9,
        xlValueIsGreaterThanOrEqualTo = 10,
        xlValueIsLessThan = 11,
        xlValueIsLessThanOrEqualTo = 12,
        xlValueIsNotBetween = 14,
        xlYearToDate = 0x34
    }

    public enum XlPivotFormatType
    {
        xlReport1,
        xlReport2,
        xlReport3,
        xlReport4,
        xlReport5,
        xlReport6,
        xlReport7,
        xlReport8,
        xlReport9,
        xlReport10,
        xlTable1,
        xlTable2,
        xlTable3,
        xlTable4,
        xlTable5,
        xlTable6,
        xlTable7,
        xlTable8,
        xlTable9,
        xlTable10,
        xlPTClassic,
        xlPTNone
    }

    public enum XlPivotLineType
    {
        xlPivotLineRegular,
        xlPivotLineSubtotal,
        xlPivotLineGrandTotal,
        xlPivotLineBlank
    }

    public enum XlPivotTableMissingItems
    {
        xlMissingItemsDefault = -1,
        xlMissingItemsMax = 0x7ef4,
        xlMissingItemsMax2 = 0x100000,
        xlMissingItemsNone = 0
    }

    public enum XlPivotTableSourceType
    {
        xlConsolidation = 3,
        xlDatabase = 1,
        xlExternal = 2,
        xlPivotTable = -4148,
        xlScenario = 4
    }

    public enum XlPivotTableVersionList
    {
        xlPivotTableVersion10 = 1,
        xlPivotTableVersion11 = 2,
        xlPivotTableVersion12 = 3,
        xlPivotTableVersion2000 = 0,
        xlPivotTableVersionCurrent = -1
    }

    public enum XlPlacement
    {
        xlFreeFloating = 3,
        xlMove = 2,
        xlMoveAndSize = 1
    }

    public enum XlPlatform
    {
        xlMacintosh = 1,
        xlMSDOS = 3,
        xlWindows = 2
    }

    public enum XlPrintErrors
    {
        xlPrintErrorsDisplayed,
        xlPrintErrorsBlank,
        xlPrintErrorsDash,
        xlPrintErrorsNA
    }

    public enum XlPrintLocation
    {
        xlPrintInPlace = 0x10,
        xlPrintNoComments = -4142,
        xlPrintSheetEnd = 1
    }

    public enum XlPriority
    {
        xlPriorityHigh = -4127,
        xlPriorityLow = -4134,
        xlPriorityNormal = -4143
    }

    public enum XlPropertyDisplayedIn
    {
        xlDisplayPropertyInPivotTable = 1,
        xlDisplayPropertyInPivotTableAndTooltip = 3,
        xlDisplayPropertyInTooltip = 2
    }

    public enum XlPTSelectionMode
    {
        xlBlanks = 4,
        xlButton = 15,
        xlDataAndLabel = 0,
        xlDataOnly = 2,
        xlFirstRow = 0x100,
        xlLabelOnly = 1,
        xlOrigin = 3
    }

    public enum XlQueryType
    {
        xlADORecordset = 7,
        xlDAORecordset = 2,
        xlODBCQuery = 1,
        xlOLEDBQuery = 5,
        xlTextImport = 6,
        xlWebQuery = 4
    }

    public enum XlRangeAutoFormat
    {
        xlRangeAutoFormat3DEffects1 = 13,
        xlRangeAutoFormat3DEffects2 = 14,
        xlRangeAutoFormatAccounting1 = 4,
        xlRangeAutoFormatAccounting2 = 5,
        xlRangeAutoFormatAccounting3 = 6,
        xlRangeAutoFormatAccounting4 = 0x11,
        xlRangeAutoFormatClassic1 = 1,
        xlRangeAutoFormatClassic2 = 2,
        xlRangeAutoFormatClassic3 = 3,
        xlRangeAutoFormatClassicPivotTable = 0x1f,
        xlRangeAutoFormatColor1 = 7,
        xlRangeAutoFormatColor2 = 8,
        xlRangeAutoFormatColor3 = 9,
        xlRangeAutoFormatList1 = 10,
        xlRangeAutoFormatList2 = 11,
        xlRangeAutoFormatList3 = 12,
        xlRangeAutoFormatLocalFormat1 = 15,
        xlRangeAutoFormatLocalFormat2 = 0x10,
        xlRangeAutoFormatLocalFormat3 = 0x13,
        xlRangeAutoFormatLocalFormat4 = 20,
        xlRangeAutoFormatNone = -4142,
        xlRangeAutoFormatPTNone = 0x2a,
        xlRangeAutoFormatReport1 = 0x15,
        xlRangeAutoFormatReport10 = 30,
        xlRangeAutoFormatReport2 = 0x16,
        xlRangeAutoFormatReport3 = 0x17,
        xlRangeAutoFormatReport4 = 0x18,
        xlRangeAutoFormatReport5 = 0x19,
        xlRangeAutoFormatReport6 = 0x1a,
        xlRangeAutoFormatReport7 = 0x1b,
        xlRangeAutoFormatReport8 = 0x1c,
        xlRangeAutoFormatReport9 = 0x1d,
        xlRangeAutoFormatSimple = -4154,
        xlRangeAutoFormatTable1 = 0x20,
        xlRangeAutoFormatTable10 = 0x29,
        xlRangeAutoFormatTable2 = 0x21,
        xlRangeAutoFormatTable3 = 0x22,
        xlRangeAutoFormatTable4 = 0x23,
        xlRangeAutoFormatTable5 = 0x24,
        xlRangeAutoFormatTable6 = 0x25,
        xlRangeAutoFormatTable7 = 0x26,
        xlRangeAutoFormatTable8 = 0x27,
        xlRangeAutoFormatTable9 = 40
    }

    public enum XlRangeValueDataType
    {
        xlRangeValueDefault = 10,
        xlRangeValueMSPersistXML = 12,
        xlRangeValueXMLSpreadsheet = 11
    }

    public enum XlReferenceStyle
    {
        xlA1 = 1,
        xlR1C1 = -4150
    }

    public enum XlReferenceType
    {
        xlAbsolute = 1,
        xlAbsRowRelColumn = 2,
        xlRelative = 4,
        xlRelRowAbsColumn = 3
    }

    public enum XlRemoveDocInfoType
    {
        xlRDIAll = 0x63,
        xlRDIComments = 1,
        xlRDIContentType = 0x10,
        xlRDIDefinedNameComments = 0x12,
        xlRDIDocumentManagementPolicy = 15,
        xlRDIDocumentProperties = 8,
        xlRDIDocumentServerProperties = 14,
        xlRDIDocumentWorkspace = 10,
        xlRDIEmailHeader = 5,
        xlRDIInactiveDataConnections = 0x13,
        xlRDIInkAnnotations = 11,
        xlRDIPrinterPath = 20,
        xlRDIPublishInfo = 13,
        xlRDIRemovePersonalInformation = 4,
        xlRDIRoutingSlip = 6,
        xlRDIScenarioComments = 12,
        xlRDISendForReview = 7
    }

    public enum XlRgbColor
    {
        rgbAliceBlue = 0xfff8f0,
        rgbAntiqueWhite = 0xd7ebfa,
        rgbAqua = 0xffff00,
        rgbAquamarine = 0xd4ff7f,
        rgbAzure = 0xfffff0,
        rgbBeige = 0xdcf5f5,
        rgbBisque = 0xc4e4ff,
        rgbBlack = 0,
        rgbBlanchedAlmond = 0xcdebff,
        rgbBlue = 0xff0000,
        rgbBlueViolet = 0xe22b8a,
        rgbBrown = 0x2a2aa5,
        rgbBurlyWood = 0x87b8de,
        rgbCadetBlue = 0xa09e5f,
        rgbChartreuse = 0xff7f,
        rgbCoral = 0x507fff,
        rgbCornflowerBlue = 0xed9564,
        rgbCornsilk = 0xdcf8ff,
        rgbCrimson = 0x3c14dc,
        rgbDarkBlue = 0x8b0000,
        rgbDarkCyan = 0x8b8b00,
        rgbDarkGoldenrod = 0xb86b8,
        rgbDarkGray = 0xa9a9a9,
        rgbDarkGreen = 0x6400,
        rgbDarkGrey = 0xa9a9a9,
        rgbDarkKhaki = 0x6bb7bd,
        rgbDarkMagenta = 0x8b008b,
        rgbDarkOliveGreen = 0x2f6b55,
        rgbDarkOrange = 0x8cff,
        rgbDarkOrchid = 0xcc3299,
        rgbDarkRed = 0x8b,
        rgbDarkSalmon = 0x7a96e9,
        rgbDarkSeaGreen = 0x8fbc8f,
        rgbDarkSlateBlue = 0x8b3d48,
        rgbDarkSlateGray = 0x4f4f2f,
        rgbDarkSlateGrey = 0x4f4f2f,
        rgbDarkTurquoise = 0xd1ce00,
        rgbDarkViolet = 0xd30094,
        rgbDeepPink = 0x9314ff,
        rgbDeepSkyBlue = 0xffbf00,
        rgbDimGray = 0x696969,
        rgbDimGrey = 0x696969,
        rgbDodgerBlue = 0xff901e,
        rgbFireBrick = 0x2222b2,
        rgbFloralWhite = 0xf0faff,
        rgbForestGreen = 0x228b22,
        rgbFuchsia = 0xff00ff,
        rgbGainsboro = 0xdcdcdc,
        rgbGhostWhite = 0xfff8f8,
        rgbGold = 0xd7ff,
        rgbGoldenrod = 0x20a5da,
        rgbGray = 0x808080,
        rgbGreen = 0x8000,
        rgbGreenYellow = 0x2fffad,
        rgbGrey = 0x808080,
        rgbHoneydew = 0xf0fff0,
        rgbHotPink = 0xb469ff,
        rgbIndianRed = 0x5c5ccd,
        rgbIndigo = 0x82004b,
        rgbIvory = 0xf0ffff,
        rgbKhaki = 0x8ce6f0,
        rgbLavender = 0xfae6e6,
        rgbLavenderBlush = 0xf5f0ff,
        rgbLawnGreen = 0xfc7c,
        rgbLemonChiffon = 0xcdfaff,
        rgbLightBlue = 0xe6d8ad,
        rgbLightCoral = 0x8080f0,
        rgbLightCyan = 0x8b8b00,
        rgbLightGoldenrodYellow = 0xd2fafa,
        rgbLightGray = 0xd3d3d3,
        rgbLightGreen = 0x90ee90,
        rgbLightGrey = 0xd3d3d3,
        rgbLightPink = 0xc1b6ff,
        rgbLightSalmon = 0x7aa0ff,
        rgbLightSeaGreen = 0xaab220,
        rgbLightSkyBlue = 0xface87,
        rgbLightSlateGray = 0x998877,
        rgbLightSlateGrey = 0x998877,
        rgbLightSteelBlue = 0xdec4b0,
        rgbLightYellow = 0xe0ffff,
        rgbLime = 0xff00,
        rgbLimeGreen = 0x32cd32,
        rgbLinen = 0xe6f0fa,
        rgbMaroon = 0x80,
        rgbMediumAquamarine = 0xaaff66,
        rgbMediumBlue = 0xcd0000,
        rgbMediumOrchid = 0xd355ba,
        rgbMediumPurple = 0xdb7093,
        rgbMediumSeaGreen = 0x71b33c,
        rgbMediumSlateBlue = 0xee687b,
        rgbMediumSpringGreen = 0x9afa00,
        rgbMediumTurquoise = 0xccd148,
        rgbMediumVioletRed = 0x8515c7,
        rgbMidnightBlue = 0x701919,
        rgbMintCream = 0xfafff5,
        rgbMistyRose = 0xe1e4ff,
        rgbMoccasin = 0xb5e4ff,
        rgbNavajoWhite = 0xaddeff,
        rgbNavy = 0x800000,
        rgbNavyBlue = 0x800000,
        rgbOldLace = 0xe6f5fd,
        rgbOlive = 0x8080,
        rgbOliveDrab = 0x238e6b,
        rgbOrange = 0xa5ff,
        rgbOrangeRed = 0x45ff,
        rgbOrchid = 0xd670da,
        rgbPaleGoldenrod = 0x6be8ee,
        rgbPaleGreen = 0x98fb98,
        rgbPaleTurquoise = 0xeeeeaf,
        rgbPaleVioletRed = 0x9370db,
        rgbPapayaWhip = 0xd5efff,
        rgbPeachPuff = 0xb9daff,
        rgbPeru = 0x3f85cd,
        rgbPink = 0xcbc0ff,
        rgbPlum = 0xdda0dd,
        rgbPowderBlue = 0xe6e0b0,
        rgbPurple = 0x800080,
        rgbRed = 0xff,
        rgbRosyBrown = 0x8f8fbc,
        rgbRoyalBlue = 0xe16941,
        rgbSalmon = 0x7280fa,
        rgbSandyBrown = 0x60a4f4,
        rgbSeaGreen = 0x578b2e,
        rgbSeashell = 0xeef5ff,
        rgbSienna = 0x2d52a0,
        rgbSilver = 0xc0c0c0,
        rgbSkyBlue = 0xebce87,
        rgbSlateBlue = 0xcd5a6a,
        rgbSlateGray = 0x908070,
        rgbSlateGrey = 0x908070,
        rgbSnow = 0xfafaff,
        rgbSpringGreen = 0x7fff00,
        rgbSteelBlue = 0xb48246,
        rgbTan = 0x8cb4d2,
        rgbTeal = 0x808000,
        rgbThistle = 0xd8bfd8,
        rgbTomato = 0x4763ff,
        rgbTurquoise = 0xd0e040,
        rgbViolet = 0xee82ee,
        rgbWheat = 0xb3def5,
        rgbWhite = 0xffffff,
        rgbWhiteSmoke = 0xf5f5f5,
        rgbYellow = 0xffff,
        rgbYellowGreen = 0x32cd9a
    }

    public enum XlRobustConnect
    {
        xlAsRequired,
        xlAlways,
        xlNever
    }

    public enum XlRoutingSlipDelivery
    {
        xlAllAtOnce = 2,
        xlOneAfterAnother = 1
    }

    public enum XlRoutingSlipStatus
    {
        xlNotYetRouted,
        xlRoutingInProgress,
        xlRoutingComplete
    }

    public enum XlRowCol
    {
        xlColumns = 2,
        xlRows = 1
    }

    public enum XlRunAutoMacro
    {
        xlAutoActivate = 3,
        xlAutoClose = 2,
        xlAutoDeactivate = 4,
        xlAutoOpen = 1
    }

    public enum XlSaveAction
    {
        xlDoNotSaveChanges = 2,
        xlSaveChanges = 1
    }

    public enum XlSaveAsAccessMode
    {
        xlExclusive = 3,
        xlNoChange = 1,
        xlShared = 2
    }

    public enum XlSaveConflictResolution
    {
        xlLocalSessionChanges = 2,
        xlOtherSessionChanges = 3,
        xlUserResolution = 1
    }

    public enum XlScaleType
    {
        xlScaleLinear = -4132,
        xlScaleLogarithmic = -4133
    }

    public enum XlSearchDirection
    {
        xlNext = 1,
        xlPrevious = 2
    }

    public enum XlSearchOrder
    {
        xlByColumns = 2,
        xlByRows = 1
    }

    public enum XlSearchWithin
    {
        xlWithinSheet = 1,
        xlWithinWorkbook = 2
    }

    public enum XlSheetType
    {
        xlChart = -4109,
        xlDialogSheet = -4116,
        xlExcel4IntlMacroSheet = 4,
        xlExcel4MacroSheet = 3,
        xlWorksheet = -4167
    }

    public enum XlSheetVisibility
    {
        xlSheetHidden = 0,
        xlSheetVeryHidden = 2,
        xlSheetVisible = -1
    }

    public enum XlSizeRepresents
    {
        xlSizeIsArea = 1,
        xlSizeIsWidth = 2
    }

    public enum XlSmartTagControlType
    {
        xlSmartTagControlActiveX = 13,
        xlSmartTagControlButton = 6,
        xlSmartTagControlCheckbox = 9,
        xlSmartTagControlCombo = 12,
        xlSmartTagControlHelp = 3,
        xlSmartTagControlHelpURL = 4,
        xlSmartTagControlImage = 8,
        xlSmartTagControlLabel = 7,
        xlSmartTagControlLink = 2,
        xlSmartTagControlListbox = 11,
        xlSmartTagControlRadioGroup = 14,
        xlSmartTagControlSeparator = 5,
        xlSmartTagControlSmartTag = 1,
        xlSmartTagControlTextbox = 10
    }

    public enum XlSmartTagDisplayMode
    {
        xlIndicatorAndButton,
        xlDisplayNone,
        xlButtonOnly
    }

    public enum XlSortDataOption
    {
        xlSortNormal,
        xlSortTextAsNumbers
    }

    public enum XlSortMethod
    {
        xlPinYin = 1,
        xlStroke = 2
    }

    public enum XlSortMethodOld
    {
        xlCodePage = 2,
        xlSyllabary = 1
    }

    public enum XlSortOn
    {
        xlSortOnValues,
        xlSortOnCellColor,
        xlSortOnFontColor,
        xlSortOnIcon
    }

    public enum XlSortOrder
    {
        xlAscending = 1,
        xlDescending = 2
    }

    public enum XlSortOrientation
    {
        xlSortColumns = 1,
        xlSortRows = 2
    }

    public enum XlSortType
    {
        xlSortLabels = 2,
        xlSortValues = 1
    }

    public enum XlSourceType
    {
        xlSourceWorkbook,
        xlSourceSheet,
        xlSourcePrintArea,
        xlSourceAutoFilter,
        xlSourceRange,
        xlSourceChart,
        xlSourcePivotTable,
        xlSourceQuery
    }

    public enum XlSpeakDirection
    {
        xlSpeakByRows,
        xlSpeakByColumns
    }

    public enum XlSpecialCellsValue
    {
        xlErrors = 0x10,
        xlLogical = 4,
        xlNumbers = 1,
        xlTextValues = 2
    }

    public enum XlStdColorScale
    {
        xlColorScaleBlackWhite = 3,
        xlColorScaleGYR = 2,
        xlColorScaleRYG = 1,
        xlColorScaleWhiteBlack = 4
    }

    public enum XlSubscribeToFormat
    {
        xlSubscribeToPicture = -4147,
        xlSubscribeToText = -4158
    }

    public enum XlSubtototalLocationType
    {
        xlAtBottom = 2,
        xlAtTop = 1
    }

    public enum XlSummaryColumn
    {
        xlSummaryOnLeft = -4131,
        xlSummaryOnRight = -4152
    }

    public enum XlSummaryReportType
    {
        xlStandardSummary = 1,
        xlSummaryPivotTable = -4148
    }

    public enum XlSummaryRow
    {
        xlSummaryAbove,
        xlSummaryBelow
    }

    public enum XlTableStyleElementType
    {
        xlBlankRow = 0x13,
        xlColumnStripe1 = 7,
        xlColumnStripe2 = 8,
        xlColumnSubheading1 = 20,
        xlColumnSubheading2 = 0x15,
        xlColumnSubheading3 = 0x16,
        xlFirstColumn = 3,
        xlFirstHeaderCell = 9,
        xlFirstTotalCell = 11,
        xlGrandTotalColumn = 4,
        xlGrandTotalRow = 2,
        xlHeaderRow = 1,
        xlLastColumn = 4,
        xlLastHeaderCell = 10,
        xlLastTotalCell = 12,
        xlPageFieldLabels = 0x1a,
        xlPageFieldValues = 0x1b,
        xlRowStripe1 = 5,
        xlRowStripe2 = 6,
        xlRowSubheading1 = 0x17,
        xlRowSubheading2 = 0x18,
        xlRowSubheading3 = 0x19,
        xlSubtotalColumn1 = 13,
        xlSubtotalColumn2 = 14,
        xlSubtotalColumn3 = 15,
        xlSubtotalRow1 = 0x10,
        xlSubtotalRow2 = 0x11,
        xlSubtotalRow3 = 0x12,
        xlTotalRow = 2,
        xlWholeTable = 0
    }

    public enum XlTabPosition
    {
        xlTabPositionFirst,
        xlTabPositionLast
    }

    public enum XlTextParsingType
    {
        xlDelimited = 1,
        xlFixedWidth = 2
    }

    public enum XlTextQualifier
    {
        xlTextQualifierDoubleQuote = 1,
        xlTextQualifierNone = -4142,
        xlTextQualifierSingleQuote = 2
    }

    public enum XlTextVisualLayoutType
    {
        xlTextVisualLTR = 1,
        xlTextVisualRTL = 2
    }

    public enum XlThemeColor
    {
        xlThemeColorAccent1 = 5,
        xlThemeColorAccent2 = 6,
        xlThemeColorAccent3 = 7,
        xlThemeColorAccent4 = 8,
        xlThemeColorAccent5 = 9,
        xlThemeColorAccent6 = 10,
        xlThemeColorDark1 = 1,
        xlThemeColorDark2 = 3,
        xlThemeColorFollowedHyperlink = 12,
        xlThemeColorHyperlink = 11,
        xlThemeColorLight1 = 2,
        xlThemeColorLight2 = 4
    }

    public enum XlThemeFont
    {
        xlThemeFontNone,
        xlThemeFontMajor,
        xlThemeFontMinor
    }

    public enum XlThreadMode
    {
        xlThreadModeAutomatic,
        xlThreadModeManual
    }

    public enum XlTickLabelOrientation
    {
        xlTickLabelOrientationAutomatic = -4105,
        xlTickLabelOrientationDownward = -4170,
        xlTickLabelOrientationHorizontal = -4128,
        xlTickLabelOrientationUpward = -4171,
        xlTickLabelOrientationVertical = -4166
    }

    public enum XlTickLabelPosition
    {
        xlTickLabelPositionHigh = -4127,
        xlTickLabelPositionLow = -4134,
        xlTickLabelPositionNextToAxis = 4,
        xlTickLabelPositionNone = -4142
    }

    public enum XlTickMark
    {
        xlTickMarkCross = 4,
        xlTickMarkInside = 2,
        xlTickMarkNone = -4142,
        xlTickMarkOutside = 3
    }

    public enum XlTimePeriods
    {
        xlToday,
        xlYesterday,
        xlLast7Days,
        xlThisWeek,
        xlLastWeek,
        xlLastMonth,
        xlTomorrow,
        xlNextWeek,
        xlNextMonth,
        xlThisMonth
    }

    public enum XlTimeUnit
    {
        xlDays,
        xlMonths,
        xlYears
    }

    public enum XlToolbarProtection
    {
        xlNoButtonChanges = 1,
        xlNoChanges = 4,
        xlNoDockingChanges = 3,
        xlNoShapeChanges = 2,
        xlToolbarProtectionNone = -4143
    }

    public enum XlTopBottom
    {
        xlTop10Bottom,
        xlTop10Top
    }

    public enum XlTotalsCalculation
    {
        xlTotalsCalculationNone,
        xlTotalsCalculationSum,
        xlTotalsCalculationAverage,
        xlTotalsCalculationCount,
        xlTotalsCalculationCountNums,
        xlTotalsCalculationMin,
        xlTotalsCalculationMax,
        xlTotalsCalculationStdDev,
        xlTotalsCalculationVar,
        xlTotalsCalculationCustom
    }

    public enum XlTrendlineType
    {
        xlExponential = 5,
        xlLinear = -4132,
        xlLogarithmic = -4133,
        xlMovingAvg = 6,
        xlPolynomial = 3,
        xlPower = 4
    }

    public enum XlUnderlineStyle
    {
        xlUnderlineStyleDouble = -4119,
        xlUnderlineStyleDoubleAccounting = 5,
        xlUnderlineStyleNone = -4142,
        xlUnderlineStyleSingle = 2,
        xlUnderlineStyleSingleAccounting = 4
    }

    public enum XlUpdateLinks
    {
        xlUpdateLinksAlways = 3,
        xlUpdateLinksNever = 2,
        xlUpdateLinksUserSetting = 1
    }

    public enum XlVAlign
    {
        xlVAlignBottom = -4107,
        xlVAlignCenter = -4108,
        xlVAlignDistributed = -4117,
        xlVAlignJustify = -4130,
        xlVAlignTop = -4160
    }

    public enum XlWBATemplate
    {
        xlWBATChart = -4109,
        xlWBATExcel4IntlMacroSheet = 4,
        xlWBATExcel4MacroSheet = 3,
        xlWBATWorksheet = -4167
    }

    public enum XlWebFormatting
    {
        xlWebFormattingAll = 1,
        xlWebFormattingNone = 3,
        xlWebFormattingRTF = 2
    }

    public enum XlWebSelectionType
    {
        xlAllTables = 2,
        xlEntirePage = 1,
        xlSpecifiedTables = 3
    }

    public enum XlWindowState
    {
        xlMaximized = -4137,
        xlMinimized = -4140,
        xlNormal = -4143
    }

    public enum XlWindowType
    {
        xlChartAsWindow = 5,
        xlChartInPlace = 4,
        xlClipboard = 3,
        xlInfo = -4129,
        xlWorkbook = 1
    }

    public enum XlWindowView
    {
        xlNormalView = 1,
        xlPageBreakPreview = 2,
        xlPageLayoutView = 3
    }

    public enum XlXLMMacroType
    {
        xlCommand = 2,
        xlFunction = 1,
        xlNotXLM = 3
    }

    public enum XlXmlExportResult
    {
        xlXmlExportSuccess,
        xlXmlExportValidationFailed
    }

    public enum XlXmlImportResult
    {
        xlXmlImportSuccess,
        xlXmlImportElementsTruncated,
        xlXmlImportValidationFailed
    }

    public enum XlXmlLoadOption
    {
        xlXmlLoadPromptUser,
        xlXmlLoadOpenXml,
        xlXmlLoadImportToList,
        xlXmlLoadMapXml
    }

    public enum XlYesNoGuess
    {
        xlGuess,
        xlYes,
        xlNo
    }
}
