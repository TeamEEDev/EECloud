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

    Private myBlueAuraPotionCount As Integer

    Friend ReadOnly Property BlueAuraPotionCount As Integer Implements IGame.BlueAuraPotionCount
        Get
            Return myBlueAuraPotionCount
        End Get
    End Property

    Private myRedAuraPotionCount As Integer

    Friend ReadOnly Property RedAuraPotionCount As Integer Implements IGame.RedAuraPotionCount
        Get
            Return myRedAuraPotionCount
        End Get
    End Property

    Private myYellowAuraPotionCount As Integer

    Friend ReadOnly Property YellowAuraPotionCount As Integer Implements IGame.YellowAuraPotionCount
        Get
            Return myYellowAuraPotionCount
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

    Private myGravityMultiplayer As Double

    Friend ReadOnly Property GravityMultiplayer As Double Implements IGame.GravityMultiplayer
        Get
            Return myGravityMultiplayer
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
        myMyPlayer = New Player
        myMyPlayer.SetupPlayer(New InternalPlayer(myClient, e), myClient.Chatter)
        myOwner = e.UsernameOwner
        myWorldName = e.WorldName
        myPlays = e.Plays
        myEncryption = Derot(e.Encryption)
        myIsTutorialRoom = e.IsTutorialRoom
        myGravityMultiplayer = e.Gravity
        myAllowPotions = e.AllowPotions
        myCurrentWoots = e.CurrentWoots
        myTotalWoots = e.TotalWoots

        If e.IsOwner Then
            myAccessRight = AccessRight.Owner
        ElseIf e.CanEdit Then
            myAccessRight = AccessRight.Edit
        End If

        ParsePotion(e)
    End Sub

    Private Sub ParsePotion(e As InitReceiveMessage)
        Dim startNum As UInteger
        For i = CInt(e.PlayerIOMessage.Count - 1) To 0 Step -1
            If TryCast(e.PlayerIOMessage.Item(CUInt(i)), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(CUInt(i)) = "pe" Then
                startNum = CUInt(i - 1)
            End If
        Next
        Dim pointer As UInteger = startNum
        Do
            If TryCast(e.PlayerIOMessage.Item(pointer), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(pointer) = "ps" Then
                Exit Do
            End If
            Select Case CType(e.PlayerIOMessage.GetInteger(CUInt(pointer - 1)), Potion)
                Case Potion.BlueAura
                    myBlueAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.RedAura
                    myRedAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.YellowAura
                    myYellowAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
            End Select
            pointer = CUInt(pointer - 2)
        Loop
    End Sub

    Private Sub myConnection_OnReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Handles myConnection.ReceiveLostAccess
        myAccessRight = AccessRight.None
    End Sub

    Private Sub myConnection_OnReceiveAccess(sender As Object, e As AccessReceiveMessage) Handles myConnection.ReceiveAccess
        myAccessRight = AccessRight.Edit
    End Sub

    Private Sub myConnection_ReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Handles myConnection.ReceiveUpdateMeta
        If myWorldName <> e.WorldName Then
            myWorldName = e.WorldName
        End If

        If myPlays <> e.Plays Then
            myPlays = e.Plays
        End If

        If myOwner <> e.Owner Then
            myOwner = e.Owner
        End If
    End Sub

    Friend Shared Function Derot(str As String) As String
        Derot = String.Empty
        For N = 1 To str.Length
            Dim charNum As Integer = Asc(GetChar(str, N))
            If charNum >= Asc("a") And charNum <= Asc("z") Then
                If charNum > Asc("m") Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            ElseIf charNum >= Asc("A") And charNum <= Asc("Z") Then
                If charNum > Asc("M") Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            End If
            Derot &= Chr(charNum)
        Next
        Return Derot
    End Function

#End Region
End Class
