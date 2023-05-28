
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace disconnectedMode
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter dataAdapter = null;
        DataSet dataSet = null;
        SqlCommandBuilder cmd = null;
        string connectionString = "";
        public Form1()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("AppConfig.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection")!;
            conn = new SqlConnection(connectionString);
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet = new DataSet();
                string sqlQuery = queryTextBox.Text;
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataGridView1.DataSource = null;
                cmd = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataSet, "mybook");
                dataGridView1.DataSource = dataSet.Tables["mybook"];
                Debug.WriteLine(cmd.GetUpdateCommand().CommandText);
                Debug.WriteLine(cmd.GetInsertCommand().CommandText);
                Debug.WriteLine(cmd.GetDeleteCommand().CommandText);
            }
            catch (Exception)
            {
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dataAdapter.Update(dataSet, "mybook");


        }
    }
}