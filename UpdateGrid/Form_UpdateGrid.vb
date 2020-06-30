Public Class UpdateGrid
    Dim GlobalParms As New ESPOParms.Framework
    Dim GlobalSession As New ESPOParms.Session
    Dim DAL As New UpdateGridDAL
    Dim Sortwatch As New Stopwatch

    Private _FirstEntry As String
    Private _LastEntry As String
    Private _LastEditRow As Integer
    Private _GridVerticalScrollOffset As Integer
    Private _GridColumnIndex As Integer
    Private _GridRowIndex As Integer
    Public Shared DBVersion As String
    Public Shared ThemeSelection As Integer

    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOParms.Framework)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Property FirstEntry As String
        Get
            Return _FirstEntry
        End Get
        Set(value As String)
            _FirstEntry = value
        End Set
    End Property

    Property LastEntry As String
        Get
            Return _LastEntry
        End Get
        Set(value As String)
            _LastEntry = value
        End Set
    End Property

    Property LastEditRow As Integer
        Get
            Return _LastEditRow
        End Get
        Set(value As Integer)
            _LastEditRow = value
        End Set
    End Property

    Property GridVerticalScrollOffset As Integer
        Get
            Return _GridVerticalScrollOffset
        End Get
        Set(value As Integer)
            _GridVerticalScrollOffset = value
        End Set
    End Property

    Property GridColumnIndex As Integer
        Get
            Return _GridColumnIndex
        End Get
        Set(value As Integer)
            _GridColumnIndex = value
        End Set
    End Property

    Property GridRowIndex As Integer
        Get
            Return _GridRowIndex
        End Get
        Set(value As Integer)
            _GridRowIndex = value
        End Set
    End Property

    Private Sub UpdateGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        If ThemeSelection = 0 Then
            Me.BackColor = SystemColors.Control
            dgvUpdateGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
            dgvUpdateGrid.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        Else
            Me.BackColor = SystemColors.ControlDark
            dgvUpdateGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(245, 255, 245))
            dgvUpdateGrid.DefaultCellStyle.BackColor = ColorTranslator.FromWin32(RGB(235, 255, 235)) 'LIGHT GREEN
        End If
        'dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvUpdateGrid.AllowUserToOrderColumns = True
        dgvUpdateGrid.AllowUserToResizeColumns = True
        txtSearchDiv.Text = ""
        txtSearchSD.Text = ""
        txtSearchItemCode.Text = ""
        txtSearchItemDesc.Text = ""
        txtSearchCat.Text = ""
        txtSearchPage.Text = ""
        txtSearchSect.Text = ""
        txtSearchSupplier.Text = ""
        txtSearchDiv.Focus()
        'dgvUpdateGrid.AllowUserToAddRows = True
        'dgvUpdateGrid.AllowUserToDeleteRows = True
        'dgvUpdateGrid.MultiSelect = True
        'dgvUpdateGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'dgvUpdateGrid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        'FieldAttributes.ClearSelectedAttributesList()

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
    End Sub

    Sub PopulateForm()
        Dim dt As DataTable
        Dim dgvCheckUpdate As New DataGridViewCheckBoxColumn()
        Dim Criteria As String
        Dim IsExact As Boolean
        Dim Reversed As Boolean
        Dim watch As Stopwatch

        dgvCheckUpdate.HeaderText = "UPDATED"
        dgvCheckUpdate.Name = "UPDATED"
        dgvCheckUpdate.ReadOnly = True

        stsUpdateGridLabel1.Text = "Initialisation..."
        Try

            watch = Stopwatch.StartNew()
            dgvUpdateGrid.Columns.Clear()
            stsUpdateGridLabel1.Text = ""
            'stsUpdateGridLabel2.Text = ""
            stsUpdateGridLabel1.Text = "Get Data..."
            Refresh()
            dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            IsExact = cbExact.Checked
            Reversed = cbReversed.Checked
            If DBVersion = "MYSQL" Then
                dt = DAL.GetAPEMaster_MYSQL(GlobalSession.ConnectString, txtSearchDiv.Text, txtSearchSD.Text, txtSearchCat.Text, txtSearchSect.Text, txtSearchPage.Text,
                                    txtSearchItemCode.Text, txtSearchItemDesc.Text, txtSearchSupplier.Text, IsExact, cboSortFields.Text, Reversed)
            Else
                dt = DAL.GetAPEMast(GlobalSession.ConnectString, txtSearchDiv.Text, txtSearchSD.Text, txtSearchCat.Text, txtSearchSect.Text, txtSearchPage.Text,
                                    txtSearchItemCode.Text, txtSearchItemDesc.Text, txtSearchSupplier.Text, IsExact, cboSortFields.Text, Reversed)
            End If
            stsUpdateGridLabel1.Text = "Get Data...Completed. Populate Grid..."
            Refresh()

            If dt IsNot Nothing Then
                dgvUpdateGrid.DataSource = dt
                stsUpdateGridLabel2.Text = "Records: " & CStr(dt.Rows.Count)
            End If
            dgvUpdateGrid.Columns.Add(dgvCheckUpdate)
            stsUpdateGridLabel1.Text = "Lock Records..."
            Refresh()
            Lock_RecordColumns("New Buying Price,New Selling Price")
            stsUpdateGridLabel1.Text = "Format Grid..."
            Refresh()
            RightAlignNumerics()
            PopulateSortFieldsCombo()

            If Me.LastEditRow > 0 And Me.LastEditRow < dgvUpdateGrid.Rows.Count - 1 Then
                dgvUpdateGrid.Rows(Me.LastEditRow).Selected = True
                dgvUpdateGrid.FirstDisplayedScrollingRowIndex = Me.GridRowIndex

                dgvUpdateGrid.FirstDisplayedScrollingColumnIndex = Me.GridColumnIndex
            End If

            'dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgvUpdateGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            watch.Stop()
            stsUpdateGridLabel1.Text = "Completed in " & " (" & Format(watch.Elapsed.TotalSeconds, "##,##0.00") & " seconds)"
            stsUpdateGridLabel2.Text = "Records: " & CStr(dt.Rows.Count)
            txtSearchDiv.Focus()
            Refresh()
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Error in PopulateForm(): " & ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub

    Sub Lock_RecordColumns(Comma_Delim_Exceptions As String)
        Dim arr() As String

        Try
            For i As Integer = 0 To dgvUpdateGrid.Columns.Count - 1
                dgvUpdateGrid.Columns(i).ReadOnly = True
            Next
            If Comma_Delim_Exceptions <> "" Then
                arr = Split(Comma_Delim_Exceptions, ",")
                For i As Integer = 0 To arr.Length - 1
                    dgvUpdateGrid.Columns(arr(i)).ReadOnly = False
                Next
            End If
            'dgvUpdateGrid.Columns("New Buying Price").ReadOnly = False
            'dgvUpdateGrid.Columns("New Selling Price").ReadOnly = False
        Catch ex As Exception
            MsgBox("Error in Lock_RecordColumn(): " & ex.Message)
        End Try

    End Sub

    Sub PopulateSortFieldsCombo()
        Dim ColumnName As String

        cboSortFields.Items.Clear()
        For i As Integer = 0 To dgvUpdateGrid.Columns.Count - 1
            ColumnName = dgvUpdateGrid.Columns(i).HeaderText
            If ColumnName.ToUpper <> "UPDATED" Then
                cboSortFields.Items.Add(ColumnName)
            End If
        Next
    End Sub

    Sub RightAlignNumerics()
        Dim ColType As Type

        Try
            For i As Integer = 0 To dgvUpdateGrid.Columns.Count - 1
                ColType = dgvUpdateGrid.Columns(i).ValueType
                'MsgBox("Col Type: " & ColType.ToString)
                If Not IsNothing(dgvUpdateGrid.Columns(i)) And Not IsNothing(ColType) Then
                    If ColType.ToString.ToUpper = "SYSTEM.INT32" Then
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Format = "N0"
                    ElseIf ColType.ToString.ToUpper = "SYSTEM.DOUBLE" Or ColType.ToString.ToUpper = "SYSTEM.DECIMAL" Then
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Format = "N2"
                    Else
                        'All other types:
                    End If
                    'EXCEPTIONS - these specifically require formatting to 0 dp:
                    If InStr(dgvUpdateGrid.Columns(i).HeaderText.ToUpper, "ID") > 0 Or InStr(dgvUpdateGrid.Columns(i).HeaderText.ToUpper, "PAGE") > 0 Then
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvUpdateGrid.Columns(i).DefaultCellStyle.Format = "N0"
                    End If
                End If

            Next
        Catch ex As Exception
            MsgBox("Error in RightAlignNumerics(): " & ex.Message)
        End Try


        'dgvUpdateGrid.Columns("Record ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvUpdateGrid.Columns("Record ID").DefaultCellStyle.Format = "N0"
        'dgvUpdateGrid.Columns("New Selling Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvUpdateGrid.Columns("New Selling Price").DefaultCellStyle.Format = "N2"
        'dgvUpdateGrid.Columns("New Buying Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvUpdateGrid.Columns("New Buying Price").DefaultCellStyle.Format = "N2"
        'dgvUpdateGrid.Columns("Profit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvUpdateGrid.Columns("Profit").DefaultCellStyle.Format = "N2"
        'dgvUpdateGrid.Columns("Margin%").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvUpdateGrid.Columns("Margin%").DefaultCellStyle.Format = "N2"

    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()

        End Select
    End Sub

    Private Function UpdateDBfromGrid()
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim RecordID As Integer

        stsUpdateGridLabel1.Text = "Update Grid..."

        For i As Integer = 0 To dgvUpdateGrid.Rows.Count - 1
            If Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value) = Nothing Then
                RecordID = 0
            ElseIf Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value.ToString) = "" Then
                RecordID = 0
            Else
                RecordID = Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value)
            End If

            If Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value) <> Nothing Then
                DAL.UpdateAPEMast(
                        GlobalSession.ConnectString,
                        RecordID,
                        Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value.ToString),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Item Description").Value.ToString),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Selling Price").Value),
                        Trim(dgvUpdateGrid.Rows(i).Cells("Current Price").Value)
                    )
            End If

            Message = ""
            'Percentage = (i / dgvUpdateGrid.Rows.Count - 1) * 100
            'Message = "Updating Grid: " & CStr(Percentage) & "%"
            'stsUpdateGridLabel1.Text = Message
        Next i
        watch.Stop()
        stsUpdateGridLabel1.Text = "Completed in " & " (" & CStr(watch.Elapsed.TotalSeconds) & " seconds)"
        Refresh()
    End Function

    Private Function UpdateDBfromGridDan()
        Dim Percentage As Double = 0.0
        Dim Message As String
        Dim watch As Stopwatch = Stopwatch.StartNew()
        Dim RecordID As Integer
        Dim strS21ItemCode As String
        Dim strItemDescription As String
        Dim strSellingPrice As String
        Dim strCurrentPrice As String
        Dim NumRowsUpdated As Integer

        stsUpdateGridLabel2.Text = ""
        stsUpdateGridLabel1.Text = "Update Grid..."
        Refresh()
        NumRowsUpdated = 0
        For i As Integer = 0 To dgvUpdateGrid.Rows.Count - 1
            If dgvUpdateGrid.Rows(i).Cells("UPDATED").Value = True Then
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value = Nothing Then
                        strS21ItemCode = ""
                    Else
                        strS21ItemCode = Trim(dgvUpdateGrid.Rows(i).Cells("S21 Item Code").Value.ToString)
                    End If
                Else
                    strS21ItemCode = ""
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("Item Description").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("Item Description").Value = Nothing Then
                        strItemDescription = ""
                    Else
                        strItemDescription = Trim(dgvUpdateGrid.Rows(i).Cells("Item Description").Value.ToString)
                    End If
                Else
                    strItemDescription = ""
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("New Selling Price").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("New Selling Price").Value = Nothing Then
                        strSellingPrice = "0"
                    Else
                        strSellingPrice = dgvUpdateGrid.Rows(i).Cells("New Selling Price").Value.ToString
                    End If
                Else
                    strSellingPrice = "0"
                End If
                If Not IsDBNull(dgvUpdateGrid.Rows(i).Cells("New Buying Price").Value) Then
                    If dgvUpdateGrid.Rows(i).Cells("New Buying Price").Value = Nothing Then
                        strCurrentPrice = "0"
                    Else
                        strCurrentPrice = dgvUpdateGrid.Rows(i).Cells("New Buying Price").Value.ToString
                    End If
                Else
                    strCurrentPrice = "0"
                End If
                If IsDBNull(dgvUpdateGrid.Rows(i).Cells("Record ID").Value) Then
                    RecordID = 0
                ElseIf dgvUpdateGrid.Rows(i).Cells("Record ID").Value = Nothing Then
                    RecordID = 0
                    'Continue For
                Else
                    RecordID = Trim(dgvUpdateGrid.Rows(i).Cells("Record ID").Value)
                End If
                If strS21ItemCode <> "" Then
                    If DBVersion = "MYSQL" Then
                        DAL.UpdateAPEMaster_MYSQL(RecordID, strS21ItemCode, strItemDescription, strSellingPrice, strCurrentPrice)
                    Else
                        DAL.UpdateAPEMast(GlobalSession.ConnectString, RecordID, strS21ItemCode, strItemDescription, strSellingPrice, strCurrentPrice)
                    End If
                End If
            End If
            Message = ""
            NumRowsUpdated += 1
            'Percentage = (i / dgvUpdateGrid.Rows.Count - 1) * 100
            'Message = "Updating Grid: " & CStr(Percentage) & "%"
            'stsUpdateGridLabel1.Text = Message
        Next i
        watch.Stop()
        stsUpdateGridLabel1.Text = "Completed in " & Format(watch.Elapsed.TotalSeconds, "##,##0.00") & " seconds"
        stsUpdateGridLabel2.Text = "Updated: " & CStr(NumRowsUpdated) & " Rows."
        Refresh()
    End Function

    Private Sub InsertRow()
        Dim dt As DataTable

        'dgvUpdateGrid.DataSource = Nothing
        dgvUpdateGrid.Rows.Add() 'Gives error
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        PopulateForm()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DBVersion = "MYSQL" Then
            UpdateDBfromGridDan()
        Else
            UpdateDBfromGridDan()
        End If

        PopulateForm()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs)
        InsertRow()
    End Sub

    Private Sub dgvUpdateGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvUpdateGrid.CellBeginEdit
        Try
            If Not IsDBNull(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If Not IsNothing(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    If IsNumeric(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                        Me.FirstEntry = dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Else
                        MsgBox("Invalid Entry")
                        Exit Sub
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("Error in CellBeginEdit: " & ex.Message)
        End Try

    End Sub

    Private Sub dgvUpdateGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateGrid.CellEndEdit
        Try
            If Not IsDBNull(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If Not IsNothing(dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    Me.LastEntry = dgvUpdateGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    If Me.FirstEntry <> Me.LastEntry Then
                        dgvUpdateGrid.Rows(e.RowIndex).Cells("UPDATED").Value = True
                        LastEditRow = e.RowIndex
                        Me.GridVerticalScrollOffset = dgvUpdateGrid.VerticalScrollingOffset
                        Me.GridRowIndex = dgvUpdateGrid.FirstDisplayedScrollingRowIndex
                        If dgvUpdateGrid.FirstDisplayedScrollingColumnIndex + 1 < dgvUpdateGrid.Columns.Count - 1 Then
                            Me.GridColumnIndex = dgvUpdateGrid.FirstDisplayedScrollingColumnIndex + 1
                        Else
                            Me.GridColumnIndex = dgvUpdateGrid.FirstDisplayedScrollingColumnIndex
                        End If
                        'MsgBox("Vertical Scroll INDEX: Row=" & CStr(Me.GridRowIndex) & ", Col=" & CStr(Me.GridColumnIndex))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error in CellEndEdit: " & ex.Message)
        End Try

    End Sub

    Private Sub UndockChild()
        If Me.MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub UpdateGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

    End Sub

    Private Sub UpdateGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnRefresh.PerformClick()
        ElseIf e.KeyValue = 27 Then 'ESC pressed
            'Clear certain fields
            btnRefresh.PerformClick()
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        ElseIf e.KeyValue = Keys.Return Or e.KeyValue = Keys.Enter Then
            btnRefresh.PerformClick()
        ElseIf (e.Control AndAlso (e.KeyCode = Keys.S)) Then
            'btnShowSQLQuery.PerformClick()
        ElseIf (e.Control AndAlso (e.Shift) AndAlso (e.KeyCode = Keys.C)) Then
            btnClose.PerformClick()
        End If
    End Sub

    Private Sub dgvUpdateGrid_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvUpdateGrid.MouseClick
        Dim hit As DataGridView.HitTestInfo = dgvUpdateGrid.HitTest(e.X, e.Y)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            'Clear any currently sellected rows ?
            If hit.Type = DataGridViewHitTestType.Cell Then
                'dgvHeaderList.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                dgvUpdateGrid.ClearSelection()
                Me.dgvUpdateGrid.Rows(hit.RowIndex).Selected = True
                If hit.ColumnIndex >= 0 And hit.RowIndex >= 0 Then
                    Me.dgvUpdateGrid.CurrentCell = Me.dgvUpdateGrid.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                End If
            End If
            CRUDUpdateGrid.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ViewRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewRowToolStripMenuItem.Click
        'Show form to view row selected:
        Dim RecordID As Integer
        Dim strRecordID As String
        Dim App As New ViewSelectedRow

        Cursor = Cursors.Default
        stsUpdateGridLabel1.Text = "View Row Selected..."
        'stsFW100Label1.Text = "Loading List......"
        Cursor = Cursors.WaitCursor
        Refresh()
        If DBVersion = "MYSQL" Then
            strRecordID = dgvUpdateGrid.CurrentRow.Cells("Record ID").Value.ToString
            If IsNumeric(strRecordID) Then
                RecordID = CInt(strRecordID)
            Else
                MsgBox("problem getting record ID")
                Exit Sub
            End If
        Else
            If dgvUpdateGrid.CurrentRow.Cells("Record ID").Value.ToString = "" Then
                MsgBox("Error: Record ID not valid")
                Exit Sub
            Else
                RecordID = dgvUpdateGrid.CurrentRow.Cells("Record ID").Value
            End If
        End If


        App.Visible = False
        App.GetParms(GlobalSession, GlobalParms)
        App.PopulateForm(RecordID)
        App.Show()
        'pp.btnRefresh.PerformClick()
        Cursor = Cursors.Default
        stsUpdateGridLabel1.Text = ""
    End Sub

    Private Sub dgvUpdateGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvUpdateGrid.DataError
        MsgBox("DataError: " & e.Exception.Message)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSearchItemCode.Text = ""
        txtSearchItemDesc.Text = ""
        txtSearchDiv.Text = ""
        txtSearchSD.Text = ""
        txtSearchSupplier.Text = ""
        cbExact.Checked = False

    End Sub

    Private Sub dgvUpdateGrid_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUpdateGrid.ColumnHeaderMouseClick
        'not fire very well.
    End Sub

    Private Sub dgvUpdateGrid_Sorted(sender As Object, e As EventArgs) Handles dgvUpdateGrid.Sorted
        'Fires as soon as a column is clicked upon - but impossible to time it.
    End Sub
End Class
