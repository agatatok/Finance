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

        public Load()
        {
            InitializeComponent();
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
                //File.Open(openFileDialog.FileName, FileMode.Open);
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
        }
    }
}
