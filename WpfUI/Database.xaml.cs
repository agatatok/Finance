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
        DataTable dt;
               
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
            dt = new DataTable("Płatnicy");
            da.Fill(dt);

            dg_Baza.ItemsSource = dt.DefaultView;
        }

        private void AddPersonIntoBase_Click(object sender, RoutedEventArgs e)
        {
            AddPerson window1 = new AddPerson();
            window1.Show();

        }

        private void DeletePersonFromBase_Click(object sender, RoutedEventArgs e)
        {
            DataRowView Id = (DataRowView)dg_Baza.SelectedItem;
            string personId = Id.Row.ItemArray[0].ToString();
            string name = Id.Row.ItemArray[1].ToString()+" "+Id.Row.ItemArray[2].ToString();
            string message = String.Format("Czy na pewno chcesz usunąć płatnika {0}?", name);
            MessageBoxResult result = MessageBox.Show(message, "Usunięcie płatnika", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DeleteFromBase(personId);
                dt.Rows.Remove(Id.Row);
            }
        }

        private void DeleteFromBase(string personId)
        {
            string Id = personId;
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrPlatnicy"].ConnectionString))
            {
                connection.Open();

                string cmdstr = "DELETE FROM [Płatnicy] WHERE ID=@param1";
                SqlCommand cmd = new SqlCommand(cmdstr, connection);
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = personId;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
}