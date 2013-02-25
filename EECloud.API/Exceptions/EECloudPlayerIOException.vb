Imports PlayerIOClient

Public NotInheritable Class EECloudPlayerIOException
    Inherits EECloudException

    Private ReadOnly myPlayerIOError As PlayerIOError

    Public ReadOnly Property PlayerIOError As PlayerIOError
        Get
            Return myPlayerIOError
        End Get
    End Property

    Public Overrides ReadOnly Property Message As String
        Get
            Return myPlayerIOError.Message
        End Get
    End Property

    Sub New(playerIOError As PlayerIOError)
        MyBase.New(ErrorCode.PlayerIOError)
        myPlayerIOError = playerIOError
    End Sub
End Class
