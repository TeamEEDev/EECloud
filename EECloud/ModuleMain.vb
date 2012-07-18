Module ModuleMain
    Dim myHost As EECloud.HostAPI.CloudHost

    Sub Main()
        myHost = New EECloud.HostAPI.CloudHost
        If myHost.ComponentManager.BlockManager IsNot Nothing Then
            Console.WriteLine("Things work, proof: " & myHost.ComponentManager.BlockManager.IsPortal(242) & ", " & myHost.ComponentManager.BlockManager.IsPortal(222))
        End If
        Console.ReadLine()
    End Sub
End Module
