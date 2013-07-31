Public Class CommandRequest

#Region "Properties"
    Private ReadOnly mySender As CommandSender

    Public ReadOnly Property Sender As CommandSender
        Get
            Return mySender
        End Get
    End Property

    Private ReadOnly myPhrase As CommandPhrase

    Public ReadOnly Property Phrase As CommandPhrase
        Get
            Return myPhrase
        End Get
    End Property

    Private ReadOnly myRights As Group

    Public ReadOnly Property Rights As Group
        Get
            Return myRights
        End Get
    End Property
#End Region

#Region "Methods"
    Sub New(sender As CommandSender, phrase As CommandPhrase, rights As Group)
        mySender = sender
        myPhrase = phrase
        myRights = rights
    End Sub
#End Region

End Class
