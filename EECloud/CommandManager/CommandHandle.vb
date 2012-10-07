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

    Public ReadOnly Property Attribute As CommandAttribute
        Get
            Return myAttribute
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(attribute As CommandAttribute, method As MethodInfo, ByVal target As Object)
        myAttribute = attribute
        myMethodInfo = method
        myTarget = target

        Dim prams As ParameterInfo() = method.GetParameters
        If Not prams(0).ParameterType = GetType(ICommand) Then
            Cloud.Logger.Log(LogPriority.Error, "First parameter must be a Command: " & attribute.Type)
            Throw New EECloudException(ErrorCode.CommandSyntaxInvalid)
        End If

        mySyntaxStr = "!command"
        For i As Integer = 1 To prams.Count - 1
            Dim pram As ParameterInfo = prams(i)
            Select Case pram.ParameterType
                Case GetType(String)
                    myCount += 1
                    mySyntaxStr += " [" & pram.Name & "]"
                Case GetType(String())
                    myHasParamArray = True
                    mySyntaxStr += " [" & pram.Name & "...]"
                Case Else
                    Cloud.Logger.Log(LogPriority.Error, "Arguments must all be type of String: " & attribute.Type)
                    Throw New EECloudException(ErrorCode.CommandSyntaxInvalid)
            End Select
        Next
    End Sub

    Friend Sub Run(ParamArray args As Object())
        Try
            myMethodInfo.Invoke(myTarget, args)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Command failed to excecute: " & myAttribute.Type)
            Cloud.Logger.Log(ex)
        End Try
    End Sub

    Private ReadOnly mySyntaxStr As String

    Public Overrides Function ToString() As String
        Return mySyntaxStr
    End Function
#End Region
End Class
