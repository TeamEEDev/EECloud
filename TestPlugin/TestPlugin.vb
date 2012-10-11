<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Test Or PluginCategory.Fun,
        ChatName:="Test",
        Description:="A test plugin to test stuff",
        Version:="1.0.0.0")>
Public Class TestPlugin
    Inherits Plugin(Of TestPlayer)
    Dim WithEvents myConnection As IConnection

    Protected Overrides Sub OnEnable()
        myConnection = Client.Connection
    End Sub

    Protected Overrides Sub OnDisable()
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

    End Sub

    Private Sub myConnection_ReceiveAdd(sender As Object, e As AddReceiveMessage) Handles myConnection.ReceiveAdd
        Client.PlayerManager.GetPlayers().ToString()
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit

    End Sub
End Class

Public NotInheritable Class TestPlayer
    Inherits Player
End Class
