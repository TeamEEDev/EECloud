Public Class Init_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UsernameOwner As String '0
    Public ReadOnly WorldName As String '1
    Public ReadOnly Plays As Integer '2
    Public ReadOnly Encryption As String '3
    Public ReadOnly UserID As Integer '4
    Public ReadOnly SpawnX As Integer '5
    Public ReadOnly SpawnY As Integer '6
    Public ReadOnly Username As String '7
    Public ReadOnly CanEdit As Boolean '8
    Public ReadOnly IsOwner As Boolean '9
    Public ReadOnly SizeX As Integer '10
    Public ReadOnly SizeY As Integer '11
    Public ReadOnly IsTutorialRoom As Boolean '12

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UsernameOwner = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = CInt(message.GetString(2))
        Encryption = message.GetString(3)
        UserID = message.GetInteger(4)
        SpawnX = message.GetInteger(5)
        SpawnY = message.GetInteger(6)
        Username = message.GetString(7)
        CanEdit = message.GetBoolean(8)
        IsOwner = message.GetBoolean(9)
        SizeX = message.GetInteger(10)
        SizeY = message.GetInteger(11)
        IsTutorialRoom = message.GetBoolean(12)
    End Sub
End Class
