<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainTemplate.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_AdminIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DropDownList runat="server" ID="DdlCon" OnSelectedIndexChanged="DdlCon_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="全部" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="已处理" Value="1"></asp:ListItem>
        <asp:ListItem Text="未处理" Value="2"></asp:ListItem>
        <asp:ListItem Text="已同意" Value="3"></asp:ListItem>
        <asp:ListItem Text="已拒绝" Value="4"></asp:ListItem>
    </asp:DropDownList>
    <table>
        <tr>
            <td>申请标题</td>
            <td>申请人</td>
            <td>申请日期</td>
            <td>申请时间段</td>           
            <td>处理状态</td>
            <td>操作</td>
        </tr>
        <tr>
            <asp:Repeater runat="server" ID="RptCon" OnItemCommand="RptCon_ItemCommand">
                <ItemTemplate>
                    <td><a href="AppContent.aspx?<%#Eval("id")%>"><%#Eval("AppTitle")%></a></td>
                    <td><%#Eval("AppName")%></td>
                    <td><%#Eval("AppTime")%></td>
                    <td><%#Eval("tim")%></td>
                    <td><%#Eval("dealstate")%></td>
                    <td><a href="AppContent.aspx?id=<%#Eval("id")%>">查看详情</a></td>
                </ItemTemplate>
            </asp:Repeater>

        </tr>
    </table>
    <asp:Button runat="server" ID="BtnFirst" Text="首页" OnClick="BtnFirst_Click" />
    <asp:Button runat="server" ID="BtnLast" Text="上一页" OnClick="BtnLast_Click" />
    <asp:Label runat="server" ID="LblNowPage" Text="{nowPage}"></asp:Label>/
    <asp:Label runat="server" ID="LblAllPage" Text="{allPage}"></asp:Label>
    <asp:Button runat="server" ID="BtnNext" Text="下一页" OnClick="BtnNext_Click" />
    <asp:Button runat="server" ID="BtnFinal" Text="末页" OnClick="BtnFinal_Click" />
    <asp:TextBox runat="server" ID ="TxtPage" MaxLength="4" Width="30px" />
    <asp:Button runat="server" ID="BtnGo" Text="go" OnClick="BtnGo_Click" />

</asp:Content>

