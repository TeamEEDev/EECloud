Imports PlayerIOClient

Public Class PortalPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly PortalID As Integer
    Public ReadOnly PortalTarget As Integer
    Public ReadOnly PortalRotation As PortalRotation

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlockType, portalID As Integer, portalTarget As Integer, portalRotation As PortalRotation)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.PortalID = portalID
        Me.PortalTarget = portalTarget
        Me.PortalRotation = portalRotation
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        If IsPortal(Block) Then
            Dim message As Message = MyBase.GetMessage(world)
            message.Add(PortalRotation)
            message.Add(PortalID)
            message.Add(PortalTarget)
            Return message
        Else
            Return MyBase.GetMessage(world)
        End If
    End Function
End Class
