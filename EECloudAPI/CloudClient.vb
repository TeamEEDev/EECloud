Imports EECloudAPI.EECloudAPI.Messages

Public MustInherit Class CloudClient
    Public LockObject As Object
#Region "Events"
    Public Class OnMessageEventArgs
        Inherits EventArgs

        Public Sub New(PMessage As PlayerIOClient.Message)
            Message = PMessage
        End Sub

        Public Message As PlayerIOClient.Message
    End Class

    Public Event OnMessage(sender As Object, e As OnMessageEventArgs)
    Public Event OnJoin(sender As Object, e As EventArgs)
    Public Event OnDisconnect(sender As Object, e As EventArgs)
#End Region

#Region "Methods"
    Private Connected As Boolean
    Public Sub Connect()
        SyncLock LockObject
            If Not Connected Then
                Connected = True
                'TODO: Do this for every message
                RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_Message))
                RegisterMessage("upgrade", GetType(Upgrade_Message))
                RegisterMessage("info", GetType(Info_Message))
                RegisterMessage("init", GetType(Init_Message))
            End If
        End SyncLock
    End Sub


    Private MessageDictionary As Dictionary(Of String, Type)
    Private Sub RegisterMessage(PType As String, PMessage As Type)
        If MessageDictionary.ContainsKey(PType) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PMessage.IsSubclassOf(GetType(Message)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit EECloudAPI.Messages.Message")
        Else
            MessageDictionary.Add(PType, PMessage)
        End If
    End Sub
#End Region
End Class
