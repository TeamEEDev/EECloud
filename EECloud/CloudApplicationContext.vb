﻿Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        'Dim PluginsPath As String = My.Application.Info.DirectoryPath & "\Plugins"
        'If Not System.IO.Directory.Exists(PluginsPath) Then
        '    System.IO.Directory.CreateDirectory(PluginsPath)
        'End If

        'Dim ComponentsPath As String = My.Application.Info.DirectoryPath & "\Components"
        'If Not System.IO.Directory.Exists(ComponentsPath) Then
        '    System.IO.Directory.CreateDirectory(ComponentsPath)
        'End If
        Console.Write("                                    EECloud")
        Console.WriteLine()
        Console.Write("                        Made by Processor and Jojatekok")
        Console.WriteLine()

        Dim myHost = New EECloud.HostAPI.CloudHost(My.Application.Info.DirectoryPath)
    End Sub
End Class
