<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cross.aspx.cs" Inherits="WebApplication4.cross" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" /> <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
