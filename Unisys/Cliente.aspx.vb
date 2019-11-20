Public Class Cliente
    Inherits System.Web.UI.Page
    Shared idCliente As Long = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub ExibeMsg(ByVal mensagem As String, ByVal cor As String, ByVal exibir As Boolean)
        txtMsg.Visible = exibir
        txtMsg.Text = mensagem
        If cor = "Red" Then
            txtMsg.ForeColor = Drawing.Color.Red
        End If
        If cor = "Blue" Then
            txtMsg.ForeColor = Drawing.Color.Blue
        End If
    End Sub
    Sub LimparDados()
        txtNome.Text = ""
        txtCpf.Text = ""
        txtSexo.Text = ""
        txtIdade.Text = ""
        txtTelefone.Text = ""
    End Sub

    Sub HabilitaBotoes(ByVal habilita As Boolean)
        btnSalvar.Enabled = habilita
        'btnCancelar.Enabled = habilita
        'btnPesquisar.Enabled = Not habilita
        'btnNovo.Enabled = Not habilita
        'btnEditar.Enabled = Not habilita
        'btnExcluir.Enabled = Not habilita
    End Sub
    Sub HabilitaDados(ByVal habilita As Boolean)
        txtNome.Enabled = habilita
        txtCpf.Enabled = habilita
        txtSexo.Enabled = habilita
        txtIdade.Enabled = habilita
        txtTelefone.Enabled = habilita
    End Sub
    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        'Captura os dados do formulário e cria um objeto Cliente
        Dim cliente As New ClienteTO
        With cliente
            .IdCliente = idCliente
            .NomeCliente = txtNome.Text
            .Cpf = txtCpf.Text
            .Sexo = txtSexo.Text
            .Idade = txtIdade.Text
            .Telefone = txtTelefone.Text
        End With
        'Cria o DAO
        Dim retorno As String
        Dim dao As New ClienteDAO
        If idCliente = -1 Then
            retorno = dao.Adiciona(cliente)
        Else
            'retorno = dao.Altera(cliente)
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
        'Retorno da Gravacao
        txtMsg.Visible = True
        txtMsg.Text = dao.Adiciona(cliente)
    End Sub
End Class