Public Class CadastroVenda
    Inherits System.Web.UI.Page

    Shared idVenda As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then 'Se for a primeira vez que 'postar a página' ou seja se não estiver postando de novo
            PreencheCboCliente()
            PreencheCboProduto()
            PreencheCboVendedor()
            LimpaDados()
            cboCliente.Focus()
        End If
    End Sub

    Sub CalcTotal()
        txtTotal.Text = txtPrecoVenda.Text * txtQuantidade.Text - txtDesconto.Text
    End Sub

    Sub Mensagem(ByVal texto As String)
        Dim javaScript As String = "<script>alert('" & texto & "');</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
    End Sub

    Sub PreencheCboCliente()
        Dim cn As New Conexao
        Dim sql As String

        sql = "select idCliente,NomeCliente " & _
              "from " & _
              "(select -1 as idCliente,' -- Selecione o cliente -- ' as NomeCliente " & _
              "  union all " & _
              " select idCliente,NomeCliente from clientes) tbl " & _
              "order by NomeCliente "

        cboCliente.DataSource = cn.ExecutaSqlRetorno(sql)
        cboCliente.DataValueField = "idCliente"
        cboCliente.DataTextField = "NomeCliente"
        cboCliente.DataBind()
    End Sub

    Sub PreencheCboProduto()
        Dim cn As New Conexao
        Dim sql As String

        sql = "select idProduto,NomeProduto from Produtos order by NomeProduto"

        cboProduto.DataSource = cn.ExecutaSqlRetorno(sql)
        cboProduto.DataValueField = "idProduto"
        cboProduto.DataTextField = "NomeProduto"
        cboProduto.DataBind()
    End Sub

    Sub PreencheCboVendedor()
        Dim cn As New Conexao
        Dim sql As String

        sql = "select idVendedor,NomeVendedor from Vendedores order by NomeVendedor"

        cboVendedor.DataSource = cn.ExecutaSqlRetorno(sql)
        cboVendedor.DataValueField = "idVendedor"
        cboVendedor.DataTextField = "NomeVendedor"
        cboVendedor.DataBind()
    End Sub

    Sub RefreshGrid(ByVal idVenda As Long)

        Dim dao As New ItemVendaDAO
        
        grdItemVenda.DataSource = dao.PreencheGrid(idVenda)
        grdItemVenda.DataBind()

    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvar.Click

        Dim venda As New VendaTO

        venda.IdCliente = cboCliente.SelectedValue
        venda.IdVendedor = cboVendedor.SelectedValue

        Dim dao As New VendaDAO
        Dim msg As String

        msg = dao.Adiciona(venda)

        If Integer.TryParse(msg, idVenda) Then
            Mensagem("Gravação realizada com sucesso!")
            HabilitaObjetos(False)
            cboProduto.Focus()
        Else
            Mensagem(msg)
        End If

    End Sub

    Sub HabilitaObjetos(ByVal habilita As Boolean)

        'Venda
        cboCliente.Enabled = habilita
        cboVendedor.Enabled = habilita
        btnSalvar.Enabled = habilita
        btnCancelar.Enabled = Not habilita
        'ItemVenda
        cboProduto.Enabled = Not habilita
        txtPrecoVenda.Enabled = Not habilita
        txtQuantidade.Enabled = Not habilita
        txtDesconto.Enabled = Not habilita
        txtTotal.Enabled = Not habilita
        btnAdicionar.Enabled = Not habilita
        btnRemover.Enabled = Not habilita
        grdItemVenda.Enabled = Not habilita

    End Sub


    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionar.Click

        Dim item As New ItemVendaTO
        With item
            .IdVenda = idVenda
            .IdProduto = cboProduto.SelectedValue
            .Quantidade = txtQuantidade.Text
            .PrecoVenda = txtPrecoVenda.Text.Replace(",", ".")
            .Desconto = txtDesconto.Text.Replace(",", ".")
        End With

        Dim dao As New ItemVendaDAO
        Dim msg As String
        msg = dao.Adiciona(item)

        If msg = "OK" Then
            LimpaDados()
        Else
            Mensagem(msg)
            Dim produto As New ProdutoTO
            Dim daoProduto As New ProdutoDAO
            daoProduto.PreecheObj(produto, item.idProduto)
            Mensagem("Estoque do " & produto.NomeProduto & " é " & produto.Estoque)
        End If

    End Sub


    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click

        Dim dao As New VendaDAO
        Dim msg As String = dao.Exclui(idVenda)
        If msg = "OK" Then
            Mensagem("Venda excluída com sucesso!")
            LimpaDados()
            idVenda = -1
        Else
            Mensagem("Houve um erro na tentativa de exclusão da venda!" & msg)
        End If

    End Sub

    Sub LimpaDados()

        txtPrecoVenda.Text = 0
        txtQuantidade.Text = 1
        txtDesconto.Text = 0
        txtTotal.Text = 0

        RefreshGrid(idVenda)

        HabilitaObjetos(True)

    End Sub

    Protected Sub grdItemVenda_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdItemVenda.SelectedIndexChanged

        Dim idItemVenda As Integer
        idItemVenda = grdItemVenda.SelectedValue

        Dim dao As New ItemVendaDAO
        Dim msg As String
        msg = dao.Exclui(idItemVenda)

        If msg = "OK" Then
            LimpaDados()
        Else
            Mensagem(msg)
        End If

    End Sub

    Protected Sub cboProduto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboProduto.SelectedIndexChanged

        Dim idProduto As Long
        idProduto = cboProduto.SelectedValue

        Dim produto As New ProdutoTO
        Dim daoProduto As New ProdutoDAO
        daoProduto.PreecheObj(produto, idProduto)

        txtPrecoVenda.Text = produto.Preco
        CalcTotal()

    End Sub

    Protected Sub txtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtQuantidade.TextChanged
        CalcTotal()
    End Sub

    Protected Sub txtDesconto_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDesconto.TextChanged
        CalcTotal()
    End Sub

End Class
