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

#End Region


#Region "Methods"
    Sub New(sender As CommandSender, phrase As CommandPhrase)
        mySender = sender
        myPhrase = phrase
    End Sub
#End Region

End Class
