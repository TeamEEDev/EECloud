Imports PlayerIOClient

Public NotInheritable Class WorldPortalPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage

    '2
    Public ReadOnly WorldPortalBlock As WorldPortalBlock
    '3
    Public ReadOnly WorldPortalTarget As String

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        WorldPortalBlock = DirectCast(message.GetInteger(2), WorldPortalBlock)
        WorldPortalTarget = message.GetString(3)
    End Sub
End Class
