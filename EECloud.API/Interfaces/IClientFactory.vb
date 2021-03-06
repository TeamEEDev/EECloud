﻿Public Interface IClientFactory

    ''' <summary>
    ''' Creates a new Client.
    ''' </summary>
    ''' <param name="commandChar">The command character used to call commands in the bot</param>
    Function CreateClient(commandChar As Char) As IClient(Of Player)

    ''' <summary>
    ''' Creates a new Client.
    ''' </summary>
    Function CreateClient() As IClient(Of Player)

End Interface
