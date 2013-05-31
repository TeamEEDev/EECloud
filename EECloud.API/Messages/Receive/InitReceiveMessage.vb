Imports PlayerIOClient

Public NotInheritable Class InitReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly OwnerUsername As String
    '1
    Public ReadOnly WorldName As String
    '2
    Public ReadOnly Plays As Integer
    '3
    Public ReadOnly CurrentWoots As Integer
    '4
    Public ReadOnly TotalWoots As Integer
    '5
    Public ReadOnly Encryption As String
    '6
    Public ReadOnly UserID As Integer
    '7
    Public ReadOnly SpawnX As Integer
    '8
    Public ReadOnly SpawnY As Integer
    '9
    Public ReadOnly Username As String
    '10
    Public ReadOnly CanEdit As Boolean
    '11
    Public ReadOnly IsOwner As Boolean
    '12
    Public ReadOnly SizeX As Integer
    '13
    Public ReadOnly SizeY As Integer
    '14
    Public ReadOnly IsTutorialRoom As Boolean
    '15
    Public ReadOnly Gravity As Double
    '16
    Public ReadOnly AllowPotions As Boolean

    Friend Sub New(message As Message)
        MyBase.New(message)

        OwnerUsername = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = message.GetInteger(2)
        CurrentWoots = message.GetInteger(3)
        TotalWoots = message.GetInteger(4)
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
