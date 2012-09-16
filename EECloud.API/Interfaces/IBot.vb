Friend Interface IBot
    Event OnConnect()

    ReadOnly Property AppEnvironment As AppEnvironment
    ReadOnly Property Logger As ILogger
    ReadOnly Property PluginManager As IPluginManager
    ReadOnly Property HasConnection As Boolean
    ReadOnly Property EEService As EEService.EESClient

    Sub Connect(Of P As {Player, New})(Username As String, Password As String, WorldID As String, SuccessCallback As Action(Of IConnection(Of P)), ErrorCallback As Action(Of EECloudException))
    Function GetChatter(connection As IConnection(Of Player), name As String) As IChatter
    Function GetConnection(Of P As {Player, New})() As IConnection(Of P)
    Function GetDefaultChatter(connection As IConnection(Of Player)) As IChatter
    Function GetDefaultConnection(Of P As {Player, New})(connection As IConnection(Of P)) As IConnection(Of Player)
End Interface