Imports System.IO

Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports SharpDX
Imports SharpDX.DirectInput
Imports System.Text

<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class Form2
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
    Private Declare Function SetCursorPos Lib "user32" (ByVal x As Integer, ByVal y As Integer) As Integer
    Private Declare Function joyGetPos Lib "winmm.dll" (ByVal uJoyID As Integer, ByRef jInfo As JOYINFO) As Integer
    Private Declare Function joyGetPosEx Lib "winmm.dll" (ByVal uJoyID As Integer, ByRef jInfo As JOYINFOEX) As Integer
    Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Public Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Public Declare Auto Function ShowWindow Lib "user32.dll" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    Public Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByRef lpvParam As Rectangle, ByVal fuWinIni As Integer) As Integer
    Public Declare Function PlaySound Lib "winmm.dll" (ByVal lpszSoundName As String, ByVal hModule As Integer, ByVal dwFlags As Integer) As Integer
    Public Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer
    Const SND_FILENAME As Integer = &H20000 ' 文件模式
    Const SND_ALIAS As Integer = &H10000    '自己查查
    Const SND_SYNC As Integer = &H0  '同步
    Const SND_ASYNC As Integer = &H1  '异步
    Const SND_LOOP As Integer = &H8  '循环

    Public Const SPIF_UPDATEINIFILE As Integer = &H1
    Public Const SPI_SETWORKAREA As Integer = 47
    Public Const SPI_GETWORKAREA As Integer = 48
    Public Const SW_SHOW As Integer = 5
    Public Const SW_HIDE As Integer = 0
    Public Const MOUSEEVENTF_LEFTDOWN = &H2 '模拟鼠标左键按下
    Public Const MOUSEEVENTF_LEFTUP = &H4 '模拟鼠标左键释放
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 '模拟鼠标中间键按下
    Public Const MOUSEEVENTF_MIDDLEUP = &H40 '模拟鼠标中间键释放
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8 '模拟鼠标右键按下
    Public Const MOUSEEVENTF_RIGHTUP = &H10 '模拟鼠标右键释放
    Public Const MOUSEEVENTF_MOVE = &H1 '模拟鼠标指针移动


    Public Function SetFullScreen(ByVal fullscreen As Boolean, ByRef rectOld As Rectangle) As Boolean
        Dim Hwnd As Integer = FindWindow("Shell_TrayWnd", Nothing)
        If Hwnd = 0 Then
            Return False
        End If
        If fullscreen Then
            ShowWindow(Hwnd, SW_HIDE)
            Dim rectFull As Rectangle = Screen.PrimaryScreen.Bounds
            SystemParametersInfo(SPI_GETWORKAREA, 0, rectOld, SPIF_UPDATEINIFILE) 'Get
            SystemParametersInfo(SPI_SETWORKAREA, 0, rectFull, SPIF_UPDATEINIFILE) 'Set
        Else
            ShowWindow(Hwnd, SW_SHOW)
            SystemParametersInfo(SPI_SETWORKAREA, 0, rectOld, SPIF_UPDATEINIFILE)
        End If
        Return True
    End Function




    Dim pic_time As String
    Dim xmlnodes As Xml.XmlNodeList
    Dim xmllist As Xml.XmlNodeList
    Dim n As Integer
    Dim romxml As String
    Dim fs As String
    Dim xiang As Integer
    Dim 模拟器 As String
    Dim 当前路径 As String
    Dim 游戏机 As String
    Dim 电视机 As String
    Dim 卡带 As String
    Dim 信息 As String
    Dim 背景 As String
    Dim 页眉 As String
    Dim 人物 As String
    Dim logo As String
    Dim mengban As String
    Dim linph As String 'html路径
    Dim linpcss As String 'css路径
    Dim dll As String
    Dim s As String
    Dim k As Boolean
    Dim k1 As Boolean
    Dim xuanz As Integer = 0
    Dim xuana As Integer = 0
    Dim key事件 As Boolean = True
    Dim key_rom_xml As Boolean = False
    Dim key事件_l As Boolean = True
    Dim key事件_r As Boolean = True
    Dim key事件_s As Boolean = True
    Dim key事件_x As Boolean = True
    Dim 鼠标事件_s As Boolean = True
    Dim 鼠标事件_x As Boolean = True
    Dim key事件_ins As Boolean = True
    Dim key事件_del As Boolean = True
    Dim key事件_z As Boolean = True
    Dim key事件_esc As Boolean = True
    Dim key事件_so As Boolean = False
    Dim key事件_en As Boolean = True
    Dim 全屏事件 As Boolean
    Dim 全屏控制 As String
    Dim joyu As String
    Dim joyd As String
    Dim joyl As String
    Dim joyr As String
    Dim joye As String
    Dim joyn As String
    Dim joyso As String
    Dim next1 As String
    Dim next2 As String
    Dim ku As String
    Dim kd As String
    Dim kl As String
    Dim kr As String
    Dim ke As String
    Dim kz As String
    Dim kx As String
    Dim ks As String
    Dim kso As String
    Dim 列表数 As Integer
    Dim listNO As String
    Dim 列表 As Integer
    Dim listsize As String
    Dim 列表条数 As Integer
    Dim ops As Integer = 0
    Dim linka As Integer = 0
    Dim cshtml As String '初始页
    Dim cslb As String '初始列表
    Dim dhleix As String
    Dim mbdhleix As String
    Dim 页面数 As String
    Dim 翻页 As String
    Dim 列表value As String
    Private rect As New Rectangle
    ' Dim joypd As Integer
    '  Dim joypu As Integer
    Dim bj_zidian As New Dictionary(Of String, String)
    Dim s_list_url() As String
    Dim k_list_url() As String
    Dim pic_list_index As Integer = 0
    Dim pick_list_index As Integer = 0
    Dim k_tf As Boolean = False
    Dim s_tf As Boolean = False
    Dim web_color(7) As String
    Dim joytype As String
    Dim joy_drive As String





    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then


        End If

    End Sub



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim txt2 As String = "zuo"
        Dim txt3 As String
        Dim htmlNO As Integer
        Dim 启动 As String
        Dim 窗口top As String
        k1 = True
        Dim proc As Process()
        Dim jinchengshu As Integer
        Try
            Dim zc_ie11 As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
            If (zc_ie11.GetValue("MTN.exe") <> 11001) Then
                zc_ie11.SetValue("MTN.exe", 11001, RegistryValueKind.DWord)
                zc_ie11.SetValue("MTN.vshost.exe", 11001, RegistryValueKind.DWord)
            End If
        Catch ex As Exception

        End Try
       
        If System.Diagnostics.Process.GetProcessesByName("jincheng").Length > 0 Then
            proc = Process.GetProcessesByName("jincheng")
            For jinchengshu = 0 To proc.Length - 1
                proc(jinchengshu).Kill()
            Next
        End If
        proc = Nothing
        htmlNO = 0
        WebBrowser1.ObjectForScripting = Me
        n = 0 '初始列表显示的文件如（md，fc,sfc）先显示md
        xiang = 0 '初始列表中的游戏名称的位置
        linph = ""
        linpcss = ""
        模拟器 = "" '初始模拟器的名字
        s = "0"

        当前路径 = Application.StartupPath() '初始路径
        k = True

        fs = 当前路径 + "\daohang.xml" 'XML文件所在位置
        Me.Height = SystemInformation.PrimaryMonitorSize.Height
        Me.Width = SystemInformation.PrimaryMonitorSize.Width
        Me.WebBrowser1.Width = Me.Width
        Me.WebBrowser1.Height = Me.Height

        xmlnodes = duxml(fs, "book")


        For i As Integer = 0 To xmlnodes.Count - 1
            linph = 当前路径 + "\html\" + i.ToString + ".html"
            linpcss = 当前路径 + "\html\" + i.ToString + ".css"
            If My.Computer.FileSystem.FileExists(linph) Then

            Else
                FileCopy(当前路径 + "\ceshi.html", linph)
                Dim htmltxt() As String = File.ReadAllLines(linph)
                For j As Integer = 0 To htmltxt.Length - 1
                    txt2 = htmltxt(j)
                    txt3 = ""

                    If (InStr(txt2, "daohang.css") > 0) Then
                        txt3 += "<link rel=" + Chr(34)
                        txt3 += " stylesheet" + Chr(34)
                        txt3 += " type=" + Chr(34)
                        txt3 += "text/css" + Chr(34)
                        txt3 += " href=" + Chr(34)
                        txt3 += i.ToString + ".css" + Chr(34)
                        txt3 += " >"
                        htmltxt(j) = txt3

                    End If




                Next
                File.WriteAllLines(linph, htmltxt)
            End If
            If My.Computer.FileSystem.FileExists(linpcss) Then
            Else
                FileCopy(当前路径 + "\daohang.css", linpcss)
            End If


        Next
        joy_drive = New String(CChar(" "), 128)
        joyu = New String(CChar(" "), 128)
        joytype = New String(CChar(" "), 128)
        joyso = New String(CChar(" "), 128)
        joyd = New String(CChar(" "), 128)
        joyl = New String(CChar(" "), 128)
        joyr = New String(CChar(" "), 128)
        joye = New String(CChar(" "), 128)
        joyn = New String(CChar(" "), 128)
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
        cshtml = New String(CChar(" "), 128)
        cslb = New String(CChar(" "), 128)
        listNO = New String(CChar(" "), 128)
        listsize = New String(CChar(" "), 128)
        dhleix = New String(CChar(" "), 128)
        mbdhleix = New String(CChar(" "), 128)
        翻页 = New String(CChar(" "), 128)
        启动 = New String(CChar(" "), 128)
        窗口top = New String(CChar(" "), 128)
        全屏控制 = New String(CChar(" "), 128)
        页面数 = New String(CChar(" "), 128)
        pic_time = New String(CChar(" "), 128)


        GetPrivateProfileString("rocker", "up", "up", joyu, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "down", "down", joyd, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "left", "left", joyl, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "right", "right", joyr, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "determine", "determine", joye, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "Back", "Back", joyn, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "next page", "next page", next1, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "last page", "last page", next2, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "search", "search", joyso, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "joutype", "joutype", joytype, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "up", "up", ku, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "down", "down", kd, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "left", "left", kl, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "right", "right", kr, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "determine", "determine", ke, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "Back", "Back", kz, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "next page", "next page", kx, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "last page", "last page", ks, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("keyboard", "search", "search", kso, 128, 当前路径 + "\joy.ini")
        GetPrivateProfileString("rocker", "dx_joutype", "dx_joutype", joy_drive, 128, 当前路径 + "\joy.ini")

        GetPrivateProfileString("Startup file", "page", "page", cshtml, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "list", "list", cslb, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "List number", "List number", listNO, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Navigation mask", "Navigation mask", mbdhleix, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "General navigation", "General navigation", dhleix, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Turn pages", "Turn pages", 翻页, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Self starting", "Self starting", 启动, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Front of window", "Front of window", 窗口top, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Full screen", "Full screen", 全屏控制, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "no_web", "no_web", 页面数, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("keyboard", "search", "search", kso, 128, 当前路径 + "\joy.ini")

        Try
            GetPrivateProfileString("Startup file", "pic_interval", "pic_interval", pic_time, 128, 当前路径 + "\config.ini")
        Catch ex As Exception
            pic_time = "1"
        End Try

        joyu = 首尾删除空格(joyu)
        joyd = 首尾删除空格(joyd)
        joyl = 首尾删除空格(joyl)
        joyr = 首尾删除空格(joyr)
        joye = 首尾删除空格(joye)
        joyn = 首尾删除空格(joyn)
        joyso = 首尾删除空格(joyso)
        joytype = 首尾删除空格(joytype)
        joy_drive = 首尾删除空格(joy_drive)

        next1 = 首尾删除空格(next1)
        next2 = 首尾删除空格(next2)
        ' ku = ku.Replace(Chr(10), "")
        ku = 首尾删除空格(ku)
        kd = 首尾删除空格(kd)
        kl = 首尾删除空格(kl)
        kr = 首尾删除空格(kr)
        ke = 首尾删除空格(ke)
        kz = 首尾删除空格(kz)
        kx = 首尾删除空格(kx)
        ks = 首尾删除空格(ks)
        kso = 首尾删除空格(kso)
        cshtml = 首尾删除空格(cshtml)
        cslb = 首尾删除空格(cslb)
        mbdhleix = 首尾删除空格(mbdhleix)
        dhleix = 首尾删除空格(dhleix)

        列表数 = CInt(首尾删除空格(listNO))
        翻页 = 首尾删除空格(翻页)
        启动 = 首尾删除空格(启动)
        窗口top = 首尾删除空格(窗口top)
        全屏控制 = 首尾删除空格(全屏控制)
        页面数 = 首尾删除空格(页面数)
        pic_time = 首尾删除空格(pic_time)

        web_color(0) = "#000000"

        If (pic_time = "pic_interval") Then
            pic_time = "1"
        End If
        If My.Computer.FileSystem.FileExists(当前路径 + "\gamerom_bj.txt") Then
            Dim gamerom_bj_txt() As String = File.ReadAllLines("gamerom_bj.txt")
            For i As Integer = 0 To gamerom_bj_txt.Length - 1
                If gamerom_bj_txt(i) <> "" Then
                    bj_zidian.Add(gamerom_bj_txt(i).Split("=")(0), gamerom_bj_txt(i).Split("=")(1))
                End If

            Next
        End If


        cshtml = cshtml.Replace("/", "\")
        GetPrivateProfileString("Startup file", "Number of lists10000", "Number of lists10000", listsize, 128, 当前路径 + "\config.ini")
        列表条数 = CInt(首尾删除空格(listsize))
        If (cshtml <> "ceshi.html" And InStr(cshtml, "index") <= 0) Then
            htmlNO = CInt(cshtml.Replace("html\", "").Split(".")(0))
        End If
        If (xmlnodes.Count - 1 < htmlNO) Then
            cshtml = "html\0.html"
        End If
        If (启动 = "1") Then
            Dim 注册表 As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")

            If (注册表.GetValue("MTN.exe") = "") Then
                注册表.SetValue("MTN.exe", Application.StartupPath & "\MTN.bat")
            Else
            End If

        Else

            Dim 注册表 As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")

            If (注册表.GetValue("MTN.exe") = "") Then

            Else
                注册表.DeleteValue("MTN.exe")
            End If
        End If
        If (窗口top = "1") Then
            Me.TopMost = True

        Else
            Me.TopMost = False

        End If
        If (全屏控制 = "1") Then
            全屏事件 = True
            Me.WindowState = FormWindowState.Normal
            SetFullScreen(全屏事件, rect)
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            WritePrivateProfileString("Startup file", "Full screen", 1.ToString, 当前路径 + "\config.ini")
        Else
            全屏事件 = False
            Me.WindowState = FormWindowState.Normal
            SetFullScreen(全屏事件, rect)
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            WritePrivateProfileString("Startup file", "Full screen", 0.ToString, 当前路径 + "\config.ini")

        End If

        Dim li_text(0) As String
        li_text(0) = ""
        ' File.WriteAllLines(当前路径 + "\html\list_js\li.json", li_text)
        Dim mHandle As IntPtr = Me.Handle()


        If (InStr(cshtml, "index") > 0) Then



            Call indexY(cshtml)

        Else
            WebBrowser1.Navigate(Path.GetFullPath(cshtml))

        End If
        Call GetJoyStick2(joy_drive)
        Me.Focus()
        Dim MTN_Hwnd As Long = FindWindow("Shell_TrayWnd", Nothing)
        Dim x_y_z As Integer
        x_y_z = SetActiveWindow(MTN_Hwnd)

    End Sub
    Public Sub indexY(ByVal 文件名 As String)

        Dim html链接 As String
        Dim 替换html链接 As String
        Dim MTNtn As Integer = 0
        Dim MTNln As Integer = 0
        If (InStr(文件名, "index") > 0) Then

            页面数 = New String(CChar(" "), 128)
            GetPrivateProfileString("Startup file", "no_web", "no_web", 页面数, 128, 当前路径 + "\config.ini")
            页面数 = 首尾删除空格(页面数)
            If My.Computer.FileSystem.FileExists(当前路径 + "\html\index.html") Then


                System.IO.File.Delete(当前路径 + "\html\index.html")
            End If
            'If My.Computer.FileSystem.FileExists(当前路径 + "\" + 文件名) Then

            File.Copy(当前路径 + "\" + 文件名, 当前路径 + "\html\index.html")
            ' End If
            Dim html文件() As String = File.ReadAllLines(当前路径 + "\html\index.html")
            For i As Integer = 0 To html文件.Length - 1
                html链接 = html文件(i)

                替换html链接 = ""
                If (InStr(html链接, "{mtnl}") > 0) Then
                    ' 替换html链接 += xmlnodes(0).ChildNodes(2).InnerText
                    替换html链接 += "<a href=" + Chr(34) + "file:///" + 当前路径 + "\html\" + MTNln.ToString + ".html" + Chr(34) + ">" + xmlnodes(MTNln).ChildNodes(0).InnerText + "</a>"
                    html文件(i) = html文件(i).Replace("{mtnl}", 替换html链接)
                    If (xmlnodes.Count - 1 > MTNln) Then
                        MTNln = MTNln + 1
                    End If
                End If
                If (InStr(html链接, "{mtnt}") > 0) Then
                    ' 替换html链接 += xmlnodes(0).ChildNodes(2).InnerText
                    替换html链接 += "<a href=" + Chr(34) + "file:///" + 当前路径 + "\html\" + MTNtn.ToString + ".html" + Chr(34) + ">" + xmlnodes(MTNtn).ChildNodes(2).InnerText + "</a>"
                    html文件(i) = html文件(i).Replace("{mtnt}", 替换html链接)
                    If (xmlnodes.Count - 1 > MTNtn) Then
                        MTNtn = MTNtn + 1

                    End If
                End If
            Next
            File.WriteAllLines(当前路径 + "\html\index.html", html文件)
            WritePrivateProfileString("Startup file", "page", 文件名, 当前路径 + "\config.ini")
            WebBrowser1.Navigate(Path.GetFullPath("html\index.html"))
        Else
            WebBrowser1.Navigate(Path.GetFullPath(文件名))


        End If
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub htmlDoc_Click(sender As Object, e As HtmlElementEventArgs)
        ' Dim sss As String
        ' sss = WebBrowser1.Document.GetElementById("ziti").GetAttribute("value")

        ' sss = ""

    End Sub

    Private Sub htmlDoc_dblClick(sender As Object, e As EventArgs)
        ' Dim sss As String
        'sss = WebBrowser1.Document.GetElementById("ziti").GetAttribute("dir")

    End Sub
    Public Sub getvalue(ByVal txt As String, ByVal xuan_ze As String)

        Timer2.Enabled = False
        pic_list_index = 0
        pick_list_index = 0
        k_tf = False
        s_tf = False
        Dim s1 As String = ""
        WebBrowser1.Document.All("video-player").SetAttribute("poster", "")
        WebBrowser1.Document.All("video-player").SetAttribute("src", "")
        WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", "")
        WritePrivateProfileString("Startup file", "list", txt, 当前路径 + "\config.ini")
        WebBrowser1.Document.GetElementById("intro").InnerHtml = "<div id='intro_d1'></div><div id='intro_d2'></div>"
        xiang = CInt(txt) '选择了第几个游戏
        xuanz = CInt(xuan_ze)


        If (romxml = "kong") Then

        Else
            If My.Computer.FileSystem.FileExists(romxml) Then


                xmllist = duxml(romxml, "book")
                s1 = xmllist(xiang).ChildNodes(2).InnerText '视频或图片地址（写在xml里）
                卡带 = xmllist(xiang).ChildNodes(3).InnerText
                信息 = xmllist(xiang).ChildNodes(6).InnerText

                Dim rom_bj As String()
                Dim rom_bj_name As String
                rom_bj_name = Path.GetFileName(romxml).Replace(".xml", "")
                rom_bj_name = rom_bj_name + "_" + xiang.ToString
                Try
                    If bj_zidian.ContainsKey(rom_bj_name) Then



                        rom_bj = bj_zidian(rom_bj_name).Split(";")

                        If (System.IO.Path.GetExtension(rom_bj(0)) = ".mp4" Or System.IO.Path.GetExtension(rom_bj(0)) = ".avi") Then
                            WebBrowser1.Document.GetElementById("bvid").SetAttribute("src", Path.GetFullPath(rom_bj(0)))
                            Invoke_color("color_web", rom_bj(1), rom_bj(2), rom_bj(3), rom_bj(4), rom_bj(5), rom_bj(6), rom_bj(7))
                        Else
                            If (rom_bj(0) = "") Then
                                WebBrowser1.Document.GetElementById("bvid").SetAttribute("src", Path.GetFullPath(背景))
                            Else
                                WebBrowser1.Document.All("zhuye").SetAttribute("background", rom_bj(0))
                            End If

                            'MsgBox(rom_bj(0))
                            Invoke_color("color_web", rom_bj(1), rom_bj(2), rom_bj(3), rom_bj(4), rom_bj(5), rom_bj(6), rom_bj(7))
                        End If
                    Else
                        If (My.Computer.FileSystem.FileExists(背景)) Then
                            If (System.IO.Path.GetExtension(背景) = ".mp4" Or System.IO.Path.GetExtension(背景) = ".avi") Then
                                WebBrowser1.Document.GetElementById("bvid").SetAttribute("src", Path.GetFullPath(背景))
                                Invoke_color("color_web", web_color(1), web_color(2), web_color(3), web_color(4), web_color(5), web_color(6), web_color(7))
                            Else

                                WebBrowser1.Document.All("zhuye").SetAttribute("background", Path.GetFullPath(背景))
                                Invoke_color("color_web", web_color(1), web_color(2), web_color(3), web_color(4), web_color(5), web_color(6), web_color(7))
                            End If
                        Else
                            ' WebBrowser1.Document.All("zhuye").SetAttribute("background", "")
                            Invoke_color("color_web", web_color(1), web_color(2), web_color(3), web_color(4), web_color(5), web_color(6), web_color(7))
                        End If
                    End If
                Catch ex As Exception



                End Try
                If (信息 = "kong") Then
                    信息 = "<div id='intro_d1'></div><div id='intro_d2'></div>"
                    WebBrowser1.Document.GetElementById("intro").InnerHtml = 信息
                Else
                    If (My.Computer.FileSystem.FileExists(信息)) Then
                        Dim fileReader As String
                        fileReader = My.Computer.FileSystem.ReadAllText(信息)
                        WebBrowser1.Document.GetElementById("intro").InnerHtml = "<div id='intro_d1'>" + fileReader + "</div><div id='intro_d2'></div>"
                    Else
                        信息 = "<div id='intro_d1'></div><div id='intro_d2'></div>"
                        WebBrowser1.Document.GetElementById("intro").InnerHtml = 信息
                    End If
                End If
                If (卡带 = "kong") Then
                    卡带 = ""
                    WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", 卡带)

                Else
                    If Path.GetExtension(卡带) = ".txt" And My.Computer.FileSystem.FileExists(卡带) Then
                        k_list_url = File.ReadAllLines(卡带)
                        k_tf = True
                        Timer2.Interval = 100
                        Timer2.Enabled = True
                    Else
                        If Path.GetDirectoryName(卡带).Length >= 4 Then
                            If Path.GetDirectoryName(卡带) = "http:" Or
                            Path.GetDirectoryName(卡带).Substring(0, 4) = "http" Or
                            Path.GetDirectoryName(卡带).Substring(0, 3) = "ftp" Then
                                WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", 卡带)
                            Else
                                WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", Path.GetFullPath(卡带))
                            End If
                        End If
                    End If
                End If


                If s1 = "kong" Then

                    s1 = xmllist(xiang).ChildNodes(4).InnerText '视频或图片地址（写在xml里）

                    If s1 = "kong" Then

                        WebBrowser1.Document.All("video-player").SetAttribute("poster", "") '显示图片
                        WebBrowser1.Document.All("video-player").SetAttribute("src", 当前路径 + "/theme/static.mp4")
                    Else
                        If Path.GetExtension(s1) = ".txt" And My.Computer.FileSystem.FileExists(s1) Then
                            s_list_url = File.ReadAllLines(s1)
                            s_tf = True
                            Timer2.Interval = 100
                            Timer2.Enabled = True


                        Else
                            If Path.GetDirectoryName(s1) = "http:" Or
                            Path.GetDirectoryName(s1).Substring(0, 4) = "http" Or
                              Path.GetDirectoryName(s1).Substring(0, 5) = "https" Or
                              Path.GetDirectoryName(s1).Substring(0, 3) = "ftp" Then

                                WebBrowser1.Document.All("video-player").SetAttribute("poster", s1) '显示图片
                            Else
                                WebBrowser1.Document.All("video-player").SetAttribute("poster", Path.GetFullPath(s1)) '显示图片
                                WebBrowser1.Document.All("video-player").SetAttribute("src", "")
                            End If
                        End If
                    End If
                    ' WebBrowser1.Document.All("video-player").SetAttribute("poster", Path.GetFullPath(s1)) '显示图片
                    '  WebBrowser1.Document.All("video-player").SetAttribute("src", "")

                Else
                    Dim sty As String = Path.GetExtension(s1)
                    If sty = ".jpg" Or sty = ".png" Or sty = ".gif" Or sty = ".jpeg" Or sty = ".bmp" Then
                        WebBrowser1.Document.All("video-player").SetAttribute("poster", Path.GetFullPath(s1)) '显示图片
                        WebBrowser1.Document.All("video-player").SetAttribute("src", "")
                    Else
                        If Path.GetDirectoryName(s1) = "http:" Or
                        Path.GetDirectoryName(s1).Substring(0, 4) = "http" Or
                          Path.GetDirectoryName(s1).Substring(0, 5) = "https" Or
                          Path.GetDirectoryName(s1).Substring(0, 3) = "ftp" Then
                            WebBrowser1.Document.All("video-player").SetAttribute("src", s1)
                        Else
                            'WebBrowser1.Document.All("video-player").SetAttribute("poster", "")
                            WebBrowser1.Document.All("video-player").SetAttribute("src", Path.GetFullPath(s1)) '显示视频

                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Public Sub openrom(ByVal txt As String)
        Dim s1 As String = ""
        Dim mnq As String
        Dim miname As String
        Dim romp As String
        Dim battxt As String
        Dim 模拟器盘符 As String
        Dim 模拟器p As String
        Dim 模拟器rom As String
        Dim 核心 As String
        Dim cank As Boolean = False
        WritePrivateProfileString("Startup file", "list", txt, 当前路径 + "\config.ini")

        Try


            If (模拟器 = "kong") Then

                If (xmlnodes(xiang).ChildNodes(0).InnerText = "kong") Then
                    MsgBox("未选中启动文件")
                Else
                    s1 = xmllist(xiang).ChildNodes(0).InnerText '游戏rom路径
                    File.WriteAllText("pics.txt", s1)
                    romp = xmllist(xiang).ChildNodes(0).InnerText
                    If Path.GetExtension(s1) = ".xml" Then

                        If My.Computer.FileSystem.FileExists(s1) Then
                            romxml = s1
                            WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                            key_rom_xml = True
                            WebBrowser1.Refresh()
                        End If
                    ElseIf (Path.GetExtension(s1) = "") Then
                        ShellExecute(0, "open", s1, "", "", 1)
                    ElseIf Path.GetDirectoryName(s1) = "http:" Or
                           Path.GetDirectoryName(s1).Substring(0, 4) = "http" Or
                           Path.GetDirectoryName(s1).Substring(0, 3) = "ftp" Then
                        ShellExecute(0, "open", s1, "", "", 1)
                    ElseIf Not My.Computer.FileSystem.FileExists(s1) Then
                        Dim yesno As Integer
                        Dim d_rom_name As String

                        yesno = MsgBox("游戏不存在是否去下载", MsgBoxStyle.YesNo)
                        If yesno = 6 Then
                            d_rom_name = text_处理(xmllist(xiang).ChildNodes(1).InnerText)
                            File.WriteAllText(当前路径 + "\dws.txt", d_rom_name)
                            If (My.Computer.FileSystem.FileExists(当前路径 + "\download.exe")) Then
                                ShellExecute(0, "open", "download.exe", "", "", 1)
                                End

                            Else
                                WebBrowser1.Document.InvokeScript("jingyin")
                                Form12.Label4.Text = 2
                                Form12.Show()
                                Me.Hide()
                            End If
                        End If
                    Else

                        mnq = romp
                        miname = romp




                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(romp))
                        模拟器p = romp
                        battxt = " "
                        miname = Path.GetFileName(miname)
                        miname = miname.Replace(Path.GetExtension(miname), "")

                        ' Dim FileProperties As FileVersionInfo =
                        ' FileVersionInfo.GetVersionInfo(模拟器p)
                        ' Dim 进程名称 As String = FileProperties.FileName

                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)

                        battxt += "start" + Chr(32) + Chr(34) + Chr(34) + Chr(32) + Chr(34) + Path.GetFileName(模拟器p) + Chr(34)

                        Dim LocaleID As Long
                        LocaleID = GetSystemDefaultLCID()

                        Select Case LocaleID
                            Case &H404
                                MsgBox("中文繁体")
                                System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.GetEncoding("BIG5"))
                            Case &H804
                                ' MsgBox("中文简体")
                                System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.GetEncoding("GB2312"))
                            Case &H409
                                System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.Default)
                            Case Else
                                System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.Default)
                        End Select


                        WritePrivateProfileString("Startup file", "simulator", miname, 当前路径 + "\config.ini")

                        ShellExecute(0, "open", "qidong.bat", "", "", 1) '使用模拟器（MXL中）打开rom
                        SetFullScreen(False, rect)
                        Threading.Thread.Sleep(100)
                        If k1 Then
                            Dim proc As Process()
                            Dim jinchengshu As Integer

                            If System.Diagnostics.Process.GetProcessesByName("jincheng").Length > 0 Then
                                proc = Process.GetProcessesByName("jincheng")
                                For jinchengshu = 0 To proc.Length - 1
                                    proc(jinchengshu).Kill()
                                Next
                            End If
                            proc = Nothing

                            ShellExecute(0, "open", "jincheng", "", "", 0)
                            k1 = False
                        End If
                        End

                    End If
                End If





            Else

                s1 = xmllist(xiang).ChildNodes(0).InnerText '游戏rom路径
                File.WriteAllText("pics.txt", s1)
                romp = xmllist(xiang).ChildNodes(0).InnerText

                模拟器rom = xmllist(xiang).ChildNodes(5).InnerText
                If Path.GetExtension(s1) = ".xml" Then
                    If My.Computer.FileSystem.FileExists(s1) Then
                        romxml = s1
                        WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                        key_rom_xml = True

                        WebBrowser1.Refresh()
                    End If
                ElseIf Not My.Computer.FileSystem.FileExists(s1) Then
                    Dim yesno As Integer
                    Dim d_rom_name As String
                    yesno = MsgBox("游戏不存在是否去下载", MsgBoxStyle.YesNo)
                    If yesno = 6 Then
                        d_rom_name = text_处理(xmllist(xiang).ChildNodes(1).InnerText)
                        File.WriteAllText(当前路径 + "\dws.txt", d_rom_name)
                        If (My.Computer.FileSystem.FileExists(当前路径 + "\download.exe")) Then
                            ShellExecute(0, "open", "download.exe", "", "", 1)
                            End

                        Else
                            WebBrowser1.Document.InvokeScript("jingyin")
                            Form12.Label4.Text = 2
                            Form12.Show()
                            Me.Hide()
                        End If
                    End If
                Else

                    If (模拟器rom = "kong") Then
                        mnq = 模拟器
                        miname = 模拟器
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(模拟器))
                        模拟器p = 模拟器
                        核心 = dll

                    ElseIf (System.IO.Path.GetExtension(模拟器rom) = ".dll") Then
                        mnq = 模拟器
                        miname = 模拟器
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(模拟器))
                        模拟器p = 模拟器
                        核心 = 模拟器rom
                    ElseIf (Not My.Computer.FileSystem.FileExists(模拟器rom)) Then
                        mnq = 模拟器
                        miname = 模拟器
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(模拟器))
                        模拟器p = 模拟器
                        核心 = 模拟器rom
                        cank = True
                    Else
                        mnq = 模拟器rom
                        miname = 模拟器rom
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(模拟器rom))
                        模拟器p = 模拟器rom
                        核心 = dll

                    End If

                    battxt = " "
                    miname = Path.GetFileName(miname)
                    miname = miname.Replace(Path.GetExtension(miname), "")


                    If (miname = "retroarch") Then
                        If (核心 = "kong") Then
                            battxt = " "
                            battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                            battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                            battxt += "start" + Chr(32) + Path.GetFileName(模拟器p) + Chr(32)
                        Else
                            If (romp = "kong") Then
                                battxt = " "
                                battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                                battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                                battxt += "start" + Chr(32) + Path.GetFileName(模拟器p) + Chr(32) + "-L" + Chr(32) + Path.GetFullPath(核心).Replace(模拟器盘符 + "\", "")

                            Else
                                battxt = " "
                                battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                                battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                                battxt += "start" + Chr(32) + Path.GetFileName(模拟器p) + Chr(32) + "-L" + Chr(32) + Path.GetFullPath(核心).Replace(模拟器盘符 + "\", "") + Chr(32)
                                battxt += Chr(34) + Path.GetFullPath(romp) + Chr(34)
                            End If
                        End If

                    ElseIf (romp = "kong") Then
                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                        battxt += "start" + Chr(32) + Path.GetFileName(模拟器p)

                    ElseIf (miname = "mame") Then
                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                        battxt += "start" + Chr(32) + Path.GetFileName(模拟器p)
                        battxt += " -rompath" + Chr(32) + Chr(34) + Path.GetDirectoryName(Path.GetFullPath(romp)) + Chr(34)
                        battxt += Chr(32) + Path.GetFileName(romp)
                    ElseIf (miname = "cmd") Then
                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                        battxt += "start" + Chr(32) + Path.GetFileName(模拟器p) + Chr(32) + "/k"
                        battxt += Chr(32) + Chr(34) + Path.GetFullPath(romp) + Chr(34)
                    ElseIf (miname = "fbneo" Or miname = "fbneo64") Then

                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                        battxt += "start" + Chr(32) + Path.GetFileName(模拟器p)
                        battxt += Chr(32) + Chr(34) + Path.GetFileNameWithoutExtension(romp) + Chr(34)
                        'battxt += Chr(32) + "-w"
                    Else

                        battxt = " "
                        battxt += 模拟器盘符.Substring(0, 2) + Chr(13) + Chr(10)
                        battxt += "cd" + Chr(32) + Chr(34) + 模拟器盘符 + Chr(34) + Chr(13) + Chr(10)
                        battxt += "start" + Chr(32) + Path.GetFileName(模拟器p)

                        battxt += Chr(32) + Chr(34) + Path.GetFullPath(romp) + Chr(34)

                    End If
                    If cank Then
                        battxt += Chr(32) + 核心
                    End If
                    Dim LocaleID As Long
                    LocaleID = GetSystemDefaultLCID()

                    Select Case LocaleID
                        Case &H404
                            ' MsgBox("中文繁体")
                            System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.GetEncoding("BIG5"))
                        Case &H804
                            ' MsgBox("中文简体")
                            System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.GetEncoding("GB2312"))
                        Case &H409
                            System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.Default)
                        Case Else
                            System.IO.File.WriteAllText(当前路径 + "\qidong.bat", battxt, System.Text.Encoding.Default)
                    End Select

                    WritePrivateProfileString("Startup file", "simulator", miname, 当前路径 + "\config.ini")


                    ShellExecute(0, "open", "qidong.bat", "", "", 1) '使用模拟器（MXL中）打开rom
                    SetFullScreen(False, rect)
                    Threading.Thread.Sleep(100)
                    If k1 Then
                        Dim proc As Process()
                        Dim jinchengshu As Integer

                        If System.Diagnostics.Process.GetProcessesByName("jincheng").Length > 0 Then
                            proc = Process.GetProcessesByName("jincheng")
                            For jinchengshu = 0 To proc.Length - 1
                                proc(jinchengshu).Kill()
                            Next
                        End If
                        proc = Nothing

                        ShellExecute(0, "open", "jincheng", "", "", 0)
                        k1 = False
                    End If
                    End
                End If
            End If
        Catch ex As Exception
            ShellExecute(0, "open", s1, "", "", 1)

            ' MsgBox("出现异常无法启动")
        End Try
        ' Me.WindowState = FormWindowState.Minimized '最小化窗口本来应该选择关闭的，这里只是测试
    End Sub
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Dim yemian As String
        key事件_l = True
        key事件_r = True
        key事件 = True
        Dim key事件_s As Boolean = True
        Dim key事件_x As Boolean = True
        Dim 鼠标事件_s As Boolean = True
        Dim 鼠标事件_x As Boolean = True
        s = WebBrowser1.Document.Url.ToString()
        Timer1.Enabled = False
        yemian = s.Replace("file:///", "").Replace("/", "\").Replace(当前路径 + "\", "")

        If (InStr(yemian, "index") > 0) Then


        Else
            If (My.Computer.FileSystem.FileExists(Path.GetFullPath(yemian))) Then
                WritePrivateProfileString("Startup file", "page", yemian, 当前路径 + "\config.ini")
                cshtml = yemian

                WritePrivateProfileString("Startup file", "no_web", cshtml.Replace("html\", "").Split(".")(0), 当前路径 + "\config.ini")
            Else
                WritePrivateProfileString("Startup file", "page", "ceshi.html", 当前路径 + "\config.ini")
            End If
            s = Path.GetFileName(s)
            s = s.Replace(Path.GetExtension(s), "")
        End If
        If (s = "ceshi") Then
            k = True
        Else
            k = False
        End If

    End Sub
    Public Sub shezhi()


        WritePrivateProfileString("Startup file", "list", xuanz.ToString, 当前路径 + "\config.ini")
        ShellExecute(0, "open", 当前路径 + "\shezhi.exe", "", "", 1)
        SetFullScreen(False, rect)

        End
    End Sub
    Public Sub dwie11()
        Dim jiance As String
        jiance = New String(CChar(" "), 128)
        GetPrivateProfileString("Startup file", "detection", "detection", jiance, 128, 当前路径 + "\config.ini")
        jiance = 首尾删除空格(jiance)
        If jiance = "0" Then
            WebBrowser1.Document.InvokeScript("jingyin")
            Form12.Label4.Text = 2
            Form12.Show()
            Me.Hide()
        End If
    End Sub
    Public Sub dh(ByVal shu As Integer)
        linph = ""
        xuanz = 0
        cslb = "0"
        列表数 = 0
        翻页 = "0"
        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
        WritePrivateProfileString("Startup file", "Turn pages", 列表数.ToString, 当前路径 + "\config.ini")
        WritePrivateProfileString("Startup file", "list", cslb, 当前路径 + "\config.ini")
        linph = 当前路径 + "\html\" + shu.ToString + ".html"
        WebBrowser1.Navigate(linph)
    End Sub
    Public Sub chushi()

        Dim htmlDoc = WebBrowser1.Document
        Dim lina As String
        Dim nobe As Xml.XmlElement
        Dim cssp As String
        Dim html_color_index As Integer

        lina = ""
        cssp = ""
        'linph = 当前路径 + "\html\" + s + ".html"
        xmlnodes = duxml(fs, "book") '声明XML文件对象
        n = 0
        Dim li_text(0) As String
        li_text(0) = ""
        html_color_index = CInt(cshtml.Replace("html\", "").Split(".")(0))



        GetPrivateProfileString(html_color_index.ToString, "ziti_color", "ziti_color", web_ziti_color, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "id1_color", "id1_color", web_a_color, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "id1_background", "id1_background", web_a_bgcolor, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "id1_xzh_bd", "id1_xzh_bd", web_az_bgcolor, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "id1_xzh_color", "id1_xzh_color", web_az_color, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "intro_color", "intro_color", web_intro_color, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString(html_color_index.ToString, "intro_background", "intro_background", web_intro_bgcolor, 128, 当前路径 + "\config.ini")


        web_color(1) = web_ziti_color
        web_color(2) = web_a_color
        web_color(3) = web_a_bgcolor
        web_color(4) = web_az_color
        web_color(5) = web_az_bgcolor
        web_color(6) = web_intro_color
        web_color(7) = web_intro_bgcolor
        web_color(1) = 首尾删除空格(web_color(1))
        web_color(2) = 首尾删除空格(web_color(2))
        web_color(3) = 首尾删除空格(web_color(3))
        web_color(4) = 首尾删除空格(web_color(4))
        web_color(5) = 首尾删除空格(web_color(5))
        web_color(6) = 首尾删除空格(web_color(6))
        web_color(7) = 首尾删除空格(web_color(7))
        If (web_color(1) = "ziti_color") Then
            web_color(1) = ""
            WritePrivateProfileString(html_color_index.ToString, "ziti_color", "", 当前路径 + "\config.ini")
        End If
        If (web_color(2) = "id1_color") Then
            web_color(2) = ""
            WritePrivateProfileString(html_color_index.ToString, "id1_color", "", 当前路径 + "\config.ini")
        End If
        If (web_color(3) = "id1_background") Then
            web_color(3) = ""
            WritePrivateProfileString(html_color_index.ToString, "id1_background", "", 当前路径 + "\config.ini")
        End If
        If (web_color(4) = "id1_xzh_color") Then
            web_color(4) = ""
            WritePrivateProfileString(html_color_index.ToString, "id1_xzh_color", "", 当前路径 + "\config.ini")
        End If
        If (web_color(5) = "id1_xzh_bd") Then
            web_color(5) = ""
            WritePrivateProfileString(html_color_index.ToString, "id1_xzh_bd", "", 当前路径 + "\config.ini")
        End If
        If (web_color(6) = "intro_color") Then
            web_color(6) = ""
            WritePrivateProfileString(html_color_index.ToString, "intro_color", "", 当前路径 + "\config.ini")
        End If
        If (web_color(7) = "intro_background") Then
            web_color(7) = ""
            WritePrivateProfileString(html_color_index.ToString, "intro_background", "", 当前路径 + "\config.ini")
        End If

        'File.WriteAllLines(当前路径 + "\html\list_js\li.json", li_text)
        If 列表数 < 0 Then
            列表数 = 0
            翻页 = "0"
        End If


        WebBrowser1.Document.All("beiban").SetAttribute("src", 当前路径 + "\theme\mengban.gif")
        If k Then

            For Each nobe In xmlnodes '循环读取XML文件中（book）的所有元素
                If (nobe("name").InnerText <> "kong") Then
                    lina += "<a href="
                    lina += Chr(34)

                    lina += 当前路径 + "\html\" + n.ToString + ".html"
                    lina += Chr(34)
                    lina += ">"
                    lina += nobe("name").InnerText
                    lina += "</a>"
                Else
                    lina += "<a href="
                    lina += Chr(34)

                    lina += 当前路径 + "\html\" + n.ToString + ".html"
                    lina += Chr(34)
                    lina += ">"
                    lina += nobe("txt").InnerText
                    lina += "</a>"

                End If

                n += 1
            Next
            WebBrowser1.Document.GetElementById("id1").InnerHtml = lina '将所有模拟器对应的中文名添加到导航菜单
            linka = n
            WebBrowser1.Document.GetElementsByTagName("a")(0).SetAttribute("id", "xuanzhong")
            模拟器 = xmlnodes(0).ChildNodes(1).InnerText '模拟器的位置（如FCxml）<lujing>C:\Users\Administrator\Desktop\vb.net\VirtuaNES\VirtuaNES.exe</lujing>
            电视机 = xmlnodes(0).ChildNodes(4).InnerText
            游戏机 = xmlnodes(0).ChildNodes(5).InnerText
            背景 = xmlnodes(0).ChildNodes(6).InnerText
            页眉 = xmlnodes(0).ChildNodes(7).InnerText
            人物 = xmlnodes(0).ChildNodes(8).InnerText
            dll = xmlnodes(0).ChildNodes(9).InnerText
            logo = WebBrowser1.Document.All("logo").GetAttribute("src").Replace("file:///", "").Replace("%20", " ")
            logo = logo.Replace("/html", "")
            mengban = WebBrowser1.Document.All("mengban").GetAttribute("src").Replace("file:///", "").Replace("%20", " ")
            mengban = mengban.Replace("/html", "")

            If (游戏机 = "kong") Then
                游戏机 = ""
                WebBrowser1.Document.All("jiz").SetAttribute("src", "")
            Else

                WebBrowser1.Document.All("jiz").SetAttribute("src", Path.GetFullPath(游戏机))
            End If
            If (电视机 = "kong") Then
                电视机 = ""
                WebBrowser1.Document.All("dsh").SetAttribute("src", "")
            Else

                WebBrowser1.Document.All("dsh").SetAttribute("src", Path.GetFullPath(电视机))
            End If
            If (背景 = "kong") Then
                背景 = ""
                'WebBrowser1.Document.All("zhuye").SetAttribute("background", "")
            Else

                If (System.IO.Path.GetExtension(背景) = ".mp4" Or System.IO.Path.GetExtension(背景) = ".avi") Then
                    WebBrowser1.Document.GetElementById("bvid").SetAttribute("src", Path.GetFullPath(背景))

                Else
                    WebBrowser1.Document.All("zhuye").SetAttribute("background", Path.GetFullPath(背景))
                End If

            End If
            If (页眉 = "kong") Then
                页眉 = ""
                WebBrowser1.Document.All("yemei").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("yemei").SetAttribute("src", Path.GetFullPath(页眉))
            End If
            If (人物 = "kong") Then
                人物 = ""
                WebBrowser1.Document.All("renwu").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("renwu").SetAttribute("src", Path.GetFullPath(人物))
            End If
            If (logo = "" Or Not My.Computer.FileSystem.FileExists(logo)) Then
                logo = ""
                WebBrowser1.Document.All("logo").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("logo").SetAttribute("src", logo)

            End If
            If (mengban = "" Or Not My.Computer.FileSystem.FileExists(mengban)) Then
                mengban = ""
                WebBrowser1.Document.All("mengban").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("mengban").SetAttribute("src", mengban)

            End If



            If xmlnodes(0).ChildNodes(3).InnerText <> "kong" Then
                If key_rom_xml Then

                Else
                    romxml = xmlnodes(0).ChildNodes(3).InnerText '游戏列表的位置（如FCxml）<xmlfile>C:\Users\Administrator\Desktop\vb.net\rom\psp\game.xml</xmlfile>
                End If


                n = 0
                lina = ""

                If My.Computer.FileSystem.FileExists(romxml) Then

                    xmllist = duxml(romxml, "book") '建立列表XML对象
                    If xmllist.Count - 列表数 <= 0 Then
                        列表数 = 0
                        翻页 = "0"
                        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                    End If
                    If (xmllist.Count - 列表数 > 列表条数) Then
                        列表 = list(列表数, 列表数 + (列表条数 - 1))
                    Else
                        列表 = list(列表数, xmllist.Count - 1)
                    End If

                    AddHandler htmlDoc.Click, AddressOf htmlDoc_Click
                    htmlDoc.AttachEventHandler("ondblclick", AddressOf htmlDoc_dblClick)
                    '  AddHandler htmlDoc.ContextMenuShowing, AddressOf htmlDoc_ContextMenuShowing
                    ' AddHandler htmlDoc.ContextMenuShowing, AddressOf htmlDoc_ContextMenuShowing

                    '  htmlDoc.AttachEventHandler("ondblclick", AddressOf htmlDoc_ContextMenuShowing)
                Else
                    lina += "<option value=" + Chr(34) + "0" + Chr(34) + ">" + "添加游戏列表" + "</option>"
                    WebBrowser1.Document.GetElementById("ziti").InnerHtml = lina '将XML的游戏名称添加到列表框
                End If
            Else
                romxml = xmlnodes(CInt(s)).ChildNodes(3).InnerText
                lina += "<option value=" + Chr(34) + "0" + Chr(34) + ">" + "添加游戏列表" + "</option>"
                WebBrowser1.Document.GetElementById("ziti").InnerHtml = lina '将XML的游戏名称添加到列表框
                k = False
            End If
            xmlnodes = duxml(fs, "book")
            If xmlnodes(0).ChildNodes(3).InnerText = "kong" And k Then
                lina += "<option value=" + Chr(34) + "0" + Chr(34) + ">" + "添加游戏列表" + "</option>"
                WebBrowser1.Document.GetElementById("ziti").InnerHtml = lina '将XML的游戏名称添加到列表框
                k = False
            End If
        Else

            xuana = CInt(s)
            cssp = 当前路径 + "\html\" + s + ".css"
            GetPrivateProfileString("Startup file", "Number of lists" + s, "Number of lists" + s, listsize, 128, 当前路径 + "\config.ini")
            列表条数 = CInt(首尾删除空格(listsize))
            Dim csstxt As TextReader = File.OpenText(cssp)
            Dim txt1 As String
            Dim txt2 As String = "zuo"
            While csstxt.Peek() > -1
                txt1 = csstxt.ReadLine
                Select Case txt1
                    Case ".topnav a {"
                        While (InStr(txt1, "float:") <= 0)
                            txt1 = csstxt.ReadLine
                        End While
                        txt2 = txt1.Split(";")(0)
                        txt2 = txt2.Split(":")(1).Replace(" ", "")

                        GoTo 左右
                End Select
            End While
左右:


            If (txt2 = "right") Then
                For i As Integer = xmlnodes.Count - 1 To 0 Step -1
                    If (xmlnodes(i).ChildNodes(0).InnerText <> "kong") Then
                        lina += "<a href="
                        lina += Chr(34)

                        lina += 当前路径 + "\html\" + i.ToString + ".html"
                        lina += Chr(34)
                        lina += ">"
                        lina += xmlnodes(i).ChildNodes(0).InnerText
                        lina += "</a>"
                    Else
                        lina += "<a href="
                        lina += Chr(34)

                        lina += 当前路径 + "\html\" + i.ToString + ".html"
                        lina += Chr(34)
                        lina += ">"
                        lina += xmlnodes(i).ChildNodes(2).InnerText
                        lina += "</a>"
                    End If




                Next

                WebBrowser1.Document.GetElementById("id1").InnerHtml = lina
                linka = xmlnodes.Count
                WebBrowser1.Document.GetElementsByTagName("a")((xmlnodes.Count - 1) - CInt(s)).SetAttribute("id", "xuanzhong")
            Else

                For Each nobe In xmlnodes '循环读取XML文件中（book）的所有元素
                    If (nobe("name").InnerText <> "kong") Then
                        lina += "<a href="
                        lina += Chr(34)

                        lina += 当前路径 + "\html\" + n.ToString + ".html"
                        lina += Chr(34)
                        lina += ">"
                        lina += nobe("name").InnerText
                        lina += "</a>"
                    Else
                        lina += "<a href="
                        lina += Chr(34)

                        lina += 当前路径 + "\html\" + n.ToString + ".html"
                        lina += Chr(34)
                        lina += ">"
                        lina += nobe("txt").InnerText
                        lina += "</a>"
                    End If


                    n += 1
                Next
                WebBrowser1.Document.GetElementById("id1").InnerHtml = lina '将所有模拟器对应的中文名添加到导航菜单
                linka = n
                WebBrowser1.Document.GetElementsByTagName("a")(CInt(s)).SetAttribute("id", "xuanzhong")
            End If
            模拟器 = xmlnodes(CInt(s)).ChildNodes(1).InnerText '模拟器的位置（如FCxml）<lujing>C:\Users\Administrator\Desktop\vb.net\VirtuaNES\VirtuaNES.exe</lujing>
            电视机 = xmlnodes(CInt(s)).ChildNodes(4).InnerText
            游戏机 = xmlnodes(CInt(s)).ChildNodes(5).InnerText
            背景 = xmlnodes(CInt(s)).ChildNodes(6).InnerText
            页眉 = xmlnodes(CInt(s)).ChildNodes(7).InnerText
            人物 = xmlnodes(CInt(s)).ChildNodes(8).InnerText
            dll = xmlnodes(CInt(s)).ChildNodes(9).InnerText

            logo = WebBrowser1.Document.All("logo").GetAttribute("src").Replace("file:///", "").Replace("%20", " ")
            logo = logo.Replace("/html", "")
            mengban = WebBrowser1.Document.All("mengban").GetAttribute("src").Replace("file:///", "").Replace("%20", " ")
            mengban = mengban.Replace("/html", "")

            If (游戏机 = "kong") Then
                游戏机 = ""
                WebBrowser1.Document.All("jiz").SetAttribute("src", "")
            Else

                WebBrowser1.Document.All("jiz").SetAttribute("src", Path.GetFullPath(游戏机))
            End If
            If (电视机 = "kong") Then
                电视机 = ""
                WebBrowser1.Document.All("dsh").SetAttribute("src", "")
            Else

                WebBrowser1.Document.All("dsh").SetAttribute("src", Path.GetFullPath(电视机))
            End If
            If (背景 = "kong") Then
                背景 = ""
                ' WebBrowser1.Document.All("zhuye").SetAttribute("background", "")
            Else

                If (System.IO.Path.GetExtension(背景) = ".mp4" Or System.IO.Path.GetExtension(背景) = ".avi") Then
                    WebBrowser1.Document.GetElementById("bvid").SetAttribute("src", Path.GetFullPath(背景))

                Else
                    WebBrowser1.Document.All("zhuye").SetAttribute("background", Path.GetFullPath(背景))
                End If

            End If
            If (页眉 = "kong") Then
                页眉 = ""
                WebBrowser1.Document.All("yemei").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("yemei").SetAttribute("src", Path.GetFullPath(页眉))
            End If
            If (人物 = "kong") Then
                人物 = ""
                WebBrowser1.Document.All("renwu").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("renwu").SetAttribute("src", Path.GetFullPath(人物))
            End If
            If (logo = "" Or Not My.Computer.FileSystem.FileExists(logo)) Then
                logo = ""
                WebBrowser1.Document.All("logo").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("logo").SetAttribute("src", logo)

            End If
            If (mengban = "" Or Not My.Computer.FileSystem.FileExists(mengban)) Then
                mengban = ""
                WebBrowser1.Document.All("mengban").SetAttribute("src", "")
            Else
                WebBrowser1.Document.All("mengban").SetAttribute("src", mengban)

            End If
            If xmlnodes(CInt(s)).ChildNodes(3).InnerText <> "kong" Then
                If key_rom_xml Then
                Else
                    romxml = xmlnodes(CInt(s)).ChildNodes(3).InnerText '游戏列表的位置（如FCxml）<xmlfile>C:\Users\Administrator\Desktop\vb.net\rom\psp\game.xml</xmlfile>
                End If


                n = 0
                lina = ""

                If My.Computer.FileSystem.FileExists(romxml) Then

                    xmllist = duxml(romxml, "book") '建立列表XML对象
                    If xmllist.Count - 列表数 <= 0 Then
                        列表数 = 0
                        翻页 = "0"
                        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                    End If

                    If (xmllist.Count - 列表数 > 列表条数) Then
                        列表 = list(列表数, 列表数 + (列表条数 - 1))
                    Else
                        列表 = list(列表数, xmllist.Count - 1)
                    End If

                    AddHandler htmlDoc.Click, AddressOf htmlDoc_Click
                    htmlDoc.AttachEventHandler("ondblclick", AddressOf htmlDoc_dblClick)
                Else
                    lina += "<option value=" + Chr(34) + "0" + Chr(34) + ">" + "添加游戏列表" + "</option>"
                    WebBrowser1.Document.GetElementById("ziti").InnerHtml = lina '将XML的游戏名称添加到列表框
                End If
                k = False
            End If
            xmlnodes = duxml(fs, "book")
            If xmlnodes(CInt(s)).ChildNodes(3).InnerText = "kong" Then
                romxml = xmlnodes(CInt(s)).ChildNodes(3).InnerText
                lina += "<option value=" + Chr(34) + "0" + Chr(34) + ">" + "添加游戏列表" + "</option>"
                WebBrowser1.Document.GetElementById("ziti").InnerHtml = lina '将XML的游戏名称添加到列表框
                k = False
            End If
        End If
        If (WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count - 1 >= CInt(cslb)) Then
            WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(CInt(cslb)).SetAttribute("selected", "true")
            xuanz = CInt(cslb)
        Else
            xuanz = 0
            WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")

        End If
        'If (mbdhleix = "0") Then
        ' WebBrowser1.Document.InvokeScript("yinchang")
        'Else
        'WebBrowser1.Document.InvokeScript("xianshi")
        'End If

        If (dhleix = "0") Then
            WebBrowser1.Document.InvokeScript("yidh")

        Else
            WebBrowser1.Document.InvokeScript("xidh")

        End If
        Timer1.Enabled = True
    End Sub


    Private Sub WebBrowser1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles WebBrowser1.PreviewKeyDown

        Dim 列表值 As String
        Try


            If (InStr(cshtml, "index") > 0 Or key事件_so) Then

                If (key事件) Then
                    Select Case e.KeyCode
                        Case kd
                            mouse_event(&H1, 0, 20, 0, 0)

                            WebBrowser1.Document.InvokeScript("k_dw")
                        Case ku
                            mouse_event(&H1, 0, -20, 0, 0)
                            WebBrowser1.Document.InvokeScript("k_up")
                        Case kl
                            mouse_event(&H1, -20, 0, 0, 0)
                            WebBrowser1.Document.InvokeScript("k_left")
                        Case kr
                            mouse_event(&H1, 20, 0, 0, 0)
                            WebBrowser1.Document.InvokeScript("k_right")
                        Case ke
                            mouse_event(&H2, 0, 0, 0, 0)
                            Threading.Thread.Sleep(50)
                            mouse_event(&H4, 0, 0, 0, 0)
                            Threading.Thread.Sleep(50)
                            WebBrowser1.Document.InvokeScript("k_start")
                        Case kz
                            xmlnodes = duxml(fs, "book")
                            cshtml = "html\index1.html"
                            Call indexY(cshtml)
                        Case ks

                            WebBrowser1.Document.InvokeScript("k_last")
                        Case kx
                            WebBrowser1.Document.InvokeScript("k_next")
                    End Select
                End If
                key事件 = Not (key事件)
            Else

                ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count

                列表值 = xiang

                Select Case e.KeyCode
                    Case kd

                        If (xuanz < ops - 1) Then
                            xuanz = xuanz + 1
                            Console.WriteLine(xuanz)
                            Console.WriteLine(ops - 1)
                            Call 选择(1, xuanz)

                        Else
                            If (xmllist.Count - 列表值 > 列表条数) Then
                                列表 = list(CInt(列表值), CInt(列表值) + (列表条数 - 1))
                                翻页 = CInt(翻页) + (列表条数 - 1)
                                ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                列表数 = 列表 - (列表条数 - 1)
                                xuanz = 0
                                Call 选择(1, xuanz)
                                WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")

                            ElseIf (xmllist.Count - CInt(列表值) - 1 = 0) Then
                                ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")

                            Else

                                列表 = list(CInt(列表值), xmllist.Count - 1)
                                翻页 = (0 - CInt(列表条数 - 1)).ToString
                                ops = (xmllist.Count - 1) - CInt(列表值)
                                ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                列表数 = 列表 - (列表 - CInt(列表值))
                                WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                xuanz = 0
                                Call 选择(1, xuanz)

                            End If


                        End If
                        WebBrowser1.Document.InvokeScript("k_dw")
                    Case ku
                        ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                        If (xuanz > 0) Then
                            xuanz = xuanz - 1
                            Call 选择(2, xuanz)


                        Else



                            If (xmllist.Count - CInt(列表值) > 0 And CInt(列表值) <> 0) Then
                                列表 = list(CInt(列表值) - (列表条数 - 1), CInt(列表值)) - (列表条数 - 1)

                                翻页 = 列表
                                xuanz = (列表条数 - 1)
                                If (xuanz < 0 Or xuanz > ops - 1) Then
                                    xuanz = 0
                                End If
                                Console.WriteLine(xmllist.Count - CInt(列表值))
                                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(列表条数 - 1).SetAttribute("selected", "true")
                                列表数 = 列表
                                WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                Invoke_text("intNO_up_text", WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).InnerText)
                            ElseIf (CInt(列表值) = 0) Then
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "true")

                            Else

                                ' 列表 = list(0, 列表数)
                                ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                                ' xuanz = ops - 1
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                                ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "true")
                                ' 列表值 = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).GetAttribute("value")

                            End If

                        End If
                        WebBrowser1.Document.InvokeScript("k_up")
                    Case kl
                        If (key事件_l) Then


                            If (xuana > 0) Then

                                key_rom_xml = False
                                xuana = xuana - 1
                                xiang = 0

                                WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                                Call dh(xuana)
                            Else
                                key_rom_xml = False
                                xuana = linka - 1
                                xiang = 0
                                WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                                Call dh(xuana)

                            End If
                        End If
                        key事件_l = Not (key事件_l)
                    Case kr
                        If (key事件_r) Then


                            If (xuana < linka - 1) Then
                                xuana = xuana + 1
                                xiang = 0
                                key_rom_xml = False
                                WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                                Call dh(xuana)
                            Else
                                key_rom_xml = False
                                xuana = 0
                                xiang = 0
                                WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                                Call dh(xuana)
                            End If
                        End If
                        key事件_r = Not (key事件_r)
                    Case ke
                        '2022年修改
                        ' If (mbdhleix = "1") Then
                        'WebBrowser1.Document.InvokeScript("yinchang")
                        'mbdhleix = 0.ToString
                        ' xiang = 0
                        ' WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                        ' WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                        ' WritePrivateProfileString("Startup file", "Navigation mask", 0.ToString, 当前路径 + "\config.ini")
                        ' Else
                        If (key事件_en) Then


                            Call openrom(xuanz.ToString)
                            ' End If
                            Threading.Thread.Sleep(50)
                        End If
                        key事件_en = Not (key事件_en)
                    Case kz
                        If (key事件_z) Then

                            If (key_rom_xml = False And mbdhleix = 1) Then
                                Timer2.Enabled = False
                                xmlnodes = duxml(fs, "book")
                                cshtml = "html\index1.html"
                                Call indexY(cshtml)
                            Else
                                key_rom_xml = False

                                WebBrowser1.Refresh()

                            End If
                        End If
                        key事件_z = Not (key事件_z)


                    Case kx
                        If (key事件_x) Then


                            翻页 = (CInt(翻页) + (列表条数 - 1)).ToString
                            Console.WriteLine(翻页)
                            If (xmllist.Count - CInt(翻页) > 列表条数) Then

                                列表 = list(CInt(翻页), CInt(翻页) + (列表条数 - 1))
                                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                                xuanz = 0

                            Else
                                列表 = list(CInt(翻页), xmllist.Count - 1)
                                xuanz = 0
                                WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                翻页 = (0 - CInt(列表条数 - 1)).ToString
                                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                            End If
                        End If
                        key事件_x = Not (key事件_x)
                    Case ks
                        If (key事件_s) Then


                            If ((xmllist.Count - 1) - (列表条数 - 1) > 0) Then

                                If (翻页 > "0") Then
                                    列表 = list(CInt(翻页) - (列表条数 - 1), CInt(翻页))
                                    xuanz = 0
                                    翻页 = (CInt(翻页) - (列表条数 - 1)).ToString
                                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                ElseIf (翻页 = "0") Then
                                    列表 = list(xmllist.Count - (xmllist.Count Mod (列表条数 - 1)), xmllist.Count - 1)
                                    xuanz = 0
                                    翻页 = (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))).ToString
                                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                                    翻页 = (0 - CInt(列表条数 - 1)).ToString
                                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                Else
                                    列表 = list((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1), (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))))
                                    xuanz = 0
                                    翻页 = ((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1)).ToString
                                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                                End If
                            End If
                        End If
                        key事件_s = Not (key事件_s)
                    Case Keys.Delete
                        If key事件_del Then

                            Dim xmldellist As Xml.XmlNodeList
                            Dim yesno As Integer

                            yesno = MsgBox("是否要删除", MsgBoxStyle.YesNo)
                            If yesno = 6 Then
                                If (My.Computer.FileSystem.FileExists(xmllist(xiang).ChildNodes(0).InnerText())) Then
                                    My.Computer.FileSystem.DeleteFile(xmllist(xiang).ChildNodes(0).InnerText())
                                End If
                                If (My.Computer.FileSystem.FileExists(xmllist(xiang).ChildNodes(2).InnerText())) Then
                                    My.Computer.FileSystem.DeleteFile(xmllist(xiang).ChildNodes(2).InnerText())
                                End If
                                If (My.Computer.FileSystem.FileExists(xmllist(xiang).ChildNodes(3).InnerText())) Then
                                    My.Computer.FileSystem.DeleteFile(xmllist(xiang).ChildNodes(3).InnerText())
                                End If
                                If (My.Computer.FileSystem.FileExists(xmllist(xiang).ChildNodes(4).InnerText())) Then
                                    My.Computer.FileSystem.DeleteFile(xmllist(xiang).ChildNodes(4).InnerText())
                                End If

                                xmldellist = duxml(romxml, "plp_yx_m")
                                xmldellist(0).RemoveChild(xmldellist(0).ChildNodes(xiang))
                                doc.Save(romxml)
                                linph = 当前路径 + "\html\" + xuana.ToString + ".html"
                                WebBrowser1.Navigate(linph)
                            End If

                        End If
                        key事件_del = Not (key事件_del)
                    Case Keys.Insert
                        If key事件_ins Then


                            Dim str1 As String = ""
                            str1 = InputBox("修改名称")
                            If (str1 <> "") Then
                                xmllist(xiang).ChildNodes(1).InnerText() = str1
                                doc.Save(romxml)
                                linph = 当前路径 + "\html\" + xuana.ToString + ".html"
                                WebBrowser1.Navigate(linph)
                            End If
                        End If
                        key事件_ins = Not (key事件_ins)
                    Case Keys.Escape
                        If key事件_esc Then
                            If (全屏事件) Then
                                全屏事件 = False
                                Me.WindowState = FormWindowState.Normal
                                SetFullScreen(全屏事件, rect)
                                Me.WindowState = FormWindowState.Maximized

                                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                                WritePrivateProfileString("Startup file", "Full screen", 0.ToString, 当前路径 + "\config.ini")
                            Else
                                全屏事件 = True
                                Me.WindowState = FormWindowState.Normal
                                SetFullScreen(全屏事件, rect)
                                Me.WindowState = FormWindowState.Maximized

                                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                                WritePrivateProfileString("Startup file", "Full screen", 1.ToString, 当前路径 + "\config.ini")

                            End If
                        End If
                        key事件_esc = Not (key事件_esc)
                    Case kso
                        Try
                            WebBrowser1.Document.GetElementById("keyboard").Focus()
                            Dim so_x1 As Integer
                            Dim so_x2 As Integer
                            Dim so_y1 As Integer
                            Dim so_y2 As Integer
                            Dim so_x As Integer
                            Dim so_y As Integer
                            so_x1 = WebBrowser1.Document.GetElementById("row").OffsetRectangle.Left
                            so_x2 = WebBrowser1.Document.GetElementById("keyboard").OffsetRectangle.Left
                            so_y1 = WebBrowser1.Document.GetElementById("row").OffsetRectangle.Top
                            so_y2 = WebBrowser1.Document.GetElementById("keyboard").OffsetRectangle.Top
                            so_x = so_x1 + so_x2
                            so_y = so_y1 + so_y2 + 100
                            'MsgBox(WebBrowser1.Document.GetElementById("row").OffsetRectangle.Top.ToString)

                            SetCursorPos(so_x, so_y)
                            key事件_so = True
                        Catch ex As Exception

                        End Try

                    Case Keys.F4

                        'ShellExecute(0, "open", "ruanjian.bat", "", "", 1)
                End Select

                ' MsgBox(e.KeyCode)


            End If
        Catch ex As Exception
            ' MsgBox("出现错误")
        End Try
    End Sub
    Private Sub 选择(ByVal ob As Integer, ByVal weizhi As Integer)
        Dim 列表值 As String

        Select Case ob
            Case 1

                For i As Integer = 0 To ops - 1
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(i).SetAttribute("selected", "")
                Next
                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(weizhi).SetAttribute("selected", "true")
                列表值 = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(weizhi).GetAttribute("value")
                列表值 = (CInt(列表值)).ToString
                Call getvalue(列表值, xuanz)

            Case 2

                For i As Integer = 0 To ops - 1
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(i).SetAttribute("selected", "")
                Next
                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(weizhi).SetAttribute("selected", "true")
                列表值 = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(weizhi).GetAttribute("value")

                列表值 = (CInt(列表值)).ToString
                Call getvalue(列表值, xuanz)


        End Select

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Dim 列表值 As String
        Dim 按键 As String
        If (InStr(cshtml, "index") > 0 Or key事件_so) Then
            按键 = joyjc()
            Select Case 按键
                Case joyd
                    mouse_event(&H1, 0, 20, 0, 0)
                    WebBrowser1.Document.InvokeScript("k_dw")
                Case joyu
                    mouse_event(&H1, 0, -20, 0, 0)
                    WebBrowser1.Document.InvokeScript("k_up")
                Case joyl
                    mouse_event(&H1, -20, 0, 0, 0)
                    WebBrowser1.Document.InvokeScript("k_left")
                Case joyr
                    mouse_event(&H1, 20, 0, 0, 0)
                    WebBrowser1.Document.InvokeScript("k_right")
                Case joye
                    mouse_event(&H2, 0, 0, 0, 0)
                    Threading.Thread.Sleep(50)
                    mouse_event(&H4, 0, 0, 0, 0)
                    Threading.Thread.Sleep(50)
                    WebBrowser1.Document.InvokeScript("k_start")
                Case joyn
                    If (key_rom_xml = False And mbdhleix = 1) Then
                        Timer2.Enabled = False
                        xmlnodes = duxml(fs, "book")
                        cshtml = "html\index1.html"
                        Call indexY(cshtml)
                    Else
                        key事件_so = False

                        WebBrowser1.Refresh()

                    End If
                Case next1
                    WebBrowser1.Document.InvokeScript("k_last")
                Case next2
                    WebBrowser1.Document.InvokeScript("k_next")
            End Select

            key事件 = Not (key事件)
        Else
            Try


                ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
            Catch ex As Exception
                'MsgBox("网页载入慢了")
            End Try
            If (xuanz < 0 Or xuanz > ops - 1) Then
                xuanz = 0
            End If

            列表值 = xiang



            按键 = joyjc()
            If (按键 = joyd) Then


                If (xuanz < ops - 1) Then
                    xuanz = xuanz + 1
                    Call 选择(1, xuanz)
                Else
                    If (xmllist.Count - 列表值 > 列表条数) Then
                        列表 = list(CInt(列表值), CInt(列表值) + (列表条数 - 1))
                        翻页 = CInt(翻页) + (列表条数 - 1)
                        ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                        列表数 = 列表 - (列表条数 - 1)
                        xuanz = 0
                        Call 选择(1, xuanz)
                        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")

                    ElseIf (xmllist.Count - CInt(列表值) - 1 = 0) Then
                        ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")

                    Else

                        列表 = list(CInt(列表值), xmllist.Count - 1)
                        翻页 = (0 - CInt(列表条数 - 1)).ToString
                        ops = (xmllist.Count - 1) - CInt(列表值)
                        ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "")
                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                        列表数 = 列表 - (列表 - CInt(列表值))
                        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                        xuanz = 0
                        Call 选择(1, xuanz)

                    End If


                End If
                WebBrowser1.Document.InvokeScript("k_dw")


            ElseIf (按键 = joyu) Then
                ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                If (xuanz > 0) Then
                    xuanz = xuanz - 1
                    Call 选择(2, xuanz)


                Else



                    If (xmllist.Count - CInt(列表值) > 0 And CInt(列表值) <> 0) Then
                        列表 = list(CInt(列表值) - (列表条数 - 1), CInt(列表值)) - (列表条数 - 1)

                        翻页 = 列表
                        xuanz = (列表条数 - 1)
                        If (xuanz < 0 Or xuanz > ops - 1) Then
                            xuanz = 0
                        End If

                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(列表条数 - 1).SetAttribute("selected", "true")
                        列表数 = 列表
                        WritePrivateProfileString("Startup file", "List number", 列表数.ToString, 当前路径 + "\config.ini")
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                        Invoke_text("intNO_up_text", WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).InnerText)
                    ElseIf (CInt(列表值) = 0) Then
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "true")

                    Else

                        ' 列表 = list(0, 列表数)
                        ' ops = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option").Count
                        ' xuanz = ops - 1
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "")
                        ' WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).SetAttribute("selected", "true")
                        ' 列表值 = WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(ops - 1).GetAttribute("value")

                    End If

                End If
                WebBrowser1.Document.InvokeScript("k_up")

            ElseIf (按键 = joyl) Then
                If (xuana > 0) Then

                    key_rom_xml = False
                    xuana = xuana - 1
                    xiang = 0

                    WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                    Call dh(xuana)
                Else
                    key_rom_xml = False
                    xuana = linka - 1
                    xiang = 0
                    WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                    Call dh(xuana)

                End If
                Threading.Thread.Sleep(50)
            ElseIf (按键 = joyr) Then
                If (xuana < linka - 1) Then
                    xuana = xuana + 1
                    xiang = 0
                    key_rom_xml = False
                    WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                    Call dh(xuana)
                Else
                    key_rom_xml = False
                    xuana = 0
                    xiang = 0
                    WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                    Call dh(xuana)
                End If
            ElseIf (joyjc() = joye) Then
                '修改
                'If (mbdhleix = "1") Then
                'WebBrowser1.Document.InvokeScript("yinchang")
                '  mbdhleix = 0.ToString
                ' xiang = 0
                ' WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")
                'WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
                ' WritePrivateProfileString("Startup file", "Navigation mask", 0.ToString, 当前路径 + "\config.ini")
                'Else
                Call openrom(xuanz.ToString)
                ' End If
            ElseIf (joyjc() = joyn) Then
                If (key_rom_xml = False And mbdhleix = 1) Then
                    Timer2.Enabled = False
                    xmlnodes = duxml(fs, "book")
                    cshtml = "html\index1.html"
                    Call indexY(cshtml)
                Else
                    key_rom_xml = False

                    WebBrowser1.Refresh()



                End If
            ElseIf (joyjc() = next1) Then
                翻页 = (CInt(翻页) + (列表条数 - 1)).ToString

                If (xmllist.Count - CInt(翻页) > 列表条数) Then

                    列表 = list(CInt(翻页), CInt(翻页) + (列表条数 - 1))
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                    xuanz = 0

                Else
                    列表 = list(CInt(翻页), xmllist.Count - 1)
                    xuanz = 0
                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                    翻页 = (0 - CInt(列表条数 - 1)).ToString
                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                End If
                Threading.Thread.Sleep(50)
            ElseIf (joyjc() = next2) Then
                If ((xmllist.Count - 1) - (列表条数 - 1) > 0) Then

                    If (翻页 > "0") Then
                        列表 = list(CInt(翻页) - (列表条数 - 1), CInt(翻页))
                        xuanz = 0
                        翻页 = (CInt(翻页) - (列表条数 - 1)).ToString
                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                        WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                    ElseIf (翻页 = "0") Then
                        列表 = list(xmllist.Count - (xmllist.Count Mod (列表条数 - 1)), xmllist.Count - 1)
                        xuanz = 0
                        翻页 = (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))).ToString
                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                        WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                        翻页 = (0 - CInt(列表条数 - 1)).ToString
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                    Else
                        列表 = list((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1), (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))))
                        xuanz = 0
                        翻页 = ((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1)).ToString
                        WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                        WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                        WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                    End If
                    Threading.Thread.Sleep(50)
                End If
            ElseIf (joyjc() = joyso) Then
                Try
                    WebBrowser1.Document.GetElementById("keyboard").Focus()
                    Dim so_x1 As Integer
                    Dim so_x2 As Integer
                    Dim so_y1 As Integer
                    Dim so_y2 As Integer
                    Dim so_x As Integer
                    Dim so_y As Integer
                    so_x1 = WebBrowser1.Document.GetElementById("row").OffsetRectangle.Left
                    so_x2 = WebBrowser1.Document.GetElementById("keyboard").OffsetRectangle.Left
                    so_y1 = WebBrowser1.Document.GetElementById("row").OffsetRectangle.Top
                    so_y2 = WebBrowser1.Document.GetElementById("keyboard").OffsetRectangle.Top
                    so_x = so_x1 + so_x2
                    so_y = so_y1 + so_y2 + 100
                    'MsgBox(WebBrowser1.Document.GetElementById("row").OffsetRectangle.Top.ToString)

                    SetCursorPos(so_x, so_y)
                    key事件_so = True
                Catch ex As Exception

                End Try


            ElseIf (joyjc() = next2 + joyn Or joyjc() = joyn + next2) Then
                If (全屏事件) Then
                    全屏事件 = False
                    Me.WindowState = FormWindowState.Normal
                    SetFullScreen(全屏事件, rect)
                    Me.WindowState = FormWindowState.Maximized

                    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                    WritePrivateProfileString("Startup file", "Full screen", 0.ToString, 当前路径 + "\config.ini")
                Else
                    全屏事件 = True
                    Me.WindowState = FormWindowState.Normal
                    SetFullScreen(全屏事件, rect)
                    Me.WindowState = FormWindowState.Maximized

                    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    WritePrivateProfileString("Startup file", "Full screen", 1.ToString, 当前路径 + "\config.ini")

                End If

            End If
        End If

    End Sub
    Function list(ByVal NO1 As Integer, ByVal NO2 As Integer)
        Dim lins As String = ""
        Try
            WebBrowser1.Document.InvokeScript("ul_li_c")

            For i = NO1 To NO2 '获取列表中的所有文件名称
                'cccc(liNOl) = xmllist(i).ChildNodes(1).InnerText
                lins += "<option value=" + Chr(34) + i.ToString + Chr(34) + ">" + Format((i + 1), "000") + ".&nbsp;&nbsp;" + xmllist(i).ChildNodes(1).InnerText + "</option>" + Chr(13)
                WebBrowser1.Document.GetElementById("ziti").InnerHtml = lins '将XML的游戏名称添加到列表框
                InvokeTestMethod("ul_li", Format((i + 1), "000") + ".&nbsp;&nbsp;" + xmllist(i).ChildNodes(1).InnerText, xmllist.Count, (NO2 - NO1))
            Next
        Catch ex As Exception

        End Try
        Return NO2
    End Function
    Private Sub InvokeTestMethod(ByVal js_hanshu As String, ByVal Name As String, ByVal Address As Single, ByVal li_NO As Single)
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim ObjArr(3) As Object
            ObjArr(0) = Name
            ObjArr(1) = Address
            ObjArr(2) = li_NO
            WebBrowser1.Document.InvokeScript(js_hanshu, ObjArr)
        End If
    End Sub
    Private Sub Invoke_chushi(ByVal js_hanshu As String, ByVal li_NO As Single)
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim ObjArr(1) As Object
            ObjArr(0) = li_NO
            WebBrowser1.Document.InvokeScript(js_hanshu, ObjArr)
        End If
    End Sub
    Private Sub Invoke_color(ByVal js_hanshu As String, ByVal ziti_color As String, ByVal a_color As String _
, ByVal a_bgcolor As String, ByVal az_color As String, ByVal az_bgcolor As String, ByVal intro_color As String _
, ByVal intro_bgcolor As String)
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim ObjArr(6) As Object
            ObjArr(0) = ziti_color
            ObjArr(1) = a_color
            ObjArr(2) = a_bgcolor
            ObjArr(3) = az_color
            ObjArr(4) = az_bgcolor
            ObjArr(5) = intro_color
            ObjArr(6) = intro_bgcolor
            WebBrowser1.Document.InvokeScript(js_hanshu, ObjArr)
        End If
    End Sub
    Private Sub Invoke_text(ByVal js_hanshu As String, ByVal li_NO As String)
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim ObjArr(1) As Object
            ObjArr(0) = li_NO
            WebBrowser1.Document.InvokeScript(js_hanshu, ObjArr)
        End If
    End Sub
    Public Sub weizhi()

        Invoke_chushi("index_html", CInt(页面数))
    End Sub
    Public Sub fanye_audio(ByVal audio_path As String)

        Dim nologin As String = Path.GetFullPath(audio_path)

        PlaySound(nologin, 0, SND_ASYNC)
    End Sub
    Public Sub htmlDoc_ContextMenuShowing()

        If (key_rom_xml = False And mbdhleix = 1) Then
            Timer2.Enabled = False
            xmlnodes = duxml(fs, "book")
            cshtml = "html\index1.html"
            Call indexY(cshtml)
        Else
            key_rom_xml = False

            WebBrowser1.Refresh()

        End If
    End Sub
    Public Sub htmdoc_wheel_up()
        If (鼠标事件_s) Then


            翻页 = (CInt(翻页) + (列表条数 - 1)).ToString

            If (xmllist.Count - CInt(翻页) > 列表条数) Then

                列表 = list(CInt(翻页), CInt(翻页) + (列表条数 - 1))
                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                xuanz = 0

            Else
                列表 = list(CInt(翻页), xmllist.Count - 1)
                xuanz = 0
                WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                翻页 = (0 - CInt(列表条数 - 1)).ToString
                WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
            End If
        End If
        鼠标事件_s = Not (鼠标事件_s)
    End Sub
    Public Sub search(ByVal sou_txt As String)

        Dim abcd As String = ""
        abcd = sou_txt
        Dim SXML As XElement = XElement.Load(romxml)
        Dim root = From item In SXML.Elements("book")
           Where getpy(item.Element("name").Value.ToString) Like "*" + abcd + "*"
           Select New XElement(item)
        Dim newTree As XElement = New XElement("plp_yx_m", root)

        newTree.Save(当前路径 + "\rom\game_list\search.xml")
        key事件_so = False
        If root.Count > 0 Then
            romxml = 当前路径 + "\rom\game_list\search.xml"
            WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
            key_rom_xml = True


            WebBrowser1.Refresh()




        Else
            key_rom_xml = False

            WebBrowser1.Refresh()


        End If


    End Sub
    Public Sub htmdoc_wheel_dw()
        If (鼠标事件_x) Then


            If ((xmllist.Count - 1) - (列表条数 - 1) > 0) Then

                If (翻页 > "0") Then
                    列表 = list(CInt(翻页) - (列表条数 - 1), CInt(翻页))
                    xuanz = 0
                    翻页 = (CInt(翻页) - (列表条数 - 1)).ToString
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                ElseIf (翻页 = "0") Then
                    列表 = list(xmllist.Count - (xmllist.Count Mod (列表条数 - 1)), xmllist.Count - 1)
                    xuanz = 0
                    翻页 = (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))).ToString
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                    翻页 = (0 - CInt(列表条数 - 1)).ToString
                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                Else
                    列表 = list((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1), (xmllist.Count - (xmllist.Count Mod (列表条数 - 1))))
                    xuanz = 0
                    翻页 = ((xmllist.Count - (xmllist.Count Mod (列表条数 - 1))) - (列表条数 - 1)).ToString
                    WebBrowser1.Document.GetElementById("ziti").Document.GetElementsByTagName("option")(0).SetAttribute("selected", "true")
                    WritePrivateProfileString("Startup file", "List number", 翻页, 当前路径 + "\config.ini")
                    WritePrivateProfileString("Startup file", "Turn pages", 翻页, 当前路径 + "\config.ini")
                End If
            End If
        End If
        鼠标事件_x = Not (鼠标事件_x)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If (s_tf) Then
            WebBrowser1.Document.All("video-player").SetAttribute("src", "")

            If (s_list_url.Length - 1 > pic_list_index) Then

                If Path.GetDirectoryName(s_list_url(pic_list_index)) = "http:" Or
                Path.GetDirectoryName(s_list_url(pic_list_index)).Substring(0, 4) = "http" Or
                Path.GetDirectoryName(s_list_url(pic_list_index)).Substring(0, 5) = "https" Or
                Path.GetDirectoryName(s_list_url(pic_list_index)).Substring(0, 3) = "ftp" Then

                    WebBrowser1.Document.All("video-player").SetAttribute("poster", s_list_url(pic_list_index)) '显示图片
                Else
                    WebBrowser1.Document.All("video-player").SetAttribute("poster", Path.GetFullPath(s_list_url(pic_list_index))) '显示图片
                    WebBrowser1.Document.All("video-player").SetAttribute("src", "")
                End If
                pic_list_index = pic_list_index + 1
            Else
                pic_list_index = 0
            End If
        End If

        If (k_tf) Then
            If (k_list_url.Length - 1 > pick_list_index) Then
                If Path.GetDirectoryName(k_list_url(pick_list_index)) = "http:" Or
                    Path.GetDirectoryName(k_list_url(pick_list_index)).Substring(0, 4) = "http" Or
                    Path.GetDirectoryName(k_list_url(pick_list_index)).Substring(0, 5) = "https" Or
                    Path.GetDirectoryName(k_list_url(pick_list_index)).Substring(0, 3) = "ftp" Then
                    WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", k_list_url(pick_list_index))
                Else
                    WebBrowser1.Document.GetElementById("fmt").SetAttribute("src", Path.GetFullPath(k_list_url(pick_list_index)))
                End If
                pick_list_index = pick_list_index + 1
            Else
                pick_list_index = 0
            End If
        End If
        Try
            If CSng(pic_time) > 0 Then
                Timer2.Interval = 1000 * CSng(pic_time)
            Else
                Timer2.Interval = 1000
            End If
        Catch ex As Exception
            Timer2.Interval = 1000
        End Try


    End Sub

End Class