using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WpfUI
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();
            firstNameText.Focus();
            FillMonthList(monthlist);
            months.ItemsSource = monthlist;
            months.SelectedIndex = MonthSetter();

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationIfEmpty()) { }

            else
            {
                Person newPerson = CreatePerson();
                InsertIntoDatabase(newPerson);

                string message_Added = $"Nowy płatnik {newPerson.Nazwisko} {newPerson.Imię} został dodany pomyślnie.";
                MessageBoxResult message = MessageBox.Show(message_Added);
                this.Close();
                Database window = new Database();
                window.Show();
            }
        }

        private void InsertIntoDatabase(Person Person)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrPlatnicy"].ConnectionString))
            {
                connection.Open();

                string cmdstr = "INSERT INTO [Płatnicy](Nazwisko, Imię) VALUES(@param1,@param2)";
                //string cmdstr = "INSERT INTO [Płatnicy](Nazwisko, Imię, email, [Numer telefonu], [Opłata wpisowa]) VALUES(@param1,@param2,@param3,param4,@param5)";
                SqlCommand cmd = new SqlCommand(cmdstr, connection);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = Person.Nazwisko;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = Person.Imię;
                //cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = Person.Email;
                //cmd.Parameters.Add("@param4", SqlDbType.Int).Value = Person.Nrtel;
                //cmd.Parameters.Add("@param5", SqlDbType.Int).Value = Person.OpłataWpisowa;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }


        public List<Month> monthlist = new List<Month>();
        public void FillMonthList(List<Month> monthlist)
        {
            monthlist.Add(new Month("Wrzesień"));
            monthlist.Add(new Month("Październik"));
            monthlist.Add(new Month("Listopad"));
            monthlist.Add(new Month("Grudzień"));
            monthlist.Add(new Month("Styczeń"));
            monthlist.Add(new Month("Luty"));
            monthlist.Add(new Month("Marzec"));
            monthlist.Add(new Month("Kwiecień"));
            monthlist.Add(new Month("Maj"));
            monthlist.Add(new Month("Czerwiec"));
        }
        
       
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public int MonthSetter()
        {
            int nextmonth;
            int now = DateTime.Now.Month;
            if (now >= 9 && now <= 12) nextmonth = now - 8;
            else nextmonth = now + 4;
            return nextmonth;
        }

        private bool ValidationIfEmpty()
        {
            if (firstNameText.Text.Length == 0 || lastNameText.Text.Length == 0
                || phoneNumber.Text.Length == 0 || firstPayment.Text.Length == 0)
            {
                string message_SthMissing = $"Wypełnij wszystkie pola.";
                MessageBoxResult message = MessageBox.Show(message_SthMissing);
                return true;
            }
            else { return false; }
        }

        private Person CreatePerson()
        {
            Person newPerson = new Person
            {
                Imię = firstNameText.Text,
                Nazwisko = lastNameText.Text,
                Email = email.Text,
                Nrtel = Int32.Parse(phoneNumber.Text),
                OpłataWpisowa = Double.Parse(firstPayment.Text)
            };
            int miesiac = months.SelectedIndex;
            newPerson.FullFillMonths(miesiac);
            return newPerson;
        }

    }
}
