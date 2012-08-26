﻿Public Class EECloudException
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

    Sub New(errorCode As ErrorCode)
        myErrorCode = errorCode
    End Sub

    Sub New(PErrorCode As ErrorCode, PMessage As String)
        myErrorCode = PErrorCode
        myMessage = PMessage
    End Sub

    Public Overrides Function ToString() As String
        Return myErrorCode.ToString
    End Function
End Class
