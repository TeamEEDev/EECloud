Public MustInherit Class CloudPluginManager
    Protected Sub DoSetup(Plugin As CloudPlugin(Of EECloud.PluginAPI.CloudPlayer), Host As CloudPluginHost)
        Plugin.AttemptSetup(Host)
    End Sub
End Class
