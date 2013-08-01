Imports PlayerIOClient

Public NotInheritable Class AddReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly Username As String
    '2
    Public ReadOnly Face As Smiley
    '3
    Public ReadOnly PlayerPosX As Integer
    '4
    Public ReadOnly PlayerPosY As Integer
    '5
    Public ReadOnly IsGod As Boolean
    '6
    Public ReadOnly IsMod As Boolean
    '7
    Public ReadOnly HasChat As Boolean
    '8
    Public ReadOnly Coins As Integer
    '9
    Public ReadOnly IsMyFriend As Boolean
    '10
    Public ReadOnly IsPurple As Boolean
    '11
    Public ReadOnly MagicClass As MagicClass
    '12
    Public ReadOnly IsClubMember As Boolean

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Username = message.GetString(1)
        Face = DirectCast(message.GetInteger(2), Smiley)
        PlayerPosX = message.GetInteger(3)
        PlayerPosY = message.GetInteger(4)
        IsGod = message.GetBoolean(5)
        IsMod = message.GetBoolean(6)
        HasChat = message.GetBoolean(7)
        Coins = message.GetInteger(8)
        IsMyFriend = message.GetBoolean(9)
        IsPurple = message.GetBoolean(10)
        MagicClass = DirectCast(message.GetInteger(11), MagicClass)
        IsClubMember = message.GetBoolean(12)
    End Sub
End Class
