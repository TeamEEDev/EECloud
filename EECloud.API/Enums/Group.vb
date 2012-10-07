''' <summary>
''' Represents the rights of a user
''' </summary>
''' <remarks></remarks>
Public Enum Group
    ''' <summary>
    ''' Banned. May not join any world and therefore should not be given access to any commands.
    ''' </summary>
    ''' <remarks></remarks>
    Banned = -200
    ''' <summary>
    ''' The pre-ban stage. If there are any commands available to Users, this group will not have access to them.
    ''' </summary>
    ''' <remarks></remarks>
    Limited = -100
    ''' <summary>
    ''' Default rank.
    ''' </summary>
    ''' <remarks></remarks>
    User = 0
    ''' <summary>
    ''' These users can kick normal users and might be used to test alpha stage commands. Do not give them permanent advatage over normal users.
    ''' </summary>
    ''' <remarks></remarks>
    Trusted = 100
    ''' <summary>
    ''' This rank is temprorary, most level bot commands (other than setting wins for ex.) should use this rank.
    ''' </summary>
    ''' <remarks></remarks>
    Moderator = 300
    ''' <summary>
    ''' Should have the same rights as Admins, excluding setting ranks.
    ''' </summary>
    ''' <remarks></remarks>
    [Operator] = 200
    ''' <summary>
    ''' Has access to absolutely everything. Most commands should use Operator instead.
    ''' </summary>
    ''' <remarks></remarks>
    Admin = 400
    ''' <summary>
    ''' This rank is used to specify console-only commands, no real user will have this rank.
    ''' </summary>
    ''' <remarks></remarks>
    Host = 500
End Enum
