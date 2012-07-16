Public MustInherit Class CloudPlugin
    Private myHost As Interfaces.CloudPluginHost
    Friend Sub AttemptSetup(Host As Interfaces.CloudPluginHost)
        If myHost Is Nothing Then
            myHost = Host
        End If
    End Sub

    Public MustOverride Sub OnEnable()
    Public MustOverride Sub OnDisable()
End Class
