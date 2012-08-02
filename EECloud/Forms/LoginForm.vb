Imports System.Runtime.InteropServices

Public Class LoginForm
    Private Class NativeMethods
        <DllImport("user32.dll")> _
        Friend Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    Public Sub New()
        Me.Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxEmail.Text = My.Settings.LoginEmail
        TextBoxPassword.Text = My.Settings.LoginPassword
        TextBoxWorldID.Text = My.Settings.LoginWorldID
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Me.IsHandleCreated Then
            NativeMethods.SetForegroundWindow(Me.Handle)
        End If
    End Sub

    Private Sub ButtonJoinWorld_Click(sender As Object, e As EventArgs) Handles ButtonJoinWorld.Click
        If Not TextBoxEmail.Text = "" AndAlso Not TextBoxPassword.Text = "" AndAlso Not TextBoxWorldID.Text = "" Then
            My.Settings.LoginEmail = TextBoxEmail.Text
            My.Settings.LoginPassword = TextBoxPassword.Text
            My.Settings.LoginWorldID = TextBoxWorldID.Text
            My.Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("You didn't enter some information", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class
