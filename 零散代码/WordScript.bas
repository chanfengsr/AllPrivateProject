Attribute VB_Name = "WordScript"
'不显示语法及拼写错误
Sub DontShowError()
    ActiveDocument.ShowGrammaticalErrors = True
    ActiveDocument.ShowSpellingErrors = True
End Sub


' 选择所有对象只对doc中的Shape管用
'删除所有的嵌入式图片
Sub DeleteAllInlineShape()
    Dim isp As InlineShape
On Error Resume Next
    For Each isp In ActiveDocument.InlineShapes
        isp.Delete
    Next

End Sub

'docx中能一次全成功，doc中只能成功前面3个或页面之内的！
'转换所有的嵌入式图片至浮动型图片
Sub ConvertAllInlineShape()
    Dim isp As InlineShape

    For Each isp In ActiveDocument.InlineShapes
        isp.ConvertToShape
    Next
End Sub

'选中所有的非嵌入式图片
Sub SelectAllShapes()
On Error Resume Next
    ActiveDocument.Shapes.SelectAll
End Sub

'删除所有图片超链接
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

'删除所有的“复制代码”的图片
Sub DeleteAllCopyCodeShapes()
    Dim isp As InlineShape
    Dim sp As Shape

On Error Resume Next
    'And sp.Hyperlink.Address = "javascript:void(0);"
    For Each isp In ActiveDocument.InlineShapes
        If isp.AlternativeText = "复制代码" Then
            isp.Delete
        Else
            isp.AlternativeText = ""
        End If
    Next
    
    For Each sp In ActiveDocument.Shapes
        If sp.AlternativeText = "复制代码" Then
            sp.Delete
        Else
            sp.AlternativeText = ""
        End If
    Next
End Sub

'保存成适合手机阅读的PDF格式
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


'Trim 空行
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



'自动设置段落章节
Sub SetChapter()

    Dim strSplitZ, strSplitD As String
    Dim aSplitZ() As String
    Dim aSplitD() As String
    Dim lineIdx As Long
    Dim fetchIdx As Integer
    Dim found As Boolean

    strSplitZ = "第一章,第二章,第三章,第四章,第五章,第六章,第七章,第八章,第九章,第十章,第十一章,第十二章,第十三章,第十四章,第十五章,第十六章,第十七章,第十八章,第十九章,第二十章"
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
                Selection.Style = ActiveDocument.Styles("标题 2")
                found = True
                
                Exit For
            End If
        Next fetchIdx
        
        If found = False Then
            For fetchIdx = 0 To UBound(aSplitD)
                If StrComp(aSplitD(fetchIdx), Replace(Trim(Selection.Text), Chr(13), ""), vbTextCompare) = 0 Then
                    Selection.Text = Trim(Selection.Text)
                    Selection.Style = ActiveDocument.Styles("标题 3")
                    found = True
                    
                    Exit For
                End If
            Next fetchIdx
        End If
    Next lineIdx
    
'ActiveDocument.Range.Information(wdSelectionMode)
End Sub

'自动设置段落章节
Sub SetChapter2()

    Dim strSplitZ, strSplitD As String
    Dim aSplitZ() As String
    Dim aSplitD() As String
    Dim fetchIdx As Integer

    strSplitZ = "第一章,第二章,第三章,第四章,第五章,第六章,第七章,第八章,第九章,第十章,第十一章,第十二章,第十三章,第十四章,第十五章,第十六章,第十七章,第十八章,第十九章,第二十章"
    strSplitD = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20"
    
    aSplitZ = Split(strSplitZ, ",", -1, vbTextCompare)
    aSplitD = Split(strSplitD, ",", -1, vbTextCompare)
    
    For fetchIdx = 0 To UBound(aSplitZ)
        With ActiveDocument.Range.Find
            .Text = "　　" & aSplitZ(fetchIdx) '查找替换的查找条件
            .ClearFormatting
            .Replacement.ClearFormatting
            .Replacement.Text = aSplitZ(fetchIdx)
            .Replacement.Style = ActiveDocument.Styles("标题 2")
            .Execute Replace:=wdReplaceAll, Forward:=True, Wrap:=wdFindContinue
        End With
    Next fetchIdx

Exit Sub
    For fetchIdx = 0 To UBound(aSplitD)
        With ActiveDocument.Range.Find
            .Text = "    " & aSplitD(fetchIdx) '查找替换的查找条件
            .ClearFormatting
            .Replacement.ClearFormatting
            .Replacement.Text = aSplitD(fetchIdx)
            .Replacement.Style = ActiveDocument.Styles("标题 3")
            .Execute Replace:=wdReplaceAll, Forward:=True, Wrap:=wdFindContinue
        End With
    Next fetchIdx
End Sub

'自动设置段落章节
'
'其他参考语句
'获取第一段
'ActiveDocument.Paragraphs(1)
'
'选中某一行
'    With Selection
'        .GoTo What:=wdGoToLine, which:=wdGoToFirst, Count:=lineIdx
'        .Expand Unit:=wdLine
'    End With
Sub SetChapter3()
    Dim iLine As Integer

    '标题 1 内容
    Selection.HomeKey Unit:=wdStory, Extend:=wdMove
    
    With Selection.Find
        .Text = "@1"
        .Forward = True
        .Wrap = wdFindStop
    End With
    
    Do While Selection.Find.Execute
        '选中找到值的整行
        Selection.HomeKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdMove
        Selection.EndKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend

        '设置字体样式
        Selection.Text = Replace(Selection.Text, "@1", "")
        Selection.Style = ActiveDocument.Styles("标题 2")
        
        '移动光标至下一个字符
        Selection.MoveRight Unit:=WdUnits.wdCharacter, Count:=1, Extend:=wdMove
    Loop
    
    
    '标题 2 内容
    Selection.HomeKey Unit:=wdStory, Extend:=wdMove
    
    With Selection.Find
        .Text = "@2"
        .Forward = True
        .Wrap = wdFindStop
    End With
    
    Do While Selection.Find.Execute
        '选中找到值的整行
        Selection.HomeKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdMove
        Selection.EndKey Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend
        
        '设置字体样式
        Selection.Text = Replace(Selection.Text, "@2", "")
        Selection.Style = ActiveDocument.Styles("标题 3")
        
        '移动光标至下一个字符
        Selection.MoveRight Unit:=WdUnits.wdCharacter, Count:=1, Extend:=wdMove
    Loop
    
End Sub
