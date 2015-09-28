Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Public Class frmMCustomer
    Private strConnSql As String = "Provider=SQLOLEDB;" & Configuration.GetConnectionstring
    'Private strConnSql As String = "Provider=SQLOLEDB;Password=db2005;User ID=sa;Persist Security Info=True;Initial Catalog=PBD;Data Source=YICO26SYS145\SQLEX2;Connect Timeout=10000;"
    Private Conn As New OleDbConnection(strConnSql)
    Private CNTREC, CNTREC2 As Integer
    Private Stdpack As Integer
    Private CustName, CustCode, ShortName, PlantCode, Address2, Address, Post, Amphur, Tambol, Province, Road, TaxId, Saleman As String
    Private strdate As String = Date.Now.ToString("yyyyMMdd")
    Private strtime As Decimal = Date.Now.ToString("HHmm")

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        On Error GoTo MsErr2
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        CustCode = txtCode.Text
        CustName = txtName.Text
        ShortName = txtShrtName.Text


        Address = txtAddress.Text
        Amphur = txtamp.Text
        Tambol = txttam.Text
        Province = txtpro.Text
        Road = txtRoad.Text

        If CustCode = "32T1" Then
            PlantCode = "00001"
        ElseIf CustCode = "32T3" Then
            PlantCode = "00003"
        End If

        Post = txtPost.Text
        TaxId = txtTaxID.Text
        Saleman = ""

        insertdata()
        Exit Sub

MsErr2:
        MsgBox("Please check Data", MsgBoxStyle.OkOnly)
        Exit Sub
    End Sub
    Sub updatedata()
        Dim strup As String
        strup = "update MCustomer set CADD1='" & Address & "',CCUSNM='" & CustName & "', CROAD='" & Road & "', CTAMB='" & Tambol & "',"
        strup += " CAMPH='" & Amphur & "',CPROV='" & Province & "',CPOST='" & Post & "',CTAXID='" & TaxId & "'"
        strup += " where CCUSNO='" & CustCode & "' and CPLANT='" & PlantCode & "' "
        Dim CMD2 As New OleDbCommand(strup, Conn)
        CNTREC2 = CMD2.ExecuteNonQuery()

        If CNTREC2 > 0 Then
            lberr.Text = "Update Data Complete."
            GETDATA()
        End If
    End Sub
    Sub insertdata()

        Dim stradd As String
        stradd = "insert into MCustomer VALUES ( "
        stradd += " '" & CustCode & "', "
        stradd += " '" & CustName & "', "
        stradd += " '" & PlantCode & "', "
        stradd += " '" & Address & "', "
        stradd += " '" & Address2 & "', "
        stradd += " '" & Road & "', "
        stradd += " '" & Tambol & "', "
        stradd += " '" & Amphur & "', "
        stradd += " '" & Province & "', "
        stradd += " '" & Post & "', "
        stradd += " '" & TaxId & "', "
        stradd += " '" & Saleman & "', "
        stradd += " '" & ShortName & "', " 'Desc
        stradd += " '', "
        stradd += " " & strdate & ", "
        stradd += " " & strtime & ", "
        stradd += " '') "
        Dim CMD As New OleDbCommand(stradd, Conn)
        CNTREC = CMD.ExecuteNonQuery()

        If CNTREC > 0 Then
            lberr.Text = "Add Data Complete."
            GETDATA()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error GoTo MsErr3
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        CustCode = txtCode.Text
        CustName = txtName.Text
        ShortName = txtShrtName.Text

        If CustCode = "32T1" Then
            PlantCode = "00001"
        ElseIf CustCode = "32T3" Then
            PlantCode = "00003"
        End If

        Address = txtAddress.Text
        Amphur = txtamp.Text
        Tambol = txttam.Text
        Province = txtpro.Text
        Road = txtRoad.Text

        Post = txtPost.Text
        TaxId = txtTaxID.Text
        Saleman = ""

        updatedata()
        Exit Sub

MsErr3:
        MsgBox("Please check Data", MsgBoxStyle.OkOnly)
        Exit Sub
    End Sub
    Sub GETDATA()
        Dim oLinkLabel As New LinkLabel
        Dim strsql As String
        Dim dr As DataRow

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Clear()
        End If

        strsql = "select * from MCustomer"
        Dim da As New OleDbDataAdapter(strsql, Conn)
        Dim dt As New DataTable
        da.Fill(dt)

        If dt.Rows.Count > 0 Then

            For Each dr In dt.Rows
                CustCode = dr.Item("CCUSNO")
                CustName = dr.Item("CCUSNM")
                Address = dr.Item("CADD1")
                Post = dr.Item("CPOST")
                TaxId = dr.Item("CTAXID")
                Saleman = dr.Item("CSALEM")
                Amphur = dr.Item("CAMPH")
                Tambol = dr.Item("CTAMB")
                Province = dr.Item("CPROV")
                Road = dr.Item("CROAD")
                ShortName = dr.Item("cdesc1")

                Dim item As New List(Of String)()
                item.Add(CustCode)
                item.Add(CustName)
                item.Add(Address)
                item.Add(Road)
                item.Add(Tambol)
                item.Add(Amphur)
                item.Add(Province)
                item.Add(Post)
                item.Add(TaxId)
                item.Add(ShortName)
                Dim lvi As New ListViewItem(item.ToArray())

                ListView1.Items.Add(lvi)
            Next

        Else
            lberr.Text = "No data."
        End If
    End Sub
    Private Sub frmMCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo MsErr

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        GETDATA()


        Exit Sub

MsErr:
        MsgBox("Error on file, Please check Data", MsgBoxStyle.OkOnly)
        Exit Sub
    End Sub


    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1
            txtCode.Text = .SelectedItems(0).SubItems(0).Text
            txtName.Text = .SelectedItems(0).SubItems(1).Text
            txtAddress.Text = .SelectedItems(0).SubItems(2).Text
            txtRoad.Text = .SelectedItems(0).SubItems(3).Text
            txttam.Text = .SelectedItems(0).SubItems(4).Text
            txtamp.Text = .SelectedItems(0).SubItems(5).Text
            txtpro.Text = .SelectedItems(0).SubItems(6).Text
            txtPost.Text = .SelectedItems(0).SubItems(7).Text
            txtTaxID.Text = .SelectedItems(0).SubItems(8).Text

            txtShrtName.Text = .SelectedItems(0).SubItems(9).Text
        End With
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For Each c As Control In GroupBox2.Controls
            If TypeOf c Is TextBox Then c.Text = ""

        Next
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class