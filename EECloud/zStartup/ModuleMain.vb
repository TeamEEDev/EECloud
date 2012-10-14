Imports System.Configuration
Imports EECloud.API.EEService
Imports System.Reflection
Imports System.IO

Module ModuleMain
#Region "Methods"
    <STAThread>
    Sub Main()
        'Creating singletons
        CreateSingletons()

        'Loading settings
        LoadSettings()

        'License check
        Cloud.Logger.Log(LogPriority.Info, "Conencting to EEService...")
        CheckLicense()

        'Creating Client
        Dim client As IClient(Of Player) = Cloud.ClientFactory.CreateClient

        Cloud.Logger.Log(LogPriority.Info, "Loading plugins...")
        'Loading assemblies
        LoadAssembies(client)

        'Login
        Login(client)

        Threading.Thread.Sleep(Threading.Timeout.Infinite)
    End Sub

    Private Sub CreateSingletons()
        Cloud.AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Cloud.Logger = New Logger
        Cloud.Service = New EESClient
        Cloud.ClientFactory = New ClientFactory
    End Sub

    Private Sub LoadSettings()
        If Cloud.AppEnvironment = AppEnvironment.Release Then
            My.Settings.LicenseUsername = ConfigurationManager.AppSettings("cloud.username")
            My.Settings.LicenseKey = ConfigurationManager.AppSettings("cloud.key")
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

    Private Sub CheckLicense()
        If Not Cloud.Service.CheckLicense(My.Settings.LicenseUsername, My.Settings.LicenseKey) Then
            If Not Cloud.AppEnvironment = AppEnvironment.Release Then
                If New LicenseForm().ShowDialog = DialogResult.OK Then
                    CheckLicense()
                Else
                    Environment.Exit(0)
                End If
            Else
                Throw New Exception("Unable to auth!")
            End If
        End If
    End Sub

    Private Sub LoadAssembies(client As IClient(Of Player))
        client.PluginManager.Load(GetType(CommandsBot))

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

                    client.PluginManager.Load(enumrator.Current)
                Catch ex As Exception
                    Cloud.Logger.LogEx(ex)
                End Try
            Loop
        End Using
    End Sub

    Private Iterator Function GetAssemblies(path As String) As IEnumerable(Of Assembly)
        For Each dll As String In Directory.GetFiles(path, "*.plugin.dll")
            Try
                Yield Assembly.LoadFile(dll)
            Catch ex As FileLoadException
                Cloud.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Catch ex As BadImageFormatException
                Cloud.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            End Try
        Next
    End Function

    Private Async Sub Login(client As IClient(Of Player))
        Try
            Cloud.Logger.Log(LogPriority.Info, "Joining world...")
            Dim task As Task = client.Connection.ConnectAsync(My.Settings.LoginEmail, My.Settings.LoginPassword, My.Settings.LoginWorldID)

            AddHandler client.Connection.Disconnect,
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
End Module
