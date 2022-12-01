Imports System
Imports System.IO

Public Class Form14
    Dim xmlnodes As Xml.XmlNodeList
    Dim xml_index As Integer = -1
    Dim index_rom() As Integer
    Dim 当前路径 As String
    Dim pics_path_1 As String = ""
    Dim s_vp_index As Integer = 0
    Dim s_pic_index As Integer = 0

    Private Sub Form14_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ListBox1.Items.Clear()
        Me.Hide()
        Form3.Show()
    End Sub
    Private Function file_f(ByVal str1 As String) As Boolean
            file_f = My.Computer.FileSystem.FileExists(str1)
    End Function
    Private Function file_img(ByVal str1 As String)
        Dim memoryStream_start As New MemoryStream()
        Using Fs As New System.IO.FileStream(str1, IO.FileMode.Open, IO.FileAccess.Read)
            Dim Buff(Fs.Length - 1) As Byte
            Fs.Read(Buff, 0, Fs.Length - 1)
            memoryStream_start.Write(Buff, 0, Buff.Length - 1)
            Return Image.FromStream(memoryStream_start)
        End Using

    End Function
    Private Function file_rom(ByVal str1 As String) As Boolean
        If CheckBox9.Checked = False Then
            file_rom = file_f(str1)
        Else
            file_rom = True
        End If
    End Function
    Private Function file_video(ByVal str1 As String) As Boolean
        If CheckBox4.Checked = False Then
            file_video = file_f(str1)
        Else
            file_video = True
        End If
    End Function
    Private Function file_cassette(ByVal str1 As String) As Boolean
        If CheckBox6.Checked = False Then
            file_cassette = file_f(str1)
        Else
            file_cassette = True
        End If
    End Function
    Private Function file_theme(ByVal str1 As String) As Boolean
        If CheckBox5.Checked = False Then
            file_theme = file_f(str1)
        Else
            file_theme = True
        End If
    End Function
    Private Function file_intro1(ByVal str1 As String) As Boolean
        If CheckBox7.Checked = False Then
            file_intro1 = file_f(str1)
        Else
            file_intro1 = True
        End If
    End Function
    Private Function file_intro2(ByVal str1 As String) As Boolean
        If CheckBox8.Checked = False Then
            file_intro2 = file_f(str1)
        Else
            file_intro2 = True
        End If
    End Function
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index_re As Integer = 0
        Dim game_name As String
        Dim game_dr As String
        Dim game_intro As String
        当前路径 = Application.StartupPath()

        Me.Width = SystemInformation.PrimaryMonitorSize.Width * 0.6
        Me.Height = SystemInformation.PrimaryMonitorSize.Height * 0.8
        xmlnodes = duxml(Label1.Text, "book")
        ListBox1.Width = 300
        ListBox1.Height = Me.Height * 0.95
        For i = 0 To xmlnodes.Count - 1
            game_name = Path.GetFileNameWithoutExtension(xmlnodes(i).ChildNodes(0).InnerText)
            game_dr = Path.GetDirectoryName(xmlnodes(i).ChildNodes(0).InnerText)
            game_intro = game_dr + "\" + game_name + "\" + game_name + ".txt"
            If (file_rom(xmlnodes(i).ChildNodes(0).InnerText) And file_video(xmlnodes(i).ChildNodes(2).InnerText) And file_cassette(xmlnodes(i).ChildNodes(3).InnerText) And _
                 file_theme(xmlnodes(i).ChildNodes(4).InnerText) And file_intro1(xmlnodes(i).ChildNodes(6).InnerText) And file_intro2(game_intro)) Then
            Else
                ReDim Preserve index_rom(index_re)
                index_rom(index_re) = i
                ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
                index_re = index_re + 1
            End If
        Next

        'WebBrowser1.Location = New Point(winx * 0.8, 0)
        TextBox1.Location = New Point(306, 44)
        Panel1.Location = New Point(306, 71)
        CheckBox1.Location = New Point(306, 12)
        CheckBox2.Location = New Point(432, 12)
        CheckBox3.Location = New Point(534, 12)
        Button1.Location = New Point(307, Me.Height * 0.9)
        Button2.Location = New Point(768, Me.Height * 0.9)
        Label2.Location = New Point(25, 25)
        Panel2.Location = New Point(548, 71)
        Label3.Location = New Point(546, 47)
        TextBox3.Location = New Point(548, 216)
        Panel5.Location = New Point(745, 71)
        Label7.Location = New Point(743, 44)
        TextBox5.Location = New Point(745, 216)

        Panel3.Location = New Point(307, 271 + 50)
        Label4.Location = New Point(305, 247 + 50)
        TextBox4.Location = New Point(307, 425 + 50)
        Panel4.Location = New Point(520, 539 + 50)
        Label5.Location = New Point(468, 247 + 50)
        TextBox6.Location = New Point(470, 501 + 50)
        WebBrowser1.Location = New Point(470, 262 + 50)
        Panel6.Location = New Point(745, 271 + 50)
        Label6.Location = New Point(743, 247 + 50)
        TextBox7.Location = New Point(745, 425 + 50)

        Panel7.Location = New Point(307, 501 + 50)
        Panel1.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel2.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel3.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel4.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel5.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel6.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel7.BackgroundImage = Image.FromFile("theme\file.jpg")

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        WebBrowser1.Navigate(Path.GetFullPath("theme\video.html"))

    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown

        Dim xmldellist As Xml.XmlNodeList
        Dim yesno As Integer
        Dim ds As New DataSet
        Dim index_re As Integer = 0
        Dim game_name As String
        Dim game_dr As String
        Dim game_intro As String
        If (e.KeyCode = Keys.Delete) Then
            yesno = MsgBox("是否要删除", MsgBoxStyle.YesNo)
            If yesno = 6 Then
                If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(0).InnerText())) Then
                    My.Computer.FileSystem.DeleteFile(xmlnodes(xml_index).ChildNodes(0).InnerText())
                End If
                If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(2).InnerText())) Then
                    My.Computer.FileSystem.DeleteFile(xmlnodes(xml_index).ChildNodes(2).InnerText())
                End If
                If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(3).InnerText())) Then
                    My.Computer.FileSystem.DeleteFile(xmlnodes(xml_index).ChildNodes(3).InnerText())
                End If
                If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(4).InnerText())) Then
                    My.Computer.FileSystem.DeleteFile(xmlnodes(xml_index).ChildNodes(4).InnerText())
                End If
                If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(6).InnerText())) Then
                    My.Computer.FileSystem.DeleteFile(xmlnodes(xml_index).ChildNodes(6).InnerText())
                End If
                xmldellist = duxml(Label1.Text, "plp_yx_m")
                xmldellist(0).RemoveChild(xmldellist(0).ChildNodes(xml_index))
                doc.Save(Label1.Text)
            End If
            xmlnodes = duxml(Label1.Text, "book")
            ListBox1.Items.Clear()
            For i = 0 To xmlnodes.Count - 1
                game_name = Path.GetFileNameWithoutExtension(xmlnodes(i).ChildNodes(0).InnerText)
                game_dr = Path.GetDirectoryName(xmlnodes(i).ChildNodes(0).InnerText)
                game_intro = game_dr + "\" + game_name + "\" + game_name + ".txt"
                If (file_rom(xmlnodes(i).ChildNodes(0).InnerText) And file_video(xmlnodes(i).ChildNodes(2).InnerText) And file_cassette(xmlnodes(i).ChildNodes(3).InnerText) And _
                     file_theme(xmlnodes(i).ChildNodes(4).InnerText) And file_intro1(xmlnodes(i).ChildNodes(6).InnerText) And file_intro2(game_intro)) Then
                Else
                    ReDim Preserve index_rom(index_re)
                    index_rom(index_re) = i
                    ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
                    index_re = index_re + 1
                End If
            Next

            If (Array.FindIndex(index_rom, Function(s) s = xml_index) <= ListBox1.Items.Count - 1 And Array.FindIndex(index_rom, Function(s) s = xml_index) >= 0) Then
                Try
                    ListBox1.SelectedIndex = Array.FindIndex(index_rom, Function(s) s = xml_index)
                Catch ex As Exception
                    ListBox1.SelectedIndex = -1
                End Try

            Else
                Try
                    ListBox1.SelectedIndex = 0
                Catch ex As Exception
                    ListBox1.SelectedIndex = -1
                End Try
            End If
            ds.ReadXml(Label1.Text)
            Form3.DataGridView2.DataSource = ds
        End If
    End Sub



    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        ' MsgBox(ListBox1.SelectedValue)
        Dim game_name As String
        Dim game_dr As String
        Dim game_intro As String
        xml_index = index_rom(ListBox1.SelectedIndex)
        TextBox1.Text = ListBox1.Text
        TextBox2.Text = xmlnodes(xml_index).ChildNodes(0).InnerText
        game_name = Path.GetFileNameWithoutExtension(TextBox2.Text)
        game_dr = Path.GetDirectoryName(TextBox2.Text)
        ' MsgBox(game_dr + "\" + game_name + "\" + game_name + ".txt")
        game_intro = game_dr + "\" + game_name + "\" + game_name + ".txt"
        If (TextBox2.Text <> "kong" And My.Computer.FileSystem.FileExists(TextBox2.Text)) Then
            Panel1.BackgroundImage = Image.FromFile("theme\file.jpg")
        Else
            Panel1.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If
        TextBox6.Text = xmlnodes(xml_index).ChildNodes(2).InnerText
        If (My.Computer.FileSystem.FileExists(xmlnodes(xml_index).ChildNodes(2).InnerText)) Then
            WebBrowser1.Document.All("bvid").SetAttribute("src", Path.GetFullPath(xmlnodes(xml_index).ChildNodes(2).InnerText))
            Panel4.BackgroundImage = Image.FromFile("theme\file.jpg")
        Else
            WebBrowser1.Document.All("bvid").SetAttribute("src", Path.GetFullPath("theme\file1.jpg"))
            Panel4.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If
        TextBox3.Text = xmlnodes(xml_index).ChildNodes(4).InnerText
        If (TextBox3.Text <> "kong" And My.Computer.FileSystem.FileExists(TextBox3.Text)) Then
            Panel2.BackgroundImage = file_img(xmlnodes(xml_index).ChildNodes(4).InnerText)
        Else
            Panel2.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If
        TextBox5.Text = xmlnodes(xml_index).ChildNodes(3).InnerText
        If (TextBox5.Text <> "kong" And My.Computer.FileSystem.FileExists(TextBox5.Text)) Then
            Panel5.BackgroundImage = file_img(xmlnodes(xml_index).ChildNodes(3).InnerText)
        Else
            Panel5.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If
        TextBox4.Text = xmlnodes(xml_index).ChildNodes(5).InnerText
        TextBox7.Text = xmlnodes(xml_index).ChildNodes(6).InnerText
        If (TextBox7.Text <> "kong" And My.Computer.FileSystem.FileExists(TextBox7.Text)) Then
            Panel6.BackgroundImage = Image.FromFile("theme\file.jpg")
        Else
            Panel6.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If
        If (game_intro <> "kong" And My.Computer.FileSystem.FileExists(game_intro)) Then
            Panel7.BackgroundImage = Image.FromFile("theme\file.jpg")
        Else
            Panel7.BackgroundImage = Image.FromFile("theme\file1.jpg")
        End If

    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "游戏rom|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox2.Text = 文件
        End If
    End Sub

    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            ' For Each file As String In filePath
            文件 = filePath(0)

            'Me.TextBox1.Text = 文件
            Me.TextBox2.Text = 文件 'Replace(Application.StartupPath() + "\", "")



            ' Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Panel2_DoubleClick(sender As Object, e As EventArgs) Handles Panel2.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox3.Text = 文件
            Panel2.BackgroundImage = Image.FromFile(文件)
        End If
    End Sub
    Private Sub Panel2_DragDrop(sender As Object, e As DragEventArgs) Handles Panel2.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox3.Text = 文件
            Panel2.BackgroundImage = Image.FromFile(文件)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel2_DragEnter(sender As Object, e As DragEventArgs) Handles Panel2.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Panel3_DoubleClick(sender As Object, e As EventArgs) Handles Panel3.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "模拟器或ra核心|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox4.Text = 文件
        End If
    End Sub
    Private Sub Panel3_DragDrop(sender As Object, e As DragEventArgs) Handles Panel3.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox4.Text = 文件

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel3_DragEnter(sender As Object, e As DragEventArgs) Handles Panel3.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Panel6_DoubleClick(sender As Object, e As EventArgs) Handles Panel6.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "信息|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox7.Text = 文件
        End If
    End Sub
    Private Sub Panel6_DragDrop(sender As Object, e As DragEventArgs) Handles Panel6.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox7.Text = 文件

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel6_DragEnter(sender As Object, e As DragEventArgs) Handles Panel6.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Panel5_DoubleClick(sender As Object, e As EventArgs) Handles Panel5.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "图片|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox5.Text = 文件
            Panel5.BackgroundImage = Image.FromFile(文件)
        End If
    End Sub
    Private Sub Panel5_DragDrop(sender As Object, e As DragEventArgs) Handles Panel5.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox5.Text = 文件
            Panel5.BackgroundImage = Image.FromFile(文件)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel5_DragEnter(sender As Object, e As DragEventArgs) Handles Panel5.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Label2_DoubleClick(sender As Object, e As EventArgs) Handles Label2.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "游戏rom|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox2.Text = 文件
        End If
    End Sub

    Private Sub Panel4_DoubleClick(sender As Object, e As EventArgs) Handles Panel4.DoubleClick
        Dim 文件 As String = ""
        OpenFileDialog1.Filter = "视频|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            文件 = OpenFileDialog1.FileName
            Me.TextBox6.Text = 文件 'Replace(Application.StartupPath() + "\", "")
            WebBrowser1.Document.All("bvid").SetAttribute("src", 文件)
        End If
    End Sub
    Private Sub Panel4_DragDrop(sender As Object, e As DragEventArgs) Handles Panel4.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            ' For Each file As String In filePath
            文件 = filePath(0)

            'Me.TextBox1.Text = 文件
            Me.TextBox6.Text = 文件 'Replace(Application.StartupPath() + "\", "")
            WebBrowser1.Document.All("bvid").SetAttribute("src", 文件)
            ' Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel4_DragEnter(sender As Object, e As DragEventArgs) Handles Panel4.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function file_w(ByVal str1 As String, ByVal str2 As String)
        Dim str3 As String = str1

        If CheckBox1.Checked And str1 <> str2 And My.Computer.FileSystem.FileExists(str1) Then
            Dim showUI As FileIO.UIOption = FileIO.UIOption.AllDialogs
            If My.Computer.FileSystem.FileExists(str2) Then
                System.IO.File.Delete(str2)
            End If
        End If

        If CheckBox3.Checked And str1 <> str2 And My.Computer.FileSystem.FileExists(str1) Then
            Dim showUI As FileIO.UIOption = FileIO.UIOption.AllDialogs
            If (Directory.Exists(Path.GetDirectoryName(str2))) Then
                str3 = Path.GetDirectoryName(str2) + "\" + Path.GetFileName(str1)

                If Not My.Computer.FileSystem.FileExists(str3) And Path.GetDirectoryName(str1) <> Path.GetDirectoryName(str2) Then
                    My.Computer.FileSystem.CopyFile(str1, Path.GetDirectoryName(str2) + "\" + Path.GetFileName(str1), showUI)
                End If


            End If
        End If

        If CheckBox2.Checked And str1 <> str2 Then
            Dim showUI As FileIO.UIOption = FileIO.UIOption.AllDialogs
            If My.Computer.FileSystem.FileExists(str1) Then
                System.IO.File.Delete(str1)
            End If
        End If

        Return str3
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim index_re As Integer = 0
        Dim game_name As String
        Dim game_dr As String
        Dim game_intro As String
        If (xml_index = -1) Then
            MsgBox("未选择游戏")
        Else
            xmlnodes(xml_index).ChildNodes(0).InnerText = file_w(TextBox2.Text, xmlnodes(xml_index).ChildNodes(0).InnerText).Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(0).InnerText = TextBox2.Text
            xmlnodes(xml_index).ChildNodes(1).InnerText = TextBox1.Text
            'xmlnodes(xml_index).ChildNodes(2).InnerText = TextBox6.Text
            xmlnodes(xml_index).ChildNodes(2).InnerText = file_w(TextBox6.Text, xmlnodes(xml_index).ChildNodes(2).InnerText).Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(3).InnerText = TextBox5.Text
            xmlnodes(xml_index).ChildNodes(3).InnerText = file_w(TextBox5.Text, xmlnodes(xml_index).ChildNodes(3).InnerText).Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(4).InnerText = TextBox3.Text
            xmlnodes(xml_index).ChildNodes(4).InnerText = file_w(TextBox3.Text, xmlnodes(xml_index).ChildNodes(4).InnerText).Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(5).InnerText = TextBox4.Text
            xmlnodes(xml_index).ChildNodes(5).InnerText = file_w(TextBox4.Text, xmlnodes(xml_index).ChildNodes(5).InnerText).Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(6).InnerText = TextBox7.Text
            xmlnodes(xml_index).ChildNodes(6).InnerText = file_w(TextBox7.Text, xmlnodes(xml_index).ChildNodes(6).InnerText).Replace(Application.StartupPath() + "\", "")
            doc.Save(Label1.Text)
            xmlnodes = duxml(Label1.Text, "book")
            ListBox1.Items.Clear()
            For i = 0 To xmlnodes.Count - 1
                game_name = Path.GetFileNameWithoutExtension(xmlnodes(i).ChildNodes(0).InnerText)
                game_dr = Path.GetDirectoryName(xmlnodes(i).ChildNodes(0).InnerText)
                game_intro = game_dr + "\" + game_name + "\" + game_name + ".txt"
                If (file_rom(xmlnodes(i).ChildNodes(0).InnerText) And file_video(xmlnodes(i).ChildNodes(2).InnerText) And file_cassette(xmlnodes(i).ChildNodes(3).InnerText) And _
                     file_theme(xmlnodes(i).ChildNodes(4).InnerText) And file_intro1(xmlnodes(i).ChildNodes(6).InnerText) And file_intro2(game_intro)) Then
                Else
                    ReDim Preserve index_rom(index_re)
                    index_rom(index_re) = i
                    ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
                    index_re = index_re + 1
                End If
            Next
            If (xml_index > 0 And Array.FindIndex(index_rom, Function(s) s = xml_index) >= 0) Then
                Try
                    ListBox1.SelectedIndex = Array.FindIndex(index_rom, Function(s) s = xml_index)
                Catch ex As Exception
                    ListBox1.SelectedIndex = -1
                End Try

            Else
                ListBox1.SelectedIndex = 0
            End If
            ds.ReadXml(Label1.Text)
            Form3.DataGridView2.DataSource = ds
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Panel7_DoubleClick(sender As Object, e As EventArgs) Handles Panel7.DoubleClick
        Dim gl_rom_path As String = ""
        gl_rom_path = TextBox2.Text
            If (gl_rom_path <> "" And Path.GetExtension(gl_rom_path) <> ".xml") Then
            Form10.Label1.Text = gl_rom_path
            Form10.Label3.Text = "14"
            Form10.Show()
            Me.Hide()
        End If
    End Sub


    Private Sub Label9_DoubleClick(sender As Object, e As EventArgs) Handles Label9.DoubleClick
        Dim gl_rom_path As String = ""
        gl_rom_path = TextBox2.Text
        If (gl_rom_path <> "" And Path.GetExtension(gl_rom_path) <> ".xml") Then
            Form10.Label1.Text = gl_rom_path
            Form10.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim s_pic_txt As String = ""
        Dim s_pic_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then


            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个搜图窗口")
            Else
                If (xml_index > -1) Then
                    s_pic_txt = Path.GetFileNameWithoutExtension(TextBox2.Text)
                    pics_path_1 = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/Photos/" + s_pic_txt + ".txt"
                    s_pic_path = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/Photos/" + s_pic_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + Form3.ComboBox1.Text + "/Photos/")
                    s_pic_index = xml_index.ToString + Chr(13)
                    s_pic_path += TextBox1.Text + Chr(13)
                    s_pic_path += 1.ToString + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/Photos" + Chr(13)
                    s_pic_path += s_pic_txt + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/Photos" + Chr(13)
                    s_pic_path += 1.ToString + Chr(13)
                    s_pic_path += 当前路径 + "/" + Label1.Text + Chr(13)
                    s_pic_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/thumb" + Chr(13)
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_pic_path)
                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 1
                    Me.Timer1.Enabled = True
                End If
            End If

        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub
    Private Sub 建立文件夹(ByVal 文件夹名 As String)
        If Not Directory.Exists(文件夹名) Then
            Directory.CreateDirectory(文件夹名)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim s_picsp_txt As String = ""
        Dim s_picsp_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then

            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (xml_index > -1) Then
                    s_picsp_txt = Path.GetFileNameWithoutExtension(TextBox2.Text)
                    pics_path_1 = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt"
                    s_picsp_path = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/CPhotos/" + s_picsp_txt + ".txt" + Chr(13)
                    Call 建立文件夹(当前路径 + "/rom/" + Form3.ComboBox1.Text + "/CPhotos/")
                    s_pic_index = xml_index.ToString + Chr(13)
                    s_picsp_path += TextBox1.Text + Chr(13)
                    s_picsp_path += 3.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += s_picsp_txt + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/CPhotos" + Chr(13)
                    s_picsp_path += 2.ToString + Chr(13)
                    s_picsp_path += 当前路径 + "/" + Label1.Text + Chr(13)
                    s_picsp_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/cassette" + Chr(13)
                    's_pic_txt = s_pic_path
                    File.WriteAllText("pics.txt", s_picsp_path)

                    ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                    While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                    End While
                    s_vp_index = 3
                    Me.Timer1.Enabled = True
                End If
            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub 新建游戏信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建游戏信息ToolStripMenuItem.Click
        Dim intro_filetxt_path As String
        Dim intro_filetxt_name As String

        Dim open_filetxt_index As Integer
        If (xml_index > -1) Then
            open_filetxt_index = xml_index
            intro_filetxt_name = TextBox2.Text
            intro_filetxt_name = Path.GetFileNameWithoutExtension(intro_filetxt_name)
            intro_filetxt_path = "rom/" + Form3.ComboBox1.Text + "/intro"
            建立文件夹(intro_filetxt_path)
            If (My.Computer.FileSystem.FileExists(intro_filetxt_path + "/" + intro_filetxt_name + ".txt")) Then
                ShellExecute(0, "open", 当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", "", "", 1)
            Else
                File.WriteAllText(当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", intro_filetxt_name)
                ShellExecute(0, "open", 当前路径 + "/" + intro_filetxt_path + "/" + intro_filetxt_name + ".txt", "", "", 1)
            End If
            TextBox7.Text = intro_filetxt_path + "/" + intro_filetxt_name + ".txt"
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim s_video_txt As String = ""
        Dim s_video_path As String = ""
        If (My.Computer.FileSystem.FileExists(当前路径 + "\mtn_pv_index.exe")) Then


            If (System.Diagnostics.Process.GetProcessesByName("mtn_stu").Length > 0) Then
                MsgBox("只能打开一个下载窗口")
            Else
                If (xml_index > -1) Then
                    s_video_txt = Path.GetFileNameWithoutExtension(TextBox2.Text)
                    pics_path_1 = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/video/" + s_video_txt + ".mp4"
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        MsgBox("视频已经存在")
                    Else
                        s_video_path = 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/video/" + s_video_txt + ".txt" + Chr(13)
                        Call 建立文件夹(当前路径 + "/rom/" + Form3.ComboBox1.Text + "/video/")
                        s_pic_index = xml_index.ToString + Chr(13)
                        s_video_path += TextBox1.Text + Chr(13)
                        s_video_path += 5.ToString + Chr(13)
                        s_video_path += 当前路径 + "/rom/" + Form3.ComboBox1.Text + "/video" + Chr(13)
                        s_video_path += s_video_txt
                        's_pic_txt = s_pic_path
                        File.WriteAllText("pics.txt", s_video_path)
                        ShellExecute(0, "open", "https://search.bilibili.com/all?vt=91666068&keyword=" + TextBox1.Text, "", "", 1)
                        ShellExecute(0, "open", 当前路径 + "\mtn_pv_index.exe", "", "", 1)
                        While System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length < 0
                        End While
                        s_vp_index = 5
                        Me.Timer1.Enabled = True
                    End If
                End If
            End If
        Else
            Form12.Label4.Text = 3
            Form12.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim pics_if As Integer = 0
        If (System.Diagnostics.Process.GetProcessesByName("mtn_pv_index").Length > 0) Then

        Else
            Select Case s_vp_index
                Case 1
                    Dim pics_path_2 As String = ""
                    pics_path_2 = Path.GetDirectoryName(Path.GetDirectoryName(pics_path_1)) + "\thumb\" + Path.GetFileNameWithoutExtension(pics_path_1) + ".png"
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        TextBox3.Text = pics_path_1.Replace(当前路径 + "/", "")
                        Panel2.BackgroundImage = file_img(TextBox3.Text)
                    ElseIf My.Computer.FileSystem.FileExists(pics_path_2) Then
                        TextBox3.Text = pics_path_2.Replace(当前路径 + "\", "")
                        Panel2.BackgroundImage = file_img(TextBox3.Text)
                    End If
                Case 2

                Case 3
                    Dim pics_path_2 As String = ""
                    pics_path_2 = Path.GetDirectoryName(Path.GetDirectoryName(pics_path_1)) + "\cassette\" + Path.GetFileNameWithoutExtension(pics_path_1) + ".png"

                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        TextBox5.Text = pics_path_1.Replace(当前路径 + "/", "")
                        Panel5.BackgroundImage = file_img(TextBox5.Text)
                    ElseIf My.Computer.FileSystem.FileExists(pics_path_2) Then
                        TextBox5.Text = pics_path_2.Replace(当前路径 + "\", "")
                        Panel5.BackgroundImage = file_img(TextBox5.Text)
                    End If
                Case 4

                Case 5
                    If My.Computer.FileSystem.FileExists(pics_path_1) Then
                        TextBox6.Text = pics_path_1.Replace(当前路径 + "/", "")
                        WebBrowser1.Document.All("bvid").SetAttribute("src", Path.GetFullPath(TextBox6.Text))
                        Panel4.BackgroundImage = Image.FromFile("theme\file.jpg")
                    End If

            End Select
            Me.Timer1.Enabled = False
        End If
    End Sub
End Class