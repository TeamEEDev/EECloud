Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class UnitTest1

    <TestMethod()>
    Public Sub TestMessageReciver()
        Dim myClient As New EECloudAPI.CloudClient
        myClient.RegisterMessages()
        AddHandler myClient.OnMessage, Sub(sender As Object, e As EECloudAPI.CloudClient.OnMessageEventArgs)
                                           If Not e.Type = MessageType.GroupDisallowedJoin Then
                                               Throw New ArgumentException("Wrong message")
                                           End If
                                       End Sub
        myClient.MessageReciver(Nothing, PlayerIOClient.Message.Create("groupdisallowedjoin"))
    End Sub

    <TestMethod()>
    Public Sub TestMethod2()
        Try
            Dim myClient As New EECloudAPI.CloudClient
            myClient.RegisterMessages()
            myClient.MessageReciver(Nothing, PlayerIOClient.Message.Create("GROUPDISALLOWEDJOIN"))
            Throw New ArgumentException("Case Insensivity enabled!")
        Catch ex As KeyNotFoundException

        End Try

    End Sub

End Class