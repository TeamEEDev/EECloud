Public Interface ILogManager
    Property Input As String
    Event OnInput As EventHandler
    Sub Log(priority As LogPriority, str As String)
    Sub AttemptSetup()
End Interface
