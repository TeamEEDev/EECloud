Public Class HostCommandSender
    Inherits CommandSender


#Region "Methods"
    Public Sub New()
        MyBase.New(CommandSenderType.Host)
    End Sub

    Friend Overrides Sub Reply(msg As String)
        Cloud.Logger.Log(LogPriority.Info, msg)
    End Sub
#End Region


End Class
