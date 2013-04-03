Imports System.Runtime.InteropServices

Friend Class UserDataForm

#Region "Methods"

    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxUsername.Text = My.Settings.InGameUserame
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

                e.Handled = True
                Exit Sub
            End If
        End If

        TextBoxUsername.Text = TextBoxUsername.Text.ToLower(InvariantCulture)
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If Not String.IsNullOrWhiteSpace(TextBoxUsername.Text) Then
            My.Settings.InGameUserame = TextBoxUsername.Text
            My.Settings.Save()

            DialogResult = DialogResult.OK
            Close()
        Else
            MessageBox.Show("You didn't enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            TextBoxUsername.Focus()
        End If
    End Sub

#End Region

End Class
