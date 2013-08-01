Imports PlayerIOClient

Public NotInheritable Class UpdateMetaReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Owner As String
    '0
    Public ReadOnly WorldName As String
    '1
    Public ReadOnly Plays As Integer
    '2
    Public ReadOnly CurrentWoots As Integer
    '3
    Public ReadOnly TotalWoots As Integer
    '4

    Friend Sub New(message As Message)
        MyBase.New(message)

        Owner = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = message.GetInteger(2)
        CurrentWoots = message.GetInteger(3)
        TotalWoots = message.GetInteger(4)
    End Sub
End Class
