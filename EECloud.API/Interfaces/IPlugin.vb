Public Interface IPlugin(Of CloudPlayer)
    Sub AttemptSetup(Host As IConnectionManager)
    Sub OnEnable()
    Sub OnDisable()
End Interface
