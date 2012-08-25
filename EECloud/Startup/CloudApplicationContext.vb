Imports System.Configuration.ConfigurationManager

Friend NotInheritable Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext
    Dim myBot As Bot

#Region "Methods"
    Friend Sub New()
        Dim myAppEnvironment As AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), AppSettings("Environment"), True), AppEnvironment)
        If myAppEnvironment = API.AppEnvironment.Release Then
            My.Settings.LicenceUsername = AppSettings("cloud.username")
            My.Settings.LicenceKey = AppSettings("cloud.key")
            My.Settings.LoginWorldID = AppSettings("cloud.worldid")
            Dim AccData As String() = AppSettings("cloud.acc").Split(":"c)
            If AccData.Length >= 2 Then
                My.Settings.LoginEmail = AccData(0)
                My.Settings.LoginPassword = AccData(1)
            End If
        ElseIf Not New LoginForm().ShowDialog() = Windows.Forms.DialogResult.OK Then
            Environment.Exit(0)
        End If

        myBot = New Bot(myAppEnvironment, GetService(myAppEnvironment))

        myBot.Logger.Log(LogPriority.Info, "Joining world...")
        myBot.Connect(My.Settings.LoginEmail, My.Settings.LoginPassword, My.Settings.LoginWorldID,
            Sub(PConnection As Connection(Of Player))
                AddHandler PConnection.OnDisconnect,
                    Sub()
                        myBot.Logger.Log(LogPriority.Info, "Disconnected.")
                    End Sub
                myBot.Logger.Log(LogPriority.Info, "Successfully joined.")
            End Sub,
            Sub(ex As EECloudException)
                myBot.Logger.Log(LogPriority.Error, "Failed to join.")
            End Sub)
    End Sub

    Private Function GetService(myAppEnvironment As AppEnvironment) As PlayerIOClient.Client
        Try
            Return PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.ServiceGameID, My.Settings.LicenceUsername, My.Settings.LicenceKey)
        Catch ex As Exception
            If myAppEnvironment = API.AppEnvironment.Dev Then
                If Not New LicenseForm().ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Environment.Exit(0)
                    Return Nothing
                Else
                    Return GetService(myAppEnvironment)
                End If
            Else
                Throw New EECloudException(ErrorCode.ServiceConnectionFailed, "Failed to create Service connection.")
            End If
        End Try
    End Function
#End Region
End Class
