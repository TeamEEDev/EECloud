﻿Imports PlayerIOClient

Public NotInheritable Class MoveSendMessage
    Inherits SendMessage

    Public ReadOnly PosX As Integer
    Public ReadOnly PosY As Integer
    Public ReadOnly SpeedX As Double
    Public ReadOnly SpeedY As Double
    Public ReadOnly ModifierX As Double
    Public ReadOnly ModifierY As Double
    Public ReadOnly Horizontal As Double
    Public ReadOnly Vertical As Double
    Public ReadOnly GravityMultiplier As Double

    Public Sub New(posX As Integer, posY As Integer, speedX As Double, speedY As Double, modifierX As Double, modifierY As Double, horizontal As Double, vertical As Double, gravityMultiplier As Double)
        Me.PosX = posX
        Me.PosY = posY
        Me.SpeedX = speedX
        Me.SpeedY = speedY
        Me.ModifierX = modifierX
        Me.ModifierY = modifierY
        Me.Horizontal = horizontal
        Me.Vertical = vertical
        Me.GravityMultiplier = gravityMultiplier
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("m", PosX, PosY, SpeedX, SpeedY, ModifierX, ModifierY, Horizontal, Vertical, GravityMultiplier)
    End Function
End Class
