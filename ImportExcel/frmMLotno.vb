Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
'Imports Syncfusion.XlsIO
Public Class frmMLotno
    Dim sql As String = ""
    Dim Founddata As String
    Dim arg0 As Object
    Dim sFilePath, sFileName As String
    Dim sSlash As Single
    Dim Xrow As Integer
    Private strConnSql As String = "Provider=SQLOLEDB;" & Configuration.GetConnectionstring
    'Private strConnSql As String = "Provider=SQLOLEDB;Password=db2005;User ID=sa;Persist Security Info=True;Initial Catalog=PBD;Data Source=YICO26SYS145\SQLEX2;Connect Timeout=10000;"
    'Private strCon400 As String = " Provider=IBMDA400;Data Source=10.200.1.5;User ID=TY#00006;Password=L333;"
    Private Conn As New OleDbConnection(strConnSql)
    Private DefaultPath As String = ("~/tmp/")
    'Private excelengine As New ExcelEngine
    'Private appExcel As IApplication = excelengine.Excel
    'Private Workbook As IWorkbook
    'Private sheet As IWorksheet
    'Private sheet2 As IWorksheet
    'Private sheet3, test1 As IWorksheet
    'Private oTable As New DataTable
    Private Path As String
    Private CNTREC, CNTREC2, CNTREC3 As Integer
    ' Private savePath As String = Server.MapPath("~/uploads/OtherJob/")
    Private aRecord(), aDetail()
    Private EffDate, MaxRec As Integer
    Private LOTNo, Month2, SetNo As Double
    Private Filename, tmpFilename, Status2, Uselot2, Model2, Suffix2, PartNo2 As String
    Private strdate As String = Date.Now.ToString("yyyyMMdd")
    Private strtime As Decimal = Date.Now.ToString("HHmm")
    Private objStreamReader
    Private Sub GetData() ''Load data to listliew
        Dim Temp, pid, pven, ppart As String
        Dim cellCnt As Integer
        Dim anyData1() As String
        Dim lvi1 As ListViewItem
        Dim MPPDNO, MPCHG, MPDTE, MPPRC As String
        Dim Rec As Integer = 0

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Clear()
        End If

        On Error GoTo MsErr

        Path = txtfile.Text

        Dim ds As New DataSet

        tmpFilename = "Test.csv"
        ' FileUpload1.SaveAs(Path & tmpFilename)
        Dim StartTime As String = Val(Date.Now.ToString("HHmm"))

        '*********** Open Text File ***************
        Dim objFile As New FileInfo(Path)
        Dim objStreamReader As StreamReader = objFile.OpenText()
        Dim data As String = objStreamReader.ReadToEnd()
        aRecord = data.Split(Chr(10))
        '************** end  ***************

        If (UBound(aRecord)) < 1 Then
            MaxRec = 0
        Else
            MaxRec = (UBound(aRecord))
        End If

        aDetail = aRecord(0).Split(",")

        Dim i As Integer = 97
        Dim x As Integer = 0
        Dim nl As Integer = 0
        Dim xRow As Integer = 1
        Dim Cl As String = ""
        Dim Cm As String = ""

        With ListView1

            For x = 1 To MaxRec

                aDetail = aRecord(x).Split(",")

                If aDetail(0) <> "" Then
                    PartNo2 = aDetail(1)
                    Suffix2 = aDetail(2)
                    Model2 = aDetail(3)
                    LOTNo = aDetail(4)
                    Month2 = aDetail(5)
                    SetNo = aDetail(6)


                    Status2 = 0
                    Uselot2 = 0
                    chkdata()

                    If CNTREC > 0 Or CNTREC3 > 0 Then
                        Dim item As New List(Of String)()
                        item.Add(x)
                        item.Add(Model2)
                        item.Add(PartNo2)
                        item.Add(Suffix2)
                        item.Add(LOTNo)
                        item.Add(Month2)
                        item.Add(SetNo)
                        item.Add(Status2)
                        item.Add(Uselot2)

                        Dim lvi As New ListViewItem(item.ToArray())

                        ListView1.Items.Add(lvi)
                        Rec += 1
                    End If

                End If


            Next

        End With

        If CNTREC > 0 Then
            message.Text = "Insert " & CNTREC & " Rows "
        End If

        If CNTREC3 > 0 Then
            message.Text += ",Update " & CNTREC3 & " Rows  "
        End If

        lblTot.Text = "Total: " & Rec
        Exit Sub

MsErr:
        MsgBox("Error on file, Please check Data", MsgBoxStyle.OkOnly)
        Exit Sub
    End Sub
    Sub chkdata()
        Dim strchk As String
        strchk = "select * from MLOTNO where model='" & Model2 & "' and partno='" & PartNo2 & "' and  chg='" & Suffix2 & "' and month='" & Month2 & "' "
        Dim da As New OleDbDataAdapter(strchk, Conn)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count = 0 Then
            savedata()
        ElseIf dt.Rows.Count = 1 And dt.Rows(0).Item("status") = "0" Then
            updatedata()
            'ElseIf dt.Rows.Count = 1 And dt.Rows(0).Item("status") = "1" Then
        End If
    End Sub
    Sub updatedata()
        Dim strsql2 As String
        strsql2 = "update MLOTNO set planlot='" & LOTNo & "',stdset='" & SetNo & "'  where model='" & Model2 & "' and partno='" & PartNo2 & "' and chg='" & Suffix2 & "' and month='" & Month2 & "' and status=0 "
        Dim CMD3 As New OleDbCommand(strsql2, Conn)
        CNTREC3 += CMD3.ExecuteNonQuery()

    End Sub

    Sub savedata()
        Dim strsql As String
        strsql = "insert into MLOTNO VALUES ( "
        strsql += " '" & Model2 & "', "
        strsql += " '" & PartNo2 & "', "
        strsql += " '" & Suffix2 & "', "
        strsql += " '" & LOTNo & "', "
        strsql += " '" & Month2 & "', "
        strsql += " '" & SetNo & "', "
        strsql += " '" & Status2 & "','" & Uselot2 & "') "

        Dim CMD As New OleDbCommand(strsql, Conn)
        CNTREC += CMD.ExecuteNonQuery()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        With dlg1
            .ShowDialog()
            .Filter = "File (*.xls)|*.xlsx|All files (*.*)|*.*"
            .Title = "Select File CSV"
            If Len(.FileName) > 0 Then
                txtfile.Text = .FileName
                Dim i As Integer = 0
                With ListView1

                    For i = 0 To .Items.Count - 1
                        ListView1.Columns.Add(.Items(i).SubItems(1).Text, 200)
                    Next
                End With
            End If

            If txtfile.Text <> "OpenFile" Then
                GetData()
            End If

        End With
        txtfile.Focus()
        txtfile.Text = ""
    End Sub

    Private Sub frmMLotno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CNTREC = 0
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

   
End Class