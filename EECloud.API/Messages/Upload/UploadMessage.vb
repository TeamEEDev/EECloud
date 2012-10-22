Public MustInherit Class UploadMessage
    Inherits SendMessage
    Friend MustOverride Function SendMessage(client As IClient(Of Player)) As Boolean
    Friend MustOverride Function IsUploaded(ByVal message As BlockPlaceReceiveMessage) As Boolean
End Class
