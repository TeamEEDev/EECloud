Imports PlayerIOClient

Public NotInheritable Class CrownReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class
