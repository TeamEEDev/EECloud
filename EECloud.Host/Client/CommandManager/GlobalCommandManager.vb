Friend Class GlobalCommandManager
    Event OnConsoleCommand(msg As String, e As CommandEventArgs)

    Friend Shared ReadOnly Value As New GlobalCommandManager

    Private Sub New()

    End Sub

    Friend Sub InvokeConsoleCmd(msg As String, logger As ILogger)
        Dim e As New CommandEventArgs
        RaiseEvent OnConsoleCommand(msg, e)
        If Not e.Handled Then
            logger.Log(LogPriority.Info, "Unknown command char")
        End If
    End Sub
End Class
