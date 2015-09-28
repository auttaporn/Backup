Imports System.IO
Imports System
'Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Public Class frmSetting
    Dim strsql As String
    Private DS As DataSet = New DataSet()
    Private TB, dt As DataTable
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCode.Text <> "" Then
            DS.Tables.Clear()
            OpenConn()
            strsql = "select * from mplant  "
            Dim DA As New OleDbDataAdapter(strsql, Comn)

            DA.Fill(DS)
            TB = DS.Tables(0)
            If TB.Rows.Count > 0 Then
                DelPalnt()
                SavePlant()
            Else
                SavePlant()
            End If
            txtCode.Text = ""
            txtName.Text = ""
        End If

    End Sub
    Sub SavePlant()
        OpenConn()
        strsql = " insert into mplant values('" & Trim(txtCode.Text).ToUpper & "','" & Trim(txtName.Text).ToUpper & "' )"
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = strsql
        cm.ExecuteNonQuery()
        Comn.Close()
        MsgBox("Saving Complete", MsgBoxStyle.Critical)
    End Sub
    Sub DelPalnt()
        OpenConn()
        strsql = " delete  from mplant "
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = strsql
        cm.ExecuteNonQuery()
        Comn.Close()
    End Sub
    
End Class