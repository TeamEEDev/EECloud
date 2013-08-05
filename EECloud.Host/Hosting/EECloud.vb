Imports System.IO
Imports System.Reflection

Public NotInheritable Class EECloud

#Region "Fields"

    Private Shared myHostMySqlConnStr As String

    Private Shared ReadOnly myCommandChar As Char

    Private Shared myUsername As String
    Private Shared myPassword As String
    Private Shared myType As AccountType
    Private Shared myWorldID As String

    Private Shared myClient As IClient(Of Player)

#End Region

#Region "Properties"

    Private Shared myForceShowSettings As Boolean
    Public Shared Property ForceShowSettings As Boolean
        Get
            Dim output = myForceShowSettings
            myForceShowSettings = False
            Return output
        End Get
        Set(value As Boolean)
            myForceShowSettings = value
        End Set
    End Property

    Public Shared ReadOnly Property Client As IClient(Of Player)
        Get
            Return myClient
        End Get
    End Property

#End Region

#Region "Methods"

    Private Sub New()

    End Sub

    Shared Sub New()
        If Not My.Settings.Updated Then
            My.Settings.Upgrade()
            My.Settings.Updated = True
            My.Settings.Save()
        End If

        Cloud.HostUsername = My.Settings.HostUserame
        myHostMySqlConnStr = My.Settings.HostMySqlConnStr

        If My.Settings.LoginTypes.Count > 0 Then
            myUsername = My.Settings.LoginEmails(0)
            myPassword = My.Settings.LoginPasswords(0)
            myType = My.Settings.LoginTypes(0)
        End If

        If My.Settings.LoginWorldIDs.Count > 0 Then
            myWorldID = My.Settings.LoginWorldIDs(0)
        End If

        myCommandChar = My.Settings.CommandChar
    End Sub

    Shared Sub RunCloudMode(hostUserame As String, username As String, password As String, type As AccountType,
                            worldID As String,
                            Optional mySqlConnStr As String = Nothing)
        SetHostData(hostUserame, mySqlConnStr)
        SetLoginData(username, password, type, worldID)

        Init(False, False, True)

        Client.CommandManager.Load(New DefaultCommandListener(Client))

        LoadDir(My.Application.Info.DirectoryPath)

        Login().Wait()
        Application.Run()
    End Sub

    Friend Shared Sub RunDesktopMode(restart As Boolean)
        Init(False, False, False)

        Dim loginTask As Task = ShowLogin(restart)
        Client.CommandManager.Load(New DefaultCommandListener(Client))

        LoadDir(My.Application.Info.DirectoryPath)
        Dim pluginDir As String = My.Application.Info.DirectoryPath & "\Plugins"
        If Not Directory.Exists(pluginDir) Then
            Directory.CreateDirectory(pluginDir)
        Else
            LoadDir(pluginDir)
        End If

        If Not loginTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for user response...")
            loginTask.Wait()
        End If

        Login().Wait()
        Application.Run()
    End Sub

    Public Shared Sub RunDebugMode(plugin As Type)
        Init(True, False, False)

        Dim loginTask As Task = ShowLogin()
        Client.CommandManager.Load(New DefaultCommandListener(Client))
        Client.PluginManager.Load(plugin)

        If Not loginTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for user response...")
            loginTask.Wait()
        End If

        Login().Wait()
        Application.Run()
    End Sub

    Public Shared Sub EnableHostMode(hostUserame As String, debug As Boolean, console As Boolean, Optional mySqlConnStr As String = Nothing)
        SetHostData(hostUserame, mySqlConnStr)

        Init(debug, True, console)
    End Sub

    Private Shared Sub Init(dev As Boolean, hosted As Boolean, noConsole As Boolean)
        Console.WriteLine(String.Format("{0} Version {1}", My.Application.Info.Title, My.Application.Info.Version) & Environment.NewLine &
                          "Built on " & RetrieveLinkerTimestamp.ToString())

        Cloud.Logger = New Logger()

        Cloud.IsDebug = dev
        Cloud.IsHosted = hosted
        Cloud.IsNoConsole = noConsole
        Cloud.IsNoGUI = Not SystemInformation.UserInteractive

        If Not Cloud.IsNoGUI Then
            Application.EnableVisualStyles()
        End If

        CheckHostData()

        Cloud.ClientFactory = New ClientFactory()
        Cloud.Service = New EEService.EEService(myHostMySqlConnStr)

        myClient = Cloud.ClientFactory.CreateClient(myCommandChar)
    End Sub

    Private Shared Function RetrieveLinkerTimestamp() As DateTime
        Dim filePath As String = Assembly.GetCallingAssembly().Location
        Const peHeaderOffset As Integer = 60
        Const linkerTimestampOffset As Integer = 8
        Dim b(2047) As Byte

        Using s As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            s.Read(b, 0, 2048)
        End Using

        Dim i As Integer = BitConverter.ToInt32(b, peHeaderOffset)
        Dim secondsSince1970 As Integer = BitConverter.ToInt32(b, i + linkerTimestampOffset)

        Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
        dt = dt.AddSeconds(secondsSince1970)
        dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)
        Return dt
    End Function

    Shared myStartupWorldIDSet As Boolean

    Public Shared Sub SetStartupWorldID(worldID As String)
        If Not myStartupWorldIDSet Then
            myStartupWorldIDSet = True
            Cloud.StartupWorldID = worldID
        End If
    End Sub

    Public Shared Sub SetLoginData(username As String, password As String, type As AccountType, worldID As String)
        myUsername = username
        myPassword = password
        myType = type
        myWorldID = worldID
    End Sub

    Public Shared Sub SetHostData(username As String, mySqlConnStr As String)
        Cloud.HostUsername = username
        myHostMySqlConnStr = mySqlConnStr
    End Sub

    Public Shared Async Function ShowLogin(Optional restart As Boolean = False) As Task
        If Not restart Then
            Await Task.Run(
                Sub()
                    If Not New LoginForm().ShowDialog() = DialogResult.OK Then
                        Environment.Exit(0)
                    End If
                End Sub)

            If My.Settings.LoginTypes.Count > 0 Then
                myUsername = My.Settings.LoginEmails(0)
                myPassword = My.Settings.LoginPasswords(0)
                myType = My.Settings.LoginTypes(0)
            End If

            If My.Settings.LoginWorldIDs.Count > 0 Then
                myWorldID = My.Settings.LoginWorldIDs(0)
            End If
        End If
    End Function

    Private Shared Sub CheckHostData(Optional ignoreCheckSQLiteDb As Boolean = False)
        If ForceShowSettings OrElse _
        String.IsNullOrWhiteSpace(My.Settings.HostUserame) OrElse EEService.My.Settings.QueryMySqlConnStr OrElse _
        (Not ignoreCheckSQLiteDb AndAlso Not File.Exists(EEService.SQLiteService.DbLocation)) Then
            If Not Cloud.IsNoGUI Then
                If New HostDataForm().ShowDialog() = DialogResult.OK Then
                    EEService.My.Settings.QueryMySqlConnStr = False
                    EEService.My.Settings.Save()

                    SetHostData(My.Settings.HostUserame, My.Settings.HostMySqlConnStr)
                    CheckHostData(True)
                Else
                    Environment.Exit(0)
                End If

            Else
                EEService.My.Settings.QueryMySqlConnStr = False
                EEService.My.Settings.Save()

                Throw New Exception("Corrupted host data.")
            End If
        End If
    End Sub

    Public Shared Sub LoadDir(dir As String)
        For Each assembly In GetAssemblies(dir)
            Client.PluginManager.Load(assembly)
        Next
    End Sub

    Private Shared Iterator Function GetAssemblies(path As String) As IEnumerable(Of Assembly)
        For Each assembly As Assembly In From dll In Directory.GetFiles(path, "*.plugin.dll") Select assembly1 = LoadAssembly(dll) Where assembly1 IsNot Nothing
            Yield assembly
        Next
    End Function

    Private Shared Function LoadAssembly(dll As String) As Assembly
        Try
            Return Assembly.LoadFile(dll)

        Catch ex As FileLoadException
            Cloud.Logger.Log(LogPriority.Error, "Failed to load assembly: " & dll)
            Cloud.Logger.LogEx(ex)

        Catch ex As BadImageFormatException
            Cloud.Logger.Log(LogPriority.Error, "Currupted assembly: " & dll)
            Cloud.Logger.LogEx(ex)
        End Try

        Return Nothing
    End Function

    Public Shared Async Function Login() As Task
RetryLogin:
        Try
            Cloud.Logger.Log(LogPriority.Info, "Joining world...")
            Dim task As Task = Client.Connection.ConnectAsync(myType, myUsername, myPassword, myWorldID)

            AddHandler Client.Connection.Disconnect,
                Sub(sender As Object, e As DisconnectEventArgs)
                    If String.IsNullOrWhiteSpace(e.Reason) Then
                        Cloud.Logger.Log(LogPriority.Info, "Disconnected.")
                    Else
                        Cloud.Logger.Log(LogPriority.Info, "Disconnected. Reason: " & e.Reason)
                    End If

                    For i = 0 To Client.PluginManager.Plugins.Count - 1
                        Cloud.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", Client.PluginManager.Plugins(i).Name))
                        Client.PluginManager.Plugins(i).Stop()
                    Next

                    If Not Client.Connection.UserExpectingDisconnect Then
                        If Not e.Unexpected AndAlso Not e.Restarting Then
                            Environment.Exit(0)
                        End If
                    End If
                    Environment.Exit(1)
                End Sub

            Await task

            If Client.Connection.Connected Then
                Cloud.Logger.Log(LogPriority.Info, "Connected.")
            End If

        Catch ex As EECloudPlayerIOException
            Select Case ex.PlayerIOError.ErrorCode
                Case PlayerIOClient.ErrorCode.UnknownUser
                    Select Case myType
                        Case AccountType.Regular
                            MessageBox.Show("Please check whether the username you provided is correct.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Case Else 'AccountType.Facebook
                            MessageBox.Show("Please check whether the authentication token you provided is correct.", "Invalid auth token", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select

                Case PlayerIOClient.ErrorCode.InvalidPassword
                    MessageBox.Show("Please check whether the password you provided is correct.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Case Else
                    Cloud.Logger.Log(LogPriority.Info, "Failed to connect.")
                    Cloud.Logger.LogEx(ex)
                    Environment.Exit(1)
            End Select

            ShowLogin().Wait()
            GoTo RetryLogin
        End Try
    End Function

#End Region

End Class
