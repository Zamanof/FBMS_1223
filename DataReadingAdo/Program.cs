using System.Data.SqlClient;

string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Library;Integrated Security=True;";


#region Read Data
SqlConnection connection = new(connectionString);
SqlDataReader reader = null;

SqlCommand cmd = new(@"SELECT * FROM Authors", connection);
try
{
    connection.Open();
    reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        //Console.WriteLine($"{reader[1]} {reader[2]}");
        Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
    }
}
finally
{
    if (reader != null) reader.Close();
    if (connection != null) connection.Close();
}

#endregion

//using (SqlConnection connection = new(connectionString))
//{
//    SqlDataReader reader = null;

//    SqlCommand cmd = new(@"SELECT * FROM Authors", connection);
//    connection.Open();
//    reader = cmd.ExecuteReader();
//    bool line = true;
//    while (reader.Read())
//    {
//        if (line)
//        {
//            for (int i = 1; i < reader.FieldCount; i++)
//            {
//                Console.Write($"{reader.GetName(i)}\t\t");
//            }
//            line = false;
//        }
//        else
//        {
//            for(int i = 1; i < reader.FieldCount; i++)
//            {
//                Console.Write($"{reader[i]}\t\t");
//            }
//        }
//        Console.WriteLine();


//    }
//}




