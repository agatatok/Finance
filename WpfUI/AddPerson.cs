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

namespace WpfUI
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
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


        public AddPerson()
        {
            InitializeComponent();
            FillMonthList(monthlist);
            months.ItemsSource = monthlist;
            months.SelectedIndex = MonthSetter(); 

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text.Length == 0 || firstNameText.Text.Length == 0 || lastNameText.Text.Length == 0
                || phoneNumber.Text.Length == 0 || firstPayment.Text.Length == 0)
            {
                string message_SthMissing = $"Wypełnij wszystkie pola.";
                MessageBoxResult message = MessageBox.Show(message_SthMissing);

            }
            //else if (!Regex.IsMatch(email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@
            //                            [a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            //{
            //    string message_Email = $"Błędny adres e-mail.";
            //    MessageBoxResult message = MessageBox.Show(message_Email);
            //    email.Select(0, email.Text.Length);
            //    email.Focus();
            //}
            else
            {
//                INSERT INTO table_name(column1, column2, column3, ...)
//VALUES(value1, value2, value3, ...);
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
                Database.People.Add(newPerson);


                string messageAdd = $"Nowy płatnik {newPerson.Nazwisko} {newPerson.Imię} został dodany pomyślnie.";
                MessageBoxResult message = MessageBox.Show(messageAdd);
                this.Close();
                Database window = new Database();
                window.Show();
            }
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

    }
}