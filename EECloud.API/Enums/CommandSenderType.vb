Public Enum CommandSenderType

    ''' <summary>
    ''' Command was invoked by an ingame player. There is a Player class available.
    ''' </summary>
    Player

    ''' <summary>
    ''' Command was invoked by a user on the machine EECloud is hosted on. There is no data avaiable.
    ''' </summary>
    Host

    ''' <summary>
    ''' Command was invoked by code running on the machine EECloud is hosted on. There is a caller class avaiable.
    ''' </summary>
    Internal

    ''' <summary>
    ''' Command was invoked by a user EECloud isn't hosted on. There is a username string available.
    ''' </summary>
    Remote

End Enum
