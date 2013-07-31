Public Class HostCommandSender
    Implements ICommandSender


#Region "Methods"
    Public Sub New()

    End Sub

    Public Sub Reply(msg As String) Implements ICommandSender.Reply
        Cloud.Logger.Log(LogPriority.Info, msg)
    End Sub
#End Region
End Class
