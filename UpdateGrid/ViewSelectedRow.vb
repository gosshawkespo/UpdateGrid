Public Class ViewSelectedRow
    Dim GlobalParms As New ESPOParms.Framework
    Dim GlobalSession As New ESPOParms.Session
    Dim DAL As New UpdateGridDAL
    Private Sub ViewSelectedRow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOParms.Framework)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Sub PopulateForm(RecordID As Integer)
        Dim dt As DataTable
        Dim txtBox As New TextBox

        For Each ctrl As Control In Me.Panel1.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, System.Windows.Forms.TextBox).ReadOnly = True
                'Any txtboxes that need to be editable - can be excluded.
            End If
        Next

        If UpdateGrid.DBVersion = "MYSQL" Then
            dt = DAL.GetAPEMasterDetail_MYSQL(RecordID)
        Else
            dt = DAL.GetAPEMastDetail(GlobalSession.ConnectString, RecordID)
        End If

        'txtRecordID.Text = dt.Rows(0)("Record ID").ToString
        txtRecordID.Text = RecordID
        txtS21ItemCode.Text = dt.Rows(0)("S21 Item Code").ToString
        txtItemDescription.Text = dt.Rows(0)("Item Description").ToString
        txtDivisionCode.Text = dt.Rows(0)("divn35").ToString
        txtDivisionDesc.Text = dt.Rows(0)("divn35D").ToString
        txtSubDivisionCode.Text = dt.Rows(0)("sdiv35").ToString
        txtSubDivisionDesc.Text = dt.Rows(0)("sdiv35D").ToString
        txtMajorGroupCode.Text = dt.Rows(0)("pgmj35").ToString
        txtMajorGroupDesc.Text = dt.Rows(0)("pgmj35D").ToString
        txtMinorGroupCode.Text = dt.Rows(0)("pgmn35").ToString
        txtMinorGroupDesc.Text = dt.Rows(0)("pgmn35D").ToString
        txtSupplierCode.Text = dt.Rows(0)("Supp Code").ToString
        txtSupplierName.Text = dt.Rows(0)("Supplier Name").ToString
        txtNewBuyPrice.Text = dt.Rows(0)("New Buying Price").ToString
        txtNewSellPrice.Text = dt.Rows(0)("New Selling Price").ToString
        txtProfit.Text = dt.Rows(0)("Profit").ToString
        txtMargin.Text = dt.Rows(0)("Margin%").ToString
        txtCatalogue.Text = dt.Rows(0)("Cat").ToString
        txtSection.Text = dt.Rows(0)("Sect").ToString
        txtPage.Text = dt.Rows(0)("Page").ToString


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub
End Class