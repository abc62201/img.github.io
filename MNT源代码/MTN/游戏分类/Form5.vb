Imports System.IO
Public Class Form5
    Dim 当前路径 As String

    Dim thumb_path_file As String = "kong"



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists(thumb_path) Then
            thumb_path_file = Me.Label10.Text

        Else
            thumb_path = "kong"
        End If
        If thumb_path = "kong" Then
            MsgBox("请选择展示图")
        Else

            Dim Sw As StreamWriter = File.CreateText(当前路径 + "\mtn_tool\upfile.xml")
            Dim xml_txt As String
            xml_txt = ""
            xml_txt = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " encoding=" + Chr(34) + "utf-8" + Chr(34) + "?>" + Chr(13)
            xml_txt += "<plp_yx_m>" + Chr(13)
            xml_txt += "<book>" + Chr(13)
            xml_txt += "<class_name>" + Label14.Text + "</class_name>" + Chr(13)
            xml_txt += "<classification>" + TextBox1.Text + "</classification>" + Chr(13)
            xml_txt += "<thumbnail>" + thumb_path_file.Replace("\\", "\") + "</thumbnail>" + Chr(13)
            If TextBox2.Text = "" Then
                TextBox2.Text = "kong"
            End If
            xml_txt += "<ch_name>" + TextBox2.Text + "</ch_name>" + Chr(13)
            If TextBox3.Text = "" Then
                TextBox3.Text = "kong"
            End If
            xml_txt += "<en_name>" + TextBox3.Text + "</en_name>" + Chr(13)
            If TextBox4.Text = "" Then
                TextBox4.Text = "kong"
            End If
            xml_txt += "<countries>" + TextBox4.Text + "</countries>" + Chr(13)
            If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt") Then
                Dim down_emu_path As TextReader = File.OpenText(当前路径 + "\mtn_tool\zip_file.txt")
                Dim zip_path As String = ""
                While down_emu_path.Peek() > -1
                    zip_path = down_emu_path.ReadLine
                    If My.Computer.FileSystem.FileExists(zip_path) Then
                        xml_txt += "<update_file_path>" + zip_path.Replace("\\", "\") + "</update_file_path>" + Chr(13)
                    End If
                End While
                down_emu_path.Close()
            End If
            If TextBox8.Text = "" Then
                TextBox8.Text = "kong"
            End If
            xml_txt += "<emulations>" + TextBox8.Text.Replace("\", "/") + "</emulations>" + Chr(13)
            If TextBox9.Text = "" Then
                TextBox9.Text = "kong"
            End If
            xml_txt += "<core>" + TextBox9.Text.Replace("\", "/") + "</core>" + Chr(13)
            If TextBox6.Text = "" Then
                TextBox6.Text = "kong"
            End If
            xml_txt += "<intro>" + TextBox6.Text + "</intro>" + Chr(13)
            If TextBox5.Text = "" Then
                TextBox5.Text = "kong"
            End If
            xml_txt += "<author>" + TextBox5.Text + "</author>" + Chr(13)
            If (Label14.Text = "game") Then
                xml_txt += "<other>" + Label9.Text + "</other>" + Chr(13)
            Else
                xml_txt += "<other>" + "kong" + "</other>" + Chr(13)
            End If

            xml_txt += "</book>" + Chr(13)
            xml_txt += "</plp_yx_m>"
            Sw.Write(xml_txt)
            Sw.Close()
            Shell(当前路径 + "\mtn_tool\mtn_update.bat")
            Me.Hide()
            Form3.Show()
        End If
    End Sub

    Private Sub Form5_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form3.Show()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        当前路径 = Application.StartupPath()
        TextBox2.Text = "kong"
        TextBox3.Text = "kong"
        TextBox4.Text = "kong"
        TextBox5.Text = "kong"
        TextBox6.Text = "kong"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim zip_path As String = ""
        If (System.Diagnostics.Process.GetProcessesByName("winrar").Length > 0) Or (System.Diagnostics.Process.GetProcessesByName("mtn_update").Length > 0) Then
            Label9.Text = "无法删除文件，请手动删除"
            Threading.Thread.Sleep(3000)
        Else
            If My.Computer.FileSystem.DirectoryExists(Mid(当前路径, 1, 3) + "temp") Then
                FileIO.FileSystem.DeleteDirectory(Mid(当前路径, 1, 3) + "temp", 5)
            End If
            Label9.Text = "删除压缩文件请稍等......"
            If My.Computer.FileSystem.FileExists(当前路径 + "\mtn_tool\zip_file.txt") Then

                FileIO.FileSystem.DeleteFile(当前路径 + "\mtn_tool\zip_file.txt")
            End If
        End If
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim thumb_dw_paht_html As String = ""
        OpenFileDialog1.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.jgp;*.png;*.jpeg;*.bmp;*.gif|All files(*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            thumb_path = OpenFileDialog1.FileName
            thumb_path_file = Mid(当前路径, 1, 3) + "temp\" + Format(DateTime.Now, "yyyyMMddhhmmss") + Path.GetExtension(thumb_path)
            File.Copy(thumb_path, thumb_path_file, True)
            Label10.Text = thumb_path_file
            thumb_dw_paht_html = 当前路径 + "\html\upanddw\tbumb\game\" + TextBox1.Text
            Call 建立文件夹(thumb_dw_paht_html)
            System.IO.File.Copy(thumb_path_file, thumb_dw_paht_html + "\" + Path.GetFileName(thumb_path_file), True)
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.Filter = "All files(*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox8.Text = Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        OpenFileDialog1.Filter = "All files(*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub 建立文件夹(ByVal 文件夹名 As String)
        If Not Directory.Exists(文件夹名) Then
            Directory.CreateDirectory(文件夹名)
        End If
    End Sub
End Class