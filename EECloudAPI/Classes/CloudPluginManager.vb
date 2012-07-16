Public MustInherit Class CloudPluginManager
    Protected Sub DoSetup(Plugin As CloudPlugin(Of EECloud.API.CloudPlayer), Host As Interfaces.CloudPluginHost)
        Plugin.AttemptSetup(Host)
    End Sub
End Class
