<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateGrid
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvUpdateGrid = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.stsUpdateGrid = New System.Windows.Forms.StatusStrip()
        Me.stsUpdateGridLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsUpdateGridLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CRUDUpdateGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearchPage = New System.Windows.Forms.TextBox()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.txtSearchSect = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSearchCat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbReversed = New System.Windows.Forms.CheckBox()
        Me.cboSortFields = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSearchSupplier = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbExact = New System.Windows.Forms.CheckBox()
        Me.txtSearchItemDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearchItemCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchSD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearchDiv = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbReversed2 = New System.Windows.Forms.CheckBox()
        Me.cboSortFields2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvUpdateGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.stsUpdateGrid.SuspendLayout()
        Me.CRUDUpdateGrid.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUpdateGrid
        '
        Me.dgvUpdateGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUpdateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUpdateGrid.Location = New System.Drawing.Point(1, 74)
        Me.dgvUpdateGrid.Name = "dgvUpdateGrid"
        Me.dgvUpdateGrid.RowHeadersWidth = 62
        Me.dgvUpdateGrid.Size = New System.Drawing.Size(1242, 389)
        Me.dgvUpdateGrid.TabIndex = 0
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnUpdate)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Location = New System.Drawing.Point(1, 469)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1251, 34)
        Me.pnlButtons.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(266, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(88, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(3, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(173, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(83, 23)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "Clear Search"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'stsUpdateGrid
        '
        Me.stsUpdateGrid.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsUpdateGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsUpdateGridLabel1, Me.stsUpdateGridLabel2})
        Me.stsUpdateGrid.Location = New System.Drawing.Point(0, 506)
        Me.stsUpdateGrid.Name = "stsUpdateGrid"
        Me.stsUpdateGrid.Size = New System.Drawing.Size(1251, 22)
        Me.stsUpdateGrid.TabIndex = 2
        '
        'stsUpdateGridLabel1
        '
        Me.stsUpdateGridLabel1.Name = "stsUpdateGridLabel1"
        Me.stsUpdateGridLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'stsUpdateGridLabel2
        '
        Me.stsUpdateGridLabel2.Name = "stsUpdateGridLabel2"
        Me.stsUpdateGridLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'CRUDUpdateGrid
        '
        Me.CRUDUpdateGrid.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CRUDUpdateGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewRowToolStripMenuItem})
        Me.CRUDUpdateGrid.Name = "CRUDUpdateGrid"
        Me.CRUDUpdateGrid.Size = New System.Drawing.Size(100, 26)
        '
        'ViewRowToolStripMenuItem
        '
        Me.ViewRowToolStripMenuItem.Name = "ViewRowToolStripMenuItem"
        Me.ViewRowToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewRowToolStripMenuItem.Text = "View"
        '
        'pnlSearch
        '
        Me.pnlSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSearch.Controls.Add(Me.Label9)
        Me.pnlSearch.Controls.Add(Me.cbReversed2)
        Me.pnlSearch.Controls.Add(Me.cboSortFields2)
        Me.pnlSearch.Controls.Add(Me.txtSearchPage)
        Me.pnlSearch.Controls.Add(Me.lblPage)
        Me.pnlSearch.Controls.Add(Me.txtSearchSect)
        Me.pnlSearch.Controls.Add(Me.Label8)
        Me.pnlSearch.Controls.Add(Me.txtSearchCat)
        Me.pnlSearch.Controls.Add(Me.Label7)
        Me.pnlSearch.Controls.Add(Me.cbReversed)
        Me.pnlSearch.Controls.Add(Me.cboSortFields)
        Me.pnlSearch.Controls.Add(Me.Label6)
        Me.pnlSearch.Controls.Add(Me.txtSearchSupplier)
        Me.pnlSearch.Controls.Add(Me.Label5)
        Me.pnlSearch.Controls.Add(Me.cbExact)
        Me.pnlSearch.Controls.Add(Me.txtSearchItemDesc)
        Me.pnlSearch.Controls.Add(Me.Label4)
        Me.pnlSearch.Controls.Add(Me.txtSearchItemCode)
        Me.pnlSearch.Controls.Add(Me.Label3)
        Me.pnlSearch.Controls.Add(Me.txtSearchSD)
        Me.pnlSearch.Controls.Add(Me.Label2)
        Me.pnlSearch.Controls.Add(Me.txtSearchDiv)
        Me.pnlSearch.Controls.Add(Me.Label1)
        Me.pnlSearch.Location = New System.Drawing.Point(1, 2)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(1239, 66)
        Me.pnlSearch.TabIndex = 3
        '
        'txtSearchPage
        '
        Me.txtSearchPage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchPage.Location = New System.Drawing.Point(424, 6)
        Me.txtSearchPage.Name = "txtSearchPage"
        Me.txtSearchPage.Size = New System.Drawing.Size(36, 20)
        Me.txtSearchPage.TabIndex = 9
        Me.txtSearchPage.Text = "99999"
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(389, 9)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(35, 13)
        Me.lblPage.TabIndex = 8
        Me.lblPage.Text = "Page:"
        '
        'txtSearchSect
        '
        Me.txtSearchSect.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchSect.Location = New System.Drawing.Point(355, 6)
        Me.txtSearchSect.Name = "txtSearchSect"
        Me.txtSearchSect.Size = New System.Drawing.Size(26, 20)
        Me.txtSearchSect.TabIndex = 7
        Me.txtSearchSect.Text = "999"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(309, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Section:"
        '
        'txtSearchCat
        '
        Me.txtSearchCat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchCat.Location = New System.Drawing.Point(275, 6)
        Me.txtSearchCat.Name = "txtSearchCat"
        Me.txtSearchCat.Size = New System.Drawing.Size(26, 20)
        Me.txtSearchCat.TabIndex = 5
        Me.txtSearchCat.Text = "999"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(223, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Category:"
        '
        'cbReversed
        '
        Me.cbReversed.AutoSize = True
        Me.cbReversed.Location = New System.Drawing.Point(162, 35)
        Me.cbReversed.Name = "cbReversed"
        Me.cbReversed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbReversed.Size = New System.Drawing.Size(88, 17)
        Me.cbReversed.TabIndex = 20
        Me.cbReversed.Text = "Reverse Sort"
        Me.cbReversed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbReversed.UseVisualStyleBackColor = True
        '
        'cboSortFields
        '
        Me.cboSortFields.FormattingEnabled = True
        Me.cboSortFields.Location = New System.Drawing.Point(49, 32)
        Me.cboSortFields.Name = "cboSortFields"
        Me.cboSortFields.Size = New System.Drawing.Size(105, 21)
        Me.cboSortFields.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Sort by:"
        '
        'txtSearchSupplier
        '
        Me.txtSearchSupplier.Location = New System.Drawing.Point(913, 6)
        Me.txtSearchSupplier.Name = "txtSearchSupplier"
        Me.txtSearchSupplier.Size = New System.Drawing.Size(161, 20)
        Me.txtSearchSupplier.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(865, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Supplier:"
        '
        'cbExact
        '
        Me.cbExact.AutoSize = True
        Me.cbExact.Location = New System.Drawing.Point(1082, 8)
        Me.cbExact.Name = "cbExact"
        Me.cbExact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbExact.Size = New System.Drawing.Size(53, 17)
        Me.cbExact.TabIndex = 16
        Me.cbExact.Text = "Exact"
        Me.cbExact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbExact.UseVisualStyleBackColor = True
        '
        'txtSearchItemDesc
        '
        Me.txtSearchItemDesc.Location = New System.Drawing.Point(692, 6)
        Me.txtSearchItemDesc.Name = "txtSearchItemDesc"
        Me.txtSearchItemDesc.Size = New System.Drawing.Size(165, 20)
        Me.txtSearchItemDesc.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(634, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Item Desc:"
        '
        'txtSearchItemCode
        '
        Me.txtSearchItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchItemCode.Location = New System.Drawing.Point(526, 6)
        Me.txtSearchItemCode.Name = "txtSearchItemCode"
        Me.txtSearchItemCode.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchItemCode.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(468, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Item Code:"
        '
        'txtSearchSD
        '
        Me.txtSearchSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchSD.Location = New System.Drawing.Point(194, 6)
        Me.txtSearchSD.Name = "txtSearchSD"
        Me.txtSearchSD.Size = New System.Drawing.Size(21, 20)
        Me.txtSearchSD.TabIndex = 3
        Me.txtSearchSD.Text = "99"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sub Division:"
        '
        'txtSearchDiv
        '
        Me.txtSearchDiv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchDiv.Location = New System.Drawing.Point(90, 6)
        Me.txtSearchDiv.Name = "txtSearchDiv"
        Me.txtSearchDiv.Size = New System.Drawing.Size(27, 20)
        Me.txtSearchDiv.TabIndex = 1
        Me.txtSearchDiv.Text = "HW"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Division:"
        '
        'cbReversed2
        '
        Me.cbReversed2.AutoSize = True
        Me.cbReversed2.Location = New System.Drawing.Point(403, 35)
        Me.cbReversed2.Name = "cbReversed2"
        Me.cbReversed2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbReversed2.Size = New System.Drawing.Size(88, 17)
        Me.cbReversed2.TabIndex = 22
        Me.cbReversed2.Text = "Reverse Sort"
        Me.cbReversed2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbReversed2.UseVisualStyleBackColor = True
        '
        'cboSortFields2
        '
        Me.cboSortFields2.FormattingEnabled = True
        Me.cboSortFields2.Location = New System.Drawing.Point(290, 32)
        Me.cboSortFields2.Name = "cboSortFields2"
        Me.cboSortFields2.Size = New System.Drawing.Size(105, 21)
        Me.cboSortFields2.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "and:"
        '
        'UpdateGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 528)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.dgvUpdateGrid)
        Me.Controls.Add(Me.stsUpdateGrid)
        Me.Controls.Add(Me.pnlButtons)
        Me.Name = "UpdateGrid"
        Me.Text = "Update Grid"
        CType(Me.dgvUpdateGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.stsUpdateGrid.ResumeLayout(False)
        Me.stsUpdateGrid.PerformLayout()
        Me.CRUDUpdateGrid.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvUpdateGrid As DataGridView
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents stsUpdateGrid As StatusStrip
    Friend WithEvents stsUpdateGridLabel1 As ToolStripStatusLabel
    Friend WithEvents btnClear As Button
    Friend WithEvents CRUDUpdateGrid As ContextMenuStrip
    Friend WithEvents ViewRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtSearchDiv As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearchSD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearchItemCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchItemDesc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbExact As CheckBox
    Friend WithEvents txtSearchSupplier As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboSortFields As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbReversed As CheckBox
    Friend WithEvents stsUpdateGridLabel2 As ToolStripStatusLabel
    Friend WithEvents txtSearchPage As TextBox
    Friend WithEvents lblPage As Label
    Friend WithEvents txtSearchSect As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSearchCat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cbReversed2 As CheckBox
    Friend WithEvents cboSortFields2 As ComboBox
End Class
