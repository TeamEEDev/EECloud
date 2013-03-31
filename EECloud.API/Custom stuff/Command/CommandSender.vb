Public MustInherit Class CommandSender
#Region "Properties"
    Private myType As CommandSenderType

    Public ReadOnly Property Type As CommandSenderType
        Get
            Return myType
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(type As CommandSenderType)
        myType = type
    End Sub

    Friend MustOverride Sub Reply(msg As String)
#End Region

End Class
