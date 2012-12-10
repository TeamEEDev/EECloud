Public Interface IUploader
    Event FinishedUpload As EventHandler
    ReadOnly Property Count() As Integer
    Sub Upload(ByVal blockMessage As BlockPlaceUploadMessage)
    Sub Clear()
End Interface
