VERSION 5.00
Begin VB.Form frmCloseMonitor 
   Caption         =   "Form1"
   ClientHeight    =   0
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   1725
   LinkTopic       =   "Form1"
   ScaleHeight     =   0
   ScaleWidth      =   1725
   StartUpPosition =   3  '窗口缺省
End
Attribute VB_Name = "frmCloseMonitor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Any) As Long
Const WM_SYSCOMMAND = &H112&
Const SC_MONITORPOWER = &HF170&

Private Sub Form_Load()
    Me.Visible = False
    SendMessage Me.hwnd, WM_SYSCOMMAND, SC_MONITORPOWER, ByVal 2& '关闭显示器
    SendMessage Me.hwnd, WM_SYSCOMMAND, SC_MONITORPOWER, ByVal 2& '关闭显示器
    Unload Me
End Sub
