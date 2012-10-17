Imports PlayerIOClient

Public NotInheritable Class ModModeSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create("mod")
    End Function
End Class
