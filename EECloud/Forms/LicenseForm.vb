Imports System.Runtime.InteropServices

Friend Class LicenseForm
    Private Class NativeMethods
        <DllImport("user32.dll")> _
        Friend Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    Friend Sub New()
        Me.Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxUsername.Text = My.Settings.LicenceUsername
        TextBoxKey.Text = My.Settings.LicenceKey
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Me.IsHandleCreated Then
            NativeMethods.SetForegroundWindow(Me.Handle)
        End If
    End Sub

    Private Sub TextBoxUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUsername.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            TextBoxUsername.SelectAll()
        End If
    End Sub

    Private Sub TextBoxKey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxKey.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            TextBoxKey.SelectAll()
        End If
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If Not TextBoxUsername.Text = "" Then
            If Not TextBoxKey.Text = "" Then
                My.Settings.LicenceUsername = TextBoxUsername.Text
                My.Settings.LicenceKey = TextBoxKey.Text
                My.Settings.Save()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("You didn't enter your license key.", MsgBoxStyle.Critical, "Error")
                TextBoxKey.Focus()
            End If
        Else
            If Not TextBoxKey.Text = "" Then
                MsgBox("You didn't enter your username.", MsgBoxStyle.Critical, "Error")
            Else
                MsgBox("You didn't enter your username, and your license key.", MsgBoxStyle.Critical, "Error")
            End If
            TextBoxUsername.Focus()
        End If
    End Sub
End Class
