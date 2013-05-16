Imports PlayerIOClient

Public NotInheritable Class GodModeReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly IsGod As Boolean

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        IsGod = message.GetBoolean(1)
    End Sub
End Class
