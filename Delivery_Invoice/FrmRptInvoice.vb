Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class FrmRptInvoice
    Private m_invoice_no As String
    Public Property Invoice_NO()
        Get
            Return m_invoice_no
        End Get
        Set(ByVal value)
            m_invoice_no = value
        End Set
    End Property

    Private _dbConn As DatabaseConnection
    Private ReadOnly Property DBConnection() As DatabaseConnection
        Get
            If _dbConn Is Nothing Then
                _dbConn = New DatabaseConnection()
            End If
            Return _dbConn
        End Get
    End Property
    Private Sub FrmRptInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        Dim str As String
        str = Application.StartupPath & "\report\rptInvoice.rpt"
        rpt.Load(str)
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

       
        rpt.SetDataSource(LoadInvoiceDetail())
        rpt.SetDataSource(LoadInvoiceDetail())
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()

    End Sub

    Private Function LoadInvoiceDetail() As DataSet
        Dim str As String
        str = String.Format("select INVNO,DELINO DELNO,PARTNO PDNO,CHG PDCHG,QTY PDQTY,UPRICE MPPRC from invdel " & _
              "where INVNO = '{0}'", Invoice_NO)
      

        Dim ds As New DataSet()
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        conn = New SqlConnection(Configuration.GetConnectionstring)
        cmd = New SqlCommand(str, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "dtInvoice")

        str = String.Format("select INVNO,CUSTCODE CUST,INVDATE,ADDR1,ADDR2,ADDR3,TAXNO,PLANT from INVOICE " & _
              "where INVNO = '{0}'", Invoice_NO)

        cmd = New SqlCommand(str, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "dtInvoiceH")
        Return ds
    End Function
  
    
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class