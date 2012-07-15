Friend Class RegisteredMessageInfo
    Private m_Type As ReciveType
    Private m_Message As Type
    Public ReadOnly Property Type
        Get
            Return m_Type
        End Get
    End Property
    Public ReadOnly Property Message
        Get
            Return m_Message
        End Get
    End Property

    Public Sub New(PType As ReciveType, PMessage As Type)
        m_Type = PType
        m_Message = PMessage
    End Sub
End Class