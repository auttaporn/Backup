Imports System.IO
Imports System
Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO.Stream
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class frmEmpty
    Private DS As DataSet = New DataSet()
    Private DA As New OleDbDataAdapter
    Private RW As DataRow
    Private TB, dt As DataTable
    Private strsql As String
    Public Dmak, Dy, DMM, DYMD, DYY As String
    Public PrePall, PRunn, PalNO As String
    Private DDel As Array
    Private DRun As Integer
    Private DPref, Dtype, DPlant As String
    Public dell, makk As String
    Dim RPT As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Public Overridable Sub PrintToPrinter(ByVal nCopies As Integer, ByVal collated As Boolean, ByVal startPageN As Integer, ByVal endPageN As Integer)

    End Sub

    Public Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim DEmp As String
        If txtEmpty.Text <> "" Then
            DEmp = Trim(txtEmpty.Text)

            GenPall()
            PalNO = PrePall & "-" & PRunn
            UpPalNo()
            'Call frmPrintPallet.WritePall()
            GetPrint()   ''print to pdf
            Me.Close()
        End If
    End Sub
    Public Sub GenPall()
      
        getVar()

        ''----- get running
        DS.Tables.Clear()
        'TB.Rows.Clear()
        OpenConn()
        strsql = "select *  from mdoc where dtype='" & Dtype & "'and dyear =" & DYY & " and dmonth=" & DMM & " "
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            DRun = Val(TB.Rows(0).Item("DRUNN")) + 1
            ' UpDoc(DRun)
        Else
            DRun = 1
            ' AddDoc(DRun)
        End If
        PRunn = Format(DRun, "00000")
        UpDoc(DRun)

        ''---------


    End Sub
    Public Sub getVar()

        ''---get del date---
        '  DDel = frmPrintPallet.dtp1.Text.Split("/")
        If makk = "H" Then
            DDel = frmPrintPalletHON.dtp1.Value.ToString.Split("/")
            Dy = Mid(DDel(2), 4, 1)
            DYY = Mid(DDel(2), 1, 4)
            DMM = DDel(0)
            DYMD = DYY & DMM & Format(CInt(DDel(1)), "00")
        Else
            Dy = Mid(dell, 4, 1)
            DYY = Mid(dell, 1, 4)
            DMM = Mid(dell, 5, 2)
            DYMD = DYY & DMM & Mid(dell, 7, 2)
        End If

        'Dy = Mid(DDel(2), 4, 1)
        'DYY = Mid(DDel(2), 1, 4)
        'DMM = DDel(0)
        'DYMD = DYY & DMM & Format(CInt(DDel(1)), "00")

        ''-- Get maker code (1)---
        Dmak = Mid(makk, 1, 1)

        GetPlant()
        ''--- Set pre fix of pallet no---
        PrePall = DPlant & Dmak & Dy & DMM


        Dtype = "PALLET-" & Dmak
        DPref = DPlant & Dmak

    End Sub
    Sub UpDoc(ByVal DRun As Integer)
        Dim sql As String

        getVar()
        Dim DPref As String = "A" & Dmak

        OpenConn()
        sql = "Update mdoc set drunn = " & DRun & ",dmonth=" & DMM & " , dyear=" & DYY & "  where "
        sql += "dtype='" & Dtype & "'"
        'sql = "Update mdoc set drunn = " & DRun & " where "
        '  sql += "dtype='" & Dtype & "' and dmonth=" & DMM & " and dyear=" & DYY & " "
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = sql
        cm.ExecuteNonQuery()
        Comn.Close()

    End Sub
    Sub AddDoc(ByVal DRun As Integer)
        Dim sql As String
        getVar()
        OpenConn()
        sql = "insert into mdoc (dtype,drunn,dpref,dmonth,dyear) values "
        sql += "('" & Dtype & "'," & DRun & ",'" & DPref & "'," & DMM & "," & DYY & ")"
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = sql
        cm.ExecuteNonQuery()
        Comn.Close()
    End Sub
    Private Sub UpPalNo()
        Dim sql As String
        On Error GoTo Err
        OpenConn()
        sql = "Update label set pprefx='" & PrePall & " ' , pseqno= " & DRun & ", pemtry ='" & Val(txtEmpty.Text) & "' "
        sql += " where PDELDT= " & DYMD & " and pprefx='' and pseqno=0 and pmaker  like '" & makk & "%'"
        cm.CommandType = CommandType.Text
        cm.Connection = Comn
        cm.CommandText = sql
        cm.ExecuteNonQuery()
        Comn.Close()
        Exit Sub
Err:
        MsgBox("Error!!", MsgBoxStyle.Critical)

    End Sub
    Public Sub GetPlant()
        DS.Clear()
        '  TB.Clear()

        strsql = "SELECT top 1 * FROM MPLANT"
        Dim DA As New OleDbDataAdapter(strsql, Comn)
        DA.Fill(DS)
        TB = DS.Tables(0)
        If TB.Rows.Count > 0 Then
            DPlant = Trim(TB.Rows(0).Item("pcode"))
        End If


    End Sub
    Sub GetPrint()
        Dim RPT As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim pa As String = Application.StartupPath


        RPT.Load(Application.StartupPath & "\report\rptPalLabel.rpt")
        RPT.SetDataSource(GetData)

        'RPT.PrintToPrinter(1, False, 0, 0)

        With frmPrev.CrystalReportViewer1
            .ReportSource = RPT

            .Refresh()

        End With

        frmPrev.Show()


        If makk = "H" Then
            frmPrintPalletHON.Redata()
        Else
            frmPrintPalletAAT.Redata()
        End If

        Me.Close()

    End Sub
    Function GetData()

        OpenConn()
        DS.Tables.Clear()
        strsql = "select  row_number ()  over (order by ppart) as no  ,ppart,ppdchg,sum(pbqty) as qty ,count(ppart) as car,pprefx,pseqno,pemtry from label "
        strsql += "where pstat='' and pprefx='" & PrePall & "' and pseqno='" & DRun & "' "
        strsql += "group by ppart,ppdchg,pprefx,pseqno,pemtry order by ppart "
        Dim DA As New OleDbDataAdapter(strsql, Comn)

        DA.Fill(DS)
        dt = DS.Tables(0)
        dt.TableName = "DLabel"
        Return dt
    End Function
 
   
End Class