Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"

        Dim m_ConnectionManager As IConnectionManager = New ConnectionManager
        m_ConnectionManager.AttemptSetup(System.Configuration.ConfigurationManager.AppSettings("Environment") = "Release")
        m_ConnectionManager.Connect(
            "guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                m_ConnectionManager.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
