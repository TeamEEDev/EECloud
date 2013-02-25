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

    Private myCursePotionCount As Integer

    Public ReadOnly Property CursePotionCount As Integer Implements IPotionManager.CursePotionCount
        Get
            Return myCursePotionCount
        End Get
    End Property

    Private myFirePotionCount As Integer

    Public ReadOnly Property FirePotionCount As Integer Implements IPotionManager.FirePotionCount
        Get
            Return myFirePotionCount
        End Get
    End Property

    Private myProtectionPotionCount As Integer

    Public ReadOnly Property ProtectionPotionCount As Integer Implements IPotionManager.ProtectionPotionCount
        Get
            Return myProtectionPotionCount
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
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
                Case Potion.GreenAura
                    myGreenAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Jump
                    myJumpPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Curse
                    myCursePotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Fire
                    myFirePotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.Protection
                    myProtectionPotionCount = e.PlayerIOMessage.GetInteger(pointer)
            End Select
            pointer = CUInt(pointer - 2)
        Loop
    End Sub

#End Region
End Class
