Public Class DGComponentManager
    Dim myControl As Control
    Public Sub AddFormControls(myForm As Form, ControlType As String, ControlName As String, InitialValue As String, TagNumber As String,
                        xx As Integer, yy As Integer, Width As Integer, Height As Integer,
                        theImage As Image,
                        ControlForecolourasRGBString As String,
                        ControlBACKcolourasRGBString As String)
        'Dim tempControl As clsControls 'replaces mycontrol = OR tempControl = myControl
        Dim myPanel As Panel
        Dim ControlForeColour As Color
        Dim ControlBackColour As Color
        Dim NewButton As System.Windows.Forms.Button
        Dim NewTextbox As System.Windows.Forms.TextBox

        If ControlForecolourasRGBString = "" Then
            If UpdateGrid.ThemeSelection = 0 Then
                ControlForeColour = SystemColors.ControlText
            Else
                ControlForeColour = SystemColors.ControlDarkDark
            End If
        Else
            ControlForeColour = DirectCast(New ColorConverter().ConvertFromString(ControlForecolourasRGBString), Color)
        End If
        If ControlBACKcolourasRGBString = "" Then
            If UpdateGrid.ThemeSelection = 0 Then
                ControlBackColour = SystemColors.Control
            Else
                ControlBackColour = SystemColors.ControlDarkDark
            End If
        Else
            ControlBackColour = DirectCast(New ColorConverter().ConvertFromString(ControlBACKcolourasRGBString), Color)
        End If

        If UCase(ControlType) = "LABEL" Then
            myControl = New Label
            myControl.Name = ControlName
            myControl.Tag = TagNumber
            myControl.Left = xx
            myControl.Top = yy
            myControl.Width = Width
            myControl.Height = 25
            myControl.Text = InitialValue
            myControl.ForeColor = ControlForeColour
            myControl.BackColor = ControlBackColour
            'AddHandler myControl.TextChanged, AddressOf myControl_textchanged
            myForm.Controls.Add(myControl)

        End If

        If UCase(ControlType) = "TEXTBOX" Then
            NewTextbox = New TextBox
            NewTextbox.Name = ControlName
            NewTextbox.Tag = TagNumber
            NewTextbox.Left = xx
            NewTextbox.Top = yy
            NewTextbox.Width = Width
            NewTextbox.Height = Height
            NewTextbox.Text = InitialValue
            NewTextbox.ForeColor = ControlForeColour
            NewTextbox.BackColor = ControlBackColour
            'AddHandler myControl.TextChanged, AddressOf myControl_textchanged
            myControl = DirectCast(NewTextbox, System.Windows.Forms.TextBox)
            myForm.Controls.Add(myControl)

        End If

        If UCase(ControlType) = "TEXTBOX_R" Then
            NewTextbox = New TextBox
            NewTextbox.Name = ControlName
            NewTextbox.Tag = TagNumber
            NewTextbox.Left = xx
            NewTextbox.Top = yy
            NewTextbox.Width = Width
            NewTextbox.Height = Height
            NewTextbox.Text = InitialValue
            NewTextbox.ReadOnly = True
            NewTextbox.ForeColor = ControlForeColour
            NewTextbox.BackColor = ControlBackColour
            'AddHandler myControl.TextChanged, AddressOf myControl_textchanged
            myControl = DirectCast(NewTextbox, System.Windows.Forms.TextBox)
            myForm.Controls.Add(myControl)

        End If

        If UCase(ControlType) = "BUTTON" Then
            NewButton = New Button
            NewButton.Name = ControlName
            NewButton.Tag = TagNumber
            NewButton.Left = xx
            NewButton.Top = yy
            NewButton.Width = Width
            NewButton.Height = Height
            NewButton.Text = InitialValue
            NewButton.ForeColor = Color.Black
            NewButton.BackColor = Color.Red
            AddHandler NewButton.Click, AddressOf myForm.Close
            myControl = DirectCast(NewButton, System.Windows.Forms.Button)
            myForm.Controls.Add(myControl)

        End If
        If UCase(ControlType) = "COMBOBOX" Then
            myControl = New ComboBox
            myControl.Name = ControlName
            myControl.Tag = TagNumber
            myControl.Left = xx
            myControl.Top = yy
            myControl.Width = Width
            myControl.Height = Height
            myControl.Text = InitialValue
            myControl.ForeColor = ControlForeColour
            myControl.BackColor = ControlBackColour
            'AddHandler myControl.TextChanged, AddressOf myControl_textchanged
            myForm.Controls.Add(myControl)

        End If
        'NewOBJ = DirectCast(NewCombo, System.Windows.Forms.ComboBox)
        If UCase(ControlType) = "PICTUREBOX" Then
            myControl = New PictureBox
            myControl.Name = ControlName
            myControl.Tag = TagNumber
            myControl.Left = xx
            myControl.Top = yy
            myControl.Width = Width
            myControl.Height = Height
            myControl.ForeColor = ControlForeColour
            myControl.BackColor = ControlBackColour
            'myControl.image = theImage
            myForm.Controls.Add(myControl)
        End If

        If UCase(ControlType) = "PANEL" Then
            myPanel = New Panel
            myPanel.Name = ControlName
            myPanel.Tag = TagNumber
            myPanel.Parent = myForm
            myPanel.Left = xx
            myPanel.Top = yy
            myPanel.Width = Width
            myPanel.Height = Height
            myPanel.AutoScroll = True
            myPanel.AutoScrollMargin = New Size(10, 10)
            ControlForeColour = DirectCast(New ColorConverter().ConvertFromString(ControlForecolourasRGBString), Color)
            myPanel.ForeColor = ControlForeColour
            'NewCombo.ForeColor = ColorTranslator.FromWin32(ControlForecolor)
            ControlBackColour = DirectCast(New ColorConverter().ConvertFromString(ControlBACKcolourasRGBString), Color)
            myPanel.BackColor = ControlBackColour
            'myControl.image = theImage
            myControl = DirectCast(myPanel, System.Windows.Forms.Panel)
            myForm.Controls.Add(myControl)
        End If

    End Sub
End Class
