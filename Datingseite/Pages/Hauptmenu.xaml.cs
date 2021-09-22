using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using Microsoft.Win32;






namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Hauptmenu.xaml
    /// </summary>
    public partial class Hauptmenu : Page
    {
        MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
        string query;
        public Hauptmenu()
        {
            InitializeComponent();
            textBlockLoggeInAs.Text = "Eingeloggt als: " + Environment.NewLine + GlobaleVariabeln.username;



            query = "SELECT username,vorname,geburtsdatum FROM user";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);

            matchesDatagrid.ItemsSource = dt.DefaultView;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Tinderseite tinderseite = new Tinderseite();
            NavigationService.Navigate(tinderseite);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
