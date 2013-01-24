<Serializable()> _
Public Class Subw : Inherits FWrapper

    Public Sub New()
        MyBase.New(2, "subtract")
    End Sub

    Public Overrides Function fn(ByVal l As System.Collections.Generic.List(Of Integer)) As Int64
        Return l(0) - l(1)
    End Function
End Class
