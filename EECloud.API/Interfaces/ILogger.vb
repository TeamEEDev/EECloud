Public Interface ILogger

    Property Input As String

    Sub Log(priority As LogPriority, str As String)
    Sub LogEx(ex As Exception)

    Event OnInput As EventHandler

End Interface
