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
                    Overwrite(False, PreTag & value)
                End SyncLock

                myInput = value
            End If
        End Set
    End Property

    Private ReadOnly Property ExtraInputLines As Integer
        Get
            Return (Input.Length + PreTagLength) \ Console.BufferWidth
        End Get
    End Property

    Private Property CurrentInputLineIndex As Integer

    Private ReadOnly Property LastInputLineMaxCursorLeft As Integer
        Get
            Return (Input.Length + PreTagLength) Mod Console.BufferWidth
        End Get
    End Property

    Private ReadOnly Property CursorLeftWithoutPreTag As Integer
        Get
            If CurrentInputLineIndex = 0 Then
                Return Console.CursorLeft - 2
            End If

            Return Console.CursorLeft
        End Get
    End Property

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
                    If CurrentInputLineIndex <> ExtraInputLines OrElse Console.CursorLeft <> LastInputLineMaxCursorLeft Then
                        'Insert text
                        Dim currentCursorLeft As Integer = Console.CursorLeft
                        Dim tmpCursorLeft As Integer = CursorLeftWithoutPreTag

                        Input = Input.Substring(0, tmpCursorLeft) & inputKey.KeyChar & Input.Substring(tmpCursorLeft)
                        'Overwrite(True, inputKey.KeyChar & myInput.Substring(tmpCursorLeft))

                        If currentCursorLeft <> Console.BufferWidth - 1 Then
                            Console.CursorLeft = currentCursorLeft + 1
                        Else
                            Console.CursorLeft = 0
                            Console.CursorTop += 1
                            CurrentInputLineIndex += 1
                        End If

                    Else
                        'Regular text input
                        myInput &= inputKey.KeyChar
                        Console.Write(inputKey.KeyChar)
                    End If

                    'Check the current input line
                    If Console.CursorLeft = 0 AndAlso LastInputLineMaxCursorLeft = 0 Then
                        CurrentInputLineIndex += 1
                    End If

                Else
                    Select Case inputKey.Key
                        Case ConsoleKey.Enter
                            If Input.Length > 0 Then
                                TriggerInput()
                            End If

                        Case ConsoleKey.Backspace
                            If Input.Length > 0 Then
                                If CurrentInputLineIndex <> 0 OrElse Console.CursorLeft > PreTagLength Then
                                    Dim currentCursorLeft As Integer = Console.CursorLeft
                                    Dim tmpCursorLeft As Integer = CursorLeftWithoutPreTag

                                    Input = Input.Substring(0, tmpCursorLeft - 1) & Input.Substring(tmpCursorLeft)

                                    If Console.CursorLeft <> 0 Then
                                        Console.CursorLeft = currentCursorLeft - 1
                                    Else 'CurrentInputLineIndex has to be reduced by 1
                                        Console.CursorLeft = Console.BufferWidth - 1
                                        Console.CursorTop -= 1
                                        CurrentInputLineIndex -= 1
                                    End If
                                End If
                            End If


                        Case ConsoleKey.LeftArrow
                            If Console.CursorLeft > PreTagLength OrElse (CurrentInputLineIndex <> 0 AndAlso Console.CursorLeft > 0) Then
                                Console.CursorLeft -= 1
                            ElseIf CurrentInputLineIndex <> 0 Then
                                Console.CursorTop -= 1
                                Console.CursorLeft = Console.BufferWidth - 1
                                CurrentInputLineIndex -= 1
                            End If

                        Case ConsoleKey.RightArrow
                            If Console.CursorLeft + 1 < Console.BufferWidth Then
                                If Console.CursorLeft + CurrentInputLineIndex * Console.BufferWidth < Input.Length + PreTagLength Then
                                    Console.CursorLeft += 1
                                End If
                            ElseIf ExtraInputLines <> CurrentInputLineIndex Then
                                Console.CursorLeft = 0
                                Console.CursorTop += 1
                                CurrentInputLineIndex += 1
                            End If

                            'TODO: ConsoleKey.UpArrow, ConsoleKey.DownArrow
                    End Select
                End If
            End SyncLock
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Private Sub TriggerInput()
        Console.Write(GetNewLineByCursorPos() & PreTag)

        Dim currentInput As String = Input
        myInput = String.Empty
        CurrentInputLineIndex = 0

        RaiseEvent OnInput(Me, currentInput)
    End Sub

    Private Shared Function GetNewLineByCursorPos()
        If Console.CursorLeft = 0 Then
            Return String.Empty
        End If

        Return Environment.NewLine
    End Function

    Friend Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        If Not Cloud.IsNoConsole Then
            Dim output As String = String.Format("{0} [{1}] {2}",
                                                 Now.ToLongTimeString(),
                                                 priority.ToString().ToUpper(InvariantCulture),
                                                 str)
            SyncLock myLockObj
                Overwrite(False, output)
                Console.CursorTop -= CurrentInputLineIndex
                Console.Write(GetNewLineByCursorPos() &
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

    Private Sub Overwrite(fromCurrentPos As Boolean, newStr As String, Optional setCursorLeft As Boolean = False)
        If Not fromCurrentPos Then
            Console.CursorTop -= CurrentInputLineIndex
            Console.CursorLeft = 0
        End If

        Dim currentCursorTop As String = Console.CursorTop
        Dim spaces As Integer = Console.BufferWidth - Console.CursorLeft +
                                Console.BufferWidth * CurrentInputLineIndex -
                                newStr.Length - 1

        If spaces > 0 Then
            Console.Write(newStr & Space(spaces))
        Else
            Console.Write(newStr)
        End If

        If setCursorLeft Then
            Console.CursorLeft = newStr.Length + PreTagLength
        Else
            Console.CursorTop = currentCursorTop
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
