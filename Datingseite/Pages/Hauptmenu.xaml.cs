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
        String allmatches = "";

        public Hauptmenu()
        {
            InitializeComponent();
            textBlockLoggeInAs.Text = "Eingeloggt als: " + Environment.NewLine + GlobaleVariabeln.username;

            loadTinders();

   
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
            Application.Current.Shutdown();
       
            
        }


        private void loadTinders()
        {
            mySqlCon.Open();

           
            int howmuchmatches = 0;

            query = "SELECT * FROM matches WHERE idUser1 = '" + GlobaleVariabeln.userid + "'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);

           // MessageBox.Show("Debug1");

            int User1 = GlobaleVariabeln.userid;
            

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int User2 = Convert.ToInt32(dt.Rows[i].ItemArray[2]);

              //      MessageBox.Show("" + User1 + " & " + User2);

                    query = "SELECT * FROM matches WHERE idUser1 = '" + User2 + "' AND idUser2 = '" + User1 + "'";
                    mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

                    DataTable dt2 = new DataTable();
                    mySqlDataAdapter.Fill(dt2);

                    if (dt2.Rows.Count > 0)
                    {
                        howmuchmatches++;

                        allmatches += howmuchmatches + ". " + User1 + " & " + User2 + " ";
                    }

                }

                MessageBox.Show(allmatches);

            }
            else
            {
                MessageBox.Show("Nix ;c");
            }

        }
    }
}
