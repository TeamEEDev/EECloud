Imports PlayerIOClient

Public NotInheritable Class PortalPlaceUploadMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly PortalID As Integer
    Public ReadOnly PortalTarget As Integer
    Public ReadOnly PortalRotation As PortalRotation

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlock, portalID As Integer, portalTarget As Integer, portalRotation As PortalRotation)
        MyBase.New(layer, x, y, CType(block, Block))

        Me.PortalID = portalID
        Me.PortalTarget = portalTarget
        Me.PortalRotation = portalRotation
    End Sub

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        If IsPortal(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(PortalRotation)
            message.Add(PortalID)
            message.Add(PortalTarget)
            Return message
        Else
            Return MyBase.GetMessage(game)
        End If
    End Function
End Class
