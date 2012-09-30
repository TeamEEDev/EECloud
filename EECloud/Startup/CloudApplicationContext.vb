Imports System.Configuration.ConfigurationManager
Imports System.Reflection
Imports System.IO

Friend NotInheritable Class CloudApplicationContext
    Inherits Windows.Forms.ApplicationContext

#Region "Methods"
    Friend Sub New()
        'Loading settings
        If Cloud.AppEnvironment = AppEnvironment.Release Then
            My.Settings.LicenceUsername = AppSettings("cloud.username")
            My.Settings.LicenceKey = AppSettings("cloud.key")
            My.Settings.LoginWorldID = AppSettings("cloud.worldid")
            Dim accData As String() = AppSettings("cloud.acc").Split(":"c)
            If accData.Length >= 2 Then
                My.Settings.LoginEmail = accData(0)
                My.Settings.LoginPassword = accData(1)
            End If
        Else
            Application.EnableVisualStyles()
            If Not New LoginForm().ShowDialog() = Windows.Forms.DialogResult.OK Then
                Environment.Exit(0)
            End If
        End If

        'Creating singletons
        Cloud.AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), AppSettings("Environment"), True), AppEnvironment)
        Cloud.Logger = New Logger
        Cloud.Service = New EEService.EESClient
        Cloud.Connector = New ConnectionHandleFactory

        'Loading Plugin assemblies
        Dim handle As IConnectionHandle = Cloud.Connector.GetConnectionHandle

        Dim allAssemblies As New List(Of Assembly)
        Dim path As String = My.Application.Info.DirectoryPath

        For Each dll As String In Directory.GetFiles(path, "*.dll")
            Try
                allAssemblies.Add(Assembly.LoadFile(dll))
            Catch ex As FileLoadException
                Cloud.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Catch ex As BadImageFormatException
                Cloud.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            End Try
        Next

        'Checking for valid plugins
        Dim plugins As IEnumerable(Of Type) =
            From assembly As Assembly In allAssemblies
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

                    handle.PluginManager.Add(enumrator.Current).Start()
                Catch ex As Exception
                    Cloud.Logger.Log(ex)
                End Try
            Loop
        End Using

        'Login
        Cloud.Logger.Log(LogPriority.Info, "Joining world...")
        handle.JoinAsync(My.Settings.LoginEmail, My.Settings.LoginPassword, My.Settings.LoginWorldID)
    End Sub
#End Region
End Class
