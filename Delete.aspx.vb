
Partial Class Delete
    Inherits System.Web.UI.Page
    'declare a variable to store the primary key value
    Dim SaleID As Integer
    'this code is activated upon the page load event
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'take the primary key value from the string passed to us from the previous page
        SaleID = Request.QueryString("SaleID")
        'display an "are you sure" message
        lblMessage.Text = "Are you sure you would like to delete record " & SaleID & "?"
    End Sub
    'this code is activated by the click event of the button btnDelete
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'pass the primary key value to the delete function
        Call DeleteSale(SaleID)
        'redirect back to the filteredlist page when function has finished
        Response.Redirect("FilteredList.aspx")
    End Sub
    'this function will delete a record from the table using the primary key value passed to it
    Function DeleteSale(ByVal SaleID As Integer) As Boolean
        'create an instance of the dataconnection class
        Dim DeleteQuery As New DataConnection
        'declare a variable to store the results of the function
        Dim Success As Boolean
        'add the primary key value as a parameter
        DeleteQuery.AddParameter("@SaleID", SaleID)
        'execute the delete query
        Success = DeleteQuery.Execute("qry_Sales_Delete")
        'return success
        Return Success
    End Function
End Class
