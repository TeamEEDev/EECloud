﻿Imports PlayerIOClient

Public NotInheritable Class MoveReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly PlayerPosX As Integer
    '1
    Public ReadOnly PlayerPosY As Integer
    '2
    Public ReadOnly SpeedX As Double
    '3
    Public ReadOnly SpeedY As Double
    '4
    Public ReadOnly ModifierX As Double
    '5
    Public ReadOnly ModifierY As Double
    '6
    Public ReadOnly Horizontal As Double
    '7
    Public ReadOnly Vertical As Double
    '8
    Public ReadOnly Coins As Integer
    '9
    Public ReadOnly IsPurple As Boolean
    '10

    Friend Sub New(message As Message)
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
        IsPurple = message.GetBoolean(10)
    End Sub

    Public ReadOnly Property BlockX As Integer
        Get
            Return PlayerPosX + 8 >> 4
        End Get
    End Property

    Public ReadOnly Property BlockY As Integer
        Get
            Return PlayerPosY + 8 >> 4
        End Get
    End Property
End Class
