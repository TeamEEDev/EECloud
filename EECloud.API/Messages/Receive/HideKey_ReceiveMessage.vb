Imports PlayerIOClient

Public Class HideKey_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly KeyColor As DoorID
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        KeyColor = CType([Enum].Parse(GetType(DoorID), message.GetString(0), True), DoorID)
    End Sub
End Class
