Public Interface ICommandManager
    ''' <summary>
    '''     Loads the command handlers of instance into this CommandManager
    ''' </summary>
    ''' <param name="target">The instance being extracted</param>
    ''' <remarks></remarks>
    Sub Load(target As Object)

    ''' <summary>
    ''' Runs a command
    ''' </summary>
    ''' <param name="request">The CommandRequest being used to run this command</param>
    ''' <remarks></remarks>
    Sub InvokeCommand(request As CommandRequest)
End Interface
