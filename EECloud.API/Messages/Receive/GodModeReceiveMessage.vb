Imports PlayerIOClient

Public NotInheritable Class GodModeReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly IsGod As Boolean
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        IsGod = message.GetBoolean(1)
    End Sub
End Class
