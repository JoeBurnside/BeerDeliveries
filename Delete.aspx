<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Delete.aspx.vb" Inherits="Delete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Order</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="btnDelete" runat="server" 
        style="z-index: 1; left: 216px; top: 182px; position: absolute" Text="Delete" />
    <asp:Label ID="lblMessage" runat="server" 
        style="z-index: 1; left: 191px; top: 120px; position: absolute"></asp:Label>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnCancel" runat="server" 
            style="z-index: 1; left: 324px; top: 182px; position: absolute" Text="Cancel" />
    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
