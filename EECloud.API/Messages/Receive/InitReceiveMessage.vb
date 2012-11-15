Imports PlayerIOClient

Public NotInheritable Class InitReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UsernameOwner As String
    '0
    Public ReadOnly WorldName As String
    '1
    Public ReadOnly Plays As Integer
    '2
    Public ReadOnly Encryption As String
    '5
    Public ReadOnly UserID As Integer
    '6
    Public ReadOnly SpawnX As Integer
    '7
    Public ReadOnly SpawnY As Integer
    '8
    Public ReadOnly Username As String
    '9
    Public ReadOnly CanEdit As Boolean
    '10
    Public ReadOnly IsOwner As Boolean
    '11
    Public ReadOnly SizeX As Integer
    '12
    Public ReadOnly SizeY As Integer
    '13
    Public ReadOnly IsTutorialRoom As Boolean
    '14
    Public ReadOnly Gravity As Double
    '15
    Public ReadOnly AllowPotions As Boolean
    '16

    Friend Sub New(message As Message)
        MyBase.New(message)

        UsernameOwner = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = message.GetInteger(2)
        Encryption = message.GetString(5)
        UserID = message.GetInteger(6)
        SpawnX = message.GetInteger(7)
        SpawnY = message.GetInteger(8)
        Username = message.GetString(9)
        CanEdit = message.GetBoolean(10)
        IsOwner = message.GetBoolean(11)
        SizeX = message.GetInteger(12)
        SizeY = message.GetInteger(13)
        IsTutorialRoom = message.GetBoolean(14)
        Gravity = message.GetDouble(15)
        AllowPotions = message.GetBoolean(16)
    End Sub
End Class
