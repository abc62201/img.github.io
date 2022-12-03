Imports System.IO
Public Class Form4
    Dim xml_txt As String
    Dim romp As String
    Dim rom_name As String
    Dim video_name As String
    Dim kadai_name As String
    Dim tu_name As String
    Dim intro_name As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.Label1.Text = Me.FolderBrowserDialog1.SelectedPath
            romp = "已选择"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.Label2.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.Label3.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.Label4.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim gamelist As String
        Dim fname As Integer
        fname = 0
        If (romp = "已选择" And TextBox1.Text <> "") Then
            If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
改名:
                gamelist = Me.FolderBrowserDialog1.SelectedPath + "\" + TextBox1.Text.Split(".")(0) + fname.ToString + ".xml"
                If My.Computer.FileSystem.FileExists(gamelist) Then
                    fname = fname + 1
                    GoTo 改名
                End If
                Dim Sw As StreamWriter = File.CreateText(gamelist)

                GetAllFile(Label1.Text)
                xml_txt += "</plp_yx_m>"
                Sw.Write(xml_txt, System.Text.Encoding.UTF8)
                Sw.Close()
                Form3.DataGridView1.CurrentRow.Cells(3).Value = gamelist
                Dim bak_txt() As String = File.ReadAllLines("bak_phat.txt")
                Dim bak_txt1 As String
                Dim bak_txt2 As String = ""
                Try
                    For i As Integer = 0 To bak_txt.Length - 1
                        bak_txt1 = bak_txt(i)
                        bak_txt2 = ""
                        If (InStr(bak_txt1, "[bak" + bak_ColumnIndex.ToString + "]") > 0) Then
                            bak_txt(i) = "[bak" + bak_ColumnIndex.ToString + "]"
                            bak_txt(i + 1) = "rom=" + Label1.Text
                            bak_txt(i + 2) = "thumb=" + Label3.Text
                            bak_txt(i + 3) = "video=" + Label2.Text
                            bak_txt(i + 4) = "cassette=" + Label4.Text
                            bak_txt(i + 5) = "intro=" + Label6.Text
                            bak_txt2 = "xiugai"
                            GoTo bak
                        End If
                    Next
bak:
                    If (bak_txt2 = "") Then
                        bak_txt2 += "[bak" + bak_ColumnIndex.ToString + "]" + Chr(13)
                        bak_txt2 += "rom=" + Label1.Text + Chr(13)
                        bak_txt2 += "thumb=" + Label3.Text + Chr(13)
                        bak_txt2 += "video=" + Label2.Text + Chr(13)
                        bak_txt2 += "cassette=" + Label4.Text + Chr(13)
                        bak_txt2 += "intro=" + Label6.Text + Chr(13)
                        bak_txt(bak_txt.Length - 1) = bak_txt2
                    End If
                    File.WriteAllLines("bak_phat.txt", bak_txt, System.Text.Encoding.UTF8)
                Catch ex As Exception

                End Try

                MsgBox("完成任务,记得点保存")
                Me.Hide()
                Form3.Show()

            End If
        Else
            MsgBox("请选择rom游戏文件夹或给列表起名")
        End If
    End Sub

    Private Sub Form4_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form3.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        romp = ""
        xml_txt = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " standalone=" + Chr(34) + "yes" + Chr(34) + "?>" + Chr(13)
        xml_txt += "<plp_yx_m>" + Chr(13)

        rom_name = ""
        video_name = ""
        kadai_name = ""
        tu_name = ""
        intro_name = ""
        Me.TextBox1.Text = ""
        Me.Label6.Text = "选择信息文件夹"
        Me.Label4.Text = "选择卡带文件夹"
        Me.Label3.Text = "选择图片文件夹"
        Me.Label2.Text = "选择视频文件夹"
        Me.Label1.Text = "选择rom文件夹"
    End Sub
    Private Sub GetAllFile(ByVal path As String)

        Dim strDir As String() = System.IO.Directory.GetDirectories(path)
        Dim strFile As String() = System.IO.Directory.GetFiles(path)
        Dim i As Integer
        Dim ceshi As String
        Dim arr() As String = {""}
        Dim file_ext_k As Boolean = True
        Try

            If (TextBox2.Text <> "") Then
                arr = TextBox2.Text.Split(";")
            End If
            If strFile.Length > 0 Then
                Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Minimum = 0
                Me.ProgressBar1.Maximum = strFile.Length - 1
                For i = 0 To strFile.Length - 1

                    If (TextBox2.Text = "" Or Array.FindIndex(arr, Function(s) s.Contains(System.IO.Path.GetExtension(strFile(i)))) >= 0) Then
                        file_ext_k = True
                    Else
                        file_ext_k = False
                    End If
                    If (System.IO.Path.GetExtension(strFile(i)) <> ".xml" And file_ext_k) Then


                        xml_txt += "<book>" + Chr(13)
                        xml_txt += "<rom>" + strFile(i).Replace(Application.StartupPath() + "\", "").Replace("&", "&amp;") + "</rom>" + Chr(13)
                        If (InStr(strFile(i), ".") > 0) Then
                            rom_name = System.IO.Path.GetFileName(strFile(i)).Replace(System.IO.Path.GetExtension(strFile(i)), "")
                        Else
                            rom_name = System.IO.Path.GetFileName(strFile(i))
                        End If
                        xml_txt += "<name>" + rom_name.Replace("&", "&amp;") + "</name>" + Chr(13)
                        ceshi = Label2.Text + rom_name + ".mp4"

                        If Label2.Text = "选择视频文件夹" Then
                            video_name = "kong"

                        ElseIf My.Computer.FileSystem.FileExists(Label2.Text + "\" + rom_name + ".mp4") Then
                            video_name = Label2.Text + "\" + rom_name + ".mp4"
                            video_name = video_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label2.Text + "\" + rom_name + ".avi") Then
                            video_name = Label2.Text + "\" + rom_name + ".avi"
                            video_name = video_name.Replace(Application.StartupPath() + "\", "")
                        Else
                            video_name = "kong"
                        End If
                        xml_txt += "<void>" + video_name.Replace("&", "&amp;") + "</void>" + Chr(13)

                        If Label4.Text = "选择卡带文件夹" Then
                            kadai_name = "kong"
                        ElseIf My.Computer.FileSystem.FileExists(Label4.Text + "\" + rom_name + ".png") Then
                            kadai_name = Label4.Text + "\" + rom_name + ".png"
                            kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label4.Text + "\" + rom_name + ".jpg") Then
                            kadai_name = Label4.Text + "\" + rom_name + ".jpg"
                            kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label4.Text + "\" + rom_name + ".jpeg") Then
                            kadai_name = Label4.Text + "\" + rom_name + ".jpeg"
                            kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label4.Text + "\" + rom_name + ".gif") Then
                            kadai_name = Label4.Text + "\" + rom_name + ".gif"
                            kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label4.Text + "\" + rom_name + ".bmp") Then
                            kadai_name = Label4.Text + "\" + rom_name + ".bmp"
                            kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        Else
                            kadai_name = "kong"
                        End If
                        xml_txt += "<kadai>" + kadai_name.Replace("&", "&amp;") + "</kadai>" + Chr(13)

                        If Label3.Text = "选择图片文件夹" Then
                            tu_name = "kong"
                        ElseIf My.Computer.FileSystem.FileExists(Label3.Text + "\" + rom_name + ".png") Then
                            tu_name = Label3.Text + "\" + rom_name + ".png"
                            tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label3.Text + "\" + rom_name + ".jpg") Then
                            tu_name = Label3.Text + "\" + rom_name + ".jpg"
                            tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label3.Text + "\" + rom_name + ".jpeg") Then
                            tu_name = Label3.Text + "\" + rom_name + ".jpeg"
                            tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label3.Text + "\" + rom_name + ".gif") Then
                            tu_name = Label3.Text + "\" + rom_name + ".gif"
                            tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        ElseIf My.Computer.FileSystem.FileExists(Label3.Text + "\" + rom_name + ".bmp") Then
                            tu_name = Label3.Text + "\" + rom_name + ".bmp"
                            tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        Else
                            tu_name = "kong"
                        End If
                        If Label6.Text = "选择信息文件夹" Then
                            intro_name = "kong"

                        ElseIf My.Computer.FileSystem.FileExists(Label6.Text + "\" + rom_name + ".txt") Then
                            intro_name = Label6.Text + "\" + rom_name + ".txt"
                            intro_name = intro_name.Replace(Application.StartupPath() + "\", "")
                        Else
                            intro_name = "kong"
                        End If
                        xml_txt += "<mig>" + tu_name.Replace("&", "&amp;") + "</mig>" + Chr(13)
                        xml_txt += "<emu>" + "kong" + "</emu>" + Chr(13)
                        xml_txt += "<intro>" + intro_name.Replace("&", "&amp;") + "</intro>" + Chr(13)
                        xml_txt += "</book>" + Chr(13)
                        Me.ProgressBar1.Value = i
                    End If
                Next

            End If
            If strDir.Length > 0 Then
                For i = 0 To strDir.Length - 1

                    GetAllFile(strDir(i))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.Label6.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class