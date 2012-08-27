Public Class ChangeFace_SendMessage
    Inherits SendMessage
    Public ReadOnly Face As Smiley
    Public Sub New(face As Smiley)
        Me.Face = face
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "f", Face)
    End Function
End Class
