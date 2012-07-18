Public Interface IConnectionManager
    Default ReadOnly Property Item(Index As Integer) As IConnection
    ReadOnly Property Count As Integer
    Property Main As IConnection
    Sub Add(PConnection As IConnection)
    Sub Remove(PConnection As IConnection)
End Interface
