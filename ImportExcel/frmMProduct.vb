Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
'Imports Syncfusion.XlsIO
Public Class frmMProduct
    Dim sql As String = ""
    Dim Founddata As String
    Dim arg0 As Object
    Dim sFilePath, sFileName As String
    Dim sSlash As Single
    Dim Xrow As Integer
    Private strConnSql As String = "Provider=SQLOLEDB;" & Configuration.GetConnectionstring
    ' Private strConnSql As String = "Provider=SQLOLEDB;Password=db2005;User ID=sa;Persist Security Info=True;Initial Catalog=PBD;Data Source=YICO26SYS145\SQLEX2;Connect Timeout=10000;"
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
    Private MaxRec As Integer
    Private MANHOUR As Double
    Private Filename, tmpFilename, suffix, PartNo, MAKER, DPnam, DPack As String
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

                    PartNo = aDetail(1)
                    suffix = aDetail(2)
                    DPnam = aDetail(3)
                    DPack = aDetail(4)
                    MANHOUR = aDetail(5)
                    MAKER = aDetail(6)

                    chkdata()

                    If CNTREC > 0 Or CNTREC3 > 0 Then
                        Dim item As New List(Of String)()
                        item.Add(x)
                        item.Add(PartNo)
                        item.Add(suffix)
                        item.Add(DPnam)
                        item.Add(DPack)
                        item.Add(MANHOUR)
                        item.Add(MAKER)

                        Dim lvi As New ListViewItem(item.ToArray())
                        ListView1.Items.Add(lvi)
                        Rec += 1
                    End If

                End If

            Next

        End With
        lblTot.Text = "Total: " & Rec
        Exit Sub

MsErr:
        MsgBox("Error on file, Please check Data", MsgBoxStyle.OkOnly)
        Exit Sub
    End Sub
    Sub chkdata()
        Dim strchk As String
        strchk = "select count(*) from MProduct where spdno='" & PartNo & "' and spchg='" & suffix & "'"
        Dim CMD2 As New OleDbCommand(strchk, Conn)
        CNTREC2 = CMD2.ExecuteScalar

        If CNTREC2 = 0 Then
            savedata()
        Else
            updatedata()
        End If
    End Sub
    Sub updatedata()
        Dim strsql2 As String
        strsql2 = "update MProduct set smanh='" & MANHOUR & "',spdnm= '" & DPnam & "',supack ='" & DPack & "' "
        strsql2 += "where spdno='" & PartNo & "' and spchg='" & suffix & "'  "
        Dim CMD3 As New OleDbCommand(strsql2, Conn)
        CNTREC3 = CMD3.ExecuteNonQuery()

    End Sub
    Sub savedata()
        Dim strsql As String
        strsql = "insert into MPRODUCT  "
        strsql += " ( spdno,spchg,spdnm,supack,smanh,smaker )"
        strsql += "VALUES ( "
        strsql += " '" & PartNo & "', "
        strsql += " '" & suffix & "', "
        strsql += " '" & DPnam & "', "
        strsql += " '" & DPack & "', "
        strsql += " '" & MANHOUR & "', "
        strsql += " '" & MAKER & "') "
        Dim CMD As New OleDbCommand(strsql, Conn)
        CNTREC = CMD.ExecuteNonQuery()

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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub frmMProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTot.Text = ""
    End Sub

End Class