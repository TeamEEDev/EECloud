Imports PlayerIOClient

Public NotInheritable Class HideKeyReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly Keys As Key()

    Friend Sub New(message As Message)
        MyBase.New(message)

        ReDim Keys(CInt(message.Count - 1UI))
        For i As UInteger = 0 To message.Count - 1UI
            Keys(CInt(i)) = DirectCast([Enum].Parse(GetType(Key), message.GetString(i), True), Key)
        Next
    End Sub
End Class
