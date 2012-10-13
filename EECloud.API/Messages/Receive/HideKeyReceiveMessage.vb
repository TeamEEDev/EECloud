Imports PlayerIOClient

Public NotInheritable Class HideKeyReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Key As Key
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        Key = CType([Enum].Parse(GetType(Key), message.GetString(0), True), Key)
    End Sub
End Class
