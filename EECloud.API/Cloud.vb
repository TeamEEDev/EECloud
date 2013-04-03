Public NotInheritable Class Cloud

#Region "Properties"
    Private Shared myIsDebug As Boolean

    Public Shared Property IsDebug As Boolean
        Get
            Return myIsDebug
        End Get

        Friend Set(value As Boolean)
            myIsDebug = value
        End Set
    End Property


    Private Shared myIsHosted As Boolean

    Public Shared Property IsHosted As Boolean
        Get
            Return myIsHosted
        End Get

        Friend Set(value As Boolean)
            myIsHosted = value
        End Set
    End Property


    Private Shared myIsNoConsole As Boolean

    Public Shared Property IsNoConsole As Boolean
        Get
            Return myIsNoConsole
        End Get

        Friend Set(value As Boolean)
            myIsNoConsole = value
        End Set
    End Property


    Private Shared myIsNoGUI As Boolean

    Public Shared Property IsNoGUI As Boolean
        Get
            Return myIsNoGUI
        End Get

        Friend Set(value As Boolean)
            myIsNoGUI = value
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


    Private Shared myInGameUsername As String

    Public Shared Property InGameUsername As String
        Get
            Return myInGameUsername
        End Get

        Friend Set(value As String)
            myInGameUsername = value
        End Set
    End Property

#End Region

#Region "Methods"

    Private Sub New()

    End Sub

#End Region

End Class
