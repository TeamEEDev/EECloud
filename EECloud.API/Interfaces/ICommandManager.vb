Public Interface ICommandManager
''' <summary>
'''     Returns the number of handlers registered for this plugin
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    ReadOnly Property Count As Integer

    ''' <summary>
    '''     Checks whether a command can be handled
    ''' </summary>
    ''' <param name="cmd">The command type</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Contains(cmd As String) As Boolean

    ''' <summary>
    '''     Checks whether a command can be handled
    ''' </summary>
    ''' <param name="cmd">The command type</param>
    ''' <param name="paramCount">Number of parameters the command has</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Contains(cmd As String, paramCount As Integer) As Boolean

    ''' <summary>
    ''' Loads the command handlers of instance into this CommandManager
    ''' </summary>
    ''' <param name="target">The instance being extracted</param>
    Sub Load(target As Object)

    ''' <summary>
    '''     Runs a command
    ''' </summary>
    ''' <param name="request">The CommandRequest being used to run this command</param>
    Sub InvokeCommand(request As CommandRequest)

    ''' <param name="player">Player being invoked or null</param>
    ''' <param name="msg">The command being invoked</param>
    ''' <param name="rights">Minimum rights, if the player has higher rights, this will be ignored</param>
    ''' <remarks></remarks>
    Sub InvokeCommand(player As Player, msg As String, rights As Group)

    Sub Dispose()
End Interface
