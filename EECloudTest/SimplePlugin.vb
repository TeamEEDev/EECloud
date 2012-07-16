Public Class SimplePlayer
    Inherits EECloud.API.CloudPlayer

End Class

Public Class SimplePlugin
    Inherits EECloud.API.CloudPlugin(Of SimplePlayer)


    Public Overrides Sub OnDisable()

    End Sub

    Public Overrides Sub OnEnable()

    End Sub
End Class
