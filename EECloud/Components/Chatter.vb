Public Class Chatter
    Implements IChatter

    Dim myConnection As Connection(Of Player)
    Dim prefix As String

    Dim chatQueue As New Queue(Of Say_SendMessage)
    Dim WithEvents SendTimer As New Timers.Timer With {.Enabled = True, .AutoReset = True, .Interval = 700}


    Friend Sub New(connection As Connection(Of Player), name As String)
        myConnection = connection
        prefix = "<" & name & "> "
    End Sub

    Private Sub SendChat(msg As String)
        chatQueue.Enqueue(New Say_SendMessage(msg))
        If Not SendTimer.Enabled Then
            SendTimer.Enabled = True
        End If
    End Sub

    Public Sub Chat(msg As String) Implements IChatter.Chat
        SendChat(prefix & msg)
    End Sub

    Public Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        SendChat("/kick " & user.Username & " " & prefix & msg)
    End Sub

    Public Sub Loadlevel() Implements IChatter.Loadlevel
        SendChat("/loadlevel")
    End Sub

    Public Sub Reset() Implements IChatter.Reset
        SendChat("/reset")
    End Sub

    Private Sub SendTimer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles SendTimer.Elapsed
        SyncLock chatQueue 'Super important to make code thread safe
            If chatQueue.Count > 0 Then
                myConnection.Send(chatQueue.Dequeue)
            Else
                SendTimer.Enabled = False
            End If
        End SyncLock
    End Sub
End Class
