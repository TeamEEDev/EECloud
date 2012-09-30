Imports System.Reflection

Friend NotInheritable Class CommandHandle
    Private ReadOnly myDel As [Delegate]

    Friend Sub New(name As String, method As MethodInfo, obj As Object)
        Dim prams As ParameterInfo() = method.GetParameters
        If Not prams(0).ParameterType = GetType(ICommand) Then
            Cloud.Logger.Log(LogPriority.Error, "First parameter must be a Command: " & name)
            Throw New EECloudException(ErrorCode.CommandSyntaxInvalid)
        End If

        mySyntaxStr = "/command"
        For i = 1 To prams.Count - 1
            Dim pram As ParameterInfo = prams(i)
            If pram.ParameterType = GetType(String) Then
                myRecommendedArgs += 1

                mySyntaxStr += " "
                If Not pram.IsOptional Then
                    myMinimumArgs += 1
                    mySyntaxStr += "[" & pram.Name & "]"
                Else
                    mySyntaxStr += pram.Name
                End If
            Else
                Cloud.Logger.Log(LogPriority.Error, "Arguments must all be type of String: " & name)
                Throw New EECloudException(ErrorCode.CommandSyntaxInvalid)
            End If
        Next
        myDel = method.CreateDelegate(GetType([Delegate]), obj)
    End Sub

    Friend Sub Run(cmd As Command, ParamArray args As String())
        Try
            myDel.DynamicInvoke(cmd, args)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Command failed to excecute: " & cmd.Label)
        End Try
    End Sub

    Private ReadOnly myMinimumArgs As Integer

    Friend ReadOnly Property MinimumArgs As Integer
        Get
            Return myMinimumArgs
        End Get
    End Property

    Private ReadOnly myRecommendedArgs As Integer

    Friend ReadOnly Property RecommendedArgs As Integer
        Get
            Return myRecommendedArgs
        End Get
    End Property

    Private ReadOnly mySyntaxStr As String

    Public Overrides Function ToString() As String
        Return mySyntaxStr
    End Function
End Class
