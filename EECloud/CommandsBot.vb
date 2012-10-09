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
        Client.Chatter.Chat("[Debug] The Commands Bot is active.")
    End Sub

    '<Command("end", Group.Admin, Aliases:={"shutdown", "killbot"})>
    'Public Sub EndCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Chat("Terminating...")
    '    'end
    'End Sub

    '<Command("leave", Group.Operator, Aliases:={"leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    'Public Sub LeaveWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Chat("Leaving world...")
    '    CType(Client, Client(Of CommandsBotPlayer)).InternalConnection.Close()
    'End Sub

    '<Command("clear", Group.Moderator, Aliases:={"clearworld", "clearlevel"})>
    'Public Sub ClearWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Send(New ClearWorldSendMessage)
    '    AddHandler Client.ReceiveClear, Sub()
    '                                            Client.Chatter.Chat("World cleared.")
    '                                        End Sub
    'End Sub

    '<Command("name", Group.Moderator, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    'Public Sub ChangeWorldNameCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    AddHandler Client.ReceiveUpdateMeta, Sub()
    '                                                 Client.Chatter.Chat("World name changed.")
    '                                             End Sub
    'End Sub

    '<Command("loadlevel", Group.Operator, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    'Public Sub LoadWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Chat("Loading world...")
    '    Client.Chatter.Loadlevel()
    '    AddHandler Client.ReceiveReset, Sub()
    '                                            Client.Chatter.Chat("World loaded.")
    '                                        End Sub
    'End Sub

    '<Command("save", Group.Operator, Aliases:={"saveworld", "savelevel"})>
    'Public Sub SaveWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Chat("Saving world...")
    '    Client.Send(New SaveWorldSendMessage)
    '    AddHandler Client.ReceiveSaveDone, Sub()
    '                                               Client.Chatter.Chat("World saved.")
    '                                           End Sub
    'End Sub

    '<Command("reset", Group.Operator, Aliases:={"resetworld", "resetlevel", "resetplayers"})>
    'Public Sub ResetCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Reset()
    '    AddHandler Client.ReceiveTeleport, Sub()
    '                                               Client.Chatter.Chat("Players' position reset.")
    '                                           End Sub
    'End Sub
End Class

Public NotInheritable Class CommandsBotPlayer
    Inherits Player
End Class
