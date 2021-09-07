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

namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Hauptmenu.xaml
    /// </summary>
    public partial class Hauptmenu : Page
    {
        MySqlConnection mySqlCon;
        string query;
        public Hauptmenu()
        {
            InitializeComponent();
            textBlockLoggeInAs.Text = "Eingeloggt als: "+ Environment.NewLine + GlobaleVariabeln.loggedInUser;

            mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);

            query = "SELECT username,vorname,geburtsdatum FROM user";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);

            matchesDatagrid.ItemsSource = dt.DefaultView;
            

        }
    }
}
