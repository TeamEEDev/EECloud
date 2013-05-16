Imports PlayerIOClient

Public NotInheritable Class WriteReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly Title As String
    '1
    Public ReadOnly Text As String

    Friend Sub New(message As Message)
        MyBase.New(message)

        Title = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class
