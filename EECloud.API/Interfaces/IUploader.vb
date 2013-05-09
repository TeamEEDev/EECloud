Public Interface IUploader

    ReadOnly Property Count As Integer

    Sub Upload(blockMessage As BlockPlaceUploadMessage)
    Sub Clear()

    Event FinishedUpload As EventHandler

End Interface
