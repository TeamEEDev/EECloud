﻿Imports System.Reflection
Imports System.IO

Public NotInheritable Class EECloud
    Private Shared myLicenseUsername As String
    Private Shared myLicenseKey As String
    Private Shared myUsername As String
    Private Shared myPassword As String
    Private Shared myType As AccountType
    Private Shared myWorldID As String
    Private Shared myCommandChar As Char

    Private Shared myClient As IClient(Of Player)

    Private Sub New()
    End Sub

    Shared Sub New()
        If Not My.Settings.Updated Then
            My.Settings.Upgrade()
            My.Settings.Updated = True
        End If

        myLicenseUsername = My.Settings.LicenseUsername
        myLicenseKey = My.Settings.LicenseKey
        myUsername = My.Settings.LoginEmail
        myPassword = My.Settings.LoginPassword
        myType = My.Settings.LoginType
        myWorldID = My.Settings.LoginWorldID
        myCommandChar = My.Settings.CommandChar
        Cloud.LicenseUsername = myLicenseUsername
    End Sub

    Public Shared ReadOnly Property Client As IClient(Of Player)
        Get
            Return myClient
        End Get
    End Property

    Shared Sub RunCloudMode(licenseUsername As String, licenseKey As String, username As String, password As String, type As AccountType, worldID As String)
        SetLicenseData(licenseUsername, licenseKey)
        SetLoginData(username, password, type, worldID)
        Init(False, False, True)
        CheckLicense()
        Client.CommandManager.Load(New DefaultCommandListner(Client))

        LoadDir(My.Application.Info.DirectoryPath)

        Login().Wait()
        Application.Run()
    End Sub

    Friend Shared Sub RunDesktopMode()
        Init(False, False, False)
        CheckLicense()
        Dim loginTask As Task = ShowLogin()
        Client.CommandManager.Load(New DefaultCommandListner(Client))

        LoadDir(My.Application.Info.DirectoryPath)
        Dim pluginDir As String = My.Application.Info.DirectoryPath & "\Plugins"
        If Not Directory.Exists(pluginDir) Then
            Directory.CreateDirectory(pluginDir)
        End If
        LoadDir(pluginDir)

        If Not loginTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for user response...")
            loginTask.Wait()
        End If

        Login().Wait()
        Application.Run()
    End Sub

    Public Shared Sub RunDebugMode(plugin As Type)
        Init(True, False, False)
        CheckLicense()
        Dim loginTask As Task = ShowLogin()
        Client.CommandManager.Load(New DefaultCommandListner(Client))
        Client.PluginManager.Load(plugin)

        If Not loginTask.IsCompleted Then
            Cloud.Logger.Log(LogPriority.Info, "Waiting for user response...")
            loginTask.Wait()
        End If
        Login().Wait()
        Application.Run()
    End Sub

    Public Shared Sub EnableHostMode(licenseUsername As String, licenseKey As String, debug As Boolean, console As Boolean)
        SetLicenseData(licenseUsername, licenseKey)
        Init(debug, True, console)
        CheckLicense()
    End Sub

    Private Shared Sub Init(dev As Boolean, hosted As Boolean, noConsole As Boolean)
        Console.WriteLine(String.Format("{0} Version {1}", My.Application.Info.Title, My.Application.Info.Version))
        Console.WriteLine("Built on " & RetrieveLinkerTimestamp.ToString)

        If SystemInformation.UserInteractive Then
            Application.EnableVisualStyles()
        End If

        Cloud.IsDebug = dev
        Cloud.IsHosted = hosted
        Cloud.IsNoConsole = noConsole
        Cloud.IsNoGUI = Not SystemInformation.UserInteractive

        Cloud.Logger = New Logger
        Cloud.ClientFactory = New ClientFactory
        Cloud.Service = New EEService

        myClient = Cloud.ClientFactory.CreateClient(myCommandChar)
    End Sub

    Private Shared Function RetrieveLinkerTimestamp() As DateTime
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

    Public Shared Sub SetLicenseData(username As String, key As String)
        myLicenseUsername = username
        myLicenseKey = key
        Cloud.LicenseUsername = myLicenseUsername
    End Sub

    Public Shared Async Function ShowLogin() As Task
        Await Task.Run(
            Sub()
                If Not New LoginForm().ShowDialog = DialogResult.OK Then
                    Environment.Exit(0)
                          End If
                          End Sub)
        myUsername = My.Settings.LoginEmail
        myPassword = My.Settings.LoginPassword
        myType = My.Settings.LoginType
        myWorldID = My.Settings.LoginWorldID
    End Function

    Private Shared Sub CheckLicense()
        If Not Cloud.Service.CheckLicense(myLicenseUsername, myLicenseKey) Then
            If Not Cloud.IsNoGUI Then
                If New LicenseForm().ShowDialog = DialogResult.OK Then
                    SetLicenseData(My.Settings.LicenseUsername, My.Settings.LicenseKey)
                    CheckLicense()
                Else
                    Environment.Exit(0)
                End If
            Else
                Throw New Exception("Unable to auth!")
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
            Cloud.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Cloud.Logger.LogEx(ex)
        Catch ex As BadImageFormatException
            Cloud.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            Cloud.Logger.LogEx(ex)
        End Try
        Return Nothing
    End Function

    Public Shared Async Function Login() As Task
        Try
            Cloud.Logger.Log(LogPriority.Info, "Joining world...")
            Dim task As Task = Client.Connection.ConnectAsync(myType, myUsername, myPassword, myWorldID)

            AddHandler Client.Connection.Disconnect,
                Sub()
                    Cloud.Logger.Log(LogPriority.Info, "Disconnected!")

                    For Each plugin In Client.PluginManager.Plugins
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
    End Function
End Class