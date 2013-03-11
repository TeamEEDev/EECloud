Imports PlayerIOClient

Public NotInheritable Class WorldPortalPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public ReadOnly PortalBlock As PortalBlock
    '2
    Public ReadOnly PortalTarget As String
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        PortalBlock = DirectCast(message.GetInteger(2), PortalBlock)
        PortalTarget = message.GetString(3)
    End Sub
End Class
