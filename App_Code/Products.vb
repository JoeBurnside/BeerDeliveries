Imports Microsoft.VisualBasic

Public Class Products
    'create an instance of the dataconnection class
    Private mDBConnection As New DataConnection
    Sub New()
        'execute the query to select all records from the products table
        mDBConnection.Execute("qry_Product_SelectAll")
    End Sub
    'this property counts the number of results found by the select all query
    Public ReadOnly Property Count As Integer
        Get
            'return the count of records found
            Return mDBConnection.Count
        End Get
    End Property
    'this property returns the results of the select all query
    Public ReadOnly Property QueryResults As System.Data.DataTable
        Get
            'return the results of the query
            Return mDBConnection.QueryResults
        End Get
    End Property
End Class
