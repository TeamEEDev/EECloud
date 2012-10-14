Public Class Schematic
#Region "Fields"
    Private ReadOnly myBlocks(,,) As IWorldBlock
#End Region

#Region "Properties"
    Default Public Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock
        Get
            Return myBlocks(layer, x, y)
        End Get
        Set(value As IWorldBlock)
            myBlocks(x, y, layer) = value
        End Set
    End Property
#End Region

#Region "Methods"

    Friend Sub New(sizeX As Integer, sizeY As Integer)
        Dim value(1, sizeX - 1, sizeY - 1) As IWorldBlock
        For i = 0 To 1
            For j = 0 To sizeX - 1
                For k = 0 To sizeY - 1
                    value(i, j, k) = New SchematicBlock(Block.BlockGravityNothing)
                Next
            Next
        Next
        myBlocks = value
    End Sub

#End Region

End Class
