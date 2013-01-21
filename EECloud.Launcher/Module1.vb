﻿Imports System.Runtime.InteropServices
Imports System.Windows.Forms
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

#End Region

#Region "Fields"
    Const SW_HIDE As Integer = 0
    Const SW_SHOW As Integer = 5

    Public WithEvents NotifyIcon As New NotifyIcon With {.Icon = My.Resources.Icon, .Visible = True}
    Public Handle As IntPtr = GetConsoleWindow()
    Public TempNoAutoHide As Boolean
#End Region

#Region "Properties"

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
        AddHandler NotifyIcon.Click,
            Sub()
                TempNoAutoHide = True
                ConsoleVisible = True
            End Sub

        Console.Title = "EECloud Launcher"
        Console.WriteLine("Welcome to EECloud.Launcher")
        Console.WriteLine("Starting EECloud...")
        Do
            Console.WriteLine("---------------------------------------------------")
            'Start Process
            Dim p = New Process()
            p.StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "/EECloud.exe") With {.UseShellExecute = False}
            p.Start()
            myEECProcId = p.Id

            'Hide Window as it looses focus
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

                Threading.Thread.Sleep(1000)
            Loop

            'Exit if it exists with a 0 exit code
            If p.ExitCode = 0 Then
                Exit Sub
            End If

            'Restart 
            Console.WriteLine("---------------------------------------------------")
            Console.WriteLine("Restarting EECloud...")
        Loop
    End Sub

#End Region
End Module