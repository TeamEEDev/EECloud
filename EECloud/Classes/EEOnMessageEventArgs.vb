Friend Class EEOnMessageEventArgs
    Inherits OnMessageEventArgs
    Private m_Type As ReciveType
    Public Overrides ReadOnly Property Type As ReciveType
        Get
            Return m_Type
        End Get
    End Property

    Private m_Message As Recive.ReciveMessage
    Public Overrides ReadOnly Property Message As Recive.ReciveMessage
        Get
            Return m_Message
        End Get
    End Property

    Public Sub New(PType As ReciveType, PMessage As Recive.ReciveMessage)
        m_Type = PType
        m_Message = PMessage
    End Sub
End Class