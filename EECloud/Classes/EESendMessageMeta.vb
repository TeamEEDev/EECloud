Public Class EESendMessageMeta
    Inherits SendMessageMeta

    Private m_Encryption As String
    Public Overrides ReadOnly Property Encryption As String
        Get
            Return m_Encryption
        End Get
    End Property

    Private m_BlockManager As BlockManager
    Public Overrides ReadOnly Property BlockManager As BlockManager
        Get
            Return m_BlockManager
        End Get
    End Property

    Sub New(Encryption As String, BlockManager As BlockManager)
        m_Encryption = Encryption
    End Sub
End Class
