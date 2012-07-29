Imports System.Runtime.InteropServices

Public Class LicenceForm
    <DllImport("user32.dll")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Sub New()
        Me.Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxUsername.Text = My.Settings.LicenceUsername
        TextBoxKey.Text = My.Settings.LicenceKey
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Me.IsHandleCreated Then
            SetForegroundWindow(Me.Handle)
        End If
    End Sub

    Private Sub ButtonJoinWorld_Click(sender As Object, e As EventArgs) Handles ButtonJoinWorld.Click
        If Not TextBoxUsername.Text = "" AndAlso Not TextBoxKey.Text = "" Then
            My.Settings.LicenceUsername = TextBoxUsername.Text
            My.Settings.LicenceKey = TextBoxKey.Text
            My.Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("You didn't enter some information", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class
