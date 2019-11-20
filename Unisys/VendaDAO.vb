Public Class VendaDAO
    Implements iDAO(Of VendaTO)

    Public Function Adiciona(Obj As VendaTO) As String Implements iDAO(Of VendaTO).Adiciona
        Dim sql As New StringBuilder
        sql.Append("INSERT INTO Vendas(")
        sql.Append(" idCliente,")
        sql.Append(" idVendedor,")
        sql.Append(" dataVenda )")
        sql.Append("VALUES(")
        sql.Append(Obj.IdCliente & ",")
        sql.Append(Obj.IdVendedor & ",")
        sql.Append("getDate() )")
        sql.Append("SELECT @@identity")

        Dim cn As New Conexao
        Dim msg As String
        msg = cn.ExecutaSqlScalar(sql.ToString)
        Return msg
    End Function

    Public Function Altera(Obj As VendaTO) As String Implements iDAO(Of VendaTO).Altera
        Return ""
    End Function

    Public Function Exclui(id As Integer) As String Implements iDAO(Of VendaTO).Exclui
        Dim sql As String = "sp_ExcluiVenda " & id
        Dim cn As New Conexao
        Return cn.ExecutaSqlNew(sql)
    End Function

    Public Function Lista(texto As String) As DataSet Implements iDAO(Of VendaTO).Lista
        Dim retorno As New DataSet
        Return retorno
    End Function

    Public Function PreecheCombo() As DataSet Implements iDAO(Of VendaTO).PreecheCombo
        Dim retorno As New DataSet
        Return retorno
    End Function

    Public Sub PreecheObj(ByRef Obj As VendaTO, ByRef id As Integer) Implements iDAO(Of VendaTO).PreecheObj

    End Sub

    'Métodos adicionados ao DAO (não constam na Interface)
    Function PreencheCboCliente() As DataSet
        Dim sql As String
        Dim cn As New Conexao

        sql = "select idCliente,nomeCliente from clientes"

        Return cn.ExecutaSqlRetorno(sql)
    End Function

    Function PreencheCboVendedor() As DataSet
        Dim sql As String
        Dim cn As New Conexao

        sql = "select idVendedor,nomeVendedor from vendedores"

        Return cn.ExecutaSqlRetorno(sql)
    End Function

    Function ListaVendas() As DataSet
        Dim sql As String
        Dim cn As New Conexao

        sql = "select * from vw_Vendas"

        Return cn.ExecutaSqlRetorno(sql)
    End Function
End Class
