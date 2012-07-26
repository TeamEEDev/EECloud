Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"

        Dim AppEnvironment As AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), System.Configuration.ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Dim myBot As New Bot(AppEnvironment)
        'TODO: well, ask for login defails somehow
        myBot.Logger.Log(LogPriority.Info, "Joining world...")
        myBot.Connect("guest", "guest", "PWWOfglOCdbEI",
            Sub(PConnection As IConnection)
                myBot.Logger.Log(LogPriority.Info, "Successfully joined.")
            End Sub,
            Sub(ex As EECloudException)
                myBot.Logger.Log(LogPriority.Info, "Failed to join.")
            End Sub)
    End Sub
End Class
