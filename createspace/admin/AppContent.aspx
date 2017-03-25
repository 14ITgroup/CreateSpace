<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainTemplate.master" AutoEventWireup="true" CodeFile="AppContent.aspx.cs" Inherits="admin_AppContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    标题:<asp:TextBox ID="TxtTile" Enabled="false" runat="server" ></asp:TextBox><br />
    申请人:<asp:TextBox ID="TxtName" Enabled="false" runat="server"></asp:TextBox><br />
    申请时间:<asp:Label Text="Temple" runat="server" ID="LblTime"></asp:Label><br />
    手机号:<asp:Label Text="Temple" runat="server" ID="LblMobile"></asp:Label><br />
    邮箱:<asp:Label Text="Temple" runat="server" ID="LblEmail"></asp:Label><br />
    申请理由:<br /><asp:TextBox ID="TxtReason" Enabled="false" runat="server" TextMode="MultiLine" style="width:300px;height:300px"></asp:TextBox><br />

    <asp:Button runat="server" ID="BtnOk" OnClick="BtnOk_Click" Text="同意"/>     
    <asp:Button runat="server" ID="BtnRefuse" OnClick="BtnRefuse_Click" Text="拒绝"/>    
    <asp:Button runat="server" ID="BtnCanel" OnClick="BtnCanel_Click" Text="取消"/>   


    
</asp:Content>

