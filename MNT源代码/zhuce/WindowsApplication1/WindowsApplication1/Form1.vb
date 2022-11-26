Imports System.IO
Imports System.Management
Public Class Form1
    Dim 当前路径 As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox2.Text = Change2(TextBox1.Text)) Then
            If My.Computer.FileSystem.FileExists(当前路径 + "\key.txt") Then
                Dim key_qidong() As String = File.ReadAllLines(当前路径 + "\key.txt")
                Dim key_txt_index As Integer = key_qidong.Length
                ReDim Preserve key_qidong(key_txt_index)
                key_qidong(key_txt_index) = Chr(13) + Change1("MTN_key:" + TextBox2.Text)
                File.WriteAllLines(当前路径 + "\key.txt", key_qidong)
                MsgBox("注册成功请重新启动MTN")
                End
            End If
        Else
            MsgBox("密码错误")
        End If
    End Sub
    Public Function Change2(ByVal Str1 As String) As String
        Dim tt As String = ""
        Dim Str_C As String = ""
        For i = 1 To Len(Str1) / 2
            tt = Mid(Str1, i * 2 - 1, 2)
            Str_C = Str_C & Chr(CInt(tt) + 30)
        Next
        Change2 = Str_C
    End Function
    Public Function Change1(ByVal Str1 As String) As String
        Dim tt As Char = ""
        Dim Str_B As String = ""
        For i = 1 To Len(Str1)
            tt = Mid(Str1, i, 1)
            Str_B = Str_B & (Asc(tt) - 30)
        Next
        Change1 = Str_B
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        当前路径 = Application.StartupPath()
        Dim mtn_key_t As String
        Dim mtn_key_t2 As String = ""
        Dim mtn_key_t1 As String()
        If My.Computer.FileSystem.FileExists(当前路径 + "\key.txt") Then
            Dim key_qidong() As String = File.ReadAllLines(当前路径 + "\key.txt")
            If key_qidong(0) = "" Then
                GoTo 结束
            Else
                mtn_key_t = Change2(key_qidong(0))
                mtn_key_t1 = mtn_key_t.Split({"[MTN]"}, StringSplitOptions.None)
                Label3.Text = key_qidong(1)
            End If
            If (mtn_key_t1.Length < 1) Then
                GoTo 结束
            Else
                If Array.FindIndex(mtn_key_t1, Function(s) s.Contains("qd:")) >= 0 Then
                    '获取密码
                    If Array.FindIndex(mtn_key_t1, Function(s) s.Contains("key:")) >= 0 Then
                        mtn_key_t2 = mtn_key_t1(1).Replace("key:", "")

                    Else
                        GoTo 结束
                    End If
                    '获取硬盘序列号
                    If Array.FindIndex(mtn_key_t1, Function(s) s.Contains("yp:")) >= 0 Then
                        Dim rootDiskNo As Integer
                        Dim cmicWmi2 As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition")

                        For Each cmicWmiObj As ManagementObject In cmicWmi2.Get
                            If cmicWmiObj("BootPartition") = True Then '判断当前分区是否为系统盘所在
                                rootDiskNo = cmicWmiObj("DiskIndex") '获得电脑中硬盘序号（形如0，1，2）
                            End If

                        Next

                        Dim rootDiskSerialNO As String = ""
                        Dim cmicWmi As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
                        For Each cmicWmiObj As ManagementObject In cmicWmi.Get
                            If cmicWmiObj("Index") = rootDiskNo Then
                                rootDiskSerialNO = cmicWmiObj("serialnumber")
                            End If
                        Next
                        mtn_key_t2 += "_" + rootDiskSerialNO

                    End If
                    '获取网卡mac地址
                    If Array.FindIndex(mtn_key_t1, Function(s) s.Contains("wk:")) >= 0 Then
                        Dim netid As String = ""
                        Dim ip As String
                        Dim searcher As New ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
                        Dim moc2 As ManagementObjectCollection = searcher.Get()
                        For Each mo As ManagementObject In moc2
                            If mo("IPEnabled") Then
                                netid = mo("MACAddress")
                                ip = mo("IpAddress")(0)
                                Exit For
                            End If
                        Next
                        mtn_key_t2 += "_" + netid

                    End If
                    '第一次启动时间
                    If Array.FindIndex(mtn_key_t1, Function(s) s.Contains("sj:")) >= 0 Then
                        If Array.FindIndex(key_qidong, Function(s) s.Contains("time:")) >= 0 Then
                            Dim key_time_index As Integer = 0
                            key_time_index = Array.FindIndex(key_qidong, Function(s) s.Contains("time:"))
                            mtn_key_t2 += "_" + key_qidong(key_time_index).Replace("time:", "")

                        Else
                            Dim key_txt_index As Integer = key_qidong.Length
                            ReDim Preserve key_qidong(key_txt_index)
                            key_qidong(key_txt_index) = Chr(13) + "time:" + DateTime.Now.ToString.Replace(" ", "")
                            File.WriteAllLines(当前路径 + "\key.txt", key_qidong)
                            Dim key_time_index As Integer = 0
                            key_time_index = Array.FindIndex(key_qidong, Function(s) s.Contains("time:"))
                            mtn_key_t2 += "_" + key_qidong(key_time_index).Replace("time:", "")
                        End If
                    End If
                Else
                    GoTo 结束
                End If
            End If

        Else
结束:
            MsgBox("请联系作者取得正确的KEY文件")
            End
        End If

        TextBox1.Text = Change1(mtn_key_t2)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
