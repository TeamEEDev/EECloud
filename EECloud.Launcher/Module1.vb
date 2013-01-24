Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Threading

Module Module1
#Region "Unmanaged calls"

    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
    Public Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function GetWindowThreadProcessId(handle As IntPtr, ByRef processId As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")>
    Public Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Public Function SetConsoleCtrlHandler(handler As HandlerRoutine, add As Boolean) As Boolean
    End Function

#End Region

#Region "Fields"
    Public Handle As IntPtr = GetConsoleWindow()
    Public WithEvents NotifyIcon As New NotifyIcon With {.Icon = My.Resources.Icon, .Visible = True}

    Public TempNoAutoHide As Boolean
    Public LastRestart As Date
    Public RestartTry As Integer

    Const SW_HIDE As Integer = 0
    Const SW_SHOW As Integer = 5

    Public Delegate Function HandlerRoutine(ctrlType As CtrlTypes) As Boolean

    Public Enum CtrlTypes
        CTRL_C_EVENT = 0
        CTRL_BREAK_EVENT
        CTRL_CLOSE_EVENT
        CTRL_LOGOFF_EVENT = 5
        CTRL_SHUTDOWN_EVENT
    End Enum
#End Region

#Region "Properties"

    Private ReadOnly mySeparatorText As String = StrDup(Console.BufferWidth - 1, "-")
    Public ReadOnly Property SeparatorText As String
        Get
            Return mySeparatorText
        End Get
    End Property

    Private myConsoleVisible As Boolean = True
    Public Property ConsoleVisible As Boolean
        Get
            Return myConsoleVisible
        End Get
        Set(value As Boolean)
            If value Then
                ShowWindow(Handle, SW_SHOW)
            Else
                ShowWindow(Handle, SW_HIDE)
            End If

            myConsoleVisible = value
        End Set
    End Property

#End Region

#Region "Methods"

    Private myEECProcId As Integer
    Private ReadOnly myThisProcId As Integer = Process.GetCurrentProcess().Id

    Public Function ApplicationIsActivated() As Boolean
        Dim activatedHandle = GetForegroundWindow()
        If activatedHandle = IntPtr.Zero Then
            Return False
        End If

        Dim activeProcId As Integer
        GetWindowThreadProcessId(activatedHandle, activeProcId)

        Return activeProcId = myEECProcId OrElse activeProcId = myThisProcId
    End Function

    Sub Main()
        SetConsoleCtrlHandler(New HandlerRoutine(AddressOf ConsoleCtrlCheck), True)
        AddHandler NotifyIcon.Click,
            Sub()
                TempNoAutoHide = True
                ConsoleVisible = True
            End Sub

        Console.Title = "EECloud"
        Console.WriteLine("Welcome to EECloud.Launcher" & Environment.NewLine &
                          "Starting EECloud...")

        Do
            LastRestart = Now
            Console.WriteLine(SeparatorText)
            'Start process
            Using p = New Process()
                p.StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\EECloud.exe") With {.UseShellExecute = False}
                p.Start()
                myEECProcId = p.Id

                'Hide window as it looses focus
                Do Until p.HasExited
                    If TempNoAutoHide Then
                        If ApplicationIsActivated() Then
                            TempNoAutoHide = False
                        End If
                    ElseIf ConsoleVisible Then
                        If Not ApplicationIsActivated() Then
                            ConsoleVisible = False
                        End If
                    End If

                    Thread.Sleep(1000)
                Loop

                'Exit if it exists with a 0 exit code
                If p.ExitCode = 0 Then
                    Exit Sub
                End If
            End Using

            Console.WriteLine(Environment.NewLine & SeparatorText)

            'Wait if failing too often
            If Now.Subtract(LastRestart).TotalMinutes >= 1 Then
                RestartTry = 0
            Else
                Dim waitSecs As Integer = RestartTry << 1
                Console.WriteLine(String.Format("Restarting in {0} second(s)...", waitSecs))
                Thread.Sleep(waitSecs * 1000)
                RestartTry += 1
            End If

            'Restart
            Console.WriteLine("Restarting EECloud...")
        Loop
    End Sub

    Private Function ConsoleCtrlCheck(ctrlType As CtrlTypes) As Boolean
        'TODO: Wait for plugins to stop properly

        NotifyIcon.Dispose()

        Return False
    End Function

#End Region
End Module
