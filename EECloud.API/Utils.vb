Module Utils

    'TODO: Code Cleanup
#Region "Properties"
    Friend ReadOnly Property CorrectLayer(id As BlockType, layer As Layer) As Layer
        Get
            If (id > 0 AndAlso id < 500) Or id = 1000 Then
                Return layer.Foreground
            ElseIf id >= 500 AndAlso id < 1000 Then
                Return layer.Background
            Else
                Return layer
            End If
        End Get
    End Property

    Friend ReadOnly Property IsCoinDoor(id As BlockType) As Boolean
        Get
            Return id = 43
        End Get
    End Property

    Friend ReadOnly Property IsSound(id As BlockType) As Boolean
        Get
            Return id = 77 Or id = 83
        End Get
    End Property

    Friend ReadOnly Property IsPortal(id As BlockType) As Boolean
        Get
            Return id = 242
        End Get
    End Property

    Friend ReadOnly Property IsLabel(id As BlockType) As Boolean
        Get
            Return id = 1000
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Function Derot(str As String) As String
        Derot = String.Empty
        For N = 1 To str.Length
            Dim charNum As Integer = Asc(GetChar(str, N))
            If charNum >= Asc("a") And charNum <= Asc("z") Then
                If charNum > Asc("m") Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            ElseIf charNum >= Asc("A") And charNum <= Asc("Z") Then
                If charNum > Asc("M") Then
                    charNum -= 13
                Else
                    charNum += 13
                End If
            End If
            Derot &= Chr(charNum)
        Next
        Return Derot
    End Function
#End Region
End Module
