Imports PlayerIOClient

Public Class GodModeSendMessage
    Inherits SendMessage
    Public ReadOnly GodModeEnabled As Boolean

    Public Sub New(godModeEnabled As Boolean)
        Me.GodModeEnabled = godModeEnabled
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("god", GodModeEnabled)
    End Function
End Class
