<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Test Or PluginCategory.Fun,
        ChatName:="Test",
        Description:="A test plugin to test stuff",
        Version:="1.0.0.0")>
Public Class TestPlugin
    Inherits Plugin(Of TestPlayer)

    Protected Overrides Sub OnEnable()
    End Sub

    Protected Overrides Sub OnDisable()
    End Sub

    Private Sub Connection_OnSendMove(sender As Object, e As SendEventArgs(Of MoveSendMessage)) Handles Connection.OnSendMove
    End Sub

    <Command("test", Group.Admin, Aliases:={"hi"})>
    Public Sub TestCommand(cmd As ICommand(Of TestPlayer))
        cmd.Sender.Reply("testin")
    End Sub

    <Command("test", Group.Admin, Aliases:={"hi"})>
    Public Sub TestCommand(cmd As ICommand(Of TestPlayer), vars As String)
        cmd.Sender.Reply("You said: " & String.Join(" ", vars))
    End Sub

    Protected Overrides Sub OnConnect()
        Connection.Chatter.Chat("Hi")
    End Sub
End Class

Public NotInheritable Class TestPlayer
    Inherits Player
End Class
