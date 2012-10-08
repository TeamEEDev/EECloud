Public NotInheritable Class DisconnectEventArgs
    Inherits EventArgs

    Private ReadOnly myUnexpected As Boolean

    Public ReadOnly Property Unexpected As Boolean
        Get
            Return myUnexpected
        End Get
    End Property

    Public Sub New(unexpected As Boolean)
        myUnexpected = unexpected
    End Sub
End Class
