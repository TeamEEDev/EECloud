Public NotInheritable Class ItemEventArgs(Of T)
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myValue As T

    Public ReadOnly Property Value As T
        Get
            Return myValue
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(ByVal value As T)
        myValue = value
    End Sub

#End Region
End Class
