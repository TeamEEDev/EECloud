Public Class EECloudManager
    Inherits CloudManager
    Private CloudConnectionsList As New List(Of CloudConnection)
    Public Overrides ReadOnly Property Count As Integer
        Get
            Return CloudConnectionsList.Count
        End Get
    End Property

    Default Public Overrides ReadOnly Property Item(Index As Integer) As CloudConnection
        Get
            Return CloudConnectionsList.Item(Index)
        End Get
    End Property

    Public Overrides Sub Add(PConnection As CloudConnection)
        If Not CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Add(PConnection)
        Else
            Throw New ApplicationException("Connection has been already added.")
        End If
    End Sub

    Public Overrides Sub Remove(PConnection As CloudConnection)
        If CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Remove(PConnection)
        Else
            Throw New ApplicationException("Unknown Connection")
        End If
    End Sub

    Private m_MainConnection As Integer = 0
    Public Overrides Property Main As CloudConnection
        Get
            If CloudConnectionsList.Count >= m_MainConnection + 1 Then
                Return CloudConnectionsList(m_MainConnection)
            Else
                Return Nothing
            End If
        End Get
        Set(value As CloudConnection)
            If CloudConnectionsList.Contains(value) Then
                m_MainConnection = CloudConnectionsList.IndexOf(value)
            Else
                Throw New ApplicationException("Unknown Connection")
            End If
        End Set
    End Property

    Friend Sub New(MainConnection As CloudConnection)
        Add(MainConnection)
    End Sub
End Class
