Public Class ItemVendaDAO
    Implements iDAO(Of ItemVendaTO)

    Public Function Adiciona(Obj As ItemVendaTO) As String Implements iDAO(Of ItemVendaTO).Adiciona
        Dim sql As New StringBuilder
        sql.Append("insert into ItemVenda(idVenda,idProduto,quantidade,precoVenda,desconto)")
        sql.Append("values(")
        sql.Append(Obj.idVenda)
        sql.Append(",")
        sql.Append(Obj.idProduto)
        sql.Append(",")
        sql.Append(Obj.quantidade)
        sql.Append(",")
        sql.Append(Obj.precoVenda.ToString.Replace(",", "."))
        sql.Append(",")
        sql.Append(Obj.desconto.ToString.Replace(",", "."))
        sql.Append(")")
        Dim cn As New Conexao

        Return cn.ExecutaSqlNew(sql.ToString)

    End Function

    Public Function Altera(Obj As ItemVendaTO) As String Implements iDAO(Of ItemVendaTO).Altera
        Return ""
    End Function

    Public Function Exclui(id As Integer) As String Implements iDAO(Of ItemVendaTO).Exclui
        Dim sql As String
        Dim cn As New Conexao

        sql = "delete from ItemVenda where idItemVenda = " & id

        Return cn.ExecutaSqlNew(sql)
    End Function

    Public Function Lista(texto As String) As DataSet Implements iDAO(Of ItemVendaTO).Lista
        Dim retorno As New DataSet
        Return retorno
    End Function

    Public Function PreecheCombo() As DataSet Implements iDAO(Of ItemVendaTO).PreecheCombo
        Dim retorno As New DataSet
        Return retorno
    End Function

    Public Sub PreecheObj(ByRef Obj As ItemVendaTO, ByRef id As Integer) Implements iDAO(Of ItemVendaTO).PreecheObj

    End Sub

    Public Function PreencheGrid(ByVal idVenda As Long) As DataSet
        Dim cn As New Conexao
        Dim retorno As New DataSet
        Dim sql As String

        sql = "exec sp_ItemVenda " & idVenda

        retorno = cn.ExecutaSqlRetorno(sql)

        Return retorno
    End Function

End Class
