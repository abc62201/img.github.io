Imports System.Text
Imports SharpDX
Imports SharpDX.DirectInput
Module Module1
    Public pad As Joystick
    Public allEffects
    Public dx_joy As Boolean = False
    Public Function 首尾删除空格(fullString As String) As String
        If fullString <> "" Then
            fullString = fullString.Substring(0, InStr(fullString, vbNullChar) - 1)
        End If
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function
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

End Module
