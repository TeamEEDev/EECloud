Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Private myHost As IBot
    Private myConnection As IConnection(Of P)
    Private myCommandManager As CommandManager

    Friend Sub SetupPlugin(host As IBot, isStartup As Boolean) Implements IPlugin.SetupPlugin
        myHost = host
        OnEnable()
        AddHandler myHost.OnConnect, AddressOf myHost_OnConnect
        If host.HasConnection Then
            myHost_OnConnect()
        End If
    End Sub

    Private Sub myHost_OnConnect()
        myConnection = myHost.GetConnection(Of P)()
        myCommandManager = New CommandManager(myHost.GetDefaultConnection(Of P)(myConnection), myHost, Me)
        OnConnect(myConnection)
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect(mainConnection As IConnection(Of P))
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

    Protected Sub Connect(username As String, password As String, worldID As String, successCallback As Action(Of IConnection(Of P)), errorCallback As Action(Of EECloudException))
        Try
            myHost.Connect(Of P)(username, password, worldID, successCallback, errorCallback)
        Catch
            errorCallback.Invoke(Nothing)
        End Try
    End Sub
End Class
