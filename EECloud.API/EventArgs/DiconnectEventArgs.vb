Public NotInheritable Class DisconnectEventArgs
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myUnexpected As Boolean

    Public ReadOnly Property Unexpected As Boolean
        Get
            Return myUnexpected
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(unexpected As Boolean)
        myUnexpected = unexpected
    End Sub

#End Region
End Class
