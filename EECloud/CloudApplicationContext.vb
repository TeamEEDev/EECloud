Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"

        Dim onAppharbor = (System.Configuration.ConfigurationManager.AppSettings("Environment") = "Release")
        Dim m_ConnectionManager As IConnections = New Connections(onAppharbor)
        m_ConnectionManager.Connect("guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                m_ConnectionManager.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
