Imports System.Xml.Serialization

Namespace EECloud.EEService.XmlElement
    <XmlRoot("EEService")>
    Public Class EEService

        Public Sub New()

        End Sub

        <XmlElement("Settings")>
        Public Property Settings As List(Of KeyValuePair(Of String, String))

        <XmlElement("Facts")>
        Public Property Facts As Facts

        <XmlElement("PlayerData")>
        Public Property PlayerData As PlayerData

    End Class
End Namespace
