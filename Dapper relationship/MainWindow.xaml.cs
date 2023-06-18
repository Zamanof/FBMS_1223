using Dapper;
using Dapper_relationship.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dapper_relationship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var cs = @"Server=(localdb)\MSSQLLocalDB;Database=Dapper_relationship;Integrated Security=True;TrustServerCertificate=True;";
            // One to one
            using (var conn = new SqlConnection(cs))
            {
                var sql =
                    @"SELECT * 
                      FROM Capitals
                      INNER JOIN Countries
                      ON Countries.Id = Capitals.CountryId";
                var result = conn.Query<Capital, Country, Capital>(sql, 
                    (capital, country) =>
                    {
                        capital.Country = country;
                        return capital;
                    });
                dataGrid.ItemsSource = result;
            }
        }
    }
}
