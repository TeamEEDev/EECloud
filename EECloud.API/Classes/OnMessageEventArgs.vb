Public Class OnMessageEventArgs
    Inherits EventArgs
    Public ReadOnly Property Type As Type
        Get
            Return m_Message.GetType
        End Get
    End Property

    Private m_Message As ReciveMessage
    Public ReadOnly Property Message As ReciveMessage
        Get
            Return m_Message
        End Get
    End Property

    Public Sub New(PMessage As ReciveMessage)
        m_Message = PMessage
    End Sub
End Class
