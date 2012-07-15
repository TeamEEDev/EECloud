Public MustInherit Class OnMessageEventArgs
    Inherits EventArgs
    Public MustOverride ReadOnly Property Type As MessageType
    Public MustOverride ReadOnly Property Message As Recive.ReciveMessage
End Class