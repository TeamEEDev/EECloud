Imports System.Runtime.InteropServices

Friend Class LicenseForm

#Region "Methods"

    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxUsername.Text = My.Settings.LicenseUsername
        TextBoxKey.Text = My.Settings.LicenseKey
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If IsHandleCreated Then
            SetForegroundWindow(Handle)
        End If
    End Sub

    Private Sub TextBoxUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUsername.KeyPress
        If e.KeyChar = CtrlA Then
            TextBoxUsername.SelectAll()
        End If
    End Sub

    Private Sub TextBoxKey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxKey.KeyPress
        If e.KeyChar = CtrlA Then
            TextBoxKey.SelectAll()
        End If
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If Not TextBoxUsername.Text = String.Empty Then
            If Not TextBoxKey.Text = String.Empty Then
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
            If Not TextBoxKey.Text = String.Empty Then
                MessageBox.Show("You didn't enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("You didn't enter your username, and your license key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            TextBoxUsername.Focus()
        End If
    End Sub

#End Region
End Class
