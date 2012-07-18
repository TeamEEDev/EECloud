<Export(GetType(IComponentManager))>
Public Class ComponentManager
    Implements EECloud.PluginAPI.IComponentManager

    <Import(GetType(IBlockManager))>
    Private m_BlockManager As IBlockManager
    Public ReadOnly Property BlockManager As IBlockManager Implements IComponentManager.BlockManager
        Get
            Return m_BlockManager
        End Get
    End Property

    <Import(GetType(IConnectionManager))>
    Private m_ConnectionManager As IConnectionManager
    Public ReadOnly Property ConnectionManager As IConnectionManager Implements IComponentManager.ConnectionManager
        Get
            Return m_ConnectionManager
        End Get
    End Property
End Class
