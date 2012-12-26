Imports PlayerIOClient

Public NotInheritable Class SayReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly Text As String
    '1
    Public ReadOnly IsMyFriend As Boolean
    '2

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Text = message.GetString(1)
        IsMyFriend = message.GetBoolean(2)
    End Sub
End Class
