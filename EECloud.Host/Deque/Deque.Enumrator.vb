Partial Friend Class Deque(Of T)

#Region "Enumerator Class"
    <Serializable>
    Private NotInheritable Class Enumerator

        Implements IEnumerator(Of T)

        Private ReadOnly myOwner As Deque(Of T)

        Private myCurrentNode As Node

        Private myCurrent As T = Nothing

        Private myMoveResult As Boolean = False

        Private ReadOnly myVersion As Long

        Private myDisposed As Boolean = False

        Friend Sub New(owner As Deque(Of T))
            myOwner = owner
            myCurrentNode = owner.myFront
            myVersion = owner.myVersion
        End Sub

#Region "IEnumerator Members"
        Friend Sub Reset() Implements IEnumerator.Reset
            If myDisposed Then
                Throw New ObjectDisposedException([GetType]().Name)
            ElseIf myVersion <> myOwner.myVersion Then
                Throw New InvalidOperationException("The Deque was modified after the enumerator was created.")
            End If

            myCurrentNode = myOwner.myFront
            myMoveResult = False
        End Sub

        Friend ReadOnly Property Current As Object Implements IEnumerator.Current
            Get
                If myDisposed Then
                    Throw New ObjectDisposedException([GetType]().Name)
                ElseIf Not myMoveResult Then
                    Throw New InvalidOperationException("The enumerator is positioned before the first element of the Deque or after the last element.")
                End If

                Return myCurrent
            End Get
        End Property

        Friend Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            If myDisposed Then
                Throw New ObjectDisposedException([GetType]().Name)
            ElseIf myVersion <> myOwner.myVersion Then
                Throw New InvalidOperationException("The Deque was modified after the enumerator was created.")
            End If

            If myCurrentNode IsNot Nothing Then
                myCurrent = myCurrentNode.Value
                myCurrentNode = myCurrentNode.[Next]

                myMoveResult = True
            Else
                myMoveResult = False
            End If

            Return myMoveResult
        End Function
#End Region

#Region "IEnumerator<T> Members"
        Private ReadOnly Property IEnumerator_Current As T Implements IEnumerator(Of T).Current
            Get
                If myDisposed Then
                    Throw New ObjectDisposedException([GetType]().Name)
                ElseIf Not myMoveResult Then
                    Throw New InvalidOperationException("The enumerator is positioned before the first element of the Deque or after the last element.")
                End If

                Return myCurrent
            End Get
        End Property
#End Region

#Region "IDisposable Members"
        Friend Sub Dispose() Implements IDisposable.Dispose
            myDisposed = True
        End Sub
#End Region

    End Class
#End Region

End Class
