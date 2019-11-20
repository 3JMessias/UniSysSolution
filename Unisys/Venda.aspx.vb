Public Class Venda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshGrid()
    End Sub

    Sub RefreshGrid()
        Dim dao As New VendaDAO
        grdVendas.DataSource = dao.ListaVendas
        grdVendas.DataBind()
    End Sub

End Class