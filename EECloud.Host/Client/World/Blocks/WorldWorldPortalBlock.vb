Public NotInheritable Class WorldWorldPortalBlock
    Inherits WorldBlock
    Implements IWorldWorldPortalBlock

#Region "Properties"

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return BlockType.WorldPortal
        End Get
    End Property

    Private ReadOnly myPortalTarget As String

    Public ReadOnly Property PortalTarget As String Implements IWorldWorldPortalBlock.PortalTarget
        Get
            Return myPortalTarget
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(block As API.WorldPortalBlock, portalTarget As String)
        MyBase.New(DirectCast(block, Block))
        myPortalTarget = portalTarget
    End Sub

#End Region

End Class
