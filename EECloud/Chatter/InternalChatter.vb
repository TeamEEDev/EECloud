Imports System.Timers

Friend NotInheritable Class InternalChatter
    ReadOnly myChatQueue As New Queue(Of SaySendMessage)

    Dim WithEvents mySendTimer As New Timer With {.Enabled = True, .AutoReset = True, .Interval = 700}

    ReadOnly myHistoryList As New List(Of String)

    ReadOnly myConnection As InternalConnection
    Friend Sub New(connection As InternalConnection)
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

        myChatQueue.Enqueue(New SaySendMessage(msg))
        If Not mySendTimer.Enabled Then
            SendTimer_Elapsed(Nothing, Nothing)
            mySendTimer.Start()
        End If
    End Sub

    Private Sub SendTimer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles mySendTimer.Elapsed
        SyncLock myChatQueue
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
