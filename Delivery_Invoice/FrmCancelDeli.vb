Public Class FrmCancelDeli
    Private _dbConn As DatabaseConnection
    Private ReadOnly Property DBConnection() As DatabaseConnection
        Get
            If _dbConn Is Nothing Then
                _dbConn = New DatabaseConnection()
            End If
            Return _dbConn
        End Get
    End Property
    Private Sub txtDeliveryNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeliveryNo.KeyPress

    End Sub

    Private Function ValidateRequiredField() As Boolean
        Dim result As Boolean = True
        Dim i As Integer = 0
       
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells(0).Value Then
                i = i + 1
            End If
        Next
        If i = 0 Then
            result = False
            MessageBox.Show("Please selected record.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return result
    End Function

    Private Sub txtDeliveryNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeliveryNo.KeyDown
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub FrmCancelDeli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click
        If ValidateRequiredField() = False Then
            Exit Sub
        End If
        Dim delno As String
        Dim str As String
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells("colChk").Value = True Then


                delno = r.Cells("colDeliveryNo").Value
                str = String.Format("update DELVERYNOTE set STATUS = 'C' where delno = '{0}'", delno)
                DBConnection.ExcuteNonQueryString(str)

                str = String.Format("update LABEL set pdelno = '',pdeldt = null where pdelno = '{0}'", delno)
                DBConnection.ExcuteNonQueryString(str)
            End If
        Next
        MessageBox.Show("Cancel Delivery Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadDelivery(False)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadDelivery(True)
    End Sub

    Private Sub LoadDelivery(ByVal isShow As Boolean)
        Dim str As String
        str = String.Format("select distinct DELNO,DELDT,INVNO from dbo.DELVERYNOTE where STATUS = 'A' and (DELNO = '{0}' or '{0}' = '')", txtDeliveryNo.Text)
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString(str)
        DataGridView1.DataSource = dt
        If dt.Rows.Count = 0 Then
            If isShow Then
                MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        SetDatagrid()
    End Sub

    Private Sub SetDatagrid()
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells("colInvoiceNo").Value.ToString.Length > 0 Then
                r.Cells("colChk").ReadOnly = True
            End If
        Next
    End Sub
End Class