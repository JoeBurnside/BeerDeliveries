
Partial Class _Default
    Inherits System.Web.UI.Page
    'declare a variable to store the primary key value
    Dim SaleID As Integer
    'this code is activated by the click event of btnSave
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'declare a variable to store the error message and run the validorder function to validate the data entered 
        'in the textboxes
        Dim ErrorMessage As String = ValidOrder()
        'check whether there is an error message
        If ErrorMessage = "" Then
            'take the primary key value from the string passed to us from the previous page
            SaleID = Request.QueryString("SaleID")
            'declare a variable to store the CustomerName and retrieve the data from the Customername textbox on the interface
            Dim CustomerName As String = txtCustomerName.Text
            'declare a variable to store the Address and retrieve the data from the Address textbox on the interface
            Dim Address As String = txtAddress.Text
            'declare a variable to store the PhoneNo and retrieve the data from the PhoneNo textbox on the interface
            Dim PhoneNo As String = txtPhoneNo.Text
            'declare a variable to store the ProductID and retrieve the data from the ProductID drop down list on the interface
            Dim ProductID As Integer = ddlProductID.SelectedValue
            'declare a variable to store the SaleDate and retrieve the data from the SaleDate textbox on the interface
            Dim SaleDate As Date = txtSaleDate.Text
            'declare a variable to store the Delivery and retrieve the data from the Delivery checkbox on the interface
            Dim Delivery As Boolean = chkDelivery.Checked
            'check if the value entered into the SaleID textbox is -1
            If SaleID = -1 Then
                'run the insertorder function
                InsertOrder(CustomerName, Address, PhoneNo, ProductID, SaleDate, Delivery)
            Else
                'run the updateorder function
                UpdateOrder(SaleID, CustomerName, Address, PhoneNo, ProductID, SaleDate, Delivery)
            End If
            'redirect the the filteredlist page
            Response.Redirect("FilteredList.aspx")
        Else
            'change the errorlabel to show that there was an error with the data
            lblError.Text = ErrorMessage
        End If
    End Sub
    'this function checks that all the data entered is valid and displays an error message if it is not
    Function ValidOrder() As String
        'clear the error message
        Dim ErrorMessage As String = ""
        'validate CustomerName
        'check that the customername is not blank
        If Len(txtCustomerName.Text) = 0 Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Customer Name cannot be blank: "
        End If
        'validate Address
        'check that the address is not blank
        If Len(txtAddress.Text) = 0 Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Address cannot be blank: "
        End If
        'validate PhoneNo
        'check that the phone number is made up completely of numbers
        If IsNumeric(txtPhoneNo.Text) = False Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Phone Number must be all numbers: "
        End If
        'check that the phone number has more than 11 digits
        If Len(txtPhoneNo.Text) < 11 Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Phone Number too short: "
        End If
        'check that the phone number is less than 15 digits
        If Len(txtPhoneNo.Text) > 15 Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Phone Number too long: "
        End If
        'validate SaleDate
        'check that the saledate is a valid date
        If IsDate(txtSaleDate.Text) = False Then
            'add to errormessage
            ErrorMessage = ErrorMessage & "Sale Date is not a valid date: "
        Else
            'check that the sale date is not in the future
            If txtSaleDate.Text > DateTime.Now Then
                'add to errormessage
                ErrorMessage = ErrorMessage & "Sale Date can not be in the future: "
            End If
            'check that sale date is not before a certain date. i have used january 1st 2000
            If txtSaleDate.Text < #1/1/2000# Then
                'add to errormessage
                ErrorMessage = ErrorMessage & "Sale Date can not be before 01/01/2000: "
            End If
        End If
        'return the contents of the errormessage
        Return ErrorMessage
    End Function
    'this function will insert a new record in the database
    Function InsertOrder(ByVal CustomerName As String, ByVal Address As String, ByVal PhoneNo As String, ByVal ProductID As Integer, ByVal SaleDate As Date, ByVal Delivery As Boolean) As Boolean
        'create an instance of the dataconnection class
        Dim MySales As New DataConnection
        'declare a variable to store whether running the query is successful
        Dim Success As Boolean
        'add the customername parameter
        MySales.AddParameter("@CustomerName", CustomerName)
        'add the address parameter
        MySales.AddParameter("@Address", Address)
        'add the phoneno parameter
        MySales.AddParameter("@PhoneNo", PhoneNo)
        'add the product parameter
        MySales.AddParameter("@ProductID", ProductID)
        'add the saledate parameter
        MySales.AddParameter("@SaleDate", SaleDate)
        'add the delivery parameter
        MySales.AddParameter("@Delivery", Delivery)
        'execute the insert query
        Success = MySales.Execute("qry_Sales_Insert")
        'return whether the query was successful or not
        Return Success
    End Function
    'this function will update an existing record
    Function UpdateOrder(ByVal SaleID As Integer, ByVal CustomerName As String, ByVal Address As String, ByVal PhoneNo As String, ByVal ProductID As Integer, ByVal SaleDate As Date, ByVal Delivery As Boolean) As Boolean
        'create an instance of the dataconnection class
        Dim MySales As New DataConnection
        'declare a variable to store whether running the query is successful
        Dim Success As Boolean
        'add the customername parameter
        MySales.AddParameter("@CustomerName", CustomerName)
        'add the address parameter
        MySales.AddParameter("@Address", Address)
        'add the phoneno parameter
        MySales.AddParameter("@PhoneNo", PhoneNo)
        'add the productid parameter
        MySales.AddParameter("@ProductID", ProductID)
        'add the saledate parameter
        MySales.AddParameter("@SaleDate", SaleDate)
        'add the delivery parameter
        MySales.AddParameter("@Delivery", Delivery)
        'add the saleid parameter
        MySales.AddParameter("@SaleID", SaleID)
        'execute the update query
        Success = MySales.Execute("qry_Sales_Update")
        'return whether the query was successful or not
        Return Success
    End Function
    'this function populates the dropdownlist with data
    Function DisplayProduct() As Integer
        'create an instance of the class products
        Dim MyProducts As New Products
        'declare a variable to store the number of results
        Dim ProductCount As Integer
        'declare a variable to stre the product names
        Dim ProductName As String
        'declare a variable to store the primary key values of the products
        Dim ProductNo As Integer
        'declare a variable to store the product sizes
        Dim ProductSize As String
        'count the number of results and store the results in productcount
        ProductCount = MyProducts.Count
        'clear the drop down list of any data
        ddlProductID.Items.Clear()
        'loop through the results
        For i = 0 To ProductCount - 1
            'retrieve the product names from the database
            ProductName = MyProducts.QueryResults.Rows(i).Item("ProductName")
            'retrieve the primary key values from the database
            ProductNo = MyProducts.QueryResults.Rows(i).Item("ProductID")
            'retrieve size information fro the database
            ProductSize = MyProducts.QueryResults.Rows(i).Item("Size")
            'create an instance of the listitem class and concatenate the data retrieved from the database
            'pair each product with its primary key value
            Dim NewProduct As New ListItem(ProductName & "  " & ProductSize, ProductNo)
            'populate the drop down list
            ddlProductID.Items.Add(NewProduct)
        Next
        'return the count of products
        Return ProductCount
    End Function
    'this code is activated upon page load
    Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) Handles Me.Load
        'retrieve the saleID primary key value from the string passed to us from the previous page
        SaleID = Request.QueryString("SaleID")
        'check if the page is being loaded for the first time
        If IsPostBack = False Then
            'call the displayproduct function to populate the drop down list
            Call DisplayProduct()
            'check if the saleID value is -1 (for new record) or an existing primary key value
            If SaleID <> -1 Then
                'pass the primary key value to displaysale function to display details for that record
                DisplaySale(SaleID)
            End If
        End If
    End Sub
    'this code is activated by the click event of btnCancel
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'redirect to the filteredlist page
        Response.Redirect("FilteredList.aspx")
    End Sub
    'this function displays all the data from an existing record in the interface using the primary key value
    Function DisplaySale(ByVal SaleID As Integer) As Boolean
        'declare a variable to store whether the query was successfully executed
        Dim Success As Boolean
        'create an instance of the dataconnection class
        Dim MySales As New DataConnection
        'add the primary key value as a parameter SaleID
        MySales.AddParameter("@SaleID", SaleID)
        'execute the query
        MySales.Execute("qry_Sales_FilterBySaleID")
        'check that there is exactly one result
        If MySales.Count = 1 Then
            'display the customername in the customername text box
            txtCustomerName.Text = MySales.QueryResults.Rows(0).Item("CustomerName")
            'display the customer address in the address text box
            txtAddress.Text = MySales.QueryResults.Rows(0).Item("Address")
            'display the phne number in the phoneno text box
            txtPhoneNo.Text = MySales.QueryResults.Rows(0).Item("PhoneNo")
            'select the productid from the drop down list
            ddlProductID.SelectedValue = MySales.QueryResults.Rows(0).Item("ProductID")
            'display the sale date in the sale date text box
            txtSaleDate.Text = MySales.QueryResults.Rows(0).Item("SaleDate")
            'display the delivery option in the delivery checkbox
            chkDelivery.Checked = MySales.QueryResults.Rows(0).Item("Delivery")
            'assign a positive value to success
            Success = True
        Else
            'assign a negative value to success
            Success = False
        End If
        'return success
        Return Success
    End Function
End Class
