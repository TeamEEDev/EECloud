Module ModuleMain
    Dim myHost As EECloud.HostAPI.CloudHost

    Function Main() As Integer
        Dim PluginsPath As String = My.Application.Info.DirectoryPath & "\Plugins"
        If Not System.IO.Directory.Exists(PluginsPath) Then
            System.IO.Directory.CreateDirectory(PluginsPath)
        End If

        Dim ComponentsPath As String = My.Application.Info.DirectoryPath & "\Components"
        If Not System.IO.Directory.Exists(ComponentsPath) Then
            System.IO.Directory.CreateDirectory(ComponentsPath)
        End If
        myHost = New EECloud.HostAPI.CloudHost(ComponentsPath)
        Console.ReadLine()
        Return 0
    End Function

End Module
