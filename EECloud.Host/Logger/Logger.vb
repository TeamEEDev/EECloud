Imports System.Threading

Friend NotInheritable Class Logger
    Implements ILogger

#Region "Fields"

    Private Const PreTag As String = "> "
    Private Const PreTagLength As Integer = 2

    Private Shared ReadOnly MaxCharsOfFirstLine As Integer = Console.BufferWidth - PreTagLength

    Private ReadOnly myLockObj As New Object()

#End Region

#Region "Events"

    Friend Event OnInput As EventHandler(Of String) Implements ILogger.OnInput

#End Region

#Region "Properties"

    Private myInput As String = String.Empty

    Private Property Input As String
        Get
            Return myInput
        End Get
        Set(value As String)
            If Not Cloud.IsNoConsole Then
                SyncLock myLockObj
                    Overwrite(False, PreTag & value, False)
                End SyncLock

                myInput = value
            End If
        End Set
    End Property

    Private ReadOnly Property InputLines As Integer
        Get
            Return (Input.Length + PreTagLength) \ Console.BufferWidth + 1
        End Get
    End Property

    Private Property CurrentInputLine As Integer

#End Region

#Region "Methods"

    Sub New()
        If Not Cloud.IsNoConsole Then
            Console.Write(PreTag)
            Call New Thread(AddressOf HandleInput) With {.IsBackground = True}.Start()
        End If
    End Sub

    Private Sub HandleInput()
        Dim inputKey As ConsoleKeyInfo

        Do
            inputKey = Console.ReadKey(True)

            SyncLock myLockObj
                If Not Char.IsControl(inputKey.KeyChar) Then
                    'Regular text input
                    myInput &= inputKey.KeyChar
                    Console.Write(inputKey.KeyChar)

                    'Check the current input line
                    If Console.CursorLeft = 0 Then
                        CurrentInputLine += 1
                    End If

                Else
                    Select Case inputKey.Key
                        Case ConsoleKey.Enter
                            If Input.Length > 0 Then
                                ResetInput()
                            End If

                        Case ConsoleKey.Backspace
                            If Input.Length > 0 Then
                                If CurrentInputLine <> 0 OrElse Console.CursorLeft > PreTagLength Then
                                    Dim currentCursorLeft As Integer = Console.CursorLeft

                                    Dim realCursorLeft As Integer = Console.CursorLeft
                                    If CurrentInputLine = 0 Then
                                        realCursorLeft -= 2
                                    End If

                                    Input = Input.Substring(0, realCursorLeft - 1) & Input.Substring(realCursorLeft)

                                    If Console.CursorLeft <> 0 Then
                                        Console.CursorLeft = currentCursorLeft - 1
                                    Else 'CurrentInputLine has to be changed
                                        Console.CursorLeft = Console.BufferWidth - 1
                                        Console.CursorTop -= 1
                                        CurrentInputLine -= 1
                                    End If
                                End If
                            End If


                        Case ConsoleKey.LeftArrow
                            If Console.CursorLeft > PreTagLength OrElse (CurrentInputLine <> 0 AndAlso Console.CursorLeft > 0) Then
                                Console.CursorLeft -= 1
                            ElseIf CurrentInputLine <> 0 Then
                                Console.CursorTop -= 1
                                Console.CursorLeft = Console.BufferWidth - 1
                                CurrentInputLine -= 1
                            End If

                        Case ConsoleKey.RightArrow
                            If Console.CursorLeft + 1 < Console.BufferWidth Then
                                If Console.CursorLeft + CurrentInputLine * Console.BufferWidth < Input.Length + PreTagLength Then
                                    Console.CursorLeft += 1
                                End If
                            ElseIf InputLines <> CurrentInputLine + 1 Then
                                Console.CursorLeft = 0
                                Console.CursorTop += 1
                                CurrentInputLine += 1
                            End If

                            'TODO: ConsoleKey.UpArrow, ConsoleKey.DownArrow
                    End Select
                End If
            End SyncLock
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Private Sub ResetInput()
        Console.Write(Environment.NewLine & PreTag)

        Dim storedInput As String = Input
        myInput = String.Empty
        CurrentInputLine = 0

        RaiseEvent OnInput(Me, storedInput)
    End Sub

    Friend Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        If Not Cloud.IsNoConsole Then
            Dim output As String = String.Format("{0} [{1}] {2}",
                                                 Now.ToLongTimeString(),
                                                 priority.ToString().ToUpper(InvariantCulture),
                                                 str)
            SyncLock myLockObj
                Overwrite(False, output, False)
                Console.CursorTop -= CurrentInputLine
                Console.Write(Environment.NewLine &
                              PreTag & Input)
            End SyncLock
        End If
    End Sub

    Friend Sub LogEx(ex As Exception) Implements ILogger.LogEx
        Log(LogPriority.Error, String.Format("{0} was unhandeled:" & Environment.NewLine &
                                             "{1}" & Environment.NewLine &
                                             "{2}",
                                             ex.ToString(), ex.Message, ex.StackTrace))
    End Sub

    Private Sub Overwrite(fromCurrentPos As Boolean, newStr As String, Optional setCursorPos As Boolean = True)
        If Not fromCurrentPos Then
            Console.CursorTop -= CurrentInputLine
            Console.CursorLeft = 0
        End If

        Dim spaces As Integer = Console.BufferWidth - Console.CursorLeft +
                                Console.BufferWidth * CurrentInputLine -
                                newStr.Length - 1
        If spaces > 0 Then
            Console.Write(newStr & Space(spaces))
        Else
            Console.Write(newStr)
        End If

        If setCursorPos Then
            Console.CursorLeft = newStr.Length + PreTagLength
        End If
    End Sub

    Private Sub Logger_OnInput(sender As Object, e As String) Handles Me.OnInput
        If e.ToCharArray()(0) <> My.Settings.CommandChar Then
            e = My.Settings.CommandChar & "say " & e
        End If

        GlobalCommandManager.Value.InvokeConsoleCmd(e, Me)
    End Sub

#End Region

End Class
