Friend Class InternalChatter
    ReadOnly myChatQueue As New Queue(Of Say_SendMessage)

    Dim WithEvents mySendTimer As New Timers.Timer With {.Enabled = True, .AutoReset = True, .Interval = 700}

    ReadOnly myHistoryList As New List(Of String)

    ReadOnly myConnection As IConnection(Of Player)

    Friend Sub New(connection As IConnection(Of Player))
        myConnection = connection
    End Sub

    Friend Sub SendChat(msg As String)
        If CheckHistory(msg) Then
            SendChat("." & msg)
            Exit Sub
        Else
            myHistoryList.Add(msg)
            If myHistoryList.Count > 10 Then
                myHistoryList.RemoveAt(0)
            End If
        End If

        myChatQueue.Enqueue(New Say_SendMessage(msg))
        If Not mySendTimer.Enabled Then
            SendTimer_Elapsed(Nothing, Nothing)
            mySendTimer.Start()
        End If
    End Sub

    Private Sub SendTimer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles mySendTimer.Elapsed
        SyncLock myChatQueue 'Super important to make the code thread safe
            If myChatQueue.Count > 0 Then
                myConnection.Send(myChatQueue.Dequeue())
            Else
                mySendTimer.Stop()
            End If
        End SyncLock
    End Sub

    Private Function CheckHistory(str As String) As Boolean
        Return myHistoryList.Where(Function(x) str.Equals(x)).Count >= 4
    End Function
End Class
