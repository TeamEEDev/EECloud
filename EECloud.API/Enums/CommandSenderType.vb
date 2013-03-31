Public Enum CommandSenderType
    ''' <summary>
    ''' Command was invoked by an ingame player. There is a Player class available.
    ''' </summary>
    ''' <remarks></remarks>
    Player
    ''' <summary>
    ''' Command was invoked by a user on the machine EECloud is hosted on. There is no data avaiable.
    ''' </summary>
    ''' <remarks></remarks>
    Host
    ''' <summary>
    ''' Command was invoked by code running on the machine EECloud is hosted on. There is a caller class avaiable.
    ''' </summary>
    ''' <remarks></remarks>
    Internal
    ''' <summary>
    ''' Command was invoked by a user not EECloud is hosted on. There is a username string available.
    ''' </summary>
    ''' <remarks></remarks>
    Remote
End Enum
