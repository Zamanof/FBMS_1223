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

string authorName = "";
SqlParameter parameter = new SqlParameter();
parameter.ParameterName = "@authorname";
parameter.SqlDbType = SqlDbType.NVarChar;
