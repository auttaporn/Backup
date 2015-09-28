Imports System.IO
Imports System
'Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared


Public Class frmPrintPalletAAT
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB1, TB, dt As DataTable

    Private strsql As String
    Private Cnt, dpack, Cqty As Integer
    Private BarData As String
    Private DPart, DCHG, DSN, DModel, DPName, DLot, Dmak As String
    '--- Path / Excel
    Private Rptpath As String = Application.StartupPath() & "\Temp"
    Private CurReportPath As String = Application.StartupPath() & "\RPT\"
    Private Filename As String
    Private DYMD As String
    Public Del As String
    Dim RPT As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim RptName As String = "rptPalletLabel.rpt"

    Private Sub frmPrintPalletHON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetCust()
        GetMaker()
        frmEmpty.GetPlant()
        Redata()

    End Sub
    Sub GetDel()
        Dim dDel As Array
        dDel = dtp1.Text.Split("/")     ''MMDDYYYY      delivery date
        DYMD = Mid(dDel(2), 1, 4) & dDel(0) & dDel(1)    ''YYYMMDD      delivery date
    End Sub

    Sub GetCust()

        DS.Tables.Clear()
        OpenConn()
        strsql = "select distinct cdesc1,ccusno from mcustomer order by cdesc1 "
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS, "mcustomer")
        TB1 = DS.Tables(0)
        If TB1.Rows.Count > 0 Then
            cboCust.DataSource = TB1
            cboCust.ValueMember = "ccusno"
            cboCust.DisplayMember = "cdesc1"
        End If

        Comn.Close()
    End Sub
    Public Sub GetMaker()
        'Dim TBM As DataTable
        'DS.Tables.Clear()

        'OpenConn()
        'strsql = "select distinct Smaker from mproduct order by Smaker "
        'Dim DA1 As New OleDbDataAdapter(strsql, Comn)

        'DA1.Fill(DS, "mproduct")
        'TBM = DS.Tables(0)
        'If TBM.Rows.Count > 0 Then
        '    cboMaker.DataSource = TBM
        '    cboMaker.ValueMember = "Smaker"
        '    cboMaker.DisplayMember = "Smaker"
        'End If

        'Comn.Close()

        cboMaker.Text = "AAT"
    End Sub
    Sub savePallet()


        If txtCarton.Text <> "" Then
            GetDate()
            GetDel()

            OpenConn()
            strsql = "Insert Into label (pprefx,pseqno,PCUST,PMAKER,PPART,PPDCHG,PSENO,PBQTY,PQRDAT,PITEM,"
            strsql += "PSTAT,PDELDT,PMODEL,PCRDT,PCTMT) values ("
            strsql += "'',0,'" & cboCust.SelectedValue.ToString & "','" & cboMaker.Text.ToUpper & "','" & DPart & "','" & DCHG & "',"
            strsql += "'" & DSN & "'," & Cqty & ",'" & BarData & "'," & Cnt & ",''," & DYMD & ",'" & DModel & "'," & YMD & ", " & TME & " )"
            cm.CommandType = CommandType.Text
            cm.Connection = Comn
            cm.CommandText = strsql
            cm.ExecuteNonQuery()
            Comn.Close()
        End If
        Redata()

    End Sub

    Private Sub txtCarton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarton.GotFocus
        txtCarton.BackColor = Color.LightGreen
        txtCarton.Enabled = True
    End Sub


    Private Sub txtCarton_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarton.KeyDown

        DPart = ""
        DCHG = ""
        If txtCarton.Text <> "" Then                                    '1
            BarData = txtCarton.Text
            If e.KeyCode = Keys.Enter Then                              '2
                Dim Abar As Array
                Dim i, a As Integer

                Abar = BarData.Split(" ")
                a = 0

                For i = 0 To Abar.Length - 1

                    If Abar(i).ToString <> "" Then

                        Select Case a
                            Case 0 : DPart = Trim(Abar(i))
                            Case 1 : DCHG = Trim(Abar(i))
                            Case 2 : DLot = Trim(Abar(i))
                                Cqty = Trim(Mid(DLot, 7, 3))
                                DSN = Mid(Trim(DLot), 1, 13)
                                DModel = Trim(Mid(DLot, 14, 15))

                            Case Else : If Abar(i).ToString <> cboMaker.Text.ToUpper Then
                                    DPName += Trim(Abar(i)) & " "
                                End If
                        End Select

                        a += 1
                    End If

                Next




                'DPart = Trim(Mid(BarData, 1, 14))
                'DCHG = Trim(Mid(BarData, 16, 4))
                'DLot = Trim(Mid(BarData, 19, 7))
                ' Cqty = Trim(Mid(DLot, 7, 3))
                ' DSN = Trim(Mid(BarData, 20, 14))
                ' DModel = Trim(Mid(BarData, 34, 18))
                ' DPName = Trim(Mid(BarData, 53, 25))
                Dmak = Trim(Mid(BarData, 97, 15)).ToUpper
                'If Dmak = "" Then Dmak = cboMaker.Text

                If Trim(Dmak) <> "" And Mid(Trim(Dmak), 1, 5).ToUpper <> cboMaker.Text.ToUpper Then
                    MsgBox("Carton label is not match with maker", MsgBoxStyle.Information)
                    txtCarton.Text = ""
                    txtCarton.BackColor = Color.LightGreen
                    Exit Sub
                End If

                'End Select
                Cnt += 1
                ChkSN()
            End If                                                      '1


            ''  GetSTDP()



        End If
    End Sub
    Sub ChkSN()
        '' serail are exist in label?

        DS.Tables.Clear()
        TB.Rows.Clear()
        OpenConn()
        strsql = "select *  from label where pstat<> 'C' and pqrdat='" & BarData & "' "
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count = 0 Then

            'Cqty = GetSTDP()
            'ChkPD()
            savePallet()
        Else
            MsgBox("Duplicate carton label, Please try again", MsgBoxStyle.OkOnly)
            Redata()
            Comn.Close()
            Exit Sub

        End If
    End Sub
    Sub ChkPD()
        '' check pd+CHG  are exist in label? 
        '' then count total qty
        Dim ddpack As Integer
        ddpack = GetSTDP()
        TB.Rows.Clear()
        DS.Tables.Clear()
        OpenConn()
        strsql = "select *  from label where pstat='' and ppart='" & DPart & "'and ppdchg='" & DCHG & "'  "
        Dim DA1 As New OleDbDataAdapter(strsql, Comn)
        DA1.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            Cqty = TB.Rows(0).Item("pbqty") + ddpack
        Else
            Cqty = TB.Rows(0).Item("pbqty")
        End If

        Comn.Close()
    End Sub
    Function GetSTDP()
        Dim dpack As Integer
        '' get qty / carton

        DS.Tables.Clear()
        TB.Rows.Clear()

        strsql = "select *  from mproduct where spdno='" & DPart & "' and spchg='" & DCHG & "' "
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            dpack = TB.Rows(0).Item("supack")
        Else
            dpack = 1
        End If
        Return dpack
    End Function
    Public Sub Redata()
        Dim anyData() As String
        Dim lvi As ListViewItem
        Dim i As Integer
        Cnt = 0

        OpenConn()
        DS.Tables.Clear()

        strsql = "select ppart,ppdchg,sum(pbqty)as qty ,count(ppart) as car,pmaker,pcust,PDELDT from label "
        strsql += "where pstat='' and  pprefx ='' and pseqno =0 and pmaker like '" & cboMaker.Text & "%' "
        strsql += "group by ppart,ppdchg,pmaker,pcust,PDELDT order by ppart"
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            ListView1.Items.Clear()
            With ListView1
                For i = 0 To TB.Rows.Count - 1

                    anyData = New String() {.Items.Count.ToString + 1, TB.Rows(i).Item("ppart").ToString, TB.Rows(i).Item("ppdchg").ToString, TB.Rows(i).Item("qty").ToString, TB.Rows(i).Item("car").ToString}
                    lvi = New ListViewItem(anyData)
                    .Items.Add(lvi)
                    .EnsureVisible(ListView1.Items.Count.ToString - 1)

                    Cnt += TB.Rows(i).Item("car")
                    'If i = 11 Then
                    '    MsgBox("Maximum part per pallet!!! Please cloase pallet", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Notice")
                    '    txtCarton.Enabled = False
                    'End If
                Next
            End With
            ' cboMaker.SelectedValue = TB.Rows(0).Item("pmaker").ToString
            cboCust.SelectedValue = TB.Rows(0).Item("pcust").ToString

            Del = TB.Rows(0).Item("pdeldt")
        Else
            Cnt = 0
        End If
        txtCarton.Text = ""

        lblCnt.Text = "Total Carton :" & Cnt
        Comn.Close()
    End Sub

    Private Sub btnCPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPallet.Click
        ' If MsgBox("Do you want to close pallet and print label", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If cboMaker.Text <> "" And cboCust.Text <> "" Then

            'frmEmpty.Show()
            Dim f As New frmEmpty()
            f.makk = cboMaker.Text
            f.dell = Del
            f.MdiParent = MDIParent1
            f.Show()

        End If

        'Else
        'Redata()
        'Exit Sub
        'End If

    End Sub
    'Public Sub WritePall()
    '    ' Dim Irow, i As Integer

    '    dt = GetData()
    '    If dt.Rows.Count > 0 Then
    '        ' GetPrint()
    '    End If

    'End Sub
    'Sub GetPrint()
    '    Dim RPT As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    Dim directory As String = My.Application.Info.DirectoryPath
    '    Dim pfs As New ParameterFields
    '    'ParameterValues()
    '    Dim prv0 As New ParameterDiscreteValue

    '    RPT.Load(Application.StartupPath & "\RPT\" & RptName)
    '    With frmPrev.CrystalReportViewer1
    '        .ReportSource = RPT

    '        .Refresh()

    '    End With

    '    frmPrev.Show()

    'End Sub
    Function GetData()
        'Dim PrePall As String = "AA411"
        'Dim PRunn As String = "2"
        GetDel()

        OpenConn()
        DS.Tables.Clear()
        'strsql += "where pstat='' and pprefx='" & PrePall & "' and pseqno=" & PRunn & " "
        '  strsql += "where pstat='' and pprefx='" & frmEmpty.PrePall & "' and pseqno='" & frmEmpty.PRunn & "' "
        strsql = "select ppart,ppdchg,sum(pbqty)as qty ,count(ppart) as car from label "
        strsql += "where pstat='' and pprefx='" & frmEmpty.PrePall & "' and pseqno='" & frmEmpty.PRunn & "' "
        strsql += "group by ppart,ppdchg order by ppart"
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        dt = DS.Tables(0)

        Return dt
    End Function

    Private Sub txtCarton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarton.LostFocus
        txtCarton.BackColor = Color.White
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class
