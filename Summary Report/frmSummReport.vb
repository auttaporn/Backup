Imports System.IO
Imports System
Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Public Class frmSummReport
    Private Condi, DYMD1, DYMD2 As String
    Dim strsql As String
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB As DataTable

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For Each c As Control In GroupBox2.Controls
            If TypeOf c Is TextBox Then c.Text = ""

        Next
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then c.Text = ""

        Next

        dtp2.ResetText()
        dtp1.ResetText()

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        GetDel()

        If txtDn1.Text <> "" And txtDn2.Text <> "" Then
            Condi = " where  d.delno between '" & txtDn1.Text & "' and '" & txtDn2.Text & "' "
        End If
        DS.Clear()

        OpenConn()
        strsql = "select case when sum(p.Smanh)> 0 then sum(p.Smanh) else 0 end  as manh,case when sum(pdqty) > 0 then sum(pdqty) else 0 end  as qtyset  "
        strsql += "from delverynote d inner join mproduct p on d.pdno=p.Spdno "
        strsql += Condi

        Dim DA As New OleDbDataAdapter(strsql, Comn)


        DA.Fill(DS)

        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            txtSumMan.Text = TB.Rows(0).Item("manh").ToString
            txtTotSet.Text = TB.Rows(0).Item("qtyset").ToString
            lblMsg.Text = ""
        
        End If
        Comn.Close()

    End Sub
    Sub GetDel()
        Dim dDel1, dDel2 As Array
        dDel1 = dtp1.Text.Split("/")     ''MMDDYYYY      delivery date
        DYMD1 = dDel1(2) & dDel1(0) & dDel1(1)    ''YYYMMDD      delivery date


        dDel2 = dtp2.Text.Split("/")     ''MMDDYYYY      delivery date
        DYMD2 = dDel2(2) & dDel2(0) & dDel2(1)    ''YYYMMDD      delivery date
        Condi = "where d.deldt between " & DYMD1 & " and " & DYMD2 & " "


        
    End Sub

    Private Sub frmSummReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
    End Sub
End Class