<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Tool,
        Description:="Commands Bot",
        Version:="1.0.0.0",
        ChatName:="Bot")>
Public NotInheritable Class CommandsBot
    Inherits Plugin(Of CommandsBotPlayer)

    Protected Overrides Sub OnEnable()
        Client.CommandManager.Load(Me)
    End Sub

    Protected Overrides Sub OnDisable()
    End Sub

    Protected Overrides Sub OnConnect()

    End Sub

    <Command("end", Group.Admin, Aliases:={"shutdown", "killbot", "leave", "leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub EndCommand(cmd As ICommand(Of CommandsBotPlayer))
        cmd.Sender.Reply("Terminating...")
        Client.Connection.Close()
    End Sub

    '<Command("clear", Group.Moderator, Aliases:={"clearworld", "clearlevel"})>
    'Public Sub ClearWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Connection.Send(New ClearWorldSendMessage)
    'End Sub

    '<Command("name", Group.Moderator, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    'Public Sub ChangeWorldNameCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    'TODO: Implement
    'End Sub

    '<Command("loadlevel", Group.Operator, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    'Public Sub LoadWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
    '    Client.Chatter.Chat("Loading world...")
    '    Client.Chatter.Loadlevel()
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
