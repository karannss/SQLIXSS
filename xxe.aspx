<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="xxe.aspx.cs" Inherits="WebApplication4.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>XML External Entities attack through File Upload</h2>
      <table>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px">Please select XML file for upload.</td>
        </tr>
        <tr>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td><td><asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px"> <asp:Label ID="Label1" runat="server" Text=""></asp:Label>||||
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>||||<asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>  
    <div id="content" runat="server">
        </div>
</asp:Content>
