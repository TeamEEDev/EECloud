Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Threading

Module Module1
#Region "Unmanaged calls"

    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
    Private Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Sub SetForegroundWindow(ByVal handle As IntPtr)
    End Sub

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function GetWindowThreadProcessId(handle As IntPtr, ByRef processId As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Function SetConsoleCtrlHandler(handler As HandlerRoutine, add As Boolean) As Boolean
    End Function

#End Region

#Region "Fields"

    Private ReadOnly Handle As IntPtr = GetConsoleWindow()

    Private ReadOnly BgAppProcess As New Process() With {.StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\EECloud.exe") With {.UseShellExecute = False}}

    Public WithEvents TrayIcon As NotifyIcon
    Public WithEvents TrayMenu As New ContextMenuStrip()

    Private TempNoAutoHide As Boolean
    Private LastRestart As Date
    Private RestartTry As Integer


    Const SW_HIDE As Integer = 0
    Const SW_RESTORE As Integer = 9

    Private Delegate Function HandlerRoutine(ctrlType As CtrlTypes) As Boolean

    Private Enum CtrlTypes
        CTRL_C_EVENT = 0
        CTRL_BREAK_EVENT
        CTRL_CLOSE_EVENT
        CTRL_LOGOFF_EVENT = 5
        CTRL_SHUTDOWN_EVENT
    End Enum

#End Region

#Region "Properties"

    Private ReadOnly mySeparatorText As String = StrDup(Console.BufferWidth - 1, "-")
    Private ReadOnly Property SeparatorText As String
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
                ShowWindow(Handle, SW_RESTORE)
                SetForegroundWindow(GetConsoleWindow())
            Else
                ShowWindow(Handle, SW_HIDE)
            End If

            myConsoleVisible = value
        End Set
    End Property

#End Region

#Region "Methods"

    Private myBgAppProcId As Integer
    Private ReadOnly myThisProcId As Integer = Process.GetCurrentProcess().Id

    Private Sub Initialize()
        SetConsoleCtrlHandler(New HandlerRoutine(AddressOf ConsoleCtrlCheck), True)

        Dim trayIconThread As New Thread(AddressOf InitializeTrayIcon)
        trayIconThread.SetApartmentState(ApartmentState.STA)
        trayIconThread.Start()

        Console.Title = "EECloud"
        Console.WriteLine("Welcome to EECloud.Launcher" & Environment.NewLine &
                          "Starting EECloud...")
    End Sub

    Private Sub InitializeTrayIcon()
        TrayIcon = New NotifyIcon() With {.Icon = My.Resources.Icon,
                                          .Visible = True,
                                          .Text = "EECloud"}

        AddHandler TrayIcon.DoubleClick,
            Sub()
                TempNoAutoHide = True
                ConsoleVisible = True
            End Sub

        TrayMenu.Items.Add("Exit", Nothing, Sub() Close())
        TrayIcon.ContextMenuStrip = TrayMenu

        Application.Run()
    End Sub

    Sub Main()
        Initialize()

        Do
            LastRestart = Now
            Console.WriteLine(SeparatorText)

            'Start process
            BgAppProcess.Start()
            myBgAppProcId = BgAppProcess.Id

            'Hide window as it looses focus
            Do Until BgAppProcess.HasExited
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
            If BgAppProcess.ExitCode = 0 Then
                Close()
                End
            End If

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

    Sub Close()
        BgAppProcess.Close()
        BgAppProcess.Dispose()

        If TrayIcon IsNot Nothing Then
            TrayIcon.Dispose()
        End If
    End Sub

    Private Function ConsoleCtrlCheck(ctrlType As CtrlTypes) As Boolean
        Close()

        Return False
    End Function

    Function ApplicationIsActivated() As Boolean
        Dim activatedHandle = GetForegroundWindow()
        If activatedHandle = IntPtr.Zero Then
            Return False
        End If

        Dim activeProcId As Integer
        GetWindowThreadProcessId(activatedHandle, activeProcId)

        Return activeProcId = myBgAppProcId OrElse activeProcId = myThisProcId
    End Function

#End Region
End Module
