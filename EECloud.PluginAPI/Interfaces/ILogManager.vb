Public Interface ILogManager
    Property Input As String
    Event OnInput As EventHandler
    Sub Log(str As String)
End Interface
