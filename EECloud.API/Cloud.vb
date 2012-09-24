Public NotInheritable Class Cloud
    Private Sub New()
    End Sub

    Private Shared myAppEnvironment As AppEnvironment
    Public Shared Property AppEnvironment As AppEnvironment
        Get
            Return myAppEnvironment
        End Get

        Friend Set(value As AppEnvironment)
            myAppEnvironment = value
        End Set
    End Property

    Private Shared myLogger As ILogger
    Public Shared Property Logger As ILogger
        Get
            Return myLogger
        End Get

        Friend Set(value As ILogger)
            myLogger = value
        End Set
    End Property

    Private Shared myService As EEService.EESClient
    Public Shared Property Service As EEService.EESClient
        Get
            Return myService
        End Get

        Friend Set(value As EEService.EESClient)
            myService = value
        End Set
    End Property

    Private Shared myConnector As IConnector
    Public Shared Property Connector As IConnector
        Get
            Return myConnector
        End Get

        Friend Set(value As IConnector)
            myConnector = value
        End Set
    End Property
End Class
