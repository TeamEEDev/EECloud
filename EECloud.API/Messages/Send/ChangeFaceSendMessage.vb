Imports PlayerIOClient

Public Class ChangeFaceSendMessage
    Inherits SendMessage
    Public ReadOnly Face As Smiley

    Public Sub New(face As Smiley)
        Me.Face = face
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create(connection.World.Encryption & "f", Face)
    End Function
End Class
