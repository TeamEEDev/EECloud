Public Class Chatter
    Implements IChatter

    Dim myConnection As IConnection(Of Player)
    Dim prefix As String

    Dim chatQueue As New Queue(Of Say_SendMessage)

    Dim WithEvents SendTimer As New Timers.Timer With {.Enabled = True, .AutoReset = True, .Interval = 700}

    Dim HistoryList As New List(Of String)

    Friend Sub New(connection As IConnection(Of Player), name As String)
        myConnection = connection
        prefix = "<" & name & "> "
    End Sub

    Private Sub SendChat(msg As String)
        If CheckHistory(msg) Then
            SendChat("." & msg)
            Exit Sub
        Else
            HistoryList.Add(msg)
            If HistoryList.Count > 10 Then
                HistoryList.RemoveAt(0)
            End If
        End If

        chatQueue.Enqueue(New Say_SendMessage(msg))
        If Not SendTimer.Enabled Then
            SendTimer_Elapsed(Nothing, Nothing)
            SendTimer.Start()
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
        SyncLock chatQueue 'Super important to make the code thread safe
            If chatQueue.Count > 0 Then
                myConnection.Send(chatQueue.Dequeue())
            Else
                SendTimer.Stop()
            End If
        End SyncLock
    End Sub

    Private Function CheckHistory(str As String) As Boolean
        Return HistoryList.Where(Function(x) str.Equals(x)).Count >= 4
    End Function
End Class
