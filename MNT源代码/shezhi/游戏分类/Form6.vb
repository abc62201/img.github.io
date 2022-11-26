Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml

Public Class Form6
    Dim xml_txt As String
    Dim romp As String
    Dim rom_name As String
    Dim video_name As String
    Dim kadai_name As String
    Dim tu_name As String
    Dim intro_name As String
    Dim xmlDoc As New XmlDocument()
    Dim root As XmlNode
    Dim xe1 As XmlElement
    Dim xml_book_node As XmlNodeList
    Dim db_id As String = 0


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
            romp = "已选择"

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TextBox2.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TextBox3.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TextBox4.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql As String = ""
        Dim ds As New DataSet
        xmlDoc.Load(Label5.Text)

        root = xmlDoc.SelectSingleNode("plp_yx_m") '查找<bookstore>

        xml_book_node = xmlDoc.GetElementsByTagName("book")
        db_id = xml_book_node.Count - 1

        If (Directory.Exists(TextBox1.Text)) Then
            Call GetAllFile(TextBox1.Text)


        ElseIf (Not Directory.Exists(TextBox1.Text) And (Not Directory.Exists(TextBox2.Text)) And (Not Directory.Exists(TextBox3.Text)) And (Not Directory.Exists(TextBox4.Text)) And (Not Directory.Exists(TextBox5.Text))) Then


        Else
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = Form3.DataGridView2.Rows.Count - 2
            For i As Integer = 0 To Form3.DataGridView2.Rows.Count - 2

                xml_txt = System.IO.Path.GetFileName(Form3.DataGridView2.Rows(i).Cells(0).Value)
                rom_name = xml_txt.Replace(System.IO.Path.GetExtension(xml_txt), "")

                If (System.IO.Path.GetExtension(xml_txt) <> ".xml") Then


                    If (My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".mp4")) Then

                        video_name = TextBox2.Text + "\" + rom_name + ".mp4"
                        video_name = video_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(2).InnerText = video_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".avi") Then
                        video_name = TextBox2.Text + "\" + rom_name + ".avi"
                        video_name = video_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(2).InnerText = video_name
                    End If

                    If (My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".png")) Then
                        kadai_name = TextBox4.Text + "\" + rom_name + ".png"
                        kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(3).InnerText = kadai_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpg") Then
                        kadai_name = TextBox4.Text + "\" + rom_name + ".jpg"
                        kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(3).InnerText = kadai_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpeg") Then
                        kadai_name = TextBox4.Text + "\" + rom_name + ".jpeg"
                        kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(3).InnerText = kadai_name.Replace("&", "&amp;")
                    ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".gif") Then
                        kadai_name = TextBox4.Text + "\" + rom_name + ".gif"
                        kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(3).InnerText = kadai_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".bmp") Then
                        kadai_name = TextBox4.Text + "\" + rom_name + ".bmp"
                        kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(3).InnerText = kadai_name
                    End If


                    If My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".png") Then
                        tu_name = TextBox3.Text + "\" + rom_name + ".png"
                        tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(4).InnerText = tu_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpg") Then
                        tu_name = TextBox3.Text + "\" + rom_name + ".jpg"
                        tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(4).InnerText = tu_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpeg") Then
                        tu_name = TextBox3.Text + "\" + rom_name + ".jpeg"
                        tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(4).InnerText = tu_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".gif") Then
                        tu_name = TextBox3.Text + "\" + rom_name + ".gif"
                        tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(4).InnerText = tu_name
                    ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".bmp") Then
                        tu_name = TextBox3.Text + "\" + rom_name + ".bmp"
                        tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(4).InnerText = tu_name
                    End If

                    If My.Computer.FileSystem.FileExists(TextBox5.Text + "\" + rom_name + ".txt") Then
                        intro_name = TextBox5.Text + "\" + rom_name + ".txt"
                        intro_name = intro_name.Replace(Application.StartupPath() + "\", "")
                        xml_book_node(i).ChildNodes(6).InnerText = intro_name
                    End If
                    Me.ProgressBar1.Value = i
                End If

            Next

        End If
        xmlDoc.Save(Label5.Text)
        db_zidian.Clear()
        ds.ReadXml(Label5.Text)
        Form3.DataGridView2.DataSource = ds
        Form3.ProgressBar1.Value = 0
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form3.Show()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        romp = ""
        xml_txt = ""
        rom_name = ""
        video_name = ""
        kadai_name = ""
        tu_name = ""
        intro_name = ""
        Label7.Visible = False
        ' Me.TextBox5.Text = "选择信息文件夹"
        ' Me.TextBox4.Text = "选择卡带文件夹"
        ' Me.TextBox3.Text = "选择图片文件夹"
        ' Me.TextBox2.Text = "选择视频文件夹"
        ' Me.TextBox1.Text = "选择rom文件夹"

    End Sub
    Private Sub GetAllFile(ByVal path As String)

        Dim strDir As String() = System.IO.Directory.GetDirectories(path)
        Dim strFile As String() = System.IO.Directory.GetFiles(path)
        Dim i As Integer
        Dim cunzi As Integer = -1
        Dim sql As String = ""
        Dim arr() As String = {""}
        Dim file_ext_k As Boolean = True
        Dim dat_file_index As Integer = -1
        Dim dat_file() As String = {""}
        If (TextBox6.Text <> "") Then
            arr = TextBox6.Text.Split(";")
        End If

        ' db_id = 0
        If strFile.Length > 0 Then
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = strFile.Length - 1
            For i = 0 To strFile.Length - 1
                xml_txt = System.IO.Path.GetFileName(strFile(i))

                If (InStr(strFile(i), ".") > 0) Then
                    rom_name = xml_txt.Replace(System.IO.Path.GetExtension(xml_txt), "")
                Else
                    rom_name = xml_txt
                End If
                If (TextBox6.Text = "" Or Array.FindIndex(arr, Function(s) s.Contains(System.IO.Path.GetExtension(xml_txt))) >= 0) Then
                    file_ext_k = True
                Else
                    file_ext_k = False
                End If

                If (System.IO.Path.GetExtension(xml_txt) <> ".xml" And file_ext_k) Then

                    Try
                        If db_zidian.ContainsKey(xml_txt) Then
                            sql = db_zidian.Item(xml_txt)
                            cunzi = CInt(sql)
                            If (My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".mp4")) Then
                                video_name = TextBox2.Text + "\" + rom_name + ".mp4"
                                video_name = video_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(2).InnerText = video_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".avi") Then
                                video_name = TextBox2.Text + "\" + rom_name + ".avi"
                                video_name = video_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(2).InnerText = video_name
                            End If

                            If (My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".png")) Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".png"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(3).InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpg") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".jpg"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(3).InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpeg") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".jpeg"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(3).InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".gif") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".gif"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(3).InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".bmp") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".bmp"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(3).InnerText = kadai_name
                            End If


                            If My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".png") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".png"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(4).InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpg") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".jpg"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(4).InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpeg") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".jpeg"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(4).InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".gif") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".gif"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(4).InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".bmp") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".bmp"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(4).InnerText = tu_name
                            End If

                            If My.Computer.FileSystem.FileExists(TextBox5.Text + "\" + rom_name + ".txt") Then
                                intro_name = TextBox5.Text + "\" + rom_name + ".txt"
                                intro_name = intro_name.Replace(Application.StartupPath() + "\", "")
                                xml_book_node(cunzi).ChildNodes(6).InnerText = intro_name
                            End If
                        Else

                            xe1 = xmlDoc.CreateElement("book") '创建一个<book>节点
                            Dim xesub1 As XmlElement = xmlDoc.CreateElement("rom")
                            If (InStr(System.IO.Path.GetFileName(Label5.Text), "mf_ips_") > 0) Then
                                xesub1.InnerText = Label7.Text

                            Else
                                xesub1.InnerText = strFile(i).Replace(Application.StartupPath() + "\", "") '设置文本节点
                            End If

                            xe1.AppendChild(xesub1) '添加到<book>节点中

                            Dim xesub2 As XmlElement = xmlDoc.CreateElement("name")

                            If (InStr(System.IO.Path.GetFileName(Label5.Text), "mf_ips_") > 0 And System.IO.Path.GetExtension(strFile(i)) = ".dat") Then
                                dat_file = File.ReadAllLines(strFile(i))

                                dat_file_index = Array.FindIndex(dat_file, Function(s) s.Contains("[zh_CN]"))                               
                                Try
                                    If (dat_file_index > 0) Then
                                        xesub2.InnerText = dat_file(dat_file_index + 1)
                                    Else
                                        xesub2.InnerText = rom_name
                                    End If

                                Catch ex As Exception

                                End Try
                            Else
                                xesub2.InnerText = rom_name
                            End If

                            xe1.AppendChild(xesub2)

                            Dim xesub3 As XmlElement = xmlDoc.CreateElement("void")
                            If (My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".mp4")) Then
                                video_name = TextBox2.Text + "\" + rom_name + ".mp4"
                                video_name = video_name.Replace(Application.StartupPath() + "\", "")
                                xesub3.InnerText = video_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox2.Text + "\" + rom_name + ".avi") Then
                                video_name = TextBox2.Text + "\" + rom_name + ".avi"
                                video_name = video_name.Replace(Application.StartupPath() + "\", "")
                                xesub3.InnerText = video_name
                            Else
                                xesub3.InnerText = "kong"
                            End If

                            xe1.AppendChild(xesub3)

                            Dim xesub4 As XmlElement = xmlDoc.CreateElement("kadai")
                            If (My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".png")) Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".png"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xesub4.InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpg") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".jpg"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xesub4.InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".jpeg") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".jpeg"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xesub4.InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".gif") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".gif"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xesub4.InnerText = kadai_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox4.Text + "\" + rom_name + ".bmp") Then
                                kadai_name = TextBox4.Text + "\" + rom_name + ".bmp"
                                kadai_name = kadai_name.Replace(Application.StartupPath() + "\", "")
                                xesub4.InnerText = kadai_name
                            Else
                                xesub4.InnerText = "kong"
                            End If

                            xe1.AppendChild(xesub4)

                            Dim xesub5 As XmlElement = xmlDoc.CreateElement("mig")
                            If My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".png") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".png"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xesub5.InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpg") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".jpg"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xesub5.InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".jpeg") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".jpeg"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xesub5.InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".gif") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".gif"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xesub5.InnerText = tu_name
                            ElseIf My.Computer.FileSystem.FileExists(TextBox3.Text + "\" + rom_name + ".bmp") Then
                                tu_name = TextBox3.Text + "\" + rom_name + ".bmp"
                                tu_name = tu_name.Replace(Application.StartupPath() + "\", "")
                                xesub5.InnerText = tu_name
                            Else
                                xesub5.InnerText = "kong"
                            End If
                            xe1.AppendChild(xesub5)



                            Dim xesub6 As XmlElement = xmlDoc.CreateElement("emu")
                            If (InStr(System.IO.Path.GetFileName(Label5.Text), "mf_ips_") > 0) Then
                                xesub6.InnerText = "-ips " + System.IO.Path.GetFileName(strFile(i))
                            Else
                                xesub6.InnerText = "kong"
                            End If

                            xe1.AppendChild(xesub6)



                            Dim xesub7 As XmlElement = xmlDoc.CreateElement("intro")
                            If My.Computer.FileSystem.FileExists(TextBox5.Text + "\" + rom_name + ".txt") Then
                                intro_name = TextBox5.Text + "\" + rom_name + ".txt"
                                intro_name = intro_name.Replace(Application.StartupPath() + "\", "")
                                xesub7.InnerText = intro_name
                            ElseIf (dat_file_index > 0) Then

                                intro_name = TextBox1.Text + "\" + rom_name + ".txt"
                                intro_name = intro_name.Replace(Application.StartupPath() + "\", "")
                                Dim dat_intro_txt As String = ""
                                For index_dat = dat_file_index + 1 To dat_file.Length - 1
                                    dat_intro_txt += dat_file(index_dat) + "<br/>"
                                Next

                                File.WriteAllText(intro_name, dat_intro_txt)
                                xesub7.InnerText = intro_name
                            Else
                                xesub7.InnerText = "kong"
                            End If
                            xe1.AppendChild(xesub7)
                            root.AppendChild(xe1) '添加到<bookstore>节点中
                        End If

                    Catch ex As Exception


                    End Try


                    Me.ProgressBar1.Value = i

                End If

            Next



        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1

                GetAllFile(strDir(i))
            Next
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FolderBrowserDialog1.Reset()
        FolderBrowserDialog1.SelectedPath = Application.StartupPath()
        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TextBox5.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub other()

    End Sub
End Class