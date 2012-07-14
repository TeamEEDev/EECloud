Public Class CloudClient
#Region "Consts"
    Private Const gameID As String = "everybody-edits-su9rn58o40itdbnw69plyw"
    Private Const gameVersion As String = "118"
    Public Const NormalRoom As String = "Everybodyedits" + gameVersion
    Public Const BetaRoom As String = "Beta" + gameVersion
    Public Const GuestServiceRoom As String = "LobbyGuest" + gameVersion
    Public Const ServiceRoom As String = "Lobby" + gameVersion
    Public Const AuthRoom As String = "Auth" + gameVersion
    Public Const BlacklistRoom As String = "QuickInviteHandler" + gameVersion
    Public Const TutorialRoom As String = "Tutorial" + gameVersion + "_world_"
    Public Const TrackingRoom As String = "Tracking" + gameVersion
#End Region

#Region "Properties"
    Private m_Client As PlayerIOClient.Client
    Public ReadOnly Property Client As PlayerIOClient.Client
        Get
            Return m_Client
        End Get
    End Property

    Public Property Username As PlayerIOClient.Connection
    Private m_Password As String
    Public WriteOnly Property Password As String
        Set(value As String)
            m_Password = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Sub Connect()

    End Sub
#End Region
End Class