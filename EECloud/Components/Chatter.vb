Public Class Chatter
    Implements IChatter

    Dim myConnection As Connection(Of Player)
    Dim prefix As String

    Friend Sub New(connection As Connection(Of Player), name As String)
        myConnection = connection
        prefix = "<" & name & "> "
    End Sub

    Public Sub Chat(msg As String) Implements IChatter.Chat
        myConnection.Send(New Say_SendMessage(prefix & msg))
    End Sub

    Public Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        myConnection.Send(New Say_SendMessage("/kick " & user.Username & " " & prefix & msg))
    End Sub

    Public Sub Loadlevel() Implements IChatter.Loadlevel
        myConnection.Send(New Say_SendMessage("/loadlevel"))
    End Sub

    Public Sub Reset() Implements IChatter.Reset
        myConnection.Send(New Say_SendMessage("/reset"))
    End Sub
End Class
