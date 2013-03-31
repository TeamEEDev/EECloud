Friend NotInheritable Class Game
    Implements IGame

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
#End Region

#Region "Properties"
    Private myEncryption As String

    Friend ReadOnly Property Encryption As String Implements IGame.Encryption
        Get
            Return myEncryption
        End Get
    End Property

    Private myMyPlayer As Player

    Friend ReadOnly Property MyPlayer As Player Implements IGame.MyPlayer
        Get
            Return myMyPlayer
        End Get
    End Property

    Private myOwner As String

    Friend ReadOnly Property Owner As String Implements IGame.Owner
        Get
            Return myOwner
        End Get
    End Property

    Private myPlays As Integer

    Friend ReadOnly Property Plays As Integer Implements IGame.Plays
        Get
            Return myPlays
        End Get
    End Property

    Private myAccessRight As AccessRight

    Friend ReadOnly Property AccessRight As AccessRight Implements IGame.AccessRight
        Get
            Return myAccessRight
        End Get
    End Property

    Private myWorldName As String

    Friend ReadOnly Property WorldName As String Implements IGame.WorldName
        Get
            Return myWorldName
        End Get
    End Property

    Private myAllowPotions As Boolean

    Friend ReadOnly Property AllowPotions As Boolean Implements IGame.AllowPotions
        Get
            Return myAllowPotions
        End Get
    End Property

    Private myGravityMultiplier As Double

    Friend ReadOnly Property GravityMultiplier As Double Implements IGame.GravityMultiplier
        Get
            Return myGravityMultiplier
        End Get
    End Property

    Private myIsTutorialRoom As Boolean

    Friend ReadOnly Property IsTutorialRoom As Boolean Implements IGame.IsTutorialRoom
        Get
            Return myIsTutorialRoom
        End Get
    End Property

    Private myCurrentWoots As Integer

    Public ReadOnly Property CurrentWoots As Integer Implements IGame.CurrentWoots
        Get
            Return myCurrentWoots
        End Get
    End Property

    Private myTotalWoots As Integer

    Public ReadOnly Property TotalWoots As Integer Implements IGame.TotalWoots
        Get
            Return myTotalWoots
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = myClient.Connection
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        myMyPlayer = New Player()
        myMyPlayer.SetupPlayer(New InternalPlayer(myClient, e), myClient.Chatter)
        myOwner = e.UsernameOwner
        myWorldName = e.WorldName
        myPlays = e.Plays
        myEncryption = Derot(e.Encryption)
        myIsTutorialRoom = e.IsTutorialRoom
        myGravityMultiplier = e.Gravity
        myAllowPotions = e.AllowPotions
        myCurrentWoots = e.CurrentWoots
        myTotalWoots = e.TotalWoots

        If e.IsOwner Then
            myAccessRight = AccessRight.Owner
        ElseIf e.CanEdit Then
            myAccessRight = AccessRight.Edit
        End If
    End Sub

    Private Sub myConnection_OnReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Handles myConnection.ReceiveLostAccess
        myAccessRight = AccessRight.None
    End Sub

    Private Sub myConnection_OnReceiveAccess(sender As Object, e As AccessReceiveMessage) Handles myConnection.ReceiveAccess
        myAccessRight = AccessRight.Edit
    End Sub

    Private Sub myConnection_ReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Handles myConnection.ReceiveUpdateMeta
        myWorldName = e.WorldName
        myPlays = e.Plays
        myOwner = e.Owner
        myCurrentWoots = e.CurrentWoots
        myTotalWoots = e.TotalWoots
    End Sub

    Friend Shared Function Derot(input As String) As String
        ' 'L' stands for Lower case
        ' 'U' stands for Upper case

        Const ascLa = Asc("a"c)
        Const ascLm = Asc("m"c)
        Const ascLz = Asc("z"c)

        Const ascUa = Asc("A"c)
        Const ascUm = Asc("M"c)
        Const ascUz = Asc("Z"c)

        Dim array() As Char = input.ToCharArray()

        Dim charNum As Integer
        For i = 0 To input.Length - 1
            charNum = Asc(array(i))

            If charNum >= ascLa AndAlso charNum <= ascLz Then
                If charNum > ascLm Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            ElseIf charNum >= ascUa AndAlso charNum <= ascUz Then
                If charNum > ascUm Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            End If

            array(i) = Chr(charNum)
        Next

        Return New String(array)
    End Function

#End Region
End Class
