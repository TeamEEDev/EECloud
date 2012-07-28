Public Interface IBot
    ReadOnly Property AppEnvironment As AppEnvironment

    Overloads Sub Connect(Client As PlayerIOClient.Client, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException))
    Overloads Sub Connect(Username As String, Password As String, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException))

    ReadOnly Property LicenceUsername As String
    ReadOnly Property LicenceKey As String

    ReadOnly Property Connection As IConnection
    ReadOnly Property Logger As ILogger
    ReadOnly Property Service As IService
    ReadOnly Property Settings As ISettings
    ReadOnly Property PluginManager As IPluginManager

    ReadOnly Property Blocks As IBlocks
End Interface