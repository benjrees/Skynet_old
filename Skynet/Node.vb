Imports System.Random
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public MustInherit Class Node
    Implements ICloneable

    Const numFun As Integer = 5
    Shared randObj As New Random
    Friend mChildren As List(Of Node)


    Shared Function GetFlistItem() As FWrapper

        Dim fw As FWrapper
        Select Case randObj.Next(0, numFun - 1)
            Case 0
                fw = New Addw
            Case 1
                fw = New Mulw
            Case 2
                fw = New Ifw
            Case 3
                fw = New Gtw
            Case 4
                fw = New Subw
        End Select

        Return fw

    End Function

    Public MustOverride Function Evaluate(ByVal inp As List(Of Integer)) As Integer

    Public MustOverride Function Display(Optional ByVal out As String = "", Optional ByVal indent As Integer = 0) As String

    Public Shared Function MakeRandomTree(ByVal pc As Integer, Optional ByVal maxDepth As Integer = 4, Optional ByVal fpr As Double = 0.5, Optional ByVal ppr As Double = 0.6) As Node

        If randObj.NextDouble < fpr And maxDepth > 0 Then
            Dim f As FWrapper = Node.GetFlistItem()

            Dim children As New List(Of Node)

            For i As Integer = 0 To f.mChildCount - 1
                children.Add(Node.MakeRandomTree(pc, maxDepth - 1, fpr, ppr))
            Next

            Return New FunctionNode(f, children)
        ElseIf randObj.NextDouble() < ppr Then
            Return New ParamNode(randObj.Next(0, pc))
        Else
            Return New ConstNode(randObj.Next(0, 11))
        End If

    End Function

    Public Shared Function Mutate(ByVal t As Node, ByVal pc As Integer, Optional ByVal probchange As Double = 0.1) As Node

        If randObj.NextDouble < probchange Then
            Return Node.MakeRandomTree(pc)
        Else
            Dim result As Node = t.Clone()

            If TypeOf t Is FunctionNode Then

                Dim resChildren As New List(Of Node)

                For Each c As Node In t.mChildren
                    resChildren.Add(Node.Mutate(c, pc, probchange))

                Next
                result.mChildren = resChildren
            End If
            Return result

        End If


    End Function

    Public Shared Function Crossover(ByVal t1 As Node, ByVal t2 As Node, Optional ByVal probswap As Double = 0.7, Optional ByVal top As Boolean = True) As Node
        If randObj.NextDouble < probswap And Not top Then
            Return t2.Clone()
        Else
            Dim result As Node = t1.Clone()

            If TypeOf t1 Is FunctionNode And TypeOf t2 Is FunctionNode Then

                Dim resChildren As New List(Of Node)

                For Each c As Node In t1.mChildren
                    Dim child As Node = t2.mChildren(randObj.Next(0, t2.mChildren.Count - 1))
                    resChildren.Add(Node.Crossover(c, child, probswap, False))
                Next
                result.mChildren = resChildren
            End If
            Return result
        End If
    End Function




    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim b As New BinaryFormatter()

        b.Serialize(m, Me)
        m.Position = 0
        Return b.Deserialize(m)

    End Function
End Class
