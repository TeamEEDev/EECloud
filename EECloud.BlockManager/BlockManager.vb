<Export(GetType(PluginAPI.IBlockManager))>
Public Class BlockManager
    Implements IBlockManager

    Public ReadOnly Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer Implements IBlockManager.CorrectLayer
        Get
            If (PID > 0 And PID < 500) Or PID = 1000 Then
                Return Layer.Foreground
            ElseIf PID >= 500 And PID < 1000 Then
                Return Layer.Background
            Else
                Return PLayer
            End If
        End Get
    End Property

    Public ReadOnly Property IsCoinDoor(PID As Integer) As Boolean Implements IBlockManager.IsCoinDoor
        Get
            Return PID = 43
        End Get
    End Property

    Public ReadOnly Property IsSound(PID As Integer) As Boolean Implements IBlockManager.IsSound
        Get
            Return PID = 77 Or PID = 83
        End Get
    End Property

    Public ReadOnly Property IsPortal(PID As Integer) As Boolean Implements IBlockManager.IsPortal
        Get
            Return PID = 242
        End Get
    End Property

    Public ReadOnly Property IsLabel(PID As Integer) As Boolean Implements IBlockManager.IsLabel
        Get
            Return PID = 1000
        End Get
    End Property
End Class
