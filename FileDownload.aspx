<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileDownload.aspx.cs" Inherits="WebApplication4.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>SQLI and XSS Vulnerability</h2>

    <table>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px">Please enter below details:</td>
        </tr>
        <tr>
            <td>First Name</td><td>
                <asp:TextBox ID="fname1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name</td><td><asp:TextBox ID="lname1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address</td><td><asp:TextBox ID="addr1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address2</td><td><asp:TextBox ID="addr21" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><td colspan="2"><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px"> <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>  
 Recent Additions:


    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>Filename</th>
                    <th>Download Link</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container, "DataItem.fname")%></td>
                <td><%# DataBinder.Eval(Container, "DataItem.lname")%></td>
                <td><%# DataBinder.Eval(Container, "DataItem.addr")%></td>
                <td><%# DataBinder.Eval(Container, "DataItem.addr2")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
