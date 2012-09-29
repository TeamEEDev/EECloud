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

        Dim root_delay As Integer = MinDelay
        While True
            Try
                Dim api_addr As [String] = LeApi
                Try
                    Me.mySocket = New MyTcpClient(LeApi)

                    Dim header As [String] = [String].Format("PUT /{0}/hosts/{1}/?realtime=1 HTTP/1.1" & vbCr & vbLf & vbCr & vbLf, Me.SubstituteAppSetting(ConfigKey), Me.SubstituteAppSetting(ConfigLocation))
                    Me.mySocket.Write(Ascii.GetBytes(header), 0, header.Length)
                Catch
                    Throw New IOException()
                End Try
                Return
            Catch
            End Try
            root_delay *= 2
            If root_delay > MaxDelay Then
                root_delay = MaxDelay
            End If
            Dim wait_for As Integer = root_delay + myRandom.[Next](root_delay)
            Try
                Thread.Sleep(wait_for)
            Catch
                Throw New ThreadInterruptedException()
            End Try
        End While
    End Sub

    Private Sub CloseConnection()
        If Me.mySocket IsNot Nothing Then
            Me.mySocket.Close()
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
        Dim is_full As Boolean = Not myQueue.TryAdd(data)

        If is_full Then
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

    Private Sub Shutdown()
        myThread.Interrupt()
        myStarted = False
    End Sub

    Private Function SubstituteAppSetting(key As String) As String
        Dim appSettings = ConfigurationManager.AppSettings
        If appSettings.HasKeys() AndAlso appSettings.AllKeys.Contains(key) Then
            Return appSettings(key)
        Else
            Return key
        End If
    End Function

    Private Class MyTcpClient
        Implements IDisposable
        Dim client As TcpClient
        Dim stream As Stream

        Friend Sub New(host As [String])
            Dim port As Integer = LePort
            client = New TcpClient(host, port)
            client.NoDelay = True
            Me.stream = client.GetStream()
        End Sub

        Friend Sub Write(buffer As Byte(), offset As Integer, count As Integer)
            Me.stream.Write(buffer, offset, count)
        End Sub

        Friend Sub Flush()
            Me.stream.Flush()
        End Sub

        Friend Sub Close()
            If Me.client IsNot Nothing Then
                Try
                    Me.client.Close()
                Catch
                End Try
            End If
            Me.client = Nothing
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    stream.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub

        Friend Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not Me.myDisposedValue Then
            If disposing Then
                If mySocket IsNot Nothing Then
                    mySocket.Dispose()
                End If
            End If
        End If
        Me.myDisposedValue = True
    End Sub
    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class