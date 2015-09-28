Imports System.Data.SqlClient

Public Class FrmPrintDeliNote

    Private _dbConn As DatabaseConnection
    Private ReadOnly Property DBConnection() As DatabaseConnection
        Get
            If _dbConn Is Nothing Then
                _dbConn = New DatabaseConnection()
            End If
            Return _dbConn
        End Get
    End Property
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboBox()
        'DataGridView1.Rows.Clear()
    End Sub

    Private Sub LoadComboBox()
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString("select distinct CCUSNO,CCUSNM + '(' + CPLANT + ')' CCUSNM from mcustomer")
        cboCustomer.DataSource = dt
        cboCustomer.DisplayMember = "CCUSNM"
        cboCustomer.ValueMember = "CCUSNO"

        dt = DBConnection.ExcuteQueryString("select distinct SMAKER as PMAKER,SPDNO as PPDNO from mproduct where smaker is not null")
        cboMaker.DataSource = dt
        cboMaker.DisplayMember = "PMAKER"
        cboMaker.ValueMember = "PPDNO"
        'cboCustomer.DataBindings
    End Sub
    Private Sub dataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As DataGridViewRowsAddedEventArgs)
        'Dim i As Integer = 0
        'For i = e.RowIndex To (e.RowCount + e.RowIndex) Step 1
        '    If DataGridView1.Rows(i - 1).Cells("colQty").Value = 15 Then
        '        DataGridView1.Rows(i - 1).Cells("colChk").ReadOnly = True
        '    End If
        'Next
    End Sub
    Private Sub SetDatagrid()
        For Each r As DataGridViewRow In DataGridView1.Rows
            If Not r.Cells("colPrice").Value > 0 Then
                r.Cells("colChk").ReadOnly = True
                r.Cells("colRemark").Value = "Price Master is not found."
            End If
        Next
    End Sub
    Private Function ValidateRequiredField() As Boolean
        Dim result As Boolean = True
        Dim i As Integer = 0
        If txtTrunkNo.Text = "" Or txtDriver.Text = "" Then
            result = False
            MessageBox.Show("Please input required field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
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

    Private Sub LoadLabel(ByVal isShow As Boolean)
        Dim str As String
        str = String.Format("select L.PMODEL,PPREFX + '-' + cast(PSEQNO as varchar) as PalletNo,PPART,SUM(PBQTY) PBQTY,PPDCHG, " & _
        "COALESCE(MPPRC,0) MPPRC,COALESCE(SUPACK,0) SUPACK from LABEL L " & _
        "left join mprice mp on mp.MPPDNO = ppart " & _
        "left join MPRODUCT mt on mt.SPDNO = ppart " & _
        "where (PDELNO = '' OR PDELNO is  NULL) and PSTAT <> 'C' AND PCUST like '%{0}%' AND PMAKER like '%{1}%'  GROUP BY PPREFX,PSEQNO,PPART,PPDCHG,MPPRC,SUPACK,PMODEL", cboCustomer.SelectedValue.ToString(), cboMaker.Text)



        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString(str)
        DataGridView1.DataSource = dt
        If dt.Rows.Count = 0 Then
            If isShow Then
                MessageBox.Show("No data found", "Informaition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        With DataGridView1
            .Columns("colChk").DisplayIndex = 0
            .Columns("colModel").DisplayIndex = 1
            .Columns("colPalletNo").DisplayIndex = 2
            .Columns("colPartNo").DisplayIndex = 3
            .Columns("ColChg").DisplayIndex = 4
            .Columns("colPrice").DisplayIndex = 5
            .Columns("colRemark").DisplayIndex = 6
            .Columns("ColStdPack").DisplayIndex = 7
            .Columns("colQty").DisplayIndex = 8

        End With
        SetDatagrid()
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadLabel(True)
    End Sub

    Private Function GetShipTO() As String
        Dim shipto As String = ""
        If radTAPP.Checked Then
            shipto = radTAPP.Text
        ElseIf radKM20.Checked Then
            shipto = radKM20.Text
        ElseIf radKM36.Checked Then
            shipto = radKM36.Text
        ElseIf radKMETC.Checked Then
            shipto = radKMETC.Text
        End If
        Return shipto
    End Function
    Private Function convertDate(ByVal d As Date) As Integer
        Dim str As String
        str = d.Year.ToString() & d.Month.ToString().PadLeft(2, "0") & d.Day.ToString().PadLeft(2, "0")
        Return CInt(str)
    End Function

    Private Function GetDeliveryNo(ByVal types As String) As String
        Dim running As String
        Dim str As String
        Dim result As Integer
        str = String.Format("select count(*) cnt from Mdoc where dtype = '{0}' and dmonth = month(getdate()) and dyear = year(getdate())", types)
        result = DBConnection.ExcuteScarlar(str)
        If CInt(result) = 0 Then
            'str = String.Format("Insert into MDOC select '{0}',1,DPREF,month(getdate()),year(getdate()),DDESC from MDOC where dtype = '{1}'", types, types)
            str = String.Format("update MDOC set DRUNN = 1,DYEAR = year(getdate()),Dmonth = month(getdate()) " & _
                "where dtype = '{1}'", types, types)

            result = DBConnection.ExcuteNonQueryString(str)
            If result = 0 Then
                Return ""
            End If
        End If
        str = String.Format("select DPREF + right('00' + cast(DMONTH as varchar),2) + right('00' + cast(DRUNN as varchar),3) as delino " & _
            "from dbo.MDOC where DTYPE = '{0}' and DYEAR = year(getdate()) and Dmonth = month(getdate())", types)
        running = DBConnection.ExcuteScarlar(str).ToString()
        If running = "0" Then
            Return ""
        End If
        str = String.Format("Update MDOC set DRUNN = DRUNN + 1 where DTYPE = '{0}' and DYEAR = year(getdate()) and Dmonth = month(getdate())", types)
        DBConnection.ExcuteNonQueryString(str)
        Return running
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateRequiredField() = False Then
            Exit Sub
        End If
        Dim running_no As String
        Dim part_no As String
        Dim chg As Integer
        Dim shipto As String
        Dim remark As String
        Dim palletno As String
        Dim model As String
        Dim qty As Integer
        shipto = GetShipTO()
        If shipto.Length = 0 Then
            MessageBox.Show("Please select ship to", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        running_no = GetDeliveryNo("DELIVERY-A")
        If running_no = "" Then
            MessageBox.Show("Cannot Generate Running No. Please contact Suchawadee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim str As String
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells(0).Value Then
                qty = r.Cells("colQty").Value
                palletno = r.Cells("colPalletNo").Value
                part_no = r.Cells("colPartNo").Value
                chg = r.Cells("ColChg").Value
                remark = r.Cells("colRemark").Value
                model = r.Cells("colModel").Value

                '------ Insert Lot Number ----------------------------
                If Not ExecuteSqlTransaction(part_no, model, qty, chg, running_no, palletno) Then
                    MessageBox.Show("Master Lot Number not have a data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '------Insert Delivery Note    
                str = String.Format("insert into dbo.DELVERYNOTE(DELNO,DELDT,CUST,MAKER,SHPTO,ITEM,MODEL,PDNO,PDCHG,PDQTY, " & _
                 "UPACK,BXQTY,REMARK,STATUS,INVNO,TRUCK,DRIVER,PALLET_NO) " & _
                    "select '{0}',{1} delidate,PCUST,PMAKER,'{2}' ship,1,PMODEL MODEL,PPART,PPDCHG,sum(PBQTY), " & _
                 "SUPACK,count(PBQTY),'{3}' remark,'A','' inv,'{4}' trunk,'{5}' driver,'{6}' pallet_no " & _
                 "from  LABEL inner join MPRODUCT ON SPDNO = PPART AND SPCHG = PPDCHG " & _
                 "where  pprefx + '-' + cast(pseqno as varchar) = '{7}' and PPART = '{8}' and PPDCHG = {9} " & _
                 "GROUP BY PCUST,PMAKER,PMODEL,PPART,PPDCHG,SUPACK", running_no, convertDate(dtDeli.Value), shipto, remark, txtTrunkNo.Text, txtDriver.Text, palletno, palletno, part_no, chg)
                'cast(convert(varchar(10), getdate(), 112) as int)
                If DBConnection.ExcuteNonQueryString(str) = 0 Then
                    MessageBox.Show("Cannot save DeliveryNote. Please contact Adminsitrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '--- Update Label ------------
                str = String.Format("update LABEL set pdelno = '{0}',pdeldt = {1} where pprefx + '-' + cast(pseqno as varchar) = '{2}' and " & _
                        "PPART = '{3}' and PPDCHG = {4}", running_no, convertDate(DateTime.Now), palletno, part_no, chg)


                If DBConnection.ExcuteNonQueryString(str) = 0 Then
                    MessageBox.Show("Cannot update Label scan. Please contact Adminsitrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                
            End If
        Next
        txtDeliveryNo.Text = running_no
        MessageBox.Show("Save Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadLabel(False)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim f As New FrmRptDeliveryNo()
        f.Delivery_NO = txtDeliveryNo.Text
        f.MdiParent = MDIParent1
        f.Show()
        'FrmRptDeliveryNo.Show()
    End Sub

    Private Sub DataGridView1_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        SetDatagrid()
    End Sub

   
    Private Function ExecuteSqlTransaction(ByVal partno As String, ByVal model As String, ByVal qty As Integer, ByVal chg As String, ByVal running_no As String, ByVal pallet_no As String) As Boolean
        Using connection As New SqlConnection(Configuration.GetConnectionstring)
            connection.Open()

            Dim command As SqlCommand
            Dim transaction As SqlTransaction
            Dim qty_result As Integer
            ' Start a local transaction
            transaction = connection.BeginTransaction("SampleTransaction")
            Try
                command = connection.CreateCommand()
                command.Connection = connection
                command.Transaction = transaction
                command.CommandText = "sp_UpdateTransLot"
                command.CommandType = CommandType.StoredProcedure
                Do
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@partno", partno)
                    command.Parameters.AddWithValue("@model", model)
                    command.Parameters.AddWithValue("@qty", qty)
                    command.Parameters.AddWithValue("@chg", chg)
                    command.Parameters.AddWithValue("@running_no", running_no)
                    command.Parameters.AddWithValue("@pallet_no", pallet_no)
                    command.Parameters.Add("@qty_remain", SqlDbType.Int).Direction = ParameterDirection.Output

                    command.ExecuteNonQuery()
                    qty_result = CInt(command.Parameters("@qty_remain").Value)

                    If qty_result < 1 Then
                        Exit Do
                    End If
                    qty = qty_result
                Loop
                transaction.Commit()
                Return True
            Catch ex As Exception
                transaction.Rollback()
                Return False
            End Try
        End Using
    End Function

    Private Function GetStandartLot() As DataTable
        Dim str As String
        str = "select top 1 ISNULL(R.setremain,M.STDSET) setremain, M.STDSET" & _
             "from MLOTNO M  left join LOTRUN R on M.MODEL = R.MODEL and M.PARTNO = R.PARTNO AND M.MONTH = R.MONTH " & _
             "Order by M.MONTH"
        GetStandartLot = DBConnection.ExcuteQueryString(str)
    End Function

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtDeliveryNo.Text = "" Then
            MessageBox.Show("Please selected Delivery number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DN = txtDeliveryNo.Text
        'DN = DBConnection.GetSystenDate.ToString()
        GenText()
    End Sub
End Class
