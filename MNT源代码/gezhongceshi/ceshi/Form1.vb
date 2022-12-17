Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.IO

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

        Dim addr As String = "https://image.baidu.com/search/acjson"
        Dim poststring As String = "tn=resultjson_com&word=魂斗罗&pn=0"
        addr &= "?" & poststring
        Try
            Dim myWebRequest As WebRequest = WebRequest.Create(addr)
            myWebRequest.ContentType = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36 Edg/104.0.1293.63"
            myWebRequest.Method = "GET"
            Dim myWebresponse As WebResponse = myWebRequest.GetResponse

            Dim mystream As Stream = myWebresponse.GetResponseStream

            Dim singleReadCount As Integer = 10240
            Dim mybyte(singleReadCount - 1) As Byte
            Dim strpagecontent As String = ""

            Dim intreadl As Integer = 0
            Do
                intreadl = mystream.Read(mybyte, 0, singleReadCount)
                strpagecontent &= Encoding.UTF8.GetString(mybyte, 0, intreadl) 'Encoding.GetEncoding("gb2312").GetString(mybyte, 0, intreadl)
            Loop While intreadl > 0

            Console.WriteLine(strpagecontent)
            mystream.Close()
            myWebresponse.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
