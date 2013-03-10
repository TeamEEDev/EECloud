Public Structure Location
    Public Property X As Integer
    Public Property Y As Integer
    Public Property Layer As Layer

    Public Sub New(x As Integer, y As Integer, layer As Layer)
        Me.X = x
        Me.Y = y
        Me.Layer = layer
    End Sub

    Public Shared Operator =(loc1 As Location, loc2 As Location) As Boolean
        Return loc1.X = loc2.X AndAlso loc1.Y = loc2.Y AndAlso loc1.Layer = loc2.Layer
    End Operator

    Public Shared Operator <>(loc1 As Location, loc2 As Location) As Boolean
        Return Not loc1 = loc2
    End Operator
End Structure
