Imports System.Net
Imports System.IO

Imports System.Text

Public Class Form9
   

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = web_ziti_color
        TextBox2.Text = web_a_color
        TextBox3.Text = web_a_bgcolor
        TextBox4.Text = web_az_color
        TextBox5.Text = web_az_bgcolor
        TextBox6.Text = web_intro_color
        TextBox7.Text = web_intro_bgcolor
        'TextBox8.Text = web_intro_bgcolor
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox1.Text = s_color
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "背景图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox8.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox2.Text = s_color
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox3.Text = s_color
        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox4.Text = s_color
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox5.Text = s_color
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox6.Text = s_color
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim s_color As String
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            s_color = Hex(ColorDialog1.Color.ToArgb).ToString
            s_color = "#" + s_color.Substring(s_color.Length - 6)
            TextBox7.Text = s_color
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim gamerom_bj_txt1 As String
        Dim gamerom_bj_txt2 As String = ""
        Dim gamerom_bj_txt3 As String = ""
        Dim gamerom_bj_l As String = ""
        Dim 当前路径 As String
        当前路径 = Application.StartupPath()


        gamerom_bj_txt1 = TextBox8.Text
        gamerom_bj_txt1 = gamerom_bj_txt1.Replace(当前路径 + "\", "..\")
        gamerom_bj_l = Path.GetFileName(Label2.Text).Replace(".xml", "")
        gamerom_bj_l = gamerom_bj_l + "_" + Label3.Text
        If My.Computer.FileSystem.FileExists(当前路径 + "\gamerom_bj.txt") Then
            Dim gamerom_bj_txt() As String = File.ReadAllLines("gamerom_bj.txt")
            For i As Integer = 0 To gamerom_bj_txt.Length - 1
                gamerom_bj_txt2 = gamerom_bj_txt(i)
                If (InStr(gamerom_bj_txt2, gamerom_bj_l) > 0) Then
                    gamerom_bj_txt(i) = gamerom_bj_l + "=" + gamerom_bj_txt1 _
                        + ";" + TextBox1.Text + ";" + TextBox2.Text + ";" + TextBox3.Text + ";" + TextBox4.Text _
                        + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text
                    gamerom_bj_txt3 = "xiugai"
                    GoTo gamerom_bj_name
                End If
            Next
gamerom_bj_name:
            If gamerom_bj_txt3 = "" Then
                If (gamerom_bj_txt.Length = 0) Then
                    ReDim Preserve gamerom_bj_txt(0)
                    gamerom_bj_txt(gamerom_bj_txt.Length - 1) = gamerom_bj_l + "=" + gamerom_bj_txt1 _
                        + ";" + TextBox1.Text + ";" + TextBox2.Text + ";" + TextBox3.Text + ";" + TextBox4.Text _
                        + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text + Chr(13)
                Else
                    gamerom_bj_txt(gamerom_bj_txt.Length - 1) = gamerom_bj_l + "=" + gamerom_bj_txt1 _
                         + ";" + TextBox1.Text + ";" + TextBox2.Text + ";" + TextBox3.Text + ";" + TextBox4.Text _
                         + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text + Chr(13)
                End If


            End If
            File.WriteAllLines(当前路径 + "\gamerom_bj.txt", gamerom_bj_txt, System.Text.Encoding.UTF8)

        Else
            Dim gamerom_bj_txt As StreamWriter = File.CreateText(当前路径 + "\gamerom_bj.txt")
            gamerom_bj_l = gamerom_bj_l + "=" + gamerom_bj_txt1 _
                        + ";" + TextBox1.Text + ";" + TextBox2.Text + ";" + TextBox3.Text + ";" + TextBox4.Text _
                        + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text + Chr(13)
            gamerom_bj_txt.Write(gamerom_bj_l, System.Text.Encoding.UTF8)
            gamerom_bj_txt.Close()
        End If
        MsgBox("添加成功")
    End Sub
End Class