﻿Friend NotInheritable Class DefaultCommandListner

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
    Private WithEvents myPlayerManager As IPlayerManager(Of Player)
#End Region

#Region "Methods"

    Sub New(ByVal client As IClient(Of Player))
        myClient = client
        myConnection = myClient.Connection
        myPlayerManager = myClient.PlayerManager
    End Sub

#If DEBUG Then
    <Command("douploadertest", Group.Operator)>
    Public Sub DoUploaderTestCommand(cmd As ICommand(Of Player))
        For i = 0 To myClient.World.SizeX - 1
            For j = 0 To myClient.World.SizeY - 1
                myClient.Uploader.Upload(New BlockPlaceUploadMessage(Layer.Foreground, i, j, Block.BlockBasicLightBlue))
            Next
        Next
    End Sub
#End If

    <Command("access", Group.Moderator)>
    Public Sub BanStrCommand(cmd As ICommand(Of Player))
        cmd.Reply("Test.")
    End Sub

    <Command("access", Group.Moderator)>
    Public Sub BanStrCommand(cmd As ICommand(Of Player), ParamArray editkey As String())
        myConnection.Send(New AccessSendMessage(String.Join(" ", editkey)))
        cmd.Reply("Key sent.")
    End Sub

    <Command("banstr", Group.Host, Aliases:={"banstring", "banmsg", "banmessage"})>
    Public Sub BanStrCommand(cmd As ICommand(Of Player), newMessage As String)
        My.Settings.BanString = newMessage
        My.Settings.Save()
        cmd.Reply("Ban message changed.")
    End Sub

    <Command("cmdchar", Group.Host, Aliases:={"commandchar"})>
    Public Sub CmdCharCommand(cmd As ICommand(Of Player), character As String)
        If character.Length = 1 Then
            My.Settings.CommandChar = character(0)
            My.Settings.Save()
            cmd.Reply("Command character changed, restarting EECloud is required.")
        Else
            cmd.Reply("Character expected, string received.")
        End If
    End Sub

    <Command("admin", Group.Host)>
    Public Sub AdminCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Admin, "an admin")
    End Sub

    <Command("op", Group.Admin)>
    Public Sub OpCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Operator, "an operator")
    End Sub

    <Command("mod", Group.Operator)>
    Public Sub ModCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Moderator, "a moderator")
    End Sub

    <Command("trust", Group.Operator)>
    Public Sub TrustCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Trusted, "a trusted player")
    End Sub

    <Command("default", Group.Operator, Aliases:={"normal", "user"})>
    Public Sub NormalCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.User, "a normal user")
    End Sub

    <Command("limit", Group.Operator)>
    Public Sub LimitCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Limited, "limited")
    End Sub

    <Command("ban", Group.Operator)>
    Public Sub BanCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Banned, "banned")
    End Sub

    Private Sub ChangeRank(cmd As ICommand(Of Player), username As String, rank As Group, groupName As String)
        Dim currRank As Group
        Dim player As Player = myClient.PlayerManager.Player(username)
        If player IsNot Nothing Then
            currRank = player.Group
        Else
            Dim data As UserData = Cloud.Service.GetPlayerData(username)
            If data IsNot Nothing Then
                currRank = data.GroupID
            End If
        End If


        If cmd.Sender Is Nothing OrElse currRank < cmd.Sender.Group Then
            If player IsNot Nothing Then
                player.Group = rank
                player.Save()
            Else
                Cloud.Service.SetPlayerDataGroupID(username, rank)
            End If

            cmd.Reply(String.Format("{0} is now {1}.", username, groupName))
        Else
            cmd.Reply(String.Format("Not allowed to change rank of that player."))
        End If
    End Sub

    <Command("who", Group.Host)>
    Public Sub WhoCommand(cmd As ICommand(Of Player))
        Dim playerList As List(Of String) = (From player In myClient.PlayerManager Select player.Username).ToList()
        If playerList.Count > 0 Then
            cmd.Reply(String.Join(", ", playerList))
        Else
            cmd.Reply("No one is currently online.")
        End If
    End Sub

    <Command("say", Group.Moderator)>
    Public Sub SayCommand(cmd As ICommand(Of Player), ParamArray msg As String())
        myClient.Chatter.Send(String.Join(" ", msg))
    End Sub

    <Command("send", Group.Admin)>
    Public Sub SendCommand(cmd As ICommand(Of Player), type As String, ParamArray parameters As String())
        myClient.Connection.Send(New CustomSendMessage(type, parameters))
    End Sub

    <Command("open", Group.Host)>
    Public Sub OpenCommand(cmd As ICommand(Of Player))
        Process.Start(My.Application.Info.DirectoryPath & "\Plugins\")
    End Sub

    <Command("about", Group.Trusted)>
    Public Sub AboutCommand(cmd As ICommand(Of Player), plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            cmd.Reply(String.Format("{0} {1} by {2}. Category: {3} - {4}",
                                    pluginObj.Name,
                                    pluginObj.Attribute.Version,
                                    String.Join(", ", pluginObj.Attribute.Authors),
                                    pluginObj.Attribute.Category,
                                    pluginObj.Attribute.Description))
        Else
            cmd.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("about", Group.Trusted)>
    Public Sub AboutCommand(cmd As ICommand(Of Player))
        cmd.Reply(String.Format("This bot is run by {0} Version {1}", My.Application.Info.Title, My.Application.Info.Version))
    End Sub

    <Command("enable", Group.Operator)>
    Public Sub EnableCommand(cmd As ICommand(Of Player), plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            If Not pluginObj.Started Then
                pluginObj.Restart()
                cmd.Reply("Started plugin.")
            Else
                cmd.Reply("Plugin already started, please disable it first!")
            End If
        Else
            cmd.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("disable", Group.Operator)>
    Public Sub DisableCommand(cmd As ICommand(Of Player), plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            If pluginObj.Started Then
                pluginObj.Stop()
                cmd.Reply("Stopped plugin.")
            Else
                cmd.Reply("Plugin not started, please enable it first!")
            End If
        Else
            cmd.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("ping", Group.Trusted)>
    Public Sub PingCommand(cmd As ICommand(Of Player))
        cmd.Reply("Pong!")
    End Sub

    <Command("hi", Group.Moderator, aliases:={"hello", "hai"})>
    Public Sub HiCommand(cmd As ICommand(Of Player))
        cmd.Reply("Hi!")
    End Sub

    <Command("hi", Group.Moderator, aliases:={"hello", "hai"})>
    Public Sub HiCommand(cmd As ICommand(Of Player), player As String)
        cmd.Reply(String.Format("Hi {0}!", player))
    End Sub

    <Command("setcode", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"code", "editkey", "seteditkey"})>
    Public Sub SetCodeCommand(cmd As ICommand(Of Player), editkey As String)
        myClient.Connection.Send(New ChangeWorldEditKeySendMessage(editkey))
        cmd.Reply("Changed edit key")
    End Sub

    <Command("kick", Group.Moderator, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(cmd As ICommand(Of Player), user As String, ParamArray reason As String())
        KickPlayer(cmd, user, String.Join(" ", reason))
    End Sub

    <Command("kick", Group.Moderator, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(cmd As ICommand(Of Player), user As String)
        KickPlayer(cmd, user, "Tsk tsk tsk")
    End Sub

    Private Sub KickPlayer(cmd As ICommand(Of Player), user As String, reason As String)
        Dim player As Player = myClient.PlayerManager.Player(user)
        If player IsNot Nothing Then
            If cmd.Sender Is Nothing OrElse cmd.Sender.Group >= Group.Operator OrElse player.Group <= cmd.Sender.Group Then
                player.Kick(reason)
                cmd.Reply("Kicked.")
            Else
                cmd.Reply(String.Format("Not allowed to kick a user with a higher rank that yourself."))
            End If
        Else
            cmd.Reply("Can not find player.")
        End If
    End Sub

    <Command("reloadplayer", Group.Moderator, Aliases:={"rplayer"})>
    Public Async Sub ReloadPlayerCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As IPlayer = myClient.PlayerManager.Player(Player)
        If player1 IsNot Nothing Then
            Await player1.ReloadUserDataAsync()
            cmd.Reply("Reloaded userdata.")
        Else
            cmd.Reply("Unknown player.")
        End If
    End Sub

    <Command("env", Group.Moderator, Aliases:={"getenv", "iscloud"})>
    Public Sub GetEnvironmentCommand(cmd As ICommand(Of Player))
        Dim env As String
        If Cloud.IsNoGUI Then
            env = "cloud"
        Else
            env = "desktop"
        End If
        cmd.Reply("Current environment: " & env)
    End Sub

    <Command("host", Group.Moderator, Aliases:={"gethost", "hoster"})>
    Public Sub HostCommand(cmd As ICommand(Of Player))
        cmd.Reply("Current host: " & Cloud.LicenseUsername)
    End Sub

    <Command("end", Group.Moderator, Aliases:={"shutdown", "leave", "leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub EndCommand(cmd As ICommand(Of Player))
        cmd.Reply("Terminating...")
        myClient.Connection.Close()
    End Sub

    <Command("killbot", Group.Admin)>
    Public Sub KillBotCommand(cmd As ICommand(Of Player))
        cmd.Reply("Dying...")
        Environment.Exit(0) 'Makes the program not start again on the cloud; must re-deploy, the connection is terminated and plugins will not have their OnDisable command run.
    End Sub

    <Command("clear", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand(Of Player))
        myClient.Connection.Send(New ClearWorldSendMessage)
        cmd.Reply("Cleared.")
    End Sub

    <Command("name", Group.Moderator, AccessRight:=AccessRight.Owner, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(cmd As ICommand(Of Player), ParamArray newName As String())
        myClient.Connection.Send(New ChangeWorldNameSendMessage(String.Join(" ", newName)))
        cmd.Reply("Renamed.")
    End Sub

    <Command("loadlevel", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(cmd As ICommand(Of Player))
        cmd.Reply("Reloaded.")
        myClient.Chatter.Loadlevel()
    End Sub

    <Command("save", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(cmd As ICommand(Of Player))
        myClient.Connection.Send(New SaveWorldSendMessage)
        cmd.Reply("Saved.")
    End Sub

    <Command("reset", Group.Operator, Aliases:={"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(cmd As ICommand(Of Player))
        myClient.Chatter.Reset()
        cmd.Reply("Reset.")
    End Sub

    Private Sub myConnection_ReceiveInfo(sender As Object, e As InfoReceiveMessage) Handles myConnection.ReceiveInfo
        Cloud.Logger.Log(LogPriority.Info, String.Format("{0}: {1}.", e.Title, e.Text))
    End Sub

    Private Sub myPlayerManager_GroupChange(sender As Object, e As Player) Handles myPlayerManager.GroupChange
        If myClient.Game.AccessRight >= AccessRight.Owner Then
            If e.Group >= Group.Moderator Then
                e.GiveEdit()
            ElseIf e.Group <= Group.Banned Then
                e.Kick(My.Settings.BanString)
            Else
                e.RemoveEdit()
            End If
        End If
    End Sub

    Private Sub myPlayerManager_UserDataReady(sender As Object, e As Player) Handles myPlayerManager.UserDataReady
        If myClient.Game.AccessRight >= AccessRight.Owner Then
            If e.Group >= Group.Moderator Then
                e.GiveEdit()
            ElseIf e.Group <= Group.Banned Then
                e.Kick(My.Settings.BanString)
            End If
        End If
    End Sub

    Private Sub myPlayerManager_OnSay(sender As Object, e As Player) Handles myPlayerManager.OnSay
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Say, e.Username))
    End Sub

    Private Sub myConnection_ReceiveSayOld(sender As Object, e As SayOldReceiveMessage) Handles myConnection.ReceiveSayOld
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Text, e.Username))
    End Sub

    Private Sub myConnection_ReceiveWrite(sender As Object, e As WriteReceiveMessage) Handles myConnection.ReceiveWrite
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Text, e.Title))
    End Sub

    Private Sub myConnection_SendSay(sender As Object, e As Cancelable(Of SaySendMessage)) Handles myConnection.SendSay
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Value.Text, myClient.Game.MyPlayer.Username))
    End Sub

#End Region
End Class