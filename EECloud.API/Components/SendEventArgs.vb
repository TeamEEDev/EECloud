Public Class SendEventArgs(Of T As SendMessage)
    Private ReadOnly _message As T
    Public ReadOnly Property Message As T
        Get
            Return _Message
        End Get
    End Property

    Public Property Handled As Boolean

    Friend Sub New(message As T)
        _Message = message
    End Sub
End Class
