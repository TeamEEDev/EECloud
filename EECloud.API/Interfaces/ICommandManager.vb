Public Interface ICommandManager

    ''' <summary>
    ''' Loads the command handlers of instance into this CommandManager
    ''' </summary>
    ''' <param name="target">The instance being extracted</param>
    Sub Load(target As Object)

    Sub SetHandler()

    ''' <summary>
    ''' Runs a command
    ''' </summary>
    ''' <param name="request">The CommandRequest being used to run this command</param>
    ''' <returns>True if a command handler was invoked, otherwise false</returns>
    ''' <remarks></remarks>
    Function InvokeCommand(request As CommandRequest) As ICommandResult

    ''' <summary>
    ''' Runs a command
    ''' </summary>
    ''' <param name="request">The CommandRequest being used to run this command</param>
    Sub InvokeCommand(request As CommandRequest)

    ''' <param name="scope">Scope of the call</param>
    ''' <returns>True if a command handler was invoked, otherwise false</returns>
    ''' <remarks></remarks>
    Function InvokeCommand(request As CommandRequest, scope As CommandScope) As ICommandResult
End Interface
