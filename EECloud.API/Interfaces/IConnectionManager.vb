Public Interface IConnectionManager
    Inherits IConnection
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Sub AttemptSetup(POnAppharbor As Boolean, PContainer As CompositionContainer)
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Sub SetMainConnection(PConnection As IConnection)
    ReadOnly Property OnAppHarbor As Boolean

    Overloads Function Connect(PConnection As PlayerIOClient.Connection, WorldID As String) As IConnection
    Overloads Sub Connect(Client As PlayerIOClient.Client, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, Callback As PlayerIOClient.Callback(Of IConnection))

    ReadOnly Property SettingManager As ISettingManager
    ReadOnly Property LogManager As ILogManager
    ReadOnly Property DatabaseManager As IDatabaseManager
End Interface