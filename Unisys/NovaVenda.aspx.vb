Public Class NovaVenda
    Inherits System.Web.UI.Page

    Private Shared idVenda As Long 'Id da Venda 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
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

        Dim cn As New Conexao
        Dim sql As String = "select idVendedor, nomeVendedor " &
                            "from Vendedores order by nomeVendedor"
        With cboVendedor
            .DataSource = cn.ExecutaSqlRetorno(sql)
            .DataValueField = "idVendedor"
            .DataTextField = "nomeVendedor"
            .DataBind()
        End With

    End Sub

    Sub CarregaCboCliente()

        Dim cn As New Conexao
        Dim sql As String = "select idCliente,nomeCliente from Clientes order by nomeCliente"

        cboCliente.DataSource = cn.ExecutaSqlRetorno(sql)
        cboCliente.DataValueField = "idCliente"
        cboCliente.DataTextField = "nomeCliente"
        cboCliente.DataBind()

    End Sub

    Sub CarregaCboProduto()
        Dim dao As New ProdutoDAO
        cboProduto.DataSource = dao.PreecheCombo
        cboProduto.DataValueField = "idProduto"
        cboProduto.DataTextField = "NomeProduto"
        cboProduto.DataBind()
    End Sub

    Protected Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
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

        grdItemVenda.DataSource = dao.PreencheGrid(idVenda)
        grdItemVenda.DataBind()
    End Sub
End Class