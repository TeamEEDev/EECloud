Public Class EECloudPluginHost
    Inherits CloudPluginHost

    Private m_CloudManager As CloudManager
    Public Overrides ReadOnly Property CloudManager As CloudManager
        Get
            Return m_CloudManager
        End Get
    End Property

    Friend Sub New(PCloudManager As CloudManager)
        m_CloudManager = PCloudManager
    End Sub
End Class
