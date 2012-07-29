<Plugin()>
Public Class Testplugin
    Inherits EEPlugin(Of EEPlayer)

    Public Overrides Sub OnDisable()
        Throw New Exception
    End Sub

    Public Overrides Sub OnEnable()
        Throw New Exception
    End Sub
End Class
