Imports System.Runtime.InteropServices

Friend Class LicenseForm

#Region "Methods"

    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        KeyPreview = True

        TextBoxUsername.Text = My.Settings.LicenseUsername
        TextBoxKey.Text = My.Settings.LicenseKey
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If IsHandleCreated Then
            SetForegroundWindow(Handle)
        End If
    End Sub

    Private Sub TextBoxUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUsername.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                TextBoxUsername.SelectAll()
            End If
        End If
    End Sub

    Private Sub TextBoxKey_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxKey.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                TextBoxKey.SelectAll()
            End If
        End If
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If Not String.IsNullOrEmpty(TextBoxUsername.Text) Then
            If Not String.IsNullOrEmpty(TextBoxKey.Text) Then
                My.Settings.LicenseUsername = TextBoxUsername.Text
                My.Settings.LicenseKey = TextBoxKey.Text

                My.Settings.Save()
                DialogResult = DialogResult.OK
                Close()
            Else
                MessageBox.Show("You didn't enter your license key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                TextBoxKey.Focus()
            End If
        Else
            If Not String.IsNullOrEmpty(TextBoxKey.Text) Then
                MessageBox.Show("You didn't enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("You didn't enter your username, and your license key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            TextBoxUsername.Focus()
        End If
    End Sub

#End Region
End Class
