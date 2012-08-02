Public Class EECloudException
    Inherits Exception
    Private myErrorCode As ErrorCode
    Public ReadOnly Property ErrorCode As ErrorCode
        Get
            Return myErrorCode
        End Get
    End Property

    Private myMessage As String
    Public Overrides ReadOnly Property Message As String
        Get
            Return myMessage
        End Get
    End Property

    Sub New(PErrorCode As ErrorCode)
        myErrorCode = PErrorCode
    End Sub

    Sub New(PErrorCode As ErrorCode, PMessage As String)
        myErrorCode = PErrorCode
        myMessage = PMessage
    End Sub
End Class
