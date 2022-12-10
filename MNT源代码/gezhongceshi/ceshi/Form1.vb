Imports System.Xml
Public Class Form1
    Public doc As New Xml.XmlDocument
    Dim nodes As Xml.XmlNodeList
    Dim nobe As Xml.XmlElement
    Dim nobexml As Xml.XmlNodeList
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function duxml(ByVal file As String, ByVal xmlname As String)
        If My.Computer.FileSystem.FileExists(file) Then


            doc.Load(file)
            'nodes = doc.GetElementsByTagName("book")

            nobexml = doc.GetElementsByTagName(xmlname)

            'Console.WriteLine(nobexml.Count)
            ' Console.WriteLine(nobexml(0).InnerText)

            'For Each nobe In nodes
            'Console.WriteLine(nobe("name").InnerText)

            ' Next
            Return nobexml
        Else
            Return "kong"
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xmlnodes As Xml.XmlNodeList
        doc.Load("./rss_Down_r16.xml")
        xmlnodes = doc.GetElementsByTagName("channel")
        nodes = doc.GetElementsByTagName("item")
        For Each nobe In nodes
            Console.WriteLine(nobe("description").ChildNodes(0).Count)
        Next
        Console.WriteLine(xmlnodes(0).ChildNodes(2).InnerText)
    End Sub
End Class
