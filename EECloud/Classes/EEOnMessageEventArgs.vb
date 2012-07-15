Friend Class EEOnMessageEventArgs
    Inherits OnMessageEventArgs
    Private m_Type As MessageType
    Public Overrides ReadOnly Property Type As MessageType
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

    Public Sub New(PType As MessageType, PMessage As Recive.ReciveMessage)
        m_Type = PType
        m_Message = PMessage
    End Sub
End Class