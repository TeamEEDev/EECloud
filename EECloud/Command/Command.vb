Friend Class Command
    Implements ICommand

    Friend Sub New(sender As Player, label As String)
        mySender = sender
        myLabel = label
    End Sub

    Private ReadOnly mySender As Player

    Friend ReadOnly Property Sender As Player Implements ICommand.Sender
        Get
            Return mySender
        End Get
    End Property

    Private ReadOnly myLabel As String

    Friend ReadOnly Property Label As String Implements ICommand.Label
        Get
            Return myLabel
        End Get
    End Property
End Class
