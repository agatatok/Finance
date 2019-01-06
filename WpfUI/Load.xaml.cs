using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfUI
{
    /// <summary>
    /// Logika interakcji dla klasy Wczytaj.xaml
    /// </summary>
    public partial class Load : Window
    {
        private string source;
        public List<Month> monthlist = new List<Month>();
        public static string monthName;


  
        public Load()
        {
            InitializeComponent();
            AddPerson.FillMonthList(monthlist);
            months.ItemsSource = monthlist;
            months.SelectedIndex = PayMonthSetter();
        }
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Pliki CSV (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                tb_source.Text = openFileDialog.FileName;
                source = tb_source.Text;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Analizer analizer = new Analizer(source);
            Thread thread = new Thread(analizer.Analize);
            thread.Start();
            if (!thread.IsAlive)
            {
                thread.Abort();
            }

            Close();
            Database database = new Database();
            database.Show();
        }

        

        private int PayMonthSetter()
        {
            int month;
            int now = DateTime.Now.Month;
            if (now >= 9 && now <= 12) month = now - 8;
            else month = now + 2;
            Load.monthName = monthlist.ElementAt(month).MonthName;
            return month;
        }
    }
}
