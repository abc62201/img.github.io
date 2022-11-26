Public Class Form12

    Private Sub Form12_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If (Label4.Text = "2") Then
            Form2.Show()
            Form2.WebBrowser1.Document.InvokeScript("shengyin")
        End If
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ces_txt As String = ""
        Dim 当前路径 As String = ""
        当前路径 = Application.StartupPath()
        ces_txt += "第一次运行请点否查看是否正常现在是"
        ces_txt += "如不能正常请下载相应工具" + Chr(13)
        ces_txt += "百度网盘下载（统一密码：1234）"
        Label1.Text = ces_txt
        Label2.Text = "运行必须工具"
        Button1.Text = "IE11浏览器"
        Button2.Text = ".NET4.5"
        Label3.Text = "非必须工具,解压到MNT文件下（根目录）"
        Button3.Text = "游戏分享和下载"
        Button4.Text = "游戏资源下载"
        Button5.Text = "实时攻略需要的文件"
        CheckBox1.Text = "已经正常显示取消烦人的窗口"
        Dim jiance As String
        jiance = New String(CChar(" "), 128)
        GetPrivateProfileString("Startup file", "detection", "detection", jiance, 128, 当前路径 + "\config.ini")
        jiance = 首尾删除空格(jiance)
        If jiance = "0" Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShellExecute(0, "open", "https://pan.baidu.com/s/1kD8Ssk6rdp5riIxH-QNlhg?pwd=1234", "", "", 1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ShellExecute(0, "open", "https://pan.baidu.com/s/1hNnY_VxPExJ_HcLCFCnFSQ?pwd=1234 ", "", "", 1)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim 当前路径 As String = ""
        当前路径 = Application.StartupPath()
        If (CheckBox1.Checked) Then
            WritePrivateProfileString("Startup file", "detection", 1.ToString, 当前路径 + "\config.ini")
        Else
            WritePrivateProfileString("Startup file", "detection", 0.ToString, 当前路径 + "\config.ini")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ShellExecute(0, "open", "https://pan.baidu.com/s/1Rc6RrqriRZ10ZQWZlWKIIA?pwd=1234 ", "", "", 1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShellExecute(0, "open", "https://pan.baidu.com/s/1vUmjNWjxkfjA4a_qv6j9OQ?pwd=1234  ", "", "", 1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ShellExecute(0, "open", "https://pan.baidu.com/s/1HWJtb_YXNtsKktERIqucow?pwd=1234 ", "", "", 1)
    End Sub
End Class