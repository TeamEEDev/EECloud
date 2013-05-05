Friend Class PotionManager
    Implements IPotionManager

#Region "Fields"
    Private WithEvents myConnection As IConnection
#End Region

#Region "Properties"

    Private myRedAuraPotionCount As Integer

    Friend ReadOnly Property RedAuraPotionCount As Integer Implements IPotionManager.RedAuraPotionCount
        Get
            Return myRedAuraPotionCount
        End Get
    End Property

    Private myBlueAuraPotionCount As Integer

    Friend ReadOnly Property BlueAuraPotionCount As Integer Implements IPotionManager.BlueAuraPotionCount
        Get
            Return myBlueAuraPotionCount
        End Get
    End Property

    Private myYellowAuraPotionCount As Integer

    Friend ReadOnly Property YellowAuraPotionCount As Integer Implements IPotionManager.YellowAuraPotionCount
        Get
            Return myYellowAuraPotionCount
        End Get
    End Property

    Private myGreenAuraPotionCount As Integer

    Friend ReadOnly Property GreenAuraPotionCount As Integer Implements IPotionManager.GreenAuraPotionCount
        Get
            Return myGreenAuraPotionCount
        End Get
    End Property

    Private myJumpPotionCount As Integer

    Friend ReadOnly Property JumpPotionCount As Integer Implements IPotionManager.JumpPotionCount
        Get
            Return myJumpPotionCount
        End Get
    End Property

    Private myFirePotionCount As Integer

    Public ReadOnly Property FirePotionCount As Integer Implements IPotionManager.FirePotionCount
        Get
            Return myFirePotionCount
        End Get
    End Property

    Private myCursePotionCount As Integer

    Public ReadOnly Property CursePotionCount As Integer Implements IPotionManager.CursePotionCount
        Get
            Return myCursePotionCount
        End Get
    End Property

    Private myProtectionPotionCount As Integer

    Public ReadOnly Property ProtectionPotionCount As Integer Implements IPotionManager.ProtectionPotionCount
        Get
            Return myProtectionPotionCount
        End Get
    End Property

    Private myZombiePotionCount As Integer

    Public ReadOnly Property ZombiePotionCount As Integer Implements IPotionManager.ZombiePotionCount
        Get
            Return myZombiePotionCount
        End Get
    End Property

    Private myRespawnPotionCount As Integer

    Public ReadOnly Property RespawnPotionCount As Integer Implements IPotionManager.RespawnPotionCount
        Get
            Return myRespawnPotionCount
        End Get
    End Property

    Private myLevitationPotionCount As Integer

    Public ReadOnly Property LevitationPotionCount As Integer Implements IPotionManager.LevitationPotionCount
        Get
            Return myLevitationPotionCount
        End Get
    End Property

    Private myFlauntPotionCount As Integer

    Public ReadOnly Property FlauntPotionCount As Integer Implements IPotionManager.FlauntPotionCount
        Get
            Return myFlauntPotionCount
        End Get
    End Property

    Private mySolitudePotionCount As Integer

    Public ReadOnly Property SolitudePotionCount As Integer Implements IPotionManager.SolitudePotionCount
        Get
            Return mySolitudePotionCount
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        Dim startNum As UInteger
        For i = CInt(e.PlayerIOMessage.Count - 1) To 1 Step -1
            If TryCast(e.PlayerIOMessage.Item(i), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(i) = "pe" Then
                startNum = i - 1
            End If
        Next

        Dim pointer As UInteger = startNum
        Do
            If TryCast(e.PlayerIOMessage.Item(pointer), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(pointer) = "ps" Then
                Exit Do
            End If

            Select Case DirectCast(e.PlayerIOMessage.GetInteger(pointer - 1UI), Potion)
                Case Potion.RedAura
                    myRedAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.BlueAura
                    myBlueAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.YellowAura
                    myYellowAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.GreenAura
                    myGreenAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Jump
                    myJumpPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Fire
                    myFirePotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Curse
                    myCursePotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Protection
                    myProtectionPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Zombie
                    myZombiePotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Respawn
                    myRespawnPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Levitation
                    myLevitationPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Flaunt
                    myFlauntPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Solitude
                    mySolitudePotionCount = e.PlayerIOMessage.GetInteger(pointer)
            End Select
            pointer -= 2
        Loop
    End Sub

#End Region

End Class
