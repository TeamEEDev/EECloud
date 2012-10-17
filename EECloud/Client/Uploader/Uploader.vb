Imports System.Threading

Friend NotInheritable Class Uploader
    Implements IUploader

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
    Private ReadOnly myUploadThread As Thread

    Private myUploadedArray As Boolean(,)
    Private ReadOnly myBlockUploadQueue As Deque(Of BlockPlaceUploadMessage) = Deque(Of BlockPlaceUploadMessage).Synchronized(New Deque(Of BlockPlaceUploadMessage))
    Private ReadOnly myLagCheckQueue As New Queue(Of BlockPlaceUploadMessage)
    Private myVersion As UInteger
#End Region

#Region "Events"

    Public Event FinishedUpload(sender As Object, e As EventArgs) Implements IUploader.FinishedUpload

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
            Thread.Sleep(10)
        Loop
    End Sub

    'Private Async Sub LastLagCheck()
    '    Dim tempVer As UInteger = myVersion
    '    Await Task.Delay(1000)
    '    If myVersion = tempVer Then
    '        SyncLock myLagCheckQueue
    '            If myLagCheckQueue.Count = 0 Then
    '                RaiseEvent FinishedUpload(Me, EventArgs.Empty)
    '            Else
    '                Do Until myLagCheckQueue.Count = 0
    '                    Dim sendBlock As BlockPlaceUploadMessage
    '                    sendBlock = myLagCheckQueue.Dequeue()

    '                    myBlockUploadQueue.PushFront(sendBlock)
    '                Loop
    '            End If
    '        End SyncLock
    '    End If
    'End Sub

    Private Sub SendNext()
        If myBlockUploadQueue.Count > 0 Then
            Dim block As BlockPlaceUploadMessage = myBlockUploadQueue.PopFront()
            myUploadedArray(block.X, block.Y) = True

            SyncLock myLagCheckQueue
                myLagCheckQueue.Enqueue(block)
            End SyncLock

            block.SendMessage(myClient)
        ElseIf myLagCheckQueue.Count > 0 Then
            'TODO: FIX LASTLAGCHECK
            ' LastLagCheck()
            RaiseEvent FinishedUpload(Me, EventArgs.Empty)
        End If
    End Sub

    Public Sub Upload(blockMessage As BlockPlaceUploadMessage) Implements IUploader.Upload
        If myBlockUploadQueue.Count = 0 Then
            myVersion = CUInt(myVersion + 1)
        End If
        myBlockUploadQueue.PushBack(blockMessage)
    End Sub

    Private Sub myConnection_ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Handles myConnection.ReceiveBlockPlace
        If myUploadedArray(e.PosX, e.PosY) Then
            Do Until myLagCheckQueue.Count = 0
                Dim sendBlock As BlockPlaceUploadMessage
                SyncLock myLagCheckQueue
                    sendBlock = myLagCheckQueue.Dequeue()
                End SyncLock

                myUploadedArray(sendBlock.X, sendBlock.Y) = False

                If sendBlock.IsUploaded(e) Then
                    Exit Do
                Else
                    myBlockUploadQueue.PushFront(sendBlock)
                End If
            Loop
        End If
    End Sub

    Private Sub myConnection_ReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlaceReceiveMessage) Handles myConnection.ReceiveCoinDoorPlace

    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        ReDim myUploadedArray(e.SizeX, e.SizeY)
    End Sub

#End Region
End Class
