Imports System.IO
Imports System.Text

Public Class Form10
    Dim 当前路径 As String
    Dim gl_web_txt As String() = {""}
    Dim gl_img_txt As String() = {""}
    Dim gl_web_index As Integer = 0

    Private Sub Form10_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form3.Show()

    End Sub
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        当前路径 = Application.StartupPath() '初始路径
        WebBrowser1.ObjectForScripting = Me
        Dim winx As Integer = 0
        Dim winy As Integer = 0
        Me.Location = New Point(0, 0)
        winx = SystemInformation.PrimaryMonitorSize.Width
        winy = SystemInformation.PrimaryMonitorSize.Height
        Me.WebBrowser1.Height = winy * 0.8
        WebBrowser1.Width = winx * 0.2
        WebBrowser1.Location = New Point(winx * 0.8, 0)
        WebBrowser2.Width = winx
        WebBrowser2.Height = winy * 0.2
        WebBrowser2.Location = New Point(0, winy * 0.8)
        TextBox1.Location = New Point(0, winy * 0.1)
        Me.TextBox1.Width = winx * 0.8
        TextBox1.Height = winy * 0.7
        Button1.Location = New Point(10, winy * 0.05)
        Button2.Location = New Point(100, winy * 0.05)
        Button3.Location = New Point(200, winy * 0.05)
        Button4.Location = New Point(300, winy * 0.05)
        Button4.Enabled = False
        Button5.Location = New Point(400, winy * 0.05)
        Button8.Location = New Point(500, winy * 0.05)
        Button6.Location = New Point(600, winy * 0.05)
        Button7.Location = New Point(700, winy * 0.05)
        Label2.Location = New Point(20, 10)
        Label2.Text = "第" + (gl_web_index + 1).ToString + "页"
        Dim gl_file_name As String = ""
        Dim gl_file_path As String = ""
        gl_file_name = Path.GetFileNameWithoutExtension(Label1.Text)
        gl_file_path = Path.GetDirectoryName(Label1.Text)
        WebBrowser1.Navigate(当前路径 + "\Raiders\Raiders1.html")
        WebBrowser2.Navigate(当前路径 + "\Raiders\advertising1.html")
        If My.Computer.FileSystem.FileExists(gl_file_path + "\" + gl_file_name + "\" + gl_file_name + ".txt") Then
            Dim rom_file_gl As TextReader = File.OpenText(gl_file_path + "\" + gl_file_name + "\" + gl_file_name + ".txt")
            gl_web_txt = rom_file_gl.ReadToEnd.Split({"[MTN_GL]"}, StringSplitOptions.None)
            gl_web_txt = RemoveAt(gl_web_txt, 0)
            'TextBox1.Text = gl_web_txt(gl_web_index)
            rom_file_gl.Close()
        End If
    End Sub
    Public Sub gl_txt()
        TextBox1.Text = gl_web_txt(gl_web_index)
    End Sub
    Private Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException( _
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            Return outArr
        End If
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        WebBrowser1.Document.GetElementById("zhu").InnerHtml = TextBox1.Text

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form11.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim html_font_color As String = ""
        Dim html_qian_txt As String = ""
        Dim html_hou_txt As String = ""
        Dim txt_qing As Integer = 0
        Dim txt_hou As Integer = 0
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            txt_qing = TextBox1.SelectionStart
            txt_hou = TextBox1.SelectionLength + txt_qing
            html_font_color = Hex(FontDialog1.Color.ToArgb).ToString
            html_font_color = html_font_color.Substring(html_font_color.Length - 6)
            html_qian_txt += "<p style='color:#" + html_font_color + "; "
            html_qian_txt += "font-size:" + FontDialog1.Font.Size.ToString + "pt;"
            html_qian_txt += "font-family:" + Chr(32) + FontDialog1.Font.Name + Chr(32) + ";'>"
            html_hou_txt = "</p>"
            TextBox1.Text = TextBox1.Text.Insert(txt_hou, html_hou_txt)
            TextBox1.Text = TextBox1.Text.Insert(txt_qing, html_qian_txt)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = TextBox1.Text.Insert(TextBox1.SelectionStart, "<br>")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        gl_web_txt(gl_web_index) = TextBox1.Text
        gl_web_index = gl_web_index + 1
        If (gl_web_index > gl_web_txt.Length - 1) Then
            ReDim Preserve gl_web_txt(gl_web_index)
            TextBox1.Text = ""
        End If
        Button4.Enabled = True
        Label2.Text = "第" + (gl_web_index + 1).ToString + "页"
        TextBox1.Text = gl_web_txt(gl_web_index)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gl_web_txt(gl_web_index) = TextBox1.Text
        gl_web_index = gl_web_index - 1
        If (gl_web_index = 0) Then
            Button4.Enabled = False
        End If
        TextBox1.Text = gl_web_txt(gl_web_index)
        Label2.Text = "第" + (gl_web_index + 1).ToString + "页"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim gl_file_name As String = ""
        Dim gl_file_path As String = ""
        Dim gl_file_txt As String = ""
        If My.Computer.FileSystem.FileExists(Label1.Text) Then
            gl_file_name = Path.GetFileNameWithoutExtension(Label1.Text)
            gl_file_path = Path.GetDirectoryName(Label1.Text)
            Call 建立文件夹(gl_file_path + "\" + gl_file_name)
            gl_web_txt(gl_web_index) = TextBox1.Text
            For i = 0 To gl_web_txt.Length - 1
                If (gl_web_txt(i) <> "") Then
                    gl_file_txt += "[MTN_GL]" + gl_web_txt(i)
                End If
            Next

            File.WriteAllText(gl_file_path + "\" + gl_file_name + "\" + gl_file_name + ".txt", gl_file_txt, Encoding.UTF8)
        Else
            MsgBox("游戏rom不存在")
        End If
    End Sub
    Private Sub 建立文件夹(ByVal 文件夹名 As String)
        If Not Directory.Exists(文件夹名) Then
            Directory.CreateDirectory(文件夹名)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("请截取游戏关键位置")
        Dim a As Long
        Dim gl_file_name As String = ""
        Dim gl_file_path As String = ""
        Dim gl_img As String = ""
        Dim gl_img_file As String = ""
        If My.Computer.FileSystem.FileExists(Label1.Text) Then
            gl_file_name = Path.GetFileNameWithoutExtension(Label1.Text)
            gl_file_path = Path.GetDirectoryName(Label1.Text)
            Me.Hide()
            Threading.Thread.Sleep(300)
            a = QQDLL.CameraSubArea(0)
            Me.Show()
            If a > 0 Then
                Dim jieping As Image
                jieping = My.Computer.Clipboard.GetImage
                gl_img = gl_file_path + "\" + gl_file_name + "\" + "MTN_gl_img_" + gl_web_index.ToString + ".png"
                gl_img_file = gl_file_path + "\" + gl_file_name + "\" + "MTN_gl_img.txt"
                jieping.Save(gl_img)
                ReDim Preserve gl_img_txt(gl_web_index)
                gl_img_txt(gl_web_index) = "[img]" + gl_img
                File.WriteAllLines(gl_img_file, gl_img_txt)
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (gl_web_txt.Length > gl_web_index) Then
            gl_web_txt = RemoveAt(gl_web_txt, gl_web_index)
            If (gl_web_txt.Length > gl_web_index) Then
                TextBox1.Text = gl_web_txt(gl_web_index)
            Else
                ReDim Preserve gl_web_txt(gl_web_index)
                TextBox1.Text = ""
            End If

        End If

    End Sub
End Class