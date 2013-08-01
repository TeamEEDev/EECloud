Imports PlayerIOClient

Public Class LevelUpReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly NewClass As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)
        UserID = message.GetInteger(0)
        NewClass = message.GetInteger(1)
    End Sub
End Class
