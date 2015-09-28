Imports System.Data.OleDb
Module main
    Public DD, MM, YYYY As String
    Public DMY, YMD, TME As String
    Public Comn As New OleDbConnection("Provider=SQLOLEDB;" & Configuration.GetConnectionstring)
    Public cm As OleDbCommand = New OleDbCommand
    Public DPlant As String = ""
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB As DataTable
    Private strsql As String
    Public DN As String

    Public Sub GetDate()
        'DD = Format(Day(Of Date), "00")

        DD = Format(Today.Day, "00")
        MM = Format(Today.Month, "00")
        Select Case Today.Year()
            Case Is > 2500 : YYYY = Today.Year() - 543
            Case Else : YYYY = Today.Year()
        End Select
        DMY = DD & "/" & MM & "/" & YYYY
        YMD = YYYY & MM & DD
        'TME = Today.Hour & ":" & Today.Minute & ":" & Today.Second
        'TME = Now.Hour &":"&  Now.Minute &":"& Now.Second
        TME = Now.Hour & Now.Minute & Now.Second
    End Sub
    Public Sub OpenConn()
        With Comn
            If Comn.State = ConnectionState.Open Then Comn.Close()
            Comn.Open()
        End With
    End Sub
    Public Sub GenText()
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
    End Sub

    Function Getdata()
        Dim strsql As String
        OpenConn()
        DS.Tables.Clear()
        strsql = "select * from label where pdelno='" & DN & "'"

        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)

        Return TB
    End Function

End Module
