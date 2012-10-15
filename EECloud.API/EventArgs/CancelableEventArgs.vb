Public NotInheritable Class Cancelable (Of T)

#Region "Properties"
    Private ReadOnly myValue As T

    Public ReadOnly Property Value As T
        Get
            Return myValue
        End Get
    End Property

    Public Property Handled As Boolean

#End Region

#Region "Methods"

    Friend Sub New(message As T)
        myValue = message
    End Sub

#End Region
End Class
