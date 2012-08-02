' Copyright (c) 2010-2012 Logentries, Jlizard
' 
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without 
' modification, are permitted provided that the following conditions 
' are met:
' 
' * Redistributions of source code must retain the above copyright notice, 
'   this list of conditions and the following disclaimer. 
' 
' * Redistributions in binary form must reproduce the above copyright notice,
'   this list of conditions and the following disclaimer in the documentation
'   and/or other materials provided with the distribution. 
' 
' * Neither the name of Logentries nor the names of its 
'   contributors may be used to endorse or promote products derived from this
'   software without specific prior written permission. 
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
' IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
' ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
' LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
' CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
' SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
' CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
' ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
' THE POSSIBILITY OF SUCH DAMAGE.
' 
' Mark Lacomber <marklacomber@gmail.com>
' Viliam Holub <vilda@logentries.com>

Imports System.Configuration
Imports System.Collections.Concurrent
Imports System.Diagnostics
Imports System.Linq
Imports System.Web
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Imports System.Text

Public NotInheritable Class LeLogger
    Implements IDisposable

    Public Shared ReadOnly QUEUE_SIZE As Integer = 32768
    Shared ReadOnly LE_API As [String] = "api.logentries.com"
    Shared ReadOnly LE_PORT As Integer = 80
    Shared ReadOnly UTF8 As New UTF8Encoding()
    Shared ReadOnly ASCII As New ASCIIEncoding()
    Shared ReadOnly MIN_DELAY As Integer = 100
    Shared ReadOnly MAX_DELAY As Integer = 10000
    Shared ReadOnly CONFIG_KEY As [String] = "LOGENTRIES_ACCOUNT_KEY"
    Shared ReadOnly CONFIG_LOCATION As [String] = "LOGENTRIES_LOCATION"
    ReadOnly random As New Random()

    Private Socket As MyTcpClient = Nothing
    Public Thread As Thread
    Public Started As Boolean = False
    Public Queue As BlockingCollection(Of Byte())

    Public Sub New()
        Queue = New BlockingCollection(Of Byte())(QUEUE_SIZE)

        Thread = New Thread(New ThreadStart(AddressOf RunLoop))
        Thread.Name = "Logentries logger"
        Thread.IsBackground = True
    End Sub

    Private Sub ReopenConnection()
        CloseConnection()

        Dim root_delay As Integer = MIN_DELAY
        While True
            Try
                Dim api_addr As [String] = LE_API
                Try
                    Me.Socket = New MyTcpClient(LE_API)

                    Dim header As [String] = [String].Format("PUT /{0}/hosts/{1}/?realtime=1 HTTP/1.1" & vbCr & vbLf & vbCr & vbLf, Me.SubstituteAppSetting(CONFIG_KEY), Me.SubstituteAppSetting(CONFIG_LOCATION))
                    Me.Socket.Write(ASCII.GetBytes(header), 0, header.Length)
                Catch
                    Throw New IOException()
                End Try
                Return
            Catch
            End Try
            root_delay *= 2
            If root_delay > MAX_DELAY Then
                root_delay = MAX_DELAY
            End If
            Dim wait_for As Integer = root_delay + random.[Next](root_delay)
            Try
                Thread.Sleep(wait_for)
            Catch
                Throw New ThreadInterruptedException()
            End Try
        End While
    End Sub

    Private Sub CloseConnection()
        If Me.Socket IsNot Nothing Then
            Me.Socket.Close()
        End If
    End Sub

    Public Sub RunLoop()
        Try
            ReopenConnection()

            While True
                Dim data As Byte() = Queue.Take()
                While True
                    Try
                        Socket.Write(data, 0, data.Length)
                        Socket.Flush()
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
        Dim data As Byte() = UTF8.GetBytes(line & ControlChars.Lf)
        Dim is_full As Boolean = Not Queue.TryAdd(data)

        If is_full Then
            Queue.Take()
            Queue.TryAdd(data)
        End If
    End Sub

    Private Function CheckCredentials() As Boolean
        Dim appSettings = ConfigurationManager.AppSettings
        If Not appSettings.AllKeys.Contains(CONFIG_KEY) OrElse Not appSettings.AllKeys.Contains(CONFIG_LOCATION) Then
            Return False
        End If
        If appSettings(CONFIG_KEY) = "" OrElse appSettings(CONFIG_LOCATION) = "" Then
            Return False
        End If

        Return True
    End Function

    Sub Write(str As String)
        If Not CheckCredentials() Then
            Return
        End If
        If Not Started Then
            Thread.Start()
            Started = True
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

    Sub Shutdown()
        Thread.Interrupt()
        Started = False
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

        Public Sub New(host As [String])
            Dim port As Integer = LE_PORT
            client = New TcpClient(host, port)
            client.NoDelay = True
            Me.stream = client.GetStream()
        End Sub

        Public Sub Write(buffer As Byte(), offset As Integer, count As Integer)
            Me.stream.Write(buffer, offset, count)
        End Sub

        Public Sub Flush()
            Me.stream.Flush()
        End Sub

        Public Sub Close()
            If Me.client IsNot Nothing Then
                Try
                    Me.client.Close()
                Catch
                End Try
            End If
            Me.client = Nothing
        End Sub

        Protected Overloads Sub Dispose(disposing As Boolean)
            If disposing Then
                client.Close()
            End If
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class

    Protected Overloads Sub Dispose(disposing As Boolean)
        If disposing Then
            Queue.Dispose()
            Socket.Dispose()
        End If
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
