Public Class FrnGenInvoice

    Private _dbConn As DatabaseConnection
    Private ReadOnly Property DBConnection() As DatabaseConnection
        Get
            If _dbConn Is Nothing Then
                _dbConn = New DatabaseConnection()
            End If
            Return _dbConn
        End Get
    End Property
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim str As String
        str = String.Format("select distinct DELNO,DELDT from dbo.DELVERYNOTE where STATUS = 'A' and (INVNO = '' or INVNO is null)" & _
                "and (shpto = '{0}' or '{0}' = '') and deldt between {1} and {2} and CUST = '{3}'", GetShipTO(), cDateInt(dtStart.Value), cDateInt(dtDeliveryTo.Value), cboCustomer.SelectedValue.ToString())
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString(str)
        DataGridView1.DataSource = dt
        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data found", "Informaition", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function GetShipTO() As String
        Dim shipto As String = ""
        If radTAPP.Checked Then
            shipto = radTAPP.Text
        ElseIf radKM20.Checked Then
            shipto = radKM20.Text
        ElseIf radKM36.Checked Then
            shipto = radKM36.Text
        ElseIf radETC.Checked Then
            shipto = radETC.Text
        End If
        Return shipto
    End Function
    Private Function cDateInt(ByVal d As Date) As Integer
        Return CInt(d.Year.ToString & d.Month.ToString().PadLeft(2, "0") & d.Day.ToString().PadLeft(2, "0"))
    End Function
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
    Private Function GetInvoiceNo(ByVal types As String) As String
        Dim running As String
        Dim str As String
        Dim result As Integer
        str = String.Format("select count(*) cnt from Mdoc where dtype = '{0}' and dmonth = month(getdate()) and dyear = year(getdate())", types)
        result = DBConnection.ExcuteScarlar(str)
        If CInt(result) = 0 Then
            'str = String.Format("Insert into MDOC select DTYPE,1,DPREF,month(getdate()),year(getdate()),DDESC from MDOC where dtype = {0}", types)
            str = String.Format("update MDOC set DRUNN = 1,DYEAR = year(getdate()),Dmonth = month(getdate()) " & _
                "where dtype = '{1}'", types, types)
            result = DBConnection.ExcuteNonQueryString(str)
            If result = 0 Then
                Return ""
            End If
        End If
        str = String.Format("select DPREF + substring(cast(DYEAR as varchar(4)),2,2) + right('00' + cast(DMONTH as varchar),2) + right('00' + cast(DRUNN as varchar),2) as delino " & _
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
        Dim str As String
        Dim running As String
        Dim isError As Boolean = False
        Dim result As Integer
        If ValidateRequiredField() = False Then
            Exit Sub
        End If
        running = GetInvoiceNo("INVOICE-A")
        If running = "" Then
            MessageBox.Show("Cannot Generate Running No. Please contact Suchawadee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        For Each dr As DataGridViewRow In DataGridView1.Rows
            If dr.Cells(0).Value Then
                
                str = String.Format("update DELVERYNOTE set INVNO = '{0}' where DELNO = '{1}' and STATUS = 'A'", running, dr.Cells(1).Value)
                result = DBConnection.ExcuteNonQueryString(str)
                If result = 0 Then
                    IsError = True
                    Exit For
                End If
            End If
        Next
        If isError = True Then
            str = String.Format("update DELVERYNOTE set INVNO = '' where INVNO = '{0}' and STATUS = 'A'", running)
            result = DBConnection.ExcuteNonQueryString(str)
            Exit Sub
        End If
        If InsertInvoiceDetail(running) Then
            InsertInvoiceHeader(running)
        End If
        txtInvoiceNo.Text = running
        MessageBox.Show("Generate invoice complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Function InsertInvoiceDetail(ByVal invno As String) As Boolean
        Dim str As String
        Dim result As Integer
        str = String.Format("insert into INVDEL(INVNO,PARTNO,CHG,QTY,UPRICE,AMOUNT,DELINO)" & _
        "select DN.INVNO,DN.PDNO,DN.PDCHG,DN.PDQTY,MP.MPPRC,DN.PDQTY*MP.MPPRC AMOUNT,DN.DELNO  from delverynote dn " & _
        "inner join MPRICE MP ON DN.PDNO = MP.MPPDNO AND DN.PDCHG = MP.MPCHG " & _
        "Where DN.INVNO = '{0}'", invno)
        result = DBConnection.ExcuteNonQueryString(str)
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function GetExtAmount(ByVal invno As String) As Decimal
        Dim str As String
        Dim result As Decimal
        str = String.Format("select SUM(DN.PDQTY*MP.MPPRC) AMOUNT from delverynote dn " & _
                "inner join MPRICE MP ON DN.PDNO = MP.MPPDNO AND DN.PDCHG = MP.MPCHG " & _
                "Where DN.INVNO = '{0}' GROUP BY DN.INVNO ", invno)
        result = CDec(DBConnection.ExcuteScarlar(str))
        Return result
    End Function

    Private Function InsertInvoiceHeader(ByVal invno As String) As Boolean
        Dim str As String
        Dim result As Integer
        Dim EXAMT As Decimal
        Dim VATAMT As Decimal
        Dim TOTAMT As Decimal
        EXAMT = GetExtAmount(invno)
        VATAMT = (EXAMT * 7) / 100
        TOTAMT = EXAMT + VATAMT
        str = String.Format("insert into INVOICE(INVNO,INVDATE,CREATE_DATE,STATUS,CUSTCODE,EXAMT,VATAMT,TOTAMT,ADDR1,ADDR2,ADDR3,PLANT,TAXNO)" & _
                "select top 1 '{0}',{1},{2},'A',CUST,{3},{4}," & _
                "{5},addr1,addr21 + ' ' + addr22 + ' ' + addr23,addr31 + ' ' + addr32 + ' ' + CPOST,CPLANT,TAXNO from dbo.DELVERYNOTE INNER JOIN " & _
                "(select CCUSNM addr1 , CADD1 addr21, ' ∂ππ' + CROAD as addr22, ' µ”∫≈' + CTAMB as addr23," & _
                "'Õ”‡¿Õ' + CAMPH as addr31,' ®—ßÀ«—¥' + CPROV as addr32, CPOST,CCUSNO,CPLANT,CTAXID TAXNO from MCUSTOMER) CU " & _
                "ON  CU.CCUSNO = CUST INNER JOIN mprice mp on mp.mppdno = pdno " & _
                "where STATUS = 'A' AND INVNO = '{6}'", invno, DBConnection.GetSystenDate(), DBConnection.GetSystenDate(), EXAMT, VATAMT, TOTAMT, invno)
        result = DBConnection.ExcuteNonQueryString(str)
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim f As New FrmRptInvoice()
        f.MdiParent = MDIParent1
        f.Invoice_NO = txtInvoiceNo.Text
        f.Show()
    End Sub

    Private Sub FrnGenInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboBox()
    End Sub
    Private Sub LoadComboBox()
        Dim dt As New DataTable
        dt = DBConnection.ExcuteQueryString("select CCUSNO,CCUSNM from mcustomer")
        cboCustomer.DataSource = dt
        cboCustomer.DisplayMember = "CCUSNM"
        cboCustomer.ValueMember = "CCUSNO"

       
    End Sub
End Class