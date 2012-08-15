﻿Public Class SendMessageHandle(Of T As SendMessage)
    Friend ReadOnly Property Message As T
        Get
            Try
                Return myInternalHandle.myMessage
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsSent As Boolean
        Get
            Return myInternalHandle Is Nothing
        End Get
    End Property

    Private myInternalHandle As InternalHandle
    Public Sub Send()
        If myInternalHandle IsNot Nothing Then
            myInternalHandle.Send()
            myInternalHandle = Nothing
        Else
            Throw New ApplicationException("The current message is already sent")
        End If
    End Sub

    Friend Sub New(internalHandle As InternalHandle)
        Me.myInternalHandle = internalHandle
        internalHandle.AddHandle()
    End Sub

    Friend Class InternalHandle
        Friend myMessage As T
        Private myHandleCount As Integer
        Private myInternalConnection As IInternalConnection

        Friend Sub Send()
            myHandleCount -= 1
            If myHandleCount = 0 Then
                myInternalConnection.Send(myMessage)
                myMessage = Nothing
                myInternalConnection = Nothing
            End If
        End Sub

        Friend Sub AddHandle()
            myHandleCount += 1
        End Sub

        Friend Sub New(message As T, internalConnection As IInternalConnection)
            Me.myMessage = message
            Me.myInternalConnection = internalConnection
        End Sub
    End Class
End Class