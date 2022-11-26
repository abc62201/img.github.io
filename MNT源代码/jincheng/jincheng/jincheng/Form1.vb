Imports System.Runtime.InteropServices
Imports System.IO
Imports SharpDX
Imports SharpDX.DirectInput
Imports System.Text
Imports Emgu.CV
Imports Emgu.CV.Structure
Imports Emgu.Util


Public Class Form1
    Dim hwd As Integer = 0
    Dim winx As Integer = 0
    Dim winy As Integer = 0
    Dim bth As Integer = 0
    Dim key_show As Boolean = False
    Structure EnumWindowsArg
        Dim HwndWindow As Integer
        Dim ProcessID As Integer
    End Structure
    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal IpOperation As String, ByVal IpFile As String, ByVal IpParameters As String, ByVal IpDirectory As String, ByVal nShowCmd As Int32) As Integer
    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Delegate Function EnumWindowsProc(ByVal Hwnd As Integer, ByRef ewa As EnumWindowsArg) As Boolean
    Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As String, ByVal cch As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As Integer
    Private Declare Ansi Function EnumWindows Lib "user32" Alias "EnumWindows" (ByVal lpEnumFunc As EnumWindowsProc, ByRef lParam As EnumWindowsArg) As Integer  '声明API函数EnumWindows
    Private Declare Function GetWindowThreadProcessId Lib "user32" Alias "GetWindowThreadProcessId" (ByVal hwnd As Integer, ByRef lpdwProcessId As Integer) As Integer
    Private Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Short
    Private Declare Function DestroyWindow Lib "user32" Alias "DestroyWindow" (ByVal hwnd As Integer) As Integer
    Public Const JOY_RETURNBUTTONS = &H80&
    Private Function EnumWindowsProc_GetHwndByPID(ByVal Hwnd As Integer, ByRef ewa1 As EnumWindowsArg) As Boolean
        Dim pArg As EnumWindowsArg = ewa1
        Dim ProcessID As Integer

        '通过枚举的窗口句柄用windows api 函数 GetWindowThreadProcessId取得窗口进程ID
        '与要查找的窗口进程比较，相同，则找到了该进程的窗口句柄。

        Dim threadID = GetWindowThreadProcessId(Hwnd, ProcessID)

        Dim x_hwd As Integer = 0
        x_hwd = FindWindow(vbNullString, "DIEmWin") '获取re模拟器其的展示窗口
        If (x_hwd <> Hwnd) Then
            If ProcessID = pArg.ProcessID Then
                pArg.HwndWindow = Hwnd
                hwd = Hwnd
                '找到了返回FALSE

                Return False
            End If
            If threadID = pArg.ProcessID Then
                pArg.HwndWindow = Hwnd
                hwd = Hwnd
                Return False
            End If
        End If


        '没找到，继续找，返回TRUE
        Return True

    End Function
    Public Function GetWindowhandleByProcessID(ByVal ProcessID As Integer) As Integer '通过窗口的进程ID获取窗口句柄
        Dim Hwndrtn As Integer '返回窗口句柄的变量
        Dim ewa As EnumWindowsArg '自定义的变量，用来传递窗口进程和窗口句柄

        ewa.ProcessID = ProcessID '
        ewa.HwndWindow = 0
        Dim Prc As EnumWindowsProc = New EnumWindowsProc(AddressOf EnumWindowsProc_GetHwndByPID) '实例化一个回调函数

        'EnumWindows枚举窗口，prc为实例化的回调函数指针（地址），EnumWindows将枚举窗口的句柄传递给回调函数prc处理。 
        'ewa为向回调函数按址传递的一个参数， 就是可以向回调函数传值， 也可以接收从回调函数返回的值。
        EnumWindows(Prc, ewa)


        If ewa.HwndWindow <> 0 Then
            Hwndrtn = ewa.HwndWindow
            Return Hwndrtn
        Else
            Return hwd
        End If

    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindow( _
 ByVal lpClassName As String, _
 ByVal lpWindowName As String) As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function GetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function SetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
        Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal X2 As Integer, ByVal Y2 As Integer)
            Me.Left = X
            Me.Top = Y
            Me.Right = X2
            Me.Bottom = Y2
        End Sub
    End Structure

    Private Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As ShowWindowCommands
        Public ptMinPosition As POINTAPI
        Public ptMaxPosition As POINTAPI
        Public rcNormalPosition As RECT
    End Structure

    Enum ShowWindowCommands As Integer
        Hide = 0
        Normal = 1
        ShowMinimized = 2
        Maximize = 3
        ShowMaximized = 3
        ShowNoActivate = 4
        Show = 5
        Minimize = 6
        ShowMinNoActive = 7
        ShowNA = 8
        Restore = 9
        ShowDefault = 10
        ForceMinimize = 11
    End Enum

    Public Structure POINTAPI
        Public X As Integer
        Public Y As Integer
        Public Sub New(ByVal X As Integer, ByVal Y As Integer)
            Me.X = X
            Me.Y = Y
        End Sub
    End Structure
    Private Sub game_win(ByVal prs_name As String)
        Dim proc As Process()
        proc = Process.GetProcessesByName(prs_name)
        hwd = GetWindowhandleByProcessID(proc(0).Id)
        'MsgBox(hwd)
        Dim wp As WINDOWPLACEMENT
        Dim wp2 As WINDOWPLACEMENT
        wp.Length = Marshal.SizeOf(wp)
        GetWindowPlacement(hwd, wp)

        Try


            If wp.showCmd = ShowWindowCommands.ShowMinimized Then
                wp2.showCmd = ShowWindowCommands.ShowMaximized
                wp2.ptMinPosition = wp.ptMinPosition
                wp2.ptMaxPosition = New POINTAPI(0, 0)
                wp2.rcNormalPosition = New RECT(0, bth * 0.5, winx * 0.8, winy * 0.828) 'this is the size I want
                wp2.flags = wp.flags
                wp2.Length = Marshal.SizeOf(wp2)
                SetWindowPlacement(hwd, wp2)
            Else
                AppActivate(proc(0).Id)
                wp2.showCmd = ShowWindowCommands.ShowDefault
                wp2.ptMinPosition = wp.ptMinPosition
                wp2.ptMaxPosition = New POINTAPI(0, 0)
                wp2.rcNormalPosition = New RECT(0, bth * 0.5, winx * 0.8, winy * 0.828) 'this is the size I want

                wp2.flags = wp.flags
                wp2.Length = Marshal.SizeOf(wp2)
                SetWindowPlacement(hwd, wp2)
            End If
        Catch ex As Exception

        End Try
    End Sub
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
    Dim joyn As String
    Dim joye As String
    Dim kz As String
    Dim ku As String
    Dim kd As String
    Dim kl As String
    Dim kr As String
    Dim ke As String
    Dim kx As String
    Dim ks As String
    Dim kso As String
    Dim kra As String
    Dim joyu As String
    Dim joyd As String
    Dim joyl As String
    Dim joyr As String
    Dim joyso As String
    Dim joyra As String
    Dim next1 As String
    Dim next2 As String
    Dim k As Boolean
    Dim gl_index As Integer = 1
    Dim gl_file_name As String = ""
    Dim gl_file_path As String = ""
    Dim gl_file_txt As String() = {"攻略不存在"}
    Dim gl_img_txt As String() = {"攻略不存在"}
    Dim joytype As String
    Dim joy_drive As String
    Dim timer2_show As Boolean = False


    Public Function convert_UTF8(fullString As String) As String
        If fullString <> "" Then
            fullString = fullString.Substring(0, InStr(fullString, vbNullChar) - 1)
        End If
        Return New String(fullString.ToArray())
    End Function

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
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
        bth = Me.Size.Height - Me.ClientSize.Height
        WebBrowser1.ObjectForScripting = Me
        当前路径 = Application.StartupPath() '初始路径
        Dim proc As Process()
        Dim jinchengshu As Integer
        Try
            If System.Diagnostics.Process.GetProcessesByName("MTN").Length > 0 Then
                proc = Process.GetProcessesByName("MTN")
                For jinchengshu = 0 To proc.Length - 1
                    proc(jinchengshu).Kill()
                Next
            End If
        Catch ex As Exception

        End Try

        proc = Nothing
        Threading.Thread.Sleep(200)
        filename = New String(CChar(" "), 255)

        joy_drive = New String(CChar(" "), 128)
        joytype = New String(CChar(" "), 128)
        joyu = New String(CChar(" "), 128)
        joyd = New String(CChar(" "), 128)
        joyl = New String(CChar(" "), 128)
        joyr = New String(CChar(" "), 128)
        joye = New String(CChar(" "), 128)
        joyn = New String(CChar(" "), 128)
        joyso = New String(CChar(" "), 128)
        joyra = New String(CChar(" "), 128)
        next1 = New String(CChar(" "), 128)
        next2 = New String(CChar(" "), 128)

        ku = New String(CChar(" "), 128)
        kd = New String(CChar(" "), 128)
        kl = New String(CChar(" "), 128)
        kr = New String(CChar(" "), 128)
        ke = New String(CChar(" "), 128)
        kz = New String(CChar(" "), 128)
        kx = New String(CChar(" "), 128)
        ks = New String(CChar(" "), 128)
        kso = New String(CChar(" "), 128)
        kra = New String(CChar(" "), 128)

        GetPrivateProfileString("rocker", "up", "up", joyu, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "down", "down", joyd, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "left", "left", joyl, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "right", "right", joyr, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "determine", "determine", joye, 128, 当前路径 + "\joy.ini")

        GetPrivateProfileString("rocker", "Back", "Back", joyn, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "next page", "next page", next1, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "last page", "last page", next2, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "search", "search", joyso, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "Raiders", "Raiders", joyra, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "joutype", "joutype", joytype, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "dx_joutype", "dx_joutype", joy_drive, 128, 当前路径 + "\joy.ini")

        GetPrivateProfileString("keyboard", "up", "up", ku, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "down", "down", kd, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "left", "left", kl, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "right", "right", kr, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "determine", "determine", ke, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "Back", "Back", kz, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "next page", "next page", kx, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "last page", "last page", ks, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "search", "search", kso, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "Raiders", "Raiders", kra, 128, 当前路径 + "\joy.ini")

        GetPrivateProfileString("Startup file", "simulator", "simulator", filename, 255, 当前路径 + "\config.ini")
        filename = convert_UTF8(filename)
        joyu = 首尾删除空格(joyu)
        joyd = 首尾删除空格(joyd)
        joyl = 首尾删除空格(joyl)
        joyr = 首尾删除空格(joyr)
        joye = 首尾删除空格(joye)
        joyn = 首尾删除空格(joyn)
        joyso = 首尾删除空格(joyso)
        joyra = 首尾删除空格(joyra)
        joytype = 首尾删除空格(joytype)
        joy_drive = 首尾删除空格(joy_drive)
        next1 = 首尾删除空格(next1)
        next2 = 首尾删除空格(next2)

        ku = 首尾删除空格(ku)
        kd = 首尾删除空格(kd)
        kl = 首尾删除空格(kl)
        kr = 首尾删除空格(kr)
        ke = 首尾删除空格(ke)
        kz = 首尾删除空格(kz)
        kx = 首尾删除空格(kx)
        ks = 首尾删除空格(ks)
        kso = 首尾删除空格(kso)
        kra = 首尾删除空格(kra)

        Me.Location = New Point(0, 0)
        winx = SystemInformation.PrimaryMonitorSize.Width
        winy = SystemInformation.PrimaryMonitorSize.Height
        'Me.Height = winy
        ' Me.Width = winx
        Me.WebBrowser1.Height = winy * 0.8
        WebBrowser1.Width = winx * 0.2
        WebBrowser1.Location = New Point(winx * 0.8, 0)
        WebBrowser2.Width = winx
        WebBrowser2.Height = winy * 0.2
        WebBrowser2.Location = New Point(0, winy * 0.8)
        Dim rom_file As TextReader = File.OpenText("pics.txt")
        Dim rom_file_path As String = ""
        rom_file_path = rom_file.ReadLine
        rom_file.Close()
        gl_file_name = Path.GetFileNameWithoutExtension(rom_file_path)
        gl_file_path = Path.GetDirectoryName(rom_file_path)
        If My.Computer.FileSystem.FileExists(gl_file_path + "\" + gl_file_name + "\" + gl_file_name + ".txt") Then
            Dim rom_file_gl As TextReader = File.OpenText(gl_file_path + "\" + gl_file_name + "\" + gl_file_name + ".txt")
            gl_file_txt = rom_file_gl.ReadToEnd.Split({"[MTN_GL]"}, StringSplitOptions.None)
            rom_file_gl.Close()
        End If
        If My.Computer.FileSystem.FileExists(gl_file_path + "\" + gl_file_name + "\" + "MTN_gl_img.txt") Then
            Dim rom_img_gl As TextReader = File.OpenText(gl_file_path + "\" + gl_file_name + "\" + "MTN_gl_img.txt")
            gl_img_txt = rom_img_gl.ReadToEnd.Split({"[img]"}, StringSplitOptions.None)
            rom_img_gl.Close()
        End If
        Call GetJoyStick2(joy_drive)

        Me.Hide()
        Me.Timer1.Enabled = True
        k = True

    End Sub

    Public Sub zid_gl(ByVal time_e As String)
        If My.Computer.FileSystem.FileExists(当前路径 + "\x86\cvextern.dll") Then
            If (time_e = "True") Then
                Timer2.Enabled = True
            ElseIf (time_e = "False") Then
                Timer2.Enabled = False
            End If
        Else
            MsgBox("缺少实时攻略插件")
            WebBrowser1.Document.InvokeScript("sk_x_f")
        End If

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Dim 按键 As String
        ' 按键 = joyjc()

        Dim proc As Process()
        Dim i As Integer
        Try


            If System.Diagnostics.Process.GetProcessesByName(filename).Length > 0 Then

            Else
                If k Then
                    ShellExecute(0, "open", "MTN.exe", "", "", 1)
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

            If (GetAsyncKeyState(CInt(kra)) And GetAsyncKeyState(CInt(kso))) Or (joyjc() = joyra + joyso) Or (joyjc() = joyso + joyra) Then
                If Not key_show Then
                    Me.Show()
                    WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders.html")
                    WebBrowser2.Navigate(当前路径 + "\Raiders\advertising.html")
                    key_show = True
                    Call game_win(filename)
                Else
                    Timer2.Enabled = False
                    WebBrowser1.Document.InvokeScript("sk_x_f")
                    Me.Hide()
                    key_show = False
                End If
            End If
        Catch ex As Exception

        End Try
        If (key_show) And gl_file_txt.Length - 1 > gl_index Then
            If ((joyjc() = joyra + next1) Or (joyjc() = next1 + joyra)) Or ((GetAsyncKeyState(CInt(kra))) And (GetAsyncKeyState(CInt(kx)))) Then
                gl_index = gl_index + 1
                WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders.html")
            End If
        End If
        If (key_show) And gl_index > 1 Then
            If ((joyjc() = joyra + next2) Or (joyjc() = next2 + joyra)) Or ((GetAsyncKeyState(CInt(kra))) And (GetAsyncKeyState(CInt(ks)))) Then
                gl_index = gl_index - 1
                WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders.html")
            End If
        End If
    End Sub
    Public Sub gl_next1()
        If (key_show) And gl_file_txt.Length - 1 > gl_index Then
            gl_index = gl_index + 1
            WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders.html")
        End If
    End Sub
    Public Sub gl_next2()
        If (key_show) And gl_index > 1 Then
            gl_index = gl_index - 1
            WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders.html")
        End If
    End Sub
    Public Function joyjc() As String
        Dim joyzt As String = "joy_empty"
        Dim result As Integer
        Dim infoJEx As JOYINFOEX
        Dim joy_id_index As Integer = 0
        With infoJEx
            .dwSize = Marshal.SizeOf(GetType(JOYINFOEX))
            .dwFlags = CInt(JOY_RETURNBUTTONS)
        End With
        If (joytype <> "2") Then
            Try
                joy_id_index = CInt(joy_drive)
            Catch ex As Exception
                joy_id_index = 0
            End Try
            result = joyGetPosEx(joy_id_index, infoJEx) '返回JOYERR_NOERROR(值为0)
            If result = 0 Then
                If (joytype = "0") Then
                    If (infoJEx.dwPOV = 0) Then
                        joyzt = "joyup_1p"

                    ElseIf (infoJEx.dwPOV = 18000) Then
                        joyzt = "joydw_1p"

                    ElseIf (infoJEx.dwPOV = 27000) Then
                        joyzt = "joyleft_1p"

                    ElseIf (infoJEx.dwPOV = 9000) Then
                        joyzt = "joyright_1p"
                    End If
                End If

                If (joytype = "1") Then
                    If infoJEx.wXpos = 0 Then   '输出左右按键状态
                        joyzt = "joyleft_1p"

                    ElseIf infoJEx.wXpos = 65535 Then
                        joyzt = "joyright_1p"

                        'End If
                    ElseIf infoJEx.wYpos = 0 Then   '输出上下按键状态
                        joyzt = "joyup_1p"

                    ElseIf infoJEx.wYpos = 65535 Then
                        joyzt = "joydw_1p"

                    End If
                End If

                '输出数字键
                Dim i As Integer
                For i = 0 To 9  '按位输出
                    If (infoJEx.wButtons And 2 ^ i) = 0 Then
                    Else
                        joyzt += "joy_1p" & i + 1
                        joyzt = joyzt.Replace("joy_empty", "")
                    End If
                Next
                '输出遥感状态
                '左摇杆
            Else
                joyzt = "joy_empty"

            End If
        End If
        If (joytype = 2 And dx_joy) Then
            Dim state As JoystickState = New JoystickState()
            state = pad.GetCurrentState()
            Dim buttons
            buttons = state.Buttons
            If (state.X = 0) Then
                joyzt = "joyleft_1p"

            End If
            If (state.X = 65535) Then
                joyzt = "joyright_1p"

            End If
            If (state.Y = 0) Then
                joyzt = "joyup_1p"

            End If
            If (state.Y = 65535) Then
                joyzt = "joydw_1p"

            End If
            Dim clickedId As Integer = 0
            For Each item In state.Buttons
                clickedId = clickedId + 1
                If (item) Then
                    joyzt = "joy_1p" & clickedId

                End If
            Next
        End If
        Return joyzt
    End Function
  
    Private Function img_b(ByVal pic_path As String, ByVal img_path As String)
        Dim p1 As New Point(0, bth * 0.5)
        Dim p2 As New Point(winx * 0.8, winy * 0.828)
        Dim pic As New Bitmap(p2.X, p2.Y)
        Using g As Graphics = Graphics.FromImage(pic)
            g.CopyFromScreen(p1, p1, p2)
            'New RECT(0, bth * 0.5, winx * 0.8, winy * 0.828) 'this is the size I want
        End Using
        ' Me.PictureBox1.Image = pic
        pic.Save(pic_path)
        Dim img1 As New Image(Of Bgr, Byte)(pic_path)

        Dim img2 As New Image(Of Bgr, Byte)(img_path)
        Dim c As Mat = New Mat
        Dim max As Double = 0
        Dim mix As Double = 0
        Dim max_loc As Point = New Point
        Dim mix_loc As Point = New Point
        CvInvoke.MatchTemplate(img1, img2, c, CvEnum.TemplateMatchingType.CcorrNormed)
        CvInvoke.MinMaxLoc(c, mix, max, mix_loc, max_loc)
        'Label1.Text = "X=" + max_loc.X.ToString + Chr(13) + "Y=" + max_loc.Y.ToString + Chr(13)
        ' Label1.Text += "最大相似的：" + max.ToString + Chr(13) + "最小相似度：" + mix.ToString

        Return max
    End Function
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        WebBrowser1.Document.GetElementById("zhu").InnerHtml = gl_file_txt(gl_index)
        Threading.Thread.Sleep(200)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Dim img_bj As Double = 0
        Dim pic_path_file As String = ""
        pic_path_file = gl_file_path + "\" + gl_file_name + "\" + "MTN_gl_pic.png"
        For i = 0 To gl_img_txt.Length - 1
            If My.Computer.FileSystem.FileExists(gl_img_txt(i)) Then
                img_bj = img_b(pic_path_file, Path.GetFullPath(gl_img_txt(i)))
                If (CInt(img_bj * 100) > 98) Then
                    gl_index = i
                    If (gl_file_txt.Length - 1 > gl_index) Then
                        WebBrowser1.Document.GetElementById("zhu").InnerHtml = gl_file_txt(gl_index)
                    End If
                End If
            End If
        Next

    End Sub
End Class