﻿<Plugin(Authors:={"Processor", "Jojatekok"},
        Category:=PluginCategory.Tool,
        Description:="Commands Bot",
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

    <Command("end", "!command", Group.Admin, Aliases:={"shutdown", "killbot"})>
    Public Sub EndCommand(cmd As ICommand)
        Chatter.Chat("Terminating...")
        'End
    End Sub

    <Command("leave", "!command", Group.Admin, Aliases:={"leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub LeaveWorldCommand(cmd As ICommand)
        Chatter.Chat("Leaving world...")
        Connection.Disconnect()
    End Sub

    <Command("clear", "!command", Group.Moderator, Aliases:={"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand)
        Connection.Send(New ClearWorld_SendMessage)
        AddHandler Connection.OnReceiveClear, Sub()
                                                  Chatter.Chat("World cleared.")
                                              End Sub
    End Sub

    <Command("name", "!command [name]", Group.Moderator, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(cmd As ICommand)
        Connection.Send(New ChangeWorldName_SendMessage(cmd.Args.ToString))
        AddHandler Connection.OnReceiveUpdateMeta, Sub()
                                                       Chatter.Chat("World name changed.")
                                                   End Sub
    End Sub

    <Command("loadlevel", "!command", Group.Operator, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(cmd As ICommand)
        Chatter.Chat("Loading world...")
        Chatter.Loadlevel()
        AddHandler Connection.OnReceiveReset, Sub()
                                                  Chatter.Chat("World loaded.")
                                              End Sub
    End Sub

    <Command("save", "!command", Group.Operator, Aliases:={"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(cmd As ICommand)
        Chatter.Chat("Saving world...")
        Connection.Send(New SaveWorld_SendMessage)
        AddHandler Connection.OnReceiveSaveDone, Sub()
                                                     Chatter.Chat("World saved.")
                                                 End Sub
    End Sub

    <Command("reset", "!command", Group.Operator, Aliases:={"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(cmd As ICommand)
        Chatter.Reset()
        AddHandler Connection.OnReceiveTeleport, Sub()
                                                     Chatter.Chat("Players' position reset.")
                                                 End Sub
    End Sub
End Class

Public Class CommandsBotPlayer
    Inherits Player

End Class
