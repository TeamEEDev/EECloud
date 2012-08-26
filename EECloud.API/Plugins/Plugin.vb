Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Private myHost As IBot
    Private commandsDictionary As New Dictionary(Of String, Action(Of Command))
    Private myConnection As Connection(Of P)


    Friend Sub SetupPlugin(host As IBot, isStartup As Boolean) Implements IPlugin.SetupPlugin
        myHost = host
        For Each method As Reflection.MethodInfo In Me.GetType.GetMethods
            Dim myAttributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If myAttributes IsNot Nothing AndAlso myAttributes.Length = 1 Then
                Dim myAttribute As CommandAttribute = CType(myAttributes(0), CommandAttribute)
                Try
                    commandsDictionary.Add(myAttribute.Type, CType([Delegate].CreateDelegate(GetType(Action(Of Command)), Me, method), Action(Of Command)))
                Catch ex As Exception
                    myHost.Logger.Log(LogPriority.Error, "Method has bad signature" & method.ToString)
                    myHost.Logger.Log(ex)
                End Try
            End If
        Next


        OnEnable()
        AddHandler myHost.OnConnect, AddressOf myHost_OnConnect
        If host.Connection IsNot Nothing Then
            myHost_OnConnect()
        End If
    End Sub

    Private Sub myHost_OnConnect()
        myConnection = New Connection(Of P)(myHost, myHost.Connection)
        AddHandler myConnection.OnReciveSay, AddressOf myConnection_OnReciveSay
        OnConnect(myConnection)
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Private Sub myConnection_OnReciveSay(sender As Object, e As Say_ReciveMessage)
        If e.Text.StartsWith("!") Then
            Dim cmd As String() = e.Text.Substring(1).Split(" "c)
            Dim type As String = cmd(0).ToLower
            If commandsDictionary.ContainsKey(type) Then
                Dim args() As String = {}
                If cmd.Length > 1 Then
                    ReDim args(cmd.Length - 2)
                    For i = 1 To cmd.Length - 1
                        args(i - 1) = cmd(i)
                    Next
                End If
                Dim myCommand As New Command(myConnection.Players(e.UserID), type, args)
                commandsDictionary(type).Invoke(myCommand)
            End If
        End If
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect(mainConnection As Connection(Of P))
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
            errorCallback.Invoke(Nothing)
        End Try
    End Sub
End Class
