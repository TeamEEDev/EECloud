Namespace World
    Public NotInheritable Class WorldPortalBlock
        Inherits Block
        Implements IWorldPortalBlock

#Region "Properties"

        Public Overrides ReadOnly Property BlockType As BlockType
            Get
                Return BlockType.Portal
            End Get
        End Property

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

#End Region

#Region "Methods"

        Public Sub New(block As PortalBlock, portalRotation As PortalRotation, portalID As Integer, portalTarget As Integer)
            MyBase.New(DirectCast(block, Block))
            myPortalRotation = portalRotation
            myPortalID = portalID
            myPortalTarget = portalTarget
        End Sub

#End Region
    End Class
End Namespace
