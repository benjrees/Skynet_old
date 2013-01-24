<Serializable()> _
Public Class ParamNode : Inherits Node

    Friend midx As Integer

    Public Sub New(ByVal idx As Integer)

        midx = idx

    End Sub

    Public Overrides Function Evaluate(ByVal inp As List(Of Integer)) As Integer
        Return inp(midx)
    End Function


    Public Overrides Function Display(Optional ByVal out As String = "", Optional ByVal indent As Integer = 0) As String

        For i As Integer = 0 To indent - 1
            out = out + " "

        Next

        out = out + "p" + System.Convert.ToString(midx) + System.Environment.NewLine

        Return out

    End Function


End Class
