<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Excelupload.aspx.cs" Inherits="WebApplication4.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Upload Salary Details.</h2>
     <table>
         
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px">Please select file for uploading.<br />Allowed extension is '.xlsx'.</td>
        </tr>
        <tr>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td><td><asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" /></td>
        </tr>
         
        <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
        </tr>
          <tr>
            <td colspan="2" style=""><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td colspan="2" style="padding-top:15px; padding-bottom:15px"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td colspan="2" style="padding-bottom:15px"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
       
    </table>
    Salary Details:
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
