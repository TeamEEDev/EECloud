Imports System.Threading

Friend NotInheritable Class Logger
    Implements ILogger

#Region "Fields"
    Private myInput As String = String.Empty
    Private Shared ReadOnly maxInputLength As Integer = Console.BufferWidth - 4
#End Region

#Region "Events"
    Friend Event OnInput As EventHandler Implements ILogger.OnInput
#End Region

#Region "Properties"

    Friend Property Input As String Implements ILogger.Input
        Get
            Return myInput
        End Get
        Set(value As String)
            If Not Cloud.IsNoConsole Then
                Overwrite(Input.Length + 1, ">" & value)
                Console.CursorLeft = value.Length + 1
                myInput = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Sub New()
        If Not Cloud.IsNoConsole Then
            Console.Write(">")
            Call New Thread(AddressOf HandleInput) With {.IsBackground = True}.Start()
        End If
    End Sub

    Private Sub HandleInput()
        Dim inputKey As ConsoleKeyInfo

        Do
            inputKey = Console.ReadKey(True)

            Select Case inputKey.Key
                Case ConsoleKey.Enter
                    If Input.Length > 0 Then
                        Console.WriteLine()
                        RaiseEvent OnInput(Me, New EventArgs())
                        Input = String.Empty
                    End If
                Case ConsoleKey.Backspace
                    If Input.Length > 0 Then
                        Input = Left(Input, Input.Length - 1)

                    End If

                Case Else
                    If inputKey.Modifiers <> ConsoleModifiers.Control AndAlso inputKey.KeyChar <> Nothing Then
                        If Input.Length <= maxInputLength Then
                            myInput &= inputKey.KeyChar
                            Console.Write(inputKey.KeyChar)
                        End If
                    End If
            End Select
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Friend Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        If Not Cloud.IsNoConsole Then
            Dim output As String = String.Format("{0} [{1}] {2}",
                                                 Now.ToLongTimeString(),
                                                 priority.ToString().ToUpper(InvariantCulture),
                                                 str)
            Overwrite(Input.Length + 1, output)
            Console.Write(Environment.NewLine &
                          ">" & Input)
        End If
    End Sub

    Friend Sub LogEx(ex As Exception) Implements ILogger.LogEx
        Cloud.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled:" & Environment.NewLine &
                                                          "{1}" & Environment.NewLine &
                                                          "{2}",
                                                          ex.ToString(), ex.Message, ex.StackTrace))
    End Sub

    Private Shared Sub Overwrite(oldLength As Integer, newStr As String)
        Console.CursorLeft = 0
        Dim spaces As Integer = oldLength - newStr.Length
        If spaces > 0 Then
            Console.Write(newStr & Space(spaces))
        Else
            Console.Write(newStr)
        End If
    End Sub

    Private Sub Logger_OnInput(sender As Object, e As EventArgs) Handles Me.OnInput
        If Input.ToCharArray()(0) <> My.Settings.CommandChar Then
            myInput = My.Settings.CommandChar & "say " & Input
        End If

        'GlobalCommandManager.Value.InvokeConsoleCmd(Input, Me)
    End Sub

#End Region
End Class
