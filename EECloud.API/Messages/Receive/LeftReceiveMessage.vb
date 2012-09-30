Imports PlayerIOClient

Public Class LeftReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class
