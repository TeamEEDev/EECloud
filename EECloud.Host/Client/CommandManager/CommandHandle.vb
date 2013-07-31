Imports System.Reflection

Friend NotInheritable Class CommandHandle

#Region "Fields"
    Private ReadOnly myMethodInfo As MethodInfo
    Private ReadOnly myTarget As Object
#End Region

#Region "Properties"
    Private ReadOnly myHasParamArray As Boolean

    Friend ReadOnly Property HasParamArray As Boolean
        Get
            Return myHasParamArray
        End Get
    End Property

    Private ReadOnly myCount As Integer

    Friend ReadOnly Property Count As Integer
        Get
            Return myCount
        End Get
    End Property

    Private ReadOnly myAttribute As CommandAttribute

    Friend ReadOnly Property Attribute As CommandAttribute
        Get
            Return myAttribute
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(attribute As CommandAttribute, method As MethodInfo, target As Object)
        myAttribute = attribute
        myMethodInfo = method
        myTarget = target

        'Check for first parameter
        Dim params As ParameterInfo() = method.GetParameters()
        If Not params(0).ParameterType = GetType(CommandRequest) Then
            Cloud.Logger.Log(LogPriority.Error, "First parameter must be a CommandRequest: " & attribute.Type)
            Throw New EECloudException(ErrorCode.InvalidCommand)
        End If

        'Generate syntax string and validate rest of paramters
        mySyntaxStr = "!command"
        Dim param As ParameterInfo
        For i As Integer = 1 To params.Count - 1
            param = params(i)

            Select Case param.ParameterType
                Case GetType(String)
                    myCount += 1
                    mySyntaxStr &= " [" & param.Name & "]"
                Case GetType(String())
                    Dim attributes As ParamArrayAttribute() = CType(param.GetCustomAttributes(GetType(ParamArrayAttribute)), ParamArrayAttribute())
                    If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
                        myHasParamArray = True
                        mySyntaxStr &= " [" & param.Name & "...]"
                    Else
                        Cloud.Logger.Log(LogPriority.Error, "String Arrays in commands must have the ParamArrayAttribute on them: " & attribute.Type)
                        Throw New EECloudException(ErrorCode.InvalidCommand)
                    End If

                Case Else
                    Cloud.Logger.Log(LogPriority.Error, "Arguments must all be type of String: " & attribute.Type)
                    Throw New EECloudException(ErrorCode.InvalidCommand)
            End Select
        Next
    End Sub

    Friend Sub Run(request As CommandRequest)
        Try
            myMethodInfo.Invoke(myTarget, GetArgArray(request))
        Catch cmdEx As CommandException
            Throw
        Catch ex As Exception
            request.Sender.Reply("Command failed to excecute")
            Cloud.Logger.Log(LogPriority.Error, "Command failed to excecute: " & myAttribute.Type)
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Friend Function GetArgArray(request As CommandRequest) As Object()
        Dim args As New List(Of Object)
        args.Add(request)

        If Not HasParamArray Then
            args.AddRange(request.Phrase.Parameters)
        Else
            'Normals
            For i = 0 To Count - 1
                args.Add(request.Phrase.Parameters(i))
            Next

            'ParamArray
            Dim pramArgs As New List(Of String)
            For i = Count To request.Phrase.Parameters.Length - 1
                pramArgs.Add(request.Phrase.Parameters(Count))
            Next

            args.Add(pramArgs.ToArray)
        End If

        Return args.ToArray
    End Function

    Private ReadOnly mySyntaxStr As String

    Public Overrides Function ToString() As String
        Return mySyntaxStr
    End Function

#End Region

End Class
