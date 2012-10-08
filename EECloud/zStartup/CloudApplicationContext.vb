Imports System.Configuration
Imports System.Reflection
Imports System.IO
Imports System.Threading.Tasks
Imports EECloud.API.EEService

Friend NotInheritable Class CloudApplicationContext
    Inherits ApplicationContext

#Region "Methods"

    Friend Sub New()
        'Creating singletons
        CreateSingletons()

        Cloud.Logger.Log(LogPriority.Info, "Loading settings...")
        'Loading settings
        LoadSettings()

        'Creating Connection
        Dim handle As IConnectionHandle = Cloud.Connector.GetConnectionHandle

        Cloud.Logger.Log(LogPriority.Info, "Loading plugins...")
        'Loading assemblies
        LoadAssembies(handle)

        'Login
        Login(handle)
    End Sub

    Private Shared Sub LoadSettings()
        If Cloud.AppEnvironment = AppEnvironment.Release Then
            My.Settings.LicenceUsername = ConfigurationManager.AppSettings("cloud.username")
            My.Settings.LicenceKey = ConfigurationManager.AppSettings("cloud.key")
            My.Settings.LoginWorldID = ConfigurationManager.AppSettings("cloud.worldid")
            Dim accData As String() = ConfigurationManager.AppSettings("cloud.acc").Split(":"c)
            If accData.Length >= 2 Then
                My.Settings.LoginEmail = accData(0)
                My.Settings.LoginPassword = accData(1)
            End If
        Else
            Application.EnableVisualStyles()
            If Not New LoginForm().ShowDialog() = DialogResult.OK Then
                Environment.Exit(0)
            End If
        End If
    End Sub

    Private Shared Sub CreateSingletons()
        Cloud.AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Cloud.Logger = New Logger
        Cloud.Service = New EESClient
        Cloud.Connector = New ConnectionHandleFactory
    End Sub

    Private Shared Sub LoadAssembies(connectionHandle As IConnectionHandle)
        connectionHandle.Connection.PluginManager.Add(GetType(CommandsBot))

        'Checking for valid plugins
        Dim plugins As IEnumerable(Of Type) =
                From assembly As Assembly In GetAssemblies(My.Application.Info.DirectoryPath)
                From type As Type In assembly.GetTypes
                Where GetType(IPlugin).IsAssignableFrom(type)
                Let attributes As Object() = type.GetCustomAttributes(GetType(PluginAttribute), True)
                Where attributes IsNot Nothing AndAlso attributes.Length = 1
                Select type

        'Activating valid plugins
        Using enumrator As IEnumerator(Of Type) = plugins.GetEnumerator
            Do
                Try
                    Dim hasNext As Boolean = enumrator.MoveNext()
                    If Not hasNext Then Exit Do

                    connectionHandle.Connection.PluginManager.Add(enumrator.Current)
                Catch ex As Exception
                    Cloud.Logger.LogEx(ex)
                End Try
            Loop
        End Using
    End Sub

    Private Shared Iterator Function GetAssemblies(path As String) As IEnumerable(Of Assembly)
        For Each dll As String In Directory.GetFiles(path, "*.dll")
            Try
                Yield Assembly.LoadFile(dll)
            Catch ex As FileLoadException
                Cloud.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Catch ex As BadImageFormatException
                Cloud.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            End Try
        Next
    End Function

    Private Shared Async Sub Login(handle As IConnectionHandle)
        Try
            Cloud.Logger.Log(LogPriority.Info, "Joining world...")
            Dim task As Task = handle.ConnectAsync(My.Settings.LoginEmail, My.Settings.LoginPassword, My.Settings.LoginWorldID)

            AddHandler handle.Connection.OnDisconnect,
                Sub()
                    Cloud.Logger.Log(LogPriority.Info, "Disconnected!")
                    Environment.Exit(1)
                End Sub

            Await task
            Cloud.Logger.Log(LogPriority.Info, "Connected!")
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Info, "Failed to connect!")
            Cloud.Logger.LogEx(ex)
            Environment.Exit(1000)
        End Try
    End Sub

#End Region
End Class
