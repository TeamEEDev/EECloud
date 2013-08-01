Public MustInherit Class RemoteCommandSender
    Inherits CommandSender

#Region "Properties"
    Private myName As String

    Public ReadOnly Property Name As String
        Get
            Return myName
        End Get
    End Property
#End Region

#Region "Methods"
    Sub New(name As String)
        MyBase.New(CommandSenderType.Remote)

        myName = name
    End Sub
#End Region

End Class
