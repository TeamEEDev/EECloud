Friend Class InternalPlayer
    Implements IPlayer

#Region "Fields"
    Private WithEvents myConnection As Connection(Of Player)
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

    Private myUserID As Integer
    Friend ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Return myUserID
        End Get
    End Property

    Private myUsername As String
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

    Private myHasChat As Boolean
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

    Private myIsMyFriend As Boolean
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
            Return mySpeedX
        End Get
    End Property

    Private myVertical As Double
    Friend ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Return myVertical
        End Get
    End Property

    Private myHasSilverCrown As Boolean
    Friend ReadOnly Property HasSilverCrown As Boolean
        Get
            Return myHasSilverCrown
        End Get
    End Property

    Friend ReadOnly Property HasCrown As Boolean
        Get
            Try
                Return myConnection.Crown.UserID = myUserID
            Catch
                Return False
            End Try
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(PConnection As Connection(Of Player), PAddMessage As Add_ReciveMessage)
        myConnection = PConnection
        myUserID = PAddMessage.UserID
        myUsername = PAddMessage.Username
        myFace = PAddMessage.Face
        myHasChat = PAddMessage.HasChat
        myIsGod = PAddMessage.IsGod
        myIsMod = PAddMessage.IsMod
        myIsMyFriend = PAddMessage.IsMyFriend
        myCoins = PAddMessage.Coins
        myPlayerPosX = PAddMessage.PlayerPosX
        myPlayerPosY = PAddMessage.PlayerPosY
    End Sub

    Private Sub myConnection_OnReciveCoin(sender As Object, e As Coin_ReciveMessage) Handles myConnection.OnReciveCoin
        If e.UserID = myUserID Then
            myCoins = e.Coins
        End If
    End Sub

    Private Sub myConnection_OnReciveFace(sender As Object, e As Face_ReciveMessage) Handles myConnection.OnReciveFace
        If e.UserID = myUserID Then
            myFace = e.Face
        End If
    End Sub

    Private Sub myConnection_OnReciveMove(sender As Object, e As Move_ReciveMessage) Handles myConnection.OnReciveMove
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

    Private Sub myConnection_OnReciveCrown(sender As Object, e As Crown_ReciveMessage) Handles myConnection.OnReciveCrown
        If e.UserID = myUserID Then

        End If
    End Sub

    Private Sub myConnection_OnReciveGodmode(sender As Object, e As Godmode_ReciveMessage) Handles myConnection.OnReciveGodmode
        If e.UserID = myUserID Then
            myIsGod = e.IsGod
        End If
    End Sub

    Private Sub myConnection_OnReciveModmode(sender As Object, e As Modmode_ReciveMessage) Handles myConnection.OnReciveModmode
        If e.UserID = myUserID Then
            myIsMod = True
        End If
    End Sub

    Private Sub myConnection_OnReciveSilverCrown(sender As Object, e As SilverCrown_ReciveMessage) Handles myConnection.OnReciveSilverCrown
        If e.UserID = myUserID Then

        End If
    End Sub

    Private Sub myConnection_OnReciveTeleport(sender As Object, e As Teleport_ReciveMessage) Handles myConnection.OnReciveTeleport
        If e.ResetCoins = True Then
            myCoins = 0
        End If
        'TODO: update coordinates
    End Sub
#End Region
End Class
