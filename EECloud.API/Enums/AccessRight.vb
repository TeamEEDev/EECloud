''' <summary>
''' Represents the rights of the bot connection in the world.
''' </summary>
''' <remarks></remarks>
    Public Enum AccessRight
    ''' <summary>
    ''' Represents the state where the bot doesn't have any rights in the world.
    ''' </summary>
    ''' <remarks></remarks>
        None = 0

    ''' <summary>
    ''' Represents the state where the bot has edit rights in the world.
    ''' </summary>
    ''' <remarks></remarks>
        Edit = 1

    ''' <summary>
    ''' Represents the state where bot has command access and edit rights in the world.
    ''' </summary>
    ''' <remarks></remarks>
        Owner = 2
End Enum
