﻿Imports System.Timers

Friend NotInheritable Class InternalChatter

#Region "Fields"
    ReadOnly myChatQueue As New Queue(Of SaySendMessage)
    Dim WithEvents mySendTimer As New Timer With {.Enabled = True, .AutoReset = True, .Interval = 700}
    Private ReadOnly myHistoryList As New List(Of String)

    Private ReadOnly myClient As InternalClient
    Private WithEvents myConnection As IConnection

    Friend ChatSyntaxProvider As IChatSyntaxProvider
#End Region

#Region "Methods"

    Friend Sub New(client As InternalClient)
        myClient = client
        myConnection = client.Connection
        ChatSyntaxProvider = New SimpleChatSyntaxProvider
    End Sub

    Friend Sub SendChat(msg As String)
        If msg.StartsWith("/", StringComparison.Ordinal) Then
            myClient.Connection.Send(New SaySendMessage(msg))
            Return
        End If

        If CheckHistory(msg) Then
            SendChat("." & msg)
            Exit Sub
        Else
            SyncLock myHistoryList
                myHistoryList.Add(msg)
                If myHistoryList.Count > 10 Then
                    myHistoryList.RemoveAt(0)
                End If
            End SyncLock
        End If

        SyncLock myChatQueue
            Dim left As Integer
            For i = 0 To msg.Length Step 80
                left = msg.Length - i
                If left >= 80 Then
                    myChatQueue.Enqueue(New SaySendMessage(msg.Substring(i, 80)))
                Else
                    myChatQueue.Enqueue(New SaySendMessage(msg.Substring(i, left)))
                End If
            Next
        End SyncLock

        If Not mySendTimer.Enabled Then
            SendTimer_Elapsed()
            mySendTimer.Start()
        End If
    End Sub

    Private Sub SendTimer_Elapsed() Handles mySendTimer.Elapsed
        SyncLock myChatQueue
            If myChatQueue.Count > 0 Then
                myClient.Connection.Send(myChatQueue.Dequeue())
            Else
                mySendTimer.Stop()
            End If
        End SyncLock
    End Sub

    Private Function CheckHistory(str As String) As Boolean
        Return myHistoryList.Where(Function(x) str.Equals(x)).Count >= 4
    End Function

    Private Sub myConnection_Disconnect(sender As Object, e As DisconnectEventArgs) Handles myConnection.Disconnect
        myHistoryList.Clear()
        myChatQueue.Clear()
        mySendTimer.Enabled = False
    End Sub

#End Region

End Class
