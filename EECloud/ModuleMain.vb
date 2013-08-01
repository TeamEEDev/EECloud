Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Forms

Module ModuleMain

#Region "Methods"

#Region "Startup"

    Sub Main()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AppDomain_AssemblyResolve
        CheckForUpdates()

        Dim restart As Boolean

        'Cmd arguments
        For i = My.Application.CommandLineArgs.Count - 1 To 0 Step -1
            If My.Application.CommandLineArgs(i).ToLowerInvariant() = "-restart" Then
                restart = True
            End If
        Next

        Host.EECloud.RunDesktopMode(restart)
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
            Using webClient As New WebClient()
                Dim newVersionString As String = Await webClient.DownloadStringTaskAsync(New Uri("http://dl.dropboxusercontent.com/u/13946635/EECloud/Version.txt"))
                Dim newVersionComparable As New Version(newVersionString)

                If newVersionComparable.CompareTo(My.Application.Info.Version) > 0 Then
                    Dim setupDownload As Task = webClient.DownloadFileTaskAsync(New Uri("http://dl.dropboxusercontent.com/u/13946635/EECloud/EECloud.Setup.msi"), My.Application.Info.DirectoryPath & "\Update.msi")

                    If newVersionComparable.Revision = 0 Then
                        newVersionString = Left(newVersionString, newVersionString.Length - 2)
                    End If

                    Using form As New Form() With {.TopMost = True}
                        If MessageBox.Show(form,
                                           String.Format("An update is available (Version {0}). Do you want to update now?", newVersionString),
                                           "Update available",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Information) = DialogResult.Yes Then

                            If Not setupDownload.IsCompleted Then
                                'Finish downloading the installer
                                setupDownload.Wait()

                                'Notify user
                                MessageBox.Show(form,
                                                "The update has been downloaded and it's ready to be installed. Press OK to start updating!",
                                                "Update ready",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information)
                            End If

                            'Write a batch file
                            Using writer As New StreamWriter(My.Application.Info.DirectoryPath & "\Updater.bat")
                                writer.Write("START /WAIT Update.msi" & Environment.NewLine &
                                             "DEL /F /Q Update.msi" & Environment.NewLine &
                                             "START EECloud.Launcher.exe" & Environment.NewLine &
                                             "DEL /F /Q %0")
                            End Using

                            'Start the batch file
                            Call New Process() With
                            {
                                .StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\Updater.bat") With
                                    {
                                        .UseShellExecute = False,
                                        .CreateNoWindow = True
                                    }
                            }.Start()

                            'Exit
                            End

                        Else
                            webClient.CancelAsync()
                            File.Delete(My.Application.Info.DirectoryPath & "\Update.msi")
                        End If
                    End Using
                End If
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
