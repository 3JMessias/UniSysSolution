<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CadastroVenda.aspx.vb" Inherits="Unisys.CadastroVenda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
            function ConfirmaExclusao() {
                return confirm("Confirma o cancelamento desta venda?");
            }    
    </script>

    <style type="text/css">
        .style1
        {
            width: 7px;
        }
        .style3
        {
            height: 45px;
        }
        .style5
        {
            height: 45px;
            width: 70px;
        }
        .style6
        {
            width: 70px;
        }
        .style7
        {
            height: 45px;
            width: 97px;
        }
        .style8
        {
            width: 97px;
        }
        .style9
        {
            height: 45px;
            width: 46px;
        }
        .style10
        {
            width: 46px;
        }
        .style11
        {
            height: 45px;
            width: 84px;
        }
        .style12
        {
            width: 84px;
        }
        .style13
        {
            height: 45px;
            width: 68px;
        }
        .style14
        {
            width: 68px;
        }
        .style15
        {
            width: 32px;
            height: 32px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       
          
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

      
          
        <table border="1" style="width: 89%;">
            <tr>
                <td>
                    Nome do Cliente</td>
                <td>
                    Nome do Vendedor</td>
                <td class="style1">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="70px" Height="26px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cboCliente" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="cboVendedor" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="70px" 
                        style="height: 26px" OnClientClick="return ConfirmaExclusao();" />
                </td>
            </tr>
        </table>
        <hr />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
       
        <table border="1" style="width: 696px">
            <tr>
                <td class="style3">Nome do Produto</td>
                <td class="style11">Preço (R$)</td>
                <td class="style9">Quant.</td>
                <td class="style7">Desconto (R$)</td>
                <td class="style5">Total (R$)</td>
                <td class="style13"></td>
            </tr>

            <tr>
                <td>
                    <asp:DropDownList ID="cboProduto" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style12">
                    <asp:TextBox ID="txtPrecoVenda" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtQuantidade" runat="server" Width="80px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtDesconto" runat="server" Width="80px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtTotal" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style14">
                    <asp:Button ID="btnAdicionar" runat="server" Text="+" Width="30px" />
&nbsp;
                    <asp:Button ID="btnRemover" runat="server" Text="-" Width="30px" />
                </td>
            </tr>
   
        </table>


        <hr />

        <asp:GridView ID="grdItemVenda" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="IdItemVenda" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NomeProduto" HeaderText="Nome do Produto" />
                <asp:BoundField DataField="PrecoVenda" HeaderText="Preço (R$)" />
                <asp:BoundField DataField="Quantidade" HeaderText="Quant." />
                <asp:BoundField DataField="Desconto" HeaderText="Desconto (R$)" />
                <asp:BoundField DataField="Total" HeaderText="Total (R$)" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagens/btnExcluir.jpg" 
                    ShowSelectButton="True" />
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
      
      
          </ContentTemplate>
         </asp:UpdatePanel>
        
    </div>

    </form>
</body>
</html>
