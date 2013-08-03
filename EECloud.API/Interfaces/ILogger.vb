Public Interface ILogger

    Sub Log(priority As LogPriority, str As String)
    Sub LogEx(ex As Exception)

    Event OnInput As EventHandler(Of String)

End Interface
