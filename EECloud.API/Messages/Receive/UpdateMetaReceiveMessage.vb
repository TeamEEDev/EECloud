Imports PlayerIOClient

Public NotInheritable Class UpdateMetaReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly OwnerUsername As String
    '1
    Public ReadOnly WorldName As String
    '2
    Public ReadOnly Plays As Integer
    '3
    Public ReadOnly CurrentWoots As Integer
    '4
    Public ReadOnly TotalWoots As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        OwnerUsername = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = message.GetInteger(2)
        CurrentWoots = message.GetInteger(3)
        TotalWoots = message.GetInteger(4)
    End Sub
End Class
