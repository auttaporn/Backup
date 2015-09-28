Imports System.IO
Imports System
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO.Stream
Public Class frmVerifyData

    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB, dt As DataTable
    Private strsql As String
    Private DPallet, Dcar As String
    Private DPref, Dseq, Dpart, DSN, DCHG, Dlot, dDEL As String
    Private Sub frmVerifyData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPallbar.Focus()
        txtPallbar.BackColor = Color.LightGreen
        lblResult.Text = " "
    End Sub
   
    Private Sub txtPallbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallbar.KeyDown
        lblResult.Text = ""
        If txtPallbar.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                If Len(txtPallbar.Text) > 11 Then
                    MsgBox("Label is not Pallet label!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
                    txtPallbar.Text = ""
                    Exit Sub
                End If
                DPallet = txtPallbar.Text
                DPref = Mid(DPallet, 1, 5)
                Dseq = Mid(DPallet, 7, 5)

                txtCarbar.Focus()
            End If
        End If
    End Sub
    Private Sub txtCarbar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarbar.KeyDown
        If txtCarbar.Text <> "" Then
            If Len(txtCarbar.Text) < 10 Then
                MsgBox("Label is not carton label!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
                txtCarbar.Text = ""
                Exit Sub
            End If
            Dcar = txtCarbar.Text
            If e.KeyCode = Keys.Enter Then                              '2
                'Dim Abar As Array
                'Dim i, a As Integer

                'Abar = Dcar.Split(" ")
                'a = 0
                'For i = 0 To Abar.Length - 1

                '    If Abar(i).ToString <> "" Then
                '        Select Case a
                '            Case 0 : Dpart = Trim(Abar(i))
                '            Case 1 : DCHG = Trim(Abar(i))
                '            Case 2 : DLot = Trim(Abar(i))
                '            Case 3 : DSN = DLot & Mid(Trim(Abar(i)), 1, 5)

                '        End Select

                '        a += 1
                '    End If

                'Next

                Getdata()


            End If



         
        End If
    End Sub

    Private Sub txtPallbar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPallbar.GotFocus
        txtPallbar.BackColor = Color.LightGreen
    End Sub
    

    Private Sub txtPallbar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPallbar.LostFocus
        txtPallbar.BackColor = Color.White
    End Sub

    Private Sub txtCarbar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarbar.GotFocus
        txtCarbar.BackColor = Color.LightGreen
    End Sub


    Private Sub txtCarbar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarbar.LostFocus
        txtCarbar.BackColor = Color.White
    End Sub

    Sub Getdata()
        DS.Tables.Clear()
        'TB.Rows.Clear()
        OpenConn()
        strsql = "select *  from label where pprefx='" & DPref & "'and pseqno =" & Val(Dseq) & " and PQRDAT='" & Dcar & "' "
        strsql += "  AND PSTAT <> 'C' "
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            'lblResult.Text = "OK"
            'lblResult.ForeColor = Color.Blue
            dDEL = TB.Rows(0).Item("PDESC1")
            ChkPallet()

        Else
            lblResult.Text = "Incorrect data!!!"
            lblResult.ForeColor = Color.Red
            Comn.Close()
        End If
        ClearData()
        txtPallbar.Focus()
    End Sub
    Sub ClearData()
        txtPallbar.Text = ""
        txtCarbar.Text = ""

    End Sub
    Sub SaveToPallet()
        OpenConn()
        strsql = "insert into PALLET (PPREF,PSEQ,PDELD,PSTAT) values "
        strsql += "('" & DPref & "'," & Val(Dseq) & "," & dDEL & ",'Y')"
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = strsql
        cm.ExecuteNonQuery()
        Comn.Close()
    End Sub
    Sub ChkPallet()
        DS.Tables.Clear()
        'TB.Rows.Clear()
        OpenConn()
        strsql = "select *  from PALLET where ppref='" & DPref & "'and pseq =" & Val(Dseq) & "  "
        strsql += "  AND PSTAT ='Y' "
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count = 0 Then
            SaveToPallet()
        End If
    End Sub

   

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class