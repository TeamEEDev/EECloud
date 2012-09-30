Imports PlayerIOClient

Public Class PortalPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public ReadOnly PortalRotation As PortalRotation
    '3
    Public ReadOnly PortalID As Integer
    '4
    Public ReadOnly PortalTarget As Integer
    '5

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        PortalRotation = CType(message.GetInteger(3), PortalRotation)
        PortalID = message.GetInteger(4)
        PortalTarget = message.GetInteger(5)
    End Sub
End Class
