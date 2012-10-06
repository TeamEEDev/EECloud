<Plugin(Authors := {"Processor", "Jojatekok"},
        Category := PluginCategory.Tool,
        Description := "Commands Bot",
        Version := "1.0.0.0")>
Public Class CommandsBot
    Inherits Plugin(Of CommandsBotPlayer)

    Protected Overrides Sub OnEnable()
    End Sub

    Protected Overrides Sub OnDisable()
    End Sub

    Protected Overrides Sub OnConnect()
        Connection.Chatter.Chat("[Debug] The Commands Bot is active.")
    End Sub

    <Command("end", Group.Admin, Aliases := {"shutdown", "killbot"})>
    Public Sub EndCommand(cmd As ICommand)
        Connection.Chatter.Chat("Terminating...")
        'end
    End Sub

    'TODOD: make this possible somehow, waiting to see how CommandManager will look like when finished
    '<Command("leave", "!command", Group.Admin, Aliases:={"leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    'Public Sub LeaveWorldCommand(cmd As ICommand)
    '    Chatter.Chat("Leaving world...")
    '    Connection.Disconnect()
    'End Sub

    <Command("clear", Group.Moderator, Aliases := {"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand)
        'If Connection.Players(0).IsOwner Then
        Connection.Send(New ClearWorldSendMessage)
        AddHandler Connection.OnReceiveClear, Sub()
            Connection.Chatter.Chat("World cleared.")
                                              End Sub
        'Else
        '    Chatter.Chat("Can't clear world.")
        'End If
    End Sub

    <Command("name", Group.Moderator, Aliases := {"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(cmd As ICommand)
        'If Connection.Players(0).IsOwner Then
        'Connection.Send(New ChangeWorldName_SendMessage(cmd.Args.ToString))
        AddHandler Connection.OnReceiveUpdateMeta, Sub()
            Connection.Chatter.Chat("World name changed.")
                                                   End Sub
        'Else
        '    Chatter.Chat("Can't rename world.")
        'End If
    End Sub

    <Command("loadlevel", Group.Operator, Aliases := {"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(cmd As ICommand)
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Chat("Loading world...")
        Connection.Chatter.Loadlevel()
        AddHandler Connection.OnReceiveReset, Sub()
            Connection.Chatter.Chat("World loaded.")
                                              End Sub
        'Else
        '    Chatter.Chat("Can't load world.")
        'End If
    End Sub

    <Command("save", Group.Operator, Aliases := {"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(cmd As ICommand)
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Chat("Saving world...")
        Connection.Send(New SaveWorldSendMessage)
        AddHandler Connection.OnReceiveSaveDone, Sub()
            Connection.Chatter.Chat("World saved.")
                                                 End Sub
        'Else
        '    Chatter.Chat("Can't save world.")
        'End If
    End Sub

    <Command("reset", Group.Operator, Aliases := {"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(cmd As ICommand)
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Reset()
        AddHandler Connection.OnReceiveTeleport, Sub()
            Connection.Chatter.Chat("Players' position reset.")
                                                 End Sub
        'Else
        '    Chatter.Chat("Can't reset players' position.")
        'End If
    End Sub
End Class

Public NotInheritable Class CommandsBotPlayer
    Inherits Player
End Class
