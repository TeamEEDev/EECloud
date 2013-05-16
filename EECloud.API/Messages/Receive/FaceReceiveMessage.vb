Imports PlayerIOClient

Public NotInheritable Class FaceReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly Face As Smiley

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Face = DirectCast(message.GetInteger(1), Smiley)
    End Sub
End Class
