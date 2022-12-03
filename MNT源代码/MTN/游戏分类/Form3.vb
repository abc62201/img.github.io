Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports SharpDX
Imports SharpDX.DirectInput
Imports System.Text

Public Class Form3
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

    Dim dmsz As String
    Dim pic_time As String
    Dim xmlnodes As Xml.XmlNodeList
    Dim n As Integer
    Dim fs As String
    Dim 当前路径 As String
    Dim liebiao As String
    Dim d_xml_c As Integer
    Dim xg As Integer
    Dim linph As String
    Dim linpcss As String
    Dim csszitia As String
    Dim csszitia1 As String
    Dim csszitil As String
    Dim fonttxt As String
    Dim fonttxth As String
    Dim joyshu As Integer = 0
    Dim key事件 As Boolean = False
    Dim 删除事件 As Boolean = False
    Dim d_del_index1 As Integer = 0
    Dim d_del_index2 As Integer = 0
    Dim ku As String
    Dim kd As String
    Dim kl As String
    Dim kr As String
    Dim ke As String
    Dim kz As String
    Dim kx As String
    Dim ks As String
    Dim kso As String
    Dim kra As String
    Dim joyu As String
    Dim joyd As String
    Dim joyl As String
    Dim joyr As String
    Dim joye As String
    Dim joyn As String
    Dim joyso As String
    Dim joyra As String
    Dim next1 As String
    Dim next2 As String
    Dim emu_updat As String
    Dim shell_download As Integer = 0
    Dim fileinipath As String
    Dim dic_ini_txt As New Dictionary(Of String, String)
    Dim ini语言序号 As Integer = 0
    Dim pics_path_1 As String = ""
    Dim s_vp_index As Integer = 0
    Dim s_pic_index As Integer = 0
    Dim joytype As Integer = 0






    Private Sub Form3_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If shell_download = 0 Then
            ShellExecute(0, "open", 当前路径 + "\MTN.exe", "", "", 1)
        End If
        End
    End Sub

    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim ary_index As Integer = -1
        If (e.KeyCode = Keys.Delete And DataGridView1.SelectedRows.Count > 0) Then
            d_del_index1 = DataGridView1.SelectedRows.Item(0).Index - (DataGridView1.SelectedRows.Count - 1)
            d_del_index2 = (DataGridView1.Rows.Count - 2 - DataGridView1.SelectedRows.Item(0).Index)
            If My.Computer.FileSystem.DirectoryExists(当前路径 + "\temp\html") Then
                FileIO.FileSystem.DeleteDirectory(当前路径 + "\temp\html", 5)
            End If
            建立文件夹(当前路径 + "\temp\html")
            ProgressBar2.Maximum = (d_del_index1 + d_del_index2 - 1)
            ProgressBar2.Minimum = d_del_index1
            ProgressBar2.Value = d_del_index1
            For i = d_del_index1 To (d_del_index1 + d_del_index2 - 1)
                If My.Computer.FileSystem.FileExists(当前路径 + "\html\" + (i + 1).ToString + ".html") Then
                    拷贝文件(当前路径 + "\html\" + (i + 1).ToString + ".html", 当前路径 + "\Temp\html\" + i.ToString + ".html")
                    拷贝文件(当前路径 + "\html\" + (i + 1).ToString + ".css", 当前路径 + "\Temp\html\" + i.ToString + ".css")
                    Dim txt3 As String = ""
                    Dim htmltxt() As String = File.ReadAllLines(当前路径 + "\Temp\html\" + i.ToString + ".html")
                    If (Array.FindIndex(htmltxt, Function(s) s.Contains((i + 1).ToString + ".css")) >= 0) Then
                        ary_index = Array.FindIndex(htmltxt, Function(s) s.Contains((i + 1).ToString + ".css"))
                        txt3 += "<link rel=" + Chr(34)
                        txt3 += " stylesheet" + Chr(34)
                        txt3 += " type=" + Chr(34)
                        txt3 += "text/css" + Chr(34)
                        txt3 += " href=" + Chr(34)
                        txt3 += i.ToString + ".css" + Chr(34)
                        txt3 += " >"
                        htmltxt(ary_index) = txt3
                        File.WriteAllLines(当前路径 + "\Temp\html\" + i.ToString + ".html", htmltxt)
                    End If
                    ProgressBar2.Value = i
                End If
            Next
            MsgBox("删除后及时保存连续删除2次或跳跃选择删除皮肤会出错")
        End If
        If (key事件 And e.KeyCode <> Keys.Delete) Then

            Select Case joyshu
                Case 1
                    Label55.Text = e.KeyCode
                    Label55.BackColor = Color.Gainsboro
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 2
                    Label58.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 3
                    Label56.Text = e.KeyCode
                    Label55.BackColor = Color.Gainsboro
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True

                Case 4
                    Label57.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 5
                    Label59.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 6
                    Label85.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 7
                    Label86.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 8
                    Label87.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 9
                    Label94.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 10
                    Label95.Text = e.KeyCode
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
            End Select
        Else
            Label56.BackColor = Color.Gainsboro
            Label57.BackColor = Color.Gainsboro
            Label58.BackColor = Color.Gainsboro
            Label59.BackColor = Color.Gainsboro
            Label55.BackColor = Color.Gainsboro
            Label85.BackColor = Color.Gainsboro
            Label86.BackColor = Color.Gainsboro
            Label87.BackColor = Color.Gainsboro
            Label94.BackColor = Color.Gainsboro
            Label95.BackColor = Color.Gainsboro
        End If
        key事件 = False

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet
        Dim webye As String

        Dim 启动 As String
        Dim 窗口top As String
        Dim LocaleID As Long
        Me.Focus()
        当前路径 = Application.StartupPath() '初始路径
        LocaleID = GetSystemDefaultLCID

        '  Select Case LocaleID
        ' Case &H404
        '  WriteOneString("Startup file", "msg", "1", 当前路径 + "\config.ini")
        ' ini语言序号 = 101
        '    Case &H804
        ' WriteOneString("Startup file", "msg", "0", 当前路径 + "\config.ini")
        ' ini语言序号 = 100
        '   Case &H409
        ' WriteOneString("Startup file", "msg", "2", 当前路径 + "\config.ini")
        ' ini语言序号 = 102
        '    Case Else
        '  WriteOneString("Startup file", "msg", "3", 当前路径 + "\config.ini")
        '  ini语言序号 = 103
        '  End Select



        Select Case ReadOneString("Startup file", "msg", 当前路径 + "\config.ini")

            Case "0"
                fileinipath = Application.StartupPath() + "\msg\zh_hans.txt"
            Case "1"
                fileinipath = Application.StartupPath() + "\msg\zh_hant.txt"

            Case Else
                fileinipath = Application.StartupPath() + "\msg\en.txt"
        End Select


        Dim ini_txt As TextReader = File.OpenText(fileinipath)
        If My.Computer.FileSystem.FileExists(当前路径 + "\bak_phat.txt") Then

        Else

            Dim bak_txt2 As String = ""
            bak_txt2 += "[bak0]" + Chr(13)
            bak_txt2 += "rom=请选择rom文件夹" + Chr(13)
            bak_txt2 += "thumb=请选择图片文件夹" + Chr(13)
            bak_txt2 += "video=请选择视频文件夹" + Chr(13)
            bak_txt2 += "cassette=请选择卡带文件夹" + Chr(13)
            bak_txt2 += "intro=请选择信息文件夹" + Chr(13)
            Dim bak_phat_txt As StreamWriter = File.CreateText(当前路径 + "\bak_phat.txt")
            bak_phat_txt.Write(bak_txt2, System.Text.Encoding.UTF8)
            bak_phat_txt.Close()
        End If
        Dim ini_txt1 As String
        Dim ini_txt2 As String = ""
        While ini_txt.Peek() > -1
            ini_txt1 = ini_txt.ReadLine
            If (ini_txt1 <> "") Then
                If (ini_txt1.Split("=").Length > 1) Then
                    If Not dic_ini_txt.ContainsKey(ini_txt2 + "_" + ini_txt1.Split("=")(0)) Then
                        dic_ini_txt.Add(ini_txt2 + "_" + ini_txt1.Split("=")(0), ini_txt1.Split("=")(1))
                    End If

                Else
                    ini_txt2 = ini_txt1.Replace("[", "").Replace("]", "")
                End If
            End If
        End While
        ini_txt.Close()


        Me.Label92.Text = ""
        Me.Timer1.Enabled = False

        fs = 当前路径 + "\daohang.xml"

        If My.Computer.FileSystem.FileExists(当前路径 + "\abc.txt") Then
            ShellExecute(0, "open", 当前路径 + "\abc.exe", "", "", 1)
            End
        End If

        xmlnodes = duxml(fs, "book")
        d_xml_c = xmlnodes.Count - 1
        xg = 10000
        linph = 当前路径 + "\ceshi.html"
        linpcss = 当前路径 + "\daohang.css"
        n = 0
        liebiao = ""
        csszitia = ""
        csszitil = ""
        fonttxt = ""
        Label60.Text = "程序：QQ昵称-离我远点" + Chr(13) + "美工,测试,皮肤制作：QQ昵称-wood.exe" + Chr(13) + "测试,皮肤制作：高在华" + Chr(13) + "繁体翻译:倫哥"
        ' Label60.Text += "作者：高在华" + Chr(13)
        dt.Columns.Add(New DataColumn("序号"))
        dt.Columns.Add(New DataColumn("模拟器名称"))
        dt.Columns.Add(New DataColumn("模拟器位置"))
        dt.Columns.Add(New DataColumn("游戏列表位置"))

        dr = dt.NewRow()
        dr("序号") = "aaa"

        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("序号") = "aaa"
        dt.Rows.Add(dr)
        ds.ReadXml(fs)
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "book"



        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            Select Case DataGridView1.Columns(i).HeaderText
                Case "name"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_0", dic_ini_txt)
                Case "lujing"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_1", dic_ini_txt)
                Case "txt"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_2", dic_ini_txt)

                Case "xmlfile"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_3", dic_ini_txt)
                Case "bj"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_4", dic_ini_txt)
                Case "dshj"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_5", dic_ini_txt)
                Case "jiz"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_6", dic_ini_txt)
                Case "yemei"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_7", dic_ini_txt)
                Case "renwu"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_8", dic_ini_txt)
                Case "dll"
                    DataGridView1.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView1_9", dic_ini_txt)
            End Select
        Next


        Me.TabControl1.Width = Me.Width - 20
        Me.TabControl1.Height = Me.Height - 20
        DataGridView1.Width = Me.Width - 50
        Me.DataGridView1.Height = Me.Height - 175
        DataGridView2.Width = Me.Width - 50
        Me.DataGridView2.Height = Me.Height - 175
        DataGridView3.Width = Me.Width - 50
        Me.DataGridView3.Height = Me.Height - 300
        Me.PictureBox2.Width = Me.TabControl1.Width - 500
        Me.PictureBox2.Height = Me.TabControl1.Height - Label60.Height - 150



        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox6.Text = ""
        Me.Button18.Enabled = False

        Me.ComboBox5.Items.Add(ini_txt_valeu("form3", "ComboBox5_1", dic_ini_txt))

        Me.ComboBox5.Items.Add(ini_txt_valeu("form3", "ComboBox5_2", dic_ini_txt))
        Me.ComboBox7.Items.Add("中文简体")
        Me.ComboBox7.Items.Add("中文繁体")
        Me.ComboBox7.Items.Add("英文")
        Me.ComboBox8.Items.Add("视觉头盔")
        Me.ComboBox8.Items.Add("十字轴")
        Me.ComboBox8.Items.Add("DX_DirectInput")
        For Each nobe In xmlnodes
            If (nobe("xmlfile").InnerText = "kong") Then
                Me.ComboBox1.Items.Add(nobe("txt").InnerText + "-无游戏")
                Me.ComboBox2.Items.Add(nobe("txt").InnerText + "-无游戏")
            Else
                Me.ComboBox1.Items.Add(nobe("txt").InnerText)
                Me.ComboBox2.Items.Add(nobe("txt").InnerText)
                Form8.ComboBox1.Items.Add(nobe("txt").InnerText)
            End If
            n = n + 1
        Next

        GetAllFile(当前路径 + "\font")

        Dim 字体文件1 As New StreamWriter(当前路径 + "\font.css")

        字体文件1.WriteLine(fonttxt)
        字体文件1.Close()
        Dim 字体文件2 As New StreamWriter(当前路径 + "\html\font.css")

        字体文件2.WriteLine(fonttxth)
        字体文件2.Close()
        WebBrowser1.Navigate(当前路径 + "\ceshi.html")
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
        dmsz = New String(CChar(" "), 128)
        pic_time = New String(CChar(" "), 128)
        启动 = New String(CChar(" "), 128)
        窗口top = New String(CChar(" "), 128)
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
        webye = New String(CChar(" "), 128)


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
        GetPrivateProfileString("Startup file", "Navigation mask", "Navigation mask", dmsz, 128, 当前路径 + "\config.ini")
        Try
            GetPrivateProfileString("Startup file", "pic_interval", "pic_interval", pic_time, 128, 当前路径 + "\config.ini")
        Catch ex As Exception
            pic_time = "1"
        End Try
        GetPrivateProfileString("Startup file", "Self starting", "Self starting", 启动, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "Front of window", "Front of window", 窗口top, 128, 当前路径 + "\config.ini")
        GetPrivateProfileString("Startup file", "page", "page", webye, 128, 当前路径 + "\config.ini")



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

        joyu = 首尾删除空格(joyu)
        joyd = 首尾删除空格(joyd)
        joyl = 首尾删除空格(joyl)
        joyr = 首尾删除空格(joyr)
        joye = 首尾删除空格(joye)
        joyn = 首尾删除空格(joyn)
        next2 = 首尾删除空格(next2)
        next1 = 首尾删除空格(next1)
        joyso = 首尾删除空格(joyso)
        joyra = 首尾删除空格(joyra)
        dmsz = 首尾删除空格(dmsz)
        pic_time = 首尾删除空格(pic_time)
        启动 = 首尾删除空格(启动)
        窗口top = 首尾删除空格(窗口top)
        webye = 首尾删除空格(webye)
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


        If (启动 = "1") Then
            Me.CheckBox2.Checked = True
        Else
            Me.CheckBox2.Checked = False
        End If
        If (窗口top = "1") Then
            Me.CheckBox3.Checked = True
        Else
            Me.CheckBox3.Checked = False
        End If
        If (dmsz = "1") Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        If (pic_time = "pic_interval") Then
            pic_time = "1"
        End If
        TextBox63.Text = pic_time
        Label55.Text = "up"
        Label58.Text = "down"
        Label56.Text = "left"
        Label57.Text = "right"
        Label59.Text = "start"
        Label85.Text = "Back"
        Label86.Text = "last page"
        Label87.Text = "next page"
        Label94.Text = "search"
        Label95.Text = "Raiders"
        ' duxmllist("C:\Users\Administrator\Desktop\vb.net\游戏分类\游戏分类\bin\Debug\rom\fc\fclist.xml", "/book")
        Me.PictureBox1.ImageLocation = 当前路径 + "\theme\logo2.png"
        Me.PictureBox2.ImageLocation = 当前路径 + "\theme\about.jpg"
        If (webye = "ceshi.html" Or InStr(webye, "index") > 0) Then
            webye = "ceshi.html"
        Else

            ComboBox2.SelectedIndex = CInt(webye.Replace("html\", "").Replace(".html", ""))
        End If
        Me.Label90.Text = ini_txt_valeu("form3", "Label90_0", dic_ini_txt) + Chr(13)
        Me.Label90.Text += ini_txt_valeu("form3", "Label90_1", dic_ini_txt)



        Call cn_ssimp(fileinipath, 2)

        ' MsgBox(ini_txt_valeu("form3", "Button5", dic_ini_txt))

        Call tab3int(webye.Replace("html\", "").Replace(".html", ""))
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = True
        Me.Focus()
        删除事件 = True
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Dim s As String
        Dim hang As Integer
        Dim lie As Integer
        Dim x_path_rom(6) As String
        ' Dim bak_txt() As String = File.ReadAllLines("bak_phat.txt")
        'Dim bak_txt1 As String
        Dim bak_txt2 As String = ""
        Dim ds As New DataSet
        Dim ds_list As Integer = DataGridView1.Rows.Count - 2
        Dim htmlpath_name As String = ""
        Dim csspath_name As String = ""
        Dim ary_index As Integer = -1
        ' s = DataGridView1.CurrentRow.Cells(0).Value
        '鼠标选中的行。
        ' s = DataGridView1.Rows(0).Cells(0).Value

        '第1行第1列的数据
        's = DataGridView1.SelectedCells.Item(0).Value
        '用户选中单元格的值
        's = DataGridView1.SelectedCells.Item(0).RowIndex
        '用户选中单元格的行数
        's = DataGridView1.SelectedCells.Item(0).ColumnIndex
        '用户选中单元格的列数
        'n = DataGridView1.Rows.Count
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        hang = DataGridView1.Rows.Count
        lie = DataGridView1.Rows(0).Cells.Count
        ProgressBar2.Maximum = hang - 2
        ProgressBar2.Minimum = 0
        ProgressBar2.Value = 0
        For i As Integer = 0 To hang - 2
            For j As Integer = 0 To lie - 1
                If (DataGridView1.Rows(i).Cells(j).Value.ToString().Trim() = String.Empty) Then
                    DataGridView1.Rows(i).Cells(j).Value = "kong"
                End If
            Next
            '添加缺失的网页
            htmlpath_name = 当前路径 + "\html\" + i.ToString + ".html"
            csspath_name = 当前路径 + "\html\" + i.ToString + ".css"
            If My.Computer.FileSystem.FileExists(htmlpath_name) Then
            Else
                Dim txt3 As String = ""
                FileCopy(当前路径 + "\ceshi.html", htmlpath_name)
                Dim htmltxt() As String = File.ReadAllLines(htmlpath_name)
                If (Array.FindIndex(htmltxt, Function(s) s.Contains("daohang.css")) >= 0) Then
                    ary_index = Array.FindIndex(htmltxt, Function(s) s.Contains("daohang.css"))
                    txt3 += "<link rel=" + Chr(34)
                    txt3 += " stylesheet" + Chr(34)
                    txt3 += " type=" + Chr(34)
                    txt3 += "text/css" + Chr(34)
                    txt3 += " href=" + Chr(34)
                    txt3 += i.ToString + ".css" + Chr(34)
                    txt3 += " >"
                    htmltxt(ary_index) = txt3
                    File.WriteAllLines(htmlpath_name, htmltxt)
                End If

                If My.Computer.FileSystem.FileExists(csspath_name) Then
                Else
                    FileCopy(当前路径 + "\daohang.css", csspath_name)
                End If

                End If
                x_path_rom(0) = "[bak" + i.ToString + "]"
                x_path_rom(1) = "rom/" + DataGridView1.Rows(i).Cells(2).Value + "/rom"
                x_path_rom(2) = "rom/" + DataGridView1.Rows(i).Cells(2).Value + "/thumb"
                x_path_rom(3) = "rom/" + DataGridView1.Rows(i).Cells(2).Value + "/video"
                x_path_rom(4) = "rom/" + DataGridView1.Rows(i).Cells(2).Value + "/cassette"
                x_path_rom(5) = "rom/" + DataGridView1.Rows(i).Cells(2).Value + "/intro"
                x_path_rom(6) = "rom/" + DataGridView1.Rows(i).Cells(2).Value
                If Not Directory.Exists(x_path_rom(6)) Then
                    Directory.CreateDirectory(x_path_rom(1))
                    Directory.CreateDirectory(x_path_rom(2))
                    Directory.CreateDirectory(x_path_rom(3))
                    Directory.CreateDirectory(x_path_rom(4))
                    Directory.CreateDirectory(x_path_rom(5))
                    If (Not My.Computer.FileSystem.FileExists("rom/game_list/" + DataGridView1.Rows(i).Cells(2).Value + ".xml")) Then
                        拷贝文件("rom/game_list/meun_gamelist.xml", "rom/game_list/" + DataGridView1.Rows(i).Cells(2).Value + ".xml")
                    End If
                    If (DataGridView1.Rows(i).Cells(3).Value = "kong") Then
                        DataGridView1.Rows(i).Cells(3).Value = "rom/game_list/" + DataGridView1.Rows(i).Cells(2).Value + ".xml"
                    End If
                End If
                bak_txt2 += x_path_rom(0) + Chr(13)
                bak_txt2 += "rom=" + x_path_rom(1) + Chr(13)
                bak_txt2 += "thumb=" + x_path_rom(2) + Chr(13)
                bak_txt2 += "video=" + x_path_rom(3) + Chr(13)
                bak_txt2 += "cassette=" + x_path_rom(4) + Chr(13)
            bak_txt2 += "intro=" + x_path_rom(5) + Chr(13)

            '替换删除后变化的网页
            If My.Computer.FileSystem.FileExists(当前路径 + "\Temp\html\" + i.ToString + ".html") Then
                拷贝文件(当前路径 + "\Temp\html\" + i.ToString + ".html", htmlpath_name)
            End If
            If My.Computer.FileSystem.FileExists(当前路径 + "\Temp\html\" + i.ToString + ".css") Then
                拷贝文件(当前路径 + "\Temp\html\" + i.ToString + ".css", csspath_name)
            End If
            ComboBox1.Items.Add(DataGridView1.Rows(i).Cells(2).Value)
            ComboBox2.Items.Add(DataGridView1.Rows(i).Cells(2).Value)
            ProgressBar2.Value = i
        Next
        If My.Computer.FileSystem.DirectoryExists(当前路径 + "\temp\html") Then
            FileIO.FileSystem.DeleteDirectory(当前路径 + "\temp\html", 5)
        End If
        File.WriteAllText("bak_phat.txt", bak_txt2, System.Text.Encoding.UTF8)
        ds = DataGridView1.DataSource

        ds.WriteXml(fs)
        WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
        WritePrivateProfileString("Startup file", "list", 0.ToString, 当前路径 + "\config.ini")
        GetPrivateProfileString("0", "intro_background", "intro_background", web_intro_bgcolor, 128, 当前路径 + "\config.ini")

        While hang - 2 - d_xml_c > 0
            d_xml_c = d_xml_c + 1
            WritePrivateProfileString(d_xml_c.ToString, "list", 0.ToString, 当前路径 + "\config.ini")
        End While

        '向html\index_js\index1.xml添加内容
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim xml_json As Xml.XmlNodeList
        Dim row_list As Integer
        dt.TableName = "book"
        row_list = xmlnodes.Count - 1
        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("导航图片"))
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dr("导航图片") = "kong"
            dt.Rows.Add(dr)
        Next
        DataGridView3.DataSource = dt
        xml_json = duxml(当前路径 + "\html\index_js\index1.xml", "book")
        If (row_list > xml_json.Count - 1) Then
            For i As Integer = 0 To xml_json.Count - 1
                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
            Next
        Else
            For i As Integer = 0 To row_list
                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
            Next
        End If
 
        dt = DataGridView3.DataSource
        dt.WriteXml(当前路径 + "\html\index_js\index1.xml")
        xmlnodes = duxml(fs, "book")
        dt.Clear()
        dt.Columns.Remove("名称")
        dt.Columns.Remove("链接页地址")
        dt.Columns.Remove("导航图片")
        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("导航图片"))
        dt.Columns.Add(New DataColumn("背景图片"))
        row_list = xmlnodes.Count - 1
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dr("导航图片") = "kong"
            dr("背景图片") = "kong"
            dt.Rows.Add(dr)
        Next
        DataGridView3.DataSource = dt
        xml_json = duxml(当前路径 + "\html\index_js\index2.xml", "book")
        If (row_list > xml_json.Count - 1) Then
            For i As Integer = 0 To xml_json.Count - 1
                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
                DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
            Next
        Else
            For i As Integer = 0 To row_list
                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
                DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
            Next
        End If

        dt = DataGridView3.DataSource
        dt.WriteXml(当前路径 + "\html\index_js\index2.xml")
        xmlnodes = duxml(fs, "book")
        dt.Clear()
        dt.Columns.Remove("名称")
        dt.Columns.Remove("链接页地址")
        dt.Columns.Remove("导航图片")
        dt.Columns.Remove("背景图片")
        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("左边图片"))
        dt.Columns.Add(New DataColumn("右边图片"))
        dt.Columns.Add(New DataColumn("背景图片"))

        row_list = xmlnodes.Count - 1
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dr("左边图片") = "kong"
            dr("右边图片") = "kong"
            dr("背景图片") = "kong"
            dt.Rows.Add(dr)
        Next
        DataGridView3.DataSource = dt
        xml_json = duxml(当前路径 + "\html\index_js\index3.xml", "book")
        If (row_list > xml_json.Count - 1) Then
            For i As Integer = 0 To xml_json.Count - 1

                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
                DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
                DataGridView3.Rows(i).Cells(4).Value = xml_json(i).ChildNodes(4).InnerText
            Next
        Else
            For i As Integer = 0 To row_list

                DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
                DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
                DataGridView3.Rows(i).Cells(4).Value = xml_json(i).ChildNodes(4).InnerText
            Next
        End If

        dt = DataGridView3.DataSource
        dt.WriteXml(当前路径 + "\html\index_js\index3.xml")
        xmlnodes = duxml(fs, "book")
        dt.Clear()
    End Sub



    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim s As String
        Dim lie As String


        n = DataGridView1.SelectedCells.Item(0).ColumnIndex
        s = DataGridView1.Columns(n).Name
        Select Case s
            Case "lujing"
                OpenFileDialog1.Filter = "选择模拟器或启动文件|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")

                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "xmlfile"
                OpenFileDialog1.Filter = "选择列表文件|*.xml"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "bj"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "dshj"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "jiz"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "yemei"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "renwu"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
            Case "dll"
                OpenFileDialog1.Filter = "选择核心|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView1.SelectedCells.Item(0).Value = lie
                End If
        End Select


        ' MsgBox(s)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim menu_index As Integer = 0
        Dim data2_rows_txt As String = ""
        Dim menu_name As String = ""
        Dim ds As New DataSet
        Dim fbn_menu As String
        DataGridView2.RowTemplate.Height = 40
        xg = ComboBox1.SelectedIndex
        xmlnodes = duxml(fs, "book")
        fbn_menu = xmlnodes(xg).ChildNodes(1).InnerText
        If My.Computer.FileSystem.FileExists(fbn_menu) Then
            fbn_menu = Path.GetFileNameWithoutExtension(fbn_menu)
        End If

        liebiao = xmlnodes(xg).ChildNodes(3).InnerText
        emu_updat = xmlnodes(xg).ChildNodes(1).InnerText
        If My.Computer.FileSystem.FileExists(liebiao) Then

            If fbn_menu = "fbneo" Or fbn_menu = "fbneo64" Then
                Me.添加FBN模拟器中的IPS游戏ToolStripMenuItem.Enabled = True
            Else
                Me.添加FBN模拟器中的IPS游戏ToolStripMenuItem.Enabled = False
            End If
            ds.ReadXml(liebiao)

            DataGridView2.DataSource = ds

            DataGridView2.DataMember = "book"

            For i As Integer = 0 To DataGridView2.Columns.Count - 1
                Select Case DataGridView2.Columns(i).HeaderText
                    Case "rom"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_0", dic_ini_txt)
                    Case "name"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_1", dic_ini_txt)
                    Case "void"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_2", dic_ini_txt)
                    Case "mig"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_3", dic_ini_txt)
                    Case "kadai"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_4", dic_ini_txt)
                    Case "emu"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_5", dic_ini_txt)
                    Case "intro"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_6", dic_ini_txt)
                End Select
            Next
            Me.Button18.Enabled = True
            Me.MenuStrip1.Items.Clear()
            Me.MenuStrip1.Items.Add("选择下一级").Name = "next"
            Dim menu_dr As New ToolStripMenuItem
            menu_dr = Me.MenuStrip1.Items("next")
            For i = 0 To DataGridView2.RowCount - 2
                data2_rows_txt = DataGridView2.Rows(i).Cells(0).Value
                ' DataGridView2.Rows(i).Height = 50

                If (System.IO.Path.GetExtension(data2_rows_txt) = ".xml") Then
                    menu_name = "menu" + menu_index.ToString
                    'Me.MenuStrip1.Items.Add(DataGridView2.Rows(i).Cells(1).Value, Nothing, AddressOf MenuItem_click).Name = menu_name
                    menu_dr.DropDownItems.Add(DataGridView2.Rows(i).Cells(1).Value, Nothing, AddressOf MenuItem_click).Name = menu_name
                    menu_dr.DropDownItems(menu_name).Tag = data2_rows_txt
                    menu_net(data2_rows_txt, menu_name, menu_dr)
                    menu_index = menu_index + 1
                End If
            Next
            xmlnodes = duxml(fs, "book")
        Else
            liebiao = ""
            MsgBox("该游戏列表文件不存在请检测路径")
        End If

    End Sub
    Private Sub menu_net(ByVal menu_net_path As String, ByVal menu_net_name As String, ByVal menu As ToolStripMenuItem)
        Dim menu_net_txt As String = ""
        Dim menu_net_dr As New ToolStripMenuItem
        Dim ar_i As Integer = 0
        Dim menu_net_dr_path(0) As String
        Dim menu_net_dr_name(0) As String
        menu_net_dr = menu.DropDownItems(menu_net_name)
        If My.Computer.FileSystem.FileExists(menu_net_path) Then


            xmlnodes = duxml(menu_net_path, "book")
            For i As Integer = 0 To xmlnodes.Count - 1
                menu_net_txt = xmlnodes(i).ChildNodes(0).InnerText
                If (System.IO.Path.GetExtension(menu_net_txt) = ".xml") Then
                    ReDim Preserve menu_net_dr_path(ar_i)
                    ReDim Preserve menu_net_dr_name(ar_i)
                    menu_net_dr.DropDownItems.Add(xmlnodes(i).ChildNodes(1).InnerText, Nothing, AddressOf MenuItem_click).Name = xmlnodes(i).ChildNodes(1).InnerText
                    menu_net_dr.DropDownItems(xmlnodes(i).ChildNodes(1).InnerText).Tag = menu_net_txt
                    menu_net_dr_path(ar_i) = menu_net_txt
                    menu_net_dr_name(ar_i) = xmlnodes(i).ChildNodes(1).InnerText
                End If
            Next
            If (menu_net_dr_path.Length > 0) Then
                For i = 0 To menu_net_dr_path.Length - 1
                    If (menu_net_dr_path(i) <> "") Then
                        menu_net(menu_net_dr_path(i), menu_net_dr_name(i), menu_net_dr)
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ds As New DataSet


        Dim hang As Integer
        Dim lie As Integer
        If liebiao <> "" Then
            hang = DataGridView2.Rows.Count
            lie = DataGridView2.Rows(0).Cells.Count
            For i As Integer = 0 To hang - 2
                For j As Integer = 0 To lie - 1
                    If (DataGridView2.Rows(i).Cells(j).Value.ToString().Trim() = String.Empty) Then
                        DataGridView2.Rows(i).Cells(j).Value = "kong"
                    End If

                Next
            Next

            ds = DataGridView2.DataSource

            ds.WriteXml(liebiao)

        End If

    End Sub



    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim s As String
        Dim n As Integer
        Dim lie As String

        n = DataGridView2.SelectedCells.Item(0).ColumnIndex
        s = DataGridView2.Columns(n).Name

        Select Case s
            Case "rom"
                OpenFileDialog1.Filter = "选择rom文件|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie
                End If
            Case "void"
                OpenFileDialog1.Filter = "选择视频文件|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie
                End If
            Case "mig"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie
                End If
            Case "kadai"
                OpenFileDialog1.Filter = "选择图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie

                End If
            Case "emu"
                OpenFileDialog1.Filter = "选择模拟器或核心|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie

                End If
            Case "intro"
                OpenFileDialog1.Filter = "选则游戏信息文件|*.txt"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie

                End If
        End Select
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim csstxt() As String = File.ReadAllLines(linpcss)
        Dim htmltxt() As String = File.ReadAllLines(linph)

        Dim txt1 As String
        Dim txt2 As String
        Dim txt3 As String = ""
        For i As Integer = 0 To htmltxt.Length - 1
            txt2 = htmltxt(i)

            txt3 = ""
            If (InStr(txt2, "<select") > 0) Then
                txt3 += "<select id='ziti' "
                txt3 += " name=" + Chr(34)
                txt3 += "ziti" + Chr(34)
                txt3 += "  class=" + Chr(34)
                txt3 += "sel" + Chr(34)
                txt3 += " multiple=" + Chr(34)
                txt3 += "true" + Chr(34)
                txt3 += " onclick=" + Chr(34)
                txt3 += "liebiao()" + Chr(34)
                txt3 += " ondblclick=" + Chr(34)
                txt3 += "yunxing()" + Chr(34)
                txt3 += "Size = " + Chr(34)
                txt3 += TextBox4.Text + Chr(34) + " >"
                htmltxt(i) = txt3
                WritePrivateProfileString("Startup file", "Number of lists" + xg.ToString, TextBox4.Text, 当前路径 + "\config.ini")
            End If
            txt3 = ""
            If (InStr(txt2, "logo") > 0) Then
                txt3 += "<img id=" + Chr(34)
                txt3 += "logo" + Chr(34)
                txt3 += "class=" + Chr(34)
                txt3 += "logo" + Chr(34)
                txt3 += "src=" + Chr(34)
                txt3 += TextBox25.Text + Chr(34) + " >"
                htmltxt(i) = txt3
            End If
            txt3 = ""
            If (InStr(txt2, "id=" + Chr(34) + "mengban" + Chr(34)) > 0) Then
                txt3 += "<img id=" + Chr(34)
                txt3 += "mengban" + Chr(34)
                txt3 += "class=" + Chr(34)
                txt3 += "mengban" + Chr(34)
                txt3 += "src=" + Chr(34)
                txt3 += TextBox51.Text + Chr(34) + " >"
                htmltxt(i) = txt3
            End If

            ' txt3 = ""

            'If (InStr(txt2, "dhmengban3") > 0) Then
            'txt3 += "<img id=" + Chr(34)
            'txt3 += "dhmengban3" + Chr(34)
            'txt3 += "class=" + Chr(34)
            'txt3 += "dhmengban3" + Chr(34)
            'txt3 += "src=" + Chr(34)
            ' txt3 += TextBox59.Text + Chr(34) + " >"
            'htmltxt(i) = txt3
            ' End If

        Next
        File.WriteAllLines(linph, htmltxt, System.Text.Encoding.UTF8)

        For i As Integer = 0 To csstxt.Length - 1
            txt1 = csstxt(i)
            Select Case txt1
                Case ".column1 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox20.Text + ";"
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox1.Text + ";"
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox2.Text + ";"
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox3.Text + ";"
                Case ".column2 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox30.Text + ";"
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox5.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox6.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox7.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox8.Text + ";"

                    While (InStr(txt1, "transform:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "transform:" + "skew(" + TextBox43.Text + "deg," + TextBox44.Text + "deg)" + ";"
                Case ".column3 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox32.Text + ";"

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox9.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox10.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox11.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox12.Text + ";"
                Case ".column4 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox33.Text + ";"

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox13.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox14.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox15.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox16.Text + ";"

                Case ".column5 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox39.Text + ";"

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox35.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox36.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox37.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox38.Text + ";"

                Case ".column6 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox45.Text + ";"

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox48.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox49.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox47.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox46.Text + ";"

                    While (InStr(txt1, "transform:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "transform:" + "skew(" + TextBox52.Text + "deg," + TextBox53.Text + "deg)" + ";"

                    While (InStr(txt1, "opacity:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "opacity:" + TextBox50.Text + ";"
                Case ".column7 {"
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox5.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox6.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox7.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox8.Text + ";"

                    While (InStr(txt1, "transform:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "transform:" + "skew(" + TextBox43.Text + "deg," + TextBox44.Text + "deg)" + ";"
                Case ".column1 option{"
                    'While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt(i)
                    ' i = i + 1
                    ' End While
                    'csstxt(i - 1) = "color:" + TextBox17.Text + ";"

                    While (InStr(txt1, "font-size:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "font-size:" + TextBox18.Text + ";"

                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "font-family:" + csszitil + ";"

                Case ".intro {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox56.Text + ";"


                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox54.Text + ";"


                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox55.Text + ";"

                    ' While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt(i)
                    'i = i + 1
                    'End While
                    'csstxt(i - 1) = "color:" + TextBox58.Text + ";"

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox60.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox62.Text + ";"

                    While (InStr(txt1, "font-size:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "font-size:" + TextBox61.Text + ";"

                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "font-family:" + csszitia1 + ";"
                    ' While (InStr(txt1, "background-color:") <= 0)
                    '  txt1 = csstxt(i)
                    '  i = i + 1
                    '   End While
                    ' csstxt(i - 1) = "background-color:" + TextBox57.Text + ";"
                Case ".dhmengban2 {"
                    ' While (InStr(txt1, "z-index:") <= 0)
                    ' txt1 = csstxt(i)
                    ' i = i + 1
                    'End While
                    ' csstxt(i - 1) = "z-index:" + TextBox64.Text + ";"



                    ' While (InStr(txt1, "height:") <= 0)
                    'txt1 = csstxt(i)
                    ' i = i + 1
                    '  End While
                    ' csstxt(i - 1) = "height:" + TextBox63.Text + ";"


                    While (InStr(txt1, "opacity:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "opacity:" + TextBox65.Text + ";"

                Case ".head2 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox34.Text + ";"
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox26.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox27.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox28.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox29.Text + ";"
                Case ".head1 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "z-index:" + TextBox31.Text + ";"
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "left:" + TextBox21.Text + ";"

                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "top:" + TextBox22.Text + ";"

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox23.Text + ";"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox24.Text + ";"

                Case ".header {"
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox19.Text + ";"
                    ' Case ".topnav {"
                    '   While (InStr(txt1, "background-color:") <= 0)
                    'txt1 = csstxt(i)
                    ' i = i + 1
                    ' End While
                    ' csstxt(i - 1) = "background-color:" + TextBox41.Text + ";"
                Case ".topnav a {"
                    '  While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt(i)
                    ' i = i + 1
                    ' End While
                    ' csstxt(i - 1) = "color:" + TextBox40.Text + ";"
                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "font-family:" + csszitia + ";"
                Case ".sel{"
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "width:" + TextBox42.Text + ";"

                Case ".row {"
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt(i)
                        i = i + 1
                    End While
                    csstxt(i - 1) = "height:" + TextBox66.Text + ";"

            End Select
        Next

        File.WriteAllLines(linpcss, csstxt, System.Text.Encoding.UTF8)
        WritePrivateProfileString("Startup file", "list", 0.ToString, 当前路径 + "\config.ini")
        WritePrivateProfileString("Startup file", "List number", 0.ToString, 当前路径 + "\config.ini")
        WritePrivateProfileString("Startup file", "Turn pages", 0.ToString, 当前路径 + "\config.ini")

        WritePrivateProfileString(xg.ToString, "ziti_color", TextBox17.Text, 当前路径 + "\config.ini")
        web_ziti_color = TextBox17.Text
        WritePrivateProfileString(xg.ToString, "id1_color", TextBox40.Text, 当前路径 + "\config.ini")
        web_a_color = TextBox40.Text
        WritePrivateProfileString(xg.ToString, "id1_background", TextBox41.Text, 当前路径 + "\config.ini")
        web_a_bgcolor = TextBox41.Text
        WritePrivateProfileString(xg.ToString, "id1_xzh_color", "#333", 当前路径 + "\config.ini")
        WritePrivateProfileString(xg.ToString, "id1_xzh_bd", "#ddd", 当前路径 + "\config.ini")
        WritePrivateProfileString(xg.ToString, "intro_color", TextBox58.Text, 当前路径 + "\config.ini")
        web_intro_color = TextBox58.Text
        WritePrivateProfileString(xg.ToString, "intro_background", TextBox57.Text, 当前路径 + "\config.ini")
        web_intro_bgcolor = TextBox57.Text

        If CSng(TextBox63.Text) > 0 Then
            WritePrivateProfileString("Startup file", "pic_interval", TextBox63.Text, 当前路径 + "\config.ini")

        Else
            WritePrivateProfileString("Startup file", "pic_interval", 1.ToString, 当前路径 + "\config.ini")
        End If
    End Sub
    Private Sub tab3int(ByVal web_color_index As String)
        Dim zhuanhuan As String
        zhuanhuan = New String(CChar(" "), 128)
        GetPrivateProfileString(web_color_index, "ziti_color", "ziti_color", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_ziti_color = 首尾删除空格(zhuanhuan)
        web_a_bgcolor = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "id1_color", "id1_color", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_a_color = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "id1_background", "id1_background", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_a_bgcolor = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "id1_xzh_bd", "id1_xzh_bd", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_az_bgcolor = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "id1_xzh_color", "id1_xzh_color", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_az_color = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "intro_color", "intro_color", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_intro_color = 首尾删除空格(zhuanhuan)
        GetPrivateProfileString(web_color_index, "intro_background", "intro_background", zhuanhuan, 128, 当前路径 + "\config.ini")
        web_intro_bgcolor = 首尾删除空格(zhuanhuan)
        If (web_ziti_color = "ziti_color") Then
            web_ziti_color = ""
        End If
        If (web_a_color = "id1_color") Then
            web_a_color = ""
        End If
        If (web_a_bgcolor = "id1_background") Then
            web_a_bgcolor = ""
        End If
        If (web_az_color = "id1_xzh_color") Then
            web_az_color = ""
        End If
        If (web_az_bgcolor = "id1_xzh_bd") Then
            web_az_bgcolor = ""
        End If
        If (web_intro_color = "intro_color") Then
            web_intro_color = ""

        End If
        If (web_intro_bgcolor = "intro_background") Then
            web_intro_bgcolor = ""
        End If

        Dim csstxt As TextReader = File.OpenText(linpcss)
        Dim txt1 As String
        Dim txt2 As String
        While csstxt.Peek() > -1
            txt1 = csstxt.ReadLine
            Select Case txt1
                Case ".column1 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox20.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox1.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox2.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox3.Text = txt2.Split(":")(1)
                Case ".column2 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox30.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox5.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox6.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox7.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox8.Text = txt2.Split(":")(1)
                    '倾斜x y
                    While (InStr(txt1, "transform:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox43.Text = txt2.Split(":")(1).Replace("skew", "").Replace("(", "").Replace(")", "").Split(",")(0).Replace("deg", "")
                    TextBox44.Text = txt2.Split(":")(1).Replace("skew", "").Replace("(", "").Replace(")", "").Split(",")(1).Replace("deg", "")
                Case ".column3 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox32.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox9.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox10.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox11.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox12.Text = txt2.Split(":")(1)
                Case ".column4 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox33.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox13.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox14.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox15.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox16.Text = txt2.Split(":")(1)
                Case ".column5 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox39.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox35.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox36.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox37.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox38.Text = txt2.Split(":")(1)


                Case ".column6 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox45.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox48.Text = txt2.Split(":")(1)

                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox49.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox47.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox46.Text = txt2.Split(":")(1)
                    '倾斜x y
                    While (InStr(txt1, "transform:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox52.Text = txt2.Split(":")(1).Replace("skew", "").Replace("(", "").Replace(")", "").Split(",")(0).Replace("deg", "")
                    TextBox53.Text = txt2.Split(":")(1).Replace("skew", "").Replace("(", "").Replace(")", "").Split(",")(1).Replace("deg", "")
                    While (InStr(txt1, "opacity:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox50.Text = txt2.Split(":")(1)


                Case ".intro {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox56.Text = txt2.Split(":")(1)

                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox54.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox55.Text = txt2.Split(":")(1)

                    ' While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '  End While
                    'txt2 = txt1.Split(";")(0)
                    ' TextBox58.Text = txt2.Split(":")(1)

                    ' txt1 = csstxt.ReadLine
                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox60.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox62.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "font-size:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox61.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    ComboBox6.Text = txt2.Split(":")(1)
                    csszitia1 = ComboBox6.Text

                    ' While (InStr(txt1, "background-color:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '  End While
                    'txt2 = txt1.Split(";")(0)
                    '   TextBox57.Text = txt2.Split(":")(1)
                Case ".dhmengban2 {"
                    'While (InStr(txt1, "z-index:") <= 0)
                    'txt1 = csstxt.ReadLine
                    ' End While
                    'txt2 = txt1.Split(";")(0)
                    ' TextBox64.Text = txt2.Split(":")(1)

                    ' txt1 = csstxt.ReadLine






                    'While (InStr(txt1, "height:") <= 0)
                    'txt1 = csstxt.ReadLine
                    ' End While
                    'txt2 = txt1.Split(";")(0)
                    ' TextBox63.Text = txt2.Split(":")(1)



                    ' While (InStr(txt1, "opacity:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '   End While
                    'txt2 = txt1.Split(";")(0)
                    ' TextBox65.Text = txt2.Split(":")(1)


                Case ".column1 option{"

                    'While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '  End While
                    ' txt2 = txt1.Split(";")(0)
                    'TextBox17.Text = txt2.Split(":")(1)
                    'MsgBox(txt1)
                    txt1 = csstxt.ReadLine
                    While (InStr(txt1, "font-size:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox18.Text = txt2.Split(":")(1)
                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    ComboBox3.Text = txt2.Split(":")(1)
                    csszitil = ComboBox3.Text
                Case ".header {"

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox19.Text = txt2.Split(":")(1)


                Case ".head1 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox31.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox21.Text = txt2.Split(":")(1)


                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox22.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox23.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox24.Text = txt2.Split(":")(1)


                Case ".head2 {"
                    While (InStr(txt1, "z-index:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox34.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "left:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox26.Text = txt2.Split(":")(1)


                    While (InStr(txt1, "top:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox27.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox28.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox29.Text = txt2.Split(":")(1)
                    'Case ".topnav {"
                    '  While (InStr(txt1, "background-color:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '    End While
                    'txt2 = txt1.Split(";")(0)
                    '  TextBox41.Text = txt2.Split(":")(1)
                Case ".topnav a {"
                    '  While (InStr(txt1, "color:") <= 0)
                    'txt1 = csstxt.ReadLine
                    '      End While
                    'txt2 = txt1.Split(";")(0)
                    ' TextBox40.Text = txt2.Split(":")(1)

                    While (InStr(txt1, "font-family:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    ComboBox4.Text = txt2.Split(":")(1)
                    csszitia = ComboBox4.Text
                Case ".sel{"
                    While (InStr(txt1, "width:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox42.Text = txt2.Split(":")(1)
                Case ".row {"
                    While (InStr(txt1, "height:") <= 0)
                        txt1 = csstxt.ReadLine
                    End While
                    txt2 = txt1.Split(";")(0)
                    TextBox66.Text = txt2.Split(":")(1)
            End Select

        End While
        csstxt.Close()
        csstxt.Dispose()
        TextBox17.Text = web_ziti_color
        TextBox40.Text = web_a_color
        TextBox41.Text = web_a_bgcolor
        TextBox58.Text = web_intro_color
        TextBox57.Text = web_intro_bgcolor

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim txt2 As String
        Dim 当前路径1 As String
        txt2 = WebBrowser1.Document.GetElementById("ziti").GetAttribute("size")
        TextBox4.Text = txt2
        当前路径1 = 当前路径.Replace("\", "/")

        TextBox25.Text = WebBrowser1.Document.GetElementById("logo").GetAttribute("src").Replace("file:///", "").Replace("%20", " ").Replace(当前路径1 + "/html/", "")
        TextBox51.Text = WebBrowser1.Document.GetElementById("mengban").GetAttribute("src").Replace("file:///", "").Replace("%20", " ").Replace(当前路径1 + "/html/", "")
        'TextBox59.Text = WebBrowser1.Document.GetElementById("dhmengban3").GetAttribute("src").Replace("file:///", "").Replace(当前路径1 + "/", "..\")

    End Sub




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim lie As String
        OpenFileDialog1.Filter = "选择图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lie = OpenFileDialog1.FileName
            lie = lie.Replace("file:///", "").Replace(当前路径 + "\", "")
            TextBox25.Text = lie
        End If
    End Sub



    Private Sub Form3_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Me.TabControl1.Width = Me.Width - 20
        Me.TabControl1.Height = Me.Height - 50
        DataGridView1.Width = Me.Width - 50
        Me.DataGridView1.Height = Me.Height - 200
        DataGridView2.Width = Me.Width - 50
        Me.DataGridView2.Height = Me.Height - 200

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged


        xg = ComboBox2.SelectedIndex

        If My.Computer.FileSystem.FileExists(当前路径 + "\html\" + xg.ToString + ".html") Then

            linph = 当前路径 + "\html\" + xg.ToString + ".html"
            linpcss = 当前路径 + "\html\" + xg.ToString + ".css"
            Call tab3int(xg.ToString)
            WebBrowser1.Navigate(linph)
        Else
            MsgBox("该游戏列表文件不存在请检测路径")
        End If
    End Sub
    Private Sub CopyDerictory(ByVal copy_path_div0 As String, ByVal copy_path_div1 As String, ByVal copy_path_div2 As String)
        Dim strDir As String() = System.IO.Directory.GetDirectories(copy_path_div1)
        Dim strFile As String() = System.IO.Directory.GetFiles(copy_path_div1)
        Dim copy_path_div3 As String
        Dim i As Integer
        copy_path_div3 = copy_path_div2 + "\" + Path.GetFileNameWithoutExtension(copy_path_div0)
        Dim strDirectoryDesPath As String
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                strDirectoryDesPath = strDir(i).Replace(copy_path_div0, copy_path_div3)
                建立文件夹(strDirectoryDesPath)
            Next
        End If
        If strFile.Length > 0 Then
            For i = 0 To strFile.Length - 1
                拷贝文件(strFile(i), strFile(i).Replace(copy_path_div0, copy_path_div3))
            Next
        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                CopyDerictory(copy_path_div0, strDir(i), copy_path_div2)
            Next
        End If
    End Sub
    Private Sub GetAllFile(ByVal path As String)
        Dim strDir As String() = System.IO.Directory.GetDirectories(path)
        Dim strFile As String() = System.IO.Directory.GetFiles(path)
        Dim fontp1 As String
        Dim fontp2 As String
        Dim i As Integer


        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                ' Console.WriteLine(strDir(i))
            Next
        End If

        If strFile.Length > 0 Then

            For i = 0 To strFile.Length - 1



                If (System.IO.Path.GetExtension(strFile(i)) = ".ttf" Or System.IO.Path.GetExtension(strFile(i)) = ".ttc" Or System.IO.Path.GetExtension(strFile(i)) = ".TTF" Or System.IO.Path.GetExtension(strFile(i)) = ".TTC") Then
                    fonttxt += "@font-face{" + Chr(13)
                    fonttxt += "font-family:" + Chr(34) + System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "") + Chr(34) + ";" + Chr(13)
                    fontp1 = "." + strFile(i).Replace(当前路径, "").Replace("\", "/")
                    fonttxt += "src:url(" + Chr(34) + fontp1 + Chr(34) + ");" + Chr(13)
                    fonttxt += "}" + Chr(13)
                    fonttxth += "@font-face{" + Chr(13)
                    fonttxth += "font-family:" + Chr(34) + System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "") + Chr(34) + ";" + Chr(13)
                    fontp2 = ".." + strFile(i).Replace(当前路径, "").Replace("\", "/")
                    fonttxth += "src:url(" + Chr(34) + fontp2 + Chr(34) + ");" + Chr(13)
                    fonttxth += "}" + Chr(13)
                    Me.ComboBox3.Items.Add(Chr(34) + System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "") + Chr(34))
                    Me.ComboBox4.Items.Add(Chr(34) + System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "") + Chr(34))
                    Me.ComboBox6.Items.Add(Chr(34) + System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "") + Chr(34))
                End If
            Next
        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1

                GetAllFile(strDir(i))
            Next
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        csszitil = ComboBox3.SelectedItem.ToString()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        csszitia = ComboBox4.SelectedItem.ToString()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If (joyshu > 0) Then
            Me.ComboBox5.Enabled = True

            Select Case joyshu
                Case 1

                    joyu = joyjc()
                    Label55.Text = ini_txt_valeu("joy", joyu, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 2
                    joyd = joyjc()
                    Label58.Text = ini_txt_valeu("joy", joyd, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 3
                    joyl = joyjc()
                    Label56.Text = ini_txt_valeu("joy", joyl, dic_ini_txt)
                    Label55.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 4
                    joyr = joyjc()
                    Label57.Text = ini_txt_valeu("joy", joyr, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 5
                    joye = joyjc()
                    Label59.Text = ini_txt_valeu("joy", joye, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 6
                    joyn = joyjc()
                    Label85.Text = ini_txt_valeu("joy", joyn, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 7
                    next2 = joyjc()
                    Label86.Text = ini_txt_valeu("joy", next2, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 8
                    next1 = joyjc()

                    Label87.Text = ini_txt_valeu("joy", next1, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label86.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 9
                    joyso = joyjc()
                    Label94.Text = ini_txt_valeu("joy", joyso, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label95.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
                Case 10
                    joyra = joyjc()

                    Label95.Text = ini_txt_valeu("joy", joyra, dic_ini_txt)
                    Label56.BackColor = Color.Gainsboro
                    Label57.BackColor = Color.Gainsboro
                    Label58.BackColor = Color.Gainsboro
                    Label55.BackColor = Color.Gainsboro
                    Label59.BackColor = Color.Gainsboro
                    Label85.BackColor = Color.Gainsboro
                    Label87.BackColor = Color.Gainsboro
                    Label94.BackColor = Color.Gainsboro
                    Me.ComboBox5.Enabled = True
                    Me.TabControl1.Enabled = True
            End Select
        Else
            Label56.BackColor = Color.Gainsboro
            Label57.BackColor = Color.Gainsboro
            Label58.BackColor = Color.Gainsboro
            Label59.BackColor = Color.Gainsboro
            Label55.BackColor = Color.Gainsboro
            Label85.BackColor = Color.Gainsboro
            Label86.BackColor = Color.Gainsboro
            Label87.BackColor = Color.Gainsboro
            Label94.BackColor = Color.Gainsboro
            Label95.BackColor = Color.Gainsboro
        End If

    End Sub

    Private Sub Label55_Click(sender As Object, e As EventArgs) Handles Label55.Click
        Label55.BackColor = Color.Yellow
        joyshu = 1
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub
    Public Function joyjc() As String
        Dim joyzt As String
        Dim infoJEx As JOYINFOEX
        With infoJEx
            .dwSize = Marshal.SizeOf(GetType(JOYINFOEX))
            .dwFlags = CInt(JOY_RETURNBUTTONS)
        End With

        Dim result As Integer = joyGetPosEx(ComboBox9.SelectedIndex, infoJEx)    '返回JOYERR_NOERROR(值为0)
        joyzt = "joy_empty"
        If result = 0 Then
            If (joytype = 0) Then
                If (infoJEx.dwPOV = 0) Then
                    joyzt = "joyup_1p"
                    joyshu = 0
                ElseIf (infoJEx.dwPOV = 18000) Then
                    joyzt = "joydw_1p"
                    joyshu = 0
                ElseIf (infoJEx.dwPOV = 27000) Then
                    joyzt = "joyleft_1p"
                    joyshu = 0
                ElseIf (infoJEx.dwPOV = 9000) Then
                    joyzt = "joyright_1p"
                    joyshu = 0
                End If
            End If

            If (joytype = 1) Then
                If infoJEx.wXpos = 0 Then   '输出左右按键状态
                    joyzt = "joyleft_1p"
                    joyshu = 0
                ElseIf infoJEx.wXpos = 65535 Then
                    joyzt = "joyright_1p"
                    joyshu = 0
                End If
                If infoJEx.wYpos = 0 Then   '输出上下按键状态
                    joyzt = "joyup_1p"
                    joyshu = 0
                ElseIf infoJEx.wYpos = 65535 Then
                    joyzt = "joydw_1p"
                    joyshu = 0
                End If
            End If

            '输出数字键
            Dim i As Integer
            For i = 0 To 9  '按位输出
                If (infoJEx.wButtons And 2 ^ i) = 0 Then
                Else
                    joyzt = "joy_1p" & i + 1
                    joyshu = 0
                End If
            Next
            '输出遥感状态
            '左摇杆

        Else
            joyzt = "joy_empty"

        End If
        If (joytype = 2 And dx_joy) Then
            Dim state As JoystickState = New JoystickState()
            state = pad.GetCurrentState()
            Dim buttons
            buttons = state.Buttons
            If (state.X = 0) Then
                joyzt = "joyleft_1p"
                joyshu = 0
            End If
            If (state.X = 65535) Then
                joyzt = "joyright_1p"
                joyshu = 0
            End If
            If (state.Y = 0) Then
                joyzt = "joyup_1p"
                joyshu = 0
            End If
            If (state.Y = 65535) Then
                joyzt = "joydw_1p"
                joyshu = 0
            End If
            Dim clickedId As Integer = 0
            For Each item In state.Buttons
                clickedId = clickedId + 1
                If (item) Then
                    joyzt = "joy_1p" & clickedId
                    joyshu = 0
                End If
            Next
        End If
        Return joyzt
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim infoJEx As JOYINFOEX
        With infoJEx
            .dwSize = Marshal.SizeOf(GetType(JOYINFOEX))
            .dwFlags = CInt(JOY_RETURNBUTTONS)
        End With
        Dim result As Integer = joyGetPosEx(ComboBox9.SelectedIndex, infoJEx)
        If result = 0 And Me.ComboBox5.SelectedIndex = 0 And Me.ComboBox8.SelectedIndex <> 2 Then

            WritePrivateProfileString("rocker", "up", joyu, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "down", joyd, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "left", joyl, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "right", joyr, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "determine", joye, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "Back", joyn, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "next page", next2, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "last page", next1, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "search", joyso, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "Raiders", joyra, 当前路径 + "\joy.ini")
        ElseIf (Me.ComboBox5.SelectedIndex = 1) Then

            WritePrivateProfileString("keyboard", "up", Label55.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "down", Label58.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "left", Label56.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "right", Label57.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "determine", Label59.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "Back", Label85.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "next page", Label86.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "last page", Label87.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "search", Label94.Text, 当前路径 + "\joy.ini")
            WritePrivateProfileString("keyboard", "Raiders", Label95.Text, 当前路径 + "\joy.ini")
        ElseIf (Me.ComboBox8.SelectedIndex = 2 And dx_joy) Then
            WritePrivateProfileString("rocker", "up", joyu, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "down", joyd, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "left", joyl, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "right", joyr, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "determine", joye, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "Back", joyn, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "next page", next2, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "last page", next1, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "search", joyso, 当前路径 + "\joy.ini")
            WritePrivateProfileString("rocker", "Raiders", joyra, 当前路径 + "\joy.ini")

        Else
            MsgBox("未识别到您的摇杆,或者为选择")
        End If

    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click
        Label58.BackColor = Color.Yellow
        joyshu = 2
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub

    Private Sub Label56_Click(sender As Object, e As EventArgs) Handles Label56.Click
        Label56.BackColor = Color.Yellow
        joyshu = 3
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs) Handles Label57.Click
        Label57.BackColor = Color.Yellow
        joyshu = 4
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click
        Label59.BackColor = Color.Yellow
        joyshu = 5
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim yesno As Integer
        yesno = MsgBox("是否要改变" + DataGridView1.CurrentRow.Cells(2).Value + "的游戏列表", MsgBoxStyle.YesNo)
        If yesno = 6 Then
            bak_ColumnIndex = DataGridView1.SelectedCells.Item(0).RowIndex
            Form4.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim lie As String
        OpenFileDialog1.Filter = "选择图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lie = OpenFileDialog1.FileName
            lie = lie.Replace("file:///", "").Replace(当前路径 + "\", "")
            TextBox51.Text = lie
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (ComboBox1.SelectedIndex = -1) Then
            MsgBox("请选择一个游戏列表")
        Else
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Minimum = 0

            Dim csvname As String = ""
            OpenFileDialog1.Filter = "中英文对照表|*.csv"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                csvname = OpenFileDialog1.FileName
            End If

            If csvname = "" Then
                MsgBox("选择中英文对照表")
            Else

                Dim csvtxt() As String = File.ReadAllLines(csvname)
                Dim romname As String
                Dim romname1 As String
                Dim zhongwen As String = ""
                Dim csv As String = ""
                Dim csv_l As Integer = 0
                Me.ProgressBar1.Maximum = (DataGridView2.Rows.Count - 1) + (csvtxt.Length - 1)
                For j As Integer = 1 To csvtxt.Length - 1
                    csv = csvtxt(j).Replace(Chr(34), "")
                    csv_l = csv.Split(",").Length

                    zhongwen = csvtxt(j).Replace(Chr(34), "").Split(",")(csv_l - 1)
                    romname = csv.Replace("," + zhongwen, "")

                    Try
                        If Not db_zidian.ContainsKey(romname) Then
                            db_zidian.Add(romname, zhongwen)
                        End If

                    Catch ex As Exception

                    End Try

                    Me.ProgressBar1.Value = j
                Next

                For i As Integer = 0 To DataGridView2.Rows.Count - 2

                    romname1 = DataGridView2.Rows(i).Cells(0).Value

                    romname1 = System.IO.Path.GetFileName(romname1).Replace(Path.GetExtension(romname1), "")
                    Try
                        If (db_zidian.ContainsKey(romname1)) Then


                            If (db_zidian.Item(romname1) <> "") Then
                                DataGridView2.Rows(i).Cells(1).Value = db_zidian.Item(romname1)
                            End If
                        End If
                    Catch ex As Exception

                    End Try

                    Me.ProgressBar1.Value = i + (csvtxt.Length - 1)
                Next
                MsgBox("完成任务记得保持")
                Me.ProgressBar1.Value = 0
            End If

        End If
        db_zidian.Clear()
    End Sub





    Private Sub Label85_Click(sender As Object, e As EventArgs) Handles Label85.Click
        Label85.BackColor = Color.Yellow
        joyshu = 6
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub


    Private Sub Label86_Click(sender As Object, e As EventArgs) Handles Label86.Click
        Label86.BackColor = Color.Yellow
        joyshu = 7
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub

    Private Sub Label87_Click(sender As Object, e As EventArgs) Handles Label87.Click
        Label87.BackColor = Color.Yellow
        joyshu = 8
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub



    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

        If (ComboBox5.SelectedIndex = 0) Then
            Me.Timer1.Enabled = True
            Me.PictureBox1.ImageLocation = 当前路径 + "\theme\shoubing.jpg"
            Label55.Text = ini_txt_valeu("joy", joyu, dic_ini_txt)
            Label58.Text = ini_txt_valeu("joy", joyd, dic_ini_txt)
            Label56.Text = ini_txt_valeu("joy", joyl, dic_ini_txt)
            Label57.Text = ini_txt_valeu("joy", joyr, dic_ini_txt)
            Label59.Text = ini_txt_valeu("joy", joye, dic_ini_txt)

            Label85.Text = ini_txt_valeu("joy", joyn, dic_ini_txt)


            Label86.Text = ini_txt_valeu("joy", next2, dic_ini_txt)
            Label87.Text = ini_txt_valeu("joy", next1, dic_ini_txt)
            Label94.Text = ini_txt_valeu("joy", joyso, dic_ini_txt)
            Label95.Text = ini_txt_valeu("joy", joyra, dic_ini_txt)
            ComboBox8.Visible = True
            ComboBox8.SelectedIndex = 0
            ComboBox9.Visible = True
        Else
            Me.Timer1.Enabled = False
            Me.PictureBox1.ImageLocation = 当前路径 + "\theme\jianpan.jpg"
            Label55.Text = ku
            Label58.Text = kd
            Label56.Text = kl
            Label57.Text = kr
            Label59.Text = ke
            Label85.Text = kz
            Label86.Text = ks
            Label87.Text = kx
            Label94.Text = kso
            Label95.Text = kra
            ComboBox8.Visible = False
            ComboBox9.Visible = False
        End If

    End Sub



    Private Sub TabControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles TabControl1.KeyDown


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ComboBox1.SelectedIndex > -1 Then


            Dim myExcel As New Microsoft.Office.Interop.Excel.Application
            myExcel.Application.Workbooks.Add(True)
            myExcel.Visible = True


            '  Dim m As Integer



            ' For m = 0 To DataGridView2.ColumnCount - 1
            'myExcel.Cells(1, m + 1) = Me.DataGridView2.Columns(m).HeaderText

            '  Next m


            '  Dim i As Integer
            '  For i = 0 To DataGridView2.RowCount - 2
            'Dim j As Integer
            '   For j = 0 To DataGridView2.ColumnCount - 1
            'If Me.DataGridView2(j, i).Value Is System.DBNull.Value Then
            'myExcel.Cells(i + 2, j + 1) = ""
            '   Else
            '     myExcel.Cells(i + 2, j + 1) = DataGridView2(j, i).Value.ToString
            '  End If

            '   Next j
            '   Next i
            '  End If
            'Dim m As Integer




            myExcel.Cells(1, 1) = Me.DataGridView2.Columns(1).HeaderText
            Dim i As Integer
            For i = 0 To DataGridView2.RowCount - 2
                '  Dim j As Integer
                '  For j = 0 To DataGridView2.ColumnCount - 1
                If Me.DataGridView2(1, i).Value Is System.DBNull.Value Then
                    myExcel.Cells(i + 2, 1) = ""
                Else
                    myExcel.Cells(i + 2, 1) = DataGridView2(1, i).Value.ToString
                End If

                'Next j
            Next i
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call importexceltodatagridview("Sheet1", "DataGridView2")
    End Sub
    Private Sub importexceltodatagridview(ByVal Sheet, ByVal datagridview)
        If (ComboBox1.SelectedIndex > -1) Then


            Dim fileDialog As OpenFileDialog = New OpenFileDialog()
            Dim FileName As String
            Dim dt As New DataTable
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = DataGridView2.Rows.Count - 1
            fileDialog.Filter = "Microsoft Excel files (*.xls)|*.xls"
            If fileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Try
                    FileName = fileDialog.FileName
                    Dim dataAdapter As New OleDbDataAdapter
                    Dim MyConnection As New OleDbConnection
                    Dim objcmd As OleDbCommand
                    Dim dst As New DataSet
                    Dim i As Integer = 0
                    Dim j As Integer = DataGridView2.RowCount - 2
                    MyConnection = New OleDbConnection( _
                                "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                                "Data Source=" & FileName & ";" & _
                                "Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'")
                    '   Select   the   data   from   Sheet1   of   the   workbook.
                    MyConnection.Open()
                    objcmd = New OleDbCommand("select * from [" & Sheet & "$]", MyConnection)
                    dataAdapter.SelectCommand = objcmd
                    dataAdapter.Fill(dst, "info")
                    dt = dst.Tables("info")
                    dataAdapter.Update(dst, "info")
                    MyConnection.Close()
                    For Each row As DataRow In dt.Rows
                        If (i <= j) Then
                            DataGridView2.Rows(i).Cells(1).Value = row("游戏名称")
                            i = i + 1
                        End If
                        Me.ProgressBar1.Value = i
                    Next row
                    'Me.DataGridView2.AutoGenerateColumns = True
                    'DataGridView2.DataSource = dt
                    'Msg@R_961_2419@("ok")
                Catch ex As Exception
                    MsgBox("读取出错")
                End Try
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            WritePrivateProfileString("Startup file", "Self starting", 1.ToString, 当前路径 + "\config.ini")

        Else
            WritePrivateProfileString("Startup file", "Self starting", 0.ToString, 当前路径 + "\config.ini")

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            WritePrivateProfileString("Startup file", "Front of window", 1.ToString, 当前路径 + "\config.ini")

        Else
            WritePrivateProfileString("Startup file", "Front of window", 0.ToString, 当前路径 + "\config.ini")

        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim yesno As Integer
        Dim 导出皮肤路径 As String = ""
        Dim 导出皮肤电视路径 As String = ""
        Dim 拷贝的目标 As String = ""
        Dim 写入mtn皮肤 As String = ""
        Dim html序号 As Integer
        Dim html名 As String = ""
        Dim css名 As String = ""

        html序号 = DataGridView1.SelectedCells.Item(0).RowIndex
        If My.Computer.FileSystem.FileExists(当前路径 + "\html\" + html序号.ToString + ".html") Then

            html名 = 当前路径 + "\html\" + html序号.ToString + ".html"
            css名 = 当前路径 + "\html\" + html序号.ToString + ".css"
            WebBrowser1.Navigate(html名)
        Else
            MsgBox("该页不存在请谨慎")
        End If
        yesno = MsgBox("是否要将" + DataGridView1.CurrentRow.Cells(2).Value + "的皮肤导出", MsgBoxStyle.YesNo)
        If yesno = 6 Then
            If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                导出皮肤路径 = Me.FolderBrowserDialog1.SelectedPath + "\" + DataGridView1.CurrentRow.Cells(2).Value
                Call 建立文件夹(导出皮肤路径)

                Call 建立文件夹(导出皮肤路径 + "\theme\tv")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(4).Value)

                导出皮肤电视路径 = 导出皮肤路径 + "\theme\tv\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\tv\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\theme\console")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(5).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\console\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\console\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)




                Call 建立文件夹(导出皮肤路径 + "\theme\bj")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(6).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\bj\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\bj\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)


                Call 建立文件夹(导出皮肤路径 + "\theme\head")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(7).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\head\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\head\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)


                Call 建立文件夹(导出皮肤路径 + "\theme\other")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(8).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\other\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\other\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)




                Call 建立文件夹(导出皮肤路径 + "\theme")
                拷贝的目标 = WebBrowser1.Document.GetElementById("logo").GetAttribute("src").Replace("file:///", "").Replace("/html", "")
                If My.Computer.FileSystem.FileExists(拷贝的目标) Then
                    导出皮肤电视路径 = 导出皮肤路径 + "\theme\" + System.IO.Path.GetFileName(拷贝的目标)
                    写入mtn皮肤 += "theme\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                    Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)
                Else
                    写入mtn皮肤 += Chr(13)
                End If

                Call 建立文件夹(导出皮肤路径 + "\theme\tv")
                拷贝的目标 = WebBrowser1.Document.GetElementById("mengban").GetAttribute("src").Replace("file:///", "").Replace("/html", "")
                If My.Computer.FileSystem.FileExists(拷贝的目标) Then
                    导出皮肤电视路径 = 导出皮肤路径 + "\theme\tv\" + System.IO.Path.GetFileName(拷贝的目标)
                    写入mtn皮肤 += "theme\tv\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                    Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)
                Else
                    写入mtn皮肤 += Chr(13)
                End If

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = html名
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = css名
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = 当前路径 + "\html\" + "daohang.js"
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)


                ' Call 建立文件夹(导出皮肤路径 + "\html\list_js")
                拷贝的目标 = 当前路径 + "\html\list_js"
                导出皮肤电视路径 = 导出皮肤路径 + "\html"
                写入mtn皮肤 += "html\list_js" + Chr(13)
                Console.WriteLine(拷贝的目标)
                CopyDerictory(拷贝的目标, 拷贝的目标, 导出皮肤电视路径)


                'Call 建立文件夹(导出皮肤路径 + "\html\list_css")
                拷贝的目标 = 当前路径 + "\html\list_css"
                导出皮肤电视路径 = 导出皮肤路径 + "\html"
                写入mtn皮肤 += "html\list_css" + Chr(13)
                CopyDerictory(拷贝的目标, 拷贝的目标, 导出皮肤电视路径)

            End If
        End If

        Dim mtn文件 As StreamWriter = File.CreateText(导出皮肤路径 + "\pifu.mtn")
        mtn文件.Write(写入mtn皮肤, System.Text.Encoding.UTF8)
        mtn文件.Close()

    End Sub
    Private Sub 建立文件夹(ByVal 文件夹名 As String)
        If Not Directory.Exists(文件夹名) Then
            Directory.CreateDirectory(文件夹名)
        End If
    End Sub
    Private Sub 拷贝文件(ByVal 目标文件 As String, ByVal 文件名 As String)
        Dim showUI As FileIO.UIOption = FileIO.UIOption.AllDialogs
        If My.Computer.FileSystem.FileExists(文件名) Then
            System.IO.File.Delete(文件名)
        End If
        If (System.IO.Path.GetExtension(目标文件) <> "") Then
            'IO.File.Copy(目标文件, 文件名, True)
            My.Computer.FileSystem.CopyFile(目标文件, 文件名, showUI)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim yesno As Integer
        Dim 导入皮肤路径 As String = ""
        Dim 导入皮肤文件 As String = ""
        Dim 导入皮肤电视路径 As String = ""
        Dim 拷贝的目标 As String = ""
        Dim 写入mtn皮肤 As String = ""
        Dim html序号 As Integer
        Dim html名 As String = ""
        Dim css名 As String = ""
        Dim 当前css名 As String = ""
        Dim logo文件 As String = ""

        'yesno = MsgBox("是否要将" + DataGridView1.CurrentRow.Cells(2).Value + "的皮肤导入", MsgBoxStyle.YesNo)
        yesno = 6
        If yesno = 6 Then
            OpenFileDialog1.Filter = "选择皮肤|*.mtn"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                导入皮肤文件 = OpenFileDialog1.FileName
                导入皮肤路径 = System.IO.Path.GetDirectoryName(导入皮肤文件)
                Dim 皮肤路径 As TextReader = File.OpenText(导入皮肤文件)

                html序号 = DataGridView1.SelectedCells.Item(0).RowIndex
                html名 = 当前路径 + "\html\" + html序号.ToString + ".html"
                css名 = 当前路径 + "\html\" + html序号.ToString + ".css"

                导入皮肤电视路径 = 皮肤路径.ReadLine
                DataGridView1.CurrentRow.Cells(4).Value = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 建立文件夹(System.IO.Path.GetDirectoryName(拷贝的目标))
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                DataGridView1.CurrentRow.Cells(5).Value = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 建立文件夹(System.IO.Path.GetDirectoryName(拷贝的目标))
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                DataGridView1.CurrentRow.Cells(6).Value = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 建立文件夹(System.IO.Path.GetDirectoryName(拷贝的目标))
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                DataGridView1.CurrentRow.Cells(7).Value = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 建立文件夹(System.IO.Path.GetDirectoryName(拷贝的目标))
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                DataGridView1.CurrentRow.Cells(8).Value = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 建立文件夹(System.IO.Path.GetDirectoryName(拷贝的目标))
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                logo文件 = 导入皮肤电视路径
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                拷贝的目标 = 当前路径 + "\" + 导入皮肤电视路径
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                拷贝的目标 = html名
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                当前css名 = 导入皮肤电视路径.Replace("html\", "")
                拷贝的目标 = css名
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                拷贝的目标 = 当前路径 + "\html\" + "daohang.js"
                Call 拷贝文件(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标)


                导入皮肤电视路径 = 皮肤路径.ReadLine
                拷贝的目标 = 当前路径 + "\html\list_js"
                My.Computer.FileSystem.CopyDirectory(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标, True)

                导入皮肤电视路径 = 皮肤路径.ReadLine
                拷贝的目标 = 当前路径 + "\html\list_css"
                My.Computer.FileSystem.CopyDirectory(导入皮肤路径 + "\" + 导入皮肤电视路径, 拷贝的目标, True)

                Dim html文件() As String = File.ReadAllLines(html名)
                Dim css链接 As String
                Dim 替换css As String
                For i As Integer = 0 To html文件.Length - 1
                    css链接 = html文件(i)

                    替换css = ""
                    If (InStr(css链接, 当前css名) > 0) Then
                        替换css += "<link rel=" + Chr(34) + " stylesheet" + Chr(34) + " type=" + Chr(34) + "text/css" + Chr(34) + " href=" + Chr(34) + html序号.ToString + ".css" + Chr(34) + " >"
                        html文件(i) = 替换css
                    End If
                    If (InStr(css链接, "logo") > 0) Then
                        替换css += "<img id=" + Chr(34) + "logo" + Chr(34) + "class=" + Chr(34) + "logo" + Chr(34) + "src=" + Chr(34) + logo文件 + Chr(34) + " >"
                        html文件(i) = 替换css
                    End If
                Next
                File.WriteAllLines(html名, html文件, System.Text.Encoding.UTF8)

            End If

        End If

    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Try
            Dim rectangle As New Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, Me.DataGridView1.RowHeadersWidth - 4, e.RowBounds.Height)
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), Me.DataGridView1.RowHeadersDefaultCellStyle.Font, _
            rectangle, DataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Try
            Dim rectangle As New Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, Me.DataGridView2.RowHeadersWidth - 4, e.RowBounds.Height)
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), Me.DataGridView2.RowHeadersDefaultCellStyle.Font, _
            rectangle, DataGridView2.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub DataGridView3_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView3.RowPostPaint
        Try
            Dim rectangle As New Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, Me.DataGridView3.RowHeadersWidth - 4, e.RowBounds.Height)
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), Me.DataGridView3.RowHeadersDefaultCellStyle.Font, _
            rectangle, DataGridView3.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("左边图片"))
        dt.Columns.Add(New DataColumn("右边图片"))
        dt.Columns.Add(New DataColumn("背景图片"))
        Dim row_list As Integer
        row_list = xmlnodes.Count - 1
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dt.Rows.Add(dr)
        Next


        DataGridView3.DataSource = dt
        Dim xml_json As Xml.XmlNodeList
        xml_json = duxml(当前路径 + "\html\index_js\index3.xml", "book")

        For i As Integer = 0 To xml_json.Count - 1

            DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
            DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
            DataGridView3.Rows(i).Cells(4).Value = xml_json(i).ChildNodes(4).InnerText
        Next
        xmlnodes = duxml(fs, "book")


    End Sub
    Private Sub DataGridView3_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.CellMouseDoubleClick
        Dim s As String
        Dim n As Integer
        Dim lie As String

        n = DataGridView3.SelectedCells.Item(0).ColumnIndex
        s = DataGridView3.Columns(n).Name

        Select Case s
            Case "左边图片"
                OpenFileDialog1.Filter = "左边图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    If (InStr(lie, "html\") > 0) Then
                        lie = lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    Else
                        lie = "../" + lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    End If
                End If
            Case "右边图片"
                OpenFileDialog1.Filter = "右边图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    If (InStr(lie, "html\") > 0) Then
                        lie = lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    Else
                        lie = "../" + lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    End If

                End If
            Case "背景图片"
                OpenFileDialog1.Filter = "背景图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    If (InStr(lie, "html\") > 0) Then
                        lie = lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    Else
                        lie = "../" + lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    End If
                End If
            Case "导航图片"
                OpenFileDialog1.Filter = "导航图片|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    If (InStr(lie, "html\") > 0) Then
                        lie = lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    Else
                        lie = "../" + lie.Replace("\", "/")
                        DataGridView3.SelectedCells.Item(0).Value = lie
                    End If

                End If
            Case "emu"
                OpenFileDialog1.Filter = "选择模拟器或核心|*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    lie = OpenFileDialog1.FileName
                    lie = lie.Replace(当前路径 + "\", "")
                    DataGridView2.SelectedCells.Item(0).Value = lie

                End If

        End Select
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim s As String
        Dim hang As Integer
        Dim lie As Integer
        Dim ds As New DataSet
        If (RadioButton1.Checked = True Or RadioButton2.Checked = True Or RadioButton3.Checked = True) Then


            s = DataGridView1.Rows(0).Cells(0).Value
            hang = DataGridView3.Rows.Count
            lie = DataGridView3.Rows(0).Cells.Count
            Dim json_txt(1) As String
            json_txt(0) = "var text_name = [" + Chr(13)

            For i As Integer = 0 To hang - 1
                For j As Integer = 0 To lie - 1
                    If (DataGridView3.Rows(i).Cells(j).Value.ToString().Trim() = String.Empty) Then
                        DataGridView3.Rows(i).Cells(j).Value = "kong"

                    End If

                Next
                If (Me.RadioButton1.Checked) Then
                    json_txt(0) += "{" + Chr(13) + Chr(34) + "name" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(0).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "web_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(1).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "img_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(2).Value + Chr(34) + ",}," + Chr(13)
                ElseIf (Me.RadioButton2.Checked) Then
                    json_txt(0) += "{" + Chr(13) + Chr(34) + "name" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(0).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "web_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(1).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "img_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(2).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "bi_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(3).Value + Chr(34) + ",}," + Chr(13)
                Else
                    json_txt(0) += "{" + Chr(13) + Chr(34) + "name" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(0).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "web_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(1).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "img_url_left" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(2).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "img_url_right" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(3).Value + Chr(34) + "," + Chr(13)
                    json_txt(0) += Chr(34) + "bi_url" + Chr(34) + ":" + Chr(34) + DataGridView3.Rows(i).Cells(4).Value + Chr(34) + ",}," + Chr(13)
                End If
            Next
            json_txt(0) += "];"
            ' ds = DataGridView3.DataSource
            Dim dt As DataTable = DataGridView3.DataSource
            dt.TableName = "book"
            File.WriteAllLines(当前路径 + "\html\index_js\index.json", json_txt, System.Text.Encoding.UTF8)
            If (Me.RadioButton1.Checked) Then
                dt.WriteXml(当前路径 + "\html\index_js\index1.xml")
                Call 拷贝文件(当前路径 + "\html\flhtml\index1.html", 当前路径 + "\html\index1.html")
            ElseIf (Me.RadioButton2.Checked) Then
                dt.WriteXml(当前路径 + "\html\index_js\index2.xml")
                Call 拷贝文件(当前路径 + "\html\flhtml\index2.html", 当前路径 + "\html\index1.html")
            Else
                dt.WriteXml(当前路径 + "\html\index_js\index3.xml")
                Call 拷贝文件(当前路径 + "\html\flhtml\index3.html", 当前路径 + "\html\index1.html")
            End If
        End If
    End Sub


    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("导航图片"))
        dt.Columns.Add(New DataColumn("背景图片"))
        Dim row_list As Integer
        row_list = xmlnodes.Count - 1
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dt.Rows.Add(dr)
        Next
        DataGridView3.DataSource = dt
        Dim xml_json As Xml.XmlNodeList
        xml_json = duxml(当前路径 + "\html\index_js\index2.xml", "book")
        For i As Integer = 0 To xml_json.Count - 1
            DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
            DataGridView3.Rows(i).Cells(3).Value = xml_json(i).ChildNodes(3).InnerText
        Next
        xmlnodes = duxml(fs, "book")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim xml_json As Xml.XmlNodeList
        Dim row_list As Integer
        row_list = xmlnodes.Count - 1
        dt.Columns.Add(New DataColumn("名称"))
        dt.Columns.Add(New DataColumn("链接页地址"))
        dt.Columns.Add(New DataColumn("导航图片"))
        For i As Integer = 0 To row_list
            dr = dt.NewRow()
            dr("名称") = xmlnodes(i).ChildNodes(2).InnerText
            dr("链接页地址") = "html/" + i.ToString + ".html"
            dt.Rows.Add(dr)
        Next
        DataGridView3.DataSource = dt
        xml_json = duxml(当前路径 + "\html\index_js\index1.xml", "book")
        For i As Integer = 0 To xml_json.Count - 1
            DataGridView3.Rows(i).Cells(2).Value = xml_json(i).ChildNodes(2).InnerText
        Next
        xmlnodes = duxml(fs, "book")

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        csszitia1 = ComboBox6.SelectedItem.ToString()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim yesno As Integer
        Dim 导出皮肤路径 As String = ""
        Dim 导出皮肤电视路径 As String = ""
        Dim 拷贝的目标 As String = ""
        Dim 写入mtn皮肤 As String = ""
        Dim html序号 As Integer
        Dim html名 As String = ""
        Dim css名 As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\mtn_update.exe")) Then


            Label92.Text = "正在打包处理上传文件请稍等......"
            html序号 = DataGridView1.SelectedCells.Item(0).RowIndex
            If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\update_file.txt") Then

                FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\update_file.txt")
            End If
            If My.Computer.FileSystem.FileExists(当前路径 + "\html\" + html序号.ToString + ".html") Then

                html名 = 当前路径 + "\html\" + html序号.ToString + ".html"
                css名 = 当前路径 + "\html\" + html序号.ToString + ".css"
                WebBrowser1.Navigate(html名)
            Else
                MsgBox("该页不存在请谨慎")
            End If
            yesno = MsgBox("是否要将" + DataGridView1.CurrentRow.Cells(2).Value + "的皮肤上传", MsgBoxStyle.YesNo)
            If yesno = 6 Then
                导出皮肤路径 = Mid(当前路径, 1, 3) + "temp\" + DataGridView1.CurrentRow.Cells(2).Value
                Call 建立文件夹(导出皮肤路径)

                Call 建立文件夹(导出皮肤路径 + "\theme\tv")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(4).Value)

                导出皮肤电视路径 = 导出皮肤路径 + "\theme\tv\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\tv\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\theme\console")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(5).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\console\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\console\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)




                Call 建立文件夹(导出皮肤路径 + "\theme\bj")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(6).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\bj\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\bj\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)


                Call 建立文件夹(导出皮肤路径 + "\theme\head")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(7).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\head\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\head\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)


                Call 建立文件夹(导出皮肤路径 + "\theme\other")
                拷贝的目标 = Path.GetFullPath(DataGridView1.CurrentRow.Cells(8).Value)
                导出皮肤电视路径 = 导出皮肤路径 + "\theme\other\" + System.IO.Path.GetFileName(拷贝的目标)
                If (System.IO.Path.GetFileName(拷贝的目标) = "kong") Then
                    写入mtn皮肤 += Chr(13)
                Else
                    写入mtn皮肤 += "theme\other\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                End If
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)




                Call 建立文件夹(导出皮肤路径 + "\theme")
                拷贝的目标 = WebBrowser1.Document.GetElementById("logo").GetAttribute("src").Replace("file:///", "").Replace("/html", "")
                If My.Computer.FileSystem.FileExists(拷贝的目标) Then
                    导出皮肤电视路径 = 导出皮肤路径 + "\theme\" + System.IO.Path.GetFileName(拷贝的目标)
                    写入mtn皮肤 += "theme\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                    Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)
                Else
                    写入mtn皮肤 += Chr(13)
                End If

                Call 建立文件夹(导出皮肤路径 + "\theme\tv")
                拷贝的目标 = WebBrowser1.Document.GetElementById("mengban").GetAttribute("src").Replace("file:///", "").Replace("/html", "")
                If My.Computer.FileSystem.FileExists(拷贝的目标) Then
                    导出皮肤电视路径 = 导出皮肤路径 + "\theme\tv\" + System.IO.Path.GetFileName(拷贝的目标)
                    写入mtn皮肤 += "theme\tv\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                    Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)
                Else
                    写入mtn皮肤 += Chr(13)
                End If

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = html名
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = css名
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                Call 建立文件夹(导出皮肤路径 + "\html")
                拷贝的目标 = 当前路径 + "\html\" + "daohang.js"
                导出皮肤电视路径 = 导出皮肤路径 + "\html\" + System.IO.Path.GetFileName(拷贝的目标)
                写入mtn皮肤 += "html\" + System.IO.Path.GetFileName(拷贝的目标) + Chr(13)
                Call 拷贝文件(拷贝的目标, 导出皮肤电视路径)

                ' Call 建立文件夹(导出皮肤路径 + "\html\list_js")
                拷贝的目标 = 当前路径 + "\html\list_js"
                导出皮肤电视路径 = 导出皮肤路径 + "\html\list_js"
                写入mtn皮肤 += "html\list_js" + Chr(13)
                My.Computer.FileSystem.CopyDirectory(拷贝的目标, 导出皮肤电视路径, True)

                'Call 建立文件夹(导出皮肤路径 + "\html\list_css")
                拷贝的目标 = 当前路径 + "\html\list_css"
                导出皮肤电视路径 = 导出皮肤路径 + "\html\list_css"
                写入mtn皮肤 += "html\list_css" + Chr(13)
                My.Computer.FileSystem.CopyDirectory(拷贝的目标, 导出皮肤电视路径, True)
                Dim mtn文件 As StreamWriter = File.CreateText(导出皮肤路径 + "\pifu.mtn")
                mtn文件.Write(写入mtn皮肤, System.Text.Encoding.UTF8)
                mtn文件.Close()
                Dim xml_txt As String
                Dim zip_path As String = Mid(当前路径, 1, 3) + "temp\" + Format(DateTime.Now, "yyyyMMddhhmmss") + ".zip"
                Dim Sw As StreamWriter = File.CreateText(当前路径 + "\mtn_tool\zip.xml")
                xml_txt = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " encoding=" + Chr(34) + "utf-8" + Chr(34) + "?>" + Chr(13)
                xml_txt += "<plp_yx_m>" + Chr(13)
                xml_txt += "<book>" + Chr(13)
                xml_txt += "<file_path>" + 导出皮肤路径 + "</file_path>" + Chr(13)
                xml_txt += "<zip_path>" + zip_path + "</zip_path>" + Chr(13)
                xml_txt += "<zip_size>" + "500M" + "</zip_size>" + Chr(13)
                xml_txt += "</book>" + Chr(13)
                xml_txt += "</plp_yx_m>"
                Sw.Write(xml_txt, System.Text.Encoding.UTF8)
                Sw.Close()
                Shell(当前路径 + "\mtn_tool\mtn_zip.bat")
                While Not My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt")
                End While
                Label92.Text = ""
                Me.Hide()
                Form5.Show()
                Form5.TextBox1.Text = "皮肤"
                Form5.Label14.Text = "tool"
                Form5.Label9.Text = 导出皮肤路径

            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim zip_path As String = ""
        If (System.Diagnostics.Process.GetProcessesByName("winrar").Length > 0) Or (System.Diagnostics.Process.GetProcessesByName("mtn_update").Length > 0) Then
            Label92.Text = "无法删除文件，请手动删除"
            Threading.Thread.Sleep(3000)
        Else
            Label92.Text = "删除压缩文件请稍等......"
            If My.Computer.FileSystem.DirectoryExists(Mid(当前路径, 1, 3) + "temp") Then
                FileIO.FileSystem.DeleteDirectory(Mid(当前路径, 1, 3) + "temp", 5)
            End If
            If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt") Then

                FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\zip_file.txt")
            End If
            If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\update_file.txt") Then

                FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\update_file.txt")
            End If
            Label92.Text = "完成删除"
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If (My.Computer.FileSystem.FileExists(当前路径 + "\download.exe")) Then
            ShellExecute(0, "open", 当前路径 + "\download.exe", "", "", 1)
            shell_download = 1
            End
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'Dim 导出rom路径 As String
        'Dim 导出资源路径 As String
        Dim thumb_dw_paht_html As String = ""
        Dim gl_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\mtn_update.exe")) Then

            ShellExecute(0, "open", 当前路径 + "\download.exe", "", "", 1)
            shell_download = 1
            End

            ' If (ComboBox1.SelectedIndex > -1) Then
            ' If (liebiao <> "kong") Then
            'If (System.Diagnostics.Process.GetProcessesByName("winrar").Length > 0) Or (System.Diagnostics.Process.GetProcessesByName("mtn_update").Length > 0) Then
            ' MsgBox("每次只能上传一个文件")
            'Else
            ' If My.Computer.FileSystem.DirectoryExists(Mid(当前路径, 1, 3) + "temp") Then
            'FileIO.FileSystem.DeleteDirectory(Mid(当前路径, 1, 3) + "temp", 5)
            ' End If
            'If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt") Then

            ' FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\zip_file.txt")
            'End If
            'If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\update_file.txt") Then

            'FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\update_file.txt")
            'End If
            'Try


            '导出资源路径 = Mid(当前路径, 1, 3) + "temp\" + Me.ComboBox1.Text
            ' Call 建立文件夹(导出资源路径)
            'If (DataGridView2.CurrentRow.Cells(0).Value <> "kong") Then
            '导出rom路径 = DataGridView2.CurrentRow.Cells(0).Value
            ' Call 建立文件夹(导出资源路径 + "\rom")
            ' Call 拷贝文件(Path.GetFullPath(导出rom路径), 导出资源路径 + "\rom\" + Path.GetFileName(导出rom路径))
            ' Form5.Label9.Text = "rom:" + Me.ComboBox1.Text + "/rom/" + Path.GetFileName(导出rom路径)
            ' gl_path = Path.GetFullPath(导出rom路径).Replace(Path.GetExtension(导出rom路径), "")
            ' If Directory.Exists(gl_path) Then
            'CopyDerictory(gl_path, gl_path, 导出资源路径 + "\rom")
            'End If
            'End If
            'If (DataGridView2.CurrentRow.Cells(2).Value <> "kong") Then
            '导出rom路径 = DataGridView2.CurrentRow.Cells(2).Value
            'Call 建立文件夹(导出资源路径 + "\video")
            'Call 拷贝文件(Path.GetFullPath(导出rom路径), 导出资源路径 + "\video\" + Path.GetFileName(导出rom路径))
            'Form5.Label9.Text += ";video:" + Me.ComboBox1.Text + "/video/" + Path.GetFileName(导出rom路径)
            ' End If


            'If (DataGridView2.CurrentRow.Cells(3).Value <> "kong") Then
            '导出rom路径 = DataGridView2.CurrentRow.Cells(3).Value
            'Call 建立文件夹(导出资源路径 + "\cassette")
            'Call 拷贝文件(Path.GetFullPath(导出rom路径), 导出资源路径 + "\cassette\" + Path.GetFileName(导出rom路径))
            'Form5.Label9.Text += ";cassette:" + Me.ComboBox1.Text + "/cassette/" + Path.GetFileName(导出rom路径)
            ' End If

            'If (DataGridView2.CurrentRow.Cells(4).Value <> "kong") Then
            '导出rom路径 = DataGridView2.CurrentRow.Cells(4).Value
            'Call 建立文件夹(导出资源路径 + "\thumb")
            'Call 拷贝文件(Path.GetFullPath(导出rom路径), 导出资源路径 + "\thumb\" + Path.GetFileName(导出rom路径))
            ' Form5.Label9.Text += ";thumb:" + Me.ComboBox1.Text + "/thumb/" + Path.GetFileName(导出rom路径)
            'End If

            'If (DataGridView2.CurrentRow.Cells(6).Value <> "kong") Then

            '导出rom路径 = DataGridView2.CurrentRow.Cells(6).Value
            'If (My.Computer.FileSystem.FileExists(Path.GetFullPath(导出rom路径))) Then
            'Call 建立文件夹(导出资源路径 + "\intro")
            'Call 拷贝文件(Path.GetFullPath(导出rom路径), 导出资源路径 + "\intro\" + Path.GetFileName(导出rom路径))
            ' Form5.Label9.Text += ";intro:" + Me.ComboBox1.Text + "/intro/" + Path.GetFileName(导出rom路径)
            'End If
            ' End If


            'Dim xml_txt As String
            'Dim zip_path As String = Mid(当前路径, 1, 3) + "temp\" + md5(DataGridView2.CurrentRow.Cells(0).Value) + ".zip"
            'Dim Sw As StreamWriter = File.CreateText(当前路径 + "\mtn_tool\zip.xml")
            'xml_txt = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " encoding=" + Chr(34) + "utf-8" + Chr(34) + "?>" + Chr(13)
            'xml_txt += "<plp_yx_m>" + Chr(13)
            'xml_txt += "<book>" + Chr(13)
            'xml_txt += "<file_path>" + 导出资源路径 + "</file_path>" + Chr(13)
            'xml_txt += "<zip_path>" + zip_path + "</zip_path>" + Chr(13)
            'xml_txt += "<zip_size>" + "500M" + "</zip_size>" + Chr(13)
            'xml_txt += "</book>" + Chr(13)
            ' xml_txt += "</plp_yx_m>"
            'Sw.Write(xml_txt, System.Text.Encoding.UTF8)
            'Sw.Close()
            'Shell(当前路径 + "\mtn_tool\mtn_zip.bat")
            'While Not My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt")
            'End While
            ' Me.Hide()
            ' Form5.Show()
            ' If (My.Computer.FileSystem.FileExists(DataGridView2.CurrentRow.Cells(4).Value) And DataGridView2.CurrentRow.Cells(4).Value <> "kong") Then
            'thumb_path = DataGridView2.CurrentRow.Cells(4).Value
            'thumb_path_file = Mid(当前路径, 1, 3) + "temp\" + Format(DateTime.Now, "yyyyMMddhhmmss") + Path.GetExtension(thumb_path)
            'System.IO.File.Copy(thumb_path, thumb_path_file, True)
            'Form5.Label10.Text = thumb_path_file
            'thumb_dw_paht_html = 当前路径 + "\html\upanddw\tbumb\game\" + Me.ComboBox1.Text
            ' Call 建立文件夹(thumb_dw_paht_html)
            'System.IO.File.Copy(thumb_path_file, thumb_dw_paht_html + "\" + Path.GetFileName(thumb_path_file), True)
            'Else
            ' thumb_path = "kong"
            'End If
            'Dim form5_text3 As String
            'Form5.TextBox1.Text = Me.ComboBox1.Text

            ' Form5.TextBox2.Text = text_处理(DataGridView2.CurrentRow.Cells(1).Value)
            'form5_text3 = text_处理(Path.GetFileName(DataGridView2.CurrentRow.Cells(0).Value))
            'Form5.TextBox3.Text = form5_text3

            ' Form5.TextBox3.Text = form5_text3.Replace(Path.GetExtension(form5_text3), "")

            ' Form5.TextBox9.Text = Path.GetFileName(DataGridView2.CurrentRow.Cells(5).Value)

            'Form5.TextBox8.Text = Path.GetFileName(emu_updat)
            ' Form5.Label14.Text = "game"
            ' Catch ex As Exception

            'End Try
            'End If
            'End If

            'Else
            '  MsgBox("请选择游戏")
            'End If

        Else
        Form12.Label4.Text = 3
        Form12.Show()
        Me.Hide()
        End If
    End Sub



    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        Dim sort As Integer
        sort = ComboBox7.SelectedIndex
        Select Case sort
            Case 0
                WriteOneString("Startup file", "msg", "0", 当前路径 + "\config.ini")

                Call cn_ssimp(Application.StartupPath() + "\msg\zh_hans.txt", 2)


            Case 1
                WriteOneString("Startup file", "msg", "1", 当前路径 + "\config.ini")

                Call cn_ssimp(Application.StartupPath() + "\msg\zh_hant.txt", 2)


            Case Else
                WriteOneString("Startup file", "msg", "2", 当前路径 + "\config.ini")
                Call cn_ssimp(Application.StartupPath() + "\msg\en.txt", 2)
        End Select
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim hang As Integer = 0
        Dim db_id As Integer = 0
        Dim db_rom As String = ""
        Dim db_name As String = ""
        Dim db_void As String = ""
        Dim db_kadai As String = ""
        Dim db_mig As String = ""
        Dim db_emu As String = ""
        Dim db_intro As String = ""
        Dim sql As String = ""
        Dim bak_path_txt As New Dictionary(Of String, String)

        Dim bak_txt As TextReader = File.OpenText("bak_phat.txt")

        Dim bak_txt1 As String
        Dim bak_txt2 As String = ""

        While bak_txt.Peek() > -1
            bak_txt1 = bak_txt.ReadLine
            If (bak_txt1 <> "") Then
                If (bak_txt1.Split("=").Length > 1) Then
                    If Not bak_path_txt.ContainsKey(bak_txt2 + "_" + bak_txt1.Split("=")(0)) Then
                        bak_path_txt.Add(bak_txt2 + "_" + bak_txt1.Split("=")(0), bak_txt1.Split("=")(1))
                    End If
                Else
                    bak_txt2 = bak_txt1.Replace("[", "").Replace("]", "")
                End If
            End If
        End While
        bak_txt.Close()

        If (liebiao <> "") Then
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = DataGridView2.Rows.Count - 2
            Form6.Label5.Text = liebiao
            Form6.Label7.Text = ComboBox1.Text
            'MsgBox(ComboBox1.SelectedIndex)
            hang = DataGridView2.Rows.Count
            For i As Integer = 0 To hang - 2
                db_rom = DataGridView2.Rows(i).Cells(0).Value
                Try
                    If Not db_zidian.ContainsKey(db_rom) Then
                        db_zidian.Add(Path.GetFileName(db_rom), i.ToString)
                    End If

                Catch ex As Exception

                End Try

                Me.ProgressBar1.Value = i
            Next
            If (InStr(Path.GetFileName(liebiao), "mf_ips_") > 0) Then
                Dim menu_new_index As Integer
                menu_new_index = DataGridView2.SelectedCells.Item(0).RowIndex
                Form6.Label5.Text = liebiao
                Form6.Label7.Text = DataGridView2.Rows(menu_new_index).Cells(0).Value

            End If
            If (ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "intro", bak_path_txt) <> "") Then
                Form6.TextBox5.Text = ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "intro", bak_path_txt)
                Form6.TextBox4.Text = ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "cassette", bak_path_txt)
                Form6.TextBox3.Text = ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "thumb", bak_path_txt)
                Form6.TextBox2.Text = ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "video", bak_path_txt)
                Form6.TextBox1.Text = ini_txt_valeu("bak" + CStr(ComboBox1.SelectedIndex), "rom", bak_path_txt)
                Form6.TextBox6.Text = ""
            Else
                Form6.TextBox5.Text = "添加游戏信息"
                Form6.TextBox4.Text = "添加游戏卡带图"
                Form6.TextBox3.Text = "添加游戏图片"
                Form6.TextBox2.Text = "添加游戏视频"
                Form6.TextBox1.Text = "添加游戏rom"
                Form6.TextBox6.Text = ""
            End If

            Form6.ProgressBar1.Value = 0

            Form6.Show()
            Me.Hide()
        End If

    End Sub


    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim da1rows As Integer = 0
        Dim da1_txt As String
        da1rows = DataGridView1.Rows.Count
        Form7.CheckedListBox1.Items.Clear()
        For i As Integer = 0 To da1rows - 2
            da1_txt = DataGridView1.Rows(i).Cells(2).Value
            Try
                Form7.CheckedListBox1.Items.Add(da1_txt, False)
            Catch ex As Exception

            End Try

            Me.ProgressBar1.Value = i
        Next
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub 移动ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移动ToolStripMenuItem.Click
        Dim menu_new_dr As String = ""
        Dim menu_new_index As Integer = -1
        Dim menu_new_path As String = ""
        If (Me.ComboBox1.SelectedIndex > -1) Then
            menu_new_dr = InputBox("列表名称")
            menu_new_index = Me.DataGridView2.RowCount - 1
            If (menu_new_dr <> "") Then
                menu_new_path = 当前路径 + "\rom\game_list\" + Me.ComboBox1.Text + "\" + Path.GetFileName(liebiao).Replace(".xml", "")
                Call 建立文件夹(menu_new_path)
                Call 拷贝文件(当前路径 + "\rom\game_list\meun_gamelist.xml", menu_new_path + "\" + menu_new_dr + ".xml")
                Dim xmlDoc As New XmlDocument()
                Dim root As XmlNode
                Dim xe1 As XmlElement
                xmlDoc.Load(liebiao)
                root = xmlDoc.SelectSingleNode("plp_yx_m") '查找<bookstore>
                xe1 = xmlDoc.CreateElement("book") '创建一个<book>节点
                Dim xesub1 As XmlElement = xmlDoc.CreateElement("rom")
                xesub1.InnerText = menu_new_path.Replace(当前路径 + "\", "") + "\" + menu_new_dr + ".xml" '设置文本节点
                xe1.AppendChild(xesub1) '添加到<book>节点中

                Dim xesub2 As XmlElement = xmlDoc.CreateElement("name")
                xesub2.InnerText = menu_new_dr
                xe1.AppendChild(xesub2)

                Dim xesub3 As XmlElement = xmlDoc.CreateElement("void")
                xesub3.InnerText = "kong"
                xe1.AppendChild(xesub3)

                Dim xesub4 As XmlElement = xmlDoc.CreateElement("kadai")
                xesub4.InnerText = "kong"
                xe1.AppendChild(xesub4)

                Dim xesub5 As XmlElement = xmlDoc.CreateElement("mig")
                xesub5.InnerText = "kong"
                xe1.AppendChild(xesub5)

                Dim xesub6 As XmlElement = xmlDoc.CreateElement("emu")
                xesub6.InnerText = "kong"
                xe1.AppendChild(xesub6)

                Dim xesub7 As XmlElement = xmlDoc.CreateElement("intro")
                xesub7.InnerText = "kong"
                xe1.AppendChild(xesub7)

                root.AppendChild(xe1) '添加到<bookstore>节点中
                'root.ChildNodes.Item(0).AppendChild(xe1)
                xmlDoc.Save(liebiao)
                Dim ds As New DataSet
                ds.ReadXml(liebiao)
                DataGridView2.DataSource = ds
            End If
        End If
    End Sub

    Private Sub MenuItem_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuStrip1.Click
        Dim ds As New DataSet
        If (sender.Tag <> "" And My.Computer.FileSystem.FileExists(sender.Tag)) Then
            liebiao = sender.Tag
            ds.ReadXml(liebiao)
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "book"
            For i As Integer = 0 To DataGridView2.Columns.Count - 1
                Select Case DataGridView2.Columns(i).HeaderText
                    Case "rom"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_0", dic_ini_txt)
                    Case "name"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_1", dic_ini_txt)
                    Case "void"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_2", dic_ini_txt)
                    Case "mig"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_3", dic_ini_txt)
                    Case "kadai"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_4", dic_ini_txt)
                    Case "emu"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_5", dic_ini_txt)
                    Case "intro"
                        DataGridView2.Columns(i).HeaderText = ini_txt_valeu("form3", "DataGridView2_6", dic_ini_txt)
                End Select
            Next
        End If

    End Sub


    Private Sub AaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AaToolStripMenuItem.Click
        If (Me.ComboBox1.SelectedIndex > -1) Then
            Form8.Label1.Text = liebiao
            Form8.Show()
        End If

    End Sub

    Private Sub 在选中的位置下面新建分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在选中的位置下面新建分类ToolStripMenuItem.Click

        Dim menu_new_dr As String = ""
        Dim menu_new_index As Integer = -1
        Dim menu_new_path As String = ""
        If (Me.ComboBox1.SelectedIndex > -1) Then
            menu_new_dr = InputBox("列表名称")
            menu_new_index = Me.DataGridView2.RowCount - 1
            If (menu_new_dr <> "") Then
                menu_new_path = 当前路径 + "\rom\game_list\" + Path.GetFileName(liebiao).Replace(".xml", "")
                Call 建立文件夹(menu_new_path)
                Call 拷贝文件(当前路径 + "\rom\game_list\meun_gamelist.xml", menu_new_path + "\" + menu_new_dr + ".xml")
                Dim xmlDoc As New XmlDocument()
                Dim root As XmlNode
                Dim xe1 As XmlElement
                xmlDoc.Load(liebiao)
                root = xmlDoc.SelectSingleNode("plp_yx_m") '查找<bookstore>
                xe1 = xmlDoc.CreateElement("book") '创建一个<book>节点
                Dim xesub1 As XmlElement = xmlDoc.CreateElement("rom")
                xesub1.InnerText = menu_new_path.Replace(当前路径 + "\", "") + "\" + menu_new_dr + ".xml" '设置文本节点
                xe1.AppendChild(xesub1) '添加到<book>节点中

                Dim xesub2 As XmlElement = xmlDoc.CreateElement("name")
                xesub2.InnerText = menu_new_dr
                xe1.AppendChild(xesub2)

                Dim xesub3 As XmlElement = xmlDoc.CreateElement("void")
                xesub3.InnerText = "kong"
                xe1.AppendChild(xesub3)

                Dim xesub4 As XmlElement = xmlDoc.CreateElement("kadai")
                xesub4.InnerText = "kong"
                xe1.AppendChild(xesub4)

                Dim xesub5 As XmlElement = xmlDoc.CreateElement("mig")
                xesub5.InnerText = "kong"
                xe1.AppendChild(xesub5)

                Dim xesub6 As XmlElement = xmlDoc.CreateElement("emu")
                xesub6.InnerText = "kong"
                xe1.AppendChild(xesub6)

                Dim xesub7 As XmlElement = xmlDoc.CreateElement("intro")
                xesub7.InnerText = "kong"
                xe1.AppendChild(xesub7)

                ' root.AppendChild(xe1) '添加到<bookstore>节点中
                ' MsgBox(DataGridView2.CurrentRow.Index)
                root.InsertAfter(xe1, root.ChildNodes(DataGridView2.CurrentRow.Index))
                xmlDoc.Save(liebiao)
                Dim ds As New DataSet
                ds.ReadXml(liebiao)
                DataGridView2.DataSource = ds
            End If
        End If
    End Sub
    Private Sub 为该游戏添加背景ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 为该游戏添加背景ToolStripMenuItem.Click
        If (Me.ComboBox1.SelectedIndex > -1) Then
            Form9.Label2.Text = liebiao
            Form9.Label3.Text = DataGridView2.SelectedCells.Item(0).RowIndex.ToString
            Form9.Show()
        End If
    End Sub

    Private Sub 制作图片集ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 制作图片集ToolStripMenuItem.Click
        Dim s_pic_txt As String = ""
        Dim s_pic_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then


            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个搜图窗口")
            Else
                If (Me.ComboBox1.SelectedIndex > -1) Then
                    s_pic_txt = Path.GetFileNameWithoutExtension(DataGridView2.SelectedCells.Item(0).Value)
                    pics_path_1 = 当前路径 + "/rom/" + ComboBox1.Text + "/Photos/" + s_pic_txt + ".txt"
                    s_pic_path = 当前路径 + "/rom/" + ComboBox1.Text + "/Photos/" + s_pic_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + ComboBox1.Text + "/Photos/")
                    s_pic_index = DataGridView2.SelectedCells.Item(0).RowIndex.ToString + Chr(13)
                    s_pic_path += DataGridView2.Rows(s_pic_index).Cells(1).Value + Chr(13)
                    s_pic_path += 1.ToString + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + ComboBox1.Text + "/Photos" + Chr(13)
                    s_pic_path += s_pic_txt + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + ComboBox1.Text + "/Photos" + Chr(13)
                    s_pic_path += 1.ToString + Chr(13)
                    s_pic_path += 当前路径 + "/" + liebiao + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + ComboBox1.Text + "/thumb" + Chr(13)
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_pic_path)
                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 1
                    Me.Timer2.Enabled = True
                End If
            End If

        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim pics_if As Integer = 0
        If (System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length > 0) Then

        Else
            Select Case s_vp_index
                Case 1
                    Dim pics_path_2 As String = ""
                    pics_path_2 = Path.GetDirectoryName(Path.GetDirectoryName(pics_path_1)) + "\thumb\" + Path.GetFileNameWithoutExtension(pics_path_1) + ".png"
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        DataGridView2.Rows(s_pic_index).Cells(4).Value = pics_path_1.Replace(当前路径 + "/", "")
                        DataGridView2.Refresh()
                    ElseIf My.Computer.FileSystem.FileExists(pics_path_2) Then
                        DataGridView2.Rows(s_pic_index).Cells(4).Value = pics_path_2.Replace(当前路径 + "\", "")
                        DataGridView2.Refresh()
                    End If
                Case 2
                    Dim ds As New DataSet
                    ds.ReadXml(liebiao)
                    DataGridView2.DataSource = ds
                Case 3
                    Dim pics_path_2 As String = ""
                    pics_path_2 = Path.GetDirectoryName(Path.GetDirectoryName(pics_path_1)) + "\cassette\" + Path.GetFileNameWithoutExtension(pics_path_1) + ".png"

                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        DataGridView2.Rows(s_pic_index).Cells(3).Value = pics_path_1.Replace(当前路径 + "/", "")
                        DataGridView2.Refresh()
                    ElseIf My.Computer.FileSystem.FileExists(pics_path_2) Then
                        DataGridView2.Rows(s_pic_index).Cells(3).Value = pics_path_2.Replace(当前路径 + "\", "")
                        DataGridView2.Refresh()
                    End If
                Case 4
                    Dim ds As New DataSet
                    ds.ReadXml(liebiao)
                    DataGridView2.DataSource = ds
                Case 5
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        DataGridView2.Rows(s_pic_index).Cells(2).Value = pics_path_1.Replace(当前路径 + "/", "")
                        DataGridView2.Refresh()
                    End If

            End Select
            Me.Timer2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            WritePrivateProfileString("Startup file", "Navigation mask", 1.ToString, 当前路径 + "\config.ini")

        Else
            WritePrivateProfileString("Startup file", "Navigation mask", 0.ToString, 当前路径 + "\config.ini")
        End If
    End Sub

    Private Sub PlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlToolStripMenuItem.Click
        Dim s_picsp_txt As String = ""
        Dim s_picsp_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then

            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (Me.ComboBox1.SelectedIndex > -1) Then
                    s_picsp_txt = Path.GetFileNameWithoutExtension(DataGridView2.SelectedCells.Item(0).Value)
                    pics_path_1 = 当前路径 + "/rom/" + ComboBox1.Text + "/Photos/" + s_picsp_txt + ".txt"
                    s_picsp_path = 当前路径 + "/rom/" + ComboBox1.Text + "/Photos/" + s_picsp_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + ComboBox1.Text + "/Photos/")
                    s_pic_index = DataGridView2.SelectedCells.Item(0).RowIndex.ToString + Chr(13)
                    s_picsp_path += DataGridView2.Rows(s_pic_index).Cells(1).Value + Chr(13)
                    s_picsp_path += 2.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/Photos" + Chr(13)
                    s_picsp_path += s_picsp_txt + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/Photos" + Chr(13)
                    s_picsp_path += 1.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/" + liebiao
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_picsp_path)

                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 2
                    Me.Timer2.Enabled = True
                End If
            End If

        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub 下载并添加视频ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下载并添加视频ToolStripMenuItem.Click
        Dim s_video_txt As String = ""
        Dim s_video_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then


            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (Me.ComboBox1.SelectedIndex > -1) Then
                    s_video_txt = Path.GetFileNameWithoutExtension(DataGridView2.SelectedCells.Item(0).Value)
                    pics_path_1 = 当前路径 + "/rom/" + ComboBox1.Text + "/video/" + s_video_txt + ".mp4"
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        MsgBox("视频已经存在")
                    Else
                        s_video_path = 当前路径 + "/rom/" + ComboBox1.Text + "/video/" + s_video_txt + ".txt" + Chr(13)
                        Call 建立文件夹(当前路径 + "/rom/" + ComboBox1.Text + "/video/")
                        s_pic_index = DataGridView2.SelectedCells.Item(0).RowIndex.ToString + Chr(13)
                        s_video_path += DataGridView2.Rows(s_pic_index).Cells(1).Value + Chr(13)
                        s_video_path += 5.ToString + Chr(13)
                        s_video_path += 当前路径 + "/rom/" + ComboBox1.Text + "/video" + Chr(13)
                        s_video_path += s_video_txt
                        's_pic_txt = s_pic_path
                        File.WriteAllText("pics.txt", s_video_path)
                        ShellExecute(0, "open", "https://search.bilibili.com/all?vt=91666068&keyword=" + DataGridView2.Rows(s_pic_index).Cells(1).Value, "", "", 1)
                        ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                        While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                        End While
                        s_vp_index = 5
                        Me.Timer2.Enabled = True
                    End If
                End If
            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub 批量添加卡带图片集ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量添加卡带图片集ToolStripMenuItem.Click
        Dim s_picsp_txt As String = ""
        Dim s_picsp_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then

            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (Me.ComboBox1.SelectedIndex > -1) Then
                    s_picsp_txt = Path.GetFileNameWithoutExtension(DataGridView2.SelectedCells.Item(0).Value)
                    pics_path_1 = 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt"
                    s_picsp_path = 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/")
                    s_pic_index = DataGridView2.SelectedCells.Item(0).RowIndex.ToString + Chr(13)
                    s_picsp_path += DataGridView2.Rows(s_pic_index).Cells(1).Value + Chr(13)
                    s_picsp_path += 4.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += s_picsp_txt + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += 2.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/" + liebiao
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_picsp_path)

                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 4
                    Me.Timer2.Enabled = True
                End If
            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub 制作卡带图片集ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 制作卡带图片集ToolStripMenuItem.Click
        Dim s_picsp_txt As String = ""
        Dim s_picsp_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then

            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (Me.ComboBox1.SelectedIndex > -1) Then
                    s_picsp_txt = Path.GetFileNameWithoutExtension(DataGridView2.SelectedCells.Item(0).Value)
                    pics_path_1 = 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt"
                    s_picsp_path = 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos/")
                    s_pic_index = DataGridView2.SelectedCells.Item(0).RowIndex.ToString + Chr(13)
                    s_picsp_path += DataGridView2.Rows(s_pic_index).Cells(1).Value + Chr(13)
                    s_picsp_path += 3.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += s_picsp_txt + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += 2.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/" + liebiao + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + ComboBox1.Text + "/cassette" + Chr(13)
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_picsp_path)

                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 3
                    Me.Timer2.Enabled = True
                End If
            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub 打开游戏信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开游戏信息ToolStripMenuItem.Click
        Dim open_filetxt_path As String
        Dim open_filetxt_index As Integer
        If (Me.ComboBox1.SelectedIndex > -1) Then
            open_filetxt_index = DataGridView2.SelectedCells.Item(0).RowIndex
            open_filetxt_path = DataGridView2.Rows(open_filetxt_index).Cells(6).Value
            If (Path.GetExtension(open_filetxt_path) = ".txt") And My.Computer.FileSystem.FileExists(open_filetxt_path) Then
                ShellExecute(0, "open", 当前路径 + "\" + open_filetxt_path, "", "", 1)
            Else
                MsgBox("未找到信息文件")
            End If
        End If
    End Sub

    Private Sub 打开图片集文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开图片集文件ToolStripMenuItem.Click
        Dim open_filetxt_path As String
        Dim open_filetxt_index As Integer
        If (Me.ComboBox1.SelectedIndex > -1) Then
            open_filetxt_index = DataGridView2.SelectedCells.Item(0).RowIndex
            open_filetxt_path = DataGridView2.Rows(open_filetxt_index).Cells(4).Value
            If (Path.GetExtension(open_filetxt_path) = ".txt") And My.Computer.FileSystem.FileExists(open_filetxt_path) Then

                ShellExecute(0, "open", 当前路径 + "\" + open_filetxt_path, "", "", 1)
            Else
                MsgBox("未找到图片集文件")
            End If
        End If
    End Sub

    Private Sub 打开卡带集文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开卡带集文件ToolStripMenuItem.Click
        Dim open_filetxt_path As String
        Dim open_filetxt_index As Integer
        If (Me.ComboBox1.SelectedIndex > -1) Then
            open_filetxt_index = DataGridView2.SelectedCells.Item(0).RowIndex
            open_filetxt_path = DataGridView2.Rows(open_filetxt_index).Cells(3).Value
            If (Path.GetExtension(open_filetxt_path) = ".txt") And My.Computer.FileSystem.FileExists(open_filetxt_path) Then

                ShellExecute(0, "open", 当前路径 + "\" + open_filetxt_path, "", "", 1)
            Else
                MsgBox("未找到卡带集文件")
            End If
        End If
    End Sub


    Private Sub 编辑游戏信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 编辑游戏信息ToolStripMenuItem.Click
        Dim intro_filetxt_path As String
        Dim intro_filetxt_name As String

        Dim open_filetxt_index As Integer
        If (Me.ComboBox1.SelectedIndex > -1) Then
            open_filetxt_index = DataGridView2.SelectedCells.Item(0).RowIndex
            intro_filetxt_name = DataGridView2.Rows(open_filetxt_index).Cells(0).Value
            intro_filetxt_name = Path.GetFileNameWithoutExtension(intro_filetxt_name)
            intro_filetxt_path = "rom/" + ComboBox1.Text + "/intro"
            建立文件夹(intro_filetxt_path)
            If (My.Computer.FileSystem.FileExists(intro_filetxt_path + "/" + intro_filetxt_name + ".txt")) Then
                ShellExecute(0, "open", 当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", "", "", 1)
            Else
                File.WriteAllText(当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", intro_filetxt_name)
                ShellExecute(0, "open", 当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", "", "", 1)
            End If
            DataGridView2.Rows(open_filetxt_index).Cells(6).Value = intro_filetxt_path + "/" + intro_filetxt_name + ".txt"
        End If
    End Sub



    Private Sub 跳转到行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 跳转到行ToolStripMenuItem.Click
        Dim index_row As Integer
        Dim input_row As String
        Dim index_row1 As Integer
        If (Me.ComboBox1.SelectedIndex > -1) Then
            input_row = InputBox("行序号")
            If input_row <> "" Then
                Try
                    index_row = CInt(input_row)
                    If index_row < DataGridView2.RowCount - 1 Then
                        index_row1 = DataGridView2.SelectedCells.Item(0).RowIndex
                        DataGridView2.Rows(index_row1).Selected = False
                        DataGridView2.CurrentCell = DataGridView2.Rows(index_row).Cells(0)
                        DataGridView2.Rows(index_row).Selected = True
                    Else
                        MsgBox("没有那么多游戏")
                    End If
                Catch ex As Exception
                    MsgBox("只能输入数字")
                End Try


            End If
        End If

    End Sub

    Private Sub CeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CeToolStripMenuItem.Click
       


        ' Dim strConn As String = "driver={microsoft access driver (*.mdb)};uid=admin;pwd=;dbq=" & Application.StartupPath & "\mtn.MDB"
        'Dim cn As New OdbcConnection(strConn)
        'cn.Open()
        ' da As New OdbcDataAdapter("Select * From 测试", cn)
        'Dim ds As New DataSet
        '.Fill(ds, "测试")
        'Dim cmdBuilder As New OdbcCommandBuilder(da)
        'da.InsertCommand = cmdBuilder.GetInsertCommand
        'With ds.Tables("测试")
        'For i = 0 To DataGridView2.Rows.Count - 1
        'Dim dr As DataRow = .NewRow
        ' dr("rom") = DataGridView2.Rows(i).Cells(0).Value
        'dr("name") = DataGridView2.Rows(i).Cells(1).Value
        '.Rows.Add(dr)
        ' Next
        ' End With
        'da.Update(ds.Tables("测试"))
        ' cn.Close()

    End Sub

   
    Private Sub Label94_Click(sender As Object, e As EventArgs) Handles Label94.Click
        Label94.BackColor = Color.Yellow
        joyshu = 9
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        Dim infoJEx As JOYINFOEX
        Dim joy_hao As Integer
        Dim joy_index As Integer = 0
        With infoJEx
            .dwSize = Marshal.SizeOf(GetType(JOYINFOEX))
            .dwFlags = CInt(JOY_RETURNBUTTONS)
        End With


        'Dim result As Integer = joyGetPosEx(Me.IsDisposed, infoJEx)
        If ComboBox8.SelectedIndex = 0 Then
            joytype = 0
            ComboBox9.Items.Clear()
            ComboBox9.SelectedIndex = -1
            ComboBox9.Text = "选择摇杆"
            Do While (joy_hao = 0 And ComboBox8.SelectedIndex < 2)
                joy_hao = joyGetPosEx(joy_index, infoJEx)
                If (joy_hao = 0) Then
                    ComboBox9.Items.Add((joy_index + 1).ToString + "号摇杆")
                    joy_index = joy_index + 1
                End If
            Loop
            WritePrivateProfileString("rocker", "joutype", joytype.ToString, 当前路径 + "\joy.ini")

        ElseIf (ComboBox8.SelectedIndex = 1) Then

            joytype = 1
            ComboBox9.Items.Clear()
            ComboBox9.SelectedIndex = -1
            ComboBox9.Text = "选择摇杆"
            Do While (joy_hao = 0 And ComboBox8.SelectedIndex < 2)
                joy_hao = joyGetPosEx(joy_index, infoJEx)
                If (joy_hao = 0) Then
                    ComboBox9.Items.Add((joy_index + 1).ToString + "号摇杆")
                    joy_index = joy_index + 1

                End If
            Loop
            WritePrivateProfileString("rocker", "joutype", joytype.ToString, 当前路径 + "\joy.ini")

        Else
            ComboBox9.Items.Clear()
            ComboBox9.SelectedIndex = -1
            ComboBox9.Text = "选择摇杆"
            Call GetJoyStick()
            If (dx_joutype(0) <> "") Then
                For dx_i As Integer = 1 To dx_joutype.Length
                    ComboBox9.Items.Add(dx_i.ToString + "号摇杆")
                Next

            End If
            joytype = 2
            WritePrivateProfileString("rocker", "joutype", joytype.ToString, 当前路径 + "\joy.ini")

        End If

    End Sub

    Private Sub 添加FBN模拟器中的IPS游戏ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加FBN模拟器中的IPS游戏ToolStripMenuItem.Click
        Dim menu_new_dr As String = ""
        Dim menu_new_index As Integer = -1
        Dim menu_new_path As String = ""
        Dim game_name As String
        Dim dat_rom_name As String = ""
        Dim fbn_xml As Xml.XmlNodeList
        If (Me.ComboBox1.SelectedIndex > -1) Then
            menu_new_index = DataGridView2.SelectedCells.Item(0).RowIndex
            If (InStr(Path.GetFileName(liebiao), "mf_ips_") > 0) Then
                Form6.Label5.Text = liebiao
                Form6.Label7.Text = DataGridView2.Rows(menu_new_index).Cells(0).Value
                Form6.Show()
                Me.Hide()
            Else

                game_name = DataGridView2.Rows(menu_new_index).Cells(1).Value
                menu_new_path = 当前路径 + "\rom\game_list\" + Path.GetFileName(liebiao).Replace(".xml", "")
                Call 建立文件夹(menu_new_path)
                game_name = "mf_ips_" + game_name
                game_name = menu_new_path + "\" + game_name + ".xml"
                game_name = game_name.Replace(当前路径 + "\", "")
                Call 拷贝文件(当前路径 + "\rom\game_list\meun_gamelist.xml", game_name)
                dat_rom_name = DataGridView2.Rows(menu_new_index).Cells(0).Value
                DataGridView2.Rows(menu_new_index).Cells(0).Value = game_name
                Dim ds As New DataSet
                ds = DataGridView2.DataSource
                ds.WriteXml(liebiao)


                fbn_xml = duxml(game_name, "book")
                fbn_xml(0).ChildNodes(0).InnerText = dat_rom_name
                fbn_xml(0).ChildNodes(1).InnerText = DataGridView2.Rows(menu_new_index).Cells(1).Value
                fbn_xml(0).ChildNodes(2).InnerText = DataGridView2.Rows(menu_new_index).Cells(2).Value
                fbn_xml(0).ChildNodes(3).InnerText = DataGridView2.Rows(menu_new_index).Cells(3).Value
                fbn_xml(0).ChildNodes(4).InnerText = DataGridView2.Rows(menu_new_index).Cells(4).Value
                fbn_xml(0).ChildNodes(5).InnerText = DataGridView2.Rows(menu_new_index).Cells(5).Value
                fbn_xml(0).ChildNodes(6).InnerText = DataGridView2.Rows(menu_new_index).Cells(6).Value
                doc.Save(game_name)
                liebiao = game_name
                Form6.Label5.Text = game_name
                Form6.Label7.Text = dat_rom_name
                Form6.Show()
                Me.Hide()
                'ds = DataGridView2.DataSource
                'ds.WriteXml(liebiao)
                ' MsgBox(liebiao)
                'Form8.Show()
            End If
        End If
    End Sub


    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox8.SelectedIndex = 0 Then
            WritePrivateProfileString("rocker", "dx_joutype", ComboBox9.SelectedIndex.ToString, Application.StartupPath() + "\joy.ini")
        ElseIf (ComboBox8.SelectedIndex = 1) Then
            WritePrivateProfileString("rocker", "dx_joutype", ComboBox9.SelectedIndex.ToString, Application.StartupPath() + "\joy.ini")
        ElseIf (ComboBox8.SelectedIndex = 2) Then
            Dim directInput As New DirectInput
            Dim joysticGuid As Guid = Guid.Empty
            Dim dx_joytyep As String
            dx_joytyep = dx_joutype(ComboBox9.SelectedIndex)
            For Each deviceInstance In directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)
                joysticGuid = deviceInstance.InstanceGuid
                If (joysticGuid.ToString = dx_joytyep) Then

                    GoTo joy_zhao
                End If
            Next
            'If joysticGuid = Guid.Empty Then
            For Each deviceInstance1 In directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)
                joysticGuid = deviceInstance1.InstanceGuid
                If (joysticGuid.ToString = dx_joytyep) Then

                    GoTo joy_zhao
                End If
            Next
            'End If
            If (joysticGuid.ToString <> dx_joytyep) Then
                dx_joy = False

            Else

joy_zhao:
                Dim sb As StringBuilder = New StringBuilder()
                pad = New Joystick(directInput, joysticGuid)
                allEffects = pad.GetEffects()
                For Each effectInfo In allEffects
                    sb.Append(effectInfo.Name.ToString())
                Next

                pad.Properties.BufferSize = 128
                pad.Acquire()
                dx_joy = True
            End If
            WritePrivateProfileString("rocker", "dx_joutype", dx_joutype(ComboBox9.SelectedIndex), Application.StartupPath() + "\joy.ini")
        End If
    End Sub

    Private Sub 添加游戏攻略ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加游戏攻略ToolStripMenuItem.Click
        Dim gl_index As Integer = 0
        Dim gl_rom_path As String = ""
        If (Me.ComboBox1.SelectedIndex > -1) Then
            gl_index = DataGridView2.SelectedCells.Item(0).RowIndex
            gl_rom_path = DataGridView2.Rows(gl_index).Cells(0).Value
            If (gl_rom_path <> "" And Path.GetExtension(gl_rom_path) <> ".xml") Then
                Form10.Label1.Text = gl_rom_path
                Form10.Label3.Text = "3"
                Form10.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Label95_Click(sender As Object, e As EventArgs) Handles Label95.Click
        Label95.BackColor = Color.Yellow
        joyshu = 10
        key事件 = True
        Me.ComboBox5.Enabled = False
        Me.TabControl1.Enabled = False
    End Sub





    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If (DataGridView1.Rows.Count - 2 >= 0) Then
            ' For i = d_del_index1 To d_del_index2

            ' Next

        End If



    End Sub

    Private Sub 替换当前资料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 替换当前资料ToolStripMenuItem.Click
        If (Me.ComboBox1.SelectedIndex > -1) Then
            Form13.Label9.Text = DataGridView1.Rows(Me.ComboBox1.SelectedIndex).Cells(1).Value
            Form13.Label10.Text = DataGridView1.Rows(Me.ComboBox1.SelectedIndex).Cells(9).Value
            Form13.Label1.Text = liebiao
            Me.Hide()
            Form13.Show()
        End If
    End Sub

    Private Sub 查看缺失资源的游戏ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查看缺失资源的游戏ToolStripMenuItem.Click
        If (Me.ComboBox1.SelectedIndex > -1) Then
            Form14.Label11.Text = DataGridView1.Rows(Me.ComboBox1.SelectedIndex).Cells(1).Value
            Form14.Label12.Text = DataGridView1.Rows(Me.ComboBox1.SelectedIndex).Cells(9).Value
            Form14.Label1.Text = liebiao
            Me.Hide()
            Form14.Show()
        End If
    End Sub

    Private Sub CesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CesToolStripMenuItem.Click
        MsgBox(getpychar("鳄"))
    End Sub
End Class