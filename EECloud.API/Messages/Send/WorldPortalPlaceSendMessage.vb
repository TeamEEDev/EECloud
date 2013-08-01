Imports PlayerIOClient

Public NotInheritable Class WorldPortalPlaceSendMessage
    Inherits BlockPlaceSendMessage

    Public ReadOnly WorldPortalTarget As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As WorldPortalBlock, worldPortalTarget As String)
        MyBase.New(layer, x, y, DirectCast(block, Block))

        Me.WorldPortalTarget = worldPortalTarget
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsWorldPortal(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(WorldPortalTarget)
            Return message
        Else
            Return MyBase.GetMessage(game)
        End If
    End Function
End Class
