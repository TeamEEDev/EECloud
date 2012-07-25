Public Class EECloudException
    Inherits Exception
    Private myErrorCode As ErrorCode
    Public ReadOnly Property ErrorCode As ErrorCode
        Get
            Return myErrorCode
        End Get
    End Property

    Sub New(PErrorCode As ErrorCode)
        myErrorCode = PErrorCode
    End Sub
End Class
