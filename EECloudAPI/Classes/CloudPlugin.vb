Public MustInherit Class CloudPlugin
    Inherits Interfaces.BasePlugin

    Private myHost As Interfaces.CloudPluginHost
    Public NotOverridable Overrides Sub AttemptSetup(Host As Interfaces.CloudPluginHost)
        myHost = Host
    End Sub
End Class