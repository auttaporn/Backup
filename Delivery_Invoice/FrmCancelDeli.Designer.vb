<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCancelDeli
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnConform = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.colChk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colDeliveryNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDeliveryDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDeliveryNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConform
        '
        Me.btnConform.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConform.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnConform.Location = New System.Drawing.Point(666, 507)
        Me.btnConform.Name = "btnConform"
        Me.btnConform.Size = New System.Drawing.Size(75, 23)
        Me.btnConform.TabIndex = 0
        Me.btnConform.Text = "Confirm"
        Me.btnConform.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChk, Me.colDeliveryNo, Me.colDeliveryDate, Me.colInvoiceNo})
        Me.DataGridView1.Location = New System.Drawing.Point(25, 166)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(716, 322)
        Me.DataGridView1.TabIndex = 1
        '
        'colChk
        '
        Me.colChk.HeaderText = ""
        Me.colChk.Name = "colChk"
        Me.colChk.Width = 50
        '
        'colDeliveryNo
        '
        Me.colDeliveryNo.DataPropertyName = "DELNO"
        Me.colDeliveryNo.HeaderText = "Delivery No"
        Me.colDeliveryNo.Name = "colDeliveryNo"
        Me.colDeliveryNo.ReadOnly = True
        Me.colDeliveryNo.Width = 160
        '
        'colDeliveryDate
        '
        Me.colDeliveryDate.DataPropertyName = "DELDT"
        Me.colDeliveryDate.HeaderText = "Delivery Date"
        Me.colDeliveryDate.Name = "colDeliveryDate"
        Me.colDeliveryDate.ReadOnly = True
        Me.colDeliveryDate.Width = 160
        '
        'colInvoiceNo
        '
        Me.colInvoiceNo.DataPropertyName = "invno"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colInvoiceNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colInvoiceNo.HeaderText = "Invoice No"
        Me.colInvoiceNo.Name = "colInvoiceNo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Delivery Note No."
        '
        'txtDeliveryNo
        '
        Me.txtDeliveryNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDeliveryNo.Location = New System.Drawing.Point(185, 96)
        Me.txtDeliveryNo.Name = "txtDeliveryNo"
        Me.txtDeliveryNo.Size = New System.Drawing.Size(222, 22)
        Me.txtDeliveryNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cancel Delivery Note"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(443, 96)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(22, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "แสดงผลการค้นหา"
        '
        'FrmCancelDeli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 542)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDeliveryNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnConform)
        Me.Name = "FrmCancelDeli"
        Me.Text = "Cancel Delivery Note"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConform As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents colChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDeliveryNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeliveryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
