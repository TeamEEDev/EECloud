Module ModuleMain
    Dim myHost As EECloud.HostAPI.CloudHost

    Function Main() As Integer
        Application.Run(New EECloud.HostAPI.CloudApplicationContext)
        Console.ReadLine()
        Return 0
    End Function

End Module
