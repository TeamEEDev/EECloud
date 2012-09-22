Friend Class CommandSyntax
    Private mySyntaxStr As String

    Friend Sub New(syntaxStr As String)
        Try
            Me.mySyntaxStr = syntaxStr
            If Not mySyntaxStr.StartsWith("!command") Then
                Throw New Exception
            End If
            Dim args As String() = mySyntaxStr.Split(" "c)
            Dim hadOptional As Boolean
            For i = 1 To args.Length - 1
                myRecommendedArgs += 1
                If Not (args(i).StartsWith("["c) AndAlso args(i).EndsWith("]"c)) Then
                    myMinimumArgs += 1
                    hadOptional = True
                ElseIf hadOptional Then
                    Throw New Exception
                End If
            Next
        Catch ex As Exception
            Throw New EECloudException(ErrorCode.CommandSyntaxInvalid)
        End Try
    End Sub

    Private myMinimumArgs As Integer
    Public ReadOnly Property MinimumArgs As Integer
        Get
            Return myMinimumArgs
        End Get
    End Property

    Private myRecommendedArgs As Integer
    Public ReadOnly Property RecommendedArgs As Integer
        Get
            Return myRecommendedArgs
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return mySyntaxStr
    End Function
End Class
