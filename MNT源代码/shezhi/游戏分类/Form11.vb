Public Class Form11

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "选择图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim img As String = ""


        If (TextBox2.Text <> "") Then
            img += "Width='" + TextBox2.Text + "' "
        End If
        If (TextBox3.Text <> "") Then
            img += "Height='" + TextBox3.Text + "' "
        End If
        If TextBox1.Text <> "" Then
            img += "src='" + TextBox1.Text + "'"
        End If
        Form10.TextBox1.Text += "<img " + img + "></img>"
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class