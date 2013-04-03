Public MustInherit Class CommandSender
#Region "Properties"
    Private myType As CommandSenderType

    Public ReadOnly Property Type As CommandSenderType
        Get
            Return myType
        End Get
    End Property

    Private myChatter As IChatter

    Protected ReadOnly Property Chatter As IChatter
        Get
            Return myChatter
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(type As CommandSenderType)
        myType = type
    End Sub

    Public MustOverride Sub Reply(msg As String)

    Friend Sub InjectChatter(chatter As IChatter)
        myChatter = chatter
    End Sub
#End Region

End Class
