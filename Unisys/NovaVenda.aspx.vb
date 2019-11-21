Public Class NovaVenda
    Inherits System.Web.UI.Page

    Private Shared idVenda As Long 'Id da Venda 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then 'Se 
            CarregaCboCliente()
            CarregaCboVendedor()
            CarregaCboProduto()
        End If
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvar.Click
        'Objeto da VendaTO
        Dim venda As New VendaTO
        venda.IdCliente = cboCliente.SelectedValue
        venda.IdVendedor = cboVendedor.SelectedValue
        'Objeto dao 
        Dim dao As New VendaDAO
        Dim retorno As String
        retorno = dao.Adiciona(venda)
        If Val(retorno) > 0 Then
            idVenda = Val(retorno)
        Else
            MsgBox("Erro na gravação")
        End If
    End Sub
    Sub CarregaCboVendedor()

        Dim dao As New VendedorDAO
        With cboVendedor
            .DataSource = dao.PreecheCombo
            .DataValueField = "idVendedor"
            .DataTextField = "nomeVendedor"
            .DataBind()
        End With

    End Sub

    Sub CarregaCboCliente()

        Dim dao As New ClienteDAO
        With cboCliente
            .DataSource = dao.PreecheCombo
            .DataValueField = "idCliente"
            .DataTextField = "nomeCliente"
            .DataBind()
        End With

    End Sub

    Sub CarregaCboProduto()
        Dim dao As New ProdutoDAO
        Try
            With cboProduto
                .DataSource = dao.PreecheCombo
                .DataValueField = "idProduto"
                .DataTextField = "NomeProduto"
                .DataBind()
            End With
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Protected Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        AdicionaItem()
        RefreshGrid()
    End Sub
    Sub AdicionaItem()
        Dim item As New ItemVendaTO
        With item
            .idVenda = idVenda
            .idProduto = cboProduto.SelectedValue
            .precoVenda = txtPreco.Text
            .quantidade = txtQuant.Text
            .desconto = txtDesconto.Text
        End With
        Dim dao As New ItemVendaDAO
        dao.Adiciona(item)
    End Sub
    Sub RefreshGrid()
        Dim dao As New ItemVendaDAO
        grdItemVenda.DataSource = dao.PreencheGrid(idVenda)
        grdItemVenda.DataBind()
    End Sub
    Sub CalcTotal()
        Dim quant As Integer = txtQuant.Text
        Dim preco As Double = txtPreco.Text '.Replace(",", ".")
        Dim desconto As Double = txtDesconto.Text
        Dim total As String = preco * quant - desconto



        txtTotal.Text = total
    End Sub

    Protected Sub cboProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduto.SelectedIndexChanged
        Dim idProduto As Long = cboProduto.SelectedValue
        Dim produto As New ProdutoTO
        Dim dao As New ProdutoDAO
        dao.PreecheObj(produto, idProduto)

        txtPreco.Text = produto.Preco
        CalcTotal()

    End Sub

    Protected Sub txtQuant_TextChanged(sender As Object, e As EventArgs) Handles txtQuant.TextChanged
        CalcTotal()
    End Sub

    Protected Sub txtDesconto_TextChanged(sender As Object, e As EventArgs) Handles txtDesconto.TextChanged
        CalcTotal()
    End Sub

    Protected Sub grdItemVenda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdItemVenda.SelectedIndexChanged

    End Sub

    Protected Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click
        Dim idItemVenda As Long = grdItemVenda.SelectedValue
        Dim dao As ItemVendaDAO

        dao.Exclui(idItemVenda)
        RefreshGrid()
    End Sub

End Class