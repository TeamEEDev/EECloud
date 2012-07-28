﻿Public Class EECloudPlayerIOException
    Inherits EECloudException

    Private myPlayerIOError As PlayerIOClient.PlayerIOError
    Public ReadOnly Property PlayerIOError As PlayerIOClient.PlayerIOError
        Get
            Return myPlayerIOError
        End Get
    End Property

    Public NotOverridable Overrides ReadOnly Property Message As String
        Get
            Return myPlayerIOError.Message
        End Get
    End Property

    Sub New(PPlayerIOError As PlayerIOClient.PlayerIOError)
        MyBase.New(API.ErrorCode.PlayerIOError)
        myPlayerIOError = PPlayerIOError
    End Sub
End Class