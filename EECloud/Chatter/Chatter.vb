Friend Class Chatter
    Implements IChatter

    ReadOnly myInternalChatter As InternalChatter
    ReadOnly myPrefix As String

    Friend Sub New(internalChatter As InternalChatter, name As String)
        myInternalChatter = internalChatter
        myPrefix = "<" & name & "> "
    End Sub

    Friend Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(myPrefix & msg)
    End Sub

    Friend Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        myInternalChatter.SendChat("/kick " & user.Username & " " & myPrefix & msg)
    End Sub

    Friend Sub Loadlevel() Implements IChatter.Loadlevel
        myInternalChatter.SendChat("/loadlevel")
    End Sub

    Friend Sub Reset() Implements IChatter.Reset
        myInternalChatter.SendChat("/reset")
    End Sub
End Class
