Friend Class EEService
    Implements IEEService, IDisposable

#Region "Properties"
    Private ReadOnly myMySqlService As MySqlService
    Private ReadOnly mySQLiteService As SQLiteService

    Private Property UseMySql As Boolean

    Private ReadOnly myMySqlConnStr As String
    Public ReadOnly Property MySqlConnectionString As String Implements IEEService.MySqlConnectionString
        Get
            Return myMySqlConnStr
        End Get
    End Property
#End Region

#Region "Methods"

#Region "Creation"

    Friend Sub New(mySqlConnStr As String)
        If Not String.IsNullOrWhiteSpace(mySqlConnStr) Then
            myMySqlConnStr = mySqlConnStr
            myMySqlService = New MySqlService(mySqlConnStr)
            UseMySql = True
        Else
            mySQLiteService = New SQLiteService()
        End If
    End Sub

#End Region

#Region "Settings"
    Friend Function GetSetting(key As String) As String Implements IEEService.GetSetting
        If UseMySql Then
            Return myMySqlService.GetSetting(key)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetSetting(key)
        End If
    End Function

    Friend Function GetSettingAsync(key As String) As Task(Of String) Implements IEEService.GetSettingAsync
        Return Task.Run(Of String)(Function() GetSetting(key))
    End Function


    Friend Function GetSettings(ParamArray keyList As String()) As Dictionary(Of String, String) Implements IEEService.GetSettings
        If UseMySql Then
            Return myMySqlService.GetSettings(keyList)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetSettings(keyList)
        End If
    End Function

    Friend Function GetSettingsAsync(ParamArray keyList As String()) As Task(Of Dictionary(Of String, String)) Implements IEEService.GetSettingsAsync
        Return Task.Run(Of Dictionary(Of String, String))(Function() GetSettings(keyList))
    End Function


    Friend Sub SetSetting(key As String, value As String) Implements IEEService.SetSetting
        If UseMySql Then
            myMySqlService.SetSetting(key, value)
        Else 'If UseSQLite Then
            mySQLiteService.SetSetting(key, value)
        End If
    End Sub

    Friend Function SetSettingAsync(key As String, value As String) As Task Implements IEEService.SetSettingAsync
        Return Task.Run(Sub() SetSetting(key, value))
    End Function


    Friend Sub SetSettings(ParamArray keyValuePairs As KeyValuePair(Of String, String)()) Implements IEEService.SetSettings
        If UseMySql Then
            myMySqlService.SetSettings(keyValuePairs)
        Else 'If UseSQLite Then
            mySQLiteService.SetSettings(keyValuePairs)
        End If
    End Sub

    Friend Function SetSettingsAsync(ParamArray keyValuePairs As KeyValuePair(Of String, String)()) As Task Implements IEEService.SetSettingsAsync
        Return Task.Run(Sub() SetSettings(keyValuePairs))
    End Function
#End Region

#Region "PlayerDatas"
    Friend Function GetPlayerData(username As String) As UserData Implements IEEService.GetPlayerData
        If UseMySql Then
            Return myMySqlService.GetPlayerData(username)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetPlayerData(username)
        End If
    End Function

    Friend Function GetPlayerDataAsync(username As String) As Task(Of UserData) Implements IEEService.GetPlayerDataAsync
        Return Task.Run(Of UserData)(Function() GetPlayerData(username))
    End Function


    Friend Function GetPlayerDatas(ParamArray usernames As String()) As Dictionary(Of String, UserData) Implements IEEService.GetPlayerDatas
        If UseMySql Then
            Return myMySqlService.GetPlayerDatas(usernames)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetPlayerDatas(usernames)
        End If
    End Function

    Friend Function GetPlayerDatasAsync(ParamArray usernames As String()) As Task(Of Dictionary(Of String, UserData)) Implements IEEService.GetPlayerDatasAsync
        Return Task.Run(Of Dictionary(Of String, UserData))(Function() GetPlayerDatas(usernames))
    End Function


    Friend Function GetPlayerDataRange(Optional offset As UInteger = 0,
                                       Optional limit As UInteger = 1000,
                                       Optional orderBy As String = "Username") As UserData() Implements IEEService.GetPlayerDataRange
        If UseMySql Then
            Return myMySqlService.GetPlayerDataRange(offset, limit, orderby)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetPlayerDataRange(offset, limit, orderby)
        End If
    End Function

    Friend Function GetPlayerDataRangeAsync(Optional offset As UInteger = 0,
                                            Optional limit As UInteger = 1000,
                                            Optional orderBy As String = "Username") As Task(Of UserData()) Implements IEEService.GetPlayerDataRangeAsync
        Return Task.Run(Of UserData())(Function() GetPlayerDataRange(offset, limit, orderBy))
    End Function


    Private Shared ReadOnly myAcceptedGroupIDs As Short() = {400, 300, 100, 0, -100, -200}

    Friend Sub SetPlayerDataGroupID(username As String, groupID As Short) Implements IEEService.SetPlayerDataGroupID
        If UseMySql Then
            myMySqlService.SetPlayerDataGroupID(username, groupID)
        Else 'If UseSQLite Then
            mySQLiteService.SetPlayerDataGroupID(username, groupID)
        End If
    End Sub

    Friend Function SetPlayerDataGroupIDAsync(username As String, groupID As Short) As Task Implements IEEService.SetPlayerDataGroupIDAsync
        Return Task.Run(Sub() SetPlayerDataGroupID(username, groupID))
    End Function


    Friend Sub SetPlayerDataWins(gameName As RegisteredGameName, username As String, wins As UShort) Implements IEEService.SetPlayerDataWins
        If UseMySql Then
            myMySqlService.SetPlayerDataWins(gameName, username, wins)
        Else 'If UseSQLite Then
            mySQLiteService.SetPlayerDataWins(gameName, username, wins)
        End If
    End Sub

    Friend Function SetPlayerDataWinsAsync(gameName As RegisteredGameName, username As String, wins As UShort) As Task Implements IEEService.SetPlayerDataWinsAsync
        Return Task.Run(Sub() SetPlayerDataWins(gameName, username, wins))
    End Function
#End Region

#Region "Facts"
    Friend Function GetFacts(factGroup As String) As String() Implements IEEService.GetFacts
        If UseMySql Then
            Return myMySqlService.GetFacts(factGroup)
        Else 'If UseSQLite Then
            Return mySQLiteService.GetFacts(factGroup)
        End If
    End Function

    Friend Function GetFactsAsync(factGroup As String) As Task(Of String()) Implements IEEService.GetFactsAsync
        Return Task.Run(Of String())(Function() GetFacts(factGroup))
    End Function


    Friend Sub SetFact(factID As String, factGroup As String) Implements IEEService.SetFact
        If UseMySql Then
            myMySqlService.SetFact(factID, factGroup)
        Else 'If UseSQLite Then
            mySQLiteService.SetFact(factID, factGroup)
        End If
    End Sub

    Friend Function SetFactAsync(factID As String, factGroup As String) As Task Implements IEEService.SetFactAsync
        Return Task.Run(Sub() SetFact(factID, factGroup))
    End Function


    Friend Sub RemoveFact(factID As String) Implements IEEService.RemoveFact
        If UseMySql Then
            myMySqlService.RemoveFact(factID)
        Else 'If UseSQLite Then
            mySQLiteService.RemoveFact(factID)
        End If
    End Sub

    Friend Function RemoveFactAsync(factID As String) As Task Implements IEEService.RemoveFactAsync
        Return Task.Run(Sub() RemoveFact(factID))
    End Function
#End Region

#Region "Optimizations"
    Friend Sub OptimizeTable(tableName As String) Implements IEEService.OptimizeTable
        If UseMySql Then
            myMySqlService.OptimizeTable(tableName)
        End If
    End Sub

    Friend Function OptimizeTableAsync(tableName As String) As Task Implements IEEService.OptimizeTableAsync
        Return Task.Run(Sub() OptimizeTable(tableName))
    End Function


    Friend Sub OptimizeTables(ParamArray tableNames As String()) Implements IEEService.OptimizeTables
        If UseMySql Then
            myMySqlService.OptimizeTables(tableNames)
        End If
    End Sub

    Friend Function OptimizeTablesAsync(ParamArray tableNames As String()) As Task Implements IEEService.OptimizeTablesAsync
        Return Task.Run(Sub() OptimizeTables(tableNames))
    End Function
#End Region

#Region "Miscellaneous"
    Public Sub ForceOpenConnection() Implements IEEService.ForceOpenConnection
        If UseMySql Then
            myMySqlService.ForceOpenConnection()
        Else 'If UseSQLite Then
            mySQLiteService.ForceOpenConnection()
        End If
    End Sub

    Public Function ForceOpenConnectionAsync() As Task Implements IEEService.ForceOpenConnectionAsync
        Return Task.Run(Sub() ForceOpenConnection())
    End Function


    Public Sub CreateDefaultMySqlTables() Implements IEEService.CreateDefaultMySqlTables
        If UseMySql Then
            myMySqlService.CreateDefaultTables()
        End If
    End Sub

    Public Function CreateDefaultMySqlTablesAsync() As Task Implements IEEService.CreateDefaultMySqlTablesAsync
        Return Task.Run(Sub() CreateDefaultMySqlTables())
    End Function
#End Region

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then
                If UseMySql Then
                    myMySqlService.Dispose()
                Else 'If UseSQLite Then
                    mySQLiteService.Dispose()
                End If
            End If
        End If
        myDisposedValue = True
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose, IEEService.Dispose
        Dispose(True)
    End Sub

#End Region

End Class
