Public Class UploadSnapshot
    Private ReadOnly myUploader As IUploader
    Private WithEvents myWorld As IWorld
    Private ReadOnly myUploadDictionary As New Dictionary(Of Location, BlockPlaceUploadMessage)

    Public Sub New(uploader As IUploader, world As IWorld)
        myUploader = uploader
        myWorld = world
    End Sub

    Private ReadOnly Property IsChanged(location As Location) As Boolean
        Get
            Return myUploadDictionary.ContainsKey(location)
        End Get
    End Property

    Private ReadOnly Property IsSame(blockMessage As BlockPlaceUploadMessage) As Boolean
        Get
            Dim loc As New Location(blockMessage.X, blockMessage.Y, blockMessage.Layer)
            Dim worldBlock As IWorldBlock = myWorld(loc.X, loc.Y, loc.Layer)
            Return worldBlock.BlockType = BlockType.Normal AndAlso worldBlock.Block = blockMessage.Block
        End Get
    End Property

    Public Sub SetBlock(blockMessage As BlockPlaceUploadMessage)
        Dim loc As New Location(blockMessage.X, blockMessage.Y, blockMessage.Layer)

        If IsChanged(loc) Then
            If Not myUploadDictionary(loc).Block = blockMessage.Block Then
                myUploadDictionary.Remove(loc)
                If Not IsSame(blockMessage) Then
                    myUploadDictionary.Add(loc, blockMessage)
                End If
            End If
        ElseIf Not IsSame(blockMessage) Then
            myUploadDictionary.Add(loc, blockMessage)
        End If
    End Sub

    Public Sub Sync()
        For Each uploadBlock In myUploadDictionary.Values
            If Not IsSame(uploadBlock) Then
                myUploader.Upload(uploadBlock)
            End If
        Next
    End Sub

    Private Sub myWorld_BlockPlace(sender As Object, e As BlockPlaceEventArgs) Handles myWorld.BlockPlace
        Dim loc As New Location(e.X, e.Y, e.Layer)

        If IsChanged(loc) Then
            myUploadDictionary.Remove(loc)
        End If
    End Sub
End Class
