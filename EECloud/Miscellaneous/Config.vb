﻿Imports System.Configuration.ConfigurationManager

Friend NotInheritable Class Config
    Friend Const GameID As String = "everybody-edits-su9rn58o40itdbnw69plyw"
    Friend Const ServiceGameID As String = "tbp-b6p6m4ndauwncfvxbrq04q"
    Friend Const NormalRoom As String = "Everybodyedits"
    Friend Shared MySQLConnectionString As String = AppSettings("MYSQL_CONNECTION_STRING")
End Class
