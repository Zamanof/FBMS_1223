using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

SqlDataReader reader;
SqlConnection conn;
DataTable table;
string connecionString;
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("AppConfig.json");
var config = builder.Build();
connecionString = config.GetConnectionString("DefaultConnection")!;
conn = new SqlConnection(connecionString);

string authorName = "Boris";
SqlParameter parameter = new SqlParameter();
parameter.ParameterName = "@authorname";
parameter.SqlDbType = SqlDbType.NVarChar;
parameter.Value = authorName;

conn.Open();
SqlCommand cmd = new SqlCommand("SELECT @authorname FROM Authors;");
//cmd.Parameters.Add(parameter);
//cmd.Parameters.Add("@authorname", SqlDbType.NVarChar).Value = authorName;
cmd.Parameters.AddWithValue("@authorname", authorName);
