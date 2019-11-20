Public Class Produto
    Inherits System.Web.UI.Page

    Shared idProduto As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dao As New CategoriaDAO
            cboCategoria.DataSource = dao.PreencheCombo
            cboCategoria.DataBind()
            cboIdCategoria.DataSource = dao.PreencheCombo
            cboIdCategoria.DataBind()

            HabilitaDados(False) 'Inicia com o formulário travado para edição
        End If
    End Sub

    Sub RefreshGrid()
        Dim dao As New ProdutoDAO

        If Not chkFiltroMult.Checked Then
            grdVendas.DataSource = dao.Lista(txtPesquisar.Text)
        Else
            Dim idCategoria As Integer = cboCategoria.SelectedValue
            Dim precoMin As Double = txtPrecoMin.Text
            Dim precoMax As Double = txtPrecoMax.Text
            grdVendas.DataSource = dao.FiltroMultiplo(idCategoria, precoMin, precoMax)
        End If

        grdVendas.DataBind()
    End Sub

    Protected Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        ExibeMsg("", "", False)
        LimparDados()
        HabilitaDados(False)
        RefreshGrid()
    End Sub

    Protected Sub chkFiltroMult_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroMult.CheckedChanged
        If chkFiltroMult.Checked = True Then
            tblFiltroMult.Visible = True
        Else
            tblFiltroMult.Visible = False
        End If
    End Sub

    Protected Sub grdProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdVendas.SelectedIndexChanged
        'Captura o idProduto na grid
        idProduto = grdVendas.SelectedRow.Cells(0).Text
        'Obter o objeto Produto preenchido
        Dim produto As New ProdutoTO
        Dim dao As New ProdutoDAO
        dao.PreecheObj(produto, idProduto)
        'Preencher o fomrulário com os campos do objeto
        txtNomeProduto.Text = produto.NomeProduto
        cboIdCategoria.SelectedValue = produto.IdCategoria
        txtPreco.Text = produto.Preco
        txtEstoque.Text = produto.Estoque
        chkForaDeLinha.Checked = produto.ForaDeLinha
    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        ExibeMsg("", "", False)
        LimparDados()
        HabilitaBotoes(True)
        HabilitaDados(True)
        txtNomeProduto.Focus()
        idProduto = -1 'sinaliza para o botão Salvar
    End Sub

    Sub LimparDados()
        txtNomeProduto.Text = ""
        cboIdCategoria.SelectedValue = -1
        txtPreco.Text = ""
        txtEstoque.Text = ""
        chkForaDeLinha.Checked = False
    End Sub

    Sub HabilitaBotoes(ByVal habilita As Boolean)
        btnSalvar.Enabled = habilita
        btnCancelar.Enabled = habilita
        btnPesquisar.Enabled = Not habilita
        btnNovo.Enabled = Not habilita
        btnEditar.Enabled = Not habilita
        btnExcluir.Enabled = Not habilita
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim produto As New ProdutoTO
        'Preenche o objeto com os dados do formulário
        With produto
            .IdProduto = idProduto
            .NomeProduto = txtNomeProduto.Text
            .IdCategoria = cboIdCategoria.SelectedValue
            .Preco = txtPreco.Text
            .Estoque = txtEstoque.Text
            .ForaDeLinha = chkForaDeLinha.Checked
        End With
        'Gravação
        Dim retorno As String
        Dim dao As New ProdutoDAO
        If idProduto = -1 Then
            retorno = dao.Adiciona(produto)
        Else
            retorno = dao.Altera(produto)
        End If

        'Exibe o retorno da gravação
        If retorno = "OK" Then
            ExibeMsg("Gravaçao com sucesso!", "Blue", True)
            'Reabilita botões
            HabilitaBotoes(False)
            'Trava a tela de Edição
            HabilitaDados(False)
        Else
            ExibeMsg(retorno, "Red", True)
        End If

    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ExibeMsg("", "", False)
        LimparDados()
        HabilitaDados(False)
        HabilitaBotoes(False)
    End Sub

    Sub HabilitaDados(ByVal habilita As Boolean)
        txtNomeProduto.Enabled = habilita
        cboIdCategoria.Enabled = habilita
        txtPreco.Enabled = habilita
        txtEstoque.Enabled = habilita
        chkForaDeLinha.Enabled = habilita
    End Sub

    Sub ExibeMsg(ByVal mensagem As String, ByVal cor As String, ByVal exibir As Boolean)
        txtMensagem.Visible = exibir
        txtMensagem.Text = mensagem
        If cor = "Red" Then
            txtMensagem.ForeColor = Drawing.Color.Red
        End If
        If cor = "Blue" Then
            txtMensagem.ForeColor = Drawing.Color.Blue
        End If
    End Sub

    Protected Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim dao As New ProdutoDAO
        Dim retorno As String
        retorno = dao.Exclui(idProduto)
        If retorno = "OK" Then
            ExibeMsg("Produto excluído com sucesso!", "Blue", True)
            LimparDados()
            RefreshGrid()
        Else
            ExibeMsg(retorno, "Red", True)
        End If
    End Sub

    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ExibeMsg("", "", False)
        HabilitaBotoes(True)
        HabilitaDados(True)
        txtNomeProduto.Focus()
    End Sub

    Protected Sub a(sender As Object, e As EventArgs)

    End Sub
End Class