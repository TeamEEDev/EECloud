Imports System.Threading

Friend NotInheritable Class Logger
    Implements ILogger

#Region "Fields"

    Private Const PreTag As String = "> "
    Private Const PreTagLength As Integer = 2

    Private Shared ReadOnly MaxCursorLeft As Integer = Console.BufferWidth - 1

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
                    Overwrite(False, PreTag & value, True)
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

    Private myCurrentInputLineIndex As Integer
    Private Property CurrentInputLineIndex As Integer
        Get
            Return myCurrentInputLineIndex
        End Get
        Set(value As Integer)
            Console.CursorTop += value - myCurrentInputLineIndex
            myCurrentInputLineIndex = value
        End Set
    End Property

    Private ReadOnly Property LastInputLineMaxCursorLeft As Integer
        Get
            Return (Input.Length + PreTagLength) Mod Console.BufferWidth
        End Get
    End Property

    Private ReadOnly Property CursorLeftWithoutPreTag As Integer
        Get
            If CurrentInputLineIndex = 0 Then
                Return Console.CursorLeft - PreTagLength
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
                    If CurrentInputLineIndex = ExtraInputLines AndAlso Console.CursorLeft = LastInputLineMaxCursorLeft Then
                        'Regular text input
                        myInput &= inputKey.KeyChar
                        Console.Write(inputKey.KeyChar)

                    Else
                        'Insert text
                        Dim currentCursorLeft As Integer = Console.CursorLeft

                        myInput = myInput.Substring(0, CursorLeftWithoutPreTag) &
                                  inputKey.KeyChar &
                                  myInput.Substring(CursorLeftWithoutPreTag)
                        Overwrite(True, myInput.Substring(CursorLeftWithoutPreTag))

                        If currentCursorLeft <> MaxCursorLeft Then
                            Console.CursorLeft = currentCursorLeft + 1
                        Else
                            CurrentInputLineIndex += 1
                            Console.CursorLeft = 0
                        End If
                    End If

                    'Check the current input line
                    If Console.CursorLeft = 0 Then
                        myCurrentInputLineIndex += 1
                    End If

                ElseIf Input.Length <> 0 Then
                    Select Case inputKey.Key
                        Case ConsoleKey.Enter
                            TriggerInput()

                        Case ConsoleKey.Backspace
                            If CurrentInputLineIndex <> 0 OrElse Console.CursorLeft > PreTagLength Then
                                Dim currentCursorLeft As Integer = Console.CursorLeft
                                Dim tmpCharIndex As Integer = CurrentInputLineIndex * Console.BufferWidth +
                                                              currentCursorLeft - PreTagLength

                                Input = Input.Substring(0, tmpCharIndex - 1) & Input.Substring(tmpCharIndex)

                                If Console.CursorLeft <> 0 Then
                                    Console.CursorLeft = currentCursorLeft - 1
                                Else 'CurrentInputLineIndex has to be reduced by 1
                                    CurrentInputLineIndex -= 1
                                    Console.CursorLeft = MaxCursorLeft
                                End If
                            End If

                            'TODO: ConsoleKey.LeftArrow, ConsoleKey.RightArrow
                            'Case ConsoleKey.LeftArrow
                            '    If Console.CursorLeft > PreTagLength OrElse (CurrentInputLineIndex <> 0 AndAlso Console.CursorLeft <> 0) Then
                            '        Console.CursorLeft -= 1
                            '    ElseIf CurrentInputLineIndex <> 0 Then
                            '        CurrentInputLineIndex -= 1
                            '        Console.CursorLeft = MaxCursorLeft
                            '    End If

                            'Case ConsoleKey.RightArrow
                            '    If Console.CursorLeft <> MaxCursorLeft Then
                            '        If Console.CursorLeft + CurrentInputLineIndex * Console.BufferWidth < Input.Length + PreTagLength Then
                            '            Console.CursorLeft += 1
                            '        End If
                            '    ElseIf CurrentInputLineIndex <> ExtraInputLines Then
                            '        CurrentInputLineIndex += 1
                            '        Console.CursorLeft = 0
                            '    End If

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
        myCurrentInputLineIndex = 0

        RaiseEvent OnInput(Me, currentInput)
    End Sub

    Private Function GetNewLineByCursorPos() As String
        If LastInputLineMaxCursorLeft = 0 Then
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
                Dim currentCursorLeft As Integer = Console.CursorLeft

                Overwrite(False, output)
                Console.CursorTop -= CurrentInputLineIndex
                Console.Write(GetNewLineByCursorPos() &
                              PreTag & Input)

                Console.CursorLeft = currentCursorLeft
            End SyncLock
        End If
    End Sub

    Friend Sub LogEx(ex As Exception) Implements ILogger.LogEx
        Log(LogPriority.Error, String.Format("{0} was unhandeled:" & Environment.NewLine &
                                             "{1}" & Environment.NewLine &
                                             "{2}",
                                             ex.ToString(), ex.Message, ex.StackTrace))
    End Sub

    Private Sub Overwrite(fromCurrentPos As Boolean, newStr As String, Optional reSetCursorPos As Boolean = False)
        Dim extraLinesToOverwrite As Integer
        If Not fromCurrentPos Then
            Console.CursorTop -= CurrentInputLineIndex
            Console.CursorLeft = 0
            extraLinesToOverwrite = ExtraInputLines
        Else
            extraLinesToOverwrite = ExtraInputLines - CurrentInputLineIndex
        End If

        Dim spaces As Integer = MaxCursorLeft - Console.CursorLeft +
                                Console.BufferWidth * extraLinesToOverwrite -
                                newStr.Length

        If spaces > 0 Then
            Console.Write(newStr & Space(spaces))
        Else
            Console.Write(newStr)
        End If

        If reSetCursorPos Then
            Console.CursorTop -= extraLinesToOverwrite - CurrentInputLineIndex
            Console.CursorLeft = newStr.Length Mod Console.BufferWidth
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
