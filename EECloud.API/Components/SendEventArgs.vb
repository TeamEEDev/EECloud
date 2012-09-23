Public Class SendEventArgs(Of T As SendMessage)
    Private myMessage As T
    Public ReadOnly Property Message As T
        Get
            Return myMessage
        End Get
    End Property

    Public Property Handled As Boolean

    Friend Sub New(message As T)
        myMessage = message
    End Sub
End Class
