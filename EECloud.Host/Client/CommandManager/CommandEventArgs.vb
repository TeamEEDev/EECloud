Friend NotInheritable Class CommandEventArgs
    Inherits EventArgs

#Region "Properties"
    Friend Property Handled As Boolean

    Friend Property Message As String
    Friend Property Rights As Group
    Friend Property UserID As Integer
#End Region

#Region "Methods"
    Friend Sub New(msg As String, group As Group, user As Integer)
        Message = msg
        Rights = group
        UserID = user
    End Sub
#End Region
End Class
