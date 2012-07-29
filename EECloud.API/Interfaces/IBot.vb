Public Interface IBot
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException))

    ReadOnly Property AppEnvironment As AppEnvironment
    ReadOnly Property Service As PlayerIOClient.Client
    ReadOnly Property Logger As ILogger
    ReadOnly Property Settings As ISettings
    ReadOnly Property PluginManager As IPluginManager

    ReadOnly Property Blocks As IBlocks
End Interface