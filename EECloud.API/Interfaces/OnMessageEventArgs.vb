Public MustInherit Class OnMessageEventArgs
    Inherits EventArgs
    Public MustOverride ReadOnly Property Type As ReciveType
    Public MustOverride ReadOnly Property Message As Recive.ReciveMessage
End Class
