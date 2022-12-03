Imports System.Text
Imports System.IO


Module Module2

    Public Sub cn_ssimp(ByVal path_ini As String, ByVal int_sort_no As Integer)
        Dim dic_ini_txt As New Dictionary(Of String, String)
        Dim ini_txt As TextReader = File.OpenText(path_ini)

        Dim ini_txt1 As String
        Dim ini_txt2 As String = ""
        While ini_txt.Peek() > -1
            ini_txt1 = ini_txt.ReadLine
            If (ini_txt1 <> "") Then
                If (ini_txt1.Split("=").Length > 1) Then

                    dic_ini_txt.Add(ini_txt2 + "_" + ini_txt1.Split("=")(0), ini_txt1.Split("=")(1))
                Else
                    ini_txt2 = ini_txt1.Replace("[", "").Replace("]", "")
                End If
            End If
        End While
        ini_txt.Close()
        ' MsgBox(dic_ini_txt.Item("form4_"))
        Form3.TabPage1.Text = cn_sort(ini_txt_valeu("form3", "tabpage1", dic_ini_txt), int_sort_no)
        Form3.TabPage2.Text = cn_sort(ini_txt_valeu("form3", "tabpage2", dic_ini_txt), int_sort_no)
        Form3.TabPage3.Text = cn_sort(ini_txt_valeu("form3", "tabpage3", dic_ini_txt), int_sort_no)
        Form3.TabPage4.Text = cn_sort(ini_txt_valeu("form3", "tabpage4", dic_ini_txt), int_sort_no)
        Form3.TabPage5.Text = cn_sort(ini_txt_valeu("form3", "tabpage5", dic_ini_txt), int_sort_no)
        Form3.TabPage6.Text = cn_sort(ini_txt_valeu("form3", "tabpage6", dic_ini_txt), int_sort_no)

        Form3.Button1.Text = cn_sort(ini_txt_valeu("form3", "Button1", dic_ini_txt), int_sort_no)
        Form3.Button2.Text = cn_sort(ini_txt_valeu("form3", "Button2", dic_ini_txt), int_sort_no)
        Form3.Button3.Text = cn_sort(ini_txt_valeu("form3", "Button3", dic_ini_txt), int_sort_no)
        Form3.Button4.Text = cn_sort(ini_txt_valeu("form3", "Button4", dic_ini_txt), int_sort_no)
        Form3.Button5.Text = cn_sort(ini_txt_valeu("form3", "Button5", dic_ini_txt), int_sort_no)
        Form3.Button6.Text = cn_sort(ini_txt_valeu("form3", "Button6", dic_ini_txt), int_sort_no)
        Form3.Button7.Text = cn_sort(ini_txt_valeu("form3", "Button7", dic_ini_txt), int_sort_no)
        Form3.Button8.Text = cn_sort(ini_txt_valeu("form3", "Button8", dic_ini_txt), int_sort_no)
        Form3.Button9.Text = cn_sort(ini_txt_valeu("form3", "Button9", dic_ini_txt), int_sort_no)
        Form3.Button10.Text = cn_sort(ini_txt_valeu("form3", "Button10", dic_ini_txt), int_sort_no)
        Form3.Button11.Text = cn_sort(ini_txt_valeu("form3", "Button11", dic_ini_txt), int_sort_no)
        Form3.Button12.Text = cn_sort(ini_txt_valeu("form3", "Button12", dic_ini_txt), int_sort_no)
        Form3.Button13.Text = cn_sort(ini_txt_valeu("form3", "Button13", dic_ini_txt), int_sort_no)
        Form3.Button14.Text = cn_sort(ini_txt_valeu("form3", "Button14", dic_ini_txt), int_sort_no)
        Form3.Button15.Text = cn_sort(ini_txt_valeu("form3", "Button15", dic_ini_txt), int_sort_no)
        Form3.Button16.Text = cn_sort(ini_txt_valeu("form3", "Button16", dic_ini_txt), int_sort_no)
        Form3.Button17.Text = cn_sort(ini_txt_valeu("form3", "Button17", dic_ini_txt), int_sort_no)
        Form3.Button18.Text = cn_sort(ini_txt_valeu("form3", "Button18", dic_ini_txt), int_sort_no)

        Form3.RadioButton1.Text = cn_sort(ini_txt_valeu("form3", "RadioButton1", dic_ini_txt), int_sort_no)
        Form3.RadioButton2.Text = cn_sort(ini_txt_valeu("form3", "RadioButton2", dic_ini_txt), int_sort_no)
        Form3.RadioButton3.Text = cn_sort(ini_txt_valeu("form3", "RadioButton3", dic_ini_txt), int_sort_no)

        Form3.ComboBox1.Text = cn_sort(ini_txt_valeu("form3", "ComboBox1", dic_ini_txt), int_sort_no)
        Form8.ComboBox1.Text = cn_sort(ini_txt_valeu("form3", "ComboBox1", dic_ini_txt), int_sort_no)

        Form3.ComboBox5.Text = cn_sort(ini_txt_valeu("form3", "ComboBox5_0", dic_ini_txt), int_sort_no)
        Form3.ComboBox5.Items(0) = cn_sort(ini_txt_valeu("form3", "ComboBox5_1", dic_ini_txt), int_sort_no)
        Form3.ComboBox5.Items(1) = cn_sort(ini_txt_valeu("form3", "ComboBox5_2", dic_ini_txt), int_sort_no)

        Form3.Label90.Text = cn_sort(ini_txt_valeu("form3", "Label90_0", dic_ini_txt) + Chr(13), int_sort_no)
        Form3.Label90.Text += cn_sort(ini_txt_valeu("form3", "Label90_1", dic_ini_txt), int_sort_no)

        Form3.Label1.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label2.Text = cn_sort(ini_txt_valeu("form3", "Label2", dic_ini_txt), int_sort_no)
        Form3.Label3.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label4.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label5.Text = cn_sort(ini_txt_valeu("form3", "Label_li", dic_ini_txt), int_sort_no)
        Form3.Label6.Text = cn_sort(ini_txt_valeu("form3", "Label6", dic_ini_txt), int_sort_no)
        Form3.Label7.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label8.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label9.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label10.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label11.Text = cn_sort(ini_txt_valeu("form3", "Label11", dic_ini_txt), int_sort_no)
        Form3.Label12.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label13.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label14.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label15.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label16.Text = cn_sort(ini_txt_valeu("form3", "Label16", dic_ini_txt), int_sort_no)
        Form3.Label17.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label18.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label19.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label20.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label21.Text = cn_sort(ini_txt_valeu("form3", "Label_fc", dic_ini_txt), int_sort_no)
        Form3.Label22.Text = cn_sort(ini_txt_valeu("form3", "Label_fz", dic_ini_txt), int_sort_no)
        Form3.Label23.Text = cn_sort(ini_txt_valeu("form3", "Label23", dic_ini_txt), int_sort_no)
        Form3.Label24.Text = cn_sort(ini_txt_valeu("form3", "Label_head", dic_ini_txt), int_sort_no)
        Form3.Label25.Text = cn_sort(ini_txt_valeu("form3", "Label25", dic_ini_txt), int_sort_no)
        Form3.Label26.Text = cn_sort(ini_txt_valeu("form3", "Label26", dic_ini_txt), int_sort_no)
        Form3.Label27.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label28.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label29.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label30.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label31.Text = cn_sort(ini_txt_valeu("form3", "Label_logo", dic_ini_txt), int_sort_no)
        Form3.Label32.Text = cn_sort(ini_txt_valeu("form3", "Label32", dic_ini_txt), int_sort_no)
        Form3.Label33.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label34.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label35.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label36.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label37.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)

        Form3.Label39.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label40.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label41.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label42.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label43.Text = cn_sort(ini_txt_valeu("form3", "Label43", dic_ini_txt), int_sort_no)
        Form3.Label44.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label45.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label46.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label47.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label48.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label49.Text = cn_sort(ini_txt_valeu("form3", "Label_fs", dic_ini_txt), int_sort_no)
        Form3.Label50.Text = cn_sort(ini_txt_valeu("form3", "Label50", dic_ini_txt), int_sort_no)
        Form3.Label51.Text = cn_sort(ini_txt_valeu("form3", "Label_fc", dic_ini_txt), int_sort_no)
        Form3.Label52.Text = cn_sort(ini_txt_valeu("form3", "Label_bg_c", dic_ini_txt), int_sort_no)
        Form3.Label53.Text = cn_sort(ini_txt_valeu("form3", "Label_fs", dic_ini_txt), int_sort_no)
        Form3.Label54.Text = cn_sort(ini_txt_valeu("form3", "Label_over", dic_ini_txt), int_sort_no)

        Form3.Label61.Text = cn_sort(ini_txt_valeu("form3", "Label_tr_x", dic_ini_txt), int_sort_no)
        Form3.Label62.Text = cn_sort(ini_txt_valeu("form3", "Label_tr_y", dic_ini_txt), int_sort_no)
        Form3.Label63.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label64.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label65.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        Form3.Label66.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label67.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label68.Text = cn_sort(ini_txt_valeu("form3", "Label68", dic_ini_txt), int_sort_no)
        Form3.Label69.Text = cn_sort(ini_txt_valeu("form3", "Label_m", dic_ini_txt), int_sort_no)
        Form3.Label70.Text = cn_sort(ini_txt_valeu("form3", "Label_m_img", dic_ini_txt), int_sort_no)
        Form3.Label71.Text = cn_sort(ini_txt_valeu("form3", "Label_tr_x", dic_ini_txt), int_sort_no)
        Form3.Label72.Text = cn_sort(ini_txt_valeu("form3", "Label_tr_y", dic_ini_txt), int_sort_no)
        Form3.Label73.Text = cn_sort(ini_txt_valeu("form3", "Label_t", dic_ini_txt), int_sort_no)
        Form3.Label74.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label75.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label76.Text = cn_sort(ini_txt_valeu("form3", "Label_bg_c", dic_ini_txt), int_sort_no)
        Form3.Label77.Text = cn_sort(ini_txt_valeu("form3", "Label_fc", dic_ini_txt), int_sort_no)
        Form3.Label78.Text = cn_sort(ini_txt_valeu("form3", "Label_font", dic_ini_txt), int_sort_no)
        Form3.Label79.Text = cn_sort(ini_txt_valeu("form3", "Label_fz", dic_ini_txt), int_sort_no)
        Form3.Label80.Text = cn_sort(ini_txt_valeu("form3", "Label_l", dic_ini_txt), int_sort_no)
        Form3.Label81.Text = cn_sort(ini_txt_valeu("form3", "Label_w", dic_ini_txt), int_sort_no)
        ' Form3.Label82.Text = cn_sort(ini_txt_valeu("form3", "Label_h", dic_ini_txt), int_sort_no)
        Form3.Label83.Text = cn_sort(ini_txt_valeu("form3", "Label_index", dic_ini_txt), int_sort_no)
        Form3.Label84.Text = cn_sort(ini_txt_valeu("form3", "Label_m", dic_ini_txt), int_sort_no)
        Form3.Label91.Text = cn_sort(ini_txt_valeu("form3", "label_body", dic_ini_txt), int_sort_no)

        Form3.Label93.Text = cn_sort(ini_txt_valeu("form3", "CheckBox1", dic_ini_txt), int_sort_no)
        Form3.CheckBox2.Text = cn_sort(ini_txt_valeu("form3", "CheckBox2", dic_ini_txt), int_sort_no)
        Form3.CheckBox3.Text = cn_sort(ini_txt_valeu("form3", "CheckBox3", dic_ini_txt), int_sort_no)






        Form4.Label1.Text = cn_sort(ini_txt_valeu("form4", "Label1", dic_ini_txt), int_sort_no)
        Form4.Label2.Text = cn_sort(ini_txt_valeu("form4", "Label2", dic_ini_txt), int_sort_no)
        Form4.Label3.Text = cn_sort(ini_txt_valeu("form4", "Label3", dic_ini_txt), int_sort_no)
        Form4.Label4.Text = cn_sort(ini_txt_valeu("form4", "Label4", dic_ini_txt), int_sort_no)
        Form4.Label5.Text = cn_sort(ini_txt_valeu("form4", "Label5", dic_ini_txt), int_sort_no)
        Form4.Label6.Text = cn_sort(ini_txt_valeu("form4", "Label6", dic_ini_txt), int_sort_no)

        Form4.Button1.Text = cn_sort(ini_txt_valeu("form4", "button", dic_ini_txt), int_sort_no)
        Form4.Button2.Text = cn_sort(ini_txt_valeu("form4", "button", dic_ini_txt), int_sort_no)
        Form4.Button3.Text = cn_sort(ini_txt_valeu("form4", "button", dic_ini_txt), int_sort_no)
        Form4.Button4.Text = cn_sort(ini_txt_valeu("form4", "button", dic_ini_txt), int_sort_no)
        Form4.Button5.Text = cn_sort(ini_txt_valeu("form4", "button5", dic_ini_txt), int_sort_no)
        Form4.Button6.Text = cn_sort(ini_txt_valeu("form4", "button", dic_ini_txt), int_sort_no)




        Form5.Label1.Text = cn_sort(ini_txt_valeu("form5", "Label1", dic_ini_txt), int_sort_no)
        Form5.Label2.Text = cn_sort(ini_txt_valeu("form5", "Label2", dic_ini_txt), int_sort_no)
        Form5.Label3.Text = cn_sort(ini_txt_valeu("form5", "Label3", dic_ini_txt), int_sort_no)
        Form5.Label4.Text = cn_sort(ini_txt_valeu("form5", "Label4", dic_ini_txt), int_sort_no)
        Form5.Label5.Text = cn_sort(ini_txt_valeu("form5", "Label5", dic_ini_txt), int_sort_no)
        Form5.Label6.Text = cn_sort(ini_txt_valeu("form5", "Label6", dic_ini_txt), int_sort_no)
        Form5.Label7.Text = cn_sort(ini_txt_valeu("form5", "Label7", dic_ini_txt), int_sort_no)
        Form5.Label8.Text = cn_sort(ini_txt_valeu("form5", "Label8", dic_ini_txt), int_sort_no)
        Form5.Label12.Text = cn_sort(ini_txt_valeu("form5", "Label12", dic_ini_txt), int_sort_no)
        Form5.Label11.Text = cn_sort(ini_txt_valeu("form5", "Label11", dic_ini_txt), int_sort_no)
        Form5.Button1.Text = cn_sort(ini_txt_valeu("form5", "button1", dic_ini_txt), int_sort_no)
        Form5.Button2.Text = cn_sort(ini_txt_valeu("form5", "button2", dic_ini_txt), int_sort_no)
    End Sub
    Public Function cn_sort(srt As String, sort As Integer) As String
        cn_sort = ""
        Select Case sort
            Case 0
                'cn_sort = (StrConv(srt, VbStrConv.SimplifiedChinese, 1033))

                'cn_sort = Encoding.Default.GetString(Encoding.Convert(Encoding.GetEncoding(936), Encoding.GetEncoding(950), Encoding.Default.GetBytes(srt)))
                cn_sort = srt
            Case 1
                'cn_sort = (StrConv(srt, VbStrConv.TraditionalChinese, 1033))

                'cn_sort = Encoding.Default.GetString(Encoding.Convert(Encoding.GetEncoding(950), Encoding.GetEncoding(936), Encoding.Default.GetBytes(srt)))
                cn_sort = srt
            Case Else

                cn_sort = srt

        End Select

    End Function
    Public Function ini_txt_valeu(ByVal ini_key As String, ByVal str_key As String, ByVal dic_ini_txt1 As Dictionary(Of String, String)) As String
        If dic_ini_txt1.ContainsKey(ini_key + "_" + str_key) Then
            ini_txt_valeu = dic_ini_txt1.Item(ini_key + "_" + str_key)
        Else
            ini_txt_valeu = ""
        End If

    End Function
End Module
