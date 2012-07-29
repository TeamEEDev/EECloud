Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext
    Dim myBot As Bot

    Public Sub New()
        Console.Title = "EECloud"

        Dim AppEnvironment As AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), System.Configuration.ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        If AppEnvironment = API.AppEnvironment.Release Then
            My.Settings.LicenceUsername = System.Configuration.ConfigurationManager.AppSettings("cloud.username")
            My.Settings.LicenceKey = System.Configuration.ConfigurationManager.AppSettings("cloud.key")
        Else
            If My.Settings.LicenceKey = "" Then
                Console.Write("Please enter licence username: ")
                My.Settings.LicenceUsername = Console.ReadLine()
                Console.Write("Please enter licence key: ")
                My.Settings.LicenceKey = Console.ReadLine()
                My.Settings.Save()
            End If
            If SystemInformation.UserInteractive Then 'Does the current operating system support a user interface?
                Dim DialogResult As DialogResult = New LoginForm().ShowDialog()
                If DialogResult = Windows.Forms.DialogResult.Cancel Then
                    End
                End If
            End If
        End If



        myBot = New Bot(AppEnvironment, My.Settings.LicenceUsername, My.Settings.LicenceKey)
        'TODO: well, ask for login defails somehow
        myBot.Logger.Log(LogPriority.Info, "Joining world...")
        myBot.Connect("guest", "guest", "PWWOfglOCdbEI",
            Sub(PConnection As IConnection)
                    myBot.Logger.Log(LogPriority.Info, "Successfully joined.")
                End Sub,
            Sub(ex As EECloudException)
                    myBot.Logger.Log(LogPriority.Error, "Failed to join.")
                End Sub)
    End Sub
End Class
