Imports System.Threading

Friend NotInheritable Class Uploader
    Implements IUploader

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
    Private ReadOnly myUploadThread As Thread

    Private myUploadedArray As Boolean(,)
    Private ReadOnly myBlockUploadQueue As Deque(Of BlockPlaceUploadMessage) = Deque (Of BlockPlaceUploadMessage).Synchronized(New Deque(Of BlockPlaceUploadMessage))
    Private ReadOnly myLagCheckQueue As New Queue(Of BlockPlaceUploadMessage)
    Private myVersion As UInteger
#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = client.Connection
        myUploadThread = New Thread(AddressOf RunUploaderThread)
        myUploadThread.IsBackground = True
        myUploadThread.Start()
    End Sub

    Private Sub RunUploaderThread()
        Do
            SendNext()
            Thread.Sleep(5)
        Loop
    End Sub

    Private Async Sub LastLagCheck()
        Dim tempVer As UInteger = myVersion
        Await Task.Delay(1000)
        If myVersion = tempVer Then
            SyncLock myLagCheckQueue
                Do Until myLagCheckQueue.Count = 0
                    Dim sendBlock As BlockPlaceUploadMessage
                    sendBlock = myLagCheckQueue.Dequeue()


                    If Not myClient.World(sendBlock.X, sendBlock.Y, sendBlock.Layer).Block = sendBlock.Block Then
                        myBlockUploadQueue.PushFront(sendBlock)
                    End If
                Loop
            End SyncLock
        End If
    End Sub

    Private Sub SendNext()
        If myBlockUploadQueue.Count > 0 Then
            Dim block As BlockPlaceUploadMessage = myBlockUploadQueue.PopFront()
            myUploadedArray(block.X, block.Y) = True

            SyncLock myLagCheckQueue
                myLagCheckQueue.Enqueue(block)
            End SyncLock

            block.SendMessage(myConnection)
        ElseIf myLagCheckQueue.Count > 0 Then
            LastLagCheck()
        End If
    End Sub

    Public Sub Upload(blockMessage As BlockPlaceUploadMessage) Implements IUploader.Upload
        If Not myClient.World(blockMessage.X, blockMessage.Y, blockMessage.Layer).Block = blockMessage.Block Then
            If myBlockUploadQueue.Count = 0 Then
                myVersion = CUInt(myVersion + 1)
            End If
            myBlockUploadQueue.PushBack(blockMessage)
        End If
    End Sub

    Private Sub myConnection_ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Handles myConnection.ReceiveBlockPlace
        If myUploadedArray(e.PosX, e.PosY) Then
            Do Until myLagCheckQueue.Count = 0
                Dim sendBlock As BlockPlaceUploadMessage
                SyncLock myLagCheckQueue
                    sendBlock = myLagCheckQueue.Dequeue()
                End SyncLock

                myUploadedArray(sendBlock.X, sendBlock.Y) = False

                If sendBlock.X = e.PosX AndAlso sendBlock.Y = e.PosY AndAlso sendBlock.Layer = e.Layer Then
                    Exit Do
                Else
                    If Not myClient.World(sendBlock.X, sendBlock.Y, sendBlock.Layer).Block = sendBlock.Block Then
                        myBlockUploadQueue.PushFront(sendBlock)
                    End If
                End If
            Loop
        End If
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        ReDim myUploadedArray(e.SizeX, e.SizeY)
    End Sub

#End Region
End Class
