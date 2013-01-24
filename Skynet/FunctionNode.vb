<Serializable()> _
Public Class FunctionNode : Inherits Node

    Friend mFunction As FWrapper
    Friend mName As String


    Public Sub New(ByVal fw As FWrapper, ByVal children As List(Of Node))

        mFunction = fw
        mName = fw.mName
        mChildren = children

    End Sub

    Public Overrides Function Evaluate(ByVal inp As List(Of Integer)) As Integer

        Dim results As New List(Of Integer)
        For Each n As Node In mChildren
            results.Add(n.Evaluate(inp))
        Next

        Return mFunction.fn(results)

    End Function


    Public Overrides Function Display(Optional ByVal out As String = "", Optional ByVal indent As Integer = 0) As String

        For i As Integer = 0 To indent - 1
            out = out + " "

        Next

        out = out + mName + System.Environment.NewLine

        For Each n As Node In mChildren
            out = n.Display(out, indent + 1)
        Next

        Return out

    End Function



End Class
