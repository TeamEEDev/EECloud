<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Test Or PluginCategory.Fun,
        Description:="A test plugin to test stuff",
        StartupPriority:=PluginStartupPriority.Normal,
        Version:="1.0.0.0")>
Public Class TestPlugin
    Inherits Plugin(Of TestPlayer)
    Private WithEvents Connection As Connection(Of TestPlayer)
    Private Chatter As IChatter

    Protected Overrides Sub OnEnable()

    End Sub

    Protected Overrides Sub OnDisable()

    End Sub

    Protected Overrides Sub OnConnect(mainConnection As Connection(Of TestPlayer))
        Me.Connection = mainConnection
        Chatter = Connection.GetChatter("TestPlugin")
        Chatter.Chat("Hi")
    End Sub

    Private Sub Connection_OnSendMove(sender As Object, e As OnSendMessageEventArgs(Of Move_SendMessage)) Handles Connection.OnSendMove
        'EAT ALL MOVE MESSAGES!!!
        Dim Handle As SendMessageHandle(Of Move_SendMessage) = e.GetHandle() 'Get the handle; once a handle is created, the message wont be sent anymore
        'If we want to send it later:
        'Handle.Send()
        'The difference of that send is that it won't call the events; but nope, you can call it once per handle
        'What if two plugins call the GetHandle method? The message will be sent once Send() has been called on all handles!
    End Sub

    <Command("test", "!command username password", Group.Admin, Aliases:={"hi"})>
    Public Sub TestCommand(cmd As Command)
        Chatter.Chat(":D")
    End Sub
End Class

Public Class TestPlayer
    Inherits Player

End Class
