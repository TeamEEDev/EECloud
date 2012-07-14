Public Class OnMessageEventArgs
    Inherits EventArgs
    Public Type As MessageType
    Public Message As Messages.Message

    Public Sub New(PType As MessageType, PMessage As Messages.Message)
        Type = PType
        Message = PMessage
    End Sub
End Class