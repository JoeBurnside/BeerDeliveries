
Partial Class FilteredList
    Inherits System.Web.UI.Page
    'this part of the code is activated upon page load
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check if this is the first time the page has been loaded up
        If IsPostBack = False Then
            'declare a variable to count the number of records found
            'use it to pass an empty string to the DisplayCustomers function
            Dim SalesCount As Integer = DisplayCustomers("")
            'display the number of records in the label
            lblMessage.Text = "There are " & SalesCount & " customers details shown"
        End If
    End Sub
    'this code is activated by the click event of the button btnAll
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        'clear the text box
        txtFilter.Text = ""
        'declare a variable to count the number of records found
        'use it to pass an empty string to the DisplayCustomers function
        Dim SalesCount As Integer = DisplayCustomers("")
        'display the number of records in the label
        lblMessage.Text = "There are " & SalesCount & " customers details shown"
        'place the cursor in the text box txtFilter ready for data to be entered
        txtFilter.Focus()
    End Sub

    Protected Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        'declare a variable to store the filter text entered in the textbox
        Dim Filtertxt As String = txtFilter.Text
        'declare a variable to count the number of records found
        'use it to pass the filter text to the DisplayCustomers function and count the number of records
        Dim SalesCount As Integer = DisplayCustomers(Filtertxt)
        'display the number of records in the label
        lblMessage.Text = "There are " & SalesCount & " customers details shown"
        'clear the contents text box
        txtFilter.Text = ""
        'place the cursor in the text box txtFilter ready for data to be entered
        txtFilter.Focus()
    End Sub
    'this function displays the names and addresses of customers in the listbox
    'results can either be filtered according to the contents of the txtFilter box or not
    Function DisplayCustomers(ByVal Filtertxt As String) As Integer
        'clear the listbox
        lstCustomer.Items.Clear()
        'declare a variable to store the primary key value
        Dim SaleID As Integer
        'create an instance of the class listitem used for storing data in the listbox
        Dim NewItem As ListItem
        'declare variables to store the customers names and addresses
        Dim CustomerNames, Address, NameAddress As String
        'create an instance of the data connection class
        Dim MySales As New DataConnection
        'add the parameter for the query to use
        MySales.AddParameter("@Address", Filtertxt)
        'execute the query
        MySales.Execute("qry_Sales_FilterByAddress")
        'loop through results of the query 
        'final row number will be number of rows minus 1 as access tables begin at 0 not 1
        For i = 0 To MySales.Count - 1
            'retrieve the customer name from the database and store in variable CustomerNames
            CustomerNames = MySales.QueryResults.Rows(i).Item("CustomerName")
            'retrieve the customers address from the database and store in variable address
            Address = MySales.QueryResults.Rows(i).Item("Address")
            'retrieve the primary key value from the database and store in the variable SaleID
            SaleID = MySales.QueryResults.Rows(i).Item("SaleID")
            'concatenate the name and address of the customers for display in the listbox
            NameAddress = CustomerNames & ",  " & Address
            'create a list item and pair with its primary key values
            NewItem = New ListItem(NameAddress, SaleID)
            'add the listitem to the listbox
            lstCustomer.Items.Add(NewItem)
        Next
        'return the number of records found
        Return MySales.Count
    End Function
    'this code is activated by the click event of btnDelete
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'declare a variable to store the primary key value
        Dim SaleID As Integer
        'check that a record has been selected from the list
        If lstCustomer.SelectedIndex <> -1 Then
            'take the primary key value of the selected record
            SaleID = lstCustomer.SelectedValue
            'redirect to the delete page retaining the primary key value of the record selected
            Response.Redirect("Delete.aspx?SaleID=" & SaleID)
        Else
            'display an error message 
            lblMessage.Text = "You must first select an item from the list."
        End If
    End Sub
    'this code is activated by the click event of btnNew
    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'redirect to the updateadd page with a primary key value of -1 for a new record
        Response.Redirect("UpdateAdd.aspx?SaleID=-1")
    End Sub
    'this code is activated by the click event of btnUpdate
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'declare a variable to store the primary key value
        Dim SaleID As Integer
        'check that a record has been selected from the list
        If lstCustomer.SelectedIndex <> -1 Then
            'take the primary key value of the selected record
            SaleID = lstCustomer.SelectedValue
            'redirect to the updateadd page retaining the primary key value of the selected record
            Response.Redirect("UpdateAdd.aspx?SaleID=" & SaleID)
        Else
            'display an error message
            lblMessage.Text = "You must first select an item from the list."
        End If
    End Sub
End Class
