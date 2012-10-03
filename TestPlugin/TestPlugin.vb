Imports System.Threading.Tasks

<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Test Or PluginCategory.Fun,
        Description:="A test plugin to test stuff",
        StartupPriority:=PluginStartupPriority.Normal,
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
    Public Sub TestCommand(cmd As ICommand)
        Connection.Chatter.Chat(":D")
    End Sub

    Protected Overrides Async Sub OnConnect()
        Connection.Chatter.Chat("Hi")
        Connection.Send(New MoveSendMessage(0, 0, 0, 0, 0, 0, 0, 0))

        For m = 1 To 99
            For n = 1 To 99
                Await task.Delay(25)
                Connection.Send(New BlockPlaceSendMessage(Layer.Foreground, n, m, BlockType.BlockGravityNothing))
            Next
        Next


    End Sub
End Class

Public NotInheritable Class TestPlayer
    Inherits Player
End Class
