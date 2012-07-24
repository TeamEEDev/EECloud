Public Interface IBot
    ReadOnly Property OnAppHarbor As Boolean

    Overloads Function Connect(PConnection As PlayerIOClient.Connection, WorldID As String) As IConnection
    Overloads Sub Connect(Client As PlayerIOClient.Client, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))

    ReadOnly Property Connection As IConnection
    ReadOnly Property Settings As ISettings
    ReadOnly Property Logger As ILogger
    ReadOnly Property Database As IDatabase
End Interface