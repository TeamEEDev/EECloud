Public Class EEService
    Implements IEEService
    Private ReadOnly myConnection As New MySqlConnection(ConnStr)

    Sub New()
        myConnection.Open()
    End Sub

    Public Function GetSetting(key As String) As String Implements IEEService.GetSetting
        Using command As MySqlCommand = myConnection.CreateCommand()
            command.CommandText = "SELECT SettingValue FROM settings WHERE SettingKey = @SettingKey"
            command.Parameters.AddWithValue("@SettingKey", key)

            Return CType(command.ExecuteScalar(), String)
        End Using
    End Function

    Public Sub SetSetting(key As String, value As String) Implements IEEService.SetSetting
        If key IsNot Nothing Then
            Using command As MySqlCommand = myConnection.CreateCommand()
                command.CommandText = "INSERT INTO settings VALUES (@SettingKey, @SettingValue) ON DUPLICATE KEY UPDATE SettingValue = @SettingValue"
                command.Parameters.AddWithValue("@SettingKey", key)
                command.Parameters.AddWithValue("@SettingValue", value)

                command.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Public Function GetPlayerData(username As String) As UserData Implements IEEService.GetPlayerData
        If username IsNot Nothing Then
            Using command As MySqlCommand = myConnection.CreateCommand()
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
        Else
            Return Nothing
        End If
    End Function

    Public Function GetPlayerDatas(usernames() As String) As UserData() Implements IEEService.GetPlayerDatas
        If usernames IsNot Nothing AndAlso usernames.Length > 0 Then
            Dim userDatas(usernames.Length - 1) As UserData
            For i As Integer = 0 To usernames.Length - 1
                userDatas(i) = GetPlayerData(usernames(i))
            Next

            Return userDatas
        Else
            Return Nothing
        End If
    End Function

    Public Function GetPlayerDataRange(Optional offset As UInteger = 0, Optional limit As UInteger = 1000, Optional orderBy As String = "Username") As UserData() Implements IEEService.GetPlayerDataRange
        If limit > 0 Then
            limit = Math.Min(limit, CUInt(1000))
            If orderBy Is Nothing Then orderBy = "Username"

            Using command As MySqlCommand = myConnection.CreateCommand()
                command.CommandText = "SELECT * FROM playerData ORDER BY " & orderBy & " LIMIT @Limit OFFSET @Offset"
                command.Parameters.AddWithValue("@Limit", limit)
                command.Parameters.AddWithValue("@Offset", offset)

                Try
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim userDatas As New List(Of UserData)
                        Dim pointer As UInteger
                        While reader.Read() AndAlso limit > pointer
                            userDatas.Add(ParsePlayerData(reader))
                            pointer += CUInt(1)
                        End While

                        Return userDatas.ToArray()
                    End Using
                Catch ex As Exception
                    Return GetPlayerDataRange(offset, limit)
                End Try
            End Using
        Else
            Return Nothing
        End If
    End Function

    Private Shared ReadOnly AcceptedGroupIDs() As Short = {400, 300, 100, 0, -100, -200}

    Public Sub SetPlayerDataGroupID(username As String, groupID As Short) Implements IEEService.SetPlayerDataGroupID
        If Not AcceptedGroupIDs.Contains(groupID) Then
            Throw New Exception("Bad group ID. The value of groupID must be a short number contained by the AcceptedGroupIDs() array.")
        End If

        Using command As MySqlCommand = myConnection.CreateCommand()
            command.CommandText = "INSERT INTO playerData (Username, GroupID) VALUES (@Username, @GroupID) ON DUPLICATE KEY UPDATE GroupID = @GroupID"
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@GroupID", groupID)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub SetPlayerDataYoScrollWins(username As String, yoScrollWins As UShort) Implements IEEService.SetPlayerDataYoScrollWins
        Using command As MySqlCommand = myConnection.CreateCommand()
            command.CommandText = "INSERT INTO playerData (Username, YoScrollWins) VALUES (@Username, @YoScrollWins) ON DUPLICATE KEY UPDATE YoScrollWins = @YoScrollWins"
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@YoScrollWins", yoScrollWins)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub SetPlayerDataFTBreakerWins(username As String, ftBreakerWins As UShort) Implements IEEService.SetPlayerDataFTBreakerWins
        Using command As MySqlCommand = myConnection.CreateCommand()
            command.CommandText = "INSERT INTO playerData (Username, FTBreakerWins) VALUES (@Username, @FTBreakerWins) ON DUPLICATE KEY UPDATE FTBreakerWins = @FTBreakerWins"
            command.Parameters.AddWithValue("@Username", username)
            command.Parameters.AddWithValue("@FTBreakerWins", ftBreakerWins)

            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function GetFacts(factGroup As String) As String() Implements IEEService.GetFacts
        Using command As MySqlCommand = myConnection.CreateCommand()
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
    End Function

    Public Sub RemoveFact(factID As String) Implements IEEService.RemoveFact
        Try
            Using command As MySqlCommand = myConnection.CreateCommand()
                command.CommandText = "DELETE FROM facts WHERE FactID = @FactID"
                command.Parameters.AddWithValue("@FactID", factID)

                command.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

    Public Sub SetFact(factID As String, factGroup As String) Implements IEEService.SetFact
        Try
            Using command As MySqlCommand = myConnection.CreateCommand()
                command.CommandText = "INSERT INTO facts VALUES (@FactID, @FactGroup)"
                command.Parameters.AddWithValue("@FactID", factID)
                command.Parameters.AddWithValue("@FactGroup", factGroup)

                command.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

    Public Function CheckLicense(username As String, authKey As String) As Boolean Implements IEEService.CheckLicense
        Using command As MySqlCommand = myConnection.CreateCommand()
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
    End Function

    Public Function ParsePlayerData(reader As MySqlDataReader) As UserData
        If reader IsNot Nothing Then
            Return New UserData With {.Username = TryCastStr(reader.GetString(0)), _
                                      .GroupID = TryCastShort(reader.GetValue(1)), _
                                      .YoScrollWins = TryCastUShort(reader.GetValue(2)), _
                                      .FTBreakerWins = TryCastUShort(reader.GetValue(3))}
        Else
            Return Nothing
        End If
    End Function

    Public Function TryCastStr(input As Object) As String
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

    Public Function TryCastInt(input As Object) As Integer
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CInt(input)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function TryCastUInt(input As Object) As UInteger
        Try
            If input IsNot DBNull.Value AndAlso input IsNot Nothing Then
                Return CUInt(input)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function TryCastShort(input As Object) As Short
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

    Public Function TryCastUShort(input As Object) As UShort
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
