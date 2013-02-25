''' <summary>
'''     You can get the details of a fired command using this class.
''' </summary>
''' <typeparam name="TPlayer"></typeparam>
''' <remarks></remarks>
Public Interface ICommand(Of TPlayer As {New, Player})

    ''' <summary>
    '''     The sender (who made the command execute).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Sender As TPlayer

    ''' <summary>
    '''     The command used (To identify aliases)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>???</remarks>
    ReadOnly Property Label As String

    ''' <summary>
    '''    The text used to run the command
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CommandText As String

    ''' <summary>
    '''     Replies to the command's sender.
    ''' </summary>
    ''' <param name="msg">The message to reply with.</param>
    ''' <remarks></remarks>
    Sub Reply(msg As String)
End Interface
