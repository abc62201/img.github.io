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
    Public dx_joy As Boolean = False
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
    
    Public Function 首尾删除空格(fullString As String) As String

        If fullString <> "" Then
            fullString = fullString.Substring(0, InStr(fullString, vbNullChar) - 1)
        End If
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
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
End Module
