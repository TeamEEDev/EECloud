Imports System.Runtime.InteropServices

Friend NotInheritable Class LoginForm

#Region "Methods"

    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxEmail.Text = My.Settings.LoginEmails(0)
        Select Case My.Settings.LoginTypes(0)
            Case AccountType.Regular
                TextBoxPassword.Text = My.Settings.LoginPasswords(0)
                RadioButtonRegular.Checked = True
            Case AccountType.Facebook
                RadioButtonFacebook.Checked = True
        End Select
        TextBoxWorldID.Text = My.Settings.LoginWorldIDs(0)
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If IsHandleCreated Then
            SetForegroundWindow(Handle)
        End If
    End Sub

    Private Sub TextBoxEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEmail.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            TextBoxEmail.SelectAll()
        End If
    End Sub

    Private Sub TextBoxPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPassword.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            TextBoxPassword.SelectAll()
        End If
    End Sub

    Private Sub TextBoxWorldID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxWorldID.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            TextBoxWorldID.SelectAll()
        End If
    End Sub

    Private Sub ButtonJoinWorld_Click(sender As Object, e As EventArgs) Handles ButtonJoinWorld.Click
        If Not TextBoxEmail.Text = "" Then
            If Not TextBoxPassword.Text = "" Or RadioButtonFacebook.Checked Then
                If Not TextBoxWorldID.Text = "" Then
                    Dim myLoginTypes As List(Of AccountType) = My.Settings.LoginTypes.ToList()

                    Dim settingIndex As Integer = My.Settings.LoginEmails.IndexOf(TextBoxEmail.Text)
                    If settingIndex > -1 Then
                        myLoginTypes.RemoveAt(settingIndex)
                        My.Settings.LoginEmails.Remove(settingIndex)
                        My.Settings.LoginPasswords.Remove(settingIndex)
                        My.Settings.LoginWorldIDs.Remove(settingIndex)
                    End If

                    If RadioButtonRegular.Checked Then
                        myLoginTypes.Insert(0, AccountType.Regular)
                    Else
                        myLoginTypes.Insert(0, AccountType.Facebook)
                    End If

                    My.Settings.LoginTypes = myLoginTypes.ToArray()
                    My.Settings.LoginEmails.Insert(0, TextBoxEmail.Text)
                    My.Settings.LoginPasswords.Insert(0, TextBoxPassword.Text)
                    My.Settings.LoginWorldIDs.Insert(0, TextBoxWorldID.Text)

                    My.Settings.Save()
                    DialogResult = DialogResult.OK
                    Close()
                Else
                    MsgBox("You didn't enter the world's ID you want to join to.", MsgBoxStyle.Critical, "Error")
                    TextBoxWorldID.Focus()
                End If
            Else
                If Not TextBoxWorldID.Text = "" Then
                    MsgBox("You didn't enter your password.", MsgBoxStyle.Critical, "Error")
                Else
                    MsgBox("You didn't enter your password, and the world's ID you want to join to.", MsgBoxStyle.Critical, "Error")
                End If
                TextBoxPassword.Focus()
            End If
        Else
            If Not TextBoxPassword.Text = "" Or RadioButtonFacebook.Checked Then
                If Not TextBoxWorldID.Text = "" Then
                    MsgBox("You didn't enter your e-mail address.", MsgBoxStyle.Critical, "Error")
                Else
                    MsgBox("You didn't enter your e-mail address, and the world's ID you want to join to.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                If Not TextBoxWorldID.Text = "" Then
                    MsgBox("You didn't enter your e-mail address, and your password.", MsgBoxStyle.Critical, "Error")
                Else
                    MsgBox("You didn't enter your e-mail address, your password, and the world's ID you want to join to.", MsgBoxStyle.Critical, "Error")
                End If
            End If
            TextBoxEmail.Focus()
        End If
    End Sub

    Private Sub RadioButtonTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonRegular.CheckedChanged, RadioButtonFacebook.CheckedChanged
        Dim senderAsRadioButton As RadioButton = TryCast(sender, RadioButton)

        If senderAsRadioButton IsNot Nothing AndAlso senderAsRadioButton.Checked Then
            If senderAsRadioButton Is RadioButtonRegular Then
                LabelPassword.Enabled = True
                TextBoxPassword.Text = My.Settings.LoginPasswords(0)
                TextBoxPassword.Enabled = True
                LabelEmail.Text = "E-mail:"
            Else 'If senderAsRadioButton Is RadioButtonFacebook Then
                TextBoxPassword.Enabled = False
                TextBoxPassword.Text = ""
                LabelPassword.Enabled = False
                LabelEmail.Text = "Token:"
            End If
        End If
    End Sub

#End Region
End Class
