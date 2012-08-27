Public Class EESendEventArgs(Of T As SendMessage)
    Inherits SendEventArgs(Of T)

    Private myMessage As T
    Public Overrides ReadOnly Property Message As T
        Get
            Return myMessage
        End Get
    End Property

    Private myHandle As SendMessageHandle(Of T).InternalHandle
    Public Overrides ReadOnly Property Handled As Boolean
        Get
            Return myHandle IsNot Nothing
        End Get
    End Property

    Private myInternalConnection As InternalConnection
    Public Overrides Function GetHandle() As ISendMessageHandle(Of T)
        If Not myHandle Is Nothing Then
            myHandle = New SendMessageHandle(Of T).InternalHandle(myMessage, myInternalConnection)
        End If
        Return New SendMessageHandle(Of T)(myHandle)
    End Function

    Friend Sub New(message As T, internalConnection As InternalConnection)
        Me.myMessage = message
        Me.myInternalConnection = internalConnection
    End Sub
End Class
