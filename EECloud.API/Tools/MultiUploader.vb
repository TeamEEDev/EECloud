Public Class MultiUploader
    Private ReadOnly myUploaderList As New List(Of IUploader)
    Private myPointer As Integer

    Public Sub New()
    End Sub

    Public Sub Add(uploader As IUploader)
        myUploaderList.Add(uploader)
    End Sub

    Public Sub Upload(blockMessage As BlockPlaceUploadMessage)
        myUploaderList(myPointer).Upload(blockMessage)

        myPointer += 1
        If myPointer >= myUploaderList.Count Then myPointer = 0
    End Sub
End Class
