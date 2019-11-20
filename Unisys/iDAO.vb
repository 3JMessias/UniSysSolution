Public Interface iDAO(Of T)

    Function Adiciona(ByVal Obj As T) As String

    Function Altera(ByVal Obj As T) As String

    Function Exclui(ByVal id As Integer) As String

    Function Lista(ByVal texto As String) As DataSet

    Sub PreecheObj(ByRef Obj As T, ByRef id As Integer)

    Function PreecheCombo() As DataSet

End Interface