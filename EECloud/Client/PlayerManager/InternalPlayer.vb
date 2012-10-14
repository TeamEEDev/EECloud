Imports System.Threading.Tasks

Friend NotInheritable Class InternalPlayer
    Implements IPlayer

#Region "Fields"
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As IClient(Of Player)
#End Region

#Region "Events"
    Public Event AutoText(sender As Object, e As AutoText) Implements IPlayer.AutoText

    Public Event Chat(sender As Object, e As String) Implements IPlayer.Chat

    Public Event Coin(sender As Object, e As ItemChangedEventArgs(Of Integer)) Implements IPlayer.Coin

    Public Event GodMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Implements IPlayer.GodMode

    Public Event Leave(sender As Object, e As EventArgs) Implements IPlayer.Leave

    Public Event ModMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Implements IPlayer.ModMode

    Public Event Move(sender As Object, e As MoveReceiveMessage) Implements IPlayer.Move

    Public Event SilverCrown(sender As Object, e As EventArgs) Implements IPlayer.SilverCrown

    Public Event SmileyChange(sender As Object, e As ItemChangedEventArgs(Of Smiley)) Implements IPlayer.SmileyChange

    Public Event UsePotion(sender As Object, e As Potion) Implements IPlayer.UsePotion

    Public Event DeactivatePotion(sender As Object, e As Potion) Implements IPlayer.DeactivatePotion

    Public Event GroupChange(sender As Object, e As ItemChangedEventArgs(Of Group)) Implements IPlayer.GroupChange

    Public Event YoScrollWinsChange(sender As Object, e As ItemChangedEventArgs(Of UInteger)) Implements IPlayer.YoScrollWinsChange
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

    Private mySmiley As Smiley

    Friend ReadOnly Property Smiley As Smiley Implements IPlayer.Smiley
        Get
            Return mySmiley
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
                Return myClient.PlayerManager.Crown.UserID = myUserID
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
            RaiseEvent GroupChange(Me, New ItemChangedEventArgs(Of Group)(myGroup, value))
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
            RaiseEvent YoScrollWinsChange(Me, New ItemChangedEventArgs(Of UInteger)(myYoScrollWins, value))
            myYoScrollWins = value
            Cloud.Service.SetPlayerDataYoScrollWinsAsync(Username, value)
        End Set
    End Property

    Private myBlueAuraPotion As Boolean

    Public ReadOnly Property BlueAuraPotion As Boolean Implements IPlayer.BlueAuraPotion
        Get
            Return myBlueAuraPotion
        End Get
    End Property

    Private myRedAuraPotion As Boolean

    Public ReadOnly Property RedAuraPotion As Boolean Implements IPlayer.RedAuraPotion
        Get
            Return myRedAuraPotion
        End Get
    End Property

    Private myYellowAuraPotion As Boolean

    Public ReadOnly Property YellowAuraPotion As Boolean Implements IPlayer.YellowAuraPotion
        Get
            Return myYellowAuraPotion
        End Get
    End Property

    Private mySpawnX As Integer

    Public ReadOnly Property SpawnX As Integer Implements IPlayer.SpawnX
        Get
            Return mySpawnX
        End Get
    End Property

    Private mySpawnY As Integer

    Public ReadOnly Property SpawnY As Integer Implements IPlayer.SpawnY
        Get
            Return mySpawnY
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player), addMessage As AddReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = addMessage.UserID
        myUsername = addMessage.Username
        mySmiley = addMessage.Face
        myHasChat = addMessage.HasChat
        myIsGod = addMessage.IsGod
        myIsMod = addMessage.IsMod
        myIsMyFriend = addMessage.IsMyFriend
        myCoins = addMessage.Coins
        myPlayerPosX = addMessage.PlayerPosX
        myPlayerPosY = addMessage.PlayerPosY
        mySpawnX = addMessage.PlayerPosX
        mySpawnY = addMessage.PlayerPosY
    End Sub

    Friend Sub New(client As IClient(Of Player), initMessage As InitReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = initMessage.UserID
        myUsername = initMessage.Username
        myPlayerPosX = initMessage.SpawnX
        myPlayerPosY = initMessage.SpawnY
        mySpawnX = initMessage.SpawnX
        mySpawnY = initMessage.SpawnY
    End Sub

    Friend Async Function ReloadUserDataAsync() As Threading.Tasks.Task Implements IPlayer.ReloadUserDataAsync
        Dim userData As EEService.UserData = Await Cloud.Service.GetPlayerDataAsync(myUsername)
        If userData IsNot Nothing Then
            myGroup = CType(userData.GroupID, Group)
            myYoScrollWins = userData.YoScrollWins
        End If
    End Function

    Public Sub Reply(msg As String) Implements IPlayer.Reply
        myClient.Chatter.Reply(myUsername, msg)
    End Sub

    Private Sub myConnection_ReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Handles myConnection.ReceiveAutoText
        RaiseEvent AutoText(Me, CType([Enum].Parse(GetType(AutoText), e.Text), AutoText))
    End Sub

    Private Sub myConnection_OnReceiveCoin(sender As Object, e As CoinReceiveMessage) Handles myConnection.ReceiveCoin
        If e.UserID = myUserID Then
            RaiseEvent Coin(Me, New ItemChangedEventArgs(Of Integer)(myCoins, e.Coins))
            myCoins = e.Coins
        End If
    End Sub

    Private Sub myConnection_OnReceiveFace(sender As Object, e As FaceReceiveMessage) Handles myConnection.ReceiveFace
        If e.UserID = myUserID Then
            RaiseEvent SmileyChange(Me, New ItemChangedEventArgs(Of Smiley)(mySmiley, e.Face))
            mySmiley = e.Face
        End If
    End Sub

    Private Sub myConnection_OnReceiveMove(sender As Object, e As MoveReceiveMessage) Handles myConnection.ReceiveMove
        If e.UserID = myUserID Then
            RaiseEvent Move(Me, e)
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

    Private Sub myConnection_OnReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Handles myConnection.ReceiveGodMode
        If e.UserID = myUserID Then
            RaiseEvent GodMode(Me, New ItemChangedEventArgs(Of Boolean)(myIsGod, e.IsGod))
            myIsGod = e.IsGod
        End If
    End Sub

    Private Sub myConnection_OnReceiveModMode(sender As Object, e As ModModeReceiveMessage) Handles myConnection.ReceiveModMode
        If e.UserID = myUserID Then
            RaiseEvent ModMode(Me, New ItemChangedEventArgs(Of Boolean)(myIsMod, True))
            myIsMod = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Handles myConnection.ReceiveSilverCrown
        If e.UserID = myUserID Then
            RaiseEvent SilverCrown(Me, New ItemChangedEventArgs(Of Boolean)(myHasSilverCrown, True))
            myHasSilverCrown = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.ReceiveTeleport
        If e.ResetCoins = True Then
            myCoins = 0
        End If
        Try
            Dim loc As Location = e.Coordinates(myUserID)
            myPlayerPosX = loc.X
            myPlayerPosY = loc.Y
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private Sub myConnection_ReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.ReceiveLeft
        RaiseEvent Leave(Me, EventArgs.Empty)
        myConnection = Nothing
    End Sub

    Private Sub myConnection_ReceivePotion(sender As Object, e As PotionReceiveMessage) Handles myConnection.ReceivePotion
        If e.UserID = myUserID Then
            If e.Enabled Then
                RaiseEvent UsePotion(Me, e.Potion)
            Else
                RaiseEvent DeactivatePotion(Me, e.Potion)
            End If

            Select Case e.Potion
                Case Potion.RedAura
                    myRedAuraPotion = e.Enabled
                Case Potion.BlueAura
                    myBlueAuraPotion = e.Enabled
                Case Potion.YellowAura
                    myYellowAuraPotion = e.Enabled
            End Select
        End If
    End Sub

    Private Sub myConnection_ReceiveSay(sender As Object, e As SayReceiveMessage) Handles myConnection.ReceiveSay
        If e.UserID = myUserID Then
            RaiseEvent Chat(Me, e.Text)
        End If
    End Sub

    Public Sub Kick(msg As String) Implements IPlayer.Kick
        myClient.Chatter.Kick(myUsername, msg)
    End Sub

#End Region

End Class
