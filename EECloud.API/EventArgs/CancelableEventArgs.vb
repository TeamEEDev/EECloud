Public NotInheritable Class Cancelable (Of T)
    Inherits EventArgs
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
