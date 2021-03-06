﻿Public Class BlockPlaceEventArgs
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myX As Integer

    Public ReadOnly Property X As Integer
        Get
            Return myX
        End Get
    End Property

    Private ReadOnly myY As Integer

    Public ReadOnly Property Y As Integer
        Get
            Return myY
        End Get
    End Property

    Private ReadOnly myLayer As Layer

    Public ReadOnly Property Layer As Layer
        Get
            Return myLayer
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(x As Integer, y As Integer, layer As Layer)
        myX = x
        myY = y
        myLayer = layer
    End Sub

#End Region

End Class
