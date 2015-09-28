Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data


Public Class FrmRptDeliveryNo
    Private m_delivery_no As String
    Public Property Delivery_NO()
        Get
            Return m_delivery_no
        End Get
        Set(ByVal value)
            m_delivery_no = value
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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmRptDeliveryNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        Dim str As String
        str = Application.StartupPath & "\report\rptDeliveryNote.rpt"
        rpt.Load(str)
        Dim ds As New DataSet
        'ds.Tables.Add(LoadDelivery())
        rpt.SetDataSource(LoadDelivery())
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Function LoadDelivery() As DataTable
        Dim str As String
        str = String.Format("select DELNO,DELDT,CUST,MAKER,SHPTO,DN.MODEL,PDNO,PDCHG,PDQTY,LT.LOT_NO LOTNO,LT.SET_NO SETNO," & _
        "UPACK,BXQTY,REMARK,addr1,addr21,addr22,addr23,addr31,addr32,CPOST,DN.PALLET_NO PALLETNO,CTAXID from dbo.DELVERYNOTE DN " & _
        "INNER JOIN LOTTRANS LT ON LT.DELIVERY_NO = DN.DELNO AND DN.PALLET_NO = LT.PALLET_NO " & _
        "INNER JOIN (select CCUSNM addr1 , CADD1 addr21, ' ∂ππ' + CROAD as addr22, ' µ”∫≈' + CTAMB as addr23, " & _
        "'Õ”‡¿Õ' + CAMPH as addr31,' ®—ßÀ«—¥' + CPROV as addr32, CPOST,CCUSNO,CTAXID from MCUSTOMER) CU " & _
        "ON  CU.CCUSNO = DN.CUST  where (STATUS = 'A' or 1=1) AND DELNO = '{0}' Order by PDNO,DN.PALLET_NO,LT.MONTH", Delivery_NO)
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString(str)
        dt.TableName = "dtInvoice"
        Return dt
    End Function
End Class