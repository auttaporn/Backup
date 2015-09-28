
Imports System.Data.SqlClient
Public Class Configuration
    Public Shared Function GetConnectionstring() As String
        GetConnectionstring = System.Configuration.ConfigurationManager.AppSettings("conn")
    End Function
End Class

Public Class DatabaseConnection
    Public Function ExcuteNonQueryString(ByVal strcmd As String) As Integer
        Dim result As Integer
        result = 0
        Dim conn As New SqlConnection(Configuration.GetConnectionstring)
        Dim cmd As SqlCommand
        conn = New SqlConnection(Configuration.GetConnectionstring)
        cmd = New SqlCommand(strcmd, conn)
        Try
            conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch
            result = 0
        Finally
            conn.Close()
        End Try
        ExcuteNonQueryString = result
    End Function

    Public Function ExcuteQueryString(ByVal strcmd As String) As DataTable
        Dim ds As New DataSet()
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        conn = New SqlConnection(Configuration.GetConnectionstring)
        cmd = New SqlCommand(strcmd, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds)
        ExcuteQueryString = ds.Tables(0)

    End Function

    Public Function ExcuteScarlar(ByVal strcmd As String) As Object
        Dim result As Object
        'result = 0
        Dim conn As New SqlConnection(Configuration.GetConnectionstring)
        Dim cmd As SqlCommand
        conn = New SqlConnection(Configuration.GetConnectionstring)
        cmd = New SqlCommand(strcmd, conn)
        Try
            conn.Open()
            result = cmd.ExecuteScalar()
        Catch
            result = 0
        Finally
            conn.Close()
        End Try
        ExcuteScarlar = result
    End Function
    Public Function GetSystenDate() As Integer
        Dim str As String
        Dim cmd As String
        Dim d As Date
        cmd = "select getdate() as systemDate"
        d = CDate(ExcuteScarlar(cmd))
        str = d.Year.ToString() & d.Month.ToString().PadLeft(2, "0") & d.Day.ToString().PadLeft(2, "0")
        Return CInt(str)
    End Function
    
End Class
