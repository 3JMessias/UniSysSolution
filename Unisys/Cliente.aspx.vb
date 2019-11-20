Public Class Cliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        'Captura os dados do formulário e cria um objeto Cliente
        Dim cliente As New ClienteTO
        With cliente
            .NomeCliente = txtNome.Text
            .Cpf = txtCpf.Text
            .Sexo = txtSexo.Text
            .Idade = txtIdade.Text
            .Telefone = txtTelefone.Text
        End With
        'Cria o DAO
        Dim dao As New ClienteDAO
        'Retorno da Gravacao
        txtMsg.Visible = True
        txtMsg.Text = dao.Adiciona(cliente)
    End Sub
End Class