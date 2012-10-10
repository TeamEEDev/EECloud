Imports PlayerIOClient

Public Class PotionSendMessage
    Inherits SendMessage
    Public ReadOnly Potion As Potion

    Public Sub New(potion As Potion)
        Me.Potion = potion
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create(world.Encryption & "p", CInt(Potion))
    End Function
End Class
