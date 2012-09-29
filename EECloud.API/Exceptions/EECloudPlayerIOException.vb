Public NotInheritable Class EECloudPlayerIOException
    Inherits EECloudException

    Private ReadOnly myPlayerIOError As PlayerIOClient.PlayerIOError
    Public ReadOnly Property PlayerIOError As PlayerIOClient.PlayerIOError
        Get
            Return myPlayerIOError
        End Get
    End Property

    Public Overrides ReadOnly Property Message As String
        Get
            Return myPlayerIOError.Message
        End Get
    End Property

    Sub New(playerIOError As PlayerIOClient.PlayerIOError)
        MyBase.New(ErrorCode.PlayerIOError)
        myPlayerIOError = playerIOError
    End Sub
End Class
