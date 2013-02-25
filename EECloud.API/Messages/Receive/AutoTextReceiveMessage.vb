Imports PlayerIOClient

Public NotInheritable Class AutoTextReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly AutoText As String
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        AutoText = message.GetString(1)
    End Sub
End Class
