Friend NotInheritable Class Connection(Of P As {Player, New})
    Inherits ConnectionBase
    Implements IConnection(Of P)

#Region "Fields"
    Private WithEvents myInternalConnection As ConnectionHandle

    Private myInternalChatter As InternalChatter
#End Region

#Region "Properties"
    Friend ReadOnly Property InternalChatter As InternalChatter
        Get
            Return myInternalConnection.InternalChatter
        End Get
    End Property

    Friend ReadOnly Property DefaultChatter As IChatter
        Get
            Return myInternalConnection.DefaultChatter
        End Get
    End Property

    Public Overrides ReadOnly Property WorldID As String
        Get
            Return myInternalConnection.WorldID
        End Get
    End Property

    Public Overrides ReadOnly Property World As World
        Get
            Return myInternalConnection.World
        End Get
    End Property

    Public Overrides ReadOnly Property IsMainConnection As Boolean
        Get
            Return myInternalConnection.IsMainConnection
        End Get
    End Property

    Public Overrides ReadOnly Property Connected As Boolean
        Get
            Return myInternalConnection.Connected
        End Get
    End Property

    Private myPlayersDictionary As New Dictionary(Of Integer, P)
    Public ReadOnly Property Players(number As Integer) As P Implements IConnection(Of P).Players
        Get
            If myPlayersDictionary.ContainsKey(number) Then
                Return myPlayersDictionary(number)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Players As IEnumerable(Of P) Implements IConnection(Of P).Players
        Get
            Try
                Return myPlayersDictionary.Values
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Private myCrown As P
    Public ReadOnly Property Crown As P Implements IConnection(Of P).Crown
        Get
            Return myCrown
        End Get
    End Property

    Friend ReadOnly Property DefaultConnection As Connection(Of Player)
        Get
            Return myInternalConnection.DefaultConnection
        End Get
    End Property

    Public ReadOnly Property Encryption As String Implements IConnection(Of P).Encryption
        Get
            Return myInternalConnection.Encryption
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(internalConnection As ConnectionHandle)
        myInternalConnection = internalConnection
    End Sub

    Private Sub myInternalConnection_OnAddUser(sender As Object, e As IPlayer) Handles myInternalConnection.OnAddUser
        If Not myPlayersDictionary.ContainsKey(e.UserID) Then
            Dim myPlayer As New P
            myPlayer.SetupPlayer(e)
            myPlayersDictionary.Add(e.UserID, myPlayer)
        End If
    End Sub



    Private Sub myInternalConnection_OnRemoveUser(sender As Object, e As Left_ReceiveMessage) Handles myInternalConnection.OnRemoveUser
        Try
            myPlayersDictionary.Remove(e.UserID)
        Catch
        End Try
    End Sub



    Public Overrides Sub Send(message As SendMessage)
        If Not RaiseSendEvent(message) Then
            myInternalConnection.Send(message)
        End If
    End Sub

    Public Sub Disconnect() Implements IConnection(Of P).Disconnect
        myInternalConnection.Disconnect()
    End Sub
#End Region
End Class
