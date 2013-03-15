﻿Friend Class EEService
    Implements IEEService

    Public ReadOnly Property ConnectionString As String Implements IEEService.ConnectionString
        Get
            Return MySQLConnStr
        End Get
    End Property

    Friend Function GetSetting(key As String) As String Implements IEEService.GetSetting
        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentNullException("key")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT SettingValue FROM settings WHERE SettingKey = @SettingKey"
                command.Parameters.AddWithValue("@SettingKey", key)

                Return DirectCast(command.ExecuteScalar(), String)
            End Using
        End Using
    End Function

    Friend Function GetSettings(ParamArray keyList() As String) As KeyValuePair(Of String, String)() Implements IEEService.GetSettings
        If keyList Is Nothing OrElse keyList.Count < 0 Then
            Throw New ArgumentNullException("keyList", "KeyList can't be null, and its length must be 1 or more.")
        End If

        For i = 0 To keyList.Length - 1
            If String.IsNullOrEmpty(keyList(i)) Then
                Throw New ArgumentNullException("keyList", "KeyList mustn't contain empty or null values.")
            End If
        Next

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT SettingKey, SettingValue FROM settings WHERE SettingKey = @SettingKey0"
                command.Parameters.AddWithValue("@SettingKey0", keyList(0))

                For i = 1 To keyList.Length - 1
                    command.CommandText &= " OR SettingKey = @SettingKey" & i
                    command.Parameters.AddWithValue("@SettingKey" & i, keyList(i))
                Next

                Try
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim settings As New List(Of KeyValuePair(Of String, String))
                        While reader.Read()
                            settings.Add(New KeyValuePair(Of String, String)(reader.GetString(0), reader.GetString(1)))
                        End While

                        Return settings.ToArray()
                    End Using
                Catch ex As Exception
                    Throw New Exception("Unknown error", ex)
                End Try
            End Using
        End Using
    End Function

    Friend Sub SetSetting(key As String, value As String) Implements IEEService.SetSetting
        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentNullException("key")
        End If
        If String.IsNullOrEmpty(value) Then
            Throw New ArgumentNullException("value")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "INSERT INTO settings VALUES (@SettingKey, @SettingValue) ON DUPLICATE KEY UPDATE SettingValue = @SettingValue"
                command.Parameters.AddWithValue("@SettingKey", key)
                command.Parameters.AddWithValue("@SettingValue", value)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Function GetPlayerData(username As String) As UserData Implements IEEService.GetPlayerData
        If String.IsNullOrEmpty(username) Then
            Throw New ArgumentNullException("username")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()
            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT * FROM playerData WHERE Username = @Username"
                command.Parameters.AddWithValue("@Username", username)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Return ParsePlayerData(reader)
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        End Using
    End Function

    Friend Function GetPlayerDatas(usernames() As String) As UserData() Implements IEEService.GetPlayerDatas
        If usernames Is Nothing OrElse usernames.Length < 1 Then
            Throw New ArgumentNullException("usernames")
        End If

        Dim userDatas(usernames.Length - 1) As UserData
        For i As Integer = 0 To usernames.Length - 1
            userDatas(i) = GetPlayerData(usernames(i))
        Next
        Return userDatas
    End Function

    Friend Function GetPlayerDataRange(Optional offset As UInteger = 0, Optional limit As UInteger = 1000, Optional orderBy As String = "Username") As UserData() Implements IEEService.GetPlayerDataRange
        If Not limit > 0 Then
            Throw New ArgumentException("Limit must be bigger than 0.", "limit")
        End If

        limit = Math.Min(limit, 1000)
        If orderBy Is Nothing Then orderBy = "Username"

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT * FROM playerData ORDER BY @OrderBy LIMIT @Limit OFFSET @Offset"
                command.Parameters.AddWithValue("@OrderBy", orderBy)
                command.Parameters.AddWithValue("@Limit", limit)
                command.Parameters.AddWithValue("@Offset", offset)

                Try
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim userDatas As New List(Of UserData)
                        Dim pointer As UInteger
                        While reader.Read() AndAlso limit > pointer
                            userDatas.Add(ParsePlayerData(reader))
                            pointer += 1
                        End While

                        Return userDatas.ToArray()
                    End Using
                Catch ex As Exception
                    Throw New Exception("Unknown error", ex)
                End Try
            End Using
        End Using
    End Function

    Private Shared ReadOnly myAcceptedGroupIDs() As Short = {400, 300, 100, 0, -100, -200}

    Friend Sub SetPlayerDataGroupID(username As String, groupID As Short) Implements IEEService.SetPlayerDataGroupID
        If String.IsNullOrEmpty(username) Then
            Throw New ArgumentNullException("username")
        End If
        If Not myAcceptedGroupIDs.Contains(groupID) Then
            Exit Sub
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "INSERT INTO playerData (Username, GroupID) VALUES (@Username, @GroupID) ON DUPLICATE KEY UPDATE GroupID = @GroupID"
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@GroupID", groupID)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Sub SetPlayerDataYoScrollWins(username As String, yoScrollWins As UShort) Implements IEEService.SetPlayerDataYoScrollWins
        If String.IsNullOrEmpty(username) Then
            Throw New ArgumentNullException("username")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "INSERT INTO playerData (Username, YoScrollWins) VALUES (@Username, @YoScrollWins) ON DUPLICATE KEY UPDATE YoScrollWins = @YoScrollWins"
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@YoScrollWins", yoScrollWins)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Sub SetPlayerDataFTBreakerWins(username As String, ftBreakerWins As UShort) Implements IEEService.SetPlayerDataFTBreakerWins
        If String.IsNullOrEmpty(username) Then
            Throw New ArgumentNullException("username")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "INSERT INTO playerData (Username, FTBreakerWins) VALUES (@Username, @FTBreakerWins) ON DUPLICATE KEY UPDATE FTBreakerWins = @FTBreakerWins"
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@FTBreakerWins", ftBreakerWins)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Function GetFacts(factGroup As String) As String() Implements IEEService.GetFacts
        If String.IsNullOrEmpty(factGroup) Then
            Throw New ArgumentNullException("factGroup")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT FactID FROM facts WHERE FactGroup = @FactGroup"
                command.Parameters.AddWithValue("@FactGroup", factGroup)

                Dim items As New List(Of String)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    Do While reader.Read()
                        items.Add(reader.GetString(0))
                    Loop
                End Using
                Return items.ToArray
            End Using
        End Using
    End Function

    Friend Sub RemoveFact(factID As String) Implements IEEService.RemoveFact
        If String.IsNullOrEmpty(factID) Then
            Throw New ArgumentNullException("factID")
        End If

        Try
            Using connection As New MySqlConnection(MySQLConnStr)
                connection.Open()

                Using command As MySqlCommand = connection.CreateCommand()
                    command.CommandText = "DELETE FROM facts WHERE FactID = @FactID"
                    command.Parameters.AddWithValue("@FactID", factID)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Friend Sub SetFact(factID As String, factGroup As String) Implements IEEService.SetFact
        If String.IsNullOrEmpty(factID) Then
            Throw New ArgumentNullException("factID")
        End If
        If String.IsNullOrEmpty(factGroup) Then
            Throw New ArgumentNullException("factGroup")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "INSERT INTO facts VALUES (@FactID, @FactGroup)"
                command.Parameters.AddWithValue("@FactID", factID)
                command.Parameters.AddWithValue("@FactGroup", factGroup)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Function CheckLicense(username As String, authKey As String) As Boolean Implements IEEService.CheckLicense
        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                command.CommandText = "SELECT authKey FROM licenses WHERE Username = @Username"
                command.Parameters.AddWithValue("@Username", username)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Return reader.GetString(0) = authKey
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        End Using
    End Function

    Private Shared Function ParsePlayerData(reader As MySqlDataReader) As UserData
        If reader Is Nothing Then
            Throw New ArgumentNullException("reader")
        End If

        Return New UserData With {.Username = reader.GetString(0),
            .GroupID = TryCastShort(reader.GetValue(1)),
            .YoScrollWins = TryCastUShort(reader.GetValue(2)),
            .FTBreakerWins = TryCastUShort(reader.GetValue(3))}
    End Function

    Private Shared Function TryCastStr(input As Object) As String
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CStr(input)
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Shared Function TryCastShort(input As Object) As Short
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CShort(input)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Shared Function TryCastUShort(input As Object) As UShort
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CUShort(input)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
