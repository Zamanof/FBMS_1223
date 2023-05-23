#region Ado_intro
// MS SQL, ODBC, OLE DB, Oracle
// 

// DbConnection (SqlConnection, ...)
// DbCommand
// DbDataReader
// DbDataAdapter

// DataTable
// DataSet

// ...

// Connected - qoşulmuş
// Disconnected - ayrılmış
#endregion

#region Connection String
// SQL Authentication
// Data Source = server_name; Initial Catalog = db_name; Id = user_id; Password = user_pass;

// Windows Authentication
// Data Source = server_name; Initial Catalog = db_name; Integrated Security = SSPI;

//MSSQL Local DB connection string
// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;
// Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;

// Sql Server connection string
//Data Source = STHQ0116-01; Initial Catalog=master; User ID = admin; Password = admin;
#endregion

using System.Data.SqlClient;

string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Library;Integrated Security=True;";

SqlConnection connection = null;
connection = new SqlConnection(connectionString);

string insertQuery = @"INSERT INTO Groups (Id, [Name], Id_Faculty) VALUES(15, 'FBMS_1223', 1)";

//SqlCommand insertCommand = new(insertQuery, connection);
SqlCommand insertCommand = new();
insertCommand.Connection = connection;
insertCommand.CommandText = insertQuery;

// ExecuteScalar() - bir dəyər qaytaran sorğular üçün (məsəslən aggregation funksiyalar üçün)
// ExecuteNonQuery() - dəyər qaytaramayan sorğular üçün (INSERT, UPDATE, DELETE, ...)
// ExecuteReader() - cədvəl qaytaran sorğular üçün - (SELECT, ...) 

try
{
	connection.Open();
	insertCommand.ExecuteNonQuery();

}
finally
{
	if (connection != null)
	{
		connection.Close();
	}	
}

