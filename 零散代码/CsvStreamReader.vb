Imports System
Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Reflection
Imports System.Text

<DefaultMember("Item")> _
Public Class CsvStreamReader
    ' Fields
    Private _encoding As Encoding
    Private _fileName As String
    Private _rowAL As ArrayList

    ' Methods
    Public Sub New()
        Me._rowAL = New ArrayList
        Me._fileName = ""
        Me._encoding = Encoding.Default
    End Sub

    Public Sub New(ByVal fileName As String)
        Me._rowAL = New ArrayList
        Me._fileName = fileName
        Me._encoding = Encoding.Default
        Me.LoadCsvFile()
    End Sub

    Public Sub New(ByVal fileName As String, ByVal encoding As Encoding)
        Me._rowAL = New ArrayList
        Me._fileName = fileName
        Me._encoding = encoding
        Me.LoadCsvFile()
    End Sub

    Private Sub AddNewDataLine(ByVal newDataLine As String)
        Dim list As New ArrayList
        Dim strArray As String() = newDataLine.Split(New Char() {","c})
        Dim flag As Boolean = False
        Dim fileCellData As String = ""
        Dim i As Integer
        For i = 0 To strArray.Length - 1
            If flag Then
                fileCellData = (fileCellData & "," & strArray(i))
                If Me.IfOddEndQuota(strArray(i)) Then
                    list.Add(Me.GetHandleData(fileCellData))
                    flag = False
                End If
            ElseIf Me.IfOddStartQuota(strArray(i)) Then
                If Not ((Not Me.IfOddEndQuota(strArray(i)) OrElse (strArray(i).Length <= 2)) OrElse Me.IfOddQuota(strArray(i))) Then
                    list.Add(Me.GetHandleData(strArray(i)))
                    flag = False
                Else
                    flag = True
                    fileCellData = strArray(i)
                End If
            Else
                list.Add(Me.GetHandleData(strArray(i)))
            End If
        Next i
        If flag Then
            Throw New Exception("数据格式有问题")
        End If
        Me._rowAL.Add(list)
    End Sub

    Private Sub CheckColValid(ByVal col As Integer)
        If (col <= 0) Then
            Throw New Exception("列数不能小于0")
        End If

        If (col > Me.ColCount) Then
            Throw New Exception("没有当前列的数据")
        End If
    End Sub

    Private Sub CheckMaxColValid(ByVal maxCol As Integer)
        If ((maxCol <= 0) AndAlso (maxCol <> -1)) Then
            Throw New Exception("检查检查最大列数是否是有效的")
        End If
        If (maxCol > Me.ColCount) Then
            Throw New Exception("没有当前列的数据")
        End If
    End Sub

    Private Sub CheckMaxRowValid(ByVal maxRow As Integer)
        If ((maxRow <= 0) AndAlso (maxRow <> -1)) Then
            Throw New Exception("行数不能等于0或小于-1")
        End If
        If (maxRow > Me.RowCount) Then
            Throw New Exception("没有当前行的数据")
        End If
    End Sub

    Private Sub CheckRowValid(ByVal row As Integer)
        If (row <= 0) Then
            Throw New Exception("行数不能小于0")
        End If
        If (row > Me.RowCount) Then
            Throw New Exception("没有当前行的数据")
        End If
    End Sub

    Private Function GetDeleteQuotaDataLine(ByVal fileDataLine As String) As String
        Return fileDataLine.Replace("""""", """")
    End Function

    Private Function GetHandleData(ByVal fileCellData As String) As String
        If (fileCellData = "") Then
            Return ""
        End If
        If Me.IfOddStartQuota(fileCellData) Then
            If Not Me.IfOddEndQuota(fileCellData) Then
                Throw New Exception("数据引号无法匹配")
            End If
            Return fileCellData.Substring(1, (fileCellData.Length - 2)).Replace("""""", """")
        End If
        If ((fileCellData.Length > 2) AndAlso (fileCellData.Chars(0) = """"c)) Then
            fileCellData = fileCellData.Substring(1, (fileCellData.Length - 2)).Replace("""""", """")
        End If
        Return fileCellData
    End Function

    Private Function IfOddEndQuota(ByVal dataCell As String) As Boolean
        Dim num As Integer = 0
        Dim i As Integer = (dataCell.Length - 1)
        Do While (i >= 0)
            If (dataCell.Chars(i) <> """"c) Then
                Exit Do
            End If
            num += 1
            i -= 1
        Loop
        Return ((num Mod 2) = 1)
    End Function

    Private Function IfOddQuota(ByVal dataLine As String) As Boolean
        Dim num As Integer = 0
        Dim i As Integer
        For i = 0 To dataLine.Length - 1
            If (dataLine.Chars(i) = """"c) Then
                num += 1
            End If
        Next i
        Return ((num Mod 2) = 1)
    End Function

    Private Function IfOddStartQuota(ByVal dataCell As String) As Boolean
        Dim num As Integer = 0
        Dim i As Integer
        For i = 0 To dataCell.Length - 1
            If (dataCell.Chars(i) <> """"c) Then
                Exit For
            End If
            num += 1
        Next i
        Dim flag = (num Mod 2) = 1
        Return flag
    End Function

    Private Sub LoadCsvFile()
        If (Me._fileName Is Nothing) Then
            Throw New Exception("请指定要载入的CSV文件名")
        End If
        If Not File.Exists(Me._fileName) Then
            Throw New Exception("指定的CSV文件不存在")
        End If
        If (Me._encoding Is Nothing) Then
            Me._encoding = Encoding.Default
        End If
        Dim reader As New StreamReader(Me._fileName, Me._encoding)
        Dim dataLine As String = ""
        Do While True
            Dim str2 As String = reader.ReadLine
            If (str2 Is Nothing) Then
                reader.Close()
                If (dataLine.Length > 0) Then
                    Throw New Exception("CSV文件的格式有错误")
                End If
                Return
            End If
            If (dataLine = "") Then
                dataLine = str2
            Else
                dataLine = (dataLine & ChrW(13) & ChrW(10) & str2)
            End If
            If Not Me.IfOddQuota(dataLine) Then
                Me.AddNewDataLine(dataLine)
                dataLine = ""
            End If
        Loop
    End Sub


    ' Properties
    Public ReadOnly Property ColCount As Integer
        Get
            Dim num As Integer = 0
            Dim i As Integer
            For i = 0 To Me._rowAL.Count - 1
                Dim list As ArrayList = DirectCast(Me._rowAL.Item(i), ArrayList)
                num = If((num > list.Count), num, list.Count)
            Next i
            Return num
        End Get
    End Property

    Public WriteOnly Property FileEncoding As Encoding
        Set(ByVal value As Encoding)
            Me._encoding = value
        End Set
    End Property

    Public WriteOnly Property FileName As String
        Set(ByVal value As String)
            Me._fileName = value
            Me.LoadCsvFile()
        End Set
    End Property

    Default Public ReadOnly Property Item(ByVal minRow As Integer, ByVal maxRow As Integer, ByVal minCol As Integer, ByVal maxCol As Integer) As DataTable
        Get
            Me.CheckRowValid(minRow)
            Me.CheckMaxRowValid(maxRow)
            Me.CheckColValid(minCol)
            Me.CheckMaxColValid(maxCol)
            If (maxRow = -1) Then
                maxRow = Me.RowCount
            End If
            If (maxCol = -1) Then
                maxCol = Me.ColCount
            End If
            If (maxRow < minRow) Then
                Throw New Exception("最大行数不能小于最小行数")
            End If
            If (maxCol < minCol) Then
                Throw New Exception("最大列数不能小于最小列数")
            End If
            Dim table As New DataTable
            Dim num As Integer = minCol
            Do While (num <= maxCol)
                table.Columns.Add(num.ToString)
                num += 1
            Loop
            Dim i As Integer = minRow
            Do While (i <= maxRow)
                Dim row As DataRow = table.NewRow
                num = 0
                Dim j As Integer = minCol
                Do While (j <= maxCol)
                    row.Item(num) = Me.Item(i, j)
                    num += 1
                    j += 1
                Loop
                table.Rows.Add(row)
                i += 1
            Loop
            Return table
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal row As Integer, ByVal col As Integer) As String
        Get
            Me.CheckRowValid(row)
            Me.CheckColValid(col)
            Dim list As ArrayList = DirectCast(Me._rowAL.Item((row - 1)), ArrayList)
            If (list.Count < col) Then
                Return ""
            End If
            Return list.Item((col - 1)).ToString
        End Get
    End Property

    Public ReadOnly Property RowCount As Integer
        Get
            Return Me._rowAL.Count
        End Get
    End Property
End Class


