Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Public Class Form1


    Public Const JOY_RETURNBUTTONS = &H80&

    Structure JOYINFO
        Dim wXpos As Integer
        Dim wYpos As Integer
        Dim zYpos As Integer
        Dim wButtons As Integer
    End Structure
    Structure JOYINFOEX
        Dim dwSize As Integer   'size of structure 
        Dim dwFlags As Integer   '  flags to indicate what to return 
        Dim wXpos As Integer     '  x position 
        Dim wYpos As Integer     '  y position 
        Dim wZpos As Integer     '  z position 
        Dim wRpos As Integer      '  rudder/4th axis position 
        Dim wUpos As Integer     '  5th axis position 
        Dim wVpos As Integer     '  6th axis position 
        Dim wButtons As Integer '  button states
        Dim wButtonNumber As Integer    '  current button number pressed 
        Dim dwPOV As Integer     '  point of view state 
        Dim dwReserved1 As Integer   '  reserved for communication between winmm driver 
        Dim dwReserved2 As Integer  '  reserved for future expansion 
    End Structure


    Private Declare Function joyGetPos Lib "winmm.dll" (ByVal uJoyID As Integer, ByRef jInfo As JOYINFO) As Integer
    Private Declare Function joyGetPosEx Lib "winmm.dll" (ByVal uJoyID As Integer, ByRef jInfo As JOYINFOEX) As Integer
    Dim 当前路径 As String
    Dim filename As String
    Dim joye As String
    Dim joyn As String
    Dim kz As String
    Dim k As Boolean
    Public Function convert_UTF8(fullString As String) As String
        If fullString <> "" Then
            fullString = fullString.Substring(0, InStr(fullString, vbNullChar) - 1)
        End If
        Return New String(fullString.ToArray())
    End Function
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim proc As Process()
        Dim i As Integer
        If (e.KeyCode = kz) Then
            If System.Diagnostics.Process.GetProcessesByName(filename).Length > 0 Then
                proc = Process.GetProcessesByName(filename)
                For i = 0 To proc.Length - 1
                    proc(i).Kill()
                Next
            End If
            proc = Nothing
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        当前路径 = Application.StartupPath() '初始路径
        Dim proc As Process()
        Dim jinchengshu As Integer

        If System.Diagnostics.Process.GetProcessesByName("梦童年").Length > 0 Then
            proc = Process.GetProcessesByName("梦童年")
            For jinchengshu = 0 To proc.Length - 1
                proc(jinchengshu).Kill()
            Next
        End If
        proc = Nothing
        filename = New String(CChar(" "), 255)
        joyn = New String(CChar(" "), 128)
        joye = New String(CChar(" "), 128)
        kz = New String(CChar(" "), 128)
        GetPrivateProfileString("rocker", "Back", "Back", joyn, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "Back", "Back", kz, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "determine", "determine", joye, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("Startup file", "simulator", "simulator", filename, 255, 当前路径 + "\config.ini")
        filename = convert_UTF8(filename)
        joyn = 首尾删除空格(joyn)
        joye = 首尾删除空格(joye)
        kz = 首尾删除空格(kz)
        'filename = filename 
        ' Debug.WriteLine(filename)
        Me.Hide()
        ' MsgBox(IO.Path.GetFileName("EMU\VirtuaNES\VirtuaNES.exe"))
        'MsgBox(IO.Path.GetExtension("EMU\VirtuaNES\VirtuaNES.exe"))
        '   Dim i As Integer
        '  Dim proc As Process()

        '判断excel进程是否存在
        k = True
        ' proc = Process.GetProcessesByName("nestopia")
        '得到名为excel进程个数，全部关闭
        ' For i = 0 To proc.Length - 1
        '  proc(i).Kill()
        ' Next
        ' End If
        'proc = Nothing
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Dim 按键 As String
        ' 按键 = joyjc()

        Dim proc As Process()
        Dim i As Integer
        If System.Diagnostics.Process.GetProcessesByName(filename).Length > 0 Then

        Else
            If k Then
                ShellExecute(0, "open", "梦童年.exe", "", "", 1)
                k = False
            End If

            End
            Me.Timer1.Enabled = False
        End If
        If (joyjc() = joye + joyn Or joyjc() = joyn + joye) Then

            If System.Diagnostics.Process.GetProcessesByName(filename).Length > 0 Then
                proc = Process.GetProcessesByName(filename)
                For i = 0 To proc.Length - 1
                    proc(i).Kill()
                Next
            End If
            proc = Nothing
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Yan As Object
        Dim aa As Integer = SystemInformation.PrimaryMonitorSize.Width
        Dim bb As Integer = SystemInformation.PrimaryMonitorSize.Height
        MsgBox(aa)

        '  Dim p As Process = New Process()

        '  p.StartInfo.FileName = "C:\Users\Administrator\Desktop\GBA\123.exe"
        ' p.Start()
        'filename = p.ProcessName()
        'Console.WriteLine(p.ProcessName())
        ' Dim i As Integer
        ' Dim proc As Process()
        ' Dim txt As String

        ' filename = "1 2 3"
        'For Each p As Process In Process.GetProcesses()
        'Debug.WriteLine(p.ProcessName)

        ' Next

        ' If System.Diagnostics.Process.GetProcessesByName(filename).Length > 0 Then
        'MsgBox("ok")
        '判断excel进程是否存在

        ' proc = Process.GetProcessesByName(filename)
        '得到名为excel进程个数，全部关闭
        ' For i = 0 To proc.Length - 1
        'proc(i).Kill()
        '  Next
        '  End If
        ' proc = Nothing
    End Sub
    Public Function joyjc() As String
        Dim joyzt As String
        Dim infoJEx As JOYINFOEX
        With infoJEx
            .dwSize = Marshal.SizeOf(GetType(JOYINFOEX))
            .dwFlags = CInt(JOY_RETURNBUTTONS)
        End With
        Dim result As Integer = joyGetPosEx(Me.IsDisposed, infoJEx)    '返回JOYERR_NOERROR(值为0)
        joyzt = "空"
        If result = 0 Then
            If (infoJEx.dwPOV = 0) Then
                joyzt = "joyup_1p"
            ElseIf (infoJEx.dwPOV = 18000) Then
                joyzt = "joydw_1p"

            ElseIf (infoJEx.dwPOV = 27000) Then
                joyzt = "joyleft_1p"

            ElseIf (infoJEx.dwPOV = 9000) Then
                joyzt = "joyright_1p"

                'End If

            ElseIf infoJEx.wXpos = 0 Then   '输出左右按键状态
                joyzt = "joyleft_1p"

            ElseIf infoJEx.wXpos = 65535 Then
                joyzt = "joyright_1p"

                'End If
            ElseIf infoJEx.wYpos = 0 Then   '输出上下按键状态
                joyzt = "joyup_1p"

            ElseIf infoJEx.wYpos = 65535 Then
                joyzt = "joydw_1p"
                
            End If
            '输出数字键
            Dim i As Integer
            For i = 0 To 9  '按位输出
                If (infoJEx.wButtons And 2 ^ i) = 0 Then
                Else

                    joyzt += "joy_1p" & i + 1
                    joyzt = joyzt.Replace("空", "")
                End If
            Next
            '输出遥感状态
            '左摇杆
        Else
            joyzt = "空"

        End If
        Return joyzt
    End Function
End Class