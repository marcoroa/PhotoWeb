<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoRequests.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="Default.aspx.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Photo Request Service Tester</h2>
        <asp:Panel id="container" runat="server">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lusername" runat="server" Text="Username"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lpassword" runat="server" Text="Password"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="SearchBtn" runat="server" Text="Search Photo Requests" OnClick="SearchBtn_Click" />                    
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        <br />
        <br />
        </asp:Panel>
    </form>
</body>
</html>
