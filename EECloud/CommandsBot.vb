﻿<Plugin(Authors := {"Processor", "Jojatekok"},
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

    <Command("end", Group.Admin, Aliases:={"shutdown", "killbot"})>
    Public Sub EndCommand(cmd As ICommand(Of CommandsBotPlayer))
        Connection.Chatter.Chat("Terminating...")
        'end
    End Sub

    <Command("leave", Group.Operator, Aliases:={"leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub LeaveWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        Connection.Chatter.Chat("Leaving world...")
        CType(Connection, Connection(Of CommandsBotPlayer)).InternalConnection.Close()
    End Sub

    <Command("clear", Group.Moderator, Aliases:={"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        'If Connection.Players(0).IsOwner Then
        Connection.Send(New ClearWorldSendMessage)
        AddHandler Connection.ReceiveClear, Sub()
                                                Connection.Chatter.Chat("World cleared.")
                                            End Sub
        'Else
        '    Chatter.Chat("Can't clear world.")
        'End If
    End Sub

    <Command("name", Group.Moderator, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(cmd As ICommand(Of CommandsBotPlayer))
        'If Connection.Players(0).IsOwner Then
        'Connection.Send(New ChangeWorldName_SendMessage(cmd.Args.ToString))
        AddHandler Connection.ReceiveUpdateMeta, Sub()
                                                     Connection.Chatter.Chat("World name changed.")
                                                 End Sub
        'Else
        '    Chatter.Chat("Can't rename world.")
        'End If
    End Sub

    <Command("loadlevel", Group.Operator, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Chat("Loading world...")
        Connection.Chatter.Loadlevel()
        AddHandler Connection.ReceiveReset, Sub()
                                                Connection.Chatter.Chat("World loaded.")
                                            End Sub
        'Else
        '    Chatter.Chat("Can't load world.")
        'End If
    End Sub

    <Command("save", Group.Operator, Aliases:={"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Chat("Saving world...")
        Connection.Send(New SaveWorldSendMessage)
        AddHandler Connection.ReceiveSaveDone, Sub()
                                                   Connection.Chatter.Chat("World saved.")
                                               End Sub
        'Else
        '    Chatter.Chat("Can't save world.")
        'End If
    End Sub

    <Command("reset", Group.Operator, Aliases:={"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(cmd As ICommand(Of CommandsBotPlayer))
        'If Connection.Players(0).IsOwner Then
        Connection.Chatter.Reset()
        AddHandler Connection.ReceiveTeleport, Sub()
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
