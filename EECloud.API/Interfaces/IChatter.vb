Public Interface IChatter
    Sub Reply(username As String, msg As String)
    Sub Chat(msg As String)
    Sub Kick(username As String, msg As String)
    Sub Loadlevel()
    Sub Reset()
End Interface
