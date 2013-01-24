Imports System.Random

Public Class Form1

    Shared randObj As New Random


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim exampleChildren As New List(Of Node)

        'Dim params As New List(Of Node)

        'params.Add(New ParamNode(0))
        'params.Add(New ConstNode(3))
        'exampleChildren.Add(New FunctionNode(New Gtw(), params))

        'params = New List(Of Node)
        'params.Add(New ParamNode(1))
        'params.Add(New ConstNode(5))
        'exampleChildren.Add(New FunctionNode(New Addw(), params))

        'params = New List(Of Node)
        'params.Add(New ParamNode(1))
        'params.Add(New ConstNode(2))
        'exampleChildren.Add(New FunctionNode(New Subw(), params))


        'Dim exampleTree As New FunctionNode(New Ifw(), exampleChildren)

        'Dim treeDisplay As String = exampleTree.Display()
        'Output.Text = treeDisplay

        'Dim testVals As New List(Of Integer)

        'testVals.Add(2)
        'testVals.Add(3)
        'Output.AppendText(exampleTree.Evaluate(testVals))

        'Output.AppendText(System.Environment.NewLine)

        'testVals = New List(Of Integer)
        'testVals.Add(5)
        'testVals.Add(3)
        'Output.AppendText(exampleTree.Evaluate(testVals))


        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Dim randomTree As Node = Node.MakeRandomTree(2)

        'treeDisplay = randomTree.Display()
        'Output.AppendText(treeDisplay)

        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Dim hs As List(Of Integer)() = Form1.BuildHiddenSet()

        'Dim score As Integer = Form1.scorefunction(randomTree, hs)

        'Output.AppendText(score)


        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Output.AppendText("Pre-mutation:" + System.Environment.NewLine)

        'treeDisplay = randomTree.Display()
        'Output.AppendText(treeDisplay)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText("Post-mutation:" + System.Environment.NewLine)
        'Dim mutatedTree As Node = Node.Mutate(randomTree, 2)
        'treeDisplay = mutatedTree.Display()
        'Output.AppendText(treeDisplay)



        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Output.AppendText("Pre-crossover:" + System.Environment.NewLine)

        'treeDisplay = randomTree.Display()
        'Output.AppendText(treeDisplay)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Dim randomTree2 As Node = Node.MakeRandomTree(2)

        'treeDisplay = randomTree2.Display()
        'Output.AppendText(treeDisplay)
        'Output.AppendText(System.Environment.NewLine)
        'Output.AppendText(System.Environment.NewLine)

        'Output.AppendText("Post-crossover:" + System.Environment.NewLine)


        'Dim crossoverTree As Node = Node.Crossover(randomTree, randomTree2)
        'treeDisplay = crossoverTree.Display()
        'Output.AppendText(treeDisplay)









        ' first part of section of interest!
        'Dim hiddenset As List(Of Integer)()
        'hiddenset = Form1.BuildHiddenSet()

        'Me.Evolve(2, 500, hiddenset, , , , , 0.1)



        ' second interesting part
        'Dim p1 As Node = Node.MakeRandomTree(5)
        'Dim p2 As Node = Node.MakeRandomTree(5)

        'Dim p As New List(Of Node)
        'p.Add(p1)
        'p.Add(p2)

        'Dim result As Integer = Me.GridGame(p)

        'Output.AppendText(result)
        'Output.AppendText(System.Environment.NewLine)



    End Sub


    Private Shared Function BuildHiddenSet() As List(Of Integer)()

        Dim rows As List(Of Integer)()
        ReDim rows(200 - 1)


        For i As Integer = 0 To 200 - 1
            Dim row As New List(Of Integer)
            row.Add(randObj.Next(0, 41))
            row.Add(randObj.Next(0, 41))
            row.Add(Form1.HiddenFunction(row(0), row(1)))
            rows(i) = row
        Next

        Return rows

    End Function

    Public Shared Function HiddenFunction(ByVal x As Integer, ByVal y As Integer) As Integer
        Return x ^ 2 + 2 * y + 3 * x + 5

    End Function


    Public Shared Function ScoreFunction(ByVal tree As Node, ByVal s As List(Of Integer)()) As Integer
        Dim dif As Int64 = 0

        For Each data As List(Of Integer) In s
            Dim inputs As New List(Of Integer)
            inputs.Add(data(0))
            inputs.Add(data(1))
            Dim v As Int64 = tree.Evaluate(inputs)
            Dim diff As Int64 = v - data(2)
            dif += Math.Abs(diff)
        Next

        If dif > Integer.MaxValue Then dif = Integer.MaxValue

        Return dif
    End Function



    Private Function Evolve(ByVal pc As Integer, ByVal popsize As Integer, ByVal dataset As List(Of Integer)(), Optional ByVal maxGen As Integer = 500, Optional ByVal mutationrate As Double = 0.2, Optional ByVal breedingrate As Double = 0.1 _
                            , Optional ByVal pexp As Double = 0.7, Optional ByVal pnew As Double = 0.05) As Node

        Dim population As New List(Of Node)


        For i As Integer = 0 To popsize - 1
            population.Add(Node.MakeRandomTree(pc))
        Next

        Dim scores As List(Of NodeScore)
        For i As Integer = 0 To maxGen - 1
            scores = RankFunction(population, dataset)
            Output.AppendText(scores(0).GetScore)
            Output.AppendText(System.Environment.NewLine)

            If scores(0).GetScore = 0 Then
                Exit For
            End If

            Dim newpop As New List(Of Node)
            newpop.Add(scores(0).GetNode)
            newpop.Add(scores(1).GetNode)

            While newpop.Count < popsize

                If randObj.NextDouble > pnew Then
                    newpop.Add(Node.Mutate(Node.Crossover(scores(Form1.SelectIndex(pexp)).GetNode, scores(Form1.SelectIndex(pexp)).GetNode, breedingrate), pc, mutationrate))
                Else
                    newpop.Add(Node.MakeRandomTree(pc))
                End If
            End While

            population = newpop



        Next
        Output.AppendText(scores(0).GetNode.Display)
        Output.AppendText(System.Environment.NewLine)

        Return scores(0).GetNode

    End Function



    Public Shared Function SelectIndex(ByVal pexp As Double) As Integer

        Return System.Convert.ToInt32(Math.Log(randObj.NextDouble()) / Math.Log(pexp))

    End Function


    Public Shared Function RankFunction(ByVal population As List(Of Node), ByVal dataset As List(Of Integer)()) As List(Of NodeScore)

        Dim scores As New List(Of NodeScore)
        For Each t As Node In population
            scores.Add(New NodeScore(t, Form1.ScoreFunction(t, dataset)))
        Next
        scores.Sort()

        Return scores

    End Function


    Private Function GridGame(ByVal p As List(Of Node)) As Integer

        Dim max() As Integer = {3, 3}

        Dim lastmove() As Integer = {-1, -1}

        Dim location(1)() As Integer

        


        location(0) = New Integer() {randObj.Next(0, max(0) - 1), randObj.Next(0, max(1) - 1)}
        location(1) = New Integer() {(location(0)(0) + 2) Mod 4, (location(0)(1) + 2) Mod 4}

        For o As Integer = 0 To 50 - 1
            For i As Integer = 0 To 1
                Dim locs As New List(Of Integer)
                locs.Add(location(i)(0))
                locs.Add(location(i)(1))
                locs.Add(location(1 - i)(0))
                locs.Add(location(1 - i)(1))
                locs.Add(lastmove(i))

                Dim move As Integer = p(i).Evaluate(locs) Mod 4

                If lastmove(i) = move Then Return 1 - i

                lastmove(i) = move

                Select Case move

                    Case 0
                        location(i)(0) -= 1
                        If location(i)(0) < 0 Then location(i)(0) = 0
                    Case 1
                        location(i)(0) += 1
                        If location(i)(0) > max(0) - 1 Then location(i)(0) = max(0) - 1

                    Case 2
                        location(i)(1) -= 1
                        If location(i)(1) < 0 Then location(i)(1) = 0
                    Case 3
                        location(i)(1) += 1
                        If location(i)(1) > max(1) - 1 Then location(i)(1) = max(1) - 1
                End Select

                If location(i)(0) = location(1 - i)(0) And location(i)(1) = location(1 - i)(1) Then Return i

            Next
        Next

        Return -1


    End Function



    Private Function Tournament(ByVal pl As List(Of Node)) As List(Of Integer)

        Dim losses(pl.Count - 1) As Integer

        For i As Integer = 0 To pl.Count - 1
            For j As Integer = 0 To pl.Count - 1

                If i = j Then Continue For

                Dim p As List(Of Node)
                p.Add(pl(i))
                p.Add(pl(j))

                Dim winner As Integer = Me.GridGame(p)

                Select Case winner
                    Case 0
                        losses(j) += 2
                    Case 1
                        losses(i) += 2
                    Case -1
                        losses(i) += 1
                        losses(j) += 1

                End Select

            Next
        Next

        Dim z As New List(Of NodeScore)

        For i As Integer = 0 To pl.Count - 1

            Dim ns As New NodeScore(pl(i), losses(i))
            z.Add(ns)
        Next

        z.Sort()

        Return z

    End Function




End Class
