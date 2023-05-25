
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data_table
{
    public partial class Form1 : Form
    {
        private SqlDataReader reader;
        private SqlConnection conn;
        private DataTable table;
        string connecionString;

        public Form1()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("AppConfig.json");
            var config = builder.Build();
            connecionString = config.GetConnectionString("DefaultConnection")!;

            conn = new SqlConnection(connecionString);

        }

        private void execButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = queryTextBox.Text;
                command.Connection = conn;
                conn.Open();
                table = new DataTable();
                reader = command.ExecuteReader();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow dr = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dr[i] = reader[i];
                        }
                        table.Rows.Add(dr);
                    }

                } while (reader.NextResult());
                dataGridView1.DataSource = table;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }

        }
    }
}