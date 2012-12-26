Imports PlayerIOClient

Public NotInheritable Class AddReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly Username As String
    '1
    Public ReadOnly Face As Smiley
    '2
    Public ReadOnly PlayerPosX As Integer
    '3
    Public ReadOnly PlayerPosY As Integer
    '4
    Public ReadOnly IsGod As Boolean
    '5
    Public ReadOnly IsMod As Boolean
    '6
    Public ReadOnly HasChat As Boolean
    '7
    Public ReadOnly Coins As Integer
    '8
    Public ReadOnly IsMyFriend As Boolean
    '9
    Public ReadOnly IsPurple As Boolean
    '10
    Public ReadOnly MagicClass As Integer
    '11
    Public ReadOnly IsClubMember As Boolean
    '12

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Username = message.GetString(1)
        Face = CType(message.GetInteger(2), Smiley)
        PlayerPosX = message.GetInteger(3)
        PlayerPosY = message.GetInteger(4)
        IsGod = message.GetBoolean(5)
        IsMod = message.GetBoolean(6)
        HasChat = message.GetBoolean(7)
        Coins = message.GetInteger(8)
        IsMyFriend = message.GetBoolean(9)
        IsPurple = message.GetBoolean(10)
        MagicClass = message.GetInteger(11)
        IsClubMember = message.GetBoolean(12)
    End Sub
End Class
