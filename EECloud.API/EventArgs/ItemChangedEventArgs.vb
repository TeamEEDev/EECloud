Public NotInheritable Class ItemChangedEventArgs (Of T)
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myOldValue As T

    Public ReadOnly Property OldValue As T
        Get
            Return myOldValue
        End Get
    End Property

    Private ReadOnly myNewValue As T

    Public ReadOnly Property NewValue As T
        Get
            Return myNewValue
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(ByVal oldValue As T, ByVal newValue As T)
        myOldValue = oldValue
        myNewValue = newValue
    End Sub

#End Region
End Class
