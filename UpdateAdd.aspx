<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UpdateAdd.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="txtCustomerName" runat="server" 
        style="z-index: 1; left: 294px; top: 82px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtAddress" runat="server" 
        style="z-index: 1; left: 294px; top: 122px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtPhoneNo" runat="server" 
        style="z-index: 1; left: 294px; top: 160px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtSaleDate" runat="server" 
        style="z-index: 1; left: 294px; top: 239px; position: absolute"></asp:TextBox>
    <p>
        &nbsp;</p>
    <p>
        <asp:CheckBox ID="chkDelivery" runat="server" 
            style="z-index: 1; left: 295px; top: 282px; position: absolute" />
        <asp:Label ID="lblPhoneNo" runat="server" 
            style="z-index: 1; left: 172px; top: 160px; position: absolute" 
            Text="Phone Number"></asp:Label>
        <asp:Label ID="lblCustomerName" runat="server" 
            style="z-index: 1; left: 164px; top: 84px; position: absolute" 
            Text="Customer Name"></asp:Label>
        <asp:Button ID="btnCancel" runat="server" 
            style="z-index: 1; left: 505px; top: 202px; position: absolute; height: 26px" 
            Text="Cancel" />
        <asp:Label ID="lblDelivery" runat="server" 
            style="z-index: 1; left: 214px; top: 283px; position: absolute" Text="Delivery"></asp:Label>
        <asp:Label ID="lblDateOrdered" runat="server" 
            style="z-index: 1; left: 179px; top: 246px; position: absolute" 
            Text="Date Ordered"></asp:Label>
        <asp:Label ID="lblAddress" runat="server" 
            style="z-index: 1; left: 213px; top: 123px; position: absolute" Text="Address"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" 
            style="z-index: 1; left: 125px; top: 311px; position: absolute"></asp:Label>
        <asp:Label ID="lblProductID" runat="server" 
            style="z-index: 1; left: 196px; top: 203px; position: absolute" 
            Text="Product ID"></asp:Label>
        <asp:Button ID="btnSave" runat="server" 
            
            style="z-index: 1; left: 505px; top: 154px; position: absolute; width: 60px;" 
            Text="Save" />
    </p>
    <p>
        &nbsp;</p>
    <asp:DropDownList ID="ddlProductID" runat="server" 
        style="z-index: 1; left: 296px; top: 203px; position: absolute">
    </asp:DropDownList>
    </form>
</body>
</html>
