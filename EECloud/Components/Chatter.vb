Friend Class Chatter
    Implements IChatter

    Dim myInternalChatter As InternalChatter
    Dim prefix As String

    Friend Sub New(internalChatter As InternalChatter, name As String)
        Me.myInternalChatter = internalChatter
        prefix = "<" & name & "> "
    End Sub

    Friend Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(prefix & msg)
    End Sub

    Friend Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        myInternalChatter.SendChat("/kick " & user.Username & " " & prefix & msg)
    End Sub

    Friend Sub Loadlevel() Implements IChatter.Loadlevel
        myInternalChatter.SendChat("/loadlevel")
    End Sub

    Friend Sub Reset() Implements IChatter.Reset
        myInternalChatter.SendChat("/reset")
    End Sub
End Class
