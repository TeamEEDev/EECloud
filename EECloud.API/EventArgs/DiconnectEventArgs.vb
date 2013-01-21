Public NotInheritable Class DisconnectEventArgs
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myUnexpected As Boolean

    Public ReadOnly Property Unexpected As Boolean
        Get
            Return myUnexpected
        End Get
    End Property

    Private ReadOnly myRestarting As Boolean

    Public ReadOnly Property Restarting As Boolean
        Get
            Return myRestarting
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(unexpected As Boolean, restarting As Boolean)
        myUnexpected = unexpected
        myRestarting = restarting
    End Sub

#End Region
End Class
