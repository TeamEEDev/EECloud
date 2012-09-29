Imports System.Threading.Tasks

Public Interface IConnectionHandle
    Inherits IConnection(Of Player)
    Function JoinAsync(username As String, password As String, id As String) As Task
    Sub Disconnect()
End Interface
