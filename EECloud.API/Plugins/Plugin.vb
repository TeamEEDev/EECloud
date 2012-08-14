Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Private myHost As IBot

    Public Sub New()

    End Sub

    Friend Sub SetupPlugin(host As IBot) Implements IPlugin.SetupPlugin
        myHost = host
        OnEnable(New Connection(Of P)(myHost, myHost.Connection))
    End Sub
    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable(mainConnection As Connection(Of P))
    Protected MustOverride Sub OnDisable()

    Protected ReadOnly Property AppEnvironment As AppEnvironment
        Get
            Try
                Return myHost.AppEnvironment
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Protected ReadOnly Property Logger As ILogger
        Get
            Try
                Return myHost.Logger
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Protected ReadOnly Property PluginManager As IPluginManager
        Get
            Try
                Return myHost.PluginManager
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Protected ReadOnly Property Service As PlayerIOClient.Client
        Get
            Try
                Return myHost.Service
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Protected ReadOnly Property Settings As ISettings
        Get
            Try
                Return myHost.Settings
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Protected Sub Connect(username As String, password As String, worldID As String, successCallback As Action(Of Connection(Of P)), errorCallback As Action(Of EECloudException))
        Try
            myHost.Connect(Of P)(username, password, worldID, successCallback, errorCallback)
        Catch
        End Try
    End Sub
End Class
