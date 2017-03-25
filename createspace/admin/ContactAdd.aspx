<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainTemplate.master" AutoEventWireup="true" CodeFile="ContactAdd.aspx.cs" Inherits="admin_ContactAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    联系人名:<asp:TextBox runat="server" ID="TxtName"></asp:TextBox> <br />
    联系人邮箱:<asp:TextBox runat="server" ID="TxtEmail"></asp:TextBox><br />
    权限选择 <asp:RadioButton runat="server" GroupName="ac" Text="通知人" ID="Rad0" /><asp:RadioButton runat="server" GroupName="ac" Text="管理人" ID="Rad1" /><br />
    <asp:Button runat="server" ID="BtnSub" Text="添加" OnClick="BtnSub_Click"/>
</asp:Content>

