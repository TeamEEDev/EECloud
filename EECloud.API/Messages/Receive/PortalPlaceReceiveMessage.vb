Imports PlayerIOClient

Public NotInheritable Class PortalPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage

    '2
    Public ReadOnly PortalBlock As PortalBlock
    '3
    Public ReadOnly PortalRotation As PortalRotation
    '4
    Public ReadOnly PortalID As Integer
    '5
    Public ReadOnly PortalTarget As Integer

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        PortalBlock = DirectCast(message.GetInteger(2), PortalBlock)
        PortalRotation = DirectCast(message.GetInteger(3), PortalRotation)
        PortalID = message.GetInteger(4)
        PortalTarget = message.GetInteger(5)
    End Sub
End Class
