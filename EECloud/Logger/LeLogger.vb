Imports System.Configuration
Imports System.Collections.Concurrent
Imports System.Linq
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Imports System.Text

Friend NotInheritable Class LeLogger
    Implements IDisposable

#Region "Fields"
    Private Const QueueSize As Integer = 32768
    Private Const LeApi As [String] = "api.logentries.com"
    Private Const LePort As Integer = 80
    Private Shared ReadOnly Utf8 As New UTF8Encoding()
    Private Shared ReadOnly Ascii As New ASCIIEncoding()
    Private Const MinDelay As Integer = 100
    Private Const MaxDelay As Integer = 10000
    Private Const ConfigKey As [String] = "LOGENTRIES_ACCOUNT_KEY"
    Private Const ConfigLocation As [String] = "LOGENTRIES_LOCATION"
    Private ReadOnly myRandom As New Random()

    Private mySocket As MyTcpClient = Nothing
    Private ReadOnly myThread As Thread
    Private myStarted As Boolean = False
    Private ReadOnly myQueue As BlockingCollection(Of Byte())
#End Region

#Region "Methods"
    Friend Sub New()
        myQueue = New BlockingCollection(Of Byte())(QueueSize)

        myThread = New Thread(New ThreadStart(AddressOf RunLoop))
        myThread.Name = "Logentries logger"
        myThread.IsBackground = True
    End Sub

    Private Sub ReopenConnection()
        CloseConnection()

        Dim rootDelay As Integer = MinDelay
        While True
            Try
                Try
                    mySocket = New MyTcpClient(LeApi)

                    Dim header As [String] = [String].Format("PUT /{0}/hosts/{1}/?realtime=1 HTTP/1.1" & vbCr & vbLf & vbCr & vbLf, SubstituteAppSetting(ConfigKey), SubstituteAppSetting(ConfigLocation))
                    mySocket.Write(Ascii.GetBytes(header), 0, header.Length)
                Catch
                    Throw New IOException()
                End Try
                Return
            Catch
            End Try
            rootDelay *= 2
            If rootDelay > MaxDelay Then
                rootDelay = MaxDelay
            End If
            Dim waitFor As Integer = rootDelay + myRandom.[Next](rootDelay)
            Try
                Thread.Sleep(waitFor)
            Catch
                Throw New ThreadInterruptedException()
            End Try
        End While
    End Sub

    Private Sub CloseConnection()
        If mySocket IsNot Nothing Then
            mySocket.Close()
        End If
    End Sub

    Private Sub RunLoop()
        Try
            ReopenConnection()

            While True
                Dim data As Byte() = myQueue.Take()
                While True
                    Try
                        mySocket.Write(data, 0, data.Length)
                        mySocket.Flush()
                    Catch e As IOException
                        ReopenConnection()
                        Continue While
                    End Try
                    Exit While
                End While
            End While
        Catch e As ThreadInterruptedException
        End Try

        CloseConnection()
    End Sub

    Private Sub AddLine(line As [String])
        Dim data As Byte() = Utf8.GetBytes(line & ControlChars.Lf)
        Dim isFull As Boolean = Not myQueue.TryAdd(data)

        If isFull Then
            myQueue.Take()
            myQueue.TryAdd(data)
        End If
    End Sub

    Private Function CheckCredentials() As Boolean
        Dim appSettings = ConfigurationManager.AppSettings
        If Not appSettings.AllKeys.Contains(ConfigKey) OrElse Not appSettings.AllKeys.Contains(ConfigLocation) Then
            Return False
        End If
        If appSettings(ConfigKey) = "" OrElse appSettings(ConfigLocation) = "" Then
            Return False
        End If

        Return True
    End Function

    Sub Write(str As String)
        If Not CheckCredentials() Then
            Return
        End If
        If Not myStarted Then
            myThread.Start()
            myStarted = True
        End If

        AddLine(str)

        Try
            Dim excep As [String] = str
            If excep.Length > 0 Then
                excep = excep.Replace(vbLf, Chr(&H2028))
                AddLine(excep)
            End If
        Catch

        End Try
    End Sub

    Private Function SubstituteAppSetting(key As String) As String
        Dim appSettings = ConfigurationManager.AppSettings
        If appSettings.HasKeys() AndAlso appSettings.AllKeys.Contains(key) Then
            Return appSettings(key)
        Else
            Return key
        End If
    End Function

    Private NotInheritable Class MyTcpClient
        Implements IDisposable
        Dim myClient As TcpClient
        ReadOnly myStream As Stream

        Friend Sub New(host As [String])
            Const port As Integer = LePort
            myClient = New TcpClient(host, port)
            myClient.NoDelay = True
            myStream = myClient.GetStream()
        End Sub

        Friend Sub Write(buffer As Byte(), offset As Integer, count As Integer)
            myStream.Write(buffer, offset, count)
        End Sub

        Friend Sub Flush()
            myStream.Flush()
        End Sub

        Friend Sub Close()
            If myClient IsNot Nothing Then
                Try
                    myClient.Close()
                Catch
                End Try
            End If
            myClient = Nothing
        End Sub

#Region "IDisposable Support"
        Private myDisposedValue As Boolean ' To detect redundant calls

        Private Sub Dispose(disposing As Boolean)
            If Not myDisposedValue Then
                If disposing Then
                    myStream.Dispose()
                End If
            End If
            myDisposedValue = True
        End Sub

        Friend Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class
#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then
                If mySocket IsNot Nothing Then
                    mySocket.Dispose()
                End If
            End If
        End If
        myDisposedValue = True
    End Sub
    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region
End Class