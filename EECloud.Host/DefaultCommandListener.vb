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
    Public Sub DoUploaderTestCommand(cmd As ICommand(Of Player))
        For i = 0 To myClient.World.SizeX - 1
            For j = 0 To myClient.World.SizeY - 1
                myClient.Uploader.Upload(New BlockPlaceUploadMessage(Layer.Foreground, i, j, Block.BlockBasicLightBlue))
            Next
        Next
    End Sub
#End If

    <Command("getrank", Group.Moderator, Aliases:={"rank", "group", "getgroup", "userrank", "usergroup", "playerrank", "playergroup"})>
    Public Sub GetRankCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As IPlayer = GetPlayer(player)
        Dim rank As Group
        If player1 IsNot Nothing Then
            rank = player1.Group
        Else
            rank = Cloud.Service.GetPlayerData(player).Username
        End If
        cmd.Reply(String.Format("User {0} is {1}", player.ToUpper(InvariantCulture), GetGroupString(rank)))
    End Sub

    Private pinging As Boolean

    <Command("pinghost", Group.Moderator)>
    Public Sub PingHostCommand(cmd As ICommand(Of Player))
        If cmd.Sender IsNot Nothing Then
            If Not pinging Then
                pinging = True
                Call New Thread(Sub(obj As Object)
                                    Beep()
                                    MessageBox.Show("Ping from user: " & cmd.Sender.Username,
                                                    "Ping received",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information)

                                    pinging = False
                                End Sub).Start()
            Else
                cmd.Reply("A ping has been already sent.")
            End If
        Else
            cmd.Reply("Cannot ping from console.")
        End If
    End Sub

    <Command("respawnall", Group.Moderator)>
    Public Sub RespawnAllCommand(cmd As ICommand(Of Player))
        myClient.Chatter.RespawnAll()
    End Sub

    <Command("killemall", Group.Moderator)>
    Public Sub KillEmAllCommand(cmd As ICommand(Of Player))
        myClient.Chatter.KillAll()
    End Sub

    <Command("kill", Group.Moderator)>
    Public Sub KillCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As IPlayer = GetPlayer(player)
        If player1 IsNot Nothing Then
            player1.Kill()
            cmd.Reply("Killed.")
        Else
            cmd.Reply("Unknown player.")
        End If
    End Sub

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
        ChangeRank(cmd, username, Group.Admin)
    End Sub

    <Command("op", Group.Admin)>
    Public Sub OpCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Operator)
    End Sub

    <Command("mod", Group.Operator)>
    Public Sub ModCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Moderator)
    End Sub

    <Command("trust", Group.Operator)>
    Public Sub TrustCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Trusted)
    End Sub

    <Command("default", Group.Operator, Aliases:={"normal", "user"})>
    Public Sub NormalCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.User)
    End Sub

    <Command("limit", Group.Operator)>
    Public Sub LimitCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Limited)
    End Sub

    <Command("ban", Group.Operator)>
    Public Sub BanCommand(cmd As ICommand(Of Player), username As String)
        ChangeRank(cmd, username, Group.Banned)
    End Sub

    Private Sub ChangeRank(cmd As ICommand(Of Player), username As String, rank As Group)
        Dim currRank As Group
        Dim player As Player = GetPlayer(username)
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

            cmd.Reply(String.Format("{0} is now {1}.", username.ToUpper(InvariantCulture), GetGroupString(rank)))
        Else
            cmd.Reply(String.Format("Not allowed to change rank of that player."))
        End If
    End Sub

    Private Shared Function GetGroupString(rank As Group) As String
        Select Case rank
            Case Group.Host
                Return "the host"
            Case Group.Admin
                Return "an admin"
            Case Group.Operator
                Return "an operator"
            Case Group.Moderator
                Return "a moderator"
            Case Group.Trusted
                Return "a trusted player"
            Case Group.User
                Return "a normal player"
            Case Group.Limited
                Return "limited"
            Case Group.Banned
                Return "banned"
            Case Else
                Return "a player with an unknown rank"
        End Select
    End Function

    <Command("who", Group.Host)>
    Public Sub WhoCommand(cmd As ICommand(Of Player))
        Dim playerList As String() = (From player In myClient.PlayerManager Select player.Username).ToArray()
        If playerList.Count > 0 Then
            cmd.Reply(String.Format("({0} players online) {1}", playerList.Count, String.Join(", ", playerList)))
        Else
            cmd.Reply("No one is currently online.")
        End If
    End Sub

    <Command("say", Group.Moderator)>
    Public Sub SayCommand(cmd As ICommand(Of Player), ParamArray msg As String())
        Dim realSenderString As String = String.Empty

        If cmd.Sender Is Nothing Then
            'TODO: Check if Cloud.LicenseUsername is the same as the currently used EE account's name. If it isn't, then modify realSenderString.
            realSenderString = "<" & Cloud.LicenseUsername & "> "
        Else
            'TODO: Check if cmd.Sender.Username is the same as the currently used EE account's name. If it isn't, then modify realSenderString.
            realSenderString = "<" & StrConv(cmd.Sender.Username, VbStrConv.ProperCase) & "> "
        End If

        myClient.Chatter.Send(realSenderString &
                              String.Join(" ", msg))
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

    <Command("hello", Group.Moderator, aliases:={"hi", "hai"})>
    Public Sub HelloCommand(cmd As ICommand(Of Player))
        cmd.Reply("Hello!")
    End Sub

    <Command("hello", Group.Moderator, aliases:={"hi", "hai"})>
    Public Sub HelloCommand(cmd As ICommand(Of Player), player As String)
        myClient.Chatter.Chat(String.Format("Hello {0}!", player))
    End Sub

    <Command("goodbye", Group.Moderator, aliases:={"bye", "bai"})>
    Public Sub GoodbyeCommand(cmd As ICommand(Of Player))
        cmd.Reply("Goodbye!")
    End Sub

    <Command("goodbye", Group.Moderator, aliases:={"bye", "bai"})>
    Public Sub GoodbyeCommand(cmd As ICommand(Of Player), player As String)
        myClient.Chatter.Chat(String.Format("Goodbye {0}!", player))
    End Sub

    <Command("setcode", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"code", "editkey", "seteditkey"})>
    Public Sub SetCodeCommand(cmd As ICommand(Of Player), editkey As String)
        myClient.Connection.Send(New ChangeWorldEditKeySendMessage(editkey))
        cmd.Reply("Changed edit key")
    End Sub

    <Command("kick", Group.Trusted, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(cmd As ICommand(Of Player), player As String, ParamArray reason As String())
        Dim player1 As Player = GetPlayer(player)
        If player1 IsNot Nothing Then
            If cmd.Sender Is Nothing OrElse cmd.Sender.Group >= Group.Operator OrElse player1.Group <= cmd.Sender.Group Then
                player1.Kick(String.Join(" ", reason))

                cmd.Reply("Kicked.")
            Else
                cmd.Reply(String.Format("Not allowed to kick a player with a higher rank that yourself."))
            End If
        Else
            cmd.Reply("Can not find player.")
        End If
    End Sub

    <Command("kick", Group.Trusted, AccessRight:=AccessRight.Owner, Aliases:={"ki", "kickp", "kickplayer"})>
    Public Sub KickCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As Player = GetPlayer(player)
        If player1 IsNot Nothing Then
            If cmd.Sender Is Nothing OrElse cmd.Sender.Group >= Group.Operator OrElse player1.Group <= cmd.Sender.Group Then
                player1.Kick()

                cmd.Reply("Kicked.")
            Else
                cmd.Reply(String.Format("Not allowed to kick a player with a higher rank that yourself."))
            End If
        Else
            cmd.Reply("Can not find player.")
        End If
    End Sub

    <Command("reloadplayer", Group.Moderator, Aliases:={"rplayer"})>
    Public Async Sub ReloadPlayerCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As IPlayer = GetPlayer(player)
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

    <Command("restart", Group.Moderator)>
    Public Sub RestartCommand(cmd As ICommand(Of Player))
        cmd.Reply("Restarting...")
        myClient.Connection.Close(True)
    End Sub

    <Command("end", Group.Moderator, Aliases:={"shutdown", "leave", "leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub EndCommand(cmd As ICommand(Of Player))
        cmd.Reply("Terminating...")
        myClient.Connection.Close()
    End Sub

    <Command("killbot", Group.Operator)>
    Public Sub KillBotCommand(cmd As ICommand(Of Player))
        cmd.Reply("Dying...")
        Environment.Exit(0)
    End Sub

    <Command("clear", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand(Of Player))
        myClient.Connection.Send(New ClearWorldSendMessage())
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

    Private Function GetPlayer(username As String) As Player
        Dim name As String = username.Replace("."c, Nothing)
        Dim user As Player = Nothing

        For Each p In myPlayerManager
            If p.Username = name Then
                Return p
            ElseIf p.Username.StartsWith(name) Then
                If user Is Nothing Then
                    user = p
                Else
                    Return Nothing
                End If
            End If
        Next

        Return user
    End Function

#End Region
End Class
