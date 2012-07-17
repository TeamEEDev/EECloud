Public Class EEBlockManager
    Inherits BlockManager

    Public Overrides ReadOnly Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer
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

    Public Overrides ReadOnly Property IsCoinDoor(PID As Integer) As Boolean
        Get
            Return PID = 43
        End Get
    End Property

    Public Overrides ReadOnly Property IsSound(PID As Integer) As Boolean
        Get
            Return PID = 77 Or PID = 83
        End Get
    End Property

    Public Overrides ReadOnly Property IsPortal(PID As Integer) As Boolean
        Get
            Return PID = 242
        End Get
    End Property

    Public Overrides ReadOnly Property IsLabel(PID As Integer) As Boolean
        Get
            Return PID = 1000
        End Get
    End Property
End Class
