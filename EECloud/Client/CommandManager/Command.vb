﻿Friend NotInheritable Class Command(Of TPlayer As {New, Player})
    Implements ICommand(Of TPlayer)

    Friend Sub New(sender As TPlayer, label As String)
        mySender = sender
        myLabel = label
    End Sub

    Private ReadOnly mySender As TPlayer

    Friend ReadOnly Property Sender As TPlayer Implements ICommand(Of TPlayer).Sender
        Get
            Return mySender
        End Get
    End Property

    Private ReadOnly myLabel As String

    Friend ReadOnly Property Label As String Implements ICommand(Of TPlayer).Label
        Get
            Return myLabel
        End Get
    End Property
End Class