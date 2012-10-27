Public Interface IKeyManager
    Event OnPress As EventHandler(Of Key)
    Event OnRelease As EventHandler(Of Key)

    Event OnRedKey As EventHandler(Of Boolean)
    Event OnBlueKey As EventHandler(Of Boolean)
    Event OnGreenKey As EventHandler(Of Boolean)
    Event OnTimedDoor As EventHandler(Of Boolean)
    Event OnPurpleSwitch As EventHandler(Of Boolean)

    ReadOnly Property RedKey As Boolean
    ReadOnly Property BlueKey As Boolean
    ReadOnly Property GreenKey As Boolean
    ReadOnly Property TimeDoor As Boolean
    ReadOnly Property PurpleSwitch As Boolean

    Sub PressRedKey()
    Sub PressBlueKey()
    Sub PressGreenKey()
    Sub PressPurpleSwitch()
End Interface
