Imports PlayerIOClient

Public Class LevelupRecieveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly NewClass As Integer
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)
        UserID = message.GetInteger(0)
        NewClass = message.GetInteger(1)
    End Sub
End Class
