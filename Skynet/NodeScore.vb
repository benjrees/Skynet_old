Public Class NodeScore
    Implements IComparable(Of NodeScore)

    Public GetNode As Node
    Public GetScore As Integer

    Public Sub New(ByVal iNode As Node, ByVal iScore As Integer)

        GetNode = iNode
        GetScore = iScore

    End Sub

    Public Overloads Function CompareTo(ByVal other As Skynet.NodeScore) As Integer _
        Implements IComparable(Of NodeScore).CompareTo


        Return GetScore.CompareTo(other.GetScore)

    End Function

End Class
