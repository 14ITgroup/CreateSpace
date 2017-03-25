<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainTemplate.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="admin_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DropDownList runat="server" ID="DdlCon" OnSelectedIndexChanged="DdlCon_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="全部" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="通知人" Value="1"></asp:ListItem>
        <asp:ListItem Text="管理人" Value="2"></asp:ListItem>
    </asp:DropDownList>
    <a href="ContactAdd.aspx">添加联系人</a>
    <table>
        <tr>
            <td>联系人姓名</td>
            <td>联系人邮箱</td>
            <td>联系人权限</td>
            <td>操作</td>
        </tr>
        <tr>
            <asp:Repeater runat="server" ID="RptCon" OnItemCommand="RptCon_ItemCommand">
                <ItemTemplate>
                    <td><%#Eval("usname")%></td>
                    <td><%#Eval("usemail")%></td>
                    <td><%#Eval("usclass")%></td>
                    <td><a href="ContactAdd.aspx?id=<%#Eval("id")%>">修改</a> <asp:LinkButton runat="server" CommandArgument='<%#Eval("id")%>' CommandName="del">删除</asp:LinkButton></td>
                </ItemTemplate>
            </asp:Repeater>

        </tr>
    </table>

</asp:Content>

