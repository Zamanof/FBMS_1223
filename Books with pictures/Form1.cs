using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Books_with_pictures
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter dataAdapter = null;
        DataSet dataSet = null;
        SqlCommandBuilder cmd = null;
        string connectionString = "";
        string fileName = "";
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

        private void loadPictureMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Graphics File|*.bmp;*.gif;*.jpg;*.png";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                LoadPicture();
            }
        }

        private void LoadPicture()
        {
            try
            {
                byte[] bytes;
                bytes = CreateCopy();
                conn.Open();
                SqlCommand command = 
                    new SqlCommand(@"INSERT INTO Pictures (bookId, name, picture)
VALUES(@bookId, @name, @picture)", conn);
                if (findTextBox.Text == null || findTextBox.Text.Length == 0) return;
                int index = -1;
                int.TryParse(findTextBox.Text, out index);
                if (index == -1) return;
                command.Parameters.Add("@bookId", SqlDbType.Int).Value = index;
                command.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = fileName;
                command.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).Value = bytes;
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private byte[] CreateCopy()
        {
            Image img = Image.FromFile(fileName);
            int maxWidth = 300, maxHeight = 300;
            double ratioX = (double)maxWidth/img.Width;
            double ratioY = (double)maxHeight/img.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(img.Width * ratio); 
            int newHeight = (int)(img.Height * ratio);
            Image mi = new Bitmap(newWidth, newHeight);
            Graphics graphics = Graphics.FromImage(mi);
            graphics.DrawImage(mi, 0 , 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] bytes = br.ReadBytes((int)ms.Length);
            return bytes;
        }

        private void showAllMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM Pictures", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "picture");
                booksDataGrid.DataSource = dataSet.Tables["picture"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showOneMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (findTextBox.Text == null || findTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please enter book id");
                    return;
                }
                int index = -1;
                int.TryParse(findTextBox.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Incorrect format for book id");
                    return ;
                }
                dataAdapter = new SqlDataAdapter(@"SELECT picture FROM Pictures
WHERE id = @id", conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = index;
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                byte[] bytes = (byte[])dataSet.Tables[0].Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(bytes);
                coverPictureBox.Image = Image.FromStream(ms);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}