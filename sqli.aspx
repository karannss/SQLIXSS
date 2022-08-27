<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sqli.aspx.cs" Inherits="WebApplication4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>SQL Injection through File Upload</h2>
    <table>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px">Please select file for uploading.<br />Allowed extensions are '.pdf', '.docx', '.csv', '.xlsx', '.pptx'.</td>
        </tr>
        <tr>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td><td><asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px"> <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>               
</asp:Content>
