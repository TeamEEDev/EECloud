''' <summary>
''' Describes the usage of a plugin.
''' </summary>
<Flags>
Public Enum PluginCategory

    ''' <summary>
    ''' A bot that makes a fun gameplay.
    ''' </summary>
    Fun = 1

    ''' <summary>
    ''' A bot that makes admins' tasks easier.
    ''' </summary>
    Admin = 2

    ''' <summary>
    ''' A bot used for testing.
    ''' </summary>
    Test = 4

    ''' <summary>
    ''' A bot that offers chat functions.
    ''' </summary>
    Chat = 8

    ''' <summary>
    ''' A bot that monitors data and provides statistics.
    ''' </summary>
    Monitor = 16

    ''' <summary>
    ''' Helps players do specific tasks.
    ''' </summary>
    Tool = 32

    ''' <summary>
    ''' A bot that acts as the main bot and is made for a specific level.
    ''' </summary>
    LevelBot = 64

    ''' <summary>
    ''' A bot that helps builders build awesome levels.
    ''' </summary>
    Edit = 128

End Enum
