Public Class CloudConnection
#Region "Properties"
    Private m_Client As PlayerIOClient.Client
    Public ReadOnly Property Client As PlayerIOClient.Client
        Get
            Return m_Client
        End Get
    End Property

    Private m_Connection As PlayerIOClient.Connection
    Public ReadOnly Property Connection As PlayerIOClient.Connection
        Get
            Return m_Connection
        End Get
    End Property

    Public Property Username As PlayerIOClient.Connection
    Private m_Password As String
    Public WriteOnly Property Password
        Set(value)
            m_Password = value
        End Set
    End Property

    Public Property WorldId As String
#End Region
End Class
