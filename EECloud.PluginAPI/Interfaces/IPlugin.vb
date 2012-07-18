Public Interface IPlugin(Of CloudPlayer)
    Sub AttemptSetup(Host As CloudPluginHost)
    Sub OnEnable()
    Sub OnDisable()
End Interface
