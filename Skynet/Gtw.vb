<Serializable()> _
Public Class Gtw : Inherits FWrapper

    Public Sub New()
        MyBase.New(2, "isgreater")
    End Sub

    Public Overrides Function fn(ByVal l As System.Collections.Generic.List(Of Integer)) As Int64
        If l(0) > l(1) Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class



