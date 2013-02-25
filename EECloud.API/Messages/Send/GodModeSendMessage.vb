Imports PlayerIOClient

Public NotInheritable Class GodModeSendMessage
    Inherits SendMessage
    Public ReadOnly GodModeEnabled As Boolean

    Public Sub New(godModeEnabled As Boolean)
        Me.GodModeEnabled = godModeEnabled
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("god", GodModeEnabled)
    End Function
End Class
