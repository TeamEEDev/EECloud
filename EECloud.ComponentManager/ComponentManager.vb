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
End Class
