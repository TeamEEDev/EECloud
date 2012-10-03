Imports System.Threading.Tasks

Public Interface IConnectionHandle
    ReadOnly Property Connection As IConnection(Of Player)
    ReadOnly Property ConnectionFactory As IConnectionFactory
    Function ConnectAsync(username As String, password As String, id As String) As Task
    Sub Disconnect()
End Interface
