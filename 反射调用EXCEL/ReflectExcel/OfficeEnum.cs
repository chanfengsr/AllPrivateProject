using System.Runtime.InteropServices;

namespace ReflectOffice.Core
{
    public enum BackstageGroupStyle
    {
        BackstageGroupStyleNormal,
        BackstageGroupStyleWarning,
        BackstageGroupStyleError
    }

    public enum CertificateDetail
    {
        certdetAvailable,
        certdetSubject,
        certdetIssuer,
        certdetExpirationDate,
        certdetThumbprint
    }

    public enum CertificateVerificationResults
    {
        certverresError,
        certverresVerifying,
        certverresUnverified,
        certverresValid,
        certverresInvalid,
        certverresExpired,
        certverresRevoked,
        certverresUntrusted
    }

    public enum ContentVerificationResults
    {
        contverresError,
        contverresVerifying,
        contverresUnverified,
        contverresValid,
        contverresModified
    }

    public enum DocProperties
    {
        offPropertyTypeBoolean = 2,
        offPropertyTypeDate = 3,
        offPropertyTypeFloat = 5,
        offPropertyTypeNumber = 1,
        offPropertyTypeString = 4
    }

    public enum EncryptionCipherMode
    {
        cipherModeECB,
        cipherModeCBC
    }

    public enum EncryptionProviderDetail
    {
        encprovdetUrl,
        encprovdetAlgorithm,
        encprovdetBlockCipher,
        encprovdetCipherBlockSize,
        encprovdetCipherMode
    }

    public enum MailFormat
    {
        mfHTML = 2,
        mfPlainText = 1,
        mfRTF = 3
    }

    public enum MsoAlertButtonType
    {
        msoAlertButtonOK,
        msoAlertButtonOKCancel,
        msoAlertButtonAbortRetryIgnore,
        msoAlertButtonYesNoCancel,
        msoAlertButtonYesNo,
        msoAlertButtonRetryCancel,
        msoAlertButtonYesAllNoCancel
    }

    public enum MsoAlertCancelType
    {
        msoAlertCancelDefault = -1,
        msoAlertCancelFifth = 4,
        msoAlertCancelFirst = 0,
        msoAlertCancelFourth = 3,
        msoAlertCancelSecond = 1,
        msoAlertCancelThird = 2
    }

    public enum MsoAlertDefaultType
    {
        msoAlertDefaultFirst,
        msoAlertDefaultSecond,
        msoAlertDefaultThird,
        msoAlertDefaultFourth,
        msoAlertDefaultFifth
    }

    public enum MsoAlertIconType
    {
        msoAlertIconNoIcon,
        msoAlertIconCritical,
        msoAlertIconQuery,
        msoAlertIconWarning,
        msoAlertIconInfo
    }

    public enum MsoAlignCmd
    {
        msoAlignLefts,
        msoAlignCenters,
        msoAlignRights,
        msoAlignTops,
        msoAlignMiddles,
        msoAlignBottoms
    }

    public enum MsoAnimationType
    {
        msoAnimationAppear = 0x20,
        msoAnimationBeginSpeaking = 4,
        msoAnimationCharacterSuccessMajor = 6,
        msoAnimationCheckingSomething = 0x67,
        msoAnimationDisappear = 0x1f,
        msoAnimationEmptyTrash = 0x74,
        msoAnimationGestureDown = 0x71,
        msoAnimationGestureLeft = 0x72,
        msoAnimationGestureRight = 0x13,
        msoAnimationGestureUp = 0x73,
        msoAnimationGetArtsy = 100,
        msoAnimationGetAttentionMajor = 11,
        msoAnimationGetAttentionMinor = 12,
        msoAnimationGetTechy = 0x65,
        msoAnimationGetWizardy = 0x66,
        msoAnimationGoodbye = 3,
        msoAnimationGreeting = 2,
        msoAnimationIdle = 1,
        msoAnimationListensToComputer = 0x1a,
        msoAnimationLookDown = 0x68,
        msoAnimationLookDownLeft = 0x69,
        msoAnimationLookDownRight = 0x6a,
        msoAnimationLookLeft = 0x6b,
        msoAnimationLookRight = 0x6c,
        msoAnimationLookUp = 0x6d,
        msoAnimationLookUpLeft = 110,
        msoAnimationLookUpRight = 0x6f,
        msoAnimationPrinting = 0x12,
        msoAnimationRestPose = 5,
        msoAnimationSaving = 0x70,
        msoAnimationSearching = 13,
        msoAnimationSendingMail = 0x19,
        msoAnimationThinking = 0x18,
        msoAnimationWorkingAtSomething = 0x17,
        msoAnimationWritingNotingSomething = 0x16
    }

    public enum MsoAppLanguageID
    {
        msoLanguageIDExeMode = 4,
        msoLanguageIDHelp = 3,
        msoLanguageIDInstall = 1,
        msoLanguageIDUI = 2,
        msoLanguageIDUIPrevious = 5
    }

    public enum MsoArrowheadLength
    {
        msoArrowheadLengthMedium = 2,
        msoArrowheadLengthMixed = -2,
        msoArrowheadLong = 3,
        msoArrowheadShort = 1
    }

    public enum MsoArrowheadStyle
    {
        msoArrowheadDiamond = 5,
        msoArrowheadNone = 1,
        msoArrowheadOpen = 3,
        msoArrowheadOval = 6,
        msoArrowheadStealth = 4,
        msoArrowheadStyleMixed = -2,
        msoArrowheadTriangle = 2
    }

    public enum MsoArrowheadWidth
    {
        msoArrowheadNarrow = 1,
        msoArrowheadWide = 3,
        msoArrowheadWidthMedium = 2,
        msoArrowheadWidthMixed = -2
    }

    public enum MsoAutomationSecurity
    {
        msoAutomationSecurityByUI = 2,
        msoAutomationSecurityForceDisable = 3,
        msoAutomationSecurityLow = 1
    }

    public enum MsoAutoShapeType
    {
        msoShape10pointStar = 0x95,
        msoShape12pointStar = 150,
        msoShape16pointStar = 0x5e,
        msoShape24pointStar = 0x5f,
        msoShape32pointStar = 0x60,
        msoShape4pointStar = 0x5b,
        msoShape5pointStar = 0x5c,
        msoShape6pointStar = 0x93,
        msoShape7pointStar = 0x94,
        msoShape8pointStar = 0x5d,
        msoShapeActionButtonBackorPrevious = 0x81,
        msoShapeActionButtonBeginning = 0x83,
        msoShapeActionButtonCustom = 0x7d,
        msoShapeActionButtonDocument = 0x86,
        msoShapeActionButtonEnd = 0x84,
        msoShapeActionButtonForwardorNext = 130,
        msoShapeActionButtonHelp = 0x7f,
        msoShapeActionButtonHome = 0x7e,
        msoShapeActionButtonInformation = 0x80,
        msoShapeActionButtonMovie = 0x88,
        msoShapeActionButtonReturn = 0x85,
        msoShapeActionButtonSound = 0x87,
        msoShapeArc = 0x19,
        msoShapeBalloon = 0x89,
        msoShapeBentArrow = 0x29,
        msoShapeBentUpArrow = 0x2c,
        msoShapeBevel = 15,
        msoShapeBlockArc = 20,
        msoShapeCan = 13,
        msoShapeChartPlus = 0xb6,
        msoShapeChartStar = 0xb5,
        msoShapeChartX = 180,
        msoShapeChevron = 0x34,
        msoShapeChord = 0xa1,
        msoShapeCircularArrow = 60,
        msoShapeCloud = 0xb3,
        msoShapeCloudCallout = 0x6c,
        msoShapeCorner = 0xa2,
        msoShapeCornerTabs = 0xa9,
        msoShapeCross = 11,
        msoShapeCube = 14,
        msoShapeCurvedDownArrow = 0x30,
        msoShapeCurvedDownRibbon = 100,
        msoShapeCurvedLeftArrow = 0x2e,
        msoShapeCurvedRightArrow = 0x2d,
        msoShapeCurvedUpArrow = 0x2f,
        msoShapeCurvedUpRibbon = 0x63,
        msoShapeDecagon = 0x90,
        msoShapeDiagonalStripe = 0x8d,
        msoShapeDiamond = 4,
        msoShapeDodecagon = 0x92,
        msoShapeDonut = 0x12,
        msoShapeDoubleBrace = 0x1b,
        msoShapeDoubleBracket = 0x1a,
        msoShapeDoubleWave = 0x68,
        msoShapeDownArrow = 0x24,
        msoShapeDownArrowCallout = 0x38,
        msoShapeDownRibbon = 0x62,
        msoShapeExplosion1 = 0x59,
        msoShapeExplosion2 = 90,
        msoShapeFlowchartAlternateProcess = 0x3e,
        msoShapeFlowchartCard = 0x4b,
        msoShapeFlowchartCollate = 0x4f,
        msoShapeFlowchartConnector = 0x49,
        msoShapeFlowchartData = 0x40,
        msoShapeFlowchartDecision = 0x3f,
        msoShapeFlowchartDelay = 0x54,
        msoShapeFlowchartDirectAccessStorage = 0x57,
        msoShapeFlowchartDisplay = 0x58,
        msoShapeFlowchartDocument = 0x43,
        msoShapeFlowchartExtract = 0x51,
        msoShapeFlowchartInternalStorage = 0x42,
        msoShapeFlowchartMagneticDisk = 0x56,
        msoShapeFlowchartManualInput = 0x47,
        msoShapeFlowchartManualOperation = 0x48,
        msoShapeFlowchartMerge = 0x52,
        msoShapeFlowchartMultidocument = 0x44,
        msoShapeFlowchartOfflineStorage = 0x8b,
        msoShapeFlowchartOffpageConnector = 0x4a,
        msoShapeFlowchartOr = 0x4e,
        msoShapeFlowchartPredefinedProcess = 0x41,
        msoShapeFlowchartPreparation = 70,
        msoShapeFlowchartProcess = 0x3d,
        msoShapeFlowchartPunchedTape = 0x4c,
        msoShapeFlowchartSequentialAccessStorage = 0x55,
        msoShapeFlowchartSort = 80,
        msoShapeFlowchartStoredData = 0x53,
        msoShapeFlowchartSummingJunction = 0x4d,
        msoShapeFlowchartTerminator = 0x45,
        msoShapeFoldedCorner = 0x10,
        msoShapeFrame = 0x9e,
        msoShapeFunnel = 0xae,
        msoShapeGear6 = 0xac,
        msoShapeGear9 = 0xad,
        msoShapeHalfFrame = 0x9f,
        msoShapeHeart = 0x15,
        msoShapeHeptagon = 0x91,
        msoShapeHexagon = 10,
        msoShapeHorizontalScroll = 0x66,
        msoShapeIsoscelesTriangle = 7,
        msoShapeLeftArrow = 0x22,
        msoShapeLeftArrowCallout = 0x36,
        msoShapeLeftBrace = 0x1f,
        msoShapeLeftBracket = 0x1d,
        msoShapeLeftCircularArrow = 0xb0,
        msoShapeLeftRightArrow = 0x25,
        msoShapeLeftRightArrowCallout = 0x39,
        msoShapeLeftRightCircularArrow = 0xb1,
        msoShapeLeftRightRibbon = 140,
        msoShapeLeftRightUpArrow = 40,
        msoShapeLeftUpArrow = 0x2b,
        msoShapeLightningBolt = 0x16,
        msoShapeLineCallout1 = 0x6d,
        msoShapeLineCallout1AccentBar = 0x71,
        msoShapeLineCallout1BorderandAccentBar = 0x79,
        msoShapeLineCallout1NoBorder = 0x75,
        msoShapeLineCallout2 = 110,
        msoShapeLineCallout2AccentBar = 0x72,
        msoShapeLineCallout2BorderandAccentBar = 0x7a,
        msoShapeLineCallout2NoBorder = 0x76,
        msoShapeLineCallout3 = 0x6f,
        msoShapeLineCallout3AccentBar = 0x73,
        msoShapeLineCallout3BorderandAccentBar = 0x7b,
        msoShapeLineCallout3NoBorder = 0x77,
        msoShapeLineCallout4 = 0x70,
        msoShapeLineCallout4AccentBar = 0x74,
        msoShapeLineCallout4BorderandAccentBar = 0x7c,
        msoShapeLineCallout4NoBorder = 120,
        msoShapeLineInverse = 0xb7,
        msoShapeMathDivide = 0xa6,
        msoShapeMathEqual = 0xa7,
        msoShapeMathMinus = 0xa4,
        msoShapeMathMultiply = 0xa5,
        msoShapeMathNotEqual = 0xa8,
        msoShapeMathPlus = 0xa3,
        msoShapeMixed = -2,
        msoShapeMoon = 0x18,
        msoShapeNonIsoscelesTrapezoid = 0x8f,
        msoShapeNoSymbol = 0x13,
        msoShapeNotchedRightArrow = 50,
        msoShapeNotPrimitive = 0x8a,
        msoShapeOctagon = 6,
        msoShapeOval = 9,
        msoShapeOvalCallout = 0x6b,
        msoShapeParallelogram = 2,
        msoShapePentagon = 0x33,
        msoShapePie = 0x8e,
        msoShapePieWedge = 0xaf,
        msoShapePlaque = 0x1c,
        msoShapePlaqueTabs = 0xab,
        msoShapeQuadArrow = 0x27,
        msoShapeQuadArrowCallout = 0x3b,
        msoShapeRectangle = 1,
        msoShapeRectangularCallout = 0x69,
        msoShapeRegularPentagon = 12,
        msoShapeRightArrow = 0x21,
        msoShapeRightArrowCallout = 0x35,
        msoShapeRightBrace = 0x20,
        msoShapeRightBracket = 30,
        msoShapeRightTriangle = 8,
        msoShapeRound1Rectangle = 0x97,
        msoShapeRound2DiagRectangle = 0x99,
        msoShapeRound2SameRectangle = 0x98,
        msoShapeRoundedRectangle = 5,
        msoShapeRoundedRectangularCallout = 0x6a,
        msoShapeSmileyFace = 0x11,
        msoShapeSnip1Rectangle = 0x9b,
        msoShapeSnip2DiagRectangle = 0x9d,
        msoShapeSnip2SameRectangle = 0x9c,
        msoShapeSnipRoundRectangle = 0x9a,
        msoShapeSquareTabs = 170,
        msoShapeStripedRightArrow = 0x31,
        msoShapeSun = 0x17,
        msoShapeSwooshArrow = 0xb2,
        msoShapeTear = 160,
        msoShapeTrapezoid = 3,
        msoShapeUpArrow = 0x23,
        msoShapeUpArrowCallout = 0x37,
        msoShapeUpDownArrow = 0x26,
        msoShapeUpDownArrowCallout = 0x3a,
        msoShapeUpRibbon = 0x61,
        msoShapeUTurnArrow = 0x2a,
        msoShapeVerticalScroll = 0x65,
        msoShapeWave = 0x67
    }

    public enum MsoAutoSize
    {
        msoAutoSizeMixed = -2,
        msoAutoSizeNone = 0,
        msoAutoSizeShapeToFitText = 1,
        msoAutoSizeTextToFitShape = 2
    }

    public enum MsoBackgroundStyleIndex
    {
        msoBackgroundStyleMixed = -2,
        msoBackgroundStyleNotAPreset = 0,
        msoBackgroundStylePreset1 = 1,
        msoBackgroundStylePreset10 = 10,
        msoBackgroundStylePreset11 = 11,
        msoBackgroundStylePreset12 = 12,
        msoBackgroundStylePreset2 = 2,
        msoBackgroundStylePreset3 = 3,
        msoBackgroundStylePreset4 = 4,
        msoBackgroundStylePreset5 = 5,
        msoBackgroundStylePreset6 = 6,
        msoBackgroundStylePreset7 = 7,
        msoBackgroundStylePreset8 = 8,
        msoBackgroundStylePreset9 = 9
    }

    public enum MsoBalloonButtonType
    {
        msoBalloonButtonAbort = -8,
        msoBalloonButtonBack = -5,
        msoBalloonButtonCancel = -2,
        msoBalloonButtonClose = -12,
        msoBalloonButtonIgnore = -9,
        msoBalloonButtonNext = -6,
        msoBalloonButtonNo = -4,
        msoBalloonButtonNull = 0,
        msoBalloonButtonOK = -1,
        msoBalloonButtonOptions = -14,
        msoBalloonButtonRetry = -7,
        msoBalloonButtonSearch = -10,
        msoBalloonButtonSnooze = -11,
        msoBalloonButtonTips = -13,
        msoBalloonButtonYes = -3,
        msoBalloonButtonYesToAll = -15
    }

    public enum MsoBalloonErrorType
    {
        msoBalloonErrorNone,
        msoBalloonErrorOther,
        msoBalloonErrorTooBig,
        msoBalloonErrorOutOfMemory,
        msoBalloonErrorBadPictureRef,
        msoBalloonErrorBadReference,
        msoBalloonErrorButtonlessModal,
        msoBalloonErrorButtonModeless,
        msoBalloonErrorBadCharacter,
        msoBalloonErrorCOMFailure,
        msoBalloonErrorCharNotTopmostForModal,
        msoBalloonErrorTooManyControls
    }

    public enum MsoBalloonType
    {
        msoBalloonTypeButtons,
        msoBalloonTypeBullets,
        msoBalloonTypeNumbers
    }

    public enum MsoBarPosition
    {
        msoBarLeft,
        msoBarTop,
        msoBarRight,
        msoBarBottom,
        msoBarFloating,
        msoBarPopup,
        msoBarMenuBar
    }

    public enum MsoBarProtection
    {
        msoBarNoChangeDock = 0x10,
        msoBarNoChangeVisible = 8,
        msoBarNoCustomize = 1,
        msoBarNoHorizontalDock = 0x40,
        msoBarNoMove = 4,
        msoBarNoProtection = 0,
        msoBarNoResize = 2,
        msoBarNoVerticalDock = 0x20
    }

    public enum MsoBarRow
    {
        msoBarRowFirst = 0,
        msoBarRowLast = -1
    }

    public enum MsoBarType
    {
        msoBarTypeNormal,
        msoBarTypeMenuBar,
        msoBarTypePopup
    }

    public enum MsoBaselineAlignment
    {
        msoBaselineAlignAuto = 5,
        msoBaselineAlignBaseline = 1,
        msoBaselineAlignCenter = 3,
        msoBaselineAlignFarEast50 = 4,
        msoBaselineAlignMixed = -2,
        msoBaselineAlignTop = 2
    }

    public enum MsoBevelType
    {
        msoBevelAngle = 6,
        msoBevelArtDeco = 13,
        msoBevelCircle = 3,
        msoBevelConvex = 8,
        msoBevelCoolSlant = 9,
        msoBevelCross = 5,
        msoBevelDivot = 10,
        msoBevelHardEdge = 12,
        msoBevelNone = 1,
        msoBevelRelaxedInset = 2,
        msoBevelRiblet = 11,
        msoBevelSlope = 4,
        msoBevelSoftRound = 7,
        msoBevelTypeMixed = -2
    }

    public enum MsoBlackWhiteMode
    {
        msoBlackWhiteAutomatic = 1,
        msoBlackWhiteBlack = 8,
        msoBlackWhiteBlackTextAndLine = 6,
        msoBlackWhiteDontShow = 10,
        msoBlackWhiteGrayOutline = 5,
        msoBlackWhiteGrayScale = 2,
        msoBlackWhiteHighContrast = 7,
        msoBlackWhiteInverseGrayScale = 4,
        msoBlackWhiteLightGrayScale = 3,
        msoBlackWhiteMixed = -2,
        msoBlackWhiteWhite = 9
    }

    public enum MsoBlogCategorySupport
    {
        msoBlogNoCategories,
        msoBlogOneCategory,
        msoBlogMultipleCategories
    }

    public enum MsoBlogImageType
    {
        msoblogImageTypeGIF = 2,
        msoblogImageTypeJPEG = 1,
        msoblogImageTypePNG = 3
    }

    public enum MsoBulletType
    {
        msoBulletMixed = -2,
        msoBulletNone = 0,
        msoBulletNumbered = 2,
        msoBulletPicture = 3,
        msoBulletUnnumbered = 1
    }

    public enum MsoButtonSetType
    {
        msoButtonSetNone,
        msoButtonSetOK,
        msoButtonSetCancel,
        msoButtonSetOkCancel,
        msoButtonSetYesNo,
        msoButtonSetYesNoCancel,
        msoButtonSetBackClose,
        msoButtonSetNextClose,
        msoButtonSetBackNextClose,
        msoButtonSetRetryCancel,
        msoButtonSetAbortRetryIgnore,
        msoButtonSetSearchClose,
        msoButtonSetBackNextSnooze,
        msoButtonSetTipsOptionsClose,
        msoButtonSetYesAllNoCancel
    }

    public enum MsoButtonState
    {
        msoButtonDown = -1,
        msoButtonMixed = 2,
        msoButtonUp = 0
    }

    public enum MsoButtonStyle
    {
        msoButtonAutomatic = 0,
        msoButtonCaption = 2,
        msoButtonIcon = 1,
        msoButtonIconAndCaption = 3,
        msoButtonIconAndCaptionBelow = 11,
        msoButtonIconAndWrapCaption = 7,
        msoButtonIconAndWrapCaptionBelow = 15,
        msoButtonWrapCaption = 14
    }

    public enum MsoButtonStyleHidden
    {
        msoButtonTextBelow = 8,
        msoButtonWrapText = 4
    }

    public enum MsoCalloutAngleType
    {
        msoCalloutAngle30 = 2,
        msoCalloutAngle45 = 3,
        msoCalloutAngle60 = 4,
        msoCalloutAngle90 = 5,
        msoCalloutAngleAutomatic = 1,
        msoCalloutAngleMixed = -2
    }

    public enum MsoCalloutDropType
    {
        msoCalloutDropBottom = 4,
        msoCalloutDropCenter = 3,
        msoCalloutDropCustom = 1,
        msoCalloutDropMixed = -2,
        msoCalloutDropTop = 2
    }

    public enum MsoCalloutType
    {
        msoCalloutFour = 4,
        msoCalloutMixed = -2,
        msoCalloutOne = 1,
        msoCalloutThree = 3,
        msoCalloutTwo = 2
    }

    public enum MsoCharacterSet
    {
        msoCharacterSetArabic = 1,
        msoCharacterSetCyrillic = 2,
        msoCharacterSetEnglishWesternEuropeanOtherLatinScript = 3,
        msoCharacterSetGreek = 4,
        msoCharacterSetHebrew = 5,
        msoCharacterSetJapanese = 6,
        msoCharacterSetKorean = 7,
        msoCharacterSetMultilingualUnicode = 8,
        msoCharacterSetSimplifiedChinese = 9,
        msoCharacterSetThai = 10,
        msoCharacterSetTraditionalChinese = 11,
        msoCharacterSetVietnamese = 12
    }

    public enum MsoChartElementType
    {
        msoElementChartFloorNone = 0x4b0,
        msoElementChartFloorShow = 0x4b1,
        msoElementChartTitleAboveChart = 2,
        msoElementChartTitleCenteredOverlay = 1,
        msoElementChartTitleNone = 0,
        msoElementChartWallNone = 0x44c,
        msoElementChartWallShow = 0x44d,
        msoElementDataLabelBestFit = 210,
        msoElementDataLabelBottom = 0xd1,
        msoElementDataLabelCenter = 0xca,
        msoElementDataLabelInsideBase = 0xcc,
        msoElementDataLabelInsideEnd = 0xcb,
        msoElementDataLabelLeft = 0xce,
        msoElementDataLabelNone = 200,
        msoElementDataLabelOutSideEnd = 0xcd,
        msoElementDataLabelRight = 0xcf,
        msoElementDataLabelShow = 0xc9,
        msoElementDataLabelTop = 0xd0,
        msoElementDataTableNone = 500,
        msoElementDataTableShow = 0x1f5,
        msoElementDataTableWithLegendKeys = 0x1f6,
        msoElementErrorBarNone = 700,
        msoElementErrorBarPercentage = 0x2be,
        msoElementErrorBarStandardDeviation = 0x2bf,
        msoElementErrorBarStandardError = 0x2bd,
        msoElementLegendBottom = 0x68,
        msoElementLegendLeft = 0x67,
        msoElementLegendLeftOverlay = 0x6a,
        msoElementLegendNone = 100,
        msoElementLegendRight = 0x65,
        msoElementLegendRightOverlay = 0x69,
        msoElementLegendTop = 0x66,
        msoElementLineDropHiLoLine = 0x324,
        msoElementLineDropLine = 0x321,
        msoElementLineHiLoLine = 0x322,
        msoElementLineNone = 800,
        msoElementLineSeriesLine = 0x323,
        msoElementPlotAreaNone = 0x3e8,
        msoElementPlotAreaShow = 0x3e9,
        msoElementPrimaryCategoryAxisBillions = 0x176,
        msoElementPrimaryCategoryAxisLogScale = 0x177,
        msoElementPrimaryCategoryAxisMillions = 0x175,
        msoElementPrimaryCategoryAxisNone = 0x15c,
        msoElementPrimaryCategoryAxisReverse = 0x15f,
        msoElementPrimaryCategoryAxisShow = 0x15d,
        msoElementPrimaryCategoryAxisThousands = 0x174,
        msoElementPrimaryCategoryAxisTitleAdjacentToAxis = 0x12d,
        msoElementPrimaryCategoryAxisTitleBelowAxis = 0x12e,
        msoElementPrimaryCategoryAxisTitleHorizontal = 0x131,
        msoElementPrimaryCategoryAxisTitleNone = 300,
        msoElementPrimaryCategoryAxisTitleRotated = 0x12f,
        msoElementPrimaryCategoryAxisTitleVertical = 0x130,
        msoElementPrimaryCategoryAxisWithoutLabels = 350,
        msoElementPrimaryCategoryGridLinesMajor = 0x14e,
        msoElementPrimaryCategoryGridLinesMinor = 0x14d,
        msoElementPrimaryCategoryGridLinesMinorMajor = 0x14f,
        msoElementPrimaryCategoryGridLinesNone = 0x14c,
        msoElementPrimaryValueAxisBillions = 0x164,
        msoElementPrimaryValueAxisLogScale = 0x165,
        msoElementPrimaryValueAxisMillions = 0x163,
        msoElementPrimaryValueAxisNone = 0x160,
        msoElementPrimaryValueAxisShow = 0x161,
        msoElementPrimaryValueAxisThousands = 0x162,
        msoElementPrimaryValueAxisTitleAdjacentToAxis = 0x132,
        msoElementPrimaryValueAxisTitleBelowAxis = 0x134,
        msoElementPrimaryValueAxisTitleHorizontal = 0x137,
        msoElementPrimaryValueAxisTitleNone = 0x132,
        msoElementPrimaryValueAxisTitleRotated = 0x135,
        msoElementPrimaryValueAxisTitleVertical = 310,
        msoElementPrimaryValueGridLinesMajor = 330,
        msoElementPrimaryValueGridLinesMinor = 0x149,
        msoElementPrimaryValueGridLinesMinorMajor = 0x14b,
        msoElementPrimaryValueGridLinesNone = 0x148,
        msoElementSecondaryCategoryAxisBillions = 0x17a,
        msoElementSecondaryCategoryAxisLogScale = 0x17b,
        msoElementSecondaryCategoryAxisMillions = 0x179,
        msoElementSecondaryCategoryAxisNone = 0x166,
        msoElementSecondaryCategoryAxisReverse = 0x169,
        msoElementSecondaryCategoryAxisShow = 0x167,
        msoElementSecondaryCategoryAxisThousands = 0x178,
        msoElementSecondaryCategoryAxisTitleAdjacentToAxis = 0x139,
        msoElementSecondaryCategoryAxisTitleBelowAxis = 0x13a,
        msoElementSecondaryCategoryAxisTitleHorizontal = 0x13d,
        msoElementSecondaryCategoryAxisTitleNone = 0x138,
        msoElementSecondaryCategoryAxisTitleRotated = 0x13b,
        msoElementSecondaryCategoryAxisTitleVertical = 0x13c,
        msoElementSecondaryCategoryAxisWithoutLabels = 360,
        msoElementSecondaryCategoryGridLinesMajor = 0x156,
        msoElementSecondaryCategoryGridLinesMinor = 0x155,
        msoElementSecondaryCategoryGridLinesMinorMajor = 0x157,
        msoElementSecondaryCategoryGridLinesNone = 340,
        msoElementSecondaryValueAxisBillions = 0x16e,
        msoElementSecondaryValueAxisLogScale = 0x16f,
        msoElementSecondaryValueAxisMillions = 0x16d,
        msoElementSecondaryValueAxisNone = 0x16a,
        msoElementSecondaryValueAxisShow = 0x16b,
        msoElementSecondaryValueAxisThousands = 0x16c,
        msoElementSecondaryValueAxisTitleAdjacentToAxis = 0x13f,
        msoElementSecondaryValueAxisTitleBelowAxis = 320,
        msoElementSecondaryValueAxisTitleHorizontal = 0x143,
        msoElementSecondaryValueAxisTitleNone = 0x13e,
        msoElementSecondaryValueAxisTitleRotated = 0x141,
        msoElementSecondaryValueAxisTitleVertical = 0x142,
        msoElementSecondaryValueGridLinesMajor = 0x152,
        msoElementSecondaryValueGridLinesMinor = 0x151,
        msoElementSecondaryValueGridLinesMinorMajor = 0x153,
        msoElementSecondaryValueGridLinesNone = 0x150,
        msoElementSeriesAxisGridLinesMajor = 0x15a,
        msoElementSeriesAxisGridLinesMinor = 0x159,
        msoElementSeriesAxisGridLinesMinorMajor = 0x15b,
        msoElementSeriesAxisGridLinesNone = 0x158,
        msoElementSeriesAxisNone = 0x170,
        msoElementSeriesAxisReverse = 0x173,
        msoElementSeriesAxisShow = 0x171,
        msoElementSeriesAxisTitleHorizontal = 0x147,
        msoElementSeriesAxisTitleNone = 0x144,
        msoElementSeriesAxisTitleRotated = 0x145,
        msoElementSeriesAxisTitleVertical = 0x146,
        msoElementSeriesAxisWithoutLabeling = 370,
        msoElementTrendlineAddExponential = 0x25a,
        msoElementTrendlineAddLinear = 0x259,
        msoElementTrendlineAddLinearForecast = 0x25b,
        msoElementTrendlineAddTwoPeriodMovingAverage = 0x25c,
        msoElementTrendlineNone = 600,
        msoElementUpDownBarsNone = 900,
        msoElementUpDownBarsShow = 0x385
    }

    public enum MsoClipboardFormat
    {
        msoClipboardFormatHTML = 2,
        msoClipboardFormatMixed = -2,
        msoClipboardFormatNative = 1,
        msoClipboardFormatPlainText = 4,
        msoClipboardFormatRTF = 3
    }

    public enum MsoColorType
    {
        msoColorTypeCMS = 4,
        msoColorTypeCMYK = 3,
        msoColorTypeInk = 5,
        msoColorTypeMixed = -2,
        msoColorTypeRGB = 1,
        msoColorTypeScheme = 2
    }

    public enum MsoComboStyle
    {
        msoComboNormal,
        msoComboLabel
    }

    public enum MsoCommandBarButtonHyperlinkType
    {
        msoCommandBarButtonHyperlinkNone,
        msoCommandBarButtonHyperlinkOpen,
        msoCommandBarButtonHyperlinkInsertPicture
    }

    public enum MsoCondition
    {
        msoConditionAnyNumberBetween = 0x22,
        msoConditionAnytime = 0x19,
        msoConditionAnytimeBetween = 0x1a,
        msoConditionAtLeast = 0x24,
        msoConditionAtMost = 0x23,
        msoConditionBeginsWith = 11,
        msoConditionDoesNotEqual = 0x21,
        msoConditionEndsWith = 12,
        msoConditionEquals = 0x20,
        msoConditionEqualsCompleted = 0x42,
        msoConditionEqualsDeferred = 0x44,
        msoConditionEqualsHigh = 60,
        msoConditionEqualsInProgress = 0x41,
        msoConditionEqualsLow = 0x3a,
        msoConditionEqualsNormal = 0x3b,
        msoConditionEqualsNotStarted = 0x40,
        msoConditionEqualsWaitingForSomeoneElse = 0x43,
        msoConditionFileTypeAllFiles = 1,
        msoConditionFileTypeBinders = 6,
        msoConditionFileTypeCalendarItem = 0x2d,
        msoConditionFileTypeContactItem = 0x2e,
        msoConditionFileTypeDatabases = 7,
        msoConditionFileTypeDataConnectionFiles = 0x33,
        msoConditionFileTypeDesignerFiles = 0x38,
        msoConditionFileTypeDocumentImagingFiles = 0x36,
        msoConditionFileTypeExcelWorkbooks = 4,
        msoConditionFileTypeJournalItem = 0x30,
        msoConditionFileTypeMailItem = 0x2c,
        msoConditionFileTypeNoteItem = 0x2f,
        msoConditionFileTypeOfficeFiles = 2,
        msoConditionFileTypeOutlookItems = 0x2b,
        msoConditionFileTypePhotoDrawFiles = 50,
        msoConditionFileTypePowerPointPresentations = 5,
        msoConditionFileTypeProjectFiles = 0x35,
        msoConditionFileTypePublisherFiles = 0x34,
        msoConditionFileTypeTaskItem = 0x31,
        msoConditionFileTypeTemplates = 8,
        msoConditionFileTypeVisioFiles = 0x37,
        msoConditionFileTypeWebPages = 0x39,
        msoConditionFileTypeWordDocuments = 3,
        msoConditionFreeText = 0x2a,
        msoConditionIncludes = 9,
        msoConditionIncludesFormsOf = 0x29,
        msoConditionIncludesNearEachOther = 13,
        msoConditionIncludesPhrase = 10,
        msoConditionInTheLast = 0x1f,
        msoConditionInTheNext = 30,
        msoConditionIsExactly = 14,
        msoConditionIsNo = 40,
        msoConditionIsNot = 15,
        msoConditionIsYes = 0x27,
        msoConditionLastMonth = 0x16,
        msoConditionLastWeek = 0x13,
        msoConditionLessThan = 0x26,
        msoConditionMoreThan = 0x25,
        msoConditionNextMonth = 0x18,
        msoConditionNextWeek = 0x15,
        msoConditionNotEqualToCompleted = 0x47,
        msoConditionNotEqualToDeferred = 0x49,
        msoConditionNotEqualToHigh = 0x3f,
        msoConditionNotEqualToInProgress = 70,
        msoConditionNotEqualToLow = 0x3d,
        msoConditionNotEqualToNormal = 0x3e,
        msoConditionNotEqualToNotStarted = 0x45,
        msoConditionNotEqualToWaitingForSomeoneElse = 0x48,
        msoConditionOn = 0x1b,
        msoConditionOnOrAfter = 0x1c,
        msoConditionOnOrBefore = 0x1d,
        msoConditionThisMonth = 0x17,
        msoConditionThisWeek = 20,
        msoConditionToday = 0x11,
        msoConditionTomorrow = 0x12,
        msoConditionYesterday = 0x10
    }

    public enum MsoConnector
    {
        msoConnectorAnd = 1,
        msoConnectorOr = 2
    }

    public enum MsoConnectorType
    {
        msoConnectorCurve = 3,
        msoConnectorElbow = 2,
        msoConnectorStraight = 1,
        msoConnectorTypeMixed = -2
    }

    public enum MsoContactCardAddressType
    {
        msoContactCardAddressTypeUnknown,
        msoContactCardAddressTypeOutlook,
        msoContactCardAddressTypeSMTP,
        msoContactCardAddressTypeIM
    }

    public enum MsoContactCardStyle
    {
        msoContactCardHover,
        msoContactCardFull
    }

    public enum MsoContactCardType
    {
        msoContactCardTypeEnterpriseContact,
        msoContactCardTypePersonalContact,
        msoContactCardTypeUnknownContact,
        msoContactCardTypeEnterpriseGroup,
        msoContactCardTypePersonalDistributionList
    }

    public enum MsoControlOLEUsage
    {
        msoControlOLEUsageNeither,
        msoControlOLEUsageServer,
        msoControlOLEUsageClient,
        msoControlOLEUsageBoth
    }

    public enum MsoControlType
    {
        msoControlCustom,
        msoControlButton,
        msoControlEdit,
        msoControlDropdown,
        msoControlComboBox,
        msoControlButtonDropdown,
        msoControlSplitDropdown,
        msoControlOCXDropdown,
        msoControlGenericDropdown,
        msoControlGraphicDropdown,
        msoControlPopup,
        msoControlGraphicPopup,
        msoControlButtonPopup,
        msoControlSplitButtonPopup,
        msoControlSplitButtonMRUPopup,
        msoControlLabel,
        msoControlExpandingGrid,
        msoControlSplitExpandingGrid,
        msoControlGrid,
        msoControlGauge,
        msoControlGraphicCombo,
        msoControlPane,
        msoControlActiveX,
        msoControlSpinner,
        msoControlLabelEx,
        msoControlWorkPane,
        msoControlAutoCompleteCombo
    }

    public enum MsoCTPDockPosition
    {
        msoCTPDockPositionLeft,
        msoCTPDockPositionTop,
        msoCTPDockPositionRight,
        msoCTPDockPositionBottom,
        msoCTPDockPositionFloating
    }

    public enum MsoCTPDockPositionRestrict
    {
        msoCTPDockPositionRestrictNone,
        msoCTPDockPositionRestrictNoChange,
        msoCTPDockPositionRestrictNoHorizontal,
        msoCTPDockPositionRestrictNoVertical
    }

    public enum MsoCustomXMLNodeType
    {
        msoCustomXMLNodeAttribute = 2,
        msoCustomXMLNodeCData = 4,
        msoCustomXMLNodeComment = 8,
        msoCustomXMLNodeDocument = 9,
        msoCustomXMLNodeElement = 1,
        msoCustomXMLNodeProcessingInstruction = 7,
        msoCustomXMLNodeText = 3
    }

    public enum MsoCustomXMLValidationErrorType
    {
        msoCustomXMLValidationErrorSchemaGenerated,
        msoCustomXMLValidationErrorAutomaticallyCleared,
        msoCustomXMLValidationErrorManual
    }

    public enum MsoDateTimeFormat
    {
        msoDateTimeddddMMMMddyyyy = 2,
        msoDateTimedMMMMyyyy = 3,
        msoDateTimedMMMyy = 5,
        msoDateTimeFigureOut = 14,
        msoDateTimeFormatMixed = -2,
        msoDateTimeHmm = 10,
        msoDateTimehmmAMPM = 12,
        msoDateTimeHmmss = 11,
        msoDateTimehmmssAMPM = 13,
        msoDateTimeMdyy = 1,
        msoDateTimeMMddyyHmm = 8,
        msoDateTimeMMddyyhmmAMPM = 9,
        msoDateTimeMMMMdyyyy = 4,
        msoDateTimeMMMMyy = 6,
        msoDateTimeMMyy = 7
    }

    public enum MsoDiagramNodeType
    {
        msoDiagramAssistant = 2,
        msoDiagramNode = 1
    }

    public enum MsoDiagramType
    {
        msoDiagramCycle = 2,
        msoDiagramMixed = -2,
        msoDiagramOrgChart = 1,
        msoDiagramPyramid = 4,
        msoDiagramRadial = 3,
        msoDiagramTarget = 6,
        msoDiagramVenn = 5
    }

    public enum MsoDistributeCmd
    {
        msoDistributeHorizontally,
        msoDistributeVertically
    }

    public enum MsoDocInspectorStatus
    {
        msoDocInspectorStatusDocOk,
        msoDocInspectorStatusIssueFound,
        msoDocInspectorStatusError
    }

    public enum MsoDocProperties
    {
        msoPropertyTypeBoolean = 2,
        msoPropertyTypeDate = 3,
        msoPropertyTypeFloat = 5,
        msoPropertyTypeNumber = 1,
        msoPropertyTypeString = 4
    }

    public enum MsoEditingType
    {
        msoEditingAuto,
        msoEditingCorner,
        msoEditingSmooth,
        msoEditingSymmetric
    }

    public enum MsoEncoding
    {
        msoEncodingArabic = 0x4e8,
        msoEncodingArabicASMO = 0x2c4,
        msoEncodingArabicAutoDetect = 0xc838,
        msoEncodingArabicTransparentASMO = 720,
        msoEncodingAutoDetect = 0xc351,
        msoEncodingBaltic = 0x4e9,
        msoEncodingCentralEuropean = 0x4e2,
        msoEncodingCyrillic = 0x4e3,
        msoEncodingCyrillicAutoDetect = 0xc833,
        msoEncodingEBCDICArabic = 0x4fc4,
        msoEncodingEBCDICDenmarkNorway = 0x4f35,
        msoEncodingEBCDICFinlandSweden = 0x4f36,
        msoEncodingEBCDICFrance = 0x4f49,
        msoEncodingEBCDICGermany = 0x4f31,
        msoEncodingEBCDICGreek = 0x4fc7,
        msoEncodingEBCDICGreekModern = 0x36b,
        msoEncodingEBCDICHebrew = 0x4fc8,
        msoEncodingEBCDICIcelandic = 0x5187,
        msoEncodingEBCDICInternational = 500,
        msoEncodingEBCDICItaly = 0x4f38,
        msoEncodingEBCDICJapaneseKatakanaExtended = 0x4f42,
        msoEncodingEBCDICJapaneseKatakanaExtendedAndJapanese = 0xc6f2,
        msoEncodingEBCDICJapaneseLatinExtendedAndJapanese = 0xc6fb,
        msoEncodingEBCDICKoreanExtended = 0x5161,
        msoEncodingEBCDICKoreanExtendedAndKorean = 0xc6f5,
        msoEncodingEBCDICLatinAmericaSpain = 0x4f3c,
        msoEncodingEBCDICMultilingualROECELatin2 = 870,
        msoEncodingEBCDICRussian = 0x5190,
        msoEncodingEBCDICSerbianBulgarian = 0x5221,
        msoEncodingEBCDICSimplifiedChineseExtendedAndSimplifiedChinese = 0xc6f7,
        msoEncodingEBCDICThai = 0x5166,
        msoEncodingEBCDICTurkish = 0x51a9,
        msoEncodingEBCDICTurkishLatin5 = 0x402,
        msoEncodingEBCDICUnitedKingdom = 0x4f3d,
        msoEncodingEBCDICUSCanada = 0x25,
        msoEncodingEBCDICUSCanadaAndJapanese = 0xc6f3,
        msoEncodingEBCDICUSCanadaAndTraditionalChinese = 0xc6f9,
        msoEncodingEUCChineseSimplifiedChinese = 0xcae0,
        msoEncodingEUCJapanese = 0xcadc,
        msoEncodingEUCKorean = 0xcaed,
        msoEncodingEUCTaiwaneseTraditionalChinese = 0xcaee,
        msoEncodingEuropa3 = 0x7149,
        msoEncodingExtAlphaLowercase = 0x5223,
        msoEncodingGreek = 0x4e5,
        msoEncodingGreekAutoDetect = 0xc835,
        msoEncodingHebrew = 0x4e7,
        msoEncodingHZGBSimplifiedChinese = 0xcec8,
        msoEncodingIA5German = 0x4e8a,
        msoEncodingIA5IRV = 0x4e89,
        msoEncodingIA5Norwegian = 0x4e8c,
        msoEncodingIA5Swedish = 0x4e8b,
        msoEncodingISCIIAssamese = 0xdeae,
        msoEncodingISCIIBengali = 0xdeab,
        msoEncodingISCIIDevanagari = 0xdeaa,
        msoEncodingISCIIGujarati = 0xdeb2,
        msoEncodingISCIIKannada = 0xdeb0,
        msoEncodingISCIIMalayalam = 0xdeb1,
        msoEncodingISCIIOriya = 0xdeaf,
        msoEncodingISCIIPunjabi = 0xdeb3,
        msoEncodingISCIITamil = 0xdeac,
        msoEncodingISCIITelugu = 0xdead,
        msoEncodingISO2022CNSimplifiedChinese = 0xc435,
        msoEncodingISO2022CNTraditionalChinese = 0xc433,
        msoEncodingISO2022JPJISX02011989 = 0xc42e,
        msoEncodingISO2022JPJISX02021984 = 0xc42d,
        msoEncodingISO2022JPNoHalfwidthKatakana = 0xc42c,
        msoEncodingISO2022KR = 0xc431,
        msoEncodingISO6937NonSpacingAccent = 0x4f2d,
        msoEncodingISO885915Latin9 = 0x6fbd,
        msoEncodingISO88591Latin1 = 0x6faf,
        msoEncodingISO88592CentralEurope = 0x6fb0,
        msoEncodingISO88593Latin3 = 0x6fb1,
        msoEncodingISO88594Baltic = 0x6fb2,
        msoEncodingISO88595Cyrillic = 0x6fb3,
        msoEncodingISO88596Arabic = 0x6fb4,
        msoEncodingISO88597Greek = 0x6fb5,
        msoEncodingISO88598Hebrew = 0x6fb6,
        msoEncodingISO88598HebrewLogical = 0x96c6,
        msoEncodingISO88599Turkish = 0x6fb7,
        msoEncodingJapaneseAutoDetect = 0xc6f4,
        msoEncodingJapaneseShiftJIS = 0x3a4,
        msoEncodingKOI8R = 0x5182,
        msoEncodingKOI8U = 0x556a,
        msoEncodingKorean = 0x3b5,
        msoEncodingKoreanAutoDetect = 0xc705,
        msoEncodingKoreanJohab = 0x551,
        msoEncodingMacArabic = 0x2714,
        msoEncodingMacCroatia = 0x2762,
        msoEncodingMacCyrillic = 0x2717,
        msoEncodingMacGreek1 = 0x2716,
        msoEncodingMacHebrew = 0x2715,
        msoEncodingMacIcelandic = 0x275f,
        msoEncodingMacJapanese = 0x2711,
        msoEncodingMacKorean = 0x2713,
        msoEncodingMacLatin2 = 0x272d,
        msoEncodingMacRoman = 0x2710,
        msoEncodingMacRomania = 0x271a,
        msoEncodingMacSimplifiedChineseGB2312 = 0x2718,
        msoEncodingMacTraditionalChineseBig5 = 0x2712,
        msoEncodingMacTurkish = 0x2761,
        msoEncodingMacUkraine = 0x2721,
        msoEncodingOEMArabic = 0x360,
        msoEncodingOEMBaltic = 0x307,
        msoEncodingOEMCanadianFrench = 0x35f,
        msoEncodingOEMCyrillic = 0x357,
        msoEncodingOEMCyrillicII = 0x362,
        msoEncodingOEMGreek437G = 0x2e1,
        msoEncodingOEMHebrew = 0x35e,
        msoEncodingOEMIcelandic = 0x35d,
        msoEncodingOEMModernGreek = 0x365,
        msoEncodingOEMMultilingualLatinI = 850,
        msoEncodingOEMMultilingualLatinII = 0x354,
        msoEncodingOEMNordic = 0x361,
        msoEncodingOEMPortuguese = 860,
        msoEncodingOEMTurkish = 0x359,
        msoEncodingOEMUnitedStates = 0x1b5,
        msoEncodingSimplifiedChineseAutoDetect = 0xc6f8,
        msoEncodingSimplifiedChineseGB18030 = 0xd698,
        msoEncodingSimplifiedChineseGBK = 0x3a8,
        msoEncodingT61 = 0x4f25,
        msoEncodingTaiwanCNS = 0x4e20,
        msoEncodingTaiwanEten = 0x4e22,
        msoEncodingTaiwanIBM5550 = 0x4e23,
        msoEncodingTaiwanTCA = 0x4e21,
        msoEncodingTaiwanTeleText = 0x4e24,
        msoEncodingTaiwanWang = 0x4e25,
        msoEncodingThai = 0x36a,
        msoEncodingTraditionalChineseAutoDetect = 0xc706,
        msoEncodingTraditionalChineseBig5 = 950,
        msoEncodingTurkish = 0x4e6,
        msoEncodingUnicodeBigEndian = 0x4b1,
        msoEncodingUnicodeLittleEndian = 0x4b0,
        msoEncodingUSASCII = 0x4e9f,
        msoEncodingUTF7 = 0xfde8,
        msoEncodingUTF8 = 0xfde9,
        msoEncodingVietnamese = 0x4ea,
        msoEncodingWestern = 0x4e4
    }

    public enum MsoExtraInfoMethod
    {
        msoMethodGet,
        msoMethodPost
    }

    public enum MsoExtrusionColorType
    {
        msoExtrusionColorAutomatic = 1,
        msoExtrusionColorCustom = 2,
        msoExtrusionColorTypeMixed = -2
    }

    public enum MsoFarEastLineBreakLanguageID
    {
        MsoFarEastLineBreakLanguageJapanese = 0x411,
        MsoFarEastLineBreakLanguageKorean = 0x412,
        MsoFarEastLineBreakLanguageSimplifiedChinese = 0x804,
        MsoFarEastLineBreakLanguageTraditionalChinese = 0x404
    }

    public enum MsoFeatureInstall
    {
        msoFeatureInstallNone,
        msoFeatureInstallOnDemand,
        msoFeatureInstallOnDemandWithUI
    }

    public enum MsoFileDialogType
    {
        msoFileDialogFilePicker = 3,
        msoFileDialogFolderPicker = 4,
        msoFileDialogOpen = 1,
        msoFileDialogSaveAs = 2
    }

    public enum MsoFileDialogView
    {
        msoFileDialogViewDetails = 2,
        msoFileDialogViewLargeIcons = 6,
        msoFileDialogViewList = 1,
        msoFileDialogViewPreview = 4,
        msoFileDialogViewProperties = 3,
        msoFileDialogViewSmallIcons = 7,
        msoFileDialogViewThumbnail = 5,
        msoFileDialogViewTiles = 9,
        msoFileDialogViewWebView = 8
    }

    public enum MsoFileFindListBy
    {
        msoListbyName = 1,
        msoListbyTitle = 2
    }

    public enum MsoFileFindOptions
    {
        msoOptionsAdd = 2,
        msoOptionsNew = 1,
        msoOptionsWithin = 3
    }

    public enum MsoFileFindSortBy
    {
        msoFileFindSortbyAuthor = 1,
        msoFileFindSortbyDateCreated = 2,
        msoFileFindSortbyDateSaved = 4,
        msoFileFindSortbyFileName = 5,
        msoFileFindSortbyLastSavedBy = 3,
        msoFileFindSortbySize = 6,
        msoFileFindSortbyTitle = 7
    }

    public enum MsoFileFindView
    {
        msoViewFileInfo = 1,
        msoViewPreview = 2,
        msoViewSummaryInfo = 3
    }

    public enum MsoFileNewAction
    {
        msoEditFile,
        msoCreateNewFile,
        msoOpenFile
    }

    public enum MsoFileNewSection
    {
        msoOpenDocument,
        msoNew,
        msoNewfromExistingFile,
        msoNewfromTemplate,
        msoBottomSection
    }

    public enum MsoFileType
    {
        msoFileTypeAllFiles = 1,
        msoFileTypeBinders = 6,
        msoFileTypeCalendarItem = 11,
        msoFileTypeContactItem = 12,
        msoFileTypeDatabases = 7,
        msoFileTypeDataConnectionFiles = 0x11,
        msoFileTypeDesignerFiles = 0x16,
        msoFileTypeDocumentImagingFiles = 20,
        msoFileTypeExcelWorkbooks = 4,
        msoFileTypeJournalItem = 14,
        msoFileTypeMailItem = 10,
        msoFileTypeNoteItem = 13,
        msoFileTypeOfficeFiles = 2,
        msoFileTypeOutlookItems = 9,
        msoFileTypePhotoDrawFiles = 0x10,
        msoFileTypePowerPointPresentations = 5,
        msoFileTypeProjectFiles = 0x13,
        msoFileTypePublisherFiles = 0x12,
        msoFileTypeTaskItem = 15,
        msoFileTypeTemplates = 8,
        msoFileTypeVisioFiles = 0x15,
        msoFileTypeWebPages = 0x17,
        msoFileTypeWordDocuments = 3
    }

    public enum MsoFileValidationMode
    {
        msoFileValidationDefault,
        msoFileValidationSkip
    }

    public enum MsoFillType
    {
        msoFillBackground = 5,
        msoFillGradient = 3,
        msoFillMixed = -2,
        msoFillPatterned = 2,
        msoFillPicture = 6,
        msoFillSolid = 1,
        msoFillTextured = 4
    }

    public enum MsoFilterComparison
    {
        msoFilterComparisonEqual,
        msoFilterComparisonNotEqual,
        msoFilterComparisonLessThan,
        msoFilterComparisonGreaterThan,
        msoFilterComparisonLessThanEqual,
        msoFilterComparisonGreaterThanEqual,
        msoFilterComparisonIsBlank,
        msoFilterComparisonIsNotBlank,
        msoFilterComparisonContains,
        msoFilterComparisonNotContains
    }

    public enum MsoFilterConjunction
    {
        msoFilterConjunctionAnd,
        msoFilterConjunctionOr
    }

    public enum MsoFlipCmd
    {
        msoFlipHorizontal,
        msoFlipVertical
    }

    public enum MsoFontLanguageIndex
    {
        msoThemeComplexScript = 2,
        msoThemeEastAsian = 3,
        msoThemeLatin = 1
    }

    public enum MsoGradientColorType
    {
        msoGradientColorMixed = -2,
        msoGradientMultiColor = 4,
        msoGradientOneColor = 1,
        msoGradientPresetColors = 3,
        msoGradientTwoColors = 2
    }

    public enum MsoGradientStyle
    {
        msoGradientDiagonalDown = 4,
        msoGradientDiagonalUp = 3,
        msoGradientFromCenter = 7,
        msoGradientFromCorner = 5,
        msoGradientFromTitle = 6,
        msoGradientHorizontal = 1,
        msoGradientMixed = -2,
        msoGradientVertical = 2
    }

    public enum MsoHorizontalAnchor
    {
        msoAnchorCenter = 2,
        msoAnchorNone = 1,
        msoHorizontalAnchorMixed = -2
    }

    public enum MsoHTMLProjectOpen
    {
        msoHTMLProjectOpenSourceView = 1,
        msoHTMLProjectOpenTextView = 2
    }

    public enum MsoHTMLProjectState
    {
        msoHTMLProjectStateDocumentLocked = 1,
        msoHTMLProjectStateDocumentProjectUnlocked = 3,
        msoHTMLProjectStateProjectLocked = 2
    }

    public enum MsoHyperlinkType
    {
        msoHyperlinkRange,
        msoHyperlinkShape,
        msoHyperlinkInlineShape
    }

    public enum MsoIconType
    {
        msoIconAlert = 2,
        msoIconAlertCritical = 7,
        msoIconAlertInfo = 4,
        msoIconAlertQuery = 6,
        msoIconAlertWarning = 5,
        msoIconNone = 0,
        msoIconTip = 3
    }

    public enum MsoIodGroup
    {
        msoIodGroupPIAs,
        msoIodGroupVSTOR35Mgd,
        msoIodGroupVSTOR40Mgd
    }

    public enum MsoLanguageID
    {
        msoLanguageIDAfrikaans = 0x436,
        msoLanguageIDAlbanian = 0x41c,
        msoLanguageIDAmharic = 0x45e,
        msoLanguageIDArabic = 0x401,
        msoLanguageIDArabicAlgeria = 0x1401,
        msoLanguageIDArabicBahrain = 0x3c01,
        msoLanguageIDArabicEgypt = 0xc01,
        msoLanguageIDArabicIraq = 0x801,
        msoLanguageIDArabicJordan = 0x2c01,
        msoLanguageIDArabicKuwait = 0x3401,
        msoLanguageIDArabicLebanon = 0x3001,
        msoLanguageIDArabicLibya = 0x1001,
        msoLanguageIDArabicMorocco = 0x1801,
        msoLanguageIDArabicOman = 0x2001,
        msoLanguageIDArabicQatar = 0x4001,
        msoLanguageIDArabicSyria = 0x2801,
        msoLanguageIDArabicTunisia = 0x1c01,
        msoLanguageIDArabicUAE = 0x3801,
        msoLanguageIDArabicYemen = 0x2401,
        msoLanguageIDArmenian = 0x42b,
        msoLanguageIDAssamese = 0x44d,
        msoLanguageIDAzeriCyrillic = 0x82c,
        msoLanguageIDAzeriLatin = 0x42c,
        msoLanguageIDBasque = 0x42d,
        msoLanguageIDBelgianDutch = 0x813,
        msoLanguageIDBelgianFrench = 0x80c,
        msoLanguageIDBengali = 0x445,
        msoLanguageIDBosnian = 0x101a,
        msoLanguageIDBosnianBosniaHerzegovinaCyrillic = 0x201a,
        msoLanguageIDBosnianBosniaHerzegovinaLatin = 0x141a,
        msoLanguageIDBrazilianPortuguese = 0x416,
        msoLanguageIDBulgarian = 0x402,
        msoLanguageIDBurmese = 0x455,
        msoLanguageIDByelorussian = 0x423,
        msoLanguageIDCatalan = 0x403,
        msoLanguageIDCherokee = 0x45c,
        msoLanguageIDChineseHongKongSAR = 0xc04,
        msoLanguageIDChineseMacaoSAR = 0x1404,
        msoLanguageIDChineseSingapore = 0x1004,
        msoLanguageIDCroatian = 0x41a,
        msoLanguageIDCzech = 0x405,
        msoLanguageIDDanish = 0x406,
        msoLanguageIDDivehi = 0x465,
        msoLanguageIDDutch = 0x413,
        [TypeLibVar((short)0x40)]
        msoLanguageIDDzongkhaBhutan = 0x851,
        msoLanguageIDEdo = 0x466,
        msoLanguageIDEnglishAUS = 0xc09,
        msoLanguageIDEnglishBelize = 0x2809,
        msoLanguageIDEnglishCanadian = 0x1009,
        msoLanguageIDEnglishCaribbean = 0x2409,
        msoLanguageIDEnglishIndonesia = 0x3809,
        msoLanguageIDEnglishIreland = 0x1809,
        msoLanguageIDEnglishJamaica = 0x2009,
        msoLanguageIDEnglishNewZealand = 0x1409,
        msoLanguageIDEnglishPhilippines = 0x3409,
        msoLanguageIDEnglishSouthAfrica = 0x1c09,
        msoLanguageIDEnglishTrinidadTobago = 0x2c09,
        msoLanguageIDEnglishUK = 0x809,
        msoLanguageIDEnglishUS = 0x409,
        msoLanguageIDEnglishZimbabwe = 0x3009,
        msoLanguageIDEstonian = 0x425,
        msoLanguageIDFaeroese = 0x438,
        msoLanguageIDFarsi = 0x429,
        msoLanguageIDFilipino = 0x464,
        msoLanguageIDFinnish = 0x40b,
        msoLanguageIDFrench = 0x40c,
        msoLanguageIDFrenchCameroon = 0x2c0c,
        msoLanguageIDFrenchCanadian = 0xc0c,
        msoLanguageIDFrenchCongoDRC = 0x240c,
        msoLanguageIDFrenchCotedIvoire = 0x300c,
        msoLanguageIDFrenchHaiti = 0x3c0c,
        msoLanguageIDFrenchLuxembourg = 0x140c,
        msoLanguageIDFrenchMali = 0x340c,
        msoLanguageIDFrenchMonaco = 0x180c,
        msoLanguageIDFrenchMorocco = 0x380c,
        msoLanguageIDFrenchReunion = 0x200c,
        msoLanguageIDFrenchSenegal = 0x280c,
        msoLanguageIDFrenchWestIndies = 0x1c0c,
        [TypeLibVar((short)0x40)]
        msoLanguageIDFrenchZaire = 0x240c,
        msoLanguageIDFrisianNetherlands = 0x462,
        msoLanguageIDFulfulde = 0x467,
        msoLanguageIDGaelicIreland = 0x83c,
        msoLanguageIDGaelicScotland = 0x43c,
        msoLanguageIDGalician = 0x456,
        msoLanguageIDGeorgian = 0x437,
        msoLanguageIDGerman = 0x407,
        msoLanguageIDGermanAustria = 0xc07,
        msoLanguageIDGermanLiechtenstein = 0x1407,
        msoLanguageIDGermanLuxembourg = 0x1007,
        msoLanguageIDGreek = 0x408,
        msoLanguageIDGuarani = 0x474,
        msoLanguageIDGujarati = 0x447,
        msoLanguageIDHausa = 0x468,
        msoLanguageIDHawaiian = 0x475,
        msoLanguageIDHebrew = 0x40d,
        msoLanguageIDHindi = 0x439,
        msoLanguageIDHungarian = 0x40e,
        msoLanguageIDIbibio = 0x469,
        msoLanguageIDIcelandic = 0x40f,
        msoLanguageIDIgbo = 0x470,
        msoLanguageIDIndonesian = 0x421,
        msoLanguageIDInuktitut = 0x45d,
        msoLanguageIDItalian = 0x410,
        msoLanguageIDJapanese = 0x411,
        msoLanguageIDKannada = 0x44b,
        msoLanguageIDKanuri = 0x471,
        msoLanguageIDKashmiri = 0x460,
        msoLanguageIDKashmiriDevanagari = 0x860,
        msoLanguageIDKazakh = 0x43f,
        msoLanguageIDKhmer = 0x453,
        msoLanguageIDKirghiz = 0x440,
        msoLanguageIDKonkani = 0x457,
        msoLanguageIDKorean = 0x412,
        msoLanguageIDKyrgyz = 0x440,
        msoLanguageIDLao = 0x454,
        msoLanguageIDLatin = 0x476,
        msoLanguageIDLatvian = 0x426,
        msoLanguageIDLithuanian = 0x427,
        [TypeLibVar((short)0x40)]
        msoLanguageIDMacedonian = 0x42f,
        msoLanguageIDMacedonianFYROM = 0x42f,
        msoLanguageIDMalayalam = 0x44c,
        msoLanguageIDMalayBruneiDarussalam = 0x83e,
        msoLanguageIDMalaysian = 0x43e,
        msoLanguageIDMaltese = 0x43a,
        msoLanguageIDManipuri = 0x458,
        msoLanguageIDMaori = 0x481,
        msoLanguageIDMarathi = 0x44e,
        msoLanguageIDMexicanSpanish = 0x80a,
        msoLanguageIDMixed = -2,
        msoLanguageIDMongolian = 0x450,
        msoLanguageIDNepali = 0x461,
        msoLanguageIDNone = 0,
        msoLanguageIDNoProofing = 0x400,
        msoLanguageIDNorwegianBokmol = 0x414,
        msoLanguageIDNorwegianNynorsk = 0x814,
        msoLanguageIDOriya = 0x448,
        msoLanguageIDOromo = 0x472,
        msoLanguageIDPashto = 0x463,
        msoLanguageIDPolish = 0x415,
        msoLanguageIDPortuguese = 0x816,
        msoLanguageIDPunjabi = 0x446,
        msoLanguageIDQuechuaBolivia = 0x46b,
        msoLanguageIDQuechuaEcuador = 0x86b,
        msoLanguageIDQuechuaPeru = 0xc6b,
        msoLanguageIDRhaetoRomanic = 0x417,
        msoLanguageIDRomanian = 0x418,
        msoLanguageIDRomanianMoldova = 0x818,
        msoLanguageIDRussian = 0x419,
        msoLanguageIDRussianMoldova = 0x819,
        msoLanguageIDSamiLappish = 0x43b,
        msoLanguageIDSanskrit = 0x44f,
        msoLanguageIDSepedi = 0x46c,
        msoLanguageIDSerbianBosniaHerzegovinaCyrillic = 0x1c1a,
        msoLanguageIDSerbianBosniaHerzegovinaLatin = 0x181a,
        msoLanguageIDSerbianCyrillic = 0xc1a,
        msoLanguageIDSerbianLatin = 0x81a,
        msoLanguageIDSesotho = 0x430,
        msoLanguageIDSimplifiedChinese = 0x804,
        msoLanguageIDSindhi = 0x459,
        msoLanguageIDSindhiPakistan = 0x859,
        msoLanguageIDSinhalese = 0x45b,
        msoLanguageIDSlovak = 0x41b,
        msoLanguageIDSlovenian = 0x424,
        msoLanguageIDSomali = 0x477,
        msoLanguageIDSorbian = 0x42e,
        msoLanguageIDSpanish = 0x40a,
        msoLanguageIDSpanishArgentina = 0x2c0a,
        msoLanguageIDSpanishBolivia = 0x400a,
        msoLanguageIDSpanishChile = 0x340a,
        msoLanguageIDSpanishColombia = 0x240a,
        msoLanguageIDSpanishCostaRica = 0x140a,
        msoLanguageIDSpanishDominicanRepublic = 0x1c0a,
        msoLanguageIDSpanishEcuador = 0x300a,
        msoLanguageIDSpanishElSalvador = 0x440a,
        msoLanguageIDSpanishGuatemala = 0x100a,
        msoLanguageIDSpanishHonduras = 0x480a,
        msoLanguageIDSpanishModernSort = 0xc0a,
        msoLanguageIDSpanishNicaragua = 0x4c0a,
        msoLanguageIDSpanishPanama = 0x180a,
        msoLanguageIDSpanishParaguay = 0x3c0a,
        msoLanguageIDSpanishPeru = 0x280a,
        msoLanguageIDSpanishPuertoRico = 0x500a,
        msoLanguageIDSpanishUruguay = 0x380a,
        msoLanguageIDSpanishVenezuela = 0x200a,
        msoLanguageIDSutu = 0x430,
        msoLanguageIDSwahili = 0x441,
        msoLanguageIDSwedish = 0x41d,
        msoLanguageIDSwedishFinland = 0x81d,
        msoLanguageIDSwissFrench = 0x100c,
        msoLanguageIDSwissGerman = 0x807,
        msoLanguageIDSwissItalian = 0x810,
        msoLanguageIDSyriac = 0x45a,
        msoLanguageIDTajik = 0x428,
        msoLanguageIDTamazight = 0x45f,
        msoLanguageIDTamazightLatin = 0x85f,
        msoLanguageIDTamil = 0x449,
        msoLanguageIDTatar = 0x444,
        msoLanguageIDTelugu = 0x44a,
        msoLanguageIDThai = 0x41e,
        msoLanguageIDTibetan = 0x451,
        msoLanguageIDTigrignaEritrea = 0x873,
        msoLanguageIDTigrignaEthiopic = 0x473,
        msoLanguageIDTraditionalChinese = 0x404,
        msoLanguageIDTsonga = 0x431,
        msoLanguageIDTswana = 0x432,
        msoLanguageIDTurkish = 0x41f,
        msoLanguageIDTurkmen = 0x442,
        msoLanguageIDUkrainian = 0x422,
        msoLanguageIDUrdu = 0x420,
        msoLanguageIDUzbekCyrillic = 0x843,
        msoLanguageIDUzbekLatin = 0x443,
        msoLanguageIDVenda = 0x433,
        msoLanguageIDVietnamese = 0x42a,
        msoLanguageIDWelsh = 0x452,
        msoLanguageIDXhosa = 0x434,
        msoLanguageIDYi = 0x478,
        msoLanguageIDYiddish = 0x43d,
        msoLanguageIDYoruba = 0x46a,
        msoLanguageIDZulu = 0x435
    }

    public enum MsoLanguageIDHidden
    {
        msoLanguageIDChineseHongKong = 0xc04,
        msoLanguageIDChineseMacao = 0x1404,
        msoLanguageIDEnglishTrinidad = 0x2c09
    }

    public enum MsoLastModified
    {
        msoLastModifiedAnyTime = 7,
        msoLastModifiedLastMonth = 5,
        msoLastModifiedLastWeek = 3,
        msoLastModifiedThisMonth = 6,
        msoLastModifiedThisWeek = 4,
        msoLastModifiedToday = 2,
        msoLastModifiedYesterday = 1
    }

    public enum MsoLightRigType
    {
        msoLightRigBalanced = 14,
        msoLightRigBrightRoom = 0x1b,
        msoLightRigChilly = 0x16,
        msoLightRigContrasting = 0x12,
        msoLightRigFlat = 0x18,
        msoLightRigFlood = 0x11,
        msoLightRigFreezing = 0x17,
        msoLightRigGlow = 0x1a,
        msoLightRigHarsh = 0x10,
        msoLightRigLegacyFlat1 = 1,
        msoLightRigLegacyFlat2 = 2,
        msoLightRigLegacyFlat3 = 3,
        msoLightRigLegacyFlat4 = 4,
        msoLightRigLegacyHarsh1 = 9,
        msoLightRigLegacyHarsh2 = 10,
        msoLightRigLegacyHarsh3 = 11,
        msoLightRigLegacyHarsh4 = 12,
        msoLightRigLegacyNormal1 = 5,
        msoLightRigLegacyNormal2 = 6,
        msoLightRigLegacyNormal3 = 7,
        msoLightRigLegacyNormal4 = 8,
        msoLightRigMixed = -2,
        msoLightRigMorning = 0x13,
        msoLightRigSoft = 15,
        msoLightRigSunrise = 20,
        msoLightRigSunset = 0x15,
        msoLightRigThreePoint = 13,
        msoLightRigTwoPoint = 0x19
    }

    public enum MsoLineDashStyle
    {
        msoLineDash = 4,
        msoLineDashDot = 5,
        msoLineDashDotDot = 6,
        msoLineDashStyleMixed = -2,
        msoLineLongDash = 7,
        msoLineLongDashDot = 8,
        msoLineLongDashDotDot = 9,
        msoLineRoundDot = 3,
        msoLineSolid = 1,
        msoLineSquareDot = 2,
        msoLineSysDash = 10,
        msoLineSysDashDot = 12,
        msoLineSysDot = 11
    }

    public enum MsoLineStyle
    {
        msoLineSingle = 1,
        msoLineStyleMixed = -2,
        msoLineThickBetweenThin = 5,
        msoLineThickThin = 4,
        msoLineThinThick = 3,
        msoLineThinThin = 2
    }

    public enum MsoMenuAnimation
    {
        msoMenuAnimationNone,
        msoMenuAnimationRandom,
        msoMenuAnimationUnfold,
        msoMenuAnimationSlide
    }

    public enum MsoMetaPropertyType
    {
        msoMetaPropertyTypeUnknown,
        msoMetaPropertyTypeBoolean,
        msoMetaPropertyTypeChoice,
        msoMetaPropertyTypeCalculated,
        msoMetaPropertyTypeComputed,
        msoMetaPropertyTypeCurrency,
        msoMetaPropertyTypeDateTime,
        msoMetaPropertyTypeFillInChoice,
        msoMetaPropertyTypeGuid,
        msoMetaPropertyTypeInteger,
        msoMetaPropertyTypeLookup,
        msoMetaPropertyTypeMultiChoiceLookup,
        msoMetaPropertyTypeMultiChoice,
        msoMetaPropertyTypeMultiChoiceFillIn,
        msoMetaPropertyTypeNote,
        msoMetaPropertyTypeNumber,
        msoMetaPropertyTypeText,
        msoMetaPropertyTypeUrl,
        msoMetaPropertyTypeUser,
        msoMetaPropertyTypeUserMulti,
        msoMetaPropertyTypeBusinessData,
        msoMetaPropertyTypeBusinessDataSecondary,
        msoMetaPropertyTypeMax
    }

    public enum MsoMixedType
    {
        msoIntegerMixed = 0x8000,
        msoSingleMixed = -2147483648
    }

    public enum MsoModeType
    {
        msoModeModal,
        msoModeAutoDown,
        msoModeModeless
    }

    public enum MsoMoveRow
    {
        msoMoveRowFirst = -4,
        msoMoveRowNbr = -1,
        msoMoveRowNext = -2,
        msoMoveRowPrev = -3
    }

    public enum MsoNumberedBulletStyle
    {
        msoBulletAlphaLCParenBoth = 8,
        msoBulletAlphaLCParenRight = 9,
        msoBulletAlphaLCPeriod = 0,
        msoBulletAlphaUCParenBoth = 10,
        msoBulletAlphaUCParenRight = 11,
        msoBulletAlphaUCPeriod = 1,
        msoBulletArabicAbjadDash = 0x18,
        msoBulletArabicAlphaDash = 0x17,
        msoBulletArabicDBPeriod = 0x1d,
        msoBulletArabicDBPlain = 0x1c,
        msoBulletArabicParenBoth = 12,
        msoBulletArabicParenRight = 2,
        msoBulletArabicPeriod = 3,
        msoBulletArabicPlain = 13,
        msoBulletCircleNumDBPlain = 0x12,
        msoBulletCircleNumWDBlackPlain = 20,
        msoBulletCircleNumWDWhitePlain = 0x13,
        msoBulletHebrewAlphaDash = 0x19,
        msoBulletHindiAlpha1Period = 40,
        msoBulletHindiAlphaPeriod = 0x24,
        msoBulletHindiNumParenRight = 0x27,
        msoBulletHindiNumPeriod = 0x25,
        msoBulletKanjiKoreanPeriod = 0x1b,
        msoBulletKanjiKoreanPlain = 0x1a,
        msoBulletKanjiSimpChinDBPeriod = 0x26,
        msoBulletRomanLCParenBoth = 4,
        msoBulletRomanLCParenRight = 5,
        msoBulletRomanLCPeriod = 6,
        msoBulletRomanUCParenBoth = 14,
        msoBulletRomanUCParenRight = 15,
        msoBulletRomanUCPeriod = 7,
        msoBulletSimpChinPeriod = 0x11,
        msoBulletSimpChinPlain = 0x10,
        msoBulletStyleMixed = -2,
        msoBulletThaiAlphaParenBoth = 0x20,
        msoBulletThaiAlphaParenRight = 0x1f,
        msoBulletThaiAlphaPeriod = 30,
        msoBulletThaiNumParenBoth = 0x23,
        msoBulletThaiNumParenRight = 0x22,
        msoBulletThaiNumPeriod = 0x21,
        msoBulletTradChinPeriod = 0x16,
        msoBulletTradChinPlain = 0x15
    }

    public enum MsoOLEMenuGroup
    {
        msoOLEMenuGroupContainer = 2,
        msoOLEMenuGroupEdit = 1,
        msoOLEMenuGroupFile = 0,
        msoOLEMenuGroupHelp = 5,
        msoOLEMenuGroupNone = -1,
        msoOLEMenuGroupObject = 3,
        msoOLEMenuGroupWindow = 4
    }

    public enum MsoOrgChartLayoutType
    {
        msoOrgChartLayoutBothHanging = 2,
        msoOrgChartLayoutDefault = 5,
        msoOrgChartLayoutLeftHanging = 3,
        msoOrgChartLayoutMixed = -2,
        msoOrgChartLayoutRightHanging = 4,
        msoOrgChartLayoutStandard = 1
    }

    public enum MsoOrgChartOrientation
    {
        msoOrgChartOrientationMixed = -2,
        msoOrgChartOrientationVertical = 1
    }

    public enum MsoOrientation
    {
        msoOrientationHorizontal = 1,
        msoOrientationMixed = -2,
        msoOrientationVertical = 2
    }

    public enum MsoParagraphAlignment
    {
        msoAlignCenter = 2,
        msoAlignDistribute = 5,
        msoAlignJustify = 4,
        msoAlignJustifyLow = 7,
        msoAlignLeft = 1,
        msoAlignMixed = -2,
        msoAlignRight = 3,
        msoAlignThaiDistribute = 6
    }

    public enum MsoPathFormat
    {
        msoPathType1 = 1,
        msoPathType2 = 2,
        msoPathType3 = 3,
        msoPathType4 = 4,
        msoPathTypeMixed = -2,
        msoPathTypeNone = 0
    }

    public enum MsoPatternType
    {
        msoPattern10Percent = 2,
        msoPattern20Percent = 3,
        msoPattern25Percent = 4,
        msoPattern30Percent = 5,
        msoPattern40Percent = 6,
        msoPattern50Percent = 7,
        msoPattern5Percent = 1,
        msoPattern60Percent = 8,
        msoPattern70Percent = 9,
        msoPattern75Percent = 10,
        msoPattern80Percent = 11,
        msoPattern90Percent = 12,
        msoPatternCross = 0x33,
        msoPatternDarkDownwardDiagonal = 15,
        msoPatternDarkHorizontal = 13,
        msoPatternDarkUpwardDiagonal = 0x10,
        msoPatternDarkVertical = 14,
        msoPatternDashedDownwardDiagonal = 0x1c,
        msoPatternDashedHorizontal = 0x20,
        msoPatternDashedUpwardDiagonal = 0x1b,
        msoPatternDashedVertical = 0x1f,
        msoPatternDiagonalBrick = 40,
        msoPatternDiagonalCross = 0x36,
        msoPatternDivot = 0x2e,
        msoPatternDottedDiamond = 0x18,
        msoPatternDottedGrid = 0x2d,
        msoPatternDownwardDiagonal = 0x34,
        msoPatternHorizontal = 0x31,
        msoPatternHorizontalBrick = 0x23,
        msoPatternLargeCheckerBoard = 0x24,
        msoPatternLargeConfetti = 0x21,
        msoPatternLargeGrid = 0x22,
        msoPatternLightDownwardDiagonal = 0x15,
        msoPatternLightHorizontal = 0x13,
        msoPatternLightUpwardDiagonal = 0x16,
        msoPatternLightVertical = 20,
        msoPatternMixed = -2,
        msoPatternNarrowHorizontal = 30,
        msoPatternNarrowVertical = 0x1d,
        msoPatternOutlinedDiamond = 0x29,
        msoPatternPlaid = 0x2a,
        msoPatternShingle = 0x2f,
        msoPatternSmallCheckerBoard = 0x11,
        msoPatternSmallConfetti = 0x25,
        msoPatternSmallGrid = 0x17,
        msoPatternSolidDiamond = 0x27,
        msoPatternSphere = 0x2b,
        msoPatternTrellis = 0x12,
        msoPatternUpwardDiagonal = 0x35,
        msoPatternVertical = 50,
        msoPatternWave = 0x30,
        msoPatternWeave = 0x2c,
        msoPatternWideDownwardDiagonal = 0x19,
        msoPatternWideUpwardDiagonal = 0x1a,
        msoPatternZigZag = 0x26
    }

    public enum MsoPermission
    {
        msoPermissionAllCommon = 0x7f,
        msoPermissionChange = 15,
        msoPermissionEdit = 2,
        msoPermissionExtract = 8,
        msoPermissionFullControl = 0x40,
        msoPermissionObjModel = 0x20,
        msoPermissionPrint = 0x10,
        msoPermissionRead = 1,
        msoPermissionSave = 4,
        msoPermissionView = 1
    }

    public enum MsoPickerField
    {
        msoPickerFieldUnknown,
        msoPickerFieldDateTime,
        msoPickerFieldNumber,
        msoPickerFieldText,
        msoPickerFieldUser,
        msoPickerFieldMax
    }

    public enum MsoPictureColorType
    {
        msoPictureAutomatic = 1,
        msoPictureBlackAndWhite = 3,
        msoPictureGrayscale = 2,
        msoPictureMixed = -2,
        msoPictureWatermark = 4
    }

    public enum MsoPictureEffectType
    {
        msoEffectNone,
        msoEffectBackgroundRemoval,
        msoEffectBlur,
        msoEffectBrightnessContrast,
        msoEffectCement,
        msoEffectCrisscrossEtching,
        msoEffectChalkSketch,
        msoEffectColorTemperature,
        msoEffectCutout,
        msoEffectFilmGrain,
        msoEffectGlass,
        msoEffectGlowDiffused,
        msoEffectGlowEdges,
        msoEffectLightScreen,
        msoEffectLineDrawing,
        msoEffectMarker,
        msoEffectMosiaicBubbles,
        msoEffectPaintBrush,
        msoEffectPaintStrokes,
        msoEffectPastelsSmooth,
        msoEffectPencilGrayscale,
        msoEffectPencilSketch,
        msoEffectPhotocopy,
        msoEffectPlasticWrap,
        msoEffectSaturation,
        msoEffectSharpenSoften,
        msoEffectTexturizer,
        msoEffectWatercolorSponge
    }

    public enum MsoPresetCamera
    {
        msoCameraIsometricBottomDown = 0x17,
        msoCameraIsometricBottomUp = 0x16,
        msoCameraIsometricLeftDown = 0x19,
        msoCameraIsometricLeftUp = 0x18,
        msoCameraIsometricOffAxis1Left = 0x1c,
        msoCameraIsometricOffAxis1Right = 0x1d,
        msoCameraIsometricOffAxis1Top = 30,
        msoCameraIsometricOffAxis2Left = 0x1f,
        msoCameraIsometricOffAxis2Right = 0x20,
        msoCameraIsometricOffAxis2Top = 0x21,
        msoCameraIsometricOffAxis3Bottom = 0x24,
        msoCameraIsometricOffAxis3Left = 0x22,
        msoCameraIsometricOffAxis3Right = 0x23,
        msoCameraIsometricOffAxis4Bottom = 0x27,
        msoCameraIsometricOffAxis4Left = 0x25,
        msoCameraIsometricOffAxis4Right = 0x26,
        msoCameraIsometricRightDown = 0x1b,
        msoCameraIsometricRightUp = 0x1a,
        msoCameraIsometricTopDown = 0x15,
        msoCameraIsometricTopUp = 20,
        msoCameraLegacyObliqueBottom = 8,
        msoCameraLegacyObliqueBottomLeft = 7,
        msoCameraLegacyObliqueBottomRight = 9,
        msoCameraLegacyObliqueFront = 5,
        msoCameraLegacyObliqueLeft = 4,
        msoCameraLegacyObliqueRight = 6,
        msoCameraLegacyObliqueTop = 2,
        msoCameraLegacyObliqueTopLeft = 1,
        msoCameraLegacyObliqueTopRight = 3,
        msoCameraLegacyPerspectiveBottom = 0x11,
        msoCameraLegacyPerspectiveBottomLeft = 0x10,
        msoCameraLegacyPerspectiveBottomRight = 0x12,
        msoCameraLegacyPerspectiveFront = 14,
        msoCameraLegacyPerspectiveLeft = 13,
        msoCameraLegacyPerspectiveRight = 15,
        msoCameraLegacyPerspectiveTop = 11,
        msoCameraLegacyPerspectiveTopLeft = 10,
        msoCameraLegacyPerspectiveTopRight = 12,
        msoCameraObliqueBottom = 0x2e,
        msoCameraObliqueBottomLeft = 0x2d,
        msoCameraObliqueBottomRight = 0x2f,
        msoCameraObliqueLeft = 0x2b,
        msoCameraObliqueRight = 0x2c,
        msoCameraObliqueTop = 0x29,
        msoCameraObliqueTopLeft = 40,
        msoCameraObliqueTopRight = 0x2a,
        msoCameraOrthographicFront = 0x13,
        msoCameraPerspectiveAbove = 0x33,
        msoCameraPerspectiveAboveLeftFacing = 0x35,
        msoCameraPerspectiveAboveRightFacing = 0x36,
        msoCameraPerspectiveBelow = 0x34,
        msoCameraPerspectiveContrastingLeftFacing = 0x37,
        msoCameraPerspectiveContrastingRightFacing = 0x38,
        msoCameraPerspectiveFront = 0x30,
        msoCameraPerspectiveHeroicExtremeLeftFacing = 0x3b,
        msoCameraPerspectiveHeroicExtremeRightFacing = 60,
        msoCameraPerspectiveHeroicLeftFacing = 0x39,
        msoCameraPerspectiveHeroicRightFacing = 0x3a,
        msoCameraPerspectiveLeft = 0x31,
        msoCameraPerspectiveRelaxed = 0x3d,
        msoCameraPerspectiveRelaxedModerately = 0x3e,
        msoCameraPerspectiveRight = 50,
        msoPresetCameraMixed = -2
    }

    public enum MsoPresetExtrusionDirection
    {
        msoExtrusionBottom = 2,
        msoExtrusionBottomLeft = 3,
        msoExtrusionBottomRight = 1,
        msoExtrusionLeft = 6,
        msoExtrusionNone = 5,
        msoExtrusionRight = 4,
        msoExtrusionTop = 8,
        msoExtrusionTopLeft = 9,
        msoExtrusionTopRight = 7,
        msoPresetExtrusionDirectionMixed = -2
    }

    public enum MsoPresetGradientType
    {
        msoGradientBrass = 20,
        msoGradientCalmWater = 8,
        msoGradientChrome = 0x15,
        msoGradientChromeII = 0x16,
        msoGradientDaybreak = 4,
        msoGradientDesert = 6,
        msoGradientEarlySunset = 1,
        msoGradientFire = 9,
        msoGradientFog = 10,
        msoGradientGold = 0x12,
        msoGradientGoldII = 0x13,
        msoGradientHorizon = 5,
        msoGradientLateSunset = 2,
        msoGradientMahogany = 15,
        msoGradientMoss = 11,
        msoGradientNightfall = 3,
        msoGradientOcean = 7,
        msoGradientParchment = 14,
        msoGradientPeacock = 12,
        msoGradientRainbow = 0x10,
        msoGradientRainbowII = 0x11,
        msoGradientSapphire = 0x18,
        msoGradientSilver = 0x17,
        msoGradientWheat = 13,
        msoPresetGradientMixed = -2
    }

    public enum MsoPresetLightingDirection
    {
        msoLightingBottom = 8,
        msoLightingBottomLeft = 7,
        msoLightingBottomRight = 9,
        msoLightingLeft = 4,
        msoLightingNone = 5,
        msoLightingRight = 6,
        msoLightingTop = 2,
        msoLightingTopLeft = 1,
        msoLightingTopRight = 3,
        msoPresetLightingDirectionMixed = -2
    }

    public enum MsoPresetLightingSoftness
    {
        msoLightingBright = 3,
        msoLightingDim = 1,
        msoLightingNormal = 2,
        msoPresetLightingSoftnessMixed = -2
    }

    public enum MsoPresetMaterial
    {
        msoMaterialClear = 13,
        msoMaterialDarkEdge = 11,
        msoMaterialFlat = 14,
        msoMaterialMatte = 1,
        msoMaterialMatte2 = 5,
        msoMaterialMetal = 3,
        msoMaterialMetal2 = 7,
        msoMaterialPlastic = 2,
        msoMaterialPlastic2 = 6,
        msoMaterialPowder = 10,
        msoMaterialSoftEdge = 12,
        msoMaterialSoftMetal = 15,
        msoMaterialTranslucentPowder = 9,
        msoMaterialWarmMatte = 8,
        msoMaterialWireFrame = 4,
        msoPresetMaterialMixed = -2
    }

    public enum MsoPresetTextEffect
    {
        msoTextEffect1 = 0,
        msoTextEffect10 = 9,
        msoTextEffect11 = 10,
        msoTextEffect12 = 11,
        msoTextEffect13 = 12,
        msoTextEffect14 = 13,
        msoTextEffect15 = 14,
        msoTextEffect16 = 15,
        msoTextEffect17 = 0x10,
        msoTextEffect18 = 0x11,
        msoTextEffect19 = 0x12,
        msoTextEffect2 = 1,
        msoTextEffect20 = 0x13,
        msoTextEffect21 = 20,
        msoTextEffect22 = 0x15,
        msoTextEffect23 = 0x16,
        msoTextEffect24 = 0x17,
        msoTextEffect25 = 0x18,
        msoTextEffect26 = 0x19,
        msoTextEffect27 = 0x1a,
        msoTextEffect28 = 0x1b,
        msoTextEffect29 = 0x1c,
        msoTextEffect3 = 2,
        msoTextEffect30 = 0x1d,
        msoTextEffect4 = 3,
        msoTextEffect5 = 4,
        msoTextEffect6 = 5,
        msoTextEffect7 = 6,
        msoTextEffect8 = 7,
        msoTextEffect9 = 8,
        msoTextEffectMixed = -2
    }

    public enum MsoPresetTextEffectShape
    {
        msoTextEffectShapeArchDownCurve = 10,
        msoTextEffectShapeArchDownPour = 14,
        msoTextEffectShapeArchUpCurve = 9,
        msoTextEffectShapeArchUpPour = 13,
        msoTextEffectShapeButtonCurve = 12,
        msoTextEffectShapeButtonPour = 0x10,
        msoTextEffectShapeCanDown = 20,
        msoTextEffectShapeCanUp = 0x13,
        msoTextEffectShapeCascadeDown = 40,
        msoTextEffectShapeCascadeUp = 0x27,
        msoTextEffectShapeChevronDown = 6,
        msoTextEffectShapeChevronUp = 5,
        msoTextEffectShapeCircleCurve = 11,
        msoTextEffectShapeCirclePour = 15,
        msoTextEffectShapeCurveDown = 0x12,
        msoTextEffectShapeCurveUp = 0x11,
        msoTextEffectShapeDeflate = 0x1a,
        msoTextEffectShapeDeflateBottom = 0x1c,
        msoTextEffectShapeDeflateInflate = 0x1f,
        msoTextEffectShapeDeflateInflateDeflate = 0x20,
        msoTextEffectShapeDeflateTop = 30,
        msoTextEffectShapeDoubleWave1 = 0x17,
        msoTextEffectShapeDoubleWave2 = 0x18,
        msoTextEffectShapeFadeDown = 0x24,
        msoTextEffectShapeFadeLeft = 0x22,
        msoTextEffectShapeFadeRight = 0x21,
        msoTextEffectShapeFadeUp = 0x23,
        msoTextEffectShapeInflate = 0x19,
        msoTextEffectShapeInflateBottom = 0x1b,
        msoTextEffectShapeInflateTop = 0x1d,
        msoTextEffectShapeMixed = -2,
        msoTextEffectShapePlainText = 1,
        msoTextEffectShapeRingInside = 7,
        msoTextEffectShapeRingOutside = 8,
        msoTextEffectShapeSlantDown = 0x26,
        msoTextEffectShapeSlantUp = 0x25,
        msoTextEffectShapeStop = 2,
        msoTextEffectShapeTriangleDown = 4,
        msoTextEffectShapeTriangleUp = 3,
        msoTextEffectShapeWave1 = 0x15,
        msoTextEffectShapeWave2 = 0x16
    }

    public enum MsoPresetTexture
    {
        msoPresetTextureMixed = -2,
        msoTextureBlueTissuePaper = 0x11,
        msoTextureBouquet = 20,
        msoTextureBrownMarble = 11,
        msoTextureCanvas = 2,
        msoTextureCork = 0x15,
        msoTextureDenim = 3,
        msoTextureFishFossil = 7,
        msoTextureGranite = 12,
        msoTextureGreenMarble = 9,
        msoTextureMediumWood = 0x18,
        msoTextureNewsprint = 13,
        msoTextureOak = 0x17,
        msoTexturePaperBag = 6,
        msoTexturePapyrus = 1,
        msoTextureParchment = 15,
        msoTexturePinkTissuePaper = 0x12,
        msoTexturePurpleMesh = 0x13,
        msoTextureRecycledPaper = 14,
        msoTextureSand = 8,
        msoTextureStationery = 0x10,
        msoTextureWalnut = 0x16,
        msoTextureWaterDroplets = 5,
        msoTextureWhiteMarble = 10,
        msoTextureWovenMat = 4
    }

    public enum MsoPresetThreeDFormat
    {
        msoPresetThreeDFormatMixed = -2,
        msoThreeD1 = 1,
        msoThreeD10 = 10,
        msoThreeD11 = 11,
        msoThreeD12 = 12,
        msoThreeD13 = 13,
        msoThreeD14 = 14,
        msoThreeD15 = 15,
        msoThreeD16 = 0x10,
        msoThreeD17 = 0x11,
        msoThreeD18 = 0x12,
        msoThreeD19 = 0x13,
        msoThreeD2 = 2,
        msoThreeD20 = 20,
        msoThreeD3 = 3,
        msoThreeD4 = 4,
        msoThreeD5 = 5,
        msoThreeD6 = 6,
        msoThreeD7 = 7,
        msoThreeD8 = 8,
        msoThreeD9 = 9
    }

    public enum MsoReflectionType
    {
        msoReflectionType1 = 1,
        msoReflectionType2 = 2,
        msoReflectionType3 = 3,
        msoReflectionType4 = 4,
        msoReflectionType5 = 5,
        msoReflectionType6 = 6,
        msoReflectionType7 = 7,
        msoReflectionType8 = 8,
        msoReflectionType9 = 9,
        msoReflectionTypeMixed = -2,
        msoReflectionTypeNone = 0
    }

    public enum MsoRelativeNodePosition
    {
        msoAfterLastSibling = 4,
        msoAfterNode = 2,
        msoBeforeFirstSibling = 3,
        msoBeforeNode = 1
    }

    public enum MsoScaleFrom
    {
        msoScaleFromTopLeft,
        msoScaleFromMiddle,
        msoScaleFromBottomRight
    }

    public enum MsoScreenSize
    {
        msoScreenSize544x376,
        msoScreenSize640x480,
        msoScreenSize720x512,
        msoScreenSize800x600,
        msoScreenSize1024x768,
        msoScreenSize1152x882,
        msoScreenSize1152x900,
        msoScreenSize1280x1024,
        msoScreenSize1600x1200,
        msoScreenSize1800x1440,
        msoScreenSize1920x1200
    }

    public enum MsoScriptLanguage
    {
        msoScriptLanguageASP = 3,
        msoScriptLanguageJava = 1,
        msoScriptLanguageOther = 4,
        msoScriptLanguageVisualBasic = 2
    }

    public enum MsoScriptLocation
    {
        msoScriptLocationInBody = 2,
        msoScriptLocationInHead = 1
    }

    public enum MsoSearchIn
    {
        msoSearchInMyComputer,
        msoSearchInOutlook,
        msoSearchInMyNetworkPlaces,
        msoSearchInCustom
    }

    public enum MsoSegmentType
    {
        msoSegmentLine,
        msoSegmentCurve
    }

    public enum MsoShadowStyle
    {
        msoShadowStyleInnerShadow = 1,
        msoShadowStyleMixed = -2,
        msoShadowStyleOuterShadow = 2
    }

    public enum MsoShadowType
    {
        msoShadow1 = 1,
        msoShadow10 = 10,
        msoShadow11 = 11,
        msoShadow12 = 12,
        msoShadow13 = 13,
        msoShadow14 = 14,
        msoShadow15 = 15,
        msoShadow16 = 0x10,
        msoShadow17 = 0x11,
        msoShadow18 = 0x12,
        msoShadow19 = 0x13,
        msoShadow2 = 2,
        msoShadow20 = 20,
        msoShadow21 = 0x15,
        msoShadow22 = 0x16,
        msoShadow23 = 0x17,
        msoShadow24 = 0x18,
        msoShadow25 = 0x19,
        msoShadow26 = 0x1a,
        msoShadow27 = 0x1b,
        msoShadow28 = 0x1c,
        msoShadow29 = 0x1d,
        msoShadow3 = 3,
        msoShadow30 = 30,
        msoShadow31 = 0x1f,
        msoShadow32 = 0x20,
        msoShadow33 = 0x21,
        msoShadow34 = 0x22,
        msoShadow35 = 0x23,
        msoShadow36 = 0x24,
        msoShadow37 = 0x25,
        msoShadow38 = 0x26,
        msoShadow39 = 0x27,
        msoShadow4 = 4,
        msoShadow40 = 40,
        msoShadow41 = 0x29,
        msoShadow42 = 0x2a,
        msoShadow43 = 0x2b,
        msoShadow5 = 5,
        msoShadow6 = 6,
        msoShadow7 = 7,
        msoShadow8 = 8,
        msoShadow9 = 9,
        msoShadowMixed = -2
    }

    public enum MsoShapeStyleIndex
    {
        msoLineStylePreset1 = 0x2711,
        msoLineStylePreset10 = 0x271a,
        msoLineStylePreset11 = 0x271b,
        msoLineStylePreset12 = 0x271c,
        msoLineStylePreset13 = 0x271d,
        msoLineStylePreset14 = 0x271e,
        msoLineStylePreset15 = 0x271f,
        msoLineStylePreset16 = 0x2720,
        msoLineStylePreset17 = 0x2721,
        msoLineStylePreset18 = 0x2722,
        msoLineStylePreset19 = 0x2723,
        msoLineStylePreset2 = 0x2712,
        msoLineStylePreset20 = 0x2724,
        msoLineStylePreset21 = 0x2725,
        msoLineStylePreset3 = 0x2713,
        msoLineStylePreset4 = 0x2714,
        msoLineStylePreset5 = 0x2715,
        msoLineStylePreset6 = 0x2716,
        msoLineStylePreset7 = 0x2717,
        msoLineStylePreset8 = 0x2718,
        msoLineStylePreset9 = 0x2719,
        msoShapeStyleMixed = -2,
        msoShapeStyleNotAPreset = 0,
        msoShapeStylePreset1 = 1,
        msoShapeStylePreset10 = 10,
        msoShapeStylePreset11 = 11,
        msoShapeStylePreset12 = 12,
        msoShapeStylePreset13 = 13,
        msoShapeStylePreset14 = 14,
        msoShapeStylePreset15 = 15,
        msoShapeStylePreset16 = 0x10,
        msoShapeStylePreset17 = 0x11,
        msoShapeStylePreset18 = 0x12,
        msoShapeStylePreset19 = 0x13,
        msoShapeStylePreset2 = 2,
        msoShapeStylePreset20 = 20,
        msoShapeStylePreset21 = 0x15,
        msoShapeStylePreset22 = 0x16,
        msoShapeStylePreset23 = 0x17,
        msoShapeStylePreset24 = 0x18,
        msoShapeStylePreset25 = 0x19,
        msoShapeStylePreset26 = 0x1a,
        msoShapeStylePreset27 = 0x1b,
        msoShapeStylePreset28 = 0x1c,
        msoShapeStylePreset29 = 0x1d,
        msoShapeStylePreset3 = 3,
        msoShapeStylePreset30 = 30,
        msoShapeStylePreset31 = 0x1f,
        msoShapeStylePreset32 = 0x20,
        msoShapeStylePreset33 = 0x21,
        msoShapeStylePreset34 = 0x22,
        msoShapeStylePreset35 = 0x23,
        msoShapeStylePreset36 = 0x24,
        msoShapeStylePreset37 = 0x25,
        msoShapeStylePreset38 = 0x26,
        msoShapeStylePreset39 = 0x27,
        msoShapeStylePreset4 = 4,
        msoShapeStylePreset40 = 40,
        msoShapeStylePreset41 = 0x29,
        msoShapeStylePreset42 = 0x2a,
        msoShapeStylePreset5 = 5,
        msoShapeStylePreset6 = 6,
        msoShapeStylePreset7 = 7,
        msoShapeStylePreset8 = 8,
        msoShapeStylePreset9 = 9
    }

    public enum MsoShapeType
    {
        msoAutoShape = 1,
        msoCallout = 2,
        msoCanvas = 20,
        msoChart = 3,
        msoComment = 4,
        msoDiagram = 0x15,
        msoEmbeddedOLEObject = 7,
        msoFormControl = 8,
        msoFreeform = 5,
        msoGroup = 6,
        msoInk = 0x16,
        msoInkComment = 0x17,
        msoLine = 9,
        msoLinkedOLEObject = 10,
        msoLinkedPicture = 11,
        msoMedia = 0x10,
        msoOLEControlObject = 12,
        msoPicture = 13,
        msoPlaceholder = 14,
        msoScriptAnchor = 0x12,
        msoShapeTypeMixed = -2,
        msoSlicer = 0x19,
        msoSmartArt = 0x18,
        msoTable = 0x13,
        msoTextBox = 0x11,
        msoTextEffect = 15
    }

    public enum MsoSharedWorkspaceTaskPriority
    {
        msoSharedWorkspaceTaskPriorityHigh = 1,
        msoSharedWorkspaceTaskPriorityLow = 3,
        msoSharedWorkspaceTaskPriorityNormal = 2
    }

    public enum MsoSharedWorkspaceTaskStatus
    {
        msoSharedWorkspaceTaskStatusCompleted = 3,
        msoSharedWorkspaceTaskStatusDeferred = 4,
        msoSharedWorkspaceTaskStatusInProgress = 2,
        msoSharedWorkspaceTaskStatusNotStarted = 1,
        msoSharedWorkspaceTaskStatusWaiting = 5
    }

    public enum MsoSignatureSubset
    {
        msoSignatureSubsetSignaturesAllSigs,
        msoSignatureSubsetSignaturesNonVisible,
        msoSignatureSubsetSignatureLines,
        msoSignatureSubsetSignatureLinesSigned,
        msoSignatureSubsetSignatureLinesUnsigned,
        msoSignatureSubsetAll
    }

    public enum MsoSmartArtNodePosition
    {
        msoSmartArtNodeAbove = 4,
        msoSmartArtNodeAfter = 2,
        msoSmartArtNodeBefore = 3,
        msoSmartArtNodeBelow = 5,
        msoSmartArtNodeDefault = 1
    }

    public enum MsoSmartArtNodeType
    {
        msoSmartArtNodeTypeAssistant = 2,
        msoSmartArtNodeTypeDefault = 1
    }

    public enum MsoSoftEdgeType
    {
        msoSoftEdgeType1 = 1,
        msoSoftEdgeType2 = 2,
        msoSoftEdgeType3 = 3,
        msoSoftEdgeType4 = 4,
        msoSoftEdgeType5 = 5,
        msoSoftEdgeType6 = 6,
        msoSoftEdgeTypeMixed = -2,
        msoSoftEdgeTypeNone = 0
    }

    public enum MsoSortBy
    {
        msoSortByFileName = 1,
        msoSortByFileType = 3,
        msoSortByLastModified = 4,
        msoSortByNone = 5,
        msoSortBySize = 2
    }

    public enum MsoSortOrder
    {
        msoSortOrderAscending = 1,
        msoSortOrderDescending = 2
    }

    public enum MsoSyncAvailableType
    {
        msoSyncAvailableNone,
        msoSyncAvailableOffline,
        msoSyncAvailableAnywhere
    }

    public enum MsoSyncCompareType
    {
        msoSyncCompareAndMerge,
        msoSyncCompareSideBySide
    }

    public enum MsoSyncConflictResolutionType
    {
        msoSyncConflictClientWins,
        msoSyncConflictServerWins,
        msoSyncConflictMerge
    }

    public enum MsoSyncErrorType
    {
        msoSyncErrorNone,
        msoSyncErrorUnauthorizedUser,
        msoSyncErrorCouldNotConnect,
        msoSyncErrorOutOfSpace,
        msoSyncErrorFileNotFound,
        msoSyncErrorFileTooLarge,
        msoSyncErrorFileInUse,
        msoSyncErrorVirusUpload,
        msoSyncErrorVirusDownload,
        msoSyncErrorUnknownUpload,
        msoSyncErrorUnknownDownload,
        msoSyncErrorCouldNotOpen,
        msoSyncErrorCouldNotUpdate,
        msoSyncErrorCouldNotCompare,
        msoSyncErrorCouldNotResolve,
        msoSyncErrorNoNetwork,
        msoSyncErrorUnknown
    }

    public enum MsoSyncEventType
    {
        msoSyncEventDownloadInitiated,
        msoSyncEventDownloadSucceeded,
        msoSyncEventDownloadFailed,
        msoSyncEventUploadInitiated,
        msoSyncEventUploadSucceeded,
        msoSyncEventUploadFailed,
        msoSyncEventDownloadNoChange,
        msoSyncEventOffline
    }

    public enum MsoSyncStatusType
    {
        msoSyncStatusConflict = 4,
        msoSyncStatusError = 6,
        msoSyncStatusLatest = 1,
        msoSyncStatusLocalChanges = 3,
        msoSyncStatusNewerAvailable = 2,
        msoSyncStatusNoSharedWorkspace = 0,
        msoSyncStatusNotRoaming = 0,
        msoSyncStatusSuspended = 5
    }

    public enum MsoSyncVersionType
    {
        msoSyncVersionLastViewed,
        msoSyncVersionServer
    }

    public enum MsoTabStopType
    {
        msoTabStopCenter = 2,
        msoTabStopDecimal = 4,
        msoTabStopLeft = 1,
        msoTabStopMixed = -2,
        msoTabStopRight = 3
    }

    public enum MsoTargetBrowser
    {
        msoTargetBrowserV3,
        msoTargetBrowserV4,
        msoTargetBrowserIE4,
        msoTargetBrowserIE5,
        msoTargetBrowserIE6
    }

    public enum MsoTextCaps
    {
        msoAllCaps = 2,
        msoCapsMixed = -2,
        msoNoCaps = 0,
        msoSmallCaps = 1
    }

    public enum MsoTextChangeCase
    {
        msoCaseLower = 2,
        msoCaseSentence = 1,
        msoCaseTitle = 4,
        msoCaseToggle = 5,
        msoCaseUpper = 3
    }

    public enum MsoTextCharWrap
    {
        msoCharWrapMixed = -2,
        msoCustomCharWrap = 3,
        msoNoCharWrap = 0,
        msoStandardCharWrap = 1,
        msoStrictCharWrap = 2
    }

    public enum MsoTextDirection
    {
        msoTextDirectionLeftToRight = 1,
        msoTextDirectionMixed = -2,
        msoTextDirectionRightToLeft = 2
    }

    public enum MsoTextEffectAlignment
    {
        msoTextEffectAlignmentCentered = 2,
        msoTextEffectAlignmentLeft = 1,
        msoTextEffectAlignmentLetterJustify = 4,
        msoTextEffectAlignmentMixed = -2,
        msoTextEffectAlignmentRight = 3,
        msoTextEffectAlignmentStretchJustify = 6,
        msoTextEffectAlignmentWordJustify = 5
    }

    public enum MsoTextFontAlign
    {
        msoFontAlignAuto = 0,
        msoFontAlignBaseline = 3,
        msoFontAlignBottom = 4,
        msoFontAlignCenter = 2,
        msoFontAlignMixed = -2,
        msoFontAlignTop = 1
    }

    public enum MsoTextOrientation
    {
        msoTextOrientationDownward = 3,
        msoTextOrientationHorizontal = 1,
        msoTextOrientationHorizontalRotatedFarEast = 6,
        msoTextOrientationMixed = -2,
        msoTextOrientationUpward = 2,
        msoTextOrientationVertical = 5,
        msoTextOrientationVerticalFarEast = 4
    }

    public enum MsoTextStrike
    {
        msoDoubleStrike = 2,
        msoNoStrike = 0,
        msoSingleStrike = 1,
        msoStrikeMixed = -2
    }

    public enum MsoTextTabAlign
    {
        msoTabAlignCenter = 1,
        msoTabAlignDecimal = 3,
        msoTabAlignLeft = 0,
        msoTabAlignMixed = -2,
        msoTabAlignRight = 2
    }

    public enum MsoTextUnderlineType
    {
        msoNoUnderline = 0,
        msoUnderlineDashHeavyLine = 8,
        msoUnderlineDashLine = 7,
        msoUnderlineDashLongHeavyLine = 10,
        msoUnderlineDashLongLine = 9,
        msoUnderlineDotDashHeavyLine = 12,
        msoUnderlineDotDashLine = 11,
        msoUnderlineDotDotDashHeavyLine = 14,
        msoUnderlineDotDotDashLine = 13,
        msoUnderlineDottedHeavyLine = 6,
        msoUnderlineDottedLine = 5,
        msoUnderlineDoubleLine = 3,
        msoUnderlineHeavyLine = 4,
        msoUnderlineMixed = -2,
        msoUnderlineSingleLine = 2,
        msoUnderlineWavyDoubleLine = 0x11,
        msoUnderlineWavyHeavyLine = 0x10,
        msoUnderlineWavyLine = 15,
        msoUnderlineWords = 1
    }

    public enum MsoTextureAlignment
    {
        msoTextureAlignmentMixed = -2,
        msoTextureBottom = 7,
        msoTextureBottomLeft = 6,
        msoTextureBottomRight = 8,
        msoTextureCenter = 4,
        msoTextureLeft = 3,
        msoTextureRight = 5,
        msoTextureTop = 1,
        msoTextureTopLeft = 0,
        msoTextureTopRight = 2
    }

    public enum MsoTextureType
    {
        msoTexturePreset = 1,
        msoTextureTypeMixed = -2,
        msoTextureUserDefined = 2
    }

    public enum MsoThemeColorIndex
    {
        msoNotThemeColor = 0,
        msoThemeColorAccent1 = 5,
        msoThemeColorAccent2 = 6,
        msoThemeColorAccent3 = 7,
        msoThemeColorAccent4 = 8,
        msoThemeColorAccent5 = 9,
        msoThemeColorAccent6 = 10,
        msoThemeColorBackground1 = 14,
        msoThemeColorBackground2 = 0x10,
        msoThemeColorDark1 = 1,
        msoThemeColorDark2 = 3,
        msoThemeColorFollowedHyperlink = 12,
        msoThemeColorHyperlink = 11,
        msoThemeColorLight1 = 2,
        msoThemeColorLight2 = 4,
        msoThemeColorMixed = -2,
        msoThemeColorText1 = 13,
        msoThemeColorText2 = 15
    }

    public enum MsoThemeColorSchemeIndex
    {
        msoThemeAccent1 = 5,
        msoThemeAccent2 = 6,
        msoThemeAccent3 = 7,
        msoThemeAccent4 = 8,
        msoThemeAccent5 = 9,
        msoThemeAccent6 = 10,
        msoThemeDark1 = 1,
        msoThemeDark2 = 3,
        msoThemeFollowedHyperlink = 12,
        msoThemeHyperlink = 11,
        msoThemeLight1 = 2,
        msoThemeLight2 = 4
    }

    public enum MsoTriState
    {
        msoCTrue = 1,
        msoFalse = 0,
        msoTriStateMixed = -2,
        msoTriStateToggle = -3,
        msoTrue = -1
    }

    public enum MsoVerticalAnchor
    {
        msoAnchorBottom = 4,
        msoAnchorBottomBaseLine = 5,
        msoAnchorMiddle = 3,
        msoAnchorTop = 1,
        msoAnchorTopBaseline = 2,
        msoVerticalAnchorMixed = -2
    }

    public enum MsoWarpFormat
    {
        msoWarpFormat1 = 0,
        msoWarpFormat10 = 9,
        msoWarpFormat11 = 10,
        msoWarpFormat12 = 11,
        msoWarpFormat13 = 12,
        msoWarpFormat14 = 13,
        msoWarpFormat15 = 14,
        msoWarpFormat16 = 15,
        msoWarpFormat17 = 0x10,
        msoWarpFormat18 = 0x11,
        msoWarpFormat19 = 0x12,
        msoWarpFormat2 = 1,
        msoWarpFormat20 = 0x13,
        msoWarpFormat21 = 20,
        msoWarpFormat22 = 0x15,
        msoWarpFormat23 = 0x16,
        msoWarpFormat24 = 0x17,
        msoWarpFormat25 = 0x18,
        msoWarpFormat26 = 0x19,
        msoWarpFormat27 = 0x1a,
        msoWarpFormat28 = 0x1b,
        msoWarpFormat29 = 0x1c,
        msoWarpFormat3 = 2,
        msoWarpFormat30 = 0x1d,
        msoWarpFormat31 = 30,
        msoWarpFormat32 = 0x1f,
        msoWarpFormat33 = 0x20,
        msoWarpFormat34 = 0x21,
        msoWarpFormat35 = 0x22,
        msoWarpFormat36 = 0x23,
        msoWarpFormat4 = 3,
        msoWarpFormat5 = 4,
        msoWarpFormat6 = 5,
        msoWarpFormat7 = 6,
        msoWarpFormat8 = 7,
        msoWarpFormat9 = 8,
        msoWarpFormatMixed = -2
    }

    public enum MsoWizardActType
    {
        msoWizardActInactive,
        msoWizardActActive,
        msoWizardActSuspend,
        msoWizardActResume
    }

    public enum MsoWizardMsgType
    {
        msoWizardMsgLocalStateOff = 2,
        msoWizardMsgLocalStateOn = 1,
        msoWizardMsgResuming = 5,
        msoWizardMsgShowHelp = 3,
        msoWizardMsgSuspending = 4
    }

    public enum MsoZOrderCmd
    {
        msoBringToFront,
        msoSendToBack,
        msoBringForward,
        msoSendBackward,
        msoBringInFrontOfText,
        msoSendBehindText
    }

    public enum RibbonControlSize
    {
        RibbonControlSizeRegular,
        RibbonControlSizeLarge
    }

    public enum SignatureDetail
    {
        sigdetLocalSigningTime,
        sigdetApplicationName,
        sigdetApplicationVersion,
        sigdetOfficeVersion,
        sigdetWindowsVersion,
        sigdetNumberOfMonitors,
        sigdetHorizResolution,
        sigdetVertResolution,
        sigdetColorDepth,
        sigdetSignedData,
        sigdetDocPreviewImg,
        sigdetIPFormHash,
        sigdetIPCurrentView,
        sigdetSignatureType,
        sigdetHashAlgorithm,
        sigdetShouldShowViewWarning,
        sigdetDelSuggSigner,
        sigdetDelSuggSignerSet,
        sigdetDelSuggSignerLine2,
        sigdetDelSuggSignerLine2Set,
        sigdetDelSuggSignerEmail,
        sigdetDelSuggSignerEmailSet
    }

    public enum SignatureLineImage
    {
        siglnimgSoftwareRequired,
        siglnimgUnsigned,
        siglnimgSignedValid,
        siglnimgSignedInvalid,
        siglnimgSigned
    }

    public enum SignatureProviderDetail
    {
        sigprovdetUrl,
        sigprovdetHashAlgorithm,
        sigprovdetUIOnly,
        sigprovdetUseOfficeUI,
        sigprovdetUseOfficeStampUI
    }

    public enum SignatureType
    {
        sigtypeUnknown,
        sigtypeNonVisible,
        sigtypeSignatureLine,
        sigtypeMax
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

    public enum XlBarShape
    {
        xlBox,
        xlPyramidToPoint,
        xlPyramidToMax,
        xlCylinder,
        xlConeToPoint,
        xlConeToMax
    }

    public enum XlBorderWeight
    {
        xlHairline = 1,
        xlMedium = -4138,
        xlThick = 4,
        xlThin = 2
    }

    public enum XlCategoryType
    {
        xlAutomaticScale = -4105,
        xlCategoryScale = 2,
        xlTimeScale = 3
    }

    public enum XlChartElementPosition
    {
        xlChartElementPositionAutomatic = -4105,
        xlChartElementPositionCustom = -4114
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

    public enum XlChartOrientation
    {
        xlDownward = -4170,
        xlHorizontal = -4128,
        xlUpward = -4171,
        xlVertical = -4166
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

    public enum XlColorIndex
    {
        xlColorIndexAutomatic = -4105,
        xlColorIndexNone = -4142
    }

    public enum XlConstants
    {
        xl3DBar = -4099,
        xl3DSurface = -4103,
        xlAbove = 0,
        xlAutomatic = -4105,
        xlBar = 2,
        xlBelow = 1,
        xlBoth = 1,
        xlBottom = -4107,
        xlCenter = -4108,
        xlChecker = 9,
        xlCircle = 8,
        xlColumn = 3,
        xlCombination = -4111,
        xlCorner = 2,
        xlCrissCross = 0x10,
        xlCross = 4,
        xlCustom = -4114,
        xlDefaultAutoFormat = -1,
        xlDiamond = 2,
        xlDistributed = -4117,
        xlFill = 5,
        xlFixedValue = 1,
        xlGeneral = 1,
        xlGray16 = 0x11,
        xlGray25 = -4124,
        xlGray50 = -4125,
        xlGray75 = -4126,
        xlGray8 = 0x12,
        xlGrid = 15,
        xlHigh = -4127,
        xlInside = 2,
        xlJustify = -4130,
        xlLeft = -4131,
        xlLightDown = 13,
        xlLightHorizontal = 11,
        xlLightUp = 14,
        xlLightVertical = 12,
        xlLow = -4134,
        xlMaximum = 2,
        xlMinimum = 4,
        xlMinusValues = 3,
        xlNextToAxis = 4,
        xlNone = -4142,
        xlOpaque = 3,
        xlOutside = 3,
        xlPercent = 2,
        xlPlus = 9,
        xlPlusValues = 2,
        xlRight = -4152,
        xlScale = 3,
        xlSemiGray75 = 10,
        xlShowLabel = 4,
        xlShowLabelAndPercent = 5,
        xlShowPercent = 3,
        xlShowValue = 2,
        xlSingle = 2,
        xlSolid = 1,
        xlSquare = 1,
        xlStar = 5,
        xlStError = 4,
        xlTop = -4160,
        xlTransparent = 2,
        xlTriangle = 3
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

    public enum XlDataLabelsType
    {
        xlDataLabelsShowBubbleSizes = 6,
        xlDataLabelsShowLabel = 4,
        xlDataLabelsShowLabelAndPercent = 5,
        xlDataLabelsShowNone = -4142,
        xlDataLabelsShowPercent = 3,
        xlDataLabelsShowValue = 2
    }

    public enum XlDisplayBlanksAs
    {
        xlInterpolated = 3,
        xlNotPlotted = 1,
        xlZero = 2
    }

    public enum XlDisplayUnit
    {
        xlDisplayUnitCustom = -4114,
        xlDisplayUnitNone = -4142,
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

    public enum XlEndStyleCap
    {
        xlCap = 1,
        xlNoCap = 2
    }

    public enum XlErrorBarDirection
    {
        xlChartX = -4168,
        xlChartY = 1
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

    public enum XlLegendPosition
    {
        xlLegendPositionBottom = -4107,
        xlLegendPositionCorner = 2,
        xlLegendPositionCustom = -4161,
        xlLegendPositionLeft = -4131,
        xlLegendPositionRight = -4152,
        xlLegendPositionTop = -4160
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

    public enum XlPieSliceIndex
    {
        xlCenterPoint = 5,
        xlInnerCenterPoint = 8,
        xlInnerClockwisePoint = 7,
        xlInnerCounterClockwisePoint = 9,
        xlMidClockwiseRadiusPoint = 4,
        xlMidCounterClockwiseRadiusPoint = 6,
        xlOuterCenterPoint = 2,
        xlOuterClockwisePoint = 3,
        xlOuterCounterClockwisePoint = 1
    }

    public enum XlPieSliceLocation
    {
        xlHorizontalCoordinate = 1,
        xlVerticalCoordinate = 2
    }

    public enum XlPivotFieldOrientation
    {
        xlHidden,
        xlRowField,
        xlColumnField,
        xlPageField,
        xlDataField
    }

    public enum XlReadingOrder
    {
        xlContext = -5002,
        xlLTR = -5003,
        xlRTL = -5004
    }

    public enum XlRowCol
    {
        xlColumns = 2,
        xlRows = 1
    }

    public enum XlScaleType
    {
        xlScaleLinear = -4132,
        xlScaleLogarithmic = -4133
    }

    public enum XlSizeRepresents
    {
        xlSizeIsArea = 1,
        xlSizeIsWidth = 2
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

    public enum XlTimeUnit
    {
        xlDays,
        xlMonths,
        xlYears
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

    public enum XlVAlign
    {
        xlVAlignBottom = -4107,
        xlVAlignCenter = -4108,
        xlVAlignDistributed = -4117,
        xlVAlignJustify = -4130,
        xlVAlignTop = -4160
    }
}
