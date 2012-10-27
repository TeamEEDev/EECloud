﻿Friend NotInheritable Class PlayerManager (Of TPlayer As {Player, New})
    Implements IPlayerManager(Of TPlayer), IDisposable

#Region "Fields"
    Private WithEvents myInternalPlayerManager As InternalPlayerManager
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Public Event Join(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Join

    Public Event Leave(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Leave
#End Region

#Region "Properties"
    Private ReadOnly myIDDictionary As New Dictionary(Of Integer, TPlayer)
    Private ReadOnly myUsernameDictionary As New Dictionary(Of String, List(Of TPlayer))

    Friend ReadOnly Property Player(number As Integer) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            SyncLock myUsernameDictionary
                If myIDDictionary.ContainsKey(number) Then
                    Return myIDDictionary(number)
                Else
                    Return Nothing
                End If
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property Player(username As String) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            SyncLock myUsernameDictionary
                If myUsernameDictionary.ContainsKey(username) Then
                    Dim list As List(Of TPlayer) = myUsernameDictionary(username)
                    If list.Count > 0 Then
                        Return list(0)
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End SyncLock
        End Get
    End Property

    Friend ReadOnly Property GetPlayers As TPlayer() Implements IPlayerManager(Of TPlayer).GetPlayers
        Get
            Return myIDDictionary.Values.ToArray
        End Get
    End Property

    Private myCrown As TPlayer

    Friend ReadOnly Property Crown As TPlayer Implements IPlayerManager(Of TPlayer).Crown
        Get
            Return myCrown
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements IPlayerManager(Of TPlayer).Count
        Get
            Return myIDDictionary.Count
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(internalClient As InternalClient)
        myInternalPlayerManager = internalClient.InternalPlayerManager
        myConnection = internalClient.Connection
        myClient = internalClient

        For Each player1 As InternalPlayer In myInternalPlayerManager.Players.Values
            AddPlayer(player1)
        Next

        If myInternalPlayerManager.Crown IsNot Nothing Then
            myCrown = Player(myInternalPlayerManager.Crown.UserID)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnRemoveUser(sender As Object, e As LeftReceiveMessage) Handles myInternalPlayerManager.RemoveUser
        Dim player1 As TPlayer = Nothing

        SyncLock myIDDictionary
            If myIDDictionary.ContainsKey(e.UserID) Then
                player1 = myIDDictionary(e.UserID)
                myIDDictionary.Remove(e.UserID)

                SyncLock myUsernameDictionary
                    If myUsernameDictionary.ContainsKey(player1.Username) Then
                        Dim list As List(Of TPlayer) = myUsernameDictionary(player1.Username)
                        For Each item In From item1 In list Where item1.UserID = e.UserID
                            list.Remove(item)
                            Exit For
                        Next
                    End If
                End SyncLock
            End If
        End SyncLock

        If player1 IsNot Nothing Then
            RaiseEvent Leave(Me, player1)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnAddUser(sender As Object, e As InternalPlayer) Handles myInternalPlayerManager.AddUser
        AddPlayer(e)
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.ReceiveCrown
        myCrown = Player(e.UserID)
    End Sub

    Private Sub AddPlayer(internalPlayer As InternalPlayer)
        Dim player1 As TPlayer = Nothing

        SyncLock myIDDictionary
            If Not myIDDictionary.ContainsKey(internalPlayer.UserID) Then
                player1 = New TPlayer
                player1.SetupPlayer(internalPlayer, myClient.Chatter)
                myIDDictionary.Add(player1.UserID, player1)

                SyncLock myUsernameDictionary
                    If Not myUsernameDictionary.ContainsKey(player1.Username) Then
                        Dim list As New List(Of TPlayer)
                        list.Add(player1)
                        myUsernameDictionary.Add(player1.Username, list)
                    Else
                        myUsernameDictionary(player1.Username).Add(player1)
                    End If
                End SyncLock
            End If
        End SyncLock

        If player1 IsNot Nothing Then
            RaiseEvent Join(Me, player1)
        End If
    End Sub

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then

            End If

            myConnection = Nothing
            myInternalPlayerManager = Nothing
        End If
        myDisposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
