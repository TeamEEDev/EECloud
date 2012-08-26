Imports System.IO
Imports System.IO.IsolatedStorage

Public Class Command
    Friend Sub New(sender As Player, type As String, args As String())
        Me.mySender = sender
        Me.myType = type
        Me.myArgs = args
    End Sub

    Private myArgs As String()
    Public ReadOnly Property Args As String()
        Get
            Return myArgs
        End Get
    End Property

    Private mySender As Player
    Public ReadOnly Property Sender As Player
        Get
            Return mySender
        End Get
    End Property

    Private myType As String
    Public ReadOnly Property Type As String
        Get
            Return myType
        End Get
    End Property
End Class
