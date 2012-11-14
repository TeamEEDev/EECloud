Public Class GlobalCommandManager
    Event OnConsoleCommand(msg As String, e As CommandEventArgs)

    Public Shared ReadOnly Value As New GlobalCommandManager

    Private Sub New()

    End Sub

    Public Sub InvokeConsoleCmd(msg As String, logger As ILogger)
        Dim e As New CommandEventArgs
        RaiseEvent OnConsoleCommand(msg, e)
        If Not e.Handled Then
            logger.Log(LogPriority.Info, "Unknown command char")
        End If
    End Sub
End Class
