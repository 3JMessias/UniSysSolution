Public Class CategoriaDAO
    Public Function Adiciona(ByVal categoria As CategoriaTO) As String
        Dim msg As String = "OK"

        Dim cn As New Conexao
        Dim sql As New StringBuilder

        With sql
            .Append("insert into Categoria")
            .Append("(")
            .Append("nomeCategoria,")
            .Append("descricao")
            .Append(")")
            .Append("values")
            .Append("(")
            .Append("'" & categoria.NomeCategoria & "',")
            .Append("'" & categoria.Descricao & "'")
            .Append(")")
        End With

        Return cn.ExecutaSqlNew(sql.ToString)
    End Function

    Public Function PreencheCombo() As DataSet
        Dim retorno As DataSet
        Dim sql As String
        Dim cn As New Conexao
        sql = "SELECT -1 as idCategoria,'--escolha a categoria--' as nomeCategoria " & _
              " union all " & _
              "SELECT idCategoria,nomeCategoria from categorias "
        retorno = cn.ExecutaSqlRetorno(sql)
        Return retorno
    End Function

End Class
