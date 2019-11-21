<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NovaVenda.aspx.vb" Inherits="Unisys.NovaVenda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            width: 163px;
        }
        .style2
        {
            width: 236px;
        }
        .style3
        {
            width: 80px;
        }
    </style>
    <script type="text/javascript">
        function ConfirmaExclusao() {
            return confirm("Produto selecionado na grid será excluido!");
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Nome do Cliente"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Nome do Vendedor"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="76px" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:DropDownList ID="cboCliente" runat="server" style="height: 22px" 
                    AppendDataBoundItems="True" DataValueField="idCliente">
                    <asp:ListItem Value="0">Selecione um cliente</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style2">
                <asp:DropDownList ID="cboVendedor" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Selecione o vendedor</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="76px"
                    OnClientClick="return confirm('Confirma o cancelamento desta venda?');" />
            </td>
        </tr>
    </table>

    <hr>

    <table border=1>
        <tr><td>Nome do Produto</td><td class="style3">Quant.</td><td>Preço</td><td>Desc.</td><td>
            Total</td><td>
                <asp:Button ID="btnInserir" runat="server" Text="+" Height="26px" 
                    Width="53px" Font-Bold="True" Font-Size="15pt" />
            </td></tr>
        <tr> <td>
            <asp:DropDownList ID="cboProduto" runat="server" AutoPostBack="True" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">Selecione o produto        </asp:ListItem>
            </asp:DropDownList>
            </td> <td class="style3">
                <asp:TextBox ID="txtQuant" runat="server" Width="76px" AutoPostBack="True">1</asp:TextBox>
            </td> <td>
                <asp:TextBox ID="txtPreco" runat="server" Width="76px" ReadOnly="True">0,00</asp:TextBox>
            </td> <td>
                <asp:TextBox ID="txtDesconto" runat="server" Width="76px" AutoPostBack="True">0,00</asp:TextBox>
            </td> <td>
                <asp:TextBox ID="txtTotal" runat="server" Width="76px" ReadOnly="True">0,00</asp:TextBox>
            </td> <td>
                <asp:Button ID="btnRemover" runat="server" Text="-" Height="26px" 
                    Width="53px" Font-Bold="True" Font-Size="15pt" ForeColor="Red" OnClientClick="ConfirmaExclusao()"/>
            </td> </tr>

    
    </table>

    <asp:GridView ID="grdItemVenda" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idItemVenda">
        <Columns>
            <asp:BoundField DataField="idItemVenda" HeaderText="IdItemVenda" 
                Visible="False" />
            <asp:BoundField DataField="NomeProduto" HeaderText="Nome do Produto" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quant." />
            <asp:BoundField DataField="PrecoVenda" HeaderText="Preço Unit." 
                DataFormatString="{0:c}" />
            <asp:BoundField DataField="Desconto" HeaderText="Desconto" 
                DataFormatString="{0:c}" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:c}" />
            <asp:BoundField DataField="idVenda" HeaderText="idVenda" Visible="False" />
            <asp:CommandField 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Text="Button" />
        
    </form>
 
</body>
</html>
