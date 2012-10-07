''' <summary>
''' Describes the usage of a plugin.
''' </summary>
''' <remarks></remarks>
<Flags>
Public Enum PluginCategory
    ''' <summary>
    ''' A bot that creates a funny gameplay.
    ''' </summary>
    ''' <remarks></remarks>
    Fun = 1

    ''' <summary>
    ''' A bot that makes admins' tasks easier.
    ''' </summary>
    ''' <remarks></remarks>
    Admin = 2

    ''' <summary>
    ''' A bot used for testing.
    ''' </summary>
    ''' <remarks></remarks>
    Test = 4

    ''' <summary>
    ''' A bot that offers chat functions.
    ''' </summary>
    ''' <remarks></remarks>
    Chat = 8

    ''' <summary>
    ''' A bot that monitors data and provides statistics.
    ''' </summary>
    ''' <remarks></remarks>
    Monitor = 16

    ''' <summary>
    ''' Helps players do specific tasks.
    ''' </summary>
    ''' <remarks></remarks>
    Tool = 32

    ''' <summary>
    ''' A bot that acts as the main bot and is made for a specific level.
    ''' </summary>
    ''' <remarks></remarks>
    LevelBot = 64

    ''' <summary>
    ''' A bot that helps builders build awesome levels.
    ''' </summary>
    ''' <remarks></remarks>
    Edit = 128
End Enum
