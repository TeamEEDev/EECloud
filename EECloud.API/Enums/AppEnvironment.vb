''' <summary>
''' Repesents the environment where the application is currently running.
''' </summary>
''' <remarks></remarks>
    Public Enum AppEnvironment
    ''' <summary>
    ''' The state where the program is running locally on a PC.
    ''' </summary>
    ''' <remarks></remarks>
    Dev

    ''' <summary>
    ''' The state where the program is in a hosted environment.
    ''' </summary>
    ''' <remarks></remarks>
    Hosted

    ''' <summary>
    ''' The state where the program is running in the cloud.
    ''' </summary>
    ''' <remarks></remarks>
    Release
End Enum
