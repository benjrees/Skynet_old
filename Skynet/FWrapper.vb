<Serializable()> _
Public MustInherit Class FWrapper

    Friend mChildCount As Integer
    Friend mName As String


    Public Sub New(ByVal childCount As Integer, ByVal name As String)

        mChildCount = childCount
        mName = name

    End Sub

    Public MustOverride Function fn(ByVal l As List(Of Integer)) As Int64

End Class
