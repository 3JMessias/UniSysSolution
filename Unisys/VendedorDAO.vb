Imports Unisys

Public Class VendedorDAO
    Implements iDAO(Of VendedorTO)

    Public Sub PreecheObj(ByRef Obj As VendedorTO, ByRef id As Integer) Implements iDAO(Of VendedorTO).PreecheObj
        Throw New NotImplementedException()
    End Sub

    Public Function Adiciona(Obj As VendedorTO) As String Implements iDAO(Of VendedorTO).Adiciona
        Throw New NotImplementedException()
    End Function

    Public Function Altera(Obj As VendedorTO) As String Implements iDAO(Of VendedorTO).Altera
        Throw New NotImplementedException()
    End Function

    Public Function Exclui(id As Integer) As String Implements iDAO(Of VendedorTO).Exclui
        Throw New NotImplementedException()
    End Function

    Public Function Lista(texto As String) As DataSet Implements iDAO(Of VendedorTO).Lista
        Throw New NotImplementedException()
    End Function

    Public Function PreecheCombo() As DataSet Implements iDAO(Of VendedorTO).PreecheCombo
        Dim cn As New Conexao
        Dim sql As String = "select idVendedor, nomeVendedor " &
                            "from Vendedores order by nomeVendedor"
        Return cn.ExecutaSqlRetorno(sql)
    End Function
End Class
