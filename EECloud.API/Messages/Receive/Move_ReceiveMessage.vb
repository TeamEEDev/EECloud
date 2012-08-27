Public Class Move_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly PlayerPosX As Integer '1
    Public ReadOnly PlayerPosY As Integer '2
    Public ReadOnly SpeedX As Double  '3
    Public ReadOnly SpeedY As Double '4
    Public ReadOnly ModifierX As Double '5
    Public ReadOnly ModifierY As Double '6
    Public ReadOnly Horizontal As Double '7
    Public ReadOnly Vertical As Double '8
    Public ReadOnly Coins As Integer '9

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        PlayerPosX = message.GetInteger(1)
        PlayerPosY = message.GetInteger(2)
        SpeedX = message.GetDouble(3)
        SpeedY = message.GetDouble(4)
        ModifierX = message.GetDouble(5)
        ModifierY = message.GetDouble(6)
        Horizontal = message.GetDouble(7)
        Vertical = message.GetDouble(8)
        Coins = message.GetInteger(9)
    End Sub
End Class
