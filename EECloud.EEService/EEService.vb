﻿Friend Class EEService
    Implements IEEService, IDisposable

#Region "Properties"
    Private Shared ReadOnly myConnection As New Lazy(Of MySqlConnection)(Function() New MySqlConnection(MySQLConnStr))

    Private Shared ReadOnly Property Connection As MySqlConnection
        Get
            Return myConnection.Value
        End Get
    End Property

    Public ReadOnly Property ConnectionString As String Implements IEEService.ConnectionString
        Get
            Return MySQLConnStr
        End Get
    End Property
#End Region

#Region "Methods"

#Region "Settings"
    Friend Function GetSetting(key As String) As String Implements IEEService.GetSetting
        If String.IsNullOrWhiteSpace(key) Then
            Throw New ArgumentNullException("key")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT SettingValue FROM settings WHERE SettingKey = @SettingKey",
                                          Connection)
            command.Parameters.AddWithValue("@SettingKey", key)

            Return DirectCast(command.ExecuteScalar(), String)
        End Using
    End Function

    Friend Function GetSettingAsync(key As String) As Task(Of String) Implements IEEService.GetSettingAsync
        Return Task.Run(Of String)(Function() GetSetting(key))
    End Function


    Friend Function GetSettings(ParamArray keyList As String()) As Dictionary(Of String, String) Implements IEEService.GetSettings
        If keyList.Count = 0 Then
            Throw New ArgumentNullException("keyList")
        End If

        For i = 0 To keyList.Length - 1
            If String.IsNullOrWhiteSpace(keyList(i)) Then
                Throw New ArgumentNullException("keyList", "'KeyList()' mustn't contain empty or null values.")
            End If
        Next

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT SettingKey, SettingValue FROM settings WHERE SettingKey = @SettingKey0",
                                          Connection)
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
    End Function

    Friend Function GetSettingsAsync(ParamArray keyList As String()) As Task(Of Dictionary(Of String, String)) Implements IEEService.GetSettingsAsync
        Return Task.Run(Of Dictionary(Of String, String))(Function() GetSettings(keyList))
    End Function


    Friend Sub SetSetting(key As String, value As String) Implements IEEService.SetSetting
        If String.IsNullOrWhiteSpace(key) Then
            Throw New ArgumentNullException("key")
        End If
        If String.IsNullOrWhiteSpace(value) Then
            Throw New ArgumentNullException("value")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("INSERT INTO settings VALUES (@SettingKey, @SettingValue) ON DUPLICATE KEY UPDATE SettingValue = @SettingValue",
                                          Connection)
            command.Parameters.AddWithValue("@SettingKey", key)
            command.Parameters.AddWithValue("@SettingValue", value)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function SetSettingAsync(key As String, value As String) As Task Implements IEEService.SetSettingAsync
        Return Task.Run(Sub() SetSetting(key, value))
    End Function


    Friend Sub SetSettings(ParamArray keyValuePairs As KeyValuePair(Of String, String)()) Implements IEEService.SetSettings
        If keyValuePairs.Length = 0 Then
            Throw New ArgumentNullException("keyValuePairs")
        End If

        For i = 0 To keyValuePairs.Length - 1
            If String.IsNullOrWhiteSpace(keyValuePairs(i).Key) OrElse String.IsNullOrWhiteSpace(keyValuePairs(i).Value) Then
                Throw New ArgumentNullException("keyValuePairs", "'KeyValuePairs()' mustn't contain empty or null values.")
            End If
        Next

        ForceOpenConnection()

        Using command As New MySqlCommand(String.Empty, Connection)
            For i = 0 To keyValuePairs.Length - 1
                command.CommandText &= String.Format("INSERT INTO settings VALUES (@SettingKey{0}, @SettingValue{0}) ON DUPLICATE KEY UPDATE SettingValue = @SettingValue{0};", i)
                command.Parameters.AddWithValue("@SettingKey" & i, keyValuePairs(i).Key)
                command.Parameters.AddWithValue("@SettingValue" & i, keyValuePairs(i).Value)
            Next

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function SetSettingsAsync(ParamArray keyValuePairs As KeyValuePair(Of String, String)()) As Task Implements IEEService.SetSettingsAsync
        Return Task.Run(Sub() SetSettings(keyValuePairs))
    End Function
#End Region

#Region "PlayerDatas"
    Friend Function GetPlayerData(username As String) As UserData Implements IEEService.GetPlayerData
        If String.IsNullOrWhiteSpace(username) Then
            Throw New ArgumentNullException("username")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT * FROM playerData WHERE Username = @Username",
                                          Connection)
            command.Parameters.AddWithValue("@Username", username)

            Using reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    Return ParsePlayerData(reader)
                Else
                    Return Nothing
                End If
            End Using
        End Using
    End Function

    Friend Function GetPlayerDataAsync(username As String) As Task(Of UserData) Implements IEEService.GetPlayerDataAsync
        Return Task.Run(Of UserData)(Function() GetPlayerData(username))
    End Function


    Friend Function GetPlayerDatas(ParamArray usernames As String()) As Dictionary(Of String, UserData) Implements IEEService.GetPlayerDatas
        If usernames.Length = 0 Then
            Throw New ArgumentNullException("usernames")
        End If

        For i = 0 To usernames.Length - 1
            If String.IsNullOrWhiteSpace(usernames(i)) Then
                Throw New ArgumentNullException("usernames", "'Usernames()' mustn't contain empty or null values.")
            End If
        Next

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT * FROM playerData WHERE Username = @Username0",
                                          Connection)
            command.Parameters.AddWithValue("@Username0", usernames(0))

            For i = 1 To usernames.Length - 1
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
    End Function

    Friend Function GetPlayerDatasAsync(ParamArray usernames As String()) As Task(Of Dictionary(Of String, UserData)) Implements IEEService.GetPlayerDatasAsync
        Return Task.Run(Of Dictionary(Of String, UserData))(Function() GetPlayerDatas(usernames))
    End Function


    Friend Function GetPlayerDataRange(Optional offset As UInteger = 0,
                                       Optional limit As UInteger = 1000,
                                       Optional orderBy As String = "Username") As UserData() Implements IEEService.GetPlayerDataRange
        If Not limit > 0 Then
            Throw New ArgumentException("Limit must be bigger than 0.", "limit")
        End If

        limit = Math.Min(limit, 1000UI)
        If String.IsNullOrWhiteSpace(orderBy) Then orderBy = "Username"

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT * FROM playerData ORDER BY @OrderBy LIMIT @Limit OFFSET @Offset",
                                          Connection)
            command.Parameters.AddWithValue("@OrderBy", orderBy)
            command.Parameters.AddWithValue("@Limit", limit)
            command.Parameters.AddWithValue("@Offset", offset)

            Try
                Using reader As MySqlDataReader = command.ExecuteReader()
                    Dim userDatas As New List(Of UserData)
                    Dim pointer As UInteger
                    While reader.Read() AndAlso limit > pointer
                        userDatas.Add(ParsePlayerData(reader))
                        pointer += 1UI
                    End While

                    Return userDatas.ToArray()
                End Using
            Catch ex As Exception
                Throw New Exception("Unknown error", ex)
            End Try
        End Using
    End Function

    Friend Function GetPlayerDataRangeAsync(Optional offset As UInteger = 0,
                                            Optional limit As UInteger = 1000,
                                            Optional orderBy As String = "Username") As Task(Of UserData()) Implements IEEService.GetPlayerDataRangeAsync
        Return Task.Run(Of UserData())(Function() GetPlayerDataRange(offset, limit, orderBy))
    End Function


    Private Shared ReadOnly myAcceptedGroupIDs As Short() = {400, 300, 100, 0, -100, -200}

    Friend Sub SetPlayerDataGroupID(username As String, groupID As Short) Implements IEEService.SetPlayerDataGroupID
        If String.IsNullOrWhiteSpace(username) Then
            Throw New ArgumentNullException("username")
        End If
        If Not myAcceptedGroupIDs.Contains(groupID) Then
            Exit Sub
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("INSERT INTO playerData (Username, GroupID) VALUES (@Username, @GroupID) ON DUPLICATE KEY UPDATE GroupID = @GroupID",
                                          Connection)
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@GroupID", NumberToDbValue(groupID))

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function SetPlayerDataGroupIDAsync(username As String, groupID As Short) As Task Implements IEEService.SetPlayerDataGroupIDAsync
        Return Task.Run(Sub() SetPlayerDataGroupID(username, groupID))
    End Function


    Friend Sub SetPlayerDataWins(gameName As RegisteredGameName, username As String, wins As UShort) Implements IEEService.SetPlayerDataWins
        If String.IsNullOrWhiteSpace(username) Then
            Throw New ArgumentNullException("username")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand(String.Format("INSERT INTO playerData (Username, {0}Wins) VALUES (@Username, @Wins) ON DUPLICATE KEY UPDATE {0}Wins = @Wins",
                                                        gameName.ToString()),
                                          Connection)
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@Wins", NumberToDbValue(wins))

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function SetPlayerDataWinsAsync(gameName As RegisteredGameName, username As String, wins As UShort) As Task Implements IEEService.SetPlayerDataWinsAsync
        Return Task.Run(Sub() SetPlayerDataWins(gameName, username, wins))
    End Function
#End Region

#Region "Facts"
    Friend Function GetFacts(factGroup As String) As String() Implements IEEService.GetFacts
        If String.IsNullOrWhiteSpace(factGroup) Then
            Throw New ArgumentNullException("factGroup")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("SELECT FactID FROM facts WHERE FactGroup = @FactGroup",
                                          Connection)
            command.Parameters.AddWithValue("@FactGroup", factGroup)

            Dim items As New List(Of String)
            Using reader As MySqlDataReader = command.ExecuteReader()
                Do While reader.Read()
                    items.Add(reader.GetString(0))
                Loop
            End Using
            Return items.ToArray()
        End Using
    End Function

    Friend Function GetFactsAsync(factGroup As String) As Task(Of String()) Implements IEEService.GetFactsAsync
        Return Task.Run(Of String())(Function() GetFacts(factGroup))
    End Function


    Friend Sub SetFact(factID As String, factGroup As String) Implements IEEService.SetFact
        If String.IsNullOrWhiteSpace(factID) Then
            Throw New ArgumentNullException("factID")
        End If
        If String.IsNullOrWhiteSpace(factGroup) Then
            Throw New ArgumentNullException("factGroup")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("INSERT INTO facts VALUES (@FactID, @FactGroup)",
                                          Connection)
            command.Parameters.AddWithValue("@FactID", factID)
            command.Parameters.AddWithValue("@FactGroup", factGroup)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function SetFactAsync(factID As String, factGroup As String) As Task Implements IEEService.SetFactAsync
        Return Task.Run(Sub() SetFact(factID, factGroup))
    End Function


    Friend Sub RemoveFact(factID As String) Implements IEEService.RemoveFact
        If String.IsNullOrWhiteSpace(factID) Then
            Throw New ArgumentNullException("factID")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("DELETE FROM facts WHERE FactID = @FactID",
                                          Connection)
            command.Parameters.AddWithValue("@FactID", factID)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function RemoveFactAsync(factID As String) As Task Implements IEEService.RemoveFactAsync
        Return Task.Run(Sub() RemoveFact(factID))
    End Function
#End Region

#Region "Optimizations"
    Friend Sub OptimizeTable(tableName As String) Implements IEEService.OptimizeTable
        If String.IsNullOrWhiteSpace(tableName) Then
            Throw New ArgumentNullException("tableName")
        End If

        ForceOpenConnection()

        Using command As New MySqlCommand("OPTIMIZE TABLE @TableName",
                                          Connection)
            command.Parameters.AddWithValue("@TableName", tableName)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function OptimizeTableAsync(tableName As String) As Task Implements IEEService.OptimizeTableAsync
        Return Task.Run(Sub() OptimizeTable(tableName))
    End Function


    Friend Sub OptimizeTables(ParamArray tableNames As String()) Implements IEEService.OptimizeTables
        If tableNames.Count = 0 Then
            'Optimize all tables
            ForceOpenConnection()

            Using command As New MySqlCommand("SHOW TABLES",
                                              Connection)
                Dim items As New List(Of String)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    Do While reader.Read()
                        items.Add(reader.GetString(0))
                    Loop
                End Using

                tableNames = items.ToArray()
                If tableNames.Count = 0 Then
                    Throw New Exception("Couldn't find any tables in the MySQL database.")
                End If
            End Using

        Else
            'Optimize only the given tables
            If tableNames.Count = 0 Then
                Throw New ArgumentNullException("tableNames")
            End If

            For i = 0 To tableNames.Length - 1
                If String.IsNullOrWhiteSpace(tableNames(i)) Then
                    Throw New ArgumentNullException("tableNames", "'TableNames()' mustn't contain empty or null values.")
                End If
            Next

            ForceOpenConnection()
        End If

        Using command As New MySqlCommand("OPTIMIZE TABLE " & MySqlHelper.EscapeString(tableNames(0)),
                                          Connection)
            For i = 1 To tableNames.Length - 1
                command.CommandText &= ", " & MySqlHelper.EscapeString(tableNames(i))
            Next

            command.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function OptimizeTablesAsync(ParamArray tableNames As String()) As Task Implements IEEService.OptimizeTablesAsync
        Return Task.Run(Sub() OptimizeTables(tableNames))
    End Function
#End Region

#Region "Miscellaneous"
    Public Sub ForceOpenConnection() Implements IEEService.ForceOpenConnection
        If Connection.State = ConnectionState.Closed Then
            Connection.Open()
        End If
    End Sub

    Public Function ForceOpenConnectionAsync() As Task Implements IEEService.ForceOpenConnectionAsync
        Return Task.Run(Sub() ForceOpenConnection())
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


    Private Shared Function NumberToDbValue(input As Object) As Object
        If Equals(input, CObj(0)) Then
            Return DBNull.Value
        End If

        Return input
    End Function
#End Region

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then
                Connection.Dispose()
            End If
        End If
        myDisposedValue = True
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub

#End Region

End Class
