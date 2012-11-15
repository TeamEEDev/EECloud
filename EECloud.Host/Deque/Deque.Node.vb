Partial Friend Class Deque(Of T)

#Region "Node Class"

    ' Represents a node in the deque.
    <Serializable>
    Private NotInheritable Class Node
        Private ReadOnly myValue As T

        Private myPrevious As Node = Nothing

        Private myNext As Node = Nothing

        Friend Sub New(value As T)
            myValue = value
        End Sub

        Friend ReadOnly Property Value() As T
            Get
                Return myValue
            End Get
        End Property

        Friend Property Previous() As Node
            Get
                Return myPrevious
            End Get
            Set(value1 As Node)
                myPrevious = value1
            End Set
        End Property

        Friend Property [Next]() As Node
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