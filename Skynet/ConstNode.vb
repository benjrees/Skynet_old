<Serializable()> _
Public Class ConstNode : Inherits Node

    Friend mv As Integer

    Public Sub New(ByVal v As Integer)
        mv = v

    End Sub

    Public Overrides Function Evaluate(ByVal inp As List(Of Integer)) As Integer
        Return mv
    End Function


    Public Overrides Function Display(Optional ByVal out As String = "", Optional ByVal indent As Integer = 0) As String

        For i As Integer = 0 To indent - 1
            out = out + " "

        Next

        out = out + System.Convert.ToString(mv) + System.Environment.NewLine

        Return out

    End Function

End Class
