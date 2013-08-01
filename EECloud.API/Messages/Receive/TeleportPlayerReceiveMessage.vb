Imports PlayerIOClient

Public NotInheritable Class TeleportPlayerReceiveMessage
    Inherits ReceiveMessage

    'this.connection.addMessageHandler("teleport", function (param1:Message, param2:int, param3:Number, param4:Number) : void
    '        {
    '            var _loc_5:Player = null;
    '            if (param2 == myid)
    '            {
    '                player.setPosition(param3, param4);
    '            }
    '            else
    '            {
    '                _loc_5 = players[param2] as Player;
    '                if (_loc_5)
    '                {
    '                    _loc_5.setPosition(param3, param4);
    '                }
    '            }
    '            return;
    '        }

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly PlayerPosX As Integer
    '2
    Public ReadOnly PlayerPosY As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        PlayerPosX = message.GetInteger(1)
        PlayerPosY = message.GetInteger(2)
    End Sub

    Public ReadOnly Property BlockX As Integer
        Get
            Return PlayerPosX + 8 >> 4
        End Get
    End Property

    Public ReadOnly Property BlockY As Integer
        Get
            Return PlayerPosY + 8 >> 4
        End Get
    End Property
End Class
