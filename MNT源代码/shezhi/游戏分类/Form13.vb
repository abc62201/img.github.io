﻿Imports System
Imports System.IO

Public Class Form13
    Dim xmlnodes As Xml.XmlNodeList
    Dim xml_index As Integer = -1
    Dim souh_index As Integer = -1
    Dim 当前路径 As String

    Private Sub Form13_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ListBox1.Items.Clear()
        Me.Hide()
        Form3.Show()
    End Sub
    Private Function file_img(ByVal str1 As String)
        Dim memoryStream_start As New MemoryStream()
        Using Fs As New System.IO.FileStream(str1, IO.FileMode.Open, IO.FileAccess.Read)
            Dim Buff(Fs.Length - 1) As Byte
            Fs.Read(Buff, 0, Fs.Length - 1)
            memoryStream_start.Write(Buff, 0, Buff.Length - 1)
            Return Image.FromStream(memoryStream_start)
        End Using

    End Function
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        当前路径 = Application.StartupPath()
        Me.Width = SystemInformation.PrimaryMonitorSize.Width * 0.6
        Me.Height = SystemInformation.PrimaryMonitorSize.Height * 0.8
        xmlnodes = duxml(Label1.Text, "book")
        ListBox1.Width = 300
        ListBox1.Height = Me.Height
        For i = 0 To xmlnodes.Count - 1
            ' MsgBox(xmlnodes(i).CloneNode(1).InnerText)
            ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
        Next
        'WebBrowser1.Location = New Point(winx * 0.8, 0)
        TextBox1.Location = New Point(306, 44)
        Panel1.Location = New Point(306, 71)
        CheckBox1.Location = New Point(306, 12)
        CheckBox2.Location = New Point(432, 12)
        CheckBox3.Location = New Point(534, 12)
        Button1.Location = New Point(307, Me.Height * 0.9)

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

        TextBox8.Location = New Point(688, 10)
        Button3.Location = New Point(838, 8)

        Panel1.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel2.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel3.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel4.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel5.BackgroundImage = Image.FromFile("theme\file.jpg")
        Panel6.BackgroundImage = Image.FromFile("theme\file.jpg")
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        WebBrowser1.Navigate(Path.GetFullPath("theme\video.html"))
    End Sub

  

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        Dim xmldellist As Xml.XmlNodeList
        Dim yesno As Integer
        Dim ds As New DataSet
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
                ' MsgBox(xmlnodes(i).CloneNode(1).InnerText)
                ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
            Next

            If (xml_index <= xmlnodes.Count - 1) Then
                ListBox1.SelectedIndex = xml_index
            Else
                ListBox1.SelectedIndex = xmlnodes.Count - 1
            End If
            ds.ReadXml(Label1.Text)
            Form3.DataGridView2.DataSource = ds
        End If
    End Sub



    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' MsgBox(ListBox1.SelectedValue)

        xml_index = ListBox1.SelectedIndex
        TextBox1.Text = ListBox1.Text
        TextBox2.Text = xmlnodes(xml_index).ChildNodes(0).InnerText
        TextBox6.Text = xmlnodes(xml_index).ChildNodes(2).InnerText
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
            Panel2.BackgroundImage = file_img(文件)
        End If
    End Sub
    Private Sub Panel2_DragDrop(sender As Object, e As DragEventArgs) Handles Panel2.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox3.Text = 文件
            Panel2.BackgroundImage = file_img(文件)
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
            Panel5.BackgroundImage = file_img(文件)
        End If
    End Sub
    Private Sub Panel5_DragDrop(sender As Object, e As DragEventArgs) Handles Panel5.DragDrop
        Try
            Dim filePath() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim 文件 As String = ""
            文件 = filePath(0)
            Me.TextBox5.Text = 文件
            Panel5.BackgroundImage = file_img(文件)
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

    Private Function file_w(ByVal str1 As String, ByVal str2 As String, ByVal str4 As String)
        Dim str3 As String = str1
        If (str4 <> "emu") Then
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
                Else
                    str3 = 当前路径 + "\rom\" + Form3.ComboBox1.Text + "\" + str4
                    Call 建立文件夹(当前路径 + "\rom\" + Form3.ComboBox1.Text + "\" + str4)
                    str3 = str3 + "\" + Path.GetFileName(str1)
                    My.Computer.FileSystem.CopyFile(str1, str3, showUI)
                End If
            End If

            If CheckBox2.Checked And str1 <> str2 Then
                Dim showUI As FileIO.UIOption = FileIO.UIOption.AllDialogs
                If My.Computer.FileSystem.FileExists(str1) Then
                    System.IO.File.Delete(str1)
                End If
            End If
        End If
        Return str3
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        If (xml_index = -1) Then
            MsgBox("未选择游戏")
        Else
            xmlnodes(xml_index).ChildNodes(0).InnerText = file_w(TextBox2.Text, xmlnodes(xml_index).ChildNodes(0).InnerText, "rom").Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(0).InnerText = TextBox2.Text
            xmlnodes(xml_index).ChildNodes(1).InnerText = TextBox1.Text
            'xmlnodes(xml_index).ChildNodes(2).InnerText = TextBox6.Text
            xmlnodes(xml_index).ChildNodes(2).InnerText = file_w(TextBox6.Text, xmlnodes(xml_index).ChildNodes(2).InnerText, "video").Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(3).InnerText = TextBox5.Text
            xmlnodes(xml_index).ChildNodes(3).InnerText = file_w(TextBox5.Text, xmlnodes(xml_index).ChildNodes(3).InnerText, "cassette").Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(4).InnerText = TextBox3.Text
            xmlnodes(xml_index).ChildNodes(4).InnerText = file_w(TextBox3.Text, xmlnodes(xml_index).ChildNodes(4).InnerText, "thumb").Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(5).InnerText = TextBox4.Text
            xmlnodes(xml_index).ChildNodes(5).InnerText = file_w(TextBox4.Text, xmlnodes(xml_index).ChildNodes(5).InnerText, "emu").Replace(Application.StartupPath() + "\", "")
            ' xmlnodes(xml_index).ChildNodes(6).InnerText = TextBox7.Text
            xmlnodes(xml_index).ChildNodes(6).InnerText = file_w(TextBox7.Text, xmlnodes(xml_index).ChildNodes(6).InnerText, "intro").Replace(Application.StartupPath() + "\", "")
            doc.Save(Label1.Text)
            xmlnodes = duxml(Label1.Text, "book")
            ListBox1.Items.Clear()
            For i = 0 To xmlnodes.Count - 1
                ' MsgBox(xmlnodes(i).CloneNode(1).InnerText)
                ListBox1.Items.Add(xmlnodes(i).ChildNodes(1).InnerText)
            Next
            If (xml_index > 0) Then
                ListBox1.SelectedIndex = xml_index
            End If
            ds.ReadXml(Label1.Text)
            Form3.DataGridView2.DataSource = ds
        End If
    End Sub
    Private Sub 建立文件夹(ByVal 文件夹名 As String)
        If Not Directory.Exists(文件夹名) Then
            Directory.CreateDirectory(文件夹名)
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

 

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox8.Text <> "" Then
            souh_index = ListBox1.FindString(TextBox8.Text, souh_index)
            If (souh_index > -1) Then
                ListBox1.SelectedIndex = souh_index
                souh_index = souh_index + 1
            End If
        End If
    End Sub
    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
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

        Try


            If (Label9.Text = "kong") Then

                If (TextBox2.Text = "kong") Then
                    MsgBox("未选中启动文件")
                Else
                    s1 = TextBox2.Text '游戏rom路径
                    File.WriteAllText("pics.txt", s1)
                    romp = TextBox2.Text
                    If Path.GetExtension(s1) = ".xml" Then

                    ElseIf (Path.GetExtension(s1) = "") Then
                        ShellExecute(0, "open", s1, "", "", 1)
                    ElseIf Path.GetDirectoryName(s1) = "http:" Or
                           Path.GetDirectoryName(s1).Substring(0, 4) = "http" Or
                           Path.GetDirectoryName(s1).Substring(0, 3) = "ftp" Then
                        ShellExecute(0, "open", s1, "", "", 1)
                    ElseIf Not My.Computer.FileSystem.FileExists(s1) Then
                        MsgBox("游戏不存")
                    Else
                        mnq = romp
                        miname = romp
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(romp))
                        模拟器p = romp
                        battxt = " "
                        miname = Path.GetFileName(miname)
                        miname = miname.Replace(Path.GetExtension(miname), "")
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


                        ShellExecute(0, "open", "qidong.bat", "", "", 1) '使用模拟器（MXL中）打开rom                     
                    End If
                End If





            Else

                s1 = TextBox2.Text '游戏rom路径
                File.WriteAllText("pics.txt", s1)
                romp = TextBox2.Text
                模拟器rom = TextBox4.Text
                If Path.GetExtension(s1) = ".xml" Then
                    If My.Computer.FileSystem.FileExists(s1) Then

                    End If
                ElseIf Not My.Computer.FileSystem.FileExists(s1) Then                
                    MsgBox("游戏不存")                
                Else

                    If (模拟器rom = "kong") Then
                        mnq = Label9.Text
                        miname = Label9.Text
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(Label9.Text))
                        模拟器p = Label9.Text
                        核心 = Label10.Text

                    ElseIf (System.IO.Path.GetExtension(模拟器rom) = ".dll") Then
                        mnq = Label9.Text
                        miname = Label9.Text
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(Label9.Text))
                        模拟器p = Label9.Text
                        核心 = 模拟器rom
                    ElseIf (Not My.Computer.FileSystem.FileExists(模拟器rom)) Then
                        mnq = Label9.Text
                        miname = Label9.Text
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(Label9.Text))
                        模拟器p = Label9.Text
                        核心 = 模拟器rom
                        cank = True
                    Else
                        mnq = Label9.Text
                        miname = Label9.Text
                        模拟器盘符 = System.IO.Path.GetDirectoryName(Path.GetFullPath(模拟器rom))
                        模拟器p = 模拟器rom
                        核心 = Label10.Text

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




                    ShellExecute(0, "open", "qidong.bat", "", "", 1) '使用模拟器（MXL中）打开rom
                   
                End If
            End If
        Catch ex As Exception
            ShellExecute(0, "open", s1, "", "", 1)

            ' MsgBox("出现异常无法启动")
        End Try
        ' Me.WindowState = FormWindowState.Minimized '最小化窗口本来应该选择关闭的，这里只是测试
    End Sub
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        souh_index = 0
    End Sub
End Class