Public Interface IUploader
    Event FinishedUpload As EventHandler
    Sub Upload(ByVal blockMessage As BlockPlaceUploadMessage)
End Interface
