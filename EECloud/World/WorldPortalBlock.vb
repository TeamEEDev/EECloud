Public NotInheritable Class WorldPortalBlock
    Inherits WorldBlock
    Implements IWorldPortalBlock

    Friend Sub New(block As PortalBlockType, portalRotation As PortalRotation, portalID As Integer, portalTarget As Integer)
        MyBase.New(CType(block, BlockType))

        myPortalRotation = portalRotation
        myPortalID = portalID
        myPortalTarget = portalTarget
    End Sub

    Private ReadOnly myPortalRotation As PortalRotation

    Public ReadOnly Property PortalRotation As PortalRotation Implements IWorldPortalBlock.PortalRotation
        Get
            Return myPortalRotation
        End Get
    End Property

    Private ReadOnly myPortalID As Integer

    Public ReadOnly Property PortalID As Integer Implements IWorldPortalBlock.PortalID
        Get
            Return myPortalID
        End Get
    End Property

    Private ReadOnly myPortalTarget As Integer

    Public ReadOnly Property PortalTarget As Integer Implements IWorldPortalBlock.PortalTarget
        Get
            Return myPortalTarget
        End Get
    End Property
End Class
