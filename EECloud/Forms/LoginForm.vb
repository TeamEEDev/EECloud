Public Class LoginForm
    Public Sub New()
        Me.Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxEmail.Text = My.Settings.LoginEmail
        TextBoxPassword.Text = My.Settings.LoginPassword
        TextBoxWorldID.Text = My.Settings.LoginWorldID
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If TextBoxEmail.Text <> "" AndAlso TextBoxPassword.Text <> "" AndAlso TextBoxWorldID.Text <> "" Then
            ButtonJoinWorld.Focus()
        End If
    End Sub

    Private Sub TextBoxes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxEmail.KeyDown, TextBoxPassword.KeyDown, TextBoxWorldID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonJoinWorld_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ButtonJoinWorld_Click(sender As Object, e As EventArgs) Handles ButtonJoinWorld.Click
        If TextBoxEmail.Text <> "" AndAlso TextBoxPassword.Text <> "" AndAlso TextBoxWorldID.Text <> "" Then
            My.Settings.LoginEmail = TextBoxEmail.Text
            My.Settings.LoginPassword = TextBoxPassword.Text
            My.Settings.LoginWorldID = TextBoxWorldID.Text
            My.Settings.Save()
            Me.Close()
        Else
            MsgBox("You didn't enter some information", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class
