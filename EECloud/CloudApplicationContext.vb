Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"

        Dim AppEnvironment As AppEnvironment = CType([Enum].Parse(GetType(AppEnvironment), System.Configuration.ConfigurationManager.AppSettings("Environment"), True), AppEnvironment)
        Dim m_ConnectionManager As New Bot(AppEnvironment)
        m_ConnectionManager.Connect("guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                m_ConnectionManager.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
