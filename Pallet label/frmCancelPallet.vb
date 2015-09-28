Imports System.IO
Imports System
Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Public Class frmCancelPallet
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private TB As DataTable
    Dim strsql As String
    Dim DPre, Dseq As String
    Private Sub frmCancelPallet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnConfirm.Enabled = False
        txtCarton.Text = ""
    End Sub

    Private Sub txtCarton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarton.GotFocus
        txtCarton.BackColor = Color.LightGreen
    End Sub
    Private Sub txtCarton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarton.LostFocus
        txtCarton.BackColor = Color.White
    End Sub

    Private Sub txtCarton_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarton.KeyDown
        If txtCarton.Text <> "" Then
            If Len(txtCarton.Text) > 11 Then
                MsgBox("Incorect  ")
            Else

                DPre = Mid(txtCarton.Text, 1, 5)
                Dseq = Mid(txtCarton.Text, 7, 5)

                GetLabeldata()
            End If
        End If
    End Sub
    
    Sub GetLabeldata()

        Dim anyData() As String
        Dim lvi As ListViewItem
        Dim i, Cnt As Integer
        OpenConn()

        strsql = "select ppart,ppdchg,sum(pbqty)as qty ,count(ppart) as car from label "
        strsql += "where pstat='' and pprefx='" & DPre & "' and pseqno= " & CInt(Dseq) & " "
        strsql += "group by ppart,ppdchg order by ppart"
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            ListView1.Items.Clear()
            With ListView1
                For i = 0 To TB.Rows.Count - 1

                    anyData = New String() {.Items.Count.ToString + 1, TB.Rows(i).Item("ppart").ToString, TB.Rows(i).Item("ppdchg").ToString, TB.Rows(i).Item("qty").ToString, TB.Rows(i).Item("car").ToString}
                    lvi = New ListViewItem(anyData)
                    .Items.Add(lvi)
                    .EnsureVisible(ListView1.Items.Count.ToString - 1)

                    Cnt += TB.Rows(i).Item("car")
                Next
            End With
            btnConfirm.Enabled = True
        Else
            MsgBox("Data not found, Please check pallet label", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancel Pallet")
            btnConfirm.Enabled = False
        End If

    End Sub


    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If MsgBox("Do you want to cancel pallet no " & DPre & Format(CInt(Dseq), "00000"), MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Cancel Pallet") = MsgBoxResult.Yes Then
            ''update flag in label ="C"
            ''delete data on pallet (verified)
            UpLabel()
            DelPallet()


            MsgBox("Cancel pallet " & DPre & Format(CInt(Dseq), "00000") & " complete", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancel Pallet")
            ListView1.Items.Clear()
            btnConfirm.Enabled = False
            txtCarton.Text = ""

        End If
    End Sub
    Private Sub UpLabel()
        OpenConn()
        strsql = "update label  set pstat='C'"
        strsql += "where  pprefx='" & DPre & "' and pseqno= " & CInt(Dseq) & " "
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = strsql
        cm.ExecuteNonQuery()
        Comn.Close()





    End Sub
    Private Sub DelPallet()
        OpenConn()
        strsql = "delete pallet "
        strsql += "where  ppref='" & DPre & "' and pseq= " & CInt(Dseq) & " "
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = strsql
        cm.ExecuteNonQuery()
        Comn.Close()

    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class