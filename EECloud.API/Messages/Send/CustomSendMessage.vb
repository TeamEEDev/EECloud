Imports PlayerIOClient

Friend NotInheritable Class CustomSendMessage
    Inherits SendMessage
    Private ReadOnly myMessage As Message

    Public Sub New(type As String, ParamArray parameters As String())
        myMessage = Message.Create(type, parameters)
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return myMessage
    End Function
End Class