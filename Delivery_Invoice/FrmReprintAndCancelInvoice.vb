Public Class FrmReprintAndCancelInvoice
    Private _dbConn As DatabaseConnection
    Private ReadOnly Property DBConnection() As DatabaseConnection
        Get
            If _dbConn Is Nothing Then
                _dbConn = New DatabaseConnection()
            End If
            Return _dbConn
        End Get
    End Property
    Private Function cDateInt(ByVal d As Date) As Integer
        Return CInt(d.Year.ToString & d.Month.ToString().PadLeft(2, "0") & d.Day.ToString().PadLeft(2, "0"))
    End Function
    Private Sub LoadInvoice(ByVal isShow As Boolean)
        Dim str As String
        Dim status As String
        status = IIf(cboInvStatus.SelectedIndex = 0, "A", "C")
        str = String.Format("select IVH.INVNO,IVH.CUSTCODE CUST,IVH.INVDATE,CANCEL_DATE," & _
              "CASE WHEN IVH.STATUS = 'A' then 'ACTIVE' WHEN IVH.STATUS = 'C' Then 'CANCEL' end STATUS,CANCEL_REASON,IVH.EXAMT,IVH.VATAMT,IVH.TOTAMT " & _
              "from INVOICE IVH where ivh.status = '{0}' and ivh.invdate between {1} and {2} " & _
              "and ivh.invno like '{3}%'", status, cDateInt(dtInvDateStart.Value), cDateInt(dtInvEnd.Value), txtInvoice.Text)
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString(str)
        DataGridView1.DataSource = dt
        If dt.Rows.Count = 0 Then
            If isShow Then
                MessageBox.Show("No data found", "Informaition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadInvoice(True)
    End Sub

    Private Sub btnReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboInvStatus.Items.Insert(0, "Active")
        cboInvStatus.Items.Insert(1, "Cancel")
        cboInvStatus.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New FrmRptInvoice()
        f.MdiParent = MDIParent1
        Dim invNo As String
        invNo = ""
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Selected = True Then
                invNo = r.Cells("colInvNo").Value.ToString()
            End If
        Next
        If invNo = "" Then
            MessageBox.Show("Please selected inovice from table.")
            Exit Sub
        End If
        f.Invoice_NO = invNo
        f.Show()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim str As String
        Dim invNo As String
        Dim result As Integer
        invNo = ""
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Selected = True Then
                invNo = r.Cells("colInvNo").Value.ToString()
            End If
        Next
        If invNo = "" Then
            MessageBox.Show("Please selected inovice from table.")
            Exit Sub
        End If
        str = String.Format("update invoice set status = 'C' ,CANCEL_DATE = {0},CANCEL_REASON = '{1}' " & _
                "where INVNO = '{2}'", DBConnection.GetSystenDate, txtReason.Text, invNo)
        result = DBConnection.ExcuteNonQueryString(str)
        If result > 0 Then
            str = String.Format("update DELVERYNOTE set INVNO = '' where INVNO = '{0}'", invNo)
            DBConnection.ExcuteNonQueryString(str)
            MessageBox.Show("Cancel Invoice Complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInvoice(False)
        End If
    End Sub
End Class