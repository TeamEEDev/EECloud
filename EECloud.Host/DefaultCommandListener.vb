Imports System.Threading

Friend NotInheritable Class DefaultCommandListener

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
    Private WithEvents myPlayerManager As IPlayerManager(Of Player)
#End Region

#Region "Methods"

    Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = myClient.Connection
        myPlayerManager = myClient.PlayerManager
    End Sub

#If DEBUG Then
    <Command("douploadertest", Group.Operator)>
    Public Sub DoUploaderTestCommand(request As CommandRequest)
        For i = 0 To myClient.World.SizeX - 1
            For j = 0 To myClient.World.SizeY - 1
                myClient.Uploader.Upload(New BlockPlaceUploadMessage(Layer.Foreground, i, j, Block.BlockBasicLightBlue))
            Next
        Next
    End Sub
#End If

    <Command("getrank", Group.Moderator, Aliases:={"rank", "group", "getgroup", "userrank", "usergroup", "playerrank", "playergroup"})>
    Public Async Sub GetRankCommand(cmd As ICommand(Of Player), username As String)
    Public Sub GetRankCommand(request As CommandRequest, username As String)
        username = GetPlayerNormalizedUsername(username)
        Dim player As IPlayer = GetPlayer(username, True)
        Dim rank As Group

        If player IsNot Nothing Then
            rank = player.Group
        Else
            Dim playerData = Await Cloud.Service.GetPlayerDataAsync(username)
            If playerData IsNot Nothing Then
                rank = playerData.GroupID
            End If
        End If

        request.Sender.Reply(String.Format("User {0} is {1}.", username.ToUpper(InvariantCulture), GetGroupString(rank)))
    End Sub

    'TODO: Make this happen in Host application
    'Private pinging As Boolean

    '<Command("pinghost", Group.Moderator)>
    'Public Sub PingHostCommand(request As CommandRequest)
    '    If request.Sender IsNot Nothing Then
    '        If Not pinging Then
    '            pinging = True
    '            Call New Thread(Sub(obj As Object)
    '                                Beep()
    '                                MessageBox.Show("Ping from user: " & request.Sender.Username,
    '                                                "Ping received",
    '                                                MessageBoxButtons.OK,
    '                                                MessageBoxIcon.Information)

    '                                pinging = False
    '                            End Sub).Start()
    '        Else
    '            request.Sender.Reply("A ping has been already sent.")
    '        End If
    '    Else
    '        request.Sender.Reply("Cannot ping from console.")
    '    End If
    'End Sub

    <Command("respawnall", Group.Moderator)>
    Public Sub RespawnAllCommand(request As CommandRequest)
        myClient.Chatter.RespawnAll()
    End Sub

    <Command("killemall", Group.Moderator)>
    Public Sub KillEmAllCommand(request As CommandRequest)
        myClient.Chatter.KillAll()
    End Sub

    <Command("kill", Group.Moderator)>
    Public Sub KillCommand(request As CommandRequest, username As String)
        Dim player As IPlayer = GetPlayer(username)
        If player IsNot Nothing Then
            player.Kill()
            request.Sender.Reply("Killed.")
        Else
            request.Sender.Reply("Unknown player.")
        End If
    End Sub

    <Command("access", Group.Moderator)>
    Public Sub BanStrCommand(request As CommandRequest)
        request.Sender.Reply("Test.")
    End Sub

    <Command("access", Group.Moderator)>
    Public Sub BanStrCommand(request As CommandRequest, ParamArray editkey As String())
        myConnection.Send(New AccessSendMessage(String.Join(" ", editkey)))
        request.Sender.Reply("Key sent.")
    End Sub

    <Command("banstr", Group.Host, Aliases:={"banstring", "banmsg", "banmessage"})>
    Public Sub BanStrCommand(request As CommandRequest, newMessage As String)
        My.Settings.BanString = newMessage
        My.Settings.Save()
        request.Sender.Reply("Ban message changed.")
    End Sub

    <Command("requestchar", Group.Host, Aliases:={"commandchar", "requestchr"})>
    Public Sub requestCharCommand(request As CommandRequest, character As String)
        If character.Length = 1 Then
            My.Settings.CommandChar = character(0)
            My.Settings.Save()
            request.Sender.Reply("Command character changed, restarting EECloud is required.")
        Else
            request.Sender.Reply("Character expected, string received.")
        End If
    End Sub

    <Command("admin", Group.Host, Aliases:={"administrator"})>
    Public Sub AdminCommand(request As CommandRequest, username As String)
        ChangeRank(request, username, Group.Admin)
    End Sub

    <Command("op", Group.Admin, Aliases:={"operator"})>
    Public Sub OpCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.Operator)
    End Sub

    <Command("mod", Group.Operator, Aliases:={"moderator"})>
    Public Sub ModCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.Moderator)
    End Sub

    <Command("trust", Group.Operator)>
    Public Sub TrustCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.Trusted)
    End Sub

    <Command("default", Group.Operator, Aliases:={"normal", "user"})>
    Public Sub NormalCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.User)
    End Sub

    <Command("limit", Group.Operator)>
    Public Sub LimitCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.Limited)
    End Sub

    <Command("ban", Group.Operator)>
    Public Sub BanCommand(request As CommandRequest, username As String)
        ChangeRank(request, GetPlayerNormalizedUsername(username), Group.Banned)
    End Sub

    Private Async Sub ChangeRank(cmd As ICommand(Of Player), username As String, rank As Group)
    Private Sub ChangeRank(request As CommandRequest, username As String, rank As Group)
        username = GetPlayerNormalizedUsername(username)
        Dim currRank As Group
        Dim player As Player = GetPlayer(username, True)

        If player IsNot Nothing Then
            currRank = player.Group
        Else
            Dim playerData As UserData = Await Cloud.Service.GetPlayerDataAsync(username)
            If playerData IsNot Nothing Then
                currRank = playerData.GroupID
            End If
        End If


        If request.Sender Is Nothing OrElse currRank < request.Rights Then
            If player IsNot Nothing Then
                player.Group = rank
                player.Save()
            Else
                Await Cloud.Service.SetPlayerDataGroupIDAsync(username, rank)
            End If

            request.Sender.Reply(String.Format("{0} is now {1}.", username.ToUpper(InvariantCulture), GetGroupString(rank)))
        Else
            request.Sender.Reply("Not allowed to change rank of that player.")
        End If
    End Sub

    Private Shared Function GetGroupString(rank As Group) As String
        Select Case rank
            Case Group.Host
                Return "the host"
            Case Group.Admin
                Return "an administrator"
            Case Group.Operator
                Return "an operator"
            Case Group.Moderator
                Return "a moderator"
            Case Group.Trusted
                Return "a trusted player"
            Case Group.User
                Return "a normal player"
            Case Group.Limited
                Return "a limited player"
            Case Group.Banned
                Return "banned"
            Case Else
                Return "a player with an unknown rank"
        End Select
    End Function

    <Command("online", Group.Host, Aliases:={"who"})>
    Public Sub OnlineCommand(request As CommandRequest)
        Dim playerList As String() = (From player In myClient.PlayerManager Select player.Username).ToArray()
        If playerList.Count > 0 Then
            request.Sender.Reply(String.Format("{0} players are online: {1}", playerList.Count, String.Join(", ", playerList)))
        Else
            request.Sender.Reply("No one is currently online.")
        End If
    End Sub

    <Command("say", Group.Moderator)>
    Public Sub SayCommand(request As CommandRequest, ParamArray msg As String())
        Dim realSenderString As String = String.Empty

        If myClient.Game.MyPlayer IsNot Nothing Then
            If request.Sender Is Nothing Then
                If Cloud.LicenseInGameName IsNot Nothing Then
                    If Cloud.LicenseInGameName <> myClient.Game.MyPlayer.Username Then
                        realSenderString = "[" & MakeFirstLetterUpperCased(Cloud.LicenseInGameName) & "] "
                    End If
                Else
                    realSenderString = "[" & Cloud.LicenseUsername & "] "
                End If
            Else
                If request.Sender.Username <> myClient.Game.MyPlayer.Username Then
                    realSenderString = "[" & MakeFirstLetterUpperCased(request.Sender.Username) & "] "
                End If
            End If
        End If

        myClient.Chatter.Send(realSenderString &
                              String.Join(" ", msg))
    End Sub

    <Command("send", Group.Admin)>
    Public Sub SendCommand(request As CommandRequest, type As String, ParamArray parameters As String())
        myClient.Connection.Send(New CustomSendMessage(type, parameters))
    End Sub

    <Command("open", Group.Host)>
    Public Sub OpenCommand(request As CommandRequest)
        Process.Start(My.Application.Info.DirectoryPath & "\Plugins\")
    End Sub

    <Command("about", Group.Trusted)>
    Public Sub AboutCommand(request As CommandRequest, plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            request.Sender.Reply(String.Format("{0} {1} by {2}. Category: {3} - {4}",
                                    pluginObj.Name,
                                    pluginObj.Attribute.Version,
                                    String.Join(", ", pluginObj.Attribute.Authors),
                                    pluginObj.Attribute.Category,
                                    pluginObj.Attribute.Description))
        Else
            request.Sender.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("about", Group.Trusted)>
    Public Sub AboutCommand(request As CommandRequest)
        request.Sender.Reply(String.Format("This bot is run by {0} Version {1}", My.Application.Info.Title, My.Application.Info.Version))
    End Sub

    <Command("enable", Group.Operator)>
    Public Sub EnableCommand(request As CommandRequest, plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            If Not pluginObj.Started Then
                pluginObj.Restart()
                request.Sender.Reply("Started plugin.")
            Else
                request.Sender.Reply("Plugin already started, please disable it first!")
            End If
        Else
            request.Sender.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("disable", Group.Operator)>
    Public Sub DisableCommand(request As CommandRequest, plugin As String)
        Dim pluginObj As IPluginObject = myClient.PluginManager.Plugin(plugin)
        If pluginObj IsNot Nothing Then
            If pluginObj.Started Then
                pluginObj.Stop()
                request.Sender.Reply("Stopped plugin.")
            Else
                request.Sender.Reply("Plugin not started, please enable it first!")
            End If
        Else
            request.Sender.Reply("Unknown plugin.")
        End If
    End Sub

    <Command("ping", Group.Trusted)>
    Public Sub PingCommand(request As CommandRequest)
        request.Sender.Reply("Pong!")
    End Sub

    <Command("hello", Group.Moderator, aliases:={"hi", "hai"})>
    Public Sub HelloCommand(request As CommandRequest)
        request.Sender.Reply("Hello!")
    End Sub

    <Command("hello", Group.Moderator, aliases:={"hi", "hai"})>
    Public Sub HelloCommand(request As CommandRequest, username As String)
        myClient.Chatter.Chat(String.Format("Hello {0}!", GetPlayerNormalizedUsername(username)))
    End Sub

    <Command("goodbye", Group.Moderator, aliases:={"bye", "bai"})>
    Public Sub GoodbyeCommand(request As CommandRequest)
        request.Sender.Reply("Goodbye!")
    End Sub

    <Command("goodbye", Group.Moderator, aliases:={"bye", "bai"})>
    Public Sub GoodbyeCommand(request As CommandRequest, username As String)
        myClient.Chatter.Chat(String.Format("Goodbye {0}!", GetPlayerNormalizedUsername(username)))
    End Sub

    <Command("setcode", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"code", "editkey", "seteditkey"})>
    Public Sub SetCodeCommand(request As CommandRequest, editkey As String)
        myClient.Connection.Send(New ChangeWorldEditKeySendMessage(editkey))
        request.Sender.Reply("Changed edit key")
    End Sub

    <Command("kick", Group.Trusted, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(request As CommandRequest, username As String, ParamArray reason As String())
        Dim player As Player = GetPlayer(username)
        If player IsNot Nothing Then
            If request.Sender Is Nothing OrElse request.Rights >= Group.Operator OrElse player.Group <= request.Rights Then
                player.Kick(String.Join(" ", reason))

                request.Sender.Reply("Kicked.")
            Else
                request.Sender.Reply("Not allowed to kick a player with a higher rank than yourself.")
            End If
        Else
            request.Sender.Reply("Can't find player.")
        End If
    End Sub

    <Command("kick", Group.Trusted, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(request As CommandRequest, username As String)
        Dim player As Player = GetPlayer(username)
        If player IsNot Nothing Then
            If request.Sender Is Nothing OrElse request.Rights >= Group.Operator OrElse player.Group <= request.Rights Then
                player.Kick()

                request.Sender.Reply("Kicked.")
            Else
                request.Sender.Reply("Not allowed to kick a player with a higher rank than yourself.")
            End If
        Else
            request.Sender.Reply("Can't find player.")
        End If
    End Sub

    <Command("reloadplayer", Group.Moderator, Aliases:={"rplayer"})>
    Public Async Sub ReloadPlayerCommand(request As CommandRequest, username As String)
        username = GetPlayerNormalizedUsername(username)
        Dim player As IPlayer = GetPlayer(username, True)

        If player IsNot Nothing Then
            Await player.ReloadUserDataAsync()
            request.Sender.Reply(String.Format("Reloaded the UserData of {0}.", username))
        Else
            request.Sender.Reply("Unknown player.")
        End If
    End Sub

    <Command("env", Group.Moderator, Aliases:={"getenv", "iscloud"})>
    Public Sub GetEnvironmentCommand(request As CommandRequest)
        Dim env As String
        If Cloud.IsNoGUI Then
            env = "Cloud"
        Else
            env = "Desktop"
        End If
        request.Sender.Reply("Current environment: " & env)
    End Sub

    <Command("host", Group.Moderator, Aliases:={"gethost", "hoster"})>
    Public Sub HostCommand(request As CommandRequest)
        request.Sender.Reply("Current host: " & Cloud.LicenseUsername)
    End Sub

    <Command("restart", Group.Moderator)>
    Public Sub RestartCommand(request As CommandRequest)
        request.Sender.Reply("Restarting...")
        myClient.Connection.Close(True)
    End Sub

    <Command("end", Group.Moderator, Aliases:={"shutdown", "leave", "leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub EndCommand(request As CommandRequest)
        request.Sender.Reply("Terminating...")

        If myClient.Connection.Connected Then
            myClient.Connection.Close()
        Else
            Environment.Exit(0)
        End If
    End Sub

    <Command("killbot", Group.Operator)>
    Public Sub KillBotCommand(request As CommandRequest)
        request.Sender.Reply("Dying...")
        Environment.Exit(0)
    End Sub

    <Command("clear", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(request As CommandRequest)
        myClient.Connection.Send(New ClearWorldSendMessage())
        request.Sender.Reply("Cleared.")
    End Sub

    <Command("name", Group.Moderator, AccessRight:=AccessRight.Owner, Aliases:={"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(request As CommandRequest, ParamArray newName As String())
        myClient.Connection.Send(New ChangeWorldNameSendMessage(String.Join(" ", newName)))
        request.Sender.Reply("Renamed.")
    End Sub

    <Command("loadlevel", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(request As CommandRequest)
        request.Sender.Reply("Reloaded.")
        myClient.Chatter.Loadlevel()
    End Sub

    <Command("save", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(request As CommandRequest)
        myClient.Connection.Send(New SaveWorldSendMessage)
        request.Sender.Reply("Saved.")
    End Sub

    <Command("reset", Group.Operator, Aliases:={"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(request As CommandRequest)
        myClient.Chatter.Reset()
        request.Sender.Reply("Reset.")
    End Sub

    Private Sub myConnection_ReceiveInfo(sender As Object, e As InfoReceiveMessage) Handles myConnection.ReceiveInfo
        myConnection.UserExpectingDisconnect = True
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

    Private Sub myConnection_PreviewReceiveSay(sender As Object, e As SayReceiveMessage) Handles myConnection.PreviewReceiveSay
        Dim player As Player = myPlayerManager.Player(e.UserID)
        If player IsNot Nothing Then
            Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Text, player.Username))
        End If
    End Sub

    Private Sub myConnection_PreviewReceiveSayOld(sender As Object, e As SayOldReceiveMessage) Handles myConnection.PreviewReceiveSayOld
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Text, e.Username))
    End Sub

    Private Sub myConnection_PreviewReceiveWrite(sender As Object, e As WriteReceiveMessage) Handles myConnection.PreviewReceiveWrite
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Text, e.Title))
    End Sub

    Private Sub myConnection_SendSay(sender As Object, e As Cancelable(Of SaySendMessage)) Handles myConnection.SendSay
        Cloud.Logger.Log(LogPriority.Info, myClient.Chatter.SyntaxProvider.ApplyChatSyntax(e.Value.Text, myClient.Game.MyPlayer.Username))
    End Sub

    Private Function GetPlayer(username As String, Optional usernameAlreadyNormalized As Boolean = False) As Player
        If Not usernameAlreadyNormalized Then
            username = GetPlayerNormalizedUsername(username)
        End If

        Dim user As Player = Nothing

        For Each p In myPlayerManager
            If p.Username = username Then
                Return p
            ElseIf p.Username.StartsWith(username, StringComparison.Ordinal) Then
                If user Is Nothing Then
                    user = p
                Else
                    Return Nothing
                End If
            End If
        Next

        Return user
    End Function

    Private Shared Function GetPlayerNormalizedUsername(username As String) As String
        Return username.Replace("."c, String.Empty)
    End Function

#End Region
End Class
