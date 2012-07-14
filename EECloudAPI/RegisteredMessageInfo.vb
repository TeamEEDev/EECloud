Public Class RegisteredMessageInfo
    Public ReadOnly Type As MessageType
    Public ReadOnly Message As Type

    Public Sub New(PType As MessageType, PMessage As Type)
        Type = PType
        Message = PMessage
    End Sub
End Class