Imports System.Configuration

Public Class EECloud
    Private myClient As IClient(Of Player)

    Public ReadOnly Property Client As IClient(Of Player)
        Get
            Return myClient
        End Get
    End Property

    Sub New(defaultCommands As Boolean)
        Me.New(defaultCommands, True)
    End Sub

    Friend Sub New(defaultCommands As Boolean, hosted As Boolean)
        If hosted Then
            Cloud.AppEnvironment = AppEnvironment.Hosted
        Else
            Cloud.AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        End If

        Cloud.Logger = New Logger
        Cloud.ClientFactory = New ClientFactory
        Cloud.Service = New EEService

        myClient = Cloud.ClientFactory.CreateClient("!"c)
        If defaultCommands Then
            Client.CommandManager.Load(New DefaultCommandListner(Client))
        End If
    End Sub

    Public Function LicenseLogin(username As String, key As String) As Boolean
        Dim value As Boolean = Cloud.Service.CheckLicense(username, key)
        If value = True Then
            Cloud.LicenseUsername = username
        End If
        Return value
    End Function

    Dim startupWorldIDSet As Boolean

    Public Sub SetStartupWorldID(worldID As String)
        If Not startupWorldIDSet Then
            startupWorldIDSet = True
            Cloud.StartupWorldID = worldID
        End If
    End Sub
End Class