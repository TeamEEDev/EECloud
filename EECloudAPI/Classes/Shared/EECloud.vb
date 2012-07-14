Public Class EECloud
    Private Shared CloudConnections As New List(Of CloudConnection)
    Public Shared ReadOnly Property ConnectionsCount As Integer
        Get
            Return CloudConnections.Count
        End Get
    End Property

    Public Shared ReadOnly Property Connection(Index As Integer) As CloudConnection
        Get
            Return CloudConnections.Item(Index)
        End Get
    End Property

    Private Shared m_MainConnection As Integer = 0
    Public Shared Property MainConnection As CloudConnection
        Get
            If CloudConnections.Count >= m_MainConnection + 1 Then
                Return CloudConnections(m_MainConnection)
            Else
                Return Nothing
            End If
        End Get
        Set(value As CloudConnection)
            If CloudConnections.Contains(value) Then
                m_MainConnection = CloudConnections.IndexOf(value)
            Else
                Throw New ApplicationException("Unknown Connection")
            End If
        End Set
    End Property

    Public Shared Sub AddConnection(PConnection As CloudConnection)
        If Not CloudConnections.Contains(PConnection) Then
            CloudConnections.Add(PConnection)
        Else
            Throw New ApplicationException("Connection has been already added.")
        End If
    End Sub

    Public Shared Sub RemoveConnection(PConnection As CloudConnection)
        If CloudConnections.Contains(PConnection) Then
            CloudConnections.Remove(PConnection)
        Else
            Throw New ApplicationException("Unknown Connection")
        End If
    End Sub
End Class
