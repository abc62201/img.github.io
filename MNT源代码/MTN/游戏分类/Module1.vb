Imports System.Xml
Imports SharpDX
Imports SharpDX.DirectInput
Imports System.Xml.Linq
Imports System.Text



Module Module1
    Public doc As New Xml.XmlDocument
    Dim nodes As Xml.XmlNodeList
    Dim nobe As Xml.XmlElement
    Dim nobexml As Xml.XmlNodeList
    Public db_zidian As New Dictionary(Of String, String)
    Public 游戏列表 As String
    Public thumb_path As String = "kong"
    Public thumb_path_file As String = "kong"
    Public web_ziti_color As String = New String(CChar(" "), 128)
    Public web_a_color As String = New String(CChar(" "), 128)
    Public web_a_bgcolor As String = New String(CChar(" "), 128)
    Public web_az_color As String = New String(CChar(" "), 128)
    Public web_az_bgcolor As String = New String(CChar(" "), 128)
    Public web_intro_color As String = New String(CChar(" "), 128)
    Public web_intro_bgcolor As String = New String(CChar(" "), 128)
    Public Declare Function GetSystemDefaultLCID Lib "kernel32 " () As Long
    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal IpOperation As String, ByVal IpFile As String, ByVal IpParameters As String, ByVal IpDirectory As String, ByVal nShowCmd As Int32) As Integer
    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Long
    Private Declare Function LCMapString Lib "kernel32" Alias "LCMapStringA" (ByVal Locale As Integer, ByVal dwMapFlags As Integer, ByVal lpSrcStr As String, ByVal cchSrc As Integer, ByVal lpDestStr As String, ByVal cchDest As Integer) As Integer
    Public bak_ColumnIndex As Integer = 0
    Public Declare Function SetFocusAPI& Lib "user32" Alias "SetFocus" (ByVal hwnd As Integer)
    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Long
    Public pad As Joystick
    Public allEffects
    Public dx_joutype As String() = {""}
    Public dx_joy As Boolean = False
    Public Sub GetJoyStick()
        Dim directInput As New DirectInput
        Dim joysticGuid As Guid = Guid.Empty
        Dim ayy_inddex As Integer = 0
        For Each deviceInstance In directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)
            joysticGuid = deviceInstance.InstanceGuid
            If joysticGuid <> Guid.Empty Then
                ReDim Preserve dx_joutype(ayy_inddex)
                dx_joutype(ayy_inddex) = joysticGuid.ToString
                ayy_inddex = ayy_inddex + 1

            End If
        Next
        If joysticGuid = Guid.Empty Then
            For Each deviceInstance1 In directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)
                joysticGuid = deviceInstance1.InstanceGuid
                If joysticGuid <> Guid.Empty Then
                    ReDim Preserve dx_joutype(ayy_inddex)
                    dx_joutype(ayy_inddex) = joysticGuid.ToString
                    ayy_inddex = ayy_inddex + 1

                End If
            Next
        End If

        If (joysticGuid = Guid.Empty) Then
            dx_joy = False
        Else
            Dim sb As StringBuilder = New StringBuilder()
            pad = New Joystick(directInput, joysticGuid)
            allEffects = pad.GetEffects()
            For Each effectInfo In allEffects
                sb.Append(effectInfo.Name.ToString())
            Next

            pad.Properties.BufferSize = 128
            pad.Acquire()
            dx_joy = True
        End If
    End Sub
    Public Sub GetJoyStick2(ByVal joy_drive As String)
        Dim directInput As New DirectInput
        Dim joysticGuid As Guid = Guid.Empty
        Dim dx_joytyep As String
        dx_joytyep = joy_drive
        For Each deviceInstance In directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)
            joysticGuid = deviceInstance.InstanceGuid
            If (joysticGuid.ToString = dx_joytyep) Then

                GoTo joy_zhao
            End If
        Next
        'If joysticGuid = Guid.Empty Then
        For Each deviceInstance1 In directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)
            joysticGuid = deviceInstance1.InstanceGuid
            If (joysticGuid.ToString = dx_joytyep) Then

                GoTo joy_zhao
            End If
        Next
        'End If
        If (joysticGuid.ToString <> dx_joytyep) Then
            dx_joy = False

        Else

joy_zhao:
            Dim sb As StringBuilder = New StringBuilder()
            pad = New Joystick(directInput, joysticGuid)
            allEffects = pad.GetEffects()
            For Each effectInfo In allEffects
                sb.Append(effectInfo.Name.ToString())
            Next

            pad.Properties.BufferSize = 128
            pad.Acquire()
            dx_joy = True
        End If
    End Sub
    Public Function duxml(ByVal file As String, ByVal xmlname As String)
        If My.Computer.FileSystem.FileExists(file) Then


            doc.Load(file)
            'nodes = doc.GetElementsByTagName("book")

            nobexml = doc.GetElementsByTagName(xmlname)

            ' Console.WriteLine(nobexml.Count)
            ' Console.WriteLine(nobexml(0).InnerText)

            'For Each nobe In nodes
            'Console.WriteLine(nobe("name").InnerText)

            ' Next
            Return nobexml
        Else
            Return "kong"
        End If
    End Function
    
    Public Function duxmllist(ByVal file As String, ByVal xmlname As String)

        If My.Computer.FileSystem.FileExists(file) Then

            doc.Load(file)

            If (doc.SelectSingleNode("plp_yx_m/book") Is Nothing) Then
                Dim root As Xml.XmlNode
                Dim xmlbook As Xml.XmlElement
                Dim xmlrom As Xml.XmlElement
                Dim xmlname1 As Xml.XmlElement
                Dim xmlvideo As Xml.XmlElement
                Dim xmlkadai As Xml.XmlElement
                Dim xmlimg As Xml.XmlElement

                root = doc.SelectSingleNode("plp_yx_m")
                xmlbook = doc.CreateElement("book")

                xmlrom = doc.CreateElement("rom")
                xmlrom.InnerText = "kong"
                xmlbook.AppendChild(xmlrom)
                xmlname1 = doc.CreateElement("name")
                xmlname1.InnerText = "kong"
                xmlbook.AppendChild(xmlname1)
                xmlvideo = doc.CreateElement("video")
                xmlvideo.InnerText = "kong"
                xmlbook.AppendChild(xmlvideo)
                xmlkadai = doc.CreateElement("kadai")
                xmlkadai.InnerText = "kong"
                xmlbook.AppendChild(xmlkadai)
                xmlimg = doc.CreateElement("img")
                xmlimg.InnerText = "kong"
                xmlbook.AppendChild(xmlimg)
                root.AppendChild(xmlbook)
                doc.Save(file)
            Else

            End If




            'nodes = doc.GetElementsByTagName("book")

            nobexml = doc.GetElementsByTagName(xmlname)

            ' Console.WriteLine(nobexml.Count)
            'Console.WriteLine(nobexml(0).InnerText)

            'For Each nobe In nodes
            'Console.WriteLine(nobe("name").InnerText)

            ' Next
            Return nobexml
        Else
            Return "kong"
        End If
    End Function

    Public Sub cdxml(ByVal file As String, ByVal namet As String, ByVal lujingt As String, ByVal txtt As String)
        doc.Load(file)
        Dim root As Xml.XmlNode
        Dim xmlbook As Xml.XmlElement
        Dim xmlname As Xml.XmlElement
        Dim xmllujing As Xml.XmlElement
        Dim xmltxt As Xml.XmlElement
        root = doc.SelectSingleNode("plp_yx_m")
        xmlbook = doc.CreateElement("book")

        xmlname = doc.CreateElement("name")
        xmlname.InnerText = namet
        xmlbook.AppendChild(xmlname)
        xmllujing = doc.CreateElement("lujing")
        xmllujing.InnerText = lujingt
        xmlbook.AppendChild(xmllujing)
        xmltxt = doc.CreateElement("txt")
        xmltxt.InnerText = txtt
        xmlbook.AppendChild(xmltxt)
        root.AppendChild(xmlbook)
        doc.Save(file)
    End Sub
    Public Sub dscxml(ByVal file As String, ByVal weizhi As Integer)
        doc.Load(file)
        nobexml = doc.GetElementsByTagName("plp_yx_m")
        nobexml(0).RemoveChild(nobexml(0).ChildNodes(weizhi))
        doc.Save(file)
    End Sub
    Public Function wenben1(ByVal file As String, ByVal diyizu As String, ByVal ziduan As String) As String

        Return file
    End Function
    Public Function 首尾删除空格(fullString As String) As String

        If fullString <> "" Then
            fullString = fullString.Substring(0, InStr(fullString, vbNullChar) - 1)
        End If
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())




    End Function
    Public Function WriteOneString(ByVal section As String, ByVal key As String, ByVal value As String, ByVal filename As String) As Long
        Dim X As Boolean
        Dim Nbuff As New String(CType(" ", Char), 1000)
        Nbuff = value + Chr(0)
        X = WritePrivateProfileString(section, key, Nbuff, filename)
        WriteOneString = X
    End Function
    Public Function ReadOneString(ByVal section As String, ByVal key As String, ByVal Filename As String) As String
        Dim X As Long, i As Integer

        Dim Buffer As New String(CType(" ", Char), 1000)
        X = GetPrivateProfileString(section, key, "", Buffer, 1000, Filename)
        i = InStr(Buffer, Chr(0))
        ReadOneString = Trim(Left(Buffer, i - 1))
    End Function
    Public Function md5(ByVal a As String) As String
        Dim tempmd5 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytResult() As Byte = tempmd5.ComputeHash(System.Text.Encoding.Default.GetBytes(a))
        Dim strResult As String = BitConverter.ToString(bytResult)
        strResult = strResult.Replace("-", "")
        Return strResult
    End Function
    Public Function getpychar(ByVal as_char As String) As String
        Dim tmp
        as_char = StrConv(as_char, VbStrConv.SimplifiedChinese)
        tmp = 65536 + Asc(as_char)
        If (as_char = "蝙") Then
            getpychar = "B"
        ElseIf (as_char = "蝠") Then
            getpychar = "F"
        ElseIf (as_char = "鸠") Then
            getpychar = "J"
        ElseIf (as_char = "噗") Then
            getpychar = "P"
        ElseIf (as_char = "呦") Then
            getpychar = "Y"
        ElseIf (as_char = "鳄") Then
            getpychar = "E"
        ElseIf (tmp >= 45217 And tmp <= 45252) Then
            getpychar = "A"
        ElseIf (tmp >= 45253 And tmp <= 45760) Then
            getpychar = "B"
        ElseIf (tmp >= 45761 And tmp <= 46317) Then
            getpychar = "C"
        ElseIf (tmp >= 46318 And tmp <= 46825) Then
            getpychar = "D"
        ElseIf (tmp >= 46826 And tmp <= 47009) Then
            getpychar = "E"
        ElseIf (tmp >= 47010 And tmp <= 47296) Then
            getpychar = "F"
        ElseIf (tmp >= 47297 And tmp <= 47613) Then
            getpychar = "G"
        ElseIf (tmp >= 47614 And tmp <= 48118) Then
            getpychar = "H"
        ElseIf (tmp >= 48119 And tmp <= 49061) Then
            getpychar = "J"
        ElseIf (tmp >= 49062 And tmp <= 49323) Then
            getpychar = "K"
        ElseIf (tmp >= 49324 And tmp <= 49895) Then
            getpychar = "L"
        ElseIf (tmp >= 49896 And tmp <= 50370) Then
            getpychar = "M"
        ElseIf (tmp >= 50371 And tmp <= 50613) Then
            getpychar = "N"
        ElseIf (tmp >= 50614 And tmp <= 50621) Then
            getpychar = "O"
        ElseIf (tmp >= 50622 And tmp <= 50905) Then
            getpychar = "P"
        ElseIf (tmp >= 50906 And tmp <= 51386) Then
            getpychar = "Q"
        ElseIf (tmp >= 51387 And tmp <= 51445) Then
            getpychar = "R"
        ElseIf (tmp >= 51446 And tmp <= 52217) Then
            getpychar = "S"
        ElseIf (tmp >= 52218 And tmp <= 52697) Then
            getpychar = "T"
        ElseIf (tmp >= 52698 And tmp <= 52979) Then
            getpychar = "W"
        ElseIf (tmp >= 52980 And tmp <= 53688) Then
            getpychar = "X"
        ElseIf (tmp >= 53689 And tmp <= 54480) Then
            getpychar = "Y"
        ElseIf (tmp >= 54481 And tmp <= 62289) Then
            getpychar = "Z"
        Else '如果不是中文，则不处理
            getpychar = as_char
        End If
    End Function
    Public Function getpy(ByVal str As String)
        Dim i As Integer
        Dim ret As String
        ret = ""
        For i = 1 To Len(str)
            ret = ret & getpychar(Mid(str, i, 1))
        Next
        Return ret   '看需求也可以改成Return ret
    End Function
    Public Function text_处理(ByVal text As String) As String
        text_处理 = text.Replace("-", "_")
        text_处理 = text_处理.Replace(" ", "")
        text_处理 = text_处理.Replace(Chr(34), "")
        text_处理 = text_处理.Replace(",", "")
        text_处理 = text_处理.Replace(";", "")
        text_处理 = text_处理.Replace(":", "")
        text_处理 = text_处理.Replace("?", "")
        text_处理 = text_处理.Replace("'", "")
        text_处理 = text_处理.Replace("(", "")
        text_处理 = text_处理.Replace(")", "")
        text_处理 = text_处理.Replace("*", "")
        text_处理 = text_处理.Replace("&", "")
        text_处理 = text_处理.Replace("^", "")
        text_处理 = text_处理.Replace("%", "")
        text_处理 = text_处理.Replace("$", "")
        text_处理 = text_处理.Replace("#", "")
        text_处理 = text_处理.Replace("@", "")
        text_处理 = text_处理.Replace("!", "")
        text_处理 = text_处理.Replace("~", "")
        text_处理 = text_处理.Replace("\", "")
        text_处理 = text_处理.Replace("[", "")
        text_处理 = text_处理.Replace("]", "")
        text_处理 = text_处理.Replace("{", "")
        text_处理 = text_处理.Replace("}", "")
        text_处理 = text_处理.Replace("+", "")
    End Function

    Public Class QQDLL
        ''' <summary>
        ''' QQ调用普通截图
        ''' </summary>
        ''' <returns></returns>
        <Runtime.InteropServices.DllImport("CameraDll.dll", EntryPoint:="CameraSubArea")>
        Public Shared Function CameraSubArea(ByVal handle As Integer) As Integer
        End Function

        ''' <summary>
        ''' QQ根据窗口截图
        ''' </summary>
        ''' <returns></returns>
        <Runtime.InteropServices.DllImport("CameraDll.dll", EntryPoint:="CameraWindowLikeSpy")>
        Public Shared Function CameraWindowLikeSpy() As Integer
        End Function

    End Class
    Public Class WXDLL
        ''' <summary>
        ''' 微信普通截图
        ''' </summary>
        ''' <returns></returns>
        <Runtime.InteropServices.DllImport("PrScrn.dll", EntryPoint:="PrScrn")>
        Public Shared Function PrScrn() As Integer
        End Function

    End Class
End Module
