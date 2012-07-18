Friend Class EECloudManager
    Implements IConnectionManager

    Private CloudConnectionsList As New List(Of IConnection)
    Public ReadOnly Property Count As Integer Implements IConnectionManager.Count
        Get
            Return CloudConnectionsList.Count
        End Get
    End Property

    Default Public ReadOnly Property Item(Index As Integer) As IConnection Implements IConnectionManager.Item
        Get
            Return CloudConnectionsList.Item(Index)
        End Get
    End Property

    Public Sub Add(PConnection As IConnection) Implements IConnectionManager.Add
        If Not CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Add(PConnection)
        Else
            Throw New ApplicationException("Connection has been already added.")
        End If
    End Sub

    Public Sub Remove(PConnection As IConnection) Implements IConnectionManager.Remove
        If CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Remove(PConnection)
        Else
            Throw New ApplicationException("Unknown Connection")
        End If
    End Sub

    Private m_MainConnection As Integer = 0
    Public Property Main As IConnection Implements IConnectionManager.Main
        Get
            If CloudConnectionsList.Count >= m_MainConnection + 1 Then
                Return CloudConnectionsList(m_MainConnection)
            Else
                Return Nothing
            End If
        End Get
        Set(value As IConnection)
            If CloudConnectionsList.Contains(value) Then
                m_MainConnection = CloudConnectionsList.IndexOf(value)
            Else
                Throw New ApplicationException("Unknown Connection")
            End If
        End Set
    End Property
End Class
