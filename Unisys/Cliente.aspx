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

        <div>
            <asp:TextBox ID="txtMsg" runat="server" BackColor="#FFFF99" ForeColor="Blue" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
        </div>
    </form>
</body>
</html>
