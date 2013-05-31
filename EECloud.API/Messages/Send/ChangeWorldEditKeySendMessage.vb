Imports PlayerIOClient

Public NotInheritable Class ChangeWorldEditKeySendMessage
    Inherits SendMessage

    Public ReadOnly EditKey As String

    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("key", EditKey)
    End Function
End Class
