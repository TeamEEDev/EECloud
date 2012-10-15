Imports EECloud.API.EEService

Public NotInheritable Class Cloud

#Region "Properties"

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

    Private Shared myService As EESClient

    Public Shared Property Service As EESClient
        Get
            Return myService
        End Get

        Friend Set(value As EESClient)
            myService = value
        End Set
    End Property

    Private Shared myClientFactory As IClientFactory

    Public Shared Property ClientFactory As IClientFactory
        Get
            Return myClientFactory
        End Get

        Friend Set(value As IClientFactory)
            myClientFactory = value
        End Set
    End Property

#End Region

#Region "Methods"

    Private Sub New()
    End Sub

#End Region
End Class
