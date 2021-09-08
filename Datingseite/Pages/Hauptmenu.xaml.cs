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
            textBlockLoggeInAs.Text = "Eingeloggt als: "+ Environment.NewLine + GlobaleVariabeln.loggedInUser;

           

            query = "SELECT username,vorname,geburtsdatum FROM user";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);

            matchesDatagrid.ItemsSource = dt.DefaultView;
            

        }
        void saveImgageInDB(string bildPfad)
        {
            byte[] blob = File.ReadAllBytes(bildPfad);
            var cmd = new MySqlCommand("INSERT INTO user (idUser,profilbild) VALUES (1, (@test))", mySqlCon);
            MySqlParameter param = new MySqlParameter("@test", MySqlDbType.LongBlob);
            param.Value = blob;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestseitePage1 testseitePage = new TestseitePage1();
            NavigationService.Navigate(testseitePage);
        }
    }
}
