<Serializable()> _
Public Class Addw : Inherits FWrapper

    Public Sub New()
        MyBase.New(2, "add")
    End Sub

    Public Overrides Function fn(ByVal l As System.Collections.Generic.List(Of Integer)) As Int64
        Dim num As Int64
        Try
            num = l(0) + l(1)
        Catch ex As Exception
            num = Int32.MaxValue
        End Try

        Return num
    End Function
End Class
