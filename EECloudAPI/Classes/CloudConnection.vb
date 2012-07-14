Public Class CloudConnection
#Region "Properties"
    Private m_Client As PlayerIOClient.Client
    Public ReadOnly Property Client As PlayerIOClient.Client
        Get
            Return m_Client
        End Get
    End Property

    Public Property WorldId As String
#End Region

    Sub New()

    End Sub
End Class
