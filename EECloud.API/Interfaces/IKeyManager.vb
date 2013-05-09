Public Interface IKeyManager

    Event OnPress As EventHandler(Of Key)
    Event OnRelease As EventHandler(Of Key)

    Event OnRedKey As EventHandler(Of Boolean)
    Event OnBlueKey As EventHandler(Of Boolean)
    Event OnGreenKey As EventHandler(Of Boolean)
    Event OnTimedDoor As EventHandler(Of Boolean)

    ReadOnly Property RedKey As Boolean
    ReadOnly Property BlueKey As Boolean
    ReadOnly Property GreenKey As Boolean
    ReadOnly Property TimeDoor As Boolean

    Sub PressRedKey()
    Sub PressBlueKey()
    Sub PressGreenKey()

End Interface
