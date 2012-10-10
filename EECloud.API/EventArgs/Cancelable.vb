Public NotInheritable Class Cancelable(Of T)
    Private ReadOnly myValue As T

    Public ReadOnly Property Value As T
        Get
            Return myValue
        End Get
    End Property

    Public Property Handled As Boolean

    Friend Sub New(message As T)
        myValue = message
    End Sub
End Class
