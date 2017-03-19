<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名:<asp:TextBox runat="server" ID="TxtAccount"></asp:TextBox><br />
            密码:<asp:TextBox runat="server" ID="TxtPassword" TextMode="Password"></asp:TextBox><br />
            验证码:<asp:TextBox runat="server" ID="TxtVer"></asp:TextBox><asp:Image ID="Image1" imageUrl="./verification.aspx"  runat="server" />
             <br />
            <asp:Button runat="server" ID="BtnSubmit" Text="登录" OnClick="BtnSubmit_Click" /> <a href="#">忘记密码?</a> <asp:Button Visible="false" runat="server" ID="BtnRegist" Text="注册"  OnClick="BtnRegist_Click" />
        </div>
    </form>
</body>
</html>
