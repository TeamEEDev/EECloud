''' <summary>
''' Repesents the Environment where the application is currently running.
''' </summary>
''' <remarks></remarks>
Public Enum AppEnvironment
    ''' <summary>
    ''' The state where the program is running localy on a pc.
    ''' </summary>
    ''' <remarks></remarks>
    Dev
    ''' <summary>
    ''' The state where unit tests are being done.
    ''' </summary>
    ''' <remarks></remarks>
    Test
    ''' <summary>
    ''' The state where the program is running on the cloud.
    ''' </summary>
    ''' <remarks></remarks>
    Release
End Enum
