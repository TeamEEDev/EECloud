Imports PlayerIOClient

Public NotInheritable Class ChangeWorldNameSendMessage
    Inherits SendMessage
    Public ReadOnly WorldName As String

    Public Sub New(worldName As String)
        Me.WorldName = worldName
    End Sub

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create("name", WorldName)
    End Function
End Class
