Public Interface IPlugin(Of CloudPlayer)
    Sub AttemptSetup(Host As IBot)
    Sub OnEnable()
    Sub OnDisable()
End Interface
