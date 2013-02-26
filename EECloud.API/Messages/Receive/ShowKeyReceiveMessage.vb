Imports PlayerIOClient

Public NotInheritable Class ShowKeyReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Keys As Key()
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        ReDim Keys(CInt(message.Count - 1))
        For i = 0 To message.Count - 1
            Keys(CInt(i)) = DirectCast([Enum].Parse(GetType(Key), message.GetString(CUInt(i)), True), Key)
        Next
    End Sub
End Class
