﻿Imports System.Runtime.InteropServices

Friend NotInheritable Class LoginForm
    <DllImport("user32.dll")>
    Private Shared Sub SetForegroundWindow(ByVal hWnd As IntPtr)
    End Sub

    Friend Sub New()
        Icon = My.Resources.Icon
        InitializeComponent()

        TextBoxEmail.Text = My.Settings.LoginEmail
        TextBoxPassword.Text = My.Settings.LoginPassword
        TextBoxWorldID.Text = My.Settings.LoginWorldID
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
            If Not TextBoxPassword.Text = "" Then
                If Not TextBoxWorldID.Text = "" Then
                    My.Settings.LoginEmail = TextBoxEmail.Text
                    My.Settings.LoginPassword = TextBoxPassword.Text
                    My.Settings.LoginWorldID = TextBoxWorldID.Text
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
            If Not TextBoxPassword.Text = "" Then
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
End Class