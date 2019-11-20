<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cliente.aspx.vb" Inherits="Unisys.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            height: 22px;
            width: 150px;
        }
        .auto-style4 {
            width: 161px;
        }
        .auto-style5 {
            height: 22px;
            width: 161px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div>

        <div>
            <asp:TextBox ID="txtMsg" runat="server" BackColor="#FFFF99" ForeColor="Blue" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNome" runat="server" Text="Nome do cliente:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqNome" runat="server" ControlToValidate="txtNome" ErrorMessage="RequiredFieldValidator" Font-Size="Small" ForeColor="Red">* campo obrigatório</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblCpf" runat="server" Text="Cpf:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblSexo" runat="server" BorderStyle="None" Text="Sexo:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtSexo" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblIdade" runat="server" Text="Idade:" ViewStateMode="Enabled"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtIdade" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" style="height: 26px" />
                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
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
        <asp:Button ID="Button1" runat="server" Enabled="False" Text="Salvar" ToolTip="Salva os dados" />
&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" ToolTip="Cancela a ação" />

    </div>
    <hr />
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblPesquisar" runat="server" Text="Digite as iniciais do nome do produto:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtPesquisar" runat="server"></asp:TextBox>
                </td>
                <td>

                    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" />

                </td>
                <td>

                    <asp:CheckBox ID="chkFiltroMult" runat="server" AutoPostBack="True" Font-Size="Smaller" Text="Pesquisa Avançada" />

                </td>
               </tr>
        </table>
    </div>
    <hr />
    <hr />
    <div style="width: 694px">

        <asp:GridView ID="grdVendas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IdProduto" HeaderText="Cód." />
                <asp:BoundField DataField="NomeProduto" HeaderText="Nome do Produto" HtmlEncode="False" />
                <asp:BoundField DataField="NomeCategoria" HeaderText="Categoria" HtmlEncode="False" />
                <asp:BoundField DataField="Preco" HeaderText="Preço Unit." />
                <asp:BoundField DataField="Estoque" HeaderText="Estoque" />
                <asp:BoundField DataField="idCategoria" HeaderText="idCategoria" Visible="False" />
                <asp:CommandField ShowSelectButton="True" />
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
