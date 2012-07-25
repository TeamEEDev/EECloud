Friend Class OnMessageEventArgs
    Inherits EventArgs
    Public ReadOnly Property Type As Type
        Get
            Return myMessage.GetType
        End Get
    End Property

    Private myMessage As ReciveMessage
    Public ReadOnly Property Message As ReciveMessage
        Get
            Return myMessage
        End Get
    End Property

    Public Sub New(PMessage As ReciveMessage)
        myMessage = PMessage
    End Sub
End Class
