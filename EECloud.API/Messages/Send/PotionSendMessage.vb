Imports PlayerIOClient

Public NotInheritable Class PotionSendMessage
    Inherits SendMessage
    Public ReadOnly Potion As Potion

    Public Sub New(potion As Potion)
        Me.Potion = potion
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "p", CInt(Potion))
    End Function
End Class
