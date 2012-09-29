Imports System.IO
Imports System.IO.IsolatedStorage

Friend Class Command
    Implements ICommand

    Friend Sub New(sender As Player, label As String)
        Me.mySender = sender
        Me.myLabel = label
    End Sub

    Private mySender As Player
    Public ReadOnly Property Sender As Player Implements ICommand.Sender
        Get
            Return mySender
        End Get
    End Property

    Private myLabel As String
    Public ReadOnly Property Label As String Implements ICommand.Label
        Get
            Return myLabel
        End Get
    End Property

    Private myType As String
    Public ReadOnly Property Type As String Implements ICommand.Type
        Get
            Return myType
        End Get
    End Property
End Class
