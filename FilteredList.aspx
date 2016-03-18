<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FilteredList.aspx.vb" Inherits="FilteredList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblSales" runat="server" 
            style="z-index: 1; left: 64px; top: 91px; position: absolute; width: 151px; font-family: 'Cooper Black'" 
            Text="Sales"></asp:Label>
    </p>
    <asp:ListBox ID="lstCustomer" runat="server" Height="216px" 
        style="z-index: 1; left: 62px; top: 123px; position: absolute; width: 438px">
    </asp:ListBox>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:TextBox ID="txtFilter" runat="server" 
        style="position: absolute; z-index: 1; left: 67px; top: 370px"></asp:TextBox>
    <asp:Button ID="btnAll" runat="server" 
        style="z-index: 1; left: 354px; top: 370px; position: absolute" 
        Text="Display All" />
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMessage" runat="server" 
            style="z-index: 1; left: 106px; top: 440px; position: absolute"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnFilter" runat="server" 
            style="z-index: 1; left: 242px; top: 370px; position: absolute" 
            Text="Apply Filter" />
        <asp:Button ID="btnNew" runat="server" 
            style="z-index: 1; left: 576px; top: 163px; position: absolute; width: 60px" 
            Text="New" />
        <asp:Button ID="btnUpdate" runat="server" 
            style="z-index: 1; left: 576px; top: 218px; position: absolute; width: 60px" 
            Text="Update" />
        <asp:Button ID="btnDelete" runat="server" 
            style="z-index: 1; left: 576px; top: 275px; position: absolute; width: 60px" 
            Text="Delete" />
    </p>
    </form>
</body>
</html>
