Public MustInherit Class CloudPluginManager
    Protected Sub DoSetup(Plugin As CloudPlugin, Host As Interfaces.CloudPluginHost)
        Plugin.AttemptSetup(Host)
    End Sub
End Class
