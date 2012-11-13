Imports System.Reflection
Imports System.IO
Imports System.Configuration
Imports System.Net

Module ModuleMain
#Region "Methods"

#Region "Startup"

    Sub Main()
        Console.WriteLine(String.Format("{0} Version {1}", My.Application.Info.Title, My.Application.Info.Version))
        Console.WriteLine("Built on " & RetrieveLinkerTimestamp.ToString)

        If SystemInformation.UserInteractive Then
            Application.EnableVisualStyles()
        End If

        Cloud.AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Cloud.Logger = New Logger
        Cloud.ClientFactory = New ClientFactory
        Cloud.Service = New EEService

        Init()

        Application.Run()
    End Sub

    Async Sub Init()
        Dim updateTask As Task = CheckForUpdates()
        Dim loadTask As Task = LoadSettings()
        CheckLicense()

        'Creating Client
        Dim client As IClient(Of Player) = Cloud.ClientFactory.CreateClient("!"c)
        client.CommandManager.Load(New DefaultCommandListner(client))

        'Loading assemblies
        Dim args As String() = Environment.GetCommandLineArgs
        If args.Length >= 2 Then
            Dim assembly As Assembly = LoadAssembly(args(1))
            If assembly IsNot Nothing Then
                LoadAssembies(client, My.Settings.LoginWorldID, {assembly})
            End If
        Else
            LoadDefaultAssemblies(client)
        End If

        If Not loadTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for user response...")
            Await loadTask
        End If
        If Not updateTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for update check...")
            Await updateTask
        End If

        'Login
        Login(client)
    End Sub

    Private Function RetrieveLinkerTimestamp() As DateTime
        Dim filePath As String = Assembly.GetCallingAssembly().Location
        Const peHeaderOffset As Integer = 60
        Const linkerTimestampOffset As Integer = 8
        Dim b As Byte() = New Byte(2047) {}
        Dim s As Stream = Nothing

        Try
            s = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            s.Read(b, 0, 2048)
        Finally
            If s IsNot Nothing Then
                s.Close()
            End If
        End Try

        Dim i As Integer = BitConverter.ToInt32(b, peHeaderOffset)
        Dim secondsSince1970 As Integer = BitConverter.ToInt32(b, i + linkerTimestampOffset)
        Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
        dt = dt.AddSeconds(secondsSince1970)
        dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)
        Return dt
    End Function

#End Region

#Region "Updates"

    Private Async Function CheckForUpdates() As Task
        If Cloud.AppEnvironment = AppEnvironment.Dev Then
            Try
                Using webClient As New WebClient()
                    Dim version As String = Await webClient.DownloadStringTaskAsync(New Uri("https://dl.dropbox.com/u/13946635/EECloud/Version.txt"))
                    If New Version(version) > My.Application.Info.Version Then
                        'Download
                        Await webClient.DownloadFileTaskAsync(New Uri("https://dl.dropbox.com/u/13946635/EECloud/EECloud.msi"), Directory.GetCurrentDirectory & "\EECloud.msi")
                        'Notify user
                        MsgBox("Update ready. Press OK to start updating:", MsgBoxStyle.OkOnly)
                        'Write a batch file
                        Using writer As New StreamWriter(Directory.GetCurrentDirectory & "\update.bat")
                            writer.WriteLine("start /w EECloud.msi")
                            writer.WriteLine("del EECloud.msi")
                            writer.WriteLine("start EECloud.exe")
                            writer.WriteLine("del %0")
                        End Using
                        'Start the batch file
                        Dim process As New Process()
                        process.StartInfo.CreateNoWindow = True
                        process.StartInfo.RedirectStandardOutput = True
                        process.StartInfo.UseShellExecute = False
                        process.StartInfo.FileName = Directory.GetCurrentDirectory & "\update.bat"
                        process.Start()
                        'Exit
                        End
                    End If
                End Using
            Catch ex As Exception
                Cloud.Logger.Log(LogPriority.Info, "Failed to check for updates")
                Cloud.Logger.LogEx(ex)
            End Try
        End If
    End Function

#End Region

#Region "Settings"

    Private Async Function LoadSettings() As Task
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
            If Not My.Settings.Updated Then
                My.Settings.Upgrade()
                My.Settings.Updated = True
                My.Settings.Save()
            End If
            Await ShowLogin()
        End If
    End Function

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

#End Region

#Region "Login"

    Private Async Function ShowLogin() As Task
        If Cloud.AppEnvironment = AppEnvironment.Dev Then
            Await Task.Run(
                Sub()
                    If Not New LoginForm().ShowDialog = DialogResult.OK Then
                        Environment.Exit(0)
                    End If
                End Sub)
        End If
    End Function

    Private Async Sub Login(client As IClient(Of Player))
        Try
            Cloud.Logger.Log(LogPriority.Info, "Joining world...")
            Dim task As Task = client.Connection.ConnectAsync(My.Settings.LoginType, My.Settings.LoginEmail, My.Settings.LoginPassword, My.Settings.LoginWorldID)

            AddHandler client.Connection.Disconnect,
                Sub()
                    Cloud.Logger.Log(LogPriority.Info, "Disconnected!")

                    For Each plugin In client.PluginManager.Plugins
                        Cloud.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", plugin.Name))
                        plugin.Stop()
                    Next
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

#Region "Assemblies"

    Private Sub LoadDefaultAssemblies(client As IClient(Of Player))
        Dim dir As String = Directory.GetCurrentDirectory
        LoadAssembies(client, My.Settings.LoginWorldID, GetAssemblies(dir))

        If Cloud.AppEnvironment = AppEnvironment.Dev Then
            Dim pluginDir As String = dir & "\Plugins"
            If Not Directory.Exists(pluginDir) Then
                Directory.CreateDirectory(pluginDir)
            End If
            LoadAssembies(client, My.Settings.LoginWorldID, GetAssemblies(pluginDir))
        End If
    End Sub

    Private Sub LoadAssembies(client As IClient(Of Player), worldID As String, assemblies As IEnumerable(Of Assembly))
        'Checking for valid plugins
        Dim plugins As IEnumerable(Of Type) =
                From assembly As Assembly In assemblies.AsParallel
                From type As Type In assembly.GetTypes
                Where GetType(IPlugin).IsAssignableFrom(type)
                Let attributes As Object() = type.GetCustomAttributes(GetType(PluginAttribute), True)
                Where attributes IsNot Nothing AndAlso attributes.Length = 1
                Let attribute As PluginAttribute = CType(attributes(0), PluginAttribute)
                Where attribute.StartupLoaded AndAlso (attribute.StartupRooms Is Nothing OrElse attribute.StartupRooms.Length = 0 OrElse attribute.StartupRooms.Contains(worldID))
                Select type

        'Activating valid plugins
        Using enumrator As IEnumerator(Of Type) = plugins.GetEnumerator
            Do
                Try
                    Dim hasNext As Boolean = enumrator.MoveNext()
                    If Not hasNext Then Exit Do

                    Cloud.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", enumrator.Current.Name))
                    client.PluginManager.Load(enumrator.Current)
                Catch ex As Exception
                    Cloud.Logger.LogEx(ex)
                End Try
            Loop
        End Using
    End Sub

    Private Iterator Function GetAssemblies(path As String) As IEnumerable(Of Assembly)
        For Each dll As String In Directory.GetFiles(path, "*.plugin.dll")
            Dim assembly As Assembly = LoadAssembly(dll)
            If assembly IsNot Nothing Then
                Yield assembly
            End If
        Next
    End Function

    Private Function LoadAssembly(dll As String) As Assembly
        Try
            Return Assembly.LoadFile(dll)
        Catch ex As FileLoadException
            Cloud.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Cloud.Logger.LogEx(ex)
        Catch ex As BadImageFormatException
            Cloud.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            Cloud.Logger.LogEx(ex)
        End Try
        Return Nothing
    End Function

#End Region

#End Region



End Module
