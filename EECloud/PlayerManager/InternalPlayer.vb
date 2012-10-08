Imports System.Threading.Tasks

Friend NotInheritable Class InternalPlayer
    Implements IPlayer

#Region "Fields"
    Private WithEvents myConnection As InternalConnection
#End Region

#Region "Properties"
    Private myCoins As Integer

    Friend ReadOnly Property Coins As Integer Implements IPlayer.Coins
        Get
            Return myCoins
        End Get
    End Property

    Private myPlayerPosX As Integer

    Friend ReadOnly Property PlayerPosX As Integer Implements IPlayer.PlayerPosX
        Get
            Return myPlayerPosX
        End Get
    End Property

    Private myPlayerPosY As Integer

    Friend ReadOnly Property PlayerPosY As Integer Implements IPlayer.PlayerPosY
        Get
            Return myPlayerPosY
        End Get
    End Property

    Private ReadOnly myUserID As Integer

    Friend ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Return myUserID
        End Get
    End Property

    Private ReadOnly myUsername As String

    Friend ReadOnly Property Username As String Implements IPlayer.Username
        Get
            Return myUsername
        End Get
    End Property

    Private myFace As Smiley

    Friend ReadOnly Property Face As Smiley Implements IPlayer.Face
        Get
            Return myFace
        End Get
    End Property

    Private ReadOnly myHasChat As Boolean

    Friend ReadOnly Property HasChat As Boolean Implements IPlayer.HasChat
        Get
            Return myHasChat
        End Get
    End Property

    Private myHorizontal As Double

    Friend ReadOnly Property Horizontal As Double Implements IPlayer.Horizontal
        Get
            Return myHorizontal
        End Get
    End Property

    Private myIsGod As Boolean

    Friend ReadOnly Property IsGod As Boolean Implements IPlayer.IsGod
        Get
            Return myIsGod
        End Get
    End Property

    Private myIsMod As Boolean

    Friend ReadOnly Property IsMod As Boolean Implements IPlayer.IsMod
        Get
            Return myIsMod
        End Get
    End Property

    Private ReadOnly myIsMyFriend As Boolean

    Friend ReadOnly Property IsMyFriend As Boolean Implements IPlayer.IsMyFriend
        Get
            Return myIsMyFriend
        End Get
    End Property

    Private myModifierX As Double

    Friend ReadOnly Property ModifierX As Double Implements IPlayer.ModifierX
        Get
            Return myModifierX
        End Get
    End Property

    Private myModifierY As Double

    Friend ReadOnly Property ModifierY As Double Implements IPlayer.ModifierY
        Get
            Return myModifierY
        End Get
    End Property

    Private mySpeedX As Double

    Friend ReadOnly Property SpeedX As Double Implements IPlayer.SpeedX
        Get
            Return mySpeedX
        End Get
    End Property

    Private mySpeedY As Double

    Friend ReadOnly Property SpeedY As Double Implements IPlayer.SpeedY
        Get
            Return mySpeedY
        End Get
    End Property

    Private myVertical As Double

    Friend ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Return myVertical
        End Get
    End Property

    Private myHasSilverCrown As Boolean

    Friend ReadOnly Property HasSilverCrown As Boolean Implements IPlayer.HasSilverCrown
        Get
            Return myHasSilverCrown
        End Get
    End Property

    Friend ReadOnly Property HasCrown As Boolean Implements IPlayer.HasCrown
        Get
            Try
                Return myConnection.InternalPlayerManager.Crown.UserID = myUserID
            Catch
                Return False
            End Try
        End Get
    End Property

    Private myGroup As Group

    Public Property Group As Group Implements IPlayer.Group
        Get
            Return myGroup
        End Get

        Set(value As Group)
            myGroup = value
            Cloud.Service.SetPlayerDataGroupIDAsync(Username, CShort(value))
        End Set
    End Property

    Private myYoScrollWins As UInteger

    Public Property YoScrollWins As UInteger Implements IPlayer.YoScrollWins
        Get
            Return myYoScrollWins
        End Get

        Set(value As UInteger)
            myYoScrollWins = value
            Cloud.Service.SetPlayerDataYoScrollWinsAsync(Username, value)
        End Set
    End Property

#End Region

#Region "Methods"

    Friend Sub New(connection As InternalConnection, addMessage As AddReceiveMessage)
        myConnection = connection
        myUserID = addMessage.UserID
        myUsername = addMessage.Username
        myFace = addMessage.Face
        myHasChat = addMessage.HasChat
        myIsGod = addMessage.IsGod
        myIsMod = addMessage.IsMod
        myIsMyFriend = addMessage.IsMyFriend
        myCoins = addMessage.Coins
        myPlayerPosX = addMessage.PlayerPosX
        myPlayerPosY = addMessage.PlayerPosY
    End Sub

    Friend Async Function ReloadUserDataAsync() As Threading.Tasks.Task Implements IPlayer.ReloadUserDataAsync
        Dim userData As EEService.UserData = Await Cloud.Service.GetPlayerDataAsync(myUsername)
        Await task.Delay(10000)
        If userData IsNot Nothing Then
            myGroup = CType(userData.GroupID, Group)
            myYoScrollWins = userData.YoScrollWins
        End If
    End Function

    Public Sub Reply(msg As String) Implements IPlayer.Reply
        myConnection.Chatter.Reply(myUsername, msg)
    End Sub

    Private Sub myConnection_OnReceiveCoin(sender As Object, e As CoinReceiveMessage) Handles myConnection.OnReceiveCoin
        If e.UserID = myUserID Then
            myCoins = e.Coins
        End If
    End Sub

    Private Sub myConnection_OnReceiveFace(sender As Object, e As FaceReceiveMessage) Handles myConnection.OnReceiveFace
        If e.UserID = myUserID Then
            myFace = e.Face
        End If
    End Sub

    Private Sub myConnection_OnReceiveMove(sender As Object, e As MoveReceiveMessage) Handles myConnection.OnReceiveMove
        If e.UserID = myUserID Then
            myCoins = e.Coins
            myHorizontal = e.Horizontal
            myVertical = e.Vertical
            myModifierX = e.ModifierX
            myModifierY = e.ModifierY
            mySpeedX = e.SpeedX
            mySpeedY = e.SpeedY
            myPlayerPosX = e.PlayerPosX
            myPlayerPosY = e.PlayerPosY
        End If
    End Sub

    Private Sub myConnection_OnReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Handles myConnection.OnReceiveGodMode
        If e.UserID = myUserID Then
            myIsGod = e.IsGod
        End If
    End Sub

    Private Sub myConnection_OnReceiveModMode(sender As Object, e As ModModeReceiveMessage) Handles myConnection.OnReceiveModMode
        If e.UserID = myUserID Then
            myIsMod = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Handles myConnection.OnReceiveSilverCrown
        If e.UserID = myUserID Then
            myHasSilverCrown = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.OnReceiveTeleport
        If e.ResetCoins = True Then
            myCoins = 0
        End If

        Dim loc As Location = e.Coordinates(myUserID)
        myPlayerPosX = loc.X
        myPlayerPosY = loc.Y
    End Sub

    Public Sub Kick(msg As String) Implements IPlayer.Kick
        myConnection.Chatter.Kick(myUsername, msg)
    End Sub

#End Region
End Class
