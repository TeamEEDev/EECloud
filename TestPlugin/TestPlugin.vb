<Plugin(Authors := {"Processor", "Jojatekok"},
        Category := PluginCategory.Test Or PluginCategory.Fun,
        Description := "A test plugin to test stuff",
        StartupPriority := PluginStartupPriority.Normal,
        Version := "1.0.0.0")>
Public Class TestPlugin
    Inherits Plugin(Of TestPlayer)

    Protected Overrides Sub OnEnable()
    End Sub

    Protected Overrides Sub OnDisable()
    End Sub

    Protected Overrides Sub OnConnect()
        Connection.Chatter.Chat("Hi")
    End Sub

    Private Sub Connection_OnSendMove(sender As Object, e As SendEventArgs(Of Move_SendMessage)) Handles Connection.OnSendMove
        'EAT ALL MOVE MESSAGES!!!
        e.Handled = True
    End Sub

    <Command("test", Group.Admin, Aliases := {"hi"})>
    Public Sub TestCommand(cmd As ICommand)
        Connection.Chatter.Chat(":D")
    End Sub
End Class

Public NotInheritable Class TestPlayer
    Inherits Player
End Class
