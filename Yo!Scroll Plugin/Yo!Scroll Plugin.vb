<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.LevelBot,
        Description:="Yo!Scroll level bot",
        StartupPriority:=PluginStartupPriority.Normal,
        Version:="1.0.0.0")>
Public Class YoScroll_Plugin
    Inherits Plugin(Of YoScrollPlayer)
    Private WithEvents Connection As Connection(Of YoScrollPlayer)
    Private Chatter As IChatter

    Protected Overrides Sub OnEnable()

    End Sub

    Protected Overrides Sub OnDisable()

    End Sub

    Protected Overrides Sub OnConnect(mainConnection As Connection(Of YoScrollPlayer))
        Me.Connection = mainConnection
        Chatter = Connection.GetChatter("Yo!Scroll Plugin")
        Chatter.Chat("Welcome to Yo!Scroll!")
    End Sub
End Class

Public Class YoScrollPlayer
    Inherits Player

End Class
