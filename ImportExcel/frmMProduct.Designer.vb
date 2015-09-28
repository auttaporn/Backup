<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMProduct))
        Me.message = New System.Windows.Forms.Label
        Me.LBERR = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.No = New System.Windows.Forms.ColumnHeader
        Me.PPDNO = New System.Windows.Forms.ColumnHeader
        Me.PPCHG = New System.Windows.Forms.ColumnHeader
        Me.PMANH = New System.Windows.Forms.ColumnHeader
        Me.PMAKER = New System.Windows.Forms.ColumnHeader
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtfile = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dlg1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.lblTot = New System.Windows.Forms.Label
        Me.Pnam = New System.Windows.Forms.ColumnHeader
        Me.Pack = New System.Windows.Forms.ColumnHeader
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'message
        '
        Me.message.AutoSize = True
        Me.message.ForeColor = System.Drawing.Color.Red
        Me.message.Location = New System.Drawing.Point(223, 230)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(0, 13)
        Me.message.TabIndex = 20
        '
        'LBERR
        '
        Me.LBERR.AutoSize = True
        Me.LBERR.ForeColor = System.Drawing.Color.Red
        Me.LBERR.Location = New System.Drawing.Point(28, 254)
        Me.LBERR.Name = "LBERR"
        Me.LBERR.Size = New System.Drawing.Size(0, 13)
        Me.LBERR.TabIndex = 19
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.No, Me.PPDNO, Me.PPCHG, Me.Pnam, Me.Pack, Me.PMANH, Me.PMAKER})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(6, 15)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(760, 405)
        Me.ListView1.TabIndex = 18
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'No
        '
        Me.No.Text = "No"
        '
        'PPDNO
        '
        Me.PPDNO.Text = "Part No."
        Me.PPDNO.Width = 150
        '
        'PPCHG
        '
        Me.PPCHG.Text = "CHG"
        Me.PPCHG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PPCHG.Width = 80
        '
        'PMANH
        '
        Me.PMANH.DisplayIndex = 5
        Me.PMANH.Text = "Manhour"
        Me.PMANH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PMANH.Width = 99
        '
        'PMAKER
        '
        Me.PMAKER.Text = "Maker"
        Me.PMAKER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PMAKER.Width = 80
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.txtfile)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(208, 132)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(570, 62)
        Me.Panel2.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button2.Location = New System.Drawing.Point(485, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 34)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Search"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtfile
        '
        Me.txtfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtfile.Location = New System.Drawing.Point(153, 20)
        Me.txtfile.Name = "txtfile"
        Me.txtfile.Size = New System.Drawing.Size(306, 26)
        Me.txtfile.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(26, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Select File :"
        '
        'dlg1
        '
        Me.dlg1.FileName = "OpenFile"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(376, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 37)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Upload Product"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBERR)
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(112, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 426)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = Global.DeliverySystem.My.Resources.Resources.home_48
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(67, 42)
        Me.CloseToolStripMenuItem.Text = "  Close   "
        Me.CloseToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Image = Global.DeliverySystem.My.Resources.Resources.home_48
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(71, 41)
        Me.CloseToolStripMenuItem1.Text = "   Close   "
        Me.CloseToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CloseToolStripMenuItem2
        '
        Me.CloseToolStripMenuItem2.Name = "CloseToolStripMenuItem2"
        Me.CloseToolStripMenuItem2.Size = New System.Drawing.Size(63, 38)
        Me.CloseToolStripMenuItem2.Text = "Close"
        '
        'CloseToolStripMenuItem3
        '
        Me.CloseToolStripMenuItem3.Image = CType(resources.GetObject("CloseToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem3.Name = "CloseToolStripMenuItem3"
        Me.CloseToolStripMenuItem3.Size = New System.Drawing.Size(55, 42)
        Me.CloseToolStripMenuItem3.Text = "  Close"
        Me.CloseToolStripMenuItem3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CloseToolStripMenuItem4
        '
        Me.CloseToolStripMenuItem4.Image = CType(resources.GetObject("CloseToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem4.Name = "CloseToolStripMenuItem4"
        Me.CloseToolStripMenuItem4.Size = New System.Drawing.Size(63, 42)
        Me.CloseToolStripMenuItem4.Text = "  Close  "
        Me.CloseToolStripMenuItem4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CloseToolStripMenuItem5
        '
        Me.CloseToolStripMenuItem5.Image = CType(resources.GetObject("CloseToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem5.Name = "CloseToolStripMenuItem5"
        Me.CloseToolStripMenuItem5.Size = New System.Drawing.Size(66, 33)
        Me.CloseToolStripMenuItem5.Text = "    Close   "
        Me.CloseToolStripMenuItem5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator2})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1007, 37)
        Me.ToolStrip1.TabIndex = 57
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(79, 34)
        Me.ToolStripButton2.Text = "      Exit      "
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
        '
        'lblTot
        '
        Me.lblTot.AutoSize = True
        Me.lblTot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTot.Location = New System.Drawing.Point(739, 629)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(0, 13)
        Me.lblTot.TabIndex = 58
        '
        'Pnam
        '
        Me.Pnam.Text = "Part Name"
        Me.Pnam.Width = 200
        '
        'Pack
        '
        Me.Pack.Text = "Unit Pack"
        Me.Pack.Width = 80
        '
        'frmMProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1007, 663)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTot)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.message)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmMProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents message As System.Windows.Forms.Label
    Friend WithEvents LBERR As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents PPDNO As System.Windows.Forms.ColumnHeader
    Friend WithEvents PPCHG As System.Windows.Forms.ColumnHeader
    Friend WithEvents PMANH As System.Windows.Forms.ColumnHeader
    Friend WithEvents PMAKER As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtfile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dlg1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents No As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents Pnam As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pack As System.Windows.Forms.ColumnHeader
End Class
