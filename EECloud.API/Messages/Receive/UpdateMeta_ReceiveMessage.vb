﻿Public Class UpdateMeta_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Owner As String '0
    Public ReadOnly Title As String '1
    Public ReadOnly Plays As Integer '2

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Owner = message.GetString(0)
        Title = message.GetString(1)
        Plays = message.GetInteger(2)
    End Sub
End Class