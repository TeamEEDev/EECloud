Public MustInherit Class CloudPlugin
    Inherits BasePlugin

    Private myHost As CloudPluginHost
    Public Sub AttemptSetup(Host As CloudPluginHost)
        myHost = Host
    End Sub
End Class