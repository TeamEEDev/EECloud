Public Interface IWorld
    Event BlockPlace As EventHandler(Of BlockPlaceEventArgs)
    ReadOnly Property SizeX As Integer
    ReadOnly Property SizeY As Integer
    Default ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IBlock
End Interface
