Public MustInherit Class UploadMessage
    Inherits SendMessage
    Friend MustOverride Sub SendMessage(client As IClient(Of Player))
    Friend MustOverride Function IsUploaded(message As BlockPlaceReceiveMessage) As Boolean
End Class
