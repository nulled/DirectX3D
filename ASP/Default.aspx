<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Login ASP Style</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            FistName: <asp:TextBox ID="txtFirstname" runat="server" Text='<%# Eval("txtFirstname") %>'></asp:TextBox>
            <br />
            LastName: <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
            <br />
            Phone: <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" />
        </div>
        <asp:GridView ID="gridView" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
