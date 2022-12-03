Imports System.IO
Imports System.Management
Imports System.Xml

Public Class Form7
    Dim 当前路径 As String
    Dim bak_f7_txt() As String
    Dim all_file_path() As String
    Dim bak_f7_Import As String


    Private Sub Form7_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckBox1.Checked = True
        Me.RadioButton3.Checked = True
        当前路径 = Application.StartupPath()
        Try
            Me.Label6.Text = ""
        Catch ex As Exception

        End Try

        ReDim all_file_path(17)
        all_file_path(0) = 当前路径 + "/dll"
        all_file_path(1) = 当前路径 + "/font"
        all_file_path(2) = 当前路径 + "/msg"
        all_file_path(3) = 当前路径 + "/theme"
        all_file_path(4) = 当前路径 + "/ffmpeg"
        all_file_path(5) = 当前路径 + "/help"
        all_file_path(6) = 当前路径 + "/mtn_tool"
        all_file_path(7) = 当前路径 + "/Raiders"
        all_file_path(8) = 当前路径 + "/Temp"
        all_file_path(9) = 当前路径 + "/theme"
        all_file_path(10) = 当前路径 + "/x86"
        all_file_path(11) = 当前路径 + "\html\basic"
        all_file_path(12) = 当前路径 + "\html\flhtml"
        all_file_path(13) = 当前路径 + "\html\index_files"
        all_file_path(14) = 当前路径 + "\html\index_js"
        all_file_path(15) = 当前路径 + "\html\list_css"
        all_file_path(16) = 当前路径 + "\html\upanddw"
        all_file_path(17) = 当前路径 + "\emu\cores"

        ReDim bak_f7_txt(35)
        bak_f7_txt(0) = 当前路径 + "\abc.exe"
        bak_f7_txt(1) = 当前路径 + "\abc.txt"
        bak_f7_txt(2) = 当前路径 + "\bak_phat.txt"
        bak_f7_txt(3) = 当前路径 + "\ceshi.html"
        bak_f7_txt(4) = 当前路径 + "\config.ini"
        bak_f7_txt(5) = 当前路径 + "\daohang.css"
        bak_f7_txt(6) = 当前路径 + "\CameraDll.dll"
        bak_f7_txt(7) = 当前路径 + "\daohang.js"
        bak_f7_txt(8) = 当前路径 + "\daohang.xml"
        bak_f7_txt(9) = 当前路径 + "\download.exe"
        bak_f7_txt(10) = 当前路径 + "\download.exe.config"
        bak_f7_txt(11) = 当前路径 + "\font.css"
        bak_f7_txt(12) = 当前路径 + "\gamerom_bj.txt"
        bak_f7_txt(13) = 当前路径 + "\html5media.js"
        bak_f7_txt(14) = 当前路径 + "\html5media.min.js"
        bak_f7_txt(15) = 当前路径 + "\jincheng.exe"
        bak_f7_txt(16) = 当前路径 + "\jincheng.exe.config"

        bak_f7_txt(17) = 当前路径 + "\joy.ini"
        bak_f7_txt(18) = 当前路径 + "\MTN.bat"
        bak_f7_txt(19) = 当前路径 + "\MTN.exe"
        bak_f7_txt(20) = 当前路径 + "\MTN.exe.config"
        bak_f7_txt(21) = 当前路径 + "\mtn_pv_index.exe"

        bak_f7_txt(22) = 当前路径 + "\pics.txt"
        bak_f7_txt(23) = 当前路径 + "\qidong.bat"
        bak_f7_txt(24) = 当前路径 + "\shezhi.exe"
        bak_f7_txt(25) = 当前路径 + "\shezhi.exe.config"
        bak_f7_txt(26) = 当前路径 + "\version.txt"
        bak_f7_txt(27) = 当前路径 + "\更新日记.txt"
        bak_f7_txt(28) = 当前路径 + "\双击注册浏览器.reg"

        bak_f7_txt(29) = 当前路径 + "\html\daohang.js"
        bak_f7_txt(30) = 当前路径 + "\html\font.css"
        bak_f7_txt(31) = 当前路径 + "\html\html5media.js"
        bak_f7_txt(32) = 当前路径 + "\html\index.html"
        bak_f7_txt(33) = 当前路径 + "\html\index1.html"
        bak_f7_txt(34) = 当前路径 + "\html\upanddw.html"
        bak_f7_txt(35) = 当前路径 + "\rom\game_list\meun_gamelist.xml"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = all_file_path.Length - 1
        Dim i As Integer
        Dim mtn_key_b As Boolean = False
        Dim key_s As String = ""
        Dim xu_z As Boolean = False
        Dim xml_doc As Xml.XmlNodeList
        Dim romlist_j As String = ""
        Dim html_name(0) As Integer
        html_name(0) = 0
        For i = 0 To (CheckedListBox1.Items.Count - 1)
            If CheckedListBox1.GetItemChecked(i) = True Then
                xu_z = True
            End If
        Next
        If RadioButton1.Checked Or RadioButton2.Checked Then
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("不是无限制密码或作者留言不能为空")
                GoTo 结束
            End If
            If RadioButton1.Checked Then
                key_s = "qd:1[MTN]"
                mtn_key_b = True
            End If
            If RadioButton2.Checked Then
                key_s = "qd:2[MTN]"
                mtn_key_b = True
            End If
            key_s += "key:" + TextBox1.Text + "[MTN]"
            If CheckBox4.Checked Then
                key_s += "yp:1[MTN]"
            End If
            If CheckBox5.Checked Then
                key_s += "wk:2[MTN]"
            End If
            If CheckBox6.Checked Then
                key_s += "sj:3[MTN]"
            End If
            If CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False Then
                key_s += "0[MTN]"
            End If
            key_s = Change1(key_s)
            key_s += Chr(13) + TextBox2.Text

        End If
        If xu_z Then
            If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                ' MsgBox(Me.FolderBrowserDialog1.SelectedPath)

                Dim mtn_path As String = Me.FolderBrowserDialog1.SelectedPath + "\MTN"
                建立文件夹(mtn_path)
                Dim mtn_path1 As String = mtn_path
                For i = 0 To all_file_path.Length - 1
                    Label2.Text = "正在复制必须文件..."
                    If Directory.Exists(all_file_path(i)) Then
                        mtn_path1 = all_file_path(i).Replace(当前路径, mtn_path)
                        mtn_path1 = Path.GetDirectoryName(mtn_path1)
                        CopyDerictory(all_file_path(i), all_file_path(i), mtn_path1)
                    End If
                Next


                Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Minimum = 0
                Me.ProgressBar1.Maximum = bak_f7_txt.Length - 1
                Dim mtn_path2 As String = mtn_path
                For i = 0 To bak_f7_txt.Length - 1
                    Me.ProgressBar1.Value = i
                    If My.Computer.FileSystem.FileExists(bak_f7_txt(i)) Then
                        mtn_path2 = bak_f7_txt(i).Replace(当前路径, mtn_path)
                        建立文件夹(Path.GetDirectoryName(mtn_path2))
                        拷贝文件(bak_f7_txt(i), mtn_path2)
                    End If
                Next

                Dim xml_file_path As String
                xml_file_path = mtn_path + "\daohang.xml"
                xml_doc = duxml(xml_file_path, "plp_yx_m")
                Dim xmlNd As XmlNode
                Dim html_index As Integer = 0

                For i = (CheckedListBox1.Items.Count - 1) To 0 Step -1
                    Label2.Text = "正在处理导航列表..."
                    If CheckedListBox1.GetItemChecked(i) = False Then
                        xmlNd = xml_doc(0).ChildNodes(i)
                        xml_doc(0).RemoveChild(xmlNd)
                    Else
                        ReDim Preserve html_name(html_index)
                        html_name(html_index) = i

                        html_index = html_index + 1
                    End If
                Next
                doc.Save(xml_file_path)


                html_index = 0
                For i = (html_name.Length - 1) To 0 Step -1
                    Label2.Text = "正在改写HTML文件..."
                    拷贝文件(当前路径 + "\html\" + html_name(html_index).ToString + ".html", mtn_path + "\html\" + i.ToString + ".html")
                    拷贝文件(当前路径 + "\html\" + html_name(html_index).ToString + ".css", mtn_path + "\html\" + i.ToString + ".css")
                    Dim html文件() As String = File.ReadAllLines(mtn_path + "\html\" + i.ToString + ".html")
                    Dim css链接 As String
                    Dim 替换css As String
                    Dim 当前css名 As String = html_name(html_index).ToString + ".css"
                    For j As Integer = 0 To html文件.Length - 1
                        css链接 = html文件(j)
                        替换css = ""
                        If (InStr(css链接, 当前css名) > 0) Then
                            替换css += "<link rel=" + Chr(34) + " stylesheet" + Chr(34) + " type=" + Chr(34) + "text/css" + Chr(34) + " href=" + Chr(34) + i.ToString + ".css" + Chr(34) + " >"
                            html文件(j) = 替换css
                            GoTo 跳出
                        End If
跳出:
                    Next
                    File.WriteAllLines(mtn_path + "\html\" + i.ToString + ".html", html文件, System.Text.Encoding.UTF8)
                    html_index = html_index + 1
                Next


                xml_doc = duxml(xml_file_path, "book")
                Dim emu_path As String = ""
                Dim emu_file_name As String = ""
                Dim rom_list As String = ""
                Dim rom_list_meun As String = ""

                For i = 0 To xml_doc.Count - 1
                    Label2.Text = "正在复制模拟器文件..."
                    If CheckBox1.Checked Then
                        emu_path = xml_doc(i).ChildNodes(1).InnerText
                        If My.Computer.FileSystem.FileExists(emu_path) Then
                            emu_file_name = Path.GetFileName(emu_path)
                            emu_path = Path.GetFullPath(emu_path)
                            emu_path = Path.GetDirectoryName(emu_path)
                            CopyDerictory(emu_path, emu_path, mtn_path + "\emu")
                            xml_doc(i).ChildNodes(1).InnerText = "emu\" + Path.GetFileName(emu_path) + "\" + emu_file_name
                        End If
                    End If
                    rom_list = xml_doc(i).ChildNodes(3).InnerText
                    romlist_j = 当前路径 + "\rom\" + xml_doc(i).ChildNodes(2).InnerText
                    If My.Computer.FileSystem.FileExists(rom_list) Then
                        Label2.Text = "正在复制游戏列表..."
                        拷贝文件(rom_list, mtn_path + "\rom\game_list\" + Path.GetFileName(rom_list))
                        rom_list_meun = 当前路径 + "\rom\game_list\" + xml_doc(i).ChildNodes(2).InnerText
                        If Directory.Exists(rom_list_meun) Then
                            CopyDerictory(rom_list_meun, rom_list_meun, mtn_path + "\rom\game_list\")
                        End If
                    End If
                    If CheckBox2.Checked Then
                        Label2.Text = "正在复制游戏..."
                        If Directory.Exists(romlist_j) Then
                            CopyDerictory(romlist_j, romlist_j, mtn_path + "\rom")
                        End If
                    End If
                Next
                doc.Save(xml_file_path)
                WritePrivateProfileString("Startup file", "page", "html\0.html", mtn_path + "\config.ini")
                WritePrivateProfileString("Startup file", "no_web", 0.ToString, mtn_path + "\config.ini")
                File.WriteAllText(mtn_path + "\key.txt", key_s)
                If mtn_key_b Then
                    拷贝文件(当前路径 + "\dll\MTN.exe", mtn_path + "\MTN.exe")
                    拷贝文件(当前路径 + "\dll\shezhi.exe", mtn_path + "\shezhi.exe")
                End If
                Label2.Text = "完成任务请测试"
            End If
        Else
            MsgBox("至少要选择列表中的一项")
        End If
结束:

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
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Minimum = 0
        If (strFile.Length - 1) > 0 Then
            Me.ProgressBar1.Maximum = strFile.Length - 1
        Else
            Me.ProgressBar1.Maximum = 1
        End If
        If strFile.Length > 0 Then
            For i = 0 To strFile.Length - 1
                Me.ProgressBar1.Value = i
                拷贝文件(strFile(i), strFile(i).Replace(copy_path_div0, copy_path_div3))
            Next
        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                CopyDerictory(copy_path_div0, strDir(i), copy_path_div2)
            Next
        End If
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()




    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim yesno As Integer = 0
        If CheckBox2.Checked Then
            yesno = MsgBox("游戏ROM和资料需要放在ROM\（分类名）文件夹下面才会自动导出如果不是请手动拷贝", MsgBoxStyle.YesNo)
        End If

        If yesno <> 6 Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged



    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

    End Sub
    Public Function Change1(ByVal Str1 As String) As String
        Dim tt As Char = ""
        Dim Str_B As String = ""
        For i = 1 To Len(Str1)
            tt = Mid(Str1, i, 1)
            Str_B = Str_B & (Asc(tt) - 30)
        Next
        Change1 = Str_B
    End Function
    Public Function Change2(ByVal Str1 As String) As String
        Dim tt As String = ""
        Dim Str_C As String = ""
        For i = 1 To Len(Str1) / 2
            tt = Mid(Str1, i * 2 - 1, 2)
            Str_C = Str_C & Chr(CInt(tt) + 30)
        Next
        Change2 = Str_C
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mtn_key_t1 As String()
        If (TextBox3.Text <> "") Then
            mtn_key_t1 = Change2(TextBox3.Text).Split("_")
            If (TextBox4.Text = mtn_key_t1(0)) Then
                TextBox5.Text = Change2(TextBox3.Text)
            Else
                MsgBox("密码错误")
            End If
        End If

    End Sub
End Class