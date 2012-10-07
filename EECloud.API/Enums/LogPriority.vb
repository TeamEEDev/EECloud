''' <summary>
''' Describes the priority of a log entry.
''' </summary>
''' <remarks></remarks>
Public Enum LogPriority
    ''' <summary>
    ''' Some infomation which describes the progress of something.
    ''' </summary>
    ''' <remarks></remarks>
    Info = 0

    ''' <summary>
    ''' Something unusual happened, but no operation was cancelled.
    ''' </summary>
    ''' <remarks></remarks>
    Warning = 1

    ''' <summary>
    ''' Something unexpected happened; the operation is likely cancelled and the program might be unstable from now.
    ''' </summary>
    ''' <remarks></remarks>
    [Error] = 2

    ''' <summary>
    ''' Temprorary information displayed to help debugging.
    ''' </summary>
    ''' <remarks></remarks>
    Debug = 4
End Enum
