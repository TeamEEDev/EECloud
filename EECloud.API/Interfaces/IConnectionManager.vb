Public Interface IConnectionManager
    Inherits IConnection
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Sub SetMainConnection(PConnection As IConnection)
    ReadOnly Property OnAppHarbor As Boolean

    Overloads Function Connect(PConnection As PlayerIOClient.Connection, WorldID As String) As IConnection
    Overloads Sub Connect(Client As PlayerIOClient.Client, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))

    ReadOnly Property SettingManager As ISettings
    ReadOnly Property LogManager As ILogger
    ReadOnly Property DatabaseManager As IDatabase
End Interface