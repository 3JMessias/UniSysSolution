Public Class ProdutoDAO
    Implements iDAO(Of ProdutoTO)
    Public Function Adiciona(Obj As ProdutoTO) As String Implements iDAO(Of ProdutoTO).Adiciona
        Dim sql As New StringBuilder
        With sql
            .Append("insert into Produtos(")
            .Append(" nomeProduto,")
            .Append(" idCategoria,")
            .Append(" preco,")
            .Append(" estoque,")
            .Append(" foraDeLinha)")
            .Append("values(")
            .Append("'" & Obj.NomeProduto & "',")
            .Append(Obj.IdCategoria & ",")
            .Append(Obj.Preco.ToString.Replace(",", ".") & ",")
            .Append(Obj.Estoque & ",")
            .Append(IIf(Obj.ForaDeLinha, 1, 0) & ")")
        End With
        Dim cn As New Conexao
        Return cn.ExecutaSqlNew(sql.ToString)
    End Function

    Public Function Altera(Obj As ProdutoTO) As String Implements iDAO(Of ProdutoTO).Altera
        Dim sql As New StringBuilder
        With sql
            .Append("update Produtos set ")
            .Append(" nomeProduto = '" & Obj.NomeProduto & "',")
            .Append(" idCategoria = " & Obj.IdCategoria & ",")
            .Append(" preco = " & Obj.Preco.ToString.Replace(",", ".") & ",")
            .Append(" estoque = " & Obj.Estoque & ",")
            .Append(" foraDeLinha = " & IIf(Obj.ForaDeLinha, 1, 0))
            .Append(" where idProduto = " & Obj.IdProduto)
        End With
        Dim cn As New Conexao
        Return cn.ExecutaSqlNew(sql.ToString)
    End Function

    Public Function Exclui(id As Integer) As String Implements iDAO(Of ProdutoTO).Exclui
        Dim sql As String
        sql = "delete Produtos where idProduto = " & id

        Dim cn As New Conexao

        Return cn.ExecutaSqlNew(sql)
    End Function

    Public Function Lista(texto As String) As DataSet Implements iDAO(Of ProdutoTO).Lista
        Dim retorno As New DataSet
        Dim sql As String
        Dim cn As New Conexao

        sql = "select * from vw_ProdutosGrid " & _
              "where NomeProduto like '%" & texto & "%'"

        retorno = cn.ExecutaSqlRetorno(sql)

        Return retorno
    End Function

    Public Function PreecheCombo() As DataSet Implements iDAO(Of ProdutoTO).PreecheCombo
        Dim retorno As New DataSet

        Return retorno
    End Function

    Public Sub PreecheObj(ByRef Obj As ProdutoTO, ByRef id As Integer) Implements iDAO(Of ProdutoTO).PreecheObj
        Dim cn As New Conexao
        Dim ds As New DataSet
        Dim reg As DataRow
        Dim sql As String

        sql = "select * from Produtos where idProduto = " & id

        ds = cn.ExecutaSqlRetorno(sql)

        reg = ds.Tables(0).Rows(0)

        With Obj
            .IdProduto = reg(0)
            .NomeProduto = reg(1)
            .IdCategoria = reg(2)
            .Preco = reg(3)
            .Estoque = reg(4)
            .ForaDeLinha = reg(5)
        End With
    End Sub

    Public Function FiltroMultiplo(idCategoria As Integer,
                              precoMin As Double,
                              precoMax As Double
                              ) As DataSet
        Dim retorno As DataSet
        Dim sql As String
        Dim cn As New Conexao
        sql = "exec sp_ProdutosGrid " & idCategoria & "," _
                                      & precoMin & "," _
                                      & precoMax
        retorno = cn.ExecutaSqlRetorno(sql)
        Return retorno

    End Function

End Class
