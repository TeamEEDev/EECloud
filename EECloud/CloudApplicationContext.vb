Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"

        Dim AppEnvironment As AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), System.Configuration.ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Dim myBot As New Bot(AppEnvironment)
        myBot.Connect("guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                myBot.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
