<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Unisys.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 174px;
        }
        .auto-style2 {
            width: 117px;
        }
        .auto-style3 {
            width: 117px;
            height: 31px;
        }
        .auto-style4 {
            width: 174px;
            height: 31px;
        }
        .auto-style5 {
            width: 117px;
            height: 22px;
        }
        .auto-style6 {
            width: 174px;
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:62%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Idade"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtIdade" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnOk" runat="server" Text="Ok" />
                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" />
                </td>
             
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
