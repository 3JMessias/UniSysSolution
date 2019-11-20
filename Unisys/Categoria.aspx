<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Categoria.aspx.vb" Inherits="Unisys.Categoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 156px;
        }
        .auto-style3 {
            height: 26px;
            width: 156px;
        }
        .auto-style4 {
            width: 134px;
        }
        .auto-style5 {
            height: 26px;
            width: 134px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblNomeCategoria" runat="server" Text="Nome da categoria:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNomeCategoria" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqNomeCategoria" runat="server" ControlToValidate="txtNomeCategoria" ErrorMessage="RequiredFieldValidator" Font-Size="Smaller" ForeColor="Red">* campo obrigatório</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <div>
            <asp:TextBox ID="tctMsg" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
