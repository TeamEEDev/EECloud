Imports System.Runtime.InteropServices

Friend NotInheritable Class LoginForm

#Region "Fields"

    Private ReadOnly regularAccounts As New List(Of Integer)
    Private ReadOnly facebookAccounts As New List(Of Integer)

    Private selectedLoginType As AccountType

#End Region

#Region "Methods"

    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        KeyPreview = True
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.LoginTypes.Count > 0 Then
            For n = 0 To My.Settings.LoginTypes.Count - 1
                Select Case My.Settings.LoginTypes(n)
                    Case AccountType.Regular
                        regularAccounts.Add(n)
                    Case AccountType.Facebook
                        facebookAccounts.Add(n)
                End Select
            Next

            Select Case My.Settings.LoginTypes(0)
                Case AccountType.Regular
                    RadioButtonRegular.Checked = True
                Case AccountType.Facebook
                    RadioButtonFacebook.Checked = True
            End Select
        Else
            RadioButtonRegular.Checked = True
        End If

        If My.Settings.LoginWorldIDs.Count > 0 Then
            TextBoxWorldID.Items.AddRange(My.Settings.LoginWorldIDs.Cast(Of String)().ToArray())
            TextBoxWorldID.Text = TextBoxWorldID.Items(0)
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If IsHandleCreated Then
            SetForegroundWindow(Handle)
        End If
    End Sub

    Private Sub TextBoxEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxEmail.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                TextBoxEmail.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Delete Then
            If TextBoxEmail.SelectedIndex > -1 Then
                e.Handled = True

                Dim removeLocation As Integer

                Select Case selectedLoginType
                    Case AccountType.Regular
                        removeLocation = regularAccounts(TextBoxEmail.SelectedIndex)
                    Case AccountType.Facebook
                        removeLocation = facebookAccounts(TextBoxEmail.SelectedIndex)
                End Select

                TextBoxEmail.Items.RemoveAt(removeLocation)
                My.Settings.LoginTypes.RemoveAt(removeLocation)
                My.Settings.LoginEmails.RemoveAt(removeLocation)
                My.Settings.LoginPasswords.RemoveAt(removeLocation)

                My.Settings.Save()
                If TextBoxEmail.Items.Count > 0 Then
                    TextBoxEmail.SelectedIndex = 0
                Else
                    TextBoxEmail.Text = String.Empty
                    TextBoxPassword.Text = String.Empty
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPassword.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                TextBoxPassword.SelectAll()
            End If
        End If
    End Sub

    Private Sub TextBoxWorldID_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxWorldID.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                TextBoxWorldID.SelectAll()
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            If TextBoxWorldID.SelectedIndex > -1 Then
                e.Handled = True

                My.Settings.LoginWorldIDs.RemoveAt(TextBoxWorldID.SelectedIndex)
                TextBoxWorldID.Items.RemoveAt(TextBoxWorldID.SelectedIndex)

                My.Settings.Save()
                If TextBoxWorldID.Items.Count > 0 Then
                    TextBoxWorldID.SelectedIndex = 0
                Else
                    TextBoxWorldID.Text = String.Empty
                End If
            End If
        End If
    End Sub

    Private Sub ButtonJoinWorld_Click(sender As Object, e As EventArgs) Handles ButtonJoinWorld.Click
        If TextBoxEmail.Text <> String.Empty Then
            If TextBoxPassword.Text <> String.Empty OrElse RadioButtonFacebook.Checked Then
                If TextBoxWorldID.Text <> String.Empty Then
                    Dim settingIndex As Integer = My.Settings.LoginEmails.IndexOf(TextBoxEmail.Text)
                    If settingIndex > -1 Then
                        My.Settings.LoginTypes.RemoveAt(settingIndex)
                        My.Settings.LoginEmails.RemoveAt(settingIndex)
                        My.Settings.LoginPasswords.RemoveAt(settingIndex)
                    End If

                    settingIndex = My.Settings.LoginWorldIDs.IndexOf(TextBoxWorldID.Text)
                    If settingIndex > -1 Then
                        My.Settings.LoginWorldIDs.RemoveAt(settingIndex)
                    End If

                    If RadioButtonRegular.Checked Then
                        My.Settings.LoginTypes.Insert(0, AccountType.Regular)
                    Else
                        My.Settings.LoginTypes.Insert(0, AccountType.Facebook)
                    End If
                    My.Settings.LoginEmails.Insert(0, TextBoxEmail.Text)
                    My.Settings.LoginPasswords.Insert(0, TextBoxPassword.Text)
                    My.Settings.LoginWorldIDs.Insert(0, TextBoxWorldID.Text)

                    My.Settings.Save()
                    DialogResult = DialogResult.OK
                    Close()
                Else
                    MessageBox.Show("You didn't enter the world's ID you want to join to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    TextBoxWorldID.Focus()
                End If
            Else
                If Not TextBoxWorldID.Text = String.Empty Then
                    MessageBox.Show("You didn't enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("You didn't enter your password, and the world's ID you want to join to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                TextBoxPassword.Focus()
            End If
        Else
            If Not TextBoxPassword.Text = String.Empty OrElse RadioButtonFacebook.Checked Then
                If Not TextBoxWorldID.Text = String.Empty Then
                    MessageBox.Show("You didn't enter your e-mail address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("You didn't enter your e-mail address, and the world's ID you want to join to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If Not TextBoxWorldID.Text = String.Empty Then
                    MessageBox.Show("You didn't enter your e-mail address, and your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("You didn't enter your e-mail address, your password, and the world's ID you want to join to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            TextBoxEmail.Focus()
        End If
    End Sub

    Private Sub RadioButtonTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonRegular.CheckedChanged, RadioButtonFacebook.CheckedChanged
        Dim senderAsRadioButton As RadioButton = TryCast(sender, RadioButton)

        If senderAsRadioButton IsNot Nothing AndAlso senderAsRadioButton.Checked Then
            TextBoxEmail.Items.Clear()

            If senderAsRadioButton.Text = RadioButtonRegular.Text Then
                selectedLoginType = AccountType.Regular

                If regularAccounts.Count > 0 Then
                    For n = 0 To regularAccounts.Count - 1
                        TextBoxEmail.Items.Add(My.Settings.LoginEmails(regularAccounts(n)))
                    Next

                    TextBoxEmail.Text = TextBoxEmail.Items(0)
                    TextBoxPassword.Text = My.Settings.LoginPasswords(regularAccounts(0))
                Else
                    TextBoxEmail.Text = String.Empty
                End If

                TextBoxPassword.Enabled = True
                LabelEmail.Text = "E-mail:"
                LabelPassword.Enabled = True

            Else 'If senderAsRadioButton.Text = RadioButtonFacebook.Text Then
                selectedLoginType = AccountType.Facebook

                If facebookAccounts.Count > 0 Then
                    For n = 0 To facebookAccounts.Count - 1
                        TextBoxEmail.Items.Add(My.Settings.LoginEmails(facebookAccounts(n)))
                    Next

                    TextBoxEmail.Text = TextBoxEmail.Items(0)
                Else
                    TextBoxEmail.Text = String.Empty
                End If

                TextBoxPassword.Enabled = False
                TextBoxPassword.Text = String.Empty
                LabelEmail.Text = "Token:"
                LabelPassword.Enabled = False
            End If
        End If
    End Sub

    Private Sub TextBoxEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TextBoxEmail.SelectedIndexChanged
        Select Case selectedLoginType
            Case AccountType.Regular
                TextBoxPassword.Text = My.Settings.LoginPasswords(regularAccounts(TextBoxEmail.SelectedIndex))
            Case AccountType.Facebook
                TextBoxPassword.Text = My.Settings.LoginPasswords(facebookAccounts(TextBoxEmail.SelectedIndex))
        End Select
    End Sub

#End Region
End Class
