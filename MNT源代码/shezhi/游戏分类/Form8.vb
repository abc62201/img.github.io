Imports System.Xml
Imports System.IO
Public Class Form8


    Dim liebiao As String
    Dim xg As Integer
    Dim xmlnodes As Xml.XmlNodeList
    Dim fs As String
    Dim 当前路径 As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim counter As Integer
        Dim xml_index As Integer
        Dim xml_del_no As Integer = 0
        Dim data_index() As Integer = {0}
        Dim xmlDoc As New XmlDocument()
        If ComboBox1.SelectedIndex > -1 Then


            For counter = 0 To (Form3.DataGridView2.SelectedCells.Count - 1)
                Dim value As String = Nothing
                If Form3.DataGridView2.SelectedCells(counter).ColumnIndex = _
                    Form3.DataGridView2.Columns("rom").Index Then
                    xml_index = Form3.DataGridView2.SelectedCells(counter).RowIndex
                    ' Form3.DataGridView2.Rows.RemoveAt(Form3.DataGridView2.SelectedCells(counter).RowIndex)
                    'Dim del As String = DataGridView1.Rows(行号).Cells(列).Value '获取内容
                    ReDim Preserve data_index(xml_del_no)
                    data_index(xml_del_no) = xml_index
                    xml_del_no = xml_del_no + 1
                    Dim root As XmlNode
                    Dim xe1 As XmlElement
                    xmlDoc.Load(liebiao)
                    root = xmlDoc.SelectSingleNode("plp_yx_m") '查找<bookstore>
                    ' MsgBox(root.ChildNodes(0).ChildNodes(0).InnerText)
                    If (root.ChildNodes(0).ChildNodes(0).InnerText = "kong" And root.ChildNodes(0).ChildNodes(1).InnerText = "kong" And root.ChildNodes(0).ChildNodes(2).InnerText = "kong" _
                        And root.ChildNodes(0).ChildNodes(3).InnerText = "kong" And root.ChildNodes(0).ChildNodes(4).InnerText = "kong" And root.ChildNodes(0).ChildNodes(5).InnerText = "kong" _
                        And root.ChildNodes(0).ChildNodes(6).InnerText = "kong") Then
                        root.RemoveChild(root.ChildNodes(0))
                    End If

                    xe1 = xmlDoc.CreateElement("book") '创建一个<book>节点

                    Dim xesub1 As XmlElement = xmlDoc.CreateElement("rom")
                    xesub1.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(0).Value
                    xe1.AppendChild(xesub1) '添加到<book>节点中

                    Dim xesub2 As XmlElement = xmlDoc.CreateElement("name")
                    xesub2.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(1).Value
                    xe1.AppendChild(xesub2)

                    Dim xesub3 As XmlElement = xmlDoc.CreateElement("void")
                    xesub3.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(2).Value
                    xe1.AppendChild(xesub3)

                    Dim xesub4 As XmlElement = xmlDoc.CreateElement("kadai")
                    xesub4.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(3).Value
                    xe1.AppendChild(xesub4)

                    Dim xesub5 As XmlElement = xmlDoc.CreateElement("mig")
                    xesub5.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(4).Value
                    xe1.AppendChild(xesub5)

                    Dim xesub6 As XmlElement = xmlDoc.CreateElement("emu")
                    xesub6.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(5).Value
                    xe1.AppendChild(xesub6)

                    Dim xesub7 As XmlElement = xmlDoc.CreateElement("intro")
                    xesub7.InnerText = Form3.DataGridView2.Rows(xml_index).Cells(6).Value
                    xe1.AppendChild(xesub7)

                    root.AppendChild(xe1) '添加到<bookstore>节点中
                    'root.ChildNodes.Item(0).AppendChild(xe1)
                    xmlDoc.Save(liebiao)
                End If
            Next
            For i As Integer = 0 To data_index.Length - 1
                Form3.DataGridView2.Rows.RemoveAt(data_index(i))
                xmlnodes = duxml(Label1.Text, "plp_yx_m")
                xmlnodes(0).RemoveChild(xmlnodes(0).ChildNodes(data_index(i)))
                doc.Save(Label1.Text)
            Next
            Me.Hide()
        Else
            MsgBox("请选择分类")
        End If

    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        当前路径 = Application.StartupPath() '初始路径
        fs = 当前路径 + "\daohang.xml"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim menu_index As Integer = 0
        Dim data2_rows_txt As String = ""
        Dim menu_name As String = ""
        Dim ds As New DataSet
        xg = ComboBox1.SelectedIndex
        xmlnodes = duxml(fs, "book")
        liebiao = xmlnodes(xg).ChildNodes(3).InnerText

        If My.Computer.FileSystem.FileExists(liebiao) Then
            xmlnodes = duxml(liebiao, "book")
            Me.MenuStrip1.Items.Clear()
            Me.MenuStrip1.Items.Add("选择下一级").Name = "next"
            Dim menu_dr As New ToolStripMenuItem
            menu_dr = Me.MenuStrip1.Items("next")
            For i = 0 To xmlnodes.Count - 1
                xmlnodes = duxml(liebiao, "book")

                data2_rows_txt = xmlnodes(i).ChildNodes(0).InnerText

                If (System.IO.Path.GetExtension(data2_rows_txt) = ".xml") Then
                    menu_name = "menu" + menu_index.ToString
                    'Me.MenuStrip1.Items.Add(DataGridView2.Rows(i).Cells(1).Value, Nothing, AddressOf MenuItem_click).Name = menu_name
                    menu_dr.DropDownItems.Add(xmlnodes(i).ChildNodes(1).InnerText, Nothing, AddressOf MenuItem_click).Name = menu_name
                    menu_dr.DropDownItems(menu_name).Tag = data2_rows_txt
                    menu_net(data2_rows_txt, menu_name, menu_dr)
                    menu_index = menu_index + 1
                End If
            Next

            xmlnodes = duxml(fs, "book")
        Else
            liebiao = ""
            MsgBox("该游戏列表文件不存在请检测路径")
        End If
    End Sub
    Private Sub menu_net(ByVal menu_net_path As String, ByVal menu_net_name As String, ByVal menu As ToolStripMenuItem)
        Dim menu_net_txt As String = ""
        Dim menu_net_dr As New ToolStripMenuItem
        Dim ar_i As Integer = 0
        Dim menu_net_dr_path(0) As String
        Dim menu_net_dr_name(0) As String

        menu_net_dr = menu.DropDownItems(menu_net_name)
        If My.Computer.FileSystem.FileExists(menu_net_path) Then


            xmlnodes = duxml(menu_net_path, "book")
            For i As Integer = 0 To xmlnodes.Count - 1
                menu_net_txt = xmlnodes(i).ChildNodes(0).InnerText
                If (System.IO.Path.GetExtension(menu_net_txt) = ".xml") Then
                    ReDim Preserve menu_net_dr_path(ar_i)
                    ReDim Preserve menu_net_dr_name(ar_i)
                    menu_net_dr.DropDownItems.Add(xmlnodes(i).ChildNodes(1).InnerText, Nothing, AddressOf MenuItem_click).Name = xmlnodes(i).ChildNodes(1).InnerText
                    menu_net_dr.DropDownItems(xmlnodes(i).ChildNodes(1).InnerText).Tag = menu_net_txt
                    menu_net_dr_path(ar_i) = menu_net_txt
                    menu_net_dr_name(ar_i) = xmlnodes(i).ChildNodes(1).InnerText
                End If
            Next
            If (menu_net_dr_path.Length > 0) Then
                For i = 0 To menu_net_dr_path.Length - 1
                    If (menu_net_dr_path(i) <> "") Then
                        menu_net(menu_net_dr_path(i), menu_net_dr_name(i), menu_net_dr)
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub MenuItem_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuStrip1.Click
        Dim ds As New DataSet
        If (sender.Tag <> "" And My.Computer.FileSystem.FileExists(sender.Tag)) Then
            liebiao = sender.Tag
            Me.MenuStrip1.Items("next").Text = sender.text
        End If

    End Sub
End Class