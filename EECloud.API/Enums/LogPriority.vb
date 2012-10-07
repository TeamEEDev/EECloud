''' <summary>
''' Describes the Priority of a log.
''' </summary>
''' <remarks></remarks>
Public Enum LogPriority
    ''' <summary>
    ''' Some infomation which describes the progress of something.
    ''' </summary>
    ''' <remarks></remarks>
    Info = 0
    ''' <summary>
    ''' Something unusual happened but no operation was canceled.
    ''' </summary>
    ''' <remarks></remarks>
    Warning = 1
    ''' <summary>
    ''' Something unexpected happened, the operation is likely canceled and the program might be unstable in the future.
    ''' </summary>
    ''' <remarks></remarks>
    [Error] = 2
    ''' <summary>
    ''' Temprorary information displayed to help debugging.
    ''' </summary>
    ''' <remarks></remarks>
    Debug = 4
End Enum
