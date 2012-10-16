<Plugin(Authors := {"Processor", "Jojatekok"},
        Category := PluginCategory.Tool,
        Description := "Commands Bot",
        Version := "1.0.0.0",
        ChatName := "Bot")>
Public NotInheritable Class CommandsBot
    Inherits Plugin(Of CommandsBotPlayer)

    Protected Overrides Sub OnEnable()
        Client.CommandManager.Load(Me)
    End Sub

    Protected Overrides Sub OnDisable()

    End Sub

    Protected Overrides Sub OnConnect()
    End Sub

    <Command("reloadplayer", Group.Operator, AccessRight:=AccessRight.Owner, Aliases:={"rplayer"})>
    Public Async Sub ReloadPlayerCommand(cmd As ICommand(Of CommandsBotPlayer), player As String)
        Dim player1 As IPlayer = Client.PlayerManager.Player(player)
        If player1 IsNot Nothing Then
            Await player1.ReloadUserDataAsync()
            cmd.Reply("Reloaded userdata.")
        Else
            cmd.Reply("Unknown player.")
        End If
    End Sub

    <Command("env", Group.Operator, AccessRight := AccessRight.Owner, Aliases := {"getenv", "iscloud"})>
    Public Sub GetEnvironmentCommand(cmd As ICommand(Of CommandsBotPlayer))
        Dim env As String
        Select Case Cloud.AppEnvironment
            Case AppEnvironment.Dev
                env = "desktop"
            Case AppEnvironment.Release
                env = "cloud"
            Case Else
                env = "other"
        End Select
        cmd.Reply("Current environment: " & env)
    End Sub

    <Command("end", Group.Operator, Aliases := {"shutdown", "killbot", "leave", "leaveworld", "leavelevel", "exit", "exitworld", "exitlevel"})>
    Public Sub EndCommand(cmd As ICommand(Of CommandsBotPlayer))
        cmd.Reply("Terminating...")
        Client.Connection.Close()
    End Sub

    <Command("clear", Group.Operator, AccessRight := AccessRight.Owner, Aliases := {"clearworld", "clearlevel"})>
    Public Sub ClearWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        Client.Connection.Send(New ClearWorldSendMessage)
        cmd.Reply("Cleared.")
    End Sub

    <Command("name", Group.Moderator, AccessRight := AccessRight.Owner, Aliases := {"rename", "renameworld", "renamelevel", "worldname", "levelname"})>
    Public Sub ChangeWorldNameCommand(cmd As ICommand(Of CommandsBotPlayer), ParamArray newName As String())
        Client.Game.WorldName = String.Join(" ", newName)
        cmd.Reply("Renamed.")
    End Sub

    <Command("loadlevel", Group.Operator, AccessRight := AccessRight.Owner, Aliases := {"load", "loadworld", "reload", "reloadworld", "reloadlevel"})>
    Public Sub LoadWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        cmd.Reply("Reloaded.")
        Client.Chatter.Loadlevel()
    End Sub

    <Command("save", Group.Operator, AccessRight := AccessRight.Owner, Aliases := {"saveworld", "savelevel"})>
    Public Sub SaveWorldCommand(cmd As ICommand(Of CommandsBotPlayer))
        Client.Connection.Send(New SaveWorldSendMessage)
        cmd.Reply("Saved.")
    End Sub

    <Command("reset", Group.Operator, Aliases := {"resetworld", "resetlevel", "resetplayers"})>
    Public Sub ResetCommand(cmd As ICommand(Of CommandsBotPlayer))
        Client.Chatter.Reset()
        cmd.Reply("Reset.")
    End Sub
End Class

Public NotInheritable Class CommandsBotPlayer
    Inherits Player
End Class
