using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

SqlConnection conn;
string connecionString;
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("AppConfig.json");
var config = builder.Build();
connecionString = config.GetConnectionString("DefaultConnection")!;
conn = new SqlConnection(connecionString);

conn.Open();
SqlCommand command = new SqlCommand("getBooksNumber", conn);
command.CommandType = CommandType.StoredProcedure;
command.Parameters.Add("@authorId", SqlDbType.Int).Value = 4;
SqlParameter outputParameter = new SqlParameter("@BookCount", SqlDbType.Int);
outputParameter.Direction = ParameterDirection.Output;
command.Parameters.Add(outputParameter);
command.ExecuteNonQuery();
Console.WriteLine(command.Parameters["@BookCount"].Value.ToString());