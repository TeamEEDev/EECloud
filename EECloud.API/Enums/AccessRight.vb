''' <summary>
''' Represents the rights of the bot connection in the world.
''' </summary>
''' <remarks></remarks>
Public Enum AccessRight
    ''' <summary>
    ''' Represemts the state where the bot does not have any rights in the world.
    ''' </summary>
    ''' <remarks></remarks>
    None = 0
    ''' <summary>
    ''' Represents the state where the bot has edit rights in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Edit = 1
    ''' <summary>
    ''' Represents the state where bot has command access in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Full = 2
End Enum
