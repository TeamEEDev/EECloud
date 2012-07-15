Public Class OnMessageEventArgs
    Inherits EventArgs
    Public Type As MessageType
    Public Message As Recive.ReciveMessage

    Public Sub New(PType As MessageType, PMessage As Recive.ReciveMessage)
        Type = PType
        Message = PMessage
    End Sub
End Class