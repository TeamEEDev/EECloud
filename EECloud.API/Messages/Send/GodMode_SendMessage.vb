Public Class GodMode_SendMessage
    Inherits SendMessage
    Public ReadOnly GodModeEnabled As Boolean
    Public Sub New(godModeEnabled As Boolean)
        Me.GodModeEnabled = godModeEnabled
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("god", GodModeEnabled)
    End Function
End Class
