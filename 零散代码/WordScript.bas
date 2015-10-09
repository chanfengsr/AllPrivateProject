Attribute VB_Name = "WordScript"
'����ʾ�﷨��ƴд����
Sub DontShowError()
    ActiveDocument.ShowGrammaticalErrors = True
    ActiveDocument.ShowSpellingErrors = True
End Sub


' ѡ�����ж���ֻ��doc�е�Shape����
'ɾ�����е�Ƕ��ʽͼƬ
Sub DeleteAllInlineShape()
    Dim isp As InlineShape
On Error Resume Next
    For Each isp In ActiveDocument.InlineShapes
        isp.Delete
    Next

End Sub

'docx����һ��ȫ�ɹ���doc��ֻ�ܳɹ�ǰ��3����ҳ��֮�ڵģ�
'ת�����е�Ƕ��ʽͼƬ��������ͼƬ
Sub ConvertAllInlineShape()
    Dim isp As InlineShape

    For Each isp In ActiveDocument.InlineShapes
        isp.ConvertToShape
    Next
End Sub

'ѡ�����еķ�Ƕ��ʽͼƬ
Sub SelectAllShapes()
On Error Resume Next
    ActiveDocument.Shapes.SelectAll
End Sub

'ɾ������ͼƬ������
Sub DeleteAllShapesHyperlink()
    Dim isp As InlineShape
    Dim sp As Shape

On Error Resume Next
    For Each isp In ActiveDocument.InlineShapes
        isp.Hyperlink.Delete
    Next
    
    For Each sp In ActiveDocument.Shapes
        sp.Hyperlink.Delete
    Next
End Sub

'ɾ�����еġ����ƴ��롱��ͼƬ
Sub DeleteAllCopyCodeShapes()
    Dim isp As InlineShape
    Dim sp As Shape

On Error Resume Next
    'And sp.Hyperlink.Address = "javascript:void(0);"
    For Each isp In ActiveDocument.InlineShapes
        If isp.AlternativeText = "���ƴ���" Then
            isp.Delete
        Else
            isp.AlternativeText = ""
        End If
    Next
    
    For Each sp In ActiveDocument.Shapes
        If sp.AlternativeText = "���ƴ���" Then
            sp.Delete
        Else
            sp.AlternativeText = ""
        End If
    Next
End Sub

'������ʺ��ֻ��Ķ���PDF��ʽ
Sub Save2PhonePDF()
    Dim strFileName As String
    
    strFileName = "R:\" + ActiveDocument.Name + ".pdf"

    With Selection.PageSetup
        .LineNumbering.Active = False
        .Orientation = wdOrientPortrait
        .TopMargin = CentimetersToPoints(0)
        .BottomMargin = CentimetersToPoints(0)
        .LeftMargin = CentimetersToPoints(0)
        .RightMargin = CentimetersToPoints(10)
        .Gutter = CentimetersToPoints(0)
        .HeaderDistance = CentimetersToPoints(1.5)
        .FooterDistance = CentimetersToPoints(1.75)
        .PageWidth = CentimetersToPoints(21)
        .PageHeight = CentimetersToPoints(29.7)
        .FirstPageTray = wdPrinterDefaultBin
        .OtherPagesTray = wdPrinterDefaultBin
        .SectionStart = wdSectionNewPage
        .OddAndEvenPagesHeaderFooter = False
        .DifferentFirstPageHeaderFooter = False
        .VerticalAlignment = wdAlignVerticalTop
        .SuppressEndnotes = False
        .MirrorMargins = False
        .TwoPagesOnOne = False
        .BookFoldPrinting = False
        .BookFoldRevPrinting = False
        .BookFoldPrintingSheets = 1
        .GutterPos = wdGutterPosLeft
        .LinesPage = 53
        .LayoutMode = wdLayoutModeLineGrid
    End With

    With ActiveDocument.PageSetup
        .LineNumbering.Active = False
        .Orientation = wdOrientPortrait
        .TopMargin = CentimetersToPoints(0)
        .BottomMargin = CentimetersToPoints(0)
        .LeftMargin = CentimetersToPoints(0)
        .RightMargin = CentimetersToPoints(10)
        .Gutter = CentimetersToPoints(0)
        .HeaderDistance = CentimetersToPoints(1.5)
        .FooterDistance = CentimetersToPoints(1.75)
        .PageWidth = CentimetersToPoints(21)
        .PageHeight = CentimetersToPoints(29.7)
        .FirstPageTray = wdPrinterDefaultBin
        .OtherPagesTray = wdPrinterDefaultBin
        .SectionStart = wdSectionNewPage
        .OddAndEvenPagesHeaderFooter = False
        .DifferentFirstPageHeaderFooter = False
        .VerticalAlignment = wdAlignVerticalTop
        .SuppressEndnotes = False
        .MirrorMargins = False
        .TwoPagesOnOne = False
        .BookFoldPrinting = False
        .BookFoldRevPrinting = False
        .BookFoldPrintingSheets = 1
        .GutterPos = wdGutterPosLeft
        .LayoutMode = wdLayoutModeLineGrid
    End With
    
    ActiveDocument.ExportAsFixedFormat OutputFileName:= _
        strFileName, ExportFormat:=wdExportFormatPDF, _
        OpenAfterExport:=False, OptimizeFor:=wdExportOptimizeForPrint, Range:= _
        wdExportAllDocument, From:=1, To:=1, Item:=wdExportDocumentContent, _
        IncludeDocProps:=True, KeepIRM:=True, CreateBookmarks:= _
        wdExportCreateNoBookmarks, DocStructureTags:=True, BitmapMissingFonts:= _
        True, UseISO19005_1:=False
    ChangeFileOpenDirectory "R:\"
End Sub


'Trim ����
Sub TrimEmptyLine()

    Dim i As Integer
    Dim iCnt As Integer
    Dim sp As String
    
    iCnt = 20
    sp = Space(iCnt)

    For i = 0 To iCnt - 1
        Selection.Find.ClearFormatting
        Selection.Find.Replacement.ClearFormatting
        With Selection.Find
            .Text = Space(iCnt - i) + "^p"
            .Replacement.Text = "^p"
            .Forward = True
            .Wrap = wdFindContinue
            .Format = False
            .MatchCase = False
            .MatchWholeWord = False
            .MatchByte = True
            .MatchWildcards = False
            .MatchSoundsLike = False
            .MatchAllWordForms = False
        End With
            
        Selection.Find.Execute Replace:=wdReplaceAll
    Next i
End Sub



'�Զ����ö����½�
Sub SetChapter()

    Dim strSplitZ, strSplitD As String
    Dim aSplitZ() As String
    Dim aSplitD() As String
    Dim lineIdx As Long
    Dim fetchIdx As Integer
    Dim found As Boolean

    strSplitZ = "��һ��,�ڶ���,������,������,������,������,������,�ڰ���,�ھ���,��ʮ��,��ʮһ��,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,�ڶ�ʮ��"
    strSplitD = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20"
    
    aSplitZ = Split(strSplitZ, ",", -1, vbTextCompare)
    aSplitD = Split(strSplitD, ",", -1, vbTextCompare)
    
    For lineIdx = 1 To ActiveDocument.BuiltInDocumentProperties(wdPropertyLines)
        With Selection
            .GoTo What:=wdGoToLine, which:=wdGoToFirst, Count:=lineIdx
            .Expand Unit:=wdLine
        End With
    
        found = False
    
        For fetchIdx = 0 To UBound(aSplitZ)
            If StrComp(aSplitZ(fetchIdx), Replace(Trim(Selection.Text), Chr(13), ""), vbTextCompare) = 0 Then
                Selection.Text = Trim(Selection.Text)
                Selection.Style = ActiveDocument.Styles("���� 2")
                found = True
                
                Exit For
            End If
        Next fetchIdx
        
        If found = False Then
            For fetchIdx = 0 To UBound(aSplitD)
                If StrComp(aSplitD(fetchIdx), Replace(Trim(Selection.Text), Chr(13), ""), vbTextCompare) = 0 Then
                    Selection.Text = Trim(Selection.Text)
                    Selection.Style = ActiveDocument.Styles("���� 3")
                    found = True
                    
                    Exit For
                End If
            Next fetchIdx
        End If
    Next lineIdx
    
'ActiveDocument.Range.Information(wdSelectionMode)
End Sub

'�Զ����ö����½�
Sub SetChapter2()

    Dim strSplitZ, strSplitD As String
    Dim aSplitZ() As String
    Dim aSplitD() As String
    Dim fetchIdx As Integer

    strSplitZ = "��һ��,�ڶ���,������,������,������,������,������,�ڰ���,�ھ���,��ʮ��,��ʮһ��,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,��ʮ����,�ڶ�ʮ��"
    strSplitD = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20"
    
    aSplitZ = Split(strSplitZ, ",", -1, vbTextCompare)
    aSplitD = Split(strSplitD, ",", -1, vbTextCompare)
    
    For fetchIdx = 0 To UBound(aSplitZ)
        With ActiveDocument.Range.Find
            .Text = "����" & aSplitZ(fetchIdx) '�����滻�Ĳ�������
            .ClearFormatting
            .Replacement.ClearFormatting
            .Replacement.Text = aSplitZ(fetchIdx)
            .Replacement.Style = ActiveDocument.Styles("���� 2")
            .Execute Replace:=wdReplaceAll, Forward:=True, Wrap:=wdFindContinue
        End With
    Next fetchIdx

Exit Sub
    For fetchIdx = 0 To UBound(aSplitD)
        With ActiveDocument.Range.Find
            .Text = "    " & aSplitD(fetchIdx) '�����滻�Ĳ�������
            .ClearFormatting
            .Replacement.ClearFormatting
            .Replacement.Text = aSplitD(fetchIdx)
            .Replacement.Style = ActiveDocument.Styles("���� 3")
            .Execute Replace:=wdReplaceAll, Forward:=True, Wrap:=wdFindContinue
        End With
    Next fetchIdx
End Sub

'�Զ����ö����½�
'
'�����ο����
'��ȡ��һ��
'ActiveDocument.Paragraphs(1)
'
'ѡ��ĳһ��
'    With Selection
'        .GoTo What:=wdGoToLine, which:=wdGoToFirst, Count:=lineIdx
'        .Expand Unit:=wdLine
'    End With
Sub SetChapter3()
    Dim iLine As Integer

    '���� 1 ����
    Selection.HomeKey Unit:=wdStory, Extend:=wdMove
    
    With Selection.Find
        .Text = "@1"
        .Forward = True
        .Wrap = wdFindStop
    End With
    
    Do While Selection.Find.Execute
        'ѡ���ҵ�ֵ������
        Selection.HomeKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdMove
        Selection.EndKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend

        '����������ʽ
        Selection.Text = Replace(Selection.Text, "@1", "")
        Selection.Style = ActiveDocument.Styles("���� 2")
        
        '�ƶ��������һ���ַ�
        Selection.MoveRight Unit:=WdUnits.wdCharacter, Count:=1, Extend:=wdMove
    Loop
    
    
    '���� 2 ����
    Selection.HomeKey Unit:=wdStory, Extend:=wdMove
    
    With Selection.Find
        .Text = "@2"
        .Forward = True
        .Wrap = wdFindStop
    End With
    
    Do While Selection.Find.Execute
        'ѡ���ҵ�ֵ������
        Selection.HomeKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdMove
        Selection.EndKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend
        
        '����������ʽ
        Selection.Text = Replace(Selection.Text, "@2", "")
        Selection.Style = ActiveDocument.Styles("���� 3")
        
        '�ƶ��������һ���ַ�
        Selection.MoveRight Unit:=WdUnits.wdCharacter, Count:=1, Extend:=wdMove
    Loop
    
End Sub
