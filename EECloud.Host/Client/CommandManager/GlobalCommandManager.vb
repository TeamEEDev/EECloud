Friend Class GlobalCommandManager
    Event OnConsoleCommand As EventHandler(Of CommandEventArgs)

    Friend Shared ReadOnly Value As New GlobalCommandManager()

    Private Sub New()

    End Sub

    Friend Sub InvokeConsoleCmd(msg As String, logger As ILogger)
        Dim e As New CommandEventArgs(msg, Group.Host, -1)
        RaiseEvent OnConsoleCommand(Me, e)

        If Not e.Handled Then
            logger.Log(LogPriority.Info, "Unknown command char.")
        End If
    End Sub
End Class
