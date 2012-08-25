Friend Interface IBot
    Event OnConnect()

    ReadOnly Property AppEnvironment As AppEnvironment
    ReadOnly Property Service As PlayerIOClient.Client
    ReadOnly Property Logger As ILogger
    ReadOnly Property Settings As ISettings
    ReadOnly Property PluginManager As IPluginManager
    ReadOnly Property Connection As IInternalConnection

    Sub Connect(Of P As {Player, New})(Username As String, Password As String, WorldID As String, SuccessCallback As Action(Of Connection(Of P)), ErrorCallback As Action(Of EECloudException))
End Interface