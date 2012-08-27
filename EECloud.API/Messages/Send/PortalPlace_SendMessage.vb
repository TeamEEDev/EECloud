Public Class PortalPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly PortalID As Integer
    Public ReadOnly PortalTarget As Integer
    Public ReadOnly PortalRotation As PortalRotation
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlockType, portalID As Integer, portalTarget As Integer, portalRotation As PortalRotation)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.PortalID = portalID
        Me.PortalTarget = portalTarget
        Me.PortalRotation = portalRotation
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        If IsPortal(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(PortalRotation)
            myMessage.Add(PortalID)
            myMessage.Add(PortalTarget)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class
