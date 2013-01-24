<Serializable()> _
Public Class Ifw : Inherits FWrapper

    Public Sub New()
        MyBase.New(3, "if")
    End Sub

    Public Overrides Function fn(ByVal l As System.Collections.Generic.List(Of Integer)) As Int64
        If l(0) > 0 Then
            Return l(1)
        Else
            Return l(2)
        End If
    End Function
End Class


