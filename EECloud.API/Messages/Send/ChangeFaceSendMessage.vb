Imports PlayerIOClient

Public NotInheritable Class ChangeFaceSendMessage
    Inherits SendMessage

    Public ReadOnly Face As Smiley

    Public Sub New(face As Smiley)
        Me.Face = face
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "f", Face)
    End Function
End Class
