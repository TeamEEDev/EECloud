Public Interface ICommandManager

    ''' <summary>
    ''' Loads the command handlers of instance into this CommandManager
    ''' </summary>
    ''' <param name="target">The instance being extracted</param>
    Sub Load(target As Object)

    ''' <summary>
    ''' Runs a command
    ''' </summary>
    ''' <param name="request">The CommandRequest being used to run this command</param>
    Sub InvokeCommand(request As CommandRequest)

End Interface
