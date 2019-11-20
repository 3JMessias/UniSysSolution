<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Produto.aspx.vb" Inherits="Unisys.Produto" %>

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

        <table style="width:100%;">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblNomeProduto" runat="server" Text="Nome do Produto"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNomeProduto" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
                </td>
                <td class="auto-style3">

                    <asp:DropDownList ID="cboIdCategoria" runat="server" DataTextField="nomeCategoria" DataValueField="idCategoria">
                    </asp:DropDownList>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblPreco" runat="server" Text="Preço Unitário"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblEstoque" runat="server" Text="Unid. em Estoque"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtEstoque" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblForaDeLinha" runat="server" Text="Fora de Linha"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkForaDeLinha" runat="server" Text="Descontinuado" />
                </td>
                <td></td>
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
        <asp:Button ID="btnSalvar" runat="server" Enabled="False" Text="Salvar" ToolTip="Salva os dados" />
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
