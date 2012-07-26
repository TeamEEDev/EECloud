Public Interface IBot
    ReadOnly Property AppEnvironment As AppEnvironment

    Overloads Sub Connect(Client As PlayerIOClient.Client, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException))
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException))

    ReadOnly Property Username As String
    ReadOnly Property Key As String

    ReadOnly Property Connection As IConnection
    ReadOnly Property Settings As ISettings
    ReadOnly Property Logger As ILogger
    ReadOnly Property Database As IDatabase

    ReadOnly Property Blocks As IBlocks
End Interface