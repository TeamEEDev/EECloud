Public Module EECloud
    Private CloudConnections As New List(Of CloudConnection)
    Public ReadOnly Property ConnectionsCount As Integer
        Get
            Return CloudConnections.Count
        End Get
    End Property

    Private m_MainConnection As Integer = 0
    Public Property MainConnection As CloudConnection
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

    Public Sub AddConnection(PConnection As CloudConnection)
        If Not CloudConnections.Contains(PConnection) Then
            CloudConnections.Add(PConnection)
        Else
            Throw New ApplicationException("Connection has been already added.")
        End If
    End Sub

    Public Sub RemoveConnection(PConnection As CloudConnection)
        If CloudConnections.Contains(PConnection) Then
            CloudConnections.Remove(PConnection)
        Else
            Throw New ApplicationException("Unknown Connection")
        End If
    End Sub
End Module
