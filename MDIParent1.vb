Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub PrintPalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPalletToolStripMenuItem.Click

        Dim f As New frmPrintPalletHON
        f.MdiParent = Me
        f.Show()
    End Sub


    Private Sub CancelInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelInvoiceToolStripMenuItem.Click

        Dim f As New FrmReprintAndCancelInvoice
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MasterPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterPriceToolStripMenuItem.Click

        Dim f As New frmMPrice
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MasterProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterProductToolStripMenuItem.Click

        Dim f As New frmMProduct
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MasterStandardPackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim f As New frmMStandardPack
        f.MdiParent = Me
        f.Show()
    End Sub

  
    Private Sub SettingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStripMenuItem1.Click
        ' frmSetting.Show()
        Dim f As New frmSetting
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub CancelPalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelPalletToolStripMenuItem.Click
        ' frmCancelPallet.Show()
        Dim f As New frmCancelPallet
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub VerifyLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifyLabelToolStripMenuItem.Click
        ' frmVerifyData.Show()
        Dim f As New frmVerifyData
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub PrintDeliveryNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDeliveryNoteToolStripMenuItem.Click
        Dim f As New FrmPrintDeliNote
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub CancelDeliveryNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelDeliveryNoteToolStripMenuItem.Click
        Dim f As New FrmCancelDeli
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub GenerateInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateInvoiceToolStripMenuItem.Click

        Dim f As New FrnGenInvoice
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MasterLotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterLotToolStripMenuItem.Click

        Dim f As New frmMLotno
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MasterCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterCustomerToolStripMenuItem.Click
        Dim f As New frmMCustomer
        f.MdiParent = Me
        f.Show()
       
        ' frmMCustomer.Show()
    End Sub

    Private Sub SummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryReportToolStripMenuItem.Click
        Dim f As New frmSummReport
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub PrintPalletAATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPalletAATToolStripMenuItem.Click
        Dim f As New frmPrintPalletAAT
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub GenTextFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenTextFileToolStripMenuItem.Click
        Dim f As New frmFGFile
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
