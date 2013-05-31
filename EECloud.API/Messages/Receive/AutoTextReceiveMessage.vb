Imports PlayerIOClient

Public NotInheritable Class AutoTextReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly AutoText As String

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        AutoText = message.GetString(1)
    End Sub
End Class
