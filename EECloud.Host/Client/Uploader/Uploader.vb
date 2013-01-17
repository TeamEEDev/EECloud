Imports System.Threading

Friend NotInheritable Class Uploader
    Implements IUploader

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
    Private ReadOnly myUploadThread As Thread

    Private myUploadedArray As Boolean(,,)
    Private ReadOnly myBlockUploadQueue As Deque(Of BlockPlaceUploadMessage) = Deque(Of BlockPlaceUploadMessage).Synchronized(New Deque(Of BlockPlaceUploadMessage))
    Private ReadOnly myLagCheckQueue As New Queue(Of BlockPlaceUploadMessage)
    Private myVersion As UInteger
    Private myFinishedUploadVersion As UInteger
#End Region

#Region "Events"

    Friend Event FinishedUpload(sender As Object, e As EventArgs) Implements IUploader.FinishedUpload

#End Region

#Region "Properties"

    Public ReadOnly Property Count As Integer Implements IUploader.Count
        Get
            Return myBlockUploadQueue.Count
        End Get
    End Property

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
            Thread.Sleep(6)
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Private Async Sub LastLagCheck()
        Dim tempVer As UInteger = myVersion
        Await Task.Delay(500)
        If myVersion = tempVer Then
            SyncLock myLagCheckQueue
                Do Until myLagCheckQueue.Count = 0
                    Dim sendBlock As BlockPlaceUploadMessage = myLagCheckQueue.Dequeue()
                    myUploadedArray(sendBlock.Layer, sendBlock.X, sendBlock.Y) = False

                    If Not myClient.World(sendBlock.X, sendBlock.Y, sendBlock.Layer).Block = sendBlock.Block Then
                        myBlockUploadQueue.PushFront(sendBlock)
                    End If
                Loop
            End SyncLock
        End If
    End Sub

    Private Sub SendNext()
retry:
        If myBlockUploadQueue.Count > 0 Then
            Dim block As BlockPlaceUploadMessage = myBlockUploadQueue.PopFront()

            If block.SendMessage(myClient) Then
                If Not myUploadedArray(block.Layer, block.X, block.Y) Then
                    myUploadedArray(block.Layer, block.X, block.Y) = True

                    SyncLock myLagCheckQueue
                        myLagCheckQueue.Enqueue(block)
                    End SyncLock
                End If
            Else
                GoTo retry
            End If
        Else
            If myLagCheckQueue.Count > 0 Then
                LastLagCheck()
            End If
            If Not myVersion = myFinishedUploadVersion Then
                myFinishedUploadVersion = myVersion
                RaiseEvent FinishedUpload(Me, EventArgs.Empty)
            End If
        End If
    End Sub

    Friend Sub Upload(blockMessage As BlockPlaceUploadMessage) Implements IUploader.Upload
        If myBlockUploadQueue.Count = 0 Then
            myVersion = CUInt(myVersion + 1)
        End If
        myBlockUploadQueue.PushBack(blockMessage)
    End Sub

    Friend Sub Clear() Implements IUploader.Clear
        myBlockUploadQueue.Clear()

        SyncLock myLagCheckQueue
            myLagCheckQueue.Clear()
        End SyncLock

        Array.Clear(myUploadedArray, 0, myUploadedArray.Length)

        myVersion = 0
        myFinishedUploadVersion = 0
    End Sub

    Private Sub HandleBlockPlace(e As BlockPlaceReceiveMessage)
        If myUploadedArray(e.Layer, e.PosX, e.PosY) Then
            Do Until myLagCheckQueue.Count = 0
                Dim sendBlock As BlockPlaceUploadMessage
                SyncLock myLagCheckQueue
                    sendBlock = myLagCheckQueue.Dequeue()
                End SyncLock

                myUploadedArray(sendBlock.Layer, sendBlock.X, sendBlock.Y) = False

                If sendBlock.IsUploaded(e) Then
                    Exit Do
                ElseIf Not myClient.World(sendBlock.X, sendBlock.Y, sendBlock.Layer).Block = sendBlock.Block Then
                    myBlockUploadQueue.PushFront(sendBlock)
                End If
            Loop
        End If
    End Sub

    Private Sub myConnection_ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Handles myConnection.ReceiveBlockPlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlaceReceiveMessage) Handles myConnection.ReceiveCoinDoorPlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceiveLabelPlace(sender As Object, e As LabelPlaceReceiveMessage) Handles myConnection.ReceiveLabelPlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceivePortalPlace(sender As Object, e As PortalPlaceReceiveMessage) Handles myConnection.ReceivePortalPlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceiveSoundPlace(sender As Object, e As SoundPlaceReceiveMessage) Handles myConnection.ReceiveSoundPlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceiveRotatablePlace(sender As Object, e As RotatablePlaceReceiveMessage) Handles myConnection.ReceiveRotatablePlace
        HandleBlockPlace(e)
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        ReDim myUploadedArray(1, e.SizeX, e.SizeY)
    End Sub

    Private Sub myConnection_ReceiveReset(sender As Object, e As ResetReceiveMessage) Handles myConnection.ReceiveReset
        Clear()
    End Sub

#End Region
End Class
