Public MustInherit Class InternalCommandSender
    Inherits CommandSender
#Region "Properties"
    Private mySender As Object

    Public ReadOnly Property Sender As Object
        Get
            Return mySender
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(sender As Object)
        MyBase.New(CommandSenderType.Internal)

        mySender = sender
    End Sub
#End Region
End Class
