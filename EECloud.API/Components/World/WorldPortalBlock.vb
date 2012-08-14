Public Class WorldPortalBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlockType, portalRotation As PortalRotation, portalID As Integer, portalTarget As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.myPortalRotation = portalRotation
        Me.myPortalID = portalID
        Me.myPortalTarget = portalTarget
    End Sub

    Private myPortalRotation As PortalRotation
    Public ReadOnly Property PortalRotation As PortalRotation
        Get
            Return myPortalRotation
        End Get
    End Property

    Private myPortalID As Integer
    Public ReadOnly Property PortalID As Integer
        Get
            Return myPortalID
        End Get
    End Property

    Private myPortalTarget As Integer
    Public ReadOnly Property PortalTarget As Integer
        Get
            Return myPortalTarget
        End Get
    End Property
End Class
