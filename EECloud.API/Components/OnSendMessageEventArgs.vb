Public Class OnSendMessageEventArgs(Of T As SendMessage)
    Inherits EventArgs

    Private myMessage As T
    Public ReadOnly Property Message As T
        Get
            Return myMessage
        End Get
    End Property

    Private myHandle As SendMessageHandle(Of T).InternalHandle
    Public ReadOnly Property Handled As Boolean
        Get
            Return myHandle IsNot Nothing
        End Get
    End Property

    Private myInternalConnection As IInternalConnection
    Public Function GetHandle() As SendMessageHandle(Of T)
        If Not myHandle Is Nothing Then
            myHandle = New SendMessageHandle(Of T).InternalHandle(myMessage, myInternalConnection)
        End If
        Return New SendMessageHandle(Of T)(myHandle)
    End Function

    Friend Sub New(message As T, internalConnection As IInternalConnection)
        Me.myMessage = message
        Me.myInternalConnection = internalConnection
    End Sub
End Class
