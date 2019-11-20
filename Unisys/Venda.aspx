<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Venda.aspx.vb" Inherits="Unisys.Venda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 22px;
            width: 234px;
        }
        .auto-style3 {
            width: 234px;
        }
        .auto-style4 {
            height: 22px;
            width: 177px;
        }
        .auto-style5 {
            width: 177px;
        }
        .auto-style6 {
            height: 23px;
        }
    </style>

    <script type="text/javascript">
        function ConfirmaExclusao() {
            return confirm("Registro selecionado na grid será excluido!");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="txtMensagem" runat="server" BackColor="#FFFF99" Enabled="False" Font-Bold="True" ForeColor="Red" Height="41px" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>

    </div>

    <div>

        
    </div>
    <hr />
    <div>

        <asp:Button ID="btnNovo" runat="server" Text="Novo" ToolTip="Insere um novo produto" Width="61px" />
&nbsp;&nbsp;
        <asp:Button ID="btnEditar" runat="server" Text="Editar" ToolTip="Altera os dados do produto" />
&nbsp;&nbsp;
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClientClick="return ConfirmaExclusao()"
             ToolTip="Deleta o produto" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSalvar" runat="server" Enabled="False" Text="Salvar" ToolTip="Salva os dados" />
&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" ToolTip="Cancela a ação" />

    </div>
    <hr />

    <div>
        <table id="tblFiltroMult" runat="server" visible="false"> 
            <tr>
                <td>Categoria</td>
                <td>

                    <asp:DropDownList ID="cboCategoria" runat="server" DataTextField="nomeCategoria" DataValueField="idCategoria">
                    </asp:DropDownList>

                </td> 
            </tr>
            <tr>
                <td>Preço</td>
                <td>

                    <asp:TextBox ID="txtPrecoMin" runat="server"></asp:TextBox>
                    até

                    <asp:TextBox ID="txtPrecoMax" runat="server"></asp:TextBox>

                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div style="width: 694px">

        <asp:GridView ID="grdVendas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-right: 1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IdVenda" HeaderText="Cód." />
                <asp:BoundField DataField="DataVenda" HeaderText="Data da Venda" HtmlEncode="False" />
                <asp:BoundField DataField="NomeCliente" HeaderText="Nome do Cliente" HtmlEncode="False" />
                <asp:BoundField DataField="NomeVendedor" HeaderText="Nome do Vendedor" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/imagens/lupa.png" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

    </div>
    </form>
</body>
</html>
