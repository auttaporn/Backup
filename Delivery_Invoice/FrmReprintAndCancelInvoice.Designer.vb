<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReprintAndCancelInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.colInvNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInvDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCust = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExVatAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVatAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtInvEnd = New System.Windows.Forms.DateTimePicker
        Me.dtInvDateStart = New System.Windows.Forms.DateTimePicker
        Me.cboInvStatus = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNo, Me.colInvDate, Me.colCust, Me.colExVatAmt, Me.colVatAmt, Me.colTotAmt, Me.colStatus, Me.colCDate, Me.colCReason})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 252)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1104, 334)
        Me.DataGridView1.TabIndex = 0
        '
        'colInvNo
        '
        Me.colInvNo.DataPropertyName = "INVNO"
        Me.colInvNo.HeaderText = "Invoice No"
        Me.colInvNo.Name = "colInvNo"
        '
        'colInvDate
        '
        Me.colInvDate.DataPropertyName = "INVDATE"
        Me.colInvDate.HeaderText = "Invoice Date"
        Me.colInvDate.Name = "colInvDate"
        '
        'colCust
        '
        Me.colCust.DataPropertyName = "CUST"
        Me.colCust.HeaderText = "Customer Code"
        Me.colCust.Name = "colCust"
        '
        'colExVatAmt
        '
        Me.colExVatAmt.DataPropertyName = "EXAMT"
        Me.colExVatAmt.HeaderText = "Exclude Vat Amount"
        Me.colExVatAmt.Name = "colExVatAmt"
        '
        'colVatAmt
        '
        Me.colVatAmt.DataPropertyName = "VATAMT"
        Me.colVatAmt.HeaderText = "Vat Amount"
        Me.colVatAmt.Name = "colVatAmt"
        '
        'colTotAmt
        '
        Me.colTotAmt.DataPropertyName = "TOTAMT"
        Me.colTotAmt.HeaderText = "Total Amount"
        Me.colTotAmt.Name = "colTotAmt"
        '
        'colStatus
        '
        Me.colStatus.DataPropertyName = "STATUS"
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        '
        'colCDate
        '
        Me.colCDate.DataPropertyName = "CANCEL_DATE"
        Me.colCDate.HeaderText = "Cancel Date"
        Me.colCDate.Name = "colCDate"
        '
        'colCReason
        '
        Me.colCReason.HeaderText = "Cancel Reason"
        Me.colCReason.Name = "colCReason"
        Me.colCReason.Width = 200
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Reprint"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(728, 19)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(133, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel Invoice"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(447, 128)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Invoice No."
        '
        'txtInvoice
        '
        Me.txtInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtInvoice.Location = New System.Drawing.Point(174, 49)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(171, 22)
        Me.txtInvoice.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Invoice Date From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(352, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "To"
        '
        'dtInvEnd
        '
        Me.dtInvEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtInvEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInvEnd.Location = New System.Drawing.Point(405, 87)
        Me.dtInvEnd.Name = "dtInvEnd"
        Me.dtInvEnd.Size = New System.Drawing.Size(117, 22)
        Me.dtInvEnd.TabIndex = 8
        '
        'dtInvDateStart
        '
        Me.dtInvDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtInvDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInvDateStart.Location = New System.Drawing.Point(174, 92)
        Me.dtInvDateStart.Name = "dtInvDateStart"
        Me.dtInvDateStart.Size = New System.Drawing.Size(117, 22)
        Me.dtInvDateStart.TabIndex = 9
        '
        'cboInvStatus
        '
        Me.cboInvStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboInvStatus.FormattingEnabled = True
        Me.cboInvStatus.Location = New System.Drawing.Point(174, 128)
        Me.cboInvStatus.Name = "cboInvStatus"
        Me.cboInvStatus.Size = New System.Drawing.Size(121, 24)
        Me.cboInvStatus.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(68, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Invoice Status"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtReason)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 167)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1104, 63)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cancel Invoice"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(162, 19)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(517, 22)
        Me.txtReason.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Cancel Reason"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(12, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "แสดงผลการค้นหา"
        '
        'FrmReprintAndCancelInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 598)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboInvStatus)
        Me.Controls.Add(Me.dtInvDateStart)
        Me.Controls.Add(Me.dtInvEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmReprintAndCancelInvoice"
        Me.Text = "FrmReprintAndCancelInvoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtInvEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtInvDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboInvStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colInvNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExVatAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVatAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
