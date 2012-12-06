Imports System.IO

Friend NotInheritable Class DefaultCommandListner
#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)

#End Region

#Region "Methods"

    Sub New(ByVal client As IClient(Of Player))
        myClient = client
    End Sub

    <Command("who", Group.Host)>
    Public Sub WhoCommand(cmd As ICommand(Of Player))
        Dim playerList As List(Of String) = (From player In myClient.PlayerManager Select player.Username).ToList()
        If playerList.Count > 0 Then
            cmd.Reply(String.Join(", ", playerList))
        Else
            cmd.Reply("Noone is currently online.")
        End If
    End Sub

    <Command("say", Group.Host)>
    Public Sub SayCommand(cmd As ICommand(Of Player), ParamArray msg As String())
        myClient.Chatter.Chat(String.Join(" ", msg))
    End Sub

    <Command("send", Group.Host)>
    Public Sub SendCommand(cmd As ICommand(Of Player), type As String, ParamArray parameters As String())
        myClient.Connection.Send(New CustomSendMessage(type, parameters))
    End Sub

    <Command("open", Group.Host)>
    Public Sub OpenCommand(cmd As ICommand(Of Player))
        Process.Start(My.Application.Info.DirectoryPath & "\Plugins\")
    End Sub

    <Command("help", Group.Trusted)>
    Public Sub HelpCommand(cmd As ICommand(Of Player), command As String)
        cmd.Reply("Command does not exist!")
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
        Dim player As Player = myClient.PlayerManager.Player(user)
        If player IsNot Nothing Then
            player.Kick(String.Join(" ", reason))
            cmd.Reply("Kicked.")
        Else
            cmd.Reply("Can not find player.")
        End If
    End Sub

    <Command("reloadplayer", Group.Moderator, Aliases:={"rplayer"})>
    Public Sub ReloadPlayerCommand(cmd As ICommand(Of Player), player As String)
        Dim player1 As IPlayer = myClient.PlayerManager.Player(player)
        If player1 IsNot Nothing Then
            player1.ReloadUserData()
            cmd.Reply("Reloaded userdata.")
        Else
            cmd.Reply("Unknown player.")
        End If
    End Sub

    <Command("env", Group.Moderator, Aliases:={"getenv", "iscloud"})>
    Public Sub GetEnvironmentCommand(cmd As ICommand(Of Player))
        Dim env As String
        Select Case Cloud.IsNoGUI
            Case False
                env = "desktop"
            Case Else
                env = "cloud"
        End Select
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

#End Region
End Class