Public Class Chatter
    Implements IChatter

    Dim myConnection As Connection(Of Player)
    Dim prefix As String

    Dim chatQueue As New Queue(Of String)

    Friend Sub New(connection As Connection(Of Player), name As String)
        myConnection = connection
        prefix = "<" & name & "> "

        Dim SendThread As New Timers.Timer With {.Enabled = True, .Interval = 700}
        AddHandler SendThread.Elapsed, Sub()
                                           If chatQueue.Count > 0 Then
                                               myConnection.Send(New Say_SendMessage(chatQueue.Peek()))
                                               chatQueue.Dequeue()
                                           End If
                                       End Sub
    End Sub

    Public Sub Chat(msg As String) Implements IChatter.Chat
        chatQueue.Enqueue(prefix & msg)
    End Sub

    Public Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        chatQueue.Enqueue("/kick " & user.Username & " " & prefix & msg)
        'myConnection.Send(New Say_SendMessage("/kick " & user.Username & " " & prefix & msg))
    End Sub

    Public Sub Loadlevel() Implements IChatter.Loadlevel
        chatQueue.Enqueue("/loadlevel")
    End Sub

    Public Sub Reset() Implements IChatter.Reset
        chatQueue.Enqueue("/reset")
    End Sub
End Class
