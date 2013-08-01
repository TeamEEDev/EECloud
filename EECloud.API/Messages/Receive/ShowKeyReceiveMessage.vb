Imports PlayerIOClient

Public NotInheritable Class ShowKeyReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly Keys As Key()

    Friend Sub New(message As Message)
        MyBase.New(message)

        ReDim Keys(CInt(message.Count - 1))
        For i As UInteger = message.Count - 1UI To 0 Step -1
            Keys(CInt(i)) = DirectCast([Enum].Parse(GetType(Key), message.GetString(i), True), Key)
        Next
    End Sub
End Class
