Imports PlayerIOClient

Public Class FaceReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly Face As Smiley
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Face = CType(message.GetInteger(1), Smiley)
    End Sub
End Class
