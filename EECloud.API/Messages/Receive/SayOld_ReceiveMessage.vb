Imports PlayerIOClient

Public Class SayOld_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserName As String
    '0
    Public ReadOnly Text As String
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserName = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class
