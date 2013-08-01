Imports PlayerIOClient

Public NotInheritable Class SayOldReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly Username As String
    '1
    Public ReadOnly Text As String
    '2
    Public ReadOnly IsMyFriend As Boolean

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserName = message.GetString(0)
        Text = message.GetString(1)
        IsMyFriend = message.GetBoolean(2)
    End Sub
End Class
