Partial Public Class Deque(Of T)
#Region "Node Class"

    ' Represents a node in the deque.
    <Serializable> _
    Private NotInheritable Class Node
        Private ReadOnly myValue As T

        Private myPrevious As Node = Nothing

        Private myNext As Node = Nothing

        Public Sub New(value As T)
            myValue = value
        End Sub

        Public ReadOnly Property Value() As T
            Get
                Return myValue
            End Get
        End Property

        Public Property Previous() As Node
            Get
                Return myPrevious
            End Get
            Set(value1 As Node)
                myPrevious = value1
            End Set
        End Property

        Public Property [Next]() As Node
            Get
                Return myNext
            End Get
            Set(value1 As Node)
                myNext = value1
            End Set
        End Property
    End Class

#End Region
End Class