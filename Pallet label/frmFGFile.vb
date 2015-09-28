Imports System.IO
Imports System

Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Public Class frmFGFile
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB As DataTable
    Private strsql As String
    Private DN As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            DN = TextBox1.Text
            Dim FILE_NAME As String = "D:\DN" & DN & ".txt"
            Dim i As Integer
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            Dim DataDN, DataBar As String


            Getdata()
            For i = 0 To TB.Rows.Count - 1
                DataDN = TB.Rows(i).Item("pdelno").ToString & Mid("         ", 1, 15 - Len(TB.Rows(i).Item("pdelno")))
                DataBar = TB.Rows(i).Item("pqrdat").ToString & Mid("                                  ", 1, 120 - Len(TB.Rows(i).Item("pdelno")))
                objWriter.WriteLine(DataDN + DataBar)

            Next
            objWriter.Close()

        End If
    End Sub
    Function Getdata()
        OpenConn()
        DS.Tables.Clear()
        strsql = "select * from label where pdelno='" & DN & "'"

        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)

        Return TB
    End Function

End Class