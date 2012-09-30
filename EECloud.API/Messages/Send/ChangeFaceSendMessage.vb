Imports PlayerIOClient

Public Class ChangeFaceSendMessage
    Inherits SendMessage
    Public ReadOnly Face As Smiley

    Public Sub New(face As Smiley)
        Me.Face = face
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create(world.Encryption & "f", Face)
    End Function
End Class
