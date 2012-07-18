Public MustInherit Class CloudPlugin(Of CloudPlayer)
    Private myHost As CloudPluginHost
    Friend Sub AttemptSetup(Host As CloudPluginHost)
        If myHost Is Nothing Then
            myHost = Host
        End If
    End Sub

    Public MustOverride Sub OnEnable()
    Public MustOverride Sub OnDisable()
End Class
