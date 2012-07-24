Public Interface IPlugin(Of CloudPlayer)
    Sub AttemptSetup(Host As IConnections)
    Sub OnEnable()
    Sub OnDisable()
End Interface
