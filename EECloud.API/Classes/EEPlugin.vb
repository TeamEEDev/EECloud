Public MustInherit Class EEPlugin(Of Player As EEPlayer)
    Implements IPlugin, IBot

    Private myHost As IBot
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Sub SetupPlugin(Host As IBot) Implements IPlugin.SetupPlugin
        myHost = Host
    End Sub

    Public MustOverride Sub OnDisable() Implements IPlugin.OnDisable
    Public MustOverride Sub OnEnable() Implements IPlugin.OnEnable

    Public ReadOnly Property AppEnvironment As AppEnvironment Implements IBot.AppEnvironment
        Get
            Return myHost.AppEnvironment
        End Get
    End Property

    Public ReadOnly Property Blocks As IBlocks Implements IBot.Blocks
        Get
            Return myHost.Blocks
        End Get
    End Property

    Public Overloads Sub Connect(Username As String, Password As String, WorldID As String, SuccessCallback As PlayerIOClient.Callback(Of IConnection), ErrorCallback As PlayerIOClient.Callback(Of EECloudException)) Implements IBot.Connect
        myHost.Connect(Username, Password, WorldID, SuccessCallback, ErrorCallback)
    End Sub

    Public ReadOnly Property Logger As ILogger Implements IBot.Logger
        Get
            Return myHost.Logger
        End Get
    End Property

    Public ReadOnly Property PluginManager As IPluginManager Implements IBot.PluginManager
        Get
            Return myHost.PluginManager
        End Get
    End Property

    Public ReadOnly Property Service As PlayerIOClient.Client Implements IBot.Service
        Get
            Return myHost.Service
        End Get
    End Property

    Public ReadOnly Property Settings As ISettings Implements IBot.Settings
        Get
            Return myHost.Settings
        End Get
    End Property
End Class
