Public Class CommandPhrase

#Region "Properties"
    Public Property Type As String
    Public Property Parameters As String()
#End Region

#Region "Methods"
    Public Sub New(commandString As String)
        Dim args As String() = commandString.Split(" "c)
        Type = args(0)

        ReDim Parameters(args.Length - 1)
        Array.Copy(args, 1, Parameters, 0, args.Length - 1)
    End Sub

    Public Sub New(type As String, ParamArray params As String())
        Me.Type = type
        Parameters = params
    End Sub
#End Region

End Class
