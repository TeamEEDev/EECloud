Public NotInheritable Class WorldPortalBlock
    Implements IWorldBlock

#Region "Properties"

    Public ReadOnly Property BlockType As BlockType Implements IWorldBlock.BlockType
        Get
            Return BlockType.Portal
        End Get
    End Property

    Private ReadOnly myBlock As Block

    Public ReadOnly Property Block As Block Implements IWorldBlock.Block
        Get
            Return myBlock
        End Get
    End Property

    Private ReadOnly myPortalRotation As PortalRotation

    Public ReadOnly Property PortalRotation As PortalRotation Implements IWorldBlock.PortalRotation
        Get
            Return myPortalRotation
        End Get
    End Property

    Private ReadOnly myPortalID As Integer

    Public ReadOnly Property PortalID As Integer Implements IWorldBlock.PortalID
        Get
            Return myPortalID
        End Get
    End Property

    Private ReadOnly myPortalTarget As Integer

    Public ReadOnly Property PortalTarget As Integer Implements IWorldBlock.PortalTarget
        Get
            Return myPortalTarget
        End Get
    End Property

    Public ReadOnly Property CoinsToCollect As Integer Implements IWorldBlock.CoinsToCollect
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property SoundID As Integer Implements IWorldBlock.SoundID
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IWorldBlock.Text
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(block As PortalBlock, portalRotation As PortalRotation, portalID As Integer, portalTarget As Integer)
        myBlock = CType(block, Block)
        myPortalRotation = portalRotation
        myPortalID = portalID
        myPortalTarget = portalTarget
    End Sub

#End Region
End Class
