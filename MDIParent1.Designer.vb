<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MasterDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MasterCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MasterProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MasterPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MasterLotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PalletLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelPalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerifyLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPalletAATToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeliveryNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDeliveryNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelDeliveryNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GenTextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GenerateInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SummaryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 601)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(808, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterDataToolStripMenuItem, Me.PalletLabelToolStripMenuItem, Me.DeliveryNoteToolStripMenuItem, Me.InvoiceToolStripMenuItem, Me.ReportToolStripMenuItem, Me.SettingToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(808, 29)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterDataToolStripMenuItem
        '
        Me.MasterDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterCustomerToolStripMenuItem, Me.MasterProductToolStripMenuItem, Me.MasterPriceToolStripMenuItem, Me.MasterLotToolStripMenuItem})
        Me.MasterDataToolStripMenuItem.Name = "MasterDataToolStripMenuItem"
        Me.MasterDataToolStripMenuItem.Size = New System.Drawing.Size(89, 25)
        Me.MasterDataToolStripMenuItem.Text = "Master Data"
        '
        'MasterCustomerToolStripMenuItem
        '
        Me.MasterCustomerToolStripMenuItem.Name = "MasterCustomerToolStripMenuItem"
        Me.MasterCustomerToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MasterCustomerToolStripMenuItem.Text = "Master Customer"
        '
        'MasterProductToolStripMenuItem
        '
        Me.MasterProductToolStripMenuItem.Name = "MasterProductToolStripMenuItem"
        Me.MasterProductToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MasterProductToolStripMenuItem.Text = "Master Product"
        '
        'MasterPriceToolStripMenuItem
        '
        Me.MasterPriceToolStripMenuItem.Name = "MasterPriceToolStripMenuItem"
        Me.MasterPriceToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MasterPriceToolStripMenuItem.Text = "Master Price"
        '
        'MasterLotToolStripMenuItem
        '
        Me.MasterLotToolStripMenuItem.Name = "MasterLotToolStripMenuItem"
        Me.MasterLotToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MasterLotToolStripMenuItem.Text = "Master Lot "
        '
        'PalletLabelToolStripMenuItem
        '
        Me.PalletLabelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPalletToolStripMenuItem, Me.CancelPalletToolStripMenuItem, Me.VerifyLabelToolStripMenuItem, Me.PrintPalletAATToolStripMenuItem})
        Me.PalletLabelToolStripMenuItem.Name = "PalletLabelToolStripMenuItem"
        Me.PalletLabelToolStripMenuItem.Size = New System.Drawing.Size(82, 25)
        Me.PalletLabelToolStripMenuItem.Text = "Pallet label"
        '
        'PrintPalletToolStripMenuItem
        '
        Me.PrintPalletToolStripMenuItem.Name = "PrintPalletToolStripMenuItem"
        Me.PrintPalletToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PrintPalletToolStripMenuItem.Text = "Print Pallet"
        '
        'CancelPalletToolStripMenuItem
        '
        Me.CancelPalletToolStripMenuItem.Name = "CancelPalletToolStripMenuItem"
        Me.CancelPalletToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CancelPalletToolStripMenuItem.Text = "Cancel Pallet"
        '
        'VerifyLabelToolStripMenuItem
        '
        Me.VerifyLabelToolStripMenuItem.Name = "VerifyLabelToolStripMenuItem"
        Me.VerifyLabelToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.VerifyLabelToolStripMenuItem.Text = "Verify Label"
        '
        'PrintPalletAATToolStripMenuItem
        '
        Me.PrintPalletAATToolStripMenuItem.Name = "PrintPalletAATToolStripMenuItem"
        Me.PrintPalletAATToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PrintPalletAATToolStripMenuItem.Text = "Print PalletAAT"
        '
        'DeliveryNoteToolStripMenuItem
        '
        Me.DeliveryNoteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintDeliveryNoteToolStripMenuItem, Me.CancelDeliveryNoteToolStripMenuItem, Me.GenTextFileToolStripMenuItem})
        Me.DeliveryNoteToolStripMenuItem.Name = "DeliveryNoteToolStripMenuItem"
        Me.DeliveryNoteToolStripMenuItem.Size = New System.Drawing.Size(95, 25)
        Me.DeliveryNoteToolStripMenuItem.Text = "Delivery Note"
        '
        'PrintDeliveryNoteToolStripMenuItem
        '
        Me.PrintDeliveryNoteToolStripMenuItem.Name = "PrintDeliveryNoteToolStripMenuItem"
        Me.PrintDeliveryNoteToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.PrintDeliveryNoteToolStripMenuItem.Text = "Print Delivery Note"
        '
        'CancelDeliveryNoteToolStripMenuItem
        '
        Me.CancelDeliveryNoteToolStripMenuItem.Name = "CancelDeliveryNoteToolStripMenuItem"
        Me.CancelDeliveryNoteToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CancelDeliveryNoteToolStripMenuItem.Text = "Cancel Delivery Note"
        '
        'GenTextFileToolStripMenuItem
        '
        Me.GenTextFileToolStripMenuItem.Name = "GenTextFileToolStripMenuItem"
        Me.GenTextFileToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.GenTextFileToolStripMenuItem.Text = "Gen Text File"
        '
        'InvoiceToolStripMenuItem
        '
        Me.InvoiceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateInvoiceToolStripMenuItem, Me.CancelInvoiceToolStripMenuItem})
        Me.InvoiceToolStripMenuItem.Name = "InvoiceToolStripMenuItem"
        Me.InvoiceToolStripMenuItem.Size = New System.Drawing.Size(60, 25)
        Me.InvoiceToolStripMenuItem.Text = "Invoice"
        '
        'GenerateInvoiceToolStripMenuItem
        '
        Me.GenerateInvoiceToolStripMenuItem.Name = "GenerateInvoiceToolStripMenuItem"
        Me.GenerateInvoiceToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.GenerateInvoiceToolStripMenuItem.Text = "Generate Invoice"
        '
        'CancelInvoiceToolStripMenuItem
        '
        Me.CancelInvoiceToolStripMenuItem.Name = "CancelInvoiceToolStripMenuItem"
        Me.CancelInvoiceToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CancelInvoiceToolStripMenuItem.Text = "Cancel Invoice"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryReportToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(58, 25)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'SummaryReportToolStripMenuItem
        '
        Me.SummaryReportToolStripMenuItem.Name = "SummaryReportToolStripMenuItem"
        Me.SummaryReportToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SummaryReportToolStripMenuItem.Text = "Summary Report"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingToolStripMenuItem1})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(60, 25)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'SettingToolStripMenuItem1
        '
        Me.SettingToolStripMenuItem1.Name = "SettingToolStripMenuItem1"
        Me.SettingToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.SettingToolStripMenuItem1.Text = "Setting"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(40, 25)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 623)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery System "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PalletLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelPalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerifyLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeliveryNoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDeliveryNoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelDeliveryNoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterPriceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterLotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPalletAATToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenTextFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
