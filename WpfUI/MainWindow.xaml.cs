using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPerson window1 = new AddPerson();
            window1.Show();
        }

        private void InputStatement_Click(object sender, RoutedEventArgs e)
        {
            Load window2 = new Load();
            window2.Show();
        }

        private void SeeBase_Click(object sender, RoutedEventArgs e)
        {
            Database window3 = new Database();
            window3.Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę programu?", "Zakończ", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) Close();
        }
    }
    }

