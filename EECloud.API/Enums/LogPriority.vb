''' <summary>
''' Describes the priority of a LogEx entry.
''' </summary>
Public Enum LogPriority

    ''' <summary>
    ''' Some infomation which describes the progress of something.
    ''' </summary>
    Info = 0

    ''' <summary>
    ''' Something unusual happened, but no operation was cancelled.
    ''' </summary>
    Warning = 1

    ''' <summary>
    ''' Something unexpected happened; the operation is likely cancelled and the program might be unstable from now on.
    ''' </summary>
    [Error] = 2

    ''' <summary>
    ''' Temprorary information displayed to help debugging.
    ''' </summary>
    Debug = 4

End Enum
