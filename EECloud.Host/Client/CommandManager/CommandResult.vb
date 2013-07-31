Public Class CommandResult
    Implements ICommandResult

    Private ReadOnly myException As CommandException

    Public ReadOnly Property Exception As CommandException Implements ICommandResult.Exception
        Get
            Return myException
        End Get
    End Property

    Private ReadOnly mySuccess As Boolean

    Public ReadOnly Property Success As Boolean Implements ICommandResult.Success
        Get
            Return mySuccess
        End Get
    End Property

    Sub New(ByVal success As Boolean, ByVal exception As CommandException)
        mySuccess = success
        myException = Exception
    End Sub

End Class
