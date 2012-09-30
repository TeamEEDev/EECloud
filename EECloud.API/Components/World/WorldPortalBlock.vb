Public NotInheritable Class WorldPortalBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, block As PortalBlockType, portalRotation As PortalRotation, portalID As Integer, portalTarget As Integer)
        MyBase.New(layer, CType(block, BlockType))

        myPortalRotation = portalRotation
        myPortalID = portalID
        myPortalTarget = portalTarget
    End Sub

    Private ReadOnly myPortalRotation As PortalRotation

    Public ReadOnly Property PortalRotation As PortalRotation
        Get
            Return myPortalRotation
        End Get
    End Property

    Private ReadOnly myPortalID As Integer

    Public ReadOnly Property PortalID As Integer
        Get
            Return myPortalID
        End Get
    End Property

    Private ReadOnly myPortalTarget As Integer

    Public ReadOnly Property PortalTarget As Integer
        Get
            Return myPortalTarget
        End Get
    End Property
End Class
