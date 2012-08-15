﻿<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Test And PluginCategory.Fun,
        Description:="A Test plugin",
        StartupPriority:=PluginStartupPriority.Normal,
        Version:="1.0.0.0")>
Public Class Testplugin
    Inherits Plugin(Of TestPlayer)
    Private WithEvents Connection As Connection(Of TestPlayer)
    Protected Overrides Sub OnDisable()

    End Sub

    Protected Overrides Sub OnEnable(mainConnection As Connection(Of TestPlayer))
        Me.Connection = mainConnection
    End Sub

    Private Sub Connection_OnSendMove(sender As Object, e As OnSendMessageEventArgs(Of Move_SendMessage)) Handles Connection.OnSendMove
        'EAT ALL MOVE MESSAGES!!!
        Dim Handle As SendMessageHandle(Of Move_SendMessage) = e.GetHandle() 'Get the handle; once a handle is created, the message wont be sent anymore
        'If we want to send it later:
        'Handle.Send()
        'The difference of that send is that it wont call the events; but nope, you can call it once per handle
        'What if two plugins call the GetHandle method? The message will be sent once Send() has been called on all handles!
    End Sub
End Class

Public Class TestPlayer
    Inherits Player

End Class