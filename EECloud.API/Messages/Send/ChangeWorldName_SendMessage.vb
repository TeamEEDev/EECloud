Public Class ChangeWorldName_SendMessage
    Inherits SendMessage
    Public ReadOnly WorldName As String
    Public Sub New(worldName As String)
        Me.WorldName = worldName
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("name", WorldName)
    End Function
End Class
