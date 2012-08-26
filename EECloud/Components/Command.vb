Imports System.IO
Imports System.IO.IsolatedStorage

Public Class Command
    Implements ICommand

    Private myArgs As String()
    Public ReadOnly Property Args As String() Implements ICommand.Args
        Get
            Return myArgs
        End Get
    End Property

    Private mySender As Player
    Public ReadOnly Property Sender As Player Implements ICommand.Sender
        Get
            Return mySender
        End Get
    End Property

    Private myType As String
    Public ReadOnly Property Type As String Implements ICommand.Type
        Get
            Return myType
        End Get
    End Property
End Class
