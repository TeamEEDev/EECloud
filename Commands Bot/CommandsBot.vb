<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.LevelBot,
        Description:="Yo!Scroll level bot",
        StartupPriority:=PluginStartupPriority.Normal,
        Version:="1.0.0.0")>
Public Class CommandsBot
    Inherits Plugin(Of CommandsBotPlayer)
    Private WithEvents Connection As IConnection(Of CommandsBotPlayer)
    Private Chatter As IChatter

    Protected Overrides Sub OnEnable()

    End Sub

    Protected Overrides Sub OnDisable()

    End Sub

    Protected Overrides Sub OnConnect(mainConnection As IConnection(Of CommandsBotPlayer))
        Chatter.Chat("[Debug] The Commands Bot is active.")
    End Sub

    <Command("save", "!command", Group.Admin)>
    Public Sub SaveCommand(cmd As ICommand)
        Chatter.Chat("Saving world...")
        Connection.Send(New SaveWorld_SendMessage)
        'AddHandler SaveDone_ReceiveMessage, Sub()
        '                                        Chatter.Chat("World saved.")
        '                                    End Sub
    End Sub

    <Command("loadlevel", "!command", Group.Admin, Aliases:={"load", "loadworld", "reload", "reloadworld"})>
    Public Sub LoadLevelCommand(cmd As ICommand)
        Chatter.Chat("Loading world...")
        Chatter.Chat("/loadlevel")
        'AddHandler Reset_ReceiveMessage, Sub()
        '                                     Chatter.Chat("World loaded.")
        '                                 End Sub
    End Sub
End Class

Public Class CommandsBotPlayer
    Inherits Player

End Class
