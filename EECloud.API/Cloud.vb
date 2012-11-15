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

    Private Shared myService As IEEService

    Public Shared Property Service As IEEService
        Get
            Return myService
        End Get

        Friend Set(value As IEEService)
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

    Private Shared myLicenseUsername As String

    Public Shared Property LicenseUsername As String
        Get
            Return myLicenseUsername
        End Get

        Friend Set(value As String)
            myLicenseUsername = value
        End Set
    End Property

    Private Shared myStartupWorldID As String

    Public Shared Property StartupWorldID As String
        Get
            Return myStartupWorldID
        End Get

        Friend Set(value As String)
            myStartupWorldID = value
        End Set
    End Property


#End Region

#Region "Methods"

    Private Sub New()
    End Sub

#End Region
End Class
