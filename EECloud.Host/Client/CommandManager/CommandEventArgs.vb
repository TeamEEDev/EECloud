Friend Class CommandEventArgs
#Region "Properties"
    Private myRequest As CommandRequest

    Friend ReadOnly Property Request As CommandRequest
        Get
            Return myRequest
        End Get
    End Property

    Friend Handled As Boolean
#End Region

#Region "Methods"
    Friend Sub New(request As CommandRequest)
        myRequest = request
    End Sub
#End Region
End Class
