Friend Class EEService
    Implements IEEService

    Public ReadOnly Property ConnectionString As String Implements IEEService.ConnectionString
        Get
            Return MySQLConnStr
        End Get
    End Property

    Friend Function GetSetting(key As String) As String Implements IEEService.GetSetting
        If StringIsNullOrEmpty(key) Then
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

    Friend Function GetSettings(ParamArray keyList() As String) As Dictionary(Of String, String) Implements IEEService.GetSettings
        If keyList Is Nothing OrElse keyList.Count < 1 Then
            Throw New ArgumentNullException("keyList", "'KeyList' can't be null, and its length must be 1 or more.")
        End If

        For i = 0 To keyList.Length - 1
            If StringIsNullOrEmpty(keyList(i)) Then
                Throw New ArgumentNullException("keyList", "'KeyList' mustn't contain empty or null values.")
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
                        Dim dic As New Dictionary(Of String, String)
                        While reader.Read()
                            dic.Add(reader.GetString(0), reader.GetString(1))
                        End While

                        Return dic
                    End Using
                Catch ex As Exception
                    Throw New Exception("Unknown error", ex)
                End Try
            End Using
        End Using
    End Function

    Friend Sub SetSetting(key As String, value As String) Implements IEEService.SetSetting
        If StringIsNullOrEmpty(key) Then
            Throw New ArgumentNullException("key")
        End If
        If StringIsNullOrEmpty(value) Then
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

    Friend Sub SetSettings(ParamArray keyValuePairs() As KeyValuePair(Of String, String)) Implements IEEService.SetSettings
        If keyValuePairs Is Nothing OrElse keyValuePairs.Length < 1 Then
            Throw New ArgumentNullException("keyValuePairs", "'KeyValuePairs' can't be null, and its length must be 1 or more.")
        End If

        For i = 0 To keyValuePairs.Length - 1
            If StringIsNullOrEmpty(keyValuePairs(i).Key) OrElse StringIsNullOrEmpty(keyValuePairs(i).Value) Then
                Throw New ArgumentNullException("keyValuePairs", "'KeyValuePairs' mustn't contain empty or null values.")
            End If
        Next

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()

            Using command As MySqlCommand = connection.CreateCommand()
                For i = 0 To keyValuePairs.Length - 1
                    command.CommandText &= String.Format("INSERT INTO settings VALUES (@SettingKey{0}, @SettingValue{0}) ON DUPLICATE KEY UPDATE SettingValue = @SettingValue{0};", i)
                    command.Parameters.AddWithValue("@SettingKey" & i, keyValuePairs(i).Key)
                    command.Parameters.AddWithValue("@SettingValue" & i, keyValuePairs(i).Value)
                Next

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Friend Function GetPlayerData(username As String) As UserData Implements IEEService.GetPlayerData
        If StringIsNullOrEmpty(username) Then
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

    Friend Function GetPlayerDatas(ParamArray usernames() As String) As Dictionary(Of String, UserData) Implements IEEService.GetPlayerDatas
        If usernames Is Nothing OrElse usernames.Length < 1 Then
            Throw New ArgumentNullException("usernames")
        End If

        Using connection As New MySqlConnection(MySQLConnStr)
            connection.Open()
            Using command As MySqlCommand = connection.CreateCommand()
                Dim usernamesCountMinus1 = usernames.Length - 1

                command.CommandText = "SELECT * FROM playerData WHERE Username = @Username0"
                command.Parameters.AddWithValue("@Username0", usernames(0))

                For i = 1 To usernamesCountMinus1
                    command.CommandText &= " OR Username = @Username" & i
                    command.Parameters.AddWithValue("@Username" & i, usernames(i))
                Next

                Try
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim dic As New Dictionary(Of String, UserData)

                        Dim currentUserData As UserData
                        While reader.Read()
                            currentUserData = ParsePlayerData(reader)
                            dic.Add(currentUserData.Username, currentUserData)
                        End While

                        Return dic
                    End Using
                Catch ex As Exception
                    Throw New Exception("Unknown error", ex)
                End Try
            End Using
        End Using
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
        If StringIsNullOrEmpty(username) Then
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
        If StringIsNullOrEmpty(username) Then
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
        If StringIsNullOrEmpty(username) Then
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
        If StringIsNullOrEmpty(factGroup) Then
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
                Return items.ToArray()
            End Using
        End Using
    End Function

    Friend Sub RemoveFact(factID As String) Implements IEEService.RemoveFact
        If StringIsNullOrEmpty(factID) Then
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
        If StringIsNullOrEmpty(factID) Then
            Throw New ArgumentNullException("factID")
        End If
        If StringIsNullOrEmpty(factGroup) Then
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
                command.CommandText = "SELECT AuthKey, InGameName FROM licenses WHERE Username = @Username"
                command.Parameters.AddWithValue("@Username", username)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(1) Then
                            Cloud.LicenseInGameName = reader.GetString(1)
                        Else
                            Cloud.LicenseInGameName = Nothing
                        End If

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

    Private Shared Function TryCastString(input As Object) As String
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CStr(input)
            Else
                Return String.Empty
            End If
        Catch
            Return String.Empty
        End Try
    End Function

    Private Shared Function TryCastShort(input As Object) As Short
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CShort(input)
            Else
                Return 0
            End If
        Catch
            Return 0
        End Try
    End Function

    Private Shared Function TryCastUShort(input As Object) As UShort
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CUShort(input)
            Else
                Return 0
            End If
        Catch
            Return 0
        End Try
    End Function
End Class
