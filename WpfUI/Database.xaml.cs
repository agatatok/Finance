using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlServerCe;
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
using System.Windows.Shapes;
using System.Configuration;

namespace WpfUI
{
    /// <summary>
    /// Logika interakcji dla klasy Baza.xaml
    /// </summary>
    public partial class Database : Window
    {
        static ObservableCollection<Person> people = new ObservableCollection<Person>();
        public static ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
        }
        
        public Database()
        {
           InitializeComponent();
            BindDataGrid();

        }

        private void BindDataGrid()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connstrPlatnicy"].ConnectionString;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Płatnicy]";
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Płatnicy");
            da.Fill(dt);

            dg_Baza.ItemsSource = dt.DefaultView;
        }

        private void AddPersonIntoBase_Click(object sender, RoutedEventArgs e)
        {
            AddPerson window1 = new AddPerson();
            window1.Show();

        }
        

    }
}