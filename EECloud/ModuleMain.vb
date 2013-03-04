﻿Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Forms

Module ModuleMain

#Region "Methods"

#Region "Startup"

    Sub Main()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AppDomain_AssemblyResolve
        CheckForUpdates()
        Host.EECloud.RunDesktopMode()
    End Sub

#End Region

#Region "Assembly refrences"

    Private Function AppDomain_AssemblyResolve(sender As Object, e As ResolveEventArgs) As Assembly
        Dim assemblyName As String = e.Name.Split(","c)(0)
        Try
            Return Assembly.LoadFile(My.Application.Info.DirectoryPath & "\Plugins\" & assemblyName & ".dll")
        Catch
            Return Nothing
        End Try
    End Function

#End Region

#Region "Updates"

    Private Async Sub CheckForUpdates()
        Try
            Using webClient As New WebClient() 'My.Application.Info.Version
                Dim version As String = Await webClient.DownloadStringTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/Version.txt"))

                Using form As New Form() With {.TopMost = True}
                    If New Version(version).CompareTo(New Version(0, 0, 0, 0)) > 0 AndAlso MessageBox.Show(form,
                                                                                                               String.Format("An update is available (Version {0}). Do you want to update now?", version),
                                                                                                               "Update available",
                                                                                                               MessageBoxButtons.YesNo,
                                                                                                               MessageBoxIcon.Information) = DialogResult.Yes Then
                        'Download
                        Await webClient.DownloadFileTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/EECloud.Setup.msi"), My.Application.Info.DirectoryPath & "\EECloud.msi")

                        'Notify user
                        MessageBox.Show(form,
                                        "The update has been downloaded and it's ready to be installed. Press OK to start updating!",
                                        "Update ready",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)

                        'Write a batch file
                        Using writer As New StreamWriter(My.Application.Info.DirectoryPath & "\Update.bat")
                            writer.WriteLine("start /w EECloud.msi")
                            writer.WriteLine("del EECloud.msi")
                            writer.WriteLine("start EECloud.Launcher.exe")
                            writer.WriteLine("del %0")
                        End Using

                        'Start the batch file
                        Call New Process() With
                        {
                            .StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\Update.bat") With
                                {
                                    .UseShellExecute = False,
                                    .CreateNoWindow = True,
                                    .RedirectStandardOutput = True
                                }
                        }.Start()

                        'Exit
                        End
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to check for updates: " & Environment.NewLine & ex.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region

#End Region
End Module
