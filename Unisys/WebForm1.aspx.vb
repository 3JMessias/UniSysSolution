Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim idade As Integer
        idade = txtIdade.Text

        If (idade < 18) Then
            MsgBox("Volte outro dia")
        Else
            MsgBox("Seja bem vindo")
        End If
    End Sub
End Class