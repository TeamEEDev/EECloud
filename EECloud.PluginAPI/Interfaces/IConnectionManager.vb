Public Interface IConnectionManager
    Default ReadOnly Property Item(Index As Integer) As IConnection
    ReadOnly Property Count As Integer
    Property MainConnection As IConnection
    Overloads Sub Add(PConnection As IConnection)
    Overloads Sub Add(PConnection As PlayerIOClient.Connection, WorldID As String)
    Overloads Sub Add(Client As PlayerIOClient.Client, WorldID As String)
    Overloads Sub Add(Username As String, Password As String, WorldID As String)
    Sub Remove(PConnection As IConnection)
End Interface