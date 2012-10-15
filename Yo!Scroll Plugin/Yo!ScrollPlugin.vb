<Plugin(Authors := {"Processor", "Jojatekok"},
        Category := PluginCategory.LevelBot,
        Description := "Yo!Scroll level bot",
        Version := "1.0.0.0")>
Public Class YoScrollPlugin
    Inherits Plugin(Of YoScrollPlayer)

    Protected Overrides Sub OnEnable()
    End Sub

    Protected Overrides Sub OnDisable()
    End Sub

    Protected Overrides Sub OnConnect()
        Client.Chatter.Chat("Welcome to Yo!Scroll!")
    End Sub
End Class

Public NotInheritable Class YoScrollPlayer
    Inherits Player
End Class
