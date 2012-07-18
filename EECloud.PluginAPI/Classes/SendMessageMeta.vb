Public Class SendMessageMeta
    Private m_Encryption As String
    Public ReadOnly Property Encryption As String
        Get
            Return m_Encryption
        End Get
    End Property

    Private m_BlockManager As IBlockManager
    Public ReadOnly Property BlockManager As IBlockManager
        Get
            Return m_BlockManager
        End Get
    End Property

    Sub New(Encryption As String, BlockManager As IBlockManager)
        m_Encryption = Encryption
    End Sub
End Class
