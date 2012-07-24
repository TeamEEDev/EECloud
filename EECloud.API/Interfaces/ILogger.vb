Public Interface ILogger
    Property Input As String
    Event OnInput As EventHandler
    Sub Log(priority As LogPriority, str As String)
End Interface
