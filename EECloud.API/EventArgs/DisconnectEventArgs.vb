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

    Private ReadOnly myReason As String

    Public ReadOnly Property Reason As String
        Get
            Return myReason
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(unexpected As Boolean, restarting As Boolean, Optional reason As String = Nothing)
        myUnexpected = unexpected
        myRestarting = restarting
        myReason = reason
    End Sub

#End Region

End Class
