Public Class EESendMessageMeta
    Inherits SendMessageMeta

    Private m_Encryption As String
    Public Overrides ReadOnly Property Encryption As String
        Get
            Return m_Encryption
        End Get
    End Property
    Sub New(Encryption As String)
        m_Encryption = Encryption
    End Sub
End Class
