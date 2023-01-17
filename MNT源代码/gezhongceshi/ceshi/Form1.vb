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

        Dim addr As String = "https://login.live.com/oauth20_authorize.srf?"
        Dim poststring As String = "client_id=1703486b-2285-46d6-8391-db7b95211f3a&scope=files.readwrite&response_type=code&redirect_uri=http://localhost"

        WebBrowser1.Navigate(addr + "?" + poststring)


    End Sub

    Public Shared Function onedrive_get(ByVal url As String, ByVal data As String) As String

        'url是请求地址 ，data是参数      

        Dim request As HttpWebRequest = WebRequest.Create(url + "?" + data)

        '设置GET请求方式   

        request.Method = "GET"

        '获取响应数据流

        Dim sr As StreamReader = New StreamReader(request.GetResponse().GetResponseStream)

        Return sr.ReadToEnd

    End Function
    Public Function Post(ByVal url As String, ByVal content As String) As String
        Dim result As String = ""
        Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        req.Method = "POST"
        req.ContentType = "application/x-www-form-urlencoded"
        Dim data As Byte() = Encoding.UTF8.GetBytes(content)
        req.ContentLength = data.Length

        Using reqStream As Stream = req.GetRequestStream()
            reqStream.Write(data, 0, data.Length)
            reqStream.Close()
        End Using

        Dim resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
        Dim stream As Stream = resp.GetResponseStream()

        Using reader As StreamReader = New StreamReader(stream, Encoding.UTF8)
            result = reader.ReadToEnd()
        End Using

        Return result
    End Function

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Dim onedrive_code As String = ""
        Dim post_url As String = "https://login.live.com/oauth20_token.srf"
        Dim post_zhi As String = "client_id=1703486b-2285-46d6-8391-db7b95211f3a&redirect_uri=http://localhost&client_secret=EBD8Q~F~fJmVeWTZvNsIjxmMNfu6yipH4ByZvb9v&code="
        If (InStr(WebBrowser1.Url.ToString, "http://localhost/?code=")) Then
            onedrive_code = WebBrowser1.Url.ToString().Replace("http://localhost/?code=", "")
            post_zhi = post_zhi + onedrive_code + "&grant_type=authorization_code&grant_type=uthorization_code"
            MsgBox(Post(post_url, post_zhi))
        End If

    End Sub
End Class
