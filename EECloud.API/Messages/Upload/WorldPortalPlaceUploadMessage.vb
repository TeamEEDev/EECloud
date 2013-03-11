Imports PlayerIOClient

Public NotInheritable Class WorldPortalPlaceUploadMessage
    Inherits BlockPlaceUploadMessage

    Public ReadOnly PortalTarget As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlock, portalTarget As String)
        MyBase.New(layer, x, y, CType(block, Block))

        Me.PortalTarget = portalTarget
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsPortal(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(PortalTarget)
            Return message
        Else
            Return MyBase.GetMessage(game)
        End If
    End Function

    Friend Overrides Function SendMessage(client As IClient(Of Player)) As Boolean
        client.Connection.Send(Me)
        Return True
    End Function
End Class
